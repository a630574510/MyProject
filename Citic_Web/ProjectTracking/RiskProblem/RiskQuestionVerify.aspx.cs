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
    public partial class RiskQuestionVerify : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoleValidate();
                btn_Verify.OnClientClick = grid_List.GetNoSelectionAlertReference("未选择数据！");
            }
        }
        #region PrivateField--乔春羽(2013.12.9)
        public DataTable DtSource
        {
            get
            {
                return ViewState["DtSource"] as DataTable;
            }
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
            DtSource = RQBLL.GetListByPage(where, "ID", rowbegin, rowend).Tables[0];

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
            return RQBLL.GetRecordCount(where);
        }


        /// <summary>
        /// 绑定银行信息--乔春羽
        /// </summary>
        //private void BankDataBind()
        //{
        //    ddl_Bank.Items.Clear();
        //    string val = this.txt_DealerName.Text;
        //    if (!string.IsNullOrEmpty(val))
        //    {
        //        if (val.IndexOf('_') >= 0)
        //        {
        //            DataTable dt = Dealer_BankBll.GetList(string.Format(" DealerID='{0}' and CollaborateType=1", val.Split('_')[1])).Tables[0];

        //            this.ddl_Bank.DataTextField = "BankName";
        //            this.ddl_Bank.DataValueField = "BankID";
        //            this.ddl_Bank.DataSource = dt;
        //            this.ddl_Bank.DataBind();
        //        }
        //    }
        //    AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        //}

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("");
            if (this.ddl_Status.SelectedValue != "-1")
            {
                where.AppendFormat(" Status={0}", this.ddl_Status.SelectedValue);
            }
            return where.ToString();
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
            if (urls.Contains("Search77"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Verify77"))
            {
                btn_Verify.Visible = true;
            }
        }
        #endregion

        #region 审核数据--乔春羽(2013.12.9)
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
                if (dict.ContainsKey("WTCLBF"))
                {
                    row["WTCLBF"] = dict["WTCLBF"];
                }
                if (dict.ContainsKey("FXWTBMQZ"))
                {
                    row["FXWTBMQZ"] = dict["FXWTBMQZ"];
                }
                if (dict.ContainsKey("QCJRZXYJ"))
                {
                    row["QCJRZXYJ"] = dict["QCJRZXYJ"];
                }
                if (dict.ContainsKey("QCJRZXQZ"))
                {
                    row["QCJRZXQZ"] = dict["QCJRZXQZ"];
                }
                if (dict.ContainsKey("GLZXYJ"))
                {
                    row["GLZXYJ"] = dict["GLZXYJ"];
                }
                if (dict.ContainsKey("GLZXQZ"))
                {
                    row["GLZXQZ"] = dict["GLZXQZ"];
                }
            }


            List<Citic.Model.RiskQuestion> models = new List<Citic.Model.RiskQuestion>();
            foreach (int index in selectedIndex)
            {
                int rowID = Convert.ToInt32(grid_List.DataKeys[index][0]);
                DataRow row = FindRowByID(rowID);
                Citic.Model.RiskQuestion model = new Citic.Model.RiskQuestion()
                {
                    ID = Convert.ToInt32(row["ID"]),
                    WTCLBF = row["WTCLBF"].ToString(),
                    FXWTBMQZ = row["FXWTBMQZ"].ToString(),
                    QCJRZXYJ = row["QCJRZXYJ"].ToString(),
                    QCJRZXQZ = row["QCJRZXQZ"].ToString(),
                    GLZXYJ = row["GLZXYJ"].ToString(),
                    GLZXQZ = row["GLZXQZ"].ToString()
                };
                models.Add(model);
            }

            int num = RQBLL.UpdateRange(models.ToArray());
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