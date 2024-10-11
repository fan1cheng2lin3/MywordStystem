using myword.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myword.BLL
{
    internal class CiKu
    {

        DataClasses1DataContext db = new DataClasses1DataContext();





        // 新增方法：读取wordpre表的数据
        public List<CiKuWord> GetWordPreData()
        {
            var wordPreData = from wp in db._09zhuanba
                              select new CiKuWord
                              {
                                  Id = wp.id,
                                  Wordpre = wp.word,
                              };

            return wordPreData.ToList();
        }
    }


    // 定义一个WordPre类来存储wordpre表的数据
    public class CiKuWord
    {
        public int Id { get; set; }
        public string Wordpre { get; set; }
    }
}
