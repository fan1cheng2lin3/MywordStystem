<%@ Application Language="C#" %>

<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        // 注册 Web API 路由
        System.Web.Http.GlobalConfiguration.Configure(WebApiConfig.Register);

        // jQuery 的 ScriptResourceDefinition 设置
        ScriptResourceDefinition scriptResDef = new ScriptResourceDefinition();
        scriptResDef.Path = "~/Scripts/jquery-3.2.1.min.js";
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, scriptResDef);
    }

    void Application_End(object sender, EventArgs e) 
    {
        // 应用程序关闭时的代码
    }

    void Application_Error(object sender, EventArgs e) 
    {
        // 错误处理代码
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 新会话启动时的代码
    }

    void Session_End(object sender, EventArgs e) 
    {
        // 会话结束时的代码
    }
</script>
