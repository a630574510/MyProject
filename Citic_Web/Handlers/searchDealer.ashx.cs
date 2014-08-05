using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Data;
using System.Web.SessionState;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Citic_Web.Handlers
{
    /// <summary>
    /// searchDealer 的摘要说明
    /// </summary>
    public class searchDealer : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            Citic.BLL.Bank BankBll = new Citic.BLL.Bank();
            Citic.BLL.Dealer DealerBll = new Citic.BLL.Dealer();
            Citic.BLL.Dealer_Bank Dealer_BankBll = new Citic.BLL.Dealer_Bank();
            Citic.BLL.UserMapping UMBll = new Citic.BLL.UserMapping();
            context.Response.ContentType = "text/plain";
            Citic.Model.User user = null;
            user = AuthProcess.GetAuthenticateUser(true);
            string content = context.Request.QueryString["term"];
            bool isInt = Common.Common.IsInt(content);
            if (!string.IsNullOrEmpty(content))
            {
                JArray ja = new JArray();
                StringBuilder strWhere = new StringBuilder(string.Empty);
                DataSet ds = null;
                if (isInt)
                {
                    strWhere.Append(string.Format(" DealerID like '{0}%' and IsDelete=0", content));
                }
                else
                {
                    strWhere.Append(string.Format(" DealerName like '%{0}%' and IsDelete=0", content));
                }
                //权限过滤
                switch (user.RoleId)
                {
                    //监管员
                    case 10:
                        strWhere.AppendFormat(@" AND SupervisorID = '{0}'", user.RelationID.Value);
                        break;
                    case 5:     //市场专员
                    case 6:     //品牌专员
                        StringBuilder ids = new StringBuilder(string.Empty);
                        ids.Append(" BankID in (");
                        DataTable _dt = UMBll.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", user.UserId, user.RoleId)).Tables[0];
                        if (_dt != null && _dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in _dt.Rows)
                            {
                                ids.AppendFormat("{0},", row["MappingID"].ToString());
                            }
                            ids.Remove(ids.Length - 1, 1);
                        }
                        else
                        {
                            ids.Append("0");
                        }
                        ids.Append(")");
                        _dt = null;
                        _dt = Dealer_BankBll.GetList(ids.ToString()).Tables[0];
                        ids = null;
                        ids = new StringBuilder(" DealerID in (");
                        if (_dt != null && _dt.Rows.Count > 0)
                        {
                            foreach (DataRow row in _dt.Rows)
                            {
                                ids.AppendFormat("{0},", row["DealerID"].ToString());
                            }
                            ids.Remove(ids.Length - 1, 1);
                        }
                        else
                        {
                            ids.Append("0");
                        }
                        ids.Append(")");
                        if (ids != null && ids.Length != 0)
                        {
                            strWhere.AppendFormat(" AND {0}", ids.ToString());
                        }
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