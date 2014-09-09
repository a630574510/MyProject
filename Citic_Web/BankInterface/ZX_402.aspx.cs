using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

namespace Citic_Web.BankInterface
{
    public partial class ZX_402 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            if (this.txt_PI_NO.Text.Trim().Length == 0 && this.txt_DJ_NO.Text.Trim().Length == 0)
            {
                FineUI.Alert.ShowInTop("合格证和车架必须填写一样");
            }
            else
            {
                int RoleId = this.CurrentUser.RoleId;       //获取角色id
                string sql = string.Empty;
                string dj = this.txt_DJ_NO.Text.Trim();
                string pi = this.txt_PI_NO.Text.Trim();

                if (RoleId == 10)
                {
                    sql = string.Format("select * from ZX_SCF where [action]='DLCDIGSM' and ([Status]='1' or [Status]='2' or [Status]='3') and RequestDate between CONVERT(varchar(100), GETDATE()-7, 23) and CONVERT(varchar(100), GETDATE()+1, 23) and RequestID='{0}' and (RequestXml like '%<vin>{1}</vin>%' or RequestXml like '%<hgzNo>{2}</hgzNo>%') order by ResponseDate desc", CurrentUser.UserId, dj, pi);
                }
                else
                {
                    sql = string.Format("select * from ZX_SCF where [action]='DLCDIGSM' and ([Status]='1' or [Status]='2' or [Status]='3') and RequestDate between CONVERT(varchar(100), GETDATE()-7, 23) and CONVERT(varchar(100), GETDATE()+1, 23) and (RequestXml like '%<vin>{0}</vin>%' or RequestXml like '%<hgzNo>{1}</hgzNo>%') order by ResponseDate desc", dj, pi);
                }
                DataTable dt = CarBll.GetList(sql).Tables[0];
                DataTable newdt = new DataTable();
                newdt.Columns.Add("id");
                newdt.Columns.Add("PI_NO");            //合格证编号/车架
                newdt.Columns.Add("Message");       //返回错误信息
                newdt.Columns.Add("RequestDate");      //提交时间
                newdt.Columns.Add("ResponseDate");      //返回时间
                if (dt.Rows.Count == 0)
                {
                    FineUI.Alert.ShowInTop("无法查询到数据对应车辆数据", FineUI.MessageBoxIcon.Information);
                }
                else
                {
                    XmlDocument xmldoc = new XmlDocument();
                    foreach (DataRow dr in dt.Rows)
                    {
                        DataRow dr_dt = newdt.NewRow();
                        dr_dt["id"] = dr["ID"].ToString();
                        dr_dt["PI_NO"] = pi.Length == 0 ? dj : pi;
                        xmldoc.LoadXml(dr["ResponseXml"].ToString());

                        dr_dt["Message"] = xmldoc["stream"]["statusText"].InnerText.ToString() == "交易成功" ? "成功入库" : xmldoc["stream"]["statusText"].InnerText.ToString();
                        dr_dt["RequestDate"] = dr["RequestDate"].ToString();
                        dr_dt["ResponseDate"] = dr["ResponseDate"].ToString();
                        newdt.Rows.Add(dr_dt);
                    }
                }


                this.G_Correct.DataSource = newdt;
                this.G_Correct.DataBind();
            }

        }
    }
}