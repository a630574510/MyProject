<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Citic_Web.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>质押物管理平台</title>
    <link href="Css/default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Main_Form" runat="server">
        <x:PageManager ID="PMMain" runat="server" AutoSizePanelID="RPMain" />
        <x:RegionPanel ID="RPMain" runat="server" ShowBorder="false">
            <Regions>
                <x:Region ID="RegTop" Margins="0 0 0 0" ShowBorder="false" Height="50px" ShowHeader="false"
                    Position="Top" Layout="Fit" runat="server">
                    <Items>
                        <x:ContentPanel ShowBorder="false" CssClass="jumbotron" ShowHeader="false" ID="ContentPanel1"
                            runat="server">
                            <div class="title">
                                <a href="#" title="首页" class="logo">
                                    <img src="images/logo/LOGO_zxxt.gif" alt="Citic Logo" /></a> &nbsp;<a href="#" class="A_Link">中信信通质押物管理平台</a>
                            </div>
                            <div class="version">
                                <a href="Handlers/Logout.ashx" target="_parent" class="A_Link">退出</a>
                            </div>
                        </x:ContentPanel>
                    </Items>
                </x:Region>
                <x:Region ID="RegLeft" Split="true" EnableSplitTip="true" CollapseMode="Mini" Width="200px"
                    Margins="0 0 0 0" ShowHeader="true" Title="" EnableLargeHeader="false" Icon="user"
                    EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                    <Toolbars>
                        <x:Toolbar ID="ToolTop" Position="Top" runat="server">
                            <Items>
                                <x:Label ID="lbl_UserInfo" runat="server" ShowLabel="false"></x:Label>
                                <x:ToolbarFill ID="ToolbarFill1" runat="server">
                                </x:ToolbarFill>
                                <x:Button ID="Button2" EnablePostBack="false" Icon="Cog" runat="server">
                                    <Menu ID="Menu1" runat="server">
                                        <x:MenuButton ID="btnExpandAll" IconUrl="~/images/expand-all.gif" Text="展开菜单" EnablePostBack="false"
                                            runat="server">
                                        </x:MenuButton>
                                        <x:MenuButton ID="btnCollapseAll" IconUrl="~/images/collapse-all.gif" Text="折叠菜单"
                                            EnablePostBack="false" runat="server">
                                        </x:MenuButton>
                                        <x:MenuSeparator ID="MenuSeparator1" runat="server">
                                        </x:MenuSeparator>
                                        <x:MenuButton EnablePostBack="false" Text="菜单样式" ID="MenuStyle" runat="server">
                                            <Menu ID="Menu3" runat="server">
                                                <x:MenuCheckBox Text="树菜单" ID="MenuStyleTree" Checked="true" GroupName="MenuStyle"
                                                    AutoPostBack="true" OnCheckedChanged="MenuStyle_CheckedChanged" runat="server">
                                                </x:MenuCheckBox>
                                                <x:MenuCheckBox Text="手风琴+树菜单" ID="MenuStyleAccordion" GroupName="MenuStyle" AutoPostBack="true"
                                                    OnCheckedChanged="MenuStyle_CheckedChanged" runat="server">
                                                </x:MenuCheckBox>
                                            </Menu>
                                        </x:MenuButton>
                                    </Menu>
                                </x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                </x:Region>
                <x:Region ID="mainRegion" ShowHeader="false" Layout="Fit" Margins="0 0 0 0" Position="Center"
                    runat="server">
                    <Items>
                        <x:TabStrip ID="mainTabStrip" EnableTabCloseMenu="true" ShowBorder="false" runat="server">
                            <Tabs>
                                <x:Tab Title="首页" Layout="Fit" Icon="House" runat="server">
                                    <Items>
                                        <x:ContentPanel ID="ContentPanel2" ShowBorder="false" BodyPadding="10px" ShowHeader="false" AutoScroll="true"
                                            CssClass="intro" runat="server">
                                            <h2>欢迎</h2>
                                            登陆中信信通质押物管理平台！
                                        <br />
                                            <br />
                                            <h2>平台的功能</h2>
                                            规范现有质押物监管业务的操作流程,提高现有业务操作效率及数据准确性,从而达到高速无纸化办公的目的。
                                        <br />
                                            <br />
                                            <h2>支持的浏览器</h2>
                                            IE 7.0+、Firefox 3.6+、Chrome 3.0+、Opera 10.5+、Safari 3.0+
                                        <br />
                                            <br />
                                            <h2>联系方式</h2>
                                            电话：<span id="telephone"></span>
                                            <br />
                                            传真：<span id="fax"></span>
                                            <br />
                                            地址：<span id="address"></span>
                                            <br />
                                            邮编：<span id="post"></span>
                                            <br />


                                        </x:ContentPanel>
                                    </Items>
                                </x:Tab>
                            </Tabs>
                        </x:TabStrip>
                    </Items>
                </x:Region>
            </Regions>
        </x:RegionPanel>
    </form>
    <script src="js/default.js" type="text/javascript"></script>
</body>
</html>
<script src="jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
<script type="text/javascript">
    $.get("Information.txt").success(function (content) {
        var telephone = content.substring(0, content.indexOf('\n'));
        content = content.substring(telephone.length + 1);
        var fax = content.substring(0, content.indexOf('\n'));
        content = content.substring(fax.length + 1);
        var address = content.substring(0, content.indexOf('\n'));
        content = content.substring(address.length + 1);
        var post = content.substring(address.length, content.indexOf('\n'));
        $("#telephone").html(telephone);
        $("#fax").html(fax);
        $("#address").html(address);
        $("#post").html(post);
    });
</script>
