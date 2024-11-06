using myword.DAL;
using System;
using System.Linq;

namespace myword.BLL
{
    public class Cardsuanfa
    {
        private DataClasses1DataContext db = new DataClasses1DataContext();

        // 更新进度表中的单词评分
        public bool UpdateWordScore(int userId, int wordId, int score)
        {
            try
            {
                // 查找进度表中的记录
                var progressRecord = db.progress.SingleOrDefault(p => p.UserId == userId && p.WordId == wordId);

                if (progressRecord != null)
                {
                    // 更新现有记录的评分
                    progressRecord.Score = score;
                }
                else
                {
                    // 创建新的记录并添加到数据库
                    var newProgressRecord = new progress
                    {
                        UserId = userId,
                        WordId = wordId,
                        Score = score
                    };
                    db.progress.InsertOnSubmit(newProgressRecord);
                }
                db.SubmitChanges();  // 保存更改到数据库
                return true;
            }
            catch (Exception ex)
            {
                // 在日志中记录错误信息，这里使用Console.WriteLine仅作为示例
                // 在实际应用中，您可能需要使用日志框架，如NLog或log4net
                Console.WriteLine("Error updating score in progress table: " + ex.Message);
                return false;
            }
        }
    }
}