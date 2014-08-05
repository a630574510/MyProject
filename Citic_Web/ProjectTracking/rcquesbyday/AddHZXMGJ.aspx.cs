using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using FineUI;
namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class AddHZXMGJ : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BrandBind();
                DealerBind();
                BankBind();
            }
        }

        #region 加载品牌信息--乔春羽(2013.8.21)
        private void BrandBind()
        {
            ddl_Brand.Items.Clear();
            DataTable dt = null;
            try
            {
                dt = BrandBll.GetList(" IsDelete=0").Tables[0];
            }
            catch (Exception e)
            {
                AlertShow(e.Message);
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "BrandBind()");
            }
            ddl_Brand.DataTextField = "BrandName";
            ddl_Brand.DataValueField = "BrandID";
            ddl_Brand.DataSource = dt;
            ddl_Brand.DataBind();
            AddItemByInsert(ddl_Brand, "请选择", "-1", 0);
        }
        protected void ddl_Brand_SelectedIndexChanged(object sender, EventArgs e)
        {
            DealerBind();
        }
        #endregion

        #region 加载经销商信息--乔春羽(2013.8.21)
        private void DealerBind()
        {
            ddl_Dealer.Items.Clear();
            string val = ddl_Brand.SelectedValue;
            if (!string.IsNullOrEmpty(val))
            {
                if (val != "-1")
                {
                    DataTable dt = null;
                    string where = " BrandID=" + val;
                    try
                    {
                        dt = Dealer_BankBll.GetDealers(where).Tables[0];
                    }
                    catch (Exception e)
                    {
                        AlertShow(e.Message);
                        Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "DealerBind()");
                    }
                    ddl_Dealer.DataTextField = "DealerName";
                    ddl_Dealer.DataValueField = "DealerID";
                    ddl_Dealer.DataSource = dt;
                    ddl_Dealer.DataBind();
                }
            }
            AddItemByInsert(ddl_Dealer, "请选择", "-1", 0);
        }
        protected void ddl_Dealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            BankBind();
        }
        #endregion

        #region 加载合作行--乔春羽(2013.8.21)
        private void BankBind()
        {
            ddl_Bank.Items.Clear();
            string brand = ddl_Brand.SelectedValue;
            string dealer = ddl_Dealer.SelectedValue;
            if (!string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(dealer))
            {
                if (brand != "-1" && dealer != "-1")
                {
                    DataTable dt = null;
                    try
                    {
                        string where = string.Format(" DealerID={0} and BrandID={1} ", dealer, brand);
                        dt = Dealer_BankBll.GetBanks(where).Tables[0];
                    }
                    catch (Exception e)
                    {
                        AlertShow(e.Message);
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
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDetailInfo();
        }
        #endregion

        #region 显示“一个店”剩余的信息--乔春羽(2013.8.21)
        private void ShowDetailInfo()
        {
            Citic.Model.Dealer_Bank model = null;
            Citic.Model.Dealer dealerModel = null;
            Citic.Model.Supervisor superModel = null;
            string brand = ddl_Brand.SelectedValue;
            string dealer = ddl_Dealer.SelectedValue;
            string bank = ddl_Bank.SelectedValue;
            if (!string.IsNullOrEmpty(brand) && !string.IsNullOrEmpty(dealer) && !string.IsNullOrEmpty(bank))
            {
                if (brand != "-1" && dealer != "-1" && bank != "-1")
                {
                    string where = string.Format(" DealerID={0} and BankID={1} and BrandID={2} ", dealer, bank, brand);
                    model = Dealer_BankBll.GetModelList(where)[0];
                    dealerModel = DealerBll.GetModel(int.Parse(dealer));
                }
            }
            if (model != null && dealerModel != null)
            {
                superModel = SupervisorBll.GetModel(dealerModel.SupervisorID.Value);
                //显示业务模式
                lbl_BusinessMode.Text = model.BusinessMode == 1 ? "车证模式" : model.BusinessMode == 2 ? "合格证模式" : model.BusinessMode == 3 ? "巡库模式" : "无";
                hf_BM.Text = model.BusinessMode.ToString();
                //显示经销商属性
                string dtStr = dealerModel.DealerType;
                hf_DT.Text = dtStr;
                foreach (char c in dtStr)
                {
                    switch (c)
                    {
                        case '1':
                            dtStr = dtStr.Replace("1", "民营");
                            break;
                        case '2':
                            dtStr = dtStr.Replace("2", "国营");
                            break;
                        case '3':
                            dtStr = dtStr.Replace("3", "集团");
                            break;
                        case '4':
                            dtStr = dtStr.Replace("4", "单店");
                            break;
                    }
                }
                lbl_DealerType.Text = dtStr;
                //显示进驻日期
                lbl_SDispatchTime.Text = dealerModel.SupervisorDispatchTime.Value.ToShortDateString();
                //显示监管员信息
                hf_SN.Text = dealerModel.SupervisorID.ToString();
                lbl_Supervisor.Text = dealerModel.SupervisorName;
                lbl_LinkPhone.Text = superModel.LinkPhone;
            }
        }
        #endregion

        #region 保存信息并且关闭本窗口--乔春羽(2013.8.21)
        protected void btnSaveRefresh_Click(object sender, EventArgs e)
        {
            Save();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
        }
        private void Save()
        {
            Citic.Model.HZXMGJ model = new Citic.Model.HZXMGJ();
            model.BankID = int.Parse(ddl_Bank.SelectedValue);
            model.BankName = ddl_Bank.SelectedText;
            model.BM = lbl_BusinessMode.Text;
            model.BrandID = int.Parse(ddl_Brand.SelectedValue);
            model.BrandName = ddl_Brand.SelectedText;
            model.col_1 = col_1.Text;
            model.col_10 = col_10.Text;
            model.col_11 = col_11.Text;
            model.col_2 = col_2.Text;
            model.col_3 = col_3.Text;
            model.col_4 = col_4.Text;
            model.col_5 = col_5.Text;
            model.col_6 = col_6.Text;
            model.col_7 = col_7.Text;
            model.col_8 = col_8.Text;
            model.col_9 = col_9.Text;
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.DealerID = int.Parse(ddl_Dealer.SelectedValue);
            model.DealerName = ddl_Dealer.SelectedText;
            model.DTime = DateTime.Parse(lbl_SDispatchTime.Text);
            model.LinkPhone = lbl_LinkPhone.Text;
            model.Remark = txt_Remark.Text;
            model.SID = int.Parse(hf_SN.Text);
            model.SName = lbl_Supervisor.Text;
            model.type = lbl_DealerType.Text;
            try
            {
                int num = HZXMGJBLL.Add(model);
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
                AlertShow(e.Message);
                Logging.WriteLog(e, HttpContext.Current.Request.Url.AbsolutePath, "Save()");
            }
        }
        #endregion

    }
}