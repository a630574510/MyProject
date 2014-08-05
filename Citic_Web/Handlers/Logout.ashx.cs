using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;
using System.Collections;

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
            //Hashtable map = (Hashtable)HttpContext.Current.Session[AuthProcess.LOGIN_KEY];
            //if (map != null)
            //{
            //    map.Remove(AuthProcess.UserSessionID);
            //    HttpContext.Current.Session[AuthProcess.LOGIN_KEY] = map;
            //}
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