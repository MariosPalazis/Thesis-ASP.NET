using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DataView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (Convert.ToInt32(Session["View"]) != 1184)
            //{
            //    Response.Redirect("ManagersPage.aspx");
            //}
            DataTable table = new DataTable();
            table.Columns.Add("Value", typeof(string));
            table.Columns.Add("Text", typeof(string));
            table.Rows.Add("", "-Select-");
            table.Rows.Add("Teams", "Teams");
            table.Rows.Add("Players", "Players");
            table.Rows.Add("GamesPlayed", "GamesPlayed");
            table.Rows.Add("PlayerOnGame", "PlayerOnGame");
            table.Rows.Add("ArchieveTeam", "ArchieveTeam");
            table.Rows.Add("ArchieveGP", "ArchieveGP");
            table.Rows.Add("Reliability", "Reliability");

            list.DataSource = table;
            list.DataValueField = "Value";
            list.DataTextField = "Text";
            list.DataBind();

            c1.Visible = false;
            c2.Visible = false;
            c3.Visible = false;
            c4.Visible = false;
            c5.Visible = false;
        }
    }

    protected bool Exists(int cd,string tb)
    {
        tb.Replace(" ", "");
        SqlConnection REconn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        REconn.Open();
        string num = "select count(*) from "+tb+" where id="+cd.ToString().Replace(" ","");
        SqlCommand cm = new SqlCommand(num, REconn);
        int count = Convert.ToInt32(cm.ExecuteScalar());

        REconn.Close();

        if (count > 0)
        {
            return true;
        }
        return false;
        
    }

    private void ShowTable(string nm)
    {
        DataTable dt = new DataTable();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        con.Open();
        string cm = "select * from " + nm;
        SqlDataAdapter ad = new SqlDataAdapter();
        ad.SelectCommand = new SqlCommand(cm, con);
        ad.Fill(dt);
        con.Close();
        GridT.DataSource = dt;
        GridT.DataBind();
    }

    protected void ShowDB(object sender, EventArgs e)
    {
        
        if (list.SelectedIndex != 0)
        {
            
            string name = list.SelectedValue.ToString();
            ShowTable(name);

            switch (name)
            {
                case "Teams":
                    c1.Visible=true;
                    c2.Visible = false;
                    c3.Visible = false;
                    c4.Visible = false;
                    c5.Visible = false;
                    break;
                case "Players":
                    c1.Visible = false;
                    c2.Visible = true;
                    c3.Visible = false;
                    c4.Visible = false;
                    c5.Visible = false;
                    break;
                case "GamesPlayed":
                    c1.Visible = false;
                    c2.Visible = false;
                    c3.Visible = true;
                    c4.Visible = false;
                    c5.Visible = false;
                    break;
                case "PlayerOnGame":
                    c1.Visible = false;
                    c2.Visible = false;
                    c3.Visible = false;
                    c4.Visible = true;
                    c5.Visible = false;
                    break;
                case "Reliability":
                    c1.Visible = false;
                    c2.Visible = false;
                    c3.Visible = false;
                    c4.Visible = false;
                    c5.Visible = true;
                    break;
                default:
                    c1.Visible = false;
                    c2.Visible = false;
                    c3.Visible = false;
                    c4.Visible = false;
                    c5.Visible = false;
                    break;
            }
            
        }
        
            
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (list.SelectedIndex != 0)
        {
            string name = list.SelectedValue.ToString();
            DataTable dt = new DataTable();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
            con.Open();
            string cm = "select * from " + name;
            SqlDataAdapter ad = new SqlDataAdapter();
            ad.SelectCommand = new SqlCommand(cm, con);
            ad.Fill(dt);
            con.Close();

            Response.ClearContent();
            Response.AddHeader("content-disposition", string.Format("attachment; filename="+name.Replace(" ","")+".xls"));
            Response.ContentType = "application/vnd.ms-excel";
            string space = "";

            foreach (DataColumn dcolumn in dt.Columns)
            {
                Response.Write(space + dcolumn.ColumnName);
                space = "\t";
            }
            Response.Write("\n");
            foreach (DataRow dr in dt.Rows)
            {
                space = "";
                for (int countcolumn = 0; countcolumn < dt.Columns.Count; countcolumn++)
                {
                    Response.Write(space + dr[countcolumn].ToString());
                    space = "\t";
                }
                Response.Write("\n");
            }
            Response.End();

        }
    }

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
    SqlCommand cmd = new SqlCommand();

    protected void UpT_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(id.Text)&& !string.IsNullOrEmpty(nm.Text) && !string.IsNullOrEmpty(wh.Text) && !string.IsNullOrEmpty(dh.Text) && !string.IsNullOrEmpty(lh.Text) && !string.IsNullOrEmpty(wa.Text) && !string.IsNullOrEmpty(da.Text) && !string.IsNullOrEmpty(la.Text) && !string.IsNullOrEmpty(gih.Text) && !string.IsNullOrEmpty(gah.Text) && !string.IsNullOrEmpty(nick.Text))
        {
            con.Open();
            if (Exists(Convert.ToInt32(id.Text), "Teams")){
                string upT = "UPDATE Teams SET name=@nm, Whome=@wh,Dhome=@dh,Lhome=@lh,Waway=@wa,Daway=@da,Laway=@la,goalinfH=@gih,goalagH=@gah,goalinfA=@gia,goalagA=@gaa,rival=@rv,nickname=@nick WHERE Id=@id";
                cmd = new SqlCommand(upT, con);
                cmd.Parameters.AddWithValue("@nm", nm.Text);
                cmd.Parameters.AddWithValue("@wh", wh.Text);
                cmd.Parameters.AddWithValue("@dh", dh.Text);
                cmd.Parameters.AddWithValue("@lh", lh.Text);
                cmd.Parameters.AddWithValue("@wa", wa.Text);
                cmd.Parameters.AddWithValue("@da", da.Text);
                cmd.Parameters.AddWithValue("@la", la.Text);
                cmd.Parameters.AddWithValue("@gih", gih.Text);
                cmd.Parameters.AddWithValue("@gah", gah.Text);
                cmd.Parameters.AddWithValue("@gia", gia.Text);
                cmd.Parameters.AddWithValue("@gaa", gaa.Text);
                cmd.Parameters.AddWithValue("@rv", riv.Text);
                cmd.Parameters.AddWithValue("@nick", nick.Text);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.ExecuteNonQuery();
                status.Text = "Updated";
            }
            else
            {
                string insT = "INSERT INTO Teams(Id,name,Whome,Dhome,Lhome,Waway,Daway,Laway,goalinfH,goalagH,goalinfA,goalagA,rival,nickname) VALUES(@id,@nm,@wh,@dh,@lh,@wa,@da,@la,@gih,@gah,@gia,@gaa,@rv,@nick)";
                cmd = new SqlCommand(insT, con);
                cmd.Parameters.AddWithValue("id", id.Text);
                cmd.Parameters.AddWithValue("@nm", nm.Text);
                cmd.Parameters.AddWithValue("@wh", wh.Text);
                cmd.Parameters.AddWithValue("@dh", dh.Text);
                cmd.Parameters.AddWithValue("@lh", lh.Text);
                cmd.Parameters.AddWithValue("@wa", wa.Text);
                cmd.Parameters.AddWithValue("@da", da.Text);
                cmd.Parameters.AddWithValue("@la", la.Text);
                cmd.Parameters.AddWithValue("@gih", gih.Text);
                cmd.Parameters.AddWithValue("@gah", gah.Text);
                cmd.Parameters.AddWithValue("@gia", gia.Text);
                cmd.Parameters.AddWithValue("@gaa", gaa.Text);
                cmd.Parameters.AddWithValue("@rv", riv.Text);
                cmd.Parameters.AddWithValue("@nick", nick.Text);
                cmd.ExecuteNonQuery();
                status.Text="Inserted";
            }
            con.Close();
            ShowTable("Teams");
        }
        else
        {
            status.Text = "Please insert all fields";
        }

    }

    protected void DelT_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(id.Text))
        {
            if (Exists(Convert.ToInt32(id.Text), "Teams")){
                con.Open();
                string del = "DELETE FROM Teams WHERE Id=@id";
                cmd = new SqlCommand(del, con);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                status.Text = "Deleted";
            }
            else
            {
                status.Text = "Insert valid Id";
            }
            ShowTable("Teams");
        }
        else
        {
            status.Text = "Select id";
        }
    }

    protected void UpP_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(pid.Text) && !string.IsNullOrEmpty(pNm.Text) && !string.IsNullOrEmpty(pA.Text) && !string.IsNullOrEmpty(pF.Text) && !string.IsNullOrEmpty(pM.Text) && !string.IsNullOrEmpty(pAb.Text) && !string.IsNullOrEmpty(pT.Text))
        {
            con.Open();
            if (Exists(Convert.ToInt32(pid.Text), "Players"))
            {
                string upP = "UPDATE Players SET Name=@pNm,Age=@pA, Form=@pF,Pmins=@pM,Ability=@pAb,Team=@pT WHERE Id=@pid";
                cmd = new SqlCommand(upP, con);
                cmd.Parameters.AddWithValue("@pNm", pNm.Text);
                cmd.Parameters.AddWithValue("@pA", pA.Text);
                cmd.Parameters.AddWithValue("@pF", pF.Text);
                cmd.Parameters.AddWithValue("@pM", pM.Text);
                cmd.Parameters.AddWithValue("@pAb", pAb.Text);
                cmd.Parameters.AddWithValue("@pT", pT.Text);
                cmd.Parameters.AddWithValue("@pid", pid.Text);
                cmd.ExecuteNonQuery();
                status.Text = "Updated";
            }
            else
            {
                string insP = "INSERT INTO Players(Id,Name,Age,Form,Pmins,Ability,Team) VALUES(@pid,@pNm,@pA,@pF,@pM,@pAb,@pT)";
                cmd = new SqlCommand(insP, con);
                cmd.Parameters.AddWithValue("@pid", pid.Text);
                cmd.Parameters.AddWithValue("@pNm", pNm.Text);
                cmd.Parameters.AddWithValue("@pA", pA.Text);
                cmd.Parameters.AddWithValue("@pF", pF.Text);
                cmd.Parameters.AddWithValue("@pM", pM.Text);
                cmd.Parameters.AddWithValue("@pAb", pAb.Text);
                cmd.Parameters.AddWithValue("@pT", pT.Text);
                
                cmd.ExecuteNonQuery();
                status.Text = "Inserted";
            }
            con.Close();
            ShowTable("Players");
        }
        else
        {
            status.Text = "Please insert all fields";
        }
    }

    protected void DelP_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(pid.Text))
        {
            if (Exists(Convert.ToInt32(pid.Text), "Players"))
            {
                con.Open();
                string delP = "DELETE FROM Players WHERE Id=@id";
                cmd = new SqlCommand(delP, con);
                cmd.Parameters.AddWithValue("@id", pid.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                status.Text = "Deleted";
            }
            else
            {
                status.Text = "Insert valid Id";
            }
            ShowTable("Players");
        }
        else
        {
            status.Text = "Select id";
        }
    }

    protected void UpGP_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(gpid.Text) && !string.IsNullOrEmpty(gwgp.Text) && !string.IsNullOrEmpty(htgp.Text) && !string.IsNullOrEmpty(atgp.Text) && !string.IsNullOrEmpty(hggp.Text) && !string.IsNullOrEmpty(aggp.Text))
        {
            con.Open();
            if (Exists(Convert.ToInt32(gpid.Text), "GamesPlayed"))
            {
                string upgp = "UPDATE GamesPlayed SET Gid=@gwgp,HomeT=@htgp, AwayT=@atgp,HG=@hggp,AG=@aggp WHERE Id=@gpid";
                cmd = new SqlCommand(upgp, con);
                cmd.Parameters.AddWithValue("@gwgp", gwgp.Text);
                cmd.Parameters.AddWithValue("@htgp", htgp.Text);
                cmd.Parameters.AddWithValue("@atgp", atgp.Text);
                cmd.Parameters.AddWithValue("@hggp", hggp.Text);
                cmd.Parameters.AddWithValue("@aggp", aggp.Text);
                cmd.Parameters.AddWithValue("@gpid", gpid.Text);
                cmd.ExecuteNonQuery();
                status.Text = "Updated";
            }
            else
            {
                string insgp = "SET IDENTITY_INSERT GamesPlayed ON INSERT INTO GamesPlayed(Id,Gid,HomeT,AwayT,HG,AG) VALUES(@gpid,@gwgp,@htgp,@atgp,@hggp,@aggp) SET IDENTITY_INSERT GamesPlayed OFF";
                cmd = new SqlCommand(insgp, con);
                cmd.Parameters.AddWithValue("@gwgp", gwgp.Text);
                cmd.Parameters.AddWithValue("@htgp", htgp.Text);
                cmd.Parameters.AddWithValue("@atgp", atgp.Text);
                cmd.Parameters.AddWithValue("@hggp", hggp.Text);
                cmd.Parameters.AddWithValue("@aggp", aggp.Text);
                cmd.Parameters.AddWithValue("@gpid", gpid.Text);
                cmd.ExecuteNonQuery();
                status.Text = "Inserted";
            }
            con.Close();
            ShowTable("GamesPlayed");
        }
        else
        {
            status.Text = "Please insert all fields";
        }
    }

    protected void DelGP_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(gpid.Text))
        {
            if (Exists(Convert.ToInt32(gpid.Text), "GamesPlayed"))
            {
                con.Open();
                string delgp = "DELETE FROM GamesPlayed WHERE Id=@id";
                cmd = new SqlCommand(delgp, con);
                cmd.Parameters.AddWithValue("@id", gpid.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                status.Text = "Deleted";
                ShowTable("GamesPlayed");
            }
            else
            {
                status.Text = "Insert valid Id";
            }
        }
        else
        {
            status.Text = "Select id";
        }
    }

    protected void UpPoG_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(idpog.Text) && !string.IsNullOrEmpty(gwpog.Text) && !string.IsNullOrEmpty(ppog.Text) && !string.IsNullOrEmpty(minpog.Text) && !string.IsNullOrEmpty(gpog.Text) && !string.IsNullOrEmpty(cpog.Text) && !string.IsNullOrEmpty(wbpog.Text) && !string.IsNullOrEmpty(rpog.Text))
        {
            con.Open();
            if (Exists(Convert.ToInt32(idpog.Text),"PlayerOnGame"))
            {
                string upgp = "UPDATE PlayerOnGame SET PlayerWeek=@gwpog, Pid=@ppog,mins=@minpog,goal=@gpog,cards=@cpog,winBalls=@wpog,rate=@rpog WHERE id=@idpog";
                cmd = new SqlCommand(upgp, con);
                cmd.Parameters.AddWithValue("@gwpog", gwpog.Text);
                cmd.Parameters.AddWithValue("@ppog", ppog.Text);
                cmd.Parameters.AddWithValue("@minpog", minpog.Text);
                cmd.Parameters.AddWithValue("@gpog", gpog.Text);
                cmd.Parameters.AddWithValue("@cpog", cpog.Text);
                cmd.Parameters.AddWithValue("@wpog", wbpog.Text);
                cmd.Parameters.AddWithValue("@rpog", rpog.Text);
                cmd.Parameters.AddWithValue("@idpog", idpog.Text);
                cmd.ExecuteNonQuery();
                status.Text = "Updated";
            }
            else
            {
                string insgp = "SET IDENTITY_INSERT PlayerOnGame ON INSERT INTO PlayerOnGame(PlayerWeek,Pid,mins,goal,cards,winBalls,rate) VALUES(@gwpog,@ppog,@minpog,@gpog,@cpog,@wpog,@rpog) SET IDENTITY_INSERT PlayerOnGame OFF";
                cmd = new SqlCommand(insgp, con);
                cmd.Parameters.AddWithValue("@gwpog", gwpog.Text);
                cmd.Parameters.AddWithValue("@ppog", ppog.Text);
                cmd.Parameters.AddWithValue("@minpog", minpog.Text);
                cmd.Parameters.AddWithValue("@gpog", gpog.Text);
                cmd.Parameters.AddWithValue("@cpog", cpog.Text);
                cmd.Parameters.AddWithValue("@wpog", wbpog.Text);
                cmd.Parameters.AddWithValue("@rpog", rpog.Text);
                cmd.ExecuteNonQuery();
                status.Text = "Inserted";
            }
            con.Close();
            ShowTable("PlayerOnGame");
        }
        else
        {
            status.Text = "Please insert all fields";
        }
    }

    protected void DelPog_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(idpog.Text))
        {
            if (Exists(Convert.ToInt32(idpog.Text),"PlayerOnGame"))
            {
                con.Open();
                string delpog = "DELETE FROM PlayerOnGame WHERE Id=@id";
                cmd = new SqlCommand(delpog, con);
                cmd.Parameters.AddWithValue("@id", idpog.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                status.Text = "Deleted";
                ShowTable("PlayerOnGame");
            }
            else
            {
                status.Text = "Insert valid Id";
            }
        }
        else
        {
            status.Text = "Select id";
        }
    }

    protected void relU_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(idr.Text) && !string.IsNullOrEmpty(htr.Text) && !string.IsNullOrEmpty(atr.Text) && !string.IsNullOrEmpty(pred.Text) && !string.IsNullOrEmpty(rsl.Text))
        {
            con.Open();
            if (Exists(Convert.ToInt32(idr.Text), "PlayerOnGame"))
            {
                string upgp = "UPDATE Reliability SET HomeT=@htr,AwayT=@atr,Prediction=@pred,Result=@rsl WHERE Id=@idr";
                cmd = new SqlCommand(upgp, con);
                cmd.Parameters.AddWithValue("@htr", htr.Text);
                cmd.Parameters.AddWithValue("@atr", atr.Text);
                cmd.Parameters.AddWithValue("@pred", pred.Text);
                cmd.Parameters.AddWithValue("@rsl", rsl.Text);
                cmd.Parameters.AddWithValue("@idr", idr.Text);
                cmd.ExecuteNonQuery();
                status.Text = "Updated";
            }
            else
            {
                string insgp = "SET IDENTITY_INSERT Reliability ON INSERT INTO Reliability(HomeT,AwayT,Prediction,Result) VALUES(@htr,@atr,@pred,@res) SET IDENTITY_INSERT Reliability OFF";
                cmd = new SqlCommand(insgp, con);
                cmd.Parameters.AddWithValue("@htr", htr.Text);
                cmd.Parameters.AddWithValue("@atr", atr.Text);
                cmd.Parameters.AddWithValue("@pred", pred.Text);
                cmd.Parameters.AddWithValue("@res", rsl.Text);
                cmd.ExecuteNonQuery();
                status.Text = "Inserted";
            }
            con.Close();
            ShowTable("Reliability");
        }
        else
        {
            status.Text = "Please insert all fields";
        }
    }

    protected void relD_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(idr.Text))
        {
            if (Exists(Convert.ToInt32(idr.Text), "Reliability"))
            {
                con.Open();
                string delr = "DELETE FROM Reliability WHERE Id=@id";
                cmd = new SqlCommand(delr, con);
                cmd.Parameters.AddWithValue("@id", idr.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                status.Text = "Deleted";
                ShowTable("Reliability");
            }
            else
            {
                status.Text = "Insert valid Id";
            }
        }
        else
        {
            status.Text = "Select id";
        }
    }

}