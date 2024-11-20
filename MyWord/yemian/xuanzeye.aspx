<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xuanzeye.aspx.cs" Inherits="yemian_Desfault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
      <script src="https://unpkg.com/axios/dist/axios.min.js"></script> 
     <script src="../JS/xuanzeye.js"></script>
<link rel="stylesheet" href="../CSS/xuanzeye.css">
    <title>词库显示</title>
</head>
<body>
    <form id="form1" runat="server">
         <asp:HiddenField ID="userId" runat="server" />

         <div class="cal-container">
     <div class="year-month">
         <span id="month"></span>
         <span id="year"></span>
     </div>
     <div class="weeks">
         <ul>
             <li>Mon</li>
             <li>Tue</li>
             <li>Wed</li>
             <li>Thu</li>
             <li>Fri</li>
             <li>Sat</li>
             <li>Sun</li>
         </ul>
     </div>
     <div class="days">
         <ul id="day"></ul>
     </div>
 </div>

    </form>

    
         <button class="btn text">选择词书</button>
 <button class="xuexi">学习页 </button>
 <button class="fuxi">复习页</button>
 <div id="buttonContainer"></div>
</body>
</html>
