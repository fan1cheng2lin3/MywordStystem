<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Namespace.Login" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
	<title>Animated Login Form</title>
	<link rel="stylesheet" href="../CSS/style.css">
	    <script>
          
        function goToLoginPage() {
            window.location.href = 'Sign.aspx'; // 修改为你的登录页面的路径
			}
            function goToLoginPage3() {
                window.location.href = 'GetPwd.aspx'; // 修改为你的登录页面的路径
            }
        </script>
</head>
<body>
    <div class="box">
		<form id="form1" runat="server">
			<h2>登录</h2>
			<div class="inputBox">
				   <asp:TextBox ID="txtUsername" runat="server" required="required" autocomplete="off" name="randomUsername123"></asp:TextBox>
				<span>用户名</span>
				<i></i>			</div>
			<div class="inputBox">
				<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="required" autocomplete="off" name="randomUsername456"></asp:TextBox>
				<span>密码</span>
				<i></i>
			</div>
			<div class="links">

    <asp:LinkButton ID="Button2" runat="server" Text="忘记密码？"  CssClass="submit-button" OnClick="Button1_Click2" />
	<a href="#" onclick="goToLoginPage();"> 注册 </a>
			</div>

			<div class="links">
    <asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" CssClass="submit-button" />
    <asp:Button ID="Button1" runat="server" Text="返回"  CssClass="submit-button" OnClick="Button1_Click1" />
</div>
			<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
	
		</form>
	</div>
</body>
</html>
