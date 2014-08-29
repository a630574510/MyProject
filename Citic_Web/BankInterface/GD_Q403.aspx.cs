using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Citic_Web.Car;
using System.Text.RegularExpressions;

namespace Citic_Web.BankInterface
{
    public partial class GD_Q403 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDealer();
            }

        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            if (!this.ddl_Dealer.SelectedValue.Equals("-1"))
            {

                if (this.txt_Vin.Text.Trim().Length != 0)
                {
                    DataTable dt = (DataTable)ViewState["DealerList"];
                    DataRow[] dr = dt.Select(string.Format("ID='{0}'", this.ddl_Dealer.SelectedValue));
                    string tb_Name = string.Format("tb_Car_{0}_{1}", dr[0].ItemArray[2].ToString(), dr[0].ItemArray[0].ToString());
                    string sql = "select (select SEND_CAR_ID from GD_DispatchCarInfo where DJ_NO='" + this.txt_Vin.Text.Trim() + "') as SEND_CAR_ID,* from " + tb_Name + " car left join GD_BillInfo bf on car.DraftNo=bf.BF_NO where car.Vin='" + this.txt_Vin.Text.Trim() + "'  and  car.IsDelete=0 and car.GD_ID<>''";
                    DataSet ds = new Citic.BLL.Car().GetList(sql);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        this.txt_HXCS_ID.Text = ds.Tables[0].Rows[0]["HXCS_ID"].ToString();     //核心厂商id
                        this.txt_JXS_ID.Text = ds.Tables[0].Rows[0]["JXS_ID"].ToString();       //经销商id
                        this.txt_PI_ID.Text = ds.Tables[0].Rows[0]["GD_ID"].ToString();     //合格证id
                        this.txt_SEND_CAR_ID.Text = ds.Tables[0].Rows[0]["SEND_CAR_ID"].ToString(); //发车明细ID
                        this.txt_PI_NO.Text = ds.Tables[0].Rows[0]["QualifiedNo"].ToString();     //合格证编号
                        this.txt_DJ_NO.Text = ds.Tables[0].Rows[0]["Vin"].ToString();     //车辆识别代号
                        this.txt_CAR_MODEL.Text = ds.Tables[0].Rows[0]["CarModel"].ToString(); //汽车型号
                        this.txt_ENGINE_MODEL.Text = ds.Tables[0].Rows[0]["EngineNo"].ToString();  //发动机号
                        this.txt_CAR_BRAND.Text = ds.Tables[0].Rows[0]["BrandName"].ToString();     //品牌
                        this.txt_CAR_COLOR.Text = ds.Tables[0].Rows[0]["CarColor"].ToString();     //颜色
                        this.txt_PI_AMOUNT.Text = ds.Tables[0].Rows[0]["CarCost"].ToString();     //合格证金额
                        this.txt_BF_ID.Text = ds.Tables[0].Rows[0]["BF_ID"].ToString();     //对应票据id
                        this.txt_PI_STATUS.Text = STATUS(ds.Tables[0].Rows[0]["Statu"].ToString());     //合格证状态
                        this.txt_CAR_STATUS.Text = STATUS(ds.Tables[0].Rows[0]["Statu"].ToString());   //车辆状态
                        this.ddl_KEY_NUM.SelectedValue = ds.Tables[0].Rows[0]["KeyCount"].ToString();  //钥匙数量
                        //this.txt_RANGE_FLAG.Text = ds.Tables[0].Rows[0]["RANGE_FLAG"].ToString();   //是否超范围车辆
                        this.txt_MATURE_DATE.Text = ds.Tables[0].Rows[0]["BNFO_BILL_MATURE_DT"].ToString();  //合格证到期日
                        //this.txt_CAR_STOCK_ADD.Text = ds.Tables[0].Rows[0]["CAR_STOCK_ADD"].ToString(); //车辆在库地址
                    }
                    else
                    {
                        FineUI.Alert.ShowInTop("找不到此车架信息，请核对车架", FineUI.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.ShowInTop("请输入车架号", FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("请选择经销商", FineUI.MessageBoxIcon.Error);
            }
        }
        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            //车辆金额正则，大于0的浮点数
            string CheckingCarCost = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
            if (!Regex.IsMatch(txt_PI_AMOUNT.Text.Trim(), CheckingCarCost))     //金额
            {
                FineUI.Alert.ShowInTop("车辆金额有误，请认真核对", FineUI.MessageBoxIcon.Error);
            }
            else if (Add_Car.CheckBadStr(txt_CAR_MODEL.Text.Trim()))        //汽车型号
            {
                FineUI.Alert.ShowInTop("车辆型号包含特殊字符，请认真核对", FineUI.MessageBoxIcon.Error);
            }
            else if (Add_Car.CheckBadStr(txt_ENGINE_MODEL.Text.Trim()))        //发动机号
            {
                FineUI.Alert.ShowInTop("车辆发动机包含特殊字符，请认真核对", FineUI.MessageBoxIcon.Error);
            }
            else if (Add_Car.CheckBadStr(txt_CAR_BRAND.Text.Trim()))        //品牌
            {
                FineUI.Alert.ShowInTop("车辆品牌包含特殊字符，请认真核对", FineUI.MessageBoxIcon.Error);
            }
            else if (Add_Car.CheckBadStr(txt_CAR_COLOR.Text.Trim()))        //颜色
            {
                FineUI.Alert.ShowInTop("车辆颜色包含特殊字符，请认真核对", FineUI.MessageBoxIcon.Error);
            }
            else if (this.txt_DJ_NO.Text.Trim().Length == 0)      //车架为空
            {
                FineUI.Alert.ShowInTop("请重新查询信息", FineUI.MessageBoxIcon.Error);
            }
            else
            {
                string[] txt = this.ddl_Dealer.SelectedValue.Split('_');        //获取经销商信息
                string tb_Name = "tb_Car_" + txt[0] + "_" + txt[1];  //拼接表名
                string FTranCode = "Q403";      //交易码
                string TrmSeqNum = DateTime.Now.ToString("yyyyHHddmmssffff");     //终端流水号
                string xmltxt = "<CHANNEL_CODE>0231J001</CHANNEL_CODE>";        //接入机构号
                xmltxt += "<HXCS_ID>" + txt_HXCS_ID.Text.Trim() + "</HXCS_ID>";         //核心厂商id
                xmltxt += "<JXS_ID>" + txt_JXS_ID.Text.Trim() + "</JXS_ID>";            //经销商id
                xmltxt += "<PI_ID>" + txt_PI_ID.Text.Trim() + "</PI_ID>";               //合格证id
                xmltxt += "<SEND_CAR_ID>" + this.txt_SEND_CAR_ID.Text.Trim() + "</SEND_CAR_ID>";   //发车明细id  
                xmltxt += "<PI_NO>" + txt_PI_NO.Text.Trim() + "</PI_NO>";               //合格证编号
                xmltxt += "<DJ_NO>" + txt_DJ_NO.Text.Trim() + "</DJ_NO>";               //车辆识别代号
                xmltxt += "<CAR_MODEL>" + txt_CAR_MODEL.Text.Trim() + "</CAR_MODEL>";   //汽车型号
                xmltxt += "<ENGINE_MODEL>" + txt_ENGINE_MODEL.Text.Trim() + "</ENGINE_MODEL>";//发动机号
                xmltxt += "<CAR_BRAND>" + txt_CAR_BRAND.Text.Trim() + "</CAR_BRAND>"; //品牌
                xmltxt += "<CAR_COLOR>" + txt_CAR_COLOR.Text.Trim() + "</CAR_COLOR>";   //颜色
                xmltxt += "<PI_AMOUNT>" + txt_PI_AMOUNT.Text.Trim() + "</PI_AMOUNT>";   //合格证金额
                xmltxt += "<PI_STATUS>400</PI_STATUS>";         //合格证状态
                xmltxt += "<CAR_STATUS>400</CAR_STATUS>";      //车辆状态
                xmltxt += "<KEY_NUM>" + this.ddl_KEY_NUM.SelectedText.Trim() + "</KEY_NUM>";     //钥匙数量
                xmltxt += "<RANGE_FLAG>0</RANGE_FLAG>";      //是否超范围
                xmltxt += "<MATURE_DATE>" + txt_MATURE_DATE.Text.Trim() + "</MATURE_DATE>";  //合格证到期日
                xmltxt += "<BF_ID>" + txt_BF_ID.Text.Trim() + "</BF_ID>";       //对应票据id
                xmltxt += "<CAR_STOCK_ADD>" + txt_CAR_STOCK_ADD.Text.Trim() + "</CAR_STOCK_ADD>";   //车辆在库地址
                xmltxt += "<REMARK>" + txt_REMARK.Text.Trim() + "</REMARK>";     //备注
                string UpdateCarSql = "update " + tb_Name + " set CarModel=''" + txt_CAR_MODEL.Text.Trim() + "'',EngineNo=''" + txt_ENGINE_MODEL.Text.Trim() + "'',CarColor=''" + txt_CAR_COLOR.Text.Trim() + "'',CarCost=''" + txt_PI_AMOUNT.Text.Trim() + "'',KeyCount=''" + this.ddl_KEY_NUM.SelectedText.Trim() + "'' where GD_ID=''" + txt_PI_ID.Text.Trim() + "'' and Vin=''" + txt_DJ_NO.Text.Trim() + "''";

                string sql = "insert into tb_ToGDMessage (FTranCode,TrmSeqNum,RequestSource,RequestPe_ID,Status,RequestDate,insertValue,PI_ID) values('" + FTranCode + "','" + TrmSeqNum + "','" + xmltxt + "','1',0,GETDATE(),'" + UpdateCarSql + "','" + txt_PI_ID.Text.Trim() + "')";

                int Num = new Citic.BLL.Inspection().ExecuteSql(sql);
                if (Num > 0)
                {
                    FineUI.Alert.ShowInTop("提交成功，请联系光大客户经理同意修改");
                }
                else
                {
                    FineUI.Alert.ShowInTop("提交失败");
                }
            }
        }

        #region 绑定经销商
        /// <summary>
        /// 绑定经销商
        /// </summary>
        private void BindDealer()
        {
            try
            {
                DataTable dt = null;
                int RoleId = this.CurrentUser.RoleId;       //获取角色id

                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        dt = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and  D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        dt = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and  D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        int UserID_5 = this.CurrentUser.UserId;
                        dt = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=5 and UserID=" + UserID_5 + ") and  D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>''").Tables[0];
                        break;
                    case 6:         //6为品牌专员
                        int UserID_6 = this.CurrentUser.UserId;
                        dt = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=6 and UserID=" + UserID_6 + ") and  D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>''").Tables[0];
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        int SupID = this.CurrentUser.RelationID.Value;
                        dt = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and SupervisorID='" + SupID + "' and  D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                }
                this.ddl_Dealer.DataTextField = "DealerName";
                this.ddl_Dealer.DataValueField = "ID";
                ViewState["DealerList"] = dt;
                this.ddl_Dealer.DataSource = dt;
                this.ddl_Dealer.DataBind();
                ddl_Dealer.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));
            }
            catch
            {
                FineUI.Alert.ShowInTop("与服务器无法链接,经销商信息", FineUI.MessageBoxIcon.Error);
            }

        }
        #endregion

        #region 解析中信状态
        /// <summary>
        /// 解析中信本地状态
        /// </summary>
        /// <param name="Status"></param>
        /// <returns></returns>
        private string STATUS(string Status)
        {
            switch (Status)
            {
                case "0":
                    Status = "出库";
                    break;
                case "1":
                    Status = "在库";
                    break;
                case "2":
                    Status = "移动";
                    break;
                case "3":
                    Status = "在途";
                    break;
                case "4":
                    Status = "申请中";
                    break;
                default:
                    Status = "无法解析";
                    break;
            }
            return Status;
        }
        #endregion

        protected void ddl_Dealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txt_HXCS_ID.Text = "";     //核心厂商id
            this.txt_JXS_ID.Text = "";       //经销商id
            this.txt_PI_ID.Text = "";     //合格证id
            this.txt_SEND_CAR_ID.Text = ""; //发车明细ID
            this.txt_PI_NO.Text = "";     //合格证编号
            this.txt_DJ_NO.Text = "";     //车辆识别代号
            this.txt_CAR_MODEL.Text = ""; //汽车型号
            this.txt_ENGINE_MODEL.Text = "";  //发动机号
            this.txt_CAR_BRAND.Text = "";     //品牌
            this.txt_CAR_COLOR.Text = "";     //颜色
            this.txt_PI_AMOUNT.Text = "";     //合格证金额
            this.txt_BF_ID.Text = "";     //对应票据id
            this.txt_PI_STATUS.Text = "";     //合格证状态
            this.txt_CAR_STATUS.Text = "";   //车辆状态
            this.ddl_KEY_NUM.SelectedValue = "";  //钥匙数量
            //this.txt_RANGE_FLAG.Text = ds.Tables[0].Rows[0]["RANGE_FLAG"].ToString();   //是否超范围车辆
            this.txt_MATURE_DATE.Text = "";  //合格证到期日
            //this.txt_CAR_STOCK_ADD.Text = ds.Tables[0].Rows[0]["CAR_STOCK_ADD"].ToString(); //车辆在库地址
        }
    }
}