<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DealerList.aspx.cs" Inherits="Citic_Web.DealerManagement.DealerInfo.DealerList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PmRoleList" runat="server" AutoSizePanelID="PanelMenu" />
        <x:Panel ID="PanelMenu" runat="server" EnableBackgroundColor="true" BodyPadding="3px"
            EnableLargeHeader="true" Title="条件查询" ShowBorder="false" ShowHeader="True" Layout="VBox"
            BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" Height="65px" CssStyle="padding-bottom:5px">
                    <Items>
                        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="经销商名："></x:Label>
                                <x:TextBox ID="txt_DealerName" runat="server" Text="" Width="303px" CssStyle="padding-left:0px;height:20px;font-size:15px"></x:TextBox>
                                <x:Label ID="Label2" runat="server" Text="业务模式：" CssStyle="padding-left:20px"></x:Label>
                                <x:DropDownList ID="ddl_BusinessMode" runat="server" Width="180px"></x:DropDownList>
                                <x:Label ID="Label3" runat="server" Text="融资模式：" CssStyle="padding-left:20px"></x:Label>
                                <x:DropDownList ID="ddl_FinancingMode" runat="server" Label="融资模式" Width="180px"></x:DropDownList>
                            </Items>
                        </x:Panel>
                        <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label4" runat="server" Text="合作行：" CssStyle="padding-right:12px"></x:Label>
                                <x:DropDownList ID="ddl_Bank" runat="server" Width="300px"></x:DropDownList>
                                <x:Label ID="Label5" runat="server" Text="品&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;牌：" CssStyle="padding-left:21px"></x:Label>
                                <x:TextBox ID="txt_Brand" runat="server" Label="品牌" Width="185px" CssStyle="height:20px;font-size:15px"></x:TextBox>
                                <x:Button ID="btn_Search" runat="server" Text="查询" Visible="false" OnClick="btn_Search_Click" Icon="SystemSearch" CssStyle="padding-left:20px"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Panel ID="Panel8" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                    runat="server">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_Add" runat="server" Text="添加经销商" Icon="Add" Visible="false">
                                </x:Button>
                                <x:ToolbarSeparator ID="tbs_Modify" runat="server" Visible="false" />
                                <x:Button ID="btn_Modify" runat="server" Text="修改" Icon="ApplicationEdit" Visible="false" OnClick="btn_Modify_Click"></x:Button>
                                <x:ToolbarSeparator ID="tbs_Delete" runat="server" Visible="false" />
                                <x:Button ID="btn_Deletes" runat="server" Text="批量删除" Icon="Delete" OnClick="btn_Deletes_Click" Visible="false">
                                </x:Button>
                                <x:ToolbarSeparator ID="tbs_Match" runat="server" Visible="false" />
                                <x:Button ID="btn_Match" runat="server" Text="匹配监管员" Icon="Build" OnClick="btn_Match_Click" Visible="false">
                                </x:Button>
                                <x:ToolbarFill runat="server"></x:ToolbarFill>
                                <x:Button ID="btn_ExportExcel" runat="server" Text="生成Excel" Icon="PageWhiteExcel" OnClick="btn_ExportExcel_Click" Visible="false">
                                </x:Button>
                                <x:HyperLink ID="hl_ExportExcel" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出本页数据"></x:HyperLink>
                                <x:ToolbarSeparator ID="bl_Separator" runat="server" Visible="false" />
                                <x:HyperLink ID="hl_ExportAll" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出全部数据"></x:HyperLink>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Grid ID="grid_List" PageSize="15" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                            runat="server" EnableCheckBoxSelect="True" DataKeyNames="DealerID,DealerName"
                            IsDatabasePaging="true" OnPageIndexChange="grid_List_PageIndexChange" EnableRowNumber="True"
                            ClearSelectedRowsAfterPaging="false" EnableTextSelection="true"
                            OnRowCommand="grid_List_RowCommand" OnRowDataBound="grid_List_RowDataBound">
                            <Columns>
                                <x:BoundField DataField="DealerName" DataFormatString="{0}" HeaderText="企业名称" Width="290px" />
                                <x:BoundField DataField="DealerType" DataFormatString="{0}" HeaderText="企业属性" Width="80px" />
                                <x:BoundField DataField="IsGroup" DataFormatString="{0}" HeaderText="是否是集团性质" Width="100px" />
                                <x:BoundField DataField="HasOtherIndustries" DataFormatString="{0}" HeaderText="是否有其他产业" Width="100px" />
                                <x:BoundField DataField="Address" DataFormatString="{0}" HeaderText="地址" Width="240px" />
                                <x:LinkButtonField HeaderText="监管员" DataTextField="SupervisorName" CommandName="sd" />
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
        <x:Window ID="WindowEdit" Title="修改模块信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            Target="Top" runat="server" OnClose="Window_Close" IsModal="true" Width="1250px" Height="642px"
            EnableConfirmOnClose="true" EnableMaximize="false" EnableClose="true"
            EnableMinimize="false" EnableResize="false">
        </x:Window>
        <x:Window ID="WindowAdd" Title="添加经销商" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            Target="Top" runat="server" OnClose="Window_Close" IsModal="true" Width="1250px" Height="642px"
            EnableConfirmOnClose="true" EnableMaximize="false" EnableClose="true"
            EnableMinimize="false" EnableResize="false" CloseAction="HidePostBack">
        </x:Window>
        <x:Window ID="W_SupervisorHistory" Title="监管员历史信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            Target="Top" runat="server" IsModal="true" Width="1000px" Height="600px"
            EnableConfirmOnClose="true" EnableMaximize="false" EnableClose="true"
            EnableMinimize="false" EnableResize="false">
        </x:Window>
        <x:Window ID="W_Match" Title="给经销商匹配监管员" Popup="false" EnableIFrame="true"
            Target="Top" runat="server" IsModal="true" Width="600px" Height="600px"
            EnableConfirmOnClose="true" EnableMaximize="false" EnableClose="true"
            EnableMinimize="false" EnableResize="false">
        </x:Window>
    </form>
</body>
</html>
