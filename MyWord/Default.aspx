<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/UserCtrol/UserControl.ascx" TagPrefix="uc1" TagName="UserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="avatar" onclick="goToLoginPage()">
        <img src="https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png" alt="User Avatar" />
    </div>


    <div class="avatar2" onclick="goToLoginPage2()">
    <img src="1" alt="User Avatar" />
</div>

        <div class="avatar3" onclick="goToLoginPage3()">
    <img src="2" alt="User Avatar" />
</div>
    <script>
        function goToLoginPage() {
            window.location.href = 'Longin/Login.aspx'; // 修改为你的登录页面的路径
        }
        function goToLoginPage2() {
            window.location.href = 'Longin/ChangePwd.aspx'; // 修改为你的登录页面的路径
        }
        function goToLoginPage3() {
            window.location.href = 'Longin/GetPwd.aspx'; // 修改为你的登录页面的路径
        }
    </script>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="menu">
        <a href="javascript:void(0);" onclick="updateContent('这是首页');">首页</a>
        <a href="javascript:void(0);" onclick="updateContent('这是资讯');">资讯</a>
        <a href="javascript:void(0);" onclick="updateContent('这是卡牌');">卡牌</a>
        <a href="javascript:void(0);" onclick="updateContent('这是词库');">词库</a>
        <a href="javascript:void(0);" onclick="updateContent('这是关于');">关于</a>
        <hr color="red" />
    </div>
    <div>
        <uc1:UserControl runat="server" ID="UserControl" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="content" id="content">
        天上月华人如愿 | 1.2版本资讯说明
    </div>
    <button class="button" onclick="updateContent('欢迎回来！')">
        登录
    </button>
</asp:Content>