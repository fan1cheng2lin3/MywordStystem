document.addEventListener("DOMContentLoaded", async () => {
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

    const userId = document.getElementById('userId').value;  // 获取 HiddenField 中的 userId

    try {

        const wordsResponse = await axios.get(`/api/words/rewords`,  { params: { userId: userId } });
        words = wordsResponse.data;
        console.log("Fetched words data:", words);

        if (words.length > 0) {
            loadCurrentWord();
        } else {
            console.error("No words available in response.");
        }

    } catch (error) {
        console.error("Error fetching words or wordbook:", error);
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
            <dt style="font-size:40px">词根助记</dt>
            <dl>
                <dd>${formatEtyma(currentWord.Etyma || '空')}</dd>
            </dl>
            `;

            matchDiv.innerHTML = `
            <dt style="font-size:40px">助记</dt>
            <dl>
                <dd>${formatEtyma(currentWord.Ancillary || '空')}</dd>
            </dl>
            `;
            //         <button onclick="speak('${currentWord.Phonetic}')">美式发音</button>
            //<button onclick="speak('${currentWord.PhoneticUK}')">英式发音</button>
            answerDiv.innerHTML = `
            <h1>${currentWord.Wordpre || 'No Word'}</h1>
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
        const userId = document.getElementById('userId').value; // 确保获取了userId
        const wordId = words[currentIndex].Id;
        const lasttime = new Date().toISOString(); // 获取当前时间并转换为ISO字符串格式

        const requestData = {
            userId: userId,
            wordId: wordId,
            score: score,
            lasttime: lasttime
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
    // 假设这个变量用于跟踪是否已经记录过错误
    let hasRecordedError = false;

    spellInput.addEventListener('keydown', (event) => {
        if (event.key === 'Enter') {
            const userInput = spellInput.value.trim().toLowerCase();
            if (userInput === correctWord.toLowerCase()) {
                spellMessage.textContent = "拼写正确！";
                spellMessage.style.color = "green";
                spellMessage.classList.remove('hidden');
                showAnswerBtn.classList.remove('hidden');
                currentIndex++;
                hasRecordedError = false; // 重置错误记录状态
                loadCurrentWord();  // 显示下一个单词
            } else {
                questionDiv.innerHTML = `<h2>${words[currentIndex].Explanation2}</h2>`;
                answerDiv.innerHTML = `<p>${correctWord}</p>`;
                spellMessage.classList.add('hidden');  // 隐藏拼写提示信息

                // 如果还没有记录过错误，则调用更新错误次数的函数
                if (!hasRecordedError) {
                    updateFalseCount();
                    hasRecordedError = true; // 标记为已记录错误
                }
            }
            event.preventDefault();  // 阻止默认行为，如表单提交
        }
    });

    function updateFalseCount() {
        const userId = document.getElementById('userId').value; // 确保获取了userId
        const wordId = words[currentIndex].Id;

        console.log('userId:', userId);
        console.log('wordId:', wordId);

        const falseData = {
            userId: userId,
            wordId: wordId
        };

        console.log('Sending false count update request:', falseData);

        axios.post('/api/propress/score/updatefalsecount', falseData)
            .then(response => {
                console.log("False count updated:", response.data);
            })
            .catch(error => {
                console.error("Error updating false count:", error.response ? error.response.data : error.message);
            });
    }


    // 发音函数
    function speak(text) {
        if ('speechSynthesis' in window) {
            const utterance = new SpeechSynthesisUtterance(text);
            utterance.lang = 'en-US'; // 你可以根据需要设置为 'en-US' 或 'en-GB'
            speechSynthesis.speak(utterance);
        } else {
            console.error('Speech synthesis is not supported in this browser.');
        }
    }

    function cleanPhonetic(phonetic) {
        return phonetic.trim().replace(/^,|,$/g, '');
    }

    function speakPhonetic(phonetic) {
        const cleanPhonetic = cleanPhonetic(phonetic);
        if ('speechSynthesis' in window) {
            const utterance = new SpeechSynthesisUtterance(cleanPhonetic);
            utterance.lang = 'en-US'; // 设置语言为英语
            speechSynthesis.speak(utterance);
        } else {
            console.error('Speech synthesis is not supported in this browser.');
        }
    }

});