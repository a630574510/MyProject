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
using System.Text.RegularExpressions;
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
                        txtEnabled(RoleId);
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        this.Btn_Update.Enabled = true;
                        txtEnabled(RoleId);
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        this.Btn_Update.Enabled = true;
                        txtEnabled(RoleId);
                        break;
                    case 6:         //6为品牌专员
                        this.Btn_Update.Enabled = true;
                        txtEnabled(RoleId);
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员           监管员可以修改，但只能修改回款金额，备注
                        this.Btn_Update.Enabled = true;
                        txtEnabled(RoleId);
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
                this.lbl_DraftNo.Text = car.DraftNo;
                this.lbl_Dealer.Text = car.DealerName;
                this.txt_Vin.Text = car.Vin;
                this.txt_KeyNumber.Text = car.KeyNumber;
                this.txt_CarModel.Text = car.CarModel;
                this.txt_CarColor.Text = car.CarColor;
                this.txt_EngineNo.Text = car.EngineNo;
                this.txt_QualifiedNo.Text = car.QualifiedNo;
                if (car.QualifiedNoDate.ToString().Length == 0)
                {
                    this.dpIssueDate.Text = car.QualifiedNoDate.ToString();
                }
                else
                {
                    this.dpIssueDate.SelectedDate = Convert.ToDateTime(car.QualifiedNoDate.ToString());
                }

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
            string QualifiedNoDate = this.dpIssueDate.SelectedDate == null ? "QualifiedNoDate = NULL" : string.Format("QualifiedNoDate='{0}'", this.dpIssueDate.SelectedDate);       //合格证发证日期
            //string QualifiedNoDate = string.Empty;       //合格证发证日期
            string Remarks = this.txt_OTHER.Text.Trim().ToString();         //备注
            string KeyNumber = this.txt_KeyNumber.Text.Trim().ToString();     //钥匙号
            string Up_DraftNo = this.ddl_DraftNo.SelectedValue.ToString();       //修改后汇票
            string DraftNo = this.lbl_DraftNo.Text.Trim().ToString();         //原汇票
            string CarClass = this.txt_CarClass.Text.Trim().ToString();       //车辆分类
            string Displacement = this.txt_Displacement.Text.Trim();          //排量
            int ID = int.Parse(this.lbl_ID.Text.Trim().ToString());        //id
            string sql = "update " + tb_Name + " set DraftNo='" + Up_DraftNo + "',CarColor='" + CarColor + "',CarModel='" + CarModel + "',EngineNo='" + EngineNo + "'," + QualifiedNoDate + ",QualifiedNo='" + QualifiedNo + "',KeyCount='" + KeyCount + "',KeyNumber='" + KeyNumber + "',CarCost='" + CarCost + "',ReturnCost='" + ReturnCost + "',UpdateID='" + CurrentUser.UserId + "',UpdateTime=GETDATE(),CarClass='" + CarClass + "',Displacement='" + Displacement + "' where ID='" + ID + "'";
            string[] DraftNoList = { Up_DraftNo, DraftNo };
            string CheckingCarCost = @"^(([1-9]\d{0,9})|0)(\.\d{1,2})?$";
            if (Regex.IsMatch(ReturnCost, CheckingCarCost))
            {
                int number = new Citic.BLL.Inspection().ExecuteSql(sql);
                if (number > 0)
                {
                    DraftBll.UpdateDraftMoney(DraftNoList);
                    string CloseStr = FineUI.ActiveWindow.GetHideReference();
                    FineUI.Alert.ShowInTop("修改成功", "提示", CloseStr);
                    //FineUI.Alert.ShowInTop("修改成功", FineUI.MessageBoxIcon.Information);
                }
                else
                {
                    FineUI.Alert.ShowInTop("修改失败", FineUI.MessageBoxIcon.Information);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("回款金额不正确", FineUI.MessageBoxIcon.Error);
            }


        }

        private void txtEnabled(int RoleId)
        {
            if (RoleId == 1 || RoleId == 3 || RoleId == 5 || RoleId == 6)
            {
                this.ddl_DraftNo.Readonly = false;      //汇票号
                this.txt_CarModel.Enabled = true;       //车辆型号
                this.txt_CarColor.Enabled = true;       //颜色
                this.txt_EngineNo.Enabled = true;       //发动机号
                this.dpIssueDate.Enabled = true;        //合格证发证日期
                this.ddl_KeyCount.Readonly = false;     //钥匙数
                this.txt_KeyNumber.Enabled = true;      //钥匙号
                this.txt_Car_Money.Enabled = true;      //车辆金额
                this.txt_Return_Money.Enabled = true;   //回款金额
                this.txt_Displacement.Enabled = true;       //排量
                this.txt_CarClass.Enabled = true;       //车辆分类
                this.txt_OTHER.Enabled = true;      //备注
            }
            else if (RoleId == 10)
            {

                this.txt_OTHER.Enabled = true;          //备注
                this.txt_Return_Money.Enabled = true;   //回款金额
            }
        }
    }
}