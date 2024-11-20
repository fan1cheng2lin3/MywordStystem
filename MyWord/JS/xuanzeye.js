
document.addEventListener("DOMContentLoaded", async () => {
    const goodBtn = document.querySelector('.text');
    var button = document.querySelector('.xuexi');
    const buttonContainer = document.getElementById('buttonContainer');
    var fuxibutton = document.querySelector('.fuxi');
    let isShown = false; // 控制按钮显示和隐藏的标志

    const userId = document.getElementById('userId').value;
    axios.get('/api/newwords/score/getWordcoust', {
        params: { userId: userId }
    })
        .then(response => {
            // 如果服务器直接返回计数作为JSON的根值
            const wordCount = response.data;
            
            fuxibutton.textContent += '(' + wordCount + ')';

        })
        .catch(error => {
            console.error("请求失败:", error);
        });
        
 
    async function uptext() {
        try {
            // 获取 wordbook
            const response = await axios.get('/api/newwords/score/getWordbook', {
                params: { userId: userId }
            });
            console.log("Wordbook fetched:", response.data);

            const wordbook = response.data?.Wordbook?.trim();
            if (wordbook) {
                // 异步获取未学习的单词数量
                const unlearnedCountResponse = await axios.get(`/api/newwords/score/words/unlearned-count/${wordbook}`, {
                    params: { userId: userId }
                });
                const unlearnedCount = unlearnedCountResponse.data.UnlearnedCount;
                console.log("Unlearned word count:", unlearnedCount);

                // 更新按钮文本
                button.textContent = `学习页`;
                button.textContent += ` (${unlearnedCount})`;
            } else {
                alert("未能获取到有效的 Wordbook 数据！");
            }
        } catch (error) {
            console.error("Error fetching wordbook or unlearned word count:", error);
        }
    }

    // 调用函数
    uptext();
   


    // 为按钮添加点击事件监听器
    button.addEventListener('click', function () {
        // 改变当前页面的URL，实现跳转
        window.location.href = '../yemian/words.aspx';
    });

    fuxibutton.addEventListener('click', function () {
        // 改变当前页面的URL，实现跳转
        window.location.href = '../yemian/rewords.aspx';
    });




    goodBtn.addEventListener('click', () => {
        // 切换按钮的显示和隐藏
        isShown = !isShown;
        if (isShown) {
            // 显示按钮
            buttonContainer.innerHTML = '';
            const words = [
                "View_AssociateDegree",
                "View_Bachelor",
                "View_Base",
                "View_Business",
                "View_CET4",
                "View_CET6",
                "View_Computer",
                "View_Dating",
                "View_Doctor",
                "View_GMAT",
                "View_Graduate",
                "View_GRE",
                "View_HighSchool",
                "View_IELTS",
                "View_JobHunting",
                "View_MBA",
                "View_Medical",
                "View_MiddleSchool",
                "View_Phone",
                "View_PrimarySchool",
                "View_PublicService",
                "View_SAT",
                "View_Super",
                "View_TOEFL",
                "View_Trade",
                "View_Workplace"
            ]; // 假设有这些词数选项
            words.forEach(word => {
                const btn = document.createElement('button');
                btn.textContent = `选择${word}词`;
                btn.className = 'word-btn';
                btn.style.display = 'inline-block'; // 显示按钮
                buttonContainer.appendChild(btn);

                // 为每个按钮添加点击事件
                btn.addEventListener('click', () => {
                    updatewordbook(word);
                    hideButtons(); // 点击后隐藏按钮
                    uptext();
                });
            });
        } else {
            // 隐藏按钮
            hideButtons();
        }
    });

    // 点击其他地方时隐藏按钮
    document.addEventListener('click', (e) => {
        if (!e.target.matches('.text')) { // 如果点击的不是“选择词数”按钮
            hideButtons();
        }
    });

    function hideButtons() {
        // 隐藏按钮
        const wordBtns = document.querySelectorAll('.word-btn');
        wordBtns.forEach(btn => {
            btn.style.display = 'none'; // 隐藏按钮
        });
        isShown = false;
    }

    function updatewordbook(Workbook) {
        const userId = document.getElementById('userId').value;
        const requestData = {
            userId: userId,
            Wordbook: Workbook
        };

        axios.post('/api/propress/score/updatebook', requestData)
            .then(response => {
                console.log("Score updated:", response.data);
            })
            .catch(error => {
                console.error("Error updating book:", error.response ? error.response.data : error.message);
            });
    }


    // 获取年月日和星期几
    let date = new Date();
    Y = date.getFullYear();
    M = date.getMonth();
    W = date.getDay();
    D = date.getDate();
    isSelect = true;    //true为选择了月，false为选择了年（添加文本阴影）

    // 更新当前年
    let yearNow = document.getElementById("year");
    yearNow.innerHTML = Y;
    // 更新当前月
    let monthNow = document.getElementById("month");
    monthNow.innerHTML = monthAndMaxDay(Y, M)[0];
 
    //更新当前日
    let days = document.getElementById("day");
    updateAllDays(Y, M);



    
    // 按日查询对应的星期几
    function dayToStar(year, month, day) {
        let theDate = new Date(year, month, day);
        return theDate.getDay();
    }

    // 查询一个月对应的英文命名和最大天数
    function monthAndMaxDay(year, month) {
        let month_now = "";
        let maxDay = 0;     // 一个月的最大天数
        switch (month + 1) {
            case 1: month_now = "一月"; maxDay = 31; break;
            case 2:
                month_now = "二月";
                if (year % 4 == 0) {
                    maxDay = 29;
                } else {
                    maxDay = 28;
                }
                break;
            case 3: month_now = "三月"; maxDay = 31; break;
            case 4: month_now = "四月"; maxDay = 30; break;
            case 5: month_now = "五月"; maxDay = 31; break;
            case 6: month_now = "六月"; maxDay = 30; break;
            case 7: month_now = "七月"; maxDay = 31; break;
            case 8: month_now = "八月"; maxDay = 31; break;
            case 9: month_now = "九月"; maxDay = 30; break;
            case 10: month_now = "十月"; maxDay = 31; break;
            case 11: month_now = "十一月"; maxDay = 30; break;
            case 12: month_now = "十二月"; maxDay = 31; break;
            default: month = "";
        }
        return [month_now, maxDay];
    }

    // 更新当前月的所有天数
    function updateAllDays(year, month) {
        let offset = dayToStar(year, month, 1);
        let maxDay = monthAndMaxDay(year, month)[1];

        // 实现日期和星期对应
        for (let i = 0; i < offset; i++) {
            let day = document.createElement("li");
            day.className = "no-style";
            days.appendChild(day);
        }

        for (let i = 1; i <= maxDay; i++) {
            let day = document.createElement("li");
            let dateNow = new Date();
            // 当前日期有绿色背景
            if (year == dateNow.getFullYear() && month == dateNow.getMonth() && i == dateNow.getDate()) {
                day.className = "style-default bg-style"
            } else {
                day.className = "style-default";
            }
            day.id = i;
            day.innerText = i
            days.appendChild(day);
        }
    }


   
       

  

});