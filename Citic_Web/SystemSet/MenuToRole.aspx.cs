using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Text;
using System.Data;
using System.Collections;
namespace Citic_Web.SystemSet
{
    public partial class MenuToRole : BasePage
    {
        private static Citic.BLL.UserPermission UserPermissionBll = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CBToRoleBind();
            }
        }

        private void CBToRoleBind()
        {
            CBToRole.DataSource = MenuBll.GetList("");
            CBToRole.DataTextField = "MenuName";
            CBToRole.DataValueField = "MenuId";
            CBToRole.DataBind();
            if (UserPermissionBll == null)
            {
                UserPermissionBll = new Citic.BLL.UserPermission();
            }
            int RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
            DataSet ds = UserPermissionBll.GetList("RoleId=" + RoleId);
            string CBToRoleList = "";
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    CBToRoleList+=ds.Tables[0].Rows[i]["MenuId"].ToString()+",";
                }
                if (CBToRoleList != "")
                {
                    CBToRoleList = CBToRoleList.Substring(0, CBToRoleList.Length - 1);
                    CBToRole.SelectedValueArray = CBToRoleList.Split(',');
                }
            }
            

        }
        /// <summary>
        /// 保存并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑
            SaveMenu();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        /// <summary>
        /// 保存分配的模块信息修改
        /// </summary>
        private void SaveMenu()
        {
            // 1. 这里放置保存窗体中数据的逻辑
            if (UserPermissionBll == null)
            {
                UserPermissionBll = new Citic.BLL.UserPermission();
            }
            int RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
            UserPermissionBll.Delete("RoleId=" + RoleId);
            string MenuList=GetCheckedValuesString(CBToRole.SelectedValueArray);
            if (MenuList != "无")
            {
                string[] Menus = MenuList.Split(',');
                for (int i = 0; i < Menus.Length; i++)
                {
                    Citic.Model.UserPermission UserPermissionInfo = new Citic.Model.UserPermission();
                    UserPermissionInfo.MenuId = Convert.ToInt32(Menus[i]);
                    UserPermissionInfo.RoleId = RoleId;
                    UserPermissionBll.Add(UserPermissionInfo);
                }
            }
        }
        private string GetCheckedValuesString(string[] array)
        {
            if (array.Length == 0)
            {
                return "无";
            }

            StringBuilder sb = new StringBuilder();
            foreach (string item in array)
            {
                sb.Append(item);
                sb.Append(",");
            }
            return sb.ToString().TrimEnd(',');
        }



    }
}