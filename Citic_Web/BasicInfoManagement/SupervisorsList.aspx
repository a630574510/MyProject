<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupervisorsList.aspx.cs"
    Inherits="Citic_Web.BasicInfoManagement.SupervisorsList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" />
    <style type="text/css">
        .padding-bottom {
            padding-bottom: 5px;
        }

        .mright {
            margin-right: 5px;
        }

        .datecontainer .x-form-field-trigger-wrap {
            margin-right: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PmRoleList" runat="server" AutoSizePanelID="PanelMenu" />
        <x:Panel ID="PanelMenu" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            EnableLargeHeader="true" Title="条件查询" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" Height="37px" CssStyle="padding-bottom:5px">
                    <Items>
                        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="监管员姓名："></x:Label>
                                <x:TextBox ID="txt_Search" runat="server" Label="监管员姓名" Text="" Width="300px" CssStyle="padding-left:0px;height:20px;font-size:15px"></x:TextBox>
                                <x:Button ID="btn_Search" runat="server" Icon="SystemSearch" Text="查询" Visible="false" OnClick="btn_Search_Click" CssStyle="padding-left:5px"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Panel ID="Panel8" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                    runat="server">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_AddSupervisor" runat="server" Text="添加" Icon="Add" Visible="false">
                                </x:Button>
                                <x:ToolbarSeparator ID="tbs_Add" runat="server" Visible="false" />
                                <x:Button ID="btn_Modify" runat="server" Text="修改" Icon="ApplicationEdit" Visible="false" OnClick="btn_Modify_Click"></x:Button>
                                <x:ToolbarSeparator ID="tbs_Modify" runat="server" Visible="false" />
                                <x:Button ID="btn_DeleteSupervisor" runat="server" Text="删除" Icon="Delete" OnClick="btn_DeleteSupervisor_Click" Visible="false">
                                </x:Button>
                                <x:ToolbarSeparator ID="tbs_Delete" runat="server" Visible="false" />
                                <x:Button ID="btn_ExpendExcel" runat="server" Text="生成Excel" Icon="PageWhiteExcel" OnClick="btn_ExpendExcel_Click" Visible="false">
                                </x:Button>
                                <x:HyperLink ID="hl_ExportExcel" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出本页数据"></x:HyperLink>
                                <x:HyperLink ID="hl_ExportAll" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出全部数据"></x:HyperLink>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Grid ID="grid_List" runat="server" EnableCheckBoxSelect="true" EnableRowNumber="true"
                            Title="监管员信息" PageSize="15" ShowBorder="false" ShowHeader="false" AllowPaging="true" EnableTextSelection="true"
                            DataKeyNames="SupervisorID,SupervisorName" IsDatabasePaging="true" ClearSelectedRowsAfterPaging="false"
                            ForceFitAllTime="false" OnPageIndexChange="grid_SupervisorsList_PageIndexChange" OnRowDataBound="grid_SupervisorsList_RowDataBound"
                            OnRowCommand="grid_SupervisorsList_RowCommand">
                            <Columns>
                                <x:BoundField ColumnID="SupervisorName" DataField="SupervisorName" DataFormatString="{0}"
                                    HeaderText="监管员姓名" Width="100px" />
                                <x:BoundField ColumnID="Gender" DataField="Gender" DataFormatString="{0}" HeaderText="性别" Width="50px" />
                                <x:BoundField ColumnID="Age" DataField="Age" DataFormatString="{0}" HeaderText="年龄" Width="50px" />
                                <x:BoundField ColumnID="Education" DataField="Education" DataFormatString="{0}"
                                    HeaderText="学历" Width="50px" />
                                <x:BoundField ColumnID="LinkPhone" DataField="LinkPhone" DataFormatString="{0}"
                                    HeaderText="联系电话" Width="100px" />
                                <x:BoundField ColumnID="WorkSource" DataField="WorkSource" DataFormatString="{0}"
                                    HeaderText="工作来源" Width="100px" />
                                <x:BoundField ColumnID="QQ" DataField="QQ" DataFormatString="{0}" HeaderText="QQ" Width="100px" />
                                <x:BoundField ColumnID="EntryTime" DataField="EntryTime" DataFormatString="{0}"
                                    HeaderText="入职时间" Width="150px" />
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
        <x:Window ID="WindowEditSupervisor" Title="修改监管员信息" Popup="false" EnableIFrame="true"
            IFrameUrl="about:blank" EnableMaximize="true" Target="Top" EnableResize="true"
            runat="server" OnClose="Window_Close" IsModal="true" Width="500px" EnableConfirmOnClose="true"
            Height="600px">
        </x:Window>
        <x:Window ID="WindowAdd" Title="添加监管员" Popup="false" EnableIFrame="true"
            IFrameUrl="about:blank" EnableMaximize="true" Target="Top" EnableResize="true"
            runat="server" OnClose="Window_Close" IsModal="true" Width="500px" EnableConfirmOnClose="true"
            Height="570px">
        </x:Window>
    </form>
</body>
</html>
