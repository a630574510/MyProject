<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZX_ShowSCF.aspx.cs" Inherits="Citic_Web.BankInterface.ZX_ShowSCF" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="Fit" BoxConfigAlign="Stretch" EnableBackgroundColor="true">
        <Items>
            <x:Grid ID="G_List_DLCDLMLQ" runat="server" Title="详细信息" ShowBorder="true" ShowHeader="false"
                EnableTextSelection="true" Visible="false">
                <Columns>
                    <x:BoundField HeaderText="融资编号" Width="200px" DataField="loanCode" TextAlign="Center" />
                    <x:BoundField HeaderText="放款批次号" Width="200px" DataField="scftxNo" TextAlign="Center" />
                    <x:BoundField HeaderText="融资金额" Width="200px" DataField="loanAmt" TextAlign="Center" />
                    <x:BoundField HeaderText="保证金比例" Width="200px" DataField="bailRat" TextAlign="Center" />
                    <x:BoundField HeaderText="自有资金比例" Width="200px" DataField="slfcapRat" TextAlign="Center" />
                    <x:BoundField HeaderText="首付保证金可提货比例" Width="200px" DataField="fstblRat" TextAlign="Center" />
                    <x:BoundField HeaderText="融资起始日" Width="200px" DataField="loanstDate" TextAlign="Center"
                        DataFormatString="{0:yyyy-MM-dd}" />
                    <x:BoundField HeaderText="融资到期日" Width="200px" DataField="loanendDate" TextAlign="Center"
                        DataFormatString="{0:yyyy-MM-dd}" />
                    <x:BoundField HeaderText="授信产品" Width="200px" DataField="procrt" TextAlign="Center" />
                    <x:BoundField HeaderText="经办行" Width="200px" DataField="operOrg" TextAlign="Center" />
                    <x:BoundField HeaderText="业务模式" Width="200px" DataField="bizMod" TextAlign="Center" />
                    <x:BoundField HeaderText="备用字段1" Width="200px" DataField="field1" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="备用字段2" Width="200px" DataField="field2" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="备用字段3" Width="200px" DataField="field3" TextAlign="Center"
                        Hidden="true" />
                </Columns>
            </x:Grid>
        </Items>
        <Items>
            <x:Grid ID="G_List_DLCDWMLQ" runat="server" Title="详细信息" ShowBorder="true" ShowHeader="false"
                EnableTextSelection="true" Visible="false">
                <Columns>
                    <x:BoundField HeaderText="借款企业名称" Width="200px" DataField="lonNm" TextAlign="Center" />
                    <x:BoundField HeaderText="仓库名称" Width="200px" DataField="whName" TextAlign="Center" />
                    <x:BoundField HeaderText="仓库代码" Width="200px" DataField="bkwhCode" TextAlign="Center" />
                    <x:BoundField HeaderText="仓库级别" Width="200px" DataField="whLevel" TextAlign="Center" />
                    <x:BoundField HeaderText="经办行" Width="200px" DataField="operOrg" TextAlign="Center" />
                    <x:BoundField HeaderText="地址" Width="200px" DataField="address" TextAlign="Center" />
                    <x:BoundField HeaderText="电话" Width="200px" DataField="phone" TextAlign="Center" />
                    <x:BoundField HeaderText="备用字段1" Width="200px" DataField="field1" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="备用字段2" Width="200px" DataField="field2" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="备用字段3" Width="200px" DataField="field3" TextAlign="Center"
                        Hidden="true" />
                </Columns>
            </x:Grid>
        </Items>
        <Items>
            <x:Grid ID="G_Q412" runat="server" Title="详细信息" ShowBorder="true" ShowHeader="false"
                EnableTextSelection="true" Visible="false">
                <Columns>
                    <x:BoundField HeaderText="票据ID" Width="200px" DataField="BF_ID" TextAlign="Center" />
                    <x:BoundField HeaderText="承兑协议号" Width="200px" DataField="ACPT_PRTL_NO" TextAlign="Center" />
                    <x:BoundField HeaderText="票号" Width="200px" DataField="BF_NO" TextAlign="Center" />
                    <x:BoundField HeaderText="出票人名称" Width="200px" DataField="BNFO_APPLY_CUST" TextAlign="Center" />
                    <x:BoundField HeaderText="收款人名称" Width="200px" DataField="BNFO_BILL_PAYEE" TextAlign="Center" />
                    <x:BoundField HeaderText="金额" Width="200px" DataField="BNFO_BILL_MONEY" TextAlign="Center" />
                    <x:BoundField HeaderText="出票日" Width="200px" DataField="BNFO_ISSUE_DT" TextAlign="Center" />
                    <x:BoundField HeaderText="票面到期日" Width="200px" DataField="BNFO_BILL_MATURE_DT" TextAlign="Center" />
                    <x:BoundField HeaderText="票据状态" Width="200px" DataField="BILL_STATUS" TextAlign="Center" />
                    <x:BoundField HeaderText="核心厂商ID" Width="200px" DataField="HXCS_ID" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="经销商ID" Width="200px" DataField="JXS_ID" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="预留字段1" Width="200px" DataField="RESERVE1" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="预留字段2" Width="200px" DataField="RESERVE2" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="预留字段3" Width="200px" DataField="RESERVE3" TextAlign="Center"
                        Hidden="true" />
                </Columns>
            </x:Grid>
        </Items>
        <Items>
            <x:Grid ID="G_Q414" runat="server" Title="详细信息" ShowBorder="true" ShowHeader="false"
                EnableTextSelection="true" Visible="false">
                <Columns>
                    <x:BoundField HeaderText="合格证编号" Width="200px" DataField="PI_NO" TextAlign="Center" />
                    <x:BoundField HeaderText="车架号" Width="200px" DataField="DJ_NO" TextAlign="Center" />
                    <x:BoundField HeaderText="发车日期" Width="200px" DataField="SEND_CAR_DATE" TextAlign="Center" />
                    <x:BoundField HeaderText="汽车型号" Width="200px" DataField="CAR_MODEL" TextAlign="Center" />
                    <x:BoundField HeaderText="发动机号" Width="200px" DataField="ENGINE_MODEL" TextAlign="Center" />
                    <x:BoundField HeaderText="品牌" Width="200px" DataField="CAR_BRAND" TextAlign="Center" />
                    <x:BoundField HeaderText="颜色" Width="200px" DataField="CAR_COLOR" TextAlign="Center" />
                    <x:BoundField HeaderText="合格证金额" Width="200px" DataField="PI_AMOUNT" TextAlign="Center" />
                    <x:BoundField HeaderText="对应票据ID" Width="200px" DataField="BF_ID" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="快递单号" Width="200px" DataField="TRACKING_NUMBER" TextAlign="Center" />
                    <x:BoundField HeaderText="备注" Width="200px" DataField="REMARK" TextAlign="Center" />
                    <x:BoundField HeaderText="发车信息ID" Width="200px" DataField="SEND_CAR_ID" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="经销商ID" Width="200px" DataField="JXS_ID" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="核心厂商ID" Width="200px" DataField="HXCS_ID" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="预留字段1" Width="200px" DataField="RESERVE1" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="预留字段2" Width="200px" DataField="RESERVE2" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="预留字段3" Width="200px" DataField="RESERVE3" TextAlign="Center"
                        Hidden="true" />
                </Columns>
            </x:Grid>
        </Items>
        <Items>
            <x:Grid ID="G_Q406" runat="server" Title="详细信息" ShowBorder="true" ShowHeader="false"
                EnableTextSelection="true" Visible="false">
                <Columns>
                    <x:BoundField HeaderText="合格证id" Width="200px" DataField="PI_ID" TextAlign="Center"  Hidden="true" />
                    <x:BoundField HeaderText="经销商ID" Width="200px" DataField="JXS_ID" TextAlign="Center"  Hidden="true" />
                    <x:BoundField HeaderText="经销商名称" Width="200px" DataField="JXS_NAME" TextAlign="Center" />
                    <x:BoundField HeaderText="核心厂商ID" Width="200px" DataField="HXCS_ID" TextAlign="Center"  Hidden="true" />
                    <x:BoundField HeaderText="核心厂商名称" Width="200px" DataField="HXCS_NAME" TextAlign="Center" />
                    <x:BoundField HeaderText="合格证编号" Width="200px" DataField="PI_NO" TextAlign="Center" />
                    <x:BoundField HeaderText="车辆识别代号" Width="200px" DataField="DJ_NO" TextAlign="Center" />
                    <x:BoundField HeaderText="汽车型号" Width="200px" DataField="CAR_MODEL" TextAlign="Center" />
                    <x:BoundField HeaderText="发动机号" Width="200px" DataField="ENGINE_MODEL" TextAlign="Center" />
                    <x:BoundField HeaderText="品牌" Width="200px" DataField="CAR_BRAND" TextAlign="Center" />
                    <x:BoundField HeaderText="颜色" Width="200px" DataField="CAR_COLOR" TextAlign="Center" />
                    <x:BoundField HeaderText="合格证金额" Width="200px" DataField="PI_AMOUNT" TextAlign="Center" />
                    <x:BoundField HeaderText="对应票号" Width="200px" DataField="BF_NO" TextAlign="Center" />
                    <x:BoundField HeaderText="对应票据id" Width="200px" DataField="BF_ID" TextAlign="Center"  Hidden="true" />
                    <x:BoundField HeaderText="合格证状态" Width="200px" DataField="PI_STATUS" TextAlign="Center" />
                    <x:BoundField HeaderText="车辆状态" Width="200px" DataField="CAR_STATUS" TextAlign="Center" />
                    <x:BoundField HeaderText="钥匙数量" Width="200px" DataField="KEY_NUM" TextAlign="Center" />
                    <x:BoundField HeaderText="合格证到期日" Width="200px" DataField="MATURE_DATE" TextAlign="Center" />
                    <x:BoundField HeaderText="车辆在库地址" Width="200px" DataField="CAR_STOCK_ADD" TextAlign="Center" />
                    <x:BoundField HeaderText="预留字段1" Width="200px" DataField="RESERVE1" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="预留字段2" Width="200px" DataField="RESERVE2" TextAlign="Center"
                        Hidden="true" />
                    <x:BoundField HeaderText="预留字段3" Width="200px" DataField="RESERVE3" TextAlign="Center"
                        Hidden="true" />
                </Columns>
            </x:Grid>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
