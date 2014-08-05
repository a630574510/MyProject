<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChoiseSuper.aspx.cs" Inherits="Citic_Web.DealerManagement.DealerInfo.ChoiseSuper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" Title="监管员"
            EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_Save" runat="server" Text="保存" Icon="SystemSaveNew" OnClick="btn_Save_Click"></x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:SimpleForm ID="simpleform1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false" EnableBackgroundColor="true"
                    Height="40px" CssStyle="padding-bottom:5px">
                    <Items>
                        <x:Panel ID="Panel2" runat="server" CssClass="x-form-item" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="监管员姓名:" CssClass="inline"></x:Label>
                                <x:TextBox ID="txt_SName" runat="server" Width="400px" ShowLabel="true" Text="" CssClass="inline"></x:TextBox>
                                <x:Button ID="btn_Search" runat="server" Text="查询" CssClass="inline" OnClick="btn_Search_Click"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" ShowHeader="false" EnableBackgroundColor="true" IsDatabasePaging="true" AllowPaging="true"
                    EnableTextSelection="true" BoxFlex="1" PageSize="15" DataKeyNames="SupervisorID,SupervisorName"
                    ClearSelectedRowsAfterPaging="false" OnPageIndexChange="grid_List_PageIndexChange" OnRowDataBound="grid_List_RowDataBound"
                    EnableRowSelect="true" OnRowSelect="grid_List_RowSelect">
                    <Columns>
                        <x:BoundField ColumnID="bf_SupervisorName" DataField="SupervisorName" DataFormatString="{0}"
                            HeaderText="监管员姓名" Width="100px" />
                        <x:BoundField ColumnID="bf_Gender" DataField="Gender" DataFormatString="{0}" HeaderText="性别" Width="50px" />
                        <x:BoundField ColumnID="bf_Age" DataField="Age" DataFormatString="{0}" HeaderText="年龄" Width="50px" />
                        <x:BoundField ColumnID="bf_Education" DataField="Education" DataFormatString="{0}"
                            HeaderText="学历" Width="50px" />
                        <x:BoundField ColumnID="bf_LinkPhone" DataField="LinkPhone" DataFormatString="{0}"
                            HeaderText="联系电话" Width="100px" />
                        <x:BoundField ColumnID="bf_WorkSource" DataField="WorkSource" DataFormatString="{0}"
                            HeaderText="工作来源" Width="100px" />
                        <x:BoundField ColumnID="bf_QQ" DataField="QQ" DataFormatString="{0}" HeaderText="QQ" Width="100px" />
                        <x:BoundField ColumnID="bf_EntryTime" DataField="EntryTime" DataFormatString="{0}"
                            HeaderText="入职时间" Width="150px" />
                    </Columns>
                    <PageItems>
                        <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </x:ToolbarSeparator>
                        <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                        </x:ToolbarText>
                        <x:DropDownList runat="server" ID="ddlPageSize" Width="40px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <x:ListItem Text="5" Value="5" />
                            <x:ListItem Text="10" Value="10" />
                            <x:ListItem Text="15" Value="15" Selected="true" />
                            <x:ListItem Text="20" Value="20" />
                        </x:DropDownList>
                    </PageItems>
                </x:Grid>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
    </form>
</body>
</html>
