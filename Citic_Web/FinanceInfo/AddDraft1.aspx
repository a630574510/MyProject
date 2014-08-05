<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDraft1.aspx.cs" Inherits="Citic_Web.Financing.Add_Draft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" />
        <x:Panel ID="P_Draft" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false" EnableBackgroundColor="true">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" ValidateForms="SimpleForm1" runat="server" Text="保存汇票信息"
                            Icon="SystemSaveNew" OnClick="btn_SaveAndClose_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar> 
            </Toolbars>
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" ShowHeader="false" ShowBorder="false"
                    EnableBackgroundColor="true" LabelAlign="Left" BodyPadding="5px">
                    <Items>
                        <x:DropDownList ID="ddl_Bank" runat="server" Label="归属银行" Width="200px" Required="true"
                            AutoPostBack="true" RequiredMessage="请选择合作银行！" CompareOperator="NotEqual" CompareType="String"
                            CompareValue="0" OnSelectedIndexChanged="ddl_Bank_SelectedIndexChanged">
                        </x:DropDownList>
                        <x:DropDownList ID="ddl_Dealer" runat="server" Label="归属企业" Width="300px" Required="true"
                            RequiredMessage="请选择企业！" CompareOperator="NotEqual" CompareType="String" CompareValue="0">
                        </x:DropDownList>
                        <x:TextBox ID="txt_DraftNo" runat="server" Label="汇票号" Text="" Width="200px" Required="true"
                            RequiredMessage="请填写汇票号！">
                        </x:TextBox>
                        <x:NumberBox ID="num_Money" runat="server" Label="汇票金额" Width="200px" DecimalPrecision="2"
                            Required="true" RequiredMessage="请输入汇票金额！">
                        </x:NumberBox>
                        <x:DatePicker ID="dp_Start" Label="开票日期" Readonly="true" runat="server" Width="200px" Required="true"
                            RequiredMessage="请选择开票日期！">
                        </x:DatePicker>
                        <x:DatePicker ID="dp_End" Label="到期日期" runat="server" Width="200px" Required="true"
                            RequiredMessage="请选择到票日期！" CompareControl="dp_Start" CompareOperator="GreaterThanEqual">
                        </x:DatePicker>
                        <x:TextBox ID="txt_PledgeNo" runat="server" Label="质押号" Text="" Width="200px">
                        </x:TextBox>
                        <x:TextBox ID="txt_GuaranteeNo" runat="server" Label="保证金账号" Text="" Width="200px">
                        </x:TextBox>
                        <x:NumberBox ID="num_Ratio" runat="server" Label="保证金比例" Width="200px" DecimalPrecision="2"
                            Required="true" RequiredMessage="请输入保证金比例！">
                        </x:NumberBox>
                        <x:TextBox ID="txt_RGuaranteeNo" runat="server" Label="回款保证金账号" Text="" Width="200px">
                        </x:TextBox>
                        <x:TextArea ID="txt_Remark" runat="server" Height="80px" Label="备注" Width="300px"
                            Text="">
                        </x:TextArea>
                    </Items>
                </x:SimpleForm>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
