<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadImage.aspx.cs" Inherits="Citic_Web.Reminds.UploadImage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <x:PageManager ID="PageManager1" runat="server" AutoSizePanelID="Panel1" />
        <x:Panel ID="Panel1" runat="server" BodyPadding="5px" ShowBorder="true" ShowHeader="true" EnableBackgroundColor="true" Title="上传图片">
            <Items>
                <x:SimpleForm ID="SimpleForm1" runat="server" BodyPadding="5px" ShowHeader="false" ShowBorder="false" EnableBackgroundColor="true">
                    <Items>
                        <x:DropDownList ID="ddl_Dealer" runat="server" Label="经销商" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddl_Dealer_SelectedIndexChanged"></x:DropDownList>
                        <x:DropDownList ID="ddl_Bank" runat="server" Label="合作行" Width="300px" AutoPostBack="true" OnSelectedIndexChanged="ddl_Bank_SelectedIndexChanged"></x:DropDownList>
                        <x:Label ID="lbl_Brand" runat="server" Label="品牌" Text=""></x:Label>
                        <x:FileUpload ID="file_Upload" runat="server" Label="请选择文件" Width="355px" AutoPostBack="true"></x:FileUpload>
                        <x:Button ID="btn_Upload" runat="server" Text="上传" OnClick="btn_Upload_Click"></x:Button>
                    </Items>
                </x:SimpleForm>
            </Items>
        </x:Panel>
    </form>
</body>
</html>
