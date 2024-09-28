<body>

    <div class="container-wrapper">
        <!-- 左边派生卡片 -->
        <div class="container">
            <div class="card">
                <div id="derivative">
                    <h2>派生</h2>
                    <!-- 这里放派生的单词卡片 -->
                </div>
                <div class="review-buttons hidden" id="review-buttons-1">
                    <button class="btn retry">重来</button>
                </div>
            </div>
        </div>

        <!-- 中间记忆卡片 -->
        <div class="container">
            <div class="card">
                <!-- 问题部分 -->
                <div id="question">
                    <h2 id="word">word</h2>
                </div>

                <!-- 答案部分 -->
                <div id="answer" class="hidden">
                    <h2 id="answer-text">单词</h2>
                </div>

                <!-- 拼写部分 -->
                <div id="spell-section" class="hidden">
                    <p id="pronunciation">/wərd/</p>
                    <input type="text" id="spell-input" placeholder="输入正确的单词">
                    <button id="submit-spell" class="btn">提交</button>
                    <p id="spell-message" class="hidden"></p>
                    <button id="return-btn" class="btn hidden">返回</button>
                </div>
                <div class="review-buttons hidden" id="review-buttons-2">
                    <button class="btn hard">困难</button>
                    <button class="btn good">良好</button>
                    <button class="btn easy">简单</button>
                </div>
            </div>
        </div>

        <!-- 右边搭配词卡片 -->
        <div class="container">
            <div class="card">
                <div id="match">
                    <h2>搭配词</h2>
                    <!-- 这里放搭配词单词卡片 -->
                </div>
                <div class="review-buttons hidden" id="review-buttons-3">
                    <button class="btn retry">重来</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        document.addEventListener("DOMContentLoaded", () => {
            const questionDiv = document.getElementById('question');
            const answerDiv = document.getElementById('answer');
            const spellSection = document.getElementById('spell-section');
            const spellInput = document.getElementById('spell-input');
            const submitSpellBtn = document.getElementById('submit-spell');
            const spellMessage = document.getElementById('spell-message');
            const returnBtn = document.getElementById('return-btn');
            const wordDisplay = document.getElementById('word');
            const pronunciation = document.getElementById('pronunciation');
            const answerText = document.getElementById('answer-text');

            let words = [
                { word: "word", pronunciation: "/wərd/", translation: "单词" },
                { word: "apple", pronunciation: "/ˈæpəl/", translation: "苹果" }
            ];
            let currentWordIndex = 0;

            function loadNextWord() {
                if (currentWordIndex >= words.length) {
                    alert("恭喜你，已完成所有单词！");
                    return;
                }
                const currentWord = words[currentWordIndex];
                wordDisplay.textContent = currentWord.word;
                pronunciation.textContent = currentWord.pronunciation;
                answerText.textContent = currentWord.translation;
                resetCard();
            }

            function resetCard() {
                questionDiv.classList.remove('hidden');
                answerDiv.classList.add('hidden');
                spellSection.classList.add('hidden');
                spellInput.value = '';
                spellMessage.classList.add('hidden');
                returnBtn.classList.add('hidden');
            }

            // 键盘事件处理
            document.addEventListener('keydown', (event) => {
                if (event.code === 'Space' && !answerDiv.classList.contains('hidden')) {
                    // 空格键 -> 简单
                    spellSection.classList.remove('hidden');
                    answerDiv.classList.add('hidden');
                } else if (event.code === 'ControlLeft' && !answerDiv.classList.contains('hidden')) {
                    // Ctrl键 -> 困难
                    spellSection.classList.remove('hidden');
                    answerDiv.classList.add('hidden');
                } else if (event.code === 'AltLeft' && !answerDiv.classList.contains('hidden')) {
                    // Alt键 -> 重来
                    spellSection.classList.remove('hidden');
                    answerDiv.classList.add('hidden');
                } else if (event.code === 'Space' && questionDiv.classList.contains('hidden')) {
                    // 空格键显示答案
                    questionDiv.classList.add('hidden');
                    answerDiv.classList.remove('hidden');
                }
            });

            // 提交拼写事件
            submitSpellBtn.addEventListener('click', () => {
                const userInput = spellInput.value.trim().toLowerCase();
                const currentWord = words[currentWordIndex].word;

                if (userInput === currentWord) {
                    spellMessage.textContent = "拼写正确！";
                    spellMessage.style.color = "green";
                    spellMessage.classList.remove('hidden');
                    returnBtn.classList.remove('hidden');
                    currentWordIndex++;
                } else {
                    spellMessage.textContent = "拼写错误，请重试。";
                    spellMessage.style.color = "red";
                    spellMessage.classList.remove('hidden');
                }
            });

            // 返回按钮事件
            returnBtn.addEventListener('click', () => {
                loadNextWord();
            });

            // 初始加载第一个单词
            loadNextWord();
        });
    </script>
</body>
