<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InspectionDayTableUpdate.aspx.cs"
    Inherits="Citic_Web.InspectionFrequency.InspectionDayTableUpdate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改视频日报表</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel">
        <Items>
            <x:Panel ID="Panel2" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
                Title="Panel">
                <Items>
                    <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="0px" Title="" ShowBorder="false"
                        ShowHeader="false" EnableBackgroundColor="true" LabelAlign="Right">
                        <Toolbars>
                            <x:Toolbar ID="Toolbar1" runat="server">
                                <Items>
                                    <x:Button ID="btn_Update" runat="server" Text="提交修改" Icon="Tick" OnClick="btn_Update_Click">
                                    </x:Button>
                                </Items>
                            </x:Toolbar>
                        </Toolbars>
                        <Items>
                            <x:DropDownList ID="txt_Area" runat="server" Label="区域中心">
                                <x:ListItem Text="华北区域中心" Value="华北区域中心" />
                                <x:ListItem Text="华南区域中心" Value="华南区域中心" />
                                <x:ListItem Text="西南区域中心" Value="西南区域中心" />
                                <x:ListItem Text="东北区域中心" Value="东北区域中心" />
                                <x:ListItem Text="华东区域中心" Value="华东区域中心" />
                                <x:ListItem Text="华中区域中心" Value="华中区域中心" />
                                <x:ListItem Text="西北区域中心" Value="西北区域中心" />
                                <x:ListItem Text="总部" Value="总部" />
                            </x:DropDownList>
                            <x:TextBox ID="txt_Rummager" runat="server" Label="检查人员" Text="">
                            </x:TextBox>
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
                            <x:TextBox ID="txt_Inventory" runat="server" Label="库存" Text="">
                            </x:TextBox>
                            <x:TextArea ID="txt_QuartersLedger" runat="server" Height="70px" Label="总部总账" Text="">
                            </x:TextArea>
                            <x:TextArea ID="txt_MainProblem" runat="server" Height="70px" Label="主要问题" Text="">
                            </x:TextArea>
                            <x:TextArea ID="txt_Remark" runat="server" Height="70px" Label="备注" Text="">
                            </x:TextArea>
                        </Items>
                    </x:SimpleForm>
                </Items>
            </x:Panel>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
