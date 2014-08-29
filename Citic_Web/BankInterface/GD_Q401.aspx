<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GD_Q401.aspx.cs" Inherits="Citic_Web.BankInterface.GD_Q401" %>

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
                Title="光大客户信息" EnableBackgroundColor="true">
                <Items>
                    <x:SimpleForm ID="SimpleForm" runat="server" BodyPadding="5px" Title="查询客户条件" EnableBackgroundColor="true">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button runat="server" Text="提交" ID="Btn_Add_Search" OnClick="Btn_Add_Search_Click"
                                        Icon="Tick" IconAlign="Right">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Items>
                            <x:TextBox ID="txt_CUST_NAME" runat="server" Label="客户名称" Text="" Width="300px" EmptyText="客户名称与组织机构必须输入一项">
                            </x:TextBox>
                            <x:TextBox ID="txt_ORG_CODE" runat="server" Label="组织机构代码" Text="" Width="300px"
                                EmptyText="客户名称与组织机构必须输入一项">
                            </x:TextBox>
                            <x:DropDownList ID="ddl_SelCUST_TYPE" runat="server" Label="客户类型" Width="300px" Visible="false">
                                <x:ListItem Text="——请选择——" Value="-1" />
                                <x:ListItem Text="经销厂商" Value="20" />
                                <x:ListItem Text="核心厂商" Value="10" />
                            </x:DropDownList>
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
                    <x:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="True">
                        <Tabs>
                            <x:Tab ID="Tab1" runat="server" BodyPadding="5px" Title="正确返回信息" Layout="Fit" EnableBackgroundColor="true">
                                <Items>
                                    <x:Grid ID="G_DealerName" runat="server" Title="详细信息" EnableTextSelection="true"
                                        ForceFitAllTime="true">
                                        <Columns>
                                            <x:BoundField HeaderText="客户ID" DataField="CUST_ID" />
                                            <x:BoundField HeaderText="客户名称" DataField="CUST_NAME" />
                                            <x:BoundField HeaderText="组织机构代码" DataField="ORG_CODE" />
                                            <x:BoundField HeaderText="客户类型" DataField="CUST_TYPE" />
                                            <x:BoundField HeaderText="客户经理" DataField="CM_NAME" />
                                            <x:BoundField HeaderText="客户经理电话" DataField="OFFICE_PHONE_NO" />
                                            <x:BoundField HeaderText="客户经理手机" DataField="CELLPHONE_NO" />
                                            <x:BoundField HeaderText="客户经理E-MAIL" DataField="EMAIL" />
                                            <x:BoundField HeaderText="提交时间" DataField="RequestDate" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab2" runat="server" BodyPadding="5px" EnableBackgroundColor="true" Title="错误返回信息"
                                Layout="Fit">
                                <Items>
                                    <x:Grid ID="G_Error" runat="server" Title="详细信息" EnableTextSelection="true" ForceFitAllTime="true">
                                        <Columns>
                                            <x:BoundField HeaderText="客户名称" DataField="CUST_NAME" />
                                            <x:BoundField HeaderText="组织机构代码" DataField="ORG_CODE" />
                                            <x:BoundField HeaderText="客户类型" DataField="CUST_TYPE" />
                                            <x:BoundField HeaderText="提交时间" DataField="RequestDate" />
                                            <x:BoundField HeaderText="返回时间" DataField="ResponseDate" />
                                            <x:BoundField HeaderText="返回结果" DataField="ErrMessage" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                        </Tabs>
                    </x:TabStrip>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
