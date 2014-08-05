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
                btn_ToRole.OnClientClick = GvUser.GetNoSelectionAlertReference("请至少选择一项！");
                btn_ToBank.OnClientClick = GvUser.GetNoSelectionAlertReference("请至少选择一项！");
                RoleDataBind();
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

            //设置查询条件--乔春羽
            string where = ConditionInit();

            // 1.设置总项数（特别注意：数据库分页一定要设置总记录数RecordCount）
            GvUser.RecordCount = GetTotalCount(where);
            if (GvUser.PageCount <= GvUser.PageIndex)
            {
                GvUser.PageIndex = 0;
            }

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
            StringBuilder sbuilder = new StringBuilder(" T.IsDelete=0 ");
            if (!string.IsNullOrEmpty(this.txt_UserName.Text))
            {
                sbuilder.AppendFormat(" and T.UserName like '%{0}%'", txt_UserName.Text);
            }
            if (!string.IsNullOrEmpty(this.txt_TrueName.Text))
            {
                sbuilder.AppendFormat(" and T.TrueName like '%{0}%'", txt_TrueName.Text);
            }
            if (this.ddl_Role.SelectedValue != "-1")
            {
                sbuilder.AppendFormat(" and T.RoleId = '{0}'", this.ddl_Role.SelectedValue);
            }
            if (this.ddl_Type.SelectedValue != "-1")
            {
                sbuilder.AppendFormat(" and T.UserType = '{0}'", this.ddl_Type.SelectedValue);
            }
            return sbuilder.ToString();
        }

        /// <summary>
        /// 返回总项数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetTotalCount(string where)
        {
            return UserBll.GetRecordCount(where);
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

        #region 绑定角色--乔春羽
        private void RoleDataBind()
        {
            DataTable dt = RoleBll.GetAllList().Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                this.ddl_Role.DataTextField = "RoleName";
                this.ddl_Role.DataValueField = "RoleId";
                this.ddl_Role.DataSource = dt;
                this.ddl_Role.DataBind();
            }
            AddItemByInsert(ddl_Role, "请选择", "-1", 0);
        }
        #endregion


        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            GvUser.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            BindGrid();
        }

        #region 关闭窗体
        //<summary>
        //关闭窗体
        //</summary>
        //<param name="sender"></param>
        //<param name="e"></param>
        protected void Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            BindGrid();
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

        #region 根据不同角色，分配银行--乔春羽(2014.3.5)
        protected void btn_ToBank_Click(object sender, EventArgs e)
        {
            string roleID = this.GvUser.Rows[this.GvUser.SelectedRowIndex].DataKeys[2].ToString();
            string userID = this.GvUser.Rows[this.GvUser.SelectedRowIndex].DataKeys[0].ToString();
            string path = string.Empty;
            switch (roleID)
            {
                case "8":
                //path = string.Format("~/SystemSet/UserMapping.aspx?_user={0}&_role={1}&_type={2}",userID, roleID,Common.UserMappingType.Bank.ToString());
                //break;
                case "5":
                case "6":
                    path = string.Format("~/SystemSet/UserMapping.aspx?_user={0}&_role={1}&_type={2}", userID, roleID, Common.UserMappingType.Bank.ToString());
                    break;
                case "9":
                    path = string.Format("~/SystemSet/UserMapping.aspx?_user={0}&_role={1}&_type={2}", userID, roleID, Common.UserMappingType.Brand.ToString());
                    break;
                default:
                    AlertShowInTop("该角色没有该权限！");
                    break;
            }
            if (roleID == "8" || roleID == "5" || roleID == "6" || roleID == "9")
            {
                WIndowToBank.IFrameUrl = path;
                WIndowToBank.Hidden = false;
            }
        }
        #endregion

        #region 查询--乔春羽(2014.3.10)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            BindGrid();
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
                tbs_Add.Visible = true;
            }
            if (urls.Contains("Delete91"))
            {
                btnDeleteUser.Visible = true;
                tbs_Delete.Visible = true;
            }
            if (urls.Contains("Modify91"))
            {
                btn_Modify.Visible = true;
                tbs_Modify.Visible = true;
            }
            if (urls.Contains("Excel91"))
            {
                btnExport.Visible = true;
                //hl_ExportExcel.Visible = true;
            }
            if (urls.Contains("Match91"))
            {
            }
            if (urls.Contains("ToRole91"))
            {
                btn_ToRole.Visible = true;
                tbs_ToRole.Visible = true;
            }
            if (urls.Contains("ToBank91"))
            {
                btn_ToBank.Visible = true;
                tbs_ToBank.Visible = true;
            }
        }
        #endregion
    }
}