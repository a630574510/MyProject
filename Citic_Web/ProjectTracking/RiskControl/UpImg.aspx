<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpImg.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.UpImg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <style type="text/css">
        body {
            font-family: 微软雅黑;
            font-size: 16px;
        }

        .solidBorder_Left_Top {
            border-left: black 1px solid;
            border-top: black 1px solid;
        }

        .solidBorder_Right_Bottom {
            border-right: black 1px solid;
            border-bottom: black 1px solid;
        }

        .td_Width {
            width: 100px;
        }

        .talbe2_XuHao_Width {
            width: 30px;
            font-weight: bold;
            text-align: center;
        }

        .talbe2_XM_Width {
            width: 150px;
        }

        .talbe2_TX_Width {
            width: 150px;
        }

        .talbe2_MX_Width {
            width: 150px;
        }

        .talbe2_Remark_Width {
            width: 150px;
        }

        .table3_XuHao_Width {
            width: 80px;
            font-weight: bold;
            text-align: center;
        }

        .table4_1_Width {
            width: 100px;
            height: 30px;
        }

        .table6_1_Width {
            width: 100px;
            text-align: center;
            font-weight: bold;
        }

        .table6_2_Width {
            width: 200px;
        }

        #Container {
            width: 1000px;
            height: 4500px;
            padding: 10px 10px 10px 10px;
            margin: 0px auto;
        }

            #Container #table1 {
                width: 800px;
                margin: 0px 0px 10px 0px;
            }

            #Container #table2 {
                width: 800px;
                margin: 0px 0px 10px 0px;
            }

            #Container #table3 {
                width: 800px;
                margin: 0px 0px 10px 0px;
            }

            #Container #table4 {
                height: 325px;
            }

        .title {
            font-size: 16px;
            font-weight: bold;
            text-align: center;
        }

        .rowHeight {
            height: 30px;
        }

        #Container #table1 tr {
            height: 50px;
        }

        #Container #table2 tr {
            height: 30px;
        }

        #Container #table3 tr {
            height: 30px;
        }

        #Container #table31 tr {
            height: 30px;
        }

        #Container #table6 tr {
            height: 40px;
        }

        #Container table {
            width: 1000px;
            margin: 0px 0px 10px 0px;
        }

            #Container table td {
                border-right: black 1px solid;
                border-bottom: black 1px solid;
                padding-left: 5px;
            }

        #Container #Dealer_Title {
            font-size: 30px;
            font-weight: bold;
            width: 800px;
            margin: 0px 0px 20px 0px;
        }

        .bottom {
            text-align: right;
            margin-right: 50px;
        }

        .auto-style1 {
            width: 75px;
            font-weight: bold;
            text-align: center;
        }

        .auto-style2 {
            width: 178px;
        }

        .auto-style3 {
            width: 137px;
            height: 30px;
        }

        .auto-style4 {
            width: 385px;
            text-align: center;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Container">
            <table id="table7" class="solidBorder_Left_Top" cellpadding="0" cellspacing="0">
                <tr class="title">
                    <td colspan="3">店面拍照</td>
                </tr>
                <tr class="title">
                    <td>监管员照片</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_S" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_S" runat="server" /><asp:Button ID="btn_S" runat="server" Text="预览" OnClick="btn_Click" />
                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="P_S"
                            ErrorMessage="必须是 jpg或者gif文件" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\W+)\$?)(\\(\W[\W].*))+(.jpg|.Jpg|.JPEG|.gif|.Gif)$"></asp:RegularExpressionValidator>--%>
                    </td>
                </tr>
                <tr class="title">
                    <td>保险柜</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_SB" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_SB" runat="server" /><asp:Button ID="btn_SB" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>工位</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_WP" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_WP" runat="server" /><asp:Button ID="btn_WP" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>合格证保存</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_HGZ" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_HGZ" runat="server" /><asp:Button ID="btn_HGZ" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>钥匙保存</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_Keys" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_Keys" runat="server" /><asp:Button ID="btn_Keys" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>表单保存</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_Forms" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_Forms" runat="server" /><asp:Button ID="btn_Forms" runat="server" Text="预览" OnClick="btn_Click" /></td>
                </tr>
                <tr class="title">
                    <td>店面</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_Shop" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_Shop" runat="server" /><asp:Button ID="btn_Shop" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>展厅</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_SR" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_SR" runat="server" /><asp:Button ID="btn_SR" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>车库</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_CK" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_CK" runat="server" /><asp:Button ID="btn_CK" runat="server" Text="预览" OnClick="btn_Click" /></td>
                </tr>
                <tr class="title">
                    <td>车库2</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_CK2" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_CK2" runat="server" /><asp:Button ID="btn_CK2" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>宿舍</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_SS" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_SS" runat="server" /><asp:Button ID="btn_SS" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>店方荣誉</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:Image ID="img_DFRY" ImageUrl="~/Images/blank.png" runat="server" /><br />
                        <asp:FileUpload ID="P_DFRY" runat="server" /><asp:Button ID="btn_DFRY" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>
                        <input type="button" value="保存" id="btn_P" />
                    </td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
