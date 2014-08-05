using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using FineUI;
using Citic.BLL;
namespace Citic_Web.SystemSet
{
    public partial class AddUser : BasePage
    {
        private static Department DepartmentBll = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //绑定部门
                DeptBind();
                //绑定角色
                RoleDataBind();
            }
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
            this.ddl_Role.Items.Insert(0, new FineUI.ListItem("请选择", "-1"));
        }
        #endregion

        #region 绑定部门--乔春羽(2013.8.28)
        /// <summary>
        /// 绑定部门
        /// </summary>
        private void DeptBind()
        {
            if (DepartmentBll == null)
            {
                DepartmentBll = new Department();
            }
            string where = string.Format("PDID={0} or (PDID=0 and Type=0)", this.Department);
            
            ddlDept.DataSource = DepartmentBll.GetList(where);
            ddlDept.DataValueField = "ID";
            ddlDept.DataTextField = "DName";
            ddlDept.DataBind();
        }
        #endregion

        #region 保存并关闭页面--乔春羽
        /// <summary>
        /// 保存并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            SaveUser();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        /// <summary>
        /// 添加新用户
        /// </summary>
        private void SaveUser()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            Citic.Model.User UserInfo = new Citic.Model.User();
            UserInfo.UserName = txtUserName.Text.Trim();
            UserInfo.Password = txtPassword.Text.Trim();
            UserInfo.TrueName = txtTrueName.Text.Trim();
            UserInfo.Email = txtEmail.Text.Trim();
            UserInfo.MobileNo = txtEmail.Text.Trim();
            UserInfo.DeptId = Convert.ToInt32(ddlDept.SelectedValue);
            UserInfo.UserType = Convert.ToInt32(rbUserType.SelectedValue);
            UserInfo.RoleId = int.Parse(this.ddl_Role.SelectedValue);
            UserInfo.CreateUser = CurrentUser.UserId;
            UserInfo.CreateTime = DateTime.Now;
            UserInfo.IsDelete = false;
            UserInfo.IsPort = false;
            if (UserBll.GetModel(UserInfo.UserName) == null)
            {
                int result = UserBll.Add(UserInfo);
                if (result > 0)
                {
                    Alert.ShowInTop("添加的用户成功");
                }
                else
                {
                    Alert.ShowInTop("添加的用户失败");
                }
            }
            else
            {
                Alert.ShowInTop("您所添加的用户名重复");
            }
        }
        #endregion

    }
}