using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
namespace Citic_Web.BankInterface
{
    public partial class GD_Q414 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompany();
            }
        }
        protected void Btn_Add_Search_Click(object sender, EventArgs e)
        {
            if (this.DDL_Dealer.SelectedValue.ToString() != "-1")
            {
                if (this.dp_End.Text.Trim().Length != 0 && this.dp_Start.Text.Trim().Length != 0)
                {
                    TimeSpan ts = this.dp_End.SelectedDate.Value.Subtract(DateTime.Now.Date);

                    if (int.Parse(ts.TotalDays.ToString()) > 0)
                    {
                        FineUI.Alert.ShowInTop("结束日期不能大于今天", FineUI.MessageBoxIcon.Error);

                    }
                    else
                    {
                        ts = this.dp_End.SelectedDate.Value.Subtract(this.dp_Start.SelectedDate.Value);
                        if (int.Parse(ts.TotalDays.ToString()) >= 30)
                        {
                            FineUI.Alert.ShowInTop("结束日期与开始日期不能超过30天", FineUI.MessageBoxIcon.Error);
                        }
                        else
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append("<CHANNEL_CODE>0231J001</CHANNEL_CODE>");
                            sb.AppendFormat("<JXS_ID>{0}</JXS_ID>", this.DDL_Dealer.SelectedValue.ToString());
                            sb.AppendFormat("<SEND_CAR_DATE_START>{0}</SEND_CAR_DATE_START>", dp_Start.SelectedDate.Value.ToString("yyyyMMdd"));
                            sb.AppendFormat("<SEND_CAR_DATE_END>{0}</SEND_CAR_DATE_END>", dp_End.SelectedDate.Value.ToString("yyyyMMdd"));
                            sb.AppendFormat("<QISHI>1</QISHI><BISHU>99</BISHU>");
                            List<string> list = new List<string>();

                            string InsertSql = string.Format("insert into tb_ToGDMessage(FTranCode,TrmSeqNum,RequestSource,RequestPe_ID,[Status],RequestDate,insertValue)values ('Q414','{0}','{1}','{2}','0',GETDATE(),'{3}')", DateTime.Now.ToString("yyyyMMddHHmmssff"), sb.ToString(), CurrentUser.UserId, this.DDL_Dealer.SelectedText);
                            list.Add(InsertSql);

                            if (CarBll.SqlTran(list) > 0)
                            {
                                FineUI.Alert.ShowInTop("添加成功，请稍后在下面查询结果查询！", FineUI.MessageBoxIcon.Information);
                            }
                            else
                            {
                                FineUI.Alert.ShowInTop("添加失败，请核对信息！", FineUI.MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    FineUI.Alert.ShowInTop("请选择正确日期", FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("请选择经销商", FineUI.MessageBoxIcon.Error);
            }
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            int RoleId = this.CurrentUser.RoleId;       //获取角色id    2014年5月21日
            string sql = string.Empty;
            if (RoleId == 10)
            {
                sql = string.Format("select * from tb_ToGDMessage where FTranCode='Q414' and [Status]='1' and CONVERT(varchar(100), RequestDate, 23) =CONVERT(varchar(100),GETDATE(), 23) and RequestPe_ID='{0}'", CurrentUser.UserId);
            }
            else
            {
                sql = "select * from tb_ToGDMessage where FTranCode='Q414' and [Status]='1' and CONVERT(varchar(100), RequestDate, 23) =CONVERT(varchar(100),GETDATE(), 23)";
            }


            DataSet ds = CarBll.GetList(sql);
            this.G_DealerName.DataSource = Correct(ds);
            this.G_DealerName.DataBind();
        }

        #region 经销商信息
        /// <summary>
        /// 绑定经销商信息 张繁 2014年5月14日
        /// </summary>
        private void BindCompany()
        {
            try
            {
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        int UserID_5 = this.CurrentUser.UserId;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=5 and UserID=" + UserID_5 + ") and D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>''").Tables[0];
                        break;
                    case 6:         //6为品牌专员
                        int UserID_6 = this.CurrentUser.UserId;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=6 and UserID=" + UserID_6 + ") and D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>''").Tables[0];
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        int SupID = this.CurrentUser.RelationID.Value;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and SupervisorID='" + SupID + "' and D_B_L.GD_ID<>'-1' and D_B_L.GD_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                }

                this.DDL_Dealer.DataTextField = "DealerName";

                this.DDL_Dealer.DataValueField = "GD_ID";
                this.DDL_Dealer.DataSource = (DataTable)ViewState["DealerName"];
                this.DDL_Dealer.DataBind();
                DDL_Dealer.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));


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

        private DataTable Correct(DataSet ds)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");       //id
            dt.Columns.Add("CUST_NAME");    //客户名称
            dt.Columns.Add("SEND_CAR_DATE_START");  //发车日期开始
            dt.Columns.Add("SEND_CAR_DATE_END");    //发车日期结束
            dt.Columns.Add("remark");           //备注
            dt.Columns.Add("RequestDate");      //请求日期
            dt.Columns.Add("ResponseDate");     //返回日期
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataRow dr_dr = dt.NewRow();    //2014年5月20日
                dr_dr["id"] = dr["ID"].ToString();
                dr_dr["CUST_NAME"] = dr["insertValue"].ToString();
                dr_dr["SEND_CAR_DATE_START"] = dr["RequestSource"].ToString().Split('>')[5].Split('<')[0].ToString();
                dr_dr["SEND_CAR_DATE_END"] = dr["RequestSource"].ToString().Split('>')[7].Split('<')[0].ToString();

                dr_dr["RequestDate"] = dr["RequestDate"].ToString();
                dr_dr["ResponseDate"] = dr["ResponseDate"].ToString();
                dr_dr["remark"] = dr["ErrMessage"].ToString();
                dt.Rows.Add(dr_dr);
            }
            return dt;
        }
    }
}