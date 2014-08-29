<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeptToRole.aspx.cs" Inherits="Citic_Web.SystemSet.DeptToRole" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" EnableBackgroundColor="true" Title="给部门分配角色">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" runat="server" Text="保存并关闭页面" Icon="SystemSaveClose" OnClick="btn_SaveAndClose_Click"></x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:CheckBoxList ID="cbl_Roles" runat="server"></x:CheckBoxList>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
