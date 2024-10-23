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
    <script src="../JS/回收站/CiDianScript.js"></script>
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

    </div>

    <!-- 使用图片替代按钮 -->
    <img src="associate_degree.png" alt="Associate Degree" onclick="fetchWords('View_AssociateDegree')" class="dictionary-image">
    <img src="bachelor.png" alt="Bachelor" onclick="fetchWords('View_Bachelor')" class="dictionary-image">
    <img src="bachelor2.png" alt="Base" onclick="fetchWords('View_Base')" class="dictionary-image">
    <img src="bachelor.png" alt="Business" onclick="fetchWords('View_Business')" class="dictionary-image">
    <img src="bachelor.png" alt="CET4" onclick="fetchWords('View_CET4')" class="dictionary-image">
    <img src="bachelor.png" alt="CET6" onclick="fetchWords('View_CET6')" class="dictionary-image">
    <img src="bachelor.png" alt="Computer" onclick="fetchWords('View_Computer')" class="dictionary-image">
    <img src="bachelor.png" alt="Dating" onclick="fetchWords('View_Dating')" class="dictionary-image">
    <img src="bachelor.png" alt="Doctor" onclick="fetchWords('View_Doctor')" class="dictionary-image">
    <img src="bachelor.png" alt="GMAT" onclick="fetchWords('View_GMAT')" class="dictionary-image">
    <img src="bachelor.png" alt="Graduate" onclick="fetchWords('View_Graduate')" class="dictionary-image">
    <img src="bachelor.png" alt="GRE" onclick="fetchWords('View_GRE')" class="dictionary-image">
    <img src="bachelor.png" alt="High School" onclick="fetchWords('View_HighSchool')" class="dictionary-image">
    <img src="bachelor.png" alt="IELTS" onclick="fetchWords('View_IELTS')" class="dictionary-image">
    <img src="bachelor.png" alt="Job Hunting" onclick="fetchWords('View_JobHunting')" class="dictionary-image">
    <img src="bachelor.png" alt="MBA" onclick="fetchWords('View_MBA')" class="dictionary-image">
    <img src="bachelor.png" alt="Medical" onclick="fetchWords('View_Medical')" class="dictionary-image">
    <img src="bachelor.png" alt="Middle School" onclick="fetchWords('View_MiddleSchool')" class="dictionary-image">
    <img src="bachelor.png" alt="Phone" onclick="fetchWords('View_Phone')" class="dictionary-image">
    <img src="bachelor.png" alt="Primary School" onclick="fetchWords('View_PrimarySchool')" class="dictionary-image">
    <img src="bachelor.png" alt="Public Service" onclick="fetchWords('View_PublicService')" class="dictionary-image">
    <img src="bachelor.png" alt="SAT" onclick="fetchWords('View_SAT')" class="dictionary-image">
    <img src="bachelor.png" alt="Super" onclick="fetchWords('View_Super')" class="dictionary-image">
    <img src="bachelor.png" alt="TOEFL" onclick="fetchWords('View_TOEFL')" class="dictionary-image">
    <img src="bachelor.png" alt="Trade" onclick="fetchWords('View_Trade')" class="dictionary-image">
    <img src="bachelor.png" alt="Workplace" onclick="fetchWords('View_Workplace')" class="dictionary-image">

    </div>




   
    <!-- 搜索结果部分 -->
    <div id="searchResults" style="display:none;"></div>

</body>
</html>

