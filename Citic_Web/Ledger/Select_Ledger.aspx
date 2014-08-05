<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Select_Ledger.aspx.cs"
    Inherits="Citic_Web.Ledger.Select_Ledger" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" />
    <link rel="stylesheet" href="../jqueryui/css/ui-lightness/jquery-ui-1.9.2.custom.min.css" />
    <style type="text/css">
        .mright {
            margin-right: 5px;
        }

        .mleft {
            margin-left: 15px;
            margin-top: 2px;
        }

        .inline {
            margin-top: 2px;
        }

        .datecontainer .x-form-field-trigger-wrap {
            margin-right: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
            Title="质押监管车辆汇总" EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Start">
            <Items>
                <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" Title="查询条件" Height="90px" LabelWidth="60px" AutoHeight="true" BoxFlex="1" EnableBackgroundColor="true">
                    <Items>
                        <x:Panel ID="Panel2" AutoWidth="true" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Label="Label" Text="合作行：" CssClass="inline"></x:Label>
                                
                                <x:TextBox ID="txt_Bank" runat="server" Text="" CssStyle="font-size:15px" Width="300px" Height="25px"></x:TextBox>
                                <x:Label ID="Label2" runat="server" Label="Label" Text="经销商：" CssClass="mleft"></x:Label>
                                
                                <x:TextBox ID="txt_DealerName" runat="server" Width="350px" Height="25px" Text="" CssStyle="font-size:15px" CssClass="mright"></x:TextBox>
                            </Items>
                        </x:Panel>
                        <x:Panel ID="Panel3" AutoWidth="true" runat="server" BodyPadding="0px" CssStyle="margin-top:5px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column">
                            <Items>
                                <x:Label ID="Label6" runat="server" Label="Label" Text="车架号：" CssClass="inline"></x:Label>
                                <x:TextBox ID="txt_Vin" runat="server" Width="300px" Height="25px" Text="" CssStyle="font-size:15px"></x:TextBox>
                                <x:Button ID="btn_Search" runat="server" Text="查询" Size="Small" CssClass="mleft" Icon="SystemSearch" EnablePostBack="true" OnClick="btn_Search_Click">
                                </x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
            </Items>
            <Items>
                <x:Grid ID="grid_List" runat="server" EnableCheckBoxSelect="true" EnableRowNumber="true" IsDatabasePaging="true"
                    Title="具体信息" EnableBackgroundColor="true" CssStyle="padding-top:5px" BoxFlex="2" PageSize="15" AllowPaging="true"
                    ClearSelectedRowsAfterPaging="false"
                    OnPageIndexChange="grid_List_PageIndexChange" DataKeyNames="BankID,DealerID" EnableTextSelection="true">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:ToolbarFill ID="ToolbarFill1" runat="server"></x:ToolbarFill>
                                <x:Button ID="btn_BuildExcel" runat="server" Text="生成Excel" OnClick="btn_BuildExcel_Click" Icon="PageWhiteExcel"></x:Button>
                                <x:HyperLink ID="hl_ExportExcel" runat="server" Label="" NavigateUrl="" Target="_blank" Text="导出Excel"></x:HyperLink>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:BoundField HeaderText="合作行" DataField="BankName" Width="200px" />
                        <x:WindowField HeaderText="经销商" DataTextField="DealerName" DataTextFormatString="{0}" WindowID="Window_CarList"
                            DataIFrameUrlFields="BankID,DealerID" DataIFrameUrlFormatString="../Ledger/Electron_Ledger.aspx?BankID={0}&DealerID={1}"
                            Width="230" />
                        <x:BoundField HeaderText="品牌" DataField="BrandName" Width="60px" />
                        <x:BoundField HeaderText="库存台数" DataField="CarAllCount" Width="60px" />
                        <x:BoundField HeaderText="库存金额" DataField="CarAllMoney" />
                        <x:BoundField HeaderText="在库台数" DataField="CarILCount" Width="60px" />
                        <x:BoundField HeaderText="在库金额" DataField="CarILMoney" />
                        <x:BoundField HeaderText="在途台数" DataField="CarITCount" Width="60px" />
                        <x:BoundField HeaderText="在途金额" DataField="CarITMoney" />
                        <x:BoundField HeaderText="移动台数" DataField="CarMoveCount" Width="60px" />
                        <x:BoundField HeaderText="移动金额" DataField="CarMoveMoney" />
                    </Columns>
                    <PageItems>
                        <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </x:ToolbarSeparator>
                        <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                        </x:ToolbarText>
                        <x:DropDownList runat="server" ID="ddlPageSize" Width="45px" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                            <x:ListItem Text="5" Value="5" />
                            <x:ListItem Text="10" Value="10" Selected="true" />
                            <x:ListItem Text="15" Value="15" />
                            <x:ListItem Text="20" Value="20" />
                        </x:DropDownList>
                    </PageItems>
                </x:Grid>
            </Items>
        </x:Panel>

        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>

        <x:Window ID="Window_CarList" Title="质押监管车辆电子总账" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            Target="Top" runat="server" IsModal="true" Width="1250px" Height="650px"
            EnableConfirmOnClose="true" EnableMaximize="false" EnableClose="true"
            EnableMinimize="false" EnableResize="false">
        </x:Window>
    </form>
</body>
</html>
<script src="../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
<script src="../jqueryui/js/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function onReady() {
        var txt_Bank = '<%= txt_Bank.ClientID %>';
        var txt_Dealer = '<%= txt_DealerName.ClientID %>';

        $('#' + txt_Bank).autocomplete({
            source: function (request, response) {
                var term = request.term;

                $.getJSON("../Handlers/searchBank.ashx?", request, function (data, status, xhr) {
                    response(data);
                });
            }
        });

        $('#' + txt_Dealer).autocomplete({
            source: function (request, response) {
                var term = request.term;

                $.getJSON("../Handlers/searchDealer.ashx?", request, function (data, status, xhr) {
                    response(data);
                });
            }
        });
    }
</script>
