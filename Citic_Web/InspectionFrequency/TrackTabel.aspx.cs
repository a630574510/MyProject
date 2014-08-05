using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Data;
using Citic.BLL;
using FineUI;
using System.Data.SqlClient;
namespace Citic_Web.InspectionFrequency
{
    public partial class TrackTabel : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load();
            }
        }
        #region 添加年月日视频检查行
        /// <summary>
        /// 添加Grid行
        /// 张繁 2013年7月29日
        /// </summary>
        private string YTDTraceTab()
        {
            string GridRowsStr = string.Empty;
            JObject o = new JObject();
            o.Add("YTDTrace_Area", "");             //区域中心
            o.Add("YTDTrace_DealerName", "");       //经销店名称
            o.Add("YTDTrace_Bank", "");             //合作银行
            o.Add("YTDTrace_BrandName", "");        //品牌
            o.Add("YTDTrace_SupervisorName", "");   //监管员
            o.Add("YTDTrace_CheckProblem", "");     //检查问题
            o.Add("YTDTrace_FinancialCenter", "");  //汽车金融中心处理结果
            o.Add("YTDTrace_RiskControl", "");      //风控部处理结果
            o.Add("YTDTrace_AdminDepartment", "");  //行政部处理结果
            return GridRowsStr = G_YTDTraceTab.GetAddNewRecordReference(o, true);

        }
        #endregion

        #region 添加总部总账行
        /// <summary>
        /// 添加Grid行
        /// 张繁 2013年7月29日
        /// </summary>
        private string Quarters_Ledger()
        {
            string GridRowsStr = string.Empty;
            JObject o = new JObject();
            o.Add("QuartersLedger_DealerName", "");       //经销店名称
            o.Add("QuartersLedger_Bank", "");               //合作银行
            o.Add("QuartersLedger_BrandName", "");          //品牌
            o.Add("QuartersLedger_System", "");             //总部总账问题(系统、电子总账）
            o.Add("QuartersLedger_FinancialCenter", "");    //汽车金融中心处理结果

            return GridRowsStr = G_Quarters_Ledger.GetAddNewRecordReference(o, true);

        }
        #endregion

        #region 添加持续追踪行
        /// <summary>
        /// 添加Grid行
        /// 张繁 2013年7月29日
        /// </summary>
        private string ContinuousTracking()
        {
            string GridRowsStr = string.Empty;
            JObject o = new JObject();
            o.Add("ContinuousTracking_DealerName", "");     //经销店名称
            o.Add("ContinuousTracking_Bank", "");           //合作银行
            o.Add("ContinuousTracking_BrandName", "");      //品牌
            o.Add("ContinuousTracking_SupervisorName", ""); //监管员
            o.Add("ContinuousTracking_CheckProblem", "");   //检查问题
            o.Add("ContinuousTracking_HistoryTime", DateTime.Now);    //历史检查时间
            o.Add("ContinuousTracking_FinancialCenter", "");//汽车金融中心处理结果
            return GridRowsStr = G_ContinuousTracking.GetAddNewRecordReference(o, true);

        }
        #endregion

        #region 首次加载事件
        /// <summary>
        /// 加载控制显示  
        /// 张繁 2013年7月29日
        /// </summary>
        private void Load()
        {

            ViewState.Clear();
            this.btn_G_YTDTraceTab.OnClientClick = YTDTraceTab();           //追踪表添加表格
            this.G_YTDTraceTab.Title = DateTime.Now.ToLongDateString().ToString() + "视频检查追踪";
            this.btn_G_Quarters_Ledger.OnClientClick = Quarters_Ledger();       //总部总账添加表格
            this.btn_G_ContinuousTracking.OnClientClick = ContinuousTracking(); //持续追踪添加表格
        }
        #endregion

        #region 追踪表 2013年8月6日
        #region 追踪表添加
        /// <summary>
        /// 追踪表添加事件 张繁 2013年8月6日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Add_YTDTrace_Click(object sender, EventArgs e)
        {
            UpdateAndAddYTDTrace();
            this.G_YTDTraceTab.DataSource = GetSourceDataYTDTrace();
            this.G_YTDTraceTab.DataBind();
            if (this.G_YTDTraceTab.Rows.Count == 0)
            {
                FineUI.Alert.Show("请填写信息", FineUI.MessageBoxIcon.Error);
            }
            else
            {
                string UserName = CurrentUser.TrueName;
                string UserId = CurrentUser.UserId.ToString();
                string sql = "insert into tb_InspectionFrequency (Area,DealerName,Bank,BrandName,SupervisorName,CheckProblem,CreateName,CreateId,CreateTime,IsDel,Statu)";
                for (int i = 0; i < this.G_YTDTraceTab.Rows.Count; i++)
                {
                    sql += "select '" + this.G_YTDTraceTab.Rows[i].Values[0] + "','" + this.G_YTDTraceTab.Rows[i].Values[1] + "','" + this.G_YTDTraceTab.Rows[i].Values[2] + "','" + this.G_YTDTraceTab.Rows[i].Values[3] + "','" + this.G_YTDTraceTab.Rows[i].Values[4] + "','" + this.G_YTDTraceTab.Rows[i].Values[5] + "','" + UserName + "','"+UserId+"','" + DateTime.Now.ToString() + "','0','1' union all  ";
                }
                sql = sql.Remove(sql.LastIndexOf("union all")); //移除最后一个union all
                int number = new Citic.BLL.InspectionFrequency().ExecuteSql(sql);
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
        /// 清空Gird数据 张繁 2013年8月23日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Band_YTDTrace_Click(object sender, EventArgs e)
        {
            //准备添加数据的时候应先更新-相当于把ViewState数据重新修改一下，后绑定
            ViewState.Remove("YTDTrace");

            G_YTDTraceTab.DataSource = GetSourceDataYTDTrace();
            G_YTDTraceTab.DataBind();
        }
        #endregion
        #region 追踪表更新数据源
        /// <summary>
        /// 追踪表更新数据源 张繁 2013年8月6日
        /// </summary>
        /// <param name="rowDict"></param>
        /// <param name="rowData"></param>
        private static void UpdateDataRowYTDTrace(Dictionary<string, string> rowDict, DataRow rowData)
        {
            // 检查区域
            if (rowDict.ContainsKey("YTDTrace_Area"))
            {
                rowData["YTDTrace_Area"] = rowDict["YTDTrace_Area"];
            }
            // 经销店名称
            if (rowDict.ContainsKey("YTDTrace_DealerName"))
            {
                rowData["YTDTrace_DealerName"] = rowDict["YTDTrace_DealerName"];
            }
            // 合作银行
            if (rowDict.ContainsKey("YTDTrace_Bank"))
            {
                rowData["YTDTrace_Bank"] = rowDict["YTDTrace_Bank"];
            }
            // 品牌
            if (rowDict.ContainsKey("YTDTrace_BrandName"))
            {
                rowData["YTDTrace_BrandName"] = rowDict["YTDTrace_BrandName"];
            }
            // 监管员
            if (rowDict.ContainsKey("YTDTrace_SupervisorName"))
            {
                rowData["YTDTrace_SupervisorName"] = rowDict["YTDTrace_SupervisorName"];
            }
            // 检查问题
            if (rowDict.ContainsKey("YTDTrace_CheckProblem"))
            {
                rowData["YTDTrace_CheckProblem"] = rowDict["YTDTrace_CheckProblem"];
            }
            // 汽车金融中心处理结果
            if (rowDict.ContainsKey("YTDTrace_FinancialCenter"))
            {
                rowData["YTDTrace_FinancialCenter"] = rowDict["YTDTrace_FinancialCenter"];
            }
            // 风控部处理结果
            if (rowDict.ContainsKey("YTDTrace_RiskControl"))
            {
                rowData["YTDTrace_RiskControl"] = rowDict["YTDTrace_RiskControl"];
            }
            // 行政部处理结果
            if (rowDict.ContainsKey("YTDTrace_AdminDepartment"))
            {
                rowData["YTDTrace_AdminDepartment"] = rowDict["YTDTrace_AdminDepartment"];
            }
            //// 是否有问题
            //if (rowDict.ContainsKey("YTDTrace_AtProblem"))
            //{
            //    rowData["YTDTrace_AtProblem"] = Convert.ToBoolean(rowDict["YTDTrace_AtProblem"]);
            //}
        }
        #endregion
        #region 追踪表ViewState
        /// <summary>
        /// 追踪表当前数据集合是否存在 张繁 2013年8月6日
        /// </summary>
        /// <returns>返回datatabel</returns>
        private DataTable GetSourceDataYTDTrace()
        {
            //判断当前是否存在ViewState
            if (ViewState["YTDTrace"] == null)
            {
                //不存在则创建空的数据源赋给ViewState
                ViewState["YTDTrace"] = GetEmptyDataTableYTDTrace();
            }
            return (DataTable)ViewState["YTDTrace"];
        }
        #endregion
        #region 空追踪表数据源
        /// <summary>
        /// 创建空追踪表 张繁 2013年8月6日
        /// </summary>
        /// <returns></returns>
        private DataTable GetEmptyDataTableYTDTrace()
        {
            //创建table对象
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("YTDTrace_Area", typeof(String))); //检查区域
            table.Columns.Add(new DataColumn("YTDTrace_DealerName", typeof(String)));  //经销店名称
            table.Columns.Add(new DataColumn("YTDTrace_Bank", typeof(String))); //合作银行
            table.Columns.Add(new DataColumn("YTDTrace_BrandName", typeof(String)));  //品牌
            table.Columns.Add(new DataColumn("YTDTrace_SupervisorName", typeof(String)));       //监管员
            table.Columns.Add(new DataColumn("YTDTrace_CheckProblem", typeof(String)));   //检查问题
            table.Columns.Add(new DataColumn("YTDTrace_FinancialCenter", typeof(String)));      //汽车金融中心处理结果
            table.Columns.Add(new DataColumn("YTDTrace_RiskControl", typeof(String)));       //风控部处理结果
            table.Columns.Add(new DataColumn("YTDTrace_AdminDepartment", typeof(String)));        //行政部处理结果
            //table.Columns.Add(new DataColumn("YTDTrace_AtProblem", typeof(bool)));        //是否有问题
            return table;
        }
        #endregion
        #region 删除当前追踪表选择行
        /// <summary>
        /// 删除当前选择行 张繁 2013年8月6日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Del_YTDTrace_Click(object sender, EventArgs e)
        {
            if (G_YTDTraceTab.SelectedCell != null)
            {
                UpdateAndAddYTDTrace();     //更新或修改追踪表数据源

                int rowIndex = G_YTDTraceTab.SelectedCell[0];   //获取当前选择单元格索引
                DataTable dt = GetSourceDataYTDTrace();     //获取数据源
                dt.Rows.RemoveAt(rowIndex);     //移除指定索引行
                G_YTDTraceTab.DataSource = GetSourceDataYTDTrace();
                G_YTDTraceTab.DataBind();

            }
            else
            {
                Alert.ShowInTop("没有选中任何单元格！", MessageBoxIcon.Warning);
            }
        }
        #endregion
        #region 更新或修改追踪表数据源
        /// <summary>
        /// 更新或修改追踪表数据源 张繁 2013年8月6日
        /// </summary>
        private void UpdateAndAddYTDTrace()
        {
            //修改现有数据
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_YTDTraceTab.GetModifiedDict();
            for (int i = 0, count = G_YTDTraceTab.Rows.Count; i < count; i++)
            {
                if (modifiedDict.ContainsKey(i))
                {
                    Dictionary<string, string> rowDict = modifiedDict[i];

                    DataTable table = GetSourceDataYTDTrace();
                    DataRow rowData = table.Rows[i];
                    //更新数据源
                    UpdateDataRowYTDTrace(rowDict, rowData);

                }
            }
            //新增数据
            List<Dictionary<string, string>> newlist = G_YTDTraceTab.GetNewAddedList();
            for (int i = 0; i < newlist.Count; i++)
            {
                //更新数据源，其实为创建新的DateTable
                DataTable table = GetSourceDataYTDTrace();
                DataRow rowData = table.NewRow();
                //更新数据源
                UpdateDataRowYTDTrace(newlist[i], rowData);

                //table.Rows.InsertAt(rowData, 0);
                table.Rows.Add(rowData);
            }
        }
        #endregion

        #endregion

        #region 总部总账 2013年8月6日
        #region 总账表添加
        /// <summary>
        /// 总账表添加事件 张繁 2013年8月6日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_G_Quarters_Ledger_Click(object sender, EventArgs e)
        {
            //准备添加数据的时候应先更新-相当于把ViewState数据重新修改一下，后绑定
            UpdateAndAddQuartersLedger();     //更新或修改追踪表数据源

            G_Quarters_Ledger.DataSource = GetSourceDataQuartersLedger();
            G_Quarters_Ledger.DataBind();

            if (this.G_Quarters_Ledger.Rows.Count == 0)
            {
                FineUI.Alert.Show("请填写信息", FineUI.MessageBoxIcon.Error);
            }
            else
            {
                string UserName = CurrentUser.TrueName;
                string UserId = CurrentUser.UserId.ToString();
                string sql = "insert into tb_InspectionFrequency (Area,DealerName,Bank,BrandName,QuartersLedger,CreateId,CreateTime,IsDel,Statu)";
                for (int i = 0; i < this.G_Quarters_Ledger.Rows.Count; i++)
                {
                    string[] values = this.G_Quarters_Ledger.Rows[i].Values;
                    sql += "select '" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "','" + UserName + "','"+UserId+"','" + DateTime.Now.ToString() + "','0','2' union all ";
                }
                sql = sql.Remove(sql.LastIndexOf("union all")); //移除最后一个union all
                int number = new Citic.BLL.InspectionFrequency().ExecuteSql(sql);
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
        protected void Band_Quarters_Ledger_Click(object sender, EventArgs e)
        {
            ViewState.Remove("QuartersLedger");
            G_Quarters_Ledger.DataSource = GetSourceDataQuartersLedger();
            G_Quarters_Ledger.DataBind();
        }
        #endregion
        #region 总账更新数据源
        /// <summary>
        /// 更新总账数据源 张繁 2013年8月6日
        /// </summary>
        /// <param name="rowDict"></param>
        /// <param name="rowData"></param>
        private static void UpdateDataRowQuartersLedger(Dictionary<string, string> rowDict, DataRow rowData)
        {
            // 检查区域
            if (rowDict.ContainsKey("QuartersLedger_Area"))
            {
                rowData["QuartersLedger_Area"] = rowDict["QuartersLedger_Area"];
            }
            // 经销店名称
            if (rowDict.ContainsKey("QuartersLedger_DealerName"))
            {
                rowData["QuartersLedger_DealerName"] = rowDict["QuartersLedger_DealerName"];
            }
            // 合作银行
            if (rowDict.ContainsKey("QuartersLedger_Bank"))
            {
                rowData["QuartersLedger_Bank"] = rowDict["QuartersLedger_Bank"];
            }
            // 品牌
            if (rowDict.ContainsKey("QuartersLedger_BrandName"))
            {
                rowData["QuartersLedger_BrandName"] = rowDict["QuartersLedger_BrandName"];
            }
            // 总部总账问题
            if (rowDict.ContainsKey("QuartersLedger_System"))
            {
                rowData["QuartersLedger_System"] = rowDict["QuartersLedger_System"];
            }
            // 汽车金融中心处理结果
            if (rowDict.ContainsKey("QuartersLedger_FinancialCenter"))
            {
                rowData["QuartersLedger_FinancialCenter"] = rowDict["QuartersLedger_FinancialCenter"];
            }

        }
        #endregion
        #region 总账ViewState
        /// <summary>
        /// 总账表当前数据集合是否存在 张繁 2013年8月6日
        /// </summary>
        /// <returns>返回datatabel</returns>
        private DataTable GetSourceDataQuartersLedger()
        {
            //判断当前是否存在ViewState
            if (ViewState["QuartersLedger"] == null)
            {
                //不存在则创建空的数据源赋给ViewState
                ViewState["QuartersLedger"] = GetEmptyDataTableQuartersLedger();
            }
            return (DataTable)ViewState["QuartersLedger"];
        }
        #endregion
        #region 空总账表数据源
        /// <summary>
        /// 创建空总账表 张繁 2013年8月6日
        /// </summary>
        /// <returns></returns>
        protected DataTable GetEmptyDataTableQuartersLedger()
        {
            //创建table对象
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("QuartersLedger_Area", typeof(String))); //检查区域
            table.Columns.Add(new DataColumn("QuartersLedger_DealerName", typeof(String)));  //经销店名称
            table.Columns.Add(new DataColumn("QuartersLedger_Bank", typeof(String))); //合作银行
            table.Columns.Add(new DataColumn("QuartersLedger_BrandName", typeof(String)));  //品牌
            table.Columns.Add(new DataColumn("QuartersLedger_System", typeof(String)));       //总部总账问题
            table.Columns.Add(new DataColumn("QuartersLedger_FinancialCenter", typeof(String)));   //汽车金融中心处理结果
            return table;
        }
        #endregion
        #region 删除当前总账表选择行
        /// <summary>
        /// 删除选中单元格索引 张繁 2013年8月6日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Del_G_Quarters_Ledger_Click(object sender, EventArgs e)
        {
            if (G_Quarters_Ledger.SelectedCell != null)
            {
                UpdateAndAddQuartersLedger();     //更新或修改总账表数据源

                int rowIndex = G_Quarters_Ledger.SelectedCell[0];       //获取当前选择单元格索引
                DataTable dt = GetSourceDataQuartersLedger();       //获取数据源
                dt.Rows.RemoveAt(rowIndex);     //移除指定索引行
                G_Quarters_Ledger.DataSource = GetSourceDataQuartersLedger();
                G_Quarters_Ledger.DataBind();

            }
            else
            {
                Alert.ShowInTop("没有选中任何单元格！");
            }
        }
        #endregion
        #region 更新或修改总账表数据源
        /// <summary>
        /// 更新或修改总账表数据源 张繁 2013年8月6日
        /// </summary>
        private void UpdateAndAddQuartersLedger()
        {
            //修改现有数据
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_Quarters_Ledger.GetModifiedDict();
            for (int i = 0, count = G_Quarters_Ledger.Rows.Count; i < count; i++)
            {
                if (modifiedDict.ContainsKey(i))
                {
                    Dictionary<string, string> rowDict = modifiedDict[i];

                    DataTable table = GetSourceDataQuartersLedger();
                    DataRow rowData = table.Rows[i];
                    //更新数据源
                    UpdateDataRowQuartersLedger(rowDict, rowData);

                }
            }
            //新增数据
            List<Dictionary<string, string>> newlist = G_Quarters_Ledger.GetNewAddedList();
            for (int i = 0; i < newlist.Count; i++)
            {
                //更新数据源，其实为创建新的DateTable
                DataTable table = GetSourceDataQuartersLedger();
                DataRow rowData = table.NewRow();
                //更新数据源
                UpdateDataRowQuartersLedger(newlist[i], rowData);

                //table.Rows.InsertAt(rowData, 0);
                table.Rows.Add(rowData);
            }

        }
        #endregion
        #endregion

        #region 持续追踪 2013年8月6日
        #region 持续追踪添加
        /// <summary>
        /// 持续追踪添加事件 张繁 2013年8月6日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Add_G_ContinuousTracking_Click(object sender, EventArgs e)
        {
            //准备添加数据的时候应先更新-相当于把ViewState数据重新修改一下，后绑定
            UpdateAndAddContinuousTracking();     //更新或修改持续追踪表数据源
            G_ContinuousTracking.DataSource = GetSourceDataContinuousTracking();
            G_ContinuousTracking.DataBind();

            if (this.G_ContinuousTracking.Rows.Count == 0)
            {
                FineUI.Alert.Show("请填写信息", FineUI.MessageBoxIcon.Error);
            }
            else
            {
                string UserName=CurrentUser.TrueName;
                string UserId=CurrentUser.UserId.ToString();
                string sql = "insert into tb_InspectionFrequency (Area,DealerName,Bank,BrandName,SupervisorName,CheckProblem,HistoryTime,CreateId,CreateTime,IsDel,Statu)";
                for (int i = 0; i < this.G_ContinuousTracking.Rows.Count; i++)
                {
                    string[] values = this.G_ContinuousTracking.Rows[i].Values;
                    sql += "select '" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] + "','" + values[5] + "','" + values[6] + "','" + UserName + "','" + UserId + "','" + DateTime.Now.ToString() + "','0','3' union all ";
                }
                sql = sql.Remove(sql.LastIndexOf("union all")); //移除最后一个union all
                int number = new Citic.BLL.InspectionFrequency().ExecuteSql(sql);
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
        protected void Band_ContinuousTracking_Click(object sender, EventArgs e)
        {
            ViewState.Remove("ContinuousTracking");
            G_ContinuousTracking.DataSource = GetSourceDataContinuousTracking();
            G_ContinuousTracking.DataBind();
        }
        #endregion
        #region 持续追踪更新数据源
        /// <summary>
        ///  更新持续追踪数据源 张繁 2013年8月6日
        /// </summary>
        /// <param name="rowDict"></param>
        /// <param name="rowData"></param>
        private static void UpdateDataRowContinuousTracking(Dictionary<string, string> rowDict, DataRow rowData)
        {
            // 检查区域
            if (rowDict.ContainsKey("ContinuousTracking_Area"))
            {
                rowData["ContinuousTracking_Area"] = rowDict["ContinuousTracking_Area"];
            }
            // 经销店名称
            if (rowDict.ContainsKey("ContinuousTracking_DealerName"))
            {
                rowData["ContinuousTracking_DealerName"] = rowDict["ContinuousTracking_DealerName"];
            }
            // 合作银行
            if (rowDict.ContainsKey("ContinuousTracking_Bank"))
            {
                rowData["ContinuousTracking_Bank"] = rowDict["ContinuousTracking_Bank"];
            }
            // 品牌
            if (rowDict.ContainsKey("ContinuousTracking_BrandName"))
            {
                rowData["ContinuousTracking_BrandName"] = rowDict["ContinuousTracking_BrandName"];
            }
            // 监管员
            if (rowDict.ContainsKey("ContinuousTracking_SupervisorName"))
            {
                rowData["ContinuousTracking_SupervisorName"] = rowDict["ContinuousTracking_SupervisorName"];
            }
            // 检查问题
            if (rowDict.ContainsKey("ContinuousTracking_CheckProblem"))
            {
                rowData["ContinuousTracking_CheckProblem"] = rowDict["ContinuousTracking_CheckProblem"];
            }
            // 历史检查时间
            if (rowDict.ContainsKey("ContinuousTracking_HistoryTime"))
            {
                if (rowDict["ContinuousTracking_HistoryTime"] == "")
                {
                    //检查等于空，默认为今天
                    rowData["ContinuousTracking_HistoryTime"] = DateTime.Now;
                }
                else
                {
                    rowData["ContinuousTracking_HistoryTime"] = DateTime.Parse(rowDict["ContinuousTracking_HistoryTime"]).ToString("yyyy-MM-dd");
                }

            }
            // 汽车金融中心处理结果
            if (rowDict.ContainsKey("ContinuousTracking_FinancialCenter"))
            {
                rowData["ContinuousTracking_FinancialCenter"] = rowDict["ContinuousTracking_FinancialCenter"];
            }
        }
        #endregion
        #region 持续追踪ViewState
        /// <summary>
        /// 持续追踪表当前数据集合是否存在 张繁 2013年8月6日
        /// </summary>
        /// <returns>返回datatabel</returns>
        private DataTable GetSourceDataContinuousTracking()
        {
            //判断当前是否存在ViewState
            if (ViewState["ContinuousTracking"] == null)
            {
                //不存在则创建空的数据源赋给ViewState
                ViewState["ContinuousTracking"] = GetEmptyDataTableContinuousTracking();
            }
            return (DataTable)ViewState["ContinuousTracking"];
        }
        #endregion
        #region 空持续追踪表数据源
        /// <summary>
        /// 创建空持续追踪表 张繁 2013年8月6日
        /// </summary>
        /// <returns></returns>
        protected DataTable GetEmptyDataTableContinuousTracking()
        {
            //创建table对象
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("ContinuousTracking_Area", typeof(String))); //检查区域
            table.Columns.Add(new DataColumn("ContinuousTracking_DealerName", typeof(String)));  //经销店名称
            table.Columns.Add(new DataColumn("ContinuousTracking_Bank", typeof(String))); //合作银行
            table.Columns.Add(new DataColumn("ContinuousTracking_BrandName", typeof(String)));  //品牌
            table.Columns.Add(new DataColumn("ContinuousTracking_SupervisorName", typeof(String)));       //监管员
            table.Columns.Add(new DataColumn("ContinuousTracking_CheckProblem", typeof(String)));   //检查问题
            table.Columns.Add(new DataColumn("ContinuousTracking_HistoryTime", typeof(DateTime)));   //历史检查时间
            table.Columns.Add(new DataColumn("ContinuousTracking_FinancialCenter", typeof(String)));   //汽车金融中心处理结果
            return table;
        }
        #endregion
        #region 删除当前持续追踪表选择行
        /// <summary>
        /// 删除选中单元格索引 张繁 2013年8月6日
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Del_G_ContinuousTracking_Click(object sender, EventArgs e)
        {
            if (G_ContinuousTracking.SelectedCell != null)
            {
                UpdateAndAddContinuousTracking();     //更新或修改持续追踪表数据源

                int rowIndex = G_ContinuousTracking.SelectedCell[0];     //获取当前选择单元格索引
                DataTable dt = GetSourceDataContinuousTracking();       //获取数据源
                dt.Rows.RemoveAt(rowIndex);     //移除指定索引行
                G_ContinuousTracking.DataSource = GetSourceDataContinuousTracking();
                G_ContinuousTracking.DataBind();

            }
            else
            {
                Alert.ShowInTop("没有选中任何单元格！");
            }
        }
        #endregion
        #region 更新或修改持续追踪表数据源
        /// <summary>
        /// 更新或修改持续追踪表数据源 张繁 2013年8月6日
        /// </summary>
        private void UpdateAndAddContinuousTracking()
        {
            //修改现有数据
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_ContinuousTracking.GetModifiedDict();
            for (int i = 0, count = G_ContinuousTracking.Rows.Count; i < count; i++)
            {
                if (modifiedDict.ContainsKey(i))
                {
                    Dictionary<string, string> rowDict = modifiedDict[i];
                    DataTable table = GetSourceDataContinuousTracking();    //获取数据源
                    DataRow rowData = table.Rows[i];
                    UpdateDataRowContinuousTracking(rowDict, rowData);  //更新数据源

                }
            }
            //新增数据
            List<Dictionary<string, string>> newlist = G_ContinuousTracking.GetNewAddedList();
            for (int i = 0; i < newlist.Count; i++)
            {
                //更新数据源，其实为创建新的DateTable
                DataTable table = GetSourceDataContinuousTracking();
                DataRow rowData = table.NewRow();

                UpdateDataRowContinuousTracking(newlist[i], rowData);

                //table.Rows.InsertAt(rowData, 0);      //添加到第一行
                table.Rows.Add(rowData);
            }

        }
        #endregion
        #endregion
    }
}