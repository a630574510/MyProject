<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RiskQuestionVerify.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.RiskQuestionVerify" %>

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
                        <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column" CssClass="x-form-item">
                            <Items>
                                <x:Label ID="Label2" runat="server" Text="经销商：" CssStyle="padding-right:10px" CssClass="inline"></x:Label>
                                <x:TextBox ID="txt_Dealer" runat="server" ShowLabel="false" Width="300px" Text=""></x:TextBox>

                                <x:Label ID="Label1" runat="server" Text="审批状态：" CssStyle="padding-right:10px;padding-left:10px" CssClass="inline"></x:Label>
                                <x:DropDownList ID="ddl_Status" runat="server" Width="100px">
                                    <x:ListItem Text="请选择" Value="-1" />
                                    <x:ListItem Text="已审核" Value="1" />
                                    <x:ListItem Text="未审核" Value="0" />
                                </x:DropDownList>
                            </Items>
                        </x:Panel>

                        <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true" Layout="Column" CssClass="x-form-item">
                            <Items>
                                <x:Button ID="btn_Search" runat="server" Text="查询" Visible="false" Icon="SystemSearch" OnClick="btn_Search_Click"></x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Grid ID="grid_List" runat="server" ShowHeader="false" EnableTextSelection="true" AllowPaging="true" IsDatabasePaging="true"
                    EnableCheckBoxSelect="true" OnPageIndexChange="grid_List_PageIndexChange" BoxFlex="2" ClicksToEdit="1" AllowCellEditing="true"
                    DataKeyNames="ID">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <x:Button ID="btn_Verify" runat="server" Text="审核" OnClick="btn_Verify_Click" Icon="Accept" Visible="false"></x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:RenderCheckField ColumnID="ch" Width="30px"/>
                        <x:BoundField Width="100px" ColumnID="No" DataField="No" HeaderText="编号" HideMode="Visibility" Hidden="true" />
                        <%--客户投诉字段--%>
                        <x:BoundField Width="110px" ColumnID="C_Date" DataField="C_Date" HeaderText="投诉时间" />
                        <x:BoundField Width="100px" ColumnID="C_AP" DataField="C_AP" HeaderText="投诉接收人" />
                        <x:BoundField Width="100px" ColumnID="C_Unit" DataField="C_Unit" HeaderText="投诉单位" />
                        <x:BoundField Width="100px" ColumnID="C_P" DataField="C_P" HeaderText="投诉人" />
                        <x:BoundField Width="100px" ColumnID="C_Post" DataField="C_Post" HeaderText="投诉人职务" />
                        <x:BoundField Width="100px" ColumnID="C_PPhone" DataField="C_PPhone" HeaderText="投诉人联系方式" />
                        <x:BoundField Width="100px" ColumnID="C_Content" DataField="C_Content" HeaderText="投诉内容" />
                        <%--监管员问题字段--%>
                        <x:BoundField Width="260px" ColumnID="SQ_Shop" DataField="SQ_Shop" HeaderText="监管店" />
                        <x:BoundField ColumnID="SQ_ShopID" DataField="SQ_ShopID" HideMode="Visibility" Hidden="true" />
                        <x:BoundField Width="200px" ColumnID="SQ_Bank" DataField="SQ_Bank" HeaderText="合作行" />
                        <x:BoundField ColumnID="SQ_BankID" DataField="SQ_BankID" HideMode="Visibility" Hidden="true" />
                        <x:BoundField Width="100px" ColumnID="SQ_Brand" DataField="SQ_Brand" HeaderText="品牌" />
                        <x:BoundField ColumnID="SQ_BrandID" DataField="SQ_BrandID" HideMode="Visibility" Hidden="true" />

                        <x:BoundField Width="100px" ColumnID="SQ_FBP" DataField="SQ_FBP" HeaderText="问题反馈人员" />
                        <x:BoundField Width="100px" ColumnID="SQ_FBPP" DataField="SQ_FBPP" HeaderText="联系方式" />
                        <x:RenderField Width="200px" ID="SQ_Content" ColumnID="SQ_Content" DataField="SQ_Content" FieldType="String" HideMode="Visibility" Hidden="true"
                            HeaderText="问题描述">
                            <Editor>
                                <x:TextArea ID="txt_SQ_Content" runat="server" Height="70px" Text="" Enabled="false"></x:TextArea>
                            </Editor>
                        </x:RenderField>

                        <x:RenderField Width="200px" ID="OPFD" ColumnID="OPFD" DataField="OPFD" FieldType="String" HideMode="Visibility" Hidden="true"
                            HeaderText="发现问题部门意见">
                            <Editor>
                                <x:TextArea ID="txt_OPFD" runat="server" Height="70px" Text="" Enabled="false"></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderCheckField ID="OPFDPIC" ColumnID="OPFDPIC" HeaderText="同意" Width="40px" HideMode="Visibility" Hidden="true" />

                        <x:RenderField Width="200px" ID="ORCD" ColumnID="ORCD" DataField="ORCD" FieldType="String" HideMode="Visibility" Hidden="true"
                            HeaderText="风控部意见">
                            <Editor>
                                <x:TextArea ID="txt_ORCD" runat="server" Height="70px" Text="" Enabled="false"></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderCheckField ID="ORCDPIC" ColumnID="ORCDPIC" HeaderText="同意" Width="40px" HideMode="Visibility" Hidden="true" />

                        <x:RenderField Width="200px" ID="OBD" ColumnID="OBD" DataField="OBD" FieldType="String" HideMode="Visibility" Hidden="true"
                            HeaderText="业务部意见">
                            <Editor>
                                <x:TextArea ID="txt_OBD" runat="server" Height="70px" Text="" Enabled="false"></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderCheckField ID="OBDPIC" ColumnID="OBDPIC" HeaderText="同意" Width="40px" HideMode="Visibility" Hidden="true" />

                        <x:RenderField Width="200px" ID="Result" ColumnID="Result" DataField="Result" FieldType="String" HideMode="Visibility" Hidden="true"
                            HeaderText="运营部处理结果">
                            <Editor>
                                <x:TextArea ID="txt_Result" runat="server" Height="70px" Text="" Enabled="false"></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderCheckField ID="ResultPIC" ColumnID="ResultPIC" HeaderText="同意" Width="40px" HideMode="Visibility" Hidden="true" />
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
</script>
