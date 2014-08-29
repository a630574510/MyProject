<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowXDBG.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.ShowXDBG" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <!-- --------------------===  Weboffice初始化完成事件--------------------- -->
    <script for="WebOffice1" event="NotifyCtrlReady" type="text/javascript">
        // 在装载完Weboffice(执行<object>...</object>)控件后自动执行WebOffice1_NotifyCtrlReady方法
        WebOffice1_NotifyCtrlReady();
    </script>
</head>
<body>
    <form name="myform" action="#" method="post">
        <% //获取服务器的地址
            string URL = this.Session["URL"] == null ? string.Empty : this.Session["URL"].ToString();
            string Date = this.Session["Date"] == null ? string.Empty : this.Session["Date"].ToString();
            string FileName = this.Session["FileName"] == null ? string.Empty : this.Session["FileName"].ToString();
            string RequestToUrl = this.Session["RequestToUrl"] == null ? string.Empty : this.Session["RequestToUrl"].ToString();
            string XDBGID = this.ViewState["XDBGID"] == null ? string.Empty : this.ViewState["XDBGID"].ToString();
        %>
        <div style="float: left">
            <input type="button" value="上传到服务器" onclick="return SaveDoc()" />
            <%-- <input type="button" value="保存" onclick="return SaveTo()" />--%>
            <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        </div>
        <table style="width: 100%; border: 0px; border-spacing: 0; background-color: #3366cc">
            <tr>
                <td valign="top">
                    <!-- -----------------------------== 装载weboffice控件 ==----------------------------------->
                    <object id="WebOffice1" height="600" width="100%" style="left: 0px; top: 0px" classid="clsid:E77E049B-23FC-4DB8-B756-60529A35FAD5"
                        viewastext codebase="WebOffice.ocx#V5,0,0,4">
                        <param name="_Version" value="65536" />
                        <param name="_ExtentX" value="2646" />
                        <param name="_ExtentY" value="1323" />
                        <param name="_StockProps" value="0" />
                    </object>
                    <!-- --------------------------------==  结束装载控件 ==------------------------------------->
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
<script id="clientEventHandlersJS" type="text/javascript">
    function WebOffice1_NotifyCtrlReady() {
        document.all.WebOffice1.LoadOriginalFile("<%=Date %>", "doc");
        //        document.all.WebOffice1.LoadOriginalFile("E:\\工作项目\\中信二期项目\\Citic_Pledge_Manage\\Citic_Web\\Office\\汽车巡店报告模板（2013）.doc", "doc");
        document.all.WebOffice1.HideMenuItem(0x01 + 0x4000 + 0x02 + 0x04);
    };

</script>
<script type="text/javascript">
    function SaveDoc() {
        //初始化Http引擎
        document.all.WebOffice1.HttpInit();
        //添加相应的Post元素
        document.all.WebOffice1.SetTrackRevisions(0);
        document.all.WebOffice1.ShowRevisions(0);
        document.all.WebOffice1.HttpAddPostString("ID", "<%=XDBGID %>");
        document.all.WebOffice1.HttpAddPostString("DocTitle", "<%=Server.UrlEncode(FileName)%>");
        document.all.WebOffice1.HttpAddPostString("DocType", "DocType");
        //把当前文档添加到Post元素列表中，文件的标识符䶿DocContent
        //添加要上传的 Word 或者 Excel 文件
        // Field：要上传文件的 id 
        //newFielName：上传后的新文件名。 该参数可以为空，系统将自动为文件命
        document.all.WebOffice1.HttpAddPostCurrFile("DocContent", "");
        var vtRet;
        //HttpPost执行上传的动仿WebOffice支持Http的直接上传，在upload.aspx的页面中,解析Post过去的数据
        //拆分出Post元素和文件数据，可以有选择性的保存到数据库中，或保存在服务器的文件中
        //HttpPost的返回值，根据upload.aspx中的设置，返回upload.aspx中Response.Write回来的数据
        //alert(1);
        //vtRet = document.all.WebOffice1.HttpPost("<%=URL %>/upload.aspx");
        vtRet = document.all.WebOffice1.HttpPost("<%=RequestToUrl %>/ShowXDBG.aspx");
        //alert(vtRet);
        if ("succeed" == vtRet) {
            alert("文件上传成功");
        } else {
            alert("文件上传失败");
        }
    }

    function SaveTo() {
        var value = document.all.WebOffice1.SaveTo("<%=URL %>/Test.doc");
        if (value == "0") {
            alert("保存成功");
        }
        else {
            alert("保存失败");
        }
    }
</script>
