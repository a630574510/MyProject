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
    /// searchBank 的摘要说明
    /// </summary>
    public class searchBank : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            Citic.BLL.Bank BankBll = new Citic.BLL.Bank();
            Citic.BLL.UserMapping UMBLL = new Citic.BLL.UserMapping();
            Citic.BLL.UserMapping UMBll = new Citic.BLL.UserMapping();
            Citic.Model.User user = null;
            user = AuthProcess.GetAuthenticateUser(true);
            string content = context.Request.QueryString["term"];
            if (!string.IsNullOrEmpty(content))
            {
                bool isInt = Common.Common.IsInt(content);
                JArray ja = new JArray();
                StringBuilder strWhere = new StringBuilder(string.Empty);
                DataSet ds = null;
                if (isInt)
                {
                    strWhere.Append(string.Format(" BankID like '{0}%' and IsDelete=0", content));
                }
                else
                {
                    strWhere.Append(string.Format(" BankName like '%{0}%' and IsDelete=0", content));
                }
                //权限过滤
                switch (user.RoleId)
                {
                    //监管员
                    case 10:
                        strWhere.AppendFormat(@" AND (BankID in (Select BankID From tb_Dealer_Bank_List(nolock) Where DealerID in
                        (Select DealerID From tb_Dealer_List(nolock) Where SupervisorID='{0}') GROUP BY BankID)) ", user.RelationID.Value);
                        break;
                    case 8:     //银行
                        DataSet dsBank = UMBLL.GetList(string.Format(" UserID='{0}' and RoleID='{1}' and MappingType='Bank' ", user.UserId, user.RoleId));
                        if (dsBank != null && dsBank.Tables.Count > 0)
                        {
                            DataTable dt = dsBank.Tables[0];
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                strWhere.AppendFormat(" And BankID = '{0}' ", dt.Rows[0]["MappingID"].ToString());
                            }
                            else
                            {
                                strWhere.Append(" And BankID = '0' ");
                            }
                        }
                        break;
                    case 5:     //市场专员
                    case 6:     //业务专员
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
                        strWhere.AppendFormat(" AND {0}", ids);
                        break;
                }

                ds = BankBll.GetList(20, strWhere.ToString(), "BankID");

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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}