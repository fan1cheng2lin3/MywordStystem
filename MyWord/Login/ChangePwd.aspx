<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="Longin_ChangePwd" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>修改密码</title>
    <link rel="stylesheet" href="../CSS/style.css">
    <script>
        function goToLoginPage2() {
            window.location.href = '../Default.aspx'; // 修改为你的登录页面的路径
        }
    </script>
</head>
<body>
    <div class="box">
        <form id="form1" runat="server">
            <h2>修改密码</h2>
            <div class="inputBox">
                <asp:TextBox ID="txtUsername" runat="server" required="required" autocomplete="off" name="randomUsername123"></asp:TextBox>
                <span>原密码</span>
                <i></i>            
            </div>
            <div class="inputBox">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" required="required" autocomplete="off" name="randomUsername456"></asp:TextBox>
                <span>密码</span>
                <i></i>
            </div>
            <div class="inputBox">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" required="required" autocomplete="off" name="randomUsername789"></asp:TextBox>
                <span>确认新密码</span>
                <i></i>            
            </div>
            <div class="links">
    <asp:Button ID="btnCPwd" runat="server" Text="修改" OnClick="btnCPwd_Click" CssClass="submit-button" />
    <asp:Button ID="Button1" runat="server" Text="返回" OnClientClick="goToLoginPage2();" CssClass="submit-button" OnClick="Button1_Click" />
</div>
                 <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </form>
    </div>
</body>
</html>
