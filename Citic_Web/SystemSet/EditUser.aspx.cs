using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Citic.BLL;
using System.Data;
namespace Citic_Web.SystemSet
{
    public partial class EditUser : BasePage
    {
        private static Department DepartmentBll = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DeptBind();
                int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
                string UserName = Request.QueryString["UserName"].ToString();
                UserInfoBind(UserId);

            }
        }

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
            string where = " PDID = 1 AND TYPE = 1 ";
            ddlDept.DataSource = DepartmentBll.GetList(where);
            ddlDept.DataValueField = "ID";
            ddlDept.DataTextField = "DName";
            ddlDept.DataBind();
        }
        #endregion

        private void UserInfoBind(int UserId)
        {
            Citic.Model.User model = UserBll.GetModel(UserId);
            this.lblUserName.Text = model.UserName;
            this.txtPassword.Text = model.Password;
            this.txtUPassword.Text = model.Password;
            this.txtTrueName.Text = model.TrueName;
            this.ddlDept.SelectedValue = model.DeptId.ToString();
            this.txtEmail.Text = model.Email;
            this.txtMobileNo.Text = model.MobileNo;
            this.rbUserType.SelectedValue = model.UserType.ToString();
        }
        /// <summary>
        /// 保存并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑
            SaveUser();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        /// <summary>
        /// 保存用户信息修改
        /// </summary>
        private void SaveUser()
        {
            // 1. 这里放置保存窗体中数据的逻辑

            int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
            Citic.Model.User UserInfo = UserBll.GetModel(UserId);
            UserInfo.Password = this.txtPassword.Text.Trim();
            UserInfo.TrueName = this.txtTrueName.Text.Trim();
            UserInfo.DeptId = Convert.ToInt32(this.ddlDept.SelectedValue);
            UserInfo.Email = this.txtEmail.Text.Trim();
            UserInfo.MobileNo = this.txtMobileNo.Text.Trim();
            UserInfo.UserType = Convert.ToInt32(this.rbUserType.SelectedValue);
            UserInfo.UpdateUser = CurrentUser.UserId;
            UserInfo.UpdateTime = DateTime.Now;
            
            bool result = UserBll.Update(UserInfo);
            if (result)
            {
                Alert.ShowInTop("修改用户信息成功");
            }
            else
            {
                Alert.ShowInTop("修改用户信息失败");
            }
        }
    }
}