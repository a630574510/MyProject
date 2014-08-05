using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using FineUI;
namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class AddRiskQues : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DealerBind();
                BankBind();
                BrandBind();
                WCBind();
                AreaBind();
                SupervisorBind();
            }
        }

        #region 加载经销商信息--乔春羽(2013.8.21)
        protected void ddl_Dealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            BankBind();
        }
        private void DealerBind()
        {
            ddl_Dealer.Items.Clear();

            DataTable dt = null;
            try
            {
                dt = Dealer_BankBll.GetDealers(string.Empty).Tables[0];
            }
            catch (Exception e)
            {
                AlertShowInTop("网络异常，请稍后再试！");
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "DealerBind()");
            }
            ddl_Dealer.DataTextField = "DealerName";
            ddl_Dealer.DataValueField = "DealerID";
            ddl_Dealer.DataSource = dt;
            ddl_Dealer.DataBind();

            AddItemByInsert(ddl_Dealer, "请选择", "-1", 0);
        }
        #endregion

        #region 加载合作行信息--乔春羽(2013.8.21)
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            BrandBind();
        }
        private void BankBind()
        {
            ddl_Bank.Items.Clear();
            string dealer = ddl_Dealer.SelectedValue;
            if (!string.IsNullOrEmpty(dealer))
            {
                if (dealer != "-1")
                {
                    DataTable dt = null;
                    try
                    {
                        string where = string.Format(" DealerID={0} ", dealer);
                        dt = Dealer_BankBll.GetBanks(where).Tables[0];
                    }
                    catch (Exception e)
                    {
                        AlertShowInTop("网络异常，请稍后再试！");
                        Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "BankBind()");
                    }
                    ddl_Bank.DataTextField = "BankName";
                    ddl_Bank.DataValueField = "BankID";
                    ddl_Bank.DataSource = dt;
                    ddl_Bank.DataBind();
                }
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 加载品牌信息--乔春羽(2013.8.21)
        private void BrandBind()
        {
            ddl_Brand.Items.Clear();
            DataTable dt = null;
            string dealer = ddl_Dealer.SelectedValue;
            string bank = ddl_Bank.SelectedValue;
            if (!string.IsNullOrEmpty(bank) && !string.IsNullOrEmpty(dealer))
            {
                if (bank != "-1" && dealer != "-1")
                {
                    try
                    {
                        string where = string.Format(" DealerID={0} and BankID={1} ", dealer, bank);
                        dt = Dealer_BankBll.GetBrands(where).Tables[0];
                    }
                    catch (Exception e)
                    {
                        AlertShowInTop("网络异常，请稍后再试！");
                        Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "BrandBind()");
                    }
                }
            }
            ddl_Brand.DataTextField = "BrandName";
            ddl_Brand.DataValueField = "BrandID";
            ddl_Brand.DataSource = dt;
            ddl_Brand.DataBind();
            AddItemByInsert(ddl_Brand, "请选择", "-1", 0);
        }
        #endregion

        #region 加载工作内容--乔春羽(2013.8.21)
        private void WCBind()
        {
            ddl_WC.Items.Clear();
            string path = "~/ProjectTracking/RiskControl/工作内容.txt";
            FileStream fs = new FileStream(Server.MapPath(path), FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                string value = sr.ReadLine();
                AddItemByInsert(ddl_WC, value, value, -1);
            }
            sr.Close();
            fs.Close();
            AddItemByInsert(ddl_WC, "请选择", "-1", 0);
        }
        #endregion

        #region 加载区域名称--乔春羽(2013.8.21)
        private void AreaBind()
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
        }
        #endregion

        #region 加载监管员--乔春羽(2013.8.21)
        private void SupervisorBind()
        {
            ddl_Supervisor.Items.Clear();
            DataTable dt = null;
            try
            {
                dt = SupervisorBll.GetList(" IsDelete=0").Tables[0];
            }
            catch (Exception e)
            {
                AlertShowInTop("网络异常，请稍后再试！");
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "SupervisorBind()");
            }
            ddl_Supervisor.DataTextField = "SupervisorName";
            ddl_Supervisor.DataValueField = "SupervisorID";
            ddl_Supervisor.DataSource = dt;
            ddl_Supervisor.DataBind();

            AddItemByInsert(ddl_Supervisor, "请选择", "-1", 0);
        }
        #endregion

        #region 保存数据并关闭窗口--乔春羽(2013.8.21)
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            Save();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
        }
        private void Save()
        {
            Citic.Model.RiskQuesDay model = new Citic.Model.RiskQuesDay();
            model.Area = ddl_Area.SelectedValue;
            model.BankID = int.Parse(ddl_Bank.SelectedValue);
            model.BankName = ddl_Bank.SelectedText;
            model.BrandID = int.Parse(ddl_Brand.SelectedValue);
            model.BrandName = ddl_Brand.SelectedText;
            model.Checkman = txt_Checkman.Text;
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.CY_Business = txt_CY_Business.Text;
            model.CY_Market = txt_CY_Market.Text;
            model.DealerID = int.Parse(ddl_Dealer.SelectedValue);
            model.DealerName = ddl_Dealer.SelectedText;
            model.DescProb = txt_DescQues.Text;
            model.ManCenter = txt_ManCenter.Text;
            model.QC_Business = txt_QC_Business.Text;
            model.QC_Market = txt_QC_Market.Text;
            model.Remark = txt_Remark.Text;
            model.Result = txt_Result.Text;
            model.WorkContent = ddl_WC.SelectedValue;
            model.XZ = txt_XZ.Text;
            model.SID = int.Parse(ddl_Supervisor.SelectedValue);
            model.SName = ddl_Supervisor.SelectedText;

            try
            {
                int num = RQDBLL.Add(model);
                if (num > 0)
                {
                    AlertShowInTop("添加成功！");
                }
                else
                {
                    AlertShowInTop("添加失败！");
                }
            }
            catch (Exception e)
            {
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "Save()");
            }
        }
        #endregion

    }
}