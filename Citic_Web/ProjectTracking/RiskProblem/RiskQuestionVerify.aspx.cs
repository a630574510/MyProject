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
        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoleValidate();
                btn_Verify.OnClientClick = grid_List.GetNoSelectionAlertReference("未选择数据！");
            }
        }
        #endregion

        #region Page_Init
        protected void Page_Init(object sender, EventArgs e)
        {
            //获得“问题提交人”的上级角色ID
            int currentRole = this.CurrentUser.RoleId;
            //int bossRoleID = int.Parse(this.DeptToRole.GetBossRoleID(currentRole.ToString()));
            switch (currentRole)
            {
                case 27:    //风控专员
                    //风控部意见
                    ORCD.HideMode = HideMode.Display;
                    ORCD.Hidden = false;
                    txt_ORCD.Enabled = true;
                    //发现问题部门意见
                    OPFD.HideMode = HideMode.Display;
                    OPFD.Hidden = false;
                    txt_OPFD.Enabled = true;

                    SQ_Content.HideMode = HideMode.Display;
                    SQ_Content.Hidden = false;
                    txt_SQ_Content.Enabled = true;
                    break;
                case 28:    //风控经理
                    //风控部意见
                    ORCD.HideMode = HideMode.Display;
                    ORCD.Hidden = false;
                    txt_ORCD.Enabled = true;
                    //发现问题部门意见
                    OPFD.HideMode = HideMode.Display;
                    OPFD.Hidden = false;
                    txt_OPFD.Enabled = true;
                    //风控部负责人签字
                    ORCDPIC.HideMode = HideMode.Display;
                    ORCDPIC.Hidden = false;
                    break;
                case 6:     //业务专员
                    //业务部意见
                    OBD.HideMode = HideMode.Display;
                    OBD.Hidden = false;
                    txt_OBD.Enabled = true;
                    break;
                case 3:     //业务经理
                    //业务部意见
                    OBD.HideMode = HideMode.Display;
                    OBD.Hidden = false;
                    txt_OBD.Enabled = true;
                    OBDPIC.HideMode = HideMode.Display;
                    OBDPIC.Hidden = false;
                    break;
                case 29:    //运营经理
                    Result.HideMode = HideMode.Display;
                    Result.Hidden = false;
                    txt_Result.Enabled = true;
                    ResultPIC.HideMode = HideMode.Display;
                    ResultPIC.Hidden = false;
                    break;
                case 30:    //运营专员
                    Result.HideMode = HideMode.Display;
                    Result.Hidden = false;
                    txt_Result.Enabled = true;
                    break;
                case 1:     //超级管理员
                    OPFD.HideMode = HideMode.Display;
                    OPFD.Hidden = false;
                    OPFDPIC.HideMode = HideMode.Display;
                    OPFDPIC.Hidden = false;
                    ORCD.HideMode = HideMode.Display;
                    ORCD.Hidden = false;
                    ORCDPIC.HideMode = HideMode.Display;
                    ORCDPIC.Hidden = false;
                    OBD.HideMode = HideMode.Display;
                    OBD.Hidden = false;
                    OBDPIC.HideMode = HideMode.Display;
                    OBDPIC.Hidden = false;
                    Result.HideMode = HideMode.Display;
                    Result.Hidden = false;
                    ResultPIC.HideMode = HideMode.Display;
                    ResultPIC.Hidden = false;
                    break;
            }
        }
        #endregion

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
            DtSource = this.RSDBLL.GetListByPage(where, "ID", rowbegin, rowend).Tables[0];

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
            return this.RSDBLL.GetRecordCount(where);
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("1=1");
            string dealerVal = this.txt_Dealer.Text;
            if (!string.IsNullOrEmpty(dealerVal) && dealerVal.IndexOf('_') > 0)
            {
                where.AppendFormat(" AND (SQ_ShopID = '{0}' or SQ_Shop like '%{1}%') ", dealerVal.Split('_')[1], dealerVal.Split('_')[0]);
            }
            if (this.ddl_Status.SelectedValue != "-1")
            {
                where.AppendFormat(" AND Status={0}", this.ddl_Status.SelectedValue);
            }
            //权限过滤
            switch (this.CurrentUser.RoleId)
            {
                case 27:    //风控专员
                    where.Append(" AND (OPFD = '' or OPFD IS NULL) and (OPFDPIC = 0 or OPFDPIC IS NULL) and (ORCD = '' or ORCD IS NULL) and (ORCDPIC = 0 or ORCDPIC IS NULL) and (OBD = '' or OBD IS NULL) and (OBDPIC = 0 or OBDPIC IS NULL) and (Result = '' or Result IS NULL) and (ResultPIC = 0 or ResultPIC IS NULL) ");
                    break;
                case 28:    //风控经理
                    where.Append(" AND (OPFD <> '' or OPFD IS NOT NULL) and (OPFDPIC = 0 or OPFDPIC IS NULL) and (ORCD <> '' or ORCD IS NOT NULL) and (ORCDPIC = 0 or ORCDPIC IS NULL) and (OBD = '' or OBD IS NULL) and (OBDPIC = 0 or OBDPIC IS NULL) and (Result = '' or Result IS NULL) and (ResultPIC = 0 or ResultPIC IS NULL) ");
                    break;
                case 6:     //业务专员
                    where.Append(" AND (OPFD <> '' or OPFD IS NOT NULL) and (OPFDPIC = 0 or OPFDPIC IS NULL) and (ORCD <> '' or ORCD IS NOT NULL) and ORCDPIC = 1 and (OBD = '' or OBD IS NULL) and (OBDPIC = 0 or OBDPIC IS NULL) and (Result = '' or Result IS NULL) and (ResultPIC = 0 or ResultPIC IS NULL) ");
                    break;
                case 3:     //业务经理
                    where.Append(" AND (OPFD <> '' or OPFD IS NOT NULL) and (OPFDPIC = 0 or OPFDPIC IS NULL) and (ORCD <> '' or ORCD IS NOT NULL) and ORCDPIC = 1 and (OBD <> '' or OBD IS NOT NULL) and (OBDPIC = 0 or OBDPIC IS NULL) and (Result = '' or Result IS NULL) and (ResultPIC = 0 or ResultPIC IS NULL) ");
                    break;
                case 29:    //运营经理
                    where.Append(" AND (OPFD <> '' or OPFD IS NOT NULL) and (OPFDPIC = 0 or OPFDPIC IS NULL) and (ORCD <> '' or ORCD IS NOT NULL) and ORCDPIC = 1 and (OBD <> '' or OBD IS NOT NULL) and OBDPIC = 1 and (Result <> '' or Result IS NOT NULL) and (ResultPIC = 0 or ResultPIC IS NULL) ");
                    break;
                case 30:    //运营专员
                    where.Append(" AND (OPFD <> '' or OPFD IS NOT NULL) and (OPFDPIC = 0 or OPFDPIC IS NULL) and (ORCD <> '' or ORCD IS NOT NULL) and ORCDPIC = 1 and (OBD <> '' or OBD IS NOT NULL) and OBDPIC = 1 and (Result = '' or Result IS NULL) and (ResultPIC = 0 or ResultPIC IS NULL) ");
                    break;
                case 1:     //超级管理员
                    break;
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

            List<Citic.Model.RisksSolveDocuments> models = new List<Citic.Model.RisksSolveDocuments>();
            foreach (int index in selectedIndex)
            {
                int rowID = Convert.ToInt32(grid_List.DataKeys[index][0]);
                DataRow row = FindRowByID(rowID);
                Citic.Model.RisksSolveDocuments model = RSDBLL.DataRowToModel(row);
                Dictionary<string, string> dict = modifiedDict[index];
                if (dict.ContainsKey("SQ_Content"))
                {
                    //row["SQ_Content"] = dict["SQ_Content"];
                    model.SQ_Content = dict["SQ_Content"];
                }
                if (dict.ContainsKey("OPFD"))
                {
                    //row["OPFD"] = dict["OPFD"];
                    model.OPFD = dict["OPFD"];
                    model.OPFD_OptionID = this.CurrentUser.UserId;
                }
                if (dict.ContainsKey("OPFDPIC"))
                {
                    //row["OPFDPIC"] = dict["OPFDPIC"];
                    model.OPFDPIC = Convert.ToBoolean(dict["OPFDPIC"]);
                    model.OPFDPIC_OptionID = this.CurrentUser.UserId;
                }
                if (dict.ContainsKey("ORCD"))
                {
                    //row["ORCD"] = dict["ORCD"];
                    model.ORCD = dict["ORCD"];
                    model.ORCD_OptionID = this.CurrentUser.UserId;
                }
                if (dict.ContainsKey("ORCDPIC"))
                {
                    //row["ORCDPIC"] = dict["ORCDPIC"];
                    model.ORCDPIC = Convert.ToBoolean(dict["ORCDPIC"]);
                    model.ORCDPIC_OptionID = this.CurrentUser.UserId;
                }
                if (dict.ContainsKey("OBD"))
                {
                    //row["OBD"] = dict["OBD"];
                    model.OBD = dict["OBD"];
                    model.OBD_OptionID = this.CurrentUser.UserId;
                }
                if (dict.ContainsKey("OBDPIC"))
                {
                    //row["OBDPIC"] = dict["OBDPIC"];
                    model.OBDPIC = Convert.ToBoolean(dict["OBDPIC"]);
                    model.OBDPIC_OptionID = this.CurrentUser.UserId;
                }
                if (dict.ContainsKey("Result"))
                {
                    //row["Result"] = dict["Result"];
                    model.Result = dict["Result"];
                    model.Result_OptionID = this.CurrentUser.UserId;
                }
                if (dict.ContainsKey("ResultPIC"))
                {
                    //row["ResultPIC"] = dict["ResultPIC"];
                    model.ResultPIC = Convert.ToBoolean(dict["ResultPIC"]);
                    model.ResultPIC_OptionID = this.CurrentUser.UserId;
                }

                models.Add(model);
            }

            int num = RSDBLL.UpdateRange(models, this.CurrentUser.RoleId);
            if (num > 0)
            {
                AlertShowInTop("提交成功！");
                GridBind();
            }
            else
            {
                AlertShowInTop("提交失败！");
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