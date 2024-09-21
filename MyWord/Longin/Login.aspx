<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Namespace.Login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
	<title>Animated Login Form</title>
	<link rel="stylesheet" href="style.css">
	    <script>
        function goToLoginPage() {
            window.location.href = 'Sign.aspx'; // 修改为你的登录页面的路径
			}
            function goToLoginPage2() {
                window.location.href = '../Default.aspx'; // 修改为你的登录页面的路径
            }
        </script>
</head>
<body>
    <div class="box">
		<form id="form1" runat="server">
			<h2>登录</h2>


			<div class="inputBox">
				   <asp:TextBox ID="txtUsername" runat="server" required="required"></asp:TextBox>
				<span>用户名</span>
				<i></i>			</div>
			<div class="inputBox">
				<asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="required"></asp:TextBox>
				<span>密码</span>
				<i></i>
			</div>
			<div class="links">
				<a href="#">忘记密码 ?</a>
				<a href="#" onclick="goToLoginPage();"> 注册 </a>
			</div>
			<asp:Button ID="btnLogin" runat="server" Text="登录" OnClick="btnLogin_Click" />
			<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
			<a href="#" onclick="goToLoginPage2();"> 返回 </a>
		</form>
	</div>
</body>
</html>
