using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using Citic.BLL;
namespace Citic_Web.SystemSet
{
    public partial class AddRole:BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 保存并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            SaveRole();
            // 1. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        /// <summary>
        /// 添加新角色
        /// </summary>
        private void SaveRole()
        {
            // 1. 这里放置保存窗体中数据的逻辑
            
            Citic.Model.Role RoleInfo = new Citic.Model.Role();
            RoleInfo.RoleName = txtRoleName.Text.Trim();
            RoleInfo.RoleDesc = txtADesc.Text.Trim();
            if (RoleBll.GetModel(RoleInfo.RoleName) == null)
            {
                int result = RoleBll.Add(RoleInfo);
                if (result > 0)
                {
                    Alert.ShowInTop("添加的角色成功");
                }
                else
                {
                    Alert.ShowInTop("添加的角色失败");
                }
            }
            else
            {
                Alert.ShowInTop("您所添加的角色名重复");
            }
        }
    }
}