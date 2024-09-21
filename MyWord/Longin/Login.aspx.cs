using myword.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Namespace
{
    public partial class Login : System.Web.UI.Page
    {

        CustomerService CustomerSrv = new CustomerService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Name"] != null)
                {
                    txtUsername.Text = Request.QueryString["Name"];

                }
            }
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack) 
            {
                int customerId = CustomerSrv.CheckLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim());

                if (customerId > 0) 
                {
                    if(txtUsername.Text.Trim() == "admin")//管理员登录
                    {
                        Session["AdminId"] = customerId;
                        Session["AdminIdName"] = txtUsername.Text;
                        Response.Redirect("`/Admin/Default2.aspx");
                    }
                    else//一般用户
                    {
                        Session["Userid"] = customerId;
                        Session["Name"] = txtUsername.Text;
                        Response.Redirect("../Default.aspx");
                    }
                }
                else
                {
                    Label1.Text = "密码错误";
                }


            }
        }
    }
}