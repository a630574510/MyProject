<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutBound_Car.aspx.cs" Inherits="Citic_Web.Car.OutBound_Car" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>出库申请</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel_OutBound" />
    <x:Panel ID="Panel_OutBound" Title="出库申请" runat="server" BodyPadding="0px" ShowBorder="false"
        ShowHeader="false" EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch">
        <Items>
            <x:Form ID="Form2" Title="查询条件" ShowBorder="true" BodyPadding="5px" EnableBackgroundColor="true"
                ShowHeader="true" runat="server" LabelAlign="Right" LabelWidth="60px" Height="110px">
                <Toolbars>
                    <x:Toolbar runat="server" TableColspan="4">
                        <Items>
                            <x:Button runat="server" Text="查询" ID="Btn_Search" OnClick="Btn_Search_Click" Icon="SystemSearch">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Rows>
                    <x:FormRow>
                        <Items>
                            <x:DropDownList ID="ddl_Dealer" runat="server" Label="经销商" Width="250px" AutoPostBack="true"
                                OnSelectedIndexChanged="ddl_Dealer_SelectedIndexChanged" Required="true" Resizable="true">
                            </x:DropDownList>
                            <x:DropDownList ID="DDL_Bank" runat="server" Label="合作银行" Resizable="true" Width="250px"
                                AutoPostBack="true" OnSelectedIndexChanged="DDL_Bank_SelectedIndexChanged">
                            </x:DropDownList>
                            <x:Label ID="lbl_Cooperation_BrandName" runat="server" CssStyle="color:red" Label="合作品牌"
                                Text="" Width="250px">
                            </x:Label>
                        </Items>
                    </x:FormRow>
                    <x:FormRow ID="FormRow1" runat="server">
                        <Items>
                            <x:TextBox ID="txt_Vin" runat="server" Label="车架号" Text="" ShowLabel="true" Width="200px"
                                EmptyText="输入多个车架请用英文,号分割">
                            </x:TextBox>
                            <x:TextBox ID="txt_Number_Order" runat="server" Label="汇票号" Text="" ShowLabel="true"
                                Width="200px">
                            </x:TextBox>
                            <x:TextBox ID="txt_EngineNo" runat="server" Label="发动机" Text="" ShowLabel="true"
                                Width="200px" EmptyText="输入多个发动机请用英文,号分割">
                            </x:TextBox>
                            <x:TextBox ID="txt_QualifiedNo" runat="server" Label="合格证" Text="" ShowLabel="true"
                                Width="200px" EmptyText="输入多个合格证请用英文,号分割">
                            </x:TextBox>
                        </Items>
                    </x:FormRow>
                </Rows>
            </x:Form>
            <x:Panel ID="Panel2" ShowBorder="True" ShowHeader="false" BoxFlex="1" Layout="Fit"
                runat="server">
                <Items>
                    <x:Grid ID="G_Car_Removal" runat="server" EnableCheckBoxSelect="true" CheckBoxSelectOnly="true"
                        AutoScroll="true" EnableRowNumber="true" PageSize="15" AllowPaging="true" Title="车辆详细信息"
                        EnableBackgroundColor="true" DataKeyNames="Vin" OnPageIndexChange="G_Car_Removal_Page"
                        EnableTextSelection="true" AllowCellEditing="true" ClicksToEdit="1">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar2" runat="server">
                                <Items>
                                    <x:Button ID="Btn_Up_Removal" runat="server" Text="批量申请出库" OnClick="Btn_Up_Removal_Click"
                                        ToolTip="<span style='color:Red'>请注意填写回款金额</span>" Icon="Tick" IconAlign="Right">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:RenderCheckField ColumnID="Statu" HeaderText="" Width="20px" />
                            <x:BoundField HeaderText="合格证发证日期" DataField="QualifiedNoDate" DataFormatString="{0:yyyy-MM-dd}"
                                TextAlign="Center" Hidden="true" />
                            <x:BoundField HeaderText="入库日期" DataField="TransitTime" DataFormatString="{0:yyyy-MM-dd}"
                                TextAlign="Center" Hidden="true" />
                            <x:BoundField HeaderText="汇票号" DataField="DraftNo" Width="110px" ColumnID="DraftNo"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="车辆型号" DataField="CarModel" Width="110px" ColumnID="CarModel"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="颜色" DataField="CarColor" Width="50px" ColumnID="CarColor"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="发动机号" DataField="EngineNo" Width="110px" ColumnID="EngineNo"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="车架号" DataField="Vin" Width="110px" ColumnID="Vin" TextAlign="Center" />
                            <x:RenderField HeaderText="回款金额(元)" ColumnID="ReturnCost" DataField="ReturnCost"
                                Width="100px" TextAlign="Center">
                                <Editor>
                                    <x:TextBox ID="txt_ReturnCost" runat="server">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:BoundField HeaderText="合格证号" DataField="QualifiedNo" Width="110px" ColumnID="QualifiedNo"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="钥匙" DataField="KeyCount" Width="50px" ColumnID="KeyCount"
                                TextAlign="Center" Hidden="true" />
                            <x:BoundField HeaderText="车辆金额(元)" DataField="CarCost" Width="110px" ColumnID="CarCost"
                                TextAlign="Center" />
                            <x:BoundField HeaderText="备注" DataField="Remarks" Width="110px" ColumnID="Remarks"
                                TextAlign="Center" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
    <script language="javascript" type="text/javascript">
        var gridClientID = '<%= G_Car_Removal.ClientID %>';

        function registerSelectEvent() {
            var grid = X(gridClientID);
            grid.el.set({ 'data-event-click-registered': true });

            grid.el.select('.x-grid-tpl input').on('click', function (evt, el) {
                el.select();
            });
        }
        function onReady() {
            var grid = X(gridClientID);

            grid.on('viewready', function () {
                registerSelectEvent();
            });
        }

        function onAjaxReady() {
            registerSelectEvent();
        }
    </script>
</body>
</html>
