<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_Car.aspx.cs" Inherits="Citic_Web.Car.Add_Car" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>车辆添加</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="P_Pledge_Information" />
    <x:Panel ID="P_Pledge_Information" Title="质押物信息" runat="server" EnableBackgroundColor="true"
        BodyPadding="5px" ShowBorder="true" ShowHeader="True" BoxConfigAlign="Stretch"
        Layout="VBox">
        <Items>
            <x:Form ID="Form2" Title="添加条件" ShowBorder="true" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="False" runat="server" LabelAlign="Right" LabelWidth="100px" Height="60px">
                <Rows>
                    <x:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <x:DropDownList ID="DDL_Company_Name" runat="server" Label="经销商" AutoPostBack="true"
                                ShowLabel="true" Width="250px" OnSelectedIndexChanged="DDL_Company_Name_Changed"
                                Resizable="true">
                            </x:DropDownList>
                            <x:DropDownList ID="DDL_Bank" runat="server" Label="合作银行" AutoPostBack="true" Resizable="true"
                                OnSelectedIndexChanged="DDL_Bank_SelectedIndexChanged">
                            </x:DropDownList>
                            <%--<x:Label ID="lbl_Cooperation_Bank" runat="server" Label="合作银行" Text="" CssStyle="color:red;">
                            </x:Label>--%>
                            <x:DropDownList ID="DDL_Number_Order" runat="server" Label="汇票号" ShowLabel="true"
                                Width="230px" OnSelectedIndexChanged="DDL_DraftNo_Changed" AutoPostBack="true"
                                Resizable="true" EnableEdit="true">
                            </x:DropDownList>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow2" runat="server">
                        <Items>
                            <x:FileUpload ID="FileExcel" Label="车辆导入路径" ShowLabel="true" runat="server" AutoPostBack="true"
                                Width="180px" OnFileSelected="FileExcel_FileSelected">
                            </x:FileUpload>
                            <x:Label ID="lbl_BeginTime" runat="server" Label="开票日期" Text="">
                            </x:Label>
                            <x:Label ID="lbl_EndTime" runat="server" Label="到期日期" Text="">
                            </x:Label>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Panel ID="P_Detail" ShowBorder="True" ShowHeader="false" runat="server" Title="基本信息"
                Layout="Fit" BoxFlex="1">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:Button ID="btn_Add_Car" OnClick="btn_Add_Car_Clike" runat="server" Text="确定添加"
                                Icon="Add">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server" Hidden="true">
                            </x:ToolbarSeparator>
                            <x:Button ID="btn_Checking_Car" runat="server" Text="信息验证" Icon="ArrowRefresh" OnClick="btn_Add_Car_Clike"
                                Hidden="true">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator4" runat="server" Hidden="true">
                            </x:ToolbarSeparator>
                            <x:Button ID="btn_Add_Table" EnablePostBack="false" runat="server" Text="添加行" Icon="TableAdd"
                                Hidden="true">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator8" runat="server">
                            </x:ToolbarSeparator>
                            <x:Button ID="btn_Delete_Car" runat="server" Text="删除选中行" Icon="Delete" OnClick="btn_Delete_Car_Clike">
                            </x:Button>
                            <x:ToolbarSeparator ID="ToolbarSeparator9" runat="server">
                            </x:ToolbarSeparator>
                            <x:HyperLink ID="HyperLink1" runat="server" Label="Label" NavigateUrl="../Confirmation/模版文件/质押车入库导入明细表.xls"
                                Target="_blank" Text="下载导入车辆模版">
                            </x:HyperLink>
                            <x:ToolbarFill ID="ToolbarFill2" runat="server">
                            </x:ToolbarFill>
                            <x:ToolbarSeparator ID="ToolbarSeparator7" runat="server" Hidden="true">
                            </x:ToolbarSeparator>
                            <x:ToolbarText ID="TT_CarCountMoney" runat="server" Text="车辆总额：0" Hidden="true">
                            </x:ToolbarText>
                            <x:ToolbarSeparator ID="ToolbarSeparator6" runat="server" Hidden="true">
                            </x:ToolbarSeparator>
                            <x:ToolbarText ID="TT_DraftNotMoney" runat="server" Hidden="true">
                            </x:ToolbarText>
                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server" Hidden="true">
                            </x:ToolbarSeparator>
                            <x:ToolbarText ID="TT_DraftCarCountMoney" runat="server" Hidden="true">
                            </x:ToolbarText>
                            <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server" Hidden="true">
                            </x:ToolbarSeparator>
                            <x:ToolbarText ID="TT_DraftMoney" runat="server" Hidden="true">
                            </x:ToolbarText>
                            <x:ToolbarSeparator ID="ToolbarSeparator5" runat="server" Hidden="true">
                            </x:ToolbarSeparator>
                            <x:DropDownList ID="dll_Add_Table_Number" runat="server" Label="行数" ShowLabel="true"
                                Width="50px" Visible="false">
                                <x:ListItem Selected="true" Text="1行" Value="1" />
                                <x:ListItem Selected="true" Text="2行" Value="2" />
                                <x:ListItem Selected="true" Text="5行" Value="5" />
                                <x:ListItem Selected="true" Text="10行" Value="10" />
                            </x:DropDownList>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="G_Car_Detail" runat="server" EnableCheckBoxSelect="true" EnableRowNumber="true"
                        Title="车辆详细信息" EnableBackgroundColor="true" AllowCellEditing="true"
                        ClicksToEdit="1" DataKeyNames="CarCost" OnRowCommand="G_Car_Detail_RowCommand" 
                        EnableColumnLines="true" EmptyText="<span style='color:Red;font-size:21px'>提示：车架号和车辆金额必须填写</br>车架号只能输入大写英文字母和数字</br>车辆金额为数字类型，输入特殊字符自动变成0</br>当出现错误提示，请检查是否输入特殊字符</span>">
                        <Columns>
                            <x:RenderField HeaderText="合格证发证日期" DataField="IssueDate"
                                FieldType="String" Width="110px" ColumnID="IssueDate" TextAlign="Center">
                                <Editor>
                                    <%--<x:DatePicker ID="dpIssueDate" runat="server">
                                    </x:DatePicker>--%>
                                     <x:TextBox ID="txtIssueDate" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="车辆型号" FieldType="String" DataField="CarModel" Width="110px"
                                ColumnID="CarModel" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtCarModel" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="车辆分类" FieldType="String" DataField="CarClass" Width="110px"
                                ColumnID="CarClass" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtCarClass" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="排量" FieldType="String" DataField="Displacement" Width="50px"
                                ColumnID="Displacement" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtDisplacement" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="颜色" DataField="CarColour" FieldType="String" Width="50px"
                                ColumnID="CarColour" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtCarColour" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="发动机号" DataField="EngineNo" FieldType="String" Width="110px"
                                ColumnID="EngineNo" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtEngineNo" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="车架号" DataField="Vin" FieldType="String" Width="110px"
                                ColumnID="Vin" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtVin" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="合格证号" DataField="QualifiedNo" FieldType="String" Width="110px"
                                ColumnID="QualifiedNo" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtQualifiedNo" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="钥匙号" DataField="KeyNumber" FieldType="String" Width="50px"
                                ColumnID="KeyNumber" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtKeyNumber" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="车辆金额(元)" DataField="CarCost" FieldType="Float" Width="110px"
                                ColumnID="CarCost" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtCarCost" runat="server" CompareType="Float">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="备注" DataField="Remark" FieldType="String" Width="110px"
                                ColumnID="Remark" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtRemark" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:ImageField HeaderText="验证" ColumnID="imgAction" Hidden="true" />
                            <x:LinkButtonField HeaderText="删除行" ConfirmText="你确定要删除此行吗？" ConfirmTarget="Top"
                                CommandName="Delete" Icon="Delete" Hidden="true" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
