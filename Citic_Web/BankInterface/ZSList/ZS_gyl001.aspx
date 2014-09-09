<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZS_gyl001.aspx.cs" Inherits="Citic_Web.BankInterface.ZS_gyl001" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>浙商银行客户信息查询</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="VBox" BoxConfigAlign="Stretch" EnableBackgroundColor="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="false" ShowHeader="true"
                Title="浙商客户信息" EnableBackgroundColor="true">
                <Items>
                    <x:SimpleForm ID="SimpleForm" runat="server" BodyPadding="5px" Title="查询客户条件" EnableBackgroundColor="true">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button runat="server" Text="提交" ID="Btn_Add_Search" Icon="Tick" OnClick="Btn_Add_Search_Click"
                                        IconAlign="Right">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Items>
                            <x:TextBox ID="txt_custNo" runat="server" Label="客户号" Text="" Width="300px">
                            </x:TextBox>
                            <x:TextBox ID="txt_pledgeName" runat="server" Label="客户名称" Text="" Width="300px">
                            </x:TextBox>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                Title="查询结果" Layout="Fit" BoxConfigAlign="Stretch" BoxFlex="1" EnableBackgroundColor="true">
                <Toolbars>
                    <x:Toolbar ID="Toolbar2" runat="server">
                        <Items>
                            <x:Button ID="Btn_Search" runat="server" Text="查询" OnClick="Btn_Search_Click" Icon="SystemSearch"
                                ToolTip="<span style='color:Red'>查询当前用户今天提交信息</span>" ToolTipType="Qtip">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="G_DealerName" runat="server" Title="详细信息" >
                        <Columns>
                            <x:BoundField HeaderText="组织机构代码" Width="150px" DataField="orgCode" />
                            <x:BoundField HeaderText="客户ID" Width="150px" DataField="ecifCode" />
                            <x:BoundField HeaderText="客户名称" Width="150px" DataField="custName" />
                            <x:BoundField HeaderText="备注" Width="150px" DataField="remark" />
                            <x:BoundField HeaderText="请求时间" Width="150px" DataField="RequestDate" />
                            <x:BoundField HeaderText="返回时间" Width="150px" DataField="ResponseDate" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
