<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StorageList.aspx.cs" Inherits="Citic_Web.DealerManagement.StorageInfo.StorageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
    <link href="../../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PmRoleList" runat="server" AutoSizePanelID="PanelMenu" />
        <x:Panel ID="PanelMenu" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            EnableLargeHeader="true" Title="二网信息" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" ShowBorder="true"
                    EnableBackgroundColor="true" CssStyle="padding-bottom:5px">
                    <Items>
                        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                            Layout="Column" EnableBackgroundColor="true" CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label1" runat="server" ShowLabel="false" Text="合作银行："></x:Label>
                                <x:DropDownList ID="ddl_Bank" Width="300px" runat="server" AutoPostBack="true"
                                    ShowLabel="true" Label="合作银行" OnSelectedIndexChanged="ddl_Bank_SelectedIndexChanged">
                                </x:DropDownList>
                                <x:Label ID="Label2" runat="server" ShowLabel="false" Text="企业名称：" CssStyle="padding-left:5px"></x:Label>
                                <x:DropDownList ID="ddl_Dealer" Width="300px" runat="server" Label="企业名称">
                                </x:DropDownList>
                            </Items>
                        </x:Panel>
                        <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" Layout="Column"
                            EnableBackgroundColor="true" CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label3" runat="server" ShowLabel="false" Text="二网名称："></x:Label>
                                <x:TextBox ID="txt_StorageName" runat="server" Label="二网名称" Width="306px" Text="" CssStyle="height:20px;font-size:15px">
                                </x:TextBox>
                                <x:Button ID="btn_Search" runat="server" Text="搜索" Visible="false" Icon="SystemSearch" OnClick="btn_Search_Click" CssStyle="padding-left:5px">
                                </x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Panel ID="Panel8" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                    runat="server">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_Add" runat="server" Text="添加" Icon="Add" Visible="false"></x:Button>
                                <x:ToolbarSeparator ID="tbs_Add" runat="server" Visible="false" />
                                <x:Button ID="btn_Modify" runat="server" Text="修改" Icon="ApplicationEdit" OnClick="btn_Modify_Click" Visible="false"></x:Button>
                                <x:ToolbarSeparator ID="tbs_Modify" runat="server" Visible="false" />
                                <x:Button ID="btn_Delete" runat="server" Text="批量删除" Icon="Delete" OnClick="btn_Deletes_Click" Visible="false"></x:Button>
                                <x:Button ID="btn_ExpendExcel" runat="server" Text="生成Excel" Icon="PageWhiteExcel" OnClick="btn_ExpendExcel_Click" Visible="false">
                                </x:Button>
                                <x:HyperLink ID="hl_ExportExcel" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出本页数据"></x:HyperLink>
                                <x:ToolbarSeparator ID="bl_Separator" runat="server" Visible="false" />
                                <x:HyperLink ID="hl_ExportAll" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出全部数据"></x:HyperLink>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Grid ID="grid_List" Title="二网信息" PageSize="15" ShowBorder="false" ShowHeader="false"
                            AllowPaging="true" runat="server" EnableCheckBoxSelect="True" DataKeyNames="StorageID,StorageName"
                            IsDatabasePaging="true" OnPageIndexChange="grid_List_PageIndexChange" EnableRowNumber="True"
                            ClearSelectedRowsAfterPaging="false" ForceFitAllTime="false" OnRowCommand="grid_List_RowCommand"
                            OnRowDataBound="grid_List_RowDataBound">
                            <Columns>
                                <x:BoundField ColumnID="DealerName" DataField="DealerName" DataFormatString="{0}" HeaderText="企业名称" Width="200px" />
                                <x:BoundField ColumnID="StorageName" DataField="StorageName" HeaderText="二网名称" Width="250px" />
                                <x:BoundField ColumnID="Address" DataField="Address" HeaderText="二网地址" Width="240px" />
                                <x:BoundField ColumnID="IsLocalStorage" DataField="IsLocalStorage" HeaderText="是否本库" Width="240px" />
                                <x:BoundField ColumnID="Distence" DataField="Distence" HeaderText="距离" Width="100px" />
                                <x:BoundField ColumnID="LinkmanName" DataField="LinkmanName" HeaderText="联系人姓名" Width="100px" />
                                <x:BoundField ColumnID="LinkmanPhone" DataField="LinkmanPhone" HeaderText="联系方式" Width="120px" />
                                <%--<x:LinkButtonField ColumnID="link_Delete" ConfirmIcon="Warning" ConfirmTarget="Parent" Width="50px"
                                    ConfirmText="确定要删除？" ConfirmTitle="系统提示" Text="删除" CommandName="delete" HeaderText="删除" />--%>
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
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
        <x:Window ID="WindowEdit" Title="修改仓库信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="1150px" EnableConfirmOnClose="true" Height="500px">
        </x:Window>
        <x:Window ID="WindowAdd" Title="添加仓库信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="1150px" EnableConfirmOnClose="true" Height="500px">
        </x:Window>
    </form>
</body>
</html>
