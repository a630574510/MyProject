<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GD_Q412.aspx.cs" Inherits="Citic_Web.BankInterface.GD_Q412" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="VBox" BoxConfigAlign="Stretch" EnableBackgroundColor="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="true"
                Title="光大汇票信息" EnableBackgroundColor="true">
                <Items>
                    <x:SimpleForm ID="SimpleForm" runat="server" BodyPadding="5px" Title="查询汇票条件" EnableBackgroundColor="true">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button runat="server" Text="提交" ID="Btn_Add_Search" Icon="Tick" IconAlign="Right"
                                        OnClick="Btn_Add_Search_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Items>
                            <x:DropDownList ID="DDL_Dealer" runat="server" Label="经销商" Width="250px" Required="true"
                                Resizable="true">
                            </x:DropDownList>
                            <x:DatePicker runat="server" Label="开票日期" EmptyText="请选择开票日期" ID="DatePicker1" Width="250px">
                            </x:DatePicker>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                Title="查询结果" Layout="Fit" BoxConfigAlign="Stretch" BoxFlex="1" EnableBackgroundColor="true">
                <Toolbars>
                    <x:Toolbar ID="Toolbar2" runat="server">
                        <Items>
                            <x:Button ID="Btn_Search" runat="server" Text="查询" Icon="SystemSearch" OnClick="Btn_Search_Click"
                                ToolTip="<span style='color:Red'>查询当前用户今天提交信息</span>" ToolTipType="Qtip">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="G_DealerName" runat="server" Title="详细信息" ShowBorder="true" ShowHeader="false"
                        EnableTextSelection="true">
                        <Columns>
                            <x:BoundField HeaderText="客户名称" Width="200px" DataField="CUST_NAME" TextAlign="Center" />
                            <x:WindowField WindowID="W_ShowSCF" HeaderText="开票日期" DataTextField="BNFO_ISSUE_DT_START"
                                ToolTip="详细信息" DataIFrameUrlFields="id" DataIFrameUrlFormatString="ZX_ShowSCF.aspx?id={0}&type=Q412&clss=GD" />
                            <x:BoundField HeaderText="备注" Width="200px" DataField="remark" TextAlign="Center" />
                            <x:BoundField HeaderText="请求时间" Width="200px" DataField="RequestDate" TextAlign="Center" />
                            <x:BoundField HeaderText="返回时间" Width="200px" DataField="ResponseDate" TextAlign="Center" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="W_ShowSCF" Title="汇票信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        EnableMaximize="true" Target="Top" EnableResize="true" runat="server" IsModal="true"
        Width="700px" EnableConfirmOnClose="true" Height="500px">
    </x:Window>
    </form>
</body>
</html>
