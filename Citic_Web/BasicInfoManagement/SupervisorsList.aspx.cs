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
namespace Citic_Web.BasicInfoManagement
{
    public partial class SupervisorsList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //乔春羽
                btn_AddSupervisor.OnClientClick = WindowAdd.GetShowReference("../BasicInfoManagement/AddSupervisor.aspx");
                btn_DeleteSupervisor.OnClientClick = grid_List.GetNoSelectionAlertReference("至少要选择一项！");
                btn_DeleteSupervisor.ConfirmText = String.Format("你确定要删除选中的&nbsp;<b><script>{0}</script></b>&nbsp;项吗？", grid_List.GetSelectedCountReference());

                btn_Modify.OnClientClick = grid_List.GetNoSelectionAlertInParentReference("没有选择数据！");
                //乔春羽
                RoleValidate();
            }
        }

        #region 数据绑定--乔春羽
        /// <summary>
        /// 绑定数据--乔春羽
        /// </summary>
        private void GridBind()
        {
            string where = ConditionInit();
            //指定总记录数
            grid_List.RecordCount = GetAllCount(where);

            if (this.grid_List.PageCount < this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = SupervisorBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

            grid_List.DataSource = dt;
            grid_List.DataBind();

        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("T.IsDelete=0");

            //过滤权限
            //监管员
            if (this.CurrentUser.RoleId == 10)
            {
                where.AppendFormat(" AND T.SupervisorID='{0}' ", this.CurrentUser.RelationID.Value);
            }

            if (!string.IsNullOrEmpty(txt_Search.Text))
            {
                where.AppendFormat(" AND T.SupervisorName like '%{0}%'", txt_Search.Text);
            }
            return where.ToString();
        }
        /// <summary>
        /// 获取记录数--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetAllCount(string where)
        {
            return SupervisorBll.GetRecordCount(where);
        }
        #endregion

        #region 行数据绑定事件--乔春羽(2013.9.3)
        /// <summary>
        /// 绑定数据时，做一些处理--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_SupervisorsList_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                //性别
                e.Values[1] = Convert.ToInt32(e.Values[1]) == 0 ? "男" : "女";
                //工作来源
                e.Values[5] = Convert.ToInt32(e.Values[5]) == 0 ? "属地" : "外派";
            }
        }
        #endregion

        #region 数据行命令事件--乔春羽(2013.9.3)
        /// <summary>
        /// 行命令事件（删除）--乔春羽
        /// </summary>
        protected void grid_SupervisorsList_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                object[] keys = grid_List.DataKeys[e.RowIndex];
                if (keys.Length > 0)
                {
                    int superID = int.Parse(keys[0].ToString());
                    Citic.Model.Supervisor model = new Citic.Model.Supervisor();
                    model.DeleteID = this.CurrentUser.UserId;
                    model.DeleteTime = DateTime.Now;
                    model.SupervisorID = superID;

                    bool flag = SupervisorBll.DeleteOnLogic(model);
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
        #endregion

        #region 批量删除--乔春羽(2013.9.3)
        /// <summary>
        /// 批量删除--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_DeleteSupervisor_Click(object sender, EventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);

            string[] DelMenu = hfSelectedIDS.Text.Trim().Replace("[", "").Replace("]", "").Replace("\"", "").Split(',');
            string superIDList = "";
            for (int i = 0; i < DelMenu.Length; i++)
            {
                superIDList += DelMenu[i] + ",";
            }
            superIDList = superIDList.Substring(0, superIDList.Length - 1);
            Citic.Model.Supervisor model = new Citic.Model.Supervisor();
            model.DeleteID = this.CurrentUser.UserId;
            model.DeleteTime = DateTime.Now;
            bool flag = SupervisorBll.DeleteListOnLogic(superIDList, model);
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

        #region 翻页事件--乔春羽(2013.9.3)
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
        protected void grid_SupervisorsList_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);
            grid_List.PageIndex = e.NewPageIndex;

            GridBind();

            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
        }
        #endregion

        #region 查询--乔春羽(2013.9.3)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 关闭窗体--乔春羽(2013.9.3)
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

        #region 导出Excel--乔春羽
        /// <summary>
        /// 导出Excel
        /// </summary>
        protected void btn_ExpendExcel_Click(object sender, EventArgs e)
        {
            if (this.grid_List.Rows.Count <= 0)
            {
                AlertShowInTop("没有可导出的数据！");
                return;
            }
            string titleName = "监管员信息";
            string where = ConditionInit();
            where = where.Replace("T.", string.Empty);
            string sheetName = "监管员信息（当前页）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string sheetNameAll = "监管员信息（全部）_" + ConvertLongDateTimeToUI(DateTime.Now);
            string[] headers = { "监管员姓名", "性别", "年龄", "学历", "联系电话", "工作来源", "QQ", "入职时间" };
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
            DataTable dt = this.SupervisorBll.GetAllListByProcess(where, rowbegin, rowend).Tables[0];

            string[] columns = { "SupervisorName", "Gender", "Age", "Education", "LinkPhone", "WorkSource", "QQ", "EntryTime" };
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

            dt = this.SupervisorBll.GetAllListByProcess(where, 0, 0).Tables[0];

            npoi.DataTableToExcel(dt, columns, contentStyle);

            //保存文件
            filePath = "~/DownExcel/" + sheetNameAll + ".xlsx";
            npoi.Save(Server.MapPath(filePath));

            hl_ExportAll.NavigateUrl = filePath;

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
            if (urls.Contains("Search21"))
            {
                btn_Search.Visible = true;
            }
            if (urls.Contains("Insert21"))
            {
                btn_AddSupervisor.Visible = true;
                tbs_Add.Visible = true;
            }
            if (urls.Contains("Delete21"))
            {
                tbs_Delete.Visible = true;
                btn_DeleteSupervisor.Visible = true;
            }
            if (urls.Contains("Modify21"))
            {
                tbs_Modify.Visible = true;
                btn_Modify.Visible = true;
            }
            if (urls.Contains("Excel21"))
            {
                btn_ExpendExcel.Visible = true;
                hl_ExportExcel.Visible = true;
            }
            if (urls.Contains("ExcelAll21"))
            {
                btn_ExpendExcel.Visible = true;
                hl_ExportAll.Visible = true;
            }
        }
        #endregion

        #region 操作事件，删除、修改--乔春羽(2013.9.3)
        protected void lb_OModify21_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.LinkButton btn = sender as System.Web.UI.WebControls.LinkButton;
            //FineUI.LinkButton btn = sender as FineUI.LinkButton;
            if (btn != null)
            {
                int id = Convert.ToInt32(grid_List.DataKeys[grid_List.SelectedRowIndex][0]);
                if (btn.ID == "lb_OModify21") //编辑
                {
                    string path = string.Format("~/BasicInfoManagement/EditSupervisor.aspx?SupervisorID={0}", id);
                    WindowEditSupervisor.IFrameUrl = path;
                    WindowEditSupervisor.Hidden = false;
                }
                else if (btn.ID == "lb_ODelete21")
                {
                    Citic.Model.Supervisor model = new Citic.Model.Supervisor();
                    model.DeleteID = this.CurrentUser.UserId;
                    model.DeleteTime = DateTime.Now;
                    model.SupervisorID = id;

                    bool flag = SupervisorBll.DeleteOnLogic(model);
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
        }
        #endregion

        #region 修改--乔春羽(2013.9.3)
        protected void btn_Modify_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(grid_List.DataKeys[grid_List.SelectedRowIndex][0]);
            string path = string.Format("~/BasicInfoManagement/EditSupervisor.aspx?SupervisorID={0}", id);
            WindowEditSupervisor.IFrameUrl = path;
            WindowEditSupervisor.Hidden = false;
        }
        #endregion

    }
}