<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DraftInfo.aspx.cs" Inherits="Citic_Web.FinanceInfo.DraftInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false"
            ShowHeader="false" EnableBackgroundColor="true" Layout="Fit">
            <Items>
                <x:Panel ID="Panel2" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
                    ShowBorder="true" ShowHeader="true" Title="修改汇票信息" CssClass="rowpanel" Layout="HBox"
                    BoxConfigAlign="Stretch" BoxConfigPosition="Start">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar13" runat="server">
                            <Items>
                                <x:Button ID="btn_SaveAndClose" ValidateForms="sf_DraftInfo" runat="server" Text="保存汇票信息"
                                    Icon="SystemSaveNew" OnClick="btn_SaveAndClose_Click" Enabled="false">
                                </x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:SimpleForm ID="sf_DraftInfo" EnableBackgroundColor="true" runat="server" BodyPadding="5px" BoxFlex="1"
                            ShowHeader="true" Width="360px" Height="525px" Title="基本信息" CssStyle="padding-right:5px"
                            AutoScroll="true">
                            <Items>
                                <x:Button ID="btn_Modify" Enabled="false" runat="server" Text="修改" OnClick="btn_Modify_Click"></x:Button>
                                <x:Label ID="lbl_BankName" runat="server" Label="归属银行" Text="" CssStyle="color:red;font-weight:bold" Enabled="false">
                                </x:Label>
                                <x:Label ID="lbl_DealerName" runat="server" Label="归属企业" Text="" CssStyle="color:red;font-weight:bold" Enabled="false">
                                </x:Label>
                                <x:Label ID="lbl_DraftNo" runat="server" Label="质押号" Text="" CssStyle="color:red;font-weight:bold" Enabled="false">
                                </x:Label>
                                <x:NumberBox ID="num_Money" runat="server" Label="金额" DecimalPrecision="2" Required="true" Enabled="false"
                                    RequiredMessage="请输入质押金额！">
                                </x:NumberBox>
                                <x:DatePicker ID="dp_BeginTime" runat="server" Label="开票日期" Required="true" Enabled="false">
                                </x:DatePicker>
                                <x:DatePicker ID="dp_EndTime" runat="server" Label="到期日期" Required="true" Enabled="false">
                                </x:DatePicker>
                                <x:TextBox ID="txt_PledgeNo" runat="server" Label="质押号" Text="" Enabled="false">
                                </x:TextBox>
                                <x:TextBox ID="txt_GuaranteeNo" runat="server" Label="保证金号" Text="" Enabled="false">
                                </x:TextBox>
                                <x:NumberBox ID="num_Ratio" runat="server" Label="保证金比例" DecimalPrecision="0" Required="true" Enabled="false"
                                    RequiredMessage="请输入保证金比例！">
                                </x:NumberBox>
                                <x:TextBox ID="txt_RGuaranteeNo" runat="server" Label="汇款保证金号" Text="" Enabled="false">
                                </x:TextBox>
                                <x:Label ID="lbl_HKMoney" runat="server" Label="回款总额" Text="" Enabled="false">
                                </x:Label>
                            </Items>
                        </x:SimpleForm>
                        <x:Panel ID="pnl_CarInfo" EnableBackgroundColor="true" runat="server" BodyPadding="0px" BoxFlex="2"
                            ShowHeader="true" Title="质押物信息" CssStyle="padding-right:5px" Layout="Fit">
                            <Items>
                                <x:Grid ID="grid_List" PageSize="10" ShowBorder="false" ShowHeader="false" AllowPaging="true"
                                    runat="server" DataKeyNames="CarID,Vin" EnableTextSelection="true" AutoHeight="true"
                                    IsDatabasePaging="true" BoxConfigAlign="Stretch" OnPageIndexChange="grid_List_PageIndexChange"
                                    EnableRowNumber="True" ClearSelectedRowsAfterPaging="false" ForceFitAllTime="false"
                                    OnRowDataBound="grid_List_RowDataBound" AutoScroll="true">
                                    <Columns>
                                        <x:BoundField ID="bf_Vin" DataField="Vin" DataFormatString="{0}" HeaderText="车架号" />
                                        <x:BoundField ID="bf_CarModel" DataField="CarModel" DataFormatString="{0}" HeaderText="型号" />
                                        <x:BoundField ID="bf_Color" DataField="CarColor" DataFormatString="{0}" HeaderText="颜色" />
                                        <x:BoundField ID="bf_EngineNo" DataField="EngineNo" DataFormatString="{0}" HeaderText="发动机号" />
                                        <x:BoundField ID="bf_QualifiedNo" DataField="QualifiedNo" DataFormatString="{0}" HeaderText="合格证号" />
                                        <x:BoundField ID="bf_KeyCount" DataField="KeyCount" DataFormatString="{0}" HeaderText="钥匙数" />
                                        <x:BoundField ID="bf_CarCost" DataField="CarCost" DataFormatString="{0}" HeaderText="金额（元）" />
                                        <x:BoundField ID="bf_TransitTime" DataField="TransitTime" DataFormatString="{0}" HeaderText="入库日期" />
                                        <x:BoundField ID="bf_Statu" DataField="Statu" DataFormatString="{0}" HeaderText="车辆状态" />
                                        <x:BoundField ID="bf_ReturnCost" DataField="ReturnCost" DataFormatString="{0}" HeaderText="回款金额" />
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
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
    </form>
</body>
</html>
