<%@ Page Language="C#" AutoEventWireup="true" CodeFile="word2.aspx.cs" Inherits="Card_word2" %>

<!DOCTYPE html>
<html lang="zh-CN">


<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>学习卡牌</title>
    <link rel="stylesheet" href="../CSS/CardStyle.css">
    <script src="../JS/CardScript.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>

</head>

<body>
    <div class="container-wrapper">
        <!-- 左边派生卡片 -->
        <div class="container">
            <div class="card">
                <div id="derivative">
                    <h2>派生</h2>
                </div>
            </div>
        </div>

        <div class="container-wrapper">
            <div class="card">
                <div id="question"></div>
                <div id="answer" class="hidden"></div>
                <input type="text" id="spell-input" class="hidden" placeholder="输入拼写...">
                <div id="spell-message" class="hidden"></div>
            </div>
        </div>


        <!-- 右边搭配词卡片 -->
        <div class="container">
            <div class="card">
                <div id="match">
                    <h2>搭配词</h2>
                </div>
            </div>
        </div>
    </div>


 
           <button id="show-answer-btn">显示答案</button>
    <div id="review-buttons" class="hidden">
        <button class="easy">简单</button>
        <button class="retry">重来</button>
        <button class="good">良好</button>
    </div>

</body>
</html>
