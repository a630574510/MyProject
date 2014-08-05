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
                ViewState.Clear();
                //显示汇票信息
                DraftBind();
                //显示车架号信息
                VinBind();
                //显示异常信息
                ErrorOtherBind();
            }
        }

        #region PrivateFields--乔春羽(2013.8.23)
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
        /// 经销商ID
        /// </summary>
        private string DealerID
        {
            get { return (string)ViewState["DealerID"]; }
            set { ViewState["DealerID"] = value; }
        }
        /// <summary>
        /// 车辆金额
        /// </summary>
        private decimal CarCost
        {
            get { return (decimal)ViewState["CarCost"]; }
            set { ViewState["CarCost"] = value; }
        }
        #endregion

        #region 保存并关闭--乔春羽(2013.8.9)
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideRefreshReference());
        }
        private void Save()
        {
            string bankid = ddl_Bank.SelectedValue;
            string bankname = ddl_Bank.SelectedText;
            string dealerid = DealerID;
            string dealername = this.txt_Dealer.Text.Split('_')[0];
            string draftno = ddl_DraftNo.SelectedValue;
            string vin = ddl_Vin.SelectedValue;
            string errorother = this.txt_ErrorOther.Text;
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
            //得到要查询的质押物所在的表名
            string tableName = string.Format("tb_Car_{0}_{1}", bankid, dealerid);
            //获取该质押物之前的状态
            model.CarStatusOld = Convert.ToInt32(CarBll.GetValueByColumns(tableName, vin, "Statu").Tables[0].Rows[0]["Statu"]);
            //获取异常状态
            string carstatus = string.Join(",", cbl_Status.SelectedValueArray);

            model.ErrorType = carstatus;
            model.CarCost = this.CarCost;
            try
            {
                int num = StockErrorBll.Add(model);
                if (num > 0)
                {
                    Alert.ShowInTop("添加成功！");
                }
                else
                {
                    Alert.ShowInTop("添加失败！");
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region 显示数据--乔春羽(2013.8.9)

        #region 显示合作行信息--乔春羽(2013.8.9)
        /// <summary>
        /// 显示合作行信息
        /// </summary>
        private void BankBind()
        {
            ddl_Bank.Items.Clear();
            DataTable dt = Dealer_BankBll.GetBanks(string.Format(" DealerID={0}", DealerID)).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                ddl_Bank.DataTextField = "BankName";
                ddl_Bank.DataValueField = "BankID";
                ddl_Bank.DataSource = dt;
                ddl_Bank.DataBind();
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }

        /// <summary>
        /// 选择合作行之后，加载出该店的“汇票”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ddl_Bank.SelectedValue != "-1")
            {
                DraftBind();
            }
        }
        #endregion

        #region 显示汇票信息--乔春羽(2013.8.9)
        /// <summary>
        /// 显示企业信息，根据所选择的银行与经销商
        /// </summary>
        private void DraftBind()
        {
            ddl_DraftNo.Items.Clear();
            string bank = ddl_Bank.SelectedValue;
            if (!string.IsNullOrEmpty(bank) && !string.IsNullOrEmpty(DealerID))
            {
                StringBuilder where = new StringBuilder(" IsDelete=0 ");
                if (bank != "-1")
                {
                    where.AppendFormat(" and BankID={0}", bank);
                }
                if (!string.IsNullOrEmpty(DealerID))
                {
                    where.AppendFormat(" and DealerID={0}", DealerID);
                }
                DataTable dt = DraftBll.GetList(where.ToString()).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                {
                    ddl_DraftNo.DataTextField = "DraftNo";
                    ddl_DraftNo.DataValueField = "DraftNo";
                    ddl_DraftNo.DataSource = dt;
                    ddl_DraftNo.DataBind();
                }
                AddItemByInsert(ddl_DraftNo, "请选择", "-1", 0);
            }
        }

        /// <summary>
        /// 选择汇票，显示车架号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_DraftNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ddl_DraftNo.SelectedValue))
            {
                VinBind();
            }
        }
        #endregion

        #region 显示车架号信息--乔春羽(2013.8.9)
        /// <summary>
        /// 显示车架号信息，根据已选择的合作行、企业、汇票
        /// </summary>
        private void VinBind()
        {
            ddl_Vin.Items.Clear();
            string tableName = string.Empty;
            string bank = ddl_Bank.SelectedValue;
            string draftNo = ddl_DraftNo.SelectedValue;
            if (!string.IsNullOrEmpty(bank) && !string.IsNullOrEmpty(DealerID))
            {
                if (bank != "-1" && !string.IsNullOrEmpty(DealerID))
                {
                    tableName = string.Format("tb_Car_{0}_{1}", bank, DealerID);
                }
                if (!string.IsNullOrEmpty(draftNo))
                {
                    StringBuilder where = new StringBuilder(" IsDelete=0 ");
                    if (draftNo != "-1")
                    {
                        where.AppendFormat(" and DraftNo='{0}'", draftNo);
                    }
                    DataTable dt = CarBll.GetList(where.ToString(), tableName).Tables[0];
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ddl_Vin.DataTextField = "Vin";
                        ddl_Vin.DataValueField = "Vin";
                        ddl_Vin.DataSource = dt;
                        ddl_Vin.DataBind();
                    }
                    AddItemByInsert(ddl_Vin, "请选择", "-1", 0);
                }
            }
        }
        #endregion

        #region 显示异常信息--乔春羽(2013.8.13)
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

        #endregion

        #region 选择异常信息，显示在下边的框中--乔春羽(2013.8.13)
        protected void cbl_EO_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] vals = this.cbl_EO.SelectedValueArray;
            if (vals != null && vals.Length > 0)
            {
                this.txt_ErrorOther.Text = string.Join("，", vals);
            }
        }
        #endregion

        #region 选择车架号，调出该车的品牌与价格--乔春羽(2013.8.23)
        protected void ddl_Vin_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = this.ddl_Vin.SelectedValue;
            string bank = this.ddl_Bank.SelectedValue;
            if (!string.IsNullOrEmpty(DealerID) && !string.IsNullOrEmpty(bank) && !string.IsNullOrEmpty(val))
            {
                if (!string.IsNullOrEmpty(DealerID) && bank != "-1" && val != "-1")
                {
                    string tableName = string.Format("tb_Car_{0}_{1}", bank, DealerID);
                    Citic.Model.Car model = CarBll.GetModel(val, tableName);
                    BrandID = model.BrandID.Value;
                    CarCost = decimal.Parse(model.CarCost);
                }
            }
        }
        #endregion

        #region 选择经销商后，加载银行--乔春羽(2013.12.12)
        protected void txt_Dealer_TextChanged(object sender, EventArgs e)
        {
            string value = this.txt_Dealer.Text;
            if (!string.IsNullOrEmpty(value))
            {
                if (value.IndexOf('_') > 0)
                {
                    DealerID = value.Split('_')[1];
                    BankBind();
                }
            }
        }
        #endregion
    }
}