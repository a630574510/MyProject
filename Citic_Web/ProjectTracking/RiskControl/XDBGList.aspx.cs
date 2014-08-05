using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Text;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class XDBGList : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.dp_Time.SelectedDate = DateTime.Now.AddDays(-1);
                this.dp_End.SelectedDate = DateTime.Now;
                btn_Modify.OnClientClick = grid_List.GetNoSelectionAlertInTopReference("未选择数据！");
                BankDataBind();
                AreaDataBind();
            }
        }

        #region PrivateFields--乔春羽
        private Citic.BLL.DealerXDReports _XDReportBll = null;

        public Citic.BLL.DealerXDReports XDReportBll
        {
            get
            {
                if (_XDReportBll == null)
                {
                    _XDReportBll = new Citic.BLL.DealerXDReports();
                }
                return _XDReportBll;
            }
        }

        private DataTable dt_Source;

        public DataTable Dt_Source
        {
            get
            {
                if (dt_Source == null)
                {
                    dt_Source = new DataTable();
                    DataColumn dc = new DataColumn("FileName", typeof(string));
                    DataColumn dc1 = new DataColumn("FullName", typeof(string));
                    dt_Source.Columns.Add(dc);
                    dt_Source.Columns.Add(dc1);
                }
                return dt_Source;
            }
        }
        #endregion

        #region 绑定数据--乔春羽(2013.8.5)
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            string where = ConditionInit();

            //指定总记录数
            grid_List.RecordCount = GetCountBySearch(where);

            if (this.grid_List.PageCount < this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            DataTable dt = XDBGBBLL.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

            grid_List.DataSource = dt;
            grid_List.DataBind();
        }


        /// <summary>
        /// 获得查询后结果的总数据数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return XDBGBBLL.GetRecordCount(where);
        }
        /// <summary>
        /// 得到查询条件
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder(" 1=1 ");
            if (!string.IsNullOrEmpty(this.txt_Dealer.Text) && this.txt_Dealer.Text.IndexOf('_') > 0)
            {
                where.AppendFormat(" and DealerID={0}", this.txt_Dealer.Text.Split('_')[1]);
            }
            if (!this.ddl_Bank.SelectedValue.Equals("-1"))
            {
                where.AppendFormat(" and BankID={0}", this.ddl_Bank.SelectedValue);
            }
            if (!this.ddl_Area.SelectedValue.Equals("-1"))
            {
                where.AppendFormat(" and Area = '{0}'", this.ddl_Area.SelectedValue);
            }
            if (this.dp_Time.SelectedDate.HasValue)
            {
                if (this.dp_End.SelectedDate.HasValue)
                {
                    where.AppendFormat(" and (InspectTime between '{0}' and '{1}') ", this.dp_Time.SelectedDate.Value, this.dp_End.SelectedDate.Value.AddDays(1));
                }
                else
                {
                    where.AppendFormat(" and InspectTime >= '{0}' ", this.dp_Time.SelectedDate.Value);
                }
            }
            else
            {
                if (this.dp_End.SelectedDate.HasValue)
                {
                    where.AppendFormat(" and InspectTime <= '{0}' ", this.dp_End.SelectedDate.Value.AddDays(1));
                }
            }

            return where.ToString();
        }
        #endregion

        #region 每页显示数量改变事件--乔春羽(2013.8.5)
        /// <summary>
        /// 每页显示数量改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_List.PageSize = int.Parse(ddlPageSize.SelectedValue);
            GridBind();
        }
        #endregion

        #region 翻页事件--乔春羽(2013.8.5)
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

        #region 行命令事件--乔春羽(2013.8.5)
        protected void grid_List_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.RowIndex >= 0 && !string.IsNullOrEmpty(e.CommandName))
            {
                if (e.CommandName == "modify")
                {
                    string fileName = grid_List.DataKeys[e.RowIndex][1].ToString();
                    WindowEdit.IFrameUrl = "~/ProjectTracking/RiskControl/ShowXDBG.aspx?type=M_XDBG&_name=" + Server.UrlEncode(fileName) + "&_time=" + ConvertLongDateTimeToUI(DateTime.Now);
                    WindowEdit.Hidden = false;
                }
            }
        }
        #endregion

        #region 关闭“创建巡店报告”窗口--乔春羽(2013.8.5)
        protected void Window1_Close(object sender, WindowCloseEventArgs e)
        {
            Session["XDBG"] = null;
            Session["_time"] = null;
            Session["newFilePath"] = null;
        }
        #endregion

        #region 查询巡店报告--乔春羽(2013.11.21)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_Dealer.Text))
            {
                Alert.ShowInTop("请填写经销商！");
                return;
            }
            if (this.dp_Time.SelectedDate == null)
            {
                Alert.ShowInTop("请选择日期！");
                return;
            }
            GridBind();
        }
        #endregion

        #region 加载银行信息--乔春羽(2013.12.25)
        public void BankDataBind()
        {
            ddl_Bank.Items.Clear();
            if (!string.IsNullOrEmpty(this.txt_Dealer.Text))
            {
                string dealerID = this.txt_Dealer.Text.Split('_')[1];
                string where = string.Format(" DealerID='{0}'", dealerID);
                DataTable dt = Dealer_BankBll.GetList(where).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddl_Bank.DataTextField = "BankName";
                    ddl_Bank.DataValueField = "BankID";
                    ddl_Bank.DataSource = dt;
                    ddl_Bank.DataBind();
                }
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 选择经销商，联动出合作行--乔春羽(2013.12.25)
        protected void txt_Dealer_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txt_Dealer.Text) && this.txt_Dealer.Text.IndexOf('_') > 0)
            {
                //查询经销商
                BankDataBind();
            }
        }
        #endregion

        #region 加载部门--乔春羽(2013.12.25)
        public void AreaDataBind()
        {
            ddl_Area.Items.Clear();
            string path = "~/ProjectTracking/RiskControl/区域名称.txt";
            FileStream fs = new FileStream(Server.MapPath(path), FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string value = sr.ReadLine();
                AddItemByInsert(ddl_Area, value, value, -1);
            }
            sr.Close();
            fs.Close();
            AddItemByInsert(ddl_Area, "请选择", "-1", 0);
            ddl_Area.SelectedIndex = 0;
        }
        #endregion

        #region 修改文件--乔春羽(2013.12.26)
        protected void btn_Modify_Click(object sender, EventArgs e)
        {
            string fileName = grid_List.DataKeys[grid_List.SelectedRowIndex][1].ToString();
            string id = grid_List.DataKeys[grid_List.SelectedRowIndex][0].ToString();
            if (!string.IsNullOrEmpty(fileName))
            {
                WindowEdit.IFrameUrl = "~/ProjectTracking/RiskControl/ShowXDBG.aspx?type=M_XDBG&_name=" + Server.UrlEncode(fileName) + "&_id=" + id + "&_time=" + ConvertLongDateTimeToUI(DateTime.Now);
                WindowEdit.Hidden = false;
            }
        }
        #endregion
    }
}