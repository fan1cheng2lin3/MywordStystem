document.addEventListener("DOMContentLoaded", () => {
    const showAnswerBtn = document.getElementById('show-answer-btn');
    const questionDiv = document.getElementById('question');
    const answerDiv = document.getElementById('answer');
    const derivativeDiv = document.getElementById('derivative');
    const matchDiv = document.getElementById('match');
    const reviewButtons = document.getElementById('review-buttons');
    const spellInput = document.getElementById('spell-input');
    const spellMessage = document.getElementById('spell-message');
    const easyBtn = document.querySelector('.easy');
    const retryBtn = document.querySelector('.retry');
    const goodBtn = document.querySelector('.good');

    let words = [];
    let currentIndex = 0;
    let correctWord = "";

    // 使用 AJAX 获取单词列表
    axios.get(`/api/words/View_CET4`)
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

    function fetchWords(viewName) {
        axios.get(`/api/words/View_CET4`)
            .then(function (response) {
                words = response.data;
                console.log("Fetched words from " +  + ":", cikuwords);
            })
            .catch(function (error) {
                console.error("Error fetching words from " + viewName + ":", error);
            });
    }

    // 加载当前单词
    function loadCurrentWord() {
        if (!words || words.length === 0) {
            console.error("No words available.");
            return;
        }

        if (currentIndex < words.length) {
            const currentWord = words[currentIndex];
            console.log("Current word:", currentWord); // 检查这里是否为undefined
            questionDiv.innerHTML = `<h2>${currentWord.Explanation2}</h2>`;


            derivativeDiv.innerHTML = `
            <dt style=font-size:40px >词根助记</dt>
            <dl>
                <dd>${formatEtyma(currentWord.Etyma || '空')}</dd>
            </dl>
        `;


            matchDiv.innerHTML = `
            <dt style=font-size:40px >助记</dt>
            <dl>
                <dd>${formatEtyma(currentWord.Ancillary || '空')}</dd>
            </dl>
        `;


            answerDiv.innerHTML = `
            <h1>${currentWord.Wordpre || 'No Word'}</h2>
            <h1>${currentWord.Id || 'No Word'}</h2>
            <p>美式: ${currentWord.Phonetic || 'No Sound Mark'}</p>
            <p>英式: ${currentWord.PhoneticUK || 'No Sound Mark'}</p>
            <p>翻译: ${currentWord.Explanation2 || 'No Translation'}</p>
            <p>例子: ${currentWord.SentenceEN || 'No Example'}</p>
            <p>例子翻译: ${currentWord.SentenceCN || 'No Example Translation'}</p>
        `;
        
            correctWord = (currentWord.Wordpre || '').trim(); // 使用 || 操作符提供默认值

            
            resetCard(); // 重置卡片状态
        } else {
            alert("所有单词已完成！");
        }
    }

    function formatEtyma(etyma) {
        // 用 <br> 替换 ; 来换行
        let formatted = etyma.replace(/;|；/g, ';<br>')
            .replace(/【记】/g, ' ')
            .replace(/※ /g, '<br>※ ');
        // 用 <h2> 替换 # 来创建一级标题
        formatted = formatted.replace(/#/g, '</h2><h2>');

        // 用 <h3> 替换 ## 来创建二级标题
        formatted = formatted.replace(/##/g, '</h2><h3>');

        // 添加初始的 <h2> 标签，因为没有标题的文本也应该被包裹
        formatted = `<h2>${formatted}`;

        // 如果最后一个字符是 </h2> 或 </h3>，添加一个 </h3> 以闭合最后的标题
        if (formatted.endsWith('</h2>')) {
            formatted += '</h3>';
        } else if (formatted.endsWith('</h3>')) {
            formatted += '</h3>';
        }

        return formatted;
    }

   

    // 键盘事件监听
    document.addEventListener('keydown', (event) => {
        console.log('Key pressed:', event.key);
        console.log('questionDiv hidden:', questionDiv.classList.contains('hidden'));

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

   

    easyBtn.addEventListener('click', () => {
        updateScore(3); // 简单评分为3
        showSpellInput();
        hideReviewButtons();
    });

    retryBtn.addEventListener('click', () => {
        updateScore(1); // 重来评分为1
        showSpellInput();
        hideReviewButtons();
    });

    goodBtn.addEventListener('click', () => {
        updateScore(2); // 良好评分为2
        showSpellInput();
        hideReviewButtons();
    });
    function updateScore(score) {
        const userId = document.getElementById('user-id').value; // 确保获取了userId
        const wordId = words[currentIndex].Id;

        const requestData = {
            userId: userId,
            wordId: wordId,
            score: score
        };

        console.log('Sending score update request:', requestData);

        axios.post('/api/propress/score/updatescore', requestData)
            .then(response => {
                console.log("Score updated:", response.data);
            })
            .catch(error => {
                console.error("Error updating score:", error.response ? error.response.data : error.message);
            });
    }




    // 显示拼写框
    function showSpellInput() {
        questionDiv.innerHTML = `<h2>${words[currentIndex].Phonetic}</h2>`;
        answerDiv.innerHTML = `<p>${words[currentIndex].Phonetic}</p>`;
        spellInput.classList.remove('hidden');
        spellInput.focus();
        spellInput.value = '';  // 清空之前的输入
        spellMessage.classList.add('hidden');  // 隐藏提示信息
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
            reviewButtons.classList.add('hidden');
        } else {
            showAnswerBtn.classList.remove('hidden');
            reviewButtons.classList.remove('hidden');
        }
    }


    // 重置卡片为初始状态
    function resetCard() {
        questionDiv.classList.remove('hidden');
        derivativeDiv.classList.remove('hidden');
        answerDiv.classList.add('hidden');
        reviewButtons.classList.add('hidden');
        spellInput.classList.add('hidden');  // 隐藏拼写输入框
        spellMessage.classList.add('hidden');  // 隐藏拼写提示信息
    }

    // 键盘事件监听，用于拼写检查
    spellInput.addEventListener('keydown', (event) => {
        if (event.key === 'Enter') {
            const userInput = spellInput.value.trim().toLowerCase();
            if (userInput === correctWord.toLowerCase()) {
                spellMessage.textContent = "拼写正确！";
                spellMessage.style.color = "green";
                spellMessage.classList.remove('hidden');
                showAnswerBtn.classList.remove('hidden');
                currentIndex++;
                loadCurrentWord();  // 显示下一个单词
            } else {
                // 不再提示，直接显示错误的单词
                questionDiv.innerHTML = `<h2>${words[currentIndex].Explanation2}</h2>`;
                answerDiv.innerHTML = `<p>${correctWord}</p>`;
                spellMessage.classList.add('hidden');  // 隐藏拼写提示信息
            }
            event.preventDefault();  // 阻止默认行为，如表单提交
        }
    });
    
});