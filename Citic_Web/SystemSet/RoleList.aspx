<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="Citic_Web.SystemSet.RoleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="FormRoleList" runat="server">
        <x:PageManager ID="PmRoleList" runat="server" AutoSizePanelID="PanelRole" />
        <x:Panel ID="PanelRole" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            EnableLargeHeader="true" Title="条件查询" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                <x:Form ID="FormSelect" ShowBorder="False" BodyPadding="5px" EnableBackgroundColor="true"
                    ShowHeader="False" runat="server">
                    <Rows>
                        <x:FormRow ID="FormRow1" runat="server">
                            <Items>
                                <x:TwinTriggerBox runat="server" EmptyText="输入要搜索的关键词" ShowLabel="false" ID="ttbSearch"
                                    ShowTrigger1="false"
                                    Trigger1Icon="Clear" Trigger2Icon="Search"
                                    EnableTrigger2PostBack="true" OnTrigger2Click="ttbSearch_Trigger2Click"
                                    EnableTrigger1PostBack="true" OnTrigger1Click="ttbSearch_Trigger1Click">
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
                                <x:Button ID="btnAddRole" Text="添加" runat="server" Icon="add" Visible="false">
                                </x:Button>
                                <x:ToolbarSeparator ID="tbs_Add" runat="server" Visible="false">
                                </x:ToolbarSeparator>
                                <x:Button ID="btn_Modify" runat="server" Text="修改" Icon="BulletEdit" OnClick="btn_Modify_Click" Visible="false"></x:Button>
                                <x:ToolbarSeparator ID="tbs_Modify" runat="server" Visible="false">
                                </x:ToolbarSeparator>
                                <x:Button ID="btnDeleteRole" Text="删除" runat="server" Icon="delete" Visible="false" OnClick="btnDeleteRole_Click">
                                </x:Button>
                                <x:ToolbarSeparator ID="tbs_Delete" runat="server" Visible="false">
                                </x:ToolbarSeparator>
                                <x:Button ID="btn_ToMenu" runat="server" Text="分配权限" Icon="Build" Visible="false" OnClick="btn_ToMenu_Click"></x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Grid ID="GvRole" Title="角色信息" PageSize="15" ShowBorder="false" ShowHeader="false"
                            AllowPaging="true" runat="server" EnableCheckBoxSelect="True"
                            DataKeyNames="RoleId,RoleName" IsDatabasePaging="true"
                            OnPageIndexChange="GvRole_PageIndexChange" EnableRowNumber="True" ClearSelectedRowsAfterPaging="false" ForceFitAllTime="true">
                            <Columns>
                                <x:BoundField DataField="RoleName" DataFormatString="{0}" HeaderText="角色名" />
                                <x:BoundField DataField="RoleDesc" HeaderText="角色描述" />
                                <x:WindowField TextAlign="Center" Width="60px" WindowID="WindowEditRole" Icon="Pencil"
                                    ToolTip="编辑" DataIFrameUrlFields="RoleId,RoleName" DataIFrameUrlFormatString="../SystemSet/EditRole.aspx?RoleId={0}&RoleName={1}"
                                    Title="修改角色信息" IFrameUrl="~/alert.aspx" HeaderText="编辑" />
                                <x:WindowField TextAlign="Center" Width="60px" WindowID="WindowMenuToRole" Icon="Build"
                                    ToolTip="分配权限" DataIFrameUrlFields="RoleId,RoleName" DataIFrameUrlFormatString="../SystemSet/MenuToRole.aspx?RoleId={0}&RoleName={1}"
                                    Title="分配权限" IFrameUrl="~/alert.aspx" HeaderText="操作" />
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
        <x:Window ID="WindowEditRole" Title="修改角色信息信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="500px" EnableConfirmOnClose="true" Height="250px">
        </x:Window>
        <x:Window ID="WindowAddRole" Title="添加角色" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="500px" EnableConfirmOnClose="true" Height="250px">
        </x:Window>
        <x:Window ID="WindowMenuToRole" Title="分配权限" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="500px" EnableConfirmOnClose="true" Height="500px">
        </x:Window>
    </form>
</body>
</html>
