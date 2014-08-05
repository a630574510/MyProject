using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using Citic.BLL;
using System.Net;
using System.Collections;
namespace Citic_Web
{
    public class AuthProcess
    {
        private const int AUTHENTICATION_TIMEOUT = 20;
        public const string LOGIN_KEY = "THINK_ADMIN";
        public const string DEPT_KEY = "DEPT";
        private const string PERMISSION_KEY = "THINK_ADMINPERMISSION";
        private const string URL_DEFAULT = "Main.aspx";
        public static string URL_LOGIN = "/citic3.0/Login.aspx";
        //public static string URL_LOGIN = string.Empty;
        //public const string URL_LOGIN = "/Login.aspx";
        private static User UserBll = null;
        private static Department DepartmentBll = null;
        private static UserLog UserLogBll = null;
        private static UserMapping UMBLL = null;
        public static String UserSessionID = string.Empty;


        public static void SetRootDirectory(string path)
        {
            //URL_LOGIN = path;
        }

        public static string RootDirectory
        {
            get
            {
                String rootPath = HttpContext.Current.Server.HtmlEncode(HttpContext.Current.Request.ApplicationPath);
                if (rootPath.Length == 1)
                {
                    rootPath = string.Empty;
                }
                return rootPath + "/Login.aspx";
            }
        }


        /// <summary>
        /// Try to authenticate the user.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string AuthenticateUser(string UserName, string Password, int Dept, string IPAddress, bool PersistLogin)
        {
            string result = string.Empty;
            try
            {
                if (UserBll == null)
                {
                    UserBll = new User();
                }
                if (DepartmentBll == null)
                {
                    DepartmentBll = new Department();
                }
                if (UMBLL == null)
                {
                    UMBLL = new UserMapping();
                }
                Citic.Model.User UserInfo = UserBll.GetModel(UserName);
                if (UserInfo == null) { return "该用户名不存在！"; }
                bool flag = false;
                //判断银行用户是否有匹配银行
                int bankUserIsUsedCount = UMBLL.GetRecordCount(string.Format(" UserID = {0} AND RoleID = {1} AND MappingType = 'Bank' ", UserInfo.UserId, UserInfo.RoleId));
                bool bankUserIsUsed = UserInfo == null || UserInfo.UserId == -1 || UserInfo.Password != Password || UserInfo.UserType != 1 || UserInfo.IsDelete || (bankUserIsUsedCount == 0 && UserInfo.RoleId == 8);
                if (UserInfo.RoleId == 1)
                {
                    flag = UserInfo != null && UserInfo.UserId != -1 && UserInfo.Password == Password && UserInfo.UserType == 1 && !UserInfo.IsDelete;
                }
                else
                {
                    flag = UserInfo != null && UserInfo.UserId != -1 && UserInfo.Password == Password && DepartmentBll.ValidateDepartment(Dept, UserInfo.DeptId) && UserInfo.UserType == 1 && !UserInfo.IsDelete;
                }
                if (flag)
                {
                    if (bankUserIsUsed)
                    {
                        result = "该银行用户没有匹配任何银行！";
                        return result;
                    }
                    //记录日志
                    WriteUserLog(UserInfo.UserId, Convert.ToInt32(ActionType.UserLogin), IPAddress, 1, UserInfo.DeptId, UserInfo.RoleId.ToString());

                    HttpContext.Current.Session[LOGIN_KEY] = UserInfo;    //之前的做法
                    //SetLoginUser(UserInfo);
                    FormsAuthentication.SetAuthCookie(UserInfo.UserName, PersistLogin);

                    HttpContext.Current.Session[DEPT_KEY] = Dept;
                    //保存用户登录历史方法没有写 UserLogic.GetInstance().SaveUserLogin(user.UserID, IPAddress);
                    // HttpContext.Current.Session["CurrentAccount"] = _Account;
                }
                //用户被停用
                else if (UserInfo != null && UserInfo.UserId != -1 && UserInfo.Password == Password && !UserInfo.IsDelete && UserInfo.UserType == 0)
                {
                    //记录日志
                    WriteUserLog(UserInfo.UserId, Convert.ToInt32(ActionType.UserLogin), IPAddress, 1, UserInfo.DeptId, UserInfo.RoleId.ToString());

                    HttpContext.Current.Session[LOGIN_KEY] = UserInfo;    //之前的做法
                    //SetLoginUser(UserInfo);
                    FormsAuthentication.SetAuthCookie(UserInfo.UserName, PersistLogin);

                    //保存用户登录历史方法没有写 UserLogic.GetInstance().SaveUserLogin(user.UserID, IPAddress);

                    // HttpContext.Current.Session["CurrentAccount"] = _Account;

                    result = "该账户被停用！";
                    return result;
                }
                else
                {
                    return "用户名或密码输入错误!";
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex, HttpContext.Current.Request.Url.AbsolutePath, "AuthenticateUser()");
            }
            return result;
        }

        public static void WriteUserLog(int UserID, int MenuId, string IPAddress, int CompanyId, int DepartmentId, string RoleId)
        {
            if (UserLogBll == null)
            {
                UserLogBll = new Citic.BLL.UserLog();
            }
            Citic.Model.UserLog UserLogInfo = new Citic.Model.UserLog();
            UserLogInfo.UserID = UserID;
            UserLogInfo.ActionID = MenuId;
            UserLogInfo.IPAddress = IPAddress;
            UserLogInfo.CompanyID = CompanyId;
            UserLogInfo.DeptID = DepartmentId;
            UserLogInfo.ActionTime = DateTime.Now;
            UserLogInfo.RoleID = int.Parse(RoleId);
            UserLogBll.Add(UserLogInfo);
        }
        /// <summary>
        /// Retrieves the account information for a customer who has already logged in
        /// The method assume the account information is in session state
        /// If it can't find it the function will direct the user to login
        /// </summary>
        /// <returns>The User for the currently logged in user</returns>
        public static Citic.Model.User GetAuthenticateUser(bool required)
        {
            Citic.Model.User userinfo = null;

            string ParamString = "?ReturnUrl=" + HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.RawUrl.ToString());
            //////////////////////////////////////////////////////////////////////////////////
            userinfo = (Citic.Model.User)HttpContext.Current.Session[LOGIN_KEY];  //以前的做法
            //Hashtable table = (Hashtable)HttpContext.Current.Session[LOGIN_KEY];    //新做法
            //userinfo = (Citic.Model.User)table[UserSessionID];
            //////////////////////////////////////////////////////////////////////////////////
            if (userinfo == null)
                if (required) WebMessageBox.Redirect(URL_LOGIN + ParamString, true);

            return userinfo;
        }

        public static string GetAuthenticateDept(bool required)
        {
            string dept = string.Empty;
            dept = HttpContext.Current.Session[DEPT_KEY] == null ? "" : HttpContext.Current.Session[DEPT_KEY].ToString();
            return dept;
        }

        public static void SetLoginUser(Citic.Model.User userInfo)
        {
            string sessionID = HttpContext.Current.Session.SessionID;
            Hashtable map = (Hashtable)HttpContext.Current.Session[LOGIN_KEY];
            if (map == null)
            {
                map = new Hashtable();
                map.Add(sessionID, userInfo);
                UserSessionID = sessionID;
            }
            else
            {
                map.Add(sessionID, userInfo);
            }
            HttpContext.Current.Session[LOGIN_KEY] = map;
        }
    }
}