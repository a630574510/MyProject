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
    public partial class RoleToUser : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CBToRoleBind();
            }
        }
        private void CBToRoleBind()
        {
            CBToUser.DataSource = RoleBll.GetList("");
            CBToUser.DataTextField = "RoleName";
            CBToUser.DataValueField = "RoleId";
            CBToUser.DataBind();

            int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
            Citic.Model.User UserInfo = UserBll.GetModel(UserId);
            if (UserInfo.RoleId != 0)
            {
                CBToUser.SelectedValue = UserInfo.RoleId.ToString();
                //if (UserInfo.RoleId.IndexOf(",") < 0)
                //{

                //    CBToUser.SelectedValueArray = new string[] { "" + UserInfo.RoleId + "" };
                //}
                //else
                //{
                //    CBToUser.SelectedValueArray = UserInfo.RoleId.Split(',');
                //}
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
            SaveToUser();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        /// <summary>
        /// 保存分配的模块信息修改
        /// </summary>
        private void SaveToUser()
        {
            // 1. 这里放置保存窗体中数据的逻辑
            
            int UserId = Convert.ToInt32(Request.QueryString["UserId"]);
            string MenuList = CBToUser.SelectedValue;
            if (MenuList != "")
            {

                Citic.Model.User UserInfo = UserBll.GetModel(UserId.ToString());
                UserInfo.RoleId = int.Parse(MenuList);
                UserBll.Update(UserInfo);
            }
        }
        //private string GetCheckedValuesString(string[] array)
        //{
        //    if (array.Length == 0)
        //    {
        //        return "无";
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    foreach (string item in array)
        //    {
        //        sb.Append(item);
        //        sb.Append(",");
        //    }
        //    return sb.ToString().TrimEnd(',');
        //}
    }
}