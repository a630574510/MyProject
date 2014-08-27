<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZX_402.aspx.cs" Inherits="Citic_Web.BankInterface.ZX_402" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="false"
        Title="Panel" EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel">
                <Items>
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="查询信息" EnableBackgroundColor="true"
                        LabelAlign="Right">
                        <Items>
                            <x:TextBox ID="txt_PI_NO" runat="server" Label="合格证" Text="" Width="300px" EmptyText="合格证与车架号必须输入一项">
                            </x:TextBox>
                            <x:TextBox ID="txt_DJ_NO" runat="server" Label="车架" Text="" Width="300px" EmptyText="合格证与车架号请输全部">
                            </x:TextBox>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true"
                Title="返回结果" Layout="Fit" BoxFlex="1" BoxConfigAlign="Stretch">
                <Toolbars>
                    <x:Toolbar ID="Toolbar2" runat="server">
                        <Items>
                            <x:Button ID="Btn_Search" runat="server" Text="查询" Icon="SystemSearch" ToolTip="<span style='color:Red'>查询当前用户今天提交信息</span>"
                                ToolTipType="Qtip" OnClick="Btn_Search_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="G_Correct" runat="server" Title="详细信息" ShowBorder="true" ShowHeader="false"
                        EnableRowNumber="True" EnableTextSelection="true" EmptyText="<span style='color:Red;font-size:21px'>提示：车架号和合格证必须输入一项</br>请不要把<span style='color:Blue';>合格证当做车架号</span>,或者把<span style='color:Blue';>车架号当做合格证</span></br>否者查不出数据">
                        <Columns>
                            <%--<x:BoundField HeaderText="经销商名称" DataField="ID" Width="200px" />--%>
                            <%--<x:WindowField WindowID="W_ShowSCF" Width="200px" HeaderText="合格证/车架" DataTextField="PI_NO"
                                ToolTip="详细信息" DataIFrameUrlFields="id" DataIFrameUrlFormatString="ZX_ShowSCF.aspx?id={0}&type=Q406&clss=GD" />--%>
                            <x:BoundField HeaderText="合格证/车架" DataField="PI_NO" Width="200px" />
                            <x:BoundField HeaderText="返回信息" DataField="Message" Width="200px" />
                            <x:BoundField HeaderText="提交时间" DataField="RequestDate" Width="200px" />
                            <x:BoundField HeaderText="返回时间" DataField="ResponseDate" Width="200px" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="W_ShowSCF" Title="车辆信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        EnableMaximize="true" Target="Top" EnableResize="true" runat="server" IsModal="true"
        Width="700px" EnableConfirmOnClose="true" Height="500px">
    </x:Window>
    </form>
</body>
</html>
