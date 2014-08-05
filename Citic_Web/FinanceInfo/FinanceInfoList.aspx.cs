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
                //btn_Export.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("没有数据！");
                btn_Delete.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", grid_List.GetSelectedCountReference());
                //加载银行信息
                //BankDataBind();
                //加载企业信息
                DealerDataBind();
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

            if (grid_List.PageCount < grid_List.PageIndex)
            {
                grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = DraftBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];
            ViewState.Add("dt", dt);

            grid_List.DataSource = dt;
            grid_List.DataBind();
        }

        /// <summary>
        /// 得到查询条件
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("IsDelete=0");

            if (!string.IsNullOrEmpty(this.txt_Bank.Text))
            {
                where.AppendFormat(" and BankID like '%{0}%'", this.txt_Bank.Text.Split('_')[1]);
            }
            if (this.ddl_Dealer.SelectedValue != null && this.ddl_Dealer.SelectedValue != "-1")
            {
                where.AppendFormat(" and DealerID={0}", ddl_Dealer.SelectedValue);
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

        #region 加载企业信息（经销商）--乔春羽
        private void DealerDataBind()
        {
            string val = this.txt_Bank.Text;
            if (val != null && val != string.Empty)
            {
                if (val.IndexOf('_') >= 0)
                {
                    val = val.Split('_')[1];
                    DataTable dt = Dealer_BankBll.GetDealerByBankForDataTable(int.Parse(val), string.Empty);

                    ddl_Dealer.DataTextField = "DealerName";
                    ddl_Dealer.DataValueField = "DealerID";
                    ddl_Dealer.DataSource = dt;
                    ddl_Dealer.DataBind();
                }
            }
            AddItemByInsert(ddl_Dealer, "请选择", "-1", 0);
        }
        #endregion

        #region 选择银行，加载企业信息--乔春羽
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            DealerDataBind();
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
                string draftNo = grid_List.DataKeys[e.RowIndex][0].ToString();
                string type = grid_List.Rows[e.RowIndex].Values[10].ToString();
                if (!string.IsNullOrEmpty(type))
                {
                    if (type == "未清票")
                    {
                        bool flag = DraftBll.DraftClear(draftNo);
                        if (flag)
                        {
                            AlertShowInTop("清票成功！");
                        }
                        else
                        {
                            AlertShowInTop("清票失败！");
                        }
                    }
                    else if (type == "已清票")
                    {
                        AlertShowInTop("该票已清，不可再清！");
                    }
                }
            }
        }
        #endregion

        #region 行绑定事件--乔春羽
        /// <summary>
        /// 行绑定事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                int index = 10;
                if (e.Values[index] != null && e.Values[index].ToString() != string.Empty)
                {
                    bool type = Convert.ToBoolean(e.Values[index]);

                    if (type)
                    {
                        e.Values[index] = "未清票";
                    }
                    else
                    {
                        e.Values[index] = "已清票";
                    }
                }
            }

            //过滤“清票”的权限
            List<string> roles = ViewState[ROLE] as List<string>;
            if (roles != null && roles.Count > 0)
            {
                if (roles.Contains("Clear41"))
                {
                    lb_Clear.Visible = true;
                }
            }
        }

        private System.Web.UI.WebControls.LinkButton GetLinkButtonByID(int rowIndex, string id)
        {
            return (grid_List.Rows[rowIndex].FindControl(id) as System.Web.UI.WebControls.LinkButton);
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
            //保存Excel文件
            string sheetName = "汇票信息（当前页）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string sheetNameAll = "汇票信息（全部）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string filePath = string.Empty;
            //保存当前页的数据
            ExcelEditHelper.Create();
            ExcelEditHelper.AddSheet(sheetName);
            DataTable dt = null;

            StringBuilder sql = new StringBuilder(" DraftNo in (");
            foreach (GridRow row in grid_List.Rows)
            {
                sql.AppendFormat("'{0}',", row.DataKeys[0]);
            }
            sql.Remove(sql.Length - 1, 1);
            sql.Append(")");
            dt = DraftBll.GetAllListByProcess(sql.ToString()).Tables[0];
            ModifyTableHeaderByGrid(grid_List, dt);

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

            dt = DraftBll.GetAllListByProcess(string.Empty).Tables[0];

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

        #region 批量删除--乔春羽
        protected void btn_Deletes_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);

            string[] DelMenu = hfSelectedIDS.Text.Trim().Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
            string superIDList = "";
            for (int i = 0; i < DelMenu.Length; i++)
            {
                superIDList += "'" + DelMenu[i] + "',";
            }
            superIDList = superIDList.Substring(0, superIDList.Length - 1);
            Citic.Model.Draft model = new Citic.Model.Draft();
            model.DeleteID = this.CurrentUser.UserId;
            model.DeleteTime = DateTime.Now;
            bool flag = DraftBll.DeleteListOnLogic(superIDList, model);
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
            }
            if (urls.Contains("Delete41"))
            {
                btn_Delete.Visible = true;
            }
            if (urls.Contains("Import41"))
            {
                btn_Import.Visible = true;
            }
            if (urls.Contains("Excel41"))
            {
                btn_Export.Visible = true;
                hl_ExportExcel.Visible = true;
                hl_ExportAll.Visible = true;
                bl_Separator.Visible = true;
            }
        }
        #endregion

        #region “清票”操作--乔春羽(2013.12.2)
        protected void Operate_Click(object sender, EventArgs e)
        {
            int rowIndex = this.grid_List.SelectedRowIndex;
            if (rowIndex > 0)
            {
                string draftNo = grid_List.DataKeys[rowIndex][0].ToString();
                string type = grid_List.Rows[rowIndex].Values[10].ToString();
                if (!string.IsNullOrEmpty(type))
                {
                    if (type == "未清票")
                    {
                        bool flag = DraftBll.DraftClear(draftNo);
                        if (flag)
                        {
                            AlertShowInTop("清票成功！");
                        }
                        else
                        {
                            AlertShowInTop("清票失败！");
                        }
                    }
                    else if (type == "已清票")
                    {
                        AlertShowInTop("该票已清，不可再清！");
                    }
                }
            }
        }
        #endregion

        #region 选择银行时，联动出经销商--乔春羽(2013.12.2)
        protected void txt_Bank_TextChanged(object sender, EventArgs e)
        {
            DealerDataBind();
        }
        #endregion
    }
}