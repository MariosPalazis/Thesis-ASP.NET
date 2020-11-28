using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AddInfo : System.Web.UI.Page
{
    
    private DropDownList TeamsToDropDown(DropDownList ddl, DataTable d)
    {
        ddl.DataSource = d;
        ddl.DataValueField = "id";
        ddl.DataTextField = "name";
        ddl.TabIndex = 0;
        ddl.DataBind();
        return ddl;
    }
    
    private void InsertPlayersStat(int gw, int cd,int mins, int goals, int cards, int wb, int rate)
    {
        if (cards > 2)
        {
            cards = 2;
        }
        if (mins < 0)
        {
            mins = 0;
        }
        if (goals < 0)
        {
            goals = 0;
        }
        if (cards < 0)
        {
            cards = 0;
        }
        if (wb < 0)
        {
            wb = 0;
        }
        if (rate < 0)
        {
            rate = 0;
        }
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        con.Open();
        string insert = "INSERT INTO PlayerOnGame (PlayerWeek,Pid,mins,goal,cards,winBalls,rate) VALUES(@gw,@cd,@mins,@goal,@cards,@winBalls,@rate)";
        SqlCommand cmd = new SqlCommand(insert, con);
        cmd.Parameters.AddWithValue("@gw", gw);
        cmd.Parameters.AddWithValue("@cd", cd);
        cmd.Parameters.AddWithValue("@mins", mins);
        cmd.Parameters.AddWithValue("@goal", goals);
        cmd.Parameters.AddWithValue("@cards", cards);
        cmd.Parameters.AddWithValue("@winBalls", wb);
        cmd.Parameters.AddWithValue("@rate", rate);
        cmd.ExecuteNonQuery();
        con.Close();
    }

    private void UpdatePlayersDB(int cd,int mins, int rate)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        con.Open();
        string select = "select avg(rate) from PlayerOnGame where Pid=@pid";
        SqlCommand cmd = new SqlCommand(select, con);
        cmd.Parameters.AddWithValue("@pid",cd);
       
        decimal avg = Convert.ToDecimal(cmd.ExecuteScalar());

        string insert= "update Players set Form=@avg , Pmins=Pmins+@mins where Id=@pid1";
        SqlCommand cmd1 = new SqlCommand(insert, con);
        cmd1.Parameters.AddWithValue("@avg", Convert.ToDecimal(avg));
        cmd1.Parameters.AddWithValue("@mins", mins);
        cmd1.Parameters.AddWithValue("@pid1", cd);
        cmd1.ExecuteNonQuery();
        con.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["HomeTeam"] != null && Session["AwayTeam"] != null)
            {
                Label1Panel.Text = Session["HomeTeam"].ToString();
                Label2Panel.Text = Session["AwayTeam"].ToString();
                ImpHome.Text= Session["HomeTeam"].ToString();
                ImpAway.Text= Session["AwayTeam"].ToString();
                int Hcode = Convert.ToInt32(Session["Hcode"]);
                int Acode = Convert.ToInt32(Session["Acode"]);
                

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
                con.Open();
                SqlDataAdapter ad1 = new SqlDataAdapter();
                ad1.SelectCommand = new SqlCommand("select Id,Name from Players where Team=@Hcode", con);
                ad1.SelectCommand.Parameters.AddWithValue("@Hcode", Hcode);
                con.Close();
                DataTable dt1 = new DataTable();
                ad1.Fill(dt1);
                DataRow rw1 = dt1.NewRow();
                rw1["Id"] = 0;
                rw1["Name"] = "Select Player";
                dt1.Rows.InsertAt(rw1, 0);

                con.Open();
                SqlDataAdapter ad2 = new SqlDataAdapter();
                ad2.SelectCommand = new SqlCommand("select Id,Name from Players where Team=@Acode", con);
                ad2.SelectCommand.Parameters.AddWithValue("@Acode", Acode);
                con.Close();
                DataTable dt2 = new DataTable();
                ad2.Fill(dt2);
                DataRow rw2 = dt2.NewRow();
                rw2["Id"] = 0;
                rw2["Name"] = "Select Player";
                dt2.Rows.InsertAt(rw2, 0);

                TeamsToDropDown(DropDownList1, dt1);
                TeamsToDropDown(DropDownList2, dt1);
                TeamsToDropDown(DropDownList3, dt1);
                TeamsToDropDown(DropDownList4, dt1);
                TeamsToDropDown(DropDownList5, dt1);
                TeamsToDropDown(DropDownList6, dt1);
                TeamsToDropDown(DropDownList7, dt1);
                TeamsToDropDown(DropDownList8, dt1);
                TeamsToDropDown(DropDownList9, dt1);
                TeamsToDropDown(DropDownList10, dt1);
                TeamsToDropDown(DropDownList11, dt1);
                TeamsToDropDown(DropDownList12, dt1);
                TeamsToDropDown(DropDownList13, dt1);
                TeamsToDropDown(DropDownList14, dt1);

                TeamsToDropDown(DropDownList15, dt2);
                TeamsToDropDown(DropDownList16, dt2);
                TeamsToDropDown(DropDownList17, dt2);
                TeamsToDropDown(DropDownList18, dt2);
                TeamsToDropDown(DropDownList19, dt2);
                TeamsToDropDown(DropDownList20, dt2);
                TeamsToDropDown(DropDownList21, dt2);
                TeamsToDropDown(DropDownList22, dt2);
                TeamsToDropDown(DropDownList23, dt2);
                TeamsToDropDown(DropDownList24, dt2);
                TeamsToDropDown(DropDownList25, dt2);
                TeamsToDropDown(DropDownList26, dt2);
                TeamsToDropDown(DropDownList27, dt2);
                TeamsToDropDown(DropDownList28, dt2);
            }
            else
            {
                Response.Redirect("ManagersPage.aspx");
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int gameweek = Convert.ToInt32(Session["Gw"]);
        try
        {
            if (DropDownList1.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox2.Text), Convert.ToInt32(TextBox3.Text), Convert.ToInt32(TextBox4.Text), Convert.ToInt32(TextBox5.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList1.SelectedValue), Convert.ToInt32(TextBox1.Text), Convert.ToInt32(TextBox5.Text));
            }
            if (DropDownList2.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(TextBox6.Text), Convert.ToInt32(TextBox7.Text), Convert.ToInt32(TextBox8.Text), Convert.ToInt32(TextBox9.Text), Convert.ToInt32(TextBox10.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList2.SelectedValue), Convert.ToInt32(TextBox6.Text), Convert.ToInt32(TextBox10.Text));
            }
            if (DropDownList3.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList3.SelectedValue), Convert.ToInt32(TextBox11.Text), Convert.ToInt32(TextBox12.Text), Convert.ToInt32(TextBox13.Text), Convert.ToInt32(TextBox14.Text), Convert.ToInt32(TextBox15.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList3.SelectedValue), Convert.ToInt32(TextBox11.Text), Convert.ToInt32(TextBox15.Text));
            }
            if (DropDownList4.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList4.SelectedValue), Convert.ToInt32(TextBox16.Text), Convert.ToInt32(TextBox17.Text), Convert.ToInt32(TextBox18.Text), Convert.ToInt32(TextBox19.Text), Convert.ToInt32(TextBox20.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList4.SelectedValue), Convert.ToInt32(TextBox16.Text), Convert.ToInt32(TextBox20.Text));
            }
            if (DropDownList5.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList5.SelectedValue), Convert.ToInt32(TextBox21.Text), Convert.ToInt32(TextBox22.Text), Convert.ToInt32(TextBox23.Text), Convert.ToInt32(TextBox24.Text), Convert.ToInt32(TextBox25.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList5.SelectedValue), Convert.ToInt32(TextBox21.Text), Convert.ToInt32(TextBox25.Text));
            }
            if (DropDownList6.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList6.SelectedValue), Convert.ToInt32(TextBox26.Text), Convert.ToInt32(TextBox27.Text), Convert.ToInt32(TextBox28.Text), Convert.ToInt32(TextBox29.Text), Convert.ToInt32(TextBox30.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList6.SelectedValue), Convert.ToInt32(TextBox26.Text), Convert.ToInt32(TextBox30.Text));
            }
            if (DropDownList7.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList7.SelectedValue), Convert.ToInt32(TextBox31.Text), Convert.ToInt32(TextBox32.Text), Convert.ToInt32(TextBox33.Text), Convert.ToInt32(TextBox34.Text), Convert.ToInt32(TextBox35.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList7.SelectedValue), Convert.ToInt32(TextBox31.Text), Convert.ToInt32(TextBox35.Text));
            }
            if (DropDownList8.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList8.SelectedValue), Convert.ToInt32(TextBox36.Text), Convert.ToInt32(TextBox37.Text), Convert.ToInt32(TextBox38.Text), Convert.ToInt32(TextBox39.Text), Convert.ToInt32(TextBox40.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList8.SelectedValue), Convert.ToInt32(TextBox36.Text), Convert.ToInt32(TextBox40.Text));
            }
            if (DropDownList9.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList9.SelectedValue), Convert.ToInt32(TextBox41.Text), Convert.ToInt32(TextBox42.Text), Convert.ToInt32(TextBox43.Text), Convert.ToInt32(TextBox44.Text), Convert.ToInt32(TextBox45.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList9.SelectedValue), Convert.ToInt32(TextBox41.Text), Convert.ToInt32(TextBox45.Text));
            }
            if (DropDownList10.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList10.SelectedValue), Convert.ToInt32(TextBox46.Text), Convert.ToInt32(TextBox47.Text), Convert.ToInt32(TextBox48.Text), Convert.ToInt32(TextBox49.Text), Convert.ToInt32(TextBox50.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList10.SelectedValue), Convert.ToInt32(TextBox46.Text), Convert.ToInt32(TextBox50.Text));
            }
            if (DropDownList11.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList11.SelectedValue), Convert.ToInt32(TextBox51.Text), Convert.ToInt32(TextBox52.Text), Convert.ToInt32(TextBox53.Text), Convert.ToInt32(TextBox54.Text), Convert.ToInt32(TextBox55.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList11.SelectedValue), Convert.ToInt32(TextBox51.Text), Convert.ToInt32(TextBox55.Text));
            }
            if (DropDownList12.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList12.SelectedValue), Convert.ToInt32(TextBox56.Text), Convert.ToInt32(TextBox57.Text), Convert.ToInt32(TextBox58.Text), Convert.ToInt32(TextBox59.Text), Convert.ToInt32(TextBox60.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList12.SelectedValue), Convert.ToInt32(TextBox56.Text), Convert.ToInt32(TextBox60.Text));
            }
            if (DropDownList13.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList13.SelectedValue), Convert.ToInt32(TextBox61.Text), Convert.ToInt32(TextBox62.Text), Convert.ToInt32(TextBox63.Text), Convert.ToInt32(TextBox64.Text), Convert.ToInt32(TextBox65.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList13.SelectedValue), Convert.ToInt32(TextBox61.Text), Convert.ToInt32(TextBox65.Text));
            }
            if (DropDownList14.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList14.SelectedValue), Convert.ToInt32(TextBox66.Text), Convert.ToInt32(TextBox67.Text), Convert.ToInt32(TextBox68.Text), Convert.ToInt32(TextBox69.Text), Convert.ToInt32(TextBox70.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList14.SelectedValue), Convert.ToInt32(TextBox66.Text), Convert.ToInt32(TextBox70.Text));
            }
        }
        catch(Exception)
        {
            Status1.Text = "Error occurred. Insert all fields";
        }

        try { 
            if (DropDownList15.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList15.SelectedValue), Convert.ToInt32(TextBox71.Text), Convert.ToInt32(TextBox72.Text), Convert.ToInt32(TextBox73.Text), Convert.ToInt32(TextBox74.Text), Convert.ToInt32(TextBox75.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList15.SelectedValue), Convert.ToInt32(TextBox71.Text), Convert.ToInt32(TextBox75.Text));
            }
            if (DropDownList16.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList16.SelectedValue), Convert.ToInt32(TextBox76.Text), Convert.ToInt32(TextBox77.Text), Convert.ToInt32(TextBox78.Text), Convert.ToInt32(TextBox79.Text), Convert.ToInt32(TextBox80.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList16.SelectedValue), Convert.ToInt32(TextBox76.Text), Convert.ToInt32(TextBox80.Text));
            }
            if (DropDownList17.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList17.SelectedValue), Convert.ToInt32(TextBox81.Text), Convert.ToInt32(TextBox82.Text), Convert.ToInt32(TextBox83.Text), Convert.ToInt32(TextBox84.Text), Convert.ToInt32(TextBox85.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList17.SelectedValue), Convert.ToInt32(TextBox81.Text), Convert.ToInt32(TextBox85.Text));
            }
            if (DropDownList18.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList18.SelectedValue), Convert.ToInt32(TextBox86.Text), Convert.ToInt32(TextBox87.Text), Convert.ToInt32(TextBox88.Text), Convert.ToInt32(TextBox89.Text), Convert.ToInt32(TextBox90.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList18.SelectedValue), Convert.ToInt32(TextBox86.Text), Convert.ToInt32(TextBox90.Text));
            }
            if (DropDownList19.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList19.SelectedValue), Convert.ToInt32(TextBox91.Text), Convert.ToInt32(TextBox92.Text), Convert.ToInt32(TextBox93.Text), Convert.ToInt32(TextBox94.Text), Convert.ToInt32(TextBox95.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList19.SelectedValue), Convert.ToInt32(TextBox91.Text), Convert.ToInt32(TextBox95.Text));
            }
            if (DropDownList20.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList20.SelectedValue), Convert.ToInt32(TextBox96.Text), Convert.ToInt32(TextBox97.Text), Convert.ToInt32(TextBox98.Text), Convert.ToInt32(TextBox99.Text), Convert.ToInt32(TextBox100.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList20.SelectedValue), Convert.ToInt32(TextBox96.Text), Convert.ToInt32(TextBox100.Text));
            }
            if (DropDownList21.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList21.SelectedValue), Convert.ToInt32(TextBox101.Text), Convert.ToInt32(TextBox102.Text), Convert.ToInt32(TextBox103.Text), Convert.ToInt32(TextBox104.Text), Convert.ToInt32(TextBox105.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList21.SelectedValue), Convert.ToInt32(TextBox101.Text), Convert.ToInt32(TextBox105.Text));
            }
            if (DropDownList22.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList22.SelectedValue), Convert.ToInt32(TextBox106.Text), Convert.ToInt32(TextBox107.Text), Convert.ToInt32(TextBox108.Text), Convert.ToInt32(TextBox109.Text), Convert.ToInt32(TextBox110.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList22.SelectedValue), Convert.ToInt32(TextBox106.Text), Convert.ToInt32(TextBox110.Text));
            }
            if (DropDownList23.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList23.SelectedValue), Convert.ToInt32(TextBox111.Text), Convert.ToInt32(TextBox112.Text), Convert.ToInt32(TextBox113.Text), Convert.ToInt32(TextBox114.Text), Convert.ToInt32(TextBox115.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList23.SelectedValue), Convert.ToInt32(TextBox111.Text), Convert.ToInt32(TextBox115.Text));
            }
            if (DropDownList24.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList24.SelectedValue), Convert.ToInt32(TextBox116.Text), Convert.ToInt32(TextBox117.Text), Convert.ToInt32(TextBox118.Text), Convert.ToInt32(TextBox119.Text), Convert.ToInt32(TextBox120.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList24.SelectedValue), Convert.ToInt32(TextBox116.Text), Convert.ToInt32(TextBox120.Text));
            }
            if (DropDownList25.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList25.SelectedValue), Convert.ToInt32(TextBox121.Text), Convert.ToInt32(TextBox122.Text), Convert.ToInt32(TextBox123.Text), Convert.ToInt32(TextBox124.Text), Convert.ToInt32(TextBox125.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList25.SelectedValue), Convert.ToInt32(TextBox121.Text), Convert.ToInt32(TextBox125.Text));
            }
            if (DropDownList26.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList26.SelectedValue), Convert.ToInt32(TextBox126.Text), Convert.ToInt32(TextBox127.Text), Convert.ToInt32(TextBox128.Text), Convert.ToInt32(TextBox129.Text), Convert.ToInt32(TextBox130.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList26.SelectedValue), Convert.ToInt32(TextBox126.Text), Convert.ToInt32(TextBox130.Text));
            }
            if (DropDownList27.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList27.SelectedValue), Convert.ToInt32(TextBox130.Text), Convert.ToInt32(TextBox132.Text), Convert.ToInt32(TextBox133.Text), Convert.ToInt32(TextBox134.Text), Convert.ToInt32(TextBox135.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList27.SelectedValue), Convert.ToInt32(TextBox130.Text), Convert.ToInt32(TextBox135.Text));
            }
            if (DropDownList28.SelectedIndex != 0)
            {
                InsertPlayersStat(gameweek, Convert.ToInt32(DropDownList28.SelectedValue), Convert.ToInt32(TextBox136.Text), Convert.ToInt32(TextBox137.Text), Convert.ToInt32(TextBox138.Text), Convert.ToInt32(TextBox139.Text), Convert.ToInt32(TextBox140.Text));
                UpdatePlayersDB(Convert.ToInt32(DropDownList28.SelectedValue), Convert.ToInt32(TextBox136.Text), Convert.ToInt32(TextBox140.Text));
            }
        }
        catch (Exception)
        {
            Status2.Text = "Error occurred. Insert all fields";
        }
        DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/CsvDatas/"));
        EmptyFolder(directory);
        Response.Redirect("ManagersPage.aspx");
    }
    private void EmptyFolder(DirectoryInfo directory)
    {
        foreach (FileInfo file in directory.GetFiles())
        {
            file.Delete();
        }

        foreach (DirectoryInfo subdirectory in directory.GetDirectories())
        {
            EmptyFolder(subdirectory);
            subdirectory.Delete();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        importPanel.Attributes.Add("style", "visibility: visible");
    }

    protected void Upload_Click(object sender, EventArgs e)
    {
        if(FileUpload1.HasFile && FileUpload2.HasFile)
        {
            DataTable HomeT = new DataTable();
            DataTable AwayT = new DataTable();
            string csvPath = Server.MapPath("~/CsvDatas/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
            FileUpload1.PostedFile.SaveAs(csvPath);
            HomeT.Columns.Add("PlayerWeek", typeof(int));
            HomeT.Columns.Add("Pid", typeof(int));
            HomeT.Columns.Add("mins", typeof(int));
            HomeT.Columns.Add("goal", typeof(int));
            HomeT.Columns.Add("cards", typeof(int));
            HomeT.Columns.Add("winBalls", typeof(int));
            HomeT.Columns.Add("rate", typeof(int));

            string csvData = File.ReadAllText(csvPath);
            foreach (string row in csvData.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    HomeT.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split(';'))
                    {
                        HomeT.Rows[HomeT.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }


            string csvPath1 = Server.MapPath("~/CsvDatas/") + Path.GetFileName(FileUpload2.PostedFile.FileName);
            FileUpload2.PostedFile.SaveAs(csvPath1);
            AwayT.Columns.Add("PlayerWeek", typeof(int));
            AwayT.Columns.Add("Pid", typeof(int));
            AwayT.Columns.Add("mins", typeof(int));
            AwayT.Columns.Add("goal", typeof(int));
            AwayT.Columns.Add("cards", typeof(int));
            AwayT.Columns.Add("winBalls", typeof(int));
            AwayT.Columns.Add("rate", typeof(int));

            string csvData1 = File.ReadAllText(csvPath1);
            foreach (string row in csvData1.Split('\n'))
            {
                if (!string.IsNullOrEmpty(row))
                {
                    AwayT.Rows.Add();
                    int i = 0;
                    foreach (string cell in row.Split(';'))
                    {
                        AwayT.Rows[AwayT.Rows.Count - 1][i] = cell;
                        i++;
                    }
                }
            }

            

            foreach (DataRow rw in HomeT.Rows)
            {              
                InsertPlayersStat(Convert.ToInt32(rw["PlayerWeek"]), Convert.ToInt32(rw["Pid"]), Convert.ToInt32(rw["mins"]), Convert.ToInt32(rw["goal"]), Convert.ToInt32(rw["cards"]), Convert.ToInt32(rw["winBalls"]), Convert.ToInt32(rw["rate"]));
                UpdatePlayersDB(Convert.ToInt32(rw["Pid"]), Convert.ToInt32(rw["mins"]), Convert.ToInt32(rw["rate"]));
            }
            foreach (DataRow rw in AwayT.Rows)
            {
                InsertPlayersStat(Convert.ToInt32(rw["PlayerWeek"]), Convert.ToInt32(rw["Pid"]), Convert.ToInt32(rw["mins"]), Convert.ToInt32(rw["goal"]), Convert.ToInt32(rw["cards"]), Convert.ToInt32(rw["winBalls"]), Convert.ToInt32(rw["rate"]));
                UpdatePlayersDB(Convert.ToInt32(rw["Pid"]), Convert.ToInt32(rw["mins"]), Convert.ToInt32(rw["rate"]));
            }
            importPanel.Attributes.Add("style", "visibility: hidden");
        }
        else
        {
            status.Text = "Please insert 2 .csv files";
        }
    }

    protected void Close_Click(object sender, EventArgs e)
    {
        importPanel.Attributes.Add("style", "visibility: hidden");
    }
}