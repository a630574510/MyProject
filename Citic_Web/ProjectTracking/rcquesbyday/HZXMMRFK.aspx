<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HZXMMRFK.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.HZXMMRFK" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel3" />
        <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" Layout="Fit">
            <Items>
                <x:TabStrip ID="TabStrip1" runat="server" ActiveTabIndex="0" ShowBorder="True">
                    <Tabs>
                        <x:Tab ID="Tab3" runat="server" BodyPadding="5px" EnableBackgroundColor="true" Title="每日风控问题追踪" Layout="Fit">
                            <Items>
                                <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                                    EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Left">
                                    <Items>
                                        <x:Form ID="Form3" runat="server" BodyPadding="5px" ShowHeader="false" CssStyle="padding-bottom:5px"
                                            ShowBorder="true" EnableBackgroundColor="true" Height="40px">
                                            <Rows>
                                                <x:FormRow ID="FormRow2" runat="server">
                                                    <Items>
                                                        <x:Button ID="btn_Search2" runat="server" Text="查询" OnClick="btn_Search_Click"></x:Button>
                                                    </Items>
                                                </x:FormRow>
                                            </Rows>
                                        </x:Form>
                                        <x:Grid ID="grid_List2" runat="server" ShowHeader="false" ShowBorder="true" EnableBackgroundColor="true" BoxFlex="1"
                                            EnableCheckBoxSelect="true" EnableRowNumber="true" OnRowDataBound="grid_List_RowDataBound" OnRowCommand="grid_List_RowCommand"
                                            EnableTextSelection="true" DataKeyNames="ID">
                                            <Toolbars>
                                                <x:Toolbar ID="Toolbar2" runat="server">
                                                    <Items>
                                                        <x:Button ID="btn_Add2" runat="server" Text="添加"></x:Button>
                                                    </Items>
                                                </x:Toolbar>
                                            </Toolbars>
                                            <Columns>
                                                <x:BoundField HeaderText="工作内容" DataField="WorkContent" />
                                                <x:BoundField HeaderText="区域名称" DataField="Area" />
                                                <x:BoundField HeaderText="检查人员" DataField="Checkman" />
                                                <x:BoundField HeaderText="经销商名称" DataField="DealerName" />
                                                <x:BoundField HeaderText="合作行" DataField="BankName" />
                                                <x:BoundField HeaderText="品牌" DataField="BrandName" />
                                                <x:BoundField HeaderText="监管员" DataField="SName" />
                                                <x:BoundField HeaderText="问题描述" DataField="DescProb" />
                                                <x:BoundField HeaderText="检查时处理结果" DataField="Result" />
                                                <x:BoundField HeaderText="产业市场回复" DataField="CY_Market" />
                                                <x:BoundField HeaderText="产业业务回复" DataField="CY_Business" />
                                                <x:BoundField HeaderText="汽车市场回复" DataField="QC_Market" />
                                                <x:BoundField HeaderText="汽车业务回复" DataField="QC_Business" />
                                                <x:BoundField HeaderText="管理中心" DataField="ManCenter" />
                                                <x:BoundField HeaderText="行政" DataField="XZ" />
                                                <x:BoundField HeaderText="创建人" DataField="CreateID" />
                                                <x:BoundField HeaderText="创建时间" DataField="CreateTime" />
                                                <x:BoundField HeaderText="备注" DataField="Remark" />
                                                <x:LinkButtonField HeaderText="删除" Text="删除" CommandName="del" ConfirmText="确定要删除？" ConfirmTitle="系统提示" ConfirmIcon="Warning" />
                                            </Columns>
                                        </x:Grid>
                                    </Items>
                                </x:Panel>
                            </Items>
                        </x:Tab>
                    </Tabs>
                </x:TabStrip>
            </Items>
        </x:Panel>

    </form>
    <x:Window ID="WindowAdd2" runat="server" BodyPadding="5px" Height="670px" IsModal="true" Popup="false"
        Title="添加合作项目跟进追踪记录" Width="1000px" EnableDrag="false" AutoScroll="true" EnableMaximize="false" EnableMinimize="false"
        EnableIFrame="true" Target="Parent">
    </x:Window>
</body>
</html>
