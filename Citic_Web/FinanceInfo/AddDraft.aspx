<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDraft.aspx.cs" Inherits="Citic_Web.FinanceInfo.WebForm1" %>

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
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false"
            EnableBackgroundColor="true" Layout="HBox" BoxConfigAlign="Stretch">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" runat="server" Text="保存并关闭" ValidateForms="SimpleForm1"
                            Icon="SystemSaveNew" OnClick="btn_SaveAndClose_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" Title="经销商信息" EnableBackgroundColor="true"
                    CssStyle="padding-right:5px" BoxFlex="1" Layout="VBox" BoxConfigAlign="Stretch">
                    <Items>
                        <x:Form ID="Form2" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" Height="40px"
                            LabelWidth="60px" CssStyle="padding-bottom:5px" BoxConfigAlign="Stretch">
                            <Rows>
                                <x:FormRow ID="FormRow1" runat="server">
                                    <Items>
                                        <x:TwinTriggerBox ID="ttb_DealerName" runat="server" Label="经销商名"
                                            Trigger1Icon="Clear" Trigger2Icon="Search" Width="300px" ShowLabel="true"
                                            OnTrigger1Click="TwinTriggerBox1_Trigger1Click" OnTrigger2Click="TwinTriggerBox1_Trigger2Click">
                                        </x:TwinTriggerBox>
                                    </Items>
                                </x:FormRow>
                            </Rows>
                        </x:Form>
                        <x:Grid ID="grid_List" runat="server" ShowHeader="false" EnableBackgroundColor="true" IsDatabasePaging="true" AutoPostBack="true"
                            BoxFlex="1" DataKeyNames="DealerID,DealerName"
                            OnPageIndexChange="grid_List_PageIndexChange" EnableRowNumber="True" PageSize="10"
                            ClearSelectedRowsAfterPaging="false" AllowPaging="true"
                            OnRowDataBound="grid_List_RowDataBound" EnableRowSelect="true" OnRowSelect="grid_List_RowSelect">
                            <Columns>
                                <x:BoundField DataField="DealerName" DataFormatString="{0}" HeaderText="企业名称" Width="300px" />
                                <x:BoundField DataField="DealerType" DataFormatString="{0}" HeaderText="企业属性" Width="100px" />
                                <x:BoundField DataField="IsGroup" DataFormatString="{0}" HeaderText="是否是集团性质" Width="100px" />
                                <x:BoundField DataField="HasOtherIndustries" DataFormatString="{0}" HeaderText="是否有其他产业" Width="100px" />
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

                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false"
                    EnableBackgroundColor="true" Width="450px">
                    <Items>
                        <x:Label ID="lbl_DealerName" runat="server" Label="经销商名称" Text="" CssStyle="color:red;font-weight:bold"></x:Label>
                        <x:DropDownList ID="ddl_Bank" runat="server" Label="归属银行" Width="200px" Required="true" RequiredMessage="请选择合作银行！" CompareOperator="NotEqual" CompareType="String"
                            CompareValue="-1">
                        </x:DropDownList>
                        <x:TextBox ID="txt_DraftNo" runat="server" Label="汇票号" Text="" Width="200px" Required="true"
                            RequiredMessage="请填写汇票号！">
                        </x:TextBox>
                        <x:NumberBox ID="num_Money" runat="server" Label="汇票金额" Width="200px" DecimalPrecision="2"
                            Required="true" RequiredMessage="请输入汇票金额！">
                        </x:NumberBox>
                        <x:DatePicker ID="dp_Start" Label="开票日期" EnableEdit="false" runat="server" Width="200px" Required="true"
                            RequiredMessage="请选择开票日期！">
                        </x:DatePicker>
                        <x:DatePicker ID="dp_End" Label="到期日期" EnableEdit="false" runat="server" Width="200px" Required="true"
                            RequiredMessage="请选择到票日期！" CompareControl="dp_Start" CompareOperator="GreaterThanEqual">
                        </x:DatePicker>
                        <x:TextBox ID="txt_PledgeNo" runat="server" Label="质押号" Text="" Width="200px">
                        </x:TextBox>
                        <x:TextBox ID="txt_GuaranteeNo" runat="server" Label="保证金账号" Text="" Width="200px">
                        </x:TextBox>
                        <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Label="Label"  CssStyle="padding-right:41px" Text="保证金比例:"></x:Label>
                                <x:NumberBox ID="num_Ratio" runat="server" Label="保证金比例" Width="50px" DecimalPrecision="2"
                                    Required="true" RequiredMessage="请输入保证金比例！">
                                </x:NumberBox>
                                <x:Label ID="Label2" runat="server" Text="%" CssStyle="padding-left:1px"></x:Label>
                            </Items>
                        </x:Panel>
                        <x:TextBox ID="txt_RGuaranteeNo" runat="server" Label="回款保证金账号" Text="" Width="200px">
                        </x:TextBox>
                        <x:TextArea ID="txt_Remark" runat="server" Height="80px" Label="备注" Width="300px"
                            Text="">
                        </x:TextArea>
                    </Items>
                </x:SimpleForm>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
    </form>
</body>
</html>
