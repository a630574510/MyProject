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
                                <x:Label ID="Label1" runat="server" Text="审批状态：" CssStyle="padding-right:10px"></x:Label>
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
                        <x:RenderCheckField ColumnID="ch" HeaderText="选择" Width="40px" />
                        <%--客户投诉字段--%>
                        <x:BoundField Width="100px" ColumnID="No" DataField="No" HeaderText="编号" />
                        <x:BoundField Width="100px" ColumnID="CC_Date" DataField="CC_Date" DataFormatString="{0}" HeaderText="投诉时间" />

                        <x:BoundField Width="100px" ColumnID="CC_Content" DataField="CC_Content" HeaderText="投诉内容" />
                        <%--监管员问题字段--%>
                        <x:BoundField Width="260px" ColumnID="SQ_Shop" DataField="SQ_Shop" HeaderText="监管店" />

                        <x:BoundField Width="100px" ColumnID="SQ_FBP" DataField="SQ_FBP" HeaderText="问题反馈人员" />
                        <x:BoundField Width="100px" ColumnID="SQ_FBPP" DataField="SQ_FBPP" HeaderText="联系方式" />
                        <x:BoundField Width="100px" ColumnID="SQ_Content" DataField="SQ_Content" HeaderText="问题描述" />
                        <x:BoundField Width="100px" ColumnID="S_P" DataField="S_P" HeaderText="调查人" />

                        <x:BoundField Width="100px" ColumnID="S_Result" DataField="S_Result" HeaderText="调查结果" />

                        <x:RenderField Width="100px" ColumnID="WTCLBF" DataField="WTCLBF" FieldType="String"
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
