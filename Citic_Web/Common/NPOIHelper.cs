using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
namespace Citic_Web
{
    public class NPOIHelper
    {
        /// <summary>
        /// 当前Excel文件对象
        /// </summary>
        private IWorkbook _WorkBook = null;
        /// <summary>
        /// 当前的工作簿对象
        /// </summary>
        private ISheet _CurrentSheet = null;

        public ISheet CurrentSheet
        {
            get { return _CurrentSheet; }
        }
        /// <summary>
        /// 行号
        /// </summary>
        private int? rowCount = null;

        Dictionary<string, ICellStyle> CellStyleCollection;

        public NPOIHelper()
        {
            CellStyleCollection = new Dictionary<string, ICellStyle>();
        }

        #region Create
        /// <summary>
        /// 创建一个Excel对象，并且里边儿带一个Sheet工作簿
        /// </summary>
        public void Create()
        {
            this._WorkBook = new XSSFWorkbook();
            this._CurrentSheet = this._WorkBook.CreateSheet();
            this.rowCount = 0;
        }

        /// <summary>
        /// 创建一个Excel对象，并且里边儿带一个Sheet工作簿
        /// </summary>
        /// <param name="sheetName">工作簿的名字</param>
        public void Create(string sheetName)
        {
            this._WorkBook = new XSSFWorkbook();
            this._CurrentSheet = this._WorkBook.CreateSheet(sheetName);
            this.rowCount = 0;
        }
        #endregion

        #region OpenFile
        public void Open(string fileName)
        {
            FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite);
            MemoryStream ms = new MemoryStream();
            this._WorkBook = WorkbookFactory.Create(fs);
            this._CurrentSheet = this._WorkBook.GetSheetAt(0);
        }
        #endregion

        #region Row
        public IRow CreateRow()
        {
            IRow row = this._CurrentSheet.CreateRow(this.rowCount.Value);
            this.rowCount++;
            return row;
        }
        public IRow CreateRow(int index)
        {
            IRow row = null;
            row = this._CurrentSheet.CreateRow(index);
            return row;
        }
        public IRow CreateRow(short height)
        {
            IRow row = null;
            row = this._CurrentSheet.CreateRow(this.rowCount.Value);
            row.Height = (short)(20 * height);
            this.rowCount++;
            return row;
        }
        /// <summary>
        /// 创建行
        /// 实际是设置其所在行高，所以要在单元格所在行上设置行高，行高设置数值好像是像素点的1/20，所以*20以便达到设置效果；
        /// </summary>
        /// <param name="index">位置</param>
        /// <param name="height">行高度，像素为单位</param>
        /// <returns></returns>
        public IRow CreateRow(int index, int height)
        {
            IRow row = null;
            row = this._CurrentSheet.CreateRow(index);
            row.Height = (short)(20 * height);
            return row;
        }
        public IRow GetRow(int index)
        {
            IRow row = null;
            row = this._CurrentSheet.GetRow(index);
            return row;
        }
        #endregion

        #region Cell
        /// <summary>
        /// 创建一个单元格
        /// </summary>
        /// <param name="index">位置</param>
        /// <param name="row">行</param>
        /// <returns></returns>
        public ICell CreateCell(int index, IRow row)
        {
            ICell cell = null;
            cell = row.CreateCell(index);
            return cell;
        }

        /// <summary>
        /// 创建一个单元格并且赋值
        /// </summary>
        /// <param name="index">位置</param>
        /// <param name="row">行</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public ICell CreateCell(int index, IRow row, string value)
        {
            ICell cell = null;
            cell = row.CreateCell(index);
            cell.SetCellValue(value);
            return cell;
        }
        /// <summary>
        /// 创建一个单元格并且赋值、附加样式表
        /// </summary>
        /// <param name="index">位置</param>
        /// <param name="row">行</param>
        /// <param name="value">值</param>
        /// <param name="cellStyleCode">所附带的样式表代码</param>
        /// <returns></returns>
        public ICell CreateCell(int index, IRow row, string value, string cellStyleCode)
        {
            ICell cell = null;
            cell = row.CreateCell(index);
            cell.SetCellValue(value);
            cell.CellStyle = CellStyleCollection[cellStyleCode];
            return cell;
        }

        /// <summary>
        /// 批量创建单元格，返回一个单元格的数组
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="row">行</param>
        /// <returns></returns>
        public ICell[] CreateCells(int count, IRow row)
        {
            ICell[] cells = new ICell[count];
            for (int i = 0; i < count; i++)
            {
                cells[i] = row.CreateCell(i);
            }
            return cells;
        }
        /// <summary>
        /// 批量创建单元格附带样式，返回一个单元格的数组
        /// </summary>
        /// <param name="count">数量</param>
        /// <param name="row">行</param>
        /// <param name="cellStyleCode">所附加的样式代码</param>
        /// <returns></returns>
        public ICell[] CreateCells(int count, IRow row, string cellStyleCode)
        {
            ICell[] cells = new ICell[count];
            for (int i = 0; i < count; i++)
            {
                cells[i] = row.CreateCell(i);
                cells[i].CellStyle = CellStyleCollection[cellStyleCode];
            }
            return cells;
        }

        /// <summary>
        /// 根据传入的值数组批量创建一批单元格，返回一个单元格的数组
        /// </summary>
        /// <param name="objs">值数组</param>
        /// <param name="row">行</param>
        /// <returns></returns>
        public ICell[] CreateCells(object[] objs, IRow row)
        {
            ICell[] cells = new ICell[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                cells[i] = row.CreateCell(i);
                cells[i].SetCellValue(objs[i].ToString());
            }
            return cells;
        }
        /// <summary>
        /// 根据传入的值数组批量创建一批单元格并附加样式，返回一个单元格的数组
        /// </summary>
        /// <param name="objs">值数组</param>
        /// <param name="row">行</param>
        /// <param name="cellStyleCode">所附加的样式代码</param>
        /// <returns></returns>
        public ICell[] CreateCells(object[] objs, IRow row, string cellStyleCode)
        {
            ICell[] cells = new ICell[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                cells[i] = row.CreateCell(i);
                cells[i].SetCellValue(objs[i].ToString());
                cells[i].CellStyle = CellStyleCollection[cellStyleCode];
            }
            return cells;
        }

        /// <summary>
        /// 获得一个单元格
        /// </summary>
        /// <param name="index">位置</param>
        /// <param name="row">行</param>
        /// <returns></returns>
        public ICell GetCell(int index, IRow row)
        {
            ICell cell = null;
            cell = row.GetCell(index);
            return cell;
        }

        public void SetCellValue(IRow row, int index, string value)
        {
            ICell cell = null;
            cell = row.GetCell(index);
            cell.SetCellValue(value);
        }

        /// <summary>
        /// 合并单元格
        /// 合并单元格实际上是声明一个区域，该区域中的单元格将进行合并，合并后的内容与样式以该区域最左上角的单元格为准。
        /// 下标以0为开始。
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

        /// <summary>
        /// 合并单元格
        /// 合并单元格实际上是声明一个区域，该区域中的单元格将进行合并，合并后的内容与样式以该区域最左上角的单元格为准。
        /// 下标以0为开始。
        /// </summary>
        /// <param name="rowstart">开始行的索引</param>
        /// <param name="rowend">结束行的索引</param>
        /// <param name="colstart">开始列的索引</param>
        /// <param name="colend">结束列的索引</param>
        public void SetCellRangeAddress(int rowstart, int rowend, int colstart, int colend)
        {
            CellRangeAddress cellRangeAddress = new CellRangeAddress(rowstart, rowend, colstart, colend);
            this._CurrentSheet.AddMergedRegion(cellRangeAddress);
        }
        #endregion

        #region CellStyle
        public string CreateCellStyle(NPOIAlign Alignment, NPOIVAlign VAlignment, bool IsHidden, bool IsLocked, bool HasBorder)
        {
            HorizontalAlignment align = HorizontalAlignment.Center;
            switch (Alignment)
            {
                case NPOIAlign.Center:
                    align = HorizontalAlignment.Center;
                    break;
                case NPOIAlign.CenterSelection:
                    align = HorizontalAlignment.CenterSelection;
                    break;
                case NPOIAlign.Distributed:
                    align = HorizontalAlignment.Distributed;
                    break;
                case NPOIAlign.Fill:
                    align = HorizontalAlignment.Fill;
                    break;
                case NPOIAlign.General:
                    align = HorizontalAlignment.General;
                    break;
                case NPOIAlign.Justify:
                    align = HorizontalAlignment.Justify;
                    break;
                case NPOIAlign.Left:
                    align = HorizontalAlignment.Left;
                    break;
                case NPOIAlign.Right:
                    align = HorizontalAlignment.Right;
                    break;
                default:
                    break;
            }
            VerticalAlignment valign = VerticalAlignment.Center;
            switch (VAlignment)
            {
                case NPOIVAlign.Bottom:
                    valign = VerticalAlignment.Bottom;
                    break;
                case NPOIVAlign.Center:
                    valign = VerticalAlignment.Center;
                    break;
                case NPOIVAlign.Distributed:
                    valign = VerticalAlignment.Distributed;
                    break;
                case NPOIVAlign.Justify:
                    valign = VerticalAlignment.Justify;
                    break;
                case NPOIVAlign.Top:
                    valign = VerticalAlignment.Top;
                    break;
                default:
                    break;
            }
            string cellStyleCode = Guid.NewGuid().ToString();
            ICellStyle cellStyle = this._WorkBook.CreateCellStyle();
            cellStyle.Alignment = align; //水平居中
            cellStyle.FillBackgroundColor = 244;
            cellStyle.FillPattern = NPOI.SS.UserModel.FillPattern.NoFill;   //填充模式
            cellStyle.IsHidden = IsHidden;     //单元格是否隐藏
            cellStyle.IsLocked = IsLocked;     //单元格是否锁定
            cellStyle.VerticalAlignment = valign;   //垂直居中
            //边框
            if (HasBorder)
            {
                cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            }
            try
            {
                this.CellStyleCollection.Add(cellStyleCode, cellStyle);
            }
            catch (Exception e) { throw e; }
            return cellStyleCode;
        }
        #endregion

        #region Font
        /// <summary>
        /// 创建字体
        /// </summary>
        /// <param name="cellStyleCode">ICellStyle代号</param>
        /// <param name="FontHeightInPoints">大小</param>
        /// <param name="FontFamily">字体</param>
        /// <param name="Boldweight">样式</param>
        /// <param name="IsItalic">是否倾斜</param>
        /// <param name="IsStrikeout">是否有中间线</param>
        public void CreateFont(string cellStyleCode, short FontHeightInPoints, string FontFamily, NPOIFontBoldWeight Boldweight, bool IsItalic, bool IsStrikeout)
        {
            short fontBoldWeight = 0;
            switch (Boldweight)
            {
                case NPOIFontBoldWeight.Bold:
                    fontBoldWeight = (short)FontBoldWeight.Bold;
                    break;
                case NPOIFontBoldWeight.None:
                    fontBoldWeight = (short)FontBoldWeight.None;
                    break;
                case NPOIFontBoldWeight.Normal:
                    fontBoldWeight = (short)FontBoldWeight.Normal;
                    break;
            }
            IFont font = this._WorkBook.CreateFont();
            font.FontHeightInPoints = FontHeightInPoints;
            font.FontName = FontFamily;
            font.Boldweight = fontBoldWeight;
            font.IsItalic = IsItalic;      //是否倾斜
            font.IsStrikeout = IsStrikeout;   //是否有中间线

            this.CellStyleCollection[cellStyleCode].SetFont(font);
        }
        #endregion

        #region DataTableToExcel
        /// <summary>
        /// 将DataTable中的数据添加到Excel中
        /// </summary>
        /// <param name="dataTable">数据源</param>
        public void DataTableToExcel(DataTable dataTable)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    IRow temp_Row = this.CreateRow();
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        this.CreateCell(i, temp_Row).SetCellValue(row[i].ToString());
                    }
                }
            }
        }

        public void DataTableToExcel(DataTable dataTable, string styleString)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    IRow temp_Row = this.CreateRow();
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        this.CreateCell(i, temp_Row, row[i].ToString(), styleString);
                    }
                }
            }
        }

        /// <summary>
        /// 将DataTable中的数据添加到Excel中
        /// </summary>
        /// <param name="dataTable">数据源</param>
        /// <param name="columns">数据源中的列</param>
        public void DataTableToExcel(DataTable dataTable, string[] columns)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    IRow temp_Row = this.CreateRow();
                    for (int i = 0; i < columns.Length; i++)
                    {
                        this.CreateCell(i, temp_Row, row[columns[i]].ToString());
                    }
                }
            }
        }

        /// <summary>
        /// 将DataTable中的数据添加到Excel中，附加样式表
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="columns"></param>
        /// <param name="styleString"></param>
        public void DataTableToExcel(DataTable dataTable, string[] columns, string styleString)
        {
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    IRow temp_Row = this.CreateRow();
                    for (int i = 0; i < columns.Length; i++)
                    {
                        this.CreateCell(i, temp_Row, row[columns[i]].ToString(), styleString);
                    }
                }
            }
        }

        public void AppendData(DataTable dt, string[] columns, string styleString)
        {
            int rowIndex = 0;
            IRow currentRow = null;

            rowIndex = this._CurrentSheet.LastRowNum + 1;
            foreach (DataRow row in dt.Rows)
            {
                currentRow = this._CurrentSheet.CreateRow(rowIndex);

                for (int i = 0; i < columns.Length; i++)
                {
                    this.CreateCell(i, currentRow, row[columns[i]].ToString(), styleString);
                }

                rowIndex++;
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="fileName">文件全路径</param>
        public void Save(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            try
            {
                this._WorkBook.Write(fs);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                fs.Close();
                this.rowCount = 0;
                this.CellStyleCollection.Clear();
            }
        }
        #endregion
    }

    public enum NPOIAlign
    {
        Center, CenterSelection, Distributed, Fill, General, Justify, Left, Right
    }
    public enum NPOIVAlign
    {
        Bottom, Center, Distributed, Justify, Top
    }
    public enum NPOIFontBoldWeight
    {
        Bold, None, Normal
    }
}
