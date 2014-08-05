using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Citic_Web.InspectionFrequency
{
    public partial class InspectionDayTableUpdate : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID = int.Parse(Request.QueryString["ID"].ToString());
                DataSet ds = new Citic.BLL.InspectionDay().GetList("id = " + ID + " and isDel=0");
                this.txt_Area.SelectedValue = ds.Tables[0].Rows[0]["Area"].ToString();      //区域中心
                this.txt_Rummager.Text = ds.Tables[0].Rows[0]["Rummager"].ToString();       //检查人员
                this.txt_DealerName.Text = ds.Tables[0].Rows[0]["DealerName"].ToString();       //经销店名称
                this.txt_Bank.Text = ds.Tables[0].Rows[0]["Bank"].ToString();           //合作银行
                this.txt_BrandName.Text = ds.Tables[0].Rows[0]["BrandName"].ToString();     //品牌
                this.txt_SupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();       //监管员
                this.txt_Model.SelectedValue = ds.Tables[0].Rows[0]["Model"].ToString();        //监管模式
                this.txt_Inventory.Text = ds.Tables[0].Rows[0]["Inventory"].ToString();     //库存
                this.txt_QuartersLedger.Text = ds.Tables[0].Rows[0]["QuartersLedger"].ToString();       //总部总账
                this.txt_MainProblem.Text = ds.Tables[0].Rows[0]["MainProblem"].ToString();     //主要问题
                this.txt_Remark.Text = ds.Tables[0].Rows[0]["Remark"].ToString();       //备注
            }
        }
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(Request.QueryString["ID"].ToString());
            string Area = this.txt_Area.SelectedValue;
            string Rummager = this.txt_Rummager.Text;
            string DealerName = this.txt_DealerName.Text;
            string Bank = this.txt_Bank.Text;
            string BrandName = this.txt_BrandName.Text;
            string SupervisorName = this.txt_SupervisorName.Text;
            string Model = this.txt_Model.SelectedValue;
            string Inventory = this.txt_Inventory.Text;
            string QuartersLedger = this.txt_QuartersLedger.Text;
            string MainProblem = this.txt_MainProblem.Text;
            string Remark = this.txt_Remark.Text;
            string sql = "update tb_InspectionDay set Area='" + Area + "',Rummager='" + Rummager + "',DealerName='" + DealerName + "',Bank='" + Bank + "',BrandName='" + BrandName + "',SupervisorName='" + SupervisorName + "',Model='" + Model + "',Inventory='" + Inventory + "',QuartersLedger='" + QuartersLedger + "',MainProblem='" + MainProblem + "',Remark='" + Remark + "' where id=" + ID + "";
            int number = new Citic.BLL.InspectionDay().ExecuteSql(sql);
            if (number > 0)
            {
                FineUI.Alert.Show("修改成功！", FineUI.MessageBoxIcon.Information);
            }
            else
            {
                FineUI.Alert.Show("修改失败！", FineUI.MessageBoxIcon.Error);
            }
        }
    }
}