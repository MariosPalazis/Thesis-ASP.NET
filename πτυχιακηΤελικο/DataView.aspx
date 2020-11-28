<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataView.aspx.cs" Inherits="DataView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Data view</title>
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro&display=swap" rel="stylesheet"/>
    <style>
        header{
            position:relative;
            height:180px;
            color:cornsilk;
            text-align:center;
            background-color:#132A13;
            width:100%;
            font-size:x-large;
        }
        #Main{
            position:relative;
            float:left;
            width:70%;
            height:auto;
            text-align:center;
            align-content:center;
        }
        #Dinf{
            position:relative;
            width:30%;
            float:left;
            height:600px;
            text-align:center;
            align-content:center;
        }
        #ReturnMan{
            position:absolute;
            height:30px;
            width:180px;
            background-color:cornsilk;
            top:20px;
            right:20px;
            color:black;
            margin-top:5px;
            margin-right:5px;
            text-decoration:none;
            text-align:center;
            display:inline-block;
            padding-top:7px;
            border: 1px solid;
            font-size:medium;
        }
        #ReturnMan:hover{
             font-weight:bold;
        }
        .Cclass{
            width:100%;
            height:auto;
            position:absolute;
            top:620px;
            text-align:center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color:whitesmoke; color:black; font-family:'Source Sans Pro', sans-serif;">
        <header>
            <br />
            <h3>Database View</h3>
            <div id="ReturnMan">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ManagersPage.aspx" Font-Underline="false" ForeColor="Black">Return to HomePage</asp:HyperLink>
            </div>
        </header>
        <section id="Main" runat="server">
            <br />
            <br />
            <h4>Select DataBase Table to View</h4>
            <br />
            <asp:DropDownList ID="list" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ShowDB"></asp:DropDownList>
            <br />
            <asp:GridView ID="GridT" runat="server" HorizontalAlign="Center" BackColor="White" BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" GridLines="None">
                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#594B9C" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#33276A" />
            </asp:GridView>
        </section>
        <section id="Dinf" runat="server">
            <h4>Tables</h4>
            <asp:Table ID="Table1" runat="server" GridLines="Both" HorizontalAlign="Center">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Table</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Info</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell>Teams</asp:TableCell>
                    <asp:TableCell>Shows all the teams of the current season and their relevant information.</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Players</asp:TableCell>
                    <asp:TableCell>Shows all the players of the current season and their relevant information.</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>GamesPlayed</asp:TableCell>
                    <asp:TableCell>Shows all the played games of the current season with their statistics.</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>PlayerOnGame</asp:TableCell>
                    <asp:TableCell>Shows the performance of each player on the games that they have played this season.</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>ArchieveTeams</asp:TableCell>
                    <asp:TableCell>Shows the teams of the last season with their statistics.</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>ArchieveGP</asp:TableCell>
                    <asp:TableCell>Shows all the games which were held last season .</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Reliability</asp:TableCell>
                    <asp:TableCell>Shows the prediction of each game and the actual result.</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <p>1,12=1/2,13=2/3,14=X/4,15=1O/5,16=2O/</p>
            <p>6,17=XO/7,18=1U/8,19=2U/9,20=XU/</p>
            <p>10=U/11=O,</p>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Export Datatable" BackColor="#ff3300" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="50px" OnClick="Button1_Click"  Width="230px" Visible="True" />
            <br />
            <br />
            <asp:Label ID="status" runat="server" Text=""></asp:Label>
            <div id="c1" class="Cclass" runat="server">
                <h3>Edit Teams</h3>
                <asp:Table ID="Eteams" runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>id(must)</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="id" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>name</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="nm" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Whome</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="wh" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Dhome</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="dh" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Lhome</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="lh" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Waway</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="wa" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Daway</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="da" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Laway</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="la" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>GinfH</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="gih" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>GagH</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="gah" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>GinfA</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="gia" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>GagA</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="gaa" runat="server" TextMode="Number"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>rival</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="riv" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>nickname</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="nick" runat="server"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                <br />
                <asp:Button ID="Update" runat="server" Text="Update" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="UpT_Click"  Width="180px" Visible="True" />
                <br />
                <asp:Button ID="Delete" runat="server" Text="Delete" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="DelT_Click"  Width="180px" Visible="True" />
            </div>
            <div id="c2" class="Cclass" runat="server" >
                <h3>Edit Players</h3>
                <asp:Table ID="Eplayers" runat="server"  HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>Id(must)</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="pid" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Name</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="pNm" runat="server"  ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Age</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="pA" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Form</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="pF" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Pmins</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="pM" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Ability</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="pAb" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>TeamC</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="pT" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                 <br />
                <asp:Button ID="Button2" runat="server" Text="Update" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="UpP_Click"  Width="180px" Visible="True" />
                <br />
                <asp:Button ID="Button3" runat="server" Text="Delete" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="DelP_Click"  Width="180px" Visible="True" />
            </div>
            <div id="c3" class="Cclass" runat="server" >
                <h3>Edit Games Played</h3>
                <asp:Table ID="GP" runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>Id(must)</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="gpid" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>gameweek</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="gwgp" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>HomeT</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="htgp" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>AwayT</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="atgp" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>HomeGoals</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="hggp" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>AwayGoals</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="aggp" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                 <br />
                <asp:Button ID="Button4" runat="server" Text="Update" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="UpGP_Click"  Width="180px" Visible="True" />
                <br />
                <asp:Button ID="Button5" runat="server" Text="Delete" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="DelGP_Click"  Width="180px" Visible="True" />
            </div>
            <div id="c4" class="Cclass" runat="server">
                <h3>Edit Player's games</h3>
                <asp:Table ID="PoG" runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>Id(must)</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="idpog" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>gameweek</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="gwpog" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>PlayerCode</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="ppog" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Mins</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="minpog" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Goals</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="gpog" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Card</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="cpog" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>WinBalls</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="wbpog" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Rate</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="rpog" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                 <br />
                <asp:Button ID="Button6" runat="server" Text="Update" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="UpPoG_Click"  Width="180px" Visible="True" />
                <br />
                <asp:Button ID="Button7" runat="server" Text="Delete" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="DelPog_Click"  Width="180px" Visible="True" />
            
            </div>
            <div id="c5" class="Cclass" runat="server">
                <h3>Edit Reliability</h3>
                <asp:Table ID="rel" runat="server" HorizontalAlign="Center">
                    <asp:TableRow>
                        <asp:TableCell>Id(must)</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="idr" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>HomeT</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="htr" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>AwayT</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="atr" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Prediction</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="pred" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>Result</asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="rsl" runat="server" TextMode="Number" ></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
                 <br />
                <asp:Button ID="Button8" runat="server" Text="Update" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="relU_Click"  Width="180px" Visible="True" />
                <br />
                <asp:Button ID="Button9" runat="server" Text="Delete" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="relD_Click"  Width="180px" Visible="True" />
            
            </div>
            
        </section>
    </form>
</body>
</html>
