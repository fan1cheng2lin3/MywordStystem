<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>个人信息修改</title>
    <link rel="stylesheet" href="path_to_css.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
</head>
<body>
    <div class="container">
        <h2>个人信息</h2>
        <!-- 显示当前个人信息 -->
        <div class="info-display">
            <span id="displayNickname">昵称: 用户昵称</span>
            <br />
            <span id="displayPhone">手机号: 用户手机号</span>
            <br />
            <button id="editButton" onclick="openModal()">修改信息</button>
        </div>
        
        <!-- 弹窗 -->
        <div id="modal" class="modal">
            <div class="modal-content">
                <h2>修改个人信息</h2>
                <form id="form1" runat="server">
                    <div class="inputBox">
                        <asp:TextBox ID="TextBox2" runat="server" Text="用户昵称"></asp:TextBox>
                        <span>昵称</span>
                    </div>
                    <div class="inputBox">
                        <asp:TextBox ID="TextBox1" runat="server" Text="用户手机号"></asp:TextBox>
                        <span>手机号</span>
                    </div>
                    <button type="button" onclick="saveChanges()">确认修改</button>
                    <button type="button" onclick="closeModal()">取消</button>
                </form>
            </div>
        </div>
    </div>

    <script>
        // 打开弹窗
        function openModal() {
            document.getElementById("modal").style.display = "block";
        }

        // 关闭弹窗
        function closeModal() {
            document.getElementById("modal").style.display = "none";
        }

        // 保存修改
        function saveChanges() {
            // 可以添加AJAX提交数据的逻辑，这里只是关闭窗口
            closeModal();
        }
    </script>
</body>
</html>
