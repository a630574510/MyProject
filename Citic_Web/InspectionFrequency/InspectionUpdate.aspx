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
                LabelAlign="Right">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:Button ID="btn_Update" runat="server" Text="提交修改" Icon="Tick" OnClick="btn_Update_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:TextBox ID="txt_Area" runat="server" Label="检查区域" Text="">
                    </x:TextBox>
                    <x:TextBox ID="txt_DealerName" runat="server" Label="经销店名称" Text="">
                    </x:TextBox>
                    <x:TextBox ID="txt_Bank" runat="server" Label="合作银行" Text="">
                    </x:TextBox>
                    <x:TextBox ID="txt_BrandName" runat="server" Label="品牌" Text="">
                    </x:TextBox>
                    <x:TextBox ID="txt_SupervisorName" runat="server" Label="监管员" Text="">
                    </x:TextBox>
                    <x:TextArea ID="txt_CheckProblem" runat="server" Height="50px" Label="检查问题" Text="">
                    </x:TextArea>
                    <x:TextArea ID="txt_FinancialCenter1" runat="server" Height="50px" Label="汽车/产业金融中心处理结果"
                        Text="">
                    </x:TextArea>
                    <x:TextArea ID="txt_RiskControl" runat="server" Height="50px" Label="风控部处理结果" Text="">
                    </x:TextArea>
                    <x:TextArea ID="txt_AdminDepartment" runat="server" Height="50px" Label="管理中心处理结果"
                        Text="">
                    </x:TextArea>
                    <x:TextArea ID="txt_QuartersLedger" runat="server" Height="50px" Label="总部总账问题(系统、电子总账）"
                        Text="">
                    </x:TextArea>
                    <x:TextArea ID="txt_FinancialCenter" runat="server" Height="50px" Label="处理结果" Text="">
                    </x:TextArea>
                    <x:DatePicker ID="txt_HistoryTime" runat="server" Label="历史检查时间">
                    </x:DatePicker>
                </Items>
            </x:SimpleForm>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
