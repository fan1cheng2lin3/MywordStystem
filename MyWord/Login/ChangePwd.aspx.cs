using myword.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 

public partial class Longin_ChangePwd : System.Web.UI.Page
{


    CustomerService customerSrv = new CustomerService();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Userid"] == null)
        {
            Response.Redirect("Login.aspx");
        }
    }


    protected void btnCPwd_Click(object sender, EventArgs e)
    {


        if (customerSrv.CheckLogin(Session["Name"].ToString(), txtUsername.Text) > 0)
        {
            customerSrv.Changepassword(Convert.ToInt32(Session["Userid"]), TextBox1.Text);
            Label1.Text = "修改成功";
        }
        else
        {
            Label1.Text = "原密码错误";
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
    }
}