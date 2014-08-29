<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRiskQues.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.AddRiskQues" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false"
            EnableBackgroundColor="true" AutoScroll="true">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btnSaveRefresh" Text="保存并关闭" runat="server" Icon="SystemSaveNew"
                            OnClick="btnSaveRefresh_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true">
                    <Items>
                        <x:DropDownList ID="ddl_WC" runat="server" Label="工作内容" Width="300px"></x:DropDownList>
                        <x:DropDownList ID="ddl_Area" runat="server" Label="区域名称" Width="300px"></x:DropDownList>
                        <x:TextBox ID="txt_Checkman" runat="server" Label="检查人员" Text="" Width="300px"></x:TextBox>
                        <x:DropDownList ID="ddl_Dealer" runat="server" Label="经销店名" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddl_Dealer_SelectedIndexChanged"></x:DropDownList>
                        <x:DropDownList ID="ddl_Bank" runat="server" Label="合作行" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddl_Bank_SelectedIndexChanged"></x:DropDownList>
                        <x:DropDownList ID="ddl_Brand" runat="server" Label="品牌" Width="100px"></x:DropDownList>
                        <x:DropDownList ID="ddl_Supervisor" runat="server" Label="监管员" Width="200px"></x:DropDownList>
                        <x:TextBox ID="txt_DescQues" runat="server" Label="问题描述" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="txt_Result" runat="server" Label="检查时处理结果" Text="" Width="300px"></x:TextBox>
                        <x:GroupPanel ID="GroupPanel1" runat="server" EnableCollapse="True" Title="相关部门回复">
                            <Items>
                                <x:GroupPanel ID="GroupPanel2" runat="server" EnableCollapse="True" Title="产业">
                                    <Items>
                                        <x:TextBox ID="txt_CY_Market" runat="server" Label="市场" Text="" Width="300px"></x:TextBox>
                                        <x:TextBox ID="txt_CY_Business" runat="server" Label="业务" Text="" Width="300px"></x:TextBox>
                                    </Items>
                                </x:GroupPanel>
                                <x:GroupPanel ID="GroupPanel3" runat="server" EnableCollapse="True" Title="汽车">
                                    <Items>
                                        <x:TextBox ID="txt_QC_Market" runat="server" Label="市场" Text="" Width="300px"></x:TextBox>
                                        <x:TextBox ID="txt_QC_Business" runat="server" Label="业务" Text="" Width="300px"></x:TextBox>
                                    </Items>
                                </x:GroupPanel>
                                <x:TextBox ID="txt_ManCenter" runat="server" Label="管理中心" Text="" Width="300px"></x:TextBox>
                                <x:TextBox ID="txt_XZ" runat="server" Label="行政" Text="" Width="300px"></x:TextBox>
                            </Items>
                        </x:GroupPanel>
                        <x:TextArea ID="txt_Remark" runat="server" Height="80px" Label="备注" Text="" Width="300px"></x:TextArea>
                    </Items>
                </x:SimpleForm>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
