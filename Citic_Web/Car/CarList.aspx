<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarList.aspx.cs" Inherits="Citic_Web.Car.CarList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>全部车辆</title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="panel_Container" />
    <x:Panel ID="panel_Container" Title="综合查询" runat="server" BodyPadding="0px" ShowBorder="true"
        Layout="VBox" BoxConfigAlign="Stretch" ShowHeader="true" EnableBackgroundColor="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" ShowBorder="false" ShowHeader="false" Title="Panel">
                <Items>
                    <x:Form ID="Form2" runat="server" BodyPadding="0px" ShowHeader="false" ShowBorder="false"
                        EnableBackgroundColor="true" LabelAlign="Right" LabelWidth="90px">
                        <Toolbars>
                            <x:Toolbar runat="server">
                                <Items>
                                    <x:Button runat="server" Text="查询" ID="Btn_Search" OnClick="Btn_Search_Click" Icon="SystemSearch">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Rows>
                            <x:FormRow>
                                <Items>
                                    <x:DropDownList ID="ddl_Dealer" runat="server" Label="经销商" Width="250px" Required="true"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddl_Dealer_SelectedIndexChanged"
                                        Resizable="true">
                                    </x:DropDownList>
                                    <x:Label ID="lbl_Cooperation_Bank" runat="server" CssStyle="color:red;" Label="合作银行"
                                        Text="" Width="200px">
                                    </x:Label>
                                    <x:Label ID="lbl_BrandName" runat="server" CssStyle="color:red;" Label="合作品牌" Text=""
                                        Width="200px">
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
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FormRow2" runat="server">
                                <Items>
                                    <x:DatePicker ID="dp_Release_Begin" runat="server" Label="起初释放日期" ShowLabel="true"
                                        Width="200px">
                                    </x:DatePicker>
                                    <x:DatePicker ID="dp_Release_End" runat="server" Label="至释放日期" ShowLabel="true" Width="200px">
                                    </x:DatePicker>
                                    <x:TextBox ID="txt_QualifiedNo" runat="server" Label="合格证" Text="" ShowLabel="true"
                                        Width="200px" EmptyText="输入多个合格证请用英文,号分割">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FormRow3" runat="server">
                                <Items>
                                    <x:DatePicker ID="dp_Access_Begin" runat="server" Label="起初入库日期" ShowLabel="true"
                                        Width="200px">
                                    </x:DatePicker>
                                    <x:DatePicker ID="dp_Access_End" runat="server" Label="至入库日期" ShowLabel="true" Width="200px">
                                    </x:DatePicker>
                                    <x:DropDownList ID="ddl_Statu" runat="server" Label="状态" Width="200px">
                                        <x:ListItem Text="———请选择———" Value="-1" Selected="true" />
                                        <x:ListItem Text="出库" Value="0" />
                                        <x:ListItem Text="在库" Value="1" />
                                        <x:ListItem Text="移动" Value="2" />
                                        <x:ListItem Text="在途" Value="3" />
                                        <x:ListItem Text="申请中" Value="4" />
                                    </x:DropDownList>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel1" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                BoxFlex="1" Layout="HBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start"
                BoxConfigChildMargin="0 5 0 0" CssStyle="padding-top:5px">
                <Items>
                    <x:Panel ID="Panel3" EnableBackgroundColor="true" BoxFlex="1" runat="server" ShowBorder="false"
                        ShowHeader="false" Layout="Fit">
                        <Items>
                            <x:Grid ID="grid_List" Title="表格" PageSize="10" ShowBorder="true" ShowHeader="false"
                                AutoHeight="true" SortDirection="ASC" AllowPaging="true" AllowSorting="true" IsDatabasePaging="true"
                                runat="server" DataKeyNames="Vin,DraftNo" OnPageIndexChange="grid_List_PageIndexChange"
                                EnableRowNumber="false" OnRowDataBound="grid_List_RowDataBound" EnableHeaderMenu="false"
                                EnableBackgroundColor="true" EnableRowSelectEvent="false" EnableColumnLines="true"
                                EnableTextSelection="true">
                                <Toolbars>
                                    <x:Toolbar ID="Toolbar1" runat="server">
                                        <Items>
                                            <x:Button ID="Btn_Batch_OutBound" runat="server" Text="批量出库申请" Enabled="false" Hidden="true"
                                                OnClick="Btn_Car_All">
                                            </x:Button>
                                            <x:Button ID="Btn_Store_100" OnClick="Btn_Car_All" runat="server" Text="在库-100" ToolTip="<span style='color:Red'>在库车辆最新100条</span>">
                                            </x:Button>
                                            <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server">
                                            </x:ToolbarSeparator>
                                            <x:Button ID="Btn_Move_100" OnClick="Btn_Car_All" runat="server" Text="移动-100" ToolTip="<span style='color:Red'>移动车辆最新100条</span>">
                                            </x:Button>
                                            <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server">
                                            </x:ToolbarSeparator>
                                            <x:Button ID="Btn_OutBound_100" OnClick="Btn_Car_All" runat="server" Text="出库-100"
                                                ToolTip="<span style='color:Red'>出库车辆最新100条</span>">
                                            </x:Button>
                                            <x:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                            </x:ToolbarSeparator>
                                            <x:Button ID="Btn_Transit_100" OnClick="Btn_Car_All" runat="server" Text="在途-100"
                                                ToolTip="<span style='color:Red'>在途车辆最新100条</span>">
                                            </x:Button>
                                            <x:ToolbarSeparator ID="ToolbarSeparator5" runat="server">
                                            </x:ToolbarSeparator>
                                            <x:Button ID="Btn_ApplyFor_100" OnClick="Btn_Car_All" runat="server" Text="申请中-100"
                                                ToolTip="<span style='color:Red'>申请中车辆最新100条</span>">
                                            </x:Button>
                                            <x:ToolbarSeparator ID="ToolbarSeparator10" runat="server">
                                            </x:ToolbarSeparator>
                                            <x:ToolbarFill ID="ToolbarFill1" runat="server">
                                            </x:ToolbarFill>
                                            <x:ToolbarSeparator ID="ToolbarSeparator11" runat="server">
                                            </x:ToolbarSeparator>
                                            <x:Button ID="Btn_Store_All" OnClick="Btn_Car_All" runat="server" Text="在库-全部" ToolTip="<span style='color:Red'>在库全部车辆</span>">
                                            </x:Button>
                                            <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                            </x:ToolbarSeparator>
                                            <x:Button ID="Btn_Move_All" OnClick="Btn_Car_All" runat="server" Text="移动-全部" ToolTip="<span style='color:Red'>移动全部车辆</span>">
                                            </x:Button>
                                            <x:ToolbarSeparator ID="ToolbarSeparator6" runat="server">
                                            </x:ToolbarSeparator>
                                            <x:Button ID="Btn_OutBound_All" OnClick="Btn_Car_All" runat="server" Text="出库-全部"
                                                ToolTip="<span style='color:Red'>出库全部车辆</span>">
                                            </x:Button>
                                            <x:ToolbarSeparator ID="ToolbarSeparator7" runat="server">
                                            </x:ToolbarSeparator>
                                            <x:Button ID="Btn_Transit_All" OnClick="Btn_Car_All" runat="server" Text="在途-全部"
                                                ToolTip="<span style='color:Red'>在途全部车辆</span>">
                                            </x:Button>
                                            <x:ToolbarSeparator ID="ToolbarSeparator8" runat="server">
                                            </x:ToolbarSeparator>
                                            <x:Button ID="Btn_ApplyFor_All" OnClick="Btn_Car_All" runat="server" Text="申请中-全部"
                                                ToolTip="<span style='color:Red'>申请中全部车辆</span>">
                                            </x:Button>
                                        </Items>
                                    </x:Toolbar>
                                </Toolbars>
                                <Columns>
                                    <x:BoundField HeaderText="企业名称" DataField="DealerName" DataToolTipField="DealerName"
                                        TextAlign="Center" />
                                    <x:BoundField HeaderText="汇票号" DataField="DraftNo" DataToolTipField="DraftNo" TextAlign="Center" />
                                    <x:BoundField HeaderText="合格证发证日期" DataField="QualifiedNoDate" DataFormatString="{0:yyyy-MM-dd}"
                                        TextAlign="Center" />
                                    <x:BoundField HeaderText="型号" DataField="CarModel" TextAlign="Center" />
                                    <x:BoundField HeaderText="颜色" DataField="CarColor" Width="50px" TextAlign="Center" />
                                    <x:BoundField HeaderText="发动机号" DataField="EngineNo" TextAlign="Center" />
                                    <x:WindowField WindowID="W_Update_Car" HeaderText="车架号" DataTextField="Vin" ToolTip="编辑"
                                        DataIFrameUrlFields="BankID,DealerID,Vin" DataIFrameUrlFormatString="Update_Car.aspx?BankID={0}&DealerID={1}&Vin={2}" />
                                    <x:BoundField HeaderText="合格证" DataField="QualifiedNo" DataToolTipField="QualifiedNo"
                                        TextAlign="Center" />
                                    <x:BoundField HeaderText="车辆金额(元)" DataField="CarCost" TextAlign="Center" />
                                    <x:BoundField HeaderText="钥匙数" Width="50px" SortField="KeyCount" DataField="KeyCount"
                                        TextAlign="Center" />
                                    <x:BoundField HeaderText="入库日期" DataField="TransitTime" DataFormatString="{0:yyyy-MM-dd}"
                                        TextAlign="Center" />
                                    <x:BoundField HeaderText="状态" DataField="Statu" Width="50px" TextAlign="Center" />
                                    <x:BoundField HeaderText="移库日期" DataField="MoveTime" DataFormatString="{0:yyyy-MM-dd}"
                                        TextAlign="Center" />
                                    <x:BoundField HeaderText="释放日期" DataField="OutTime" DataFormatString="{0:yyyy-MM-dd}"
                                        TextAlign="Center" />
                                    <%-- <x:BoundField HeaderText="钥匙号" DataField="KeyNumber" TextAlign="Center" />
                                    <x:BoundField HeaderText="回款金额(元)" DataField="ReturnCost" TextAlign="Center" />
                                    <x:BoundField HeaderText="库名" DataField="StorageName" TextAlign="Center" />
                                    <x:BoundField HeaderText="备注" DataField="Remarks" TextAlign="Center" />--%>
                                </Columns>
                            </x:Grid>
                        </Items>
                    </x:Panel>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    <x:Window ID="W_Update_Car" Title="修改车辆" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
        EnableMaximize="true" Target="Top" EnableResize="true" runat="server" IsModal="true"
        Width="700px" EnableConfirmOnClose="true" Height="500px">
    </x:Window>
    </form>
</body>
</html>
