<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XDBGList.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.XDBGList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../jqueryui/css/ui-lightness/jquery-ui-1.9.2.custom.min.css" />
    <style type="text/css">
        .ui-autocomplete-loading {
            background: white url('../../Images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PmRoleList" runat="server" AutoSizePanelID="PanelMenu" />
        <x:Panel ID="PanelMenu" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            EnableLargeHeader="true" ShowBorder="false" ShowHeader="false" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" ShowHeader="false" EnableBackgroundColor="true">
                    <Items>
                        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="false" Height="35px" ShowHeader="false" EnableBackgroundColor="true" Layout="HBox">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="选择经销商：" CssStyle="padding-right:5px"></x:Label>
                                <x:TextBox ID="txt_Dealer" runat="server" ShowLabel="false" Width="300px" Text="" AutoPostBack="true" OnTextChanged="txt_Dealer_TextChanged"></x:TextBox>
                                <x:Label ID="Label2" runat="server" Text="选择合作行：" CssStyle="padding-right:5px;padding-left:10px"></x:Label>
                                <x:DropDownList ID="ddl_Bank" runat="server" ShowLabel="true" Width="300px"></x:DropDownList>
                            </Items>
                        </x:Panel>
                        <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="false" Height="35px" ShowHeader="false" EnableBackgroundColor="true" Layout="HBox">
                            <Items>
                                <x:Label ID="Label3" runat="server" Text="区域：" CssStyle="padding-right:41px;padding-left:0px"></x:Label>
                                <x:DropDownList ID="ddl_Area" runat="server" ShowLabel="true" Label="选择区域" Width="200px"></x:DropDownList>
                                <x:Label ID="Label4" runat="server" Text="巡店时间：" CssStyle="padding-right:5px;padding-left:10px"></x:Label>
                                <x:DatePicker ID="dp_Time" runat="server" EnableEdit="false" Width="100px"></x:DatePicker>
                                <x:Label ID="Label5" runat="server" Text="至" CssStyle="padding-right:5px;padding-left:5px"></x:Label>
                                <x:DatePicker ID="dp_End" runat="server" EnableEdit="false" Width="100px"></x:DatePicker>
                                <x:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" CssStyle="padding-left:10px"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" ShowHeader="false" EnableBackgroundColor="true" BoxFlex="1" BodyPadding="0px"
                    CssStyle="padding-top:5px" AllowPaging="true" IsDatabasePaging="true" EnableCheckBoxSelect="true" ClearSelectedRowsAfterPaging="true"
                    BoxConfigAlign="Stretch" DataKeyNames="ID,FileName,FilePath" OnRowCommand="grid_List_RowCommand" EnableTextSelection="true">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_Modify" runat="server" Icon="ReportEdit" Text="修改文件" OnClick="btn_Modify_Click" Visible="true"></x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:HyperLinkField DataNavigateUrlFields="FileName" DataTextField="FileName" HeaderText="文件名" DataNavigateUrlFormatString="~/Office/巡店报告/{0}" Width="430px" />
                        <x:BoundField DataField="DealerName" HeaderText="经销商" Width="300px" />
                        <x:BoundField DataField="BankName" HeaderText="合作行" Width="200px" />
                        <x:BoundField DataField="Area" HeaderText="区域" Width="100px" />
                        <x:BoundField DataField="InspectTime" HeaderText="巡店时间" Width="120px" />
                        <x:BoundField DataField="Remark" HeaderText="备注" Width="200px" />
                    </Columns>
                    <PageItems>
                        <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </x:ToolbarSeparator>
                        <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                        </x:ToolbarText>
                        <x:DropDownList runat="server" ID="ddlPageSize" Width="40px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <x:ListItem Text="5" Value="5" />
                            <x:ListItem Text="10" Value="10" Selected="true" />
                            <x:ListItem Text="15" Value="15" />
                            <x:ListItem Text="20" Value="20" />
                        </x:DropDownList>
                    </PageItems>
                </x:Grid>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
        <x:Window ID="Window1" runat="server" BodyPadding="0px" Height="680px" IsModal="true" Popup="false" Title="汽车巡店报告模版"
            Width="1000px" Layout="Fit" EnableIFrame="true" Target="Parent" EnableClose="true" OnClose="Window1_Close">
        </x:Window>
        <x:Window ID="WindowEdit" runat="server" BodyPadding="0px" Height="680px" IsModal="true" Popup="false" Title="汽车巡店报告模版"
            Width="1300px" Layout="Fit" EnableIFrame="true" EnableMaximize="true" Target="Parent">
        </x:Window>
    </form>
    <script src="../../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function onReady() {
            var textbox1ID = '<%= txt_Dealer.ClientID %>';

            var cache = {};

            $('#' + textbox1ID).autocomplete({
                source: function (request, response) {
                    var term = request.term;
                    if (term in cache) {
                        response(cache[term]);
                        return;
                    }

                    $.getJSON("../../ProjectTracking/RiskControl/search.ashx", request, function (data, status, xhr) {
                        cache[term] = data;
                        response(data);
                    });
                }
            });
        }

    </script>
</body>
</html>
