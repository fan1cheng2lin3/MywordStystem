using myword.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myword.BLL
{
    public class News
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public void Insert(string name, string password, string email)
        {
            user_Table customer = new user_Table
            {
                Name = name,
                Password = password,
                Email = email
            };
            db.user_Table.InsertOnSubmit(customer);
            db.SubmitChanges();
        }

        public bool IsNameExist(string name)
        {
            user_Table customer = (from c in db.user_Table
                                   where c.Name == name
                                   select c).FirstOrDefault();

            if (customer == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // 新增方法：读取wordpre表的数据
        public List<WordPre> GetWordPreData()
        {
            var wordPreData = from wp in db.wordpre
                              select new WordPre
                              {
                                  Type1 = wp.type1,
                                  Type2 = wp.type2,
                                  Type3 = wp.type3,
                                  Type4 = wp.type4,
                                  Word = wp.word,
                                  WordLevel = wp.wordlevel,
                                  RootVariant = wp.rootvariant,
                                  Meaning = wp.meaning,
                                  SoundMark = wp.soundmark,
                                  Structure = wp.structure,
                                  Explanation = wp.explain,
                                  Translation = wp.translation,
                                  Example = wp.example,
                                  ExampleTranslation = wp.exampletranslation
                              };

            return wordPreData.ToList();
        }
    }


    // 定义一个WordPre类来存储wordpre表的数据
    public class WordPre
    {
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string Type3 { get; set; }
        public string Type4 { get; set; }
        public string Word { get; set; }
        public string WordLevel { get; set; }
        public string RootVariant { get; set; }
        public string Meaning { get; set; }
        public string SoundMark { get; set; }
        public string Structure { get; set; }
        public string Explanation { get; set; }
        public string Translation { get; set; }
        public string Example { get; set; }
        public string ExampleTranslation { get; set; }
    }

}

