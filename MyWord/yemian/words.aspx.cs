using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yemian_words : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["Userid"] != null)
            {
                userId.Value = Session["Userid"].ToString();  // 设置 userId 的值
            }
        }
    }
}