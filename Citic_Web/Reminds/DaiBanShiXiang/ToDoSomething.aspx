<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoSomething.aspx.cs" Inherits="Citic_Web.Reminds.DaiBanShiXiang.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" />
    <style type="text/css">
        .padding-bottom {
            padding-bottom: 5px;
        }

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
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" Title="待办事项"
            Layout="VBox" BoxConfigAlign="Stretch" EnableBackgroundColor="true">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" Height="90px" CssStyle="padding-bottom:5px">
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
                                <x:TextBox ID="ttb_Search" runat="server" Label="Label" Width="306px" Text=""></x:TextBox>
                                <x:Label ID="Label4" runat="server" Text="手填企业名称：" CssStyle="padding-left:20px;padding-right:6px"></x:Label>
                                <x:TextBox ID="txt_DealerName" runat="server" Label="企业名称" Width="306px" Text=""></x:TextBox>
                            </Items>
                        </x:Panel>
                        <x:Panel ID="Panel4" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label5" runat="server" Text="状态：" CssStyle="padding-right:32px"></x:Label>
                                <x:DropDownList ID="ddl_Status" runat="server" Width="80px">
                                    <x:ListItem Value="-1" Text="请选择" Selected="true" />
                                    <x:ListItem Value="1" Text="通过" />
                                    <x:ListItem Value="2" Text="处理中" />
                                    <x:ListItem Value="3" Text="未通过" />
                                </x:DropDownList>
                                <x:Button ID="btn_Search" runat="server" Text="查询" Icon="SystemSearch" CssStyle="padding-left:10px" Visible="false" OnClick="btn_Search_Click"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" ShowHeader="false" EnableBackgroundColor="true" EnableTextSelection="true"
                    BoxFlex="1" EnableCheckBoxSelect="true" AllowPaging="true" DataKeyNames="ID,Vin,BankID,DealerID,ReqType" IsDatabasePaging="true" PageSize="15"
                    OnPageIndexChange="grid_List_PageIndexChange" OnRowDataBound="grid_List_RowDataBound" OnRowCommand="grid_List_RowCommand">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_Sures" runat="server" Text="批量确定" Visible="false" OnClick="btn_Sures_Click"></x:Button>
                                <x:Button ID="btn_Passes" runat="server" Text="批量通过" Visible="false" OnClick="btn_Passes_Click"></x:Button>
                                <x:Button ID="btn_Deletes" runat="server" Text="批量删除" Visible="false"></x:Button>
                                <x:Button ID="btn_Returns" runat="server" Text="批量退回" Visible="false" OnClick="btn_Returns_Click"></x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:BoundField HeaderText="经销商" DataField="DealerName" Width="200px" />
                        <x:BoundField HeaderText="票号" DataField="DraftNo" Width="200px" />
                        <x:BoundField HeaderText="车架号" DataField="Vin" Width="200px" />
                        <x:BoundField HeaderText="事项" DataField="ReqType" Width="60px" />
                        <x:BoundField HeaderText="具体内容" DataField="Content" Width="300px" />
                        <x:BoundField HeaderText="申请时间" DataField="CreateTime" />
                        <x:BoundField HeaderText="状态" DataField="Status" Width="50px" />
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
