using System;
using System.Collections.Generic;
using System.Web.Http;
using myword.BLL;


/// <summary>
/// NewWordsController 的摘要说明
/// </summary>
[RoutePrefix("api/newwords")]
public class NewWordsController : ApiController
{
    private NewWord newWordService = new NewWord();

    [HttpGet]
    public IHttpActionResult GetNewWords()
    {
        List<Word> words = newWordService.GetWordPreData();
        return Ok(words);
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
            bool result = cardsuanfa.UpdateWordScore(request.UserId, request.WordId, request.Score);



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

    // Define ScoreRequest class to transfer request parameters
    public class ScoreRequest
    {
        public int UserId { get; set; }
        public int WordId { get; set; }
        public int Score { get; set; }
        public string Wordbook { get; set; }
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

}


