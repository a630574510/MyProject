﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Citic_Web.BasicInfoManagement
{
    public partial class BankList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_AddBank.OnClientClick = WindowAddBank.GetShowReference("../BasicInfoManagement/AddBank.aspx");
                btn_DeleteBank.OnClientClick = grid_List.GetNoSelectionAlertReference("至少要选择一项！");
                btn_DeleteBank.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", grid_List.GetSelectedCountReference());
                btn_Modify.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("没有选择数据！");
                btn_Search.Visible = false;

                RoleValidate();
            }
        }

        
        #region 数据绑定--乔春羽(2013.9.3)
        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="where"></param>
        private void GridBind()
        {
            string where = ConditionInit();

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            if (this.grid_List.PageCount <= this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = BankBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

            grid_List.DataSource = dt;
            grid_List.DataBind();
        }

        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return BankBll.GetRecordCount(where);
        }

        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder(" T.IsDelete=0 ");

            //过滤权限
            //监管员
            if (this.CurrentUser.RoleId == 10)
            {
                DataTable dt = Dealer_BankBll.GetBankIDAndNameFilterRole(this.CurrentUser.RelationID.Value).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    where.Append(" AND T.BankID IN (");
                    foreach (DataRow row in dt.Rows)
                    {
                        where.AppendFormat("'{0}',", row["BankID"].ToString());
                    }
                    where.Remove(where.Length - 1, 1).Append(")");
                }
            }
            //银行
            else if (this.CurrentUser.RoleId == 8)
            {
                Citic.Model.UserMapping model = UMBLL.GetModelByCondition(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                if (model != null)
                {
                    where.AppendFormat(" And T.BankID = '{0}'  ", model.MappingID.Value.ToString());
                }
            }
            //5.市场专员，6.品牌专员
            else if (this.CurrentUser.RoleId == 5 || this.CurrentUser.RoleId == 6)
            {
                DataTable dt = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId)).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    StringBuilder ids=new StringBuilder(" AND T.BankID in (");
                    foreach (DataRow row in dt.Rows)
                    {
                        ids.AppendFormat("{0},",row["MappingID"].ToString());
                    }
                    ids.Remove(ids.Length - 1, 1);
                    ids.Append(")");

                    where.Append(ids);
                }
            }
            if (!string.IsNullOrEmpty(this.txt_Search.Text))
            {
                where.AppendFormat(" AND T.BankName LIKE '%{0}%' ", this.txt_Search.Text);
            }
            return where.ToString();
        }
        #endregion

        /// <summary>
        /// 每页显示数量改变事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_List.PageSize = int.Parse(ddlPageSize.SelectedValue);
            GridBind();
        }

        protected void grid_BankList_RowDataBind(object sender, FineUI.GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                //银行类型
                int BankType = Convert.ToInt32(e.Values[2]);
                switch (BankType)
                {
                    case 0:
                        e.Values[2] = "总行";
                        break;
                    case 1:
                        e.Values[2] = "分行";
                        break;
                    case 2:
                        e.Values[2] = "支行";
                        break;
                }
            }
        }

        /// <summary>
        /// 翻页事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GvMenu_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);
            grid_List.PageIndex = e.NewPageIndex;
            GridBind();
            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
        }
        #region 查询--乔春羽
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        /// <summary>
        /// 窗体关闭--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            //检索数据，检索出不是“逻辑删除”的数据
            GridBind();
        }

        #region 行命令事件--乔春羽(2013.9.3)
        /// <summary>
        /// 行命令事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_BankList_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName != null && e.CommandName != string.Empty)
            {
                if (e.CommandName == "delete")
                {
                    object[] keys = grid_List.DataKeys[e.RowIndex];
                    if (keys != null && keys.Length > 0)
                    {
                        int lkid = Convert.ToInt32(keys[0]);
                        bool flag = BankBll.DeleteOnLogic(new Citic.Model.Bank() { BankID = lkid, DeleteID = this.CurrentUser.UserId, DeleteTime = DateTime.Now });
                        if (flag)
                        {
                            AlertShowInTop("删除成功！");
                            GridBind();
                        }
                        else
                        {
                            AlertShowInTop("删除失败！");
                        }
                    }

                }
            }
        }
        #endregion

        #region 批量删除--乔春羽(2013.9.3)
        /// <summary>
        /// 批量删除--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_DeleteBank_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);

            string[] DelMenu = hfSelectedIDS.Text.Trim().Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
            string superIDList = "";
            for (int i = 0; i < DelMenu.Length; i++)
            {
                superIDList += DelMenu[i] + ",";
            }
            superIDList = superIDList.Substring(0, superIDList.Length - 1);
            Citic.Model.Bank model = new Citic.Model.Bank();
            model.DeleteID = this.CurrentUser.UserId;
            model.DeleteTime = DateTime.Now;
            bool flag = BankBll.DeleteListOnLogic(superIDList, model);
            if (flag)
            {
                AlertShowInTop("删除成功！");
                GridBind();
            }
            else
            {
                AlertShowInTop("删除失败！");
            }
        }
        #endregion

        #region 导出Excel--乔春羽
        protected void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            if (this.grid_List.Rows.Count <= 0)
            {
                AlertShowInTop("没有可导出的数据！");
                return;
            }
            //保存Excel文件
            string sheetName = "合作行信息（当前页）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string sheetNameAll = "合作行信息（全部）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string filePath = string.Empty;
            //保存当前页的数据
            ExcelEditHelper.Create();
            ExcelEditHelper.AddSheet(sheetName);
            DataTable dt = null;

            dt = GetTableForGrid(grid_List);

            string fileName = sheetName + ".xls";//客户端保存的文件名
            ExcelEditHelper.DataTableAdd2Excel(dt, sheetName);

            filePath = "~/DownExcel/" + sheetName + ".xls";
            bool flag = ExcelEditHelper.SaveAs(Server.MapPath(filePath));

            //释放ExcelEditHelper
            CloseExcelEditHelper();

            //下载Excel文件
            if (flag)
            {
                hl_ExportExcel.NavigateUrl = filePath;
            }

            //保存所有的数据
            ExcelEditHelper.Create();
            ExcelEditHelper.AddSheet(sheetNameAll);

            dt = BankBll.GetAllListByProcess().Tables[0];

            ModifyTableHeaderByGrid(grid_List, dt);

            fileName = sheetName + ".xls";//客户端保存的文件名
            ExcelEditHelper.DataTableAdd2Excel(dt, sheetNameAll);

            filePath = "~/DownExcel/" + sheetNameAll + ".xls";
            flag = ExcelEditHelper.SaveAs(Server.MapPath(filePath));

            //释放ExcelEditHelper
            CloseExcelEditHelper();

            //下载Excel文件
            if (flag)
            {
                hl_ExportAll.NavigateUrl = filePath;
            }
        }
        #endregion

        #region 修改--乔春羽(2013.9.3)
        protected void btn_Modify_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(grid_List.DataKeys[grid_List.SelectedRowIndex][0]);
            string path = string.Format("~/BasicInfoManagement/EditBank.aspx?BankID={0}", id);
            WindowEditBank.IFrameUrl = path;
            WindowEditBank.Hidden = false;
        }
        #endregion

        #region //权限过滤-判断登陆角色，显示不同的按钮--乔春羽(2013.9.3)
        /// <summary>
        /// 按钮权限过滤
        /// </summary>
        private void RoleValidate()
        {
            DataTable dt = GetMenusByCurrentUserRoleID(false);
            List<string> urls = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                urls.Add(row["MenuUrl"].ToString());
            }
            if (urls.Contains("Search22"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert22"))
            {
                btn_AddBank.Visible = true;
                tbs_Add.Visible = true;
            }
            if (urls.Contains("Delete22"))
            {
                tbs_Delete.Visible = true;
                btn_DeleteBank.Visible = true;
            }
            if (urls.Contains("Modify22"))
            {
                tbs_Modify.Visible = true;
                btn_Modify.Visible = true;
            }
            if (urls.Contains("Excel22"))
            {
                btn_ExportExcel.Visible = true;
                hl_ExportExcel.Visible = true;
            }
            if (urls.Contains("ExcelAll22"))
            {
                btn_ExportExcel.Visible = true;
                hl_ExportAll.Visible = true;
            }
        }
        #endregion

    }
}