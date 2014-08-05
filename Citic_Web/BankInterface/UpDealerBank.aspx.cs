using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Citic_Web.BankInterface
{
    public partial class UpDealerBank : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DealerBand();
                BankList();
            }
        }
        private DataTable DtList(string Sql)
        {
            return DealerBll.GetBankID_DealerID_BankName_List(Sql).Tables[0];
        }
        private void DealerBand()
        {
            this.Ddl_Dealer.DataTextField = "DealerName";
            this.Ddl_Dealer.DataValueField = "ID";
            this.Ddl_Dealer.DataSource = DtList("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 order by D_L.DealerName");
            this.Ddl_Dealer.DataBind();
            this.Ddl_Dealer.Items.Insert(0, new FineUI.ListItem("——请选择经销商——", "-1"));
            this.Ddl_Dealer.SelectedIndex = 0;
        }
        protected void Ddl_Dealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.Ddl_Dealer.SelectedValue.Equals("-1"))
            {
                DataTable dt = DtList(string.Format("and ID='{0}'", this.Ddl_Dealer.SelectedValue.ToString()));
                this.LblBank.Text = dt.Rows[0]["BankName"].ToString();
                this.LblBrandName.Text = dt.Rows[0]["BrandName"].ToString();
                this.LblDealerID.Text = dt.Rows[0]["DealerID"].ToString();
                this.LblBankID.Text = dt.Rows[0]["BankID"].ToString();
            }
            else
            {
                this.LblBank.Text = "";
                this.LblBrandName.Text = "";
                this.LblDealerID.Text = "";
                this.LblBankID.Text = "";
            }
        }
        private void BankList()
        {
            this.Ddl_BankList.DataTextField = "BankName";
            this.Ddl_BankList.DataValueField = "BankID";
            this.Ddl_BankList.DataSource = BankBll.GetList("");
            this.Ddl_BankList.DataBind();
            this.Ddl_BankList.Items.Insert(0, new FineUI.ListItem("——请选择合作银行——", "-1"));
            this.Ddl_Dealer.SelectedIndex = 0;
        }
        protected void Btn_Add_Search_Click(object sender, EventArgs e)
        {
            if (!this.Ddl_Dealer.SelectedValue.Equals("-1") && !this.Ddl_BankList.SelectedValue.Equals("-1"))
            {

                string tb_Dealer_Bank_List_id = this.Ddl_Dealer.SelectedValue.ToString();       //合作表id
                string DealerID = this.LblDealerID.Text.Trim().ToString();      //经销商id
                string DealerName = this.Ddl_Dealer.SelectedText.Trim().ToString(); //经销商名称
                string BankID=this.LblBankID.Text.Trim().ToString();        //原合作行id
                string BankName = this.LblBank.Text.Trim().ToString(); //原合作银行名称
                string UpBankID = this.Ddl_BankList.SelectedValue.ToString();   //需修改的银行id
                string UpBankName = this.Ddl_BankList.SelectedText.Trim().ToString();   //需修改的银行名称
                string CreateId = CurrentUser.UserId.ToString();
                string CreateName = CurrentUser.TrueName.Trim().ToString();
                string Sql = string.Format(@"insert into tb_UpDealerBank (tb_Dealer_Bank_List_id,DealerID,DealerName,BankName,UpBankID,UpBankName,Statu,CreateId,CreateTime,CreateName,BankID)
values ('{0}','{1}','{2}','{3}','{4}','{5}',0,'{6}',GETDATE(),'{7}','{8}')", tb_Dealer_Bank_List_id, DealerID, DealerName, BankName, UpBankID, UpBankName, CreateId, CreateName, BankID);
                List<string> list = new List<string>();
                list.Add(Sql);
                if (CarBll.SqlTran(list) > 0)
                {
                    FineUI.Alert.ShowInTop("提交成功", FineUI.MessageBoxIcon.Information);
                }
                else
                {
                    FineUI.Alert.ShowInTop("提交失败", FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("修改条件不符合", FineUI.MessageBoxIcon.Error);
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            string Sql = "select * from tb_UpDealerBank order by CreateTime desc";
            DataTable dt = Dealer_BankBll.Query(Sql);
            G_UpList.DataSource = dt;
            G_UpList.DataBind();
        }
        protected void G_UpList_RowDataBound(object sender, FineUI.GridRowEventArgs e)
        {
            string Statu = G_UpList.Rows[e.RowIndex].Values[3].ToString();
            switch (Statu)
            {
                case "0":
                    G_UpList.Rows[e.RowIndex].Values[3] = "待修改";
                    break;
                case "1":
                    G_UpList.Rows[e.RowIndex].Values[3] = "已修改";
                    break;
                default:
                    G_UpList.Rows[e.RowIndex].Values[3] = "未知";
                    break;
            }
        }
    }
}