using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserCtrcl_UserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["AdminId"] != null || Session["Userid"] != null)  //用户已登录
        {
            if (Session["AdminId"] != null)  //管理员用户
            {
                lblWelcome.Text = "您好, " + Session["Name"].ToString();
                lnkbtnManage.Visible = true;
            }
            else if (Session["Userid"] != null)  //一般用户
            {
                lblWelcome.Text = "您好, " + Session["Name"].ToString();
                lnkbtnPwd.Visible = true;
                lnkbtnManage.Visible = true;
            }
            lnkbtnLogout.Visible = true;
        }
    }




    protected void LnkbtnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/Default.aspx");
    }

}
