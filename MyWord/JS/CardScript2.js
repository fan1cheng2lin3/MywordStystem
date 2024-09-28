document.addEventListener("DOMContentLoaded", () => {
    const showAnswerBtn = document.getElementById('show-answer-btn');
    const questionDiv = document.getElementById('question');
    const answerDiv = document.getElementById('answer');
    const reviewButtons = document.getElementById('review-buttons');
    const spellInput = document.getElementById('spell-input');
    const spellMessage = document.getElementById('spell-message');
    const easyBtn = document.querySelector('.easy');
    const retryBtn = document.querySelector('.retry');
    const goodBtn = document.querySelector('.good');

    let words = [];  // 用于存储单词列表
    let currentIndex = 0;  // 当前单词的索引

    // 使用 AJAX 获取单词列表
    axios.get('/api/words')  // 对应后端 API 的路径
        .then(function (response) {
            words = response.data;
            console.log("Fetched words:", words);

            if (words.length > 0) {
                // 加载第一个单词
                loadCurrentWord();
            }
        })
        .catch(function (error) {
            console.error("Error fetching words:", error);
        });

    // 加载当前单词
    function loadCurrentWord() {
        if (currentIndex < words.length) {
            const currentWord = words[currentIndex];
            questionDiv.innerHTML = `<h2>${currentWord.Translation}</h2>`;
            answerDiv.innerHTML = `
                <h2>${currentWord.Word}</h2>
                <p>Sound Mark: ${currentWord.SoundMark}</p>
                <p>Translation: ${currentWord.Translation}</p>
                <p>Example: ${currentWord.Example}</p>
                <p>Example Translation: ${currentWord.ExampleTranslation}</p>
            `;
            resetCard();  // 重置卡片状态
        } else {
            alert("所有单词已完成！");  // 提示完成
        }
    }

    // 显示答案按钮事件
    showAnswerBtn.addEventListener('click', () => {
        questionDiv.classList.add('hidden');
        answerDiv.classList.remove('hidden');
        reviewButtons.classList.remove('hidden');
        toggleButtons('hide');
    });

    // 简单按钮事件
    easyBtn.addEventListener('click', nextWord);
    // 重来按钮事件
    retryBtn.addEventListener('click', nextWord);
    // 良好按钮事件
    goodBtn.addEventListener('click', nextWord);

    // 键盘事件监听，替代提交按钮
    document.addEventListener('keydown', (event) => {
        if (questionDiv.classList.contains('hidden')) {  // 当问题被隐藏时
            if (event.key === 'ArrowRight') {  // 右箭头键（简单）
                easyBtn.click();
            }
            if (event.key === 'ArrowDown') {  // 下箭头键（良好）
                goodBtn.click();
            }
            if (event.key === 'ArrowLeft') {  // 左箭头键（重来）
                retryBtn.click();
            }
        } else {
            if (event.key === ' ') {
                showAnswerBtn.click(); // 触发显示答案按钮
            }
        }
    });

    // 切换按钮显示和隐藏
    function toggleButtons(action) {
        if (action === 'hide') {
            showAnswerBtn.classList.add('hidden');
        } else if (action === 'showOnlyAnswer') {
            showAnswerBtn.classList.remove('hidden');
            reviewButtons.classList.add('hidden');  // 隐藏其他按钮
        } else {
            showAnswerBtn.classList.remove('hidden');
            reviewButtons.classList.remove('hidden');  // 显示所有按钮
        }
    }

    // 重置卡片为初始状态
    function resetCard() {
        questionDiv.classList.remove('hidden');
        answerDiv.classList.add('hidden');
        reviewButtons.classList.add('hidden');
    }

    // 跳到下一个单词
    function nextWord() {
        currentIndex++;
        loadCurrentWord();  // 加载下一个单词
    }
});
