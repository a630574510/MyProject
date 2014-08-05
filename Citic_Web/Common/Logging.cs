/*******************************************************************************************
*	Copyright:	ThinkRaceTECH
*	Create Date:	2007-11-27 by Allen
*	Update Date:
*	Description:	Log file process, write errors to log files
*******************************************************************************************/
using System;
using System.Text;
using System.Security;
using System.Security.Principal;
using System.IO;
using System.Reflection;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Citic_Web
{
    /// <summary>
    /// Summary description for Logging
    /// </summary>
    public class Logging
    {
        private readonly static string EXCEPTIONMANAGER_NAME = typeof(Logging).Name;

        public Logging()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void WriteLog(Exception exception, string ClassName, string Method)
        {
            NameValueCollection AdditionalInfo = GetAdditionalInfo(ClassName, Method);


            StringBuilder strInfo = new StringBuilder();

            // Record the contents of the AdditionalInfo collection.
            if (AdditionalInfo != null)
            {
                // Record General information.
                strInfo.Append("******************************************* Exception Information ************************************************");
                //strInfo.AppendFormat("{0}{0}General Information{0}", Environment.NewLine);
                strInfo.AppendFormat("{0}{0}General Information", Environment.NewLine);
                //strInfo.AppendFormat("{0}Additonal Info:", Environment.NewLine);
                foreach (string i in AdditionalInfo)
                {
                    strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, i, AdditionalInfo.Get(i));
                }
            }
            // Append the exception text
            strInfo.AppendFormat("{0}{0}Exception Information{0}{1}", Environment.NewLine, exception.ToString());
            strInfo.AppendFormat("{0}{0}{0}", Environment.NewLine);

            string m_LogName = new ConfigSetting().GetErrorLogPath();
            m_LogName = m_LogName + System.DateTime.Now.ToString("yyyyMMdd") + ".txt";

            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(m_LogName));

            System.IO.TextWriter output = null;

            try
            {
                output = TextWriter.Synchronized(System.IO.File.AppendText(m_LogName));
                output.Write(strInfo.ToString());
            }
            catch { }
            finally
            {
                if (output != null)
                {
                    output.Close();
                }

            }
        }

        private static NameValueCollection GetAdditionalInfo(string ClassName, string Method)
        {
            #region Load the AdditionalInformation Collection with environment data.
            NameValueCollection additionalInfo = new NameValueCollection();

            try
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName", Environment.MachineName);
            }
            catch (SecurityException)
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName", "RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED");
            }
            catch
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName", "RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION");
            }

            try
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".Exception Time", DateTime.Now.ToString());
            }
            catch (SecurityException)
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".Exception Time", "RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED");
            }
            catch
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".Exception Time", "RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION");
            }

            try
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName", Assembly.GetExecutingAssembly().FullName);
            }
            catch (SecurityException)
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName", "RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED");
            }
            catch
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName", "RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION");
            }
            try
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity", WindowsIdentity.GetCurrent().Name);
            }
            catch (SecurityException)
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity", "RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED");
            }
            catch
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity", "RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION");
            }

            additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".Exception Method", "Class Name:" + ClassName + ",Method:" + Method);

            System.Web.HttpContext hc = System.Web.HttpContext.Current;
            if (hc != null && hc.Request.Url != null)
            {
                additionalInfo.Add("Request Url is: ", hc.Request.Url.ToString());
            }
            #endregion

            return additionalInfo;
        }

        public static void WriteLog(Exception exception)
        {
            NameValueCollection AdditionalInfo = GetAdditionalInfo();

            StringBuilder strInfo = new StringBuilder();

            // Record the contents of the AdditionalInfo collection.
            if (AdditionalInfo != null)
            {
                // Record General information.
                strInfo.Append("******************************************* Exception Information ************************************************");
                //strInfo.AppendFormat("{0}{0}General Information{0}", Environment.NewLine);
                strInfo.AppendFormat("{0}{0}General Information", Environment.NewLine);
                //strInfo.AppendFormat("{0}Additonal Info:", Environment.NewLine);
                foreach (string i in AdditionalInfo)
                {
                    strInfo.AppendFormat("{0}{1}: {2}", Environment.NewLine, i, AdditionalInfo.Get(i));
                }
            }
            // Append the exception text
            strInfo.AppendFormat("{0}{0}Exception Information{0}{1}", Environment.NewLine, exception.ToString());
            strInfo.AppendFormat("{0}{0}{0}", Environment.NewLine);

            string m_LogName = new ConfigSetting().GetErrorLogPath();
            m_LogName = m_LogName + System.DateTime.Now.ToString("yyyyMMdd") + ".txt";

            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(m_LogName));

            System.IO.TextWriter output = null;

            try
            {
                output = TextWriter.Synchronized(System.IO.File.AppendText(m_LogName));
                output.Write(strInfo.ToString());
            }
            catch { }
            finally
            {
                if (output != null)
                {
                    output.Close();
                }

            }
        }

        public static void WriteLog(string Message)
        {
            Message = Message + Environment.NewLine;

            StringBuilder strInfo = new StringBuilder();

            string m_LogName = new ConfigSetting().GetErrorLogPath();
            m_LogName = m_LogName + System.DateTime.Now.ToString("yyyyMMdd") + ".txt";

            System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(m_LogName));

            System.IO.TextWriter output = null;

            try
            {
                output = TextWriter.Synchronized(System.IO.File.AppendText(m_LogName));
                output.Write(Message.ToString());
            }
            catch { }
            finally
            {
                if (output != null)
                {
                    output.Close();
                }

            }
        }

        private static NameValueCollection GetAdditionalInfo()
        {
            #region Load the AdditionalInformation Collection with environment data.
            NameValueCollection additionalInfo = new NameValueCollection();

            try
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName", Environment.MachineName);
            }
            catch (SecurityException)
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName", "RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED");
            }
            catch
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".MachineName", "RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION");
            }

            try
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".Exception Time", DateTime.Now.ToString());
            }
            catch (SecurityException)
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".Exception Time", "RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED");
            }
            catch
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".Exception Time", "RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION");
            }

            try
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName", Assembly.GetExecutingAssembly().FullName);
            }
            catch (SecurityException)
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName", "RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED");
            }
            catch
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".FullName", "RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION");
            }
            try
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity", WindowsIdentity.GetCurrent().Name);
            }
            catch (SecurityException)
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity", "RES_EXCEPTIONMANAGEMENT_PERMISSION_DENIED");
            }
            catch
            {
                additionalInfo.Add(EXCEPTIONMANAGER_NAME + ".WindowsIdentity", "RES_EXCEPTIONMANAGEMENT_INFOACCESS_EXCEPTION");
            }

            System.Web.HttpContext hc = System.Web.HttpContext.Current;
            if (hc != null && hc.Request.Url != null)
            {
                additionalInfo.Add("Request Url is: ", hc.Request.Url.ToString());
            }
            #endregion

            return additionalInfo;
        }
    }
}