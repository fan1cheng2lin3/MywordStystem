let cikuwords = [];

// 获取单词列表函数
function fetchWords(viewName) {
    axios.get(`/api/words/${viewName}`)
        .then(function (response) {
            cikuwords = response.data;
            console.log("Fetched words from " + viewName + ":", cikuwords);

            if (cikuwords.length > 0) {
                displayAllWords();  // 显示所有单词
                hideImageButtons();  // 隐藏图片按钮
                showBackButton();     // 显示返回按钮
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

// 隐藏图片按钮
function hideImageButtons() {
    const imageButtons = document.querySelectorAll('.dictionary-image');
    imageButtons.forEach(button => {
        button.style.display = 'none';
    });
}

// 显示返回按钮
function showBackButton() {
    const backButton = document.getElementById('backButton');
    backButton.style.display = 'inline-block';  // 显示返回按钮

    // 点击返回按钮时的行为
    backButton.onclick = () => {
        document.getElementById('cidianDiv').innerHTML = '<h2>请点击图片显示单词</h2>'; // 清空之前的内容
        hideBackButton();  // 隐藏返回按钮
        showImageButtons(); // 显示图片按钮
    };
}

// 隐藏返回按钮
function hideBackButton() {
    const backButton = document.getElementById('backButton');
    backButton.style.display = 'none';  // 隐藏返回按钮
}

// 显示图片按钮
function showImageButtons() {
    const imageButtons = document.querySelectorAll('.dictionary-image');
    imageButtons.forEach(button => {
        button.style.display = 'inline-block';
    });
}
