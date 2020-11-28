using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data.OleDb;
using System.Data;

public partial class _Default : System.Web.UI.Page
{

    private DropDownList TeamsToDropdown(DropDownList ddl, DataTable d)
    {
        ddl.DataSource = d;
        ddl.DataValueField = "id";
        ddl.DataTextField = "name";
        ddl.DataBind();
        
        return ddl;
    }

    private void UpdateTeamsDB(int Thome,int Taway,int Gh,int Ga)
    {
        SqlConnection mcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        string insH = "";
        string insA = "";
        if (Gh > Ga)
        {
            insH = "update Teams set Whome=Whome+1 , goalinfH=goalinfH+@p1 , goalagH=goalinfH+@p2 where Id=@p3";
            insA = "update Teams set Laway=Lhome+1 , goalinfA=goalinfA+@p4 , goalagA=goalagA+@p5 where Id=@p6";
        }
        else if (Gh < Ga)
        {
            insH = "update Teams set Lhome=Lhome+1 , goalinfH=goalinfH+@p1 , goalagH=goalagH+@p2 where Id=@p3";
            insA = "update Teams set Waway=Waway+1 , goalinfA=goalinfA+@p4 , goalagA=goalagA+@p5 where Id=@p6";
        }
        else
        {
            insH = "update Teams set Dhome=Dhome+1 , goalinfH=goalinfH+@p1 , goalagH=goalinfH+@p2 where Id=@p3";
            insA = "update Teams set Daway=Dhome+1 , goalinfA=goalinfA+@p4 , goalagA=goalagA+@p5 where Id=@p6";
        }
        mcon.Open();
        SqlCommand cmdh = new SqlCommand(insH,mcon);
        cmdh.Parameters.AddWithValue("@p1",Gh);
        cmdh.Parameters.AddWithValue("@p2",Ga);
        cmdh.Parameters.AddWithValue("@p3",Thome);
        cmdh.ExecuteNonQuery();
        mcon.Close();
        mcon.Open();
        SqlCommand cmda = new SqlCommand(insA, mcon);
        cmda.Parameters.AddWithValue("@p4", Ga);
        cmda.Parameters.AddWithValue("@p5", Gh);
        cmda.Parameters.AddWithValue("@p6", Taway);
        cmda.ExecuteNonQuery();
        mcon.Close();
    }

    private void GridLoad()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        con.Open();
        string cm = "select Gw, HteamN, AteamN from DisplayedMatches ";
        SqlDataAdapter sda = new SqlDataAdapter(cm, con);
        DataTable dt = new DataTable();
        sda.Fill(dt);
        DisplayGrid.DataSource = dt;
        DisplayGrid.DataBind();
        con.Close();
    }

    private void InsToRel(int hc,int ac, int hg, int ag)
    {
        int res;
        if (hg > ag)
        {
            if (hg + ag > 2)
            {
                res = 4;
            }
            else
            {
                res = 7;
            }
        }
        else if (hg < ag)
        {
            if (hg + ag > 2)
            {
                res = 5;
            }
            else
            {
                res = 8;
            }
        }
        else
        {
            if (hg + ag > 2)
            {
                res = 6;
            }
            else
            {
                res = 9;
            }
        }
        SqlConnection REcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);

        REcon.Open();
        string ins = "Update Reliability set Result=@rs where HomeT=@hc and AwayT=@ac";
        SqlCommand cmd1 = new SqlCommand(ins, REcon);
        cmd1.Parameters.AddWithValue("@hc", hc);
        cmd1.Parameters.AddWithValue("@ac", ac);
        cmd1.Parameters.AddWithValue("@rs", res);
        cmd1.ExecuteNonQuery();
        REcon.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Code"]!=null)
        {
            if (Convert.ToInt32(Session["Code"])!=5719)
            {
                Response.Redirect("FrontPage.aspx");
            }
        }
        else
        {
            Response.Redirect("FrontPage.aspx");
        }
        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            con.Open();
            string cm = "select id,name from Teams";
            SqlDataAdapter sda = new SqlDataAdapter(cm, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            DLHomeTeam.DataSource = dt;
            DLHomeTeam.DataValueField = "id";
            DLHomeTeam.DataTextField = "name";
            DLHomeTeam.DataBind();

            DLAwayTeam.DataSource = dt;
            DLAwayTeam.DataValueField = "id";
            DLAwayTeam.DataTextField = "name";
            DLAwayTeam.DataBind();

            TeamsToDropdown(DropDownList1, dt);
            TeamsToDropdown(DropDownList2, dt);
            TeamsToDropdown(DropDownList3, dt);
            TeamsToDropdown(DropDownList4, dt);
            TeamsToDropdown(DropDownList5, dt);
            TeamsToDropdown(DropDownList6, dt);
            TeamsToDropdown(DropDownList7, dt);
            TeamsToDropdown(DropDownList8, dt);
            TeamsToDropdown(DropDownList9, dt);
            TeamsToDropdown(DropDownList10, dt);
            TeamsToDropdown(DropDownList11, dt);
            TeamsToDropdown(DropDownList12, dt);

            TeamsToDropdown(DMdlh, dt);
            TeamsToDropdown(DMdla, dt);
            GridLoad();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(GWeek.Text) && DLHomeTeam.SelectedIndex!=DLAwayTeam.SelectedIndex) {
            int gameweek = Convert.ToInt32(GWeek.Text);
            int dlh = DLHomeTeam.SelectedIndex+1;
            int dla = DLAwayTeam.SelectedIndex+1;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            try
            {
                con.Open();
                string insert = "INSERT INTO GamesPlayed (Gid,HomeT,AwayT,HG,AG) VALUES(@Gid,@HomeT,@AwayT,@HG,@AG)";

                SqlCommand cmd = new SqlCommand(insert, con);
                cmd.Parameters.AddWithValue("@Gid", gameweek);
                cmd.Parameters.AddWithValue("@HomeT", dlh);
                cmd.Parameters.AddWithValue("@AwayT", dla);
                cmd.Parameters.AddWithValue("@HG", Convert.ToInt32(GH.Text));
                cmd.Parameters.AddWithValue("@AG", Convert.ToInt32(GA.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                UpdateTeamsDB(dlh, dla, Convert.ToInt32(GH.Text), Convert.ToInt32(GA.Text));
                CheckLabel1.Text = "Game uploaded!";
                InsToRel(dlh, dla, Convert.ToInt32(GH.Text), Convert.ToInt32(GA.Text));

                con.Open();
                string delete = "delete from DisplayedMatches where HteamC=@htc and AteamC=@atc";
                SqlCommand cmdd = new SqlCommand(delete, con);
                cmdd.Parameters.AddWithValue("@htc", dlh);
                cmdd.Parameters.AddWithValue("@atc", dla);
                cmdd.ExecuteNonQuery();
                con.Close();

                GridLoad();

                Session["HomeTeam"] = DLHomeTeam.SelectedItem.Text.Replace(" ", "").ToString();
                Session["AwayTeam"] = DLAwayTeam.SelectedItem.Text.Replace(" ", "").ToString();
                Session["Hcode"] = DLHomeTeam.SelectedIndex + 1;
                Session["Acode"] = DLAwayTeam.SelectedIndex + 1;
                Session["Gw"] = gameweek;
                Response.Redirect("AddInfo.aspx");
            }
            catch (Exception)
            {
                CheckLabel1.Text = "Error Occurred, insert all fields";
            }           
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);

        if (!string.IsNullOrEmpty(TextBox1.Text) && DropDownList1.SelectedIndex!=DropDownList2.SelectedIndex)
        {
            int gameweek = Convert.ToInt32(TextBox1.Text);
            int htc = DropDownList1.SelectedIndex + 1;
            int atc = DropDownList2.SelectedIndex + 1;
            string htn = DropDownList1.SelectedItem.Text.Replace(" ", "").ToString();
            string atn = DropDownList2.SelectedItem.Text.Replace(" ", "").ToString();
            con.Open();
            string insert = "INSERT INTO DisplayedMatches (Gw,HteamC,AteamC,HteamN,AteamN) VALUES(@gw,@htc,@atc,@htn,@atn)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@gw",gameweek);
            cmd.Parameters.AddWithValue("@htc",htc);
            cmd.Parameters.AddWithValue("@atc",atc);
            cmd.Parameters.AddWithValue("@htn",htn); 
            cmd.Parameters.AddWithValue("@atn",atn);
            cmd.ExecuteNonQuery();
            con.Close();
            CheckLabel2.Text = "Game uploaded!";
        }
        if (!string.IsNullOrEmpty(TextBox2.Text) && DropDownList3.SelectedIndex != DropDownList4.SelectedIndex)
        {
            int gameweek = Convert.ToInt32(TextBox2.Text);
            int htc = DropDownList3.SelectedIndex + 1;
            int atc = DropDownList4.SelectedIndex + 1;
            string htn = DropDownList3.SelectedItem.Text.Replace(" ", "").ToString();
            string atn = DropDownList4.SelectedItem.Text.Replace(" ", "").ToString();
            con.Open();
            string insert = "INSERT INTO DisplayedMatches (Gw,HteamC,AteamC,HteamN,AteamN) VALUES(@gw,@htc,@atc,@htn,@atn)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@gw", gameweek);
            cmd.Parameters.AddWithValue("@htc", htc);
            cmd.Parameters.AddWithValue("@atc", atc);
            cmd.Parameters.AddWithValue("@htn", htn);
            cmd.Parameters.AddWithValue("@atn", atn);
            cmd.ExecuteNonQuery();
            con.Close();
            CheckLabel2.Text = "Game uploaded!";
        }
        if (!string.IsNullOrEmpty(TextBox3.Text) && DropDownList5.SelectedIndex != DropDownList6.SelectedIndex)
        {
            int gameweek = Convert.ToInt32(TextBox3.Text);
            int htc = DropDownList5.SelectedIndex + 1;
            int atc = DropDownList6.SelectedIndex + 1;
            string htn = DropDownList5.SelectedItem.Text.Replace(" ", "").ToString();
            string atn = DropDownList6.SelectedItem.Text.Replace(" ", "").ToString();
            con.Open();
            string insert = "INSERT INTO DisplayedMatches (Gw,HteamC,AteamC,HteamN,AteamN) VALUES(@gw,@htc,@atc,@htn,@atn)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@gw", gameweek);
            cmd.Parameters.AddWithValue("@htc", htc);
            cmd.Parameters.AddWithValue("@atc", atc);
            cmd.Parameters.AddWithValue("@htn", htn);
            cmd.Parameters.AddWithValue("@atn", atn);
            cmd.ExecuteNonQuery();
            con.Close();
            CheckLabel2.Text = "Game uploaded!";
        }
        if (!string.IsNullOrEmpty(TextBox4.Text) && DropDownList7.SelectedIndex != DropDownList8.SelectedIndex)
        {
            int gameweek = Convert.ToInt32(TextBox4.Text);
            int htc = DropDownList7.SelectedIndex + 1;
            int atc = DropDownList8.SelectedIndex + 1;
            string htn = DropDownList7.SelectedItem.Text.Replace(" ", "").ToString();
            string atn = DropDownList8.SelectedItem.Text.Replace(" ", "").ToString();
            con.Open();
            string insert = "INSERT INTO DisplayedMatches (Gw,HteamC,AteamC,HteamN,AteamN) VALUES(@gw,@htc,@atc,@htn,@atn)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@gw", gameweek);
            cmd.Parameters.AddWithValue("@htc", htc);
            cmd.Parameters.AddWithValue("@atc", atc);
            cmd.Parameters.AddWithValue("@htn", htn);
            cmd.Parameters.AddWithValue("@atn", atn);
            cmd.ExecuteNonQuery();
            con.Close();
            CheckLabel2.Text = "Game uploaded!";
        }
        if (!string.IsNullOrEmpty(TextBox5.Text) && DropDownList9.SelectedIndex != DropDownList10.SelectedIndex)
        {
            int gameweek = Convert.ToInt32(TextBox5.Text);
            int htc = DropDownList9.SelectedIndex + 1;
            int atc = DropDownList10.SelectedIndex + 1;
            string htn = DropDownList9.SelectedItem.Text.Replace(" ", "").ToString();
            string atn = DropDownList10.SelectedItem.Text.Replace(" ", "").ToString();
            con.Open();
            string insert = "INSERT INTO DisplayedMatches (Gw,HteamC,AteamC,HteamN,AteamN) VALUES(@gw,@htc,@atc,@htn,@atn)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@gw", gameweek);
            cmd.Parameters.AddWithValue("@htc", htc);
            cmd.Parameters.AddWithValue("@atc", atc);
            cmd.Parameters.AddWithValue("@htn", htn);
            cmd.Parameters.AddWithValue("@atn", atn);
            cmd.ExecuteNonQuery();
            con.Close();
            CheckLabel2.Text = "Game uploaded!";
        }
        if (!string.IsNullOrEmpty(TextBox6.Text) && DropDownList11.SelectedIndex != DropDownList12.SelectedIndex)
        {
            int gameweek = Convert.ToInt32(TextBox6.Text);
            int htc = DropDownList11.SelectedIndex + 1;
            int atc = DropDownList12.SelectedIndex + 1;
            string htn = DropDownList11.SelectedItem.Text.Replace(" ", "").ToString();
            string atn = DropDownList12.SelectedItem.Text.Replace(" ", "").ToString();
            con.Open();
            string insert = "INSERT INTO DisplayedMatches (Gw,HteamC,AteamC,HteamN,AteamN) VALUES(@gw,@htc,@atc,@htn,@atn)";
            SqlCommand cmd = new SqlCommand(insert, con);
            cmd.Parameters.AddWithValue("@gw", gameweek);
            cmd.Parameters.AddWithValue("@htc", htc);
            cmd.Parameters.AddWithValue("@atc", atc);
            cmd.Parameters.AddWithValue("@htn", htn);
            cmd.Parameters.AddWithValue("@atn", atn);
            cmd.ExecuteNonQuery();
            con.Close();
            CheckLabel2.Text = "Game uploaded!";
        }
        GridLoad();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection dcon= new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        dcon.Open();
        string del = "DELETE FROM DisplayedMatches";
        SqlCommand cmd = new SqlCommand(del, dcon);
        cmd.ExecuteNonQuery();
        dcon.Close();
        GridLoad();
    }





    protected void Button4_Click(object sender, EventArgs e)
    {
        Session["Season"] = 5619;
        Response.Redirect("SeasonBegin.aspx");
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(DMt.Text) && DMdlh.SelectedIndex!=DMdla.SelectedIndex)
        {
            int htc = DMdlh.SelectedIndex + 1;
            int atc = DMdla.SelectedIndex + 1;
            SqlConnection dcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            dcon.Open();
            string del = "DELETE FROM DisplayedMatches WHERE gw=@gw AND HteamC=@htc AND AteamC=@atc";
            SqlCommand cmd = new SqlCommand(del, dcon);
            cmd.Parameters.AddWithValue("@gw",DMt.Text);
            cmd.Parameters.AddWithValue("@htc",htc);
            cmd.Parameters.AddWithValue("@atc",atc);
            cmd.ExecuteNonQuery();
            dcon.Close();
            GridLoad();
        }
    }

    protected void Button6_Click(object sender, EventArgs e)
    {
        Session["View"] = 1184;
        Response.Redirect("DataView.aspx");
    }

    protected void Button7_Click(object sender, EventArgs e)
    {
        Session["Man"] = 172;
        Response.Redirect("VCDmanagers.aspx");
    }

    protected void Button8_Click(object sender, EventArgs e)
    {
        Session["txt"] = 73;
        Response.Redirect("ChangeText.aspx");
    }
}