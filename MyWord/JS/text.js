document.addEventListener("DOMContentLoaded", () => {
    const goodBtn = document.querySelector('.text');

    // 更新书籍
    function updatewordbook(Workbook) {
        const userId = document.getElementById('userId').value;
        const requestData = { userId: userId, Wordbook: Workbook };

        axios.post('/api/propress/score/updatebook', requestData)
            .then(response => {
                console.log("Score updated:", response.data);
            })
            .catch(error => {
                console.error("Error updating book:", error.response ? error.response.data : error.message);
            });
    }

    goodBtn.addEventListener('click', () => {
        updatewordbook("6666");
    });

    // 获取日期
    let date = new Date();
    let Y = date.getFullYear();
    let M = date.getMonth();
    let D = date.getDate();

    let yearNow = document.getElementById("year");
    let monthNow = document.getElementById("month");
    let days = document.getElementById("day");

    // 更新年和月
    yearNow.innerHTML = Y;
    monthNow.innerHTML = monthAndMaxDay(Y, M)[0];
    updateAllDays(Y, M);

    // 生成月份名称和天数
    function monthAndMaxDay(year, month) {
        const months = ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"];
        const daysInMonth = [31, (year % 4 === 0 ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
        return [months[month], daysInMonth[month]];
    }

    // 更新当前月的所有天数
    function updateAllDays(year, month) {
        days.innerHTML = '';  // 清除之前内容
        let offset = new Date(year, month, 1).getDay() - 1;
        offset = offset === -1 ? 6 : offset; // 修正星期偏移

        // 填充空白
        for (let i = 0; i < offset; i++) {
            let emptyDay = document.createElement("li");
            emptyDay.className = "no-style";
            days.appendChild(emptyDay);
        }

        // 填充日期
        const maxDay = monthAndMaxDay(year, month)[1];
        for (let i = 1; i <= maxDay; i++) {
            let day = document.createElement("li");
            day.className = (year === Y && month === M && i === D) ? "style-default bg-style" : "style-default";
            day.innerText = i;
            days.appendChild(day);
        }
    }
});
