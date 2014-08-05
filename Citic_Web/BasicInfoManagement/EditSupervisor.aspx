<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditSupervisor.aspx.cs"
    Inherits="Citic_Web.BasicInfoManagement.EditSupervisor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowHeader="false" ShowBorder="false"
            AutoHeight="true" Height="500px" EnableBackgroundColor="true">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" ValidateForms="SimpleForm1,SimpleForm2" runat="server"
                            Text="保存并关闭" Icon="SystemSaveNew" OnClick="btn_SaveAndClose_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Panel ID="pnl_BasicInfo" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                    EnableBackgroundColor="true" Title="基本信息">
                    <Items>
                        <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowBorder="false"
                            ShowHeader="false" EnableBackgroundColor="true" AutoScroll="true" EnableCollapse="True"
                            AutoWidth="true" LabelWidth="110px">
                            <Items>
                                <x:HiddenField ID="hidden_SupervisorID" runat="server">
                                </x:HiddenField>
                                <x:TextBox ID="txt_Name" runat="server" Label="监管员姓名" Required="true" RequiredMessage="请输入姓名"
                                    Text="" Width="200px" />
                                <x:TextBox ID="txt_Pass" runat="server" Label="密码" Text="" Width="200px" TextMode="Password"></x:TextBox>
                                <x:TextBox ID="txt_PassA" runat="server" Label="再次输入" Text="" Width="200px" TextMode="Password" CompareControl="txt_Pass" CompareMessage="两次密码输入不一致！" CompareOperator="Equal"></x:TextBox>
                                <x:NumberBox ID="num_Age" runat="server" Label="年龄" NoDecimal="true" NoNegative="true"
                                    Required="true" MaxValue="200" MinValue="0" Width="200px" />
                                <x:RadioButtonList ID="rbl_Gender" Label="性别" runat="server" Width="100px">
                                    <x:RadioItem Value="0" Text="男" Selected="true" />
                                    <x:RadioItem Value="1" Text="女" />
                                </x:RadioButtonList>
                                <x:TextBox ID="txt_IDCard" runat="server" Label="身份证号" Text="" Regex="[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}(\d|x|X)"
                                    Width="200px" Required="true" RequiredMessage="请输入身份证号" />
                                <x:DropDownList runat="server" Label="学历" ID="ddl_Education" Width="100px">
                                    <x:ListItem Text="请选择" Value="" />
                                    <x:ListItem Text="初中" Value="初中" />
                                    <x:ListItem Text="高中" Value="高中" />
                                    <x:ListItem Text="中专" Value="中专" />
                                    <x:ListItem Text="大专" Value="大专" />
                                    <x:ListItem Text="本科" Value="本科" />
                                    <x:ListItem Text="硕士" Value="硕士" />
                                    <x:ListItem Text="博士" Value="博士" />
                                    <x:ListItem Text="博士后" Value="博士后" />
                                </x:DropDownList>
                                <x:NumberBox ID="num_LinkPhone" runat="server" Label="电话" Text="" Width="200px" />
                                <x:NumberBox ID="num_QQ" runat="server" Label="QQ" Text="" Width="200px" />
                                <x:TextBox ID="txt_UrgencyMan" runat="server" Label="紧急联系人" Text="" Width="200px" />
                                <x:TextBox ID="txt_UrgencyConnect" runat="server" Label="与紧急联系人关系" Text="" Width="200px" />
                                <x:NumberBox ID="num_UrgencyPhone" runat="server" Label="紧急联系人电话" Text="" Width="200px" />
                                <x:HiddenField runat="server" ID="hidden_CreateTime">
                                </x:HiddenField>
                                <x:HiddenField runat="server" ID="hidden_CreateID">
                                </x:HiddenField>
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
                <x:Label ID="Label1" runat="server" Text="">
                </x:Label>
                <x:Label ID="Label2" runat="server" Text="">
                </x:Label>
                <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true"
                    EnableBackgroundColor="true" Title="工作信息">
                    <Items>
                        <x:SimpleForm ID="SimpleForm2" runat="server" BodyPadding="5px" ShowBorder="false"
                            ShowHeader="false" EnableBackgroundColor="true" AutoScroll="true" EnableCollapse="True"
                            AutoWidth="true" LabelWidth="110px">
                            <Items>
                                <x:DatePicker ID="dp_EntryTime" Width="150px" runat="server" Required="true" RequiredMessage="请选择入职时间"
                                    Label="入职时间">
                                </x:DatePicker>
                                <x:RadioButtonList ID="rbl_WorkSoruce" Label="工作来源" runat="server" Width="120px">
                                    <x:RadioItem Value="0" Text="属地" Selected="true" />
                                    <x:RadioItem Value="1" Text="外派" />
                                </x:RadioButtonList>
                                <x:RadioButtonList ID="rbl_WorkType" Label="工作属性" runat="server" Width="120px">
                                    <x:RadioItem Value="0" Text="新上岗" Selected="true" />
                                    <x:RadioItem Value="1" Text="轮岗" />
                                </x:RadioButtonList>
                            </Items>
                        </x:SimpleForm>
                    </Items>
                </x:Panel>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
