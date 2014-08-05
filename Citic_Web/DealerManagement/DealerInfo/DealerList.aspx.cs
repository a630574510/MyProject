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
namespace Citic_Web.DealerManagement.DealerInfo
{
    public partial class DealerList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.btn_Add.OnClientClick = WindowAdd.GetShowReference("../../DealerManagement/DealerInfo/AddDealer.aspx");

                this.btn_Deletes.OnClientClick = grid_List.GetNoSelectionAlertReference("请选择一条数据！");
                this.btn_Match.OnClientClick = grid_List.GetNoSelectionAlertReference("请选择一条数据！");
                this.btn_Deletes.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", grid_List.GetSelectedCountReference());
                this.btn_ExportExcel.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("没有选择数据！");
                this.btn_Modify.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("没有选择数据！");

                BankBind();
                BusinessModeBind();
                FinancingModeBind();

                RoleValidate();
            }
        }

        #region 实例化成员变量--乔春羽
        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            string DealerName = this.txt_DealerName.Text;
            int BusinessMode = int.Parse(ddl_BusinessMode.SelectedValue);
            int FinancingMode = int.Parse(ddl_FinancingMode.SelectedValue);
            string BrandName = this.txt_Brand.Text;
            int BankID = int.Parse(ddl_Bank.SelectedValue);
            StringBuilder where = new StringBuilder("IsDelete=0");

            string condit = " CollaborateType=1 ";
            StringBuilder db_Where = new StringBuilder(condit);
            if (!string.IsNullOrEmpty(DealerName))
            {
                where.AppendFormat(" and DealerName like '%{0}%'", DealerName);
            }
            if (BusinessMode != -1)
            {
                db_Where.AppendFormat(" and BusinessMode={0}", BusinessMode);
            }
            if (FinancingMode != -1)
            {
                db_Where.AppendFormat(" and FinancingMode like '%{0}%'", FinancingMode);
            }
            if (BrandName != null && BrandName != string.Empty)
            {
                db_Where.AppendFormat(" and BrandName like '%{0}%'", BrandName);
            }
            if (BankID != -1)
            {
                db_Where.AppendFormat(" and BankID = '{0}'", BankID);
            }
            //得到符合条件的“经销商ID”
            if (db_Where.Length > 0)
            {
                string[] DealerIDs = Dealer_BankBll.GetDealerIDBySearch(db_Where.ToString());
                if (DealerIDs != null && DealerIDs.Length > 0)
                {
                    where.AppendFormat(" and DealerID in ({0}) ", string.Join(",", DealerIDs));
                }
                else
                {
                    where.Append(" and DealerID in (0) ");
                }
            }

            //权限过滤
            int roleID = this.CurrentUser.RoleId;
            switch (roleID)
            {
                case 10:    //监管员
                    //根据监管员ID，查询其所监管的经销商
                    where.AppendFormat(" and SupervisorID={0}", this.CurrentUser.RelationID);
                    break;
                case 5:     //市场专员
                case 6:     //品牌专员
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
                    _dt = Dealer_BankBll.GetList(ids.ToString()).Tables[0];
                    ids = null;
                    ids = new StringBuilder(" DealerID in (");
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
                    break;
                case 9:     //厂家
                    break;
            }
            return where.ToString();
        }
        #endregion

        #region 绑定数据--乔春羽
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            DataTable dt = null;
            //where条件
            string where = ConditionInit();

            //设置表格的总数据量
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
                dt = DealerBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

                if (dt != null || dt.Rows.Count > 0)
                {
                    grid_List.DataSource = dt;
                    grid_List.DataBind();
                }
                else 
                {
                    AlertShowInTop("没有数据！");
                }
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
            return DealerBll.GetRecordCount(where);
        }

        /// <summary>
        /// 绑定银行信息--乔春羽
        /// </summary>
        private void BankBind()
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
        }

        /// <summary>
        /// 显示业务模式--乔春羽
        /// </summary>
        private void BusinessModeBind()
        {
            AddItemByInsert(ddl_BusinessMode, "请选择", "-1", 0);
            AddItemByInsert(ddl_BusinessMode, "车证模式", "1", -1);
            AddItemByInsert(ddl_BusinessMode, "合格证模式", "2", -1);
            AddItemByInsert(ddl_BusinessMode, "巡库模式", "3", -1);
            ddl_BusinessMode.SelectedIndex = 0;
        }

        /// <summary>
        /// 显示融资模式--乔春羽
        /// </summary>
        private void FinancingModeBind()
        {
            AddItemByInsert(ddl_FinancingMode, "请选择", "-1", 0);
            AddItemByInsert(ddl_FinancingMode, "承兑汇票", "1", -1);
            AddItemByInsert(ddl_FinancingMode, "法人透支", "2", -1);
            AddItemByInsert(ddl_FinancingMode, "流动贷款", "3", -1);
            AddItemByInsert(ddl_FinancingMode, "信用证", "4", -1);
            ddl_FinancingMode.SelectedIndex = 0;
        }
        #endregion

        #region 行绑定事件--乔春羽
        /// <summary>
        /// 行绑定事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            if (e.DataItem != null)
            {
                int index = 1;
                //企业属性
                string dealerType = Convert.ToString(e.Values[index]);
                if (dealerType.Contains("1"))
                {
                    dealerType = dealerType.Replace("1", "民营");
                }
                if (dealerType.Contains("2"))
                {
                    dealerType = dealerType.Replace("2", "国营");
                }
                if (dealerType.Contains("3"))
                {
                    dealerType = dealerType.Replace("3", "集团");
                }
                if (dealerType.Contains("4"))
                {
                    dealerType = dealerType.Replace("4", "单店");
                }
                e.Values[index] = dealerType;
                //是否是集团性质
                index = 2;
                bool isGroup = Convert.ToBoolean(e.Values[index]);
                e.Values[index] = isGroup ? "是" : "否";
                //是否有其他产业
                index = 4;
                string hasOtherIndustries = Convert.ToString(e.Values[index]);
                e.Values[index] = string.IsNullOrEmpty(hasOtherIndustries) ? "无" : hasOtherIndustries;
            }
        }
        #endregion

        #region 行命令事件--乔春羽
        protected void grid_List_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.CommandName != null && e.CommandName != string.Empty)
            {
                int dealerID = Convert.ToInt32(grid_List.DataKeys[e.RowIndex][0]);

                //要删除该信息
                if (e.CommandName == "delete")
                {
                    try
                    {
                        bool flag = DealerBll.DeleteOnLogic(new Citic.Model.Dealer() { DealerID = dealerID, DeleteID = this.CurrentUser.UserId, DeleteTime = DateTime.Now });
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
                else if (e.CommandName == "sd")
                {
                    W_SupervisorHistory.IFrameUrl = "~/DealerManagement/DealerInfo/SupervisorHistory.aspx?id=" + dealerID;
                    W_SupervisorHistory.Hidden = false;
                }
            }
        }
        #endregion

        #region 批量删除--乔春羽
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
        #endregion

        #region 查询操作（根据不同的用户，查询出不同的数据）--乔春羽
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 每页显示数量改变事件--乔春羽
        /// <summary>
        /// 每页显示数量改变事件
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
        /// 翻页事件
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

        //<summary>
        //关闭窗体
        //</summary>
        //<param name="sender"></param>
        //<param name="e"></param>
        protected void Window_Close(object sender, FineUI.WindowCloseEventArgs e)
        {
            GridBind();
        }

        #region 导出Excel--乔春羽
        protected void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            if (this.grid_List.Rows.Count <= 0)
            {
                AlertShowInTop("没有可导出的数据！");
                return;
            }
            //保存Excel文件
            string sheetName = "经销商信息（部分数据）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string sheetNameAll = "经销商信息（全部）_" + ConvertLongDateTimeToUI(DateTime.Now);

            //得到“所选行”的下标数组
            int[] indexs = this.grid_List.SelectedRowIndexArray;
            List<string> DealerIDs = new List<string>();
            //得到“所选择”的经销商ID
            if (indexs != null && indexs.Length > 0)
            {
                foreach (int index in indexs)
                {
                    DealerIDs.Add(this.grid_List.Rows[index].DataKeys[0].ToString());
                }
            }
            //根据这些“选择”的经销商ID查询出数据来，没选就查全部
            DataTable dt = Dealer_BankBll.GetDataForExcel(DealerIDs.ToArray());
            DealerIDs.Clear();

            string filePath = string.Empty;
            //保存当前页的数据
            ExcelEditHelper.Create();
            ExcelEditHelper.AddSheet(sheetName);

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

            dt = Dealer_BankBll.GetDataForExcel(DealerIDs.ToArray());

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

        #region 匹配监管员--乔春羽(2013.8.28)
        protected void btn_Match_Click(object sender, EventArgs e)
        {
            string path = "~/DealerManagement/DealerInfo/ChoiseSuper.aspx";
            if (File.Exists(Server.MapPath(path)))
            {
                string dealerid = grid_List.DataKeys[grid_List.SelectedRowIndex][0].ToString();
                W_Match.IFrameUrl = string.Format("{0}?id={1}", path, dealerid);
                W_Match.Hidden = false;
            }
        }
        #endregion

        #region 修改--乔春羽(2013.9.3)
        protected void btn_Modify_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(grid_List.DataKeys[grid_List.SelectedRowIndex][0]);
            string path = string.Format("~/DealerManagement/DealerInfo/EditDealer.aspx?DealerID={0}", id);
            WindowEdit.IFrameUrl = path;
            WindowEdit.Hidden = false;
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
            if (urls.Contains("Search31"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert31"))
            {
                btn_Add.Visible = true;
            }
            if (urls.Contains("Delete31"))
            {
                tbs_Delete.Visible = true;
                btn_Deletes.Visible = true;
            }
            if (urls.Contains("Modify31"))
            {
                tbs_Modify.Visible = true;
                btn_Modify.Visible = true;
            }
            if (urls.Contains("Excel31"))
            {
                btn_ExportExcel.Visible = true;
                hl_ExportExcel.Visible = true;
            }
            if (urls.Contains("ExcelAll31"))
            {
                btn_ExportExcel.Visible = true;
                hl_ExportAll.Visible = true;
                bl_Separator.Visible = true;
            }
            if (urls.Contains("Match31"))
            {
                tbs_Match.Visible = true;
                btn_Match.Visible = true;
            }
        }
        #endregion
    }
}