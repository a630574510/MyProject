using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Citic.BLL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Citic_Web.InspectionFrequency
{
    /// <summary>
    /// InspectionSearch 的摘要说明
    /// </summary>
    public class InspectionSearch : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string DealerName = context.Request.QueryString["term"].Trim();
            if (DealerName.Length != 0)
            {
                JArray ja = new JArray();
                DataTable dt = new Citic.BLL.Car().GetList("select DL.DealerName,DBL.BankName,DBL.BrandName,DBL.BusinessMode,DL.SupervisorName from tb_Dealer_Bank_List DBL left join tb_Dealer_List DL on DBL.DealerID=DL.DealerID where DBL.DealerName like '%" + DealerName + "%'").Tables[0];
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ja.Add(dr["DealerName"].ToString() + "_" + dr["BankName"].ToString() + "_" + dr["BrandName"].ToString() + "_" + dr["SupervisorName"].ToString() + "_" + dr["BusinessMode"].ToString());
                    }
                }
                context.Response.ContentType = "text/plain";
                context.Response.Write(ja.ToString());
                return;
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