<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadXDBG.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.UploadXDBG" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Css/main.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../jqueryui/css/ui-lightness/jquery-ui-1.9.2.custom.min.css" />
    <style>
        .ui-autocomplete-loading {
            background: white url('../../Images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" EnableBackgroundColor="true" Title="上传巡店报告">
            <Items>
                <x:SimpleForm ID="SimpleForm2" runat="server" ShowHeader="false" ShowBorder="false" EnableBackgroundColor="true">
                    <Items>
                        <x:TextBox ID="txt_Dealer" runat="server" ShowLabel="true" Label="选择经销商" Width="300px" Text="" AutoPostBack="true" OnTextChanged="txt_Dealer_TextChanged"></x:TextBox>
                        <x:DropDownList ID="ddl_Bank" runat="server" ShowLabel="true" Label="选择合作行" Width="300px"></x:DropDownList>
                        <x:DropDownList ID="ddl_Area" runat="server" ShowLabel="true" Label="选择区域" AutoPostBack="true" OnSelectedIndexChanged="dp_Time_DateSelect" Width="200px"></x:DropDownList>
                        <x:DatePicker ID="dp_Time" runat="server" ShowLabel="true" Label="选择巡店时间" EnableEdit="false" EnableDateSelect="true" AutoPostBack="true" OnDateSelect="dp_Time_DateSelect" Width="200px"></x:DatePicker>
                        <x:RadioButtonList ID="rbl_Type" runat="server" Label="上传类型" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="rbl_Type_SelectedIndexChanged">
                            <x:RadioItem Text="新文件上传" Value="new" />
                            <x:RadioItem Text="旧文件修改" Value="old" />
                        </x:RadioButtonList>
                        <x:DropDownList ID="ddl_Files" runat="server" Label="上传的文件" Width="500px"></x:DropDownList>
                        <x:FileUpload ID="file_Upload" runat="server" Label="请选择文件" Width="355px"></x:FileUpload>
                        <x:TextArea ID="txt_Remark" runat="server" Height="80px" Width="300px" Label="备注" Text=""></x:TextArea>
                        <x:Button ID="btn_Upload" runat="server" Text="上传" OnClick="btn_Upload_Click"></x:Button>
                    </Items>
                </x:SimpleForm>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
<script src="../../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
<script src="../../jqueryui/js/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
<script type="text/javascript">
    function onReady() {
        var textbox1ID = '<%= txt_Dealer.ClientID %>';

        var cache = {};

        $('#' + textbox1ID).autocomplete({
            source: function (request, response) {
                var term = request.term;
                if (term in cache) {
                    response(cache[term]);
                    return;
                }

                $.getJSON("../../ProjectTracking/RiskControl/search.ashx", request, function (data, status, xhr) {
                    cache[term] = data;
                    response(data);
                });
            }
        });
    }

</script>
</body>