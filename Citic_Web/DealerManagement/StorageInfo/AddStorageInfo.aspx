<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStorageInfo.aspx.cs" Inherits="Citic_Web.DealerManagement.StorageInfo.AddStorageInfo" %>

<%@ Register Src="~/UserControls/WUC_Address.ascx" TagPrefix="uc1" TagName="WUC_Address" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link type="text/css" href="../../Css/main.css" rel="Stylesheet" />
    <style type="text/css">
        .margin-right {
            margin-right: 5px;
        }

        .padding-left {
            padding-left: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false"
            EnableBackgroundColor="true" Layout="HBox" BoxConfigAlign="Stretch">
            <Toolbars>
                <x:Toolbar ID="Toolbar1" runat="server">
                    <Items>
                        <x:Button ID="btn_SaveAndClose" runat="server" Text="保存并关闭" ValidateForms="SimpleForm1"
                            Icon="SystemSaveNew" OnClick="btn_SaveAndClose_Click">
                        </x:Button>
                    </Items>
                </x:Toolbar>
            </Toolbars>
            <Items>
                <x:Panel ID="Panel2" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" Title="经销商信息" EnableBackgroundColor="true"
                    CssStyle="padding-right:5px" BoxFlex="1" Layout="VBox" BoxConfigAlign="Stretch">
                    <Items>
                        <x:Form ID="Form2" runat="server" BodyPadding="5px" ShowHeader="false" EnableBackgroundColor="true" Height="40px"
                            LabelWidth="60px" CssStyle="padding-bottom:5px" BoxConfigAlign="Stretch">
                            <Rows>
                                <x:FormRow runat="server">
                                    <Items>
                                        <x:TwinTriggerBox ID="ttb_DealerName" runat="server" Label="经销商名"
                                            Trigger1Icon="Clear" Trigger2Icon="Search" Width="300px" ShowLabel="true"
                                            OnTrigger1Click="TwinTriggerBox1_Trigger1Click" OnTrigger2Click="TwinTriggerBox1_Trigger2Click">
                                        </x:TwinTriggerBox>
                                    </Items>
                                </x:FormRow>
                            </Rows>
                        </x:Form>
                        <x:Grid ID="grid_List" runat="server" ShowHeader="false" EnableBackgroundColor="true" IsDatabasePaging="true" AutoPostBack="true"
                            BoxFlex="1" DataKeyNames="DealerID,DealerName"
                            OnPageIndexChange="grid_List_PageIndexChange" EnableRowNumber="True" PageSize="10"
                            ClearSelectedRowsAfterPaging="false" AllowPaging="true"
                            OnRowDataBound="grid_List_RowDataBound" EnableRowSelect="true" OnRowSelect="grid_List_RowSelect">
                            <Columns>
                                <x:BoundField DataField="DealerName" DataFormatString="{0}" HeaderText="企业名称" Width="300px" />
                                <x:BoundField DataField="DealerType" DataFormatString="{0}" HeaderText="企业属性" Width="100px" />
                                <x:BoundField DataField="IsGroup" DataFormatString="{0}" HeaderText="是否是集团性质" Width="100px" />
                                <x:BoundField DataField="HasOtherIndustries" DataFormatString="{0}" HeaderText="是否有其他产业" Width="100px" />
                            </Columns>
                            <PageItems>
                                <x:ToolbarSeparator ID="ToolbarSeparator1" runat="server">
                                </x:ToolbarSeparator>
                                <x:ToolbarText ID="TtxtPage" runat="server" Text="每页数：">
                                </x:ToolbarText>
                                <x:DropDownList runat="server" ID="ddlPageSize" Width="40px" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                    <x:ListItem Text="5" Value="5" />
                                    <x:ListItem Text="10" Value="10" Selected="true" />
                                    <x:ListItem Text="15" Value="15" />
                                    <x:ListItem Text="20" Value="20" />
                                </x:DropDownList>
                            </PageItems>
                        </x:Grid>
                    </Items>
                </x:Panel>

                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false"
                    EnableBackgroundColor="true" Width="450px">
                    <Items>
                        <x:Label ID="lbl_DealerName" runat="server" Label="经销商名称" Text="" CssStyle="color:red;font-weight:bold"></x:Label>
                        <x:TextBox ID="txt_StorageName" runat="server" Label="二网名称" Text="" Width="200px">
                        </x:TextBox>
                        <x:CheckBoxList ID="cbl_StorageProp" runat="server" Label="二网性质" Width="200px" Required="true" RequiredMessage="请选择二网性质！">
                            <x:CheckItem Text="直营" Value="1" />
                            <x:CheckItem Text="控股" Value="2" />
                            <x:CheckItem Text="合作" Value="3" />
                            <x:CheckItem Text="其他" Value="4" />
                        </x:CheckBoxList>
                        <x:UserControlConnector ID="UserControlConnector1" runat="server">
                            <uc1:WUC_Address runat="server" ID="WUC_Address" />
                        </x:UserControlConnector>
                        <x:Panel ID="Panel3" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                            CssClass="x-form-item" Layout="Column">
                            <Items>
                                <x:Label ID="Label1" runat="server" Label="Label" CssStyle="padding-right:53px" Text="距店距离:"></x:Label>
                                <x:NumberBox ID="num_Distence" runat="server" DecimalPrecision="4" Width="50px" Text="0.00">
                                </x:NumberBox>
                                <x:Label ID="Label2" runat="server" Text="公里" CssStyle="padding-left:1px"></x:Label>
                            </Items>
                        </x:Panel>
                        <x:TextBox ID="txt_LinkmanName" runat="server" Label="联系人" Text="" Width="200px">
                        </x:TextBox>
                        <x:NumberBox ID="num_Phone" runat="server" Label="联系方式" Text="" Width="200px"></x:NumberBox>
                    </Items>
                </x:SimpleForm>
            </Items>
        </x:Panel>
        <x:HiddenField ID="hfSelectedIDS" runat="server">
        </x:HiddenField>
    </form>
</body>
</html>
