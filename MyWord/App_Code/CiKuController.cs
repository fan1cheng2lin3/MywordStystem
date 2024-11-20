using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using myword.BLL;

public class CiKuController : ApiController
{
    private CiKu newWordService = new CiKu();  // 实例化 CiKu 类

    // GET: api/words/{viewName}
    [HttpGet]
    [Route("api/words/{viewName}")]
    public IHttpActionResult GetWordsByViewName(string viewName, int userId)
    {
        if (string.IsNullOrWhiteSpace(viewName))
        {
            return BadRequest("视图名称不能为空！");
        }

        try
        {
            List<CiKuWord> words = newWordService.GetWordsByViewName(viewName, userId);

            if (words == null || words.Count == 0)
            {
                return NotFound();  // 如果没有找到对应的单词，返回 404
            }

            return Ok(words);  // 返回单词数据
        }
        catch (ArgumentException ex)
        {
            return BadRequest($"无效的视图名称: {viewName}. 错误信息: {ex.Message}");
        }
        catch (Exception ex)
        {
            return InternalServerError(new Exception($"获取单词列表时发生错误: {ex.Message}"));
        }
    }


    // GET: api/words/{viewName}
    [HttpGet]
    [Route("api/cikuwords/{viewName}")]
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



    [HttpGet]
    [Route("api/words/rewords")]
    public IHttpActionResult GetreWords(int userId)
    {

        try
        {
            List<CiKuWord> words = newWordService.GetLearnedWordPreData(userId);

            if (words == null || words.Count == 0)
            {
                return NotFound();  // 如果没有找到对应的单词，返回 404
            }

            return Ok(words);  // 返回单词数据
        }
        catch (ArgumentException ex)
        {
            return BadRequest($" 错误信息: {ex.Message}");
        }
        catch (Exception ex)
        {
            return InternalServerError(new Exception($"获取单词列表时发生错误: {ex.Message}"));
        }
    }
}
