<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMapping.aspx.cs" Inherits="Citic_Web.SystemSet.UserMapping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false" EnableBackgroundColor="true" AutoScroll="true"
            Layout="Fit">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btnSaveRefresh" Text="保存并关闭" ValidateForms="SimpleForm1" runat="server" Icon="SystemSaveNew"
                            OnClick="btnSaveRefresh_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Tree ID="tree_Bank" runat="server" AutoScroll="true" EnableArrows="true" EnableBackgroundColor="true" Visible="false" ShowHeader="false" OnNodeCheck="tree_Bank_NodeCheck"></x:Tree>
                <x:Panel ID="pnl_Bank" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false" Layout="VBox" Visible="false"
                    EnableBackgroundColor="true" AutoHeight="true">
                    <Items>
                        <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" Title="筛选条件" ShowHeader="false" ShowBorder="false" EnableBackgroundColor="true" Height="90px" CssStyle="padding-bottom:5px">
                            <Items>
                                <x:Panel ID="Panel4" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    CssClass="x-form-item" Layout="Column">
                                    <Items>
                                        <x:Label ID="Label1" runat="server" Text="银行名称："></x:Label>
                                        <x:TriggerBox runat="server" TriggerIcon="Search" ID="tb_Bank" Width="300px"
                                            OnTriggerClick="tb_Bank_TriggerClick">
                                        </x:TriggerBox>
                                    </Items>
                                </x:Panel>
                                <x:Panel ID="Panel5" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    CssClass="x-form-item" Layout="Column">
                                    <Items>
                                        <x:Label ID="Label2" runat="server" Text="银行名称："></x:Label>
                                        <x:RadioButtonList ID="rbl_Types" runat="server" Label="银行级别" Width="200px">
                                            <x:RadioItem Text="全部" Value="-1" Selected="true" />
                                            <x:RadioItem Text="总行" Value="0" />
                                            <x:RadioItem Text="分行" Value="1" />
                                            <x:RadioItem Text="支行" Value="2" />
                                        </x:RadioButtonList>
                                    </Items>
                                </x:Panel>
                                <x:Panel ID="Panel6" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    CssClass="x-form-item" Layout="Column">
                                    <Items>
                                        <x:Label ID="lbl_BankName" runat="server" Label="选择银行" Text="选择的银行将在这里显示" CssStyle="font-weight:bold;font-size:18px;color:gray"></x:Label>
                                    </Items>
                                </x:Panel>
                            </Items>
                        </x:SimpleForm>
                        <x:Grid ID="grid_List" runat="server" Title="合作行信息" EnableTextSelection="true" DataKeyNames="BankID,BankName" BoxFlex="1" ShowBorder="false"
                            AllowPaging="true" EnableBackgroundColor="true" PageSize="15" OnPageIndexChange="grid_List_PageIndexChange"
                            ClearSelectedRowsAfterPaging="true" IsDatabasePaging="true" CssStyle="padding-top:5px" OnRowDataBound="grid_List_RowDataBound"
                            ForceFitAllTime="true" EnableRowSelect="true" OnRowSelect="grid_List_RowSelect">
                            <Columns>
                                <x:BoundField HeaderText="合作行名称" DataField="BankName" Width="240px" />
                                <x:BoundField HeaderText="归属行名称" DataField="ParentName" Width="150px" />
                                <x:BoundField HeaderText="银行级别" DataField="BankType" Width="60px" />
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
        <x:HiddenField ID="hf_BankID" runat="server"></x:HiddenField>
    </form>
</body>
</html>
