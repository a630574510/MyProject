using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Citic.BLL;
using Citic.Model;
namespace Citic_Web.Car
{
    public partial class Update_Car : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        this.Btn_Update.Enabled = true;
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        this.Btn_Update.Enabled = true;
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        break;
                    case 6:         //6为品牌专员
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        this.Btn_Update.Enabled = false;
                        this.Btn_Update.ToolTip = "您没权限修改车辆信息";
                        break;
                    default:
                        this.Btn_Update.Enabled = false;
                        break;
                }
                string Vin = Request.QueryString["Vin"].ToString();
                string BankID = Request.QueryString["BankID"].ToString();
                string DealerID = Request.QueryString["DealerID"].ToString();
                string tb_Name = "tb_Car_" + BankID + "_" + DealerID + "";
                DataTable dt = DraftBll.GetList("BankID='" + BankID + "' and DealerID='" + DealerID + "'").Tables[0];
                this.ddl_DraftNo.DataTextField = "DraftNo";
                this.ddl_DraftNo.DataValueField = "DraftNo";
                this.ddl_DraftNo.DataSource = dt;
                this.ddl_DraftNo.DataBind();
                Citic.Model.Car car = CarBll.GetModel(Vin, tb_Name);

                this.ddl_DraftNo.SelectedValue = car.DraftNo;
                this.lbl_Dealer.Text = car.DealerName;
                this.txt_Vin.Text = car.Vin;
                this.txt_KeyNumber.Text = car.KeyNumber;
                this.txt_CarModel.Text = car.CarModel;
                this.txt_CarColor.Text = car.CarColor;
                this.txt_EngineNo.Text = car.EngineNo;
                this.txt_QualifiedNo.Text = car.QualifiedNo;
                this.dpIssueDate.Text = car.QualifiedNoDate.ToString() == "" ? "" : car.QualifiedNoDate.ToString();
                this.ddl_KeyCount.SelectedValue = car.KeyCount.ToString();
                this.txt_Car_Money.Text = car.CarCost;
                this.txt_Return_Money.Text = car.ReturnCost;
                this.txt_OTHER.Text = car.Remarks;
                this.txt_Displacement.Text = car.Displacement;
                this.txt_CarClass.Text = car.CarClass;
                this.lbl_ID.Text = car.ID.ToString();
                this.Btn_Close.OnClientClick = FineUI.ActiveWindow.GetHideReference();
                //this.Btn_Close.OnClientClick = FineUI.ActiveWindow.GetConfirmHidePostBackReference();
            }
        }
        /// <summary>
        /// 修改事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            string BankID = Request.QueryString["BankID"].ToString();
            string DealerID = Request.QueryString["DealerID"].ToString();
            string tb_Name = "tb_Car_" + BankID + "_" + DealerID + "";      //拼接表名

            string Vin = this.txt_Vin.Text.Trim().ToString();     //车架
            string CarModel = this.txt_CarModel.Text.Trim().ToString();  //型号
            string CarColor = this.txt_CarColor.Text.Trim().ToString(); //颜色
            string EngineNo = this.txt_EngineNo.Text.Trim().ToString();   //发动机
            int KeyCount = int.Parse(this.ddl_KeyCount.SelectedText);   //钥匙
            string QualifiedNo = this.txt_QualifiedNo.Text.Trim().ToString(); //合格证
            string CarCost = this.txt_Car_Money.Text.Trim().ToString();     //车辆金额
            string ReturnCost = this.txt_Return_Money.Text;   //回款金额
            string QualifiedNoDate = this.dpIssueDate.SelectedDate.ToString();       //合格证发证日期
            string Remarks = this.txt_OTHER.Text.Trim().ToString();         //备注
            string KeyNumber = this.txt_KeyNumber.Text.Trim().ToString();     //钥匙号
            string DraftNo = this.ddl_DraftNo.SelectedValue.ToString();       //汇票
            string CarClass = this.txt_CarClass.Text.Trim().ToString();       //车辆分类
            string Displacement = this.txt_Displacement.Text.Trim();          //排量
            int ID = int.Parse(this.lbl_ID.Text.Trim().ToString());        //id
            string sql = "update " + tb_Name + " set DraftNo='" + DraftNo + "',CarColor='" + CarColor + "',CarModel='" + CarModel + "',EngineNo='" + EngineNo + "',QualifiedNoDate='" + QualifiedNoDate + "',QualifiedNo='" + QualifiedNo + "',KeyCount='" + KeyCount + "',KeyNumber='" + KeyNumber + "',CarCost='" + CarCost + "',ReturnCost='" + ReturnCost + "',UpdateID='" + CurrentUser.UserId + "',UpdateTime=GETDATE(),CarClass='" + CarClass + "',Displacement='" + Displacement + "' where ID='" + ID + "'";
            int number = new Citic.BLL.Inspection().ExecuteSql(sql);
            if (number > 0)
            {
                string CloseStr = FineUI.ActiveWindow.GetHideReference();
                FineUI.Alert.ShowInTop("修改成功", "提示", CloseStr);
                //FineUI.Alert.ShowInTop("修改成功", FineUI.MessageBoxIcon.Information);
            }
            else
            {
                FineUI.Alert.ShowInTop("修改失败", FineUI.MessageBoxIcon.Information);
            }


        }
    }
}