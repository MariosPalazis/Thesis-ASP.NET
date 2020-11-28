using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VCDmanagers : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);

    private void GridLoad()
    {
        con.Open();
        string cm = "select Mname from Managers";
        SqlDataAdapter sda = new SqlDataAdapter(cm, con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        GridM.DataSource = dt;
        GridM.DataBind();
        con.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["Man"])==172)
        {
            GridLoad();
        }
        else
        {
            Response.Redirect("ManagersPage.aspx");
        }
    }

    protected void Cr_Click(object sender, EventArgs e)
    {
        if (name.Text != "" && passw.Text != "") 
        {
            int count;
            con.Open();
            string num = "select count(*) from Managers where Mname=@un";
            SqlCommand cmd = new SqlCommand(num, con);
            cmd.Parameters.AddWithValue("@un", name.Text.Replace(" ", ""));
            count = Convert.ToInt32(cmd.ExecuteNonQuery());
            con.Close();

            if (count > 0)
            {
                Status.Text = "User already exists";
            }
            else
            {
                con.Open();
                string ins = "insert into Managers(Mname,Mpassword) values(@nm,@pw)";
                cmd = new SqlCommand(ins, con);
                cmd.Parameters.AddWithValue("@nm", name.Text);
                cmd.Parameters.AddWithValue("@pw", passw.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Status.Text = "Manager added";
                GridLoad();

            }
        }
        else
        {
            Status.Text = "Insert fiealds are empty!";
        }
    }

    protected void Del_Click(object sender, EventArgs e)
    {
        if (Dname.Text != "")
        {
            int c;
            con.Open();
            string num = "select count(*) from Managers where Mname=@un";
            SqlCommand cmd = new SqlCommand(num, con);
            cmd.Parameters.AddWithValue("@un", Dname.Text.Replace(" ", ""));
            c = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            if (c == 0)
            {
                Status.Text = "Manager doesn't exists!";
            }
            else
            {
                con.Open();
                string del = "DELETE FROM Managers WHERE Mname=@un";
                cmd = new SqlCommand(del, con);
                cmd.Parameters.AddWithValue("@un", Dname.Text.Replace(" ", "").ToString());
                cmd.ExecuteNonQuery();
                con.Close();
                Status.Text = "Manager deleted!";
                GridLoad();
            }
        }
        else
        {
            Status.Text = "Delete field is empty!";
        }
    }
}