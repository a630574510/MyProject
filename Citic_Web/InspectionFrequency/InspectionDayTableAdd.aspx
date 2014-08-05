<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionDayTableAdd.aspx.cs"
    Inherits="Citic_Web.InspectionFrequency.InspectionDayTableAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加视频日报表</title>
    <link href="../Css/main.css" rel="stylesheet" />
    <link rel="stylesheet" href="../jqueryui/css/ui-lightness/jquery-ui-1.9.2.custom.min.css" />
    <style type="text/css">
        .ui-autocomplete-loading
        {
            background: white url('../../Images/ui-anim_basic_16x16.gif') right center no-repeat;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" Layout="Fit" EnableBackgroundColor="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="true"
                Title="添加视频检查" Layout="Fit" BoxFlex="1" EnableBackgroundColor="true">
                <Toolbars>
                    <x:Toolbar runat="server">
                        <Items>
                            <x:SimpleForm ID="SimpleForm1" ShowHeader="false" ShowBorder="false" EnableBackgroundColor="true"
                                runat="server" Width="1000px">
                                <Items>
                                    <x:TextBox ID="P_txt_DealerName" runat="server" Label="经销店名称" Text="" ShowLabel="true"
                                        Width="200px">
                                    </x:TextBox>
                                    <%--<x:Label ID="Label1" runat="server" Label="Label" Text="Label">
                                    </x:Label>--%>
                                    <%--<x:TextBox ID="P_txt_Bank" runat="server" Label="合作银行" Text="" ShowLabel="true" Width="200px">
                                    </x:TextBox>--%>
                                </Items>
                            </x:SimpleForm>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Grid ID="G_DayTabel" runat="server" Title="具体检查情况" EnableRowNumber="true" EnableBackgroundColor="true"
                        AllowCellEditing="true" ClicksToEdit="1" EnableColumnLines="true" ForceFitAllTime="true"
                        EnableAfterEditEvent="false" OnAfterEdit="G_DayTabel_AfterEdit">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button ID="btn_Add_Day" runat="server" Text="添加" Icon="Add" OnClick="Add_Day_Click">
                                    </x:Button>
                                    <x:ToolbarSeparator ID="ToolbarSeparator4" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_Del_Day" runat="server" Text="删除选中行" Icon="Delete" EnablePostBack="true" OnClick="Del_Day_Click">
                                    </x:Button>
                                    <x:ToolbarSeparator ID="ToolbarSeparator9" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_Band_Day" runat="server" Text="清空" Icon="ArrowRotateAnticlockwise"
                                        OnClick="Band_DayClick">
                                    </x:Button>
                                    <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                    </x:ToolbarSeparator>
                                    <x:Button ID="btn_G_DayTabel_Add" EnablePostBack="true" runat="server" Text="添加行"
                                        Icon="TableAdd" OnClick="Add_G_DayTabel">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Columns>
                            <x:RenderField ColumnID="Area" DataField="Area" FieldType="String" HeaderText="区域中心">
                                <Editor>
                                    <%--<x:TextBox ID="txt_Area" runat="server" Text="" Required="true">
                                    </x:TextBox>--%>
                                    <x:DropDownList ID="txt_Area" runat="server" Label="Label">
                                        <x:ListItem Text="华北区域中心" Value="华北区域中心" />
                                        <x:ListItem Text="华南区域中心" Value="华南区域中心" />
                                        <x:ListItem Text="西南区域中心" Value="西南区域中心" />
                                        <x:ListItem Text="东北区域中心" Value="东北区域中心" />
                                        <x:ListItem Text="华东区域中心" Value="华东区域中心" />
                                        <x:ListItem Text="华中区域中心" Value="华中区域中心" />
                                        <x:ListItem Text="西北区域中心" Value="西北区域中心" />
                                        <x:ListItem Text="总部" Value="总部" />
                                    </x:DropDownList>
                                </Editor>
                            </x:RenderField>
                            <%-- <x:RenderField ColumnID="Rummager" DataField="Rummager" FieldType="String" HeaderText="检查人员">
                                <Editor>
                                    <x:TextBox ID="txt_Rummager" runat="server" Text="">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>--%>
                            <x:RenderField ColumnID="DealerName" DataField="DealerName" FieldType="String" HeaderText="经销店名称">
                                <Editor>
                                    <x:TextBox ID="txt_DealerName" runat="server" Text="" Readonly="true">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField ColumnID="Bank" DataField="Bank" FieldType="String" HeaderText="合作银行">
                                <Editor>
                                    <x:TextBox ID="txt_Bank" runat="server" Text="" Readonly="true">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField ColumnID="BrandName" DataField="BrandName" FieldType="String" HeaderText="品牌">
                                <Editor>
                                    <x:TextBox ID="txt_BrandName" runat="server" Text="" Readonly="true">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField ColumnID="SupervisorName" DataField="SupervisorName" FieldType="String"
                                HeaderText="监管员">
                                <Editor>
                                    <x:TextBox ID="txt_SupervisorName" runat="server" Text="">
                                    </x:TextBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField ColumnID="Model" DataField="Model" FieldType="String" HeaderText="监管模式"
                                Width="70px">
                                <Editor>
                                    <x:DropDownList ID="txt_Model" runat="server" Label="Label" Readonly="true">
                                        <x:ListItem Text="车证钥匙" Value="车证钥匙" />
                                        <x:ListItem Text="合格证" Value="合格证" />
                                    </x:DropDownList>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField ColumnID="Inventory" DataField="Inventory" FieldType="String" HeaderText="库存">
                                <Editor>
                                    <x:NumberBox ID="txt_Inventory" runat="server" Label="Label">
                                    </x:NumberBox>
                                </Editor>
                            </x:RenderField>
                            <x:RenderField ColumnID="QuartersLedger" DataField="QuartersLedger" FieldType="String"
                                HeaderText="总部总账">
                                <Editor>
                                    <x:TextArea ID="txt_QuartersLedger" runat="server" Height="50px" Label="Label" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                            <x:RenderCheckField ColumnID="QuartersLedgerStatu" DataField="QuartersLedgerStatu"
                                Width="40px" HeaderText="总账" />
                            <x:RenderField ColumnID="MainProblem" DataField="MainProblem" FieldType="String"
                                HeaderText="主要问题">
                                <Editor>
                                    <x:TextArea ID="txt_MainProblem" runat="server" Height="50px" Label="Label" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                            <x:RenderCheckField ColumnID="MainProblemStatu" DataField="MainProblemStatu" Width="40px"
                                HeaderText="主要" />
                            <x:RenderField HeaderText="历史检查时间" DataField="HistoryDate" FieldType="String" Width="100px"
                                ColumnID="HistoryDate" RendererArgument="yyyy-MM-dd" Renderer="Date">
                                <Editor>
                                    <x:DatePicker ID="DP_HistoryDate" runat="server" Label="Label">
                                    </x:DatePicker>
                                </Editor>
                            </x:RenderField>
                            <x:RenderCheckField ColumnID="ContinueStatu" DataField="ContinueStatu" Width="40px"
                                HeaderText="持续" />
                            <x:RenderField ColumnID="Remark" DataField="Remark" FieldType="String" HeaderText="备注">
                                <Editor>
                                    <x:TextArea ID="txt_Remark" runat="server" Height="50px" Label="Label" Text="">
                                    </x:TextArea>
                                </Editor>
                            </x:RenderField>
                            <x:RenderCheckField ColumnID="IsConform" DataField="IsConform" Width="70px" HeaderText="是否符合" />
                        </Columns>
                    </x:Grid>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
    <script src="../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../jqueryui/js/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function onReady() {
            var textbox1ID = '<%= P_txt_DealerName.ClientID %>';

            var cache = {};

            $('#' + textbox1ID).autocomplete({
                minLength: 2,
                source: function (request, response) {
                    var term = request.term;
                    if (term in cache) {
                        response(cache[term]);
                        return;
                    }

                    $.getJSON("InspectionSearch.ashx", request, function (data, status, xhr) {
                        cache[term] = data;

                        //str = data.toString();
                        //arr = str.split(",")[0];
                        //alert(arr);
                        response(data);
                    });
                }
            });

        }
    
    </script>
</body>
</html>
