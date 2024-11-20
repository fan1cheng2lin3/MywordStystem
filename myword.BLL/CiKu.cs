using myword.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace myword.BLL
{
    public class CiKu
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public int GetUnlearnedWordCount(string wordbook, int userId)
        {
            // 获取所有单词的初始列表
            var allWords = GetWordsByViewNameWithoutFilter(wordbook);
      
            // 获取用户已经学习过的单词ID列表
            var learnedWordIds = db.progress
                                    .Where(p => p.UserId == userId)
                                     .Select(p => p.WordId)
                                     .ToList();

            // 计算未学习单词的数量
            var unlearnedCount = allWords.Count - learnedWordIds.Count;

            return unlearnedCount;
        }




        // 通用方法：根据视图名称动态获取数据
        public List<CiKuWord> GetWordsByViewName(string viewName)
        {
            // 获取所有单词的初始列表
            var allWords = GetWordsByViewNameWithoutFilter(viewName);

            return allWords;
        }



        public List<CiKuWord> GetWordsByViewName(string viewName, int userId)
        {
            // 获取今天 UTC 的日期字符串
            var todayString = DateTime.UtcNow.ToString("yyyy-MM-dd");

            // 获取用户已经学习过的单词 ID 列表，排除当天数据
            var learnedWordIds = db.progress
                                    .Where(p => p.UserId == userId &&
                                                p.lasttime.CompareTo(todayString) < 0)
                                    .Select(p => p.WordId)
                                    .ToList();

            // 获取所有单词并过滤掉已学习的
            var allWords = GetWordsByViewNameWithoutFilter(viewName);
            var filteredWords = allWords.Where(w => !learnedWordIds.Contains(w.Id)).ToList();

            return filteredWords;
        }


        public List<CiKuWord> GetfuxiWords(string viewName, int userId)
        {
            // 获取所有单词的初始列表
            var allWords = GetWordsByViewNameWithoutFilter(viewName);

            // 获取用户已经学习过的单词ID列表
            var learnedWordIds = db.progress
                                     .Where(p => p.UserId == userId)
                                     .Select(p => p.WordId)
                                     .ToList();

            // 过滤掉已经学习过的单词
            var filteredWords = allWords.Where(w => !learnedWordIds.Contains(w.Id)).ToList();

            return filteredWords;
        }



        public List<CiKuWord> GetLearnedWordPreData(int userId)
        {
            //// 首先，从progress表中获取用户已经学习过的单词ID列表
            //var learnedWordIds = db.progress
            //                         .Where(p => p.UserId == userId)
            //                         .Select(p => p.WordId)
            //                         .ToList();


            // 获取当前日期（UTC时间）
            var todayString = DateTime.UtcNow.ToString("yyyy-MM-dd");


            // 从progress表中获取用户已经学习过的单词ID列表，排除当天学习过的单词
            var learnedWordIds = db.progress
                                     .Where(p => p.UserId == userId &&
                                        p.lasttime.CompareTo(todayString) < 0)
                                     .Select(p => p.WordId)
                                     .ToList();


            // 使用 JOIN 查询来获取用户已经学习过的单词数据
            var wordPreData = db.word
                .Where(w => learnedWordIds.Contains(w.id))  // 只选择已学习的单词
                .Select(w => new CiKuWord
                {
                    Id = w.id,
                    Wordpre = w.wordpre,
                    Phonetic = w.phonetic,
                    PhoneticUK = w.phonetic_uk,
                    Explanation2 = w.explain,
                    Etyma = w.etyma,
                    SentenceEN = w.sentence_en,
                    SentenceCN = w.sentence_cn,
                    Ancillary = w.ancillary
                })
                .ToList();

            return wordPreData;
        }

     

        private List<CiKuWord> GetWordsByViewNameWithoutFilter(string viewName)
        {
            // 根据不同视图名称选择相应的查询
            switch (viewName)
            {
                case "View_AssociateDegree":
                    return (from wp in db.View_AssociateDegree
                            select new CiKuWord
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
                            }).ToList();

                case "View_Bachelor":
                    return (from wp in db.View_Bachelor
                            select new CiKuWord
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
                            }).ToList();
                case "View_Base":
                    return (from wp in db.View_Base
                            select new CiKuWord
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
                            }).ToList();
                case "View_Business":
                    return (from wp in db.View_Business
                            select new CiKuWord
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
                            }).ToList();
                case "View_CET4":
                    return (from wp in db.View_CET4
                            select new CiKuWord
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
                            }).ToList();
                case "View_CET6":
                    return (from wp in db.View_CET6
                            select new CiKuWord
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
                            }).ToList();
                case "View_Computer":
                    return (from wp in db.View_Computer
                            select new CiKuWord
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
                            }).ToList();
                case "View_Dating":
                    return (from wp in db.View_Dating
                            select new CiKuWord
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
                            }).ToList();
                case "View_Doctor":
                    return (from wp in db.View_Doctor
                            select new CiKuWord
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
                            }).ToList();
                case "View_GMAT":
                    return (from wp in db.View_GMAT
                            select new CiKuWord
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
                            }).ToList();
                case "View_Graduate":
                    return (from wp in db.View_Graduate
                            select new CiKuWord
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
                            }).ToList();
                case "View_GRE":
                    return (from wp in db.View_GRE
                            select new CiKuWord
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
                            }).ToList();
                case "View_HighSchool":
                    return (from wp in db.View_HighSchool
                            select new CiKuWord
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
                            }).ToList();
                case "View_IELTS":
                    return (from wp in db.View_IELTS
                            select new CiKuWord
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
                            }).ToList();
                case "View_JobHunting":
                    return (from wp in db.View_JobHunting
                            select new CiKuWord
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
                            }).ToList();
                case "View_MBA":
                    return (from wp in db.View_MBA
                            select new CiKuWord
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
                            }).ToList();
                case "View_Medical":
                    return (from wp in db.View_Medical
                            select new CiKuWord
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
                            }).ToList();
                case "View_MiddleSchool":
                    return (from wp in db.View_MiddleSchool
                            select new CiKuWord
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
                            }).ToList();
                case "View_Phone":
                    return (from wp in db.View_Phone
                            select new CiKuWord
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
                            }).ToList();
                case "View_PrimarySchool":
                    return (from wp in db.View_PrimarySchool
                            select new CiKuWord
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
                            }).ToList();
                case "View_PublicService":
                    return (from wp in db.View_PublicService
                            select new CiKuWord
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
                            }).ToList();
                case "View_SAT":
                    return (from wp in db.View_SAT
                            select new CiKuWord
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
                            }).ToList();
                case "View_Super":
                    return (from wp in db.View_Super
                            select new CiKuWord
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
                            }).ToList();
                case "View_TOEFL":
                    return (from wp in db.View_TOEFL
                            select new CiKuWord
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
                            }).ToList();
                case "View_Trade":
                    return (from wp in db.View_Trade
                            select new CiKuWord
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
                            }).ToList();
                case "View_Workplace":
                    return (from wp in db.View_Workplace
                            select new CiKuWord
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
                            }).ToList();

                default:
                    throw new ArgumentException("无效的视图名称");
            }
        }

        
    }

    

    // 定义一个 WordPre 类来存储 wordpre 表的数据
    public class CiKuWord
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
