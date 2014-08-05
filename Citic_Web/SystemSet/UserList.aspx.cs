using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FineUI;
namespace Citic_Web.SystemSet
{
    public partial class UserList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAddUser.OnClientClick = WindowAddUser.GetShowReference("../SystemSet/AddUser.aspx");
                btnDeleteUser.OnClientClick = GvUser.GetNoSelectionAlertReference("请至少选择一项！");
                btnDeleteUser.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", GvUser.GetSelectedCountReference());
                btn_Modify.OnClientClick = GvUser.GetNoSelectionAlertReference("请至少选择一项！");
                btn_Match.OnClientClick = GvUser.GetNoSelectionAlertReference("请至少选择一项！");
                btn_ToRole.OnClientClick = GvUser.GetNoSelectionAlertReference("请至少选择一项！");
                //权限过滤
                RoleValidate();
            }
        }
        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(GvUser, hfSelectedIDS);

            string[] DelUser = hfSelectedIDS.Text.Trim().Replace("[", "").Replace("]", "").Split(',');
            for (int i = 0; i < DelUser.Length; i++)
            {
                Citic.Model.User UserInfo = UserBll.GetModel(Convert.ToInt32(DelUser[i].Replace("\"", "")));
                if (UserInfo != null)
                {
                    UserInfo.IsDelete = false;
                    UserInfo.DeleteUser = CurrentUser.UserId;
                    UserInfo.DeleteTime = DateTime.Now;
                    UserBll.Update(UserInfo);
                }
            }
            BindGrid();
        }
        private void BindGrid()
        {
            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            GvUser.RecordCount = GetTotalCount();

            //设置查询条件--乔春羽
            string where = ConditionInit();

            // 2.获取当前分页数据--乔春羽
            int pageIndex = GvUser.PageIndex;
            int pageSize = GvUser.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = UserBll.GetListByPage(where, "CreateTime", rowbegin, rowend).Tables[0];

            // 3.绑定到Grid
            GvUser.DataSource = dt;
            GvUser.DataBind();
        }

        /// <summary>
        /// 获得查询条件--乔春羽(2013.8.27)
        /// </summary>
        /// <returns></returns>
        public string ConditionInit()
        {
            StringBuilder sbuilder = new StringBuilder(" T.IsDelete=0 and T.UserType=1 ");
            if (!string.IsNullOrEmpty(this.ttbSearch.Text))
            {
                sbuilder.AppendFormat(" and T.UserName like '%{0}%'", ttbSearch.Text);
            }
            return sbuilder.ToString();
        }

        /// <summary>
        /// 返回总项数
        /// </summary>
        /// <returns></returns>
        private int GetTotalCount()
        {
            return UserBll.GetRecordCount(" IsDelete=0");
        }

        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment; filename=MyExcelFile.xls");
            Response.ContentType = "application/excel";
            Response.Write(GetGridTableHtml(GvUser));
            Response.End();
        }
        protected void GvUser_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(GvUser, hfSelectedIDS);

            GvUser.PageIndex = e.NewPageIndex;
            BindGrid();

            UpdateSelectedRowIndexArray(GvUser, hfSelectedIDS);
        }

        #region 行选择事件--乔春羽(2013.8.27)
        protected void GvUser_OnRowSelect(object sender, FineUI.GridRowSelectEventArgs e)
        {

        }
        #endregion

        #region 行点击事件--乔春羽(2013.8.27)
        protected void GvUser_OnRowClick(object sender, FineUI.GridRowClickEventArgs e)
        {
        }
        #endregion


        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvUser.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            BindGrid();
        }

        //<summary>
        //关闭窗体
        //</summary>
        //<param name="sender"></param>
        //<param name="e"></param>
        protected void Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindGrid();
        }

        #region 查询事件--乔春羽(2013.8.27)
        protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
        {
            // 执行清空动作
            ttbSearch.Text = "";
            ttbSearch.ShowTrigger1 = false;
        }
        #endregion

        #region 判断登陆角色，显示不同的按钮--乔春羽(2013.9.3)
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
            if (urls.Contains("Search91"))
            {

            }
            if (urls.Contains("Insert91"))
            {
                btnAddUser.Visible = true;
            }
            if (urls.Contains("Delete91"))
            {
                btnDeleteUser.Visible = true;
            }
            if (urls.Contains("Modify91"))
            {
                btn_Modify.Visible = true;
            }
            if (urls.Contains("Excel91"))
            {
                btnExport.Visible = true;
                //hl_ExportExcel.Visible = true;
            }
            if (urls.Contains("Match91"))
            {
                btn_Match.Visible = true;
            }
            if (urls.Contains("ToRole91"))
            {
                btn_ToRole.Visible = true;
            }
        }
        #endregion

        #region 修改--乔春羽(2013.9.5)
        protected void btn_Modify_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvUser.DataKeys[GvUser.SelectedRowIndex][0]);
            string name = GvUser.DataKeys[GvUser.SelectedRowIndex][1].ToString();
            string path = string.Format("~/SystemSet/EditUser.aspx?UserId={0}&UserName={1}", id, name);
            WindowEdit.IFrameUrl = path;
            WindowEdit.Hidden = false;
        }
        #endregion

        #region 给用户分配角色--乔春羽(2013.9.5)
        protected void btn_ToRole_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvUser.DataKeys[GvUser.SelectedRowIndex][0]);
            string name = GvUser.DataKeys[GvUser.SelectedRowIndex][1].ToString();
            string path = string.Format("~/SystemSet/RoleToUser.aspx?UserId={0}&UserName={1}", id, name);
            WindowToRole.IFrameUrl = path;
            WindowToRole.Hidden = false;
        }
        #endregion

        #region 给用户分配监管员--乔春羽(2013.9.5)
        protected void btn_Match_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(GvUser.DataKeys[GvUser.SelectedRowIndex][0]);
            string name = GvUser.DataKeys[GvUser.SelectedRowIndex][1].ToString();
            string path = string.Format("~/SystemSet/RoleToUser.aspx?UserId={0}&UserName={1}", id, name);
            WindowToRole.IFrameUrl = path;
            WindowToRole.Hidden = false;
        }
        #endregion

    }
}