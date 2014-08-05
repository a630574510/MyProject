<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBank.aspx.cs" Inherits="Citic_Web.BasicInfoManagement.AddBank" %>

<%@ Register Src="~/UserControls/WUC_Address.ascx" TagPrefix="uc1" TagName="WUC_Address" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1123" runat="server" BodyPadding="5px" EnableBackgroundColor="true"
            ShowBorder="false" ShowHeader="false" Title="Panel">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" runat="server" Text="保存并关闭" Icon="SystemSaveNew"
                            OnClick="btn_SaveAndClose_Click" ValidateForms="SimpleForm1">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                    EnableBackgroundColor="true" Title="基本信息">
                    <Items>
                        <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowBorder="false"
                            ShowHeader="false" EnableBackgroundColor="true" AutoScroll="true" EnableCollapse="True"
                            AutoWidth="true">
                            <Items>
                                <x:TextBox ID="txt_Name" runat="server" Label="合作行名称" Text="" Width="300px" Required="true"
                                    RequiredMessage="请填写合作行名称" />
                                <x:RadioButtonList ID="rbl_BankType" Label="合作行级别" runat="server" Width="200px" OnSelectedIndexChanged="rbl_BankType_onSelectedIndexChanged"
                                    AutoPostBack="true">
                                    <x:RadioItem Value="0" Text="总行" Selected="true" />
                                    <x:RadioItem Value="1" Text="分行" />
                                    <x:RadioItem Value="2" Text="支行" />
                                </x:RadioButtonList>
                                <x:DropDownList ID="ddl_ParentBank" runat="server" Width="150px" Label="归属行名称" CompareType="String" CompareValue="0" CompareOperator="NotEqual" CompareMessage="请选择上级银行！">
                                    <x:ListItem Text="请选择" Value="0" />
                                </x:DropDownList>

                                <x:UserControlConnector runat="server">
                                    <uc1:WUC_Address runat="server" ID="WUC_Address" Province="-1" City="-1" Address="" />
                                </x:UserControlConnector>
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
                <x:Label runat="server">
                </x:Label>
                <x:Label runat="server">
                </x:Label>
                <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                    EnableBackgroundColor="true" Title="联系人信息">
                    <Items>
                        <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" ShowBorder="false"
                            ShowHeader="false" EnableBackgroundColor="true" AutoScroll="true" EnableCollapse="True"
                            AutoWidth="true">
                            <Items>
                                <x:TextBox ID="txt_LinkmanName" runat="server" Label="联系人姓名" Text="" Width="300px" />
                                <x:TextBox ID="txt_Post" runat="server" Label="职位" Text="" Width="300px" />
                                <x:NumberBox ID="num_Phone" runat="server" Label="联系人电话" Text="" Width="300px" />
                                <x:TextBox ID="txt_Email" runat="server" Width="300px" Label="Email" Text="" Regex="[a-zA-Z0-9_+.-]+\@([a-zA-Z0-9-]+\.)+[a-zA-Z0-9]{2,4}" />
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
