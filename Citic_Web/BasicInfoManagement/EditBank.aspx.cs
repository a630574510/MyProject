using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FineUI;

namespace Citic_Web.BasicInfoManagement
{
    public partial class EditBank : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //乔春羽
                string param = Request.QueryString["BankID"];
                WUC_Address.Init();
                if (param != null && param != string.Empty)
                {
                    BankID = int.Parse(param);
                    GridBind();
                }
                this.btn_Add.OnClientClick = WindowAdd.GetShowReference("AddLinkman.aspx?BankID=" + BankID, "添加联系人");

            }
        }

        #region Private Fields--乔春羽(2014.1.2)
        private Citic.Model.Bank Model
        {
            get { return ViewState["Model"] as Citic.Model.Bank; }
            set { ViewState["Model"] = value; }
        }
        private int BankID
        {
            get { return (int)ViewState["BankID"]; }
            set { ViewState["BankID"] = value; }
        }
        #endregion

        /// <summary>
        /// 绑定数据--乔春羽
        /// </summary>
        /// <param name="bankID"></param>
        private void GridBind()
        {
            Model = BankBll.GetModel(BankID);

            this.txt_BankName.Text = Model.BankName;

            if (Model.Address != null && Model.Address != string.Empty)
            {
                string[] adds = Model.Address.Split('-');
                if (adds.Length == 3)
                {
                    this.WUC_Address.Province = adds[0];
                    this.WUC_Address.City = adds[1];
                    this.WUC_Address.Address = adds[2];
                }
                else
                {
                    this.WUC_Address.Address = Model.Address;
                }
            }

            LinkmanDataBind(BankID);
        }
        /// <summary>
        /// 绑定联系人信息--乔春羽
        /// </summary>
        /// <param name="bankID"></param>
        private DataTable LinkmanDataBind(int bankID)
        {
            DataTable dt = null;
            try
            {
                string where = " IsDelete=0 and RelationID=" + bankID + " and LinkType=2";
                grid_LinkmanList.RecordCount = GetLinkmanRecordCount(where);

                int pageIndex = grid_LinkmanList.PageIndex;
                int pageSize = grid_LinkmanList.PageSize;
                int rowbegin = pageIndex * pageSize + 1;
                int rowend = (pageIndex + 1) * pageSize;
                dt = LinkmanBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

                grid_LinkmanList.DataSource = dt;
                grid_LinkmanList.DataBind();
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "LinkmanDataBind()");
            }
            return dt;
        }


        /// <summary>
        /// 行命令事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_LinkmanList_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName != null && e.CommandName != string.Empty)
            {
                object[] keys = grid_LinkmanList.DataKeys[e.RowIndex];
                if (keys != null && keys.Length > 0)
                {
                    int lkid = Convert.ToInt32(keys[0]);
                    if (e.CommandName == "delete")
                    {
                        bool flag = LinkmanBll.DeleteOnLogic(new Citic.Model.Linkman() { LinkmanID = lkid, DeleteID = this.CurrentUser.UserId, DeleteTime = DateTime.Now });
                        if (flag)
                        {
                            AlertShowInTop("删除成功！");
                            LinkmanDataBind(BankID);
                        }
                        else
                        {
                            AlertShowInTop("删除失败！");
                        }

                    }
                    else if (e.CommandName == "edit")
                    {

                    }
                }
            }
        }

        /// <summary>
        /// 批量删除--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_LinkmanList, hfSelectedIDS);

            string[] DelMenu = hfSelectedIDS.Text.Trim().Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
            string superIDList = "";
            for (int i = 0; i < DelMenu.Length; i++)
            {
                superIDList += DelMenu[i] + ",";
            }
            superIDList = superIDList.Substring(0, superIDList.Length - 1);
            Citic.Model.Linkman model = new Citic.Model.Linkman();
            model.DeleteID = this.CurrentUser.UserId;
            model.DeleteTime = DateTime.Now;
            bool flag = LinkmanBll.DeleteListOnLogic(superIDList, model);
            if (flag)
            {
                AlertShowInTop("删除成功！");
                LinkmanDataBind(BankID);
            }
            else
            {
                AlertShowInTop("删除失败！");
            }
        }

        /// <summary>
        /// 获得联系人的数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetLinkmanRecordCount(string where)
        {
            return LinkmanBll.GetRecordCount(where);
        }

        /// <summary>
        /// 保存并关闭--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            SaveBank();
            // 2. 关闭本窗体，然后刷新父窗体
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        /// <summary>
        /// 获取地址--乔春羽
        /// </summary>
        /// <returns></returns>
        private string GetAddress()
        {
            return this.WUC_Address.Value;
        }

        /// <summary>
        /// 保存银行信息--乔春羽
        /// </summary>
        private void SaveBank()
        {
            Model.BankName = this.txt_BankName.Text;
            Model.Address = GetAddress();

            try
            {
                bool flag = BankBll.Update(Model);
                if (flag)
                {
                    AlertShowInTop("修改成功！");
                }
                else
                {
                    AlertShowInTop("修改失败！");
                }
            }
            catch { }
        }

        /// <summary>
        /// 每页显示数量改变事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_LinkmanList.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            //乔春羽
            LinkmanDataBind(BankID);
        }

        /// <summary>
        /// 翻页事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_LinkmanList_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {

            SyncSelectedRowIndexArrayToHiddenField(grid_LinkmanList, hfSelectedIDS);
            grid_LinkmanList.PageIndex = e.NewPageIndex;

            LinkmanDataBind(BankID);

            UpdateSelectedRowIndexArray(grid_LinkmanList, hfSelectedIDS);
        }


        /// <summary>
        /// 窗体关闭--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            GridBind();
        }

    }
}