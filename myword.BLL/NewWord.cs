using myword.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myword.BLL
{
    public class NewWord
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public WordBook GetWordbookByUserId(string userId)
        {
            // 从数据库获取对应用户的 Wordbook
            var wordbook = db.user_Table
                             .Where(wp => wp.Userid.ToString() == userId)
                             .Select(wp => new WordBook
                             {
                                 Id = wp.Userid,
                                 Wordbook = wp.Wordbook
                             })
                             .FirstOrDefault();  // 只取一条记录

            return wordbook;
        }

        public int GetWordcoust(int userId)
        {
            // 获取今天的日期字符串
            var todayString = DateTime.UtcNow.ToString("yyyy-MM-dd");

            int wordcoust = db.progress
                              .Where(wp => wp.UserId == userId &&
                                           wp.lasttime.CompareTo(todayString) < 0)
                              .Count();

            return wordcoust;
        }



        // 新增方法：读取wordpre表的数据
        public List<Word> GetWordPreData()
        {
            var wordPreData = from wp in db.word
                              select new Word
                              {
                                  Id = wp.id,
                                  Wordpre = wp.wordpre,
                                  Phonetic = wp.phonetic,
                                  PhoneticUK = wp.phonetic_uk,
                                  Explanation2 = wp.explain,
                                  Etyma = wp.etyma,
                                  SentenceEN = wp.sentence_en,
                                  SentenceCN = wp.sentence_cn,
                                  Ancillary = wp.ancillary
                              };

            return wordPreData.ToList();
        }


      
    }




    // 定义一个WordPre类来存储wordpre表的数据
    public class Word
    {
        public int Id { get; set; }
        public string Wordpre { get; set; }
        public string Phonetic { get; set; }
        public string PhoneticUK { get; set; }
        public string Explanation2 { get; set; }
        public string Etyma { get; set; }
        public string SentenceEN { get; set; }
        public string SentenceCN { get; set; }
        public string Ancillary { get; set; }
    }

    public class WordBook {

        public int? Id { get; set; }
        public string Wordbook { get; set; }
    }

}
