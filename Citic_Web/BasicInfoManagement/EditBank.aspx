<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditBank.aspx.cs" Inherits="Citic_Web.BasicInfoManagement.EditBank" %>

<%@ Register Src="~/UserControls/WUC_Address.ascx" TagPrefix="uc1" TagName="WUC_Address" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" AutoHeight="true" ShowBorder="false" BodyPadding="5px"
            ShowHeader="false" Title="修改银行信息" EnableBackgroundColor="true" Height="560px"
            BoxConfigAlign="Stretch" BoxConfigPosition="Start" BoxConfigPadding="5" BoxConfigChildMargin="0 0 0 0">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" runat="server" Text="保存并关闭" Icon="SystemSaveNew"
                            OnClick="btn_SaveAndClose_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Panel ID="pnl_BasicInfo" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                    Title="基本信息" EnableBackgroundColor="true" BoxFlex="1" CssStyle="margin-bottom:5px">
                    <Items>
                        <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false"
                            ShowBorder="false" EnableBackgroundColor="true">
                            <Items>
                                <x:TextBox runat="server" ID="txt_BankName" Width="200px" Label="合作行名称" />
                                <x:UserControlConnector ID="UserControlConnector1" runat="server">
                                    <uc1:WUC_Address runat="server" ID="WUC_Address" Province="-1" City="-1" Address="" />
                                </x:UserControlConnector>

                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
                <x:Panel ID="pnl_Linkman" runat="server" BodyPadding="0px" AutoHeight="true" AutoScroll="true"
                    ShowBorder="true" ShowHeader="true" Title="联系人信息" EnableBackgroundColor="true"
                    Layout="Row" BoxFlex="2">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <x:Button ID="btn_Add" runat="server" Text="添加" Icon="Add">
                                </x:Button>
                                <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                <x:Button ID="btn_Delete" runat="server" Text="批量删除" Icon="Delete" OnClick="btn_Delete_Click">
                                </x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Grid ID="grid_LinkmanList" runat="server" EnableCheckBoxSelect="true" EnableRowNumber="true"
                            PageSize="10" ShowBorder="false" ShowHeader="false" AllowPaging="true"
                            DataKeyNames="LinkmanID,LinkmanName" IsDatabasePaging="true" ClearSelectedRowsAfterPaging="false"
                            ForceFitAllTime="true" OnPageIndexChange="grid_LinkmanList_PageIndexChange" Height="330px"
                            AutoHeight="true" OnRowCommand="grid_LinkmanList_RowCommand">
                            <Columns>
                                <x:BoundField ColumnID="bf_LinkmanName" DataField="LinkmanName" DataFormatString="{0}"
                                    HeaderText="名字" />
                                <x:BoundField ColumnID="bf_Post" DataField="Post" DataFormatString="{0}" HeaderText="职位" />
                                <x:BoundField ColumnID="bf_Phone" DataField="Phone" DataFormatString="{0}" HeaderText="电话" />
                                <x:BoundField ColumnID="bf_Email" DataField="Email" DataFormatString="{0}" HeaderText="Email" />
                                <x:WindowField WindowID="WindowShowInfo" TextAlign="Left" Width="100px" Icon="Pencil"
                                    ToolTip="编辑" DataIFrameUrlFields="LinkmanID,LinkmanName" DataIFrameUrlFormatString="../BasicInfoManagement/ShowLinkmanInfo.aspx?lkid={0}"
                                    Title="联系人信息" IFrameUrl="~/alert.aspx" HeaderText="编辑" />
                                <x:LinkButtonField ColumnID="link_Delete" Width="90px" ConfirmIcon="Warning" ConfirmTarget="Parent"
                                    ConfirmText="确定要删除？" ConfirmTitle="系统提示" CommandName="delete" Text="删除" HeaderText="删除" />
                            </Columns>
                            <PageItems>
                                <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
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
        <x:Window ID="WindowAdd" Title="添加联系人" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="500px" EnableConfirmOnClose="true" Height="400px">
        </x:Window>
        <x:Window ID="WindowShowInfo" Title="联系人信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="500px" EnableConfirmOnClose="true" Height="240px" />
    </form>
</body>
</html>
