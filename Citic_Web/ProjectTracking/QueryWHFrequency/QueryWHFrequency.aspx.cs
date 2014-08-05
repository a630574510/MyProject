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
                //btn_Add.OnClientClick = WindowAdd.GetShowReference("../../ProjectTracking/QueryWHFrequency/AddQueryWH.aspx");
                AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
                RoleValidate();
            }
        }

        #region PrivateFields--乔春羽(2013.12.6)
        private DataTable _dtSource = null;

        public DataTable DtSource
        {
            get
            {
                if (ViewState["DtSource"] == null)
                {
                    if (_dtSource == null)
                    {
                        _dtSource = new DataTable();
                    }
                    ViewState["DtSource"] = _dtSource;
                }
                return ViewState["DtSource"] as DataTable;
            }
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
            string path = Common.OperateConfigFile.getValue("Dealer_Bank");

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            if (!string.IsNullOrEmpty(this.txt_cf.Text))
            {
                where += string.Format(" and CheckFrequency like '%{0}%'", this.txt_cf.Text);
            }

            if (this.grid_List.PageCount < this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = Dealer_BankBll.GetDBInnerFrequencyBySearch(Server.MapPath(path), "dbinnerfrequency", where, "ID", rowbegin, rowend);
            
            grid_List.DataSource = DtSource;
            grid_List.DataBind();
        }


        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return Dealer_BankBll.GetRecordCount(where);
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
                    DataTable dt = Dealer_BankBll.GetList(string.Format(" DealerID='{0}' and CollaborateType=1", val.Split('_')[1])).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        this.ddl_Bank.DataTextField = "BankName";
                        this.ddl_Bank.DataValueField = "BankID";
                        this.ddl_Bank.DataSource = dt;
                        this.ddl_Bank.DataBind();
                    }
                }
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("IsDelete=0");

            if (!string.IsNullOrEmpty(this.txt_DealerName.Text))
            {
                where.AppendFormat(" and DealerName like '%{0}%'", this.txt_DealerName.Text.Split('_')[0]);
            }
            if (this.ddl_Bank.SelectedValue != "-1")
            {
                where.AppendFormat(" and BankID = '{0}'", this.ddl_Bank.SelectedValue);
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

        #region 每页显示数量改变事件--乔春羽
        /// <summary>
        /// 每页显示数量改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_List.PageSize = int.Parse(ddlPageSize.SelectedValue);
            GridBind();
        }
        #endregion

        #region 翻页事件--乔春羽
        /// <summary>
        /// 翻页事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);
            grid_List.PageIndex = e.NewPageIndex;

            GridBind();
            
            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
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

            //生成实体类对象
            List<Citic.Model.QueryWH> models = new List<Citic.Model.QueryWH>();
            foreach (DataRow row in DtSource.Rows)
            {
                Citic.Model.QueryWH model = new Citic.Model.QueryWH();
                model.CheckFrequency = row["CheckFrequency"].ToString();
                model.DB_ID = row["BankID"] + "_" + row["DealerID"];
                model.Description = row["Description"].ToString();
                model.Remark = row["Remark"].ToString();
                model.CreateID = this.CurrentUser.UserId;
                model.CreateTime = DateTime.Now;
                model.ApplyTime = Convert.ToDateTime(row["ApplyTime"]);
                models.Add(model);
            }
            int num = 0;
            try
            {
                num = QueryWH.Updates(models.ToArray());
            }
            catch (Exception ex)
            {
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
            if (!string.IsNullOrEmpty(this.ddl_Bank.SelectedValue) && this.ddl_Bank.SelectedValue != "-1")
            {
                DataTable dt = Dealer_BankBll.GetBrands(string.Format(" DealerID={0} and BankID='{1}' ", this.txt_DealerName.Text.Split('_')[1], this.ddl_Bank.SelectedValue)).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.lbl_Brand.Text = dt.Rows[0]["BrandName"].ToString();
                }
            }
        }
        #endregion
    }
}