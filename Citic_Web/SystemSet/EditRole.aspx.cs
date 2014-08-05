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
    public partial class EditRole :BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
                string RoleName = Request.QueryString["RoleName"].ToString();
                RoleInfoBind(RoleId);
            }
        }
        private void RoleInfoBind(int RoleId)
        {
            DataSet ds = RoleBll.GetList("RoleId=" + RoleId);
            this.lblRoleName.Text = ds.Tables[0].Rows[0]["RoleName"].ToString();
            this.txtADesc.Text = ds.Tables[0].Rows[0]["RoleDesc"].ToString();
        }
        /// <summary>
        /// 保存并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            // 1. 这里放置保存窗体中数据的逻辑
            SaveRole();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        /// <summary>
        /// 保存用户信息修改
        /// </summary>
        private void SaveRole()
        {
            // 1. 这里放置保存窗体中数据的逻辑
            
            int RoleId = Convert.ToInt32(Request.QueryString["RoleId"]);
            Citic.Model.Role RoleInfo = RoleBll.GetModel(RoleId);
            RoleInfo.RoleDesc = this.txtADesc.Text.Trim();
            bool result = RoleBll.Update(RoleInfo);
            if (result)
            {
                Alert.ShowInTop("修改角色信息成功");
            }
            else
            {
                Alert.ShowInTop("修改角色信息失败");
            }
        }
    }
}