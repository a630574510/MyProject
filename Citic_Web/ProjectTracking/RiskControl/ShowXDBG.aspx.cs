using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;

using FineUI;
namespace Citic_Web.ProjectTracking.RiskControl
{
    public partial class ShowXDBG : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FilePath = Common.OperateConfigFile.getValue("xdbg_path");
            if (Request.Params["ID"] != null)
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
                    DocPath = Server.MapPath(FilePath + "/" + DocTitle);
                }

                DocType = DocType.Substring(0, 3);
                if (Request.Files.Count > 0 && !string.IsNullOrEmpty(DocPath))
                {
                    HttpPostedFile upPhoto = Request.Files[0];
                    try
                    {
                        upPhoto.SaveAs(DocPath);
                        //记录一条“巡店报告修改”信息
                        Citic.Model.XDBG_Record model = new Citic.Model.XDBG_Record();
                        model.PID = int.Parse(ID);
                        model.RecordContent = "修改文件，文件名：" + DocTitle;
                        model.OperateID = this.CurrentUser.UserId;
                        model.OperateName = this.CurrentUser.UserName;
                        model.OperateTime = DateTime.Now;
                        model.TrueName = this.CurrentUser.TrueName;
                        XDBG_RecordBLL.Add(model);
                        Response.Write("succeed");
                        Response.End();
                    }
                    catch { }
                }
                else
                {
                    Response.Write("No File Upload!");
                }
            }
            else
            {
                Session["_time"] = Session["_time"] == null ? Request.QueryString["_time"] : null;
                if (Session["_time"] != null)
                {
                    //巡店报告
                    string XDBG = Common.OperateConfigFile.getValue("xdbg");
                    //获得URL的值
                    string url = "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + Request.ServerVariables["PATH_INFO"].ToString();
                    url = url.Substring(0, url.LastIndexOf("/"));

                    //存储要访问的页面地址
                    this.Session["RequestToUrl"] = url;

                    url = url.Substring(0, url.LastIndexOf("/"));
                    url = url.Substring(0, url.LastIndexOf("/"));
                    url += "/Office/" + XDBG;
                    //定义Session变量
                    //存储服务器的URL地址
                    this.Session["URL"] = url;
                    string type = Request.QueryString["type"];
                    if (!string.IsNullOrEmpty(type))
                    {
                        switch (type)
                        {
                            //修改巡店报告
                            case "M_XDBG":
                                //传过来的是“被选择的文件的全路径”，作为“源文件”路径名
                                FileName = Server.UrlDecode(Request.QueryString["_name"]);
                                XDBGID = int.Parse(Request.QueryString["_id"]);
                                break;
                        }

                        //记录下“要访问的文档”地址。
                        this.Session["Date"] = url + "/" + FileName;

                        Session["FileName"] = FileName;
                    }
                }
            }
        }


        private string FileName
        {
            get { return (string)ViewState["FileName"]; }
            set { ViewState["FileName"] = value; }
        }
        private string FilePath
        {
            get { return (string)ViewState["FilePath"]; }
            set { ViewState["FilePath"] = value; }
        }
        private int XDBGID
        {
            get { return (int)ViewState["XDBGID"]; }
            set { ViewState["XDBGID"] = value; }
        }
    }
}