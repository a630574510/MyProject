<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OperatingRecord_List.aspx.cs" Inherits="Citic_Web.Reminds.OperatingRecord_List" %>

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
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" Title="操作记录"
            Layout="VBox" BoxConfigAlign="Stretch" EnableBackgroundColor="true">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" BoxFlex="1" CssStyle="padding-bottom:5px"
                    Height="90px">
                    <Items>
                        <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="合作行：" CssStyle="padding-right:20px"></x:Label>
                                <x:DropDownList ID="ddl_Bank" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddl_Bank_SelectedIndexChanged"></x:DropDownList>

                                <x:Label ID="Label2" runat="server" Text="企业名称：" CssStyle="padding-left:20px;padding-right:30px"></x:Label>
                                <x:DropDownList ID="ddl_Dealer" runat="server" Width="300px"></x:DropDownList>
                            </Items>
                        </x:Panel>

                        <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label3" runat="server" Text="车架号：" CssStyle="padding-right:20px"></x:Label>
                                <x:TextBox ID="txt_Vin" runat="server" Label="Label" Width="306px" Text=""></x:TextBox>
                                <x:Label ID="Label4" runat="server" Text="手填企业名称：" CssStyle="padding-left:20px;padding-right:6px"></x:Label>
                                <x:TextBox ID="txt_DealerName" runat="server" Label="企业名称" Width="306px" Text=""></x:TextBox>
                            </Items>
                        </x:Panel>
                        <x:Panel ID="Panel4" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Button ID="btn_Search" runat="server" Text="查询" Icon="SystemSearch" Visible="false" OnClick="btn_Search_Click"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" ShowHeader="false" EnableBackgroundColor="true"
                    BoxFlex="1" EnableCheckBoxSelect="true" AllowPaging="true" DataKeyNames="ID,Vin" IsDatabasePaging="true"
                    OnPageIndexChange="grid_List_PageIndexChange" OnRowDataBound="grid_List_RowDataBound"
                    AllowSorting="true" OnSort="grid_List_Sort" SortColumnIndex="0" SortDirection="ASC" PageSize="15">

                    <Columns>
                        <x:BoundField HeaderText="经销商" DataField="DealerName" SortField="DealerName" Width="200px" />
                        <x:BoundField HeaderText="票号" DataField="DraftNo" SortField="DraftNo" Width="200px" />
                        <x:BoundField HeaderText="车架号" DataField="Vin" Width="200px" />
                        <x:BoundField HeaderText="事项" DataField="ReqType" Width="60px" />
                        <x:BoundField HeaderText="具体内容" DataField="Content" Width="300px" />
                        <x:BoundField HeaderText="申请时间" DataField="CreateTime" />
                        <x:BoundField HeaderText="状态" DataField="Status" Width="50px" />
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
