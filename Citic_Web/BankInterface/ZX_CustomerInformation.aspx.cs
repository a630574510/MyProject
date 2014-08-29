using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Citic.BLL;
using System.Data;
using System.Xml;
namespace Citic_Web.BankInterface
{
    public partial class ZX_CustomerInformation : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_Add_Search_Click(object sender, EventArgs e)
        {
            if (this.txt_ORG_CODE.Text.Trim().Length > 0)
            {
                List<string> list = new List<string>();
                StringBuilder sb = new StringBuilder();
                sb.Append("<?xml version=\"1.0\" encoding=\"GBK\"?>");
                sb.AppendFormat("<stream><action>DLCDCMLQ</action><userName>ZXXT</userName><orgCode>{0}</orgCode ></stream>", this.txt_ORG_CODE.Text.Trim());
                string InsertSql = string.Format("insert into ZX_SCF ([action],RequestXml,RequestDate,RequestID,[Status]) values ('DLCDCMLQ','{0}',GETDATE(),'{1}',0)", sb.ToString(), CurrentUser.UserId);
                list.Add(InsertSql);
                if (CarBll.SqlTran(list) > 0)
                {
                    FineUI.Alert.ShowInTop("添加成功，请稍后在下面查询结果查询！", FineUI.MessageBoxIcon.Information);
                    this.txt_ORG_CODE.Text = "";
                }
                else
                {
                    FineUI.Alert.ShowInTop("添加失败，请核对信息！", FineUI.MessageBoxIcon.Error);
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("请输入组织机构代码", FineUI.MessageBoxIcon.Error);
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
            //this.G_Error.DataSource = ErrorData(ds);
            //this.G_Error.DataBind();
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
    }
}