<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryWHFrequency.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.QueryWHFrequency" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../Css/main.css" rel="stylesheet" />
    <link rel="stylesheet" href="../../jqueryui/css/ui-lightness/jquery-ui-1.9.2.custom.min.css" />
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
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" Title="查库频率"
            EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch">
            <Items>
                <x:SimpleForm ID="sf_Query" runat="server" BodyPadding="5px" Title="查询" BoxFlex="1" EnableBackgroundColor="true"
                    Height="90px" CssStyle="padding-bottom:5px">
                    <Items>
                        <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="经销商：" CssStyle="padding-right:12px" CssClass="inline"></x:Label>
                                <x:TextBox ID="txt_DealerName" runat="server" Label="经销商" Text="" Width="300px" AutoPostBack="true" OnTextChanged="txt_DealerName_TextChanged" CssClass="inline"></x:TextBox>

                                <x:Label ID="Label2" runat="server" Text="合作行：" CssClass="inline" CssStyle="padding-left:10px"></x:Label>
                                <x:DropDownList ID="ddl_Bank" runat="server" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddl_Bank_SelectedIndexChanged"></x:DropDownList>
                                <x:Label ID="Label3" runat="server" Text="品牌：" CssStyle="padding-left:20px" CssClass="inline"></x:Label>
                                <x:Label ID="lbl_Brand" runat="server" Text="" CssClass="inline" CssStyle="font-size:16px;font-weight:bold;color:red"></x:Label>
                            </Items>
                        </x:Panel>

                        <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label4" runat="server" Text="查库频率：" CssClass="inline"></x:Label>
                                <x:TextBox ID="txt_cf" runat="server" Label="Label" Text="" CssClass="inline"></x:TextBox>
                                <x:Button ID="btn_Search" runat="server" Text="查询" Icon="SystemSearch" CssStyle="padding-left:20px" OnClick="btn_Search_Click" Visible="false"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" EnableBackgroundColor="true" EnableTextSelection="true" AllowPaging="true" IsDatabasePaging="true"
                    EnableCheckBoxSelect="true" EnableRowNumber="true" EnableRowNumberPaging="true" DataKeyNames="ID,DealerID,BankID" BoxFlex="2"
                    ShowHeader="false" PageSize="15" ClicksToEdit="1" AllowCellEditing="true" OnPageIndexChange="grid_List_PageIndexChange">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_Save" runat="server" Text="保存" Icon="SystemSave" OnClick="btn_Add_Click" Visible="false"></x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:BoundField DataField="DealerName" HeaderText="经销商" TextAlign="Left" Width="300px" />
                        <x:BoundField DataField="BankName" HeaderText="合作行" TextAlign="Left" Width="200px" />
                        <x:RenderField Width="100px" ColumnID="CheckFrequency" DataField="CheckFrequency" FieldType="String"
                            HeaderText="查库频率" TextAlign="Left">
                            <Editor>
                                <x:TextBox ID="txt_CheckFrequency" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="150px" ColumnID="Description" DataField="Description" FieldType="String"
                            HeaderText="描述" TextAlign="Left">
                            <Editor>
                                <x:TextArea ID="txt_Description" runat="server" Height="50px" Label="Label" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="150px" ColumnID="ApplyTime" DataField="ApplyTime" FieldType="Date" Renderer="Date"
                            HeaderText="申请时间" TextAlign="Left">
                            <Editor>
                                <x:DatePicker ID="dp_ApplyTime" runat="server" EnableEdit="false"></x:DatePicker>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="150px" ColumnID="Remark" DataField="Remark" FieldType="String"
                            HeaderText="备注" TextAlign="Left">
                            <Editor>
                                <x:TextArea ID="txt_Remark" runat="server" Height="50px" Label="Label" Text=""></x:TextArea>
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
        <x:Window ID="WindowAdd" Title="添加查库频率" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            Target="Top" runat="server" OnClose="Window_Close" IsModal="true" Width="500px" Height="500px"
            EnableConfirmOnClose="true" EnableMaximize="false" EnableClose="true"
            EnableMinimize="false" EnableResize="false">
        </x:Window>
    </form>
</body>
</html>
<script src="../../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
<script src="../../jqueryui/js/jquery-ui-1.9.2.custom.js" type="text/javascript"></script>
<script type="text/javascript">
    function onReady() {
        var txt_Dealer = '<%= txt_DealerName.ClientID %>';

        var cache = {};

        $('#' + txt_Dealer).autocomplete({
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
