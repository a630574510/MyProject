<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RCQuesByDayVerify.aspx.cs" Inherits="Citic_Web.ProjectTracking.rcquesbyday.RCQuesByDayVerify" %>

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
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false" EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true"
                    BoxFlex="1" Height="70px" CssStyle="padding-bottom:5px">
                    <Items>
                        <x:Panel ID="Panel4" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column" CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label4" runat="server" Text="选择经销商："></x:Label>
                                <x:TextBox ID="txt_Dealer" runat="server" ShowLabel="false" Width="300px" Text=""></x:TextBox>

                                <x:Label ID="Label1" runat="server" Text="创建时间：" CssStyle="padding-right:10px;padding-left:20px"></x:Label>
                                <x:DatePicker ID="dp_Start" runat="server" EnableEdit="false"></x:DatePicker>
                                <x:Label ID="Label3" runat="server" Text="至" CssStyle="padding-right:5px;padding-left:5px"></x:Label>
                                <x:DatePicker ID="dp_End" runat="server" EnableEdit="false"></x:DatePicker>
                            </Items>
                        </x:Panel>
                        <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column" CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label2" runat="server" Text="区域：" CssStyle="padding-right:36px;"></x:Label>
                                <x:DropDownList ID="ddl_Area" runat="server" Width="100px">
                                    <x:ListItem Text="请选择" Value="-1" />
                                    <x:ListItem Text="已审核" Value="1" />
                                    <x:ListItem Text="未审核" Value="0" />
                                </x:DropDownList>
                                <x:Label ID="Label5" runat="server" Text="审批状态：" CssStyle="padding-right:12px;padding-left:20px"></x:Label>
                                <x:DropDownList ID="ddl_Status" runat="server" Width="100px">
                                    <x:ListItem Text="请选择" Value="-1" />
                                    <x:ListItem Text="已审核" Value="1" />
                                    <x:ListItem Text="未审核" Value="0" />
                                </x:DropDownList>
                                <x:Button ID="btn_Search" runat="server" Text="查询" Visible="false" Icon="SystemSearch" CssStyle="padding-left:20px" OnClick="btn_Search_Click"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" ShowHeader="false" EnableTextSelection="true" AllowPaging="true" IsDatabasePaging="true"
                    EnableCheckBoxSelect="true" OnPageIndexChange="grid_List_PageIndexChange" BoxFlex="2" ClicksToEdit="1" AllowCellEditing="true"
                    DataKeyNames="ID" PageSize="10">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_Verify" runat="server" Text="审核" OnClick="btn_Verify_Click" Icon="Accept" Visible="false"></x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:RenderCheckField HeaderText="选择" Width="40px" />
                        <x:BoundField DataField="CreateTime" HeaderText="创建时间" Width="120px" />
                        <x:BoundField DataField="WorkContent" HeaderText="工作内容" Width="120px" />
                        <x:BoundField DataField="Area" HeaderText="区域名称" Width="100px" />
                        <x:BoundField DataField="DealerName" HeaderText="经销商" Width="200px" />
                        <x:BoundField DataField="BankName" HeaderText="合作行" Width="200px" />
                        <x:BoundField DataField="BrandName" HeaderText="品牌" Width="80px" />
                        <x:RenderField DataField="CY_Market" ColumnID="CY_Market" FieldType="String" HeaderText="产业市场回复" Width="100px">
                            <Editor>
                                <x:TextArea ID="txt_CY_Market" runat="server" Height="70px" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField DataField="CY_Business" ColumnID="CY_Business" FieldType="String" HeaderText="产业业务回复" Width="100px">
                            <Editor>
                                <x:TextArea ID="txt_CY_Business" runat="server" Height="70px" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField DataField="QC_Market" ColumnID="QC_Market" FieldType="String" HeaderText="汽车市场回复" Width="100px">
                            <Editor>
                                <x:TextArea ID="txt_QC_Market" runat="server" Height="70px" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField DataField="QC_Business" ColumnID="QC_Business" FieldType="String" HeaderText="汽车业务回复" Width="100px">
                            <Editor>
                                <x:TextArea ID="txt_QC_Business" runat="server" Height="70px" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField DataField="ManCenter" ColumnID="ManCenter" FieldType="String" HeaderText="管理中心" Width="100px">
                            <Editor>
                                <x:TextBox ID="txt_ManCenter" runat="server" Label="Label" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField DataField="XZ" ColumnID="XZ" FieldType="String" HeaderText="行政" Width="100px">
                            <Editor>
                                <x:TextBox ID="txt_XZ" runat="server" Label="Label" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField DataField="Remark" ColumnID="Remark" FieldType="String" HeaderText="备注" Width="100px">
                            <Editor>
                                <x:TextArea ID="txt_Remark" runat="server" Height="70px" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                    </Columns>
                    <PageItems>
                        <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                        </x:ToolbarSeparator>
                        <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                        </x:ToolbarText>
                        <x:DropDownList runat="server" ID="ddlPageSize" Width="40px" AutoPostBack="true"
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
    </form>
</body>
</html>
<script src="../../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
<script src="../../jqueryui/js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script type="text/javascript">
    function onReady() {
        var textbox1ID = '<%= txt_Dealer.ClientID %>';

        var cache = {};

        //给URL地址追加时间戳，避免浏览器缓存。
        var timestamp = (new Date()).valueOf();

        $('#' + textbox1ID).autocomplete({
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
