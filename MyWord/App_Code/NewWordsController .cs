using System.Collections.Generic;
using System.Web.Http;
using myword.BLL;

/// <summary>
/// NewWordsController 的摘要说明
/// </summary>
public class NewWordsController : ApiController
{
    private NewWord newWordService = new NewWord(); // 使用NewWordService类的实例

    // GET: api/newwords
    [HttpGet]
    public IHttpActionResult GetNewWords()
    {
        List<Word> words = newWordService.GetWordPreData(); // 调用NewWordService类的方法
        return Ok(words);  // 返回单词数据
    }

    // POST: api/newwords
    [HttpPost]
    public IHttpActionResult AddNewWord(WordPre word)
    {
        return Ok(); // 返回成功响应
    }
}