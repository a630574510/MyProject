<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HZProjectFollowVerify.aspx.cs" Inherits="Citic_Web.ProjectTracking.HZProjectsFollow.HZProjectFollowVerify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" Title="合作项目跟进追踪表" EnableBackgroundColor="true" Layout="Fit">
            <Items>
                <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                    EnableBackgroundColor="true" Layout="VBox" BoxConfigAlign="Stretch" BoxConfigPosition="Left">
                    <Items>
                        <x:Form ID="Form2" runat="server" BodyPadding="5px" ShowHeader="false" CssStyle="padding-bottom:5px"
                            ShowBorder="true" EnableBackgroundColor="true" Height="40px">
                            <Rows>
                                <x:FormRow ID="FormRow1" runat="server">
                                    <Items>
                                        <x:Button ID="btn_Search1" runat="server" Text="查询" OnClick="btn_Search_Click"></x:Button>
                                    </Items>
                                </x:FormRow>
                            </Rows>
                        </x:Form>
                        <x:Grid ID="grid_List1" runat="server" EnableBackgroundColor="true" ShowHeader="false" ShowBorder="true"
                            BoxFlex="1" EnableRowNumber="true" EnableTextSelection="true" EnableCheckBoxSelect="true"
                            OnRowCommand="grid_List_RowCommand" OnRowDataBound="grid_List_RowDataBound"
                            DataKeyNames="ID">
                            <Toolbars>
                                <x:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <x:Button ID="btn_Add1" runat="server" Text="添加"></x:Button>
                                    </Items>
                                </x:Toolbar>
                            </Toolbars>

                            <GroupColumns>
                                <x:GridGroupColumn>
                                    <Columns>
                                        <x:BoundField HeaderText="品牌" DataField="BrandName" />
                                        <x:BoundField HeaderText="经销商" DataField="DealerName" />
                                        <x:BoundField HeaderText="合作行" DataField="BankName" />
                                        <x:BoundField HeaderText="业务模式" DataField="BM" />
                                        <x:BoundField HeaderText="类型" DataField="type" />
                                        <x:BoundField HeaderText="进驻日期" DataField="DTime" />
                                        <x:BoundField HeaderText="监管员" DataField="SName" />
                                        <x:BoundField HeaderText="监管员联系方式" DataField="LinkPhone" />
                                    </Columns>
                                </x:GridGroupColumn>
                                <x:GridGroupColumn HeaderText="<span style='font-weight:bold'>跟进事项</span>" TextAlign="Center">
                                    <Columns>
                                        <x:BoundField HeaderText="监管员是否正常上岗" DataField="col_1" />
                                        <x:BoundField HeaderText="监管员委任书、经销店授权书、经销店告之函是否制作	" DataField="col_2" />
                                        <x:BoundField HeaderText="设备是否到位（电脑、保险柜、手机、工牌、标识）" DataField="col_3" />
                                        <x:BoundField HeaderText="是否接受此行业务操作培训" DataField="col_4" />
                                        <x:BoundField HeaderText="公司规章制度及操作表单是否齐全" DataField="col_5" />
                                        <x:BoundField HeaderText="是否存在与其它公司交接工作" DataField="col_6" />
                                        <x:BoundField HeaderText="档案资料是否齐全并上交" DataField="col_7" />
                                        <x:BoundField HeaderText="是否已正常开展业务（承兑汇票信息、在库车辆）" DataField="col_8" />
                                        <x:BoundField HeaderText="监管费确认单" DataField="col_9" />
                                        <x:BoundField HeaderText="是否能正常进行查库工作" DataField="col_10" />
                                        <x:BoundField HeaderText="雇员忠诚险" DataField="col_11" />
                                    </Columns>
                                </x:GridGroupColumn>
                                <x:GridGroupColumn>
                                    <Columns>
                                        <x:BoundField HeaderText="创建人" DataField="CreateID" />
                                        <x:BoundField HeaderText="创建时间" DataField="CreateTime" />
                                        <x:BoundField HeaderText="备注" DataField="Remark" />
                                        <x:LinkButtonField HeaderText="删除" Text="删除" CommandName="del" ConfirmText="确定要删除？" ConfirmTitle="系统提示" ConfirmIcon="Warning" />
                                    </Columns>
                                </x:GridGroupColumn>
                            </GroupColumns>
                        </x:Grid>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>

        <x:Window ID="WindowAdd1" runat="server" BodyPadding="5px" Height="670px" IsModal="true" Popup="false"
            Title="添加合作项目跟进追踪记录" Width="800px" EnableDrag="false" AutoScroll="true" EnableMaximize="false" EnableMinimize="false"
            EnableIFrame="true" Target="Parent">
        </x:Window>
    </form>
</body>
</html>
