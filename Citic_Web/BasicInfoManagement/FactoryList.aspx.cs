using System;
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
namespace Citic_Web.BasicInfoManagement
{
    public partial class FactoryList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_AddBank.OnClientClick = WindowAdd.GetShowReference("../BasicInfoManagement/AddFactory.aspx", "添加厂商");
                btn_DeleteBank.OnClientClick = grid_List.GetNoSelectionAlertReference("至少要选择一项！");
                btn_DeleteBank.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", grid_List.GetSelectedCountReference());
                btn_Modify.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("没有选择数据！");
                btn_Search.Visible = false;
                //权限过滤
                RoleValidate();
            }
        }

        /// <summary>
        /// 数据绑定--乔春羽
        /// </summary>
        /// <param name="where"></param>
        private void GridBind()
        {
            DataTable dt = null;
            string where = ConditionInit();

            grid_List.RecordCount = GetAllCount(where);

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
                dt = FactoryBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

                grid_List.DataSource = dt;
                grid_List.DataBind();

                if (dt == null || dt.Rows.Count == 0)
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
        /// 获取记录数--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetAllCount(string where)
        {
            return FactoryBll.GetRecordCount(where);
        }

        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder(" IsDelete=0 ");

            //过滤权限
            //监管员
            if (this.CurrentUser.RoleId == 10)
            {
                where.AppendFormat(@" AND (FactoryID IN 
(select FactoryID from tb_Brand_List where BrandID in 
(select BrandID from tb_Dealer_Bank_List where DealerID IN 
(select DealerID from tb_Dealer_List where SupervisorID='{0}') 
group by BrandID))) ", this.CurrentUser.RelationID.Value);
            }

            if (!string.IsNullOrEmpty(this.txt_Search.Text))
            {
                where.AppendFormat(" And FactoryName like '%{0}%' ", this.txt_Search.Text);
            }
            return where.ToString();
        }

        /// <summary>
        /// 每页显示数量改变事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_List.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GridBind();
        }

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
            GridBind();
        }

        #region 批量删除--乔春羽
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
            Citic.Model.Factory model = new Citic.Model.Factory();
            model.DeleteID = this.CurrentUser.UserId;
            model.DeleteTime = DateTime.Now;
            bool flag = FactoryBll.DeleteListOnLogic(superIDList, model);
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
        protected void btn_ExpendExcel_Click(object sender, EventArgs e)
        {
            if (this.grid_List.Rows.Count <= 0)
            {
                AlertShowInTop("没有可导出的数据！");
                return;
            }
            //保存Excel文件
            string sheetName = "厂商信息（当前页）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string sheetNameAll = "厂商信息（全部）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string where = this.ConditionInit();
            string filePath = string.Empty;
            string[] headers = { "厂家名称", "地址", "添加人", "添加时间" };
            string titleName = "厂商信息";
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
            DataTable dt = this.FactoryBll.GetAllListByProcess(where, rowbegin, rowend).Tables[0];


            string[] columns = { "FactoryName", "Address", "CreateName", "CreateTime" };
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

            dt = this.FactoryBll.GetAllListByProcess(where, 0, 0).Tables[0];

            npoi.DataTableToExcel(dt, columns, contentStyle);

            //保存文件
            filePath = "~/DownExcel/" + sheetNameAll + ".xlsx";
            npoi.Save(Server.MapPath(filePath));

            hl_ExportAll.NavigateUrl = filePath;

        }
        #endregion

        #region 修改--乔春羽(2013.9.3)
        protected void btn_Modify_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(grid_List.DataKeys[grid_List.SelectedRowIndex][0]);
            string path = string.Format("~/BasicInfoManagement/EditFactoryInfo.aspx?FactoryID={0}", id);
            WindowEdit.IFrameUrl = path;
            WindowEdit.Hidden = false;
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
            if (urls.Contains("Search23"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert23"))
            {
                btn_AddBank.Visible = true;
                tbs_Add.Visible = true;
            }
            if (urls.Contains("Delete23"))
            {
                tbs_Delete.Visible = true;
                btn_DeleteBank.Visible = true;
            }
            if (urls.Contains("Modify23"))
            {
                tbs_Modify.Visible = true;
                btn_Modify.Visible = true;
            }
            if (urls.Contains("Excel23"))
            {
                btn_ExportExcel.Visible = true;
                hl_ExportExcel.Visible = true;
            }
            if (urls.Contains("ExcelAll23"))
            {
                btn_ExportExcel.Visible = true;
                hl_ExportAll.Visible = true;
            }
        }
        #endregion
    }
}