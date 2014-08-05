<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionList.aspx.cs"
    Inherits="Citic_Web.InspectionFrequency.InspectionList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询视频追踪</title>
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
                    <x:Form ID="Form2" runat="server" BodyPadding="2px" Title="查询条件" LabelAlign="Right"
                        EnableBackgroundColor="true">
                        <Toolbars>
                            <x:Toolbar runat="server">
                                <Items>
                                    <x:Button runat="server" Text="查询" ID="Btn_Search" Icon="SystemSearch" OnClick="Btn_Search_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Rows>
                            <x:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <x:TextBox ID="txt_Area" runat="server" Label="检查区域" Text="" Width="150px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_Bank" runat="server" Label="合作银行" Text="" Width="150px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_BrandName" runat="server" Label="品牌" Text="" Width="150px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_CreateName" runat="server" Label="检查人员" Text="" Width="150px">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FormRow2" runat="server">
                                <Items>
                                    <x:DatePicker ID="txt_StartTime" runat="server" Label="检查起始日期" Width="150px">
                                    </x:DatePicker>
                                    <x:DatePicker ID="txt_AsTime" runat="server" Label="检查截至日期" Width="150px">
                                    </x:DatePicker>
                                    <x:TextBox ID="txt_DealerName" runat="server" Label="经销店名称" Text="" Width="150px">
                                    </x:TextBox>
                                    <x:DropDownList Label="是否处理" runat="server" Width="150px">
                                        <x:ListItem Text="———请选择———" Value="-1" Selected="true" />
                                        <x:ListItem Text="已处理" Value="0" />
                                        <x:ListItem Text="未处理" Value="1" />
                                    </x:DropDownList>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel" Layout="Fit" BoxFlex="1">
                <Items>
                    <x:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="false">
                        <Tabs>
                            <x:Tab ID="T_InspectionFrequency" runat="server" BodyPadding="0px" Title="Tab1" Layout="Fit">
                                <Items>
                                    <x:Panel ID="Panel6" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                                        Title="Panel" Layout="Fit" BoxFlex="1">
                                        <Toolbars>
                                            <x:Toolbar runat="server">
                                                <Items>
                                                    <x:Button ID="Btn_InspectionFrequency_Update" runat="server" Text="提交处理" Icon="Tick"
                                                        IconAlign="Right" OnClick="InspectionFrequency_Update_Click">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Items>
                                            <x:Grid ID="G_InspectionFrequency" runat="server" Title="" EnableRowNumber="true"
                                                ShowHeader="false" ForceFitAllTime="true" AllowCellEditing="true" ClicksToEdit="1"
                                                DataKeyNames="ID">
                                                <Columns>
                                                    <x:BoundField HeaderText="检查区域" DataField="Area" Width="35px" />
                                                    <x:BoundField HeaderText="经销店名称" DataField="DealerName" />
                                                    <%-- <x:WindowField Width="50px" WindowID="InspectionUpdate" HeaderText="经销店名称" ToolTip="编辑"
                                                        DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataTextField="DealerName"
                                                        DataIFrameUrlFormatString="InspectionUpdate.aspx?ID={0}" DataWindowTitleField="DealerName"
                                                        DataWindowTitleFormatString="编辑 - {0}" />--%>
                                                    <x:BoundField HeaderText="检查人员" DataField="Rummager" Width="60px" />
                                                    <x:BoundField HeaderText="合作银行" DataField="Bank" Width="60px" />
                                                    <x:BoundField HeaderText="品牌" DataField="BrandName" Width="30px" />
                                                    <x:BoundField HeaderText="监管员" DataField="SupervisorName" Width="30px" />
                                                    <x:RenderField Width="100px" ColumnID="MainProblem" DataField="MainProblem" FieldType="String"
                                                        ExpandUnusedSpace="true" HeaderText="检查问题">
                                                        <Editor>
                                                            <x:TextArea ID="txt_MainProblem" runat="server" Label="Label" Readonly="true" Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                    <x:RenderField Width="100px" ColumnID="MainProblem_1_Results" DataField="MainProblem_1_Results"
                                                        FieldType="String" ExpandUnusedSpace="true" HeaderText="汽车/产业金融中心处理结果">
                                                        <Editor>
                                                            <x:TextArea ID="txt_MainProblem_1_Results" runat="server" Height="80px" Label="Label"
                                                                Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                    <x:RenderField Width="100px" ColumnID="MainProblem_2_Results" DataField="MainProblem_2_Results"
                                                        FieldType="String" ExpandUnusedSpace="true" HeaderText="风控部处理结果">
                                                        <Editor>
                                                            <x:TextArea ID="txt_MainProblem_2_Results" runat="server" Height="80px" Label="Label"
                                                                Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                    <x:RenderField Width="100px" ColumnID="MainProblem_3_Results" DataField="MainProblem_3_Results"
                                                        FieldType="String" ExpandUnusedSpace="true" HeaderText="管理中心处理结果">
                                                        <Editor>
                                                            <x:TextArea ID="txt_MainProblem_3_Results" runat="server" Height="80px" Label="Label"
                                                                Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                </Columns>
                                            </x:Grid>
                                        </Items>
                                    </x:Panel>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="T_QuartersLedger" runat="server" BodyPadding="0px" EnableBackgroundColor="true"
                                Title="总部总账问题" Layout="Fit">
                                <Items>
                                    <x:Panel ID="Panel4" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                                        Title="Panel" Layout="Fit" BoxFlex="1">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar1" runat="server">
                                                <Items>
                                                    <x:Button ID="Btn_QuartersLedger_Update" runat="server" Text="提交处理" Icon="Tick" IconAlign="Right"
                                                        OnClick="QuartersLedger_Update_Click">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Items>
                                            <x:Grid ID="G_QuartersLedger" runat="server" Title="总部总账问题" EnableRowNumber="true"
                                                ForceFitAllTime="true" AllowCellEditing="true" ClicksToEdit="1" ShowHeader="false"
                                                DataKeyNames="ID">
                                                <Columns>
                                                    <x:BoundField HeaderText="检查区域" DataField="Area" Width="28px" />
                                                    <x:BoundField HeaderText="经销店名称" DataField="DealerName" />
                                                    <%-- <x:WindowField Width="50px" WindowID="InspectionUpdate" HeaderText="经销店名称" ToolTip="编辑"
                                                        DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataTextField="DealerName"
                                                        DataIFrameUrlFormatString="InspectionUpdate.aspx?ID={0}" DataWindowTitleField="DealerName"
                                                        DataWindowTitleFormatString="编辑 - {0}" />--%>
                                                    <x:BoundField HeaderText="检查人员" DataField="Rummager" Width="60px" />
                                                    <x:BoundField HeaderText="合作银行" DataField="Bank" Width="60px" />
                                                    <x:BoundField HeaderText="品牌" DataField="BrandName" Width="30px" />
                                                    <%-- <x:BoundField HeaderText="总部总账问题(系统、电子总账）" ExpandUnusedSpace="true" DataField="QuartersLedger" />--%>
                                                    <x:RenderField Width="100px" ColumnID="QuartersLedger" DataField="QuartersLedger"
                                                        FieldType="String" ExpandUnusedSpace="true" HeaderText="总部总账问题(系统、电子总账）">
                                                        <Editor>
                                                            <x:TextArea ID="txt_QuartersLedger" runat="server" Label="Label" Text="" Readonly="true">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                    <x:RenderField Width="100px" ColumnID="QuartersLedger_1_Results" DataField="QuartersLedger_1_Results"
                                                        FieldType="String" ExpandUnusedSpace="true" HeaderText="汽车/产业金融中心处理结果">
                                                        <Editor>
                                                            <x:TextArea ID="txt_QuartersLedger_1_Results" runat="server" Height="80px" Label="Label"
                                                                Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                    <x:RenderField Width="100px" ColumnID="QuartersLedger_2_Results" DataField="QuartersLedger_2_Results"
                                                        FieldType="String" ExpandUnusedSpace="true" HeaderText="风控部处理结果">
                                                        <Editor>
                                                            <x:TextArea ID="txt_QuartersLedger_2_Results" runat="server" Height="80px" Label="Label"
                                                                Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                    <x:RenderField Width="100px" ColumnID="QuartersLedger_3_Results" DataField="QuartersLedger_3_Results"
                                                        FieldType="String" ExpandUnusedSpace="true" HeaderText="管理中心处理结果">
                                                        <Editor>
                                                            <x:TextArea ID="txt_QuartersLedger_3_Results" runat="server" Height="80px" Label="Label"
                                                                Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                </Columns>
                                            </x:Grid>
                                        </Items>
                                    </x:Panel>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="T_ContinuousTracking" runat="server" BodyPadding="0px" EnableBackgroundColor="true"
                                Title="需持续追踪解决问题" Layout="Fit">
                                <Items>
                                    <x:Panel ID="Panel5" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                                        Title="Panel" Layout="Fit" BoxFlex="1">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar2" runat="server">
                                                <Items>
                                                    <x:Button ID="Btn_ContinuousTracking_Update" runat="server" Text="提交处理" Icon="Tick"
                                                        IconAlign="Right" OnClick="ContinuousTracking_Update_Click">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Items>
                                            <x:Grid ID="G_ContinuousTracking" runat="server" Title="需持续追踪解决问题" EnableRowNumber="true"
                                                ForceFitAllTime="true" AllowCellEditing="true" ClicksToEdit="1" ShowHeader="false"
                                                DataKeyNames="ID">
                                                <Columns>
                                                    <x:BoundField HeaderText="检查区域" DataField="Area" Width="28px" />
                                                    <x:BoundField HeaderText="经销店名称" DataField="DealerName" />
                                                    <%--<x:WindowField Width="50px" WindowID="InspectionUpdate" HeaderText="经销店名称" ToolTip="编辑"
                                                        DataTextFormatString="{0}" DataIFrameUrlFields="ID" DataTextField="DealerName"
                                                        DataIFrameUrlFormatString="InspectionUpdate.aspx?ID={0}" DataWindowTitleField="DealerName"
                                                        DataWindowTitleFormatString="编辑 - {0}" />--%>
                                                    <x:BoundField HeaderText="检查人员" DataField="Rummager" Width="30px" />
                                                    <x:BoundField HeaderText="合作银行" DataField="Bank" Width="60px" />
                                                    <x:BoundField HeaderText="品牌" DataField="BrandName" Width="30px" />
                                                    <x:BoundField HeaderText="监管员" DataField="SupervisorName" Width="30px" />
                                                    <%--<x:BoundField HeaderText="检查问题" DataField="CheckProblem" ExpandUnusedSpace="true" />--%>
                                                    <x:RenderField Width="100px" ColumnID="CheckProblem" DataField="CheckProblem" FieldType="String"
                                                        ExpandUnusedSpace="true" HeaderText="检查问题">
                                                        <Editor>
                                                            <x:TextArea ID="txt_CheckProblem" runat="server" Readonly="true" Label="Label" Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                    <x:BoundField HeaderText="历史检查时间" DataField="HistoryDate" DataFormatString="{0:yyyy-MM-dd}"
                                                        Width="40px" />
                                                    <x:RenderField Width="100px" ColumnID="Continue_1_Results" DataField="Continue_1_Results"
                                                        FieldType="String" ExpandUnusedSpace="true" HeaderText="汽车/产业金融中心处理结果">
                                                        <Editor>
                                                            <x:TextArea ID="txt_Continue_1_Results" runat="server" Height="80px" Label="Label"
                                                                Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                    <x:RenderField Width="100px" ColumnID="Continue_2_Results" DataField="Continue_2_Results"
                                                        FieldType="String" ExpandUnusedSpace="true" HeaderText="风控部处理结果">
                                                        <Editor>
                                                            <x:TextArea ID="txt_Continue_2_Results" runat="server" Height="80px" Label="Label"
                                                                Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                    <x:RenderField Width="100px" ColumnID="Continue_3_Results" DataField="Continue_3_Results"
                                                        FieldType="String" ExpandUnusedSpace="true" HeaderText="管理中心处理结果">
                                                        <Editor>
                                                            <x:TextArea ID="txt_Continue_3_Results" runat="server" Height="80px" Label="Label"
                                                                Text="">
                                                            </x:TextArea>
                                                        </Editor>
                                                    </x:RenderField>
                                                </Columns>
                                            </x:Grid>
                                        </Items>
                                    </x:Panel>
                                </Items>
                            </x:Tab>
                        </Tabs>
                    </x:TabStrip>
                </Items>
            </x:Panel>
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
