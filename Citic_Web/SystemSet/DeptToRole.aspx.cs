using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
namespace Citic_Web.SystemSet
{
    public partial class DeptToRole : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string value = Request.QueryString["_deptid"];
                if (!string.IsNullOrEmpty(value))
                {
                    this.DeptID = value;
                    GridBind();
                }
            }
        }

        #region Private Fields--乔春羽(2014.3.24)
        private Citic.BLL.DeptToRole _DeptToRoleBll;

        public Citic.BLL.DeptToRole DeptToRoleBll
        {
            get
            {
                if (_DeptToRoleBll == null)
                {
                    _DeptToRoleBll = new Citic.BLL.DeptToRole();
                }
                return _DeptToRoleBll;
            }
        }

        private string DeptID
        {
            get { return (string)ViewState["DeptID"]; }
            set { ViewState["DeptID"] = value; }
        }

        private string[] RoleIDs
        {
            get { return (string[])ViewState["RoleIDs"]; }
            set { ViewState["RoleIDs"] = value; }
        }
        #endregion

        #region 绑定数据--乔春羽(2014.3.24)
        private void GridBind()
        {
            DataTable dt_DeptRole = DeptToRoleBll.GetList(string.Format(" DeptID = '{0}' ", this.DeptID)).Tables[0];
            StringBuilder strWhere = new StringBuilder();
            RoleIDs = null;
            if (dt_DeptRole != null && dt_DeptRole.Rows.Count > 0)
            {
                RoleIDs = new string[dt_DeptRole.Rows.Count];
                for (int i = 0; i < dt_DeptRole.Rows.Count; i++)
                {
                    RoleIDs[i] = dt_DeptRole.Rows[i]["RoleID"].ToString();
                }
            }
            if (RoleIDs != null || RoleIDs.Length > 0)
            {
                strWhere.Append(" RoleID not in (");
                foreach (string roleID in RoleIDs)
                {
                    strWhere.AppendFormat("'{0}',", roleID.ToString());
                }
                strWhere.Remove(strWhere.Length - 1, 1);
                strWhere.Append(")");
            }
            if (strWhere != null && strWhere.Length > 0)
            {
                DataTable dt = RoleBll.GetList(strWhere.ToString()).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    this.cbl_Roles.DataSource = dt;
                    this.cbl_Roles.DataBind();
                    this.cbl_Roles.DataTextField = "RoleName";
                    this.cbl_Roles.DataValueField = "RoleID";
                }
            }
            if (RoleIDs != null || RoleIDs.Length > 0)
            {
                this.cbl_Roles.SelectedValueArray = RoleIDs;
            }
        }
        #endregion

        #region 保存并关闭--乔春羽(2014.3.24)
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            //1.删除掉该部门下的所有角色
            this.DeptToRoleBll.DeleteList(string.Join(",", this.RoleIDs));

            //2.添加本次所选择的角色
            string[] selectedRoleIDs = this.cbl_Roles.SelectedValueArray;
            List<Citic.Model.DeptToRole> deptToToleList = new List<Citic.Model.DeptToRole>();
            if (selectedRoleIDs != null && selectedRoleIDs.Length > 0)
            {
                List<Citic.Model.DeptToRole> models = new List<Citic.Model.DeptToRole>();
                foreach (string roleID in selectedRoleIDs)
                {
                    models.Add(new Citic.Model.DeptToRole() { DeptID = int.Parse(this.DeptID), RoleID = int.Parse(roleID) });
                }

                int num = this.DeptToRoleBll.AddRange(models.ToArray());
                if (num > 0)
                {
                    AlertShowInTop("匹配成功！");

                    //  关闭本窗体，然后刷新父窗体
                    PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
                }
                else
                {
                    AlertShowInTop("匹配失败！");
                }
            }
        }
        #endregion
    }
}