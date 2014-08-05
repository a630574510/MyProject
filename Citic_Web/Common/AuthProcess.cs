using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using Citic.BLL;
using System.Net;
namespace Citic_Web
{
    public class AuthProcess
    {
        private const int AUTHENTICATION_TIMEOUT = 20;
        public const string LOGIN_KEY = "THINK_ADMIN";
        public const string DEPT_KEY = "DEPT";
        private const string PERMISSION_KEY = "THINK_ADMINPERMISSION";
        private const string URL_DEFAULT = "Main.aspx";
        public const string URL_LOGIN = "../Login.aspx";
        public const string MANAGE_URL_LOGIN = "../Manage/Login.aspx";
        private static User UserBll = null;
        private static Department DepartmentBll = null;
        private static UserLog UserLogBll = null;
        /// <summary>
        /// Try to authenticate the user.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool AuthenticateUser(string UserName, string Password, int Dept, string IPAddress, bool PersistLogin)
        {
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
                Citic.Model.User UserInfo = UserBll.GetModel(UserName);
                if (UserInfo != null && UserInfo.UserId != -1 && UserInfo.Password == Password && DepartmentBll.ValidateDepartment(Dept, UserInfo.DeptId) && UserInfo.UserType == 1 && !UserInfo.IsDelete)
                {
                    WriteUserLog(UserInfo.UserId, Convert.ToInt32(ActionType.UserLogin), IPAddress, 1, UserInfo.DeptId, UserInfo.RoleId.ToString());

                    HttpContext.Current.Session[LOGIN_KEY] = UserInfo;
                    FormsAuthentication.SetAuthCookie(UserInfo.UserName, PersistLogin);
                    HttpContext.Current.Session[DEPT_KEY] = Dept;
                    //保存用户登录历史方法没有写 UserLogic.GetInstance().SaveUserLogin(user.UserID, IPAddress);
                    // HttpContext.Current.Session["CurrentAccount"] = _Account;
                    return true;
                }
                else if (UserInfo != null && UserInfo.UserId != -1 && UserInfo.Password == Password)
                {
                    WriteUserLog(UserInfo.UserId, Convert.ToInt32(ActionType.UserLogin), IPAddress, 1, UserInfo.DeptId, UserInfo.RoleId.ToString());
                    HttpContext.Current.Session[LOGIN_KEY] = UserInfo;
                    FormsAuthentication.SetAuthCookie(UserInfo.UserName, PersistLogin);

                    //保存用户登录历史方法没有写 UserLogic.GetInstance().SaveUserLogin(user.UserID, IPAddress);

                    // HttpContext.Current.Session["CurrentAccount"] = _Account;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logging.WriteLog(ex);
            }
            return false;
        }

        /// <summary>
        /// Try to authenticate the user.
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static string AuthenticateUser1(string UserName, string Password, int Dept, string IPAddress, bool PersistLogin)
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
                Citic.Model.User UserInfo = UserBll.GetModel(UserName);
                if (UserInfo != null && UserInfo.UserId != -1 && UserInfo.Password == Password && DepartmentBll.ValidateDepartment(Dept, UserInfo.DeptId) && UserInfo.UserType == 1 && !UserInfo.IsDelete)
                {
                    WriteUserLog(UserInfo.UserId, Convert.ToInt32(ActionType.UserLogin), IPAddress, 1, UserInfo.DeptId, UserInfo.RoleId.ToString());

                    HttpContext.Current.Session[LOGIN_KEY] = UserInfo;
                    FormsAuthentication.SetAuthCookie(UserInfo.UserName, PersistLogin);
                    HttpContext.Current.Session[DEPT_KEY] = Dept;
                    //保存用户登录历史方法没有写 UserLogic.GetInstance().SaveUserLogin(user.UserID, IPAddress);
                    // HttpContext.Current.Session["CurrentAccount"] = _Account;
                    return result;
                }
                //用户被停用
                else if (UserInfo != null && UserInfo.UserId != -1 && UserInfo.Password == Password && !UserInfo.IsDelete && UserInfo.UserType == 0)
                {
                    WriteUserLog(UserInfo.UserId, Convert.ToInt32(ActionType.UserLogin), IPAddress, 1, UserInfo.DeptId, UserInfo.RoleId.ToString());
                    HttpContext.Current.Session[LOGIN_KEY] = UserInfo;
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
                Logging.WriteLog(ex);
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
            userinfo = (Citic.Model.User)HttpContext.Current.Session[LOGIN_KEY];
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
    }
}