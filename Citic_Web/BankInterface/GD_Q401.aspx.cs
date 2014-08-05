using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;

namespace Citic_Web.BankInterface
{
    public partial class GD_Q401 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Btn_Add_Search_Click(object sender, EventArgs e)
        {
            if (this.txt_CUST_NAME.Text.Trim().Length != 0 || this.txt_ORG_CODE.Text.Trim().Length != 0)
            {
                string FTranCode = "Q401";          //交易码
                string TrmSeqNum = DateTime.Now.ToString("yyyyHHddmmssffff");     //流水终端号
                string xmltxt = "<CHANNEL_CODE>0231J001</CHANNEL_CODE>";    //接入机构号
                xmltxt += "<CUST_NAME>" + this.txt_CUST_NAME.Text.Trim() + "</CUST_NAME>";  //客户名称
                xmltxt += "<ORG_CODE>" + this.txt_ORG_CODE.Text.Trim() + "</ORG_CODE>";     //组织机构代码
                xmltxt += "<CUST_TYPE>20</CUST_TYPE>";  //客户类型  2014年5月21日
                xmltxt += "<QISHI>1</QISHI>";  //起始笔数
                xmltxt += "<BISHU>50</BISHU>"; //查询笔数
                string sql = "insert into tb_ToGDMessage (FTranCode,TrmSeqNum,RequestSource,RequestPe_ID,Status,RequestDate) values('" + FTranCode + "','" + TrmSeqNum + "','" + xmltxt + "','1',0,GETDATE())";
                int Num = new Citic.BLL.Inspection().ExecuteSql(sql);

                if (Num > 0)
                {
                    FineUI.Alert.ShowInTop("提交成功，请等1分钟后查询结果");
                }
                else
                {
                    FineUI.Alert.ShowInTop("提交失败");
                }
            }
            else
            {
                FineUI.Alert.ShowInTop("客户名称和组织机构代码必须输入一项", FineUI.MessageBoxIcon.Error);
            }

        }
        protected void Btn_Search_Click(object sender, EventArgs e)
        {
            //string sql = "select * from tb_ToGDMessage where FTranCode='Q401'  order by ID ASC";
            string sql = "select * from tb_ToGDMessage where FTranCode='Q401' AND RequestPe_ID=1 AND CONVERT(varchar(100), RequestDate, 23) =CONVERT(varchar(100), GETDATE(), 23)";
            DataSet ds = CarBll.GetList(sql);

            this.G_DealerName.DataSource = Correct(ds);
            this.G_DealerName.DataBind();
            this.G_Error.DataSource = ErrorData(ds);
            this.G_Error.DataBind();
        }
        #region 正确返回结果
        /// <summary>
        /// 正确返回 张繁 2014年1月20日
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private DataTable Correct(DataSet ds)
        {
            DataRow[] dr = ds.Tables[0].Select("Status=1");
            DataTable dt = new DataTable();
            dt.Columns.Add("CUST_ID");          //客户ID
            dt.Columns.Add("CUST_NAME");        //客户名称
            dt.Columns.Add("ORG_CODE");         //组织机构代码
            dt.Columns.Add("CUST_TYPE");        //客户类型
            dt.Columns.Add("CM_NAME");          //客户经理
            dt.Columns.Add("OFFICE_PHONE_NO");      //客户经理电话
            dt.Columns.Add("CELLPHONE_NO");     //客户经理手机
            dt.Columns.Add("EMAIL");        //客户经理E-MAIL
            dt.Columns.Add("RequestDate");         //提交时间
            XmlDocument xmldoc = new XmlDocument();
            for (int i = 0; i < dr.Length; i++)
            {
                string xml = dr[i].ItemArray[4].ToString();
                xmldoc.LoadXml(xml);
                XmlNode xn = xmldoc;
                for (int j = 1; j < xn["Out"]["Body"].ChildNodes.Count; j++)
                {
                    DataRow dr_dt = dt.NewRow();
                    dr_dt["CUST_ID"] = xn["Out"]["Body"].ChildNodes[j]["CUST_ID"].InnerText;        //客户ID
                    dr_dt["CUST_NAME"] = xn["Out"]["Body"].ChildNodes[j]["CUST_NAME"].InnerText;        //客户名称
                    dr_dt["ORG_CODE"] = xn["Out"]["Body"].ChildNodes[j]["ORG_CODE"].InnerText;        //组织机构代码
                    dr_dt["CUST_TYPE"] = xn["Out"]["Body"].ChildNodes[j]["CUST_TYPE"].InnerText.Replace("10", "核心厂商").Replace("20", "经销厂商");        //客户类型
                    dr_dt["CM_NAME"] = xn["Out"]["Body"].ChildNodes[j]["CM_NAME"].InnerText;        //客户经理
                    dr_dt["OFFICE_PHONE_NO"] = xn["Out"]["Body"].ChildNodes[j]["OFFICE_PHONE_NO"].InnerText;     //客户经理电话
                    dr_dt["CELLPHONE_NO"] = xn["Out"]["Body"].ChildNodes[j]["CELLPHONE_NO"].InnerText;    //客户经理手机
                    dr_dt["EMAIL"] = xn["Out"]["Body"].ChildNodes[j]["EMAIL"].InnerText;    //客户经理E-MAIL
                    dr_dt["RequestDate"] = dr[i].ItemArray[8].ToString();         //提交时间
                    dt.Rows.Add(dr_dt);
                }
                xmldoc.RemoveAll();
            }
            return dt;
        }
        #endregion

        #region 错误返回
        /// <summary>
        /// 错误返回 张繁 2014年1月20日
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        private DataTable ErrorData(DataSet ds)
        {
            DataRow[] dr = ds.Tables[0].Select("Status=2");
            DataTable dt = new DataTable();

            dt.Columns.Add("CUST_NAME");        //客户名称
            dt.Columns.Add("ORG_CODE");         //组织机构代码
            dt.Columns.Add("CUST_TYPE");        //客户类型
            dt.Columns.Add("RequestDate");      //提交时间
            dt.Columns.Add("ResponseDate");      //返回时间
            dt.Columns.Add("ErrMessage");       //返回结果
            XmlDocument xmldoc = new XmlDocument();
            for (int i = 0; i < dr.Length; i++)
            {
                string xml = "<in>" + dr[i].ItemArray[3].ToString() + "</in>";
                xmldoc.LoadXml(xml);
                XmlNode xn = xmldoc;
                DataRow dr_dt = dt.NewRow();
                dr_dt["CUST_NAME"] = xn["in"]["CUST_NAME"].InnerText;            //客户名称
                //dr_dt["ORG_CODE"] = xn["in"]["ORG_CODE"].InnerText;             //组织机构代码
                dr_dt["CUST_TYPE"] = xn["in"]["CUST_TYPE"].InnerText.Replace("10", "核心厂商").Replace("20", "经销厂商");            //客户类型
                dr_dt["RequestDate"] = dr[i].ItemArray[8].ToString();           //提交时间
                dr_dt["ResponseDate"] = dr[i].ItemArray[9].ToString();       //返回时间
                dr_dt["ErrMessage"] = dr[i].ItemArray[7].ToString();            //返回结果
                dt.Rows.Add(dr_dt);
                xmldoc.RemoveAll();
            }
            return dt;
        }
        #endregion
    }
}