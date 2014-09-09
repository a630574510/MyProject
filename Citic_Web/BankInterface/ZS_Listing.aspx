<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZS_Listing.aspx.cs" Inherits="Citic_Web.BankInterface.ZS_Listing" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" AutoSizePanelID="RegionPanel1" runat="server"></x:PageManager>
    <x:RegionPanel ID="RegionPanel1" ShowBorder="false" runat="server">
        <Regions>
            <x:Region ID="Region2" Split="true" Width="200px" Margins="0 0 0 0" ShowHeader="false"
                Title="目录" EnableCollapse="true" Layout="Fit" Position="Left" runat="server">
                <Items>
                    <x:Accordion ID="Accordion1" runat="server" ShowBorder="false" ShowHeader="false"
                        ShowCollapseTool="true">
                        <Panes>
                            <x:AccordionPane ID="AccordionPane1" runat="server" Title="查询列表" IconUrl="~/images/16/1.png"
                                BodyPadding="2px 5px" Layout="Fit" ShowBorder="false">
                                <Items>
                                    <x:Tree runat="server" EnableArrows="true" ShowBorder="false" ShowHeader="false"
                                        AutoScroll="true" ID="treeMenu">
                                        <Nodes>
                                            <x:TreeNode Target="ZS_main" Text="客户信息查询" NavigateUrl="~/BankInterface/ZSList/ZS_gyl001.aspx">
                                            </x:TreeNode>
                                            <x:TreeNode Target="ZS_main" Text="票据信息查询" NavigateUrl="~/BankInterface/ZSList/ZS_gyl025.aspx">
                                            </x:TreeNode>
                                            <x:TreeNode Target="ZS_main" Text="通知书列表查询" NavigateUrl="~/BankInterface/ZSList/ZS_gyl002.aspx">
                                            </x:TreeNode>
                                            <x:TreeNode Target="ZS_main" Text="通知书回执" NavigateUrl="~/BankInterface/ZSList/ZS_gyl003.aspx">
                                            </x:TreeNode>
                                            <x:TreeNode Target="ZS_main" Text="监管协议查询" NavigateUrl="~/BankInterface/ZSList/ZS_gyl004aspx">
                                            </x:TreeNode>
                                            <x:TreeNode Target="ZS_main" Text="质押合同信息查询" NavigateUrl="~/BankInterface/ZSList/ZS_gyl005.aspx">
                                            </x:TreeNode>
                                            <x:TreeNode Target="ZS_main" Text="申请信息查询" NavigateUrl="~/BankInterface/ZSList/ZS_gyl006.aspx">
                                            </x:TreeNode>
                                            <x:TreeNode Target="ZS_main" Text="申请信息明细查询" NavigateUrl="~/BankInterface/ZSList/ZS_gyl007.aspx">
                                            </x:TreeNode>
                                            <x:TreeNode Target="ZS_main" Text="借据信息查询" NavigateUrl="~/BankInterface/ZSList/ZS_gyl022.aspx">
                                            </x:TreeNode>
                                            <x:TreeNode Target="ZS_main" Text="可提货金额查询" NavigateUrl="~/BankInterface/ZSList/ZS_gyl018.aspx">
                                            </x:TreeNode>
                                        </Nodes>
                                    </x:Tree>
                                </Items>
                            </x:AccordionPane>
                            <%--                            <x:AccordionPane ID="AccordionPane2" runat="server" Title="面板二" IconUrl="~/images/16/4.png"
                                BodyPadding="2px 5px" ShowBorder="false">
                                <Items>
                                    <x:Label ID="Label1" Text="面板二中的文本" runat="server">
                                    </x:Label>
                                </Items>
                            </x:AccordionPane>--%>
                        </Panes>
                    </x:Accordion>
                </Items>
            </x:Region>
            <x:Region ID="Region3" ShowHeader="false" EnableIFrame="true" IFrameUrl="~/BankInterface/ZSList/ZS_gyl001.aspx"
                IFrameName="ZS_main" Margins="0 0 0 0" Position="Center" runat="server">
            </x:Region>
        </Regions>
    </x:RegionPanel>
    </form>
</body>
</html>
