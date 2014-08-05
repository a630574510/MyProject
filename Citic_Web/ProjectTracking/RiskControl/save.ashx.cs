using System;
using System.Collections.Generic;
using System.Web;

namespace Citic_Web.ProjectTracking.RiskControl
{
    /// <summary>
    /// save 的摘要说明
    /// </summary>
    public class save : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            Citic.BLL.DealerXDReports XDBLL = new Citic.BLL.DealerXDReports();
            Citic.BLL.RiskQuestion RQBLL = new Citic.BLL.RiskQuestion();
            string result = string.Empty;
            context.Response.ContentType = "text/plain";
            string type = context.Request.Form["type"];
            int id = 0;
            if (context.Request.Form["id"] != null)
            {
                id = int.Parse(context.Request.Form["id"]);
            }
            if (!string.IsNullOrEmpty(type))
            {
                if (type == "basic")
                {
                    string czms = context.Request.Form["czms"];
                    string cd = context.Request.Form["cd"];
                    string cit = context.Request.Form["cit"];
                    bool flag = XDBLL.UpdateBasic(new Citic.Model.DealerXDReports() { OperationMode = czms, CheckDate = DateTime.Parse(cd), CheckInTime = string.IsNullOrEmpty(cit) ? 0 : decimal.Parse(cit), ID = id });
                    if (flag)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else if (type == "pic")
                {
                    string pic11 = context.Request.Form["pic11"];
                    string pic12 = context.Request.Form["pic12"];
                    string pic21 = context.Request.Form["pic21"];
                    string pic22 = context.Request.Form["pic22"];
                    string pic31 = context.Request.Form["pic31"];
                    string pic32 = context.Request.Form["pic32"];
                    string pic41 = context.Request.Form["pic41"];
                    string pic42 = context.Request.Form["pic42"];
                    string pic51 = context.Request.Form["pic51"];
                    string pic52 = context.Request.Form["pic52"];
                    string pic61 = context.Request.Form["pic61"];
                    string pic62 = context.Request.Form["pic62"];
                    string pic71 = context.Request.Form["pic71"];
                    string pic72 = context.Request.Form["pic72"];
                    Citic.Model.DealerXDReports model = new Citic.Model.DealerXDReports();
                    model.ID = id;
                    model.PIC_1_1 = pic11;
                    model.PIC_1_2 = pic12;
                    model.PIC_2_1 = pic21;
                    model.PIC_2_2 = pic22;
                    model.PIC_3_1 = pic31;
                    model.PIC_3_2 = pic32;
                    model.PIC_4_1 = pic41;
                    model.PIC_4_2 = pic42;
                    model.PIC_5_1 = pic51;
                    model.PIC_5_2 = pic52;
                    model.PIC_6_1 = pic61;
                    model.PIC_6_2 = pic62;
                    model.PIC_7_1 = pic71;
                    model.PIC_7_2 = pic72;
                    bool flag = XDBLL.UpdatePIC(model);
                    if (flag)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else if (type == "sgab")
                {
                    string sgab1 = context.Request.Form["sgab1"];
                    string sgab2 = context.Request.Form["sgab2"];
                    Citic.Model.DealerXDReports model = new Citic.Model.DealerXDReports();
                    model.ID = id;
                    model.SGAB_1 = sgab1;
                    model.SGAB_2 = sgab2;
                    bool flag = XDBLL.UpdateSGAB(model);
                    if (flag)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else if (type == "cws")
                {
                    string cwsname = context.Request.Form["cwsname"];
                    string cwspost = context.Request.Form["cwspost"];
                    string cwscontent = context.Request.Form["cwscontent"];
                    Citic.Model.DealerXDReports model = new Citic.Model.DealerXDReports();
                    model.ID = id;
                    model.CWS_Name = cwsname;
                    model.CWS_Post = cwspost;
                    model.CWS_Content = cwscontent;
                    bool flag = XDBLL.UpdateCWS(model);
                    if (flag)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else if (type == "cr")
                {
                    string cr = context.Request.Form["cr"];
                    Citic.Model.DealerXDReports model = new Citic.Model.DealerXDReports();
                    model.ID = id;
                    model.CheckResults = cr;
                    bool flag = XDBLL.UpdateCheckResult(model);
                    if (flag)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else if (type == "bis")
                {
                    string bisname = context.Request.Form["bisname"];
                    string bf = context.Request.Form["bf"];
                    string jj = context.Request.Form["jj"];
                    string bissex = context.Request.Form["bissex"];
                    string bisedu = context.Request.Form["bisedu"];
                    int bisage = context.Request.Form["bisage"] == string.Empty ? 0 : int.Parse(context.Request.Form["bisage"]);
                    string bisgsrksx = context.Request.Form["bisgsrksx"];
                    string bisha = context.Request.Form["bisha"];
                    string bisbrsjsx = context.Request.Form["bisbrsjsx"];
                    string bisstay = context.Request.Form["bisstay"];
                    string biseat = context.Request.Form["biseat"];
                    string biscs = context.Request.Form["biscs"];
                    string bisws = context.Request.Form["bisws"];
                    string biswb = context.Request.Form["biswb"];
                    string bissgtime = context.Request.Form["bissgtime"];
                    string bisjgtime = context.Request.Form["bisjgtime"];
                    string biswe = context.Request.Form["biswe"];
                    string bisefs = context.Request.Form["bisefs"];
                    Citic.Model.DealerXDReports model = new Citic.Model.DealerXDReports();
                    model.ID = id;
                    model.BIS_Age = bisage;
                    model.BIS_BRSJSX = bisbrsjsx;
                    model.BIS_CS = biscs;
                    model.BIS_Eat = biseat;
                    model.BIS_Edu = bisedu;
                    model.BIS_EFS = bisefs;
                    model.BIS_GSRKSX = bisgsrksx;
                    model.BIS_HA = bisha;
                    model.BIS_JGSTime = DateTime.Parse(bisjgtime);
                    model.BIS_Name = bisname;
                    model.BIS_Phone_JJ = jj;
                    model.BIS_Phone_PF = bf;
                    model.BIS_Sex = bissex;
                    model.BIS_SGTime = DateTime.Parse(bissgtime);
                    model.BIS_Stay = bisstay;
                    model.BIS_WB = biswb;
                    model.BIS_WE = biswe;
                    model.BIS_WS = bisws;
                    bool flag = XDBLL.UpdateBIS(model);
                    if (flag)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else if (type == "p")
                {
                    string hf_S = context.Request.Form["hf_S"];
                    string hf_SB = context.Request.Form["hf_SB"];
                    string hf_WP = context.Request.Form["hf_WP"];
                    string hf_HGZ = context.Request.Form["hf_HGZ"];
                    string hf_Keys = context.Request.Form["hf_Keys"];
                    string hf_Forms = context.Request.Form["hf_Forms"];
                    string hf_Shop = context.Request.Form["hf_Shop"];
                    string hf_SR = context.Request.Form["hf_SR"];
                    string hf_CK = context.Request.Form["hf_CK"];
                    string hf_CK2 = context.Request.Form["hf_CK2"];
                    string hf_SS = context.Request.Form["hf_SS"];
                    string hf_DFRY = context.Request.Form["hf_DFRY"];

                    Citic.Model.DealerXDReports model = new Citic.Model.DealerXDReports();
                    model.ID = id;
                    model.P_CK = hf_CK;
                    model.P_CK2 = hf_CK2;
                    model.P_DFRY = hf_DFRY;
                    model.P_Forms = hf_Forms;
                    model.P_HGZ = hf_HGZ;
                    model.P_Keys = hf_Keys;
                    model.P_S = hf_S;
                    model.P_SB = hf_SB;
                    model.P_Shop = hf_Shop;
                    model.P_SR = hf_SR;
                    model.P_SS = hf_SS;
                    model.P_WP = hf_WP;
                    bool flag = XDBLL.UpdateP(model);
                    if (flag)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else if (type == "end")
                {
                    string checkman = context.Request.Form["checkman"];
                    string checkdate = context.Request.Form["checkdate"];

                    Citic.Model.DealerXDReports model = new Citic.Model.DealerXDReports();
                    model.ID = id;
                    model.Checkman = checkman;
                    model.CheckDate2 = DateTime.Parse(checkdate);
                    bool flag = XDBLL.UpdateEnd(model);
                    if (flag)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else if (type == "risk")
                {
                    string ccdate = context.Request.Form["ccdate"];
                    string ccap = context.Request.Form["ccap"];
                    string ccunit = context.Request.Form["ccunit"];
                    string ccp = context.Request.Form["ccp"];
                    string ccpost = context.Request.Form["ccpost"];
                    string ccpphone = context.Request.Form["ccpphone"];
                    string cccontent = context.Request.Form["ccconent"];
                    string sqshop = context.Request.Form["sqshop"];
                    string sqbrand = context.Request.Form["sqbrand"];
                    string sqname = context.Request.Form["sqname"];
                    string sqphone = context.Request.Form["sqphone"];
                    string sqfbp = context.Request.Form["sqfbp"];
                    string sqfbpp = context.Request.Form["sqfbpp"];
                    string sqcontent = context.Request.Form["sqcontent"];
                    string sp = context.Request.Form["sp"];
                    string sphone = context.Request.Form["sphone"];
                    string sresult = context.Request.Form["sresult"];
                    string gd = context.Request.Form["gd"];
                    string wtclbf = context.Request.Form["wtclbf"];
                    string fxwtbmqz = context.Request.Form["fxwtbmqz"];
                    string qcjrzxyj = context.Request.Form["qcjrzxyj"];
                    string qcjrzxqz = context.Request.Form["qcjrzxqz"];
                    string glzxyj = context.Request.Form["glzxyj"];
                    string glzxqz = context.Request.Form["glzxqz"];
                    string createid = context.Request.Form["creatid"];

                    Citic.Model.RiskQuestion model = new Citic.Model.RiskQuestion();
                    model.ID = id;
                    model.CC_AP = ccap;
                    model.CC_Content = cccontent;
                    model.CC_Date = DateTime.Parse(ccdate);
                    model.CC_P = ccp;
                    model.CC_Post = ccpost;
                    model.CC_PPhone = ccpphone;
                    model.CC_Unit = ccunit;
                    model.FXWTBMQZ = fxwtbmqz;
                    model.GD = gd;
                    model.GLZXQZ = glzxqz;
                    model.GLZXYJ = glzxyj;
                    model.QCJRZXQZ = qcjrzxqz;
                    model.QCJRZXYJ = qcjrzxyj;
                    model.S_P = sp;
                    model.S_Phone = sphone;
                    model.S_Result = sresult;
                    model.SQ_Brand = sqbrand;
                    model.SQ_Content = sqcontent;
                    model.SQ_FBP = sqfbp;
                    model.SQ_FBPP = sqfbpp;
                    model.SQ_Name = sqname;
                    model.SQ_Phone = sqphone;
                    model.SQ_Shop = sqshop;
                    model.WTCLBF = wtclbf;
                    bool flag = RQBLL.Update(model);
                    if (flag)
                    {
                        result = "1";
                    }
                    else
                    {
                        result = "0";
                    }
                }
                else if (type == "ce")
                {
                    Citic.BLL.CarErrorCount CECBLL = new Citic.BLL.CarErrorCount();
                    string dealerid = context.Request.Form["dealerid"];
                    string bankid = context.Request.Form["bankid"];
                    string brandid = context.Request.Form["brandid"];
                    string dealername = context.Request.Form["dealername"];
                    string bankname = context.Request.Form["bankname"];
                    string brandname = context.Request.Form["brandname"];
                    string szsm = context.Request.Form["szsm"];
                    string szsmc = context.Request.Form["szsmc"];
                    string szsmr = context.Request.Form["szsmr"];
                    string xswhk = context.Request.Form["xswhk"];
                    string xswhkc = context.Request.Form["xswhkc"];
                    string xswhkr = context.Request.Form["xswhkr"];
                    string szyd = context.Request.Form["szyd"];
                    string szydc = context.Request.Form["szydc"];
                    string szydr = context.Request.Form["szydr"];
                    string zscl = context.Request.Form["zscl"];
                    string zsclc = context.Request.Form["zsclc"];
                    string zsclr = context.Request.Form["zsclr"];
                    string zyczsjc = context.Request.Form["zyczsjc"];
                    string zyczsjcc = context.Request.Form["zyczsjcc"];
                    string zyczsjcr = context.Request.Form["zyczsjcr"];
                    string zyclb = context.Request.Form["zyclb"];
                    string zyclbc = context.Request.Form["zyclbc"];
                    string zyclbr = context.Request.Form["zyclbr"];
                    string other = context.Request.Form["other"];
                    string otherc = context.Request.Form["otherc"];
                    string otherr = context.Request.Form["otherr"];
                    string userid = context.Request.Form["userid"];
                    Citic.Model.CarErrorCount model = new Citic.Model.CarErrorCount();
                    model.DealerID = int.Parse(dealerid);
                    model.BankID = int.Parse(bankid);
                    model.BrandID = int.Parse(brandid);
                    model.DealerName = dealername.Trim();
                    model.BankName = bankname.Trim();
                    model.BrandName = brandname.Trim();
                    model.SZSM = szsm;
                    model.SZSMC = int.Parse(szsmc);
                    model.SZSMR = szsmr;
                    model.XSWHK = context.Request.Form["xswhk"];
                    model.XSWHKC = int.Parse(xswhkc);
                    model.XSWHKR = xswhkr;
                    model.SZYD = szyd;
                    model.SZYDC = int.Parse(szydc);
                    model.SZYDR = szydr;
                    model.ZSCL = zscl;
                    model.ZSCLC = int.Parse(zsclc);
                    model.ZSCLR = zsclr;
                    model.ZYCZSJC = zyczsjc;
                    model.ZYCZSJCC = int.Parse(zyczsjcc);
                    model.ZYCZSJCR = zyczsjcr;
                    model.ZYCLB = zyclb;
                    model.ZYCLBC = int.Parse(zyclbc);
                    model.ZYCLBR = zyclbr;
                    model.Other = other;
                    model.OtherC = int.Parse(otherc);
                    model.OtherR = otherr;
                    model.CreateDate = DateTime.Now;
                    model.CreateID = int.Parse(userid);

                    try
                    {
                        int num = CECBLL.Add(model);
                        if (num > 0)
                        {
                            result = num.ToString();
                        }
                        else
                        {
                            result = "-1";
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
                context.Response.Write(result);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}