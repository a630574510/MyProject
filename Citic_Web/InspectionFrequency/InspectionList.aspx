<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionList.aspx.cs"
    Inherits="Citic_Web.InspectionFrequency.InspectionList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>视频检查查询</title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
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
                                    <x:Button ID="Btn_Generate" runat="server" Text="生成Excel" OnClick="Btn_Generate_Click">
                                    </x:Button>
                                    <x:HyperLink ID="hl_ExportExcel" runat="server" Label="" NavigateUrl="" Target="_blank"
                                        Text="导出Excel">
                                    </x:HyperLink>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Rows>
                            <x:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <x:TextBox ID="txt_Area" runat="server" Label="评价" Text="" Width="150px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_Bank" runat="server" Label="合作银行" Text="" Width="150px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_BrandName" runat="server" Label="品牌" Text="" Width="150px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_Rummager" runat="server" Label="检查人员" Text="" Width="150px">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FormRow2" runat="server">
                                <Items>
                                    <x:DatePicker ID="txt_StartTime" EnableEdit="false" runat="server" Label="检查起始日期"
                                        Width="150px">
                                    </x:DatePicker>
                                    <x:DatePicker ID="txt_AsTime" EnableEdit="false" runat="server" Label="检查截至日期" Width="150px">
                                    </x:DatePicker>
                                    <x:TextBox ID="txt_DealerName" runat="server" Label="经销店名称" Text="" Width="150px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_SupervisorName" runat="server" Label="监管员" Text="" Width="150px">
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
                    <x:Grid ID="G_DayInspection" runat="server" Title="1、检查情况" ShowHeader="false" ForceFitAllTime="true"
                        EnableColumnLines="true">
                        <Columns>
                            <x:BoundField HeaderText="检查店数" ColumnID="ShopCount" DataField="ShopCount" TextAlign="Center" />
                            <x:BoundField HeaderText="符合要求店数" ColumnID="ConformShopCount" DataField="ConformShopCount"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="不符合要求店数" ColumnID="NotConformShopCount" DataField="NotConformShopCount"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="0库存店数" ColumnID="0InventoryShopCount" DataField="InventoryShopCount"
                                TextAlign="Center" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" Layout="Fit" BoxFlex="3">
                <Items>
                    <x:Grid ID="G_DayTabel" runat="server" EnableRowNumber="true" Title="2、具体情况" EnableBackgroundColor="true"
                        ForceFitAllTime="false" EnableColumnLines="true" EnableTextSelection="true">
                        <Columns>
                            <x:BoundField HeaderText="经销店名称" ColumnID="DealerName" DataField="DealerName" Hidden="true" />
                            <%--<x:BoundField HeaderText="区域中心" ColumnID="Area" DataField="Area" Hidden="true" />--%>
                            <x:BoundField HeaderText="检查人员" ColumnID="Rummager" DataField="Rummager" />
                            <%--<x:BoundField HeaderText="经销店名称" ColumnID="DealerName" DataField="DealerName" />--%>
                            <x:WindowField WindowID="DayUpdate" HeaderText="经销店名称" ToolTip="编辑" DataTextFormatString="{0}"
                                DataIFrameUrlFields="ID" DataTextField="DealerName" DataIFrameUrlFormatString="InspectionUpdate.aspx?ID={0}"
                                DataWindowTitleField="DealerName" DataWindowTitleFormatString="编辑 - {0}" />
                            <x:BoundField HeaderText="检查时间" ColumnID="CreateTime" DataField="CreateTime" DataFormatString="{0:yyyy-MM-dd}" />
                            <x:BoundField HeaderText="合作银行" ColumnID="Bank" DataField="Bank" />
                            <x:BoundField HeaderText="品牌" ColumnID="BrandName" DataField="BrandName" />
                            <x:BoundField HeaderText="监管员" ColumnID="SupervisorName" DataField="SupervisorName" />
                            <x:BoundField HeaderText="监管模式" ColumnID="Model" DataField="Model" />
                            <x:BoundField HeaderText="库存" ColumnID="Inventory" DataField="Inventory" />
                            <x:BoundField HeaderText="总部总账" ColumnID="QuartersLedger" DataField="QuartersLedger" />
                            <x:BoundField HeaderText="主要问题" ColumnID="MainProblem" DataField="MainProblem" />
                            <x:BoundField HeaderText="检查用时" ColumnID="Remark" DataField="Remark" Hidden="true" />
                            <x:BoundField HeaderText="评价" ColumnID="Area" DataField="Area" />
                            <x:BoundField HeaderText="视频-市场部处理结果" ColumnID="MainProblem_1_Results" DataField="MainProblem_1_Results" />
                            <x:BoundField HeaderText="视频-市场部处理人" ColumnID="MainProblem_1_People" DataField="MainProblem_1_People" />
                            <x:BoundField HeaderText="视频-市场部处理时间" ColumnID="MainProblem_1_Date" DataField="MainProblem_1_Date" />
                            <x:BoundField HeaderText="视频-风控部处理结果" ColumnID="MainProblem_2_Results" DataField="MainProblem_2_Results" />
                            <x:BoundField HeaderText="视频-风控部处理人" ColumnID="MainProblem_2_People" DataField="MainProblem_2_People" />
                            <x:BoundField HeaderText="视频-风控部处理时间" ColumnID="MainProblem_2_Date" DataField="MainProblem_2_Date" />
                            <x:BoundField HeaderText="视频-业务部处理结果" ColumnID="MainProblem_3_Results" DataField="MainProblem_3_Results" />
                            <x:BoundField HeaderText="视频-业务部处理人" ColumnID="MainProblem_3_People" DataField="MainProblem_3_People" />
                            <x:BoundField HeaderText="视频-业务部处理时间" ColumnID="MainProblem_3_Date" DataField="MainProblem_3_Date" />
                            <x:BoundField HeaderText="总账-业务部处理结果" ColumnID="QuartersLedger_1_Results" DataField="QuartersLedger_1_Results" />
                            <x:BoundField HeaderText="总账-业务部处理人" ColumnID="QuartersLedger_1_People" DataField="QuartersLedger_1_People" />
                            <x:BoundField HeaderText="总账-业务部处理时间" ColumnID="QuartersLedger_1_Date" DataField="QuartersLedger_1_Date" />
                            <%-- <x:BoundField HeaderText="总账-风控处理结果" ColumnID="QuartersLedger_2_Results" DataField="QuartersLedger_2_Results" />
                            <x:BoundField HeaderText="总账-风控处理人" ColumnID="QuartersLedger_2_People" DataField="QuartersLedger_2_People" />
                            <x:BoundField HeaderText="总账-风控处理时间" ColumnID="QuartersLedger_2_Date" DataField="QuartersLedger_2_Date" />
                            <x:BoundField HeaderText="总账-管理处理结果" ColumnID="QuartersLedger_3_Results" DataField="QuartersLedger_3_Results" />
                            <x:BoundField HeaderText="总账-管理处理人" ColumnID="QuartersLedger_3_People" DataField="QuartersLedger_3_People" />
                            <x:BoundField HeaderText="总账-管理处理时间" ColumnID="QuartersLedger_3_Date" DataField="QuartersLedger_3_Date" />--%>
                            <x:BoundField HeaderText="持续-业务部处理结果" ColumnID="Continue_1_Results" DataField="Continue_1_Results" />
                            <x:BoundField HeaderText="持续-业务部处理人" ColumnID="Continue_1_People" DataField="Continue_1_People" />
                            <x:BoundField HeaderText="持续-业务部处理时间" ColumnID="Continue_1_Date" DataField="Continue_1_Date" />
                            <%-- <x:BoundField HeaderText="持续-风控处理结果" ColumnID="Continue_2_Results" DataField="Continue_2_Results" />
                            <x:BoundField HeaderText="持续-风控处理人" ColumnID="Continue_2_People" DataField="Continue_2_People" />
                            <x:BoundField HeaderText="持续-风控处理时间" ColumnID="Continue_2_Date" DataField="Continue_2_Date" />
                            <x:BoundField HeaderText="持续-管理处理结果" ColumnID="Continue_3_Results" DataField="Continue_3_Results" />
                            <x:BoundField HeaderText="持续-管理处理人" ColumnID="Continue_3_People" DataField="Continue_3_People" />
                            <x:BoundField HeaderText="持续-管理处理时间" ColumnID="Continue_3_Date" DataField="Continue_3_Date" />--%>
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
