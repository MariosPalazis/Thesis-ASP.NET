using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (UsernameT.Text.Length < 20 && PasswordT.Text.Length < 20)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            conn.Open();
            String check = "select count(*) from Managers where Mname='" + UsernameT.Text + "'";
            SqlCommand com = new SqlCommand(check, conn);
            int temp = Convert.ToInt32(com.ExecuteScalar());
            conn.Close();
            if (temp == 1)
            {
                conn.Open();
                String checkPassword = "select Mpassword from Managers where Mname='" + UsernameT.Text + "'";
                SqlCommand Passcom = new SqlCommand(checkPassword, conn);
                String pw = Passcom.ExecuteScalar().ToString().Replace(" ", "");
                if (pw == PasswordT.Text)
                {
                    Session["Code"] = 5719;
                    Response.Redirect("ManagersPage.aspx");
                }
                else
                {
                    Label3.Text = "WRONG PASSWORD";
                }
                conn.Close();
            }
            else
            {
                if (UsernameT.Text != "")
                {
                    Label3.Text = "WRONG USERNAME";
                }

            }
        }
        else
        {
            Label3.Text = "Username and password length must be below 20 characters";
        }
    
    }
}