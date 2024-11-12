using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

/// <summary>
/// UserInfoController 的摘要说明
/// </summary>
[Route("api/userinfo/userid")]
public class UserInfoController : ApiController
{
    [HttpGet]
    public IHttpActionResult GetCurrentUserId()
    {
        // 检查HttpContext和Session是否不为null
        if (HttpContext.Current != null && HttpContext.Current.Session != null)
        {
            int userId = HttpContext.Current.Session["Userid"] != null ? (int)HttpContext.Current.Session["Userid"] : -1;
            return Ok(userId);
        }
        else
        {
            // 如果HttpContext或Session为null，返回错误信息
            return InternalServerError(new Exception("Session is not available."));
        }
    }
}