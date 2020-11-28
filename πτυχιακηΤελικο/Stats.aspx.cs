using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{

    private void GridTeamsLoad()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        con.Open();
        string cm = "select name, Whome,Dhome,Lhome,Waway,Daway,Laway,goalinfH,goalagH,goalinfA,goalagA from Teams ";
        SqlDataAdapter sda = new SqlDataAdapter(cm, con);
        DataTable dt = new DataTable();
        sda.Fill(dt);

        DataTable finalDT = new DataTable();
        finalDT.Columns.Add("Name", typeof(string));
        finalDT.Columns.Add("Points", typeof(int));
        finalDT.Columns.Add("Wins", typeof(int));
        finalDT.Columns.Add("Draws", typeof(int));
        finalDT.Columns.Add("Defeats", typeof(int));
        finalDT.Columns.Add("Goal's Scored", typeof(int));
        finalDT.Columns.Add("Goal's Conceded", typeof(int));

        for (int i= 0; i < dt.Rows.Count; i++)
        {
            int points =Convert.ToInt32(dt.Rows[i][1]) * 3 + Convert.ToInt32(dt.Rows[i][2]) + Convert.ToInt32(dt.Rows[i][4]) * 3 + Convert.ToInt32(dt.Rows[i][5]);
            int wins = Convert.ToInt32(dt.Rows[i][1]) + Convert.ToInt32(dt.Rows[i][4]);
            int draws = Convert.ToInt32(dt.Rows[i][2]) + Convert.ToInt32(dt.Rows[i][5]);
            int defeats = Convert.ToInt32(dt.Rows[i][3]) + Convert.ToInt32(dt.Rows[i][6]);
            int gS = Convert.ToInt32(dt.Rows[i][7]) + Convert.ToInt32(dt.Rows[i][9]);
            int gC = Convert.ToInt32(dt.Rows[i][8]) + Convert.ToInt32(dt.Rows[i][10]);

            finalDT.Rows.Add(dt.Rows[i][0].ToString(), points, wins, draws, defeats, gS,gC);

        }
        finalDT.DefaultView.Sort = "Points desc";
        finalDT = finalDT.DefaultView.ToTable();
        TeamRank.DataSource = finalDT;
        TeamRank.DataBind();
        con.Close();
    }

    private void GridscorersLoad()
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        con1.Open();
        string cm1 = "SELECT DISTINCT TOP 10 Players.Name , sum(goal) as goals FROM Players join PlayerOnGame on Players.Id = PlayerOnGame.Pid GROUP BY Name ORDER BY goals DESC";
        SqlDataAdapter sda1 = new SqlDataAdapter(cm1, con1);
        DataTable dt1 = new DataTable();
        sda1.Fill(dt1);
        Scorers.DataSource = dt1;
        Scorers.DataBind();
        con1.Close();
    }

    private string CodeToName(int cd)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        con.Open();
        string change = "select name from Teams where Id=@id";
        SqlCommand cmd = new SqlCommand(change, con);
        cmd.Parameters.AddWithValue("id", cd);
        string x=cmd.ExecuteScalar().ToString();
        con.Close();
        return x;
    }

    private void TeamsPlayedGames(int teamCode)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        con.Open();
        SqlDataAdapter ad = new SqlDataAdapter();
        ad.SelectCommand = new SqlCommand("select Gid,HomeT,AwayT,HG,AG from GamesPlayed where HomeT=@code OR AwayT=@code", con);
        ad.SelectCommand.Parameters.AddWithValue("@code", teamCode);
        DataTable dt = new DataTable();
        ad.Fill(dt);
        con.Close();
        DataTable Fdt = new DataTable();
        Fdt.Columns.Add("GameWeek", typeof(int));
        Fdt.Columns.Add("Home", typeof(string));
        Fdt.Columns.Add("Away", typeof(string));
        Fdt.Columns.Add("Home goals", typeof(int));
        Fdt.Columns.Add("Away goals", typeof(int));

        for (int i= 0; i < dt.Rows.Count; i++)
        {
            Fdt.Rows.Add(Convert.ToInt32(dt.Rows[i][0]), CodeToName(Convert.ToInt32(dt.Rows[i][1])), CodeToName(Convert.ToInt32(dt.Rows[i][2])), Convert.ToInt32(dt.Rows[i][3]), Convert.ToInt32(dt.Rows[i][4]));
        }
        teamsgames.DataSource = Fdt;
        teamsgames.DataBind();
       
    }

    private void CreateDropdown(int cd)
    {
        SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);

        con1.Open();
        string cm = "select id,name from Players where Team=@cd";
        SqlDataAdapter sda = new SqlDataAdapter();
        sda.SelectCommand = new SqlCommand(cm, con1);
        sda.SelectCommand.Parameters.AddWithValue("@cd",cd);
        DataTable dt1 = new DataTable();
        sda.Fill(dt1);
        con1.Close();
        DataRow frow = dt1.NewRow();
        frow["Id"] = 0;
        frow["Name"] = "Select Player";
        dt1.Rows.InsertAt(frow, 0);
        Pname.DataSource = dt1;
        Pname.DataValueField = "Id";
        Pname.DataTextField = "Name";
        Pname.DataBind();
    }

    private void CreatePlayerGrid(string cd)
    {
        SqlConnection conpp = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        conpp.Open();
        SqlDataAdapter ad1 = new SqlDataAdapter();
        ad1.SelectCommand = new SqlCommand("select PlayerWeek,mins,goal,cards,winBalls,rate from PlayerOnGame where Pid=@code", conpp);
        ad1.SelectCommand.Parameters.AddWithValue("@code", cd);
        DataTable dt4 = new DataTable();
        ad1.Fill(dt4);
        conpp.Close();
        PlayerGames.DataSource = dt4;
        PlayerGames.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            GridTeamsLoad();
            GridscorersLoad();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);

            con.Open();
            string cm = "select id,name from Teams";
            SqlDataAdapter sda = new SqlDataAdapter(cm, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            DataRow frow = dt.NewRow();
            frow["id"] = 0;
            frow["name"] = "Select Team";
            dt.Rows.InsertAt(frow, 0);
            TeamsG.DataSource = dt;
            TeamsG.DataValueField = "id";
            TeamsG.DataTextField = "name";
            TeamsG.DataBind();

            Pteam.DataSource = dt;
            Pteam.DataValueField = "id";
            Pteam.DataTextField = "name";
            Pteam.DataBind();

            Pname.Visible = false;
        }
    }

    protected void up_grid (object sender, EventArgs e)
    {
        if (TeamsG.SelectedIndex != 0)
        {
            TeamsPlayedGames(TeamsG.SelectedIndex);
        }
    }



    protected void TeamsDropChanged(object sender, EventArgs e)
    {
        TeamsPlayedGames(TeamsG.SelectedIndex);
    }

    protected void PlayerDrop1Changed(object sender, EventArgs e)
    {
        if (Pname.Visible == false && Pteam.SelectedIndex!=0)
        {
            CreateDropdown(Pteam.SelectedIndex);
            Pname.Visible = true;
        }
        if (Pname.Visible == true && Pteam.SelectedIndex != 0)
        {
            CreateDropdown(Pteam.SelectedIndex);
            Pname.Visible = true;
        }
        if (Pteam.SelectedIndex == 0)
        {
            Pname.Visible = false;
        }
    }
    protected void PlayerDrop2Changed(object sender, EventArgs e)
    {
        if(Pname.SelectedIndex!=0 && Pteam.SelectedIndex != 0)
        {
            CreatePlayerGrid(Pname.SelectedValue);
        }
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