using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangeText : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Convert.ToInt32(Session["txt"])!=73)
            {
                Response.Redirect("ManagersPage.aspx");
            }
            SqlConnection REcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            REcon.Open();
            string ins = "select Head,p1,p2,p3,p4,p5 from GenInfo where id=1";
            SqlCommand cmd1 = new SqlCommand(ins, REcon);
            SqlDataReader rdr = cmd1.ExecuteReader();
            if (rdr.HasRows)
                {
                while (rdr.Read())
                {
                    Head.Text = rdr.GetString(0);
                    pt1.Text = rdr.GetString(1);
                    pt2.Text = rdr.GetString(2);
                    pt3.Text = rdr.GetString(3);
                    pt4.Text = rdr.GetString(4);
                    pt5.Text = rdr.GetString(5);
                }
            }
            REcon.Close();
        }
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        string head = "";
        string p1 = "";
        string p2 = "";
        string p3 = "";
        string p4 = "";
        string p5 = "";

        head = Head.Text.ToString();
        p1 = pt1.Text.ToString();
        p2 = pt2.Text.ToString();
        p3 = pt3.Text.ToString();
        p4 = pt4.Text.ToString();
        p5 = pt5.Text.ToString();

        if(head.Length>30 || p1.Length>600 || p2.Length > 600 || p3.Length > 600 || p4.Length > 600 || p5.Length > 600)
        {
            Error.Text = "Paragraph's text must be below 600 chars and header's text below 30 chars";
        }
        else
        {
            SqlConnection REcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            REcon.Open();
            string ins = "UPDATE GenInfo SET Head=@H, p1=@p1, p2=@p2, p3=@p3, p4=@p4, p5=@p5 where id=1";
            SqlCommand cmd1 = new SqlCommand(ins, REcon);
            cmd1.Parameters.AddWithValue("@H",head);
            cmd1.Parameters.AddWithValue("@p1", p1);
            cmd1.Parameters.AddWithValue("@p2", p2);
            cmd1.Parameters.AddWithValue("@p3", p3);
            cmd1.Parameters.AddWithValue("@p4", p4);
            cmd1.Parameters.AddWithValue("@p5", p5);
            cmd1.ExecuteNonQuery();
            REcon.Close();
            Error.Text = "Succesfully Updated!";
        }
    }
}