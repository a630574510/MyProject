<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuToRole.aspx.cs" Inherits="Citic_Web.SystemSet.MenuToRole1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PMToRole" AutoSizePanelID="PanelToRole" runat="server" />
        <x:Panel ID="PanelToRole" runat="server" Layout="Fit" ShowBorder="False" ShowHeader="false"
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
                                <x:Tree ID="Tree1" runat="server" AutoScroll="true" EnableArrows="true" ShowHeader="false"
                                    OnNodeCheck="Tree1_NodeCheck">
                                </x:Tree>
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>

    </form>
</body>
</html>
