using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;

namespace Citic_Web.ProjectTracking.QueryWHFrequency
{
    public partial class AddQueryWH : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
            }
        }
        #region PrivateField--乔春羽(2013.12.6)

        #endregion

        #region 保存并关闭--乔春羽(2013.12.6)
        protected void btn_SaveAndClose_Click(object sender, EventArgs e)
        {
            Save();
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
        }
        private void Save()
        {
            Citic.Model.QueryWH model = new Citic.Model.QueryWH();
            model.CheckFrequency = this.txt_CheckFrequency.Text;
            model.CreateID = this.CurrentUser.UserId;
            model.CreateTime = DateTime.Now;
            model.Description = this.txt_Desc.Text;
            model.Remark = this.txt_Remark.Text;
            //model.DB_ID = Convert.ToInt32(this.ddl_Bank.SelectedValue);

            try
            {
                int num = QueryWH.Add(model);
                if (num > 0)
                {
                    Alert.ShowInTop("添加成功！");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region 经销商被输入后，联动出合作行--乔春羽(2013.12.6)
        protected void txt_DealerName_TextChanged(object sender, EventArgs e)
        {
            BankDataBind();
        }
        #endregion

        #region 加载合作行以及品牌--乔春羽(2013.12.6)
        private void BankDataBind()
        {
            ddl_Bank.Items.Clear();
            string val = this.txt_DealerName.Text;
            if (!string.IsNullOrEmpty(val))
            {
                if (val.IndexOf('_') >= 0)
                {
                    DataTable dt = Dealer_BankBll.GetBankBrandBySearch(string.Format(" DealerID='{0}'", val.Split('_')[1]));

                    this.ddl_Bank.DataTextField = "BankName";
                    this.ddl_Bank.DataValueField = "ID";
                    this.ddl_Bank.DataSource = dt;
                    this.ddl_Bank.DataBind();
                }
            }
            AddItemByInsert(ddl_Bank, "请选择", "-1", 0);
        }
        #endregion

    }
}