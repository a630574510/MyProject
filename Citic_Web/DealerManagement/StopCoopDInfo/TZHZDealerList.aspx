<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TZHZDealerList.aspx.cs"
    Inherits="Citic_Web.DealerManagement.StopCoopDInfo.TZHZDealerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PmRoleList" runat="server" AutoSizePanelID="PanelMenu" />
        <x:Panel ID="PanelMenu" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            EnableLargeHeader="true" Title="检索条件" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" Height="40px" CssStyle="padding-bottom:5px">
                    <Items>
                        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="企业名称：" CssClass="inline"></x:Label>
                                <x:TextBox ID="txt_DealerName" runat="server" ShowLabel="true" Label="企业名称" CssStyle="padding-left:0px;height:20px;font-size:15px" Width="300px" />
                                <x:Label ID="Label2" runat="server" Text="驻店日期：" CssClass="inline" CssStyle="padding-left:10px"></x:Label>
                                <x:DatePicker ID="dp_Start" runat="server" />
                                <x:Label ID="Label3" runat="server" Text="至：" CssClass="inline" CssStyle="padding-left:10px"></x:Label>
                                <x:DatePicker ID="dp_End" runat="server" Label="至" />
                                <x:Button ID="btn_Search" runat="server" Text="搜索" Visible="false" Icon="SystemSearch" OnClick="btn_Search_Click" CssStyle="padding-left:5px"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Panel ID="Panel8" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                    runat="server">
                    <Items>
                        <x:Grid ID="grid_List" Title="停止合企业信息" PageSize="20" ShowBorder="false" ShowHeader="false"
                            AllowPaging="true" runat="server" DataKeyNames="ID,BankID,DealerID"
                            IsDatabasePaging="true" OnPageIndexChange="grid_List_PageIndexChange" EnableRowNumber="True" EnableTextSelection="true"
                            ClearSelectedRowsAfterPaging="false" ForceFitAllTime="false" OnRowDataBound="grid_List_RowDataBound">
                            <Columns>
                                <x:BoundField DataField="DealerName" DataFormatString="{0}" HeaderText="企业名称" Width="240px" />
                                <x:BoundField DataField="BankName" HeaderText="合作银行" Width="200px" />
                                <x:BoundField DataField="BrandName" HeaderText="品牌" Width="100px" />
                                <x:BoundField DataField="BusinessMode" HeaderText="业务模式" Width="100px" />
                                <x:BoundField DataField="DispatchTime" HeaderText="驻店日期" Width="150px" />
                                <x:BoundField DataField="SSMoney" HeaderText="监管费用（元）" />
                                <x:BoundField DataField="PaymentCycle" HeaderText="缴费周期" Width="60px" />
                                <x:BoundField DataField="StopTime" HeaderText="停止合作时间" Width="150px" />
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
                                    <x:ListItem Text="15" Value="15" />
                                    <x:ListItem Text="20" Value="20" Selected="true" />
                                </x:DropDownList>
                            </PageItems>
                        </x:Grid>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
    </form>
</body>
</html>
