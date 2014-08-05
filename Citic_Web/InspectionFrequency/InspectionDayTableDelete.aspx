<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionDayTableDelete.aspx.cs"
    Inherits="Citic_Web.InspectionFrequency.InspectionDayTableDelete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>删除视频检查日记录</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false"
        Title="Panel" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start">
        <Items>
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
                                    <x:TextBox ID="txt_SupervisorName" runat="server" Label="监管员" Text="" Width="200px">
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
                                    <x:TextBox ID="txt_Rummager" runat="server" Label="检查人员" Text="" Width="200px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_DealerName" runat="server" Label="经销店名称" Text="" Width="200px">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" Layout="Fit" BoxFlex="3">
                <Items>
                    <x:Grid ID="G_DayTabel" runat="server" EnableRowNumber="true" Title="具体信息" EnableBackgroundColor="true"
                        ForceFitAllTime="true" EnableCheckBoxSelect="true" DataKeyNames="id">
                        <Toolbars>
                            <x:Toolbar runat="server">
                                <Items>
                                    <x:Button ID="btn_Logic_Del" runat="server" Text="逻辑删除" Icon="Delete" OnClick="btn_Logic_Del_Click"  Hidden="true">
                                    </x:Button>
                                    <x:Button ID="btn_Physics_Del" runat="server" Text="物理删除" Icon="Delete" OnClick="btn_Physics_Del_Click" >
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:BoundField HeaderText="检查人员" ColumnID="Rummager" DataField="Rummager" Width="40px" />
                            <x:WindowField Width="50px" WindowID="DayUpdate" HeaderText="经销店名称" ToolTip="编辑"
                                DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataTextField="DealerName"
                                DataIFrameUrlFormatString="InspectionDayTableUpdate.aspx?ID={0}" DataWindowTitleField="DealerName"
                                DataWindowTitleFormatString="编辑 - {0}" />
                            <x:BoundField HeaderText="合作银行" ColumnID="Bank" DataField="Bank" Width="80px" />
                            <x:BoundField HeaderText="品牌" ColumnID="BrandName" DataField="BrandName" Width="60px" />
                            <x:BoundField HeaderText="监管员" ColumnID="SupervisorName" DataField="SupervisorName"
                                Width="30px" />
                            <x:BoundField HeaderText="监管模式" ColumnID="Model" DataField="Model" Width="40px" />
                            <x:BoundField HeaderText="库存" ColumnID="Inventory" DataField="Inventory" Width="20px" />
                            <x:BoundField HeaderText="总部总账" ColumnID="QuartersLedger" DataField="QuartersLedger"
                                Width="150px" />
                            <x:BoundField HeaderText="主要问题" ColumnID="MainProblem" DataField="MainProblem" Width="150px" />
                            <x:BoundField HeaderText="历史检查时间" ColumnID="HistoryDate" DataField="HistoryDate" DataFormatString="{0:yyyy-MM-dd}" />
                            <x:BoundField HeaderText="备注" ColumnID="Remark" DataField="Remark" Width="150px" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="DayUpdate" Title="编辑" Popup="false" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" EnableConfirmOnClose="true" IFrameUrl="about:blank"
        EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="500px"
        Height="600px">
    </x:Window>
    </form>
</body>
</html>
