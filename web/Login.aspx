<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="Scripts/jquery.min.js"></script>
    <style>
        body {
            background: url(images/bg.jpg);
            background-repeat:no-repeat;
            background-position-x:center;
            background-position-y:center;
            background-size:100% 235%;
        }
        .center{ 
            margin:0 auto; 
            width:320px; 
            height:300px;
            line-height:60px; 
            text-align:center;
        }
        input {
            width: 100%;
            height: 40px;
            border: 1px solid #D2D7DE;
            border-radius: 4px;
            padding-left: 20px;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
            font-family: "Microsoft YaHei" !important;
        }
        .btn {
            background: #EC5466;
            color: #fff;
            border-radius: 4px;
            width: 100%;
            height: 40px;
            border: 1px solid #EC5466;
            -webkit-box-sizing: border-box;
            box-sizing: border-box;
            font-size: 16px;
        }
    </style>
    <script>
        $(function () {
            $("#imgCode").click(function () {
                $("#imgCode").prop("src", "Ashx/ValidateCode.ashx?d="+new Date().getMilliseconds());
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height:150px"></div>
        <div class="center">
            <div>
                <input type="text" placeholder="请输入你的用户名" id="txtUser" />
            </div>
            <div>
                <input type="password" id="txtPwd" placeholder="请输入你的密码"/>
            </div>
            <div id="dvCode">
                <input type="text" placeholder="请输入验证码" id="txtCode"  style="width:65%"/>
                <a href="#"><img src="Ashx/ValidateCode.ashx" id="imgCode" style="width:33%;vertical-align:middle"/></a>
            </div>
            <div>
                <input class="btn" type="button" value="确定" id="btnEnter"/>
            </div>
        </div>
    </form>    
</body>
</html>
