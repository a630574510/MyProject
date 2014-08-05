<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update_Car.aspx.cs" Inherits="Citic_Web.Car.Update_Car" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>车辆修改</title>
</head>
<body>
    <form id="form1" runat="server">
    <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
    <x:Panel ID="Panel1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false"
        Title="Panel" EnableBackgroundColor="true" Layout="Fit">
        <Items>
            <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="0px" Title="详细信息" LabelAlign="Right"
                EnableBackgroundColor="true">
                <Toolbars>
                    <x:Toolbar ID="Toolbar1" runat="server">
                        <Items>
                            <x:Button ID="Btn_Close" EnablePostBack="false" runat="server" Text="关闭" Icon="SystemClose">
                            </x:Button>
                            <x:Button ID="Btn_Update" runat="server" Text="提交修改" Icon="SystemSaveNew" OnClick="Btn_Update_Click">
                            </x:Button>
                        </Items>
                    </x:Toolbar>
                </Toolbars>
                <Items>
                    <x:Label ID="lbl_Dealer" runat="server" Label="经销商名称" Text="" Width="200">
                    </x:Label>
                    <x:DropDownList ID="ddl_DraftNo" runat="server" Label="汇票号" Width="300">
                    </x:DropDownList>
                    <x:TextBox ID="txt_Vin" runat="server" Label="车架号" Text="" Width="200" Enabled="false">
                    </x:TextBox>
                    <x:TextBox ID="txt_CarModel" runat="server" Label="车辆型号" Text="" Width="200">
                    </x:TextBox>
                    <x:TextBox ID="txt_CarColor" runat="server" Label="颜色" Text="" Width="200">
                    </x:TextBox>
                    <x:TextBox ID="txt_EngineNo" runat="server" Label="发动机号" Text="" Width="200">
                    </x:TextBox>
                    <x:TextBox ID="txt_QualifiedNo" runat="server" Label="合格证" Text="" Width="200" Enabled="false">
                    </x:TextBox>
                    <x:DatePicker ID="dpIssueDate" runat="server" Label="合格证发证日期" Text="" Width="200">
                    </x:DatePicker>
                    <x:DropDownList ID="ddl_KeyCount" runat="server" Label="钥匙数" Width="200">
                        <x:ListItem Text="1" Value="1" />
                        <x:ListItem Text="2" Value="2" />
                        <x:ListItem Text="3" Value="3" />
                        <x:ListItem Text="4" Value="4" />
                        <x:ListItem Text="5" Value="5" />
                    </x:DropDownList>
                    <x:TextBox ID="txt_KeyNumber" runat="server" Label="钥匙号" Text="" Width="200">
                    </x:TextBox>
                    <x:TextBox ID="txt_Car_Money" runat="server" Label="车辆金额" Text="" Width="200">
                    </x:TextBox>
                    <x:TextBox ID="txt_Return_Money" runat="server" Label="回款金额" Text="" Width="200">
                    </x:TextBox>
                    <x:TextBox ID="txt_Displacement" runat="server" Label="排量" Text="" Width="200">
                    </x:TextBox>
                    <x:TextBox ID="txt_CarClass" runat="server" Label="车辆分类" Text="" Width="200">
                    </x:TextBox>
                    <x:TextArea ID="txt_OTHER" runat="server" Height="50px" Label="备注" Text="" Width="200">
                    </x:TextArea>
                    <x:Label ID="lbl_ID" runat="server" Label="Label" Text="Label" Hidden="true">
                    </x:Label>
                </Items>
            </x:SimpleForm>
        </Items>
    </x:Panel>
    </form>
</body>
</html>
