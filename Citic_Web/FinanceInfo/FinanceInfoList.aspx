<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FinanceInfoList.aspx.cs" EnableViewStateMac="false"
    Inherits="Citic_Web.Financing.FinanceInfoList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../Css/main.css" rel="stylesheet" />
    <link rel="stylesheet" href="../jqueryui/css/ui-lightness/jquery-ui-1.9.2.custom.min.css" />
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
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
            Title="融资信息" EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch"
            AutoWidth="true">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" Height="65px" CssStyle="padding-bottom:5px">
                    <Items>
                        <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Text="企业名称：" CssStyle="padding-right:8px" CssClass="inline"></x:Label>
                                <x:TextBox ID="txt_Dealer" runat="server" CssStyle="height:20px;font-size:15px" Width="306px" AutoPostBack="true" OnTextChanged="txt_Bank_TextChanged"></x:TextBox>
                                <x:Label ID="Label2" runat="server" Text="合作行：" CssStyle="padding-left:20px;padding-right:22px" CssClass="inline"></x:Label>
                                <x:DropDownList ID="ddl_Bank" runat="server" Width="300px"></x:DropDownList>
                                <x:Label ID="Label5" runat="server" Text="状态：" CssStyle="padding-left:20px;padding-right:10px" CssClass="inline"></x:Label>
                                <x:DropDownList ID="ddl_Status" runat="server" Width="100px">
                                    <x:ListItem Text="请选择" Value="-1" Selected="true" />
                                    <x:ListItem Text="正常" Value="1" />
                                    <x:ListItem Text="清票" Value="0" />
                                </x:DropDownList>
                            </Items>
                        </x:Panel>

                        <x:Panel ID="Panel4" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label3" runat="server" Text="开票日期：" CssStyle="padding-right:8px" CssClass="inline"></x:Label>
                                <x:DatePicker ID="dp_Start" runat="server" EnableEdit="false" Width="110px"></x:DatePicker>
                                <x:Label ID="Label4" runat="server" Text="到期日期：" CssStyle="padding-left:10px;padding-right:6px" CssClass="inline"></x:Label>
                                <x:DatePicker ID="dp_End" runat="server" EnableEdit="false" Width="114px"></x:DatePicker>
                                <x:Label ID="Label6" runat="server" Text="汇票号：" CssStyle="padding-left:20px;padding-right:22px" CssClass="inline"></x:Label>
                                <x:TextBox ID="txt_DraftNo" runat="server" Label="汇票号" Text="" CssStyle="height:20px;font-size:15px" Width="306px"></x:TextBox>
                                <x:Button runat="server" Text="查  询" ID="btn_Search" Icon="SystemSearch" EnablePostBack="true" OnClick="btn_Search_Click" CssStyle="padding-left:20px" Visible="false">
                                </x:Button>
                            </Items>
                        </x:Panel>
                    </Items>
                </x:SimpleForm>
                <x:Panel ID="Panel3" runat="server" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                    BoxFlex="1" Layout="Fit">
                    <Items>
                        <x:Grid ID="grid_List" PageSize="15" ShowBorder="true" ShowHeader="false" AllowPaging="true"
                            CssStyle="padding-top:0px" runat="server" EnableCheckBoxSelect="True" DataKeyNames="ID,DraftNo,BankID,DealerID,DraftType"
                            IsDatabasePaging="true" BoxConfigAlign="Stretch" OnPageIndexChange="grid_List_PageIndexChange"
                            EnableRowNumber="True" ClearSelectedRowsAfterPaging="false" EnableTextSelection="true" OnRowCommand="grid_List_RowCommand">
                            <Toolbars>
                                <x:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <x:Button ID="btn_Add" runat="server" Text="添加" Icon="Add" Visible="false" />
                                        <x:ToolbarSeparator ID="tbs_Add" runat="server" Visible="false" />
                                        <x:Button ID="btn_Delete" runat="server" Text="删除" Icon="Delete" OnClick="btn_Deletes_Click" Visible="false" />
                                        <x:ToolbarSeparator ID="tbs_Delete" runat="server" Visible="false" />
                                        <x:Button ID="btn_Clear" runat="server" Text="清票" Icon="CssDelete" OnClick="btn_Clear_Click" Visible="false" />
                                        <x:ToolbarSeparator ID="ToolbarSeparator2" runat="server" Visible="false" />
                                        <x:HyperLink ID="HyperLink1" runat="server" Label="" NavigateUrl="~/Templates/融资信息导入表-模版.xls" Target="_blank" Text="融资信息导入模版下载"></x:HyperLink>
                                        <x:ToolbarFill ID="ToolbarFill2" runat="server" />
                                        <x:Button ID="btn_Import" runat="server" Text="导入数据（Excel文件）" Icon="DiskDownload" Visible="false" />
                                        <x:ToolbarSeparator ID="tbs_Excel" runat="server" Visible="false">
                                        </x:ToolbarSeparator>
                                        <x:Button ID="btn_Export" runat="server" Text="生成Excel" Icon="PageWhiteExcel" OnClick="btn_ExportExcel_Click" Visible="false">
                                        </x:Button>
                                        <x:HyperLink ID="hl_ExportExcel" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出本页数据"></x:HyperLink>
                                        <x:ToolbarSeparator ID="bl_Separator" runat="server" Visible="false" />
                                        <x:HyperLink ID="hl_ExportAll" runat="server" ShowLabel="false" NavigateUrl="" Target="_blank" Visible="false" Text="导出全部数据"></x:HyperLink>
                                    </Items>
                                </x:Toolbar>
                            </Toolbars>
                            <Columns>
                                <x:BoundField ColumnID="DealerName" HeaderText="企业" DataField="DealerName" Width="240px" />
                                <x:BoundField ColumnID="PledgeNo" HeaderText="质押号" DataField="PledgeNo" Width="150px" />
                                <x:WindowField ColumnID="DraftNo" DataTextField="DraftNo" HeaderText="汇票号" WindowID="WindowDraftInfo"
                                    DataIFrameUrlFields="DraftNo,BankID,DealerID" DataIFrameUrlFormatString="../FinanceInfo/DraftInfo.aspx?draftNo={0}&c_t=tb_Car_{1}_{2}" Width="200px" />
                                <x:BoundField ColumnID="BeginTime" HeaderText="开票日期" DataField="BeginTime" />
                                <x:BoundField ColumnID="EndTime" HeaderText="到期日期" DataField="EndTime" />
                                <x:BoundField ColumnID="GuaranteeNo" HeaderText="保证金帐号" DataField="GuaranteeNo" />
                                <x:BoundField ColumnID="DarftMoney" HeaderText="票面金额" DataField="DarftMoney" />
                                <x:BoundField ColumnID="CarStock" HeaderText="库存台数" DataField="CarStock" Width="60px" />
                                <x:BoundField ColumnID="HKMoney" HeaderText="回款金额" DataField="HKMoney" Width="100px" />
                                <x:BoundField ColumnID="CKMoney" HeaderText="敞口金额" DataField="CKMoney" Width="100px" />
                                <x:BoundField ColumnID="YYMoney" HeaderText="已押金额" DataField="YYMoney" Width="100px" />
                                <x:BoundField ColumnID="WYMoney" HeaderText="未押金额" DataField="WYMoney" Width="100px" />
                                <x:BoundField ColumnID="DraftTypeName" HeaderText="状态" DataField="DraftTypeName" Width="60px" />
                                <x:BoundField ColumnID="ID" DataField="ID" HideMode="Visibility" Hidden="true" />
                                <x:BoundField ColumnID="DraftNo_" DataField="DraftNo" HideMode="Visibility" Hidden="true" />
                                <x:BoundField ColumnID="BankID_" DataField="BankID" HideMode="Visibility" Hidden="true" />
                                <x:BoundField ColumnID="DealerID_" DataField="DealerID" HideMode="Visibility" Hidden="true" />
                            </Columns>
                            <PageItems>
                                <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </x:ToolbarSeparator>
                                <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                                </x:ToolbarText>
                                <x:DropDownList runat="server" ID="ddlPageSize" Width="45px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                    <x:ListItem Text="5" Value="5" />
                                    <x:ListItem Text="10" Value="10" />
                                    <x:ListItem Text="15" Value="15" Selected="true" />
                                    <x:ListItem Text="20" Value="20" />
                                </x:DropDownList>
                            </PageItems>
                        </x:Grid>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
        <x:Window ID="WindowAdd" Title="添加汇票" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            Target="Top" runat="server" OnClose="Window_Close" IsModal="true" Width="1150px" Height="500px"
            EnableConfirmOnClose="true" EnableMaximize="false" EnableClose="true"
            EnableMinimize="false" EnableResize="false">
        </x:Window>
        <x:Window ID="WindowDraftInfo" Title="汇票信息" Popup="false" EnableIFrame="true" IFrameUrl="about:blank"
            Target="Top" runat="server" OnClose="Window_Close" IsModal="true" Width="1200px"
            EnableConfirmOnClose="true" Height="620px" EnableMaximize="false" EnableClose="true"
            EnableMinimize="false" EnableResize="false">
        </x:Window>
    </form>

    <script src="../jqueryui/js/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script src="../jqueryui/js/jquery-ui-1.9.2.custom.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function onReady() {
            var txt_Bank = '<%= txt_Dealer.ClientID %>';

            $('#' + txt_Bank).autocomplete({
                source: function (request, response) {
                    var term = request.term;

                    $.getJSON("../Handlers/searchDealer.ashx", request, function (data, status, xhr) {
                        response(data);
                    });
                }
            });
        }
    </script>
</body>
</html>
