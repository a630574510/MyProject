using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Xml;
namespace Citic_Web.BankInterface
{
    public partial class ZX_ShowSCF : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string type = Request.QueryString["type"].ToString();
                string id = Request.QueryString["id"].ToString();
                string clss = Request.QueryString["clss"].ToString();
                if (clss.Equals("ZX"))
                {
                    DataSet ds = CarBll.GetList(string.Format("select * from ZX_SCF where id='{0}'", id));
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(ds.Tables[0].Rows[0]["ResponseXml"].ToString());
                    string strAction = ds.Tables[0].Rows[0]["action"].ToString();
                    if (string.Equals(xmldoc.ChildNodes[1]["status"].InnerText, "AAAAAAA"))
                    {
                        if (strAction.Equals("DLCDLMLQ"))
                        {
                            this.G_List_DLCDLMLQ.Visible = true;
                            this.G_List_DLCDLMLQ.DataSource = Create(Create(type), ds.Tables[0].Rows[0]["ResponseXml"].ToString(), strAction);
                            this.G_List_DLCDLMLQ.DataBind();
                        }
                        else if (strAction.Equals("DLCDWMLQ"))
                        {
                            this.G_List_DLCDWMLQ.Visible = true;   //2014年5月20日
                            this.G_List_DLCDWMLQ.DataSource = Create(Create(type), ds.Tables[0].Rows[0]["ResponseXml"].ToString(), strAction);
                            this.G_List_DLCDWMLQ.DataBind();
                        }
                        else if (true)
                        {

                        }
                    }
                    else
                    {
                        FineUI.Alert.ShowInTop("中信交易异常", FineUI.MessageBoxIcon.Error);
                    }
                }
                else if (clss.Equals("GD"))
                {
                    DataSet ds = CarBll.GetList(string.Format("select * from tb_ToGDMessage where ID='{0}'", id));
                    if (int.Parse(ds.Tables[0].Rows[0]["Status"].ToString()) > 1)
                    {
                        FineUI.Alert.ShowInTop(ds.Tables[0].Rows[0]["ErrMessage"].ToString(), FineUI.MessageBoxIcon.Error);
                    }
                    else
                    {
                        XmlDocument xmldoc = new XmlDocument();
                        xmldoc.LoadXml(ds.Tables[0].Rows[0]["ResponseSource"].ToString());
                        string strAction = ds.Tables[0].Rows[0]["FTranCode"].ToString();
                        if (ds.Tables[0].Rows[0]["ErrMessage"].ToString().Length == 0)
                        {
                            if (strAction.Equals("Q412"))
                            {
                                //2014年5月21日
                                this.G_Q412.Visible = true;      //光大汇票显示
                                this.G_Q412.DataSource = Create(Create(type), ds.Tables[0].Rows[0]["ResponseSource"].ToString(), strAction);
                                this.G_Q412.DataBind();
                            }
                            else if (strAction.Equals("Q414"))
                            {
                                this.G_Q414.Visible = true;      //光大发车显示
                                this.G_Q414.DataSource = Create(Create(type), ds.Tables[0].Rows[0]["ResponseSource"].ToString(), strAction);
                                this.G_Q414.DataBind();
                            }
                            else if (strAction.Equals("Q406"))
                            {
                                this.G_Q406.Visible = true;      //光大合格证显示 2014年5月21日 
                                this.G_Q406.DataSource = Create(Create(type), ds.Tables[0].Rows[0]["ResponseSource"].ToString(), strAction);
                                this.G_Q406.DataBind();
                            }
                        }
                        else
                        {
                            FineUI.Alert.ShowInTop(ds.Tables[0].Rows[0]["ErrMessage"].ToString(), FineUI.MessageBoxIcon.Error);
                        }
                    }
                }

            }
        }
        private DataTable Create(string type)
        {
            DataTable dt = new DataTable();
            if (type.Equals("DLCDLMLQ"))
            {
                dt.Columns.Add("loanCode");     //融资编号
                dt.Columns.Add("scftxNo");      //放款批次号
                dt.Columns.Add("loanAmt");      //融资金额 
                dt.Columns.Add("bailRat");      //保证金比例
                dt.Columns.Add("slfcapRat");    //自有资金比例
                dt.Columns.Add("fstblRat");     //首付保证金可提货比例
                dt.Columns.Add("loanstDate");   //融资起始日
                dt.Columns.Add("loanendDate");  //融资到期日
                dt.Columns.Add("procrt");       //授信产品
                dt.Columns.Add("operOrg");      //经办行
                dt.Columns.Add("bizMod");       //业务模式
                dt.Columns.Add("field1");       //备用字段1 
                dt.Columns.Add("field2");       //备用字段2 
                dt.Columns.Add("field3");       //备用字段3 
            }
            else if (type.Equals("DLCDWMLQ"))
            {
                dt.Columns.Add("lonNm");     //借款企业名称 
                dt.Columns.Add("whName");      //仓库名称
                dt.Columns.Add("bkwhCode");      //仓库代码
                dt.Columns.Add("whLevel");      //仓库级别
                dt.Columns.Add("operOrg");    //经办行
                dt.Columns.Add("address");     //地址
                dt.Columns.Add("phone");   //电话
                dt.Columns.Add("field1");       //备用字段1 
                dt.Columns.Add("field2");       //备用字段2 
                dt.Columns.Add("field3");       //备用字段3 
            }
            else if (type.Equals("Q412"))
            {
                dt.Columns.Add("BF_ID");        //票据ID
                dt.Columns.Add("ACPT_PRTL_NO"); //承兑协议号
                dt.Columns.Add("BF_NO");        //票号
                dt.Columns.Add("BNFO_APPLY_CUST");      //出票人名称
                dt.Columns.Add("BNFO_BILL_PAYEE");  //收款人名称
                dt.Columns.Add("BNFO_BILL_MONEY");  //金额
                dt.Columns.Add("BNFO_ISSUE_DT");    //出票日
                dt.Columns.Add("BNFO_BILL_MATURE_DT");  //票面到期日
                dt.Columns.Add("BILL_STATUS");  //票据状态
                dt.Columns.Add("HXCS_ID");      //核心厂商ID
                dt.Columns.Add("JXS_ID");       //经销商ID
                dt.Columns.Add("RESERVE1");
                dt.Columns.Add("RESERVE2");
                dt.Columns.Add("RESERVE3");
            }
            else if (type.Equals("Q414"))
            {
                dt.Columns.Add("SEND_CAR_ID");        //发车信息ID
                dt.Columns.Add("JXS_ID"); //经销商ID
                dt.Columns.Add("HXCS_ID");        //核心厂商ID
                dt.Columns.Add("PI_NO");      //合格证编号
                dt.Columns.Add("DJ_NO");  //车辆识别代号 (车架)
                dt.Columns.Add("SEND_CAR_DATE");  //发车日期
                dt.Columns.Add("CAR_MODEL");    //汽车型号
                dt.Columns.Add("ENGINE_MODEL");  //发动机号
                dt.Columns.Add("CAR_BRAND");  //品牌
                dt.Columns.Add("CAR_COLOR");      //颜色
                dt.Columns.Add("PI_AMOUNT");       //合格证金额
                dt.Columns.Add("BF_ID");       //对应票据ID
                dt.Columns.Add("TRACKING_NUMBER");       //快递单号
                dt.Columns.Add("REMARK");       //备注
                dt.Columns.Add("RESERVE1");
                dt.Columns.Add("RESERVE2");
                dt.Columns.Add("RESERVE3");
            }
            else if (type.Equals("Q406"))
            {
                dt.Columns.Add("PI_ID");        //合格证id
                dt.Columns.Add("JXS_ID"); //经销商ID
                dt.Columns.Add("JXS_NAME");        //经销商名称
                dt.Columns.Add("HXCS_ID");      //核心厂商ID
                dt.Columns.Add("HXCS_NAME");  //核心厂商名称
                dt.Columns.Add("PI_NO");  //合格证编号
                dt.Columns.Add("DJ_NO");    //车辆识别代号
                dt.Columns.Add("CAR_MODEL");  //汽车型号
                dt.Columns.Add("ENGINE_MODEL");  //发动机号
                dt.Columns.Add("CAR_BRAND");      //品牌
                dt.Columns.Add("CAR_COLOR");       //颜色
                dt.Columns.Add("PI_AMOUNT");       //合格证金额
                dt.Columns.Add("BF_NO");       //对应票号
                dt.Columns.Add("BF_ID");       //对应票据id
                dt.Columns.Add("PI_STATUS");    //合格证状态
                dt.Columns.Add("CAR_STATUS");   //车辆状态
                dt.Columns.Add("KEY_NUM");      //钥匙数量
                dt.Columns.Add("MATURE_DATE");   //合格证到期日
                dt.Columns.Add("CAR_STOCK_ADD");      //车辆在库地址
                dt.Columns.Add("RESERVE1");
                dt.Columns.Add("RESERVE2");
                dt.Columns.Add("RESERVE3");
            }
            return dt;
        }

        private DataTable Create(DataTable dt, string xml, string Action)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            if (Action.Equals("DLCDLMLQ"))
            {
                for (int i = 0; i < xmldoc["stream"]["list"].ChildNodes.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["loanCode"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["loanCode"].InnerText;
                    dr["scftxNo"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["scftxNo"].InnerText;
                    dr["loanAmt"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["loanAmt"].InnerText;
                    dr["bailRat"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["bailRat"].InnerText;
                    dr["slfcapRat"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["slfcapRat"].InnerText;
                    dr["fstblRat"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["fstblRat"].InnerText;
                    dr["loanstDate"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["loanstDate"].InnerText;
                    dr["loanendDate"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["loanendDate"].InnerText;
                    dr["procrt"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["procrt"].InnerText;
                    dr["operOrg"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["operOrg"].InnerText;
                    dr["bizMod"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["bizMod"].InnerText;
                    dr["field1"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["field1"].InnerText;
                    dr["field2"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["field2"].InnerText;
                    dr["field3"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["field3"].InnerText;
                    dt.Rows.Add(dr);
                }
            }
            else if (Action.Equals("DLCDWMLQ"))
            {
                for (int i = 0; i < xmldoc["stream"]["list"].ChildNodes.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["lonNm"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["lonNm"].InnerText;
                    dr["whName"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["whName"].InnerText;
                    dr["bkwhCode"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["bkwhCode"].InnerText;
                    dr["whLevel"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["whLevel"].InnerText == "1" ? "一级仓库" : "二级仓库";
                    dr["operOrg"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["operOrg"].InnerText;
                    dr["address"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["address"].InnerText;
                    dr["phone"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["phone"].InnerText;
                    dr["field1"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["field1"].InnerText;
                    dr["field2"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["field2"].InnerText;
                    dr["field3"] = xmldoc["stream"]["list"].SelectNodes("row")[i]["field3"].InnerText;
                    dt.Rows.Add(dr);
                }
            }
            else if (Action.Equals("Q412"))
            {
                for (int i = 0; i < xmldoc["Out"]["Body"].SelectNodes("Frame").Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["BF_ID"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["BF_ID"].InnerText;
                    dr["ACPT_PRTL_NO"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["ACPT_PRTL_NO"].InnerText;
                    dr["BF_NO"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["BF_NO"].InnerText;
                    dr["BNFO_APPLY_CUST"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["BNFO_APPLY_CUST"].InnerText;
                    dr["BNFO_BILL_PAYEE"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["BNFO_BILL_PAYEE"].InnerText;
                    dr["BNFO_BILL_MONEY"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["BNFO_BILL_MONEY"].InnerText;
                    dr["BNFO_ISSUE_DT"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["BNFO_ISSUE_DT"].InnerText;
                    dr["BNFO_BILL_MATURE_DT"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["BNFO_BILL_MATURE_DT"].InnerText;
                    dr["BILL_STATUS"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["BILL_STATUS"].InnerText.Replace("1", "签发").Replace("2", "到期收款").Replace("3", "未用退回").Replace("5", "垫款").Replace("6", "销记").Replace("9", "信管发起");
                    dr["HXCS_ID"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["HXCS_ID"].InnerText;
                    dr["JXS_ID"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["JXS_ID"].InnerText;
                    dr["RESERVE1"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["RESERVE1"].InnerText;
                    dr["RESERVE2"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["RESERVE2"].InnerText;
                    dr["RESERVE3"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["RESERVE3"].InnerText;
                    dt.Rows.Add(dr);
                }

            }
            else if (Action.Equals("Q414"))
            {
                for (int i = 0; i < xmldoc["Out"]["Body"].SelectNodes("Frame").Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["SEND_CAR_ID"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["SEND_CAR_ID"].InnerText;
                    dr["JXS_ID"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["JXS_ID"].InnerText;
                    dr["HXCS_ID"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["HXCS_ID"].InnerText;
                    dr["PI_NO"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["PI_NO"].InnerText;
                    dr["DJ_NO"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["DJ_NO"].InnerText;
                    dr["SEND_CAR_DATE"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["SEND_CAR_DATE"].InnerText;
                    dr["CAR_MODEL"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["CAR_MODEL"].InnerText;
                    dr["ENGINE_MODEL"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["ENGINE_MODEL"].InnerText;
                    dr["CAR_BRAND"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["CAR_BRAND"].InnerText;
                    dr["CAR_COLOR"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["CAR_COLOR"].InnerText;
                    dr["PI_AMOUNT"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["PI_AMOUNT"].InnerText;
                    dr["BF_ID"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["BF_ID"].InnerText;
                    dr["TRACKING_NUMBER"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["TRACKING_NUMBER"].InnerText;
                    dr["RESERVE1"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["RESERVE1"].InnerText;
                    dr["RESERVE2"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["RESERVE2"].InnerText;
                    dr["RESERVE3"] = xmldoc["Out"]["Body"].SelectNodes("Frame")[i]["RESERVE3"].InnerText;
                    dt.Rows.Add(dr);
                }
            }
            else if (Action.Equals("Q406"))
            {
                DataRow dr = dt.NewRow();
                dr["PI_ID"] = xmldoc["Out"]["Body"]["PI_ID"].InnerText;
                dr["JXS_ID"] = xmldoc["Out"]["Body"]["JXS_ID"].InnerText;
                dr["JXS_NAME"] = xmldoc["Out"]["Body"]["JXS_NAME"].InnerText;
                dr["HXCS_ID"] = xmldoc["Out"]["Body"]["HXCS_ID"].InnerText;
                dr["HXCS_NAME"] = xmldoc["Out"]["Body"]["HXCS_NAME"].InnerText;
                dr["PI_NO"] = xmldoc["Out"]["Body"]["PI_NO"].InnerText;
                dr["DJ_NO"] = xmldoc["Out"]["Body"]["DJ_NO"].InnerText;
                dr["CAR_MODEL"] = xmldoc["Out"]["Body"]["CAR_MODEL"].InnerText;
                dr["ENGINE_MODEL"] = xmldoc["Out"]["Body"]["ENGINE_MODEL"].InnerText;
                dr["CAR_BRAND"] = xmldoc["Out"]["Body"]["CAR_BRAND"].InnerText;
                dr["CAR_COLOR"] = xmldoc["Out"]["Body"]["CAR_COLOR"].InnerText;
                dr["PI_AMOUNT"] = xmldoc["Out"]["Body"]["PI_AMOUNT"].InnerText;
                dr["BF_NO"] = xmldoc["Out"]["Body"]["BF_NO"].InnerText;
                dr["BF_ID"] = xmldoc["Out"]["Body"]["BF_ID"].InnerText;
                dr["PI_STATUS"] = xmldoc["Out"]["Body"]["PI_STATUS"].InnerText.Replace("400", "已入库").Replace("450", "出库申请已提交").Replace("500", "出库审核流程中").Replace("700", "已出库").Replace("760", "出库审核通过").Replace("800", "超范围待确认").Replace("810", "不监管");
                dr["CAR_STATUS"] = xmldoc["Out"]["Body"]["CAR_STATUS"].InnerText.Replace("400", "已入库").Replace("700", "已出库").Replace("750", "在途").Replace("810", "不监管");
                dr["KEY_NUM"] = xmldoc["Out"]["Body"]["KEY_NUM"].InnerText;
                dr["MATURE_DATE"] = xmldoc["Out"]["Body"]["MATURE_DATE"].InnerText;
                dr["CAR_STOCK_ADD"] = xmldoc["Out"]["Body"]["CAR_STOCK_ADD"].InnerText;
                dr["RESERVE1"] = xmldoc["Out"]["Body"]["RESERVE1"].InnerText;
                dr["RESERVE2"] = xmldoc["Out"]["Body"]["RESERVE2"].InnerText;
                dr["RESERVE3"] = xmldoc["Out"]["Body"]["RESERVE3"].InnerText;
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}