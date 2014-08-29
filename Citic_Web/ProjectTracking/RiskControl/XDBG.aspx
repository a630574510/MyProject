<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XDBG.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.XDBG" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>
        <asp:Literal ID="Title_DealerName" runat="server"></asp:Literal>经销店巡店报告 </title>

    <style type="text/css">
        table {
            border-spacing: 0px;
        }

        #lbl_MessCSS {
            color: red;
        }

        body {
            font-family: 微软雅黑;
            font-size: 16px;
        }

        .input_200_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 200px;
            height: 20px;
            font-size: 14px;
        }

        .input_300_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 300px;
            height: 20px;
            font-size: 14px;
        }

        .input_400_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 400px;
            height: 20px;
            font-size: 14px;
        }

        .input_500_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 500px;
            height: 20px;
            font-size: 14px;
        }

        .input_600_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 600px;
            height: 20px;
            font-size: 14px;
        }


        .input_150_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 150px;
            height: 20px;
            font-size: 14px;
        }

        .input_100_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 100px;
            height: 20px;
            font-size: 14px;
        }

        .input_80_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 80px;
            height: 20px;
            font-size: 14px;
        }

        .input_50_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 50px;
            height: 20px;
            font-size: 14px;
        }

        .solidBorder_Left_Top {
            border-left: black 1px solid;
            border-top: black 1px solid;
            border-spacing: 0px;
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
            width: 800px;
            height: 4500px;
            border: 0px solid black;
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
            width: 800px;
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
    <script src="../../My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../Js/jquery-1.7.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Container">
            <div id="Dealer_Title">
                <center><asp:Literal ID="DealerName" runat="server"></asp:Literal> 经销店巡店报告</center>
            </div>
            <asp:HiddenField ID="ID" runat="server" />
            <table id="table1" class="solidBorder_Left_Top">
                <tr>
                    <td colspan="4" class="title">经销店基本情况介绍：</td>
                </tr>
                <tr>
                    <td class="td_Width">店&nbsp;&nbsp;名：</td>
                    <td>
                        <asp:Literal ID="DealerName1" runat="server"></asp:Literal>
                        <asp:HiddenField ID="DealerID" runat="server" />
                    </td>
                    <td class="td_Width">店方地址：</td>
                    <td>
                        <asp:Literal ID="Address" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td class="td_Width">合作银行：</td>
                    <td>
                        <asp:Literal ID="BankName" runat="server"></asp:Literal>
                        <asp:HiddenField ID="BankID" runat="server" />
                    </td>
                    <td class="td_Width">品&nbsp;&nbsp;牌：</td>
                    <td>
                        <asp:Literal ID="BrandName" runat="server"></asp:Literal>
                        <asp:HiddenField ID="BrandIDs" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="td_Width">营业时间：</td>
                    <td>
                        <asp:Literal ID="DispatchTime" runat="server"></asp:Literal></td>
                    <td class="td_Width">操作模式：</td>
                    <td>
                        <%-- <input id="txt_CaoZuoMoShi" name="txt_CaoZuoMoShi" type="text" class="input_200_20" />--%>
                        <asp:TextBox ID="txt_CaoZuoMoShi" runat="server" CssClass="input_200_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td_Width">检查日期：</td>
                    <td>
                        <%--<input id="txt_CheckDate" name="txt_CheckDate" class="input_150_20" type="text" onclick="WdatePicker()" />--%>
                        <asp:TextBox ID="txt_CheckDate" runat="server" CssClass="input_150_20" onclick="WdatePicker()"></asp:TextBox></td>
                    <td class="td_Width">检查用时：</td>
                    <td>
                        <%--<input id="txt_CheckInTime" name="txt_CheckInTime" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="txt_CheckInTime" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="td_Width">经销店属性：</td>
                    <td colspan="3">
                        <asp:Literal ID="DealerType" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td class="td_Width">是否是集团性质：</td>
                    <td>
                        <asp:Literal ID="IsGroup" runat="server"></asp:Literal></td>
                    <td class="td_Width">是否是单店：</td>
                    <td>
                        <asp:Literal ID="IsSingleStore" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td class="td_Width">合作融资行数量：</td>
                    <td>
                        <asp:Literal ID="Banks" runat="server"></asp:Literal></td>
                    <td class="td_Width">合作融资行总额：</td>
                    <td>
                        <asp:Literal ID="AllSSMoney" runat="server"></asp:Literal></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input type="button" value="保存基本信息" id="btn_Basic" />
                    </td>
                </tr>
            </table>
            <table id="table2" class="solidBorder_Left_Top">
                <tr>
                    <td colspan="5" class="title">检查内容项填写：</td>
                </tr>
                <tr id="table2_tr1" class="title">
                    <td class="talbe2_XuHao_Width">序号</td>
                    <td class="talbe2_XM_Width">项目</td>
                    <td class="talbe2_TX_Width">填写项</td>
                    <td class="talbe2_MX_Width">明细项</td>
                    <td class="talbe2_Remark_Width">备注</td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width" rowspan="3">1</td>
                    <td class="talbe2_XM_Width" rowspan="3">项目</td>
                    <td class="talbe2_TX_Width">具体分布</td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_1_1" name="CCS_1_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_1_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width" rowspan="3">
                        <%--<input id="CCS_1_4" name="CCS_1_4" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_1_4" runat="server" CssClass="input_150_20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="talbe2_TX_Width">异常情况具体说明</td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_1_2" name="CCS_1_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_1_2" runat="server" CssClass="input_150_20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="talbe2_TX_Width">异常情况是否上报</td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_1_3" name="CCS_1_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_1_3" runat="server" CssClass="input_150_20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">2</td>
                    <td class="talbe2_XM_Width">汇票信息</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_2_1" name="CCS_2_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_2_1" runat="server" CssClass="input_150_20"></asp:TextBox>
                    </td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_2_2" name="CCS_2_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_2_2" runat="server" CssClass="input_150_20"></asp:TextBox>
                    </td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_2_3" name="CCS_2_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_2_3" runat="server" CssClass="input_150_20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">3</td>
                    <td class="talbe2_XM_Width">合格证</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_3_1" name="CCS_3_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_3_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_3_2" name="CCS_3_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_3_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%-- <input id="CCS_3_3" name="CCS_3_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_3_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">4</td>
                    <td class="talbe2_XM_Width">钥匙</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_4_1" name="CCS_4_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_4_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_4_2" name="CCS_4_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_4_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_4_3" name="CCS_4_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_4_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">5</td>
                    <td class="talbe2_XM_Width">信息系统</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_5_1" name="CCS_5_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_5_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_5_2" name="CCS_5_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_5_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_5_3" name="CCS_5_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_5_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">6</td>
                    <td class="talbe2_XM_Width">手工台账</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_6_1" name="CCS_6_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_6_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_6_2" name="CCS_6_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_6_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_6_3" name="CCS_6_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_6_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">7</td>
                    <td class="talbe2_XM_Width">电子总账</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_7_1" name="CCS_7_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_7_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_7_2" name="CCS_7_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_7_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_7_3" name="CCS_7_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_7_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">8</td>
                    <td class="talbe2_XM_Width">钥匙交接及钥匙借出登记表</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_8_1" name="CCS_8_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_8_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width" rowspan="4">
                        <%--<input id="CCS_8_2" name="CCS_8_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_8_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width" rowspan="4">
                        <%--<input id="CCS_8_3" name="CCS_8_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_8_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">9</td>
                    <td class="talbe2_XM_Width">日查库检查表/ 统计表</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_9_1" name="CCS_9_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_9_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">10</td>
                    <td class="talbe2_XM_Width">周/月库存盘点表</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_10_1" name="CCS_10_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_10_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">11</td>
                    <td class="talbe2_XM_Width">其他文档的保存</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_11_1" name="CCS_11_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_11_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">12</td>
                    <td class="talbe2_XM_Width">经销商告知函、委任书</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_12_1" name="CCS_12_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_12_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width" rowspan="2">
                        <%--<input id="CCS_12_2" name="CCS_12_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_12_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_12_3" name="CCS_12_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_12_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">13</td>
                    <td class="talbe2_XM_Width">4S店授权书</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_13_1" name="CCS_13_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_13_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_13_3" name="CCS_13_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_13_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">14</td>
                    <td class="talbe2_XM_Width">工装</td>
                    <td class="talbe2_TX_Width" rowspan="2">
                        <%--<input id="CCS_14_1" name="CCS_14_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_14_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width" rowspan="2">
                        <%--<input id="CCS_14_2" name="CCS_14_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_14_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_14_3" name="CCS_14_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_14_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">15</td>
                    <td class="talbe2_XM_Width">工牌</td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_15_3" name="CCS_15_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_15_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">16</td>
                    <td class="talbe2_XM_Width">质押车标识</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_16_1" name="CCS_16_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_16_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_16_2" name="CCS_16_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_16_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_16_3" name="CCS_16_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_16_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">17</td>
                    <td class="talbe2_XM_Width">视频设备</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_17_1" name="CCS_17_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_17_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_17_2" name="CCS_17_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_17_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_17_3" name="CCS_17_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_17_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">18</td>
                    <td class="talbe2_XM_Width">办公条件及设备</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_18_1" name="CCS_18_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_18_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_18_2" name="CCS_18_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_18_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_18_3" name="CCS_18_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_18_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">19</td>
                    <td class="talbe2_XM_Width">工作手机是否配发</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_19_1" name="CCS_19_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_19_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_19_2" name="CCS_19_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_19_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_19_3" name="CCS_19_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_19_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="talbe2_XuHao_Width">20</td>
                    <td class="talbe2_XM_Width">工作手机是否完成现场数据采集</td>
                    <td class="talbe2_TX_Width">
                        <%--<input id="CCS_20_1" name="CCS_20_1" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_20_1" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_MX_Width">
                        <%--<input id="CCS_20_2" name="CCS_20_2" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_20_2" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="talbe2_Remark_Width">
                        <%--<input id="CCS_20_3" name="CCS_20_3" class="input_150_20" type="text" runat="server" />--%>
                        <asp:TextBox ID="CCS_20_3" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>

                <tr>
                    <td colspan="5">
                        <%--<input type="button" value="保存" id="btn_CCS" />--%>
                        <asp:Button ID="btn_CCS" runat="server" Text="保存" OnClick="btn_CSS_Click" /><asp:Literal ID="lbl_MessCSS" runat="server"></asp:Literal>
                    </td>
                </tr>
            </table>
            <table id="table3" class="solidBorder_Left_Top">
                <tr>
                    <td colspan="2" class="title">检查过程中发现的问题及监管员优/缺点：</td>
                </tr>
                <tr id="table3_tr1" class="title">
                    <td>序号</td>
                    <td>发现问题</td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">1</td>
                    <td>
                        <%--<input id="PIC_1_1" name="PIC_1_1" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_1_1" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">具体明细</td>
                    <td>
                        <%--<input id="PIC_1_2" name="PIC_1_2" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_1_2" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">2</td>
                    <td>
                        <%--<input id="PIC_2_1" name="PIC_2_1" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_2_1" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">具体明细</td>
                    <td>
                        <%--<input id="PIC_2_2" name="PIC_2_2" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_2_2" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">3</td>
                    <td>
                        <%--<input id="PIC_3_1" name="PIC_3_1" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_3_1" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">具体明细</td>
                    <td>
                        <%--<input id="PIC_3_2" name="PIC_3_2" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_3_2" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">4</td>
                    <td>
                        <%--<input id="PIC_4_1" name="PIC_4_1" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_4_1" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">处理结果</td>
                    <td>
                        <%--<input id="PIC_4_2" name="PIC_4_2" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_4_2" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">5</td>
                    <td>
                        <%--<input id="PIC_5_1" name="PIC_5_1" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_5_1" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">处理结果</td>
                    <td>
                        <%--<input id="PIC_5_2" name="PIC_5_2" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_5_2" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">6</td>
                    <td>
                        <%--<input id="PIC_6_1" name="PIC_6_1" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_6_1" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">处理结果</td>
                    <td>
                        <%--<input id="PIC_6_2" name="PIC_6_2" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_6_2" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">7</td>
                    <td>
                        <%--<input id="PIC_7_1" name="PIC_7_1" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_7_1" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">处理结果</td>
                    <td>
                        <%--<input id="PIC_7_2" name="PIC_7_2" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="PIC_7_2" runat="server" CssClass="input_600_20"></asp:TextBox></td>
                </tr>

                <tr>
                    <td colspan="2">
                        <input type="button" value="保存" id="btn_PIC" />
                    </td>
                </tr>
            </table>
            <table id="table31" class="solidBorder_Left_Top">
                <tr id="table31_tr1" class="title">
                    <td>序号</td>
                    <td>监管员优点/缺点</td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">1</td>
                    <td>
                        <%--<input id="SGAB_1" name="SGAB_1" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="SGAB_1" runat="server" CssClass="input_600_20"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="table3_XuHao_Width">2</td>
                    <td>
                        <%--<input id="SGAB_2" name="SGAB_2" class="input_600_20" type="text" />--%>
                        <asp:TextBox ID="SGAB_2" runat="server" CssClass="input_600_20"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td colspan="2">
                        <input type="button" value="保存" id="btn_SGAB" />
                    </td>
                </tr>
            </table>
            <table id="table4" class="solidBorder_Left_Top">
                <tr class="rowHeight">
                    <td class="title" colspan="4">与店方沟通情况：</td>
                </tr>
                <tr>
                    <td class="auto-style3">店方人员姓名：</td>
                    <td>
                        <%--<input id="CWS_Name" name="CWS_Name" class="input_200_20" type="text" />--%>
                        <asp:TextBox ID="CWS_Name" runat="server" CssClass="input_200_20"></asp:TextBox></td>
                    <td class="table4_1_Width">职位：</td>
                    <td>
                        <%--<input id="CWS_Post" name="CWS_Post" class="input_200_20" type="text" />--%>
                        <asp:TextBox ID="CWS_Post" runat="server" CssClass="input_200_20"></asp:TextBox></td>
                </tr>
                <tr valign="top">
                    <td colspan="4">座谈内容：<br />
                        <%--<textarea id="CWS_Content" name="CWS_Content" style="margin-top: 10px; border: 0px; height: 228px; width: 779px;"></textarea>--%>
                        <asp:TextBox ID="CWS_Content" runat="server" Height="158px" Width="775px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input type="button" value="保存" id="btn_CWS" />
                    </td>
                </tr>
            </table>
            <table class="solidBorder_Left_Top">
                <tr height="30px" class="title">
                    <td>检查结果总结：</td>
                </tr>
                <tr height="100px">
                    <td>
                        <%--<textarea id="CheckResults" name="CheckResults" style="margin-top: 10px; border: 0px; height: 95px; width: 782px;"></textarea>--%>
                        <asp:TextBox ID="CheckResults" runat="server" Height="77px" Width="780px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input type="button" value="保存" id="btn_CheckResults" style="margin-top: 10px" />
                    </td>
                </tr>
            </table>
            <table id="table6" class="solidBorder_Left_Top">
                <tr height="30px" class="title">
                    <td colspan="4">监管员基本情况介绍：</td>
                </tr>
                <tr>
                    <td rowspan="2" class="auto-style4">监管员姓名：</td>
                    <td rowspan="2" class="auto-style2">
                        <%--<input id="BIS_Name" name="BIS_Name" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_Name" runat="server" CssClass="input_150_20"></asp:TextBox>
                    </td>
                    <td rowspan="2" class="auto-style1">联系方式：</td>
                    <td>公司配发手机：<%--<input id="BIS_Phone_PF" name="BIS_Phone_PF" class="input_150_20" type="text" onclick="WdatePicker()" />--%>
                        <asp:TextBox ID="BIS_Phone_PF" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>紧急联系电话：<%--<input id="BIS_Phone_JJ" name="BIS_Phone_JJ" class="input_150_20" type="text" onclick="WdatePicker()" />--%>
                        <asp:TextBox ID="BIS_Phone_JJ" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">性别：</td>
                    <td class="auto-style2">
                        <%--<input id="BIS_Sex" name="BIS_Sex" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_Sex" runat="server" CssClass="input_150_20"></asp:TextBox>
                    </td>
                    <td class="auto-style1">学历：</td>
                    <td class="table6_2_Width">
                        <%--<input id="BIS_Edu" name="BIS_Edu" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_Edu" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">年龄：</td>
                    <td class="auto-style2">
                        <%--<input id="BIS_Age" name="BIS_Age" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_Age" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="auto-style1">公司认可属性：</td>
                    <td class="table6_2_Width">
                        <%--<input id="BIS_GSRKSX" name="BIS_GSRKSX" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_GSRKSX" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">户口所在地：</td>
                    <td class="auto-style2">
                        <%--<input id="BIS_HA" name="BIS_HA" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_HA" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="auto-style1">本人实际属性：</td>
                    <td class="table6_2_Width">
                        <%--<input id="BIS_BRSJSX" name="BIS_BRSJSX" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_BRSJSX" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">住宿：</td>
                    <td class="auto-style2">
                        <%--<input id="BIS_Stay" name="BIS_Stay" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_Stay" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="auto-style1">用餐：</td>
                    <td class="table6_2_Width">
                        <%--<input id="BIS_Eat" name="BIS_Eat" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_Eat" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="auto-style4">电脑技能：</td>
                    <td class="auto-style2">
                        <%--<input id="BIS_CS" name="BIS_CS" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_CS" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td class="auto-style1">招聘来源：</td>
                    <td class="table6_2_Width">
                        <%--<input id="BIS_WS" name="BIS_WS" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_WS" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                </tr>
                <tr>
                    <td rowspan="2" class="auto-style4">周末休假：</td>
                    <td rowspan="2" class="auto-style2">
                        <%--<input id="BIS_WB" name="BIS_WB" class="input_150_20" type="text" />--%>
                        <asp:TextBox ID="BIS_WB" runat="server" CssClass="input_150_20"></asp:TextBox></td>
                    <td rowspan="2" class="auto-style1">上岗时间：</td>
                    <td>初次上岗时间：<%--<input id="BIS_SGTime" name="BIS_SGTime" class="input_150_20" type="text" onclick="WdatePicker()" />--%>
                        <asp:TextBox ID="BIS_SGTime" runat="server" CssClass="input_150_20" onclick="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>监管此店时间：<%--<input id="BIS_JGSTime" name="BIS_JGSTime" class="input_150_20" type="text" onclick="WdatePicker()" />--%>
                        <asp:TextBox ID="BIS_JGSTime" runat="server" CssClass="input_150_20" onclick="WdatePicker()"></asp:TextBox></td>
                </tr>
                <tr style="height: 100px">
                    <td class="auto-style4">工作经历(监管员对工作、总部建议)</td>
                    <td colspan="3" class="table6_2_Width">
                        <%--<textarea id="BIS_WE" name="BIS_WE" style="margin-top: 10px; border: 0px; height: 79px; width: 695px;"></textarea>--%>
                        <asp:TextBox ID="BIS_WE" runat="server" Height="104px" Width="678px" TextMode="MultiLine"></asp:TextBox></td>
                </tr>
                <tr style="height: 100px">
                    <td class="auto-style4">巡检人员对监管员评价</td>
                    <td colspan="3" class="table6_2_Width">
                        <%--<textarea id="BIS_EFS" name="BIS_EFS" style="margin-top: 10px; border: 0px; height: 79px; width: 695px;"></textarea>--%>
                        <asp:TextBox ID="BIS_EFS" runat="server" Height="86px" TextMode="MultiLine" Width="678px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input type="button" value="保存" id="btn_BIS" />
                    </td>
                </tr>
            </table>
            <table id="table7" class="solidBorder_Left_Top">
                <tr class="title">
                    <td colspan="3">店面拍照</td>
                </tr>
                <tr class="title">
                    <td>监管员照片</td>
                    <td>保险柜</td>
                    <td>工位</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:HiddenField ID="hf_S" runat="server" />
                        <asp:Image ID="img_S" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_S" runat="server" /><asp:Button ID="btn_S" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hf_SB" runat="server" />
                        <asp:Image ID="img_SB" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_SB" runat="server" /><asp:Button ID="btn_SB" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hf_WP" runat="server" />
                        <asp:Image ID="img_WP" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_WP" runat="server" /><asp:Button ID="btn_WP" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>合格证保存</td>
                    <td>钥匙保存</td>
                    <td>表单保存</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:HiddenField ID="hf_HGZ" runat="server" />
                        <asp:Image ID="img_HGZ" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_HGZ" runat="server" /><asp:Button ID="btn_HGZ" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hf_Keys" runat="server" />
                        <asp:Image ID="img_Keys" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_Keys" runat="server" /><asp:Button ID="btn_Keys" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hf_Forms" runat="server" />
                        <asp:Image ID="img_Forms" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_Forms" runat="server" /><asp:Button ID="btn_Forms" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td>店面</td>
                    <td>展厅</td>
                    <td>车库</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:HiddenField ID="hf_Shop" runat="server" />
                        <asp:Image ID="img_Shop" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_Shop" runat="server" /><asp:Button ID="btn_Shop" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hf_SR" runat="server" />
                        <asp:Image ID="img_SR" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_SR" runat="server" /><asp:Button ID="btn_SR" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                    <td>
                        <asp:Image ID="img_CK" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_CK" runat="server" /><asp:Button ID="btn_CK" runat="server" Text="预览" OnClick="btn_Click" />
                        <asp:HiddenField ID="hf_CK" runat="server" />
                    </td>
                </tr>
                <tr class="title">
                    <td>车库2</td>
                    <td>宿舍</td>
                    <td>店方荣誉</td>
                </tr>
                <tr style="text-align: center">
                    <td>
                        <asp:HiddenField ID="hf_CK2" runat="server" />
                        <asp:Image ID="img_CK2" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_CK2" runat="server" /><asp:Button ID="btn_CK2" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hf_SS" runat="server" />
                        <asp:Image ID="img_SS" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_SS" runat="server" /><asp:Button ID="btn_SS" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hf_DFRY" runat="server" />
                        <asp:Image ID="img_DFRY" ImageUrl="~/Images/blank.png" runat="server" Width="200px" Height="200px" /><br />
                        <asp:FileUpload ID="P_DFRY" runat="server" /><asp:Button ID="btn_DFRY" runat="server" Text="预览" OnClick="btn_Click" />
                    </td>
                </tr>
                <tr class="title">
                    <td colspan="3">
                        <input type="button" value="保存" id="btn_P" />
                    </td>
                </tr>
            </table>

            <div style="text-align: right;">
                <p>
                    检查人：
                    <asp:TextBox ID="Checkman" runat="server" CssClass="input_150_20"></asp:TextBox>
                </p>
                <p>日期：<asp:TextBox ID="CheckDate2" runat="server" CssClass="input_150_20" onclick="WdatePicker()"></asp:TextBox></p>
                <p>
                    <input id="btn_Sub" name="btn_Sub" type="button" value="提交" />
                </p>
            </div>
        </div>
    </form>
</body>
</html>

<script type="text/javascript">

    $(function () {
        $(":button").click(function () {
            save(this.id);
        });
    });

    function save(id) {
        var _id = $("#ID").val();
        if (id != '') {
            if (id == "btn_Basic") {
                var czms = $("#txt_CaoZuoMoShi").val();
                var cd = $("#txt_CheckDate").val();
                var cit = $("#txt_CheckInTime").val();
                $.ajax({
                    type: 'post',
                    url: '../../ProjectTracking/RiskControl/save.ashx',
                    data: 'type=basic&id=' + _id + '&czms=' + czms + '&cd=' + cd + '&cit=' + cit,
                    dataType: 'text',
                    success: function (msg) {
                        if (msg == "1") {
                            alert('保存成功！');
                        } else {
                            alert('保存失败！');
                        }
                    }
                });
            } else if (id == "btn_PIC") {
                var pic11 = $("#PIC_1_1").val();
                var pic12 = $("#PIC_1_2").val();
                var pic21 = $("#PIC_2_1").val();
                var pic22 = $("#PIC_2_2").val();
                var pic31 = $("#PIC_3_1").val();
                var pic32 = $("#PIC_3_2").val();
                var pic41 = $("#PIC_4_1").val();
                var pic42 = $("#PIC_4_2").val();
                var pic51 = $("#PIC_5_1").val();
                var pic52 = $("#PIC_5_2").val();
                var pic61 = $("#PIC_6_1").val();
                var pic62 = $("#PIC_6_2").val();
                var pic71 = $("#PIC_7_1").val();
                var pic72 = $("#PIC_7_2").val();
                $.ajax({
                    type: 'post',
                    url: '../../ProjectTracking/RiskControl/save.ashx',
                    data: 'type=pic&id=' + _id + '&pic11=' + pic11 + '&pic12=' + pic12 + '&pic21=' + pic21 + '&pic22=' + pic22 + '&pic31=' + pic31 + '&pic32=' + pic32 + '&pic41=' + pic41 + '&pic42=' + pic42 + '&pic51=' + pic51 + '&pic52=' + pic52 + '&pic61=' + pic61 + '&pic62=' + pic62 + '&pic71=' + pic71 + '&pic72=' + pic72,
                    dataType: 'text',
                    success: function (msg) {
                        if (msg == "1") {
                            alert('保存成功！');
                        } else {
                            alert('保存失败！');
                        }
                    }
                });
                //}
                //else if (id == "btn_CCS") {
                //    var css11 = $("#CCS_1_1").val();
                //    var css12 = $("#CCS_1_2").val();
                //    var css13 = $("#CCS_1_3").val();
                //    var css14 = $("#CCS_1_4").val();
                //    var css21 = $("#CCS_2_1").val();
                //    var css22 = $("#CCS_2_2").val();
                //    var css23 = $("#CCS_2_3").val();
                //    var css31 = $("#CCS_3_1").val();
                //    var css32 = $("#CCS_3_2").val();
                //    var css33 = $("#CCS_3_3").val();
                //    var css41 = $("#CCS_4_1").val();
                //    var css42 = $("#CCS_4_2").val();
                //    var css43 = $("#CCS_4_3").val();
                //    var css51 = $("#CCS_5_1").val();
                //    var css52 = $("#CCS_5_2").val();
                //    var css53 = $("#CCS_5_3").val();
                //    var css61 = $("#CCS_6_1").val();
                //    var css62 = $("#CCS_6_2").val();
                //    var css63 = $("#CCS_6_3").val();
                //    var css71 = $("#CCS_7_1").val();
                //    var css72 = $("#CCS_7_2").val();
                //    var css73 = $("#CCS_7_3").val();
                //    var css81 = $("#CCS_8_1").val();
                //    var css82 = $("#CCS_8_2").val();
                //    var css83 = $("#CCS_8_3").val();
                //    var css91 = $("#CCS_9_1").val();
                //    var css101 = $("#CCS_10_1").val();
                //    var css111 = $("#CCS_11_1").val();
                //    var css121 = $("#CCS_12_1").val();
                //    var css122 = $("#CCS_12_2").val();
                //    var css123 = $("#CCS_12_3").val();
                //    var css131 = $("#CCS_13_1").val();
                //    var css133 = $("#CCS_13_3").val();
                //    var css141 = $("#CCS_14_1").val();
                //    var css142 = $("#CCS_14_2").val();
                //    var css143 = $("#CCS_14_3").val();
                //    var css153 = $("#CCS_15_3").val();

                //    var css161 = $("#CCS_16_1").val();
                //    var css162 = $("#CCS_16_2").val();
                //    var css163 = $("#CCS_16_3").val();
                //    var css171 = $("#CCS_17_1").val();
                //    var css172 = $("#CCS_17_2").val();
                //    var css173 = $("#CCS_17_3").val();
                //    var css181 = $("#CCS_18_1").val();
                //    var css182 = $("#CCS_18_2").val();
                //    var css183 = $("#CCS_18_3").val();
                //    var css191 = $("#CCS_19_1").val();
                //    var css192 = $("#CCS_19_2").val();
                //    var css193 = $("#CCS_19_3").val();
                //    var css201 = $("#CCS_20_1").val();
                //    var css202 = $("#CCS_20_2").val();
                //    var css203 = $("#CCS_20_3").val();

                //    $.ajax({
                //        type: 'post',
                //        url: '../../ProjectTracking/RiskControl/save.ashx',
                //        data:
                //            'type=ccs&id=' + _id + '&css11=' + css11 + '&css12=' + css12 + '&css13=' + css13 + '&css14=' + css14 + '&css21=' + css21 + '&css22=' + css22 + '&css23=' + css23 + '&css31=' + css31 + '&css32=' + css32 + '&css33=' + css33 + '&css41=' + css41 + '&css42=' + css42 + '&css43=' + css43 + '&css51=' + css51 + '&css52=' + css52 + '&css53=' + css53 + '&css61=' + css61 + '&css62=' + css62 + '&css63=' + css63 + '&css71=' + css71 + '&css72=' + css72 + '&css73=' + css73 + '&css81=' + css81 + '&css82=' + css82 + '&css83=' + css83 +
                //            '&css91=' + css91 + '&css101=' + css101 + '&css111=' + css111 + '&css121=' + css121 + '&css122=' + css122 + '&css123=' + css123 + '&css131=' + css131 + '&css133=' + css133 + '&css141=' + css141 + '&css142=' + css142 + '&css143=' + css143 + '&css153=' + css153 +
                //            '&css161=' + css161 + '&css162=' + css162 + '&css163=' + css163 + '&css171=' + css171 + '&css172=' + css172 + '&css173=' + css173 + '&css181=' + css181 + '&css182=' + css182 + '&css183=' + css183 + '&css191=' + css191 + '&css192=' + css192 + '&css193=' + css193 + '&css201=' + css201 + '&css202=' + css202 + '&css203=' + css203,
                //        dataType: 'text',
                //        success: function (msg) {
                //            if (msg == "1") {
                //                alert('保存成功！');
                //            } else {
                //                alert('保存失败！');
                //            }
                //        }
                //    });
            } else if (id == "btn_SGAB") {
                var sgab1 = $("#SGAB_1").val();
                var sgab2 = $("#SGAB_2").val();
                $.ajax({
                    type: 'post',
                    url: '../../ProjectTracking/RiskControl/save.ashx',
                    data: 'type=sgab&id=' + _id + '&sgab1=' + sgab1 + "&sgab2=" + sgab2,
                    dataType: 'text',
                    success: function (msg) {
                        if (msg == "1") {
                            alert('保存成功！');
                        } else {
                            alert('保存失败！');
                        }
                    }
                });
            } else if (id == "btn_CWS") {
                var cwsname = $("#CWS_Name").val();
                var cwspost = $("#CWS_Post").val();
                var cwscontent = $("#CWS_Content").val();
                $.ajax({
                    type: 'post',
                    url: '../../ProjectTracking/RiskControl/save.ashx',
                    data: 'type=cws&id=' + _id + '&cwsname=' + cwsname + "&cwspost=" + cwspost + "&cwscontent=" + cwscontent,
                    dataType: 'text',
                    success: function (msg) {
                        if (msg == "1") {
                            alert('保存成功！');
                        } else {
                            alert('保存失败！');
                        }
                    }
                });
            } else if (id == "btn_CheckResults") {
                var cr = $("#CheckResults").val();
                $.ajax({
                    type: 'post',
                    url: '../../ProjectTracking/RiskControl/save.ashx',
                    data: 'type=cr&id=' + _id + '&cr=' + cr,
                    dataType: 'text',
                    success: function (msg) {
                        if (msg == "1") {
                            alert('保存成功！');
                        } else {
                            alert('保存失败！');
                        }
                    }
                });
            } else if (id == "btn_BIS") {
                var bisname = $("#BIS_Name").val();
                var bf = $("#BIS_Phone_PF").val();
                var jj = $("#BIS_Phone_JJ").val();
                var bissex = $("#BIS_Sex").val();
                var bisedu = $("#BIS_Edu").val();
                var bisage = $("#BIS_Age").val();
                var bisgsrksx = $("#BIS_GSRKSX").val();
                var bisha = $("#BIS_HA").val();
                var bisbrsjsx = $("#BIS_BRSJSX").val();
                var bisstay = $("#BIS_Stay").val();
                var biseat = $("#BIS_Eat").val();
                var biscs = $("#BIS_CS").val();
                var bisws = $("#BIS_WS").val();
                var biswb = $("#BIS_WB").val();
                var bissgtime = $("#BIS_SGTime").val();
                var bisjgtime = $("#BIS_JGSTime").val();
                var biswe = $("#BIS_WE").val();
                var bisefs = $("#BIS_EFS").val();
                $.ajax({
                    type: 'post',
                    url: '../../ProjectTracking/RiskControl/save.ashx',
                    data: 'type=bis&id=' + _id + '&bisname=' + bisname + '&bf=' + bf + '&jj=' + jj + '&bissex=' + bissex + '&bisedu=' + bisedu + '&bisage=' + bisage + '&bisgsrksx=' + bisgsrksx + '&bisha=' + bisha + '&bisbrsjsx=' + bisbrsjsx + '&bisstay=' + bisstay + '&biseat=' + biseat + '&biscs=' + biscs + '&bisws=' + bisws + '&biswb=' + biswb + '&bissgtime=' + bissgtime + '&bisjgtime=' + bisjgtime + '&biswe=' + biswe + '&bisefs=' + bisefs,
                    dataType: 'text',
                    success: function (msg) {
                        if (msg == "1") {
                            alert('保存成功！');
                        } else {
                            alert('保存失败！');
                        }
                    }
                });
            } else if (id == "btn_P") {
                var hf_S = $("#hf_S").val();
                var hf_SB = $("#hf_SB").val();
                var hf_WP = $("#hf_WP").val();
                var hf_HGZ = $("#hf_HGZ").val();
                var hf_Keys = $("#hf_Keys").val();
                var hf_Forms = $("#hf_Forms").val();
                var hf_Shop = $("#hf_Shop").val();
                var hf_SR = $("#hf_SR").val();
                var hf_CK = $("#hf_CK").val();
                var hf_CK2 = $("#hf_CK2").val();
                var hf_SS = $("#hf_SS").val();
                var hf_DFRY = $("#hf_DFRY").val();
                $.ajax({
                    type: 'post',
                    url: '../../ProjectTracking/RiskControl/save.ashx',
                    data: 'type=p&id=' + _id + '&hf_S=' + hf_S + '&hf_SB=' + hf_SB + '&hf_WP=' + hf_WP + '&hf_HGZ=' + hf_HGZ + '&hf_Keys=' + hf_Keys + '&hf_Forms=' + hf_Forms +
                        '&hf_Shop=' + hf_Shop + '&hf_SR=' + hf_SR + '&hf_CK=' + hf_CK + '&hf_CK2=' + hf_CK2 + '&hf_SS=' + hf_SS + '&hf_DFRY=' + hf_DFRY,
                    dataType: 'text',
                    success: function (msg) {
                        if (msg == "1") {
                            alert('保存成功！');
                        } else {
                            alert('保存失败！');
                        }
                    }
                });
            } else if (id == "btn_Sub") {
                var checkman = $("#Checkman").val();
                var checkdate = $("#CheckDate2").val();
                $.ajax({
                    type: 'post',
                    url: '../../ProjectTracking/RiskControl/save.ashx',
                    data: 'type=end&id=' + _id + '&checkman=' + checkman + '&checkdate=' + checkdate,
                    dataType: 'text',
                    success: function (msg) {
                        if (msg == "1") {
                            alert('提交成功！');
                        } else {
                            alert('提交失败！');
                        }
                    }
                });
            }
        }
    }

    function ShowImage(inputObj, imgID) {
        //先获取文件路径
        var filepath = $(inputObj).attr("value");

    }
    //JavaScript取文件完整路径
    function getFullPath(obj) {
        if (obj) {
            //ie 
            if (window.navigator.userAgent.indexOf("MSIE") >= 1) {
                obj.select();
                return document.selection.createRange().text;
            }
                //firefox 
            else if (window.navigator.userAgent.indexOf("Firefox") >= 1) {
                if (obj.files) {
                    return obj.files.item(0).getAsDataURL();
                }
                return obj.value;
            }
            return obj.value;
        }
    }
</script>
