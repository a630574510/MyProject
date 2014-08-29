<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStockError.aspx.cs" Inherits="Citic_Web.Reminds.AddStockError" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../jqueryui/css/ui-lightness/jquery-ui-1.9.2.custom.min.css" />
    <style type="text/css">
        .mright {
            margin-right: 5px;
        }

        .datecontainer .x-form-field-trigger-wrap {
            margin-right: 5px;
        }

        .padding-bottom {
            padding-bottom: 5px;
        }

        .mright {
            margin-right: 5px;
        }

        .datecontainer .x-form-field-trigger-wrap {
            margin-right: 5px;
        }

        .ui-autocomplete-loading {
            background: white url('../../Images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false" Layout="Fit" EnableBackgroundColor="true">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" runat="server" Icon="SystemSaveClose" Text="保存并关闭页面" ValidateForms="sf_BasicInfo" OnClick="btn_SaveAndClose_Click"></x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:SimpleForm ID="sf_BasicInfo" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false" EnableBackgroundColor="true">
                    <Items>
                        <x:TextBox ID="txt_Dealer" runat="server" Label="经销商（手输）" Width="400px" AutoPostBack="true" OnTextChanged="txt_Dealer_TextChanged"></x:TextBox>
                        <x:DropDownList ID="ddl_Bank" runat="server" Label="合作行" Width="400px">
                            <x:ListItem Text="请选择" Value="-1" Selected="true" />
                        </x:DropDownList>
                        <x:TextBox ID="txt_Vin" runat="server" Label="车架号（手输）" Text=""></x:TextBox>
                        <x:CheckBoxList ID="cbl_Status" runat="server" Label="异常状态" Width="300px" Required="true" RequiredMessage="请选择异常状态！">
                            <x:CheckItem Text="车辆异常" Value="cl" />
                            <x:CheckItem Text="合格证异常" Value="hgz" />
                        </x:CheckBoxList>
                        <x:CheckBoxList ID="cbl_EO" runat="server" Label="异常信息" ColumnNumber="3" Required="true" RequiredMessage="请选择异常信息！" ColumnVertical="true"></x:CheckBoxList>
                        <x:TextArea ID="txt_ErrorOther" runat="server" Height="100px" Width="400px" Label="具体信息" Text=""></x:TextArea>
                    </Items>
                </x:SimpleForm>

            </Items>
        </x:Panel>
    </form>
</body>
</html>
<script src="../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
<script src="../jqueryui/js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script type="text/javascript">
    function onReady() {
        var txt_Dealer = '<%= txt_Dealer.ClientID %>';
        var txt_Vin = '<%= txt_Vin.ClientID %>';
        var ddl_Bank = '<%= ddl_Bank.ClientID %>';
        <%string bankID = string.Empty;%>
        //给URL地址追加时间戳，避免浏览器缓存。
        var timestamp = (new Date()).valueOf();

        $('#' + txt_Dealer).autocomplete({
            source: function (request, response) {
                var term = request.term;

                $.getJSON("../ProjectTracking/RiskControl/search.ashx?t=" + timestamp, request, function (data, status, xhr) {
                    response(data);
                });
            }
        });

        $('#' + txt_Vin).autocomplete({
            source: function (request, response) {
                var term = request.term;
                var dealerValue = $('#' + txt_Dealer).val();
                var bankValue = $('#' + ddl_Bank).val();
                $.getJSON("../Handlers/searchVin.ashx?type=_checkVin&_dv=" + escape(dealerValue) + "&_bv=" + escape(bankValue) + "&t=" + timestamp, request, function (data, status, xhr) {
                    response(data);
                });
            }
        });
    }
</script>
