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
        public static bool a = false;
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

        public int CurrentUserId
        {
            get
            {
                if (Session["Userid"] != null)
                {
                    return (int)Session["Userid"];
                }
                return -1; // 如果没有用户登录，返回一个无效的ID
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
                        Session["LoggedIn"] = true;
                        Response.Redirect("`/Admin/Default2.aspx");
                       
                    }
                    else//一般用户
                    {
                        Session["Userid"] = customerId;
                        Session["Name"] = txtUsername.Text;
                        Session["LoggedIn"] = true;
                        Response.Redirect("../Default.aspx");
                       
                    }
                }
                else
                {
                    Label1.Text = "密码错误";
                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            Response.Redirect("../Default.aspx");
        }

        protected void Button1_Click2(object sender, EventArgs e)
        {

            Response.Redirect("GetPwd.aspx");
        }

        public bool IsLoggedIn
        {
            get
            {
                // 这里检查用户是否登录，例如检查Session中的值
                return Session["LoggedIn"] != null && (bool)Session["LoggedIn"];
            }
        }
    }
}