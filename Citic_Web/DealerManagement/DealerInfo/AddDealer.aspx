<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddDealer.aspx.cs" Inherits="Citic_Web.DealerManagement.DealerInfo.AddDealer" %>

<%@ Register Src="~/UserControls/WUC_Address.ascx" TagPrefix="uc1" TagName="WUC_Address" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel2" />
        <x:Panel ID="Panel2" runat="server" EnableBackgroundColor="true" BodyPadding="5px"
            ShowBorder="false" ShowHeader="true" Title="企业信息" Layout="Table" TableConfigColumns="3"
            Height="600px">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" ValidateForms="sf_DealerInfo" runat="server" Text="保存经销商"
                            Icon="SystemSaveNew" OnClick="btn_SaveDeader_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Panel ID="Panel3" EnableBackgroundColor="true" runat="server" BodyPadding="5px" TableRowspan="2" Height="540px" Width="450px"
                    ShowHeader="true" Title="经销商信息" CssStyle="padding-right:5px" Layout="Fit" BoxConfigAlign="StretchMax"
                    BoxFlex="1">
                    <Items>
                        <x:SimpleForm ID="sf_DealerInfo" runat="server" AutoScroll="true" BoxFlex="1" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                            EnableBackgroundColor="true" LabelWidth="120px">
                            <Items>
                                <x:TextBox ID="txt_DealerName" Width="300px" runat="server" ShowRedStar="true" Label="经销商名称" Text=""
                                    Required="true" RequiredMessage="请输入经销商名称！">
                                </x:TextBox>
                                <x:TextBox ID="txt_JC" runat="server" Label="简称" Text="" Width="300px"></x:TextBox>
                                <x:CheckBoxList ID="cbl_DealerType" runat="server" Width="300px" Label="经销商属性">
                                    <x:CheckItem Text="民营" Value="1" />
                                    <x:CheckItem Text="国营" Value="2" />
                                    <x:CheckItem Text="集团" Value="3" />
                                    <x:CheckItem Text="单店" Value="4" />
                                </x:CheckBoxList>
                                <x:CheckBox ID="chk_IsGroup" runat="server" Label="是否是集团性质" Text="" Visible="false"></x:CheckBox>
                                <x:TextBox ID="txt_OtherIndustries" runat="server" Label="其他产业" Text="" Width="300px"></x:TextBox>
                                <x:DropDownList ID="ddl_GotoworkTime" runat="server" Label="上班时间" Width="300px">
                                    <x:ListItem Value="06:30" Text="06:30" />
                                    <x:ListItem Value="07:00" Text="07:00" />
                                    <x:ListItem Value="07:30" Text="07:30" />
                                    <x:ListItem Value="08:00" Text="08:00" Selected="true" />
                                    <x:ListItem Value="08:30" Text="08:30" />
                                    <x:ListItem Value="09:00" Text="09:00" />
                                    <x:ListItem Value="09:30" Text="09:30" />
                                    <x:ListItem Value="10:00" Text="10:00" />
                                </x:DropDownList>
                                <x:DropDownList ID="ddl_GoffworkTime" runat="server" Label="下班时间" Width="300px">
                                    <x:ListItem Value="17:00" Text="17:00" />
                                    <x:ListItem Value="17:30" Text="17:30" />
                                    <x:ListItem Value="18:00" Text="18:00" />
                                    <x:ListItem Value="18:30" Text="18:30" />
                                    <x:ListItem Value="19:00" Text="19:00" />
                                    <x:ListItem Value="19:30" Text="19:30" />
                                    <x:ListItem Value="20:00" Text="20:00" />
                                    <x:ListItem Value="20:30" Text="20:30" />
                                    <x:ListItem Value="21:00" Text="21:00" Selected="true" />
                                    <x:ListItem Value="21:30" Text="21:30" />
                                    <x:ListItem Value="22:00" Text="22:00" />
                                </x:DropDownList>
                                <x:TextBox ID="txt_OrganizationCode" runat="server" Label="组织机构代码" Width="300px" ShowRedStar="true" Text="" RequiredMessage="请填写组织机构代码！" CompareType="String" CompareValue="" CompareOperator="NotEqual" CompareMessage="请填写组织机构代码！"></x:TextBox>

                                <x:TextBox ID="txt_YWZ" runat="server" Width="300px" Label="经销商业务章" Text=""></x:TextBox>
                                <x:UserControlConnector ID="UserControlConnector1" runat="server">
                                    <uc1:WUC_Address runat="server" ID="WUC_Address" />
                                </x:UserControlConnector>
                                <x:TextArea ID="txt_Remark" runat="server" Height="100px" Width="300px" Label="备注"
                                    Text="">
                                </x:TextArea>
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>

                <x:Panel ID="pnl_DealerLinkman" EnableBackgroundColor="true" runat="server" BodyPadding="0px" Height="250px"
                    ShowHeader="true" ShowBorder="true" Width="385px" Title="企业联系人" CssStyle="padding-right:5px"
                    Layout="VBox" BoxConfigAlign="Stretch">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar6" runat="server">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="姓名：" Width="30px" CssStyle="margin-right:3px;margin-left:2px">
                                </x:Label>
                                <x:TextBox ID="txt_LinkmanName1" Width="90px" runat="server" Label="姓名" Text="" CssStyle="margin-right:5px">
                                </x:TextBox>
                                <x:Label ID="Label2" runat="server" Text="电话：" Width="30px" CssStyle="margin-right:3px;margin-left:2px">
                                </x:Label>
                                <x:TextBox ID="num_Phone1" Width="120px" runat="server" Label="电话" Text="">
                                </x:TextBox>
                                <x:Button ID="btn_AddLinkman1" runat="server" Text="" Icon="Add" OnClick="btn_Add">
                                </x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Panel ID="Panel11" runat="server" EnableBackgroundColor="true" ShowBorder="false" ShowHeader="false" Width="328px">
                            <Toolbars>
                                <x:Toolbar ID="Toolbar5" runat="server">
                                    <Items>
                                        <x:Label ID="Label6" runat="server" Text="传真：" Width="30px" CssStyle="margin-right:3px;margin-left:2px">
                                        </x:Label>
                                        <x:TextBox ID="txt_Fax1" runat="server" Width="90px" Text="" CssStyle="margin-right:5px">
                                        </x:TextBox>
                                        <x:Label ID="Label5" runat="server" Text="邮箱：" Width="30px" CssStyle="margin-right:3px;margin-left:2px">
                                        </x:Label>
                                        <x:TextBox ID="txt_Email1" Width="120px" runat="server" Text="">
                                        </x:TextBox>
                                    </Items>
                                </x:Toolbar>
                            </Toolbars>
                        </x:Panel>
                        <x:Grid ID="grid_List1" runat="server" EnableRowNumber="true" BoxFlex="1" EnableTextSelection="true"
                            ShowBorder="false" ShowHeader="false" DataKeyNames="dc_ID,dc_Name,dc_Phone" IsDatabasePaging="true"
                            ClearSelectedRowsAfterPaging="false"
                            OnRowCommand="grid_List_RowCommand">
                            <Columns>
                                <x:LinkButtonField ColumnID="link_Delete" ConfirmIcon="Warning" ConfirmTarget="Parent" Width="40px"
                                    ConfirmText="确定要删除？" ConfirmTitle="系统提示" Text="删除" CommandName="delete" HeaderText="删除" />
                                <x:BoundField ColumnID="bf_LinkmanName1" DataField="dc_Name" DataFormatString="{0}"
                                    HeaderText="名称" />
                                <x:BoundField ColumnID="bf_ParentName1" DataField="dc_Phone" DataFormatString="{0}"
                                    HeaderText="电话" />
                                <x:BoundField ColumnID="bf_Fax1" DataField="dc_Fax" DataFormatString="{0}"
                                    HeaderText="传真" />
                                <x:BoundField ColumnID="bf_Email1" DataField="dc_Email" DataFormatString="{0}"
                                    HeaderText="邮箱" />
                            </Columns>
                        </x:Grid>
                    </Items>
                </x:Panel>
                <x:Panel ID="pnl_BankLinkman" EnableBackgroundColor="true" runat="server" BodyPadding="0px" BoxFlex="2" Layout="VBox" BoxConfigAlign="Stretch"
                    ShowHeader="true" ShowBorder="true" Width="384px" Height="250px" Title="银行客户经理联系人">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar3" runat="server" Position="Top">
                            <Items>
                                <x:Label ID="Label3" runat="server" Text="姓名：" Width="30px" CssStyle="margin-right:3px;margin-left:2px">
                                </x:Label>
                                <x:TextBox ID="txt_LinkmanName2" Width="90px" runat="server" Label="姓名" Text="" CssStyle="margin-right:5px">
                                </x:TextBox>
                                <x:Label ID="Label4" runat="server" Text="电话：" Width="30px" CssStyle="margin-right:3px;margin-left:2px">
                                </x:Label>
                                <x:TextBox ID="num_Phone2" Width="120px" runat="server" Label="电话" Text="">
                                </x:TextBox>
                                <x:Button ID="btn_AddLinkman2" runat="server" Text="" Icon="Add" OnClick="btn_Add">
                                </x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Items>
                        <x:Panel ID="Panel1" runat="server" EnableBackgroundColor="true" ShowBorder="false" ShowHeader="false" Width="328px">
                            <Toolbars>
                                <x:Toolbar ID="Toolbar7" runat="server">
                                    <Items>
                                        <x:Label ID="Label7" runat="server" Text="传真：" Width="30px" CssStyle="margin-right:3px;margin-left:2px">
                                        </x:Label>
                                        <x:TextBox ID="txt_Fax2" runat="server" Width="90px" Text="" CssStyle="margin-right:5px">
                                        </x:TextBox>
                                        <x:Label ID="Label8" runat="server" Text="邮箱：" Width="30px" CssStyle="margin-right:3px;margin-left:2px">
                                        </x:Label>
                                        <x:TextBox ID="txt_Email2" Width="120px" runat="server" Text="">
                                        </x:TextBox>
                                    </Items>
                                </x:Toolbar>
                            </Toolbars>
                        </x:Panel>
                        <x:Grid ID="grid_List2" runat="server" EnableRowNumber="true" BoxFlex="1" EnableTextSelection="true"
                            ShowBorder="false" ShowHeader="false" DataKeyNames="dc_ID,dc_Name,dc_Phone" IsDatabasePaging="true"
                            ClearSelectedRowsAfterPaging="false" OnRowCommand="grid_List_RowCommand">
                            <Columns>
                                <x:LinkButtonField ColumnID="link_Delete" ConfirmIcon="Warning" ConfirmTarget="Parent" Width="40px"
                                    ConfirmText="确定要删除？" ConfirmTitle="系统提示" Text="删除" CommandName="delete" HeaderText="删除" />
                                <x:BoundField ColumnID="bf_LinkmanName2" DataField="dc_Name" DataFormatString="{0}"
                                    HeaderText="名称" />
                                <x:BoundField ColumnID="bf_ParentName2" DataField="dc_Phone" DataFormatString="{0}"
                                    HeaderText="电话" />
                                <x:BoundField ColumnID="bf_Fax2" DataField="dc_Fax" DataFormatString="{0}"
                                    HeaderText="传真" />
                                <x:BoundField ColumnID="bf_Email2" DataField="dc_Email" DataFormatString="{0}"
                                    HeaderText="邮箱" />
                            </Columns>
                        </x:Grid>
                    </Items>
                </x:Panel>

                <x:Grid ID="grid_BankList" runat="server" BoxFlex="1" Title="合作行信息" EnableBackgroundColor="true" TableColspan="2"
                    ShowHeader="true" ShowBorder="true" DataKeyNames="BankID,BankName,BrandID" Height="290px" Width="770px"
                    AutoScroll="true" CssStyle="padding-top:5px" EnableTextSelection="true"
                    OnRowDataBound="grid_BankList_RowDataBound" OnRowCommand="grid_BankList_RowCommand">
                    <Toolbars>
                        <x:Toolbar ID="Toolbar8" runat="server">
                            <Items>
                                <x:Button ID="btn_ChoiseBank" runat="server" Text="选择合作行" Type="Button" Size="Large" Icon="Add" OnClick="btn_ChoiseBank_Click"></x:Button>
                            </Items>
                        </x:Toolbar>
                    </Toolbars>
                    <Columns>
                        <x:BoundField HeaderText="合作行名称" DataField="BankName" Width="150px" />
                        <x:BoundField HeaderText="合作品牌" DataField="BrandName" Width="100px" />
                        <x:BoundField HeaderText="业务模式" DataField="BusinessMode" Width="80px" />
                        <x:BoundField HeaderText="实收费用" DataField="SSMoney" Width="60px" />
                        <x:BoundField HeaderText="应收费用" DataField="YSMoney" Width="60px" />
                        <x:BoundField HeaderText="付费周期" DataField="PaymentCycle" Width="60px" />
                        <x:BoundField HeaderText="驻店日期" DataField="DispatchTime" Width="150px" />
                        <x:LinkButtonField HeaderText="操作" Text="删除" CommandName="del" ConfirmText="确认要删除？" ConfirmTitle="系统提示" ConfirmIcon="Warning" />
                    </Columns>
                </x:Grid>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hf_BankIDs" runat="server">
        </x:HiddenField>
        <x:HiddenField ID="hf_Banks" runat="server"></x:HiddenField>
        <x:Window ID="windowAdd" Title="添加联系人" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            EnableMaximize="true" Target="Top" EnableResize="true" runat="server" IsModal="true"
            Width="840px" EnableConfirmOnClose="true" Height="620px">
        </x:Window>
        <x:Window ID="WindowShowBank" runat="server" BodyPadding="5px" Popup="false" Title="合作行信息"
            Width="1200px" Height="600px" EnableIFrame="true" IFrameUrl="about:blank" EnableMaximize="true"
            Target="Top" EnableResize="true" EnableConfirmOnClose="true" IsModal="true">
        </x:Window>
    </form>
</body>
</html>
