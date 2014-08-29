using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;

namespace Citic_Web
{
    /// <summary>
    /// 封装了Excel的各类基本操作
    /// 方便开发Excel报表
    /// By 91accp [2010/12/10]
    /// </summary>
    public class ExcelEditHelper
    {
        #region //成员变量
        /// <summary>
        /// 操作文件名称
        /// </summary>
        public string mFilename;
        /// <summary>
        /// 要操作的应用程序
        /// </summary>
        public Excel.Application app;
        /// <summary>
        /// 要操作的Book集合
        /// </summary>
        public Excel.Workbooks wbs;
        /// <summary>
        /// 要操作的Book
        /// </summary>
        public Excel.Workbook wb;
        /// <summary>
        /// 要操作的WorkSheet集合
        /// </summary>
        public Excel.Worksheets wss;
        /// <summary>
        /// 要操作的Sheet
        /// </summary>
        public Excel.Worksheet ws;
        #endregion

        #region //默认构造
        /// <summary>
        /// 默认构造
        /// </summary>
        public ExcelEditHelper()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #endregion

        #region //创建一个Excel对象
        /// <summary>
        /// 创建一个Excel对象
        /// </summary>
        public void Create()
        {
            app = new Excel.Application();
            wbs = app.Workbooks;
            wb = wbs.Add(true);
        }
        #endregion

        #region //打开一个Excel文件
        /// <summary>
        /// 打开一个Excel文件
        /// </summary>
        /// <param name="FileName">文件名称</param>
        public void Open(string FileName)
        {
            app = new Excel.Application();
            wbs = app.Workbooks;
            wb = wbs.Add(FileName);
            mFilename = FileName;
        }
        #endregion

        #region //获取一个工作表
        /// <summary>
        /// 获取一个工作表
        /// </summary>
        /// <param name="SheetName">Sheet页面的名称</param>
        /// <returns></returns>
        public Excel.Worksheet GetSheet(string SheetName)
        {
            Excel.Worksheet s = (Excel.Worksheet)wb.Worksheets[SheetName];
            return s;
        }
        #endregion

        #region //添加一个工作
        /// <summary>
        /// 添加一个工作表
        /// </summary>
        /// <param name="SheetName">新增加Sheet页面的名称</param>
        /// <returns></returns>
        public Excel.Worksheet AddSheet(string SheetName)
        {
            Excel.Worksheet s = (Excel.Worksheet)wb.Worksheets.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            s.Name = SheetName;
            return s;
        }
        #endregion

        #region //删除一个工作表
        /// <summary>
        /// 删除一个工作表
        /// </summary>
        /// <param name="SheetName">Sheet页面的名称</param>
        public void DelSheet(string SheetName)
        {
            ((Excel.Worksheet)wb.Worksheets[SheetName]).Delete();
        }
        #endregion

        #region //重命名一个工作表
        /// <summary>
        /// 重命名一个工作表一
        /// </summary>
        /// <param name="OldSheetName">Sheet页面以前的名称</param>
        /// <param name="NewSheetName">修改之后的Sheet页面的名称</param>
        /// <returns></returns>
        public Excel.Worksheet ReNameSheet(string OldSheetName, string NewSheetName)
        {
            Excel.Worksheet s = (Excel.Worksheet)wb.Worksheets[OldSheetName];
            s.Name = NewSheetName;
            return s;
        }
        /// <summary>
        /// 重命名一个工作表二
        /// </summary>
        /// <param name="Sheet">需要修改的Sheet</param>
        /// <param name="NewSheetName">修改之后的名称</param>
        /// <returns></returns>
        public Excel.Worksheet ReNameSheet(Excel.Worksheet Sheet, string NewSheetName)
        {

            Sheet.Name = NewSheetName;

            return Sheet;
        }
        #endregion

        #region //设置单元格的值
        /// <summary>
        /// 设置单元格的值          
        /// </summary>
        /// <param name="ws">需要设值的工作表Sheet</param>
        /// <param name="x">X行</param>
        /// <param name="y">Y列</param>
        /// <param name="value">需要设置的值</param>
        public void SetCellValue(Excel.Worksheet ws, int x, int y, object value)
        {
            ws.Cells[x, y] = value;
        }
        /// <summary>
        /// 设置单元格的值
        /// </summary>
        /// <param name="ws">需要设值的工作表Sheet名称</param>
        /// <param name="x">X行</param>
        /// <param name="y">Y列</param>
        /// <param name="value">需要设置的值</param>
        public void SetCellValue(string ws, int x, int y, object value)
        {

            GetSheet(ws).Cells[x, y] = value;
        }
        #endregion

        #region //设置一个单元格的属性
        /// <summary>
        /// 设置一个单元格的属性
        /// 默认字体: 宋体
        /// 默认字体大小: 12
        /// 默认颜色: 
        /// 默认对齐方式
        /// </summary>
        /// <param name="ws">要操作的Sheet页面</param>
        /// <param name="Startx">起始的X坐标</param>
        /// <param name="Starty">起始的Y坐标</param>
        /// <param name="Endx">结束的X坐标</param>
        /// <param name="Endy">结束的Y坐标</param>
        public void SetCellProperty(Excel.Worksheet ws, int Startx, int Starty, int Endx, int Endy)
        {
            string name = "宋体";
            int size = 12;
            Excel.Constants color = Excel.Constants.xlAutomatic;
            Excel.Constants HorizontalAlignment = Excel.Constants.xlRight;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Name = name;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Size = size;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Color = color;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).HorizontalAlignment = HorizontalAlignment;
        }
        ///<summary>
        /// 设置一个单元格的属性
        /// 默认字体: 宋体
        /// 默认字体大小: 12
        /// 默认颜色: 
        /// 默认对齐方式
        /// </summary>
        /// <param name="wsn">要操作的Sheet页面名称</param>
        /// <param name="Startx">起始的X坐标</param>
        /// <param name="Starty">起始的Y坐标</param>
        /// <param name="Endx">结束的X坐标</param>
        /// <param name="Endy">结束的Y坐标</param>
        public void SetCellProperty(string wsn, int Startx, int Starty, int Endx, int Endy)
        {
            Excel.Worksheet ws = GetSheet(wsn);
            string name = "宋体";
            int size = 12;
            Excel.Constants color = Excel.Constants.xlAutomatic;
            Excel.Constants HorizontalAlignment = Excel.Constants.xlRight;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Name = name;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Size = size;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Color = color;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).HorizontalAlignment = HorizontalAlignment;
        }

        ///<summary>
        /// 设置一个单元格的属性
        /// 默认字体: 宋体
        /// 默认字体大小: 12
        /// 默认颜色: 
        /// 默认对齐方式
        /// </summary>
        /// <param name="wsn">要操作的Sheet页面名称</param>
        /// <param name="Startx">起始的X坐标</param>
        /// <param name="Starty">起始的Y坐标</param>
        /// <param name="Endx">结束的X坐标</param>
        /// <param name="Endy">结束的Y坐标</param>
        /// <param name="name">字体名称</param>
        /// <param name="size">字体大小</param>
        /// <param name="color">背景颜色</param>
        /// <param name="HorizontalAlignment">对齐方式</param>
        public void SetCellProperty(string wsn, int Startx, int Starty, int Endx, int Endy, string name, int size, Excel.Constants color, Excel.Constants HorizontalAlignment)
        {

            Excel.Worksheet ws = GetSheet(wsn);
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Name = name;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Size = size;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).Font.Color = color;
            ws.get_Range(ws.Cells[Startx, Starty], ws.Cells[Endx, Endy]).HorizontalAlignment = HorizontalAlignment;
        }
        #endregion

        #region //合并单元格
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="ws">要操作Sheet</param>
        /// <param name="x1">需要合并的第一个坐标X</param>
        /// <param name="y1">需要合并的第一个坐标Y</param>
        /// <param name="x2">需要合并的第二个坐标X</param>
        /// <param name="y2">需要合并的第二个坐标Y</param>
        public void UniteCells(Excel.Worksheet ws, int x1, int y1, int x2, int y2)
        {
            ws.get_Range(ws.Cells[x1, y1], ws.Cells[x2, y2]).Merge(Type.Missing);
        }
        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="ws">要操作Sheet页面名称</param>
        /// <param name="x1">需要合并的第一个坐标X</param>
        /// <param name="y1">需要合并的第一个坐标Y</param>
        /// <param name="x2">需要合并的第二个坐标X</param>
        /// <param name="y2">需要合并的第二个坐标Y</param>
        public void UniteCells(string ws, int x1, int y1, int x2, int y2)
        {
            GetSheet(ws).get_Range(GetSheet(ws).Cells[x1, y1], GetSheet(ws).Cells[x2, y2]).Merge(Type.Missing);

        }
        #endregion

        #region //将内存中数据表格插入到Excel指定工作表的指定位置
        /// <summary>
        /// 将内存中数据表格插入到Excel指定工作表的指定位置
        /// 为在使用模板时控制格式时使用一
        /// </summary>
        /// <param name="dt">外界数据源DataTable</param>
        /// <param name="ws">要操作的Sheet页面名称</param>
        /// <param name="startX">需要插入的起始位置坐标X</param>
        /// <param name="startY">需要插入的起始位置坐标Y</param>
        public void InsertTable(System.Data.DataTable dt, string ws, int startX, int startY)
        {
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    GetSheet(ws).Cells[startX + i, j + startY] = dt.Rows[i][j].ToString();
                }
            }
        }
        /// <summary>
        /// 将内存中数据表格插入到Excel指定工作表的指定位置二
        /// </summary>
        /// <param name="dt">外界数据源DataTable</param>
        /// <param name="ws">要操作的Sheet</param>
        /// <param name="startX">需要插入的起始位置坐标X</param>
        /// <param name="startY">需要插入的起始位置坐标Y</param>
        public void InsertTable(System.Data.DataTable dt, Excel.Worksheet ws, int startX, int startY)
        {

            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {

                    ws.Cells[startX + i, j + startY] = dt.Rows[i][j];

                }

            }

        }

        /// <summary>
        /// 将内存中数据表格插入到Excel指定工作表的指定位置二
        /// </summary>
        /// <param name="dt">外界数据源DataTable</param>
        /// <param name="ws">要操作的Sheet</param>
        /// <param name="startX">需要插入的起始位置坐标X</param>
        /// <param name="startY">需要插入的起始位置坐标Y</param>
        public void InsertTable(System.Data.DataTable dt, string ws, ProgressBar pb, int startX, int startY)
        {
            pb.Maximum = dt.Rows.Count;
            pb.Value = 0;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    GetSheet(ws).Cells[startX + i, j + startY] = dt.Rows[i][j].ToString();
                }
                pb.Value = i;
            }

        }

        /// <summary>
        /// 将内存中数据表格插入到Excel指定工作表的指定位置二
        /// </summary>
        /// <param name="dt">外界数据源DataTable</param>
        /// <param name="ws">要操作的Sheet</param>
        /// <param name="startX">需要插入的起始位置坐标X</param>
        /// <param name="startY">需要插入的起始位置坐标Y</param>
        public void InsertTable(System.Data.DataTable dt, string ws, ToolStripProgressBar pb, int startX, int startY)
        {
            pb.Maximum = dt.Rows.Count;
            pb.Value = 0;
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    GetSheet(ws).Cells[startX + i, j + startY] = dt.Rows[i][j].ToString();
                }
                pb.Value = i;
            }

        }
        #endregion

        /// < summary>
        /// 根据excel的文件的路径提取其中的工作表信息
        /// < /summary>
        /// < param name="Path">Excel文件的路径< /param>
        public string[] GetDataFromExcelWithAppointSheetName(string Path)
        {
            string[] strTableNames;
            try
            {
                //连接串
                string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + Path + ";" + "Extended Properties=Excel 8.0;";
                OleDbConnection conn = new OleDbConnection(strConn);
                conn.Open();
                //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等
                DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
                //包含excel中表名的字符串数组
                strTableNames = new string[dtSheetName.Rows.Count];
                for (int k = 0; k < dtSheetName.Rows.Count; k++)
                {
                    strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();
                    strTableNames[k] = strTableNames[k].Substring(0, strTableNames[k].LastIndexOf('$'));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return strTableNames;
        }

        #region //插入图片操作
        /// <summary>
        /// 插入图片操作
        /// </summary>
        /// <param name="Filename">图片名称</param>
        /// <param name="ws">要操作Sheet的名称</param>
        public void InsertPictures(string Filename, string ws)
        {
            GetSheet(ws).Shapes.AddPicture(Filename, MsoTriState.msoFalse, MsoTriState.msoTrue, 10, 10, 150, 150);
            //后面的数字表示位置
        }
        /// <summary>
        /// 插入图片操作二
        /// </summary>
        /// <param name="Filename"></param>
        /// <param name="ws"></param>
        /// <param name="Height"></param>
        /// <param name="Width"></param>
        public void InsertPictures(string Filename, string ws, int Height, int Width)
        {
            GetSheet(ws).Shapes.AddPicture(Filename, MsoTriState.msoFalse, MsoTriState.msoTrue, 10, 10, 150, 150);
            GetSheet(ws).Shapes.get_Range(Type.Missing).Height = Height;
            GetSheet(ws).Shapes.get_Range(Type.Missing).Width = Width;
        }
        /// <summary>
        /// 插入图片操作三
        /// </summary>
        /// <param name="Filename"></param>
        /// <param name="ws"></param>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="Height"></param>
        /// <param name="Width"></param>
        public void InsertPictures(string Filename, string ws, int left, int top, int Height, int Width)
        {
            GetSheet(ws).Shapes.AddPicture(Filename, MsoTriState.msoFalse, MsoTriState.msoTrue, 10, 10, 150, 150);
            GetSheet(ws).Shapes.get_Range(Type.Missing).IncrementLeft(left);
            GetSheet(ws).Shapes.get_Range(Type.Missing).IncrementTop(top);
            GetSheet(ws).Shapes.get_Range(Type.Missing).Height = Height;
            GetSheet(ws).Shapes.get_Range(Type.Missing).Width = Width;
        }
        #endregion

        #region //插入图表操作
        /// <summary>
        /// 插入图表操作
        /// </summary>
        /// <param name="ChartType"></param>
        /// <param name="ws"></param>
        /// <param name="DataSourcesX1"></param>
        /// <param name="DataSourcesY1"></param>
        /// <param name="DataSourcesX2"></param>
        /// <param name="DataSourcesY2"></param>
        /// <param name="ChartDataType"></param>
        public void InsertActiveChart(Excel.XlChartType ChartType, string ws, int DataSourcesX1, int DataSourcesY1, int DataSourcesX2, int DataSourcesY2, Excel.XlRowCol ChartDataType)
        {
            ChartDataType = Excel.XlRowCol.xlColumns;
            wb.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            {
                wb.ActiveChart.ChartType = ChartType;
                wb.ActiveChart.SetSourceData(GetSheet(ws).get_Range(GetSheet(ws).Cells[DataSourcesX1, DataSourcesY1], GetSheet(ws).Cells[DataSourcesX2, DataSourcesY2]), ChartDataType);
                wb.ActiveChart.Location(Excel.XlChartLocation.xlLocationAsObject, ws);
            }
        }
        #endregion

        #region //保存Excel文件
        /// <summary>
        /// 保存Excel文件
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            if (mFilename == "")
            {
                return false;
            }
            else
            {
                try
                {
                    wb.Save();
                    wb.SaveAs(mFilename, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    return true;
                }

                catch
                {
                    return false;
                }
            }
        }
        #endregion

        #region //文档另存为
        /// <summary>
        /// 文档另存为
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public bool SaveAs(object FileName)
        {
            try
            {
                wb.SaveAs(FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                return true;
            }

            catch
            {
                return false;

            }
        }
        #endregion

        #region //DataGridView追加到Excel指定表格中
        /// <summary>
        ///   DataGridView追加到Excel指定表格中
        ///   ExcelEdit myExcel = new ExcelEdit();
        ///   myExcel.Create();
        ///   myExcel.DGViewAdd2Excel(this.dataGridView1, "d:\\xiao.xls", "xiaobiao");
        ///   myExcel.Save();
        ///   myExcel.Close();
        /// </summary>
        /// <param name="dgv">DataGridView，数据源</param>
        /// <param name="sheetName">导入的Sheet名称</param>
        public void DGViewAdd2Excel(DataGridView dgv, string sheetName)
        {
            try
            {
                ws = GetSheet(sheetName);

                if (ws == null)
                {
                    throw new Exception("Worksheet出现错误");
                }
                //DataGridView控件行列数
                int rowCount = dgv.RowCount;
                int columnCount = dgv.ColumnCount;
                //工作表行列数
                int sheet_row_count = ws.UsedRange.Rows.Count;
                int sheet_column_count = ws.UsedRange.Columns.Count;
                //取单元格
                Excel.Range r = ws.get_Range("A1 ", Missing.Value);
                if (r == null)
                {
                    throw new Exception("Range无法启动");
                }
                //以上是一些例行的初始化工作,下面进行具体的信息填充
                //填充标题
                int ColIndex = 1;
                foreach (DataGridViewColumn dHeader in dgv.Columns)
                {
                    ws.Cells[1, ColIndex++] = dHeader.HeaderText;
                }
                ColIndex = 1;
                //获取DataGridView中的所有行和列的数值,填充到一个二维数组中.
                object[,] myData = new object[rowCount + 1, columnCount];
                for (int i = 1; i <= rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        myData[i - 1, j] = dgv[j, i - 1].Value;         //这里的获取注意行列次序
                    }
                }
                //将填充好的二维数组填充到Excel对象中.
                //r = worksheet.get_Range(worksheet.Cells[sheet_row_count + 1, 1], worksheet.Cells[sheet_row_count + rowCount, columnCount]);

                //r = ws.get_Range(ws.Cells[sheet_row_count + 1, 1], ws.Cells[sheet_row_count + rowCount, columnCount]);
                r = ws.Range[ws.Cells[sheet_row_count + 1, 1], ws.Cells[sheet_row_count + rowCount, columnCount]];
                r.Value2 = myData;
                r = null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        #endregion

        #region //DataGridView追加到Excel指定表格中
        /// <summary>
        ///   DataGridView追加到Excel指定表格中
        ///   ExcelEdit myExcel = new ExcelEdit();
        ///   myExcel.Create();
        ///   myExcel.DGViewAdd2Excel(this.dataGridView1, "d:\\xiao.xls", "xiaobiao");
        ///   myExcel.Save();
        ///   myExcel.Close();
        /// </summary>
        /// <param name="dgv">DataGridView，数据源</param>
        /// <param name="sheetName">导入的Sheet名称</param>
        public void DataTableAdd2Excel(DataTable dgv, string sheetName)
        {
            try
            {
                ws = GetSheet(sheetName);

                if (ws == null)
                {
                    throw new Exception("Worksheet出现错误");
                }
                //DataGridView控件行列数
                int rowCount = dgv.Rows.Count;
                int columnCount = dgv.Columns.Count;
                //工作表行列数
                int sheet_row_count = ws.UsedRange.Rows.Count;
                int sheet_column_count = ws.UsedRange.Columns.Count;
                //取单元格
                Excel.Range r = ws.get_Range("A1 ", Missing.Value);
                if (r == null)
                {
                    throw new Exception("Range无法启动");
                }
                //以上是一些例行的初始化工作,下面进行具体的信息填充
                //填充标题
                int ColIndex = 1;
                foreach (DataColumn dHeader in dgv.Columns)
                {
                    ws.Cells[1, ColIndex++] = dHeader.Caption;
                }
                ColIndex = 1;
                //获取DataGridView中的所有行和列的数值,填充到一个二维数组中.
                object[,] myData = new object[rowCount + 1, columnCount];
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < columnCount; j++)
                    {
                        string value = dgv.Rows[i][j].ToString();
                        if (!string.IsNullOrEmpty(value))
                        {
                            if (Validate.IsInt(value))
                            {
                                if (value.Length >= 15 || value.Substring(0, 1) == "0")
                                {
                                    myData[i, j] = "'" + value;
                                }
                                else
                                {
                                    myData[i, j] = value;
                                }
                            }
                            else
                            {
                                DateTime dt;
                                bool isDatetime = DateTime.TryParse(value, out dt);
                                if (isDatetime)
                                {
                                    value = dt.ToShortDateString();
                                }
                                myData[i, j] = value;         //这里的获取注意行列次序
                            }
                        }
                        else
                        {
                            myData[i, j] = value;
                        }
                    }
                }
                //将填充好的二维数组填充到Excel对象中.
                //r = ws.get_Range(ws.Cells[sheet_row_count + 1, 1], ws.Cells[sheet_row_count + rowCount, columnCount]);
                r = ws.Range[ws.Cells[sheet_row_count + 1, 1], ws.Cells[sheet_row_count + rowCount, columnCount]];
                r.Value2 = myData;
                r = null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        #endregion

        #region //把Excel中的数据导入到DataTable
        /// <summary>
        /// 把Excel中的数据导入到DataTable
        /// ExcelEdit myExcel = new ExcelEdit();
        /// myExcel.Open("d:\\数据库表格20071217.xls");
        /// DataTable dt=new DataTable();
        /// myExcel.Excel2DBView("908",dt);
        /// myExcel.Close();
        /// </summary>
        /// <param name="tablename"></param>
        public DataTable Excel2DataTable(string tablename)
        {
            DataTable dt = new DataTable();
            try
            {
                //string strExcelFileName = @""+ myPath +"";
                //string strString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = " + mFilename + ";Extended Properties = &apos;Excel 8.0;HDR=NO;IMEX=1 &apos;";
                //string sConnectionString = "Provider=Microsoft.Jet.Oledb.4.0;Data Source=" + mFilename + ";Extended Properties=Excel 8.0;";
                string sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + mFilename + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=1\"";
                OleDbConnection connection = new OleDbConnection(sConnectionString);
                connection.Open();
                string sql_select_commands = "Select * from [" + tablename + "$]";
                OleDbDataAdapter adp = new OleDbDataAdapter(sql_select_commands, connection);

                adp.Fill(dt);
                connection.Close();
                return dt;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            /*
             *备注：
             * 用OLEDB进行Excel文件数据的读取，并返回DataSet数据集。其中有几点需要注意的：

              1.连接字符串中参数IMEX 的值：
              0 is Export mode 1 is Import mode 2 is Linked mode (full update capabilities)
              IMEX有3个值：当IMEX=2 时，EXCEL文档中同时含有字符型和数字型时，比如第C列有3个值，2个为数值型 123，1个为字符型 ABC，当导入时，
              页面不报错了，但库里只显示数值型的123，而字符型的ABC则呈现为空值。当IMEX=1时，无上述情况发生，库里可正确呈现 123 和 ABC.
             2.参数HDR的值：
             HDR=Yes，这代表第一行是标题，不做为数据使用 ，如果用HDR=NO，则表示第一行不是标题，做为数据来使用。系统默认的是YES
             3.参数Excel 8.0
             对于Excel 97以上版本都用Excel 8.0

              @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\MyExcel.xls;Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"""
              "HDR=Yes;" indicates that the first row contains columnnames, not data
              "IMEX=1;" tells the driver to always read "intermixed" data columns as text
              TIP! SQL syntax: "SELECT * FROM [sheet1$]" - i.e. worksheet name followed by a "$" and wrapped in "[" "]" brackets.
              如果第一行是数据而不是标题的话, 应该写: "HDR=No;"
             "IMEX=1;" tells the driver to always read "intermixed" data columns as text
             * */
            /*
             你可以先用代码打开xls文件:
             Set xlApp = CreateObject("Excel.Application")
             Set xlBook = xlApp.Workbooks.Open("d:\text2.xls")
             for i=0 to xlBook.Worksheets.Count-1
             set  xlSheet = xlBook.Worksheets(i)
             xlSheet.Name   //这就是你需要的每个sheet的名字,保存起来,备后用
             next i
             这里使用的VB写的范例,变成c#即可.
             */

        }
        #endregion

        #region //关闭一个Excel对象，销毁对象
        /// <summary>
        /// 关闭一个Excel对象，销毁对象
        /// </summary>
        public void Close()
        {
            //wb.Save();
            wb.Close(Type.Missing, Type.Missing, Type.Missing);
            wbs.Close();
            app.Quit();
            wb = null;
            wbs = null;
            app = null;
            ws = null;
            GC.Collect();
        }
        #endregion
    }

    public class Validate
    {
        public static bool IsInt(string value)
        {
            return Regex.IsMatch(value, @"^[+-]?\d*$");
        }
    }
}

