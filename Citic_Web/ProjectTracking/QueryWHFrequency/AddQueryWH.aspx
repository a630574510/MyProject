<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQueryWH.aspx.cs" Inherits="Citic_Web.ProjectTracking.QueryWHFrequency.AddQueryWH" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Css/main.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../jqueryui/css/ui-lightness/jquery-ui-1.9.2.custom.css" />
    <style type="text/css">
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
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false"
            EnableBackgroundColor="true" Layout="Fit">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" ValidateForms="SimpleForm1" runat="server"
                            Text="保存并关闭" Icon="SystemSaveNew" OnClick="btn_SaveAndClose_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="0px" ShowHeader="false" ShowBorder="false" EnableBackgroundColor="true">
                    <Items>
                        <x:HiddenField ID="hf_DealerBankID" runat="server"></x:HiddenField>
                        <x:TextBox ID="txt_DealerName" runat="server" Label="经销商" Text="" Width="300px" AutoPostBack="true" OnTextChanged="txt_DealerName_TextChanged"></x:TextBox>
                        <x:DropDownList ID="ddl_Bank" runat="server" Label="合作行及品牌" Width="300px" AutoPostBack="true"></x:DropDownList>
                        <x:TextBox ID="txt_CheckFrequency" runat="server" Label="视察频率" Text="" Width="300px"></x:TextBox>
                        <x:TextArea ID="txt_Desc" runat="server" Height="50px" Label="描述" Text="" Width="300px"></x:TextArea>
                        <x:TextArea ID="txt_Remark" runat="server" Height="50px" Label="备注" Text="" Width="300px"></x:TextArea>
                    </Items>
                </x:SimpleForm>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
<script src="../../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
<script src="../../jqueryui/js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script type="text/javascript">
    function onReady() {
        var txt_Dealer = '<%= txt_DealerName.ClientID %>';

        var cache = {};

        //给URL地址追加时间戳，避免浏览器缓存。
        var timestamp = (new Date()).valueOf();

        $('#' + txt_Dealer).autocomplete({
            source: function (request, response) {
                var term = request.term;
                if (term in cache) {
                    response(cache[term]);
                    return;
                }

                $.getJSON("../../ProjectTracking/RiskControl/search.ashx?t=" + timestamp, request, function (data, status, xhr) {
                    cache[term] = data;
                    response(data);
                });
            }
        });
    }
</script>
