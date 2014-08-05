using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
namespace Citic_Web.DealerManagement.DealerInfo
{
    public partial class ChoiseBank : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //清空ViewState中的数据
                ViewState.Clear();
                //显示融资模式
                FinancingModeBind();
                //显示业务模式
                BusinessModeBind();
                //显示厂商列表
                FactoryBind();
                //显示数据
                GridBind();
                //显示之前添加过的品牌信息
                BrandDataBind();

                Citic.Model.Dealer model = Session["model"] as Citic.Model.Dealer;
                if (model != null)
                {
                    DealerName = model.DealerName;
                }

                string dealerIDStr = Request.QueryString["DealerID"];
                if (!string.IsNullOrEmpty(dealerIDStr))
                {
                    ViewState.Add("DealerID", dealerIDStr);
                }

                string bankID = Request.QueryString["_bankid"];
                if (!string.IsNullOrEmpty(bankID) && !string.IsNullOrEmpty(dealerIDStr))
                {
                    this.BankID = int.Parse(bankID);
                    //加载所选择的“经销商合作行信息”
                    DataTable dt = Dealer_BankBll.GetList(string.Format(" DealerID='{0}' and BankID='{1}' ", dealerIDStr, bankID)).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //禁用银行选择功能
                        this.tb_Bank.Enabled = false;
                        this.rbl_Types.Enabled = false;
                        this.grid_List.Enabled = false;

                        #region 显示合作行
                        string bankName = dt.Rows[0]["BankName"].ToString();
                        this.lbl_BankName.Text = bankName;
                        this.lbl_BankName.CssStyle = "font-weight:bold;font-size:18px;color:red";
                        hf_BankID.Text = bankID;

                        if (bankName.Substring(0, 2) == "光大")
                        {
                            this.lbl_BankInterface.Enabled = true;
                            this.cbl_BankInterface.Enabled = true;
                        }
                        else
                        {
                            this.lbl_BankInterface.Enabled = false;
                            this.cbl_BankInterface.Enabled = false;
                            this.cbl_BankInterface.Checked = false;
                        }
                        #endregion

                        #region 显示品牌信息
                        foreach (DataRow row in dt.Rows)
                        {
                            object[] objs = row.ItemArray;
                            object dc_BrandID = objs[5];
                            object dc_ID = string.Empty;
                            object dc_BrandName = objs[6];
                            object dc_BusinessMode = objs[7];
                            object dc_BusinessModeStr = string.Empty;
                            object dc_SSMoney = objs[10];
                            object dc_YSMoney = objs[11];
                            object dc_PaymentCycle = objs[12];
                            object dc_PaymentCycleStr = string.Empty;
                            object dc_FinancingMode = objs[8];
                            object dc_FinancingModeStr = string.Empty;
                            object dc_DispatchTime = objs[13];

                            dc_ID = GetMaxID(Dt_Brand);
                            dc_BusinessModeStr = dc_BusinessMode.ToString() == "1" ? "车证模式" : dc_BusinessMode.ToString() == "2" ? "合格证模式" : dc_BusinessMode.ToString() == "3" ? "巡库模式" : string.Empty;
                            dc_PaymentCycleStr = dc_PaymentCycle.ToString() == "1" ? "月" : dc_PaymentCycle.ToString() == "2" ? "季" : dc_PaymentCycle.ToString() == "3" ? "半年" : dc_PaymentCycle.ToString() == "4" ? "年" : string.Empty;
                            if (dc_FinancingMode.ToString().Contains("1"))
                            {
                                dc_FinancingModeStr = dc_FinancingMode.ToString().Replace("1", "承兑汇票");
                            }
                            if (dc_FinancingMode.ToString().Contains("2"))
                            {
                                dc_FinancingModeStr = dc_FinancingMode.ToString().Replace("2", "法人透支");
                            }
                            if (dc_FinancingMode.ToString().Contains("3"))
                            {
                                dc_FinancingModeStr = dc_FinancingMode.ToString().Replace("3", "流动贷款");
                            }
                            if (dc_FinancingMode.ToString().Contains("4"))
                            {
                                dc_FinancingModeStr = dc_FinancingMode.ToString().Replace("4", "信用证");
                            }

                            DataRow dr = Dt_Brand.NewRow();
                            dr["dc_BrandID"] = dc_BrandID;
                            dr["dc_ID"] = dc_ID;
                            dr["dc_BrandName"] = dc_BrandName;
                            dr["dc_BusinessMode"] = dc_BusinessMode;
                            dr["dc_BusinessModeStr"] = dc_BusinessModeStr;
                            dr["dc_SSMoney"] = dc_SSMoney;
                            dr["dc_YSMoney"] = dc_YSMoney;
                            dr["dc_PaymentCycle"] = dc_PaymentCycle;
                            dr["dc_PaymentCycleStr"] = dc_PaymentCycleStr;
                            dr["dc_FinancingMode"] = dc_FinancingMode;
                            dr["dc_FinancingModeStr"] = dc_FinancingModeStr;
                            dr["dc_DispatchTime"] = dc_DispatchTime;

                            dr["ID"] = objs[0];
                            dr["DealerID"] = objs[1];
                            dr["DealerName"] = objs[2];
                            dr["BankID"] = objs[3];
                            dr["BankName"] = objs[4];
                            dr["GD_ID"] = objs[18];
                            dr["CreateID"] = objs[14];
                            dr["CreateTime"] = objs[15];
                            dr["StopTime"] = objs[17];

                            Dt_Brand.Rows.Add(dr);
                        }
                        BrandDataBind();
                        #endregion
                    }
                }
            }
        }

        #region PrivateFields--乔春羽
        public int DealerID
        {
            get
            {
                int dealerID = 0;
                if (ViewState["DealerID"] != null)
                {
                    dealerID = Convert.ToInt32(ViewState["DealerID"]);
                }
                return dealerID;
            }
        }

        public string DealerName
        {
            get { return (string)ViewState["DealerName"]; }
            set { ViewState["DealerName"] = value; }
        }
        /// <summary>
        /// 存放品牌信息（品牌作为一个新的维度区分了一个店）
        /// </summary>
        public DataTable Dt_Brand
        {
            get
            {
                DataTable dt = null;
                if (ViewState["dt_Brand"] == null)
                {
                    dt = new DataTable();
                    DataColumn dc = new DataColumn("dc_BrandID", typeof(int));
                    DataColumn dc_ID = new DataColumn("dc_ID", typeof(int));
                    DataColumn dc1 = new DataColumn("dc_BrandName", typeof(string));
                    DataColumn dc2 = new DataColumn("dc_BusinessMode", typeof(string));
                    DataColumn dc3 = new DataColumn("dc_BusinessModeStr", typeof(string));
                    DataColumn dc4 = new DataColumn("dc_SSMoney", typeof(string));
                    DataColumn dc5 = new DataColumn("dc_YSMoney", typeof(string));
                    DataColumn dc6 = new DataColumn("dc_PaymentCycle", typeof(string));
                    DataColumn dc7 = new DataColumn("dc_PaymentCycleStr", typeof(string));
                    DataColumn dc8 = new DataColumn("dc_FinancingMode", typeof(string));
                    DataColumn dc9 = new DataColumn("dc_FinancingModeStr", typeof(string));
                    DataColumn dc10 = new DataColumn("dc_DispatchTime", typeof(DateTime));

                    DataColumn dc11 = new DataColumn("ID", typeof(int));
                    DataColumn dc12 = new DataColumn("DealerID", typeof(int));
                    DataColumn dc13 = new DataColumn("DealerName", typeof(string));
                    DataColumn dc14 = new DataColumn("BankID", typeof(int));
                    DataColumn dc15 = new DataColumn("BankName", typeof(string));
                    DataColumn dc16 = new DataColumn("GD_ID", typeof(string));
                    DataColumn dc17 = new DataColumn("CreateID", typeof(int));
                    DataColumn dc18 = new DataColumn("CreateTime", typeof(DateTime));
                    DataColumn dc19 = new DataColumn("StopTime", typeof(DateTime));

                    dt.Columns.Add(dc_ID);
                    dt.Columns.Add(dc);
                    dt.Columns.Add(dc1);
                    dt.Columns.Add(dc2);
                    dt.Columns.Add(dc3);
                    dt.Columns.Add(dc4);
                    dt.Columns.Add(dc5);
                    dt.Columns.Add(dc6);
                    dt.Columns.Add(dc7);
                    dt.Columns.Add(dc8);
                    dt.Columns.Add(dc9);
                    dt.Columns.Add(dc10);
                    dt.Columns.Add(dc11);
                    dt.Columns.Add(dc12);
                    dt.Columns.Add(dc13);
                    dt.Columns.Add(dc14);
                    dt.Columns.Add(dc15);
                    dt.Columns.Add(dc16);
                    dt.Columns.Add(dc17);
                    dt.Columns.Add(dc18);
                    dt.Columns.Add(dc19);
                    ViewState["dt_Brand"] = dt;
                }
                else
                {
                    dt = ViewState["dt_Brand"] as DataTable;
                }
                return dt;
            }
        }
        private Citic.BLL.GD_CustInfo _GD_CustInfoBll;
        private Citic.BLL.GD_CustInfo GD_CustInfoBll
        {
            get
            {
                if (_GD_CustInfoBll == null)
                {
                    _GD_CustInfoBll = new Citic.BLL.GD_CustInfo();
                }
                return _GD_CustInfoBll;
            }
        }
        /// <summary>
        /// 从表GD_CustInfo中查询出来的CustID
        /// </summary>
        private string CustID
        {
            get { return (string)ViewState["CustID"]; }
            set { ViewState["CustID"] = value; }
        }

        /// <summary>
        /// 在修改经销商的时候，如果需要修改“已经合作了的合作行”的信息，则跳到这个页面的时候需要将BankID传过来。
        /// </summary>
        private int BankID
        {
            get
            {
                int num = 0;
                if (ViewState["BankID"] != null)
                {
                    num = (int)ViewState["BankID"];
                }
                return num;
            }
            set { ViewState["BankID"] = value; }
        }
        #endregion

        #region 显示厂商列表--乔春羽
        private void FactoryBind()
        {
            DataTable dt = FactoryBll.GetList("IsDelete=0").Tables[0];

            ddl_Factory.DataTextField = "FactoryName";
            ddl_Factory.DataValueField = "FactoryID";
            ddl_Factory.DataSource = dt;
            ddl_Factory.DataBind();

            ddl_Factory.Items.Insert(0, new FineUI.ListItem("请选择", "0"));
            ddl_Brand.Items.Insert(0, new FineUI.ListItem("请选择", "0"));
        }

        protected void ddl_Factory_SelectedIndexChanged(object sener, EventArgs e)
        {
            string val = ddl_Factory.SelectedValue;
            if (val != null && val != string.Empty)
            {
                if (val != "0")
                {
                    BrandBind(int.Parse(val));
                }
            }
        }
        #endregion

        #region 显示品牌列表--乔春羽
        private void BrandBind(int factoryID)
        {
            DataTable dt = BrandBll.GetList(string.Format("FactoryID={0} and IsDelete=0", factoryID)).Tables[0];

            ddl_Brand.DataTextField = "BrandName";
            ddl_Brand.DataValueField = "BrandID";
            ddl_Brand.DataSource = dt;
            ddl_Brand.DataBind();

            ddl_Brand.Items.Insert(0, new FineUI.ListItem("请选择", "0"));
        }
        #endregion

        #region 确定选择--乔春羽
        /// <summary>
        /// 确定选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_Sure_Click(object sender, EventArgs e)
        {
            if (hf_BankID.Text == string.Empty)
            {
                Alert.ShowInTop("请选择合作银行！");
                return;
            }
            Save();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        private void Save()
        {
            Citic.Model.Dealer_Bank model = null;
            //DealerID=0，表示该页面是从“添加经销商”的入口进入的。
            //其目的是，要添加合作行与品牌。
            //所以，要将所选择的银行和品牌添加到共有变量Banks中。
            if (DealerID == 0)
            {
                foreach (DataRow row in Dt_Brand.Rows)
                {
                    model = new Citic.Model.Dealer_Bank();

                    model.BankID = int.Parse(hf_BankID.Text);
                    model.BankName = lbl_BankName.Text;

                    model.BusinessMode = Convert.ToInt32(row["dc_BusinessMode"]);
                    model.SSMoney = Convert.ToDecimal(row["dc_SSMoney"] == null ? 0.00 : row["dc_SSMoney"]);
                    model.YSMoney = Convert.ToDecimal(row["dc_YSMoney"] == null ? 0.00 : row["dc_YSMoney"]);
                    model.PaymentCycle = Convert.ToInt32(row["dc_PaymentCycle"]);
                    //model.FinancingMode = row["dc_FinancingMode"].ToString();
                    model.FinancingMode = string.Empty;
                    model.BrandID = Convert.ToInt32(row["dc_BrandID"]);
                    model.BrandName = row["dc_BrandName"].ToString();
                    model.DispatchTime = Convert.ToDateTime(row["dc_DispatchTime"]);
                    model.CollaborateType = 1;//默认为正在合作
                    model.CreateID = this.CurrentUser.UserId;
                    model.CreateTime = DateTime.Now;

                    model.GD_ID = CustID;

                    Banks.Add(model);
                }
            }
            //DealerID!=0，表示该页面是从“修改经销商”入口进入，所以要将添加的银行与品牌直接入库并且关闭该页面。
            else
            {
                string dealerName = DealerBll.GetDealerNameByID(DealerID);
                //BankID=0，表示该页面是从“修改经销商”入口进入。
                //其目的是，要添加合作行与品牌信息。
                if (BankID == 0)
                {
                    List<Citic.Model.Dealer_Bank> banks = new List<Citic.Model.Dealer_Bank>();
                    foreach (DataRow row in Dt_Brand.Rows)
                    {
                        model = new Citic.Model.Dealer_Bank();
                        model.DealerID = DealerID;
                        model.DealerName = dealerName;

                        model.BankID = int.Parse(hf_BankID.Text);
                        model.BankName = lbl_BankName.Text;

                        model.BusinessMode = Convert.ToInt32(row["dc_BusinessMode"]);
                        model.SSMoney = Convert.ToDecimal(row["dc_SSMoney"] == null ? 0.00 : row["dc_SSMoney"]);
                        model.YSMoney = Convert.ToDecimal(row["dc_YSMoney"] == null ? 0.00 : row["dc_YSMoney"]);
                        model.PaymentCycle = Convert.ToInt32(row["dc_PaymentCycle"]);
                        model.FinancingMode = row["dc_FinancingMode"].ToString();
                        model.BrandID = Convert.ToInt32(row["dc_BrandID"]);
                        model.BrandName = row["dc_BrandName"].ToString();
                        model.DispatchTime = Convert.ToDateTime(row["dc_DispatchTime"]);
                        model.CollaborateType = 1;//默认为正在合作
                        model.CreateID = this.CurrentUser.UserId;
                        model.CreateTime = DateTime.Now;

                        model.GD_ID = CustID;

                        banks.Add(model);
                    }

                    try
                    {
                        int num = Dealer_BankBll.AddRange(banks.ToArray());
                        if (num < 0)
                        {
                            AlertShowInTop("添加失败！");
                        }
                    }
                    catch
                    {
                    }
                }
                //BankID!=0，表示该页面是从“修改经销商”入口进入。
                //其目的是，要修改已经添加了的合作行与品牌的信息。
                else
                {
                    if (this.Dt_Brand != null && Dt_Brand.Rows.Count > 0)
                    {
                        List<Citic.Model.Dealer_Bank> banks = new List<Citic.Model.Dealer_Bank>();
                        foreach (DataRow row in Dt_Brand.Rows)
                        {
                            banks.Add(new Citic.Model.Dealer_Bank()
                            {
                                ID = Convert.ToInt32(row["ID"]),
                                DealerID = Convert.ToInt32(row["DealerID"]),
                                DealerName = row["DealerName"].ToString(),
                                BankID = Convert.ToInt32(row["BankID"]),
                                BankName = row["BankName"].ToString(),
                                GD_ID = CustID,
                                BrandID = Convert.ToInt32(row["dc_BrandID"]),
                                BrandName = row["dc_BrandName"].ToString(),
                                BusinessMode = Convert.ToInt32(row["dc_BusinessMode"]),
                                SSMoney = Convert.ToDecimal(row["dc_SSMoney"]),
                                YSMoney = Convert.ToDecimal(row["dc_YSMoney"]),
                                PaymentCycle = Convert.ToInt32(row["dc_PaymentCycle"]),
                                FinancingMode = row["dc_FinancingMode"].ToString(),
                                DispatchTime = Convert.ToDateTime(row["dc_DispatchTime"]),
                                ZX_ID = string.Empty,
                                IsDelete = false,
                                //StopTime = Convert.ToDateTime(row["StopTime"]),
                                CreateID = Convert.ToInt32(row["CreateID"]),
                                CreateTime = Convert.ToDateTime(row["CreateTime"]),
                                CollaborateType = 1
                            });
                        }
                        try
                        {
                            int num = Dealer_BankBll.UpdateRange(banks.ToArray());
                            if (num < 0)
                            {
                                AlertShowInTop("添加失败！");
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }
        #endregion

        #region 显示融资模式--乔春羽
        private void FinancingModeBind()
        {
            //cbl_FinancingMode.Items.Add(new CheckItem("承兑汇票", "1"));
            //cbl_FinancingMode.Items.Add(new CheckItem("法人透支", "2"));
            //cbl_FinancingMode.Items.Add(new CheckItem("流动贷款", "3"));
            //cbl_FinancingMode.Items.Add(new CheckItem("信用证", "4"));
        }
        #endregion

        #region 显示业务模式--乔春羽
        /// <summary>
        /// 显示业务模式--乔春羽
        /// </summary>
        private void BusinessModeBind()
        {
            AddItemByInsert(ddl_BusinessMode, "请选择", "-1", 0);
            AddItemByInsert(ddl_BusinessMode, "车证模式", "1", -1);
            AddItemByInsert(ddl_BusinessMode, "合格证模式", "2", -1);
            AddItemByInsert(ddl_BusinessMode, "巡库模式", "3", -1);

            AddItemByInsert(ddl_PaymentCycle, "请选择", "-1", 0);
            AddItemByInsert(ddl_PaymentCycle, "月", "1", -1);
            AddItemByInsert(ddl_PaymentCycle, "季", "2", -1);
            AddItemByInsert(ddl_PaymentCycle, "半年", "3", -1);
            AddItemByInsert(ddl_PaymentCycle, "年", "4", -1);
        }

        #endregion

        #region 翻页事件--乔春羽
        /// <summary>
        /// 翻页事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid_List_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
        {
            SyncSelectedRowIndexArrayToHiddenField(grid_List, hfSelectedIDS);
            grid_List.PageIndex = e.NewPageIndex;
            GridBind();
            UpdateSelectedRowIndexArray(grid_List, hfSelectedIDS);
        }

        #endregion

        #region 每页显示数量改变事件--乔春羽

        /// <summary>
        /// 每页显示数量改变事件--乔春羽
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            grid_List.PageSize = int.Parse(ddlPageSize.SelectedValue);
            GridBind();
        }
        #endregion

        #region 绑定数据--乔春羽
        /// <summary>
        /// 绑定数据
        /// </summary>
        private void GridBind()
        {
            DataTable dt = null;
            //where条件
            string where = ConditionInit();

            //设置表格的总数据量
            this.grid_List.RecordCount = GetCountBySearch(where);

            if (this.grid_List.PageCount <= this.grid_List.PageIndex)
            {
                this.grid_List.PageIndex = 0;
            }

            int pageIndex = grid_List.PageIndex;
            int pageSize = grid_List.PageSize;
            int rowbegin = pageIndex * pageSize + 1;
            int rowend = (pageIndex + 1) * pageSize;
            try
            {
                dt = BankBll.GetListByPage(where, "CreateTime DESC", rowbegin, rowend).Tables[0];

                grid_List.DataSource = dt;
                grid_List.DataBind();
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "GridBind()");
            }
        }

        /// <summary>
        /// 得到查询条件--乔春羽
        /// </summary>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("T.IsDelete=0");
            if (this.tb_Bank.Text != string.Empty)
            {
                where.AppendFormat(" and T.BankName like '%{0}%'", this.tb_Bank.Text);
            }
            if (this.rbl_Types.SelectedValue != "-1")
            {
                where.AppendFormat(" and T.BankType={0}", rbl_Types.SelectedValue);
            }
            return where.ToString();
        }

        /// <summary>
        /// 获得查询后结果的总数据数量--乔春羽
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private int GetCountBySearch(string where)
        {
            return BankBll.GetRecordCount(where);
        }
        #endregion

        #region 查询数据--乔春羽
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        protected void tb_Bank_TriggerClick(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 行绑定事件（银行信息表格）--乔春羽
        protected void grid_List_RowDataBound(object sender, GridRowEventArgs e)
        {
            DataRowView row = e.DataItem as DataRowView;
            if (row != null)
            {
                int index = 2;
                int type = Convert.ToInt32(e.Values[index]);
                switch (type)
                {
                    case 0:
                        e.Values[index] = "总行";
                        break;
                    case 1:
                        e.Values[index] = "分行";
                        break;
                    case 2:
                        e.Values[index] = "支行";
                        break;
                }
            }
        }
        #endregion

        #region //表格行单击事件（银行信息表格，选择银行）--乔春羽
        protected void grid_List_RowSelect(object sender, GridRowSelectEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string bankName = grid_List.Rows[e.RowIndex].Values[0].ToString();
                this.lbl_BankName.Text = bankName;
                this.lbl_BankName.CssStyle = "font-weight:bold;font-size:18px;color:red";
                hf_BankID.Text = grid_List.Rows[e.RowIndex].DataKeys[0].ToString();

                if (bankName.Substring(0, 2) == "光大")
                {
                    this.lbl_BankInterface.Enabled = true;
                    this.cbl_BankInterface.Enabled = true;
                }
                else
                {
                    this.lbl_BankInterface.Enabled = false;
                    this.cbl_BankInterface.Enabled = false;
                    this.cbl_BankInterface.Checked = false;
                }

                Citic.Model.Dealer_Bank model = new Citic.Model.Dealer_Bank();

                model.BankID = int.Parse(hf_BankID.Text);
                model.BankName = lbl_BankName.Text;

                //验证是否重复
                if (DealerID == 0)
                {
                    foreach (Citic.Model.Dealer_Bank db in Banks)
                    {
                        if (db.BankName == model.BankName)
                        {
                            AlertShowInTop("该银行已选择，请重新选择。");
                            return;
                        }
                    }
                }
                else
                {
                    if (Dealer_BankBll.ExistsDealerBank(DealerID, int.Parse(hf_BankID.Text)))
                    {
                        AlertShowInTop("该银行已存在，请重新选择。");
                        return;
                    }
                }
            }
            else
            {
                AlertShowInTop("请选择合作行！");
            }
        }
        #endregion

        #region 行命令事件（品牌表信息）--乔春羽
        protected void grid_BrandList_RowCommand(object sender, GridCommandEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.CommandName == "del")
                {
                    int id = Convert.ToInt32(grid_BrandList.DataKeys[e.RowIndex][0]);
                    RemoveBrand(Dt_Brand, id);
                }
            }
        }

        /// <summary>
        /// 删除品牌数据
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="id"></param>
        private void RemoveBrand(DataTable dt, int id)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (id == Convert.ToInt32(dt.Rows[i]["dc_ID"]))
                    {
                        dt.Rows.RemoveAt(i);
                        break;
                    }
                }

                BrandDataBind();
            }
        }
        #endregion

        #region 添加品牌--乔春羽
        /// <summary>
        /// 获得最大的ID
        /// </summary>
        /// <returns></returns>
        private int GetMaxID(DataTable dt)
        {
            int id = 0;
            if (dt.Rows.Count > 0)
            {
                id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1]["dc_ID"]);
                id++;
            }
            else
            {
                id = 1;
            }
            return id;
        }

        /// <summary>
        /// 绑定品牌信息
        /// </summary>
        private void BrandDataBind()
        {
            this.grid_BrandList.DataSource = Dt_Brand;
            this.grid_BrandList.DataBind();
        }

        protected void btn_AddBrand_Click(object sender, EventArgs e)
        {
            if (this.lbl_BankName.Text == string.Empty || hf_BankID.Text == string.Empty)
            {
                AlertShowInTop("请选择合作银行！");
                return;
            }
            if (this.btn_AddBrand.Text.Equals("添加品牌"))
            {
                foreach (DataRow row in Dt_Brand.Rows)
                {
                    if (row["dc_BrandID"].ToString() == ddl_Brand.SelectedValue)
                    {
                        AlertShowInTop("品牌已存在，请重新选择！");
                        return;
                    }
                }
                DataRow dr = Dt_Brand.NewRow();
                dr["dc_ID"] = GetMaxID(Dt_Brand);
                dr["dc_BrandID"] = ddl_Brand.SelectedValue;
                dr["dc_BrandName"] = ddl_Brand.SelectedText;
                dr["dc_BusinessMode"] = ddl_BusinessMode.SelectedValue;
                dr["dc_BusinessModeStr"] = ddl_BusinessMode.SelectedValue == "1" ? "车证模式" : ddl_BusinessMode.SelectedValue == "2" ? "合格证模式" : ddl_BusinessMode.SelectedValue == "3" ? "巡库模式" : "";
                dr["dc_SSMoney"] = num_SSMoney.Text;
                dr["dc_YSMoney"] = num_YSMoney.Text;
                dr["dc_PaymentCycle"] = ddl_PaymentCycle.SelectedValue;
                dr["dc_PaymentCycleStr"] = ddl_PaymentCycle.SelectedValue == "1" ? "月" : ddl_PaymentCycle.SelectedValue == "2" ? "季" : ddl_PaymentCycle.SelectedValue == "3" ? "半年" : ddl_PaymentCycle.SelectedValue == "4" ? "年" : "";

                dr["dc_DispatchTime"] = dp_DispatchTime.SelectedDate.Value;
                Dt_Brand.Rows.Add(dr);
            }
            else if (this.btn_AddBrand.Text.Equals("修改品牌"))
            {
                if (this.grid_BrandList.SelectedRowIndex >= 0)
                {
                    int dc_ID = int.Parse(this.grid_BrandList.Rows[this.grid_BrandList.SelectedRowIndex].DataKeys[0].ToString());
                    foreach (DataRow row in Dt_Brand.Rows)
                    {
                        if (Convert.ToInt32(row["dc_ID"]) == dc_ID)
                        {
                            row["dc_BrandID"] = ddl_Brand.SelectedValue;
                            row["dc_BrandName"] = ddl_Brand.SelectedText;
                            row["dc_BusinessMode"] = ddl_BusinessMode.SelectedValue;
                            row["dc_BusinessModeStr"] = ddl_BusinessMode.SelectedValue == "1" ? "车证模式" : ddl_BusinessMode.SelectedValue == "2" ? "合格证模式" : ddl_BusinessMode.SelectedValue == "3" ? "巡库模式" : "";
                            row["dc_SSMoney"] = num_SSMoney.Text;
                            row["dc_YSMoney"] = num_YSMoney.Text;
                            row["dc_PaymentCycle"] = ddl_PaymentCycle.SelectedValue;
                            row["dc_PaymentCycleStr"] = ddl_PaymentCycle.SelectedValue == "1" ? "月" : ddl_PaymentCycle.SelectedValue == "2" ? "季" : ddl_PaymentCycle.SelectedValue == "3" ? "半年" : ddl_PaymentCycle.SelectedValue == "4" ? "年" : "";

                            //string financingMode = string.Join(",", cbl_FinancingMode.SelectedValueArray);
                            //row["dc_FinancingMode"] = financingMode;
                            //if (financingMode.Contains("1"))
                            //{
                            //    financingMode = financingMode.Replace("1", "承兑汇票");
                            //}
                            //if (financingMode.Contains("2"))
                            //{
                            //    financingMode = financingMode.Replace("2", "法人透支");
                            //}
                            //if (financingMode.Contains("3"))
                            //{
                            //    financingMode = financingMode.Replace("3", "流动贷款");
                            //}
                            //if (financingMode.Contains("4"))
                            //{
                            //    financingMode = financingMode.Replace("4", "信用证");
                            //}
                            //row["dc_FinancingModeStr"] = financingMode;
                            row["dc_DispatchTime"] = dp_DispatchTime.SelectedDate.Value;
                            break;
                        }
                    }
                }
                this.btn_Cancel.Enabled = false;
                this.btn_AddBrand.Text = "添加品牌";
            }
            ClearBrand();
            BrandDataBind();
        }
        #endregion

        #region 清空信息--乔春羽(2013.8.27)
        /// <summary>
        /// 清空品牌信息
        /// </summary>
        private void ClearBrand()
        {
            SimpleForm1.Reset();
            //ddl_Factory.SelectedValue = "0";
            //ddl_Brand.SelectedValue = "0";
            //ddl_BusinessMode.SelectedValue = "0";
            //num_SSMoney.Text = string.Empty;
            //num_YSMoney.Text = string.Empty;
            //ddl_PaymentCycle.SelectedValue = "0";
            //cbl_FinancingMode.SelectedValueArray = new string[0];
            //dp_DispatchTime.Text = string.Empty;
        }
        #endregion

        #region 光大接口对接--乔春羽(2014.3.12)
        protected void cbl_BankInterface_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbl_BankInterface.Checked)
            {
                if (string.IsNullOrEmpty(this.DealerName))
                {
                    AlertShowInTop("还没有添加经销商名称!");
                    return;
                }
                //根据经销商的名称，去GD_CustInfo表中查询出CustID，作为光大直联ID存入表tb_Dealer_Bank_List中的GD_ID字段中。
                DataTable dt = GD_CustInfoBll.GetList(string.Format(" CUST_NAME = '{0}' ", this.DealerName)).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    CustID = dt.Rows[0]["CUST_ID"].ToString();
                }
                else
                {
                    AlertShowInTop("找不到该经销商的关联数据，不能对接！");
                }
            }
        }
        #endregion

        #region 行选择事件（品牌），选择所添加的品牌的时候，显示出该详细信息（融资信息、支付周期、业务模式、驻点时间等）--乔春羽(2014.3.14)
        protected void grid_BrandList_RowClick(object sender, GridRowClickEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btn_Cancel.Enabled = true;
                btn_AddBrand.Text = "修改品牌";

                string dc_ID = this.grid_BrandList.Rows[e.RowIndex].DataKeys[0].ToString();

                string brandID = this.grid_BrandList.Rows[e.RowIndex].DataKeys[1].ToString();
                int factoryID = BrandBll.GetModel(int.Parse(brandID)).FactoryID.Value;
                //显示厂商、品牌
                this.ddl_Factory.SelectedValue = factoryID.ToString();
                BrandBind(factoryID);
                this.ddl_Brand.SelectedValue = brandID;
                //显示业务模式
                string businessMode = this.grid_BrandList.Rows[e.RowIndex].DataKeys[2].ToString();
                this.ddl_BusinessMode.SelectedValue = businessMode;
                //显示实收费用、应收费用
                this.num_SSMoney.Text = this.grid_BrandList.Rows[e.RowIndex].Values[2];
                this.num_YSMoney.Text = this.grid_BrandList.Rows[e.RowIndex].Values[3];
                //显示缴费周期
                string paymentCycle = this.grid_BrandList.Rows[e.RowIndex].DataKeys[3].ToString();
                this.ddl_PaymentCycle.SelectedValue = paymentCycle;
                //显示驻店日期
                DateTime dispatchTime = Convert.ToDateTime(this.grid_BrandList.Rows[e.RowIndex].Values[5]);
                this.dp_DispatchTime.SelectedDate = dispatchTime;
            }
        }
        #endregion

        #region 取消修改品牌--乔春羽(2014.3.14)
        protected void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearBrand();
            btn_AddBrand.Text = "添加品牌";
            btn_Cancel.Enabled = false;
        }
        #endregion
    }
}