let cikuwords = [];

// 获取单词列表函数
function fetchWords(viewName) {
    axios.get(`/api/words/${viewName}`)
        .then(function (response) {
            cikuwords = response.data;
            console.log("Fetched words from " + viewName + ":", cikuwords);

            if (cikuwords.length > 0) {
                displayAllWords();  // 显示所有单词
            } else {
                document.getElementById('cidianDiv').innerHTML = "<h2>无单词可显示</h2>";
            }
        })
        .catch(function (error) {
            console.error("Error fetching words from " + viewName + ":", error);
        });
}

// 显示所有单词
function displayAllWords() {
    const cidianDiv = document.getElementById('cidianDiv');
    cidianDiv.innerHTML = '';  // 清空之前的内容

    cikuwords.forEach(word => {
        const wordDiv = document.createElement('div');
        wordDiv.innerHTML = `<h2>${word.Wordpre}</h2>`;
        cidianDiv.appendChild(wordDiv);  // 添加到页面中
    });
}
