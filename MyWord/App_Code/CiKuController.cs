using System;
using System.Collections.Generic;
using System.Web.Http;
using myword.BLL;

public class CiKuController : ApiController
{
    private CiKu newWordService = new CiKu();  // 实例化 CiKu 类

    // GET: api/words/{viewName}
    [HttpGet]
    [Route("api/words/{viewName}")]
    public IHttpActionResult GetWordsByViewName(string viewName)
    {
        try
        {
            // 根据传入的视图名获取数据
            List<CiKuWord> words = newWordService.GetWordsByViewName(viewName);
            return Ok(words);  // 返回单词数据
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);  // 处理无效视图名称的错误
        }
    }
}
