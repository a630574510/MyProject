using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Xml;

namespace Citic_Web.BankInterface
{
    public partial class ZX_Financing : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCompany();
            }
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
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and D_B_L.ZX_ID<>'-1' and D_B_L.ZX_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and D_B_L.ZX_ID<>'-1' and D_B_L.ZX_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        int UserID_5 = this.CurrentUser.UserId;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=5 and UserID=" + UserID_5 + ") and D_B_L.ZX_ID<>'-1' and D_B_L.ZX_ID<>''").Tables[0];
                        break;
                    case 6:         //6为品牌专员
                        int UserID_6 = this.CurrentUser.UserId;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=6 and UserID=" + UserID_6 + ") and D_B_L.ZX_ID<>'-1' and D_B_L.ZX_ID<>''").Tables[0];
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        int SupID = this.CurrentUser.RelationID.Value;
                        ViewState["DealerName"] = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and SupervisorID='" + SupID + "' and D_B_L.ZX_ID<>'-1' and D_B_L.ZX_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                }

                this.DDL_Dealer.DataTextField = "DealerName";

                this.DDL_Dealer.DataValueField = "ZX_ID";
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

        protected void Btn_Add_Search_Click(object sender, EventArgs e)
        {
            if (!this.DDL_Dealer.SelectedValue.ToString().Equals("-1") && this.DatePicker1.Text.Trim().Length != 0)
            {
                List<string> list = new List<string>();
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"GBK\"?>");
                sb.AppendFormat("<stream><action>DLCDLMLQ</action><userName>ZXXT</userName><loncpId>{0}</loncpId><loanstDate>{1}</loanstDate></stream>", this.DDL_Dealer.SelectedValue.ToString(), Convert.ToDateTime(this.DatePicker1.Text.Trim()).ToString("yyyyMMdd"));
                string InsertSql = string.Format("insert into ZX_SCF ([action],RequestXml,RequestDate,RequestID,[Status],UpdateSql) values ('DLCDLMLQ','{0}',GETDATE(),'{1}',0,'{2}')", sb.ToString(), CurrentUser.UserId, this.DDL_Dealer.SelectedText.ToString() + "," + this.DatePicker1.Text.Trim());
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
            else
            {
                FineUI.Alert.ShowInTop("请填写查询条件", FineUI.MessageBoxIcon.Error);
            }
        }

        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            int RoleId = this.CurrentUser.RoleId;       //获取角色id
            string sql = string.Empty;
            if (RoleId == 10)
            {
                sql = string.Format("select * from  ZX_SCF where [action]='DLCDLMLQ' and [Status]=1 and CONVERT(varchar(100), RequestDate, 23) =CONVERT(varchar(100),GETDATE(), 23) and RequestID='{0}'", CurrentUser.UserId);
            }
            else
            {
                sql = "select * from  ZX_SCF where [action]='DLCDLMLQ' and [Status]=1 and CONVERT(varchar(100), RequestDate, 23) =CONVERT(varchar(100),GETDATE(), 23)";
            }

            DataSet ds = CarBll.GetList(sql);
            this.G_DealerName.DataSource = Correct(ds);
            this.G_DealerName.DataBind();
        }
        private DataTable Correct(DataSet ds)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");       //id
            dt.Columns.Add("custName");     //客户名称
            dt.Columns.Add("loanstDate");      //开票日期
            dt.Columns.Add("loanstList");      //汇票总数
            dt.Columns.Add("remark");       //备注
            dt.Columns.Add("RequestDate");       //请求时间
            dt.Columns.Add("ResponseDate");       //返回时间
            XmlDocument xmldoc = new XmlDocument();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                DataRow dr_dt = dt.NewRow();
                dr_dt["custName"] = dr["UpdateSql"].ToString();
                dr_dt["loanstDate"] = dr["RequestXml"].ToString().Split('>')[9].Split('<')[0].ToString();
                dr_dt["RequestDate"] = dr["RequestDate"].ToString();
                dr_dt["ResponseDate"] = dr["ResponseDate"].ToString();
                dr_dt["id"] = dr["id"].ToString();
                xmldoc.LoadXml(dr["ResponseXml"].ToString());
                if (string.Equals(xmldoc.ChildNodes[1]["status"].InnerText, "AAAAAAA"))
                {
                    int totNum = Convert.ToInt32(xmldoc.ChildNodes[1]["totNum"].InnerText.ToString());
                    dr_dt["loanstList"] = totNum;
                    dt.Rows.Add(dr_dt);
                }
                else
                {
                    dr_dt["remark"] = "交易行为异常,错误码是：" + xmldoc.ChildNodes[1]["status"].InnerText;
                    dt.Rows.Add(dr_dt);
                }
            }
            return dt;
        }
    }
}