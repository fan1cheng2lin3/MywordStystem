using System.Collections.Generic;
using System.Web.Http;
using myword.BLL;

public class WordsController : ApiController
{
    private News newsService = new News();

    // GET: api/words
    [HttpGet]
    public IHttpActionResult GetWords()
    {
        List<WordPre> words = newsService.GetWordPreData();
        return Ok(words);  // 返回单词数据
    }

    // POST: api/words
    [HttpPost]
    public IHttpActionResult AddWord(WordPre word)
    {
        // 添加业务逻辑：这里可以添加将新单词保存到数据库的逻辑
        return Ok();
    }
}
