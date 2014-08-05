<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowLinkmanInfo.aspx.cs"
    Inherits="Citic_Web.BasicInfoManagement.ShowLinkmanInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowHeader="false" ShowBorder="false"
            AutoHeight="true" Height="500px" EnableBackgroundColor="true">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" ValidateForms="SimpleForm1" runat="server"
                            Text="保存并关闭" Icon="SystemSaveNew" OnClick="btn_SaveAndClose_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Panel ID="pnl_BasicInfo" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                    EnableBackgroundColor="true" Title="基本信息">
                    <Items>
                        <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowBorder="false"
                            ShowHeader="false" EnableBackgroundColor="true" AutoScroll="true" EnableCollapse="True"
                            AutoWidth="true" LabelWidth="110px">
                            <Items>
                                <x:HiddenField ID="hidden_ID" runat="server">
                                </x:HiddenField>
                                <x:TextBox ID="txt_Name" runat="server" Label="联系人姓名" Required="true" RequiredMessage="请输入姓名"
                                    Text="" Width="200px" />
                                <x:TextBox ID="txt_Post" runat="server" Label="职位" Required="true" RequiredMessage="请输入职位"
                                    Text="" Width="200px" />
                                <x:NumberBox ID="txt_Phone" CompareType="Int" MinValue="0" runat="server" Label="手机号"
                                    Width="200px">
                                </x:NumberBox>
                                <x:TextBox ID="txt_Email" runat="server" Regex="[a-zA-Z0-9_+.-]+\@([a-zA-Z0-9-]+\.)+[a-zA-Z0-9]{2,4}"
                                    RegexMessage="请输入合法Email地址" Label="Email" Text="" Width="200px" />
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
