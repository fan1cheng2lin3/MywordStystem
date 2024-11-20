<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>词库显示</title>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
    <link rel="stylesheet" href="../CSS/xuanzeye.css">
</head>
<body>

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

    <%--<input type="hidden" id="userId" runat="server" value="6" />--%>

    <button class="btn text">xhu</button>
    <button class="xuexi">学习页</button>
    <button class="fuxi">复习页</button>

    <script src="../JS/xuanzeye.js"></script>
</body>
</html>
