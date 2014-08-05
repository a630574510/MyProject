using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Citic_Web.ProjectTracking.RiskControl
{
    /// <summary>
    /// search 的摘要说明
    /// </summary>
    public class search : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            Citic.BLL.Dealer_Bank Dealer_BankBll = new Citic.BLL.Dealer_Bank();
            Citic.BLL.StockError SEBLL = new Citic.BLL.StockError();
            Citic.BLL.Bank BankBll = new Citic.BLL.Bank();

            string from = context.Request.QueryString["_from"];
            if (!string.IsNullOrEmpty(from))
            {
                if (from.Equals("addrcquesbyday"))
                {
                    string id = context.Request.QueryString["_id"];
                    string result = string.Empty;
                    if (!string.IsNullOrEmpty(id))
                        result = BankBll.GetModel(int.Parse(id)).BankName;

                    context.Response.ContentType = "text/plain";
                    context.Response.Write(result);
                }
                else
                {
                    string content = context.Request.QueryString["term"];
                    bool isInt = Common.Common.IsInt(content);
                    if (!string.IsNullOrEmpty(content))
                    {
                        JArray ja = new JArray();

                        DataSet ds = null;
                        if (isInt)
                        {
                            ds = BankBll.GetList(20, string.Format(" BankID like '%{0}%' and IsDelete=0", content), "BankID"); ;
                        }
                        else
                        {
                            ds = BankBll.GetList(20, string.Format(" BankName like '%{0}%' and IsDelete=0", content), "BankID");
                        }

                        if (ds != null && ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    ja.Add(row["BankName"].ToString() + "_" + row["BankID"]);
                                }
                            }
                        }

                        context.Response.ContentType = "text/plain";
                        context.Response.Write(ja.ToString());
                        return;
                    }
                }
            }

            string term = context.Request.QueryString["term"];
            if (!String.IsNullOrEmpty(term))
            {
                JArray ja = new JArray();
                string where = string.Empty;
                bool isInt = Common.Common.IsInt(term);
                if (isInt)
                {
                    where = string.Format(" DealerID like '%{0}%'", term);
                }
                else
                {
                    where = string.Format(" DealerName like '%{0}%'", term);
                }
                where += " and CollaborateType=1";
                DataSet ds = Dealer_BankBll.GetList(20, where, "DealerID,DealerName", "DealerID", "DealerName");
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            ja.Add(row["DealerName"].ToString() + "_" + row["DealerID"].ToString());
                        }
                    }
                }

                context.Response.ContentType = "text/plain";
                context.Response.Write(ja.ToString());
            }

            string val = context.Request.QueryString["val"];
            if (!string.IsNullOrEmpty(val))
            {
                string bankid = context.Request.QueryString["bankid"];
                string dealerid = context.Request.QueryString["dealerid"];
                string error = string.Empty;
                switch (val)
                {
                    case "szyd":
                        error = "私自移动";
                        break;
                    case "szsm":
                        error = "私自售卖";
                        break;
                    case "xswhk":
                        error = "销售未还款";
                        break;
                    case "zscl":
                        error = "质损车辆";
                        break;
                    case "zyczsjc":
                        error = "质押车做试驾车";
                        break;
                    case "zyclb":
                        error = "质押车零部件被拆卸";
                        break;
                }
                string[] vins = SEBLL.GetVinsByBankIDAndDealerIDForArray(int.Parse(bankid), int.Parse(dealerid), error);
                StringBuilder result = new StringBuilder();
                if (vins != null && vins.Length > 0)
                {
                    result.Append("<div>");
                    foreach (string str in vins)
                    {
                        result.AppendFormat("{0},<br/>", str);
                    }
                    result.Append("</div>");
                }
                context.Response.ContentType = "text/plain";
                context.Response.Write(result.ToString());
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