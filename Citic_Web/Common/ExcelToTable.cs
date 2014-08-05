using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NPOI.HSSF.UserModel;
using System.Data;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Citic_Web.Common
{
    public class ExcelToTable
    {
        public static MemoryStream WriteDataToExcel(DataSet ds)
        {
            MemoryStream memoryStream = new MemoryStream();
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                foreach (DataTable table in ds.Tables)
                {
                    ISheet sheet = workbook.CreateSheet(table.TableName);
                    IRow headerRow = sheet.CreateRow(0);
                    foreach (DataColumn column in table.Columns)
                    {
                        headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                    }
                    int rowIndex = 1;
                    foreach (DataRow row in table.Rows)
                    {
                        IRow dataRow = sheet.CreateRow(rowIndex);
                        foreach (DataColumn column in table.Columns)
                        {
                            dataRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                        }
                        rowIndex++;
                    }
                    sheet = null;
                    headerRow = null;
                }
                workbook.Write(memoryStream);

                workbook = null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return memoryStream;
        }

        public static DataSet ExcelToDataSet(string excelPath, int ColumnCount, int ColumnIsNull)
        {
            return ExcelToDataSet(excelPath, true, ColumnCount, ColumnIsNull);
        }
        public static DataSet ExcelToDataSet(string excelPath, bool firstRowAsHeader, int ColumnCount, int ColumnIsNull)
        {
            int sheetCount;
            return ExcelToDataSet(excelPath, firstRowAsHeader, out sheetCount, ColumnCount, ColumnIsNull);
        }
        public static DataSet ExcelToDataSet(string excelPath, bool firstRowAsHeader, out int sheetCount, int ColumnCount, int ColumnIsNull)
        {
            using (DataSet ds = new DataSet())
            {
                using (FileStream fileStream = new FileStream(excelPath, FileMode.Open, FileAccess.Read))
                {
                    HSSFWorkbook workbook = new HSSFWorkbook(fileStream);
                    HSSFFormulaEvaluator evaluator = new HSSFFormulaEvaluator(workbook);
                    sheetCount = workbook.NumberOfSheets;
                    for (int i = 0; i < sheetCount; ++i)
                    {
                        HSSFSheet sheet = workbook.GetSheetAt(i) as HSSFSheet;
                        DataTable dt = ExcelToDataTable(sheet, evaluator, firstRowAsHeader, ColumnCount, ColumnIsNull);
                        ds.Tables.Add(dt);
                    }
                    return ds;
                }
            }
        }
        #region 解析Excel返回DataTable
        /// <summary>
        /// 解析Excel返回DataTable
        /// </summary>
        /// <param name="excelPath">路径</param>
        /// <param name="sheetName">工作簿名，为空取第一个工作簿</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string excelPath, string sheetName)
        {
            return ExcelToDataTable(excelPath, sheetName, true, 0, 0);
        }
        /// <summary>
        /// 解析Excel返回DataTable
        /// </summary>
        /// <param name="excelPath">路径</param>
        /// <param name="sheetName">工作簿名，为空取第一个工作簿</param>
        /// <param name="firstRowAsHeader">第一行是否为标题</param>
        /// <param name="ColumnCount">列长度，为0取全部列</param>
        /// <param name="ColumnIsNull">指定某列数据不能为空,为0不指定</param>
        /// <returns></returns>
        public static DataTable ExcelToDataTable(string excelPath, string sheetName, bool firstRowAsHeader, int ColumnCount, int ColumnIsNull)
        {
            using (FileStream fileStream = new FileStream(excelPath, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workbook = null;
                IFormulaEvaluator evaluator = null;
                ISheet sheet = null;
                if (excelPath.EndsWith(".xls"))
                {
                    workbook = new HSSFWorkbook(fileStream);
                    evaluator = new HSSFFormulaEvaluator(workbook);
                    sheet = workbook.GetSheet(sheetName) as HSSFSheet;
                    if (sheet == null)
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    workbook = new XSSFWorkbook(fileStream);
                    evaluator = new XSSFFormulaEvaluator(workbook);
                    sheet = workbook.GetSheet(sheetName) as XSSFSheet;
                    if (sheet == null)
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                return ExcelToDataTable(sheet, evaluator, firstRowAsHeader, ColumnCount, ColumnIsNull);
            }
        }
        #endregion
        private static DataTable ExcelToDataTable(ISheet sheet, IFormulaEvaluator evaluator, bool firstRowAsHeader, int ColumnCount, int ColumnIsNull)
        {
            if (firstRowAsHeader)
            {
                return ExcelToDataTableFirstRowAsHeader(sheet, evaluator, ColumnCount, ColumnIsNull);
            }
            else
            {
                return ExcelToDataTable(sheet, evaluator, ColumnCount, ColumnIsNull);
            }
        }
        private static DataTable ExcelToDataTableFirstRowAsHeader(ISheet sheet, IFormulaEvaluator evaluator, int ColumnCount, int ColumnIsNull)
        {
            using (DataTable dt = new DataTable())
            {
                IRow firstRow = sheet.GetRow(0) as IRow;
                if (ColumnCount == 0)
                {
                    ColumnCount = GetCellCount(sheet);
                }
                for (int i = 0; i < ColumnCount; i++)
                {
                    if (firstRow.GetCell(i) != null)
                    {
                        dt.Columns.Add(firstRow.GetCell(i).StringCellValue ?? string.Format("F{0}", i + 1), typeof(string));
                    }
                    else
                    {
                        dt.Columns.Add(string.Format("F{0}", i + 1), typeof(string));
                    }
                }
                for (int i = 1; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i) as IRow;
                    if (ColumnIsNull == 0)
                    {
                        DataRow dr = dt.NewRow();
                        FillDataRowByHSSFRow(row, evaluator, ref dr);
                        dt.Rows.Add(dr);
                    }
                    else
                    {
                        if (row.Cells[ColumnIsNull].StringCellValue.Length != 0)
                        {
                            DataRow dr = dt.NewRow();
                            FillDataRowByHSSFRow(row, evaluator, ref dr);
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                
                dt.TableName = sheet.SheetName;
                return dt;
            }
        }
        private static DataTable ExcelToDataTable(ISheet sheet, IFormulaEvaluator evaluator, int ColumnCount, int ColumnIsNull)
        {
            using (DataTable dt = new DataTable())
            {
                if (sheet.LastRowNum != 0)
                {
                    if (ColumnCount == 0)
                    {
                        ColumnCount = GetCellCount(sheet);
                    }
                    for (int i = 0; i < ColumnCount; i++)
                    {
                        dt.Columns.Add(string.Format("F{0}", i), typeof(string));
                    }
                    for (int i = 0; i < sheet.FirstRowNum; ++i)
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);
                    }
                    for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; i++)
                    {
                        IRow row = sheet.GetRow(i) as IRow;
                        if (ColumnIsNull == 0)
                        {
                            DataRow dr = dt.NewRow();
                            FillDataRowByHSSFRow(row, evaluator, ref dr);
                            dt.Rows.Add(dr);
                        }
                        else
                        {
                            if (row.Cells[ColumnIsNull].StringCellValue.Length != 0)
                            {
                                DataRow dr = dt.NewRow();
                                FillDataRowByHSSFRow(row, evaluator, ref dr);
                                dt.Rows.Add(dr);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                }
                dt.TableName = sheet.SheetName; return dt;
            }
        }
        private static void FillDataRowByHSSFRow(IRow row, IFormulaEvaluator evaluator, ref DataRow dr)
        {
            if (row != null)
            {
                for (int j = 0; j < dr.Table.Columns.Count; j++)
                {
                    ICell cell = row.GetCell(j) as ICell;
                    if (cell != null)
                    {
                        switch (cell.CellType)
                        {
                            case CellType.Blank: dr[j] = DBNull.Value;
                                break;
                            case CellType.Boolean:
                                dr[j] = cell.BooleanCellValue;
                                break;
                            case CellType.Numeric:
                                if (DateUtil.IsCellDateFormatted(cell))
                                {
                                    dr[j] = cell.DateCellValue;
                                }
                                else
                                {
                                    dr[j] = cell.NumericCellValue;
                                }
                                break;
                            case CellType.String:
                                dr[j] = cell.StringCellValue;
                                break;
                            case CellType.Error:
                                dr[j] = cell.ErrorCellValue;
                                break;
                            case CellType.Formula:
                                cell = evaluator.EvaluateInCell(cell) as ICell;
                                dr[j] = cell.ToString();
                                break;
                            default:
                                throw new NotSupportedException(string.Format("Catched unhandle CellType[{0}]", cell.CellType));
                        }
                    }
                }
            }
        }
        private static int GetCellCount(ISheet sheet)
        {
            int firstRowNum = sheet.FirstRowNum;
            int cellCount = 0;
            for (int i = sheet.FirstRowNum; i <= sheet.LastRowNum; ++i)
            {
                IRow row = sheet.GetRow(i) as IRow;
                if (row != null && row.LastCellNum > cellCount)
                {
                    cellCount = row.LastCellNum;
                }
            }
            return cellCount;
        }
    }

}

