<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GD_Q403.aspx.cs" Inherits="Citic_Web.BankInterface.GD_Q403" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
        Title="光大修改车辆信息" EnableBackgroundColor="true">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel">
                <Items>
                    <x:Form ID="Form2" Title="查询车辆条件" BodyPadding="5px" runat="server" LabelAlign="Right"
                        EnableBackgroundColor="true">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button runat="server" Text="查询" ID="Btn_Search" OnClick="Btn_Search_Click" Icon="SystemSearch">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Rows>
                            <x:FormRow ID="FormRow1" runat="server">
                                <Items>
                                    <x:DropDownList ID="ddl_Dealer" runat="server" Label="经销商" AutoPostBack="true" EnableEdit="true"
                                        Width="300px" OnSelectedIndexChanged="ddl_Dealer_SelectedIndexChanged">
                                    </x:DropDownList>
                                    <x:TextBox ID="txt_Vin" runat="server" Label="车架号" Text="" Width="300px" EmptyText="请输入单个完整车架号">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
            <x:Panel ID="Panel3" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                Title="查询结果" EnableBackgroundColor="true" AutoScroll="false">
                <Items>
                    <x:Form ID="Form3" runat="server" BodyPadding="5px" Title="详细信息" EnableBackgroundColor="true"
                        LabelAlign="Right">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar2" runat="server">
                                <Items>
                                    <x:Button runat="server" Text="提交修改" ID="Btn_Update" OnClick="Btn_Update_Click" Icon="Tick">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Rows>
                            <x:FormRow ID="FormRow2" runat="server">
                                <Items>
                                    <x:TextBox ID="txt_HXCS_ID" runat="server" Label="核心厂商id" Text="" Width="200px" Hidden="true">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_PI_ID" runat="server" Label="合格证id" Text="" Enabled="false" Width="200px">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow ID="FormRow3" runat="server">
                                <Items>
                                    <x:TextBox ID="txt_JXS_ID" runat="server" Label="经销商id" Text="" Width="200px" Hidden="true">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_SEND_CAR_ID" runat="server" Label="发车明细ID" Text="" Width="200px"
                                        Enabled="false">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow>
                                <Items>
                                    <x:TextBox ID="txt_ENGINE_MODEL" runat="server" Label="发动机号" Text="" Width="200px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_DJ_NO" runat="server" Label="车辆识别代号" Text="" Enabled="false" Width="200px">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow>
                                <Items>
                                    <x:TextBox ID="txt_CAR_MODEL" runat="server" Label="汽车型号" Text="" Width="200px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_PI_NO" runat="server" Label="合格证编号" Text="" Enabled="false" Width="200px">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow>
                                <Items>
                                    <x:TextBox ID="txt_CAR_BRAND" runat="server" Label="品牌" Text="" Width="200px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_PI_STATUS" runat="server" Label="合格证状态" Text="" Width="200px"
                                        Enabled="false">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow>
                                <Items>
                                    <x:TextBox ID="txt_PI_AMOUNT" runat="server" Label="合格证金额" Text="" Width="200px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_BF_ID" runat="server" Label="对应票据id" Text="" Enabled="false" Width="200px"
                                        Hidden="true">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow>
                                <Items>
                                    <x:TextBox ID="txt_CAR_COLOR" runat="server" Label="颜色" Text="" Width="200px">
                                    </x:TextBox>
                                    <x:TextBox ID="txt_CAR_STATUS" runat="server" Label="车辆状态" Text="" Width="200px"
                                        Enabled="false">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow>
                                <Items>
                                    <x:DropDownList ID="ddl_KEY_NUM" runat="server" Label="钥匙数量" Width="200px">
                                        <x:ListItem Text="1" Value="1" />
                                        <x:ListItem Text="2" Value="2" />
                                        <x:ListItem Text="3" Value="3" />
                                        <x:ListItem Text="4" Value="4" />
                                        <x:ListItem Text="5" Value="5" />
                                    </x:DropDownList>
                                    <x:TextBox ID="txt_RANGE_FLAG" runat="server" Label="是否超范围车辆" Text="" Width="200px"
                                        Hidden="true">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow>
                                <Items>
                                    <x:TextArea ID="txt_REMARK" runat="server" Height="50px" Label="备注" Text="" Width="200px">
                                    </x:TextArea>
                                    <x:TextBox ID="txt_MATURE_DATE" runat="server" Label="合格证到期日" Text="" Width="200px"
                                        Enabled="false">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                            <x:FormRow>
                                <Items>
                                    <x:TextBox ID="txt_CAR_STOCK_ADD" runat="server" Label="车辆在库地址" Text="" Width="200px"
                                        Hidden="true">
                                    </x:TextBox>
                                </Items>
                            </x:FormRow>
                        </Rows>
                    </x:Form>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
