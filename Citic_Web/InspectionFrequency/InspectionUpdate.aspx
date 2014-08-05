<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionUpdate.aspx.cs"
    Inherits="Citic_Web.InspectionFrequency.InspectionUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改追踪信息</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="" EnableBackgroundColor="true">
        <Items>
            <x:SimpleForm ID="SF_Update" runat="server" BodyPadding="3px" Title="" EnableBackgroundColor="true"
                LabelAlign="Right" ShowHeader="false">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:Button ID="btn_Update" runat="server" Text="提交修改" Enabled="false" Icon="Tick"
                                OnClick="btn_Update_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:TextBox ID="txt_DealerName" runat="server" Label="经销店名称" Text="">
                    </x:TextBox>
                    <x:TextBox ID="txt_Bank" runat="server" Label="合作银行" Text="">
                    </x:TextBox>
                    <x:TextBox ID="txt_BrandName" runat="server" Label="品牌" Text="">
                    </x:TextBox>
                    <x:TextBox ID="txt_SupervisorName" runat="server" Label="监管员" Text="">
                    </x:TextBox>
                    <x:DropDownList ID="txt_Model" runat="server" Label="监管模式">
                        <x:ListItem Text="车证钥匙" Value="车证钥匙" />
                        <x:ListItem Text="合格证" Value="合格证" />
                    </x:DropDownList>
                    <x:NumberBox ID="txt_Inventory" runat="server" Label="库存">
                    </x:NumberBox>
                    <x:TextArea ID="txt_QuartersLedger" runat="server" Label="总账问题" Text="">
                    </x:TextArea>
                    <x:CheckBox ID="cb_QuartersLedger" runat="server" Label="总账">
                    </x:CheckBox>
                    <x:TextArea ID="txt_MainProblem" runat="server" Label="主要问题" Text="">
                    </x:TextArea>
                    <x:CheckBox ID="cb_MainProblem" runat="server" Label="主要">
                    </x:CheckBox>
                    <x:DatePicker ID="DP_HistoryDate" runat="server" Label="历史检查时间">
                    </x:DatePicker>
                    <x:CheckBox ID="cb_HistoryDate" runat="server" Label="历史检查">
                    </x:CheckBox>
                    <x:TextArea ID="txt_Remark" runat="server" Label="备注" Text="">
                    </x:TextArea>
                    <x:TextArea ID="txt_Area" runat="server" Label="评价" Text="">
                    </x:TextArea>
                </Items>
            </x:SimpleForm>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
