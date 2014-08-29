using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

using FineUI;
namespace Citic_Web.ProjectTracking.rcquesbyday
{
    public partial class RCQuesByDayVerify : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //设置筛选时间，开始时间默认为三天前，结束时间默认为三天后
                this.dp_Start.SelectedDate = DateTime.Now.AddDays(-3).Date;
                this.dp_End.SelectedDate = DateTime.Now.Date;
                AreaBind();
                RoleValidate();
                btn_Verify.OnClientClick = grid_List.GetNoSelectionAlertReference("未选择数据！");
            }
        }

        #region PrivateField--乔春羽(2013.12.12)
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

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            if (this.grid_List.PageCount < this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DtSource = RQDBLL.GetListByPage(where, "ID", rowbegin, rowend).Tables[0];

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
            return RQDBLL.GetRecordCount(where);
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("");
            where.AppendFormat(" CreateTime BETWEEN '{0}' AND '{1}' ", dp_Start.SelectedDate, dp_End.SelectedDate.Value.AddDays(1));
            if (this.ddl_Status.SelectedValue != "-1")
            {
                where.AppendFormat(" and Status={0}", this.ddl_Status.SelectedValue);
            }
            if (!string.IsNullOrEmpty(this.txt_Dealer.Text))
            {
                if (this.txt_Dealer.Text.IndexOf('_') > 0)
                {
                    where.AppendFormat(" and DealerID='{0}'", this.txt_Dealer.Text.Split('_')[1]);
                }
            }
            if (!string.IsNullOrEmpty(this.ddl_Area.SelectedValue) && this.ddl_Area.SelectedValue != "-1")
            {
                where.AppendFormat(" and Area like '%{0}%'", this.ddl_Area.SelectedValue);
            }
            return where.ToString();
        }
        #endregion

        #region 加载区域名称--乔春羽(2013.8.21)
        private void AreaBind()
        {
            ddl_Area.Items.Clear();
            string path = "~/ProjectTracking/RiskControl/区域名称.txt";
            FileStream fs = new FileStream(Server.MapPath(path), FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string value = sr.ReadLine();
                AddItemByInsert(ddl_Area, value, value, -1);
            }
            sr.Close();
            fs.Close();
            AddItemByInsert(ddl_Area, "请选择", "-1", 0);
            ddl_Area.SelectedIndex = 0;
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

            //乔春羽
            GridBind();
            //乔春羽

            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
        }
        #endregion

        #region 查询--乔春羽(2013.12.9)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
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
            ViewState.Add("roles", urls);
            if (urls.Contains("Search78"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Verify78"))
            {
                btn_Verify.Visible = true;
            }
        }
        #endregion

        #region 审核数据--乔春羽(2013.12.12)
        protected void btn_Verify_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, string>> modifiedDict = grid_List.GetModifiedDict();

            List<int> selectedIndex = new List<int>();

            foreach (GridRow row in grid_List.Rows)
            {
                if (row.Values[0] == "True")
                {
                    selectedIndex.Add(row.RowIndex);
                }
            }

            foreach (int index in selectedIndex)
            {
                int rowID = Convert.ToInt32(grid_List.DataKeys[index][0]);
                DataRow row = FindRowByID(rowID);
                Dictionary<string, string> dict = modifiedDict[index];

                if (dict.ContainsKey("CY_Market"))
                {
                    row["CY_Market"] = dict["CY_Market"];
                }
                if (dict.ContainsKey("CY_Business"))
                {
                    row["CY_Business"] = dict["CY_Business"];
                }
                if (dict.ContainsKey("QC_Market"))
                {
                    row["QC_Market"] = dict["QC_Market"];
                }
                if (dict.ContainsKey("QC_Business"))
                {
                    row["QC_Business"] = dict["QC_Business"];
                }
                if (dict.ContainsKey("ManCenter"))
                {
                    row["ManCenter"] = dict["ManCenter"];
                }
                if (dict.ContainsKey("XZ"))
                {
                    row["XZ"] = dict["XZ"];
                }
                if (dict.ContainsKey("Remark"))
                {
                    row["Remark"] = dict["Remark"];
                }
            }
            List<Citic.Model.RiskQuesDay> models = new List<Citic.Model.RiskQuesDay>();

            foreach (int index in selectedIndex)
            {
                int rowID = Convert.ToInt32(grid_List.DataKeys[index][0]);
                DataRow row = FindRowByID(rowID);
                Citic.Model.RiskQuesDay model = new Citic.Model.RiskQuesDay()
                {
                    ID = Convert.ToInt32(row["ID"]),
                    CY_Market = row["CY_Market"].ToString(),
                    CY_Business = row["CY_Business"].ToString(),
                    QC_Market = row["QC_Market"].ToString(),
                    QC_Business = row["QC_Business"].ToString(),
                    ManCenter = row["ManCenter"].ToString(),
                    XZ = row["XZ"].ToString(),
                    Remark = row["Result"].ToString()
                };
                models.Add(model);
            }

            int num = RQDBLL.UpdateRange(models.ToArray());
            if (num > 0)
            {
                Alert.ShowInTop("审核通过！");
                GridBind();
            }
            else
            {
                Alert.ShowInTop("审核失败！");
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

    }
}