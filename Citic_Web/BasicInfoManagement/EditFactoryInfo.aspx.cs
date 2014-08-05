using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Citic_Web.BasicInfoManagement
{
    public partial class EditFactoryInfo : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //清空ViewState的值--乔春羽
                ViewState.Clear();

                WUC_Address.Init();

                //脚本注册，删除之前的提示--乔春羽
                btn_DeleteBrand.OnClientClick = grid_BrandList.GetNoSelectionAlertReference("请至少选择一项！");
                btn_DeleteBrand.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", grid_BrandList.GetSelectedCountReference());
                btn_DeleteLinkman.OnClientClick = grid_LinkManList.GetNoSelectionAlertReference("请至少选择一项！");
                btn_DeleteLinkman.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", grid_LinkManList.GetSelectedCountReference());

                string queryStr = Request.QueryString["FactoryID"];
                if (queryStr != null && queryStr != string.Empty)
                {
                    FactoryID = int.Parse(queryStr);

                    FactoryDataBind();
                    BrandBind();
                    LinkmanDataBind();
                }
            }
        }

        #region Private Fields--乔春羽(2014.1.2)
        private int FactoryID
        {
            get { return (int)ViewState["ID"]; }
            set { ViewState["ID"] = value; }
        }

        private Citic.Model.Factory Model 
        {
            get { return ViewState["Model"] as Citic.Model.Factory; }
            set { ViewState["Model"] = value; }
        }
        #endregion

        #region 保存修改厂商信息--乔春羽
        /// <summary>
        /// 保存并关闭页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            if (Model != null)
            {
                Model.FactoryName = this.txt_FactoryName.Text;
                Model.Address = GetAddress();
                bool flag = FactoryBll.Update(Model);
                if (flag)
                {
                    AlertShowInTop("修改成功！");
                }
                else
                {
                    AlertShowInTop("修改失败！");
                }
                PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
            }
        }

        /// <summary>
        /// 获取地址--乔春羽
        /// </summary>
        /// <returns></returns>
        private string GetAddress()
        {
            return WUC_Address.Value;
        }
        #endregion

        #region 绑定数据--乔春羽
        /// <summary>
        /// 显示厂商基本信息--乔春羽
        /// </summary>
        private void FactoryDataBind()
        {
            Citic.Model.Factory model = FactoryBll.GetModel(Convert.ToInt32(FactoryID));
            if (model != null)
            {
                Model = model;
            }
            this.txt_FactoryName.Text = model.FactoryName;
            if (model.Address != null && model.Address != string.Empty)
            {
                string[] adds = model.Address.Split('-');
                if (adds.Length > 1)
                {
                    WUC_Address.Province = adds[0];
                    WUC_Address.City = adds[1];
                    WUC_Address.Address = adds[2];
                }
                else
                {
                    WUC_Address.Address = model.Address;
                }
            }
        }

        /// <summary>
        /// 绑定品牌信息--乔春羽
        /// </summary>
        private void BrandBind()
        {
            //设置表格的总数据量
            this.grid_BrandList.RecordCount = GetCountBySearch("brand");

            int pageIndex = grid_BrandList.PageIndex;
            int pageSize = grid_BrandList.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = BrandBll.GetListByPage("IsDelete=0 and FactoryID=" + FactoryID.ToString(), "CreateTime DESC", rowbegin, rowend).Tables[0];

            grid_BrandList.DataSource = dt;
            grid_BrandList.DataBind();
        }

        private int GetCountBySearch(string str)
        {
            string where = string.Empty;
            int count = 0;
            if (str == "brand")
            {
                where = string.Format("FactoryID={0} and IsDelete=0", FactoryID.ToString());
                count = BrandBll.GetRecordCount(where);
            }
            else if (str == "Linkman")
            {
                where = string.Format("LinkType={0} and RelationID={1} and IsDelete=0", Convert.ToInt32(Citic_Web.Common.LinkType.FactoryLinkman), FactoryID.ToString());
                count = LinkmanBll.GetRecordCount(where);
            }
            return count;
        }

        /// <summary>
        /// 绑定联系人信息--乔春羽
        /// </summary>
        private void LinkmanDataBind()
        {
            DataTable dt = null;
            //设置表格的总数据量
            this.grid_LinkManList.RecordCount = GetCountBySearch("Linkman");

            int pageIndex = grid_LinkManList.PageIndex;
            int pageSize = grid_LinkManList.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            try
            {
                dt = LinkmanBll.GetListByPage(string.Format("RelationID={0} and LinkType={1} and IsDelete=0", Convert.ToInt32(FactoryID), Convert.ToInt32(Citic_Web.Common.LinkType.FactoryLinkman)), "CreateTime DESC", rowbegin, rowend).Tables[0];

                grid_LinkManList.DataSource = dt;
                grid_LinkManList.DataBind();
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "LinkmanDataBind()");
            }
        }
        #endregion

        #region 添加品牌与联系人--乔春羽
        /// <summary>
        /// 添加品牌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_AddBrand_Click(object sender, EventArgs e)
        {
            Citic.Model.Brand model = new Citic.Model.Brand();
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.IsDelete = false;
            model.IsPort = false;
            model.ConnectID = string.Empty;
            model.BrandName = this.txt_BrandName.Text;
            model.FactoryID = FactoryID;
            model.Remark = this.txt_Remark.Text;
            try
            {
                int num = BrandBll.Add(model);
                if (num > 0)
                {
                    AlertShowInTop("添加成功！");
                    BrandBind();
                }
                else
                {
                    AlertShowInTop("添加失败！");
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "btn_AddBrand_Click()");
            }
        }
        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_AddLinkman_Click(object sender, EventArgs e)
        {
            Citic.Model.Linkman model = new Citic.Model.Linkman();
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.IsDelete = false;
            model.IsPort = false;
            model.ConnectID = string.Empty;
            model.LinkmanName = this.txt_LinkManName.Text;
            model.RelationID = FactoryID;
            model.LinkType = Convert.ToInt32(Citic_Web.Common.LinkType.FactoryLinkman);
            model.Phone = this.num_Phone.Text;
            model.Email = this.txt_Email.Text;
            try
            {
                int num = LinkmanBll.Add(model);
                if (num > 0)
                {
                    AlertShowInTop("添加成功！");
                    LinkmanDataBind();
                }
                else
                {
                    AlertShowInTop("添加失败！");
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "btn_AddLinkman_Click()");
            }
        }
        #endregion

        #region 删除操作--乔春羽
        protected void grid_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                FineUI.Grid obj = sender as FineUI.Grid;
                if (obj != null)
                {
                    FineUI.GridRow dr = obj.Rows[e.RowIndex];
                    int id = Convert.ToInt32(dr.DataKeys[0]);
                    //品牌
                    if (obj.ID == "grid_BrandList")
                    {
                        try
                        {
                            bool flag = BrandBll.DeleteOnLogic(new Citic.Model.Brand() { BrandID = id, DeleteID = this.CurrentUser.UserId, DeleteTime = DateTime.Now });
                            if (flag)
                            {
                                AlertShowInTop("删除成功！");
                                BrandBind();
                            }
                            else
                            {
                                AlertShowInTop("删除失败！");
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    //联系人
                    else if (obj.ID == "grid_LinkmanList")
                    {
                        try
                        {
                            bool flag = LinkmanBll.DeleteOnLogic(new Citic.Model.Linkman() { LinkmanID = id, DeleteID = this.CurrentUser.UserId, DeleteTime = DateTime.Now });
                            if (flag)
                            {
                                AlertShowInTop("删除成功！");
                                LinkmanDataBind();
                            }
                            else
                            {
                                AlertShowInTop("删除失败！");
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                }
            }
        }
        #endregion

        #region 批量删除--乔春羽
        /// <summary>
        /// 批量删除--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Click(object sender, EventArgs e)
        {
            FineUI.Button btn = sender as FineUI.Button;
            bool flag = false;
            if (btn != null)
            {
                if (btn.ID == "btn_DeleteBrand")
                {
                    SyncSelectedRowIndexArrayToHiddenField(grid_BrandList, hfSelectedIDS_Brand);

                    string[] DelMenu = hfSelectedIDS_Brand.Text.Trim().Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
                    string superIDList = "";
                    for (int i = 0; i < DelMenu.Length; i++)
                    {
                        superIDList += DelMenu[i] + ",";
                    }
                    superIDList = superIDList.Substring(0, superIDList.Length - 1);
                    Citic.Model.Brand model = new Citic.Model.Brand();
                    model.DeleteID = this.CurrentUser.UserId;
                    model.DeleteTime = DateTime.Now;
                    flag = BrandBll.DeleteListOnLogic(superIDList, model);
                    if (flag)
                    {
                        AlertShowInTop("删除成功！");
                        BrandBind();
                    }
                    else
                    {
                        AlertShowInTop("删除失败！");
                    }
                }
                else if (btn.ID == "btn_DeleteLinkman")
                {
                    SyncSelectedRowIndexArrayToHiddenField(grid_LinkManList, hfSelectedIDS_Linkman);

                    string[] DelMenu = hfSelectedIDS_Linkman.Text.Trim().Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
                    string superIDList = "";
                    for (int i = 0; i < DelMenu.Length; i++)
                    {
                        superIDList += DelMenu[i] + ",";
                    }
                    superIDList = superIDList.Substring(0, superIDList.Length - 1);
                    Citic.Model.Linkman model = new Citic.Model.Linkman();
                    model.DeleteID = this.CurrentUser.UserId;
                    model.DeleteTime = DateTime.Now;
                    flag = LinkmanBll.DeleteListOnLogic(superIDList, model); 
                    if (flag)
                    {
                        AlertShowInTop("删除成功！");
                        LinkmanDataBind();
                    }
                    else
                    {
                        AlertShowInTop("删除失败！");
                    }
                }


            }
        }
        #endregion

        #region 每页显示数据数量改变--乔春羽
        /// <summary>
        /// 每页显示数据数量改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_PageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //乔春羽
            Grid grid = sender as Grid;
            if (grid != null)
            {
                if (grid.ID == "grid_BrandList")
                {
                    grid.PageSize = int.Parse(ddl_BrandPage.SelectedValue);
                    BrandBind();
                }
                else if (grid.ID == "grid_LinkmanList")
                {
                    grid.PageSize = int.Parse(ddl_LinkmanPage.SelectedValue);
                    LinkmanDataBind();
                }
            }
            //乔春羽
        }
        #endregion

        #region 翻页事件--乔春羽
        /// <summary>
        /// 翻页事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null)
            {
                if (grid.ID == "grid_BrandList")
                {
                    SyncSelectedRowIndexArrayToHiddenField(grid, hfSelectedIDS_Brand);
                    grid.PageIndex = e.NewPageIndex;
                    BrandBind();
                    UpdateSelectedRowIndexArray(grid, hfSelectedIDS_Brand);
                }
                else if (grid.ID == "grid_LinkmanList")
                {
                    SyncSelectedRowIndexArrayToHiddenField(grid, hfSelectedIDS_Linkman);
                    grid.PageIndex = e.NewPageIndex;
                    LinkmanDataBind();
                    UpdateSelectedRowIndexArray(grid, hfSelectedIDS_Linkman);
                }
            }
        }
        #endregion

    }
}