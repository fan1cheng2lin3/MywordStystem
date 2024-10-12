using myword.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace myword.BLL
{
    public class CiKu
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        // 通用方法：根据视图名称动态获取数据
        public List<CiKuWord> GetWordsByViewName(string viewName)
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

                // 添加更多视图
                // case "Other_View":
                //     return (from wp in db.Other_View
                //             select new CiKuWord
                //             {
                //                 Id = wp.id,
                //                 Wordpre = wp.wordpre
                //             }).ToList();
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
