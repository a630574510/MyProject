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
        private Citic.BLL.DeptToRole DeptToRoleBll = null;
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
            this.ddl_Role.Items.Clear();
            AddItemByInsert(ddl_Role, "请选择", "-1", 0);
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
            this.ddlDept.Items.Clear();
            string where = string.Format("PDID={0} or (PDID=0 and Type=0)", this.Department);
            DataTable dt = DepartmentBll.GetList(where).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                ddlDept.DataSource = DepartmentBll.GetList(where);
                ddlDept.DataValueField = "ID";
                ddlDept.DataTextField = "DName";
                ddlDept.DataBind();
            }
            AddItemByInsert(ddlDept, "请选择", "-1", 0);
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
            UserInfo.Post = this.ddl_Role.SelectedText;
            UserInfo.CreateUser = CurrentUser.UserId;
            UserInfo.CreateTime = DateTime.Now;
            UserInfo.IsDelete = false;
            UserInfo.IsPort = false;

            UserInfo.CompanyID = 1;
            UserInfo.RelationID = 0;
            List<Citic.Model.UserMapping> ums = new List<Citic.Model.UserMapping>();

            if (UserBll.GetModel(UserInfo.UserName) == null)
            {
                int result = UserBll.Add(UserInfo);
                if (result > 0)
                {
                    AlertShowInTop("添加的用户成功！");
                    switch (UserInfo.RoleId)
                    {
                        case 5:
                        case 6:
                        case 8:
                            AlertShowInTop("请不要忘记给新添加的用户匹配银行！");
                            break;
                    }
                }
                else
                {
                    AlertShowInTop("添加的用户失败！");
                }
            }
            else
            {
                AlertShowInTop("您所添加的用户名重复！");
            }
        }
        #endregion

        #region 选择部门，加载角色--乔春羽(2014.3.24)
        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deptID = this.ddlDept.SelectedValue;
            this.ddl_Role.Items.Clear();
            if (!string.IsNullOrEmpty(deptID))
            {
                if (this.DeptToRoleBll == null)
                {
                    this.DeptToRoleBll = new Citic.BLL.DeptToRole();
                }
                DataSet ds = this.DeptToRoleBll.GetList(string.Format(" DeptID = '{0}' ", deptID));
                if (ds != null && ds.Tables.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["RoleName"].ToString() == "监管员")
                        {
                            dt.Rows.RemoveAt(i);
                            break;
                        }
                    }
                    this.ddl_Role.DataTextField = "RoleName";
                    this.ddl_Role.DataValueField = "RoleID";
                    this.ddl_Role.DataSource = dt;
                    this.ddl_Role.DataBind();
                }
            }
            AddItemByInsert(ddl_Role, "请选择", "-1", 0);
        }
        #endregion
    }
}