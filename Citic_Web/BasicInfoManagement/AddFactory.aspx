<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddFactory.aspx.cs" Inherits="Citic_Web.BasicInfoManagement.AddFactory" %>

<%@ Register Src="~/UserControls/WUC_Address.ascx" TagPrefix="uc1" TagName="WUC_Address" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowHeader="false" ShowBorder="true"
            AutoHeight="true" Height="500px" AutoWidth="true" Width="600px" Layout="Table"
            TableConfigColumns="2" EnableBackgroundColor="true">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" runat="server" Text="保存并关闭"
                            Icon="SystemSaveNew" OnClick="btn_SaveAndClose_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Panel ID="pnl_BasicInfo" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                    EnableBackgroundColor="true" TableColspan="2" Title="工厂信息（首先添加）" Width="580px"
                    CssStyle="margin-bottom:5px">
                    <Items>
                        <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowBorder="false"
                            ShowHeader="false" EnableBackgroundColor="true" AutoScroll="true" EnableCollapse="True"
                            AutoWidth="true">
                            <Items>
                                <x:TextBox ID="txt_FactoryName" runat="server" Label="厂家名称" Required="true" RequiredMessage="请输入工厂的名称！"
                                    Text="" Width="200px" />

                                <x:UserControlConnector ID="UserControlConnector1" runat="server">
                                    <uc1:WUC_Address runat="server" ID="WUC_Address" />
                                </x:UserControlConnector>
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
                <x:Panel ID="pnl_BrandInfo" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                    EnableBackgroundColor="true" Title="品牌信息" Width="290px" Height="140px" CssStyle="margin-right:5px">
                    <Items>
                        <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" ShowBorder="false"
                            ShowHeader="false" EnableBackgroundColor="true" AutoScroll="true" EnableCollapse="True"
                            AutoWidth="true">
                            <Items>
                                <x:TextBox ID="txt_BrandName" Required="true" RequiredMessage="请输入品牌名称！" runat="server"
                                    Label="品牌名称" Text="" Width="150px">
                                </x:TextBox>
                                <x:TextArea ID="txt_Remark" runat="server" Height="50px" Label="备注" Text="" Width="150px">
                                </x:TextArea>
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
                <x:Panel ID="pnl_LinkMan" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                    EnableBackgroundColor="true" Title="联系人信息" Height="140px" Width="285px">
                    <Items>
                        <x:SimpleForm ID="SimpleForm3" runat="server" BodyPadding="5px" ShowBorder="false"
                            ShowHeader="false" EnableBackgroundColor="true" AutoScroll="true" EnableCollapse="True"
                            AutoWidth="true">
                            <Items>
                                <x:TextBox ID="txt_LinkManName" runat="server" Label="联系人姓名" Text="" Width="150px">
                                </x:TextBox>
                                <x:NumberBox ID="num_Phone" runat="server" Label="联系电话" Text="" Width="150px"></x:NumberBox>
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
