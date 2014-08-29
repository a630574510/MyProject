<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="Citic_Web.SystemSet.EditUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="FormEditUser" runat="server">
    <x:PageManager ID="PMEditUser" AutoSizePanelID="Panel1" runat="server" />
    <x:Panel ID="Panel1" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
        BodyPadding="5px" EnableBackgroundColor="true">
        <Toolbars>
            <x:Toolbar ID="Toolbar1" runat="server">
                <Items>
                    <x:Button ID="btnSaveRefresh" Text="保存并关闭" runat="server" Icon="SystemSaveNew"
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
                            <x:Label ID="lblUserName" Label="用户名" Text="" runat="server" />
                            <x:TextBox ID="txtPassword" runat="server" Label="密码" Text="" TextMode="Password">
                            </x:TextBox>
                             <x:TextBox ID="txtUPassword" runat="server" Label="确认密码" Text="" TextMode="Password">
                            </x:TextBox>
                            <x:TextBox ID="txtTrueName" runat="server" Label="真实姓名" Text="">
                            </x:TextBox>
                            <x:DropDownList ID="ddlDept" runat="server" Label="部门">
                            </x:DropDownList>
                            <x:TextBox ID="txtEmail" runat="server" Label="Email" Text="">
                            </x:TextBox>
                            <x:TextBox ID="txtMobileNo" runat="server" Label="手机" Text="">
                            </x:TextBox>
                            <x:RadioButtonList ID="rbUserType" Label="状态" runat="server">
                                <x:RadioItem Text="启用" Value="1" />
                                <x:RadioItem Text="停用" Value="0" Selected="false" />
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
