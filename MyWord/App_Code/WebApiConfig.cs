using System.Web.Http;

//配置Web API的路由
public static class WebApiConfig
{
    public static void Register(HttpConfiguration config)
    {
        // 启用属性路由
        config.MapHttpAttributeRoutes();

        // 配置默认路由
        config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
        );
    }
}
