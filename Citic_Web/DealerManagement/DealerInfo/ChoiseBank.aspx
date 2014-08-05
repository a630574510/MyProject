<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChoiseBank.aspx.cs" Inherits="Citic_Web.DealerManagement.DealerInfo.ChoiseBank" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false"
            EnableBackgroundColor="true" AutoScroll="true" Layout="HBox" BoxConfigAlign="Stretch">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_Sure" runat="server" Text="保存" Icon="Add" ValidateForms="" OnClick="btn_Sure_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true" Title="选择合作行" Layout="VBox"
                    EnableBackgroundColor="true" Width="557px" AutoHeight="true" CssStyle="padding-right:5px">
                    <Items>
                        <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" Title="筛选条件" ShowHeader="false" ShowBorder="false" EnableBackgroundColor="true" Height="110px" CssStyle="padding-bottom:5px">
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
                                <x:Panel ID="Panel7" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    CssClass="x-form-item" Layout="Column">
                                    <Items>
                                        <x:Label ID="lbl_BankInterface" runat="server" Text="是否要对接光大接口" CssStyle="padding-right:10px" Enabled="false"></x:Label>
                                        <x:CheckBox ID="cbl_BankInterface" runat="server" Label="Label" Text="" Enabled="false" AutoPostBack="true" OnCheckedChanged="cbl_BankInterface_CheckedChanged"></x:CheckBox>
                                    </Items>
                                </x:Panel>
                            </Items>
                        </x:SimpleForm>
                        <x:Grid ID="grid_List" runat="server" Title="合作行信息" EnableTextSelection="true" DataKeyNames="BankID,BankName" BoxFlex="1" Width="550px" ShowBorder="false"
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
                <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" Title="基本信息"
                    EnableBackgroundColor="true" BoxFlex="1" Layout="VBox" BoxConfigAlign="Stretch">
                    <Items>
                        <x:SimpleForm ID="SimpleForm1" BoxFlex="1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true">
                            <Items>
                                <x:DropDownList ID="ddl_Factory" runat="server" Label="经营品牌" Width="200px" Required="true"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddl_Factory_SelectedIndexChanged"
                                    CompareType="String" CompareOperator="NotEqual" CompareValue="0" Resizable="true">
                                </x:DropDownList>
                                <x:DropDownList ID="ddl_Brand" runat="server" ShowLabel="true" Width="150px" CompareType="String"
                                    CompareOperator="NotEqual" CompareValue="0" Required="true" CompareMessage="请选择合作品牌！">
                                </x:DropDownList>

                                <x:DropDownList ID="ddl_BusinessMode" runat="server" Width="150px" Label="业务模式" CompareType="String"
                                    CompareOperator="NotEqual" CompareValue="0" Required="true" CompareMessage="请选择业务模式！">
                                </x:DropDownList>
                                <x:NumberBox ID="num_SSMoney" runat="server" Label="实收费用" Width="150px" DecimalPrecision="2" Text="0.00"></x:NumberBox>
                                <x:NumberBox ID="num_YSMoney" runat="server" Label="应收费用" Width="150px" DecimalPrecision="2" Text="0.00"></x:NumberBox>
                                <x:DropDownList ID="ddl_PaymentCycle" runat="server" Width="150px" Label="缴费周期" CompareType="String"
                                    CompareOperator="NotEqual" CompareValue="0" Required="true" RequiredMessage="请选择缴费周期！">
                                </x:DropDownList>

                                <%--<x:CheckBoxList ID="cbl_FinancingMode" runat="server" Width="300px" Label="融资模式"
                                    Required="true" RequiredMessage="请选择融资模式！">
                                </x:CheckBoxList>--%>
                                <x:DatePicker ID="dp_DispatchTime" EnableEdit="false" runat="server" Width="150px" Label="驻店日期" Required="true"
                                    RequiredMessage="请选择住店日期！">
                                </x:DatePicker>
                                <x:Panel ID="Panel8" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                                    CssClass="x-form-item" Layout="Column">
                                    <Items>
                                        <x:Button ID="btn_AddBrand" runat="server" Text="添加品牌" ValidateForms="SimpleForm1" OnClick="btn_AddBrand_Click"></x:Button>
                                        <x:Button ID="btn_Cancel" runat="server" Text="取消" CssStyle="padding-left:5px" OnClick="btn_Cancel_Click" Enabled="false"></x:Button>
                                    </Items>
                                </x:Panel>
                            </Items>
                        </x:SimpleForm>
                        <x:Grid ID="grid_BrandList" runat="server" Title="品牌" EnableBackgroundColor="true" EnableRowNumber="true" BoxFlex="1"
                            OnRowCommand="grid_BrandList_RowCommand" DataKeyNames="dc_ID,dc_BrandID,dc_BusinessMode,dc_PaymentCycle"
                            EnableRowClick="true" OnRowClick="grid_BrandList_RowClick">
                            <Columns>
                                <x:BoundField DataField="dc_BrandName" HeaderText="品牌名" DataFormatString="{0}" Width="50px" />
                                <x:BoundField DataField="dc_BusinessModeStr" HeaderText="业务模式" DataFormatString="{0}" Width="70px" />
                                <x:BoundField DataField="dc_SSMoney" HeaderText="实收费用" DataFormatString="{0}" Width="60px" />
                                <x:BoundField DataField="dc_YSMoney" HeaderText="应收费用" DataFormatString="{0}" Width="60px" />
                                <x:BoundField DataField="dc_PaymentCycleStr" HeaderText="缴费周期" DataFormatString="{0}" Width="60px" />
                                <%--<x:BoundField DataField="dc_FinancingModeStr" HeaderText="融资模式" DataFormatString="{0}" Width="150px" />--%>
                                <x:BoundField DataField="dc_DispatchTime" HeaderText="驻店日期" DataFormatString="{0}" Width="80px" />
                                <x:LinkButtonField Text="删除" Width="40px" HeaderText="操作" CommandName="del" ConfirmIcon="Warning" ConfirmText="你确定要删除该条品牌信息？" ConfirmTitle="系统提醒" />
                            </Columns>
                        </x:Grid>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
        <x:HiddenField ID="hf_BankID" runat="server"></x:HiddenField>
        <x:HiddenField ID="hf_DealerInfo" runat="server"></x:HiddenField>
    </form>
</body>
</html>
