using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
using System.Threading;
using System.Text;

namespace Citic_Web.BankInterface
{
    public partial class ZS_gyl001 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string ZSList = string.Format("ZSList_{0}", CurrentUser.UserId.ToString());
                if (Cache[ZSList] == null)
                {

                    Cache[ZSList] = BindCompany();
                }
                else
                {
                    Cache.Insert(ZSList, BindCompany());
                }

            }
        }

        #region 经销商信息
        /// <summary>
        /// 绑定经销商信息 张繁 2014年5月14日
        /// </summary>
        public DataTable BindCompany()
        {
            DataTable dt = new DataTable();
            try
            {

                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                switch (RoleId)
                {
                    case 1:         //1为超级管理员
                        dt = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and D_B_L.ZS_ID<>'-1' and D_B_L.ZS_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                    case 2:         //2为管理员
                        break;
                    case 3:         //3为业务经理
                        dt = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and D_B_L.ZS_ID<>'-1' and D_B_L.ZS_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                    case 4:         //4为市场经理
                        break;
                    case 5:         //5为市场专员
                        int UserID_5 = this.CurrentUser.UserId;
                        dt = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=5 and UserID=" + UserID_5 + ") and D_B_L.ZS_ID<>'-1' and D_B_L.ZS_ID<>''").Tables[0];
                        break;
                    case 6:         //6为品牌专员
                        int UserID_6 = this.CurrentUser.UserId;
                        dt = DealerBll.GetBankID_DealerID_BankName_List("and BankID in(select MappingID from tb_UserMapping where RoleID=6 and UserID=" + UserID_6 + ") and D_B_L.ZS_ID<>'-1' and D_B_L.ZS_ID<>''").Tables[0];
                        break;
                    case 7:         //7为调配专员
                        break;
                    case 8:         //8为银行
                        break;
                    case 9:         //9为厂家
                        break;
                    case 10:         //10为监管员
                        int SupID = this.CurrentUser.RelationID.Value;
                        dt = DealerBll.GetBankID_DealerID_BankName_List("AND D_L.IsDelete=0 and D_B_L.IsDelete=0 and D_B_L.CollaborateType=1 and SupervisorID='" + SupID + "' and D_B_L.ZS_ID<>'-1' and D_B_L.ZS_ID<>'' order by D_L.DealerName").Tables[0];
                        break;
                }
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
            return dt;

        }
        #endregion
        protected void Btn_Add_Search_Click(object sender, EventArgs e)
        {
            if (this.txt_custNo.Text.Trim().Length != 0 || this.txt_pledgeName.Text.Trim().Length != 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("<currentCustNo>{0}</currentCustNo>", "133100037547");     //当前系统客户号
                sb.AppendFormat("<custType>{0}</custType>", "01");       //当前客户类型        01-监管公司    02-授信客户 03-核心厂商
            }
            else
            {

            }
        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            int RoleId = this.CurrentUser.RoleId;       //获取角色id
            string sql = string.Empty;
            if (RoleId == 10)
            {
                sql = string.Format("select * from  ZX_SCF where [action]='DLCDCMLQ' and CONVERT(varchar(100), RequestDate, 23) =CONVERT(varchar(100),GETDATE(), 23) and [Status]=1 and RequestID='{0}'", CurrentUser.UserId);
            }
            else
            {
                sql = "select * from  ZX_SCF where [action]='DLCDCMLQ' and CONVERT(varchar(100), RequestDate, 23) =CONVERT(varchar(100),GETDATE(), 23) and [Status]=1 ";
            }
            DataSet ds = CarBll.GetList(sql);

            this.G_DealerName.DataSource = Correct(ds);
            this.G_DealerName.DataBind();
        }
        private DataTable Correct(DataSet ds)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("orgCode");      //组织机构代码
            dt.Columns.Add("ecifCode");     //客户id 
            dt.Columns.Add("custName");     //客户名称
            dt.Columns.Add("remark");       //备注
            dt.Columns.Add("RequestDate");       //请求时间
            dt.Columns.Add("ResponseDate");       //返回时间
            XmlDocument xmldoc = new XmlDocument();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                xmldoc.LoadXml(dr["ResponseXml"].ToString());
                DataRow dr_dt = dt.NewRow();
                string orgCode = dr["RequestXml"].ToString().Split('>')[7].Replace("</orgCode", "");
                dr_dt["RequestDate"] = dr["RequestDate"];
                dr_dt["ResponseDate"] = dr["ResponseDate"];
                if (string.Equals(xmldoc.ChildNodes[1]["status"].InnerText, "AAAAAAA"))
                {
                    if (xmldoc.ChildNodes[1]["totNum"].InnerText == "0")
                    {
                        dr_dt["orgCode"] = orgCode;
                        dr_dt["ecifCode"] = "";
                        dr_dt["custName"] = "";
                        dr_dt["remark"] = "此经销商还没有正式对接";

                        dt.Rows.Add(dr_dt);
                    }
                    else
                    {
                        dr_dt["orgCode"] = orgCode;
                        dr_dt["ecifCode"] = xmldoc.ChildNodes[1]["list"]["row"]["ecifCode"].InnerText;
                        dr_dt["custName"] = xmldoc.ChildNodes[1]["list"]["row"]["custName"].InnerText;
                        dr_dt["remark"] = "";
                        dt.Rows.Add(dr_dt);
                    }
                }
                else
                {
                    dr_dt["orgCode"] = orgCode;
                    dr_dt["ecifCode"] = "";
                    dr_dt["custName"] = "";
                    dr_dt["remark"] = "交易行为异常,错误码是：" + xmldoc.ChildNodes[1]["status"].InnerText;
                    dt.Rows.Add(dr_dt);
                }



            }
            return dt;
        }

        public static string RequestXml(string tr_code, string body)
        {
            Random r = new Random();
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<ap><head>");
            sb.AppendFormat("<tr_code>{0}</tr_code>", tr_code); //现金管理客户号
            sb.AppendFormat("<cms_corp_no>{0}</cms_corp_no>", "10000380"); //现金管理客户号
            sb.AppendFormat("<user_no></user_no>"); //用户号
            sb.AppendFormat("<org_code></org_code>");       //机构号
            sb.AppendFormat("<serial_no>{0}{1}</serial_no>", DateTime.Now.ToString("yyyyMMddHHmmss"), r.Next(1000, 10000).ToString());     //交易流水号
            sb.AppendFormat("<req_no></req_no>");   //请求号
            sb.AppendFormat("<tr_acdt>{0}</tr_acdt>", DateTime.Now.ToString("yyyyMMdd")); //交易日期
            sb.AppendFormat("<tr_time>{0}</tr_time>", DateTime.Now.ToString("HHmmss")); //交易时间
            sb.AppendFormat("<channel>5</channel>"); //渠道标识
            sb.AppendFormat("<sign>0</sign>");        //签名标识
            sb.AppendFormat("<file_flag>0</file_flag>"); //文件标识
            sb.AppendFormat("<reserved></reserved>");   //保留字段
            sb.AppendFormat("</head><body>");
            sb.AppendFormat("{0}", body);           //请求报文主体
            sb.AppendFormat("</body></ap>");
            return sb.ToString();
        }
    }
}