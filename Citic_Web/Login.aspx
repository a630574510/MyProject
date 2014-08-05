<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Citic_Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="description" content="中信信通质押物管理平台。 登录到您的帐户。" />
    <link rel="stylesheet" type="text/css" href="Css/login.css" media="handheld,print,projection,screen,tty,tv" />
    <title>登陆</title>
    <link rel="Shortcut Icon" href="Citic_Logo.ico" />
    <link rel="Bookmark" href="Citic_Logo.ico" />
    <style type="text/css">
        .black {
            font-size: 20px;
        }

        #rbl_Dept tr td label {
            color: #000;
        }
    </style>
</head>
<body>
    <form id="Login_Form" runat="server">
        <div id="pagewrap">
            <div class="page" id="divPage" style="height: 100%; width: auto;">
                <div class="content" style="background-image:url('Images/CITIC.jpg');background-repeat:no-repeat">
                    <div class="login">
                        <div class="fi">
                            <label class="lbH3">中信信通质押物管理平台</label>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div class="fi">
                            <label class="lb">
                                用户名</label>
                            <asp:TextBox runat="server" ID="txtUsername" CssClass="ipt-t" onfocus="this.className+=&#39; ipt-t-focus&#39;"
                                onblur="this.className=&#39;ipt-t&#39;" TabIndex="1"></asp:TextBox>
                        </div>
                        <div class="fi">
                            <label class="lb">
                                密 码</label>
                            <asp:TextBox runat="server" ID="txtPass" TextMode="Password" class="ipt-t no-ime"
                                onfocus="this.className+=&#39; ipt-t-focus&#39;" onblur="this.className=&#39;ipt-t no-ime&#39;"
                                name="password" TabIndex="2" MaxLength="20"></asp:TextBox>
                        </div>
                        <div class="fi">
                            <label class="lb">
                                部 门</label>
                            <asp:RadioButtonList ID="rbl_Dept" runat="server" CssClass="black" ForeColor="Black"></asp:RadioButtonList>
                        </div>
                        <div class="fi fi-btn">
                            <asp:Button runat="server" ID="btnSubmit" Text=" 登 陆 " CssClass="btn"
                                TabIndex="6" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                    <!--<div class="intro intro-wing5" id="divIntro" style="border:1px solid red">-->
                        <div id="div1" style="width:489px;height:50px;float:left;position:relative;z-index:1;padding-top:400px">
                        <!--主题切换-->
                        <ul style="list-style-type:none">
                            <li>中信信通国际物流有限公司</li>
                            <li>CITIC Xintong International Logistics Co., Ltd</li>
                        </ul>
                        <!-- <div class="introtxt introtxt-wing5" style="height:10px;border: 1px solid blue">
                           
                        </div>
                        -->
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>