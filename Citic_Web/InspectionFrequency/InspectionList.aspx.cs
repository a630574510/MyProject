using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.HSSF.Util;
namespace Citic_Web.InspectionFrequency
{
    public partial class InspectionList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txt_StartTime.SelectedDate = DateTime.Now;
                this.txt_AsTime.SelectedDate = DateTime.Now;
                this.TT_Day.Text = DateTime.Now.ToLongDateString().ToString() + "-" + DateTime.Now.ToLongDateString().ToString() + "，总部视频部对所监管的部分经销店进行了全面的远程视频检查，现将结果报告如下：";

            }
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder("IsDel=0");
            if (!string.IsNullOrEmpty(this.txt_Area.Text.Trim()))        //检查区域
            {
                sb.Append(" and Area like '%" + this.txt_Area.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_Bank.Text.Trim()))      //合作银行
            {
                sb.Append(" and Bank like '%" + this.txt_Bank.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_BrandName.Text.Trim()))      //品牌
            {
                sb.Append(" and BrandName like '%" + this.txt_BrandName.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_StartTime.Text.Trim()) && !string.IsNullOrEmpty(this.txt_AsTime.Text.Trim()))      //检查时间
            {
                sb.Append(" and CONVERT(varchar(10),CreateTime,23) between '" + this.txt_StartTime.Text.Trim() + "' and '" + this.txt_AsTime.Text.Trim() + "'");
            }
            if (!string.IsNullOrEmpty(this.txt_Rummager.Text.Trim()))      //检查人员
            {
                sb.Append(" and Rummager like '%" + this.txt_Rummager.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_DealerName.Text.Trim()))      //经销店名称
            {
                sb.Append(" and DealerName like '%" + this.txt_DealerName.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_SupervisorName.Text.Trim()))     //监管员
            {
                sb.Append(" and SupervisorName like '%" + this.txt_SupervisorName.Text.Trim() + "%'");
            }
            //this.G_DayInspection.DataSource = new Citic.BLL.Inspection().DayInspection(this.txt_StartTime.Text.Trim());
            //this.G_DayInspection.DataBind();
            DataTable dt = new Citic.BLL.Inspection().GetList(sb.ToString()).Tables[0];
            this.G_DayTabel.DataSource = dt;
            this.G_DayTabel.DataBind();
            this.G_DayInspection.DataSource = StatisticalExamination(dt);
            this.G_DayInspection.DataBind();
            this.TT_Day.Text = Convert.ToDateTime(this.txt_StartTime.Text.Trim()).ToLongDateString().ToString() + "-" + Convert.ToDateTime(this.txt_AsTime.Text.Trim()).ToLongDateString().ToString() + "，总部视频部对所监管的部分经销店进行了全面的远程视频检查，现将结果报告如下：";
            this.hl_ExportExcel.NavigateUrl = "";
        }
        private DataTable StatisticalExamination(DataTable dt)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ShopCount");
            table.Columns.Add("ConformShopCount");
            table.Columns.Add("NotConformShopCount");
            table.Columns.Add("InventoryShopCount");
            int Dealer = dt.Rows.Count;
            int IsConform = dt.Select("IsConform='1'").Length;
            int Inventory = dt.Select("Inventory='0'").Length;
            table.Rows.Add(Dealer, Dealer - IsConform, IsConform, Inventory);

            return table;
        }

        protected void Btn_Generate_Click(object sender, EventArgs e)
        {
            if (this.G_DayTabel.Rows.Count != 0)
            {


                IWorkbook hSSFWorkbook = new HSSFWorkbook();
                ISheet sheet = hSSFWorkbook.CreateSheet(DateTime.Now.ToString("yyyy-MM-dd"));
                IRow row;
                ICell cell;
                ICellStyle style;
                IFont font;

                //DocumentSummaryInformation dis = PropertySetFactory.CreateDocumentSummaryInformation();
                //dis.Company = "中信信通";
                //SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                //si.Subject = "视频检查";
                //hSSFWorkbook.DocumentSummaryInformation = dis;
                //hSSFWorkbook.SummaryInformation = si;

                row = sheet.CreateRow(0);           //创建行     0
                row.Height = 20 * 20;           //行高
                cell = row.CreateCell(0);       //创建行的列
                cell.SetCellValue("视频检查日报表");   //列值
                style = hSSFWorkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;   //文字居中
                style.VerticalAlignment = VerticalAlignment.Center; //水平对其
                font = hSSFWorkbook.CreateFont();
                font.FontName = "宋体";
                font.Boldweight = short.MaxValue;       //字体加粗
                font.FontHeightInPoints = 14;      //列字体大小
                style.SetFont(font);
                cell.CellStyle = style;
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 12));

                row = sheet.CreateRow(1);       //创建行     1
                row.Height = 30 * 20;       //行高
                cell = row.CreateCell(0);        //创建行的列
                cell.SetCellValue(this.TT_Day.Text);         //列值
                style = hSSFWorkbook.CreateCellStyle();
                style.Alignment = HorizontalAlignment.Center;       //文字居中
                style.VerticalAlignment = VerticalAlignment.Center; //水平对其
                font = hSSFWorkbook.CreateFont();
                font.Boldweight = short.MaxValue;       //字体加粗
                font.FontHeightInPoints = 12;       //列字体大小
                style.SetFont(font);
                cell.CellStyle = style;
                sheet.AddMergedRegion(new CellRangeAddress(1, 1, 0, 12));

                row = sheet.CreateRow(2);       //创建行     2
                row.Height = 30 * 20;       //行高
                cell = row.CreateCell(0);        //创建行的列
                cell.SetCellValue("1、检查情况");         //列值
                style = hSSFWorkbook.CreateCellStyle();
                font = hSSFWorkbook.CreateFont();
                font.Boldweight = short.MaxValue;       //字体加粗
                font.FontHeightInPoints = 12;       //列字体大小
                font.FontName = "宋体";
                style.SetFont(font);
                style.Alignment = HorizontalAlignment.Left;       //文字居中
                cell.CellStyle = style;
                sheet.AddMergedRegion(new CellRangeAddress(2, 2, 0, 12));

                row = sheet.CreateRow(3);       //创建行     3
                row.Height = 30 * 20;       //行高
                style = hSSFWorkbook.CreateCellStyle();
                font = hSSFWorkbook.CreateFont();
                font.Boldweight = short.MaxValue;       //字体加粗
                font.FontHeightInPoints = 12;       //列字体大小
                font.FontName = "宋体";
                style.SetFont(font);
                style.FillPattern = FillPattern.SolidForeground;
                style.FillForegroundColor = HSSFColor.Tan.Index;
                style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                //边框颜色
                //style.BottomBorderColor = HSSFColor.OliveGreen.Blue.Index;
                //style.TopBorderColor = HSSFColor.OliveGreen.Blue.Index;

                style.Alignment = HorizontalAlignment.Center;       //文字居中
                style.VerticalAlignment = VerticalAlignment.Justify; //水平对其
                cell = row.CreateCell(0);        //创建行的列
                cell.SetCellValue("检查店数");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(4);        //创建行的列
                cell.SetCellValue("符合要求店数");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(7);        //创建行的列
                cell.SetCellValue("不符合要求店数");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(9);        //创建行的列
                cell.SetCellValue("0库存店数");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(11);        //创建行的列
                cell.SetCellValue("备注");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(1);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(2);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(3);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(5);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(6);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(8);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(10);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(12);        //创建行的列
                cell.CellStyle = style;
                sheet.AddMergedRegion(new CellRangeAddress(3, 3, 0, 3));
                sheet.AddMergedRegion(new CellRangeAddress(3, 3, 4, 6));
                sheet.AddMergedRegion(new CellRangeAddress(3, 3, 7, 8));
                sheet.AddMergedRegion(new CellRangeAddress(3, 3, 9, 10));
                sheet.AddMergedRegion(new CellRangeAddress(3, 3, 11, 12));

                row = sheet.CreateRow(4);       //创建行     4
                row.Height = 30 * 20;       //行高
                style = hSSFWorkbook.CreateCellStyle();
                font = hSSFWorkbook.CreateFont();
                font.Boldweight = short.MaxValue;       //字体加粗
                font.FontHeightInPoints = 12;       //列字体大小
                font.FontName = "宋体";
                style.SetFont(font);
                //style.FillPattern = FillPattern.SolidForeground;
                //style.FillForegroundColor = HSSFColor.Tan.Index;
                style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                //边框颜色
                //style.BottomBorderColor = HSSFColor.OliveGreen.Blue.Index;
                //style.TopBorderColor = HSSFColor.OliveGreen.Blue.Index;

                style.Alignment = HorizontalAlignment.Center;       //文字居中
                style.VerticalAlignment = VerticalAlignment.Justify; //水平对其
                cell = row.CreateCell(0);        //创建行的列
                cell.SetCellValue(this.G_DayInspection.Rows[0].Values[0].ToString());         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(4);        //创建行的列
                cell.SetCellValue(this.G_DayInspection.Rows[0].Values[1].ToString());         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(7);        //创建行的列
                cell.SetCellValue(this.G_DayInspection.Rows[0].Values[2].ToString());         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(9);        //创建行的列
                cell.SetCellValue(this.G_DayInspection.Rows[0].Values[3].ToString());         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(11);        //创建行的列
                cell.SetCellValue("");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(1);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(2);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(3);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(5);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(6);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(8);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(10);        //创建行的列
                cell.CellStyle = style;
                cell = row.CreateCell(12);        //创建行的列
                cell.CellStyle = style;
                sheet.AddMergedRegion(new CellRangeAddress(4, 4, 0, 3));
                sheet.AddMergedRegion(new CellRangeAddress(4, 4, 4, 6));
                sheet.AddMergedRegion(new CellRangeAddress(4, 4, 7, 8));
                sheet.AddMergedRegion(new CellRangeAddress(4, 4, 9, 10));
                sheet.AddMergedRegion(new CellRangeAddress(4, 4, 11, 12));

                row = sheet.CreateRow(5);       //创建行     5
                row.Height = 30 * 20;       //行高
                style = hSSFWorkbook.CreateCellStyle();
                font = hSSFWorkbook.CreateFont();
                font.Boldweight = short.MaxValue;       //字体加粗
                font.FontHeightInPoints = 12;       //列字体大小
                font.FontName = "宋体";
                style.SetFont(font);
                style.Alignment = HorizontalAlignment.Left;       //文字居中
                cell = row.CreateCell(0);        //创建行的列
                cell.SetCellValue("2、具体情况");         //列值
                cell.CellStyle = style;
                sheet.AddMergedRegion(new CellRangeAddress(5, 5, 0, 12));

                row = sheet.CreateRow(6);       //创建行     6
                row.Height = 30 * 20;       //行高
                style = hSSFWorkbook.CreateCellStyle();
                font = hSSFWorkbook.CreateFont();
                font.Boldweight = short.MaxValue;       //字体加粗
                font.FontHeightInPoints = 9;       //列字体大小
                font.FontName = "宋体";
                style.FillPattern = FillPattern.SolidForeground;//没有背景图片，显示为背景颜色
                style.FillForegroundColor = HSSFColor.Yellow.Index;//设置为黄色背景颜色
                style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                style.SetFont(font);
                style.Alignment = HorizontalAlignment.Center;       //文字居中
                style.VerticalAlignment = VerticalAlignment.Justify; //水平对其

                cell = row.CreateCell(0);        //创建行的列
                cell.SetCellValue("序号");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(1);        //创建行的列
                cell.SetCellValue("检查日期");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(2);        //创建行的列
                cell.SetCellValue("检查人员");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(3);        //创建行的列
                cell.SetCellValue("经销店名称");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(4);        //创建行的列
                cell.SetCellValue("合作银行");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(5);        //创建行的列
                cell.SetCellValue("品牌");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(6);        //创建行的列
                cell.SetCellValue("监管员");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(7);        //创建行的列
                cell.SetCellValue("监管模式");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(8);        //创建行的列
                cell.SetCellValue("库存");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(9);        //创建行的列
                cell.SetCellValue("总部总账");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(10);        //创建行的列
                cell.SetCellValue("主要问题");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(11);        //创建行的列
                cell.SetCellValue("检查用时");         //列值
                cell.CellStyle = style;
                cell = row.CreateCell(12);        //创建行的列
                cell.SetCellValue("评价");         //列值
                cell.CellStyle = style;

                for (int i = 0; i < this.G_DayTabel.Rows.Count; i++)
                {
                    string[] Values = this.G_DayTabel.Rows[i].Values;
                    row = sheet.CreateRow(7 + i);       //创建行     6
                    row.Height = 30 * 20;       //行高
                    style = hSSFWorkbook.CreateCellStyle();
                    //font = hSSFWorkbook.CreateFont();
                    //font.Boldweight = short.MaxValue;       //字体加粗
                    //font.FontHeightInPoints = 9;       //列字体大小
                    //font.FontName = "宋体";
                    //style.SetFont(font);
                    style.Alignment = HorizontalAlignment.Center;       //文字居中
                    style.VerticalAlignment = VerticalAlignment.Justify; //水平对其

                    cell = row.CreateCell(0);        //创建行的列
                    cell.SetCellValue(i + 1);         //列值-序号
                    cell.CellStyle = style;

                    cell = row.CreateCell(1);        //创建行的列
                    cell.SetCellValue(Values[3].ToString());         //列值-检查日期  
                    cell.CellStyle = style;

                    cell = row.CreateCell(2);        //创建行的列
                    cell.SetCellValue(Values[1].ToString());         //列值-检查人员
                    cell.CellStyle = style;

                    cell = row.CreateCell(3);        //创建行的列
                    //cell.SetCellValue(Values[2].ToString().Split('>')[1].Split('<')[0]);         //列值-经销店名称
                    cell.SetCellValue(Values[0].ToString());         //列值-经销店名称
                    cell.CellStyle = style;

                    cell = row.CreateCell(4);        //创建行的列
                    cell.SetCellValue(Values[4].ToString());         //列值-合作银行
                    cell.CellStyle = style;

                    cell = row.CreateCell(5);        //创建行的列
                    cell.SetCellValue(Values[5].ToString());         //列值-品牌
                    cell.CellStyle = style;

                    cell = row.CreateCell(6);        //创建行的列
                    cell.SetCellValue(Values[6].ToString());         //列值-监管员
                    cell.CellStyle = style;

                    cell = row.CreateCell(7);        //创建行的列
                    cell.SetCellValue(Values[7].ToString());         //列值-监管模式
                    cell.CellStyle = style;

                    cell = row.CreateCell(8);        //创建行的列
                    cell.SetCellValue(Values[8].ToString());         //列值-库存
                    cell.CellStyle = style;

                    cell = row.CreateCell(9);        //创建行的列
                    cell.SetCellValue(Values[9].ToString());         //列值-总部总账
                    cell.CellStyle = style;

                    cell = row.CreateCell(10);        //创建行的列
                    cell.SetCellValue(Values[10].ToString());         //列值-主要问题
                    cell.CellStyle = style;

                    cell = row.CreateCell(11);        //创建行的列
                    cell.SetCellValue(Values[11].ToString());         //列值-检查用时
                    cell.CellStyle = style;

                    cell = row.CreateCell(12);        //创建行的列
                    cell.SetCellValue(Values[12].ToString());         //列值-评价
                    cell.CellStyle = style;

                }
                try
                {

                    string FileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
                    string Map = Server.MapPath("~/Confirmation/视频检查文件/" + FileName);
                    FileStream file = new FileStream(Map, FileMode.Create);
                    hSSFWorkbook.Write(file);
                    file.Close();
                    this.hl_ExportExcel.NavigateUrl = "~/Confirmation/视频检查文件/" + FileName;
                }
                catch (Exception ex)
                {

                    Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "Btn_Generate_Click()"); ;
                }

            }
            else
            {
                FineUI.Alert.ShowInTop("没有任何数据可以生成", FineUI.MessageBoxIcon.Error);
            }
        }

        #region 获取字体样式
        /// <summary>
        /// 获取字体样式
        /// </summary>
        /// <param name="hssfworkbook">Excel操作类</param>
        /// <param name="fontname">字体名</param>
        /// <param name="fontcolor">字体颜色</param>
        /// <param name="fontsize">字体大小</param>
        /// <returns></returns>
        public static IFont GetFontStyle(HSSFWorkbook hssfworkbook, string fontfamily, HSSFColor fontcolor, int fontsize)
        {
            IFont font1 = hssfworkbook.CreateFont();
            if (string.IsNullOrEmpty(fontfamily))
            {
                font1.FontName = fontfamily;
            }
            if (fontcolor != null)
            {
                font1.Color = fontcolor.GetIndex();
            }
            font1.IsItalic = true;
            font1.FontHeightInPoints = (short)fontsize;
            return font1;
        }
        #endregion

        #region 合并单元格
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="sheet">要合并单元格所在的sheet</param>
        /// <param name="rowstart">开始行的索引</param>
        /// <param name="rowend">结束行的索引</param>
        /// <param name="colstart">开始列的索引</param>
        /// <param name="colend">结束列的索引</param>
        public static void SetCellRangeAddress(ISheet sheet, int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            sheet.AddMergedRegion(cellRangeAddress);
        }
        #endregion

        #region 获取单元格样式
        /// <summary>
        /// 获取单元格样式
        /// </summary>
        /// <param name="hssfworkbook">Excel操作类</param>
        /// <param name="font">单元格字体</param>
        /// <param name="fillForegroundColor">图案的颜色</param>
        /// <param name="fillBackgroundColor">单元格背景</param>
        /// <param name="ha">垂直对齐方式</param>
        /// <param name="va">垂直对齐方式</param>
        /// <returns></returns>
        public static ICellStyle GetCellStyle(HSSFWorkbook hssfworkbook, IFont font, HSSFColor fillForegroundColor, HSSFColor fillBackgroundColor, HorizontalAlignment ha, VerticalAlignment va)
        {
            ICellStyle cellstyle = hssfworkbook.CreateCellStyle();
            cellstyle.Alignment = ha;
            cellstyle.VerticalAlignment = va;
            if (fillForegroundColor != null)
            {
                cellstyle.FillForegroundColor = fillForegroundColor.GetIndex();
            }
            if (fillBackgroundColor != null)
            {
                cellstyle.FillBackgroundColor = fillBackgroundColor.GetIndex();
            }
            if (font != null)
            {
                cellstyle.SetFont(font);
            }
            return cellstyle;
        }
        #endregion
    }
}