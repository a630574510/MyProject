<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLinkman.aspx.cs" Inherits="Citic_Web.BasicInfoManagement.AddLinkman" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel3" />
        <x:Panel ID="Panel3" runat="server" CssStyle="margin:10 10 10 10" ShowBorder="true" ShowHeader="true"
            EnableBackgroundColor="true" Title="联系人信息" BodyPadding="5px">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" runat="server" Text="保存并关闭" Icon="SystemSaveNew"
                            OnClick="btn_SaveAndClose_Click" ValidateForms="SimpleForm2">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" ShowBorder="false"
                    ShowHeader="false" EnableBackgroundColor="true" AutoScroll="true" EnableCollapse="True"
                    AutoWidth="true">
                    <Items>
                        <x:TextBox ID="txt_LinkmanName" runat="server" Label="联系人姓名" Required="true" RequiredMessage="请输入联系人姓名" Text="" Width="300px" />
                        <x:TextBox ID="txt_Post" runat="server" Label="职位" Text="" Width="300px" />
                        <x:NumberBox ID="num_Phone" runat="server" Label="联系人电话" Text="" Width="300px" MinValue="0"></x:NumberBox>
                        <x:TextBox ID="txt_Email" runat="server" Width="300px" Label="Email" Text="" Regex="[a-zA-Z0-9_+.-]+\@([a-zA-Z0-9-]+\.)+[a-zA-Z0-9]{2,4}" />
                    </Items>
                </x:SimpleForm>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
