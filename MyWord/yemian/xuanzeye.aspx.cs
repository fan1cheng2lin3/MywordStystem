using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class yemian_xuanciye : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // 设置用户ID
            if (Session["Userid"] != null)
            {
                userId.Value = Session["Userid"].ToString();
            }
        }
    }
}