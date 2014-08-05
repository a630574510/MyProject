<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="Citic_Web.SystemSet.AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="FormAddUser" runat="server">
        <x:PageManager ID="PMAddUser" AutoSizePanelID="Panel1" runat="server" />
        <x:Panel ID="Panel1" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
            BodyPadding="5px" EnableBackgroundColor="true">
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
                <x:Panel ID="Panel2" Layout="Fit" runat="server" ShowBorder="false" ShowHeader="false">
                    <Items>
                        <x:SimpleForm ID="SimpleForm1" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            AutoScroll="true" BodyPadding="5px" runat="server" EnableCollapse="True">
                            <Items>
                                <x:TextBox ID="txtUserName" runat="server" Label="用户名" Text="" Width="200px" Required="true" RequiredMessage="请填写用户名！">
                                </x:TextBox>
                                <x:TextBox ID="txtPassword" runat="server" Label="密码" Text="" TextMode="Password" Width="200px" Required="true" RequiredMessage="请填写密码！">
                                </x:TextBox>
                                <x:TextBox ID="txtUPassword" runat="server" Label="确认密码" Text="" TextMode="Password" Width="200px" Required="true"
                                    CompareControl="txtPassword" CompareType="String" CompareOperator="Equal" CompareMessage="两次密码输入不一致！">
                                </x:TextBox>
                                <x:TextBox ID="txtTrueName" runat="server" Label="真实姓名" Text="" Width="200px">
                                </x:TextBox>
                                <x:DropDownList ID="ddlDept" runat="server" Label="部门" Width="200px" Required="true" RequiredMessage="请选择部门！" CompareValue="-1" CompareOperator="NotEqual" CompareType="String" CompareMessage="请选择部门！"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlDept_SelectedIndexChanged">
                                </x:DropDownList>
                                <x:DropDownList ID="ddl_Role" runat="server" Label="角色" Width="200px" Required="true" RequiredMessage="请选择角色！" CompareValue="-1" CompareOperator="NotEqual" CompareType="String">
                                </x:DropDownList>
                                <x:TextBox ID="txtEmail" runat="server" Label="Email" Text="" Width="200px">
                                </x:TextBox>
                                <x:TextBox ID="txtMobileNo" runat="server" Label="手机" Text="" Width="200px">
                                </x:TextBox>
                                <x:RadioButtonList ID="rbUserType" Label="状态" runat="server" Width="100px">
                                    <x:RadioItem Text="启用" Value="1" />
                                    <x:RadioItem Text="停用" Value="0" Selected="true" />
                                </x:RadioButtonList>
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>

    </form>
</body>
</html>
