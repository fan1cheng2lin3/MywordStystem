<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sign.aspx.cs" Inherits="Longin_Sign" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <title>注册</title>
    <link rel="stylesheet" href="../CSS/style.css">


    <style>

        .validator-style {
    position: relative; /* 相对于其正常位置进行定位 */
    top: 15px; /* 向下移动10px */
}
    </style>
</head>


<body>

    <div class="box">
          <form id="form1" runat="server">
            <h2>注册</h2>
            <div class="inputBox">
                <asp:TextBox ID="TextBox2" runat="server" required="required"></asp:TextBox>
                <span>用户名</span>
                <i></i>		
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
            <div class="inputBox">
                <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" required="required"></asp:TextBox>
                <span>密码</span>
                <i></i>		
            </div>
            <div class="inputBox">
                <asp:TextBox ID="ConfirmTextBox" runat="server" TextMode="Password" required="required"></asp:TextBox>
                <span>确认密码</span>
                <i></i>		
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ConfirmTextBox" ErrorMessage="确认密码是必填项" ForeColor="Red" CssClass="validator-style"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox1" ControlToValidate="ConfirmTextBox" ErrorMessage="密码不匹配" ForeColor="Red" CssClass="validator-style"></asp:CompareValidator>
            </div>
            <div class="inputBox">
                <asp:TextBox ID="EmailTextBox" runat="server" required="required"></asp:TextBox>
                <span>邮箱</span>
                <i></i>		
<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox" ValidationExpression="^[^@]+@[^@]+\.[a-zA-Z]{2,6}$" ErrorMessage="无效的邮箱格式" ForeColor="Red" CssClass="validator-style"></asp:RegularExpressionValidator>            </div>
            <asp:Button ID="RegisterButton" runat="server" Text="注册" OnClick="RegisterButton_Click" UseSubmitBehavior="True" />
        </form>
      </div>
</body>
</html>