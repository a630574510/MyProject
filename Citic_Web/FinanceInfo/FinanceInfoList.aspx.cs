using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NPOI.SS.UserModel;
namespace Citic_Web.Financing
{
    public partial class FinanceInfoList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_Add.OnClientClick = WindowAdd.GetShowReference("../FinanceInfo/AddDraft.aspx");
                btn_Import.OnClientClick = WindowDraftInfo.GetShowReference("../FinanceInfo/ImportDrafts.aspx");
                btn_Delete.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", grid_List.GetSelectedCountReference());
                btn_Clear.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("没有选择数据！");

                //加载银行信息
                BankDataBind();
                //权限过滤--乔春羽(2013.8.27)
                RoleValidate();
            }
        }
        #region PrivateFields--乔春羽(2013.12.2)
        private const string ROLE = "roles";
        #endregion

        #region 绑定数据--乔春羽
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件
            string where = ConditionInit();

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            if (grid_List.PageCount <= grid_List.PageIndex)
            {
                grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataSet ds = DraftBll.GetListByPage(where, "BeginTime DESC", rowbegin, rowend);
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count <= 0)
                {
                    AlertShow("没有数据！");
                }
                grid_List.DataSource = dt;
                grid_List.DataBind();
            }
            else
            {
                grid_List.DataSource = null;
                grid_List.DataBind();
            }
        }

        /// <summary>
        /// 得到查询条件
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("IsDelete=0 ");
            string dealerName = this.txt_Dealer.Text;

            //权限过滤
            //监管员
            if (this.CurrentUser.RoleId == 10)
            {
                string[] ids = DealerBll.GetDealerIDsBySupervisorID(this.CurrentUser.RelationID.Value);
                if (ids != null && ids.Length > 0)
                {
                    where.AppendFormat(" AND (DealerID IN ({0}))", string.Join(",", ids));
                }
                else { where.Append(" AND (DealerID IN (0))"); }
            }
            else if (this.CurrentUser.RoleId == 8)  //银行
            {
                DataSet dsBank = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                int bankID = 0;
                if (dsBank != null && dsBank.Tables.Count > 0)
                {
                    DataTable dt = dsBank.Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        bankID = Convert.ToInt32(dt.Rows[0]["MappingID"].ToString());
                        where.AppendFormat(" And BankID = '{0}' ", bankID);
                    }
                    else
                    {
                        where.Append(" And BankID = '0' ");
                    }
                }

                //经销商的过滤条件
                string[] dealerIDs = null;
                if (bankID != 0)
                {
                    dealerIDs = Dealer_BankBll.GetDealerIDsByBankID(bankID);
                }
                if (dealerIDs != null && dealerIDs.Length >= 1)
                {
                    where.AppendFormat(" AND DealerID in ({0})", string.Join(",", dealerIDs));
                }
                else
                {
                    where.Append(" AND DealerID = 0");
                }
            }
            else if (this.CurrentUser.RoleId == 5 || this.CurrentUser.RoleId == 6)  //市场专员Or业务专员
            {
                StringBuilder ids = new StringBuilder(string.Empty);
                ids.Append(" BankID in (");
                DataTable _dt = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId)).Tables[0];
                if (_dt != null && _dt.Rows.Count > 0)
                {
                    foreach (DataRow row in _dt.Rows)
                    {
                        ids.AppendFormat("{0},", row["MappingID"].ToString());
                    }
                    ids.Remove(ids.Length - 1, 1);
                }
                else
                {
                    ids.Append("0");
                }
                ids.Append(")");
                _dt = null;
                _dt = Dealer_BankBll.GetList(" A." + ids.ToString().TrimStart()).Tables[0];

                ids.Append(" AND ");
                ids.Append(" DealerID in (");
                if (_dt != null && _dt.Rows.Count > 0)
                {
                    foreach (DataRow row in _dt.Rows)
                    {
                        ids.AppendFormat("{0},", row["DealerID"].ToString());
                    }
                    ids.Remove(ids.Length - 1, 1);
                }
                else
                {
                    ids.Append("0");
                }
                ids.Append(")");
                if (ids != null && ids.Length != 0)
                {
                    where.AppendFormat(" AND {0}", ids.ToString());
                }
            }

            if (this.ddl_Status.SelectedValue != "-1")
            {
                where.AppendFormat(" AND DraftType = {0} ", this.ddl_Status.SelectedValue);
            }

            if (!string.IsNullOrEmpty(dealerName))
            {
                if (dealerName.IndexOf('_') > 0)
                {
                    if (!string.IsNullOrEmpty(dealerName.Split('_')[1]))
                    {
                        where.AppendFormat(" and DealerID = '{0}'", dealerName.Split('_')[1]);
                    }
                    else
                    {
                        where.AppendFormat(" and DealerName like '%{0}%'", dealerName);
                    }
                }
                else
                {
                    where.AppendFormat(" and DealerName like '%{0}%'", dealerName);
                }
            }

            if (this.ddl_Bank.SelectedValue != null && this.ddl_Bank.SelectedValue != "-1")
            {
                where.AppendFormat(" and BankID={0}", ddl_Bank.SelectedValue);
            }
            if (this.ddl_Status.SelectedValue != null && this.ddl_Status.SelectedValue != "-1")
            {
                where.AppendFormat(" and DraftType={0}", ddl_Status.SelectedValue);
            }
            if (dp_Start.Text != string.Empty && dp_End.Text == string.Empty)
            {
                DateTime start = DateTime.Parse(dp_Start.Text);
                where.AppendFormat(" and BeginTime > '{0}'", start);
            }
            else if (dp_Start.Text != string.Empty && dp_End.Text == string.Empty)
            {
                DateTime end = DateTime.Parse(dp_End.Text).AddDays(1);
                where.AppendFormat(" and EndTime < '{0}'", end);
            }
            else if (dp_Start.Text != string.Empty && dp_End.Text != string.Empty)
            {
                DateTime start = DateTime.Parse(dp_Start.Text);
                DateTime end = DateTime.Parse(dp_End.Text).AddDays(1);
                if (start < end)
                {
                    where.AppendFormat(" and BeginTime = '{0}' and EndTime = '{1}'", start, end);
                }
            }
            if (this.txt_DraftNo.Text != string.Empty)
            {
                where.AppendFormat(" and DraftNo like '%{0}%'", this.txt_DraftNo.Text);
            }
            return where.ToString();
        }

        /// <summary>
        /// 获得查询后结果的总数据数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return DraftBll.GetRecordCount(where);
        }
        #endregion

        #region 查询检索--乔春羽
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 加载合作行信息--乔春羽
        private void BankDataBind()
        {
            ddl_Bank.Items.Clear();
            string val = this.txt_Dealer.Text;
            DataTable dt = null;
            if (!string.IsNullOrEmpty(val))
            {
                if (val.IndexOf('_') >= 0)
                {
                    val = val.Split('_')[1];
                    StringBuilder strWhere = new StringBuilder(string.Format(" D.DealerID='{0}' ", val));
                    switch (this.CurrentUser.RoleId)
                    {
                        case 8:
                            Citic.Model.UserMapping model = UMBLL.GetModelByCondition(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", this.CurrentUser.UserId, this.CurrentUser.RoleId));
                            if (model != null)
                            {
                                strWhere.AppendFormat(" AND T.BankID = '{0}' ", model.MappingID.Value);
                            }
                            else
                            {
                                strWhere.Append(" AND T.BankID = '0' ");
                            }
                            break;
                        case 5:
                        case 6:
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

                            }
                            break;
                    }

                    dt = Dealer_BankBll.GetBanks(strWhere.ToString()).Tables[0];
                }
            }
            else    //如果没有选择经销商，则加载出该用户所有的“有逻辑关系”的合作行
            {
                StringBuilder where = new StringBuilder();
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
                    else
                    {
                        dt = BankBll.GetList(" BankID='0' ").Tables[0];
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
                    dt = BankBll.GetAllList().Tables[0];
                }
            }
            ddl_Bank.DataTextField = "BankName";
            ddl_Bank.DataValueField = "BankID";
            ddl_Bank.DataSource = dt;
            ddl_Bank.DataBind();
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 行命令事件--乔春羽
        /// <summary>
        /// 批量删除--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);

            string[] DelMenu = hfSelectedIDS.Text.Trim().Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
            string superIDList = "";
            for (int i = 0; i < DelMenu.Length; i++)
            {
                superIDList += DelMenu[i] + ",";
            }
            superIDList = superIDList.Substring(0, superIDList.Length - 1);
            Citic.Model.Dealer model = new Citic.Model.Dealer();
            model.DeleteID = this.CurrentUser.UserId;
            model.DeleteTime = DateTime.Now;
            bool flag = DealerBll.DeleteListOnLogic(superIDList, model);
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

        protected void grid_List_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.RowIndex > 0)
            {

            }
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

        #region 导出Excel--乔春羽
        protected void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            if (this.grid_List.Rows.Count <= 0)
            {
                AlertShowInTop("没有可导出的数据！");
                return;
            }

            if (this.ddl_Bank.SelectedValue == "-1")
            {
                AlertShowInTop("请选择银行！");
                return;
            }

            try
            {
                //保存Excel文件
                string sheetName = "汇票信息（当前页）_" + ConvertLongDateTimeToUI(DateTime.Now);
                string sheetNameAll = "汇票信息（全部）_" + ConvertLongDateTimeToUI(DateTime.Now);
                string filePath = string.Empty;
                DataTable dt = null;
                string[] headers = { "企业", "质押号", "保证金帐号", "汇票号", "票面金额", "开票日期", "到期日期", "回款金额", "敞口金额", "已押金额", "未押金额", "状态" };
                NPOIHelper npoi = new NPOIHelper();
                npoi.Create("汇票信息");

                //创建一行，并设定了行高
                IRow irow = npoi.CreateRow((short)60);
                //========================创建样式与字体================================
                //创建一个样式headerCellStyle
                string headerCellStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
                //给样式headerCellStyle附加字体对象
                npoi.CreateFont(headerCellStyle, 40, "黑体", NPOIFontBoldWeight.Bold, false, false);
                //创建了一个样式contentCellStyle。
                string contentCellStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
                //给样式contentCellStyle附加了一个字体对象
                npoi.CreateFont(contentCellStyle, 10, "微软雅黑", NPOIFontBoldWeight.Bold, false, false);

                string contentStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
                npoi.CreateFont(contentStyle, 10, "微软雅黑", NPOIFontBoldWeight.Normal, false, false);
                //========================创建样式与字体================================
                //表头大标题
                npoi.CreateCells(headers.Length, irow, headerCellStyle);
                npoi.SetCellValue(irow, 0, "汇票信息");
                npoi.SetCellRangeAddress(0, 0, 0, headers.Length - 1);
                //表头小标题
                IRow rowHeader = npoi.CreateRow();

                npoi.CreateCells(headers, rowHeader, contentCellStyle);

                //保存文件
                filePath = "~/DownExcel/" + sheetNameAll + ".xlsx";
                npoi.Save(Server.MapPath(filePath));

                //分批次追加数据
                //填充数据
                string[] columns = { "DealerName", "PledgeNo", "GuaranteeNo", "DraftNo", "DarftMoney", "BeginTime", "EndTime", "HKMoney", "CKMoney", "YYMoney", "WYMoney", "DraftType" };
                string where = this.ConditionInit();
                int currentPage = 1;
                int pageSize = 10000;
                int allCount = this.GetCountBySearch(where);
                int pageCount = (allCount + pageSize - 1) / pageSize;
                for (int i = 1; i <= pageCount; i++)
                {
                    npoi.Open(Server.MapPath(filePath));
                    contentStyle = npoi.CreateCellStyle(NPOIAlign.Center, NPOIVAlign.Center, false, false, true);
                    npoi.CreateFont(contentStyle, 10, "微软雅黑", NPOIFontBoldWeight.Normal, false, false);

                    currentPage = i;
                    int rowbegin = (currentPage - 1) * pageSize + 1;
                    int rowend = currentPage * pageSize;

                    dt = DraftBll.GetAllListByProcess(where, rowbegin, rowend).Tables[0];
                    npoi.AppendData(dt, columns, contentStyle);

                    npoi.Save(Server.MapPath(filePath));
                }


                //下载Excel文件
                hl_ExportAll.NavigateUrl = filePath;

            }
            catch (Exception ex)
            {
                AlertShowInTop("数据量过大，请分页导出");
                Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "btn_ExportExcel_Click()--导出Excel数据");
            }
        }
        #endregion

        #region 批量删除--乔春羽
        protected void btn_Deletes_Click(object sender, EventArgs e)
        {
            try
            {
                SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);

                string[] DelMenu = hfSelectedIDS.Text.Trim().Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');

                List<Citic.Model.Draft> models = new List<Citic.Model.Draft>();

                for (int i = 0; i < DelMenu.Length; i++)
                {
                    for (int j = 0; j < this.grid_List.Rows.Count; j++)
                    {
                        GridRow row = this.grid_List.Rows[j];
                        string id = row.Values[13];
                        if (DelMenu[i] == id)
                        {
                            string bankID = row.Values[15];
                            string dealerID = row.Values[16];
                            string draftNo = row.Values[14];
                            models.Add(new Citic.Model.Draft() { ID = string.IsNullOrEmpty(id) ? 0 : int.Parse(id), DraftNo = draftNo, BankID = string.IsNullOrEmpty(bankID) ? 0 : int.Parse(bankID), DealerID = string.IsNullOrEmpty(dealerID) ? 0 : int.Parse(dealerID) });
                        }
                    }
                }
                bool flag = DraftBll.DeleteList(models);
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
                AlertShowInTop("出现错误，请稍后再试！");
                Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "btn_Deletes_Click()--批量删除汇票");
            }
        }
        #endregion

        #region Window_Close--乔春羽
        protected void Window_Close(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 判断登陆角色，显示不同的按钮--乔春羽(2013.8.27)
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
            if (urls.Contains("Search41"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert41"))
            {
                btn_Add.Visible = true;
                tbs_Add.Visible = true;
            }
            if (urls.Contains("Delete41"))
            {
                btn_Delete.Visible = true;
                tbs_Delete.Visible = true;
            }
            if (urls.Contains("Import41"))
            {
                btn_Import.Visible = true;
                tbs_Excel.Visible = true;
            }
            if (urls.Contains("Clear41"))
            {
                btn_Clear.Visible = true;
            }
            if (urls.Contains("Excel41"))
            {
                btn_Export.Visible = true;
                hl_ExportExcel.Visible = true;
            }
            if (urls.Contains("ExcelAll41"))
            {
                btn_Export.Visible = true;
                hl_ExportAll.Visible = true;
                bl_Separator.Visible = true;
            }
        }
        #endregion

        #region “清票”操作--乔春羽(2013.12.2)
        protected void btn_Clear_Click(object sender, EventArgs e)
        {
            int[] rowIndexs = this.grid_List.SelectedRowIndexArray;
            List<String> draftNos = new List<string>();
            if (rowIndexs != null && rowIndexs.Length >= 0)
            {
                foreach (int rowIndex in rowIndexs)
                {
                    string draftNo = grid_List.DataKeys[rowIndex][1].ToString();
                    string type = grid_List.Rows[rowIndex].DataKeys[4].ToString();
                    if (!string.IsNullOrEmpty(type))
                    {
                        if (type == "True")    //未清票，可以执行“清票”操作
                        {
                            string bankID = grid_List.Rows[rowIndex].DataKeys[2].ToString();
                            string dealerID = grid_List.Rows[rowIndex].DataKeys[3].ToString();
                            string tableName = string.Format("tb_Car_{0}_{1}", bankID, dealerID);
                            int outcount = CarBll.GetRecordCount(string.Format(" DraftNo = '{0}' and Statu = 0 ", draftNo), tableName);
                            int allcount = CarBll.GetRecordCount(string.Format(" DraftNo = '{0}' ", draftNo), tableName);
                            if (outcount == allcount)
                            {
                                draftNos.Add(draftNo);
                                continue;
                            }
                            else
                            {
                                AlertShowInTop("该票 “" + draftNo + "” 尚有车未出库，不能清票！");
                            }
                        }
                        else if (type == "False")   //已清票，不能执行“清票”操作
                        {
                            AlertShowInTop("该票已清，不可再清！");
                        }
                    }
                }
                bool flag = DraftBll.DraftClear(draftNos.ToArray(), this.CurrentUser.UserId);
                if (flag)
                {
                    AlertShowInTop("清票成功！");
                }
                else
                {
                    AlertShowInTop("清票失败！");
                }
            }
        }
        #endregion

        #region 选择银行时，联动出经销商--乔春羽(2013.12.2)
        protected void txt_Bank_TextChanged(object sender, EventArgs e)
        {
            BankDataBind();
        }
        #endregion
    }
}