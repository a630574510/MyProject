using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using Citic.BLL;

using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
namespace Citic_Web.Car
{
    public partial class Transit_Car : BasePage
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
            ViewState.Remove("Car_Transit_List");
            if (ddl_Dealer.SelectedValue == "-1")
            {
                FineUI.Alert.Show("请选择经销商", FineUI.MessageBoxIcon.Error);
            }
            else if (DDL_Bank.SelectedValue == "-1")
            {
                FineUI.Alert.Show("请选择银行", FineUI.MessageBoxIcon.Error);
            }
            else if (DDL_Number_Order.SelectedValue == "-1")
            {
                FineUI.Alert.Show("请选择汇票号！", FineUI.MessageBoxIcon.Error);
            }
            else
            {
                string[] tb_Name_Count = DDL_Bank.SelectedValue.ToString().Split('_');
                string tb_Name = "tb_Car_" + tb_Name_Count[0] + "_" + tb_Name_Count[1].ToString();
                StringBuilder sb = new StringBuilder("Statu='3'  and DraftNo like '%" + DDL_Number_Order.SelectedText.ToString() + "%' ");
                //StringBuilder sb = new StringBuilder("select Vin,DraftNo,BankID,BankName,Statu,QualifiedNoDate,DealerID,DealerName,BrandID,BankName,StorageID,StorageName,CarColor,CarModel,EngineNo,QualifiedNo,KeyCount,KeyNumber,CarCost,ReturnCost,Remarks,CreateTime,TransitTime,OutTime,MoveTime from tb_Car_lisr where DealerID='" + tb_Name_Count[1].ToString() + "' and Statu='3'");
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
                sb.Append(" order by CreateTime desc");
                DataSet ds = new Citic.BLL.Car().GetAllList(sb.ToString(), tb_Name);
                ViewState["Car_Transit_List"] = ds.Tables[0];
                this.G_Car_Detail.DataSource = (System.Data.DataTable)ViewState["Car_Transit_List"];
                this.G_Car_Detail.DataBind();
            }

        }
        #endregion

        #region 经销商绑定
        /// <summary>
        /// 绑定经销商
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
                System.Data.DataTable da = ((System.Data.DataTable)ViewState["DealerName"]).DefaultView.ToTable(true, "DealerName");
                this.ddl_Dealer.DataTextField = "DealerName";
                this.ddl_Dealer.DataValueField = "DealerName";
                this.ddl_Dealer.DataSource = da;
                this.ddl_Dealer.DataBind();
                ddl_Dealer.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));
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

        #region 检查是否有特殊字符
        /// <summary>  
        ///  判断是否有非法字符
        /// </summary>  
        /// <param name="strString"></param>  
        /// <returns>返回TRUE表示有非法字符，返回FALSE表示没有非法字符。</returns>  
        public static bool CheckBadStr(string strString)
        {
            bool outValue = false;
            if (strString != null && strString.Length > 0)
            {
                string[] bidStrlist = new string[24];
                bidStrlist[0] = "'";
                bidStrlist[1] = ";";
                bidStrlist[2] = ":";
                bidStrlist[3] = "%";
                bidStrlist[4] = "@";
                bidStrlist[5] = "&";
                bidStrlist[6] = "#";
                bidStrlist[7] = "\"";
                bidStrlist[8] = "net user";
                bidStrlist[9] = "exec";
                bidStrlist[10] = "net localgroup";
                bidStrlist[11] = "select";
                bidStrlist[12] = "asc";
                bidStrlist[13] = "char";
                bidStrlist[14] = "mid";
                bidStrlist[15] = "insert";
                bidStrlist[16] = "order";
                bidStrlist[17] = "exec";
                bidStrlist[18] = "delete";
                bidStrlist[19] = "drop";
                bidStrlist[20] = "truncate";
                bidStrlist[21] = "xp_cmdshell";
                bidStrlist[22] = "<";
                bidStrlist[23] = ">";
                string tempStr = strString.ToLower();
                for (int i = 0; i < bidStrlist.Length; i++)
                {
                    if (tempStr.IndexOf(bidStrlist[i]) != -1)
                    {
                        outValue = true;
                        break;
                    }
                }
            }
            return outValue;
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
                this.DDL_Bank.SelectedIndex = 0;
                //this.lbl_Cooperation_BrandName.Text = "";   //清空品牌文本
            }
            else
            {
                this.DDL_Bank.DataTextField = "BankName";
                this.DDL_Bank.DataValueField = "DealerID";
                System.Data.DataTable da = (System.Data.DataTable)ViewState["DealerName"];
                //ViewState转换DataTable,查找经销商名称返回绑定
                DDL_Bank.DataSource = ((System.Data.DataTable)ViewState["DealerName"]).Select("DealerName='" + ddl_Dealer.SelectedValue.ToString() + "'");
                DDL_Bank.DataBind();
                AddItemByInsert(DDL_Bank, "——请选择——", "-1", 0);
            }
        }
        #endregion

        #region 银行列表事件
        protected void DDL_Bank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DDL_Bank.SelectedValue.ToString() != "-1")
            {
                //this.lbl_Cooperation_BrandName.Text = DDL_Bank.SelectedValue.ToString().Split('_')[3].ToString();

                //获取经销商绑定值集合
                string[] Dealer = DDL_Bank.SelectedValue.ToString().Split('_');
                //提示经销商的合作银行
                //this.lbl_Cooperation_Bank.Text = Dealer[2].ToString();
                DataSet ds = DraftBll.GetList("DealerID='" + Dealer[1] + "' and BankID='" + Dealer[0] + "'");
                this.DDL_Number_Order.DataTextField = "DraftNo";
                this.DDL_Number_Order.DataValueField = "DraftNo";
                this.DDL_Number_Order.DataSource = ds.Tables[0];
                this.DDL_Number_Order.DataBind();
                this.DDL_Number_Order.Items.Insert(0, new FineUI.ListItem("——请选择汇票——", "-1"));

                DataRow[] dr = ((System.Data.DataTable)ViewState["DealerName"]).Select("DealerName='" + ddl_Dealer.SelectedValue.ToString() + "' and BankName='" + DDL_Bank.SelectedText + "'");
                if (dr[0].ItemArray[3].ToString().Length > 0)
                {
                    this.Btn_GD.Hidden = false;         //光大显示
                    this.Btn_Again_Bind.Hidden = true;      //正常提交隐藏
                    this.Btn_ZX.Hidden = true;     //中信隐藏
                }
                else if (dr[0].ItemArray[4].ToString().Length > 0)
                {
                    this.Btn_GD.Hidden = true;      //光大隐藏
                    this.Btn_Again_Bind.Hidden = true;      //正常提交隐藏
                    this.Btn_ZX.Hidden = false;     //中信显示
                }
                else
                {
                    this.Btn_GD.Hidden = true;      //光大隐藏
                    this.Btn_Again_Bind.Hidden = false; //正常提交显示
                    this.Btn_ZX.Hidden = true;     //中信隐藏
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("请选择银行", FineUI.MessageBoxIcon.Error);
                //this.lbl_Cooperation_BrandName.Text = "";   //清空品牌文本
            }

        }
        #endregion

        #region 正常入库事件
        protected void Btn_Again_Bind_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_Car_Detail.GetModifiedDict();  //获取修改集合
            if (modifiedDict.Count != 0)
            {
                System.Data.DataTable dt = CreateTb();
                List<string> list = new List<string>();  //声明集合，存放需要执行的sql语句
                string[] tb_Name_Count = DDL_Bank.SelectedValue.ToString().Split('_');   //获取下拉列表集合值
                string tb_Name = "tb_Car_" + tb_Name_Count[0] + "_" + tb_Name_Count[1].ToString(); //拼接表名
                int CreateId = CurrentUser.UserId;            //获取登陆人id
                string ErrorTxt = string.Empty;     //错误提示信息
                int Statu_Count = 0;            //记录入库台数
                string CarListCount = string.Empty; //记录生成excel车辆信息
                if (int.Parse(tb_Name_Count[4].ToString()) > 1) //判断经销商业务模式
                {
                    foreach (int rowIndex in modifiedDict.Keys)
                    {
                        string Vin = G_Car_Detail.DataKeys[rowIndex][0].ToString();         //获取当前索引绑定车架号
                        string[] values = this.G_Car_Detail.Rows[rowIndex].Values;
                        if (values[0].ToString() == "True")     //是否入库状态
                        {
                            list.Add(string.Format("update {0} set KeyCount='{1}',TransitTime=getdate(),Statu=1,UpdateID='{2}',UpdateTime=getdate() where Vin='{3}'", tb_Name, values[1].ToString(), CreateId, Vin));
                            CarListCount += string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}|", values[8].Trim().ToString(), values[4].Trim().ToString(), values[7].Trim().ToString(), values[9].Trim().ToString(), values[1].Trim().ToString(), "良好", values[3].Trim().ToString(), values[5].Trim().ToString(), values[6].Trim().ToString(), values[10].Trim().ToString(), ddl_Dealer.SelectedValue.ToString());
                            Statu_Count++;
                        }
                    }
                }
                else
                {
                    foreach (int rowIndex in modifiedDict.Keys)
                    {
                        string Vin = G_Car_Detail.DataKeys[rowIndex][0].ToString();         //获取当前索引绑定车架号
                        string[] values = this.G_Car_Detail.Rows[rowIndex].Values;
                        if (values[0].ToString() == "True")     //是否入库状态
                        {
                            if (int.Parse(values[1].ToString()) > 0)
                            {
                                list.Add(string.Format("update {0} set KeyCount='{1}',TransitTime=getdate(),Statu=1,UpdateID='{2}',UpdateTime=getdate() where Vin='{3}'", tb_Name, values[1].ToString(), CreateId, Vin));
                                Statu_Count++;
                                CarListCount += string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}|", values[8].Trim().ToString(), values[4].Trim().ToString(), values[7].Trim().ToString(), values[9].Trim().ToString(), values[1].Trim().ToString(), "良好", values[3].Trim().ToString(), values[5].Trim().ToString(), values[6].Trim().ToString(), values[9].Trim().ToString(), ddl_Dealer.SelectedValue.ToString());
                            }
                            else
                            {
                                ErrorTxt = "第" + (rowIndex + 1) + "行钥匙数不能为0";
                                break;
                            }
                        }
                        else
                        {
                            if (int.Parse(values[1].ToString()) > 0)    //判断钥匙是否大于0
                            {
                                list.Add(string.Format("update {0} set KeyCount='{1}' where Vin='{2}'", tb_Name, values[1].ToString(), Vin));
                            }
                        }
                    }
                }
                if (ErrorTxt.Length == 0)
                {
                    try
                    {
                        if (list.Count > 0)
                        {
                            if (Statu_Count > 0)
                            {
                                list.Add(string.Format(@"insert into tb_CarMasterplate (DealerID,DealerName,BankID,BankName,CarList,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),'1','0')", tb_Name_Count[1], ddl_Dealer.SelectedValue.ToString(), tb_Name_Count[0], tb_Name_Count[2], CarListCount, Statu_Count, CreateId, CurrentUser.TrueName));
                            }
                            int number = CarBll.SqlTran(list);
                            if (number > 0)
                            {
                                FineUI.Alert.Show("入库" + Statu_Count + "台");
                                ViewState.Remove("Car_Transit_List");
                                this.G_Car_Detail.DataSource = (System.Data.DataTable)ViewState["Car_Transit_List"];
                                this.G_Car_Detail.DataBind();
                            }
                            else
                            {
                                FineUI.Alert.Show("修改失败！", FineUI.MessageBoxIcon.Error);
                            }
                        }

                    }
                    catch
                    {
                        FineUI.Alert.Show("生成入库确认书时失败", FineUI.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.Show(ErrorTxt, FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("没有修改任何数据", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 光大入库
        protected void Btn_GD_Click(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_Car_Detail.GetModifiedDict();  //获取修改集合
            if (modifiedDict.Count != 0)
            {
                System.Data.DataTable dt = CreateTb();
                List<string> list = new List<string>();  //声明集合，存放需要执行的sql语句
                string[] tb_Name_Count = DDL_Bank.SelectedValue.ToString().Split('_');   //获取下拉列表集合值
                string tb_Name = "tb_Car_" + tb_Name_Count[0] + "_" + tb_Name_Count[1].ToString(); //拼接表名
                string ErrorTxt = string.Empty;     //错误提示信息
                int Statu_Count = 0;            //记录入库台数
                string FTranCode = "Q402";      //交易码
                string CarListCount = string.Empty; //生成模版车辆信息
                foreach (int rowIndex in modifiedDict.Keys)
                {
                    string Vin = G_Car_Detail.DataKeys[rowIndex][0].ToString();         //获取当前索引绑定车架号
                    string[] values = this.G_Car_Detail.Rows[rowIndex].Values;
                    if (values[0].ToString() == "True")     //是否入库状态
                    {
                        if (int.Parse(values[1].ToString()) > 0)
                        {
                            list.Add(string.Format("update {0} set KeyCount='{1}',TransitTime=getdate(),Statu=1,UpdateID='{2}',UpdateTime=getdate() where Vin='{3}'", tb_Name, values[1].ToString(), CurrentUser.UserId, Vin));
                            //DataRow dr = dt.NewRow();
                            //dr["QualifiedNo"] = values[8];             //汽车合格证号
                            //dr["CarModel"] = values[4];            //车辆型号
                            //dr["Vin"] = values[7];             //车架号
                            //dr["CarCost"] = values[9];     //单价 （元）
                            //dr["KeyCount"] = values[1];        //钥匙  （把）
                            //dr["Appearance"] = "良好";       //外观是否良好
                            //dr["DraftNo"] = values[3];        //银票票号
                            //dr["CarColor"] = values[5];         //颜色
                            //dr["EngineNo"] = values[6];          //发动机
                            //dr["KeyNumber"] = values[9];         //钥匙号
                            //dr["DealerName"] = ddl_Dealer.SelectedValue.ToString(); //经销商
                            //dt.Rows.Add(dr);
                            Statu_Count++;
                            CarListCount += string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}|", values[8].Trim().ToString(), values[4].Trim().ToString(), values[7].Trim().ToString(), values[9].Trim().ToString(), values[1].Trim().ToString(), "良好", values[3].Trim().ToString(), values[5].Trim().ToString(), values[6].Trim().ToString(), values[9].Trim().ToString(), ddl_Dealer.SelectedValue.ToString());
                            string GD_sql = "select HXCS_ID,JXS_ID,BF_ID,BNFO_BILL_MATURE_DT,(select SEND_CAR_ID from GD_DispatchCarInfo where DJ_NO= '" + values[4] + "') as SEND_CAR_ID,(select CAR_BRAND from GD_DispatchCarInfo where DJ_NO= '" + values[4] + "') as CAR_BRAND from GD_BillInfo where BF_NO='" + values[3] + "'";
                            DataSet ds = CarBll.GetList(GD_sql);


                            string TrmSeqNum = DateTime.Now.ToString("yyyyHHddmmssffff");     //流水终端号

                            string insetValue = string.Format(@"'update " + tb_Name + " set KeyCount=''" + modifiedDict[rowIndex]["KeyCount"].ToString() + "'',TransitTime=''" + DateTime.Now + "'',Statu=1,GD_ID=''!!!'' where Vin=''" + Vin + "'''");

                            string xmltxt = "<CHANNEL_CODE>0231J001</CHANNEL_CODE>";        //接入机构号
                            xmltxt += "<SEND_CAR_ID></SEND_CAR_ID>";                //发车明细ID
                            xmltxt += "<HXCS_ID>" + ds.Tables[0].Rows[0]["HXCS_ID"] + "</HXCS_ID>";         //核心厂商id
                            xmltxt += "<JXS_ID>" + ds.Tables[0].Rows[0]["JXS_ID"] + "</JXS_ID>";            //经销商id
                            xmltxt += "<PI_NO>" + values[8] + "</PI_NO>";               //合格证编号
                            xmltxt += "<DJ_NO>" + values[7] + "</DJ_NO>";               //车辆识别代号
                            xmltxt += "<CAR_MODEL>" + values[4] + "</CAR_MODEL>";                //汽车型号
                            xmltxt += "<ENGINE_MODEL>" + values[6] + "</ENGINE_MODEL>";          //发动机号
                            xmltxt += "<CAR_BRAND>" + ds.Tables[0].Rows[0]["CAR_BRAND"] + "</CAR_BRAND>";                //品牌
                            xmltxt += "<CAR_COLOR>" + values[5] + "</CAR_COLOR>";                //颜色
                            xmltxt += "<PI_AMOUNT>" + values[10] + "</PI_AMOUNT>";   //合格证金额
                            xmltxt += "<KEY_NUM>" + values[1] + "</KEY_NUM>";                //钥匙数
                            xmltxt += "<MATURE_DATE>" + ds.Tables[0].Rows[0]["BNFO_BILL_MATURE_DT"] + "</MATURE_DATE>"; //合格证到期日
                            xmltxt += "<BF_ID>" + ds.Tables[0].Rows[0]["BF_ID"] + "</BF_ID>";               //对应票据id
                            xmltxt += "<PI_STATUS>400</PI_STATUS>";         //合格证状态
                            xmltxt += "<CAR_STATUS>400</CAR_STATUS>";      //车辆状态
                            xmltxt += "<RANGE_FLAG>0</RANGE_FLAG>";      //是否超范围  
                            xmltxt += "<CAR_STOCK_ADD></CAR_STOCK_ADD>";        //车辆在库地址
                            xmltxt += "<REMARK>" + values[11] + "</REMARK>";                  //备注
                            string sql = "insert into tb_ToGDMessage (FTranCode,TrmSeqNum,RequestSource,RequestPe_ID,Status,RequestDate,insertValue) values('" + FTranCode + "','" + TrmSeqNum + "','" + xmltxt + "','1',0,GETDATE()," + insetValue + ")";
                            list.Add(sql);
                        }
                        else
                        {
                            ErrorTxt = "第" + (rowIndex + 1) + "行钥匙数不能为0";
                        }
                    }
                    //else
                    //{
                    //    if (int.Parse(values[1].ToString()) > 0)    //判断钥匙是否大于0
                    //    {
                    //        list.Add(string.Format("update {0} set KeyCount='{1}' where Vin='{2}'", tb_Name, values[1].ToString(), Vin));
                    //    }
                    //}
                    ///////////////////////////////张繁注释 2014年3月27日
                    ////当前key值是否包含入库条件
                    //if ((modifiedDict[rowIndex].ContainsValue("1") || modifiedDict[rowIndex].ContainsValue("2") || modifiedDict[rowIndex].ContainsValue("3") || modifiedDict[rowIndex].ContainsValue("4") || modifiedDict[rowIndex].ContainsValue("5")) && modifiedDict[rowIndex].ContainsValue("True"))
                    //{
                    //    string[] values = this.G_Car_Detail.Rows[rowIndex].Values;
                    //    DataRow dr = dt.NewRow();
                    //    dr["QualifiedNo"] = values[8];             //汽车合格证号
                    //    dr["CarModel"] = values[4];            //车辆型号
                    //    dr["Vin"] = values[7];             //车架号
                    //    dr["CarCost"] = values[10];     //单价 （元）
                    //    dr["KeyCount"] = values[1];        //钥匙  （把）
                    //    dr["Appearance"] = "良好";       //外观是否良好
                    //    dr["DraftNo"] = values[3];        //银票票号
                    //    dr["CarColor"] = values[5];         //颜色
                    //    dr["EngineNo"] = values[6];          //发动机
                    //    dr["KeyNumber"] = values[9];         //钥匙号
                    //    dr["DealerName"] = ddl_Dealer.SelectedValue.ToString(); //经销商
                    //    dt.Rows.Add(dr);
                    //    Statu_Count++;

                    //    string GD_sql = "select HXCS_ID,JXS_ID,BF_ID,BNFO_BILL_MATURE_DT,(select SEND_CAR_ID from GD_DispatchCarInfo where DJ_NO= '" + values[4] + "') as SEND_CAR_ID,(select CAR_BRAND from GD_DispatchCarInfo where DJ_NO= '" + values[4] + "') as CAR_BRAND from GD_BillInfo where BF_NO='" + values[3] + "'";
                    //    DataSet ds = CarBll.GetList(GD_sql);


                    //    string TrmSeqNum = DateTime.Now.ToString("yyyyHHddmmssffff");     //流水终端号

                    //    string insetValue = string.Format(@"'update " + tb_Name + " set KeyCount=''" + modifiedDict[rowIndex]["KeyCount"].ToString() + "'',TransitTime=''" + DateTime.Now + "'',Statu=1,GD_ID=''!!!'' where Vin=''" + Vin + "'''");

                    //    string xmltxt = "<CHANNEL_CODE>0231J001</CHANNEL_CODE>";        //接入机构号
                    //    xmltxt += "<SEND_CAR_ID></SEND_CAR_ID>";                //发车明细ID
                    //    xmltxt += "<HXCS_ID>" + ds.Tables[0].Rows[0]["HXCS_ID"] + "</HXCS_ID>";         //核心厂商id
                    //    xmltxt += "<JXS_ID>" + ds.Tables[0].Rows[0]["JXS_ID"] + "</JXS_ID>";            //经销商id
                    //    xmltxt += "<PI_NO>" + values[8] + "</PI_NO>";               //合格证编号
                    //    xmltxt += "<DJ_NO>" + values[7] + "</DJ_NO>";               //车辆识别代号
                    //    xmltxt += "<CAR_MODEL>" + values[4] + "</CAR_MODEL>";                //汽车型号
                    //    xmltxt += "<ENGINE_MODEL>" + values[6] + "</ENGINE_MODEL>";          //发动机号
                    //    xmltxt += "<CAR_BRAND>" + ds.Tables[0].Rows[0]["CAR_BRAND"] + "</CAR_BRAND>";                //品牌
                    //    xmltxt += "<CAR_COLOR>" + values[5] + "</CAR_COLOR>";                //颜色
                    //    xmltxt += "<PI_AMOUNT>" + values[10] + "</PI_AMOUNT>";   //合格证金额
                    //    xmltxt += "<KEY_NUM>" + values[1] + "</KEY_NUM>";                //钥匙数
                    //    xmltxt += "<MATURE_DATE>" + ds.Tables[0].Rows[0]["BNFO_BILL_MATURE_DT"] + "</MATURE_DATE>"; //合格证到期日
                    //    xmltxt += "<BF_ID>" + ds.Tables[0].Rows[0]["BF_ID"] + "</BF_ID>";               //对应票据id
                    //    xmltxt += "<PI_STATUS>400</PI_STATUS>";         //合格证状态
                    //    xmltxt += "<CAR_STATUS>400</CAR_STATUS>";      //车辆状态
                    //    xmltxt += "<RANGE_FLAG>0</RANGE_FLAG>";      //是否超范围  
                    //    xmltxt += "<CAR_STOCK_ADD></CAR_STOCK_ADD>";        //车辆在库地址
                    //    xmltxt += "<REMARK>" + values[11] + "</REMARK>";                  //备注
                    //    string sql = "insert into tb_ToGDMessage (FTranCode,TrmSeqNum,RequestSource,RequestPe_ID,Status,RequestDate,insertValue) values('" + FTranCode + "','" + TrmSeqNum + "','" + xmltxt + "','1',0,GETDATE()," + insetValue + ")";
                    //    list.Add(sql);
                    //}
                }
                if (ErrorTxt.Length == 0)
                {
                    try
                    {
                        if (list.Count > 0)
                        {
                            //string StrCopyName = CurrentUser.TrueName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + "确认书.xls";
                            //string StrHandWorkCopyName = CurrentUser.TrueName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + "手工台帐.xls";
                            //string StrKeyConnectCopyName = CurrentUser.TrueName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + "钥匙交接表.xls";
                            //string StrBorrowCopyName = CurrentUser.TrueName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + "钥匙借用登记表.xls";
                            //list.Clear();       //清楚集合sql
                            //list.Add("insert into tb_CarMasterplate (DealerID,DealerName,BankID,BankName,FileName1,FileName2,FileName3,FileName4,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel) values ('" + tb_Name_Count[1] + "','" + ddl_Dealer.SelectedValue.ToString() + "','" + tb_Name_Count[0] + "','" + tb_Name_Count[2] + "','" + StrCopyName + "','" + StrHandWorkCopyName + "','" + StrKeyConnectCopyName + "','" + StrBorrowCopyName + "','" + Statu_Count + "','" + CurrentUser.UserId + "','" + CurrentUser.TrueName + "',getdate(),1,0)");
                            //list.Add(string.Format("insert into tb_CarMasterplate (DealerID,DealerName,BankID,BankName,FileName1,FileName2,FileName3,FileName4,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',getdate(),1,0)", tb_Name_Count[1], ddl_Dealer.SelectedValue.ToString(), tb_Name_Count[0], tb_Name_Count[2], StrCopyName, StrHandWorkCopyName, StrKeyConnectCopyName, StrBorrowCopyName, Statu_Count, CurrentUser.UserId, CurrentUser.TrueName));
                            list.Add(string.Format(@"insert into tb_CarMasterplate (DealerID,DealerName,BankID,BankName,CarList,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),'1','0')", tb_Name_Count[1], ddl_Dealer.SelectedValue.ToString(), tb_Name_Count[0], tb_Name_Count[2], CarListCount, Statu_Count, CurrentUser.UserId, CurrentUser.TrueName));
                            int number = new Citic.BLL.Car().SqlTran(list);
                            if (number > 0)
                            {
                                FineUI.Alert.Show("入库" + Statu_Count + "台");

                                //StrCopyName = Server.MapPath("~/Confirmation/" + StrCopyName);       //确认书路径
                                //File.Copy(Server.MapPath("~/Confirmation/确认书.xls"), StrCopyName, false);
                                //AppendText(StrCopyName, dt, 6, 1);

                                //StrHandWorkCopyName = Server.MapPath("~/Confirmation/" + StrHandWorkCopyName);       //手工台帐
                                //File.Copy(Server.MapPath("~/Confirmation/手工台帐.xls"), StrHandWorkCopyName, false);
                                //AppendText(StrHandWorkCopyName, dt, 4, 2);

                                //StrKeyConnectCopyName = Server.MapPath("~/Confirmation/" + StrKeyConnectCopyName);       //钥匙交接表
                                //File.Copy(Server.MapPath("~/Confirmation/钥匙交接表.xls"), StrKeyConnectCopyName, false);
                                //AppendText(StrKeyConnectCopyName, dt, 4, 3);

                                //StrBorrowCopyName = Server.MapPath("~/Confirmation/" + StrBorrowCopyName);       //钥匙借用登记表
                                //File.Copy(Server.MapPath("~/Confirmation/钥匙借用登记表.xls"), StrBorrowCopyName, false);
                                //AppendText(StrBorrowCopyName, dt, 4, 4);


                                ViewState.Remove("Car_Transit_List");
                                this.G_Car_Detail.DataSource = (System.Data.DataTable)ViewState["Car_Transit_List"];
                                this.G_Car_Detail.DataBind();
                            }
                            else
                            {
                                FineUI.Alert.Show("修改失败！", FineUI.MessageBoxIcon.Error);
                            }
                            //if (Statu_Count > 0)     //2014年4月8日
                            //{
                            //    StrCopyName = Server.MapPath("~/Confirmation/" + StrCopyName);       //确认书路径
                            //    File.Copy(Server.MapPath("~/Confirmation/确认书.xls"), StrCopyName, false);
                            //    AppendText(StrCopyName, dt, 6, 1);

                            //    StrHandWorkCopyName = Server.MapPath("~/Confirmation/" + StrHandWorkCopyName);       //手工台帐
                            //    File.Copy(Server.MapPath("~/Confirmation/手工台帐.xls"), StrHandWorkCopyName, false);
                            //    AppendText(StrHandWorkCopyName, dt, 4, 2);

                            //    StrKeyConnectCopyName = Server.MapPath("~/Confirmation/" + StrKeyConnectCopyName);       //钥匙交接表
                            //    File.Copy(Server.MapPath("~/Confirmation/钥匙交接表.xls"), StrKeyConnectCopyName, false);
                            //    AppendText(StrKeyConnectCopyName, dt, 4, 3);

                            //    StrBorrowCopyName = Server.MapPath("~/Confirmation/" + StrBorrowCopyName);       //钥匙借用登记表
                            //    File.Copy(Server.MapPath("~/Confirmation/钥匙借用登记表.xls"), StrBorrowCopyName, false);
                            //    AppendText(StrBorrowCopyName, dt, 4, 4);
                            //}
                        }

                    }
                    catch
                    {
                        FineUI.Alert.Show("生成入库确认书时失败", FineUI.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.Show(ErrorTxt, FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("没有修改任何数据", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 中信入库 2014年4月14日
        protected void Btn_ZX_Click(object sender, EventArgs e)
        {

            Car_Into();
        }
        #endregion

        #region Excel指定行插入
        /// <summary>
        /// Excel插入
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="dt">需要插入数据源</param>
        /// <param name="Row">插入行数</param>
        /// <param name="Number">索引，代表各类表格，1.确认书   2.手工台帐  3.钥匙交接表  4.钥匙借用登记表 5.出库申请</param>
        public void AppendText(string fileName, System.Data.DataTable dt, int Row, int Number)
        {
            Excel.Application excel = new Excel.Application(); //引用Excel对象  
            object miss = System.Type.Missing;
            excel.Workbooks.Open(fileName, miss, false, miss, miss, miss, miss, miss, miss, miss, miss, miss, miss, miss, miss);
            Workbooks workBooks = null;
            try
            {
                workBooks = excel.Workbooks;
                Workbook curWorkBook = workBooks[1];
                Worksheet curSheet = (Worksheet)curWorkBook.Worksheets[1];
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;
                Range range;
                int cout = dt.Rows.Count;       //记录添加总行数
                decimal CarCostCount = 0;
                for (int i = 0; i < cout; i++)
                {
                    range = (Excel.Range)curSheet.Rows[Row + (i), miss];
                    range.Insert(Excel.XlInsertShiftDirection.xlShiftDown, miss);
                }

                if (Number == 1)       //索引1为确认书
                {
                    for (int i = 0; i < cout; i++)
                    {
                        curSheet.Cells[Row + i, 1] = i + 1;     //序号
                        curSheet.Cells[Row + i, 2] = dt.Rows[i]["QualifiedNo"].ToString();         //汽车合格证号
                        curSheet.Cells[Row + i, 3] = dt.Rows[i]["CarModel"].ToString();           //车辆型号
                        curSheet.Cells[Row + i, 4] = dt.Rows[i]["Vin"].ToString();                //车架号
                        curSheet.Cells[Row + i, 5] = dt.Rows[i]["CarCost"].ToString();            //单价 （元）
                        curSheet.Cells[Row + i, 6] = dt.Rows[i]["KeyCount"].ToString();            //钥匙  （把）
                        curSheet.Cells[Row + i, 7] = dt.Rows[i]["Appearance"].ToString();         //外观是否良好
                        curSheet.Cells[Row + i, 8] = "'" + dt.Rows[i]["DraftNo"].ToString();            //银票票号
                        CarCostCount += decimal.Parse(dt.Rows[i]["CarCost"].ToString());
                    }
                    curSheet.Cells[Row + cout, 5] = "'" + CarCostCount.ToString();         //总金额
                }
                else if (Number == 2)      //索引2为手工台帐
                {
                    for (int i = 0; i < cout; i++)
                    {
                        curSheet.Cells[Row + i, 1] = i + 1;         //序号
                        curSheet.Cells[Row + i, 2] = dt.Rows[i]["CarModel"].ToString();           //车辆型号
                        curSheet.Cells[Row + i, 3] = dt.Rows[i]["CarColor"].ToString();         //颜色
                        curSheet.Cells[Row + i, 4] = dt.Rows[i]["EngineNo"].ToString();         //发动机
                        curSheet.Cells[Row + i, 5] = dt.Rows[i]["Vin"].ToString();                //车架号
                        curSheet.Cells[Row + i, 6] = dt.Rows[i]["QualifiedNo"].ToString();         //汽车合格证号
                        curSheet.Cells[Row + i, 7] = dt.Rows[i]["KeyNumber"].ToString();            //钥匙号
                        curSheet.Cells[Row + i, 8] = DateTime.Now.ToString("yyyy-MM-dd");            //入库时间
                    }
                    curSheet.Cells[2, 12] = "汇票:" + dt.Rows[0]["DraftNo"].ToString();                //银票票号
                    curSheet.Cells[2, 1] = "经销店:" + dt.Rows[0]["DealerName"].ToString();        //经销店
                }
                else if (Number == 3)       //索引3为钥匙交接表
                {
                    for (int i = 0; i < cout; i++)
                    {
                        curSheet.Cells[Row + i, 1] = i + 1;         //序号
                        curSheet.Cells[Row + i, 2] = dt.Rows[i]["CarModel"].ToString();           //车辆型号
                        curSheet.Cells[Row + i, 3] = dt.Rows[i]["Vin"].ToString();                //车架号
                        curSheet.Cells[Row + i, 4] = "1";         //钥匙数
                    }
                    curSheet.Cells[2, 1] = "经销店:" + dt.Rows[0]["DealerName"].ToString();        //经销店
                }
                else if (Number == 4)        //索引4钥匙借用登记表
                {
                    for (int i = 0; i < cout; i++)
                    {
                        curSheet.Cells[Row + i, 1] = i + 1;         //序号
                        curSheet.Cells[Row + i, 2] = dt.Rows[i]["CarModel"].ToString();           //车辆型号
                        curSheet.Cells[Row + i, 3] = dt.Rows[i]["Vin"].ToString();                //车架号
                        curSheet.Cells[Row + i, 4] = dt.Rows[i]["KeyCount"].ToString();         //钥匙数量
                    }
                    curSheet.Cells[2, 1] = "经销店:" + dt.Rows[0]["DealerName"].ToString();        //经销店
                }
                else if (Number == 5)       //索引5为出库申请
                {
                    for (int i = 0; i < cout; i++)
                    {
                        curSheet.Cells[Row + i, 1] = "'" + dt.Rows[i]["DraftNo"].ToString();         //汇票
                        curSheet.Cells[Row + i, 2] = dt.Rows[i]["GuaranteeNo"].ToString();           //保证金账号
                        curSheet.Cells[Row + i, 3] = dt.Rows[i]["EngineNo"].ToString();                //发动机
                        curSheet.Cells[Row + i, 4] = dt.Rows[i]["Vin"].ToString();         //车架号
                        curSheet.Cells[Row + i, 5] = dt.Rows[i]["QualifiedNo"].ToString();         //汽车合格证号
                        curSheet.Cells[Row + i, 6] = dt.Rows[i]["CarCost"].ToString();         //单价 （元）
                    }
                }
                else if (Number == 6)     //索引6为移库
                {
                    for (int i = 0; i < cout; i++)
                    {
                        curSheet.Cells[Row + i, 1] = i + 1;         //序号
                        curSheet.Cells[Row + i, 2] = dt.Rows[i]["CarModel"].ToString();         //型号
                        curSheet.Cells[Row + i, 3] = dt.Rows[i]["QualifiedNo"].ToString();           //汽车合格证号
                        curSheet.Cells[Row + i, 4] = dt.Rows[i]["VinAndEngineNo"].ToString();                //车架号/发动机
                        curSheet.Cells[Row + i, 5] = dt.Rows[i]["CarCost"].ToString();         //单价 （元）
                        curSheet.Cells[Row + i, 6] = dt.Rows[i]["StorageName"].ToString();         //二网
                        curSheet.Cells[Row + i, 7] = "'" + dt.Rows[i]["DraftNo"].ToString();         //汇票
                        CarCostCount += decimal.Parse(dt.Rows[i]["CarCost"].ToString());        //累计金额
                    }
                    curSheet.Cells[Row + cout, 5] = "'" + CarCostCount.ToString();         //总金额
                }
                curWorkBook.Save();
                workBooks.Close();
                excel.Quit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (workBooks != null) { workBooks.Close(); }
                if (excel != null) { excel.Quit(); }
            }
        }
        #endregion

        #region 创建空表格
        /// <summary>
        /// 创建空Table
        /// </summary>
        /// <returns></returns>
        private System.Data.DataTable CreateTb()
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("QualifiedNo", typeof(string));      //汽车合格证号
            dt.Columns.Add("CarModel", typeof(string));         //车辆型号
            dt.Columns.Add("Vin", typeof(string));      //车架号
            dt.Columns.Add("CarCost", typeof(string));      //单价 （元）
            dt.Columns.Add("KeyCount", typeof(string));      //钥匙  （把）
            dt.Columns.Add("Appearance", typeof(string));      //外观是否良好
            dt.Columns.Add("DraftNo", typeof(string));      //银票票号
            dt.Columns.Add("CarColor", typeof(string));     //颜色
            dt.Columns.Add("EngineNo", typeof(string));     //发动机
            dt.Columns.Add("KeyNumber", typeof(string));     //钥匙号
            dt.Columns.Add("DealerName", typeof(string));       //经销商
            return dt;
        }
        #endregion

        #region 生成入库时需要的数据表
        private void CreateExcel(System.Data.DataTable dt)
        {
            string StrCopyName = CurrentUser.TrueName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + "确认书.xls";
            string StrHandWorkCopyName = CurrentUser.TrueName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + "手工台帐.xls";
            string StrKeyConnectCopyName = CurrentUser.TrueName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + "钥匙交接表.xls";
            string StrBorrowCopyName = CurrentUser.TrueName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + "钥匙借用登记表.xls";

            StrCopyName = Server.MapPath("~/Confirmation/" + StrCopyName);       //确认书路径
            File.Copy(Server.MapPath("~/Confirmation/确认书.xls"), StrCopyName, false);
            AppendText(StrCopyName, dt, 6, 1);

            StrHandWorkCopyName = Server.MapPath("~/Confirmation/" + StrHandWorkCopyName);       //手工台帐
            File.Copy(Server.MapPath("~/Confirmation/手工台帐.xls"), StrHandWorkCopyName, false);
            AppendText(StrHandWorkCopyName, dt, 4, 2);

            StrKeyConnectCopyName = Server.MapPath("~/Confirmation/" + StrKeyConnectCopyName);       //钥匙交接表
            File.Copy(Server.MapPath("~/Confirmation/钥匙交接表.xls"), StrKeyConnectCopyName, false);
            AppendText(StrKeyConnectCopyName, dt, 4, 3);

            StrBorrowCopyName = Server.MapPath("~/Confirmation/" + StrBorrowCopyName);       //钥匙借用登记表
            File.Copy(Server.MapPath("~/Confirmation/钥匙借用登记表.xls"), StrBorrowCopyName, false);
            AppendText(StrBorrowCopyName, dt, 4, 4);
        }
        #endregion

        #region 中信车辆入库
        /// <summary>
        /// 中信车辆入库
        /// </summary>
        private void Car_Into()
        {
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_Car_Detail.GetModifiedDict();  //获取修改集合
            if (modifiedDict.Count != 0)
            {
                System.Data.DataTable dt = CreateTb();
                List<string> list = new List<string>();  //声明集合，存放需要执行的sql语句
                string[] tb_Name_Count = DDL_Bank.SelectedValue.ToString().Split('_');   //获取下拉列表集合值
                string tb_Name = "tb_Car_" + tb_Name_Count[0] + "_" + tb_Name_Count[1].ToString(); //拼接表名
                string ErrorTxt = string.Empty;     //错误提示信息
                int Statu_Count = 0;            //记录入库台数
                string CarListCount = string.Empty; //生成车辆模版信息
                DataRow[] dataRow = ((System.Data.DataTable)ViewState["DealerName"]).Select("DealerName='" + ddl_Dealer.SelectedValue.ToString() + "' and BankName='" + DDL_Bank.SelectedText + "'");
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"gb2312\"?><stream>");
                sb.Append("<action>DLCDIGSM</action>");     //交易代码      
                sb.Append("<userName>zxxtzl</userName>");   //登录名
                sb.AppendFormat("<hostNo>{0}</hostNo>", dataRow[0].ItemArray[4].ToString());     //借款企业id 
                sb.AppendFormat("<oprtName>{0}</oprtName>", CurrentUser.TrueName); //操作人名称
                sb.AppendFormat("<orderNo>{0}</orderNo>", DateTime.Now.ToString("yyyyMMddHHmmss"));       //交易流水号     唯一
                sb.Append("<pcgrtntNo></pcgrtntNo>");        // 纸质担保合同编号        可空
                sb.Append("<cmgrtcntNo></cmgrtcntNo>");     //动产质押担保合同编号        可空
                sb.AppendFormat("<whCode>{0}</whCode>", "WH00003057");             //仓库代码 
                sb.Append("<remark></remark>");             //备注
                sb.AppendFormat("<field1></field1><field2></field2><field3>{0}</field3>", "1");
                sb.AppendFormat("<totnum></totnum>");      //总记录数
                sb.AppendFormat("<list name=\"lst\">");
                foreach (int rowIndex in modifiedDict.Keys)
                {
                    string Vin = G_Car_Detail.DataKeys[rowIndex][0].ToString();         //获取当前索引绑定车架号
                    string[] values = this.G_Car_Detail.Rows[rowIndex].Values;
                    if (values[0].ToString() == "True")     //是否入库状态
                    {
                        if (int.Parse(values[1].ToString()) > 0)
                        {
                            //2014年4月15日
                            list.Add(string.Format("update {0} set KeyCount='{1}',TransitTime=getdate(),Statu=1,UpdateID='{2}',UpdateTime=getdate() where Vin='{3}'", tb_Name, values[1].ToString(), CurrentUser.UserId, Vin));
                            CarListCount += string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}|", values[8].Trim().ToString(), values[4].Trim().ToString(), values[7].Trim().ToString(), values[9].Trim().ToString(), values[1].Trim().ToString(), "良好", values[3].Trim().ToString(), values[5].Trim().ToString(), values[6].Trim().ToString(), values[9].Trim().ToString(), ddl_Dealer.SelectedValue.ToString());
                            Statu_Count++;
                            sb.AppendFormat("<row><cmdCode>{0}</cmdCode>", "CAR00" + rowIndex);       //商品代码
                            sb.AppendFormat("<stkNum>{0}</stkNum>", "1");      //入库数量
                            sb.AppendFormat("<istkPrc>{0}</istkPrc>", values[10]);    //入库单价
                            sb.AppendFormat("<vin>{0}</vin>", values[7]);     //车架号
                            sb.AppendFormat("<hgzNo>{0}</hgzNo>", values[8]); //合格证编号
                            sb.AppendFormat("<carPrice>{0}</carPrice>", values[10]);   //车价
                            sb.AppendFormat("<loanCode>{0}</loanCode>", values[3]);   //融资编号
                            sb.AppendFormat("<field4></field4><field5></field5><field6></field6><field7></field7><field8></field8><field9></field9><field10></field10><field11></field11><field12></field12><field13></field13></row>");
                        }
                        else
                        {
                            ErrorTxt = "第" + (rowIndex + 1) + "行钥匙数不能为0";
                        }
                    }
                }
                if (ErrorTxt.Length == 0)
                {
                    try
                    {
                        if (list.Count > 0)
                        {
                            sb.Append("</list></stream>").Replace("<totnum></totnum>", string.Format("<totnum>{0}</totnum>", Statu_Count.ToString()));
                            list.Add(string.Format(@"insert into tb_CarMasterplate (DealerID,DealerName,BankID,BankName,CarList,CountCar,CreateID,CreateName,CreateTime,TypeID,isDel) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',getdate(),'1','0')", tb_Name_Count[1], ddl_Dealer.SelectedValue.ToString(), tb_Name_Count[0], tb_Name_Count[2], CarListCount, Statu_Count, CurrentUser.UserId, CurrentUser.TrueName));
                            list.Add(string.Format("insert into ZX_SCF ([action],RequestXml,RequestDate,RequestID,[Status]) values ('DLCDIGSM','{0}',GETDATE(),'{1}',0)", sb.ToString(), CurrentUser.UserId));
                            int number = new Citic.BLL.Car().SqlTran(list);
                            if (number > 0)
                            {
                                FineUI.Alert.Show("入库" + Statu_Count + "台");
                                ViewState.Remove("Car_Transit_List");
                                this.G_Car_Detail.DataSource = (System.Data.DataTable)ViewState["Car_Transit_List"];
                                this.G_Car_Detail.DataBind();
                            }
                            else
                            {
                                FineUI.Alert.Show("修改失败！", FineUI.MessageBoxIcon.Error);
                            }
                        }

                    }
                    catch
                    {
                        FineUI.Alert.Show("生成入库确认书时失败", FineUI.MessageBoxIcon.Error);
                    }
                }
                else
                {
                    FineUI.Alert.Show(ErrorTxt, FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("没有修改任何数据", FineUI.MessageBoxIcon.Error);
            }
        }
        #endregion

        private void Btn_Again_Bind_Click_1(object sender, EventArgs e)
        {
            Dictionary<int, Dictionary<string, string>> modifiedDict = G_Car_Detail.GetModifiedDict();  //获取修改集合
            if (modifiedDict.Count != 0)
            {
                List<string> list = new List<string>();  //声明集合，存放需要执行的sql语句
                string[] tb_Name_Count = DDL_Bank.SelectedValue.ToString().Split('_');   //获取下拉列表集合值
                string tb_Name = "tb_Car_" + tb_Name_Count[0] + "_" + tb_Name_Count[1].ToString(); //拼接表名
                string ErrorTxt = string.Empty;     //错误提示信息
                int Statu_Count = 0;            //记录入库台数
                string CarListCount = string.Empty;
                foreach (int rowIndex in modifiedDict.Keys)
                {
                    string Vin = G_Car_Detail.DataKeys[rowIndex][0].ToString();         //获取当前索引绑定车架号
                    string[] values = this.G_Car_Detail.Rows[rowIndex].Values;
                    if (values[0].ToString() == "True")     //是否入库状态
                    {
                        list.Add(string.Format("update {0} set KeyCount='{1}',TransitTime=getdate(),Statu=1,UpdateID='{2}',UpdateTime=getdate() where Vin='{3}'", tb_Name, values[1].ToString(), CurrentUser.UserId, Vin));
                        CarListCount += string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}|", values[8].Trim().ToString(), values[4].Trim().ToString(), values[7].Trim().ToString(), values[9].Trim().ToString(), values[1].Trim().ToString(), "良好", values[3].Trim().ToString(), values[5].Trim().ToString(), values[6].Trim().ToString(), values[9].Trim().ToString(), ddl_Dealer.SelectedValue.ToString());
                        Statu_Count++;
                    }
                }
            }
        }
    }
}