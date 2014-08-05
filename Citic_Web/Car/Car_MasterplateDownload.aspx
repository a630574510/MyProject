<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Car_MasterplateDownload.aspx.cs"
    Inherits="Citic_Web.Car.Car_MasterplateDownload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" Title="模版下载" runat="server" BodyPadding="0px" ShowBorder="true"
        Layout="VBox" BoxConfigAlign="Stretch" ShowHeader="true" EnableBackgroundColor="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" ShowBorder="true" ShowHeader="false" Title="Panel">
                <Items>
                    <x:Form ID="Form2" runat="server" BodyPadding="2px" ShowHeader="false" ShowBorder="false"
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="90px">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button runat="server" Text="查询" ID="Btn_Search" Icon="SystemSearch" OnClick="Btn_Search_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Rows>
                            <x:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <x:TextBox ID="txt_Dealer" runat="server" Label="经销商" Text="" ShowLabel="true" Width="200px">
                                    </x:TextBox>
                                    <x:DatePicker ID="dp_AddTime" runat="server" Label="添加日期" Width="200px">
                                    </x:DatePicker>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                BoxFlex="1" Layout="Fit" BoxConfigAlign="Stretch" BoxConfigPosition="Start" BoxConfigChildMargin="0 5 0 0"
                CssStyle="padding-top:5px">
                <Items>
                    <x:TabStrip ID="TabStrip1" Width="750px" Height="300px" ShowBorder="true" TabPosition="Top"
                        EnableTabCloseMenu="false" EnableTitleBackgroundColor="true" ActiveTabIndex="0"
                        runat="server">
                        <Tabs>
                            <x:Tab ID="Tab1" Title="入库" EnableBackgroundColor="true" BodyPadding="5px" Layout="Fit"
                                runat="server">
                                <Items>
                                    <x:Grid ID="G_Transit" runat="server" Title="Grid" ShowHeader="false" EnableBackgroundColor="true">
                                        <Columns>
                                            <x:BoundField HeaderText="经销商" DataField="DealerName" />
                                            <x:BoundField HeaderText="车辆总数" DataField="CountCar" />
                                            <x:HyperLinkField HeaderText="确认书" DataTextFormatString="{0}" DataNavigateUrlFields="FileName1"
                                                DataNavigateUrlFormatString="../Confirmation/{0}" DataNavigateUrlFieldsEncode="true"
                                                Text="确认书下载" />
                                            <x:HyperLinkField HeaderText="手工台帐" DataTextFormatString="{0}" DataNavigateUrlFields="FileName2"
                                                DataNavigateUrlFormatString="../Confirmation/{0}" DataNavigateUrlFieldsEncode="true"
                                                Text="手工台帐下载" />
                                            <x:HyperLinkField HeaderText="钥匙交接表" DataTextFormatString="{0}" DataNavigateUrlFields="FileName3"
                                                DataNavigateUrlFormatString="../Confirmation/{0}" DataNavigateUrlFieldsEncode="true"
                                                Text="钥匙交接表下载" />
                                            <x:HyperLinkField HeaderText="钥匙借用登记表" DataTextFormatString="{0}" DataNavigateUrlFields="FileName4"
                                                DataNavigateUrlFormatString="../Confirmation/{0}" DataNavigateUrlFieldsEncode="true"
                                                Text="钥匙借用登记表下载" />
                                            <x:BoundField HeaderText="添加人" DataField="CreateName" />
                                            <x:BoundField HeaderText="添加日期" DataField="CreateTime"  DataFormatString="{0:yyyy-MM-dd}" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab2" Title="出库" BodyPadding="5px" EnableBackgroundColor="true" runat="server"  Layout="Fit">
                                <Items>
                                    <x:Grid ID="G_Out" runat="server" Title="Grid" ShowHeader="false" EnableBackgroundColor="true">
                                        <Columns>
                                            <x:BoundField HeaderText="经销商" DataField="DealerName" />
                                            <x:BoundField HeaderText="车辆总数" DataField="CountCar" />
                                            <x:HyperLinkField HeaderText="出库申请书" DataTextFormatString="{0}" DataNavigateUrlFields="FileName5"
                                                DataNavigateUrlFormatString="../Confirmation/{0}" DataNavigateUrlFieldsEncode="true"
                                                Text="出库申请书下载" />
                                            <x:BoundField HeaderText="添加人" DataField="CreateName" />
                                            <x:BoundField HeaderText="添加日期" DataField="CreateTime"  DataFormatString="{0:yyyy-MM-dd}" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab3" Title="移库" BodyPadding="5px" EnableBackgroundColor="true" runat="server"  Layout="Fit">
                                <Items>
                                    <x:Grid ID="G_Move" runat="server" Title="Grid" ShowHeader="false" EnableBackgroundColor="true">
                                        <Columns>
                                            <x:BoundField HeaderText="经销商" DataField="DealerName" />
                                            <x:BoundField HeaderText="车辆总数" DataField="CountCar" />
                                            <x:HyperLinkField HeaderText="二网申请书" DataTextFormatString="{0}" DataNavigateUrlFields="FileName6"
                                                DataNavigateUrlFormatString="../Confirmation/{0}" DataNavigateUrlFieldsEncode="true"
                                                Text="二网申请书下载" />
                                            <x:BoundField HeaderText="添加人" DataField="CreateName" />
                                            <x:BoundField HeaderText="添加日期" DataField="CreateTime" DataFormatString="{0:yyyy-MM-dd}" />
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
