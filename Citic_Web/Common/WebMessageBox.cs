using System;
using System.Text;
using System.Web;

namespace Citic_Web
{
    /// <summary>
    /// WebMessageBox 的摘要说明。
    /// </summary>
    public class WebMessageBox
    {
        /// <summary>
        /// Overloaded. Displays a message box on the client page.
        /// </summary>
        public static void Show()
        {
            Show("WebMessage!");
        }

        /// <summary>
        /// Overloaded. Displays a message box on the client page.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        public static void Show(string text)
        {
            Show(text, false);
        }

        /// <summary>
        /// Overloaded. Displays a message box on client page.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="continueExecute">a bool value to indicate whether the excution of current page should terminate.</param>
        public static void Show(string text, bool continueExecute)
        {
            if (continueExecute)
                Show(text, null);
            else
                Show(text, String.Empty);
        }

        /// <summary>
        /// Overloaded. Displays a message box on client page.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="url">The target location which client will redirect after clicking ok.</param>
        public static void Show(string text, string url)
        {
            StringBuilder strBuilder = new StringBuilder("<script language=\"javascript\">");
            if (text != String.Empty)
                strBuilder.Append("alert(\"").Append(text.Replace("\"", "\\\"")).Append("\");");

            if (url == null) { }
            else if (url.Length > 0)
                strBuilder.Append(" window.location.href='").Append(url).Append("';");
            else
                strBuilder.Append(" window.history.back();");

            strBuilder.Append("</script>");

            HttpContext.Current.Response.Write(strBuilder.ToString());
            if (url != null)
                HttpContext.Current.Response.End();
        }
        /// <summary>
        /// Overloaded. Displays a message box on client page.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        /// <param name="pos">The step number of page back.</param>
        public static void Show(string text, int pos)
        {
            StringBuilder sb = new StringBuilder("<script language=\"javascript\">");
            sb.Append("alert(\"").Append(text.Replace("\"", "\\\"")).Append("\");");
            sb.Append(" window.history.go(" + pos + ");");
            sb.Append("</script>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// Overloaded.Open a new page by specified url.
        /// </summary>
        /// <param name="url">The target location which a new page will open.</param>
        public static void Open(string url)
        {
            Open(url, true);
        }

        /// <summary>
        /// Overloaded.Open a new page by specified url.
        /// </summary>
        /// <param name="url">The target location which a new page will open.</param>
        /// <param name="continueExecute">a bool value to indicate whether the excution of current page should terminate.</param>
        public static void Open(string url, bool continueExecute)
        {
            StringBuilder strBuilder = new StringBuilder("<script language=\"javascript\">");
            if (url != String.Empty)
                strBuilder.Append("window.open('").Append(url).Append("');");
            strBuilder.Append("</script>");

            HttpContext.Current.Response.Write(strBuilder.ToString());
            if (continueExecute)
            {
                HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// Refresh the current page.
        /// </summary>
        public static void Refresh()
        {
            StringBuilder strBuilder = new StringBuilder("<script language=\"javascript\">");
            strBuilder.Append("window.location.reload();");
            strBuilder.Append("</script>");

            HttpContext.Current.Response.Write(strBuilder.ToString());
            HttpContext.Current.Response.End();
        }

        /// <summary>
        ///  Displays a message box on client page and close the current page after clicking ok.
        /// </summary>
        /// <param name="text">The text to display in the message box.</param>
        public static void ShowAndCloseWindow(string text)
        {
            StringBuilder sb = new StringBuilder("<script language=\"javascript\">");
            sb.Append("alert('").Append(text).Append("');");
            sb.Append(" window.close();");
            sb.Append("</script>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
        }

        /// <summary>
        ///  close the current page.
        /// </summary>
        public static void CloseWindow()
        {
            StringBuilder sb = new StringBuilder("<script language=\"javascript\">");
            sb.Append(" window.close();");
            sb.Append("</script>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
        }

        public static void CloseWindow(string Url)
        {
            StringBuilder sb = new StringBuilder("<script language=\"javascript\">");
            sb.Append("window.open('" + Url + "','_blank');");
            sb.Append(" window.close();");
            sb.Append("</script>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// Displays a confirm box on the client page.
        /// </summary>
        /// <param name="text">The text to display in the confirm box.</param>
        /// <param name="trueUrl">The target url which client will redirect after clicking ok.</param>
        /// <param name="falseUrl">The target url which client will redirect after clicking cancel.</param>
        public static void Confirm(string text, string trueUrl, string falseUrl)
        {
            StringBuilder strBuilder = new StringBuilder("<script language=\"javascript\">");
            strBuilder.Append("if(confirm(\"").Append(text).Append("\"))");
            strBuilder.Append("{");

            if (trueUrl == null || trueUrl == string.Empty)
                trueUrl = HttpContext.Current.Request.Url.AbsolutePath;

            strBuilder.Append(" window.location.href='").Append(trueUrl).Append("';");
            strBuilder.Append("}");
            strBuilder.Append("else");
            strBuilder.Append("{");

            if (falseUrl == null || falseUrl == string.Empty)
                falseUrl = HttpContext.Current.Request.Url.AbsolutePath;

            strBuilder.Append(" window.location.href='").Append(falseUrl).Append("';");
            strBuilder.Append("}");

            strBuilder.Append("</script>");

            HttpContext.Current.Response.Write(strBuilder.ToString());
            HttpContext.Current.Response.End();
        }

        public static void Confirm(string text)
        {
            StringBuilder strBuilder = new StringBuilder("<script language=\"javascript\">");
            strBuilder.Append("if(!confirm(\"").Append(text).Append("\"))");
            strBuilder.Append("{");
            strBuilder.Append(" window.history.back();");
            strBuilder.Append("}");

            strBuilder.Append("</script>");

            HttpContext.Current.Response.Write(strBuilder.ToString());
        }

        public static void Redirect(string url, bool continueExecute)
        {
            StringBuilder strBuilder = new StringBuilder("<script language=\"javascript\">");

            strBuilder.Append(" top.location.href='").Append(url).Append("';");

            strBuilder.Append("</script>");

            HttpContext.Current.Response.Write(strBuilder.ToString());
            if (continueExecute)
            {
                HttpContext.Current.Response.End();
            }
        }

        public static void RedirectToParent(string url, bool continueExecute)
        {
            StringBuilder strBuilder = new StringBuilder("<script language=\"javascript\">");

            strBuilder.Append(" parent.location.href='").Append(url).Append("';");

            strBuilder.Append("</script>");

            HttpContext.Current.Response.Write(strBuilder.ToString());
            if (continueExecute)
            {
                HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        ///  go back
        /// </summary>
        /// <param name="iStep">The step number of page back.</param>
        public static void GoBack(int iStep)
        {
            StringBuilder sb = new StringBuilder("<script language=\"javascript\">");
            sb.Append("window.history.go(" + iStep.ToString() + ");");
            sb.Append("</script>");

            HttpContext.Current.Response.Write(sb.ToString());
            HttpContext.Current.Response.End();
        }
    }
}
