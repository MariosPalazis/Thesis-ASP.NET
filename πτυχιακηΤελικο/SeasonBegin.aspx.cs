using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;       //Microsoft Excel 14 object in references-> COM tab
using System.Data.Odbc;
using System.Configuration;
using System.Data.SqlClient;

public partial class SeasonBegin : System.Web.UI.Page
{

    private void DeleteDB(string x)
    {
        SqlConnection dcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        dcon.Open();
        string del = "DELETE FROM " + x;
        SqlCommand cmd = new SqlCommand(del, dcon);
        cmd.ExecuteNonQuery();
        dcon.Close();
    }

    private void ArchieveTeams(string tm)
    {
        SqlConnection dcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        dcon.Open();
        string ins = "INSERT INTO ArchieveTeam(Id,name,Whome,Dhome,Lhome,Waway,Daway,Laway,goalinfH,goalagH,goalinfA,goalagA) SELECT Id,name,Whome,Dhome,Lhome,Waway,Daway,Laway,goalinfH,goalagH,goalinfA,goalagA FROM @tm";
        SqlCommand cmd = new SqlCommand(ins, dcon);
        cmd.Parameters.AddWithValue("@tm", tm);
        cmd.ExecuteNonQuery();
        dcon.Close();
    }

    private void ArchieveGamesPlayed()
    {
        SqlConnection dcon = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
        dcon.Open();
        string ins = "INSERT INTO ArchieveGP(Id,Gid,HomeC,AwayC,HG,AG) SELECT Id,Gid,HomeT,AwayT,HG,AG FROM GamesPlayed";
        SqlCommand cmd = new SqlCommand(ins, dcon);
        cmd.ExecuteNonQuery();
        dcon.Close();
    }

    private class Flags
    {
        internal static bool flagT, flagP;
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Convert.ToUInt32(Session["Season"]) != 5619)
            {
                Response.Redirect("ManagersPage.aspx");
            }
            Flags.flagT = false;
            Flags.flagP = false;
            Label1.Text = "By pressing 'Continue' you go back to Managers page";
            Button3.Attributes.Add("style", "background-color: #FFCC00");
        }

    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUploadTeams.HasFile)
        {
            try
            {
                DeleteDB("ArchieveTeam");
                ArchieveTeams("Teams");
                DeleteDB("NEWteams");
                string excelPath = Path.GetFileName(FileUploadTeams.FileName);
                excelPath = excelPath.Replace(" ", "");
                FileUploadTeams.SaveAs(Server.MapPath("~/ExcelDatas/") + excelPath);
                String ExcelPath = Server.MapPath("~/ExcelDatas/") + excelPath;
                string conString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties=Excel 8.0; Persist Security Info = False";
                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dtExcelData = new DataTable();
                    dtExcelData.Columns.Add("Id", typeof(int));
                    dtExcelData.Columns.Add("name", typeof(string));
                    dtExcelData.Columns.Add("rival", typeof(string));
                    dtExcelData.Columns.Add("nickname", typeof(string));

                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                    }

                    excel_con.Close();


                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
                    SqlCommand cmd = new SqlCommand();

                    for (int i = 0; i < dtExcelData.Rows.Count; i++)
                    {
                        con.Open();
                        string insert = "INSERT INTO NEWteams (Id,name,Whome,Dhome,Lhome,Waway,Laway,Daway,goalinfH,goalagH,goalinfA,goalagA,rival,nickname) VALUES(@id,@name,@wh,@dh,@lh,@wa,@da,@la,@gih,@gah,@gia,@gaa,@rival,@nick)";
                        cmd = new SqlCommand(insert, con);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dtExcelData.Rows[i]["Id"]));
                        cmd.Parameters.AddWithValue("@name", dtExcelData.Rows[i]["name"]);
                        cmd.Parameters.AddWithValue("@wh", 0);
                        cmd.Parameters.AddWithValue("@dh", 0);
                        cmd.Parameters.AddWithValue("@lh", 0);
                        cmd.Parameters.AddWithValue("@wa", 0);
                        cmd.Parameters.AddWithValue("@da", 0);
                        cmd.Parameters.AddWithValue("@la", 0);
                        cmd.Parameters.AddWithValue("@gih", 0);
                        cmd.Parameters.AddWithValue("@gah", 0);
                        cmd.Parameters.AddWithValue("@gia", 0);
                        cmd.Parameters.AddWithValue("@gaa", 0);
                        cmd.Parameters.AddWithValue("@rival", dtExcelData.Rows[i]["rival"]);
                        cmd.Parameters.AddWithValue("@nick", dtExcelData.Rows[i]["nickname"]);
                        cmd.ExecuteNonQuery();
                        con.Close();


                    }
                    Flags.flagT = true;
                    if (Flags.flagP && Flags.flagT)
                    {
                        Label1.Text = "By pressing 'Continue' you proceed to New Season";
                        Button3.Attributes.Add("style", "background-color: #ff3300");
                    }
                    StatusLabel1.Text = "File Uploaded Succesfully!";

                }
            }
            catch (Exception)
            {
                StatusLabel1.Text = "Error on file update occurred. Check your file";
            }
        }
        else
        {
            StatusLabel1.Text = "Error";
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (FileUploadPlayers.HasFile)
        {
            try
            {
                DeleteDB("NEWplayers");
                string excelPath1 = Path.GetFileName(FileUploadPlayers.FileName);
                excelPath1 = excelPath1.Replace(" ", "");
                FileUploadPlayers.SaveAs(Server.MapPath("~/ExcelDatas/") + excelPath1);
                String ExcelPath1 = Server.MapPath("~/ExcelDatas/") + excelPath1;
                string conString1 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath1 + "; Extended Properties=Excel 8.0; Persist Security Info = False";
                using (OleDbConnection excel_con = new OleDbConnection(conString1))
                {
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dtExcelData = new DataTable();
                    dtExcelData.Columns.Add("Id", typeof(int));
                    dtExcelData.Columns.Add("Name", typeof(string));
                    dtExcelData.Columns.Add("Age", typeof(int));
                    dtExcelData.Columns.Add("Ability", typeof(int));
                    dtExcelData.Columns.Add("Team", typeof(int));


                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        oda.Fill(dtExcelData);
                    }

                    excel_con.Close();


                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString);
                    SqlCommand cmd = new SqlCommand();

                    for (int i = 0; i < dtExcelData.Rows.Count; i++)
                    {
                        con.Open();
                        string insert = "INSERT INTO NEWplayers (Id,Name,Age,Form,Pmins,Ability,Team) VALUES(@id,@name,@age,@form,@mins,@ab,@tm)";
                        cmd = new SqlCommand(insert, con);
                        cmd.Parameters.AddWithValue("@id", Convert.ToInt32(dtExcelData.Rows[i]["Id"]));
                        cmd.Parameters.AddWithValue("@name", dtExcelData.Rows[i]["Name"]);
                        cmd.Parameters.AddWithValue("@age", dtExcelData.Rows[i]["Age"]);
                        cmd.Parameters.AddWithValue("@form", 0);
                        cmd.Parameters.AddWithValue("@mins", 0);
                        cmd.Parameters.AddWithValue("@ab", dtExcelData.Rows[i]["Ability"]);
                        cmd.Parameters.AddWithValue("@tm", dtExcelData.Rows[i]["Team"]);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    StatusLabel2.Text = "File Uploaded Succesfully!";

                    Flags.flagP = true;
                    if (Flags.flagP && Flags.flagT)
                    {
                        Label1.Text = "By pressing 'Continue' you proceed to New Season";
                        Button3.Attributes.Add("style", "background-color: #ff3300");
                    }
                }
            }
            catch (Exception)
            {
                StatusLabel2.Text = "Error on file update occurred. Check your file";
            }
        }
        else
        {
            StatusLabel2.Text = "Error. File not found";
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Flags.flagP && Flags.flagT)
        {
            DeleteDB("ArchieveGP");
            ArchieveGamesPlayed();
            DeleteDB("GamesPlayed");
            DeleteDB("PlayerOnGame");
            DirectoryInfo directory = new DirectoryInfo(Server.MapPath("~/ExcelDatas/"));
            EmptyFolder(directory);
        }
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

}