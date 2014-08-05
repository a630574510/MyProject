<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete_Car.aspx.cs" Inherits="Citic_Web.Car.Delete_Car" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>车辆删除</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start">
        <Items>
            <x:Panel ID="Panel2" runat="server" ShowBorder="false" ShowHeader="false" Title="Panel"
                Width="100px">
                <Items>
                    <x:Form ID="Form2" runat="server" BodyPadding="3px" ShowHeader="false" ShowBorder="false"
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
                            <x:FormRow>
                                <Items>
                                    <x:DropDownList ID="ddl_Dealer" runat="server" Label="经销商" Width="200px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddl_Dealer_SelectedIndexChanged" Resizable="true" EnableEdit="true"
                                        ForceSelection="false">
                                    </x:DropDownList>
                                    <x:Label ID="lbl_Cooperation_Bank" runat="server" Label="合作银行" Text="" Width="230px">
                                    </x:Label>
                                    <x:TextBox ID="txt_QualifiedNo" runat="server" Label="合格证" Text="" ShowLabel="true"
                                        Width="200px" EmptyText="合格证请输入最少为5位数">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <x:TextBox ID="txt_Vin" runat="server" Label="车架号" Text="" ShowLabel="true" Width="200px"
                                        EmptyText="车架号请输入最少为5位数">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_Number_Order" runat="server" Label="汇票号" Text="" ShowLabel="true"
                                        EmptyText="汇票请输入全部" Width="200px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_EngineNo" runat="server" Label="发动机" Text="" ShowLabel="true"
                                        EmptyText="发动机请输入最少为5位数" Width="200px">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false"
                Title="Panel" Layout="Fit" BoxFlex="2">
                <Items>
                    <x:Grid ID="G_Car_List" Title="表格" ShowBorder="false" ShowHeader="false" AutoHeight="false"
                        SortDirection="ASC" runat="server" DataKeyNames="Vin,DraftNo" EnableRowNumber="true"
                        EnableCheckBoxSelect="true" OnRowDataBound="G_Car_List_RowDataBound" EnableTextSelection="true">
                        <Toolbars>
                            <x:Toolbar runat="server">
                                <Items>
                                    <x:Button ID="btn_Logic_Del" runat="server" Icon="Delete" Text="逻辑删除" OnClick="btn_Logic_Del_Click"
                                        Visible="false">
                                    </x:Button>
                                    <x:Button ID="btn_Physics_Del" runat="server" Icon="Delete" Text="物理删除" OnClick="btn_Physics_Del_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:BoundField HeaderText="车架号" DataField="Vin" DataToolTipField="Vin" />
                            <x:BoundField HeaderText="企业名称" DataField="DealerName" DataToolTipField="DealerName" />
                            <x:BoundField HeaderText="汇票号" DataField="DraftNo" DataToolTipField="DraftNo" />
                            <x:BoundField HeaderText="合格证" DataField="QualifiedNo" DataToolTipField="QualifiedNo" />
                            <x:BoundField HeaderText="钥匙数" Width="50px" SortField="KeyCount" DataField="KeyCount" />
                            <x:BoundField HeaderText="颜色" DataField="CarColor" Width="50px" />
                            <x:BoundField HeaderText="发动机号" DataField="EngineNo" />
                            <x:BoundField HeaderText="型号" DataField="CarModel" />
                            <x:BoundField HeaderText="钥匙号" DataField="KeyNumber" />
                            <x:BoundField HeaderText="车辆金额(元)" DataField="CarCost" />
                            <x:BoundField HeaderText="回款金额(元)" DataField="ReturnCost" />
                            <x:BoundField HeaderText="状态" DataField="Statu" Width="50px" />
                            <x:BoundField HeaderText="库名" DataField="StorageName" />
                            <x:BoundField HeaderText="备注" DataField="Remarks" />
                            <x:BoundField HeaderText="合格证发证日期" DataField="QualifiedNoDate" DataFormatString="{0:yyyy-MM-dd}" />
                            <x:BoundField HeaderText="入库日期" DataField="TransitTime" DataFormatString="{0:yyyy-MM-dd}" />
                            <x:BoundField HeaderText="移库日期" DataField="MoveTime" DataFormatString="{0:yyyy-MM-dd}" />
                            <x:BoundField HeaderText="出库日期" DataField="OutTime" DataFormatString="{0:yyyy-MM-dd}" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
