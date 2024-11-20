using myword.DAL;
using System;
using System.Linq;

namespace myword.BLL
{
    public class Cardsuanfa
    {
        private DataClasses1DataContext db = new DataClasses1DataContext();

        // 更新进度表中的单词评分
        public bool UpdateWordScore(int userId, int wordId, int score, string lasttime)
        {
            try
            {
                // 查找进度表中的记录
                var progressRecord = db.progress.SingleOrDefault(p => p.UserId == userId && p.WordId == wordId);

                if (progressRecord != null)
                {
                    // 更新现有记录的评分和计数
                    progressRecord.Score = score;
                    progressRecord.lasttime = lasttime;
                }
                else
                {
                    // 创建新的记录并添加到数据库，初始计数为1
                    var newProgressRecord = new progress
                    {
                        UserId = userId,
                        WordId = wordId,
                        Score = score,
                        count = 1,
                        FalseCount = 0,
                        lasttime = lasttime,
                        lost = 0
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



        public bool UpdateWordFalseCount(int userId, int wordId)
        {
            try
            {
                // 查找进度表中的记录
                var progressRecord = db.progress.SingleOrDefault(p => p.UserId == userId && p.WordId == wordId);

                if (progressRecord != null)
                {
                    // 更新现有记录的错误次数

                    progressRecord.count += 1; // 计数加1
                    progressRecord.FalseCount += 1; // 错误次数加1
                                                    // 计算lost值，如果Score或FalseCount为NULL，则视为0
                    progressRecord.lost = (progressRecord.Score ?? 0) +
                       (float)progressRecord.FalseCount / (float)(progressRecord.count ?? 1);


                }


                db.SubmitChanges();  // 保存更改到数据库
                return true;
            }
            catch (Exception ex)
            {
                // 在日志中记录错误信息
                Console.WriteLine("Error updating false count in progress table: " + ex.Message);
                return false;
            }
        }


        public bool UpdateWordBook(int userId, string wordbook)
        {
            try
            {
                var wordbookRecord = db.user_Table.SingleOrDefault(p => p.Userid == userId);

                if (wordbookRecord == null)
                {
                    // 如果没有找到记录，创建一个新的记录
                    wordbookRecord = new user_Table { Userid = userId };
                    db.user_Table.InsertOnSubmit(wordbookRecord);
                }

                // 更新 Wordbook 属性
                wordbookRecord.Wordbook = wordbook;

                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating score in progress table: " + ex.Message);
                return false;
            }
        }

       

    }
}