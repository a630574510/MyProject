<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Electron_Ledger.aspx.cs"
    Inherits="Citic_Web.Ledger.Electron_Ledger" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="false" Title="" EnableBackgroundColor="true"
            Layout="Fit">
            <Toolbars>
                <x:Toolbar ID="Toolbar2" runat="server">
                    <Items>
                        <x:Button ID="btn_BuildExcel" runat="server" Text="生成Excel" OnClick="btn_BuildExcel_Click" Icon="PageWhiteExcel"></x:Button>
                        <x:HyperLink ID="hl_ExportExcel" runat="server" Label="" NavigateUrl="" Target="_blank" Text="导出Excel"></x:HyperLink>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Grid ID="grid_List" runat="server" EnableCheckBoxSelect="false" EnableRowNumber="false" EnableBackgroundColor="true"
                    ShowHeader="false" AllowPaging="true" EnableTextSelection="true" IsDatabasePaging="true" PageIndex="0" PageSize="20"
                    OnRowDataBound="grid_List_RowDataBound" OnPageIndexChange="grid_List_PageIndexChange" DataKeyNames="DraftNo,Vin">
                    <Columns>
                        <x:BoundField HeaderText="序号" DataField="row" ColumnID="row" Width="40px" />
                        <x:BoundField HeaderText="质押号" DataField="PledgeNo" ColumnID="PledgeNo" />
                        <x:BoundField HeaderText="保险金账号" DataField="GuaranteeNo" Width="150px" ColumnID="GuaranteeNo" />
                        <x:BoundField HeaderText="票号" DataField="DraftNo" ColumnID="DraftNo" />
                        <x:BoundField HeaderText="开票日期" DataField="BeginTime" Width="80px" ColumnID="BeginTime" />
                        <x:BoundField HeaderText="到期日期" DataField="EndTime" Width="80px" ColumnID="EndTime" />
                        <x:BoundField HeaderText="开票金额" DataField="DarftMoney" Width="70px" ColumnID="DarftMoney" />
                        <x:BoundField HeaderText="合格证发证日期" DataField="QualifiedNoDate" Width="100px" ColumnID="QualifiedNoDate" />
                        <x:BoundField HeaderText="车辆型号" DataField="CarModel" Width="70px" ColumnID="CarModel" />
                        <x:BoundField HeaderText="车辆分类" DataField="CarClass" Width="80px" ColumnID="CarClass" />
                        <x:BoundField HeaderText="排量" DataField="Displacement" Width="80px" ColumnID="Displacement" />
                        <x:BoundField HeaderText="颜色" DataField="CarColor" Width="50px" ColumnID="CarColor" />
                        <x:BoundField HeaderText="发动机号" DataField="EngineNo" Width="80px" ColumnID="EngineNo" />
                        <x:BoundField HeaderText="车架号" DataField="Vin" Width="150px" ColumnID="Vin" />
                        <x:BoundField HeaderText="合格证号" DataField="QualifiedNo" Width="150px" ColumnID="QualifiedNo" />
                        <x:BoundField HeaderText="钥匙号" DataField="KeyNumber" Width="150px" ColumnID="KeyNumber" />
                        <x:BoundField HeaderText="车辆金额" DataField="CarCost" Width="60px" ColumnID="CarCost" />
                        <x:BoundField HeaderText="明细接收日期" DataField="CreateTime" Width="85px" ColumnID="CreateTime" />
                        <x:BoundField HeaderText="入库日期" DataField="TransitTime" Width="80px" ColumnID="TransitTime" />
                        <x:BoundField HeaderText="车辆状态" DataField="Statu" Width="60px" ColumnID="Statu" />
                        <x:BoundField HeaderText="释放日期" DataField="OutTime" Width="120px" ColumnID="OutTime" />
                        <x:BoundField HeaderText="移动日期" DataField="MoveTime" Width="120px" ColumnID="MoveTime" />
                        <x:BoundField HeaderText="备注" DataField="Remarks" ColumnID="Remarks" />
                    </Columns>
                    <PageItems>
                        <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </x:ToolbarSeparator>
                        <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                        </x:ToolbarText>
                        <x:DropDownList runat="server" ID="ddlPageSize" Width="45px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <x:ListItem Text="5" Value="5" />
                            <x:ListItem Text="10" Value="10" />
                            <x:ListItem Text="15" Value="15" />
                            <x:ListItem Text="20" Value="20" Selected="true" />
                        </x:DropDownList>
                    </PageItems>
                </x:Grid>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
    </form>
</body>
</html>
