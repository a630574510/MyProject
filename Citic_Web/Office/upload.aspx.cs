using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Citic_Web.Office
{
    public partial class upload : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            //ID为文档的主键，如果ID不为空，则更新数据，否则新建一条记录
            string ID = Request.Params["ID"];
            string DocID = string.Empty, DocTitle = string.Empty, DocType = string.Empty, DocPath = string.Empty;
            if (ID == null || ID == "")
            {
                DocID = DateTime.Now.ToString("yyyyMMddhhmmss");
                DocTitle = Server.UrlDecode(Request.Params["DocTitle"]);
                DocType = Request.Params["DocType"];
                if (this.Session["newFilePath"] != null)
                {
                    DocPath = this.Session["newFilePath"].ToString();
                }
            }
            if (DocType == "")
                DocType = "doc";

            DocType = DocType.Substring(0, 3);
            if (Request.Files.Count > 0 && !string.IsNullOrEmpty(DocPath))
            {
                HttpPostedFile upPhoto = Request.Files[0];
                //upPhoto.SaveAs(Server.MapPath("~/Office/保存" + DateTime.Now.ToString("yyyyMMddHHssmm") + ".doc"));
                //upPhoto.SaveAs(Server.MapPath("~/Office/" + CurrentUser.UserName + "/" + DocTitle));
                upPhoto.SaveAs(Server.MapPath(DocPath));
                Response.Write("succeed");
                Response.End();
            }
            else
            {
                Response.Write("No File Upload!");
            }
        }
    }
}