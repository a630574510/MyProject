<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Select_All_Remind.aspx.cs"
    Inherits="Citic_Web.Reminds.Select_All_Remind" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>提醒信息</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel3" />
    <x:Panel ID="Panel3" runat="server" ShowBorder="True" Layout="HBox" BoxConfigAlign="Stretch"
        BoxConfigPosition="Start" BoxConfigPadding="5" BoxConfigChildMargin="0 5 0 0"
        ShowHeader="True" Title="提醒信息" EnableBackgroundColor="true">
        <Items>
            <x:Panel ID="Panel5" Title="面板1" EnableBackgroundColor="true" runat="server" ShowBorder="false"
                ShowHeader="false" Layout="Fit">
                <Items>
                    <x:Tree ID="T_Bank" runat="server" AutoScroll="true" EnableArrows="true" Title="银行列表"
                        EnableBackgroundColor="false" OnNodeCommand="T_Bank_OnNodeCommand" Width="200px">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:TextBox ID="T_B_Bank" runat="server" Label="Label" Text="">
                                    </x:TextBox>
                                    <x:Button ID="Btn_Select_Bank" runat="server" Text="查询" Icon="Zoom" IconAlign="Right"
                                        OnClick="Btn_Select_Bank_OnClick">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                    </x:Tree>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel4" Title="提醒类容" EnableBackgroundColor="true" BoxFlex="2" runat="server"
                BodyPadding="5px" BoxMargin="0" ShowBorder="true" ShowHeader="true" Layout="Fit">
                <Items>
                    <x:TabStrip ID="TS_Remind" runat="server" AutoPostBack="false" ShowBorder="True"
                        EnableTabCloseMenu="true" OnTabIndexChanged="TS_Remind_OnTabIndexChanged">
                        <Tabs>
                            <x:Tab ID="Tab1" runat="server" EnableClose="true" Title="进驻7日未交监管费提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind1" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar13" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind1" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All" IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="进驻日期" DataField="EnteringDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="监管费金额" DataField="SupervisionFeeMoney" />
                                            <x:BoundField HeaderText="备注" DataField="Remark" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab2" runat="server" EnableClose="true" Title="监管费到期7日提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind2" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar14" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind2" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All" IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="到期日期" DataField="DueDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="监管费金额" DataField="SupervisionFeeMoney" />
                                            <x:BoundField HeaderText="备注" DataField="Remark" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab3" runat="server" EnableClose="true" Title="0库存0承兑汇票提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind3" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar15" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind3" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All" IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="合作行" DataField="BankName"  ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName"  ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName"  ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="监管费截止日期" DataField="SupervisionFeeAsDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="备注" DataField="Remark" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab4" runat="server" EnableClose="true" Title="3日质押物未出库提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind4" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind4" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="最近出库日期" DataField="OutboundDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="在库台数" DataField="StoreCount" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab5" runat="server" EnableClose="true" Title="质押物在途5天未入库提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind5" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar9" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind5" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName"  ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName"  ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="合作行" DataField="BankName"  ExpandUnusedSpace="true" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab6" runat="server" EnableClose="true" Title="经销商剩余10台车提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind6" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID"> 
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar11" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind6" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab7" runat="server" EnableClose="true" Title="新进店未进监管员提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind7" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar6" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind7" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="业务模式" DataField="BusinessModel" />
                                            <x:BoundField HeaderText="驻店日期" DataField="EnteringDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="备注" DataField="Remark" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab8" runat="server" EnableClose="true" Title="停止合作店面提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind8" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar7" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind8" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="业务模式" DataField="BusinessModel" />
                                            <x:BoundField HeaderText="驻店日期" DataField="EnteringDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="暂停日期" DataField="DueDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="备注" DataField="Remark" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab9" runat="server" EnableClose="true" Title="经销商剩余一张汇票提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind9" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar10" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind9" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true"  />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="票号" DataField="DraftNo" ExpandUnusedSpace="true" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab11" runat="server" EnableClose="true" Title="更换监管员提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind11" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar8" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind11" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName"  ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="合作行" DataField="BankName"  ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="更换日期" DataField="ReplaceDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="原监管员" DataField="OriginalSupervision" />
                                            <x:BoundField HeaderText="现任监管员" DataField="NowSupervision" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab12" runat="server" EnableClose="true" Title="开票15日未收质押物提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind12" runat="server" Title="详细信息" AllowPaging="true"
                                        EnableCheckBoxSelect="true" EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar2" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind12" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="票号" DataField="DraftNo" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="票面金额" DataField="DraftMoney" />
                                            <x:BoundField HeaderText="开票日期" DataField="BeginDraftDate" DataFormatString="{0:yyyy-MM-dd}" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab13" runat="server" EnableClose="true" Title="开票30日未押满汇票金额提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind13" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar3" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind13" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="票号" DataField="DraftNo"  ExpandUnusedSpace="true"/>
                                            <x:BoundField HeaderText="票面金额" DataField="DraftMoney" />
                                            <x:BoundField HeaderText="开票日期" DataField="BeginDraftDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="已押金额" DataField="PledgeMoney" />
                                            <x:BoundField HeaderText="未押金额" DataField="NotMoney" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab14" runat="server" EnableClose="true" Title="汇票到期未押满票面金额提前15日提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind14" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar4" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind14" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="票号" DataField="DraftNo" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="票面金额" DataField="DraftMoney" />
                                            <x:BoundField HeaderText="开票日期" DataField="BeginDraftDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="已押金额" DataField="PledgeMoney" />
                                            <x:BoundField HeaderText="未押金额" DataField="NotMoney" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab15" runat="server" EnableClose="true" Title="汇票到期提前7日提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind15" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar5" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind15" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="合作行" DataField="BankName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="经销商名称" DataField="DealerName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="品牌" DataField="BrandName" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="票号" DataField="DraftNo" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="票面金额" DataField="DraftMoney" />
                                            <x:BoundField HeaderText="汇票到期日期" DataField="DueDate" DataFormatString="{0:yyyy-MM-dd}" />
                                            <x:BoundField HeaderText="该票下在库台数" DataField="StoreCount" />
                                            <x:BoundField HeaderText="该票下在库金额" DataField="StoreMoney" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                            <x:Tab ID="Tab10" runat="server" EnableClose="true" Title="光大总行拟驻店提醒" Layout="Fit">
                                <Items>
                                    <x:Grid ID="Remind10" runat="server" Title="详细信息" AllowPaging="true" EnableCheckBoxSelect="true"
                                        EnableRowNumber="true" DataKeyNames="ID">
                                        <Toolbars>
                                            <x:Toolbar ID="Toolbar12" runat="server">
                                                <Items>
                                                    <x:Button ID="btn_Remind10" runat="server" Text="确定" Icon="Tick" OnClick="Btn_All"
                                                        IconAlign="Right">
                                                    </x:Button>
                                                </Items>
                                            </x:Toolbar>
                                        </Toolbars>
                                        <Columns>
                                            <x:BoundField HeaderText="经销商名称" DataField="Jxs_Name" ExpandUnusedSpace="true" />
                                            <x:BoundField HeaderText="拟驻店日期" DataField="TIME_KP" ExpandUnusedSpace="true" />
                                        </Columns>
                                    </x:Grid>
                                </Items>
                            </x:Tab>
                        </Tabs>
                    </x:TabStrip>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
