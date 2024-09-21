<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GetPwd.aspx.cs" Inherits="GetPwd" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
	<title>Animated Login Form</title>
	<link rel="stylesheet" href="style.css">
	    <script>
      
            function goToLoginPage2() {
                window.location.href = '../Default.aspx'; // 修改为你的登录页面的路径
            }
        </script>

</head>
<body>
    <div class="box">
		<form id="form1" runat="server">
			<h2>找回密码
            </h2>
			<div class="inputBox">
				   <asp:TextBox ID="txtUsername" runat="server" required="required" ></asp:TextBox>
				<span>用户名</span>
				<i></i>			
			</div>
			<div class="inputBox">
				<asp:TextBox ID="txtEmail" runat="server" TextMode="Password" required="required"></asp:TextBox>
				<span>邮箱</span>
				<i></i>
				</div>
			<asp:Button ID="btnGPwd" runat="server" Text="找回密码 " OnClick="btnGPwd_Click" />
			<asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
			<a href="#" onclick="goToLoginPage2();"> 返回 </a>
		</form>
	</div>
</body>
</html>

