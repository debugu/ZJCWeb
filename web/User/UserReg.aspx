<%@ Page Title="" Language="C#" MasterPageFile="~/Master/main.Master" AutoEventWireup="true" CodeBehind="UserReg.aspx.cs" Inherits="web.User.UserReg" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            background: url(../images/bg.jpg);
            background-repeat: no-repeat;
            background-position-x: center;
            background-position-y: center;
            background-size: 100% 235%;
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
        .errorInfo {
            color:red;
            font-size:11px;
        }
    </style>
    <script src="../Scripts/jquery.min.js"></script>
    <script>
        $(function () {            
            $("#txtUser").focusout(function () {
                if ($("#txtUser").val().length != 0) {                    
                    if (!CheckUserName($("#txtUser").val())) {
                        $("#dvErrorInfo").text("该用户名已经被注册，请重新输入!");
                        return false;
                    }
                }
            });
            $("#btnEnter").click(function () {
                if ($("#txtUser").val().length == 0 || $("#tx  tPwd").val().length == 0 || $("#txtPwd2").val().length == 0) {
                    $("#dvErrorInfo").text("用户名密码必须填写!");
                    return false;
                }
                if ($("#txtPwd2").val() != $("#txtPwd").val()) {
                    $("#dvErrorInfo").text("两次密码不一样，请重新输入!");
                    return false;
                }
                if (CheckUserName($("#txtUser").val())) {
                    $("form").submit();
                } else {
                    $("#dvErrorInfo").text("该用户名已经被注册，请重新输入!");
                    return false;
                }
            })
        })
        function CheckUserName(username) {
            $.post("", {"username":username},function (data) {
                if (data) {
                    return true;
                } else {
                    return false;
                }
            })
}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="center">
            <div>
                <input type="text" placeholder="请输入你的用户名" id="txtUser" />
            </div>
            <div>
                <input type="password" id="txtPwd" placeholder="请输入你的密码"/>
            </div>
            <div>
                <input type="password" id="txtPwd2" placeholder="重复你的密码"/>
            </div>
            <div>
                <input class="btn" type="button" value="确定" id="btnEnter"/>
            </div>
            <div id="dvErrorInfo" class="errorInfo"></div>
        </div>
</asp:Content>
