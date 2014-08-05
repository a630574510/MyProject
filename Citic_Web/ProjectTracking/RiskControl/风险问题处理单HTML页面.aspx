<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="风险问题处理单HTML页面.aspx.cs" Inherits="Citic_Web.ProjectTracking.RiskControl.AddRiskQuestion1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>风险问题处理单</title>
    <style type="text/css">
        .input_200_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 200px;
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

        .input_150_20 {
            border: 0px;
            border-bottom: 1px solid black;
            width: 150px;
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

        table {
            border-left: black 1px solid;
            border-top: black 1px solid;
        }

            table tr {
                height: 40px;
            }

                table tr td {
                    border-right: black 1px solid;
                    border-bottom: black 1px solid;
                    padding-left: 10px;
                }

        .solidBorder_Left_Top {
            border-left: black 1px solid;
            border-top: black 1px solid;
        }

        .solidBorder_Right_Bottom {
            border-right: black 1px solid;
            border-bottom: black 1px solid;
        }

        #Container {
            width: 900px;
            height: 1500px;
            padding: 10px 10px 10px 10px;
            margin: 0px auto;
        }
    </style>

    <script src="../../My97DatePicker/WdatePicker.js"></script>
    <script src="../../jqueryui/js/jquery-1.8.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Container">

            <input id="ID" type="hidden" value="27" />
            <table cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan="4" style="font-size: 30px; font-weight: bold; text-align: center">风险问题处理单
                    </td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                    <td colspan="2">编号：<input type="text" value="" id="no" class="input_100_20" disabled="disabled" /></td>
                </tr>
                <tr>
                    <td rowspan="6">
                        <input type="checkbox" />&nbsp;  客户投诉</td>
                    <td colspan="3">投诉时间：<input id="CC_Date" type="text" class="input_200_20" onclick="WdatePicker()" /></td>
                </tr>
                <tr>
                    <td colspan="3">投诉接收人：<input id="CC_AP" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td colspan="3">投诉单位：<input id="CC_Unit" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td colspan="2">投诉人：<input id="CC_P" type="text" class="input_150_20" />
                    </td>
                    <td>投诉人职务：<input id="CC_Post" type="text" class="input_150_20" /></td>
                </tr>
                <tr>
                    <td colspan="3">投诉人联系方式：<input id="CC_PPhone" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td colspan="3">投诉内容：<input id="CC_Content" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td rowspan="4">
                        <input type="checkbox" />&nbsp; 监管员问题</td>
                    <td colspan="2">监管店：<input id="SQ_Shop" type="text" class="input_200_20" /></td>
                    <td>监管品牌：<input id="SQ_Brand" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td colspan="2">监管员姓名：<input id="SQ_Name" type="text" class="input_200_20" /></td>
                    <td>联系方式：<input id="SQ_Phone" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td colspan="2">问题反馈人员：<input id="SQ_FBP" type="text" class="input_200_20" /></td>
                    <td>联系方式：<input id="SQ_FBPP" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td colspan="3">问题描述：<br />
                        <textarea id="SQ_Content" style="margin-left: 10px; margin-top: 5px; width: 650px; height: 100px; border: 0px"></textarea></td>
                </tr>
                <tr>
                    <td colspan="2">调查人：<input id="S_P" type="text" class="input_200_20" />
                    </td>
                    <td colspan="2">调查人联系方式：<input id="S_Phone" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td colspan="4">调查结果：</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <textarea id="S_Result" style="margin-top: 5px; width: 800px; height: 100px; border: 0px"></textarea></td>
                </tr>
                <tr>
                    <td colspan="4">以上问题违反了物流金融《<input id="GD" type="text" class="input_200_20" />》规定。</td>
                </tr>
                <tr>
                    <td colspan="4">问题处理办法：</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <textarea id="WTCLBF" style="margin-top: 5px; width: 800px; height: 100px; border: 0px"></textarea></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: right">发现问题部门签字：<input id="FXWTBMQZ" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td colspan="4">汽车金融中心意见：</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <textarea id="QCJRZXYJ" style="margin-top: 5px; width: 800px; height: 100px; border: 0px"></textarea></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: right">汽车金融中心负责人签字：<input id="QCJRZXQZ" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td colspan="4">管理中心意见：</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <textarea id="GLZXYJ" style="margin-top: 5px; width: 800px; height: 100px; border: 0px"></textarea></td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: right">管理中心负责人签字：<input id="GLZXQZ" type="text" class="input_200_20" /></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <input id="btn_Sub" type="button" value="提交" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        var now = new Date();
        $("#no").val(now.getYear() + "" + now.getMonth() + "" + now.getDate() + "" + now.getHours() + "" + now.getMinutes() + "" + now.getSeconds());
        //$("#no").val("34567890");
        $(":button").click(function () {
            Sub(this.id);
        });
    })
    function Sub(id) {
        if (id == "btn_Sub") {
            var _id = $("#ID").val();
            var ccdate = $("#CC_Date").val();
            var ccap = $("#CC_AP").val();
            var ccunit = $("#CC_Unit").val();
            var ccp = $("#CC_P").val();
            var ccpost = $("#CC_Post").val();
            var ccpphone = $("#CC_PPhone").val();
            var ccconent = $("#CC_Content").val();
            var sqshop = $("#SQ_Shop").val();
            var sqbrand = $("#SQ_Brand").val();
            var sqname = $("#SQ_Name").val();
            var sqphone = $("#SQ_Phone").val();
            var sqfbp = $("#SQ_FBP").val();
            var sqfbpp = $("#SQ_FBPP").val();
            var sqcontent = $("#SQ_Content").val();
            var sp = $("#S_P").val();
            var sphone = $("#S_Phone").val();
            var sresult = $("#S_Result").val();
            var gd = $("#GD").val();
            var wtclbf = $("#WTCLBF").val();
            var fxwtbmqz = $("#FXWTBMQZ").val();
            var qcjrzxyj = $("#QCJRZXYJ").val();
            var qcjrzxqz = $("#QCJRZXQZ").val();
            var glzxyj = $("#GLZXYJ").val();
            var glzxqz = $("#GLZXQZ").val();
            $.ajax({
                type: 'post',
                url: '../ProjectTracking/RiskControl/save.ashx',
                data: 'type=risk&id=' + _id + '&ccdate=' + ccdate + '&ccap=' + ccap + '&ccunit=' + ccunit + '&ccp=' + ccp +
                    '&ccpost=' + ccpost + '&ccpphone=' + ccpphone + '&ccconent=' + ccconent + '&sqshop=' + sqshop +
                    '&sqbrand=' + sqbrand + '&sqname=' + sqname + '&sqphone=' + sqphone + '&sqfbp=' + sqfbp + '&sqfbpp=' + sqfbpp +
                    '&sqcontent=' + sqcontent + '&sp=' + sp + '&sphone=' + sphone + '&sresult=' + sresult + '&gd=' + gd + '&wtclbf=' + wtclbf +
                    '&fxwtbmqz=' + fxwtbmqz + '&qcjrzxyj=' + qcjrzxyj + '&qcjrzxqz=' + qcjrzxqz + '&glzxyj=' + glzxyj + '&glzxqz=' + glzxqz,
                dataType: 'text',
                success: function (msg) {
                    if (msg == "1") {
                        alert('保存成功！');
                    } else {
                        alert('保存失败！');
                    }
                }
            });
        }
    }
</script>

