using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Text;

namespace Citic_Web.ProjectTracking
{
    public partial class CarErrorCount1 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DealerBind();
                BankBind();
                BrandBind();
                string bankid = Request.QueryString["bankid"];
                string dealerid = Request.QueryString["dealerid"];
                string brandid = Request.QueryString["brandid"];
                if (!string.IsNullOrEmpty(bankid) && !string.IsNullOrEmpty(dealerid) )
                {
                    ddl_Dealer.SelectedValue = dealerid;
                    ddl_Bank.SelectedValue = bankid;
                    ddl_Brand.SelectedValue = brandid;
                    GridBind();
                }
                this.hid_UserID.Value = this.CurrentUser.UserId.ToString();
            }
        }
        #region PrivateFields--乔春羽(2013.8.15)
        private Citic.BLL.StockError _SEBLL = null;

        public Citic.BLL.StockError SEBLL
        {
            get
            {
                if (_SEBLL == null)
                {
                    _SEBLL = new Citic.BLL.StockError();
                }
                return _SEBLL;
            }
        }

        private DataTable _dt = null;

        public DataTable DataSource
        {
            get
            {
                if (_dt == null)
                {
                    if (ViewState["DS"] != null)
                    {
                        _dt = ViewState["DS"] as DataTable;
                    }
                    else
                    {
                        _dt = new DataTable();
                    }
                }
                else if (_dt != null)
                {
                    ViewState["DS"] = _dt;
                }
                return _dt;
            }
            set
            {
                _dt = value;
            }
        }
        #endregion

        #region 绑定数据--乔春羽(2013.8.15)
        private void GridBind()
        {
            string path = ConfigurationManager.AppSettings["Dealer_Bank"].ToString();
            string sqlCmd = ConfigurationManager.AppSettings["cec"].ToString();
            string where = ConditionInit();

            DataSource = SEBLL.CarErrorSearch(Server.MapPath(path), sqlCmd, where).Tables[0];

            //增加列
            DataColumn dc1 = new DataColumn("szyd", typeof(string));
            DataColumn dc2 = new DataColumn("szsm", typeof(string));
            DataColumn dc3 = new DataColumn("xswhk", typeof(string));
            DataColumn dc4 = new DataColumn("zscl", typeof(string));
            DataColumn dc5 = new DataColumn("zyczsjc", typeof(string));
            DataColumn dc6 = new DataColumn("zyclb", typeof(string));
            DataSource.Columns.Add(dc1);
            DataSource.Columns.Add(dc2);
            DataSource.Columns.Add(dc3);
            DataSource.Columns.Add(dc4);
            DataSource.Columns.Add(dc5);
            DataSource.Columns.Add(dc6);

        }

        /// <summary>
        /// 获得查询条件
        /// </summary>
        /// <returns></returns>
        private string ConditionInit()
        {
            StringBuilder where = new StringBuilder("1=1");
            if (!string.IsNullOrEmpty(this.ddl_Dealer.SelectedValue) && this.ddl_Dealer.SelectedValue != "-1")
            {
                where.AppendFormat("And DealerID = {0}", ddl_Dealer.SelectedValue);
            }
            if (!string.IsNullOrEmpty(this.ddl_Bank.SelectedValue) && this.ddl_Bank.SelectedValue != "-1")
            {
                where.AppendFormat("And BankID = {0}", ddl_Bank.SelectedValue);
            }
            if (!string.IsNullOrEmpty(this.ddl_Brand.SelectedValue) && this.ddl_Brand.SelectedValue != "-1")
            {
                where.AppendFormat("And BrandID = {0}", ddl_Brand.SelectedValue);
            }
            //此处应该还有品牌的筛选条件
            return where.ToString();
        }
        #endregion

        #region 加载合作行信息--乔春羽(2013.8.16)
        private void BankBind()
        {
            ddl_Bank.Items.Clear();
            DataTable dt = null;
            if (!string.IsNullOrEmpty(ddl_Dealer.SelectedValue))
            {
                if (ddl_Dealer.SelectedValue != "-1")
                {
                    string val = ddl_Dealer.SelectedValue;
                    string where = " DealerID=" + val;
                    dt = Dealer_BankBll.GetBanks(where).Tables[0];
                }
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl_Bank.DataTextField = "BankName";
                ddl_Bank.DataValueField = "BankID";
                ddl_Bank.DataSource = dt;
                ddl_Bank.DataBind();
            }
            AddItemByInsert(0, "请选择", "-1", ddl_Bank);
        }

        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrandBind();
        }
        #endregion

        #region 加载品牌--乔春羽(2013.8.16)
        private void BrandBind()
        {
            ddl_Brand.Items.Clear();
            DataTable dt = null;
            if (!string.IsNullOrEmpty(this.ddl_Dealer.SelectedValue) && !string.IsNullOrEmpty(this.ddl_Bank.SelectedValue))
            {
                string dealerid = this.ddl_Dealer.SelectedValue;
                string bankid = this.ddl_Bank.SelectedValue;
                if (dealerid != "-1" && bankid != "-1")
                {
                    string where = string.Format(" DealerID={0} and BankID={1}", dealerid, bankid);
                    dt = Dealer_BankBll.GetBrands(where).Tables[0];
                }
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl_Brand.DataTextField = "BrandName";
                ddl_Brand.DataValueField = "BrandID";
                ddl_Brand.DataSource = dt;
                ddl_Brand.DataBind();
            }
            AddItemByInsert(0, "请选择", "-1", ddl_Brand);
        }
        #endregion

        #region 加载经销商--乔春羽(2013.8.16)
        private void DealerBind()
        {
            ddl_Dealer.Items.Clear();
            DataTable dt = Dealer_BankBll.GetDealers(string.Empty).Tables[0];
            if (dt != null)
            {
                ddl_Dealer.DataTextField = "DealerName";
                ddl_Dealer.DataValueField = "DealerID";
                ddl_Dealer.DataSource = dt;
                ddl_Dealer.DataBind();
            }
            AddItemByInsert(0, "请选择", "-1", ddl_Dealer);
        }

        protected void ddl_Dealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            BankBind();
        }
        #endregion

        #region 查询--乔春羽(2013.8.15)
        protected void btn_Search_Click(object sender, EventArgs e)
        {
            GridBind();
        }
        #endregion

        #region 提交报告--乔春羽(2013.8.19)
        protected void btn_Submit_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}