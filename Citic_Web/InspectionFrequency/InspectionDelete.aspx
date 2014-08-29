<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionDelete.aspx.cs"
    Inherits="Citic_Web.InspectionFrequency.InspectionDelete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>视频追踪删除</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" Height="120px" EnableBackgroundColor="true">
                <Items>
                    <x:Form ID="Form2" runat="server" BodyPadding="2px" Title="删除条件" LabelAlign="Right"
                        EnableBackgroundColor="true">
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
                                    <x:DatePicker ID="txt_Time" EnableEdit="false" runat="server" Label="检查日期" Width="200px">
                                    </x:DatePicker>
                                    <x:TextBox ID="txt_CreateName" runat="server" Label="检查人员" Text="" Width="200px">
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
                Title="Panel" Layout="Fit" BoxFlex="1">
                <Items>
                    <x:Grid ID="G_InspectionFrequency" runat="server" Title="Grid" EnableCheckBoxSelect="True"
                        DataKeyNames="ID" EnableColumnLines="true">
                        <Toolbars>
                            <x:Toolbar runat="server">
                                <Items>
                                    <x:Button ID="btn_Del" runat="server" Text="删除" Icon="Delete" OnClick="btn_Del_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:BoundField HeaderText="检查人员" ColumnID="Rummager" DataField="Rummager" />
                            <x:BoundField HeaderText="经销店名称" ColumnID="DealerName" DataField="DealerName" />
                            <x:BoundField HeaderText="合作银行" ColumnID="Bank" DataField="Bank" />
                            <x:BoundField HeaderText="品牌" ColumnID="BrandName" DataField="BrandName" />
                            <x:BoundField HeaderText="监管员" ColumnID="SupervisorName" DataField="SupervisorName" />
                            <x:BoundField HeaderText="监管模式" ColumnID="Model" DataField="Model" />
                            <x:BoundField HeaderText="库存" ColumnID="Inventory" DataField="Inventory" />
                            <x:BoundField HeaderText="总部总账" ColumnID="QuartersLedger" DataField="QuartersLedger" />
                            <x:BoundField HeaderText="主要问题" ColumnID="MainProblem" DataField="MainProblem" />
                            <%-- <x:BoundField HeaderText="视频-汽车处理人" ColumnID="MainProblem_1_People" DataField="MainProblem_1_People" />
                            <x:BoundField HeaderText="视频-汽车处理时间" ColumnID="MainProblem_1_Date" DataField="MainProblem_1_Date" />
                            <x:BoundField HeaderText="视频-风控处理结果" ExpandUnusedSpace="true" ColumnID="MainProblem_2_Results"
                                DataField="MainProblem_2_Results" />
                            <x:BoundField HeaderText="视频-风控处理人" ColumnID="MainProblem_2_People" DataField="MainProblem_2_People" />
                            <x:BoundField HeaderText="视频-风控处理时间" ColumnID="MainProblem_2_Date" DataField="MainProblem_2_Date" />
                            <x:BoundField HeaderText="视频-管理处理结果" ExpandUnusedSpace="true" ColumnID="MainProblem_3_Results"
                                DataField="MainProblem_3_Results" />
                            <x:BoundField HeaderText="视频-管理处理人" ColumnID="MainProblem_3_People" DataField="MainProblem_3_People" />
                            <x:BoundField HeaderText="视频-管理处理时间" ColumnID="MainProblem_3_Date" DataField="MainProblem_3_Date" />
                            <x:BoundField HeaderText="总账-汽车处理结果" ExpandUnusedSpace="true" ColumnID="QuartersLedger_1_Results"
                                DataField="QuartersLedger_1_Results" />
                            <x:BoundField HeaderText="总账-汽车处理人" ColumnID="QuartersLedger_1_People" DataField="QuartersLedger_1_People" />
                            <x:BoundField HeaderText="总账-汽车处理时间" ColumnID="QuartersLedger_1_Date" DataField="QuartersLedger_1_Date" />
                            <x:BoundField HeaderText="持续-汽车处理结果" ExpandUnusedSpace="true" ColumnID="Continue_1_Results"
                                DataField="Continue_1_Results" />
                            <x:BoundField HeaderText="持续-汽车处理人" ColumnID="Continue_1_People" DataField="Continue_1_People" />
                            <x:BoundField HeaderText="持续-汽车处理时间" ColumnID="Continue_1_Date" DataField="Continue_1_Date" />--%>
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
            <%--<x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" Layout="Fit" BoxFlex="1">
                <Items>
                    <x:Grid ID="G_InspectionFrequency" runat="server" Title="" EnableRowNumber="true"
                        ShowHeader="true" ForceFitAllTime="true" EnableCheckBoxSelect="true" DataKeyNames="ID">
                        <Toolbars>
                            <x:Toolbar runat="server">
                                <Items>
                                    <x:Button ID="btn_InspectionFrequency_Logic_Del" runat="server" Icon="Delete" Text="逻辑删除"
                                        OnClick="btn_InspectionFrequency_Logic_Del_Click" Hidden="true">
                                    </x:Button>
                                    <x:Button ID="btn_InspectionFrequency_Physics_Del" runat="server" Icon="Delete" Text="物理删除"
                                        OnClick="btn_InspectionFrequency_Physics_Del_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:BoundField HeaderText="检查区域" DataField="Area" Width="28px" />
                            <x:WindowField Width="50px" WindowID="InspectionUpdate" HeaderText="经销店名称" ToolTip="编辑"
                                DataTextFormatString="{0}" DataIFrameUrlFields="ID,Statu" DataTextField="DealerName"
                                DataIFrameUrlFormatString="InspectionUpdate.aspx?ID={0}&Statu={1}" DataWindowTitleField="DealerName"
                                DataWindowTitleFormatString="编辑 - {0}" />
                            <x:BoundField HeaderText="合作银行" DataField="Bank" Width="60px" />
                            <x:BoundField HeaderText="品牌" DataField="BrandName" Width="30px" />
                            <x:BoundField HeaderText="监管员" DataField="SupervisorName" Width="30px" />
                            <x:BoundField HeaderText="检查问题" DataField="CheckProblem" ExpandUnusedSpace="true" />
                            <x:BoundField HeaderText="汽车/产业金融中心处理结果" DataField="FinancialCenter" />
                            <x:BoundField HeaderText="风控部处理结果" DataField="RiskControl" />
                            <x:BoundField HeaderText="管理中心处理结果" DataField="AdminDepartment" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel4" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" Layout="Fit" BoxFlex="1">
                <Items>
                    <x:Grid ID="G_QuartersLedger" runat="server" Title="总部总账问题" EnableRowNumber="true"
                        ForceFitAllTime="true" EnableCheckBoxSelect="true" DataKeyNames="ID">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar2" runat="server">
                                <Items>
                                    <x:Button ID="btn_QuartersLedger_Logic_Del" runat="server" Icon="Delete" Text="逻辑删除"
                                        OnClick="btn_QuartersLedger_Logic_Del_Click" Hidden="true">
                                    </x:Button>
                                    <x:Button ID="btn_QuartersLedger_Physics_Del" runat="server" Icon="Delete" Text="物理删除"
                                        OnClick="btn_QuartersLedger_Physics_Del_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:BoundField HeaderText="检查区域" DataField="Area" Width="28px" />
                            <x:WindowField Width="50px" WindowID="InspectionUpdate" HeaderText="经销店名称" ToolTip="编辑"
                                DataTextFormatString="{0}" DataIFrameUrlFields="ID,Statu" DataTextField="DealerName"
                                DataIFrameUrlFormatString="InspectionUpdate.aspx?ID={0}&Statu={1}" DataWindowTitleField="DealerName"
                                DataWindowTitleFormatString="编辑 - {0}" />
                            <x:BoundField HeaderText="合作银行" DataField="Bank" Width="60px" />
                            <x:BoundField HeaderText="品牌" DataField="BrandName" Width="30px" />
                            <x:BoundField HeaderText="总部总账问题(系统、电子总账）" ExpandUnusedSpace="true" DataField="QuartersLedger" />
                            <x:BoundField HeaderText="处理结果" DataField="FinancialCenter" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel5" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" Layout="Fit" BoxFlex="1">
                <Items>
                    <x:Grid ID="G_ContinuousTracking" runat="server" Title="需持续追踪解决问题" EnableRowNumber="true"
                        ForceFitAllTime="true" EnableCheckBoxSelect="true" DataKeyNames="ID">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar3" runat="server">
                                <Items>
                                    <x:Button ID="btn_ContinuousTracking_Logic_Del" runat="server" Icon="Delete" Text="逻辑删除"
                                        OnClick="btn_ContinuousTracking_Logic_Del_Click" Hidden="true">
                                    </x:Button>
                                    <x:Button ID="btn_ContinuousTrackingPhysics_Del" runat="server" Icon="Delete" Text="物理删除"
                                        OnClick="btn_ContinuousTrackingPhysics_Del_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:BoundField HeaderText="检查区域" DataField="Area" Width="28px" />
                            <x:WindowField Width="50px" WindowID="InspectionUpdate" HeaderText="经销店名称" ToolTip="编辑"
                                DataTextFormatString="{0}" DataIFrameUrlFields="ID,Statu" DataTextField="DealerName"
                                DataIFrameUrlFormatString="InspectionUpdate.aspx?ID={0}&Statu={1}" DataWindowTitleField="DealerName"
                                DataWindowTitleFormatString="编辑 - {0}" />
                            <x:BoundField HeaderText="合作银行" DataField="Bank" Width="60px" />
                            <x:BoundField HeaderText="品牌" DataField="BrandName" Width="30px" />
                            <x:BoundField HeaderText="监管员" DataField="SupervisorName" Width="30px" />
                            <x:BoundField HeaderText="检查问题" DataField="CheckProblem" ExpandUnusedSpace="true" />
                            <x:BoundField HeaderText="历史检查时间" DataField="HistoryTime" DataFormatString="{0:yyyy-MM-dd}"
                                Width="20px" />
                            <x:BoundField HeaderText="处理结果" DataField="FinancialCenter" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>--%>
        </Items>
    </x:Panel>
    <x:Window ID="InspectionUpdate" Title="编辑" Popup="false" EnableIFrame="true" runat="server"
        CloseAction="HidePostBack" EnableConfirmOnClose="true" IFrameUrl="about:blank"
        EnableMaximize="true" EnableResize="true" Target="Top" IsModal="True" Width="500px"
        Height="600px">
    </x:Window>
    </form>
</body>
</html>
