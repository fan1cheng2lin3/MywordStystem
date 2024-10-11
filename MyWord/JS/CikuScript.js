document.addEventListener("DOMContentLoaded", () => {
    const searchInput = document.getElementById('searchInput');
    const searchButton = document.getElementById('searchButton');
    let words = [];

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

        // 分别存储完全匹配和部分匹配的单词
        const exactMatches = words.filter(word =>
            word.Wordpre.toLowerCase() === searchQuery
        );
        const partialMatches = words.filter(word =>
            word.Wordpre.toLowerCase().includes(searchQuery) &&
            word.Wordpre.toLowerCase() !== searchQuery
        );

        // 合并完全匹配和部分匹配的数组
        const searchResults = exactMatches.concat(partialMatches);

        displaySearchResults(searchResults);
    });

    // 显示搜索结果
    function displaySearchResults(results) {
        let searchResultsDiv = document.getElementById('searchResults');
        if (!searchResultsDiv) {
            searchResultsDiv = document.createElement('div');
            searchResultsDiv.id = 'searchResults';
            document.body.appendChild(searchResultsDiv);
        }

        searchResultsDiv.innerHTML = ''; // 清空之前的结果

        results.forEach(word => {
            const wordDiv = document.createElement('div');
            wordDiv.innerHTML = `
                <h2>${word.Wordpre}</h2>
                <p>翻译: ${word.Explanation2}</p>
            `;
            searchResultsDiv.appendChild(wordDiv);
        });
    }
});