using System.Web.Http;

//配置Web API的路由
public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // 启用特性路由
        config.MapHttpAttributeRoutes();

        // 默认路由配置
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
}
