<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="ContentPlaceHolderHeader" runat="server">
    <div class="header">
        B端
    </div>
</asp:Content>

<asp:Content ID="ContentSidebar" ContentPlaceHolderID="ContentPlaceHolderSidebar" runat="server">
    <div class="mainDiv1">
        <ul class="accordion">
            <li>
                <div class="link"><i class="fa fa-globe"></i>用户管理<i class="fa fa-chevron-down"></i></div>
                <ul class="submenu">
                    <li><a href="javascript:void(0);">用户维护</a></li>
                    <li><a href="javascript:void(0);">用户定位</a></li>
                </ul>
            </li>
            <li>
                <div class="link"><i class="fa fa-globe"></i>单词库<i class="fa fa-chevron-down"></i></div>
                <ul class="submenu">
                    <li><a href="javascript:void(0);">添加单词</a></li>
                    <li><a href="javascript:void(0);">用户定位</a></li>
                </ul>
            </li>
            <!-- Add more list items here -->
        </ul>
    </div>
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="ContentPlaceHolderMain" runat="server">
    <div class="main">
        内容
    </div>
</asp:Content>

<asp:Content ID="ContentFooter" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
    <div class="footer">
        底部
    </div>
</asp:Content>