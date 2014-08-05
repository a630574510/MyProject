<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PledgeCarDaily.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.PledgeCarDaily" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../jqueryui/css/ui-lightness/jquery-ui-1.9.2.custom.min.css" />
    <style type="text/css">
        .mright {
            margin-right: 5px;
        }

        .datecontainer .x-form-field-trigger-wrap {
            margin-right: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" Title="日查库信息"
            Layout="VBox" BoxConfigAlign="Stretch" EnableBackgroundColor="true">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" BoxFlex="1" Height="60px">
                    <Items>
                        <%--<x:Panel ID="Panel2" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column"
                            CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="选择经销商：" CssStyle="padding-right:5px"></x:Label>
                                <x:TextBox ID="txt_Dealer" runat="server" ShowLabel="false" AutoPostBack="true" OnTextChanged="txt_Dealer_TextChanged" Width="300px" Text=""></x:TextBox>
                                <x:Label ID="Label2" runat="server" Text="选择合作行：" CssStyle="padding-right:5px;padding-left:10px"></x:Label>
                                <x:DropDownList ID="ddl_Bank" runat="server" Width="300px"></x:DropDownList>
                            </Items>
                        </x:Panel>--%>
                        <x:Panel ID="Panel2" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column"
                            CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="选择合作行：" CssStyle="padding-right:5px"></x:Label>
                                <x:TextBox ID="txt_Bank" runat="server" ShowLabel="false" AutoPostBack="true" OnTextChanged="txt_Dealer_TextChanged" Width="300px" Text=""></x:TextBox>
                                <x:Label ID="Label2" runat="server" Text="选择经销商：" CssStyle="padding-right:5px;padding-left:10px"></x:Label>
                                <x:DropDownList ID="ddl_Dealer" runat="server" Width="300px"></x:DropDownList>
                            </Items>
                        </x:Panel>
                        <x:Panel ID="Panel3" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column"
                            CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label3" runat="server" Label="Label" Text="车架号：" CssStyle="padding-right:24px"></x:Label>
                                <x:TextBox ID="txt_Vin" runat="server" Width="200px" Text="" CssStyle="margin-left:5px" CssClass="inline"></x:TextBox>
                                <x:Button ID="btn_Search" runat="server" Text="查询" Icon="SystemSearch" OnClick="btn_Search_Click" Visible="false" CssStyle="margin-left:5px"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" ShowHeader="false" EnableBackgroundColor="true" CssStyle="padding-top:5px"
                    BoxFlex="1" EnableCheckBoxSelect="true" AllowPaging="true" DataKeyNames="ID" IsDatabasePaging="true"
                    OnPageIndexChange="grid_List_PageIndexChange" OnRowDataBound="grid_List_RowDataBound" EnableTextSelection="true">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_BuildExcel" runat="server" Text="生成《每日质押车辆统计表》" OnClick="btn_BuildExcel_Click" Visible="false"></x:Button>
                                <x:HyperLink ID="hl_ExportExcel" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出《每日质押车辆统计表》"></x:HyperLink>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:BoundField HeaderText="经销商" DataField="DealerName" Width="200px" />
                        <x:BoundField HeaderText="合作行" DataField="BankName" Width="200px" />
                        <x:BoundField HeaderText="品牌" DataField="BrandName" Width="100px" />
                        <x:BoundField HeaderText="票号" DataField="DraftNo" Width="200px" />
                        <x:BoundField HeaderText="车架号" DataField="Vin" Width="200px" />
                        <x:BoundField HeaderText="车辆金额" DataField="CarCost" Width="60px" />
                        <x:BoundField HeaderText="异常情况" DataField="Status" />
                        <x:BoundField HeaderText="具体内容" DataField="ErrorOther" />
                        <x:BoundField HeaderText="提交人" DataField="UserName" Width="60px" />
                        <x:BoundField HeaderText="提交时间" DataField="CreateTime" Width="100px" />
                        <x:BoundField HeaderText="操作人" DataField="OperateName" Width="60px" />
                        <x:BoundField HeaderText="操作时间" DataField="OperateTime" Width="100px" />
                    </Columns>
                    <PageItems>
                        <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </x:ToolbarSeparator>
                        <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                        </x:ToolbarText>
                        <x:DropDownList runat="server" ID="ddlPageSize" Width="45px" AutoPostBack="true"
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

    </form>
    <script src="../../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../../jqueryui/js/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function onReady() {
            var textbox1ID = '<%= txt_Bank.ClientID %>';
            
            var cache = {};

            $('#' + textbox1ID).autocomplete({
                source: function (request, response) {
                    var term = request.term;
                    
                    $.getJSON("search.ashx?_from=pcd", request, function (data, status, xhr) {
                       
                        response(data);
                    });
                }
            });
        }

    </script>
</body>
</html>
