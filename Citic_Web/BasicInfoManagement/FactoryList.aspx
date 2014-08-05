<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FactoryList.aspx.cs" Inherits="Citic_Web.BasicInfoManagement.FactoryList" %>

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
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" Height="37px" CssStyle="padding-bottom:5px">
                    <Items>
                        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="厂商名："></x:Label>
                                <x:TextBox ID="txt_Search" runat="server" Text="" Width="300px" CssStyle="padding-left:0px;height:20px;font-size:15px"></x:TextBox>
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
                                <x:Button ID="btn_AddBank" runat="server" Text="添加" Icon="Add" Visible="false" />
                                <x:ToolbarSeparator ID="tbs_Add" runat="server" Visible="false" />
                                <x:Button ID="btn_Modify" runat="server" Text="修改" Icon="ApplicationEdit" Visible="false" OnClick="btn_Modify_Click"></x:Button>
                                <x:ToolbarSeparator ID="tbs_Modify" runat="server" Visible="false" />
                                <x:Button ID="btn_DeleteBank" runat="server" Text="删除" Icon="Delete" OnClick="btn_DeleteBank_Click" Visible="false" />
                                <x:ToolbarSeparator ID="tbs_Delete" runat="server" Visible="false" />
                                <x:Button ID="btn_ExportExcel" runat="server" Icon="PageWhiteExcel" Text="生成Excel" OnClick="btn_ExpendExcel_Click" Visible="false" />
                                <x:HyperLink ID="hl_ExportExcel" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出本页数据"></x:HyperLink>
                                <x:HyperLink ID="hl_ExportAll" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出全部数据"></x:HyperLink>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Grid ID="grid_List" runat="server" EnableCheckBoxSelect="true" EnableRowNumber="true" EnableTextSelection="true"
                            Title="厂家信息" PageSize="15" ShowBorder="false" ShowHeader="false" AllowPaging="true"
                            DataKeyNames="FactoryID,FactoryName" IsDatabasePaging="true" ClearSelectedRowsAfterPaging="false"
                            ForceFitAllTime="false" OnPageIndexChange="grid_List_PageIndexChange">
                            <Columns>
                                <x:BoundField ColumnID="FactoryName" DataField="FactoryName" DataFormatString="{0}" Width="200px"
                                    HeaderText="厂家名称" />
                                <x:BoundField ColumnID="Address" DataField="Address" DataFormatString="{0}" HeaderText="地址" Width="250px" />
                                <x:BoundField ColumnID="CreateName" DataField="CreateName" DataFormatString="{0}"
                                    HeaderText="添加人" Width="100px" />
                                <x:BoundField ColumnID="CreateTime" DataField="CreateTime" DataFormatString="{0}"
                                    HeaderText="添加时间" Width="160px" />
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
        <x:Window ID="WindowEdit" Title="修改厂家信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="825px" EnableConfirmOnClose="true" Height="600px">
        </x:Window>
        <x:Window ID="WindowAdd" Title="添加厂家" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" OnClose="Window_Close"
            IsModal="true" Width="610px" EnableConfirmOnClose="true" Height="370px">
        </x:Window>
    </form>
</body>
</html>
