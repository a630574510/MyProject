using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Text;
using System.Web.SessionState;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Citic_Web.ProjectTracking.RiskControl
{
    /// <summary>
    /// search 的摘要说明
    /// </summary>
    public class search : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            Citic.BLL.Dealer_Bank Dealer_BankBll = new Citic.BLL.Dealer_Bank();
            Citic.BLL.Dealer DealerBll = new Citic.BLL.Dealer();
            Citic.BLL.StockError SEBLL = new Citic.BLL.StockError();
            Citic.BLL.Bank BankBll = new Citic.BLL.Bank();
            Citic.BLL.Car CarBll = new Citic.BLL.Car();
            Citic.Model.User user = null;
            user = AuthProcess.GetAuthenticateUser(true);

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
                else if (from.Equals("searchvin"))
                {
                    JArray ja = new JArray();
                    string vin = context.Request.QueryString["term"];
                    if (!string.IsNullOrEmpty(vin))
                    {
                        string where = string.Format(" IsDelete=0 and Vin like '%{0}' ", vin);
                        string dealerID = context.Session["DealerID"].ToString();
                        string bankID = context.Session["BankID"].ToString();
                        string tableName = string.Format("tb_Car_{0}_{1}", bankID, dealerID);
                        DataSet ds = CarBll.GetList(20,where.ToString(),"Vin", tableName);

                        if (ds != null && ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                            {
                                foreach (DataRow row in ds.Tables[0].Rows)
                                {
                                    ja.Add(row["Vin"].ToString());
                                }
                            }
                        }

                        context.Response.ContentType = "text/plain";
                        context.Response.Write(ja.ToString());
                    }
                }
                else
                {
                    string content = context.Request.QueryString["term"];
                    bool isInt = Common.Common.IsInt(content);
                    if (!string.IsNullOrEmpty(content))
                    {
                        JArray ja = new JArray();
                        StringBuilder strWhere = new StringBuilder(string.Empty);
                        DataSet ds = null;
                        if (isInt)
                        {
                            ds = BankBll.GetList(20, string.Format(" BankID like '{0}%' and IsDelete=0", content), "BankID");
                            strWhere.Append(string.Format(" BankID like '{0}%' and IsDelete=0", content));
                            //strWhere.Append(string.Format(" DealerID like '%{0}%' and IsDelete=0", content));
                        }
                        else
                        {
                            ds = BankBll.GetList(20, string.Format(" BankName like '%{0}%' and IsDelete=0", content), "BankID");
                            strWhere.Append(string.Format(" BankName like '%{0}%' and IsDelete=0", content));
                            //strWhere.Append(string.Format(" DealerName like '%{0}%' and IsDelete=0", content));
                        }
                        //权限过滤
                        switch (user.RoleId)
                        {
                            //监管员
                            case 10:
                                strWhere.AppendFormat(@" AND (BankID in(
                                select BankID from tb_Dealer_Bank_List(nolock) where DealerID in
                                (select DealerID from tb_Dealer_List(nolock) where SupervisorID='{0}') GROUP BY BankID)) ", user.RelationID.Value);
                                //strWhere.AppendFormat(@" AND SupervisorID = '{0}'", user.RelationID.Value);
                                break;
                        }

                        ds = BankBll.GetList(20, strWhere.ToString(), "BankID");
                        //ds = DealerBll.GetList(20, strWhere.ToString(), "DealerID");

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
                bool isInt = Common.Common.IsInt(term);
                JArray ja = new JArray();
                StringBuilder strWhere = new StringBuilder(string.Empty);
                DataSet ds = null;
                if (isInt)
                {
                    strWhere.Append(string.Format(" DealerID like '{0}%' and IsDelete=0", term));
                }
                else
                {
                    strWhere.Append(string.Format(" DealerName like '%{0}%' and IsDelete=0", term));
                }
                //权限过滤
                switch (user.RoleId)
                {
                    //监管员
                    case 10:
                        strWhere.AppendFormat(@" AND SupervisorID = '{0}'", user.RelationID.Value);
                        break;
                }

                ds = DealerBll.GetList(20, strWhere.ToString(), "DealerID");

                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            ja.Add(row["DealerName"].ToString() + "_" + row["DealerID"]);
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