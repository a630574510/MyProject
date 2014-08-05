using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Threading;

namespace Citic_Web.Office
{
    public partial class LoadOffice : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            //ViewState["_time"] = ViewState["_time"] == null ? Request.QueryString["_time"] : string.Empty;
            //bool isFirst = time == ViewState["_time"].ToString();
            if (!IsPostBack)
            {
                Session["_time"] = Session["_time"] == null ? Request.QueryString["_time"] : null;
                if (Session["_time"] != null)
                {
                    //系统沉睡1秒
                    //Thread.Sleep(1000);

                    //经销商明
                    //以经销商名为依据，创建文件夹
                    string _DealerName = string.Empty;
                    //要创建的文件夹，按天为单位，一天创建一个，是经销商文件夹的子文件夹。
                    string _DirectoryFile = DateTime.Now.ToString("yyyy_MM_dd");
                    string tempValue = string.Empty;
                    //新的文件路径
                    string newFilePath = string.Empty;

                    //获得URL的值
                    string url = "http://" + Request.ServerVariables["HTTP_HOST"].ToString() + Request.ServerVariables["PATH_INFO"].ToString();
                    int i = url.LastIndexOf("/");
                    url = url.Substring(0, i);
                    //定义Session变量
                    //存储服务器的URL地址
                    this.Session["URL"] = url;

                    //最终要保存的文件名
                    string text = string.Empty;

                    //以当前登录用户的用户名来创建文件夹，并且把模板文件复制到该文件夹下
                    DirectoryInfo di = new DirectoryInfo(Server.MapPath(this.CurrentUser.UserName));
                    //该用户的文件夹不存在的话，就创建一下。
                    if (!di.Exists) { di.Create(); }

                    string type = Request.QueryString["type"];
                    _DealerName = Server.UrlDecode(Request.QueryString["_d_n"]);
                    if (!string.IsNullOrEmpty(type))
                    {
                        //“源文件”路径名
                        string sourceFileName = string.Empty;
                        //“源文件”文件名
                        string fileName = string.Empty;
                        switch (type)
                        {
                            //巡店报告
                            case "X_D_B_G":
                                sourceFileName = Server.MapPath("~/Templates/汽车巡店报告模板.doc");
                                fileName = _DealerName + " 汽车巡店报告.doc";
                                //以时间为单位，生成文件名
                                //该块，为创建文件的过程，所以文件的最终保存名称是按时间来生成
                                tempValue = Server.UrlDecode(Request.QueryString["t_v"]);
                                text = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_" + fileName;
                                break;
                            //修改巡店报告
                            case "M_XDBG":
                                //传过来的是“被选择的文件的全路径”，作为“源文件”路径名
                                string name = Server.UrlDecode(Request.QueryString["_name"]);
                                sourceFileName = name;
                                fileName = "汽车巡店报告.doc";
                                //该块，是修改文件的过程，所以引用原名。
                                text = sourceFileName.Substring(sourceFileName.LastIndexOf('\\') + 1);
                                break;
                        }

                        DirectoryInfo c_di = new DirectoryInfo(Server.MapPath(this.CurrentUser.UserName + "/" + _DealerName));
                        if (!c_di.Exists) { c_di.Create(); }
                        DirectoryInfo cc_di = new DirectoryInfo(Server.MapPath(this.CurrentUser.UserName + "/" + _DealerName + "/" + _DirectoryFile));
                        if (!cc_di.Exists) { cc_di.Create(); }

                        //记录下“要访问的文档”地址。
                        newFilePath = Server.MapPath("~/Office/" + this.CurrentUser.UserName + "/" + _DealerName + "/" + _DirectoryFile + "/" + text);
                        this.Session["Date"] = url + "/" + this.CurrentUser.UserName + "/" + _DealerName + "/" + _DirectoryFile + "/" + text;
                        //保存“新文件”的路径
                        //this.Session["newFilePath"] = newFilePath;
                        this.Session["newFilePath"] = "~/Office/" + this.CurrentUser.UserName + "/" + _DealerName + "/" + _DirectoryFile + "/" + text;
                        switch (type)
                        {
                            case "X_D_B_G":
                                //文件存在就删掉。
                                //newFilePath = Server.MapPath("~/Office/" + this.CurrentUser.UserName + "/" + text);
                                string strTemp = "{DealerName};{Address};{BankNames};{BrandNames};{Hours};{OperationMode};{CheckDate};{CheckTime}";

                                if (File.Exists(newFilePath))
                                {
                                    File.Delete(newFilePath);
                                }
                                //File.Copy(sourceFileName, Server.MapPath("~/Office/" + this.CurrentUser.UserName + "/" + text));
                                Common.Common.ReplaceWord(sourceFileName, newFilePath, strTemp, tempValue);
                                break;
                            case "M_XDBG":
                                break;
                        }

                        Session["FileName"] = text;
                    }
                }
            }
        }
    }
}