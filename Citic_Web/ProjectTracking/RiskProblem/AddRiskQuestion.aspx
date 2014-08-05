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
            EnableBackgroundColor="true" Layout="Fit">
            <Items>
                <x:Grid ID="grid_List" runat="server" EnableBackgroundColor="true" ShowHeader="false" ShowBorder="false" ClicksToEdit="1" AllowCellEditing="true">
                    <Toolbars>
                        <x:Toolbar runat="server">
                            <Items>
                                <x:Button ID="btn_Add" OnClick="btn_Add_Click" runat="server" Text="确定添加" Icon="Add"></x:Button>
                                <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server"></x:ToolbarSeparator>
                                <x:Button ID="btn_Checking_Car" runat="server" Text="信息验证" Icon="ArrowRefresh" OnClick="btn_Checking_Car_Click"
                                    Enabled="false">
                                </x:Button>
                                <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server"></x:ToolbarSeparator>
                                <x:Button ID="btn_Add_Table" EnablePostBack="false" runat="server" Text="添加行" Icon="TableAdd" />
                                <x:ToolbarSeparator ID="ToolbarSeparator3" runat="server"></x:ToolbarSeparator>
                                <x:Button ID="btn_Delete_Table" EnablePostBack="false" runat="server" Text="删除选中行" Icon="TableDelete" />
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:RenderField Width="260px" ColumnID="SQ_Shop" DataField="SQ_Shop" FieldType="String"
                            HeaderText="监管店">
                            <Editor>
                                <x:TextBox ID="SQ_Shop" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>

                        <%--客户投诉字段--%>
                        <x:RenderField Width="100px" ColumnID="CC_Date" DataField="CC_Date" FieldType="Date"
                            HeaderText="投诉时间" Renderer="Date" RendererArgument="yyyy-MM-dd">
                            <Editor>
                                <x:DatePicker ID="CC_Date" Required="true" runat="server" EnableEdit="false">
                                </x:DatePicker>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="CC_AP" DataField="CC_AP" FieldType="String"
                            HeaderText="投诉接收人">
                            <Editor>
                                <x:TextBox ID="CC_AP" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="CC_Unit" DataField="CC_Unit" FieldType="String"
                            HeaderText="投诉单位">
                            <Editor>
                                <x:TextBox ID="CC_Unit" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="CC_P" DataField="CC_P" FieldType="String"
                            HeaderText="投诉人">
                            <Editor>
                                <x:TextBox ID="CC_P" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="CC_Post" DataField="CC_Post" FieldType="String"
                            HeaderText="投诉人职务">
                            <Editor>
                                <x:TextBox ID="CC_Post" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="CC_PPhone" DataField="CC_PPhone" FieldType="String"
                            HeaderText="投诉人联系方式">
                            <Editor>
                                <x:TextBox ID="CC_PPhone" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="CC_Content" DataField="CC_Content" FieldType="String"
                            HeaderText="投诉内容">
                            <Editor>
                                <x:TextBox ID="CC_Content" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <%--监管员问题字段--%>
                        <%-- 监管店的品牌与监管员是一一对应，如果该店有两个合作品牌，则取第一个。--%>
                        <%-- <x:RenderField Width="100px" ColumnID="SQ_Brand" DataField="SQ_Brand" FieldType="String"
                            HeaderText="监管品牌">
                            <Editor>
                                <x:TextBox ID="SQ_Brand" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="SQ_Name" DataField="SQ_Name" FieldType="String"
                            HeaderText="监管员姓名">
                            <Editor>
                                <x:TextBox ID="SQ_Name" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="SQ_Phone" DataField="SQ_Phone" FieldType="String"
                            HeaderText="监管员联系方式">
                            <Editor>
                                <x:TextBox ID="SQ_Phone" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>--%>
                        <%-- 问题反馈人员为登录人员，联系方式亦然 --%>
                        <%--<x:RenderField Width="100px" ColumnID="SQ_FBP" DataField="SQ_FBP" FieldType="String"
                            HeaderText="问题反馈人员">
                            <Editor>
                                <x:TextBox ID="SQ_FBP" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="SQ_FBPP" DataField="SQ_FBPP" FieldType="String"
                            HeaderText="联系方式">
                            <Editor>
                                <x:TextBox ID="SQ_FBPP" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>--%>
                        <x:RenderField Width="100px" ColumnID="SQ_Content" DataField="SQ_Content" FieldType="String"
                            HeaderText="问题描述">
                            <Editor>
                                <x:TextArea ID="SQ_Content" runat="server" Height="50px" Label="Label" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>


                        <x:RenderField Width="100px" ColumnID="S_P" DataField="S_P" FieldType="String"
                            HeaderText="调查人">
                            <Editor>
                                <x:TextBox ID="S_P" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>
                        <%--<x:RenderField Width="100px" ColumnID="S_Phone" DataField="S_Phone" FieldType="String"
                            HeaderText="调查人联系方式">
                            <Editor>
                                <x:TextBox ID="S_Phone" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>--%>
                        <x:RenderField Width="100px" ColumnID="S_Result" DataField="S_Result" FieldType="String"
                            HeaderText="调查结果">
                            <Editor>
                                <x:TextArea ID="S_Result" runat="server" Height="50px" Label="Label" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>

                        <x:RenderField Width="100px" ColumnID="GD" DataField="GD" FieldType="String"
                            HeaderText="违反的规定">
                            <Editor>
                                <x:TextBox ID="GD" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>

                        <%--<x:RenderField Width="100px" ColumnID="WTCLBF" DataField="WTCLBF" FieldType="String"
                            HeaderText="问题处理办法">
                            <Editor>
                                <x:TextArea ID="WTCLBF" runat="server" Height="50px" Label="Label" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="FXWTBMQZ" DataField="FXWTBMQZ" FieldType="String"
                            HeaderText="发现问题部门签字">
                            <Editor>
                                <x:TextBox ID="FXWTBMQZ" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>

                        <x:RenderField Width="100px" ColumnID="QCJRZXYJ" DataField="QCJRZXYJ" FieldType="String"
                            HeaderText="汽车金融中心意见">
                            <Editor>
                                <x:TextArea ID="QCJRZXYJ" runat="server" Height="50px" Label="Label" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="QCJRZXQZ" DataField="QCJRZXQZ" FieldType="String"
                            HeaderText="汽车金融中心负责人签字">
                            <Editor>
                                <x:TextBox ID="QCJRZXQZ" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>

                        <x:RenderField Width="100px" ColumnID="GLZXYJ" DataField="GLZXYJ" FieldType="String"
                            HeaderText="管理中心意见">
                            <Editor>
                                <x:TextArea ID="GLZXYJ" runat="server" Height="50px" Label="Label" Text=""></x:TextArea>
                            </Editor>
                        </x:RenderField>
                        <x:RenderField Width="100px" ColumnID="GLZXQZ" DataField="GLZXQZ" FieldType="String"
                            HeaderText="管理中心负责人签字">
                            <Editor>
                                <x:TextBox ID="GLZXQZ" runat="server" ShowLabel="false" Text=""></x:TextBox>
                            </Editor>
                        </x:RenderField>--%>
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
    function onReady() {

    }
    function Init() {
        setTimeout("LoadAutoComplete()", 1000);
    }
    function LoadAutoComplete() {
        var txt_Dealer = '<%= SQ_Shop.ClientID %>';
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

