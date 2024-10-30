document.addEventListener("DOMContentLoaded", () => {
    const cidianDiv = document.getElementById('cidian');
    

    let words = [];
    let currentIndex = 0;

    // 使用 AJAX 获取单词列表
    axios.get('/api/ciku')
        .then(function (response) {
            words = response.data;
            console.log("Fetched words:", words);

            if (words.length > 0) {
                loadCurrentWord();
            }
        })
        .catch(function (error) {
            console.error("Error fetching words:", error);
        });

    // 加载当前单词
    function loadCurrentWord() {
        if (!words || words.length === 0) {
            console.error("No words available.");
            return;
        }
        if (currentIndex < words.length) {
            const currentWord = words[currentIndex]; // 获取当前单词
            cidianDiv.innerHTML = `<h2>${currentWord.Wordpre}</h2>
             <p>${currentWord.Explanation2 || "无"}</p>`;
        }
    }
}); // 闭合事件监听器函数