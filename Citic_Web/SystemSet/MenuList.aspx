<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="Citic_Web.SystemSet.MenuList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="FormMenuList" runat="server">
        <x:PageManager ID="PmRoleList" runat="server" AutoSizePanelID="PanelMenu" />
        <x:Panel ID="PanelMenu" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            EnableLargeHeader="true" Title="条件查询" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                <x:Form ID="FormSelect" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                    ShowHeader="False" runat="server">
                    <Rows>
                        <x:FormRow ID="FormRow1" runat="server">
                            <Items>
                                <x:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词，什么都不写默认显示全部信息" ShowLabel="false" ID="tbxMyBox1"
                                    ShowTrigger1="false" Trigger1Icon="Clear" Trigger2Icon="Search"
                                    OnTrigger1Click="ttbxMyBox1_Trigger1Click" OnTrigger2Click="ttbxMyBox1_Trigger2Click">
                                </x:TwinTriggerBox>

                            </Items>
                        </x:FormRow>
                    </Rows>
                </x:Form>
                <x:Panel ID="Panel8" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                    runat="server">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <x:Button ID="btnAddMenu" Text="添加" runat="server" Icon="add">
                                </x:Button>
                                <x:ToolbarSeparator ID="tbs_Add" runat="server"  Visible="true">
                                </x:ToolbarSeparator>
                                <x:Button ID="btnDeleteMenu" Text="删除" runat="server" Icon="delete" OnClick="btnDeleteMenu_Click">
                                </x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Grid ID="GvMenu" Title="模块信息" PageSize="15" ShowBorder="false" ShowHeader="false"
                            AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                            DataKeyNames="MenuId,MenuName" IsDatabasePaging="true" EnableTextSelection="true"
                            OnPageIndexChange="GvMenu_PageIndexChange" EnableRowNumber="True" ClearSelectedRowsAfterPaging="false" ForceFitAllTime="true">
                            <Columns>
                                <x:BoundField DataField="MenuName" DataFormatString="{0}" HeaderText="模块名" />
                                <x:BoundField DataField="MenuUrl" HeaderText="Url" />
                                <x:BoundField DataField="ParentName" HeaderText="父级模块" />
                                <x:CheckBoxField RenderAsStaticField="true" DataField="IsNavigation" HeaderText="是否为菜单" />
                                <x:BoundField DataField="MenuOrder" HeaderText="序号" />
                                <x:WindowField TextAlign="Left" Width="100px" WindowID="WindowEditMenu" Icon="Pencil"
                                    ToolTip="编辑" DataIFrameUrlFields="MenuId,MenuName" DataIFrameUrlFormatString="../SystemSet/EditMenu.aspx?MenuId={0}&MenuName={1}"
                                    Title="修改模块信息" IFrameUrl="~/alert.aspx" HeaderText="编辑" />
                            </Columns>
                            <PageItems>
                                <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </x:ToolbarSeparator>
                                <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                                </x:ToolbarText>
                                <x:DropDownList runat="server" ID="ddlPageSize" Width="40px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                    <x:ListItem Text="5" Value="5" />
                                    <x:ListItem Text="10" Value="10" Selected="true" />
                                    <x:ListItem Text="15" Value="15" />
                                    <x:ListItem Text="20" Value="20" />
                                </x:DropDownList>
                            </PageItems>
                        </x:Grid>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
        <x:Window ID="WindowEditMenu" Title="修改模块信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="500px" EnableConfirmOnClose="true" Height="500px">
        </x:Window>
        <x:Window ID="WindowAddMenu" Title="添加模块" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="500px" EnableConfirmOnClose="true" Height="250px">
        </x:Window>
    </form>
</body>
</html>
