using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
namespace Citic_Web.SystemSet
{
    public partial class EditMenu : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int MenuId = Convert.ToInt32(Request.QueryString["MenuId"]);
                string MenuName = Request.QueryString["MenuName"].ToString();
                ParentMenuBind();
                MenuInfoBind(MenuId);
            }
        }
        private void ParentMenuBind()
        {
            ddlParentMenu.DataSource = MenuBll.GetList("");
            ddlParentMenu.DataTextField = "MenuName";
            ddlParentMenu.DataValueField = "MenuId";
            ddlParentMenu.DataBind();
            FineUI.ListItem Drl = new FineUI.ListItem("父级", "0");
            ddlParentMenu.Items.Insert(0, Drl);
        }
        private void MenuInfoBind(int MenuId)
        {
            Citic.Model.Menu MenuInfo = MenuBll.GetModel(MenuId);
            lblMenuName.Text = MenuInfo.MenuName;
            txtMenuUrl.Text = MenuInfo.MenuUrl;
            this.ddlParentMenu.SelectedValue = MenuInfo.ParentMenu.ToString();
            rbIsNavigation.SelectedValue = MenuInfo.IsNavigation.ToString();
            this.NbMenuOrder.Text = MenuInfo.MenuOrder.ToString();
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
        /// 保存用户信息修改
        /// </summary>
        private void SaveMenu()
        {
            // 1. 这里放置保存窗体中数据的逻辑
            
            int MenuId = Convert.ToInt32(Request.QueryString["MenuId"]);
            Citic.Model.Menu MenuInfo = MenuBll.GetModel(MenuId);
            MenuInfo.MenuUrl = txtMenuUrl.Text.Trim();
            MenuInfo.ParentMenu = Convert.ToInt32(this.ddlParentMenu.SelectedValue);
            MenuInfo.IsNavigation = Convert.ToBoolean(rbIsNavigation.SelectedValue);
            MenuInfo.MenuOrder = Convert.ToInt32(this.NbMenuOrder.Text.Trim());
            bool result = MenuBll.Update(MenuInfo);
            if (result)
            {
                Alert.ShowInTop("修改模块信息成功");
            }
            else
            {
                Alert.ShowInTop("修改模块信息失败");
            }
        }
    }
}