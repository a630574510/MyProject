using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using Citic.BLL;
using System.IO;
using FineUI;
namespace Citic_Web.Car
{
    public partial class OutBound_Car : BasePage
    {
        #region Load事件
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDealer();
            }
        }
        #endregion

        #region 查询事件
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            if (this.ddl_Dealer.SelectedValue == "-1")
            {
                FineUI.Alert.Show("请选择经销商", FineUI.MessageBoxIcon.Error);
            }
            else if (this.DDL_Bank.SelectedValue == "-1")
            {
                FineUI.Alert.Show("请选择银行", FineUI.MessageBoxIcon.Error);
            }
            else
            {
                string[] tb_Name_Count = this.DDL_Bank.SelectedValue.ToString().Split('_');
                string tb_Name = "tb_Car_" + tb_Name_Count[0] + "_" + tb_Name_Count[1].ToString();
                StringBuilder sb = new StringBuilder("(Statu='2' or Statu='1') and  IsDelete='0' ");
                if (!string.IsNullOrEmpty(this.txt_Vin.Text.Trim()))        //车架号
                {
                    string[] Vin = this.txt_Vin.Text.ToString().Split(',');
                    sb.Append(" and Vin like '%" + Vin[0].ToString().Trim() + "%'");
                    if (Vin.Length > 1)
                    {
                        for (int i = 1; i < Vin.Length; i++)
                        {
                            sb.Append(" or Vin like '%" + Vin[i] + "%'");
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(this.txt_Number_Order.Text.Trim()))      //汇票号 
                {
                    sb.Append(" and DraftNo like '%" + this.txt_Number_Order.Text.Trim() + "%'");
                }
                else if (!string.IsNullOrEmpty(this.txt_EngineNo.Text.Trim()))      //发动机
                {
                    string[] EngineNo = this.txt_EngineNo.Text.ToString().Split(',');
                    sb.Append(" and EngineNo like '%" + EngineNo[0].ToString().Trim() + "%'");
                    if (EngineNo.Length > 1)
                    {
                        for (int i = 1; i < EngineNo.Length; i++)
                        {
                            sb.Append(" or EngineNo like '%" + EngineNo[i] + "%'");
                        }
                    }
                }
                else if (!string.IsNullOrEmpty(this.txt_QualifiedNo.Text.Trim()))       //合格证
                {
                    string[] QualifiedNo = this.txt_QualifiedNo.Text.ToString().Split(',');
                    sb.Append(" and QualifiedNo like '%" + QualifiedNo[0].ToString().Trim() + "%'");
                    if (QualifiedNo.Length > 1)
                    {
                        for (int i = 1; i < QualifiedNo.Length; i++)
                        {
                            sb.Append(" or QualifiedNo like '%" + QualifiedNo[i] + "%'");
                        }
                    }
                }
                sb.Append(" order by TransitTime desc");
                DataSet ds = new Citic.BLL.Car().GetAllList(sb.ToString(), tb_Name);
                ViewState["Car_Transit_List"] = ds.Tables[0];
                this.G_Car_Removal.DataSource = (DataTable)ViewState["Car_Transit_List"];
                this.G_Car_Removal.DataBind();
            }
        }
        #endregion

        #region 翻页
        protected void G_Car_Removal_Page(object sender, FineUI.GridPageEventArgs e)
        {
            G_Car_Removal.PageIndex = e.NewPageIndex;
        }
        #endregion

        #region 绑定经销商
        /// <summary>
        /// 绑定经销商信息
        /// </summary>
        private void BindDealer()
        {
            try
            {
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        this.ddl_Dealer.EnableEdit = true;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 order by D_L.DealerName").Tables[0];
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        this.ddl_Dealer.EnableEdit = true;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 order by D_L.DealerName").Tables[0];
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        int UserID_5 = this.CurrentUser.UserId;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=5 and UserID=" + UserID_5 + ")").Tables[0];
                        break;
                    case 6:         //6为品牌专员
                        int UserID_6 = this.CurrentUser.UserId;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=6 and UserID=" + UserID_6 + ")").Tables[0];
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        int SupID = this.CurrentUser.RelationID.Value;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and SupervisorID='" + SupID + "' order by D_L.DealerName").Tables[0];
                        break;
                }
                DataTable da = ((DataTable)ViewState["DealerName"]).DefaultView.ToTable(true, "DealerName");
                this.ddl_Dealer.DataTextField = "DealerName";
                this.ddl_Dealer.DataValueField = "DealerName";
                this.ddl_Dealer.DataSource = da;
                this.ddl_Dealer.DataBind();
                this.ddl_Dealer.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));
            }
            catch
            {
                FineUI.Alert.ShowInTop("与服务器无法链接", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 经销商下拉列表事件
        /// <summary>
        /// 经销商下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_Dealer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Dealer.SelectedValue == "-1")
            {
                FineUI.Alert.ShowInTop("请选择经销商", FineUI.MessageBoxIcon.Error);
                DDL_Bank.SelectedIndex = 0;
                this.lbl_Cooperation_BrandName.Text = "";       //清空品牌文本
            }
            else
            {
                this.DDL_Bank.DataTextField = "BankName";
                this.DDL_Bank.DataValueField = "DealerID";
                //ViewState转换DataTable,查找经销商名称返回绑定
                DDL_Bank.DataSource = ((DataTable)ViewState["DealerName"]).Select("DealerName='" + ddl_Dealer.SelectedValue.ToString() + "'");
                DDL_Bank.DataBind();
                DDL_Bank.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));
            }
        }
        #endregion

        #region 银行列表事件
        protected void DDL_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Bank.SelectedValue.ToString() != "-1")
            {
                this.lbl_Cooperation_BrandName.Text = DDL_Bank.SelectedValue.ToString().Split('_')[3].ToString();
                DataRow[] dr = ((DataTable)ViewState["DealerName"]).Select("DealerName='" + ddl_Dealer.SelectedValue.ToString() + "' and BankName='" + DDL_Bank.SelectedText + "'");
                if (dr[0].ItemArray[3].ToString().Length > 0)
                {
                    this.Btn_Up_Removal.Enabled = false;
                    this.Btn_Up_Removal.ToolTip = "<span style='color:Red'>此经销商跟光大银行合作，不能手动出库</span>";
                }
                else
                {
                    this.Btn_Up_Removal.Enabled = true;
                    this.Btn_Up_Removal.ToolTip = "<span style='color:Red'>请注意填写回款金额</span>";
                }

            }
            else
            {
                FineUI.Alert.ShowInTop("请选择银行", FineUI.MessageBoxIcon.Error);
                this.lbl_Cooperation_BrandName.Text = "";       //清空品牌文本
            }

        }
        #endregion

        #region 申请出库
        /// <summary>
        /// 批量申请出库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Btn_Up_Removal_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_Car_Removal.GetModifiedDict();  //获取修改集合
            string sql = string.Empty;      //拼接sql语句
            //获取复选框
            int[] Index = G_Car_Removal.SelectedRowIndexArray;
            if (modifiedDict.Count > 0)
            {
                #region 获取权限角色
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                int CreateID = 0;
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        CreateID = CurrentUser.UserId;
                        break;
                    case 2:         //2为管理员
                        CreateID = CurrentUser.UserId;
                        break;
                    case 3:         //3为业务经理
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
                        CreateID = this.CurrentUser.RelationID.Value;
                        break;
                }
                #endregion
                //声明集合，存放需要执行的sql语句
                List<string> list = new List<string>();

                //状态历史表sql
                string sql_Car_Status = "insert into tb_Car_Status (Vin,StatusType,CreateID,CreateTime) ";

                string[] tb_Name_Count = DDL_Bank.SelectedValue.ToString().Split('_');        //获取下拉列表集合值

                string ErrorTxt = string.Empty;     //记录错误信息
                string BankID = tb_Name_Count[0].ToString();         //银行id
                string BankName = DDL_Bank.SelectedText.ToString();           //银行名称
                string DealerID = tb_Name_Count[1].ToString();           //经销商id
                string DealerName = ddl_Dealer.SelectedText.ToString();         //经销商名称
                string tb_Name = "tb_Car_" + BankID + "_" + DealerID;  //拼接表名
                string CheckingCarCost = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
                //出库sql语句
                string OutCar = "insert into tb_DBSX_List (BankID,BankName,DealerID,DealerName,DraftNo,Vin,ReqType,Content,[Status],CreateID,CreateTime,IsDelete) ";
                string CarListCount = string.Empty; //记录生成excel车辆信息
                int CountOut = 0;      //记录出库台数
                foreach (int rowIndex in modifiedDict.Keys)
                {
                    string[] values = this.G_Car_Removal.Rows[rowIndex].Values;
                    if (values[0].Equals("True"))
                    {
                        if (Regex.IsMatch(values[8], CheckingCarCost))         //验证回款金额是否通过
                        {
                            CarListCount += string.Format("{0},{1},{2},{3},{4},{5}|", values[3].ToString(), "", values[6].ToString(), values[7].ToString(), values[9].ToString(), values[11].ToString());
                            list.Add(string.Format("update {0} set Statu='4',ReturnCost='{1}' where Vin='{2}'", tb_Name, Convert.ToDouble(values[8]), values[7].ToString()));
                            sql_Car_Status += string.Format("select '{0}','4','{1}',getdate()  union all ", values[7].ToString(), CreateID);
                            string Content = "车辆金额:" + values[11].ToString() + "，回款金额:" + values[8];
                            OutCar += string.Format(" select '{0}','{1}','{2}','{3}','{4}','{5}','0','{6}','2','{7}',getdate(),'0' union all ", BankID, BankName, DealerID, DealerName, values[3].ToString(), values[7].ToString(), Content, CreateID);
                            CountOut++;
                        }
                        else
                        {
                            ErrorTxt = "第" + (rowIndex + 1) + "行回款金额错误";
                            break;
                        }
                    }
                    //else
                    //{
                    //    ErrorTxt = "第" + (rowIndex + 1) + "行请勾选出库";
                    //    break;
                    //}
                }
                //判断是否有错误信息
                if (ErrorTxt.Length == 0)
                {
                    //找到最后一个union all 并移除，然后添加list集合
                    if (list.Count != 0)
                    {
                        list.Add(sql_Car_Status.Remove(sql_Car_Status.LastIndexOf("union all")));
                        list.Add(OutCar.Remove(OutCar.LastIndexOf("union all")));

                        //list.Clear();       //清楚集合sql 2014年4月15日
                        list.Add(string.Format(@"insert into tb_CarMasterplate (DealerID,DealerName,BankID,BankName,CarList,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),'2','0')", tb_Name_Count[1], ddl_Dealer.SelectedValue.ToString(), tb_Name_Count[0], tb_Name_Count[2], CarListCount, CountOut, CurrentUser.UserId, CurrentUser.TrueName));
                        int number = CarBll.SqlTran(list);
                        if (number > 0)
                        {
                            FineUI.Alert.Show("申请成功！共申请" + CountOut + "台车", FineUI.MessageBoxIcon.Information);
                            ViewState.Remove("Car_Transit_List");
                            this.G_Car_Removal.DataSource = (DataTable)ViewState["Car_Transit_List"];
                            this.G_Car_Removal.DataBind();
                        }
                        else
                        {
                            FineUI.Alert.Show("申请失败！", FineUI.MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        FineUI.Alert.ShowInTop("", FineUI.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.ShowInTop(ErrorTxt, FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("没有选中任何行", FineUI.MessageBoxIcon.Error);
            }

        }
        #endregion
    }
}
