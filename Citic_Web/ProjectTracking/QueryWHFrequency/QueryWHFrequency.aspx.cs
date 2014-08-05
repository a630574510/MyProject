using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using FineUI;

namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class QueryWHFrequency : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
                RoleValidate();
                this.btn_Save.Enabled = false;
            }
        }

        #region PrivateFields--乔春羽(2013.12.6)
        public DataTable DtSource
        {
            get { return ViewState["DtSource"] as DataTable; }
            set { ViewState["DtSource"] = value; }
        }
        #endregion

        #region 绑定数据--乔春羽
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件
            string where = ConditionInit();
            try
            {
                DtSource = QueryWH.GetList(where, "ID").Tables[0];

                grid_List.DataSource = DtSource;
                grid_List.DataBind();
                if (DtSource != null && DtSource.Rows.Count > 0)
                {
                    this.btn_Save.Enabled = true;
                }
                else
                {
                    this.btn_Save.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                AlertShow(ex.Message);
                Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "GridBind()");
            }
        }

        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return QueryWH.GetRecordCountBySearch(where);
        }

        /// <summary>
        /// 绑定银行信息--乔春羽
        /// </summary>
        private void BankDataBind()
        {
            ddl_Bank.Items.Clear();
            string val = this.txt_DealerName.Text;
            if (!string.IsNullOrEmpty(val))
            {
                if (val.IndexOf('_') >= 0)
                {
                    DataTable dt = Dealer_BankBll.GetList(string.Format(" ( DealerID='{0}' or DealerName like '%{1}%' )and CollaborateType=1", val.Split('_')[1], val.Split('_')[0])).Tables[0];

                    this.ddl_Bank.DataTextField = "BankName";
                    this.ddl_Bank.DataValueField = "BankID";
                    this.ddl_Bank.DataSource = dt;
                    this.ddl_Bank.DataBind();
                }
            }
            else    //将品牌去掉
            {
                this.lbl_Brand.Text = string.Empty;
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder(" CollaborateType = 1 ");

            if (!string.IsNullOrEmpty(this.txt_DealerName.Text))
            {
                where.AppendFormat(" and DealerName like '%{0}%'", this.txt_DealerName.Text.Split('_')[0]);
            }
            if (this.ddl_Bank.SelectedValue != "-1")
            {
                where.AppendFormat(" and BankID = '{0}'", this.ddl_Bank.SelectedValue);
            }
            if (!string.IsNullOrEmpty(this.txt_cf.Text))
            {
                where.AppendFormat(" and CheckFrequency like '%{0}%'", this.txt_cf.Text);
            }
            if (this.dp_ApplyTimeSearch.SelectedDate != null)
            {
                DateTime time = dp_ApplyTimeSearch.SelectedDate.Value;
                where.AppendFormat(" and ApplyTime between '{0}' and '{1}'", time.AddDays(-1), time.AddDays(1));
            }
            return where.ToString();
        }
        #endregion

        #region 经销商被输入后，联动出合作行--乔春羽(2013.12.6)
        protected void txt_DealerName_TextChanged(object sender, EventArgs e)
        {
            BankDataBind();
        }
        #endregion

        #region 查询--乔春羽(2013.12.6)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 关闭窗口--乔春羽(2013.12.6)
        protected void Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {

        }
        #endregion

        #region 保存修改--乔春羽(2013.12.6)
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, string>> modifiedDict = grid_List.GetModifiedDict();

            foreach (int rowIndex in modifiedDict.Keys)
            {
                if (modifiedDict[rowIndex].ContainsKey("check") && modifiedDict[rowIndex]["check"].Equals("True"))
                {
                    int rowID = Convert.ToInt32(grid_List.DataKeys[rowIndex][0]);
                    DataRow row = FindRowByID(rowID);

                    Dictionary<string, string> dict = modifiedDict[rowIndex];
                    //查库频率
                    if (dict.ContainsKey("CheckFrequency"))
                    {
                        row["CheckFrequency"] = dict["CheckFrequency"];
                    }
                    //描述
                    if (dict.ContainsKey("Description"))
                    {
                        row["Description"] = dict["Description"];
                    }
                    //备注
                    if (dict.ContainsKey("Remark"))
                    {
                        row["Remark"] = dict["Remark"];
                    }
                    if (dict.ContainsKey("ApplyTime"))
                    {
                        row["ApplyTime"] = dict["ApplyTime"];
                    }
                }
            }
            int num = 0;
            try
            {
                //生成实体类对象
                List<Citic.Model.QueryWH> models = new List<Citic.Model.QueryWH>();
                foreach (DataRow row in DtSource.Rows)
                {
                    Citic.Model.QueryWH model = new Citic.Model.QueryWH();
                    model.CheckFrequency = row["CheckFrequency"].ToString();
                    model.DB_ID = row["DealerID"] + "_" + row["BankID"];
                    model.Description = row["Description"].ToString();
                    model.Remark = row["Remark"].ToString();
                    model.CreateID = this.CurrentUser.UserId;
                    model.CreateTime = DateTime.Now;
                    model.ApplyTime = Convert.ToDateTime(row["ApplyTime"]);
                    models.Add(model);
                }

                num = QueryWH.Updates(models.ToArray());
            }
            catch (Exception ex)
            {
                AlertShow(ex.Message);
                Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "btn_Add_Click()");
            }
            if (num > 0)
            {
                AlertShowInTop("修改成功！");
                GridBind();
            }
            else
            {
                AlertShowInTop("修改失败！");
            }
        }

        private DataRow FindRowByID(int rowID)
        {
            foreach (DataRow row in DtSource.Rows)
            {
                if (Convert.ToInt32(row["ID"]) == rowID)
                {
                    return row;
                }
            }
            return null;
        }
        #endregion

        #region //权限过滤-判断登陆角色，显示不同的按钮--乔春羽(2013.9.3)
        /// <summary>
        /// 按钮权限过滤
        /// </summary>
        private void RoleValidate()
        {
            DataTable dt = GetMenusByCurrentUserRoleID(false);
            List<string> urls = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                urls.Add(row["MenuUrl"].ToString());
            }
            if (urls.Contains("Search76"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert31"))
            {
            }
            if (urls.Contains("Delete31"))
            {

            }
            if (urls.Contains("Modify76"))
            {
                this.btn_Save.Visible = true;
            }
            if (urls.Contains("Excel31"))
            {
            }
            if (urls.Contains("Match31"))
            {
            }
        }
        #endregion

        #region 选择合作行，带出品牌--乔春羽(2013.12.23)
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txt_DealerName.Text) && !string.IsNullOrEmpty(this.ddl_Bank.SelectedValue) && this.ddl_Bank.SelectedValue != "-1")
            {
                DataTable dt = Dealer_BankBll.GetBrands(string.Format(" DealerID={0} and BankID='{1}' ", this.txt_DealerName.Text.Split('_')[1], this.ddl_Bank.SelectedValue)).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.lbl_Brand.Text = dt.Rows[0]["BrandName"].ToString();
                }
                else
                {
                    this.lbl_Brand.Text = "无";
                }
            }
        }
        #endregion
    }
}