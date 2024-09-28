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
    let correctWord = "";  // 当前单词的正确拼写

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
            correctWord = currentWord.Word.trim();  // 去除前后空格
            resetCard();  // 重置卡片状态
        } else {
            alert("所有单词已完成！");  // 提示完成
        }
    }


    // 键盘事件监听
    document.addEventListener('keydown', (event) => {
        console.log('Key pressed:', event.key); // 输出按下的键
        console.log('questionDiv hidden:', questionDiv.classList.contains('hidden')); // 检查状态

        if (questionDiv.classList.contains('hidden')) {
            if (event.key === 'ArrowRight') {
                easyBtn.click();
            } else if (event.key === 'ArrowDown') {
                goodBtn.click();
            } else if (event.key === 'ArrowLeft') {
                retryBtn.click();
            }
        } else {
            if (event.key === ' ') {
                showAnswerBtn.click(); // 触发显示答案按钮
            }
        }
    });

    // 显示答案按钮事件
    showAnswerBtn.addEventListener('click', () => {
        questionDiv.classList.add('hidden');
        answerDiv.classList.remove('hidden');
        reviewButtons.classList.remove('hidden');
        toggleButtons('hide');
    });

    // 简单按钮事件
    easyBtn.addEventListener('click', () => {
        showSpellInput();
        hideReviewButtons();  // 隐藏所有评价按钮
    });

    // 重来按钮事件
    retryBtn.addEventListener('click', () => {
        showSpellInput();
        hideReviewButtons();  // 隐藏所有评价按钮
    });

    // 良好按钮事件
    goodBtn.addEventListener('click', () => {
        showSpellInput();
        hideReviewButtons();  // 隐藏所有评价按钮
    });

    // 显示拼写框
    function showSpellInput() {
        spellInput.classList.remove('hidden'); // 确保输入框可见
        spellInput.focus();  // 自动聚焦到输入框
        spellMessage.classList.add('hidden');  // 隐藏提示信息
        spellInput.value = '';  // 清空之前的输入
    }

    // 隐藏所有评价按钮
    function hideReviewButtons() {
        reviewButtons.classList.add('hidden');
    }

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
        spellInput.classList.add('hidden');  // 隐藏拼写输入框
        spellMessage.classList.add('hidden');  // 隐藏拼写提示信息
    }

    // 键盘事件监听，用于拼写检查
    spellInput.addEventListener('keydown', (event) => {
        if (event.key === 'Enter') {
            const userInput = spellInput.value.trim().toLowerCase(); // 确保输入被处理
            console.log('User input:', userInput); // 输出用户输入
            console.log('Correct word:', correctWord.toLowerCase()); // 输出正确单词

            if (userInput === correctWord.toLowerCase()) { // 比较时统一转为小写
                spellMessage.textContent = "拼写正确！";
                spellMessage.style.color = "green";
                spellMessage.classList.remove('hidden');
                currentIndex++;
                loadCurrentWord();  // 显示下一个单词
            } else {
                spellMessage.textContent = "拼写错误，正确答案：" + correctWord;
                spellMessage.style.color = "red";
                spellMessage.classList.remove('hidden');
            }
            event.preventDefault();  // 阻止默认行为，如表单提交
        }
    });


});
