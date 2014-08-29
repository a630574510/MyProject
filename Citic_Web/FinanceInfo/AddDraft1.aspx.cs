using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using FineUI;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


namespace Citic_Web.Financing
{
    public partial class Add_Draft : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加载银行信息
                BankDataBind();
                //加载企业信息
                DealerDataBind();
            }
        }

        #region 加载合作银行信息--乔春羽
        private void BankDataBind()
        {
            DataTable dt = BankBll.GetList("T.IsDelete=0").Tables[0];

            ddl_Bank.DataTextField = "BankName";
            ddl_Bank.DataValueField = "BankID";
            ddl_Bank.DataSource = dt;
            ddl_Bank.DataBind();

            ddl_Bank.Items.Insert(0, new FineUI.ListItem("请选择", "0"));

        }
        #endregion

        #region 加载企业信息（经销商）--乔春羽
        private void DealerDataBind()
        {
            string val = ddl_Bank.SelectedValue;
            if (val != null && val != string.Empty)
            {
                DataTable dt = Dealer_BankBll.GetList(string.Format("IsDelete=0 and BankID = {0}", val)).Tables[0];

                ddl_Dealer.DataTextField = "DealerName";
                ddl_Dealer.DataValueField = "DealerID";
                ddl_Dealer.DataSource = dt;
                ddl_Dealer.DataBind();
            }
            ddl_Dealer.Items.Insert(0, new FineUI.ListItem("请选择", "0"));
        }
        #endregion

        #region 选择银行，加载企业信息--乔春羽
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            DealerDataBind();
        }
        #endregion

        #region 保存并且关闭页面--乔春羽
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }

        #region 判断是否有重复的汇票号--乔春羽
        private bool ExistsDraftNo(string draftNo)
        {
            Citic.Model.Draft model = DraftBll.GetModel(draftNo);
            return model == null ? false : true;
        }
        #endregion

        /// <summary>
        /// 保存汇票
        /// </summary>
        private void Save()
        {
            Citic.Model.Draft model = new Citic.Model.Draft();
            model.BeginTime = DateTime.Parse(dp_Start.Text);
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.DarftMoney = this.num_Money.Text;
            model.DealerID = int.Parse(ddl_Dealer.SelectedValue);
            model.DealerName = ddl_Dealer.SelectedItem.Text;
            model.DraftType = true;
            model.EndTime = DateTime.Parse(dp_End.Text).AddDays(1);
            model.GuaranteeNo = this.txt_GuaranteeNo.Text;
            model.IsDelete = false;
            model.IsPort = false;
            model.PledgeNo = this.txt_PledgeNo.Text;
            model.Ratio = decimal.Parse(num_Ratio.Text);
            model.Remarks = this.txt_Remark.Text;
            model.RGuaranteeNo = this.txt_RGuaranteeNo.Text;
            model.DraftNo = this.txt_DraftNo.Text;
            model.BankID = int.Parse(ddl_Bank.SelectedValue);
            model.BankName = ddl_Bank.SelectedItem.Text;


            //汇款金额与敞口金额需要公式计算
            model.HKMoney = 0;
            model.CKMoney = 0;

            try
            {
                if (!ExistsDraftNo(model.DraftNo))
                {
                    int num = DraftBll.Add(model);
                    if (num > 0)
                    {
                        Alert.ShowInTop("添加成功！");
                    }
                    else
                    {
                        Alert.ShowInTop("添加失败！");
                    }
                }
                else
                {
                    Alert.ShowInTop("汇票号已存在，请重新填写！");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}