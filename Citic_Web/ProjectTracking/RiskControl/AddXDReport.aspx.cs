using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class AddXDReport : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
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

        #region 加载模版--乔春羽(2013.7.24)
        private string LoadTemplate()
        {
            string path = Server.MapPath("~/Templates/汽车巡店报告模版.html");
            string content = string.Empty;
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("utf-8"));
                content = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
            return content;
        }
        #endregion

        #region 保存生成的报告文件--乔春羽(2013.7.25)
        private bool SaveBuildedFiles(string content, string path)
        {
            bool isFile = true;
            try
            {
                FileStream fs = new FileStream(path, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("utf-8"));
                sw.Write(content);
                sw.Close();
                fs.Close();
            }
            catch
            {
                isFile = false;
            }
            return isFile;
        }
        #endregion

        #region //生成汽车巡店报告模版，创建巡店报告--乔春羽(2013.8.5)
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_Dealer.Text) && this.txt_Dealer.Text.IndexOf('_') > 0)
            {
                Alert.ShowInTop("请选择经销商！");
                return;
            }
            if (this.ddl_Bank.SelectedValue == "-1")
            {
                Alert.ShowInTop("请选择合作行！");
                return;
            }
            string DealerName = this.txt_Dealer.Text.Split('_')[0];
            string DealerID = this.txt_Dealer.Text.Split('_')[1];
            //int id = 0;
            string tempValue = "{DealerName};{Address};{BankNames};{BrandNames};{Hours};{OperationMode};{CheckDate};{CheckTime}";

            DataSet ds = new DataSet();
            if (string.IsNullOrEmpty(this.txt_Dealer.Text))
            {
                Alert.ShowInTop("请填写经销商！");
                return;
            }
            if (this.ddl_Bank.SelectedValue == "-1")
            {
                Alert.ShowInTop("请选择银行！");
                return;
            }

            //与该经销商合作的银行
            ds = Dealer_BankBll.GetDetailList(string.Format("T.DealerID='{0}' and T.BankID='{1}' ", DealerID, ddl_Bank.SelectedValue));
            //替换“模板”中的经销商名
            tempValue = tempValue.Replace("{DealerName}", DealerName);
            //替换“模板”中的银行名
            tempValue = tempValue.Replace("{BankNames}", this.ddl_Bank.SelectedText);
            //Citic.Model.M_XunDianReport Model = new Citic.Model.M_XunDianReport();
            List<int> bankIds = new List<int>();
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    string BrandNames = string.Empty;
                    //string BankNames = string.Empty;
                    //Model.AllSSMoney = 0;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        //Model.Address = row["Address"].ToString();
                        //替换“模板”中的地址
                        tempValue = tempValue.Replace("{Address}", row["Address"].ToString());
                        //累加总的实收费用
                        //Model.AllSSMoney += Convert.ToInt32(row["SSMoney"]);

                        //if (string.IsNullOrEmpty(Model.BankName))
                        //{
                        //    Model.BankID = Convert.ToInt32(row["BankID"]);
                        //    Model.BankName = row["BankName"].ToString();
                        //}
                        //if (string.IsNullOrEmpty(Model.DealerName))
                        //{
                        //    Model.DealerID = Convert.ToInt32(row["DealerID"]);
                        //    Model.DealerName = row["DealerName"].ToString();
                        //}

                        //统计合作行数量
                        if (!bankIds.Contains(Convert.ToInt32(row["BankID"])))
                        {
                            bankIds.Add(Convert.ToInt32(row["BankID"]));
                        }
                        //累加合作的品牌
                        //Model.BrandIDs += row["BrandID"].ToString() + ",";
                        BrandNames += row["BrandName"].ToString() + ",";
                        //Model.DealerType = row["DealerType"].ToString();
                        //Model.DispatchTime = row["SupervisorDispatchTime"] is DBNull ? DateTime.Now : Convert.ToDateTime(row["SupervisorDispatchTime"]);
                        //Model.IsGroup = Convert.ToBoolean(row["IsGroup"]) ? "是" : "否";
                        //Model.IsSingleStore = Convert.ToBoolean(row["IsSingleStore"]) ? "是" : "否";

                    }
                    //显示的“合作行的数量”
                    //Model.Banks = bankIds.Count;
                    //Model.BrandName = Model.BrandName.Substring(0, Model.BrandName.LastIndexOf(','));
                    tempValue = tempValue.Replace("{BrandNames}", BrandNames.Substring(0, BrandNames.LastIndexOf(',')));
                    //Model.BrandIDs = Model.BrandIDs.Substring(0, Model.BrandIDs.LastIndexOf(','));
                    //if (Model.DealerType.Contains("1"))
                    //{
                    //    Model.DealerType = Model.DealerType.Replace("1", "民营");
                    //}
                    //if (Model.DealerType.Contains("2"))
                    //{
                    //    Model.DealerType = Model.DealerType.Replace("2", "国营");
                    //}
                    //if (Model.DealerType.Contains("3"))
                    //{
                    //    Model.DealerType = Model.DealerType.Replace("3", "集团");
                    //}
                    //if (Model.DealerType.Contains("4"))
                    //{
                    //    Model.DealerType = Model.DealerType.Replace("4", "单店");
                    //}

                    //添加数据
                    //id = XDReportBll.Add(new Citic.Model.DealerXDReports()
                    //{
                    //    DealerID = Model.DealerID,
                    //    DealerName = Model.DealerName,
                    //    BankID = Model.BankID.ToString(),
                    //    Address = Model.Address,
                    //    BankName = Model.BankName,
                    //    BrandID = Model.BrandIDs,
                    //    BrandName = Model.BrandName,
                    //    DispatchTime = Model.DispatchTime,
                    //    FinBankCount = Model.Banks,
                    //    FinBankMoney = Model.AllSSMoney
                    //});
                    //Model.ID = id;
                    //Session.Add("XDBG", Model);
                    //if (Session["XDBG"] != null)
                    //{
                    //    Window1.IFrameUrl = "~/ProjectTracking/RiskControl/XDBG.aspx";
                    //    Window1.Hidden = false;
                    //}
                }
            }
            tempValue = tempValue.Replace("{Hours}", string.Empty);
            tempValue = tempValue.Replace("{OperationMode}", string.Empty);
            tempValue = tempValue.Replace("{CheckDate}", string.Empty);
            tempValue = tempValue.Replace("{CheckTime}", string.Empty);


            Window1.IFrameUrl = "~/Office/LoadOffice.aspx?type=X_D_B_G&_d_n=" + Server.UrlEncode(DealerName) + "&t_v=" + Server.UrlEncode(tempValue) + "&_time=" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Window1.Hidden = false;
        }

        private string TemplateReplace(string source, Citic.Model.M_XunDianReport model)
        {
            string content = string.Empty;
            content = source.Replace("{Address}", model.Address);
            content = content.Replace("{AllSSMoney}", model.AllSSMoney.ToString());
            content = content.Replace("{BankNames}", model.BankName);
            content = content.Replace("{DealerName}", model.DealerName);
            content = content.Replace("{Title_DealerName}", model.DealerName);
            content = content.Replace("{Banks}", model.Banks.ToString());
            content = content.Replace("{BrandNames}", model.BrandName);
            content = content.Replace("{DealerType}", model.DealerType);
            content = content.Replace("{DispatchTime}", model.DispatchTime.ToShortDateString());
            content = content.Replace("{IsGroup}", model.IsGroup);
            content = content.Replace("{IsSingleStore}", model.IsSingleStore);
            return content;
        }
        #endregion

        #region 绑定数据--乔春羽(2013.8.5)
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            //where条件
            //string where = ConditionInit();

            ////设置表格的总数据量
            //this.grid_List.RecordCount = GetCountBySearch(where);

            //if (this.grid_List.PageCount < this.grid_List.PageIndex)
            //{
            //    this.grid_List.PageIndex = 1;
            //}

            //int pageIndex = grid_List.PageIndex;
            //int pageSize = grid_List.PageSize;
            //int rowbegin = pageIndex * pageSize + 1;
            //int rowend = (pageIndex + 1) * pageSize;
            //DataTable dt = XDReportBll.GetListByPage(where, "CheckDate DESC", rowbegin, rowend, "ID", "DealerName", "BankName", "CheckInTime", "CheckDate2", "Checkman").Tables[0];
            string dealerName = this.txt_Dealer.Text.Split('_')[0];
            string dateDir = DateTime.Now.ToString("yyyy_MM_dd");

            DirectoryInfo di = new DirectoryInfo(Server.MapPath(string.Format("~/Office/{0}/{1}/{2}", this.CurrentUser.UserName, dealerName, dateDir)));
            if (di.Exists)
            {
                FileInfo[] fis = di.GetFiles();
                foreach (FileInfo fi in fis)
                {
                    DataRow row = Dt_Source.NewRow();
                    row["FileName"] = fi.Name;
                    row["FullName"] = fi.FullName;
                    Dt_Source.Rows.Add(row);
                }

                grid_List.DataSource = Dt_Source;
                grid_List.DataBind();
            }
        }


        /// <summary>
        /// 获得查询后结果的总数据数量
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return XDReportBll.GetRecordCount(where);
        }
        /// <summary>
        /// 得到查询条件
        /// </summary>
        private string ConditionInit()
        {
            return string.Empty;
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
                    string fileName = grid_List.DataKeys[e.RowIndex][0].ToString();
                    WindowEdit.IFrameUrl = "~/Office/LoadOffice.aspx?type=M_XDBG&_name=" + Server.UrlEncode(fileName) + "&_d_n=" + Server.UrlEncode(this.txt_Dealer.Text.Split('_')[0]) + "&_time=" + DateTime.Now.ToString("yyyyMMddHHmmss");
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
            GridBind();
        }
        #endregion

        #region 选择经销商之后，加载银行--乔春羽(2013.12.4)
        protected void txt_Dealer_TextChanged(object sender, EventArgs e)
        {
            BankDataBind();
        }
        #endregion

        #region 加载银行--乔春羽(2013.12.4)
        private void BankDataBind()
        {
            ddl_Bank.Items.Clear();
            string val = this.txt_Dealer.Text;
            if (!string.IsNullOrEmpty(val))
            {
                if (val.IndexOf('_') >= 0)
                {
                    DataTable dt = Dealer_BankBll.GetList(string.Format(" DealerID='{0}'", val.Split('_')[1])).Tables[0];

                    this.ddl_Bank.DataTextField = "BankName";
                    this.ddl_Bank.DataValueField = "BankID";
                    this.ddl_Bank.DataSource = dt;
                    this.ddl_Bank.DataBind();
                }
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

    }
}