﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NPOI.SS.UserModel;

namespace Citic_Web.Ledger
{
    public partial class Electron_Ledger : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string bankIDStr = Request.QueryString["BankID"];
                string dealerIDStr = Request.QueryString["DealerID"];
                if (!string.IsNullOrEmpty(bankIDStr) && !string.IsNullOrEmpty(dealerIDStr))
                {
                    ViewState["BankID"] = bankIDStr;
                    ViewState["DealerID"] = dealerIDStr;
                }
                GridBind();
            }
        }

        #region PrivateFields--乔春羽(2013.7.19)
        private int DealerID
        {
            get
            {
                int dealerID = 0;
                if (ViewState["DealerID"] == null)
                {
                    dealerID = 0;
                }
                else
                {
                    dealerID = Convert.ToInt32(ViewState["DealerID"]);
                }
                return dealerID;
            }
        }
        private int BankID
        {
            get
            {
                int bankid = 0;
                if (ViewState["BankID"] == null)
                {
                    bankid = 0;
                }
                else
                {
                    bankid = Convert.ToInt32(ViewState["BankID"]);
                }
                return bankid;
            }
        }
        #endregion

        #region 显示数据--乔春羽(2013.7.19)
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件
            string where = ConditionInit();
            string path = Common.OperateConfigFile.getValue("Dealer_Bank");
            string commandStr = Common.OperateConfigFile.getValue("Dealer_CarListCommand");
            string tableName = string.Empty;
            if (BankID != 0 && DealerID != 0)
            {
                tableName = string.Format("tb_Car_{0}_{1}", BankID, DealerID);
            }
            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where, tableName);

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            try
            {
                DataTable dt = CarBll.GetListByPage(where, string.Empty, rowbegin, rowend, tableName, Server.MapPath(path), commandStr).Tables[0];

                grid_List.DataSource = dt;
                grid_List.DataBind();
            }
            catch (Exception ex)
            {
                AlertShow(ex.Message);
            }
        }


        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where, string tableName)
        {
            return CarBll.GetRecordCount(where, tableName);
        }
        /// <summary>
        /// 得到查询条件
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("IsDelete=0");

            return where.ToString();
        }
        #endregion

        #region 每页显示数据数量改变事件--乔春羽(2013.7.19)
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region 翻页事件--乔春羽(2013.7.19)
        /// <summary>
        /// 翻页事件--乔春羽
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

        #region 数据行绑定事件--乔春羽(2013.7.19)
        protected void grid_List_RowDataBound(object sender, GridRowEventArgs e)
        {
            if (e.RowIndex >= 0 || e.DataItem != null)
            {
                int index = 19;
                int type = Convert.ToInt32(e.Values[index]);
                switch (type)
                {
                    case (int)Citic_Web.Common.CarStatus.Error:
                        e.Values[index] = "异常";
                        break;
                    case (int)Citic_Web.Common.CarStatus.Init:
                        e.Values[index] = "在途";
                        break;
                    case (int)Citic_Web.Common.CarStatus.InStorage:
                        e.Values[index] = "在库";
                        break;
                    case (int)Citic_Web.Common.CarStatus.Move:
                        e.Values[index] = "移动";
                        break;
                    case (int)Citic_Web.Common.CarStatus.OutStorage:
                        e.Values[index] = "出库";
                        break;
                    case (int)Citic_Web.Common.CarStatus.Pending:
                        e.Values[index] = "申请中";
                        break;
                }
            }
        }
        #endregion

        #region 导出Excel--乔春羽(2013.7.19)
        protected void btn_BuildExcel_Click(object sender, EventArgs e)
        {
            //得到经销商名
            string DealerName = DealerBll.GetModel(DealerID).DealerName;
            //保存Excel文件
            //string sheetName = string.Format("总账", DealerName);
            string sheetName = string.Format("{0}_质押物明细", DealerName);
            string fileName = sheetName + this.ConvertLongDateTimeToUI(DateTime.Now) + ".xlsx";//客户端保存的文件名
            string filePath = "~/DownExcel/" + fileName;

            DataTable dt = CarBll.GetAllListByProcess(string.Empty, "tb_Car_" + BankID + "_" + DealerID).Tables[0];

            string[] headers = { "质押号", "保险金账号", "票号", "开票日期", "到期日期", "开票金额", "合格证发证日期", "车辆型号", "车辆分类", "排量", "颜色", "发动机号", "车架号", "合格证号", "钥匙号", "车辆金额", "明细接收日期", "入库日期", "车辆状态", "释放日期", "移动日期", "备注" };

            NPOIHelper npoi = new NPOIHelper();
            npoi.Create(sheetName);

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
            npoi.SetCellValue(irow, 0, sheetName);
            npoi.SetCellRangeAddress(0, 0, 0, headers.Length - 1);
            //表头小标题
            IRow rowHeader = npoi.CreateRow();
            npoi.CreateCells(headers, rowHeader, contentCellStyle);

            string[] columns = { "PledgeNo", "GuaranteeNo", "DraftNo", "BeginTime", "EndTime", "DarftMoney", "QualifiedNoDate", "CarModel", "CarClass", "Displacement", "CarColor", "EngineNo", "Vin", "QualifiedNo", "KeyNumber", "CarCost", "CreateTime", "TransitTime", "Statu", "OutTime", "MoveTime", "Remarks" };
            npoi.DataTableToExcel(dt, columns, contentStyle);

            //保存文件
            npoi.Save(Server.MapPath(filePath));

            //显示下载地址
            hl_ExportExcel.NavigateUrl = filePath;
        }
        #endregion
    }
}