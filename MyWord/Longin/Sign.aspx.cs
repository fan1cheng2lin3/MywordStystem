using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using myword.BLL;

public partial class Longin_Sign : System.Web.UI.Page
{
    CustomerService customerSrv = new CustomerService();

    public void RegisterButton_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (customerSrv.IsNameExist(TextBox2.Text.Trim()))
            {
                Label1.Text = "用户名已存在";
            }
            else
            {
                customerSrv.Insert(TextBox2.Text.Trim(), TextBox1.Text.Trim(), EmailTextBox.Text.Trim());
                Response.Redirect("Login.aspx");
            }
        }
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        
    }

    protected void EmailTextBox_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ConfirmTextBox_TextChanged(object sender, EventArgs e)
    {

    }
}