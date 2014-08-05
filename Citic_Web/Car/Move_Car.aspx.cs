﻿using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Citic.BLL;
using System.IO;
using FineUI;

namespace Citic_Web.Car
{
    public partial class Move_Car : BasePage
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

        #region 查询按钮事件
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
                string[] DealerCount = this.DDL_Bank.SelectedValue.ToString().Split('_');
                string tb_Name = "tb_Car_" + DealerCount[0] + "_" + DealerCount[1];       //sql表名
                StringBuilder sb = new StringBuilder("Statu='1' and IsDelete='0' ");
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
                ViewState["Car_Move_List"] = ds.Tables[0];
                this.G_Car_Move.DataSource = (DataTable)ViewState["Car_Move_List"];
                this.G_Car_Move.DataBind();
            }
        }
        #endregion

        #region 下一页
        protected void G_Car_Move_Page(object sender, FineUI.GridPageEventArgs e)
        {
            G_Car_Move.PageIndex = e.NewPageIndex;
        }
        #endregion

        #region 经销商绑定

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
                //去除重复经销商
                DataTable da = ((DataTable)ViewState["DealerName"]).DefaultView.ToTable(true, "DealerName");
                this.ddl_Dealer.DataTextField = "DealerName";
                this.ddl_Dealer.DataValueField = "DealerName";
                this.ddl_Dealer.DataSource = da;
                this.ddl_Dealer.DataBind();
                this.ddl_Dealer.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));

            }
            catch
            {
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        FineUI.Alert.ShowInTop("超级管理员出错，请联系开发人员", FineUI.MessageBoxIcon.Error);
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        FineUI.Alert.ShowInTop("当前业务经理无法找到对应经销商", FineUI.MessageBoxIcon.Error);
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        FineUI.Alert.ShowInTop("当前市场专员无法找到对应经销商", FineUI.MessageBoxIcon.Error);
                        break;
                    case 6:         //6为业务专员
                        FineUI.Alert.ShowInTop("当前业务专员没有匹配对应银行", FineUI.MessageBoxIcon.Error);
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        FineUI.Alert.ShowInTop("当前监管员没有匹配经销商", FineUI.MessageBoxIcon.Error);
                        break;
                }

            }
        }
        #endregion

        #region 经销商下拉列表事件
        /// <summary>
        /// 查询仓库信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddl_Dealer_SelectedIndex(object sender, EventArgs e)
        {
            if (ddl_Dealer.SelectedValue == "-1")
            {
                FineUI.Alert.ShowInTop("请选择经销商", FineUI.MessageBoxIcon.Error);
                this.DDL_Bank.SelectedIndex = 0;
                this.ddl_Storage.SelectedIndex = 0;
                this.lbl_Cooperation_BrandName.Text = "";       //清空品牌文本
            }
            else
            {
                this.DDL_Bank.DataTextField = "BankName";
                this.DDL_Bank.DataValueField = "DealerID";
                //ViewState转换DataTable,查找经销商名称返回绑定
                DDL_Bank.DataSource = ((DataTable)ViewState["DealerName"]).Select("DealerName='" + ddl_Dealer.SelectedValue.ToString() + "'");
                DDL_Bank.DataBind();
                DDL_Bank.Items.Insert(0, new FineUI.ListItem("——请选择银行——", "-1"));

            }
        }
        #endregion

        #region 经销商仓库信息
        /// <summary>
        /// 查询经销商仓库
        /// </summary>
        /// <param name="DealerID">经销商id</param>
        private void StorageList(int BankId, string DealerID)
        {
            try
            {
                DataSet ds = new Citic.BLL.Dealer_Bank().GetStorageListByDealerIDAndBankID(BankId, int.Parse(DealerID));
                ddl_Storage.DataTextField = "StorageName";
                ddl_Storage.DataValueField = "StorageID";
                ddl_Storage.DataSource = ds;
                ddl_Storage.DataBind();
                this.ddl_Storage.Items.Insert(0, new FineUI.ListItem("——请选择移库地址——", "-1"));
            }
            catch
            {
                this.G_Car_Move.EmptyText = "无法与服务器连接";
            }

        }
        #endregion

        #region 银行列表事件
        protected void DDL_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Bank.SelectedValue.ToString() != "-1")
            {
                StorageList(int.Parse(this.DDL_Bank.SelectedValue.ToString().Split('_')[0].ToString()), this.DDL_Bank.SelectedValue.ToString().Split('_')[1].ToString());
                this.lbl_Cooperation_BrandName.Text = DDL_Bank.SelectedValue.ToString().Split('_')[3].ToString();
                //根据银行，经销商查询是否走接口
                DataRow[] dr = ((DataTable)ViewState["DealerName"]).Select("DealerName='" + ddl_Dealer.SelectedValue.ToString() + "' and BankName='" + DDL_Bank.SelectedText + "'");
                if (dr[0].ItemArray[3].ToString().Length > 0)
                {
                    this.Btn_Up_Move.Enabled = false;
                    this.Btn_Up_Move.ToolTip = "<span style='color:Red'>此经销商跟光大银行合作，不能手动移库</span>";
                }
                else
                {
                    this.Btn_Up_Move.Enabled = true;
                    this.Btn_Up_Move.ToolTip = "<span style='color:Red'>请注意填写回款金额</span>";
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("请选择银行", FineUI.MessageBoxIcon.Error);
                this.lbl_Cooperation_BrandName.Text = "";       //清空品牌文本
            }
        }
        #endregion

        #region 移库事件
        protected void Btn_Up_Move_Click(object sender, EventArgs e)
        {
            if (ddl_Storage.SelectedValue != "-1")
            {
                string ErrorTxt = string.Empty;     //错误提示信息
                List<string> list = new List<string>();  //声明集合，存放需要执行的sql语句
                Dictionary<int, Dictionary<string, string>> modifiedDict = G_Car_Move.GetModifiedDict();  //获取修改集合
                if (modifiedDict.Count != 0)
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
                            CreateID = CurrentUser.UserId;
                            break;
                        case 4:         //4为市场经理
                            CreateID = CurrentUser.UserId;
                            break;
                        case 5:         //5为市场专员
                            CreateID = CurrentUser.UserId;
                            break;
                        case 6:         //6为品牌专员
                            CreateID = CurrentUser.UserId;
                            break;
                        case 7:         //7为调配专员
                            CreateID = CurrentUser.UserId;
                            break;
                        case 8:         //8为银行
                            CreateID = CurrentUser.UserId;
                            break;
                        case 9:         //9为厂家
                            CreateID = CurrentUser.UserId;
                            break;
                        case 10:         //10为监管员
                            CreateID = this.CurrentUser.RelationID.Value;
                            break;
                    }
                    #endregion
                    //因为经销商要去除重复，所以经销商信息绑定到银行
                    string[] DealerCount = this.DDL_Bank.SelectedValue.ToString().Split('_');     //获取银行id，银行名称，经销商id，品牌名称集合

                    string tb_Name = "tb_Car_" + DealerCount[0] + "_" + DealerCount[1];       //sql表名
                    string BankID = DealerCount[0].ToString();         //银行id
                    string BankName = DDL_Bank.SelectedText.ToString();           //银行名称
                    string DealerID = DealerCount[1].ToString();           //经销商id
                    string DealerName = ddl_Dealer.SelectedText.ToString();         //经销商名称
                    string StorageName = this.ddl_Storage.SelectedText;                //二网名称
                    int StorageID = int.Parse(this.ddl_Storage.SelectedValue.ToString());   //二网id
                    string Content = string.Empty;
                    //移库待办事sql语句
                    string OutCar = "insert into tb_DBSX_List (BankID,BankName,DealerID,DealerName,DraftNo,Vin,ReqType,Content,[Status],CreateID,CreateTime,IsDelete) ";
                    //历史状态信息
                    string sql_Car_Status = "insert into tb_Car_Status (Vin,StatusType,CreateID,CreateTime) ";
                    string CheckingCarCost = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
                    int CountMove = 0;      //记录移库台数
                    string CarListCount = string.Empty; //记录生成excel车辆信息
                    foreach (int rowIndex in modifiedDict.Keys)
                    {

                        string[] values = this.G_Car_Move.Rows[rowIndex].Values;
                        if (values[0].Equals("True"))
                        {
                            if (Regex.IsMatch(values[12], CheckingCarCost))         //验证回款金额是否通过
                            {
                                
                                CarListCount += string.Format("{0},{1},{2},{3},{4},{5}|", values[4].ToString(), values[9].ToString(), values[7].ToString() + "/" + values[6].ToString(), values[11].ToString(), StorageName, values[3].ToString());
                                list.Add(string.Format("update {0} set Statu='4',StorageID='{1}',StorageName='{2}',ReturnCost='{3}' where Vin='{4}'", tb_Name, StorageID, StorageName, Convert.ToDouble(values[12]), values[7].ToString()));
                                sql_Car_Status += string.Format("select '{0}','4','{1}',getdate()  union all ", values[7].ToString(), CreateID);
                                Content = "原库名：" + values[8].ToString() + "，移入库名：" + StorageName;
                                OutCar += string.Format(" select '{0}','{1}','{2}','{3}','{4}','{5}','0','{6}','2','{7}',getdate(),'0' union all ", BankID, BankName, DealerID, DealerName, values[3].ToString(), values[7].ToString(), Content, CreateID);
                                CountMove++;
                            }
                            else
                            {
                                ErrorTxt = "第" + (rowIndex + 1) + "行回款金额错误";
                                break;
                            }
                        }
                        else
                        {
                            ErrorTxt = "第" + (rowIndex + 1) + "行请勾选移库";
                            break;
                        }

                    }
                    if (ErrorTxt.Length == 0)
                    {
                        try
                        {
                            //找到最后一个union all 并移除，然后添加list集合
                            list.Add(sql_Car_Status.Remove(sql_Car_Status.LastIndexOf("union all")));
                            //添加待办事到集合
                            list.Add(OutCar.Remove(OutCar.LastIndexOf("union all")));
                            //2014年4月15日
                            list.Add(string.Format(@"insert into tb_CarMasterplate (DealerID,DealerName,BankID,BankName,CarList,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),'3','0')", DealerID, ddl_Dealer.SelectedValue.ToString(), BankID, BankName, CarListCount, CountMove, CurrentUser.UserId, CurrentUser.TrueName));
                            int number = CarBll.SqlTran(list);

                            if (number > 0)
                            {
                                FineUI.Alert.Show("移库成功！共移库" + CountMove + "台车", FineUI.MessageBoxIcon.Information);
                                ViewState.Clear();
                                this.G_Car_Move.DataSource = (DataTable)ViewState["Car_Move_List"];
                                this.G_Car_Move.DataBind();
                            }
                            else
                            {
                                FineUI.Alert.Show("修改失败！", FineUI.MessageBoxIcon.Error);

                            }
                        }
                        catch
                        {

                            FineUI.Alert.Show("无法与服务器连接！", FineUI.MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        FineUI.Alert.ShowInTop(ErrorTxt, FineUI.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.Show("没有修改任何数据", FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.Show("请选择移入的库名", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}