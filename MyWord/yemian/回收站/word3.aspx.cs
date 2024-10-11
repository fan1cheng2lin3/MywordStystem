using myword.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Card_word3 : System.Web.UI.Page
{
    private List<WordPre> wordPreList;
    private int currentIndex;

    public void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 初始化索引
            currentIndex = 0;

            // 获取单词数据
            News customer = new News();
            wordPreList = customer.GetWordPreData();

            if (wordPreList != null && wordPreList.Count > 0)
            {
                LoadCurrentWord();
            }
        }
    }

    private void LoadCurrentWord()
    {
        WordPre wordPreData = wordPreList[currentIndex];
        ViewState["Word"] = wordPreData.Word;
        ViewState["SoundMark"] = wordPreData.SoundMark;
        ViewState["Translation"] = wordPreData.Translation;
        ViewState["Example"] = wordPreData.Example;
        ViewState["ExampleTranslation"] = wordPreData.ExampleTranslation;
    }
}