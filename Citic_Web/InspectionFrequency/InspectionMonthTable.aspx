<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionMonthTable.aspx.cs"
    Inherits="Citic_Web.InspectionFrequency.InspectionMonthTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>视频检查月报表</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:pagemanager id="PageManager1" runat="server" autosizepanelid="Panel1" />
    <x:panel id="Panel1" runat="server" bodypadding="0px" showborder="false" showheader="false"
        title="Panel" layout="VBox" boxconfigalign="Stretch" boxconfigposition="Start">
        <items>
            <x:Panel ID="Panel4" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" EnableBackgroundColor="true">
                <Items>
                    <x:Form ID="Form2" runat="server" BodyPadding="5px" Title="查询条件" EnableBackgroundColor="true"
                        LabelAlign="Right">
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
                                    <x:TextBox ID="txt_Area" runat="server" Label="检查区域" Text="" Width="200px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_Bank" runat="server" Label="合作银行" Text="" Width="200px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_BrandName" runat="server" Label="品牌" Text="" Width="200px">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FormRow2" runat="server">
                                <Items>
                                    <x:DatePicker ID="txt_Time" runat="server" Label="检查日期" Width="200px">
                                    </x:DatePicker>
                                    <x:TextBox ID="txt_SupervisorName" runat="server" Label="检查人员" Text="" Width="200px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_DealerName" runat="server" Label="经销店名称" Text="" Width="200px">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="true"
                Title="1、检查情况" Layout="Fit" BoxFlex="1" Height="100px">
                <Toolbars>
                    <x:Toolbar ID="Toolbar2" runat="server">
                        <Items>
                            <x:ToolbarText ID="TT_Day" runat="server" CssStyle="font-size:18px;">
                            </x:ToolbarText>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="G_DayInspection" runat="server" Title="1、检查情况" ShowHeader="false" ForceFitAllTime="true">
                        <Columns>
                            <x:BoundField HeaderText="检查店数" ColumnID="ShopCount" DataField="ShopCount" TextAlign="Center" />
                            <x:BoundField HeaderText="符合要求店数" ColumnID="ConformShopCount" DataField="ConformShopCount"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="不符合要求店数" ColumnID="NotConformShopCount" DataField="NotConformShopCount"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="0库存店数" ColumnID="0InventoryShopCount" DataField="InventoryShopCount"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="备注" ColumnID="Remark" TextAlign="Center" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" Layout="Fit" BoxFlex="3">
                <Items>
                    <x:Grid ID="G_DayTabel" runat="server" EnableRowNumber="true" Title="2、具体情况" EnableBackgroundColor="true"
                        ForceFitAllTime="true">
                        <Columns>
                            <x:BoundField HeaderText="区域中心" ColumnID="Area" DataField="Area" Width="40px" />
                            <x:BoundField HeaderText="检查人员" ColumnID="Rummager" DataField="Rummager" Width="40px" />
                            <x:WindowField Width="50px" WindowID="DayUpdate" HeaderText="经销店名称" ToolTip="编辑"
                                DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataTextField="DealerName"
                                DataIFrameUrlFormatString="InspectionDayTableUpdate.aspx?ID={0}" DataWindowTitleField="DealerName"
                                DataWindowTitleFormatString="编辑 - {0}" />
                            <x:BoundField HeaderText="合作银行" ColumnID="Bank" DataField="Bank" Width="80px" />
                            <x:BoundField HeaderText="品牌" ColumnID="BrandName" DataField="BrandName" Width="60px" />
                            <x:BoundField HeaderText="监管员" ColumnID="SupervisorName" DataField="SupervisorName" Width="30px" />
                            <x:BoundField HeaderText="监管模式" ColumnID="Model" DataField="Model" Width="40px" />
                            <x:BoundField HeaderText="库存" ColumnID="Inventory" DataField="Inventory" Width="20px" />
                            <x:BoundField HeaderText="总部总账" ColumnID="QuartersLedger" DataField="QuartersLedger" Width="150px" />
                            <x:BoundField HeaderText="主要问题" ColumnID="MainProblem" DataField="MainProblem" Width="150px" />
                            <x:BoundField HeaderText="备注" ColumnID="Remark" DataField="Remark" Width="150px" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </items>
    </x:panel>
    <x:window id="DayUpdate" title="编辑" popup="false" enableiframe="true" runat="server"
        closeaction="HidePostBack" enableconfirmonclose="true" iframeurl="about:blank"
        enablemaximize="true" enableresize="true" target="Top" ismodal="True" width="500px"
        height="600px">
    </x:window>
    </form>
</body>
</html>
