using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.IO;
using System.Configuration;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using FineUI;
namespace Citic_Web.Reminds
{
    public partial class AddStockError : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ErrorOtherBind();
            }
        }

        #region PrivateFields--乔春羽(2014.3.5)
        /// <summary>
        /// 品牌ID
        /// </summary>
        private int BrandID
        {
            get
            {
                int brandid = -1;
                if (ViewState["brandid"] != null)
                {
                    brandid = Convert.ToInt32(ViewState["brandid"]);
                }
                return brandid;
            }
            set { ViewState["brandid"] = value; }
        }
        /// <summary>
        /// 车辆金额
        /// </summary>
        private decimal CarCost
        {
            get { return ViewState["CarCost"] == null ? 0 : (decimal)ViewState["CarCost"]; }
            set { ViewState["CarCost"] = value; }
        }
        #endregion

        #region 选择经销商之后，加载合作行信息--乔春羽(2014.3.5)
        protected void txt_Dealer_TextChanged(object sender, EventArgs e)
        {
            string val = this.txt_Dealer.Text;
            if (!string.IsNullOrEmpty(val) && val.IndexOf('_') > 0)
            {
                if (!string.IsNullOrEmpty(val.Split('_')[0]) && !string.IsNullOrEmpty(val.Split('_')[1]))
                {
                    BankBind();
                }
            }
        }

        private void BankBind()
        {
            string dealerID = this.txt_Dealer.Text.Split('_')[1];
            ddl_Bank.Items.Clear();
            DataTable dt = Dealer_BankBll.GetBanks(string.Format(" T.DealerID = {0} ", dealerID)).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl_Bank.DataTextField = "BankName";
                ddl_Bank.DataValueField = "BankID";
                ddl_Bank.DataSource = dt;
                ddl_Bank.DataBind();
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

        #region 显示异常信息--乔春羽(2014.3.5)
        /// <summary>
        /// 显示异常信息，异常信息来自一个文本文件
        /// </summary>
        private void ErrorOtherBind()
        {
            string path = Common.OperateConfigFile.getValue("eoc_path");
            if (File.Exists(Server.MapPath(path)))
            {
                FileStream fs = new FileStream(Server.MapPath(path), FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string val = sr.ReadLine();
                    cbl_EO.Items.Add(new CheckItem(val.Split('_')[0], val.Split('_')[0]));
                }
                sr.Close();
                fs.Close();
            }
            else
            {
                Alert.ShowInTop("缺少配置文件，请联系技术人员！");
            }
        }
        #endregion

        #region 保存并关闭页面--乔春羽(2014.3.5)
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
        }
        private void Save()
        {
            //验证异常信息
            string dealerValue = this.txt_Dealer.Text;
            if (string.IsNullOrEmpty(dealerValue) || dealerValue.IndexOf("_") <= 0 || dealerValue.Split('_').Length != 2)
            {
                AlertShowInTop("请选择经销商！");
                return;
            }
            if (this.ddl_Bank.SelectedValue == "-1")
            {
                AlertShowInTop("请选择银行！");
                return;
            }
            if (this.cbl_EO.SelectedItemArray.Length <= 0)
            {
                AlertShowInTop("请选择一项异常信息！");
                return;
            }
            if (string.IsNullOrEmpty(this.txt_Vin.Text))
            {
                AlertShowInTop("请选择车架号！");
                return;
            }
            try
            {
                string bankid = this.ddl_Bank.SelectedValue;
                string bankname = ddl_Bank.SelectedText;
                string dealerid = this.txt_Dealer.Text.Split('_')[1];
                string dealername = this.txt_Dealer.Text.Split('_')[0];
                string tableName = string.Format("tb_Car_{0}_{1}", bankid, dealerid);
                string vin = this.txt_Vin.Text;
                int carOldStatus = 5;
                DataSet ds = CarBll.GetValueByColumns(tableName, vin, "DraftNo", "Statu", "BrandID", "CarCost");
                string draftno = string.Empty;
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
                {
                    draftno = ds.Tables[0].Rows[0]["DraftNo"].ToString();
                    carOldStatus = Convert.ToInt32(ds.Tables[0].Rows[0]["Statu"]);
                    BrandID = Convert.ToInt32(ds.Tables[0].Rows[0]["BrandID"]);
                    CarCost = Convert.ToDecimal(ds.Tables[0].Rows[0]["CarCost"]);
                }
                string errorother = this.cbl_EO.SelectedValueArray == null ? string.Empty : this.cbl_EO.SelectedValueArray.Length == 0 ? string.Empty : string.Join(",", this.cbl_EO.SelectedValueArray);
                errorother += (string.IsNullOrEmpty(errorother) ? string.Empty : ",") + this.txt_ErrorOther.Text;
                Citic.Model.StockError model = new Citic.Model.StockError()
                {
                    BankID = bankid,
                    BankName = bankname,
                    DealerID = dealerid,
                    DealerName = dealername,
                    DraftNo = draftno,
                    Vin = vin,
                    Status = false,
                    ErrorOther = errorother,
                    CreateID = this.CurrentUser.UserId,
                    CreateTime = DateTime.Now,
                    OperateID = this.CurrentUser.UserId,
                    OperateTime = DateTime.Now
                };
                //记录该条车辆异常信息的品牌
                model.BrandID = BrandID;
                //获取该质押物之前的状态
                model.CarStatusOld = carOldStatus;

                //获取异常状态
                string carstatus = string.Join(",", cbl_Status.SelectedValueArray);

                model.ErrorType = carstatus;
                model.CarCost = this.CarCost;

                int num = StockErrorBll.Add(model);
                if (num > 0)
                {
                    AlertShowInTop("添加成功！");
                }
                else
                {
                    AlertShowInTop("添加失败！");
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "Save()--添加日查库异常的保存操作");
            }

            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        #endregion
    }
}