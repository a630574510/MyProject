using System;
using System.Collections.Generic;

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
using System.IO;

namespace Citic_Web.InspectionFrequency
{
    public partial class InspectionProcessing : BasePage
    {

        ///-----------------状态1为选择-有问题，0相反-无问题-------------///////////////
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int dep_id = int.Parse(CurrentUser.DeptId.ToString());
                switch (dep_id)
                {
                    case 0:
                        this.T_ContinuousTracking.Hidden = false;           //需持续追踪解决问题
                        this.T_InspectionFrequency.Hidden = false;          //汽车业务
                        this.T_QuartersLedger.Hidden = false;               //需持续追踪解决问题

                        break;
                    case 1:
                        break;
                    case 3:
                        txt_MainProblem_2_Results.Readonly = false;     //汽车业务-风控部处理结果
                        break;
                    case 5:
                        txt_MainProblem_1_Results.Readonly = false;     //汽车业务-市场部处理结果
                        break;
                    case 6:         //业务部
                        this.T_ContinuousTracking.Hidden = false;        //需持续追踪解决问题
                        this.T_InspectionFrequency.Hidden = false;       //汽车业务
                        this.T_QuartersLedger.Hidden = false;           //需持续追踪解决问题
                        this.txt_MainProblem_3_Results.Readonly = false;  //汽车业务-业务部处理结果
                        this.txt_Continue_1_Results.Readonly = false;       //需持续追踪解决问题-业务部处理结果
                        this.txt_QuartersLedger_1_Results.Readonly = false; //总部总账问题-业务部处理结果
                        break;
                    default:
                        break;
                }
                this.T_InspectionFrequency.Title = DateTime.Now.ToLongDateString().ToString() + "视频检查追踪表（汽车业务）";
                this.txt_StartTime.SelectedDate = DateTime.Now;
                this.txt_AsTime.SelectedDate = DateTime.Now;
                BindGrid();
            }
        }
        #region 查询按钮
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        #endregion

        #region Gird绑定
        /// <summary>
        /// Gird绑定 张繁 2013年12月16日
        /// </summary>
        private void BindGrid()
        {
            ViewState.Clear();
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
            if (!string.IsNullOrEmpty(this.txt_CreateName.Text.Trim()))      //检查人员
            {
                sb.Append(" and Rummager like '%" + this.txt_CreateName.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(this.txt_DealerName.Text.Trim()))      //经销店名称
            {
                sb.Append(" and DealerName like '%" + this.txt_DealerName.Text.Trim() + "%'");
            }

            DataSet ds = new Citic.BLL.Inspection().GetList(sb.ToString());
            
            DataTable dt = ds.Clone().Tables[0];
            DataRow[] dr = ds.Tables[0].Select("MainProblemStatu='1'"); //视频检查追踪
            for (int i = 0; i < dr.Length; i++)
            {
                dt.Rows.Add(dr[i].ItemArray);
            }
            ViewState["MainProblem"] = dt.Copy();
            this.G_InspectionFrequency.DataSource = (DataTable)ViewState["MainProblem"];
            this.G_InspectionFrequency.DataBind();

            dr = ds.Tables[0].Select("QuartersLedgerStatu='1'");//总部总账问题
            dt.Clear();
            for (int i = 0; i < dr.Length; i++)
            {
                dt.Rows.Add(dr[i].ItemArray);
            }
            ViewState["QuartersLedger"] = dt.Copy();

            this.G_QuartersLedger.DataSource = (DataTable)ViewState["QuartersLedger"];
            this.G_QuartersLedger.DataBind();

            dr = ds.Tables[0].Select("ContinueStatu='1'");   //持续追踪
            dt.Clear();
            for (int i = 0; i < dr.Length; i++)
            {
                dt.Rows.Add(dr[i].ItemArray);
            }
            ViewState["Continue"] = dt.Copy();
            this.G_ContinuousTracking.DataSource = (DataTable)ViewState["Continue"];
            this.G_ContinuousTracking.DataBind();

            this.T_InspectionFrequency.Title = Convert.ToDateTime(this.txt_StartTime.Text.Trim()).ToLongDateString().ToString() + "-" + Convert.ToDateTime(this.txt_AsTime.Text.Trim()).ToLongDateString().ToString() + "视频检查追踪表（汽车业务）";
        }
        #endregion

        #region 根据行ID来获取行数据
        /// <summary>
        /// 根据行ID来获取行数据
        /// </summary>
        /// <param name="rowID"></param>
        /// <param name="Number">处理类型，1-追踪，2-总账，3-持续</param>
        /// <returns></returns>
        private DataRow FindRowByID(int rowID, int Number)
        {
            DataTable table = null;
            switch (Number)
            {
                case 1:
                    table = (DataTable)ViewState["MainProblem"];
                    break;
                case 2:
                    table = (DataTable)ViewState["QuartersLedger"];
                    break;
                case 3:
                    table = (DataTable)ViewState["Continue"];
                    break;
            }

            foreach (DataRow row in table.Rows)
            {
                if (Convert.ToInt32(row["Id"]) == rowID)
                {
                    return row;
                }
            }
            return null;
        }
        #endregion

        #region 修改DataRow
        /// <summary>
        /// 修改DataRow
        /// </summary>
        /// <param name="rowDict"></param>
        /// <param name="rowData"></param>
        private static void UpdateDataRow(Dictionary<string, string> rowDict, DataRow rowData)
        {
            //起始-------------------------视频追踪-----------------------------//
            // 汽车/产业金融中心处理结果
            if (rowDict.ContainsKey("MainProblem_1_Results"))
            {
                rowData["MainProblem_1_Results"] = rowDict["MainProblem_1_Results"];
            }
            // 风控部处理结果
            if (rowDict.ContainsKey("MainProblem_2_Results"))
            {
                rowData["MainProblem_2_Results"] = rowDict["MainProblem_2_Results"];
            }
            // 管理中心处理结果
            if (rowDict.ContainsKey("MainProblem_3_Results"))
            {
                rowData["MainProblem_3_Results"] = rowDict["MainProblem_3_Results"];
            }
            //结束------------------------------------------------------//
            //起始-----------------------总部总账-------------------------------//
            // 汽车/产业金融中心处理结果
            if (rowDict.ContainsKey("QuartersLedger_1_Results"))
            {
                rowData["QuartersLedger_1_Results"] = rowDict["QuartersLedger_1_Results"];
            }
            // 风控部处理结果
            if (rowDict.ContainsKey("QuartersLedger_2_Results"))
            {
                rowData["QuartersLedger_2_Results"] = rowDict["QuartersLedger_2_Results"];
            }
            // 管理中心处理结果
            if (rowDict.ContainsKey("QuartersLedger_3_Results"))
            {
                rowData["QuartersLedger_3_Results"] = rowDict["QuartersLedger_3_Results"];
            }
            //结束------------------------------------------------------//
            //起始------------------------持续追踪------------------------------//
            // 汽车/产业金融中心处理结果
            if (rowDict.ContainsKey("Continue_1_Results"))
            {
                rowData["Continue_1_Results"] = rowDict["Continue_1_Results"];
            }
            // 风控部处理结果
            if (rowDict.ContainsKey("Continue_1_Results"))
            {
                rowData["Continue_2_Results"] = rowDict["Continue_2_Results"];
            }
            // 管理中心处理结果
            if (rowDict.ContainsKey("Continue_1_Results"))
            {
                rowData["Continue_3_Results"] = rowDict["Continue_3_Results"];
            }
            //结束------------------------------------------------------//
        }
        #endregion

        #region 处理总部总账
        /// <summary>
        /// 总部总账问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void QuartersLedger_Update_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_QuartersLedger.GetModifiedDict();
            if (modifiedDict.Count > 0)
            {
                List<string> list = new List<string>();     //存放sql语句集合 
                string UserName = CurrentUser.TrueName.ToString();
                string UserId = CurrentUser.UserId.ToString();
                foreach (int rowIndex in modifiedDict.Keys)
                {
                    string Update_Inspection = "update tb_Inspection set ";

                    if (modifiedDict[rowIndex].ContainsKey("QuartersLedger_1_Results"))
                    {
                        string QuartersLedger_1_Results = modifiedDict[rowIndex]["QuartersLedger_1_Results"].ToString();
                        Update_Inspection += "QuartersLedger_1_Results='" + QuartersLedger_1_Results + "',QuartersLedger_1_People='" + UserName + "',QuartersLedger_1_Date=GETDATE(),";
                        int rowID = Convert.ToInt32(G_QuartersLedger.DataKeys[rowIndex][0]);       //获取绑定ID-数据库ID
                        Update_Inspection = Update_Inspection.Remove(Update_Inspection.Length - 1, 1) + " where ID='" + rowID + "' ";  //移除最后一个符号
                        list.Add(Update_Inspection);        //sql语句添加到list
                    }
                    //if (modifiedDict[rowIndex].ContainsKey("QuartersLedger_2_Results"))
                    //{
                    //    string QuartersLedger_2_Results = modifiedDict[rowIndex]["QuartersLedger_2_Results"].ToString();
                    //    Update_Inspection += "QuartersLedger_2_Results='" + QuartersLedger_2_Results + "',QuartersLedger_2_People='" + UserName + "',QuartersLedger_2_Date=GETDATE(),";
                    //}
                    //if (modifiedDict[rowIndex].ContainsKey("QuartersLedger_3_Results"))
                    //{
                    //    string QuartersLedger_3_Results = modifiedDict[rowIndex]["QuartersLedger_3_Results"].ToString();
                    //    Update_Inspection += "QuartersLedger_3_Results='" + QuartersLedger_3_Results + "',QuartersLedger_3_People='" + UserName + "',QuartersLedger_3_Date=GETDATE(),";
                    //}


                    //DataRow row = FindRowByID(rowID, 2);
                    //UpdateDataRow(modifiedDict[rowIndex], row);
                }
                if (list.Count > 0)
                {
                    int Number = new Citic.BLL.Car().SqlTran(list);
                    if (Number > 0)
                    {
                        FineUI.Alert.ShowInTop("处理成功", FineUI.MessageBoxIcon.Information);
                        DataTable dt = ((DataTable)ViewState["QuartersLedger"]).Clone();       //复制表结构
                        ViewState.Remove("QuartersLedger");            //移除
                        this.G_QuartersLedger.DataSource = dt;
                        this.G_QuartersLedger.DataBind();

                    }
                    else
                    {
                        FineUI.Alert.ShowInTop("处理失败！", FineUI.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.ShowInTop("处理失败！", FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("没修改任何数据！", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 处理需持续追踪
        /// <summary>
        /// 需持续追踪解决问题
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ContinuousTracking_Update_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_ContinuousTracking.GetModifiedDict();
            if (modifiedDict.Count > 0)
            {
                List<string> list = new List<string>();     //存放sql语句集合
                string UserName = CurrentUser.TrueName.ToString();
                string UserId = CurrentUser.UserId.ToString();
                foreach (int rowIndex in modifiedDict.Keys)
                {
                    string Update_Inspection = "update tb_Inspection set ";

                    if (modifiedDict[rowIndex].ContainsKey("Continue_1_Results"))
                    {
                        string Continue_1_Results = modifiedDict[rowIndex]["Continue_1_Results"].ToString();
                        Update_Inspection += "Continue_1_Results='" + Continue_1_Results + "',Continue_1_People='" + UserName + "',Continue_1_Date=GETDATE(),";
                        int rowID = Convert.ToInt32(G_ContinuousTracking.DataKeys[rowIndex][0]);       //获取绑定ID-数据库ID
                        Update_Inspection = Update_Inspection.Remove(Update_Inspection.Length - 1, 1) + " where ID='" + rowID + "' ";  //移除最后一个符号
                        list.Add(Update_Inspection);        //sql语句添加到list
                    }
                    //if (modifiedDict[rowIndex].ContainsKey("Continue_2_Results"))
                    //{
                    //    string Continue_2_Results = modifiedDict[rowIndex]["Continue_2_Results"].ToString();
                    //    Update_Inspection += "Continue_2_Results='" + Continue_2_Results + "',Continue_2_People='" + UserName + "',Continue_2_Date=GETDATE(),";
                    //}
                    //if (modifiedDict[rowIndex].ContainsKey("Continue_3_Results"))
                    //{
                    //    string Continue_3_Results = modifiedDict[rowIndex]["Continue_3_Results"].ToString();
                    //    Update_Inspection += "Continue_3_Results='" + Continue_3_Results + "',Continue_3_People='" + UserName + "',Continue_3_Date=GETDATE(),";
                    //}


                    //DataRow row = FindRowByID(rowID, 3);
                    //UpdateDataRow(modifiedDict[rowIndex], row);
                }
                if (list.Count > 0)
                {
                    int Number = new Citic.BLL.Car().SqlTran(list);
                    if (Number > 0)
                    {
                        FineUI.Alert.ShowInTop("处理成功", FineUI.MessageBoxIcon.Information);
                        DataTable dt = ((DataTable)ViewState["Continue"]).Clone();       //复制表结构
                        ViewState.Remove("Continue");            //移除
                        this.G_ContinuousTracking.DataSource = dt;
                        this.G_ContinuousTracking.DataBind();

                    }
                    else
                    {
                        FineUI.Alert.ShowInTop("处理失败！", FineUI.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.ShowInTop("处理失败！", FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("没修改任何数据！", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 处理视频检查追踪
        /// <summary>
        /// 视频检查追踪
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void InspectionFrequency_Update_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_InspectionFrequency.GetModifiedDict();
            if (modifiedDict.Count > 0)
            {
                List<string> list = new List<string>();     //存放sql语句集合
                string UserName = CurrentUser.TrueName.ToString();
                string UserId = CurrentUser.UserId.ToString();
                foreach (int rowIndex in modifiedDict.Keys)
                {
                    //修改sql语句
                    string Update_Inspection = "update tb_Inspection set ";
                    //判断列是否以修改
                    if (modifiedDict[rowIndex].ContainsKey("MainProblem_1_Results"))
                    {
                        string MainProblem_1_Results = modifiedDict[rowIndex]["MainProblem_1_Results"].ToString();   //汽车/产业金融中心处理结果
                        Update_Inspection += " MainProblem_1_Results='" + MainProblem_1_Results + "',MainProblem_1_People='" + UserName + "',MainProblem_1_Date=GETDATE(),";
                    }
                    if (modifiedDict[rowIndex].ContainsKey("MainProblem_2_Results"))
                    {
                        string MainProblem_2_Results = modifiedDict[rowIndex]["MainProblem_2_Results"].ToString();   //风控部处理结果
                        Update_Inspection += " MainProblem_2_Results='" + MainProblem_2_Results + "',MainProblem_2_People='" + UserName + "',MainProblem_2_Date=GETDATE(),";
                    }
                    if (modifiedDict[rowIndex].ContainsKey("MainProblem_3_Results"))
                    {
                        string MainProblem_3_Results = modifiedDict[rowIndex]["MainProblem_3_Results"].ToString();   //管理中心处理结果
                        Update_Inspection += " MainProblem_3_Results='" + MainProblem_3_Results + "',MainProblem_3_People='" + UserName + "',MainProblem_3_Date=GETDATE(),";
                    }
                    int rowID = Convert.ToInt32(G_InspectionFrequency.DataKeys[rowIndex][0]);       //获取绑定ID-数据库ID
                    Update_Inspection = Update_Inspection.Remove(Update_Inspection.Length - 1, 1) + " where ID='" + rowID + "' ";  //移除最后一个符号
                    list.Add(Update_Inspection);        //sql语句添加到list
                    //DataRow row = FindRowByID(rowID, 1);
                    //UpdateDataRow(modifiedDict[rowIndex], row);
                }
                if (list.Count > 0)
                {
                    int Number = new Citic.BLL.Car().SqlTran(list);
                    if (Number > 0)
                    {
                        FineUI.Alert.ShowInTop("处理成功", FineUI.MessageBoxIcon.Information);
                        DataTable dt = ((DataTable)ViewState["MainProblem"]).Clone();       //复制表结构
                        ViewState.Remove("MainProblem");            //移除
                        this.G_InspectionFrequency.DataSource = dt;
                        this.G_InspectionFrequency.DataBind();

                    }
                    else
                    {
                        FineUI.Alert.ShowInTop("处理失败！", FineUI.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.ShowInTop("处理失败！", FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("没修改任何数据！", FineUI.MessageBoxIcon.Error);
            }

        }
        #endregion

        protected void Btn_Generate_Click(object sender, EventArgs e)
        {
            IWorkbook hSSFWorkbook = new HSSFWorkbook();
            ISheet sheet = hSSFWorkbook.CreateSheet("视频检查追踪");
            IRow row;
            ICell cell;
            ICellStyle style;
            IFont font;
            string StartTime = this.txt_StartTime.Text.Trim();
            string AsTime = this.txt_AsTime.Text.Trim();
            #region 视频检查
            row = sheet.CreateRow(0);           //创建行     0
            row.Height = 20 * 20;           //行高
            cell = row.CreateCell(0);       //创建行的列
            cell.SetCellValue(string.Format("{0}至{1}视频检查日报表", StartTime, AsTime));   //列值
            style = hSSFWorkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;   //文字居中
            style.VerticalAlignment = VerticalAlignment.Center; //水平对其
            font = hSSFWorkbook.CreateFont();
            font.FontName = "宋体";
            font.Boldweight = short.MaxValue;       //字体加粗
            font.FontHeightInPoints = 14;      //列字体大小
            style.SetFont(font);
            cell.CellStyle = style;
            sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 14));

            row = sheet.CreateRow(1);       //创建行     1
            row.Height = 30 * 20;       //行高

            style = hSSFWorkbook.CreateCellStyle();
            font = hSSFWorkbook.CreateFont();
            font.Boldweight = short.MaxValue;       //字体加粗
            font.FontHeightInPoints = 11;       //列字体大小
            font.FontName = "宋体";
            style.SetFont(font);
            style.FillPattern = FillPattern.SolidForeground;
            style.FillForegroundColor = HSSFColor.Tan.Index;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style.Alignment = HorizontalAlignment.Center;       //文字居中
            style.VerticalAlignment = VerticalAlignment.Justify; //水平对其
            cell = row.CreateCell(0);        //创建行的列
            cell.SetCellValue("序号");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(1);        //创建行的列
            cell.SetCellValue("经销店名称");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(2);        //创建行的列
            cell.SetCellValue("合作银行");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(3);        //创建行的列
            cell.SetCellValue("品牌");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(4);        //创建行的列
            cell.SetCellValue("监管员");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(5);        //创建行的列
            cell.SetCellValue("检查问题");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(6);        //创建行的列
            cell.SetCellValue("市场部处理结果");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(7);        //创建行的列
            cell.SetCellValue("市场部处理人员");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(8);        //创建行的列
            cell.SetCellValue("市场部处理时间");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(9);        //创建行的列
            cell.SetCellValue("业务部处理结果");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(10);        //创建行的列
            cell.SetCellValue("业务部处理人员");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(11);        //创建行的列
            cell.SetCellValue("业务部处理时间");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(12);        //创建行的列
            cell.SetCellValue("风控部处理结果");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(13);        //创建行的列
            cell.SetCellValue("风控部处理人员");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(14);        //创建行的列
            cell.SetCellValue("风控部处理时间");         //列值
            cell.CellStyle = style;

            DataTable dt = (DataTable)ViewState["MainProblem"];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                row = sheet.CreateRow(2 + i);       //创建行     6
                row.Height = 30 * 20;       //行高
                style = hSSFWorkbook.CreateCellStyle();

                style.Alignment = HorizontalAlignment.Center;       //文字居中
                style.VerticalAlignment = VerticalAlignment.Justify; //水平对其

                cell = row.CreateCell(0);        //创建行的列
                cell.SetCellValue(i + 1);         //列值-序号
                cell.CellStyle = style;

                cell = row.CreateCell(1);        //创建行的列
                cell.SetCellValue(dr["DealerName"].ToString());         //列值 
                cell.CellStyle = style;

                cell = row.CreateCell(2);        //创建行的列
                cell.SetCellValue(dr["Bank"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(3);        //创建行的列
                cell.SetCellValue(dr["BrandName"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(4);        //创建行的列
                cell.SetCellValue(dr["SupervisorName"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(5);        //创建行的列
                cell.SetCellValue(dr["MainProblem"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(6);        //创建行的列
                cell.SetCellValue(dr["MainProblem_1_Results"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(7);        //创建行的列
                cell.SetCellValue(dr["MainProblem_1_People"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(8);        //创建行的列
                cell.SetCellValue(dr["MainProblem_1_Date"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(9);        //创建行的列
                cell.SetCellValue(dr["MainProblem_3_Results"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(10);        //创建行的列
                cell.SetCellValue(dr["MainProblem_3_People"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(11);        //创建行的列
                cell.SetCellValue(dr["MainProblem_3_Date"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(12);        //创建行的列
                cell.SetCellValue(dr["MainProblem_2_Results"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(12);        //创建行的列
                cell.SetCellValue(dr["MainProblem_2_People"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(12);        //创建行的列
                cell.SetCellValue(dr["MainProblem_2_Date"].ToString());         //列值
                cell.CellStyle = style;

            }
            #endregion
            #region 需持续追踪解决问题
            ISheet sheet2 = hSSFWorkbook.CreateSheet("需持续追踪解决问题");


            row = sheet2.CreateRow(0);           //创建行     0
            row.Height = 20 * 20;           //行高
            cell = row.CreateCell(0);       //创建行的列
            cell.SetCellValue(string.Format("{0}至{1}需持续追踪解决问题", StartTime, AsTime));   //列值
            style = hSSFWorkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;   //文字居中
            style.VerticalAlignment = VerticalAlignment.Center; //水平对其
            font = hSSFWorkbook.CreateFont();
            font.FontName = "宋体";
            font.Boldweight = short.MaxValue;       //字体加粗
            font.FontHeightInPoints = 14;      //列字体大小
            style.SetFont(font);
            cell.CellStyle = style;
            sheet2.AddMergedRegion(new CellRangeAddress(0, 0, 0, 9));

            row = sheet2.CreateRow(1);       //创建行     1
            row.Height = 30 * 20;       //行高

            style = hSSFWorkbook.CreateCellStyle();
            font = hSSFWorkbook.CreateFont();
            font.Boldweight = short.MaxValue;       //字体加粗
            font.FontHeightInPoints = 11;       //列字体大小
            font.FontName = "宋体";
            style.SetFont(font);
            style.FillPattern = FillPattern.SolidForeground;
            style.FillForegroundColor = HSSFColor.Tan.Index;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style.Alignment = HorizontalAlignment.Center;       //文字居中
            style.VerticalAlignment = VerticalAlignment.Justify; //水平对其
            cell = row.CreateCell(0);        //创建行的列
            cell.SetCellValue("序号");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(1);        //创建行的列
            cell.SetCellValue("经销店名称");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(2);        //创建行的列
            cell.SetCellValue("合作银行");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(3);        //创建行的列
            cell.SetCellValue("品牌");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(4);        //创建行的列
            cell.SetCellValue("监管员");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(5);        //创建行的列
            cell.SetCellValue("检查问题");         //列值
            cell.CellStyle = style;

            cell = row.CreateCell(6);        //创建行的列
            cell.SetCellValue("历史检查时间");         //列值
            cell.CellStyle = style;

            cell = row.CreateCell(7);        //创建行的列
            cell.SetCellValue("业务部处理结果");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(8);        //创建行的列
            cell.SetCellValue("业务部处理人员");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(9);        //创建行的列
            cell.SetCellValue("业务部处理时间");         //列值
            cell.CellStyle = style;
            dt.Clear();
            dt = (DataTable)ViewState["Continue"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                row = sheet2.CreateRow(2 + i);       //创建行     6
                row.Height = 30 * 20;       //行高
                style = hSSFWorkbook.CreateCellStyle();

                style.Alignment = HorizontalAlignment.Center;       //文字居中
                style.VerticalAlignment = VerticalAlignment.Justify; //水平对其

                cell = row.CreateCell(0);        //创建行的列
                cell.SetCellValue(i + 1);         //列值-序号
                cell.CellStyle = style;

                cell = row.CreateCell(1);        //创建行的列
                cell.SetCellValue(dr["DealerName"].ToString());         //列值 
                cell.CellStyle = style;

                cell = row.CreateCell(2);        //创建行的列
                cell.SetCellValue(dr["Bank"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(3);        //创建行的列
                cell.SetCellValue(dr["BrandName"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(4);        //创建行的列
                cell.SetCellValue(dr["SupervisorName"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(5);        //创建行的列
                cell.SetCellValue(dr["MainProblem"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(6);        //创建行的列
                cell.SetCellValue(dr["HistoryDate"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(7);        //创建行的列
                cell.SetCellValue(dr["Continue_1_Results"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(8);        //创建行的列
                cell.SetCellValue(dr["Continue_1_People"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(9);        //创建行的列
                cell.SetCellValue(dr["Continue_1_Date"].ToString());         //列值
                cell.CellStyle = style;

            }
            #endregion
            #region 总部总账问题
            
            
            ISheet sheet3 = hSSFWorkbook.CreateSheet("总部总账问题");
            row = sheet3.CreateRow(0);           //创建行     0
            row.Height = 20 * 20;           //行高
            cell = row.CreateCell(0);       //创建行的列
            cell.SetCellValue(string.Format("{0}至{1}总部总账问题", StartTime, AsTime));   //列值
            style = hSSFWorkbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.Center;   //文字居中
            style.VerticalAlignment = VerticalAlignment.Center; //水平对其
            font = hSSFWorkbook.CreateFont();
            font.FontName = "宋体";
            font.Boldweight = short.MaxValue;       //字体加粗
            font.FontHeightInPoints = 14;      //列字体大小
            style.SetFont(font);
            cell.CellStyle = style;
            sheet3.AddMergedRegion(new CellRangeAddress(0, 0, 0, 7));

            row = sheet3.CreateRow(1);       //创建行     1
            row.Height = 30 * 20;       //行高

            style = hSSFWorkbook.CreateCellStyle();
            font = hSSFWorkbook.CreateFont();
            font.Boldweight = short.MaxValue;       //字体加粗
            font.FontHeightInPoints = 11;       //列字体大小
            font.FontName = "宋体";
            style.SetFont(font);
            style.FillPattern = FillPattern.SolidForeground;
            style.FillForegroundColor = HSSFColor.Tan.Index;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
            style.Alignment = HorizontalAlignment.Center;       //文字居中
            style.VerticalAlignment = VerticalAlignment.Justify; //水平对其
            cell = row.CreateCell(0);        //创建行的列
            cell.SetCellValue("序号");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(1);        //创建行的列
            cell.SetCellValue("经销店名称");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(2);        //创建行的列
            cell.SetCellValue("合作银行");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(3);        //创建行的列
            cell.SetCellValue("品牌");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(4);        //创建行的列
            cell.SetCellValue("总部总账问题(系统、电子总账）");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(5);        //创建行的列
            cell.SetCellValue("业务部处理结果");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(6);        //创建行的列
            cell.SetCellValue("业务部处理人员");         //列值
            cell.CellStyle = style;
            cell = row.CreateCell(7);        //创建行的列
            cell.SetCellValue("业务部处理时间");         //列值
            cell.CellStyle = style;
            dt.Clear();
            dt = (DataTable)ViewState["QuartersLedger"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                row = sheet3.CreateRow(2 + i);       //创建行     
                row.Height = 30 * 20;       //行高
                style = hSSFWorkbook.CreateCellStyle();

                style.Alignment = HorizontalAlignment.Center;       //文字居中
                style.VerticalAlignment = VerticalAlignment.Justify; //水平对其

                cell = row.CreateCell(0);        //创建行的列
                cell.SetCellValue(i + 1);         //列值-序号
                cell.CellStyle = style;

                cell = row.CreateCell(1);        //创建行的列
                cell.SetCellValue(dr["DealerName"].ToString());         //列值 
                cell.CellStyle = style;

                cell = row.CreateCell(2);        //创建行的列
                cell.SetCellValue(dr["Bank"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(3);        //创建行的列
                cell.SetCellValue(dr["BrandName"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(4);        //创建行的列
                cell.SetCellValue(dr["QuartersLedger"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(5);        //创建行的列
                cell.SetCellValue(dr["QuartersLedger_1_Results"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(6);        //创建行的列
                cell.SetCellValue(dr["QuartersLedger_1_People"].ToString());         //列值
                cell.CellStyle = style;

                cell = row.CreateCell(7);        //创建行的列
                cell.SetCellValue(dr["QuartersLedger_1_Date"].ToString());         //列值
                cell.CellStyle = style;

            }
            #endregion

            string FileName = DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".xls";
            string Map = Server.MapPath("~/Confirmation/视频检查文件/" + FileName);
            FileStream file = new FileStream(Map, FileMode.Create);
            hSSFWorkbook.Write(file);
            file.Close();
            this.hl_ExportExcel.NavigateUrl = "~/Confirmation/视频检查文件/" + FileName;
        }
    }
}