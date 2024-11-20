using System;
using System.Collections.Generic;
using System.Web.Http;
using myword.BLL;
using static NewWordsController.PropressController;


/// <summary>
/// NewWordsController 的摘要说明
/// </summary>
[RoutePrefix("api/newwords")]
public class NewWordsController : ApiController
{
    private NewWord newWordService = new NewWord();
    private Cardsuanfa getwordcoust = new Cardsuanfa();
    private CiKu newWord = new CiKu();

    [HttpGet]
    public IHttpActionResult GetNewWords()
    {
        List<Word> words = newWordService.GetWordPreData();
        return Ok(words);
    }

    [HttpGet]
    [Route("score/getWordbook")]  // 路由为 /api/newwords/score/getWordbook
    public IHttpActionResult GetWordbook(string userId)
    {
        if (string.IsNullOrEmpty(userId))
        {
            return BadRequest("没有User ID.");
        }

        var wordbook = newWordService.GetWordbookByUserId(userId);

        if (wordbook == null)
        {
            return NotFound();
        }

        return Ok(wordbook);
    }


    [HttpGet]
    [Route("score/getWordcoust")]  // 路由为 /api/newwords/score/getWordcoust
    public IHttpActionResult GetWordcoust(int userId)
    {
        var rewordcoust = newWordService.GetWordcoust(userId);
       
        return Ok(rewordcoust);
    }


    [HttpGet]
    [Route("score/words/unlearned-count/{wordbook}")]
    public IHttpActionResult GetUnlearnedWordCount(string wordbook, int userId)
    {
        if (string.IsNullOrEmpty(wordbook))
        {
            return BadRequest("Wordbook 名称不能为空！");
        }

        try
        {
            var unlearnedCount = newWord.GetUnlearnedWordCount(wordbook, userId);
            return Ok(new { UnlearnedCount = unlearnedCount });
        }
        catch (Exception ex)
        {
            return InternalServerError(ex);
        }
    }



    /// <summary>
    /// PropressController 的摘要说明
    /// </summary>
    [RoutePrefix("api/propress")]
    public class PropressController : ApiController
    {
        [Route("score/updatescore")]
        [HttpPost]
        public IHttpActionResult UpdateScore([FromBody] ScoreRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request body. Please check the required fields and data types.");
            }

            try
            {
                Console.WriteLine($"Received request: UserId={request.UserId}, WordId={request.WordId}, Score={request.Score}");
                Cardsuanfa cardsuanfa = new Cardsuanfa();
                bool result = cardsuanfa.UpdateWordScore(request.UserId, request.WordId, request.Score,request.lasttime);



                if (result)
                {
                    return Ok("Score updated successfully.");
                }
                else
                {
                    return BadRequest("Failed to update score. Please check the database connection and data integrity.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception details, including stack trace, for debugging purposes
                Console.Error.WriteLine($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
                return InternalServerError(ex); // Pass the exception object to InternalServerError
            }
        }




        [Route("score/updatefalsecount")]
        [HttpPost]
        public IHttpActionResult UpdateFalseCount([FromBody] FalseCountModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request body. Please check the required fields and data types.");
            }

            try
            {
                Console.WriteLine($"Received false count request: UserId={model.UserId}, WordId={model.WordId}");
                Cardsuanfa cardsuanfa = new Cardsuanfa();
                bool result = cardsuanfa.UpdateWordFalseCount(model.UserId, model.WordId);

                if (result)
                {
                    return Ok("False count updated successfully.");
                }
                else
                {
                    return BadRequest("Failed to update false count. Please check the database connection and data integrity.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception details, including stack trace, for debugging purposes
                Console.Error.WriteLine($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
                return InternalServerError(ex); // Pass the exception object to InternalServerError
            }
        }





        [Route("score/updatebook")]
        [HttpPost]
        public IHttpActionResult UpdateBook([FromBody] BookRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid request body. Please check the required fields and data types.");
            }

            try
            {

                Cardsuanfa cardsuanfa = new Cardsuanfa();
                bool result = cardsuanfa.UpdateWordBook(request.UserId, request.Wordbook);

                if (result)
                {
                    return Ok("Score updated successfully.");
                }
                else
                {
                    return BadRequest("Failed to update score. Please check the database connection and data integrity.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception details, including stack trace, for debugging purposes
                Console.Error.WriteLine($"Exception: {ex.Message}\nStack Trace: {ex.StackTrace}");
                return InternalServerError(ex); // Pass the exception object to InternalServerError
            }
        }


        public class BookRequest
        {
            public int UserId { get; set; }
            public string Wordbook { get; set; }

        }

        public class ScoreRequest
        {
            public int UserId { get; set; }
            public int WordId { get; set; }
            public int Score { get; set; }
            public string Wordbook { get; set; }
            public string lasttime { get; set; }
        }

        public class FalseCountModel
        {
            public int UserId { get; set; }
            public int WordId { get; set; }
        }
    }
}


