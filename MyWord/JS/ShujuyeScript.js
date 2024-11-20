document.addEventListener("DOMContentLoaded", async () => {
    const cishuname = document.querySelector('.cishuname');
    var button = document.querySelector('.xuexi');
    const buttonContainer = document.getElementById('buttonContainer');
    var fuxibutton = document.querySelector('.fuxi');
    let isShown = false; // 控制按钮显示和隐藏的标志

    const userId = document.getElementById('userId').value;
    axios.get('/api/newwords/score/getWordbook', {
        params: { userId: userId }
    })
        .then(response => {
            // 如果服务器直接返回计数作为JSON的根值
            const wordCount = response.data?.Wordbook?.trim();

            cishuname.textContent += '(' + wordCount + ')';

        })
        .catch(error => {
            console.error("请求失败:", error);s
        });






});