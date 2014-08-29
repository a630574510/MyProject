<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditFactoryInfo.aspx.cs" Inherits="Citic_Web.BasicInfoManagement.EditFactoryInfo" %>

<%@ Register Src="~/UserControls/WUC_Address.ascx" TagPrefix="uc1" TagName="WUC_Address" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" AutoHeight="true" ShowBorder="false" ShowHeader="false" Title="修改厂商信息"
            EnableBackgroundColor="true" Layout="Table" Height="600px" TableConfigColumns="2">
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
                <x:Panel ID="pnl_BasicInfo" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" Title="基本信息"
                    EnableBackgroundColor="true" TableColspan="2" Width="800px" CssStyle="margin-bottom:5px">
                    <Items>
                        <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false"
                            ShowBorder="false" EnableBackgroundColor="true">
                            <Items>
                                <x:TextBox ID="txt_FactoryName" runat="server" Label="厂家名称" Required="true" RequiredMessage="请输入工厂的名称！"
                                    Text="" Width="200px" />
                                
                                <x:UserControlConnector ID="UserControlConnector1" runat="server">
                                    <uc1:WUC_Address runat="server" ID="WUC_Address" />
                                </x:UserControlConnector>
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
                <x:Panel ID="pnl_Brand" runat="server" BodyPadding="5px" AutoHeight="true" AutoScroll="true" ShowBorder="true" ShowHeader="true"
                    Title="品牌信息" EnableBackgroundColor="true" Width="390px" Height="350px" CssStyle="margin-right:5px">
                    <Items>
                        <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" ShowHeader="false"
                            EnableBackgroundColor="true">
                            <Toolbars>
                                <x:Toolbar ID="Toolbar3" runat="server">
                                    <Items>
                                        <x:Button ID="btn_AddBrand" runat="server" ValidateForms="SimpleForm2" Text="添加品牌"
                                            Icon="Add" OnClick="btn_AddBrand_Click">
                                        </x:Button>
                                    </Items>
                                </x:Toolbar>
                            </Toolbars>
                            <Items>
                                <x:TextBox ID="txt_BrandName" runat="server" Required="true" RequiredMessage="请输入品牌名称！"
                                    Label="品牌名称" Text="">
                                </x:TextBox>
                                <x:TextArea ID="txt_Remark" runat="server" Height="50px" Label="备注" Text="">
                                </x:TextArea>
                            </Items>
                        </x:SimpleForm>
                        <x:Label ID="Label1" runat="server">
                        </x:Label>
                        <x:Label ID="Label2" runat="server">
                        </x:Label>
                        <x:Grid ID="grid_BrandList" runat="server" EnableCheckBoxSelect="true" EnableRowNumber="true"
                            Title="品牌信息" PageSize="5" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                            DataKeyNames="BrandID,BrandName" EnableBackgroundColor="true" IsDatabasePaging="true"
                            ClearSelectedRowsAfterPaging="false" ForceFitAllTime="true" AutoHeight="true"
                            Height="185px" OnRowCommand="grid_RowCommand" OnPageIndexChange="grid_PageIndexChange">
                            <Toolbars>
                                <x:Toolbar ID="Toolbar4" runat="server">
                                    <Items>
                                        <x:Button ID="btn_DeleteBrand" runat="server" Text="批量删除" Icon="Delete" OnClick="btn_Click">
                                        </x:Button>
                                    </Items>
                                </x:Toolbar>
                            </Toolbars>
                            <Columns>
                                <x:BoundField ColumnID="bf_Brand" DataField="BrandName" DataFormatString="{0}" HeaderText="品牌" />
                                <x:BoundField ColumnID="bf_Remark" DataField="Remark" DataFormatString="{0}" HeaderText="备注" />
                                <x:LinkButtonField ConfirmIcon="Warning" ID="LinkButtonField1" ConfirmTarget="Parent"
                                    ConfirmText="确定要删除？" ConfirmTitle="系统提示" Text="删除" HeaderText="删除" CommandName="del" />
                            </Columns>
                            <PageItems>
                                <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                </x:ToolbarSeparator>
                                <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                                </x:ToolbarText>
                                <x:DropDownList runat="server" ID="ddl_BrandPage" Width="40px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged">
                                    <x:ListItem Text="5" Value="5" Selected="true" />
                                    <x:ListItem Text="10" Value="10" />
                                    <x:ListItem Text="15" Value="15" />
                                    <x:ListItem Text="20" Value="20" />
                                </x:DropDownList>
                            </PageItems>
                        </x:Grid>
                    </Items>
                </x:Panel>
                <x:Panel ID="Panel2" runat="server" BodyPadding="5px" AutoHeight="true" AutoScroll="true"
                    ShowBorder="true" ShowHeader="true" Title="联系人信息" EnableBackgroundColor="true"
                    Width="405px" Height="350px">
                    <Items>
                        <x:SimpleForm ID="SimpleForm3" runat="server" BodyPadding="5px" ShowHeader="false"
                            EnableBackgroundColor="true">
                            <Toolbars>
                                <x:Toolbar ID="Toolbar5" runat="server">
                                    <Items>
                                        <x:Button ID="btn_AddLinkman" runat="server" Text="添加联系人" Icon="Add" ValidateForms="SimpleForm3"
                                            OnClick="btn_AddLinkman_Click">
                                        </x:Button>
                                    </Items>
                                </x:Toolbar>
                            </Toolbars>
                            <Items>
                                <x:TextBox ID="txt_LinkManName" Required="true" RequiredMessage="请输入联系人姓名！" runat="server"
                                    Label="联系人名称" Text="">
                                </x:TextBox>
                                <x:NumberBox ID="num_Phone" runat="server" Label="联系电话" />
                                <x:TextBox ID="txt_Email" runat="server" Label="Email" Text="" Regex="[a-zA-Z0-9_+.-]+\@([a-zA-Z0-9-]+\.)+[a-zA-Z0-9]{2,4}" />
                            </Items>
                        </x:SimpleForm>
                        <x:Label ID="Label3" runat="server">
                        </x:Label>
                        <x:Label ID="Label4" runat="server">
                        </x:Label>
                        <x:Grid ID="grid_LinkManList" runat="server" EnableCheckBoxSelect="true" EnableRowNumber="true"
                            Title="联系人信息" PageSize="5" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                            DataKeyNames="LinkmanID,LinkmanName" EnableBackgroundColor="true" IsDatabasePaging="true"
                            ClearSelectedRowsAfterPaging="false" ForceFitAllTime="true" Height="185px" OnPageIndexChange="grid_PageIndexChange"
                            OnRowCommand="grid_RowCommand">
                            <Toolbars>
                                <x:Toolbar ID="Toolbar6" runat="server">
                                    <Items>
                                        <x:Button ID="btn_DeleteLinkman" runat="server" Text="批量删除" Icon="Delete" OnClick="btn_Click">
                                        </x:Button>
                                    </Items>
                                </x:Toolbar>
                            </Toolbars>
                            <Columns>
                                <x:BoundField ColumnID="bf_LinkManName" DataField="LinkmanName" DataFormatString="{0}"
                                    HeaderText="名称" />
                                <x:BoundField ColumnID="bf_Phone" DataField="Phone" DataFormatString="{0}" HeaderText="电话" />
                                <x:BoundField ColumnID="bf_Email" DataField="Email" DataFormatString="{0}" HeaderText="Email" />
                                <x:LinkButtonField ConfirmIcon="Warning" ID="link_Del" ConfirmTarget="Parent" ConfirmText="确定要删除？"
                                    ConfirmTitle="系统提示" Text="删除" HeaderText="删除" />
                            </Columns>
                            <PageItems>
                                <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                </x:ToolbarSeparator>
                                <x:ToolbarText ID="ToolbarText1" runat="server" Text="每页数：">
                                </x:ToolbarText>
                                <x:DropDownList runat="server" ID="ddl_LinkmanPage" Width="40px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddl_PageSize_SelectedIndexChanged">
                                    <x:ListItem Text="5" Value="5" Selected="true" />
                                    <x:ListItem Text="10" Value="10" />
                                    <x:ListItem Text="15" Value="15" />
                                    <x:ListItem Text="20" Value="20" />
                                </x:DropDownList>
                            </PageItems>
                        </x:Grid>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS_Brand" runat="server">
        </x:HiddenField>
        <x:HiddenField ID="hfSelectedIDS_Linkman" runat="server">
        </x:HiddenField>
    </form>
</body>
</html>
