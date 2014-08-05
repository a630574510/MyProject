using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
namespace Citic_Web.SystemSet
{
    public partial class AddMenu : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ParentMenuBind();
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
        /// <summary>
        /// 保存并关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            SaveMenu();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        /// <summary>
        /// 添加新用户
        /// </summary>
        private void SaveMenu()
        {
            // 1. 这里放置保存窗体中数据的逻辑
            
            Citic.Model.Menu MenuInfo = new Citic.Model.Menu();
            MenuInfo.MenuName = txtMenuName.Text.Trim();
            MenuInfo.MenuUrl = txtMenuUrl.Text.Trim();
            MenuInfo.ParentMenu = Convert.ToInt32(this.ddlParentMenu.SelectedValue);
            MenuInfo.IsNavigation = Convert.ToBoolean(rbIsNavigation.SelectedValue);
            MenuInfo.MenuOrder = Convert.ToInt32(this.NbMenuOrder.Text.Trim());
            if (!MenuBll.Exists(MenuInfo.MenuName))
            {
                int result = MenuBll.Add(MenuInfo);
                if (result > 0)
                {
                    Alert.ShowInTop("添加的模块成功");
                }
                else
                {
                    Alert.ShowInTop("添加的模块失败");
                }
            }
            else
            {
                Alert.ShowInTop("您所添加的模块名重复");
            }
        }
    }
}