using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;

using FineUI;
namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class CarErrorCount : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoleValidate();
            }
        }
        #region PrivateFields--乔春羽(2013.8.14)
        private Citic.BLL.StockError _SEBLL = null;

        public Citic.BLL.StockError SEBLL
        {
            get
            {
                if (_SEBLL == null)
                {
                    _SEBLL = new Citic.BLL.StockError();
                }
                return _SEBLL;
            }
        }

        private DataTable _dt = null;

        public DataTable DataSource
        {
            get
            {
                if (_dt == null)
                {
                    if (ViewState["DS"] != null)
                    {
                        _dt = ViewState["DS"] as DataTable;
                    }
                    else
                    {
                        _dt = new DataTable();
                    }
                }
                else if (_dt != null)
                {
                    ViewState["DS"] = _dt;
                }
                return _dt;
            }
            set
            {
                _dt = value;
            }
        }
        #endregion

        #region 绑定数据--乔春羽(2013.8.14)
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件 
            string where = ConditionInit();
            string path = Common.OperateConfigFile.getValue("Dealer_Bank");
            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = StockErrorBll.StockErrorReportSearch(Server.MapPath(path), "ser", where, rowbegin, rowend).Tables[0];

            grid_List.DataSource = dt;
            grid_List.DataBind();
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            //StringBuilder where = new StringBuilder(" (Status = 1 or Status = 3)");
            StringBuilder where = new StringBuilder("");

            return where.ToString();
        }

        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return StockErrorBll.GetRecordCount(where);
        }
        #endregion

        #region 行命令事件--乔春羽(2013.8.20)
        protected void grid_List_RowCommand(object sender, FineUI.GridCommandEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(grid_List.DataKeys[e.RowIndex][0]);
                bool flag = false;
                try
                {
                    flag = CECBLL.Delete(id);
                }
                catch (Exception)
                {
                }
                if (flag)
                {
                    Alert.ShowInTop("删除成功！");
                    GridBind();
                }
                else
                {
                    Alert.ShowInTop("删除失败！");
                }
            }
        }
        #endregion

        #region 窗口关闭事件--乔春羽(2013.8.20)
        protected void WindowAdd_Close(object sender, WindowCloseEventArgs e)
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
        /// 翻页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);
            grid_List.PageIndex = e.NewPageIndex;

            //乔春羽
            GridBind();
            //乔春羽

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
            ViewState.Add("roles", urls);
            if (urls.Contains("Search73"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert73"))
            {
                //btn_Add.Visible = true;
            }
            if (urls.Contains("Excel73"))
            {
                btn_ExpendExcel.Visible = true;
                hl_ExportExcel.Visible = true;
                hl_ExportAll.Visible = true;
                bl_Separator.Visible = true;
            }
        }
        #endregion

        #region 查询--乔春羽(2013.12.12)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 导出Excel
        protected void btn_ExpendExcel_Click(object sender, EventArgs e)
        {
            string path = Common.OperateConfigFile.getValue("Dealer_Bank");
            //保存Excel文件
            string sheetName = "车辆异常统计汇总（当前页）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string sheetNameAll = "车辆异常统计汇总（全部）_" + ConvertLongDateTimeToUI(DateTime.Now);
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

            dt = StockErrorBll.StockErrorReportSearch(Server.MapPath(path), "ser_all", string.Empty, 0, 0).Tables[0];

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
    }
}