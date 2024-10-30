using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["Userid"] != null)
            {
                lblUserId.Text = "用户ID: " + Session["Userid"].ToString();
            }
            else
            {
                lblUserId.Text = "用户未登录";
            }
        }
    }
    public bool IsLoggedIn
    {
        get
        {
            return HttpContext.Current.Session["LoggedIn"] != null && (bool)HttpContext.Current.Session["LoggedIn"];
        }
    }

    protected void LnkbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("Default.aspx"); // 重定向到登录页面
    }

}