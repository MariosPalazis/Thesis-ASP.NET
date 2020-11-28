using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrondPage : System.Web.UI.Page
{
    SqlConnection mcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);

    private int setMiniDivsH()
    {
        string[] HTnames = new string[6] {"","","","","",""};
        string[] ATnames = new string[6] {"","","","","",""};
        

        mcon.Open();
        string take = "select HteamN,AteamN,HteamC,AteamC from DisplayedMatches";
        SqlCommand cmd = new SqlCommand(take, mcon);
        SqlDataReader reader = cmd.ExecuteReader();
        int i = 0;
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                HTnames[i] = reader.GetString(0);
                ATnames[i] = reader.GetString(1);
                i++;
                
                switch (i)
                {
                    case 1:
                        SetMiniDivsP(reader.GetInt32(2), reader.GetInt32(3), Pre1,1);
                        break;
                    case 2:
                        SetMiniDivsP(reader.GetInt32(2), reader.GetInt32(3), Pre2,2);
                        break;
                    case 3:
                        SetMiniDivsP(reader.GetInt32(2), reader.GetInt32(3), Pre3,3);
                        break;
                    case 4:
                        SetMiniDivsP(reader.GetInt32(2), reader.GetInt32(3), Pre4,4);
                        break;
                    case 5:
                        SetMiniDivsP(reader.GetInt32(2), reader.GetInt32(3), Pre5,5);
                        break;
                    case 6:
                        SetMiniDivsP(reader.GetInt32(2), reader.GetInt32(3), Pre6,6);
                        break;
                    default:
                        break;
                }
            }
        }        
        mcon.Close();
        Label1.Text = HTnames[0].ToString();
        Label2.Text = ATnames[0].ToString();
        Label3.Text = HTnames[1].ToString();
        Label4.Text = ATnames[1].ToString();
        Label5.Text = HTnames[2].ToString();
        Label6.Text = ATnames[2].ToString();
        Label7.Text = HTnames[3].ToString();
        Label8.Text = ATnames[3].ToString();
        Label9.Text = HTnames[4].ToString();
        Label10.Text = ATnames[4].ToString();
        Label11.Text = HTnames[5].ToString();
        Label12.Text = ATnames[5].ToString();

        return i;
    }

    private void ShowHideDiv(int Num)
    {
        g1.Visible = false;
        g2.Visible = false;
        g3.Visible = false;
        g4.Visible = false;
        g5.Visible = false;
        g6.Visible = false;
        if (Num >= 1)
        {
            g1.Visible = true;
        }
        if (Num >= 2)
        {
            g2.Visible = true;
        }
        if (Num >= 3)
        {
            g3.Visible = true;
        }
        if (Num >= 4)
        {
            g4.Visible = true;
        }
        if (Num >= 5)
        {
            g5.Visible = true;
        }
        if (Num == 6)
        {
            g6.Visible = true;
        }
    }

    private void setMiniDivsText(string text,int Num)
    {
        switch (Num)
        {
            case 1:
                p1.InnerText = text;
                break;
            case 2:
                p2.InnerText = text;
                break;
            case 3:
                p3.InnerText = text;
                break;
            case 4:
                p4.InnerText = text;
                break;
            case 5:
                p5.InnerText = text;
                break;
            default:
                p6.InnerText = text;
                break;
        }
    }

    private int CreatePrediction(int HomeC,int AwayC,int NumP)
    {
        SqlConnection REcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);

        int HTwh =0, HTdh=0, HTlh=0, HTwa=0, HTda=0, HTla=0, HTgih=0, HTgah=0, HTgia=0, HTgaa=0, ATwh=0, ATdh=0, ATlh=0, ATwa=0, ATda=0, ATla=0, ATgih=0, ATgah=0, ATgia=0, ATgaa=0, rivalH=0,rivalA=0;
        double HPage=0, HPform=0, HPability=0, APage=0, APform=0, APability=0;
        string nicknameH = "",nicknameA="";
        REcon.Open();
        string BringT = "select Whome,Dhome,Lhome,Waway,Daway,Laway,goalinfH,goalagH,goalinfA,goalagA,rival,nickname from Teams where Id=@id";
        SqlCommand cmd1 = new SqlCommand(BringT, REcon);
        cmd1.Parameters.AddWithValue("@id", HomeC);
        SqlDataReader reader1 = cmd1.ExecuteReader();
        if (reader1.HasRows)
        {
            while (reader1.Read())
            {
                HTwh = reader1.GetInt32(0);
                HTdh = reader1.GetInt32(1);
                HTlh = reader1.GetInt32(2);
                HTwa = reader1.GetInt32(3);
                HTda = reader1.GetInt32(4);
                HTla = reader1.GetInt32(5);
                HTgih = reader1.GetInt32(6);
                HTgah = reader1.GetInt32(7);
                HTgia = reader1.GetInt32(8);
                HTgaa = reader1.GetInt32(9);
                if (!reader1.IsDBNull(10))
                {
                    rivalH = reader1.GetInt32(10);
                }
                nicknameH = reader1.GetString(11);
            }
        }
        reader1.Close();
        REcon.Close();

        REcon.Open();
        BringT = "select Whome,Dhome,Lhome,Waway,Daway,Laway,goalinfH,goalagH,goalinfA,goalagA,rival,nickname from Teams where Id=@id";
        cmd1 = new SqlCommand(BringT, REcon);
        cmd1.Parameters.AddWithValue("@id", AwayC);
        reader1 = cmd1.ExecuteReader();
        if (reader1.HasRows)
        {
            while (reader1.Read())
            {
                ATwh = reader1.GetInt32(0);
                ATdh = reader1.GetInt32(1);
                ATlh = reader1.GetInt32(2);
                ATwa = reader1.GetInt32(3);
                ATda = reader1.GetInt32(4);
                ATla = reader1.GetInt32(5);
                ATgih = reader1.GetInt32(6);
                ATgah = reader1.GetInt32(7);
                ATgia = reader1.GetInt32(8);
                ATgaa = reader1.GetInt32(9);
                if (!reader1.IsDBNull(10))
                {
                    rivalA = reader1.GetInt32(10);
                }
                nicknameA = reader1.GetString(11);
            }
        }
        REcon.Close();

        REcon.Open();
        string BringP = "select avg(Age),avg(Form),avg(Ability) from Players where Team=@team";
        cmd1 = new SqlCommand(BringP, REcon);
        cmd1.Parameters.AddWithValue("@team", HomeC);
        
        reader1 = cmd1.ExecuteReader();
        if (reader1.HasRows)
        {
            while (reader1.Read())
            {
                HPage =Convert.ToDouble(reader1.GetValue(0));
                HPform= Convert.ToDouble(reader1.GetValue(1));
                HPability = Convert.ToDouble(reader1.GetValue(2));
            }
        }
        REcon.Close();

        REcon.Open();
        BringP = "select avg(Age),avg(Form),avg(Ability) from Players where Team=@team";
        cmd1 = new SqlCommand(BringP, REcon);
        cmd1.Parameters.AddWithValue("@team", AwayC);
        reader1 = cmd1.ExecuteReader();
        if (reader1.HasRows)
        {
            while (reader1.Read())
            {
                APage = Convert.ToDouble(reader1.GetValue(0));
                APform = Convert.ToDouble(reader1.GetValue(1));
                APability = Convert.ToDouble(reader1.GetValue(2));
            }
        }
        REcon.Close();

        string text = "";
      
        int Code = 0;
        int HTPoints = HTwh * 3 + HTwa * 3+HTdh+HTda;
        int ATPoints= ATwh * 3 + ATwa * 3 + ATdh + ATda;
        int HTPointsH = HTwh * 3 + HTdh;
        int ATPointsA = ATwa*3 + ATda;
        if (HTPoints > ATPoints + 10)
        {
            //dinamikotitaOmadasH
            if (HTPointsH>ATPointsA+5)
            {
                //dinatiedra
                if (HPform > APform && HPability>APability)
                {
                    //kaluteroipaiktesH
                    Code = 15;
                    text = "The superiority of the "+nicknameH+" won't let any chance to the "+nicknameA+" to respond. "+nicknameH+" scores a lot at their stadium";
                }
                else if(HPform+0.5<APform && HPability+3 < APability)
                {
                    //kaliteroipaiktesA
                    Code = 9;
                    text ="The quality af the "+nicknameA+" is tested against a team who just doesn't like to lose at their stadium! Taught match, few goals.";
                }
                else
                {
                    //idioiPaiktes
                    Code = 12;
                    text = nicknameH+" has proven that they don't mess around.More points, better psychology, strong home stadium.";
                }
            }
            else
            {
                //adinatiedra
                if (HPform > APform && HPability > APability)
                {
                    //kaluteroipaiktesH
                    Code = 1;
                    text = "Superiority for the "+nicknameH+" against an opponment who is good away from his home. Difficult task for the "+nicknameH+" but still the odds favourite them.";
                }
                else if (HPform+1 < APform && HPability+8 < APability)
                {
                    //kaliteroipaiktesA
                    Code = 6;
                    text = "Taugh match for two equal teams who like to score! X&Over is a risky choice but worth to try.";
                }
                else
                {
                    //idioiPaiktes
                    Code = 14;
                    text = "The "+nicknameH+" still haven't earned our trust at their home stadium. Tie is the best option for this match.";
                }
            }
        }
        else if (ATPoints > HTPoints + 10)
        {
            //dinamikotitaOmadasA
            if (HTPointsH < ATPointsA)
            {
                //dinatiEktossedra
                if (HPform > APform && HPability > APability)
                {
                    //kaluteroipaiktesH
                    Code = 3;
                    text = "The prediction is based on the "+nicknameH+" player's quality and experience who calls to stop a very good team.";
                    if (APage<24)
                    {
                        Code = 11;
                        text = "Taught challenge for the "+nicknameA+"'s boys. Good game with a lots of goals! Over is the safest bet!";
                    }
                }
                else if (HPform+0.5 < APform && HPability+5 < APability)
                {
                    //kaliteroipaiktesA
                    Code = 13;
                    text = nicknameH+" won't be an obstacle for the "+nicknameA+" which is like a train this season!";
                    if (HPage<24)
                    {
                        Code = 16;
                        text = "Good game is predicted from two teams who love to score. The superiority of the "+nicknameA+" will prevail.";
                    }
                }
                else
                {
                    //idioiPaiktes
                    Code = 2;
                    text = nicknameH+"'s quality won't be an obstacle for the "+nicknameA+" which is like a train this season!";
                    if (HPage < 26 && APage < 26)
                    {
                        Code = 5;
                        text = "Furious match from to young teams! Lots of goals but still "+nicknameA+" will prove their quality.";
                    }
                }
            }
            else
            {
                //adinatiEktosedra
                if (HPform > APform && HPability > APability)
                {
                    //kaluteroipaiktesH
                    Code = 7;
                    text = "Taught match. "+nicknameA+" plays to a very hard to win stadium against good players.";
                }
                else if (HPform < APform && HPability < APability)
                {
                    //kaliteroipaiktesA
                    Code = 14;
                    text = "We can't see a favourite to win this match. Tie is reasonable and good choice.";
                    if (APage < 25)
                    {
                        Code = 10;
                        text = "Both of the teams will try to be carefull for this match. Under is a safe choice.";
                    }
                }
                else
                {
                    //idioiPaiktes
                    Code = 8;
                    text = "Hard expedition for the "+nicknameA+". Closed match, few goals. Away team call to prove their good performance so far this season.";
                }
            }
        }
        else
        {
            //IsiDinamikotita
            if (HTPointsH > ATPointsA)
            {
                //dinatiedra
                if (HPform > APform && HPability > APability)
                {
                    //kaluteroipaiktesH
                    Code = 1;
                    text = "Two equal teams which are very close at the points table. "+nicknameH+" is very strong at their home stadium so we will bet on their win.";
                }
                else if (HPform < APform && HPability < APability)
                {
                    //kaliteroipaiktesA
                    Code = 20;
                    text = "Both of the teams are going to be de carefull on this match. Doesn't look like that they going to take any unnecessary risk.";
                }
                else
                {
                    //idioiPaiktes
                    Code = 1;
                    text = "The two teams are on the same level. Big challenge for the "+nicknameH+" who calls to defend their home stadium.";
                    if (HPage<26&&APage<26)
                    {
                        Code = 4;
                        text = "The two teams are on the same level. Big challenge for the "+nicknameH+" who calls to defend their home stadium.The young of the players promise us a plenty of goals match.";
                    }
                }
            }
            else
            {
                //adinatiedra
                if (HPform > APform && HPability > APability)
                {
                    //kaluteroipaiktesH
                    Code = 22;
                    text = "Both of the teams will give 200% to overcome the opponment. Over is a good solution based on the stats of the teams.";
                }
                else if (HPform < APform && HPability < APability)
                {
                    //kaliteroipaiktesA
                    Code = 2;
                    text = "Two same level teams will fight for the 3 points. Slight advantage for the "+nicknameA+" who has prove multiple time how dangerous is.";
                    if (HPage < 24)
                    {
                        Code = 5;
                        text = "A game with lots of goals.The odds are in favour of the "+nicknameA+" who has prove multiple time how dangerous is.";
                    }
                }
                else
                {
                    //idioiPaiktes
                    Code = 14;
                    text = "Two equal teams fight each other. No need for unnecessary risks. We bet on X as we can't see any winner.";
                    if (HPage > 24 && APage > 24)
                    {
                        Code = 9;
                        text = "The two teams will fight to the death to overcome the opponment. A lots of goals but still no winner.Risky choice!";
                    }
                }
            }
        }
        if (rivalH == AwayC || rivalA == HomeC)
        {
            text = "Derby Time!!!"+text;
        }
        setMiniDivsText(text, NumP);


        return Code;
    }
    
    private void InsertToRel(int HomeC,int AwayC, int Pred)
    {
        SqlConnection REcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        REcon.Open();
        string ins = "select count(*) from Reliability where HomeT=@ht and AwayT=@at";
        SqlCommand cmd1 = new SqlCommand(ins, REcon);
        cmd1.Parameters.AddWithValue("@ht", HomeC);
        cmd1.Parameters.AddWithValue("@at", AwayC);
        int num=Convert.ToInt32(cmd1.ExecuteScalar());
        REcon.Close();
        switch (Pred)
        {
            case 12:
                Pred = 1;
                break;
            case 13:
                Pred = 2;
                break;
            case 14:
                Pred = 3;
                break;
            case 15:
                Pred = 4;
                break;
            case 16:
                Pred = 5;
                break;
            case 17:
                Pred = 6;
                break;
            case 18:
                Pred = 7;
                break;
            case 19:
                Pred = 8;
                break;
            case 20:
                Pred = 9;
                break;
            case 21:
                Pred = 10;
                break;
            case 22:
                Pred = 11;
                break;
            default:
                break;
        }


        if (num == 0)
        {
            REcon.Open();
            ins = "insert into Reliability (HomeT,AwayT,Prediction) values (@hc,@ac,@prd)";
            cmd1 = new SqlCommand(ins, REcon);
            cmd1.Parameters.AddWithValue("@hc", HomeC);
            cmd1.Parameters.AddWithValue("@ac", AwayC);
            cmd1.Parameters.AddWithValue("@prd", Pred);
            cmd1.ExecuteNonQuery();
            REcon.Close();
        }
    }

    private void SetMiniDivsP(int HomeC, int AwayC,Label Pline,int NumP)
    {
        int pred = CreatePrediction(HomeC, AwayC,NumP);

        InsertToRel(HomeC,AwayC,pred);

        switch (pred)
        {
            case 1:
                Pline.Text = "Pred: 1";
                break;
            case 2:
                Pline.Text = "Pred: 2";
                break;
            case 3:
                Pline.Text = "Pred: X";
                break;
            case 4:
                Pline.Text = "Pred: 1&Over";
                break;
            case 5:
                Pline.Text = "Pred: 2&Over";
                break;
            case 6:
                Pline.Text = "Pred: X&Over";
                break;
            case 7:
                Pline.Text = "Pred: 1&Under";
                break;
            case 8:
                Pline.Text = "Pred: 2&Under";
                break;
            case 9:
                Pline.Text = "Pred: X&Under";
                break;
            case 10:
                Pline.Text = "Pred: Under";
                break;
            case 11:
                Pline.Text = "Pred: Over";
                break;
            case 12:
                Pline.Text = "Pred: 1";
                Pline.ForeColor = System.Drawing.Color.Gold;
                Pline.Font.Bold = true;
                break;
            case 13:
                Pline.Text = "Pred: 2";
                Pline.ForeColor = System.Drawing.Color.Gold;
                Pline.Font.Bold = true;
                break;
            case 14:
                Pline.Text = "Pred: X";
                Pline.ForeColor = System.Drawing.Color.Gold;
                Pline.Font.Bold = true;
                break;
            case 15:
                Pline.Text = "Pred: 1&Over";
                Pline.ForeColor = System.Drawing.Color.Gold;
                Pline.Font.Bold = true;
                break;
            case 16:
                Pline.Text = "Pred: 2&Over";
                Pline.ForeColor = System.Drawing.Color.Gold;
                Pline.Font.Bold = true;
                break;
            case 20:
                Pline.Text = "Pred: X&Under";
                Pline.ForeColor = System.Drawing.Color.Gold;
                Pline.Font.Bold = true;
                break;
            case 22:
                Pline.Text = "Pred: Over";
                Pline.ForeColor = System.Drawing.Color.Gold;
                Pline.Font.Bold = true;
                break;
            default:
                Pline.Text = "";
                break;
        }
    }

    private double SucLabel()
    {
        SqlConnection REcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        REcon.Open();
        string ins = "select count(*) from Reliability where Result IS NOT NULL";
        SqlCommand cmd1 = new SqlCommand(ins, REcon);
        int num = Convert.ToInt32(cmd1.ExecuteScalar());
        REcon.Close();
        DataTable dt = new DataTable();
        REcon.Open();
        SqlDataAdapter ad = new SqlDataAdapter();
        ad.SelectCommand = new SqlCommand("select Prediction,Result from Reliability where Result IS NOT NULL", REcon);
        ad.Fill(dt);
        REcon.Close();
        int count = 0;
        foreach(DataRow rw in dt.Rows)
        {
            switch (rw[1])
            {
                case 4:
                    if (Convert.ToInt32(rw[0])==1 || Convert.ToInt32(rw[0]) == 4 || Convert.ToInt32(rw[0]) == 11)
                    {
                        count++;
                    }
                    break;
                case 5:
                    if (Convert.ToInt32(rw[0]) == 2 || Convert.ToInt32(rw[0]) == 5 || Convert.ToInt32(rw[0]) == 11)
                    {
                        count++;
                    }
                    break;
                case 6:
                    if (Convert.ToInt32(rw[0]) == 3 || Convert.ToInt32(rw[0]) == 6 || Convert.ToInt32(rw[0]) == 11)
                    {
                        count++;
                    }
                    break;
                case 7:
                    if (Convert.ToInt32(rw[0]) == 1 || Convert.ToInt32(rw[0]) == 7 || Convert.ToInt32(rw[0]) == 10)
                    {
                        count++;
                    }
                    break;
                case 8:
                    if (Convert.ToInt32(rw[0]) == 2 || Convert.ToInt32(rw[0]) == 8 || Convert.ToInt32(rw[0]) == 10)
                    {
                        count++;
                    }
                    break;
                case 9:
                    if (Convert.ToInt32(rw[0]) == 3 || Convert.ToInt32(rw[0]) == 9 || Convert.ToInt32(rw[0]) == 10)
                    {
                        count++;
                    }
                    break;
                default:
                    break;
            }
        }
        double res;
        if (num > 0)
        {
            res = Convert.ToDouble(count) / Convert.ToDouble(num);
        }
        else
        {
            res = 0 ;
        }
        return res*100;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int NumOfDivs=setMiniDivsH();
        ShowHideDiv(NumOfDivs);
        Success.Text="Our site's accuracy on Predictions is: "+ Math.Round(SucLabel(),1, MidpointRounding.AwayFromZero).ToString()+"%";
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