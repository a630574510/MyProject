using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;

namespace Citic_Web.Handlers
{
    /// <summary>
    /// Logout 的摘要说明
    /// </summary>
    public class Logout : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Session.Clear();
            FormsAuthentication.SignOut();
            context.Response.Redirect("~/Login.aspx");
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