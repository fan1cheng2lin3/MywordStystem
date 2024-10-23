let cikuwords = [];
let currentIndex = 0;
let words = [];


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


// 页面加载完成后执行
document.addEventListener("DOMContentLoaded", () => {
    const cidianDiv = document.getElementById('cidian');
    const searchInput = document.getElementById('searchInput');
    const searchButton = document.getElementById('searchButton');
    const backButton = document.getElementById('backButton');
    const searchResultsDiv = document.getElementById('searchResults');

    // 使用 AJAX 获取所有单词列表
    axios.get('/api/newwords')
        .then(function (response) {
            words = response.data;
            console.log("Fetched words:", words);
        })
        .catch(function (error) {
            console.error("Error fetching words:", error);
        });



    // 搜索按钮事件
    searchButton.addEventListener('click', () => {
        const searchQuery = searchInput.value.trim().toLowerCase();
        if (searchQuery === '') {
            alert('请输入搜索内容');
            return;
        }

        // 进行搜索，完全匹配和部分匹配
        const exactMatches = words.filter(word => word.Wordpre.toLowerCase() === searchQuery);
        const partialMatches = words.filter(word => word.Wordpre.toLowerCase().includes(searchQuery) && word.Wordpre.toLowerCase() !== searchQuery);

        const searchResults = exactMatches.concat(partialMatches);

        if (searchResults.length > 0) {
            displaySearchResults(searchResults);
        } else {
            searchResultsDiv.innerHTML = "<p>未找到匹配的单词</p>";
        }
    });

    // 返回按钮事件
    backButton.addEventListener('click', () => {
        // 隐藏搜索结果，显示词典部分
        searchResultsDiv.style.display = 'none';
        backButton.style.display = 'none';
        cidianDiv.style.display = 'block';
        searchResultsDiv.innerHTML = '';  // 清空搜索结果
        searchInput.value = '';  // 清空搜索框
    });

    // 显示搜索结果
    function displaySearchResults(results) {
        // 隐藏词典部分，显示搜索结果
        cidianDiv.style.display = 'none';
        searchResultsDiv.style.display = 'block';
        backButton.style.display = 'inline';  // 显示返回按钮

        searchResultsDiv.innerHTML = '';  // 清空之前的结果

        results.forEach(word => {
            const wordDiv = document.createElement('div');
            wordDiv.innerHTML = `
                <h2>${word.Wordpre}</h2>
                <p>${word.Explanation2 || "无"}</p>
            `;
            searchResultsDiv.appendChild(wordDiv);
        });
    }
});


