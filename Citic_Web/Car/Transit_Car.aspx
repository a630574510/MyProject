<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transit_Car.aspx.cs" Inherits="Citic_Web.Car.Transit_Car" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>入库申请</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel_Transit" />
    <x:Panel ID="Panel_Transit" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="入库申请" EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" Title="Panel">
                <Items>
                    <x:Form ID="Form2" runat="server" BodyPadding="5px" Title="查询条件" EnableBackgroundColor="true"
                        LabelAlign="Right" LabelWidth="60px">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar2" runat="server" Position="Top">
                                <Items>
                                    <x:Button runat="server" Text="查询" ID="Btn_Search" OnClick="Btn_Search_Click" Icon="SystemSearch">
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
                            <x:FormRow>
                                <Items>
                                    <x:DropDownList ID="ddl_Dealer" runat="server" Label="经销商" Width="200px" Required="true"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddl_Dealer_SelectedIndexChanged">
                                    </x:DropDownList>
                                    <x:DropDownList ID="DDL_Bank" runat="server" Label="合作银行" Width="200px" Resizable="true"
                                        AutoPostBack="true" OnSelectedIndexChanged="DDL_Bank_SelectedIndexChanged">
                                    </x:DropDownList>
                                    <x:DropDownList ID="DDL_Number_Order" runat="server" Label="汇票号" ShowLabel="true"
                                        Width="200px" AutoPostBack="false" Resizable="true" EnableEdit="true">
                                    </x:DropDownList>
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <x:TextBox ID="txt_Vin" runat="server" Label="车架号" Text="" ShowLabel="true" Width="200px"
                                        EmptyText="输入多个车架请用英文,号分割">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_EngineNo" runat="server" Label="发动机" Text="" ShowLabel="true"
                                        Width="200px" EmptyText="输入多个发动机请用英文,号分割">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_QualifiedNo" runat="server" Label="合格证" Text="" ShowLabel="true"
                                        Width="200px" EmptyText="输入多个合格证请用英文,号分割">
                                    </x:TextBox>
                                    <%-- <x:Label ID="lbl_Cooperation_BrandName" runat="server" CssStyle="color:red;" Label="合作品牌"
                                Text="">
                            </x:Label>--%>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel2" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Items>
                    <x:Grid ID="G_Car_Detail" runat="server" EnableRowNumber="true" Title="车辆详细信息" EnableBackgroundColor="true"
                        AllowCellEditing="true" ClicksToEdit="1" DataKeyNames="Vin,KeyCount" EnableTextSelection="true">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button ID="Btn_Again_Bind" runat="server" Text="提交入库" OnClick="Btn_Again_Bind_Click"
                                        Icon="Tick" IconAlign="Right" Enabled="true">
                                    </x:Button>
                                    <x:Button ID="Btn_GD" runat="server" Text="提交光大入库" OnClick="Btn_GD_Click" Icon="Tick"
                                        IconAlign="Right" Enabled="true">
                                    </x:Button>
                                    <x:Button ID="Btn_ZX" runat="server" Text="提交中信入库" OnClick="Btn_ZX_Click" Icon="Tick"
                                        IconAlign="Right" Enabled="true">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:RenderCheckField ColumnID="Statu" DataField="Statu" HeaderText="是否入库" />
                            <x:RenderField HeaderText="钥匙数" DataField="KeyCount" FieldType="Int" Width="50px"
                                ColumnID="KeyCount" TextAlign="Center">
                                <Editor>
                                    <x:DropDownList ID="txtKeyCount" runat="server" Label="Label">
                                        <x:ListItem Text="0" Value="0" />
                                        <x:ListItem Text="1" Value="1" />
                                        <x:ListItem Text="2" Value="2" />
                                        <x:ListItem Text="3" Value="3" />
                                        <x:ListItem Text="4" Value="4" />
                                        <x:ListItem Text="5" Value="5" />
                                    </x:DropDownList>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="合格证发证日期" DataField="QualifiedNoDate" Renderer="Date" RendererArgument="{0:yyyy-MM-dd}"
                                FieldType="String" Width="110px" ColumnID="QualifiedNoDate" TextAlign="Center"
                                Hidden="true">
                                <Editor>
                                    <x:DatePicker ID="dpIssueDate" runat="server" Readonly="true">
                                    </x:DatePicker>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="汇票号" DataField="DraftNo" FieldType="String" Width="110px"
                                ColumnID="DraftNo" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtDraftNo" runat="server" Readonly="true">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="车辆型号" FieldType="String" DataField="CarModel" Width="110px"
                                ColumnID="CarModel" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtCarModel" runat="server" Readonly="false">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="颜色" DataField="CarColor" FieldType="String" Width="50px"
                                ColumnID="CarColor" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtCarColour" runat="server" Readonly="false">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="发动机号" DataField="EngineNo" FieldType="String" Width="110px"
                                ColumnID="EngineNo" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtEngineNo" runat="server" Readonly="false">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="车架号" DataField="Vin" FieldType="String" Width="110px"
                                ColumnID="Vin" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtVin" runat="server" Readonly="true">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="合格证号" DataField="QualifiedNo" FieldType="String" Width="110px"
                                ColumnID="QualifiedNo" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtQualifiedNo" runat="server" Readonly="true">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="钥匙号" DataField="KeyNumber" FieldType="String" Width="50px"
                                ColumnID="KeyNumber" TextAlign="Center" Hidden="true">
                                <Editor>
                                    <x:TextBox ID="txtKeyNumber" runat="server" Readonly="true">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="车辆金额(元)" DataField="CarCost" FieldType="Float" Width="110px"
                                ColumnID="CarCost" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txtCarCost" runat="server" Readonly="true">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField HeaderText="备注" DataField="Remarks" FieldType="String" Width="110px"
                                ColumnID="Remarks" TextAlign="Center">
                                <Editor>
                                    <x:TextArea ID="txtRemarks" runat="server" Height="80px" Label="Label" Text="">
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
