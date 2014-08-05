<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="Citic_Web.SystemSet.UserList" %>

<!DOCTYPE>
<html>
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="FormUserList" runat="server">
        <x:PageManager ID="PmUserList" runat="server" AutoSizePanelID="PanelUser" />
        <x:Panel ID="PanelUser" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            EnableLargeHeader="true" Title="条件查询" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="sf_SearchInfo" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" CssStyle="padding-bottom:5px">
                    <Items>
                        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="用户名：" CssStyle="padding-right:12px"></x:Label>
                                <x:TextBox ID="txt_UserName" runat="server" Text="" Width="200px" CssStyle="font-size:15px"></x:TextBox>
                                <x:Label ID="Label2" runat="server" Text="真实姓名：" CssStyle="padding-left:10px"></x:Label>
                                <x:TextBox ID="txt_TrueName" runat="server" Text="" Width="200px" CssStyle="font-size:15px"></x:TextBox>
                                <x:Label ID="Label3" runat="server" Text="角色：" CssStyle="padding-left:10px"></x:Label>
                                <x:DropDownList ID="ddl_Role" runat="server" Width="200px" CssStyle="font-size:15px"></x:DropDownList>
                            </Items>
                        </x:Panel>
                        <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label4" runat="server" Text="是否停用："></x:Label>
                                <x:DropDownList ID="ddl_Type" Width="100px" runat="server" CssStyle="font-size:15px">
                                    <x:ListItem Text="请选择" Value="-1" />
                                    <x:ListItem Text="已启用" Value="1" />
                                    <x:ListItem Text="已停用" Value="0" />
                                </x:DropDownList>

                                <x:Button ID="btn_Search" runat="server" Text="查询" Icon="SystemSearch" CssStyle="padding-left:10px" OnClick="btn_Search_Click"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Panel ID="Panel8" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                    runat="server">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar2" runat="server">
                            <Items>
                                <x:Button ID="btnAddUser" Text="添加" runat="server" Icon="add" Visible="false">
                                </x:Button>
                                <x:ToolbarSeparator ID="tbs_Add" runat="server" Visible="false">
                                </x:ToolbarSeparator>
                                <x:Button ID="btn_Modify" runat="server" Text="修改" Icon="BulletEdit" OnClick="btn_Modify_Click" Visible="false"></x:Button>
                                <x:ToolbarSeparator ID="tbs_Modify" runat="server" Visible="false">
                                </x:ToolbarSeparator>
                                <x:Button ID="btnDeleteUser" Text="删除" runat="server" Icon="delete" OnClick="btnDeleteUser_Click" Visible="false">
                                </x:Button>
                                <x:ToolbarSeparator ID="tbs_Delete" runat="server" Visible="false">
                                </x:ToolbarSeparator>
                                <x:Button ID="btn_ToRole" runat="server" Text="分配角色" Icon="Build" OnClick="btn_ToRole_Click" Visible="false"></x:Button>
                                <x:ToolbarSeparator ID="tbs_ToRole" runat="server" Visible="false">
                                </x:ToolbarSeparator>
                                <x:Button ID="btn_ToBank" runat="server" Text="分配银行" Icon="Build" OnClick="btn_ToBank_Click" Visible="false"></x:Button>
                                <x:ToolbarSeparator ID="tbs_ToBank" runat="server" Visible="false">
                                </x:ToolbarSeparator>
                                <x:Button ID="btnExport" EnableAjax="false" DisableControlBeforePostBack="false" Visible="false"
                                    runat="server" Text="导出" OnClick="btnExport_Click" Icon="diskdownload">
                                </x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Grid ID="GvUser" Title="用户信息" PageSize="15" ShowBorder="false" ShowHeader="false"
                            AllowPaging="true" runat="server" EnableCheckBoxSelect="True" EnableTextSelection="true"
                            DataKeyNames="UserId,UserName,RoleId" IsDatabasePaging="true" OnPageIndexChange="GvUser_PageIndexChange"
                            EnableRowNumber="True" ClearSelectedRowsAfterPaging="false">
                            <Columns>
                                <x:BoundField DataField="UserName" DataFormatString="{0}" HeaderText="用户名" Width="100px" />
                                <x:BoundField DataField="TrueName" HeaderText="姓名" Width="100px" />
                                <x:BoundField DataField="DName" HeaderText="部门" Width="100px" />
                                <x:BoundField DataField="Email" HeaderText="Email" Width="200px" />
                                <x:BoundField DataField="MobileNo" HeaderText="手机" Width="100px" />
                                <x:BoundField DataField="RoleName" HeaderText="角色" Width="100px" />
                                <x:CheckBoxField RenderAsStaticField="true" DataField="UserType" HeaderText="状态" Width="50px" />
                                <x:BoundField DataField="CreateTime" HeaderText="注册时间" Width="150px" />
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
        <x:Window ID="WindowEdit" Title="修改用户信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="false" runat="server" OnClose="Window_Close"
            IsModal="true" Width="500px" EnableConfirmOnClose="true" Height="500px">
        </x:Window>
        <x:Window ID="WindowToRole" Title="分配角色" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="500px" EnableConfirmOnClose="true" Height="500px">
        </x:Window>
        <x:Window ID="WIndowToBank" Title="分配银行" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="650px" EnableConfirmOnClose="true" Height="600px">
        </x:Window>
        <x:Window ID="WindowAddUser" Title="添加用户" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="false" runat="server" OnClose="Window_Close"
            IsModal="true" Width="400px" EnableConfirmOnClose="true" Height="450px">
        </x:Window>
    </form>
</body>
</html>
