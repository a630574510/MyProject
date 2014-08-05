<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarErrorCount.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.CarErrorCount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
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
        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true" Title="车辆异常统计汇总"
            EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" BoxFlex="1" Height="35px">
                    <Items>
                        <x:Panel ID="Panel2" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column"
                            CssClass="x-form-item">
                            <Items>
                                <x:Button ID="btn_Search" runat="server" Text="查询" Icon="SystemSearch" OnClick="btn_Search_Click" Visible="false" CssStyle="margin-left:5px"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" ShowHeader="false" EnableBackgroundColor="true" CssStyle="padding-top:5px"
                    BoxFlex="2" EnableCheckBoxSelect="true" AllowPaging="true" DataKeyNames="row" IsDatabasePaging="true"
                    OnPageIndexChange="grid_List_PageIndexChange" EnableTextSelection="true" PageSize="20">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_ExpendExcel" runat="server" Text="生成Excel" Icon="PageWhiteExcel" OnClick="btn_ExpendExcel_Click" Visible="false">
                                </x:Button>
                                <x:HyperLink ID="hl_ExportExcel" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出本页数据"></x:HyperLink>
                                <x:ToolbarSeparator ID="bl_Separator" runat="server" Visible="false" />
                                <x:HyperLink ID="hl_ExportAll" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出全部数据"></x:HyperLink>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:BoundField ColumnID="Address" HeaderText="地址" DataField="Address" Width="200px" />
                        <x:BoundField ColumnID="DealerName" HeaderText="经销商" DataField="DealerName" Width="230px" />
                        <x:BoundField ColumnID="BankName" HeaderText="合作行" DataField="BankName" Width="200px" />
                        <x:BoundField ColumnID="BrandName" HeaderText="品牌" DataField="BrandName" Width="100px" />
                        <x:BoundField ColumnID="szsm" HeaderText="私自售卖" DataField="szsm" Width="60px" />
                        <x:BoundField ColumnID="szyd" HeaderText="私自移动" DataField="szyd" Width="60px" />
                        <x:BoundField ColumnID="xswhk" HeaderText="销售未还款" DataField="xswhk" Width="60px" />
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
        <x:Window ID="WindowAdd" runat="server" BodyPadding="5px" Height="660px" IsModal="true" Popup="false" Title="添加车辆异常汇总" Width="1360px"
            EnableClose="true" EnableBackgroundColor="true" EnableMaximize="true" EnableMinimize="true" EnableDrag="false"
            Target="Parent" EnableIFrame="true" OnClose="WindowAdd_Close">
        </x:Window>
    </form>
</body>
</html>
