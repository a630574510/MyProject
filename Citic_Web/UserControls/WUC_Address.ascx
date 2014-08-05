<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WUC_Address.ascx.cs" Inherits="Citic_Web.UserControls.WUC_Address" %>
<x:DropDownList ID="ddl_Province" runat="server" Width="200px" Label="省" OnSelectedIndexChanged="ddl_Province_SelectedIndexChanged"
    Required="true" RequiredMessage="请选择省份！" ShowRedStar="true" CompareType="String" CompareValue="-1" CompareOperator="NotEqual"
    AutoPostBack="true">
</x:DropDownList>
<x:DropDownList ID="ddl_City" runat="server" Width="200px" Label="市" AutoPostBack="true"
    Required="true" RequiredMessage="请选择市！" ShowRedStar="true" CompareType="String" CompareValue="-1" CompareOperator="NotEqual">
</x:DropDownList>
<x:TextBox ID="txt_Address" runat="server" Label="具体地址" Text="" Width="300px">
</x:TextBox>
