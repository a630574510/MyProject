<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleToUser.aspx.cs" Inherits="Citic_Web.SystemSet.RoleToUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="FormToUser" runat="server">
    <x:PageManager ID="PMToUser" AutoSizePanelID="PanelToUser" runat="server" />
    <x:Panel ID="PanelToUser" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
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
                            <x:RadioButtonList ID="CBToUser" runat="server" Label="角色列表" ColumnNumber="3" ColumnVertical="true">
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
