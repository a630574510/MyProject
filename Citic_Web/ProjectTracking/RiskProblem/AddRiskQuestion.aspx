<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRiskQuestion.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskProblem.AddRiskQuestion" %>

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
        <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="true" ShowHeader="true" Title="添加风险问题处理单"
            EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="sf_Basic" runat="server" BodyPadding="5px" ShowHeader="false" ShowBorder="false" EnableBackgroundColor="true" Height="35px" CssStyle="padding-bottom:5px; border-bottom:1px solid #99BBE8">
                    <Items>
                        <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="经销商名称：" CssClass="inline"></x:Label>
                                <x:TextBox ID="txt_Dealer" runat="server" Text="" Width="350px" EmptyText="请输入经销商" CssStyle="padding-left:0px;height:20px;font-size:15px"
                                    AutoPostBack="true" OnTextChanged="txt_Dealer_TextChanged" Label="经销商名称" Required="true" CompareType="String" CompareValue="" CompareOperator="NotEqual">
                                </x:TextBox>
                                <x:Label ID="Label2" runat="server" Text="合作行：" CssClass="inline" CssStyle="padding-left:10px"></x:Label>
                                <x:DropDownList ID="ddl_Bank" runat="server" Width="300px" Required="true" CompareType="String" CompareValue="-1" CompareOperator="NotEqual"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddl_Bank_SelectedIndexChanged" Label="合作行">
                                </x:DropDownList>
                                <x:Label ID="Label3" runat="server" Text="品牌：" CssClass="inline" CssStyle="padding-left:10px"></x:Label>
                                <x:DropDownList ID="ddl_Brand" runat="server" Width="100px"></x:DropDownList>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" EnableBackgroundColor="true" ShowHeader="false" ShowBorder="false" ClicksToEdit="1"
                    AllowCellEditing="true" BoxFlex="1">
                    <Toolbars>
                        <x:Toolbar runat="server">
                            <Items>
                                <x:Button ID="btn_Add" OnClick="btn_Add_Click" runat="server" Text="确定添加" Icon="Add"></x:Button>
                                <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server"></x:ToolbarSeparator>
                                <x:Button ID="btn_Add_Table" EnablePostBack="true" runat="server" Text="添加行" OnClick="btn_Add_Table_Click" ValidateForms="sf_Basic" Icon="TableAdd" />
                                <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server"></x:ToolbarSeparator>
                                <x:Button ID="btn_Delete_Table" EnablePostBack="false" runat="server" Text="删除选中行" Icon="TableDelete" />
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:RenderField ColumnID="SQ_ShopID" DataField="SQ_ShopID" HideMode="Visibility" Hidden="true">
                            <Editor>
                                <x:Label ID="SQ_ShopID" runat="server"></x:Label>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField ColumnID="SQ_BankID" DataField="SQ_BankID" HideMode="Visibility" Hidden="true">
                            <Editor>
                                <x:Label ID="SQ_BankID" runat="server"></x:Label>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField ColumnID="SQ_BrandID" DataField="SQ_BrandID" HideMode="Visibility" Hidden="true">
                            <Editor>
                                <x:Label ID="SQ_BrandID" runat="server"></x:Label>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="240px" ColumnID="SQ_Shop" DataField="SQ_Shop" HeaderText="监管店">
                            <Editor>
                                <x:Label ID="SQ_Shop" runat="server"></x:Label>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="200px" ColumnID="SQ_Bank" DataField="SQ_Bank" HeaderText="合作行">
                            <Editor>
                                <x:Label ID="SQ_Bank" runat="server"></x:Label>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="SQ_Brand" DataField="SQ_Brand" HeaderText="品牌">
                            <Editor>
                                <x:Label ID="SQ_Brand" runat="server"></x:Label>
                            </Editor>
                        </x:RenderField>

                        <x:RenderField Width="100px" ColumnID="C_Date" DataField="C_Date" FieldType="Date"
                            HeaderText="投诉时间" Renderer="Date" RendererArgument="yyyy-MM-dd">
                            <Editor>
                                <x:DatePicker ID="C_Date" Required="true" runat="server" EnableEdit="false">
                                </x:DatePicker>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="C_AP" DataField="C_AP" FieldType="String"
                            HeaderText="投诉接收人">
                            <Editor>
                                <x:TextBox ID="C_AP" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="C_Unit" DataField="C_Unit" FieldType="String"
                            HeaderText="投诉单位">
                            <Editor>
                                <x:TextBox ID="C_Unit" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="C_P" DataField="C_P" FieldType="String"
                            HeaderText="投诉人">
                            <Editor>
                                <x:TextBox ID="C_P" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="C_Post" DataField="C_Post" FieldType="String"
                            HeaderText="投诉人职务">
                            <Editor>
                                <x:TextBox ID="C_Post" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="C_PPhone" DataField="C_PPhone" FieldType="String"
                            HeaderText="投诉人联系方式">
                            <Editor>
                                <x:TextBox ID="C_PPhone" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="C_Content" DataField="C_Content" FieldType="String"
                            HeaderText="投诉内容">
                            <Editor>
                                <x:TextBox ID="C_Content" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="SQ_Content" DataField="SQ_Content" FieldType="String"
                            HeaderText="问题描述">
                            <Editor>
                                <x:TextArea ID="SQ_Content" runat="server" Height="50px" Label="Label" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>

                    </Columns>
                </x:Grid>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
<script src="../../jqueryui/js/jquery-1.8.3.js" type="text/javascript"></script>
<script src="../../jqueryui/js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script type="text/javascript">
    function Init() {
        setTimeout("LoadAutoComplete()", 1000);
    }
    function onReady() {
        var txt_Dealer = '<%= this.txt_Dealer.ClientID %>';
        //给URL地址追加时间戳，避免浏览器缓存。
        var timestamp = (new Date()).valueOf();

        $('#' + txt_Dealer).autocomplete({
            source: function (request, response) {
                var term = request.term;

                $.getJSON("../../ProjectTracking/RiskControl/search.ashx?t=" + timestamp, request, function (data, status, xhr) {
                    response(data);
                });
            }
        });
    }
    function LoadAutoComplete() {
        var txt_Dealer = '<%= this.txt_Dealer.ClientID %>';

        //给URL地址追加时间戳，避免浏览器缓存。
        var timestamp = (new Date()).valueOf();

        $('#' + txt_Dealer).autocomplete({
            source: function (request, response) {
                var term = request.term;

                $.getJSON("../../ProjectTracking/RiskControl/search.ashx?t=" + timestamp, request, function (data, status, xhr) {
                    response(data);
                });
            }
        });


        $('#' + txt_Dealer).blur(function () {
            var val = this.value;
            if (val.indexOf('_') > 0) {
                dealerID = val.split('_')[1];
                $('#' + bank).val(dealerID);
            }
        });
    }
</script>

