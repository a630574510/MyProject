using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using FineUI;
using System.Data;
using System.Data.SqlClient;
namespace Citic_Web.InspectionFrequency
{
    public partial class InspectionDayTableAdd : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
        #region 添加视频检查日行
        /// <summary>
        /// 添加Grid行 张繁 2013年8月13日
        /// </summary>
        private string G_DayTabel_Add()
        {
            JObject o = new JObject();
            o.Add("Area", "");               //区域中心
            //o.Add("Rummager", "");           //检查人员
            o.Add("DealerName", "");         //经销店名称
            o.Add("Bank", "");               //合作银行
            o.Add("BrandName", "");          //品牌
            o.Add("SupervisorName", "");     //监管员
            o.Add("Model", "");              //监管模式
            o.Add("Inventory", "");          //库存
            o.Add("QuartersLedger", "");     //总部总账
            o.Add("MainProblem", "");        //主要问题
            o.Add("Remark", "");             //备注
            return G_DayTabel.GetAddNewRecordReference(o, true);


        }
        #endregion

        #region 添加新行，并且绑定数据源
        /// <summary>
        /// 添加新行   张繁 2013年12月16日 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_G_DayTabel(object sender, EventArgs e)
        {
            if (this.P_txt_DealerName.Text.Length != 0)
            {
                DataTable dt = GetSourceDataDay();
                string[] strList = this.P_txt_DealerName.Text.Split('_');
                string Model = string.Empty;
                switch (int.Parse(strList[4]))
                {
                    case 1:
                        Model = "车证钥匙";
                        break;
                    case 2:
                        Model = "合格证";
                        break;
                    case 3:
                        Model = "巡库";
                        break;
                }
                DataRow dr = dt.NewRow();
                //dr["Area"] = "";                 //区域中心
                dr["DealerName"] = strList[0];  //经销店名称
                dr["Bank"] = strList[1];          //合作银行
                dr["BrandName"] = strList[2];       //品牌
                dr["SupervisorName"] = strList[3];  //监管员
                dr["Model"] = Model;             //监管模式
                dt.Rows.Add(dr);
                this.G_DayTabel.DataSource = GetSourceDataDay();
                this.G_DayTabel.DataBind();
                //JObject o = new JObject();
                //o.Add("Area", "");               //区域中心
                ////o.Add("Rummager", "");           //检查人员
                //o.Add("DealerName", strList[0]);         //经销店名称
                //o.Add("Bank", strList[1]);               //合作银行
                //o.Add("BrandName", strList[2]);          //品牌
                //o.Add("SupervisorName", strList[3]);     //监管员
                //o.Add("Model", Model);              //监管模式
                //o.Add("Inventory", "");          //库存
                //o.Add("QuartersLedger", "");     //总部总账
                //o.Add("MainProblem", "");        //主要问题
                //o.Add("Remark", "");
                //G_DayTabel.AddNewRecord(o, true);
            }
            else
            {
                FineUI.Alert.ShowInTop("请填写经销商！", MessageBoxIcon.Error);
            }
        }
        #endregion
        #region 删除当前追踪表选择行
        /// <summary>
        /// 删除当前选择行 张繁 2013年8月13日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Del_Day_Click(object sender, EventArgs e)
        {
            if (G_DayTabel.SelectedCell != null)
            {
                //UpdateAndAddDayTabel();  //更新或修改视频检查表数据源

                int rowIndex = G_DayTabel.SelectedCell[0];   //获取当前选择单元格索引
                DataTable dt = GetSourceDataDay();     //获取数据源
                dt.Rows.RemoveAt(rowIndex);     //移除指定索引行

                G_DayTabel.DataSource = GetSourceDataDay();
                G_DayTabel.DataBind();
            }
            else
            {
                Alert.ShowInTop("没有选中任何单元格！", MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region 创建空datatable
        /// <summary>
        /// 创建空datatable 张繁 2013年8月13日 
        /// </summary>
        /// <returns></returns>
        private DataTable GetEmptyDataTableDay()
        {
            //创建table对象
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Area", typeof(String)));              //检查区域
            //table.Columns.Add(new DataColumn("Rummager", typeof(String)));          //检查人员
            table.Columns.Add(new DataColumn("DealerName", typeof(String)));        //经销店名称
            table.Columns.Add(new DataColumn("Bank", typeof(String)));              //合作银行
            table.Columns.Add(new DataColumn("BrandName", typeof(String)));         //品牌
            table.Columns.Add(new DataColumn("SupervisorName", typeof(String)));    //监管员
            table.Columns.Add(new DataColumn("Model", typeof(String)));             //监管模式
            table.Columns.Add(new DataColumn("Inventory", typeof(String)));         //库存
            table.Columns.Add(new DataColumn("QuartersLedger", typeof(String)));    //总部总账
            table.Columns.Add(new DataColumn("QuartersLedgerStatu", typeof(String)));    //总部总账状态
            table.Columns.Add(new DataColumn("MainProblem", typeof(String)));       //主要问题
            table.Columns.Add(new DataColumn("MainProblemStatu", typeof(String)));       //主要问题状态
            table.Columns.Add(new DataColumn("HistoryDate", typeof(DateTime)));       //历史检查时间 
            table.Columns.Add(new DataColumn("ContinueStatu", typeof(String)));       //持续状态
            table.Columns.Add(new DataColumn("IsConform", typeof(String)));       //是否正常
            table.Columns.Add(new DataColumn("Remark", typeof(String)));            //备注
            return table;
        }
        #endregion
        #region 检查ViewState
        /// <summary>
        /// 视频检查当前数据集合是否存在 张繁 2013年8月13日
        /// </summary>
        /// <returns>返回datatabel</returns>
        private DataTable GetSourceDataDay()
        {
            //判断当前是否存在ViewState
            if (ViewState["Day"] == null)
            {
                //不存在则创建空的数据源赋给ViewState
                ViewState["Day"] = GetEmptyDataTableDay();
            }
            return (DataTable)ViewState["Day"];
        }
        #endregion
        #region 视频检查更新数据源
        /// <summary>
        /// 视频检查更新数据源 张繁 2013年8月13日
        /// </summary>
        /// <param name="rowDict"></param>
        /// <param name="rowData"></param>
        private static void UpdateDataRowDay(Dictionary<string, string> rowDict, DataRow rowData)
        {
            // 检查区域
            if (rowDict.ContainsKey("Area"))
            {
                rowData["Area"] = rowDict["Area"];
            }
            // 检查人员
            //if (rowDict.ContainsKey("Rummager"))
            //{
            //    rowData["Rummager"] = rowDict["Rummager"];
            //}
            // 经销店名称
            if (rowDict.ContainsKey("DealerName"))
            {
                rowData["DealerName"] = rowDict["DealerName"];
            }
            // 合作银行
            if (rowDict.ContainsKey("Bank"))
            {
                rowData["Bank"] = rowDict["Bank"];
            }
            // 品牌
            if (rowDict.ContainsKey("BrandName"))
            {
                rowData["BrandName"] = rowDict["BrandName"];
            }
            // 监管员
            if (rowDict.ContainsKey("SupervisorName"))
            {
                rowData["SupervisorName"] = rowDict["SupervisorName"];
            }
            // 监管模式
            if (rowDict.ContainsKey("Model"))
            {
                rowData["Model"] = rowDict["Model"];
            }
            // 库存
            if (rowDict.ContainsKey("Inventory"))
            {
                rowData["Inventory"] = rowDict["Inventory"];
            }
            // 总部总账
            if (rowDict.ContainsKey("QuartersLedger"))
            {
                rowData["QuartersLedger"] = rowDict["QuartersLedger"];
            }
            //总账是否正常
            if (rowDict.ContainsKey("QuartersLedgerStatu"))
            {
                if (rowDict["QuartersLedgerStatu"].Equals("True"))
                {
                    rowData["QuartersLedgerStatu"] = 1;          //1为选择 0相反
                }
                else
                {
                    rowData["QuartersLedgerStatu"] = 0;
                }

            }
            else
            {
                rowData["QuartersLedgerStatu"] = 0;
            }
            // 主要问题
            if (rowDict.ContainsKey("MainProblem"))
            {
                rowData["MainProblem"] = rowDict["MainProblem"];
            }
            // 主要问题是否正常
            if (rowDict.ContainsKey("MainProblemStatu"))
            {
                if (rowDict["MainProblemStatu"].Equals("True"))
                {
                    rowData["MainProblemStatu"] = 1;          //1为选择 0相反
                }
                else
                {
                    rowData["MainProblemStatu"] = 0;
                }
            }
            else
            {
                rowData["MainProblemStatu"] = 0;
            }
            // 历史检查时间
            if (rowDict.ContainsKey("HistoryDate"))
            {
                rowData["HistoryDate"] = rowDict["HistoryDate"];
            }
            // 是否持续追踪
            if (rowDict.ContainsKey("ContinueStatu"))
            {
                if (rowDict["ContinueStatu"].Equals("True"))
                {
                    rowData["ContinueStatu"] = 1;          //1为选择 0相反
                }
                else
                {
                    rowData["ContinueStatu"] = 0;
                }
            }
            else
            {
                rowData["ContinueStatu"] = 0;
            }
            // 备注
            if (rowDict.ContainsKey("Remark"))
            {
                rowData["Remark"] = rowDict["Remark"];
            }
            // 是否正常
            if (rowDict.ContainsKey("IsConform"))
            {
                if (rowDict["IsConform"].Equals("True"))
                {
                    rowData["IsConform"] = 1;          //1为选择 0相反
                }
                else
                {
                    rowData["IsConform"] = 0;
                }
            }
            else
            {
                rowData["IsConform"] = 0;
            }
        }
        #endregion
        #region 更新或修改视频检查表数据源
        /// <summary>
        /// 更新或修改视频检查表数据源 张繁 2013年8月13日
        /// </summary>
        private void UpdateAndAddDayTabel()
        {
            //修改现有数据
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_DayTabel.GetModifiedDict();
            for (int i = 0, count = G_DayTabel.Rows.Count; i < count; i++)
            {
                if (modifiedDict.ContainsKey(i))
                {
                    Dictionary<string, string> rowDict = modifiedDict[i];

                    DataTable table = GetSourceDataDay();
                    DataRow rowData = table.Rows[i];
                    //更新数据源
                    UpdateDataRowDay(rowDict, rowData);

                }
            }
            //新增数据
            List<Dictionary<string, string>> newlist = G_DayTabel.GetNewAddedList();
            for (int i = 0; i < newlist.Count; i++)
            {
                //更新数据源，其实为创建新的DateTable
                DataTable table = GetSourceDataDay();
                DataRow rowData = table.NewRow();
                //更新数据源
                UpdateDataRowDay(newlist[i], rowData);

                //table.Rows.InsertAt(rowData, 0);
                table.Rows.Add(rowData);
            }
        }
        #endregion
        #region 添加数据 旧版本 张繁 2013年12月4日
        /// <summary>
        /// 添加事件 张繁 2013年8月13日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_Day_Click_1(object sender, EventArgs e)
        {
            UpdateAndAddDayTabel();

            G_DayTabel.DataSource = GetSourceDataDay();
            G_DayTabel.DataBind();

            if (this.G_DayTabel.Rows.Count == 0)
            {
                FineUI.Alert.Show("请填写信息", FineUI.MessageBoxIcon.Error);
            }
            else
            {
                string UserName = CurrentUser.TrueName;
                string UserId = CurrentUser.UserId.ToString();
                string sql = "insert into tb_Inspection (Area,Rummager,DealerName,Bank,BrandName,SupervisorName,Model,Inventory,QuartersLedger,MainProblem,Remark,CreateTime,CreateId,isDel) ";
                for (int i = 0; i < this.G_DayTabel.Rows.Count; i++)
                {
                    string[] values = this.G_DayTabel.Rows[i].Values;
                    sql += "select '" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "','" + values[5] + "','" + values[6] + "','" + values[7] + "','" + values[8] + "','" + values[9] + "','" + values[10] + "','" + DateTime.Now + "','" + UserId + "','0' union all ";
                }
                sql = sql.Remove(sql.LastIndexOf("union all")); //移除最后一个union all
                int number = new Citic.BLL.Inspection().ExecuteSql(sql);
                if (number > 0)
                {
                    FineUI.Alert.Show("添加成功！", MessageBoxIcon.Information);
                }
                else
                {
                    FineUI.Alert.Show("添加失败！", MessageBoxIcon.Error);
                }


            }
        }
        #endregion
        #region 清空Gird
        /// <summary>
        /// 清空Gird 张繁 2013年8月23日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Band_DayClick(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.ToString());
        }
        #endregion
        #region 按钮添加事件 张繁 2013年12月4日
        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_Day_Click(object sender, EventArgs e)
        {
            if (G_DayTabel.Rows.Count != 0)
            {
                string ErrorTxt = string.Empty;    //记录错误信息
                string UserName = CurrentUser.TrueName;         //登录人
                string UserId = CurrentUser.UserId.ToString();      //登录id
                //拼接批量sql
                string sql = "insert into tb_Inspection (Area,Rummager,DealerName,Bank,BrandName,SupervisorName,Model,Inventory,QuartersLedger,QuartersLedgerStatu,MainProblem,MainProblemStatu,HistoryDate,ContinueStatu,Remark,IsConform,CreateId,CreateTime,isDel)";
                for (int i = 0; i < this.G_DayTabel.Rows.Count; i++)
                {
                    string[] listStr = this.G_DayTabel.Rows[i].Values;
                    string Area = listStr[0].ToString().Trim();     //区域中心
                    if (Area.Length == 0)
                    {
                        ErrorTxt = "第" + (i + 1) + "行，请选择区域中心！";
                        break;
                    }
                    //string Rummager = dt.Rows[i]["Rummager"].ToString().T rim(); //检查人员
                    string DealerName = listStr[1].ToString().Trim();   //经销店名称
                    string Bank = listStr[2].ToString().Trim();         //合作银行
                    string BrandName = listStr[3].ToString().Trim();        //品牌
                    string SupervisorName = listStr[4].ToString().Trim();   //监管员
                    string Model = listStr[5].ToString().Trim();             //监管模式
                    string Inventory = listStr[6].ToString().Trim();         //库存
                    string QuartersLedger = listStr[7].ToString().Trim();       //总部总账
                    string QuartersLedgerStatu = listStr[8].ToString().Trim() == "True" ? "1" : "0";      //总账状态
                    string MainProblem = listStr[9].ToString().Trim();          //主要问题
                    string MainProblemStatu = listStr[10].ToString().Trim() == "True" ? "1" : "0";     //主要问题状态
                    string HistoryDate = listStr[11].ToString().Trim() == "" ? "NULL" : "'" + listStr[11].ToString().Trim() + "'";         //历史检查时间
                    string ContinueStatu = listStr[12].ToString().Trim() == "Ture" ? "1" : "0";        //持续状态
                    string Remark = listStr[13].ToString().Trim();         //备注
                    string IsConform = listStr[14].ToString().Trim() == "True" ? "1" : "0";       //是否正常

                    sql += "select '" + Area + "','" + UserName + "','" + DealerName + "','" + Bank + "','" + BrandName + "','" + SupervisorName + "','" + Model + "','" + Inventory + "','" + QuartersLedger + "','" + QuartersLedgerStatu + "','" + MainProblem + "','" + MainProblemStatu + "'," + HistoryDate + ",'" + ContinueStatu + "','" + Remark + "','" + IsConform + "','" + UserId + "',GETDATE(),'0' union all ";
                }
                if (ErrorTxt.Length == 0)
                {
                    sql = sql.Remove(sql.LastIndexOf("union all")); //移除最后一个union all
                    int number = new Citic.BLL.InspectionDay().ExecuteSql(sql);
                    if (number > 0)
                    {
                        FineUI.Alert.ShowInTop("添加成功", MessageBoxIcon.Information);
                        ViewState.Remove("Day");
                        this.G_DayTabel.DataSource = GetEmptyDataTableDay();
                        this.G_DayTabel.DataBind();

                    }
                    else
                    {
                        FineUI.Alert.Show("添加失败！", MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.Show(ErrorTxt, MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.Show("请填写数据！", FineUI.MessageBoxIcon.Error);
            }

        }
        #endregion

        protected void G_DayTabel_AfterEdit(object sender, GridAfterEditEventArgs e)
        {
            //修改现有数据
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_DayTabel.GetModifiedDict();
            for (int i = 0, count = G_DayTabel.Rows.Count; i < count; i++)
            {
                if (modifiedDict.ContainsKey(i))
                {
                    Dictionary<string, string> rowDict = modifiedDict[i];

                    DataTable table = GetSourceDataDay();
                    DataRow rowData = table.Rows[i];
                    //更新数据源
                    UpdateDataRowDay(rowDict, rowData);

                }
            }
            //新增数据
            List<Dictionary<string, string>> newlist = G_DayTabel.GetNewAddedList();
            for (int i = 0; i < newlist.Count; i++)
            {
                if (newlist[i]["Area"].Length != 0)
                {
                    //更新数据源，其实为创建新的DateTable
                    DataTable table = GetSourceDataDay();
                    DataRow rowData = table.NewRow();
                    //newlist[i]["Bank"] = "测试";
                    //newlist[i]["BrandName"] = "测试";
                    //newlist[i]["SupervisorName"] = "测试";
                    //newlist[i]["Model"] = "测试";
                    //更新数据源
                    UpdateDataRowDay(newlist[i], rowData);

                    //table.Rows.InsertAt(rowData, 0);
                    table.Rows.Add(rowData);
                    this.G_DayTabel.DataSource = GetSourceDataDay();
                    this.G_DayTabel.DataBind();
                }
            }

        }
    }
}