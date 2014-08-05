<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMenu.aspx.cs" Inherits="Citic_Web.SystemSet.AddMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="FormAddMenu" runat="server">
    <x:PageManager ID="PMAddMenu" AutoSizePanelID="Panel1" runat="server" />
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
                            <x:TextBox ID="txtMenuName" runat="server" Label="模块名" Text="">
                            </x:TextBox>
                            <x:TextBox ID="txtMenuUrl" runat="server" Label="链接" Text="" >
                            </x:TextBox>
                            <x:DropDownList ID="ddlParentMenu" runat="server" Label="父级菜单" Width="150px">
                            </x:DropDownList>
                            <x:RadioButtonList ID="rbIsNavigation" Label="是否为菜单" runat="server" Width="100px">
                                <x:RadioItem Text="是" Value="True" />
                                <x:RadioItem Text="否" Value="False" Selected="true" />
                            </x:RadioButtonList>
                            <x:NumberBox ID="NbMenuOrder" runat="server" Label="菜单序号" NoDecimal="true" NoNegative="true" >
                            </x:NumberBox>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
