<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockErrorList.aspx.cs" Inherits="Citic_Web.Reminds.StockErrorList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../jqueryui/css/ui-lightness/jquery-ui-1.9.2.custom.min.css" />
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
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" BoxFlex="1" Height="65px">
                    <Items>
                        <x:Panel ID="Panel2" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column"
                            CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="经销商：" CssClass="inline" CssStyle="padding-right:12px"></x:Label>
                                <x:TextBox ID="txt_DealerName" runat="server" Label="经销商" Text="" Width="300px" AutoPostBack="true" OnTextChanged="txt_DealerName_TextChanged" CssClass="inline"></x:TextBox>

                                <x:Label ID="Label2" runat="server" Text="合作行：" CssClass="inline" CssStyle="padding-left:10px"></x:Label>
                                <x:DropDownList ID="ddl_Bank" runat="server" Width="300px"></x:DropDownList>
                                <x:Label ID="Label3" runat="server" Label="Label" Text="车架号：" CssStyle="margin-left:5px"></x:Label>
                                <x:TextBox ID="txt_Vin" runat="server" Label="Label" Text="" CssStyle="margin-left:5px"></x:TextBox>
                            </Items>
                        </x:Panel>
                        <x:Panel ID="Panel3" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column"
                            CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label4" runat="server" Text="具体内容：" CssClass="inline"></x:Label>
                                <x:DropDownList ID="ddl_ErrorOther" runat="server"></x:DropDownList>
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
                                <x:Button ID="btn_Add" runat="server" Text="添加" Icon="Add" Visible="false"></x:Button>
                                <x:ToolbarSeparator ID="ts_Remove" runat="server" Visible="false"></x:ToolbarSeparator>
                                <x:Button ID="btn_Remove" runat="server" Text="解除异常" Icon="Delete" OnClick="btn_Remove_Click" Visible="false"></x:Button>
                                <x:ToolbarSeparator ID="tbs_Excel" runat="server" Visible="false" />
                                <x:Button ID="btn_ExpendExcel" runat="server" Text="生成Excel" Icon="PageWhiteExcel" OnClick="btn_ExpendExcel_Click" Visible="false">
                                </x:Button>
                                <x:HyperLink ID="hl_ExportExcel" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出本页数据"></x:HyperLink>
                                <x:ToolbarSeparator ID="bl_Separator" runat="server" Visible="false" />
                                <x:HyperLink ID="hl_ExportAll" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出全部数据"></x:HyperLink>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:BoundField HeaderText="经销商" DataField="DealerName" ColumnID="DealerName" Width="200px" />
                        <x:BoundField HeaderText="票号" DataField="DraftNo" ColumnID="DraftNo" Width="200px" />
                        <x:BoundField HeaderText="车架号" DataField="Vin" ColumnID="Vin" Width="200px" />
                        <x:BoundField HeaderText="车辆金额" DataField="CarCost" ColumnID="CarCost" Width="60px" />
                        <x:BoundField HeaderText="合作行" DataField="BankName" ColumnID="BankName" Width="200px" />
                        <x:BoundField HeaderText="异常状态" DataField="ErrorType" ColumnID="ErrorType" />
                        <x:BoundField HeaderText="具体内容" DataField="ErrorOther" ColumnID="ErrorOther" />
                        <x:BoundField HeaderText="车辆状态" DataField="CarStatusOld" ColumnID="CarStatusOld" Width="100px" />
                        <x:BoundField HeaderText="状态" DataField="Status" ColumnID="Status" />
                        <x:BoundField HeaderText="提交人" DataField="CreateName" ColumnID="CreateName" Width="60px" />
                        <x:BoundField HeaderText="提交时间" DataField="CreateTime" ColumnID="CreateTime" Width="100px" />
                        <x:BoundField HeaderText="操作人" DataField="OperateName" ColumnID="OperateName" Width="60px" />
                        <x:BoundField HeaderText="操作时间" DataField="OperateTime" ColumnID="OperateTime" Width="100px" />
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

        <x:Window ID="WindowAdd" Title="添加日查库信息" Popup="false" EnableIFrame="true"
            IFrameUrl="about:blank" EnableMaximize="true" Target="Top" EnableResize="true"
            runat="server" OnClose="WindowAdd_Close" IsModal="true" Width="550px" EnableConfirmOnClose="true"
            Height="600px">
        </x:Window>
    </form>
</body>
</html>
<script src="../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
<script src="../jqueryui/js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script type="text/javascript">
    function onReady() {
        var txt_Dealer = '<%= txt_DealerName.ClientID %>';

        var cache = {};

        $('#' + txt_Dealer).autocomplete({
            source: function (request, response) {
                var term = request.term;
                if (term in cache) {
                    response(cache[term]);
                    return;
                }

                $.getJSON("../ProjectTracking/RiskControl/search.ashx", request, function (data, status, xhr) {
                    cache[term] = data;
                    response(data);
                });
            }
        });
    }
</script>
