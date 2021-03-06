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
using NPOI.SS.UserModel;

namespace Citic_Web.DealerManagement.StorageInfo
{
    public partial class StorageList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_Add.OnClientClick = WindowAdd.GetShowReference("../../DealerManagement/StorageInfo/AddStorageInfo.aspx");
                btn_Delete.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("没有选择任何数据！");
                btn_Delete.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", grid_List.GetSelectedCountReference());
                this.btn_Modify.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("没有选择数据！");
                BankDataBind();
                RoleValidate();
            }
        }

        #region 加载银行列表--乔春羽
        /// <summary>
        /// 加载银行信息列表
        /// </summary>
        private void BankDataBind()
        {
            DataTable dt = null;
            //监管员
            if (this.CurrentUser.RoleId == 10)
            {
                dt = Dealer_BankBll.GetBankIDAndNameFilterRole(this.CurrentUser.RelationID.Value).Tables[0];
            }
            //银行
            else if (this.CurrentUser.RoleId == 8)
            {
                Citic.Model.UserMapping model = UMBLL.GetModelByCondition(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                if (model != null)
                {
                    dt = BankBll.GetList(string.Format(" BankID='{0}' ", model.MappingID.Value.ToString())).Tables[0];
                }
            }
            //5.市场专员，6.品牌专员
            else if (this.CurrentUser.RoleId == 5 || this.CurrentUser.RoleId == 6)
            {
                StringBuilder ids = new StringBuilder(string.Empty);
                DataTable _dt = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId)).Tables[0];
                if (_dt != null && _dt.Rows.Count > 0)
                {
                    ids.Append(" T.BankID in (");
                    foreach (DataRow row in _dt.Rows)
                    {
                        ids.AppendFormat("{0},", row["MappingID"].ToString());
                    }
                    ids.Remove(ids.Length - 1, 1);
                    ids.Append(")");
                    dt = BankBll.GetList(ids.ToString()).Tables[0];
                }
            }
            else
            {
                dt = BankBll.GetList("IsDelete=0").Tables[0];
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl_Bank.DataTextField = "BankName";
                ddl_Bank.DataValueField = "BankID";
                ddl_Bank.DataSource = dt;
                ddl_Bank.DataBind();
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
            DealerDataBind(ddl_Bank.SelectedValue);
        }
        #endregion

        #region 银行选择事件，选择银行显示出与银行关联的厂商--乔春羽
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bankIDStr = ddl_Bank.SelectedValue;
            if (bankIDStr != null && bankIDStr != string.Empty)
            {
                DealerDataBind(bankIDStr);
            }
        }

        private void DealerDataBind(string bankIDStr)
        {
            ddl_Dealer.Items.Clear();
            if (bankIDStr != "-1")
            {
                StringBuilder strWhere = new StringBuilder(string.Format(" A.BankID = '{0}' and A.CollaborateType = 1 and A.IsDelete=0 ", bankIDStr));
                if (this.CurrentUser.RoleId == 10)
                {
                    string[] dealerIDs = this.DealerBll.GetDealerIDsBySupervisorID(this.CurrentUser.RelationID.Value);
                    if (dealerIDs != null && dealerIDs.Length > 0)
                    {
                        strWhere.AppendFormat(" and A.DealerID in ({0}) ", string.Join(",", dealerIDs));
                    }
                    else
                    {
                        strWhere.Append(" and A.DealerID in (0) ");
                    }
                }
                DataTable dt = Dealer_BankBll.GetList(strWhere.ToString()).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddl_Dealer.DataTextField = "DealerName";
                    ddl_Dealer.DataValueField = "DealerID";
                    ddl_Dealer.DataSource = dt;
                    ddl_Dealer.DataBind();
                }
            }
            AddItemByInsert(ddl_Dealer, "请选择", "-1", 0);
        }
        #endregion

        #region 数据显示--乔春羽
        private void GridBind()
        {
            DataTable dt = null;

            string where = ConditionInit();

            this.grid_List.RecordCount = GetCountBySearch(where);

            if (this.grid_List.PageCount < this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            try
            {
                dt = StorageBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

                grid_List.DataSource = dt;
                grid_List.DataBind();
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "GridBind()");
            }
        }

        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return StorageBll.GetRecordCount(where);
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            int dealerID = int.Parse(ddl_Dealer.SelectedValue);
            int bankID = 0;
            string storageName = this.txt_StorageName.Text;
            StringBuilder where = new StringBuilder("T.IsDelete=0");

            if (dealerID != -1)
            {
                where.AppendFormat(" and T.DealerID={0}", dealerID);
                bankID = int.Parse(ddl_Bank.SelectedValue);
            }
            if (storageName != string.Empty)
            {
                where.AppendFormat(" and T.StorageName like '%{0}%'", storageName);
            }

            if (bankID != 0)
            {
                //Citic.Model.Bank bankModel = this.BankBll.GetModel(bankID);
                //string bankCode = bankModel.ConnectID;
                ////如果该经销商所对应的合作行是中信银行
                ////则要加上中信银行的直联ID作为条件
                //if (bankCode.Equals("2000000000"))
                //{
                //    where.AppendFormat(" and (ConnectID <> '' or ConnectID IS NOT NULL )");
                //}
                //else
                //{
                //    where.AppendFormat(" and (ConnectID = '' or ConnectID IS NULL )");
                //}
            }

            return where.ToString();
        }
        #endregion

        #region 删除数据--乔春羽
        protected void grid_List_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName != null && e.CommandName != string.Empty)
            {
                int storageID = Convert.ToInt32(grid_List.DataKeys[e.RowIndex][0]);

                //要删除该信息
                if (e.CommandName == "delete")
                {
                    try
                    {
                        bool flag = StorageBll.DeleteOnLogic(new Citic.Model.Storage() { StorageID = storageID, DeleteID = this.CurrentUser.UserId, DeleteTime = DateTime.Now });
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
                    catch (Exception ex)
                    {
                        AlertShowInTop("服务器正忙，请稍后再试！");
                        Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "grid_List_RowCommand()");
                    }
                }
            }
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Deletes_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);

            string[] DelMenu = hfSelectedIDS.Text.Trim().Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
            string superIDList = "";
            for (int i = 0; i < DelMenu.Length; i++)
            {
                superIDList += DelMenu[i] + ",";
            }
            superIDList = superIDList.Substring(0, superIDList.Length - 1);
            Citic.Model.Storage model = new Citic.Model.Storage();
            model.DeleteID = this.CurrentUser.UserId;
            model.DeleteTime = DateTime.Now;
            try
            {
                bool flag = StorageBll.DeleteListOnLogic(superIDList, model);
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
            catch (Exception ex)
            {
                AlertShowInTop("服务器正忙，请稍后再试！");
                Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "btn_Deletes_Click()");
            }
        }
        #endregion

        #region 修改二网--乔春羽(2013.9.3)
        protected void btn_Modify_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(grid_List.DataKeys[grid_List.SelectedRowIndex][0]);
            string path = string.Format("~/DealerManagement/StorageInfo/AddStorageInfo.aspx?type=ghj&s_i_d={0}", id);
            WindowEdit.IFrameUrl = path;
            WindowEdit.Hidden = false;
        }
        #endregion

        #region 查询数据--乔春羽
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            if (this.ddl_Dealer.SelectedValue != "-1")
            {
                GridBind();
            }
            else
            {
                AlertShowInTop("请选择经销商！");
            }
        }
        #endregion

        #region 关闭窗体时，刷新一下本页面--乔春羽
        /// <summary>
        /// 窗体关闭--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 每页显示数量改变事件--乔春羽
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
        #endregion

        #region 翻页事件--乔春羽
        /// <summary>
        /// 翻页事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);
            grid_List.PageIndex = e.NewPageIndex;

            GridBind();

            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
        }
        #endregion

        #region 判断登陆角色，显示不同的按钮--乔春羽(2013.9.3)
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
            if (urls.Contains("Search32"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert32"))
            {
                btn_Add.Visible = true;
                tbs_Add.Visible = true;
            }
            if (urls.Contains("Delete32"))
            {
                btn_Delete.Visible = true;
            }
            if (urls.Contains("Modify32"))
            {
                btn_Modify.Visible = true;
                tbs_Modify.Visible = true;
            }
            if (urls.Contains("Excel32"))
            {
                btn_ExpendExcel.Visible = true;
                hl_ExportExcel.Visible = true;
            }
            if (urls.Contains("ExcelAll32"))
            {
                btn_ExpendExcel.Visible = true;
                hl_ExportAll.Visible = true;
                bl_Separator.Visible = true;
            }
            if (urls.Contains("Match32"))
            {
            }
        }
        #endregion

        #region 数据行绑定事件--乔春羽(2013.11.29)
        protected void grid_List_RowDataBound(object sender, GridRowEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //判断是否本库
                int index = 3;
                e.Values[index] = Convert.ToBoolean(e.Values[index]) ? "本库" : "二网";
            }
        }
        #endregion

        #region 导出Excel--乔春羽(2013.12.20)
        protected void btn_ExpendExcel_Click(object sender, EventArgs e)
        {
            if (this.grid_List.Rows.Count <= 0)
            {
                AlertShowInTop("没有可导出的数据！");
                return;
            }
            //保存Excel文件
            string sheetName = "二网信息（当前页）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string sheetNameAll = "二网信息（全部）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string[] headers = { "二网名称", "二网地址", "企业名称", "距离", "是否本库" };
            string where = this.ConditionInit();
            where = where.Replace("T.", string.Empty);
            string titleName = "二网信息";
            string filePath = string.Empty;
            //保存当前页的数据
            filePath = "~/DownExcel/" + sheetName + ".xls";

            NPOIHelper npoi = new NPOIHelper();
            npoi.Create(titleName);

            //创建一行，并设定了行高
            IRow irow = npoi.CreateRow((short)60);
            //========================创建样式与字体================================
            //创建一个样式headerCellStyle
            //大标题样式
            string headerCellStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
            //给样式headerCellStyle附加字体对象
            npoi.CreateFont(headerCellStyle, 40, "黑体", NPOIFontBoldWeight.Bold, false, false);
            //创建了一个样式contentCellStyle。
            //表头样式
            string contentCellStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
            //给样式contentCellStyle附加了一个字体对象
            npoi.CreateFont(contentCellStyle, 10, "微软雅黑", NPOIFontBoldWeight.Bold, false, false);
            //内容样式
            string contentStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
            npoi.CreateFont(contentStyle, 10, "微软雅黑", NPOIFontBoldWeight.Normal, false, false);
            //========================创建样式与字体================================
            //表头大标题
            npoi.CreateCells(headers.Length, irow, headerCellStyle);
            npoi.SetCellValue(irow, 0, titleName);
            npoi.SetCellRangeAddress(0, 0, 0, headers.Length - 1);
            //表头小标题
            IRow rowHeader = npoi.CreateRow();
            npoi.CreateCells(headers, rowHeader, contentCellStyle);

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = this.StorageBll.GetAllListByProcess(where, rowbegin, rowend).Tables[0];

            string[] columns = { "StorageName", "Address", "DealerName", "Distence", "IsLocalStorage" };
            npoi.DataTableToExcel(dt, columns, contentStyle);

            //保存文件
            filePath = "~/DownExcel/" + sheetName + ".xlsx";
            npoi.Save(Server.MapPath(filePath));

            //显示下载地址
            hl_ExportExcel.NavigateUrl = filePath;


            //保存所有的数据
            npoi = new NPOIHelper();
            npoi.Create(titleName);

            //创建一行，并设定了行高
            irow = npoi.CreateRow((short)60);
            //========================创建样式与字体================================
            //创建一个样式headerCellStyle
            //大标题样式
            headerCellStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
            //给样式headerCellStyle附加字体对象
            npoi.CreateFont(headerCellStyle, 40, "黑体", NPOIFontBoldWeight.Bold, false, false);
            //创建了一个样式contentCellStyle。
            //表头样式
            contentCellStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
            //给样式contentCellStyle附加了一个字体对象
            npoi.CreateFont(contentCellStyle, 10, "微软雅黑", NPOIFontBoldWeight.Bold, false, false);
            //内容样式
            contentStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
            npoi.CreateFont(contentStyle, 10, "微软雅黑", NPOIFontBoldWeight.Normal, false, false);
            //========================创建样式与字体================================
            //表头大标题
            npoi.CreateCells(headers.Length, irow, headerCellStyle);
            npoi.SetCellValue(irow, 0, titleName);
            npoi.SetCellRangeAddress(0, 0, 0, headers.Length - 1);
            //表头小标题
            rowHeader = npoi.CreateRow();
            npoi.CreateCells(headers, rowHeader, contentCellStyle);

            dt = this.StorageBll.GetAllListByProcess(where, 0, 0).Tables[0];

            npoi.DataTableToExcel(dt, columns, contentStyle);

            //保存文件
            filePath = "~/DownExcel/" + sheetNameAll + ".xlsx";
            npoi.Save(Server.MapPath(filePath));

            hl_ExportAll.NavigateUrl = filePath;

        }
        #endregion
    }
}