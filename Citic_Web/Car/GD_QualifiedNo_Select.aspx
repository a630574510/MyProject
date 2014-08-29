<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GD_QualifiedNo_Select.aspx.cs"
    Inherits="Citic_Web.Car.GD_QualifiedNo" %>

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
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" Title="查询信息" EnableBackgroundColor="true">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button runat="server" Text="提交" Icon="Tick" IconAlign="Right" ID="Btn_Add_Search"
                                        OnClick="Btn_Add_Search_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Items>
                            <x:DropDownList ID="ddl_JXS_ID" runat="server" Label="经销商" AutoPostBack="true" Width="300px" OnSelectedIndexChanged="ddl_JXS_ID_SelectedIndexChanged">
                            </x:DropDownList>
                            <x:TextBox ID="txt_PI_NO" runat="server" Label="合格证" Text="" Width="300px" EmptyText="合格证号请输全部">
                            </x:TextBox>
                            <x:TextBox ID="txt_DJ_NO" runat="server" Label="车架" Text="" Width="300px" EmptyText="车架号请输全部"
                                Hidden="true">
                            </x:TextBox>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true"
                Title="返回结果" Layout="Fit" BoxFlex="1" BoxConfigAlign="Stretch">
                <Toolbars>
                    <x:Toolbar runat="server">
                        <Items>
                            <x:Button ID="Btn_Search" runat="server" Text="查询" Icon="SystemSearch" ToolTip="<span style='color:Red'>查询当前用户今天提交信息</span>"
                                ToolTipType="Qtip" OnClick="Btn_Search_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="G_Correct" runat="server" Title="详细信息" EnableRowNumber="True" EnableTextSelection="true" >
                        <Columns>
                            <x:BoundField HeaderText="类型" DataField="FTranCode" Width="100px" />
                            <x:BoundField HeaderText="合格证" DataField="PI_NO" Width="100px" />
                            <x:BoundField HeaderText="返回信息" DataField="Message" Width="100px" />
                            <x:BoundField HeaderText="提交时间" DataField="RequestDate" Width="100px" />
                            <x:BoundField HeaderText="返回时间" DataField="ResponseDate" Width="100px" />
                            <x:BoundField HeaderText="经销商名称" DataField="JXS_NAME" Width="100px" />
                            <x:BoundField HeaderText="合格证状态" DataField="PI_STATUS" Width="100px" />
                            <x:BoundField HeaderText="车辆状态" DataField="CAR_STATUS" Width="100px" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
