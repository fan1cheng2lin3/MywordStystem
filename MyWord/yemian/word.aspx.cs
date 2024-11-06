using myword.BLL;
using System.Collections.Generic;
using System;

public partial class Card_word2 : System.Web.UI.Page
{
    private List<Word> wordPreList;
    private int currentIndex;

    public void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    // 初始化索引
        //    currentIndex = 0;

        //    // 获取单词数据
        //    News customer = new News();
        //    wordPreList = customer.GetWordPreData();

        //    if (wordPreList != null && wordPreList.Count > 0)
        //    {
        //        LoadCurrentWord();
        //    }
        //}

        //if (!IsPostBack)
        //{
        //    // 初始化索引
        //    currentIndex = 0;

        //    // 获取单词数据
        //    NewWord customer = new NewWord();
        //    wordPreList = customer.GetWordPreData();

        //    if (wordPreList != null && wordPreList.Count > 0)
        //    {
        //        LoadCurrentWord();
        //    }
        //}
    }

  

    //private void LoadCurrentWord()
    //{
    //    Word wordPreData = wordPreList[currentIndex];
    //    ViewState["Word"] = wordPreData.Wordpre;
    //    ViewState["SoundMark"] = wordPreData.Phonetic;
    //    ViewState["Translation"] = wordPreData.Explanation2;
    //    ViewState["Example"] = wordPreData.SentenceEN;
    //    ViewState["ExampleTranslation"] = wordPreData.SentenceCN;
    //}
}