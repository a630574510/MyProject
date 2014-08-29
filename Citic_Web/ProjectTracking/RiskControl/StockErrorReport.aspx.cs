using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Configuration;
using System.IO;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class StockErrorReport : BasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            //动态加载状态列
            DynamicColumnLoad();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        #region 动态加载状态列--乔春羽(2013.8.15)
        /// <summary>
        /// 动态加载状态列
        /// </summary>
        private void DynamicColumnLoad()
        {
            string[] eos = GetErrorOther();
            FineUI.BoundField bf;
            if (eos != null && eos.Length > 0)
            {
                foreach (string str in eos)
                {
                    string[] val = str.Split('_');
                    bf = new FineUI.BoundField();
                    bf.DataField = val[1];
                    bf.DataFormatString = "{0}";
                    bf.HeaderText = val[0];
                    bf.ColumnID = val[1];
                    bf.Width = Unit.Pixel(70);
                    grid_List.Columns.Add(bf);
                }
            }
            bf = new FineUI.BoundField();
            bf.HeaderText = "与上一工作日异常对比";
            bf.DataField = "Compare";
            bf.DataFormatString = "{0}";
            bf.Width = Unit.Pixel(100);
            grid_List.Columns.Add(bf);
        }
        /// <summary>
        /// 获得日查库异常状态
        /// </summary>
        private string[] GetErrorOther()
        {
            string filePath = ConfigurationManager.AppSettings["eoc_path"].ToString();
            List<string> strs = new List<string>();
            if (!string.IsNullOrEmpty(filePath))
            {
                FileStream fs = new FileStream(Server.MapPath(filePath), FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    strs.Add(sr.ReadLine());
                }
                sr.Close();
                fs.Close();
            }
            return strs.ToArray();
        }
        #endregion

        #region 绑定数据--乔春羽(2013.8.7)
        private void GridBind()
        {
            //where条件
            string where = ConditionInit();

            string path = ConfigurationManager.AppSettings["Dealer_Bank"].ToString();
            string commandStr = ConfigurationManager.AppSettings["cec"].ToString();
            //设置表格的总数据量
            this.grid_List.RecordCount = GetRecordCount(where);

            if (this.grid_List.PageCount < this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 1;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = StockErrorBll.StockErrorReportSearch(Server.MapPath(path), commandStr, where, rowbegin, rowend).Tables[0];

            grid_List.DataSource = dt;
            grid_List.DataBind();

            //显示总计信息
            OutputSummaryData(dt);
        }

        /// <summary>
        /// 得到查询条件
        /// </summary>
        /// <returns></returns>
        private string ConditionInit()
        {
            StringBuilder sbuilder = new StringBuilder(" 1=1");

            return sbuilder.ToString();
        }

        /// <summary>
        /// 获得记录总数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetRecordCount(string where)
        {
            return StockErrorBll.GetRecordCount(where);
        }
        #endregion

        #region 显示统计信息--乔春羽(2013.8.15)
        /// <summary>
        /// 显示统计信息
        /// </summary>
        /// <param name="source"></param>
        private void OutputSummaryData(DataTable source)
        {
            //获得异常情况
            string[] eos = GetErrorOther();
            Dictionary<string, float> results = new Dictionary<string, float>();
            //建立要存统计值的集合
            foreach (string str in eos)
            {
                string[] val = str.Split('_');
                results.Add(val[1], 0F);
            }
            //统计统计值
            foreach (DataRow row in source.Rows)
            {
                foreach (string key in eos)
                {
                    string str = key.Split('_')[1];
                    if (source.Columns.Contains(str))
                    {
                        results[str] += Convert.ToInt32(row[str]);
                    }
                }
            }
            JObject jo = new JObject();
            foreach (string str in results.Keys)
            {
                jo.Add(str, results[str]);
            }
            hf_GridSummary.Text = jo.ToString(Newtonsoft.Json.Formatting.None);
        }
        #endregion

        #region 翻页事件--乔春羽(2013.8.7)
        /// <summary>
        /// 翻页事件
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

        #region 查询数据--乔春羽(2013.8.7)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion
    }
}