<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/UserCtrol/UserControl.ascx" TagPrefix="uc1" TagName="UserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="avatar2 logged-in">
        <img src="https://cube.elemecdn.com/0/88/03b0d39583f48206768a7534e55bcpng.png" alt="User Avatar" onclick="handleAvatarClick()">
    </div>



    <div class="dropdown-content" id="dropdownMenu">
        <a href="#" onclick=" topage('ChangePwd')">个人资料</a>
        <a href="#" onclick=" topage('ChangePwd')">修改密码</a>
        <a href="#" onclick=" topage('GetPwd')">找回密码</a>
        <asp:LinkButton ID="LinkButtonLogout" runat="server" OnClick="LnkbtnLogout_Click">退出登录</asp:LinkButton>
    </div>

    <%--<uc1:UserControl runat="server" ID="UserControl" />--%>



    <script>

        var IsLoggedIn = <%= IsLoggedIn ? "true" : "false" %>;
        function handleAvatarClick() {

            if (/* 用户登录状态 */ IsLoggedIn) {
                toggleDropdown();
            } else {
                window.location.href = "Login/Login.aspx";
            }
        }
        function toggleDropdown() {
            var dropdownMenu = document.getElementById("dropdownMenu");
            dropdownMenu.classList.toggle("show");
        }

        function topage(page2) {
            window.location.href = 'Login/' + page2 + '.aspx';
        }

        function updateContent(content, isPage = false) {
            var contentDiv = document.getElementById("content");

            if (contentDiv) {
                if (isPage) {
                    // 如果是页面，则嵌入 iframe，展示对应页面
                    contentDiv.innerHTML = `<iframe src="${content}" style="width:100%; height:800px; border:none;"></iframe>`;
                } else {
                    // 否则直接显示文本
                    contentDiv.innerHTML = content;
                }
            }
        }

    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="menu">

        <a href="javascript:void(0);" onclick="updateContent('这是首页');">首页</a>
        <a href="javascript:void(0);" onclick="updateContent('这是资讯');">资讯</a>
        <a href="javascript:void(0);" onclick="updateContent('yemian/word.aspx', true);">卡牌</a>
        <a href="javascript:void(0);" onclick="updateContent('yemian/Ciku.aspx', true);">词库</a>
        <a href="javascript:void(0);" onclick="updateContent('这是关于');">关于</a>
        <hr color="red" />

    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div class="content" id="content">
        天上月华人如愿 | 1.2版本资讯说明

    </div>

    <%--    <button class="button" onclick="updateContent('欢迎回来！')">
        登录      
    </button>--%>

</asp:Content>
