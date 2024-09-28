<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControl.ascx.cs" Inherits="UserCtrcl_UserControl" %>



<asp:Label ID="lblWelcome" runat="server" Text="您还未登录！"></asp:Label>
<asp:LinkButton ID="lnkbtnPwd" runat="server" ForeColor="black" Visible="False" PostBackUrl="../Login/ChangePwd.aspx">密码修改</asp:LinkButton>
<asp:LinkButton ID="lnkbtnManage" runat="server" ForeColor="black" Visible="False" PostBackUrl="../Login/GetPwd.aspx">找回密码</asp:LinkButton>
<asp:LinkButton ID="lnkbtnLogout" runat="server" ForeColor="black" Visible="False" OnClick="LnkbtnLogout_Click">退出登录</asp:LinkButton>
