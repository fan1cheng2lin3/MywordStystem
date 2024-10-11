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

}
