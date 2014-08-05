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
                int ID = int.Parse(Request.QueryString["ID"]);
                int Statu = int.Parse(Request.QueryString["Statu"]);
                EnabledText(Statu);
                DataSet ds = new Citic.BLL.InspectionFrequency().GetList(" ID='" + ID + "' and IsDel=0");
                this.txt_Area.Text = ds.Tables[0].Rows[0]["Area"].ToString();
                this.txt_DealerName.Text = ds.Tables[0].Rows[0]["DealerName"].ToString();
                this.txt_Bank.Text = ds.Tables[0].Rows[0]["Bank"].ToString();
                this.txt_BrandName.Text = ds.Tables[0].Rows[0]["BrandName"].ToString();
                this.txt_SupervisorName.Text = ds.Tables[0].Rows[0]["SupervisorName"].ToString();
                this.txt_CheckProblem.Text = ds.Tables[0].Rows[0]["CheckProblem"].ToString();
                this.txt_FinancialCenter1.Text = ds.Tables[0].Rows[0]["FinancialCenter"].ToString();
                this.txt_RiskControl.Text = ds.Tables[0].Rows[0]["RiskControl"].ToString();
                this.txt_QuartersLedger.Text = ds.Tables[0].Rows[0]["QuartersLedger"].ToString();
                this.txt_FinancialCenter.Text = ds.Tables[0].Rows[0]["FinancialCenter"].ToString();
                switch (Statu)
                {
                    case 1:
                        this.SF_Update.Title = Convert.ToDateTime(ds.Tables[0].Rows[0]["CreateTime"]).ToLongDateString() + "视频检查追踪表（汽车业务）";
                        break;
                    case 2:
                        this.SF_Update.Title = "总部总账问题";
                        break;
                    case 3:
                        this.SF_Update.Title = "需持续追踪解决问题";
                        this.txt_HistoryTime.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["HistoryTime"]).ToString("yyyy-MM-dd");
                        break;
                }



            }
        }
        #region 控制显示文本框
        /// <summary>
        /// 根据状态显示不同文本框 2013年8月12日
        /// </summary>
        /// <param name="Statu"></param>
        private void EnabledText(int Statu)
        {
            switch (Statu)
            {
                case 1:

                    txt_QuartersLedger.Hidden = true;          //总账
                    txt_FinancialCenter.Hidden = true;         //处理结果
                    txt_HistoryTime.Hidden = true;             //历史检查时间
                    break;
                case 2:
                    txt_SupervisorName.Hidden = true;          //监管员
                    txt_CheckProblem.Hidden = true;            //检查问题
                    txt_FinancialCenter1.Hidden = true;       //汽车/产业金融中心处理结果
                    txt_RiskControl.Hidden = true;         //风控部处理结果
                    txt_AdminDepartment.Hidden = true;         //管理中心处理结果
                    txt_HistoryTime.Hidden = true;             //历史检查时间
                    break;
                case 3:
                    txt_FinancialCenter1.Hidden = true;       //汽车/产业金融中心处理结果
                    txt_RiskControl.Hidden = true;         //风控部处理结果
                    txt_AdminDepartment.Hidden = true;         //管理中心处理结果
                    txt_QuartersLedger.Hidden = true;          //总账
                    break;
            }
        }
        #endregion

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            int Statu = int.Parse(Request.QueryString["Statu"]);
            int ID = int.Parse(Request.QueryString["ID"]); 
            string Area = this.txt_Area.Text.Trim();        //检查区域
            string DealerName = this.txt_DealerName.Text.Trim();        //经销商名称
            string Bank = this.txt_Bank.Text.Trim();        //银行
            string BrandName = this.txt_BrandName.Text.Trim();  //品牌
            string SupervisorName = this.txt_SupervisorName.Text.Trim();    //监管员
            string CheckProblem = this.txt_CheckProblem.Text.Trim();        //检查问题
            string FinancialCenter1 = this.txt_FinancialCenter1.Text.Trim(); //汽车/产业金融中心处理结果
            string RiskControl = this.txt_RiskControl.Text.Trim();      //风控部处理结果
            string AdminDepartment = this.txt_AdminDepartment.Text.Trim();  //管理中心处理结果
            string QuartersLedger = this.txt_QuartersLedger.Text.Trim();        //总部总账问题
            string FinancialCenter = this.txt_FinancialCenter.Text.Trim();      //处理结果
            string HistoryTime = this.txt_HistoryTime.Text.Trim();          //历史检查时间
            string sql = "update tb_InspectionFrequency set Area ='" + Area + "',DealerName='" + DealerName + "',Bank='" + Bank + "',BrandName='" + BrandName + "',";
            switch (Statu)
            {
                case 1:
                    sql += "SupervisorName='" + SupervisorName + "',CheckProblem='" + CheckProblem + "',FinancialCenter='" + FinancialCenter1 + "',RiskControl='" + RiskControl + "',AdminDepartment='" + AdminDepartment + "' where ID=" + ID + " ";
                    break;
                case 2:
                    sql += "QuartersLedger='" + QuartersLedger + "',FinancialCenter='" + FinancialCenter + "' where ID=" + ID + " ";
                    break;
                case 3:
                    sql += "SupervisorName='" + SupervisorName + "',CheckProblem='" + CheckProblem + "',HistoryTime='" + HistoryTime + "',FinancialCenter='" + FinancialCenter + "' where ID=" + ID + " ";
                    break;
            }
            int number = new Citic.BLL.InspectionFrequency().ExecuteSql(sql);
            if (number>0)
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