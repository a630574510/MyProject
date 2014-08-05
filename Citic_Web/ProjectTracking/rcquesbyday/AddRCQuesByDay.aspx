<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRCQuesByDay.aspx.cs" Inherits="Citic_Web.ProjectTracking.rcquesbyday.AddRCQuesByDay" %>

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
        <x:HiddenField ID="hf_BrandID" runat="server"></x:HiddenField>
        <x:HiddenField ID="hf_BrandName" runat="server"></x:HiddenField>
        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true" Title="添加每日风控问题追踪" EnableBackgroundColor="true"
            Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" ShowBorder="false" EnableBackgroundColor="true" BoxFlex="1" CssStyle="padding-bottom:5px" Height="35px">
                    <Items>
                        <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column" CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="选择经销商："></x:Label>
                                <x:TextBox ID="txt_Dealer" runat="server" ShowLabel="false" AutoPostBack="true" OnTextChanged="txt_Dealer_TextChanged" Width="300px" Text=""></x:TextBox>
                                <x:Label ID="Label2" runat="server" Text="选择合作行：" CssStyle="padding-left:20px;padding-right:20px"></x:Label>
                                <x:DropDownList ID="ddl_Bank" runat="server" EnableEdit="false" AutoPostBack="true" OnSelectedIndexChanged="ddl_Bank_SelectedIndexChanged"></x:DropDownList>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" ShowHeader="false" ShowBorder="false" AllowCellEditing="true" ClicksToEdit="1"
                    EnableAfterEditEvent="true" OnAfterEdit="grid_List_AfterEdit" EnableMultiSelect="true" EnableRowSelect="true" BoxFlex="2">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_Add" OnClick="btn_Add_Click" runat="server" Text="确定添加" Icon="Add"></x:Button>
                                <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server"></x:ToolbarSeparator>
                                <x:Button ID="btn_Add_Row" runat="server" Text="添加行" OnClick="btn_Add_Row_Click" Icon="TableAdd"></x:Button>
                                <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server"></x:ToolbarSeparator>
                                <x:Button ID="btn_Delete_Row" EnablePostBack="false" runat="server" Text="删除选中行" Icon="TableDelete" />
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:RenderField ColumnID="WorkContent" DataField="WorkContent" FieldType="String" HeaderText="工作内容" Width="100px">
                            <Editor>
                                <%--<x:TextBox ID="txt_WorkContent" runat="server" Text=""></x:TextBox>--%>
                                <x:DropDownList ID="ddl_WorkContent" runat="server"></x:DropDownList>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField ColumnID="Area" DataField="Area" FieldType="String" HeaderText="区域名称" Width="100px">
                            <Editor>
                                <%--<x:TextBox ID="txt_Area" runat="server" Text=""></x:TextBox>--%>
                                <x:DropDownList ID="ddl_Area" runat="server"></x:DropDownList>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField ColumnID="Checkman" DataField="Checkman" FieldType="String" HeaderText="检察人员" Width="100px">
                            <Editor>
                                <x:TextBox ID="txt_Checkman" runat="server" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField ColumnID="DealerName" DataField="DealerName" FieldType="String" HeaderText="经销商名称" Width="260px">
                            <Editor>
                                <x:TextBox ID="txt_DealerName" runat="server" Text="" AutoPostBack="true" EnableAjax="true" EnableAjaxLoading="true"></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField ColumnID="BankName" DataField="BankName" FieldType="Int" HeaderText="合作行" Width="200px">
                            <Editor>
                                <x:TextBox ID="txt_BankName" runat="server" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField ColumnID="BrandName" DataField="BrandName" FieldType="String" HeaderText="品牌" Width="100px">
                            <Editor>
                                <x:TextBox ID="txt_BrandName" runat="server" Enabled="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField ColumnID="SName" DataField="SName" FieldType="String" HeaderText="监管员" Width="100px">
                            <Editor>
                                <x:TextBox ID="txt_SName" runat="server" Enabled="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField ColumnID="DescProb" DataField="DescProb" FieldType="String" HeaderText="问题描述" Width="100px">
                            <Editor>
                                <x:TextArea ID="txt_DescProb" runat="server" Height="100px" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField ColumnID="Result" DataField="Result" FieldType="String" HeaderText="检时处理结果" Width="100px">
                            <Editor>
                                <x:TextArea ID="txt_Result" runat="server" Height="100px" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                    </Columns>
                </x:Grid>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
<script src="../../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
<script src="../../jqueryui/js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script type="text/javascript">
    function onReady() {
        var textbox1ID = '<%= txt_Dealer.ClientID %>';

        var cache = {};

        $('#' + textbox1ID).autocomplete({
            source: function (request, response) {
                var term = request.term;

                $.getJSON("../../ProjectTracking/RiskControl/search.ashx", request, function (data, status, xhr) {
                    response(data);
                });
            }
        });

        var bankID = '<%= ddl_Bank.ClientID%>';
    }
    function checkDealer() {
        var dealer = '<%= txt_Dealer.ClientID %>';
        if ($('#' + dealer).val().length == 0) {
            alert("请选择经销商！");
            return;
        }
    }

</script>
