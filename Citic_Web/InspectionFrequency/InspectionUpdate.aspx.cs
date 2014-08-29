using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace Citic_Web.InspectionFrequency
{
    public partial class InspectionUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurrentUser.RoleId == 26 || CurrentUser.RoleId == 1)
                {
                    this.btn_Update.Enabled = true;
                    this.btn_Update.ToolTip = "";
                }
                else
                {
                    this.btn_Update.ToolTip = "<span style='color:Red'>如需修改数据，请联系视频部经理</span>";
                }
                int ID = int.Parse(Request.QueryString["ID"]);
                DataSet ds = new Citic.BLL.Inspection().GetList(" ID='" + ID + "' and IsDel=0");
                this.txt_Area.Text = ds.Tables[0].Rows[0]["Area"].ToString();
                this.txt_DealerName.Text = ds.Tables[0].Rows[0]["DealerName"].ToString();
                this.txt_Bank.Text = ds.Tables[0].Rows[0]["Bank"].ToString();
                this.txt_BrandName.Text = ds.Tables[0].Rows[0]["BrandName"].ToString();
                this.txt_Model.SelectedValue = ds.Tables[0].Rows[0]["Model"].ToString();
                this.txt_SupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();
                this.txt_Inventory.Text = ds.Tables[0].Rows[0]["Inventory"].ToString();
                this.txt_QuartersLedger.Text = ds.Tables[0].Rows[0]["QuartersLedger"].ToString();
                this.cb_QuartersLedger.Checked = ds.Tables[0].Rows[0]["QuartersLedgerStatu"].ToString() == "1" ? true : false;
                this.txt_MainProblem.Text = ds.Tables[0].Rows[0]["MainProblem"].ToString();
                this.cb_MainProblem.Checked = ds.Tables[0].Rows[0]["MainProblemStatu"].ToString() == "1" ? true : false;
                this.DP_HistoryDate.Text = ds.Tables[0].Rows[0]["HistoryDate"].ToString();
                this.cb_HistoryDate.Checked = ds.Tables[0].Rows[0]["ContinueStatu"].ToString() == "1" ? true : false;
                this.txt_Remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();
            }
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"]);
            string Area = this.txt_Area.Text.Trim();        //检查区域      //代用给评价
            string DealerName = this.txt_DealerName.Text.Trim();        //经销商名称
            string Bank = this.txt_Bank.Text.Trim();        //银行
            string BrandName = this.txt_BrandName.Text.Trim();  //品牌
            string SupervisorName = this.txt_SupervisorName.Text.Trim();    //监管员
            string Model = this.txt_Model.SelectedText;
            string Inventory = this.txt_Inventory.Text.Trim();      //库存
            string QuartersLedger = this.txt_QuartersLedger.Text.Trim();    //总账问题
            string QuartersLedgerStatu = this.cb_QuartersLedger.Checked == true ? "1" : "0";    //总账是否选中
            string MainProblem = this.txt_MainProblem.Text.Trim();  //主要问题
            string MainProblemStatu = this.cb_MainProblem.Checked == true ? "1" : "0";    //主要是否选中
            string HistoryDate = this.DP_HistoryDate.Text.Trim();   //历史检查时间
            string ContinueStatu = this.cb_HistoryDate.Checked == true ? "1" : "0"; //历史是否选中
            string Remark = this.txt_Remark.Text.Trim();
            string Up_Sql = string.Format("update tb_Inspection set DealerName='{0}',Bank='{1}',BrandName='{2}',SupervisorName='{3}',Model='{4}',Inventory='{5}',QuartersLedger='{6}',QuartersLedgerStatu='{7}',MainProblem='{8}',MainProblemStatu='{9}',HistoryDate='{10}',ContinueStatu='{11}',DelId='{12}',DelTime=GETDATE() where ID='{13}'", DealerName, Bank, BrandName, SupervisorName, Model, Inventory, QuartersLedger, QuartersLedgerStatu, MainProblem, MainProblemStatu, HistoryDate, ContinueStatu, CurrentUser.UserId, ID.ToString());
            int number = new Citic.BLL.Inspection().ExecuteSql(Up_Sql);
            if (number > 0)
            {
                //FineUI.ActiveWindow.GetHideReference();
                FineUI.Alert.ShowInTop("修改成功！", "提示", FineUI.ActiveWindow.GetHideReference());
            }
            else
            {
                FineUI.Alert.ShowInTop("修改失败！");
            }
        }
    }
}