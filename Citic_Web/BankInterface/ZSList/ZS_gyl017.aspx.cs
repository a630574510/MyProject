using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Data;
using System.Text;

namespace Citic_Web.BankInterface.ZSList
{
    public partial class ZS_gyl017 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ZSList = string.Format("ZSList_{0}", CurrentUser.UserId.ToString());
                if (Cache[ZSList] != null)
                {
                    DataTable dt = (DataTable)Cache[ZSList];

                    this.DDL_Dealer.DataTextField = "DealerName";

                    this.DDL_Dealer.DataValueField = "ZS_ID";
                    this.DDL_Dealer.DataSource = dt;
                    this.DDL_Dealer.DataBind();
                    DDL_Dealer.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));
                }
                else
                {
                    Cache.Insert(ZSList, new ZS_gyl001().BindCompany());

                    DataTable dt = (DataTable)Cache[ZSList];
                    this.DDL_Dealer.DataTextField = "DealerName";
                    this.DDL_Dealer.DataValueField = "ZS_ID";
                    this.DDL_Dealer.DataSource = dt;
                    this.DDL_Dealer.DataBind();
                    DDL_Dealer.Items.Insert(0, new FineUI.ListItem("——请选择——", "-1"));
                }

            }
        }
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