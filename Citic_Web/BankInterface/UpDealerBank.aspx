<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpDealerBank.aspx.cs" Inherits="Citic_Web.BankInterface.UpDealerBank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="VBox" BoxConfigAlign="Stretch" EnableBackgroundColor="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="true"
                Title="经销商修改银行" EnableBackgroundColor="true">
                <Items>
                    <x:SimpleForm ID="SimpleForm" runat="server" BodyPadding="5px" Title="基本信息" EnableBackgroundColor="true"
                        LabelAlign="Right">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button runat="server" Text="提交" ID="Btn_Add_Search" Icon="Tick" IconAlign="Right"
                                        OnClick="Btn_Add_Search_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Items>
                            <x:DropDownList ID="Ddl_Dealer" runat="server" Label="经销商" EnableEdit="true" Width="300px"
                                AutoPostBack="true" Resizable="true" OnSelectedIndexChanged="Ddl_Dealer_SelectedIndexChanged">
                            </x:DropDownList>
                            <x:Label ID="LblDealerID" runat="server" CssStyle="color:red;" Label="原经销商ID" Text=""
                                Hidden="true">
                            </x:Label>
                            <x:Label ID="LblBankID" runat="server" CssStyle="color:red;" Label="原银行ID" Text=""
                                Hidden="true">
                            </x:Label>
                            <x:Label ID="LblBank" runat="server" CssStyle="color:red;" Label="现合作银行" Text="">
                            </x:Label>
                            <x:Label ID="LblBrandName" runat="server" CssStyle="color:red;" Label="现合作品牌" Text="">
                            </x:Label>
                            <x:DropDownList ID="Ddl_BankList" runat="server" Label="修改银行" EnableEdit="true" Width="300px"
                                Resizable="true">
                            </x:DropDownList>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                Title="结果信息" Layout="Fit" BoxFlex="1" EnableBackgroundColor="true">
                <Toolbars>
                    <x:Toolbar runat="server">
                        <Items>
                            <x:Button ID="Btn_Search" runat="server" Text="查询" Icon="SystemSearch" ToolTipType="Qtip"
                                OnClick="Btn_Search_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="G_UpList" runat="server" Title="Grid" ShowHeader="false" OnRowDataBound="G_UpList_RowDataBound" EnableBackgroundColor="true">
                        <Columns>
                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" Width="200px" />
                            <x:BoundField HeaderText="原合作银行" DataField="BankName" Width="200px" />
                            <x:BoundField HeaderText="修改后合作银行" DataField="UpBankName" Width="200px" />
                            <x:BoundField HeaderText="状态" DataField="Statu" Width="50px" />
                            <x:BoundField HeaderText="添加时间" DataField="CreateTime" Width="150px" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
