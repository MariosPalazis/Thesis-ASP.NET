using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GeneralInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection REcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        REcon.Open();
        string ins = "select Head,p1,p2,p3,p4,p5 from GenInfo where id=1";
        SqlCommand cmd1 = new SqlCommand(ins, REcon);
        SqlDataReader rdr = cmd1.ExecuteReader();
        if (rdr.HasRows)
        {
            while (rdr.Read())
            {
                head.InnerText = rdr.GetString(0);
                p1.InnerText = rdr.GetString(1);
                p2.InnerText = rdr.GetString(2);
                p3.InnerText = rdr.GetString(3);
                p4.InnerText = rdr.GetString(4);
                p5.InnerText = rdr.GetString(5);
            }
        }
        REcon.Close();
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string url = "https://www.betarades.gr/";
        Response.Write("<script type='text/javascript'>window.open('" + url + "');</script>");
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string url = "https://www.stoiximan.gr/";
        Response.Write("<script type='text/javascript'>window.open('" + url + "');</script>");
    }
}