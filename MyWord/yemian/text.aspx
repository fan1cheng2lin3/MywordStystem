<%@ Page Language="C#" AutoEventWireup="true" CodeFile="text.aspx.cs" Inherits="yemian_text" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>词库显示</title>
    <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
</head>
<body>
    <div>
        <h1>单词显示</h1>
        <div id="cidianDiv">
            <h2>请点击按钮显示单词</h2>
        </div>
        <button onclick="fetchWords('View_AssociateDegree')">显示 Associate Degree 单词</button>
        <button onclick="fetchWords('View_Bachelor')">显示 Bachelor 单词</button>
    </div>

    <script>
        let cikuwords = [];
        let currentIndex = 0;

        // 获取单词列表
        function fetchWords(viewName) {
            axios.get(`/api/words/${viewName}`)
                .then(function (response) {
                    cikuwords = response.data;
                    console.log("Fetched words from " + viewName + ":", cikuwords);

                    if (cikuwords.length > 0) {
                        currentIndex = 0;  // 重置索引
                        loadCurrentWord();
                    } else {
                        document.getElementById('cidianDiv').innerHTML = "<h2>无单词可显示</h2>";
                    }
                })
                .catch(function (error) {
                    console.error("Error fetching words from " + viewName + ":", error);
                });
        }

        // 加载当前单词
        function loadCurrentWord() {
            if (!cikuwords || cikuwords.length === 0) {
                console.error("No words available.");
                return;
            }
            if (currentIndex < cikuwords.length) {
                const currentWord = cikuwords[currentIndex]; // 获取当前单词
                document.getElementById('cidianDiv').innerHTML = `<h2>${currentWord.Wordpre}</h2>`;
            }
        }
    </script>
</body>
</html>
