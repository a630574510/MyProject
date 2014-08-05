<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrackTabel.aspx.cs" Inherits="Citic_Web.InspectionFrequency.TrackTabel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>追踪表</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" ShowBorder="True" Layout="VBox" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" ShowHeader="false" Title="追踪表">
        <Items>
            <x:Panel ID="Panel2" Title="X年X月X日视频检查追踪表（汽车业务）" EnableBackgroundColor="true" BoxFlex="1"
                runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" Layout="Fit">
                <Items>
                    <x:Grid ID="G_YTDTraceTab" runat="server" EnableRowNumber="true" Title="" EnableBackgroundColor="true"
                        AllowCellEditing="true" ClicksToEdit="2" ForceFitAllTime="true">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button ID="btn_Add_YTDTrace" runat="server" Text="添加" Icon="Add" OnClick="Add_YTDTrace_Click">
                                    </x:Button>
                                    <x:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_Del_YTDTrace" runat="server" Text="删除选中行" Icon="Delete" OnClick="Del_YTDTrace_Click">
                                    </x:Button>
                                    <x:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_Band_YTDTrace" runat="server" Text="清空" Icon="ArrowRotateAnticlockwise"
                                        OnClick="Band_YTDTrace_Click">
                                    </x:Button>
                                    <x:ToolbarFill ID="ToolbarFill1" runat="server">
                                    </x:ToolbarFill>
                                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_G_YTDTraceTab" EnablePostBack="false" runat="server" Text="添加行"
                                        Icon="TableAdd">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:RenderField HeaderText="检查区域" DataField="YTDTrace_Area" FieldType="String" ColumnID="YTDTrace_Area">
                                <Editor>
                                    <x:DropDownList ID="YTDTrace_Area" runat="server" Label="Label">
                                        <x:ListItem Text="华北区域中心" Value="华北区域中心" />
                                        <x:ListItem Text="华南区域中心" Value="华南区域中心" />
                                        <x:ListItem Text="西南区域中心" Value="西南区域中心" />
                                        <x:ListItem Text="东北区域中心" Value="东北区域中心" />
                                        <x:ListItem Text="华东区域中心" Value="华东区域中心" />
                                        <x:ListItem Text="华中区域中心" Value="华中区域中心" />
                                        <x:ListItem Text="西北区域中心" Value="西北区域中心" />
                                        <x:ListItem Text="总部" Value="总部" />
                                    </x:DropDownList>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="经销店名称" DataField="YTDTrace_DealerName" FieldType="String"
                                ColumnID="YTDTrace_DealerName">
                                <Editor>
                                    <x:TextBox ID="YTDTrace_DealerName" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="合作银行" FieldType="String" DataField="YTDTrace_Bank" ColumnID="YTDTrace_Bank">
                                <Editor>
                                    <x:TextBox ID="YTDTrace_Bank" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="品牌" DataField="YTDTrace_BrandName" FieldType="String"
                                ColumnID="YTDTrace_BrandName">
                                <Editor>
                                    <x:TextBox ID="YTDTrace_BrandName" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="监管员" DataField="YTDTrace_SupervisorName" FieldType="String"
                                ColumnID="YTDTrace_SupervisorName">
                                <Editor>
                                    <x:TextBox ID="YTDTrace_SupervisorName" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="检查问题" DataField="YTDTrace_CheckProblem" FieldType="String"
                                ColumnID="YTDTrace_CheckProblem" ExpandUnusedSpace="true">
                                <Editor>
                                    <%--<x:TextBox ID="YTDTrace_CheckProblem" runat="server"  >
                                    </x:TextBox>--%>
                                    <x:TextArea ID="YTDTrace_CheckProblem" runat="server" Height="80px" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="汽车/产业金融中心处理结果" DataField="YTDTrace_FinancialCenter" FieldType="String"
                                ColumnID="YTDTrace_FinancialCenter">
                                <Editor>
                                    <%-- <x:TextBox ID="YTDTrace_FinancialCenter" runat="server"  >
                                    </x:TextBox>--%>
                                    <x:TextArea ID="YTDTrace_FinancialCenter" runat="server" Height="80px" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="风控部处理结果" DataField="YTDTrace_RiskControl" FieldType="String"
                                ColumnID="YTDTrace_RiskControl">
                                <Editor>
                                    <%--<x:TextBox ID="YTDTrace_RiskControl" runat="server"  >
                                    </x:TextBox>--%>
                                    <x:TextArea ID="YTDTrace_RiskControl" runat="server" Height="80px" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="管理中心处理结果" DataField="YTDTrace_AdminDepartment" FieldType="String"
                                Width="110px" ColumnID="YTDTrace_AdminDepartment">
                                <Editor>
                                    <%--<x:TextBox ID="YTDTrace_AdminDepartment" runat="server" CompareType="Float">
                                    </x:TextBox>--%>
                                    <x:TextArea ID="YTDTrace_AdminDepartment" runat="server" Height="80px" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" Title="总部总账问题" EnableBackgroundColor="true" runat="server" BoxFlex="1"
                BodyPadding="0px" ShowBorder="false" ShowHeader="false" Layout="Fit">
                <Items>
                    <x:Grid ID="G_Quarters_Ledger" runat="server" EnableRowNumber="true" Title="总部总账问题"
                        EnableBackgroundColor="true" AllowCellEditing="true" ClicksToEdit="2" ForceFitAllTime="true"
                        ShowHeader="true">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar2" runat="server">
                                <Items>
                                    <x:Button ID="btn_Add_G_Quarters_Ledger" runat="server" Text="添加" Icon="Add" OnClick="btn_Add_G_Quarters_Ledger_Click">
                                    </x:Button>
                                    <x:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_Del_G_Quarters_Ledger" runat="server" Text="删除选中行" Icon="Delete"
                                        OnClick="btn_Del_G_Quarters_Ledger_Click">
                                    </x:Button>
                                    <x:ToolbarSeparator ID="ToolbarSeparator8" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_Band_Quarters_Ledger" runat="server" Text="清空" Icon="ArrowRotateAnticlockwise"
                                        OnClick="Band_Quarters_Ledger_Click">
                                    </x:Button>
                                    <x:ToolbarFill ID="ToolbarFill2" runat="server">
                                    </x:ToolbarFill>
                                    <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_G_Quarters_Ledger" EnablePostBack="false" runat="server" Text="添加行"
                                        Icon="TableAdd">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:RenderField HeaderText="检查区域" DataField="QuartersLedger_Area" FieldType="String"
                                ColumnID="QuartersLedger_Area">
                                <Editor>
                                    <x:DropDownList ID="QuartersLedger_Area" runat="server" Label="Label">
                                        <x:ListItem Text="华北区域中心" Value="华北区域中心" />
                                        <x:ListItem Text="华南区域中心" Value="华南区域中心" />
                                        <x:ListItem Text="西南区域中心" Value="西南区域中心" />
                                        <x:ListItem Text="东北区域中心" Value="东北区域中心" />
                                        <x:ListItem Text="华东区域中心" Value="华东区域中心" />
                                        <x:ListItem Text="华中区域中心" Value="华中区域中心" />
                                        <x:ListItem Text="西北区域中心" Value="西北区域中心" />
                                        <x:ListItem Text="总部" Value="总部" />
                                    </x:DropDownList>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="经销店名称" DataField="QuartersLedger_DealerName" FieldType="String"
                                Width="110px" ColumnID="QuartersLedger_DealerName">
                                <Editor>
                                    <x:TextBox ID="QuartersLedger_DealerName" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="合作银行" FieldType="String" DataField="QuartersLedger_Bank"
                                Width="110px" ColumnID="QuartersLedger_Bank">
                                <Editor>
                                    <x:TextBox ID="QuartersLedger_Bank" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="品牌" DataField="QuartersLedger_BrandName" FieldType="String"
                                Width="50px" ColumnID="QuartersLedger_BrandName">
                                <Editor>
                                    <x:TextBox ID="QuartersLedger_BrandName" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="总部总账问题(系统、电子总账）" DataField="QuartersLedger_System" FieldType="String"
                                Width="110px" ColumnID="QuartersLedger_System">
                                <Editor>
                                    <%--<x:TextBox ID="QuartersLedger_System" runat="server"  >
                                    </x:TextBox>--%>
                                    <x:TextArea ID="QuartersLedger_System" runat="server" Height="80px" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                             <x:RenderField HeaderText="处理结果" DataField="QuartersLedger_FinancialCenter"
                                FieldType="String" Width="110px" ColumnID="QuartersLedger_FinancialCenter">
                                <Editor>
                                  <%--<x:TextBox ID="QuartersLedger_FinancialCenter" runat="server"  >
                                    </x:TextBox>--%>
                                    <x:TextArea ID="QuartersLedger_FinancialCenter" runat="server" Height="80px" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel4" Title="需持续追踪解决问题" EnableBackgroundColor="true" BoxFlex="1" BoxMargin="0"
                runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" Layout="Fit">
                <Items>
                    <x:Grid ID="G_ContinuousTracking" runat="server" EnableRowNumber="true" Title="需持续追踪解决问题"
                        EnableBackgroundColor="true" AllowCellEditing="true" ClicksToEdit="2" ForceFitAllTime="true">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar3" runat="server">
                                <Items>
                                    <x:Button ID="btn_Add_G_ContinuousTracking" runat="server" Text="添加" Icon="Add" OnClick="btn_Add_G_ContinuousTracking_Click">
                                    </x:Button>
                                    <x:ToolbarSeparator ID="ToolbarSeparator6" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_Del_G_ContinuousTracking" runat="server" Text="删除选择行" Icon="Delete"
                                        OnClick="btn_Del_G_ContinuousTracking_Click">
                                    </x:Button>
                                    <x:ToolbarSeparator ID="ToolbarSeparator9" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_Band_ContinuousTracking" runat="server" Text="清空" Icon="ArrowRotateAnticlockwise"
                                        OnClick="Band_ContinuousTracking_Click">
                                    </x:Button>
                                    <x:ToolbarFill ID="ToolbarFill3" runat="server">
                                    </x:ToolbarFill>
                                    <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_G_ContinuousTracking" EnablePostBack="false" runat="server" Text="添加行"
                                        Icon="TableAdd">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:RenderField HeaderText="检查区域" DataField="ContinuousTracking_Area" FieldType="String"
                                ColumnID="ContinuousTracking_Area">
                                <Editor>
                                    <x:DropDownList ID="ContinuousTracking_Area" runat="server" Label="Label">
                                        <x:ListItem Text="华北区域中心" Value="华北区域中心" />
                                        <x:ListItem Text="华南区域中心" Value="华南区域中心" />
                                        <x:ListItem Text="西南区域中心" Value="西南区域中心" />
                                        <x:ListItem Text="东北区域中心" Value="东北区域中心" />
                                        <x:ListItem Text="华东区域中心" Value="华东区域中心" />
                                        <x:ListItem Text="华中区域中心" Value="华中区域中心" />
                                        <x:ListItem Text="西北区域中心" Value="西北区域中心" />
                                        <x:ListItem Text="总部" Value="总部" />
                                    </x:DropDownList>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="经销店名称" DataField="ContinuousTracking_DealerName" FieldType="String"
                                ColumnID="ContinuousTracking_DealerName">
                                <Editor>
                                    <x:TextBox ID="ContinuousTracking_DealerName" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="合作银行" FieldType="String" DataField="ContinuousTracking_Bank"
                                ColumnID="ContinuousTracking_Bank">
                                <Editor>
                                    <x:TextBox ID="ContinuousTracking_Bank" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="品牌" DataField="ContinuousTracking_BrandName" FieldType="String"
                                ColumnID="ContinuousTracking_BrandName">
                                <Editor>
                                    <x:TextBox ID="ContinuousTracking_BrandName" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="监管员" DataField="ContinuousTracking_SupervisorName" FieldType="String"
                                ColumnID="ContinuousTracking_SupervisorName">
                                <Editor>
                                    <x:TextBox ID="ContinuousTracking_SupervisorName" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="检查问题" DataField="ContinuousTracking_CheckProblem" FieldType="String"
                                ColumnID="ContinuousTracking_CheckProblem">
                                <Editor>
                                    <%-- <x:TextBox ID="ContinuousTracking_CheckProblem" runat="server"  >
                                    </x:TextBox>--%>
                                    <x:TextArea ID="ContinuousTracking_CheckProblem" runat="server" Height="80px" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="历史检查时间" DataField="ContinuousTracking_HistoryTime" FieldType="Date"
                                Width="50px" ColumnID="ContinuousTracking_HistoryTime" RendererArgument="yyyy-MM-dd"
                                Renderer="Date">
                                <Editor>
                                    <x:DatePicker ID="ContinuousTracking_HistoryTime" runat="server" Label="Label">
                                    </x:DatePicker>
                                    <%--<x:TextBox ID="ContinuousTracking_HistoryTime" runat="server"  >
                                    </x:TextBox>--%>
                                </Editor>
                            </x:RenderField>
                             <x:RenderField HeaderText="处理结果" DataField="ContinuousTracking_FinancialCenter"
                                FieldType="String" ColumnID="ContinuousTracking_FinancialCenter">
                                <Editor>
                                   <%-- <x:TextBox ID="ContinuousTracking_FinancialCenter" runat="server"  >
                                    </x:TextBox>--%>
                                    <x:TextArea ID="ContinuousTracking_FinancialCenter" runat="server" Height="80px" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
