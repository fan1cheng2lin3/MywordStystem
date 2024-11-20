<%@ Page Language="C#" AutoEventWireup="true" CodeFile="words.aspx.cs" Inherits="yemian_words" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>首次学习卡牌</title>
 <link rel="stylesheet" href="../CSS/CardStyle.css">
 <script src="../JS/CardScript.js"></script>
      <script src="https://unpkg.com/axios/dist/axios.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/say.js/2.0.1/say.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
          <asp:HiddenField ID="userId" runat="server" />
 


    </form>
    <button onclick="speakPhonetic('æbsns')">发音</button>

    <div class="container-wrapper">


    <!-- 左边派生卡片 -->
    <div class="container">
        <div class="card">
            <div id="derivative">

            </div>
        </div>
    </div>

    <!-- 中间记忆卡片 -->
    <div class="container">
        <div class="card">
            <!-- 英语部分 -->
            <div id="question"></div>
            <!-- 中文部分 -->
            <div id="answer" class="hidden"></div>
           
            <!-- 拼写部分，默认隐藏 -->
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

     <!-- 按钮部分 -->
 <div id="buttons" class="button-container">
     <button id="show-answer-btn" class="btn">显示答案</button>
     <div class="review-buttons hidden" id="review-buttons">
         <button class="btn retry">重来</button>
         <button class="btn good">良好</button>
         <button class="btn easy">简单</button>
     </div>
 </div>
</body>
</html>
