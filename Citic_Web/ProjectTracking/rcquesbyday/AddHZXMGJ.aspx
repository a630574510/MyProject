<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddHZXMGJ.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.AddHZXMGJ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="false" Layout="Fit" EnableBackgroundColor="true">
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
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="0px" ShowBorder="false" ShowHeader="false" EnableBackgroundColor="true"
                    AutoScroll="true">
                    <Items>
                        <x:DropDownList ID="ddl_Brand" runat="server" Label="品牌" AutoPostBack="true" OnSelectedIndexChanged="ddl_Brand_SelectedIndexChanged" Width="100px"></x:DropDownList>
                        <x:DropDownList ID="ddl_Dealer" runat="server" Label="经销商" AutoPostBack="true" OnSelectedIndexChanged="ddl_Dealer_SelectedIndexChanged" Width="300px"></x:DropDownList>
                        <x:DropDownList ID="ddl_Bank" runat="server" Label="合作行" AutoPostBack="true" OnSelectedIndexChanged="ddl_Bank_SelectedIndexChanged" Width="300px"></x:DropDownList>
                        <x:Label ID="lbl_BusinessMode" runat="server" Label="业务模式" Text="" Width="300px"></x:Label>
                        <x:HiddenField ID="hf_BM" runat="server"></x:HiddenField>
                        <x:Label ID="lbl_DealerType" runat="server" Label="类型" Text="" Width="300px"></x:Label>
                        <x:HiddenField ID="hf_DT" runat="server"></x:HiddenField>
                        <x:Label ID="lbl_SDispatchTime" runat="server" Label="进驻日期" Text="" Width="200px"></x:Label>
                        <x:Label ID="lbl_Supervisor" runat="server" Label="监管员" Text="" Width="200px"></x:Label>
                        <x:HiddenField ID="hf_SN" runat="server"></x:HiddenField>
                        <x:Label ID="lbl_LinkPhone" runat="server" Label="联系方式" Text="" Width="200px"></x:Label>
                        <x:TextBox ID="col_1" runat="server" Label="监管员是否正常上岗" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="col_2" runat="server" Label="监管员委任书、经销店授权书、经销店告之函是否制作" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="col_3" runat="server" Label="设备是否到位（电脑、保险柜、手机、工牌、标识）" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="col_4" runat="server" Label="是否接受此行业务操作培训" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="col_5" runat="server" Label="公司规章制度及操作表单是否齐全" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="col_6" runat="server" Label="是否存在与其它公司交接工作" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="col_7" runat="server" Label="档案资料是否齐全并上交" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="col_8" runat="server" Label="是否已正常开展业务（承兑汇票信息、在库车辆）" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="col_9" runat="server" Label="监管费确认单" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="col_10" runat="server" Label="是否能正常进行查库工作" Text="" Width="300px"></x:TextBox>
                        <x:TextBox ID="col_11" runat="server" Label="雇员忠诚险" Text="" Width="300px"></x:TextBox>
                        <x:TextArea ID="txt_Remark" runat="server" Height="80px" Label="备注" Text="" Width="350px"></x:TextArea>
                    </Items>
                </x:SimpleForm>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
<x:FileUpload ID="FileUpload1" runat="server" Label="Label"></x:FileUpload>
