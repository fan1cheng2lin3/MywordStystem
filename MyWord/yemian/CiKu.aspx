<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CiKu.aspx.cs" Inherits="ciku_CiKu" %>


<!DOCTYPE html>
<html lang="zh-CN">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>词库</title>
    <link rel="stylesheet" href="../CSS/CiKuStyle.css">
    <script src="https://unpkg.com/axios/dist/axios.min.js"></script> 
    <script src="../JS/CiKuScript.js"></script>
    <script src="../JS/CiDianScript.js"></script>
</head>

<body>
    <!-- 搜索框和按钮 -->
    <input type="text" id="searchInput" placeholder="输入单词进行搜索">
    <button id="searchButton">搜索</button>
    <button id="backButton" style="display:none;">返回词典</button>

    <!-- 词典部分 -->
<div id="cidian">
    <h1>词典</h1>
    <div id="cidianDiv">
        <h2>请点击图片显示单词</h2>
    </div>

    <!-- 使用图片替代按钮 -->
    <img src="associate_degree.png" alt="显示 Associate Degree 单词" onclick="fetchWords('View_AssociateDegree')" class="dictionary-image">
    <img src="bachelor.png" alt="显示 Bachelor 单词" onclick="fetchWords('View_Bachelor')" class="dictionary-image">

   

    <!-- 搜索结果部分 -->
    <div id="searchResults" style="display:none;"></div>

</body>
</html>

