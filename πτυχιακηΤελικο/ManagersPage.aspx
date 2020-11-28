<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ManagersPage.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manager's page</title>
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro&display=swap" rel="stylesheet"/>
    <style>
        .align{
            align-content:center;
            
        }
        #end{
            background-color:dimgrey;
            position:absolute;
            top:1050px;
            left:0px;
            height:160px;
            width:1275px;
            padding:30px;
            color:cornsilk;
            background-color:#132A13;
        }
        #ft{
            text-decoration:none;
            color:cornflowerblue;
        }
        #ReturnMain{
            position:absolute;
            height:30px;
            width:180px;
            background-color:white;
            font-family:'Source Sans Pro', sans-serif;
            top:20px;
            right:20px;
            color:#132A13;
            margin-top:5px;
            margin-right:5px;
            text-decoration:none;
            text-align:center;
            display:inline-block;
            padding-top:7px;
            border: 1px solid;
        }
        #ReturnMain:hover{
             font-weight:bold;
        }
        header{
            position:relative;
            height:180px;
            left:0px;
            top:0px;
            color:cornsilk;
            text-align:center;
            background-color:#132A13;
            width:100%;
            font-size:x-large;
        }
        .played{
            position:relative;
            width:100%;
            height:200px;
        }
        .display{
            position:relative;
            width:100%;
            height:250px;
        }
        .Amatches{
            position:relative;
            width:100%;
            height:300px;
        }
        #btns{
            position:absolute;
            top:20px;
            left:53%;
            margin:10px;
        }
        #redbtns{
            position:relative;
            width:100%;
            height:50px;
            background-color:black;
        }
        .btn{
            margin-left:60px;
            height:50px;
            width:250px;
        }
        .btn:hover{
            cursor:pointer;
        }
    </style>
</head>
<body style="background-color: whitesmoke; font-family:'Source Sans Pro', sans-serif;">
    <form id="form1" runat="server"  style="position: relative;">

        
        <header>
            <br />
            <h2>Manager's Page</h2>
        </header>
        <section id="redbtns">
            <asp:Button ID="Button4" runat="server" CssClass="btn" BackColor="#ff3300" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" OnClick="Button4_Click" Text="New Season" Visible="True" />
            <asp:Button ID="Button6" runat="server" CssClass="btn" BackColor="#ff3300" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" OnClick="Button6_Click" Text="Inspect Database" Visible="True" />
            <asp:Button ID="Button7" runat="server" CssClass="btn" BackColor="#ff3300" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" OnClick="Button7_Click" Text="Edit Managers" Visible="True" />
            <asp:Button ID="Button8" runat="server" CssClass="btn" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" OnClick="Button8_Click" Text="Change Text" Visible="True" />
        </section>
        <section class="played">
            <br />
            <h3>Played game</h3><br />
            <asp:Table ID="Table1" runat="server" Width="900px">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>GameWeek</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Home Team</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Away Team</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Home team G</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Away Team G</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Press Button fo Players info</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                <asp:TableCell HorizontalAlign="Center"><asp:TextBox runat="server" ID="GWeek" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DLHomeTeam" runat="server" Width="110" ></asp:DropDownList></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DLAwayTeam" runat="server" Width="110" ></asp:DropDownList></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:TextBox runat="server" ID="GH" TextMode="Number" MaxLength="2" Width="40" Text="0"></asp:TextBox></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:TextBox runat="server" ID="GA" TextMode="Number" MaxLength="2" Width="40" Text="0"></asp:TextBox></asp:TableCell>
                <asp:TableCell HorizontalAlign="Center"><asp:Button ID="Button1" runat="server" Text="Add" Width="60" OnClick="Button1_Click"/></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Label ID="CheckLabel1" runat="server" Text=""></asp:Label>
            <br />
        </section>
        <hr />
        <section class="display">
            <br />
            <h3>Next matche's (Display)</h3>
            <div class="align">
                <asp:Table ID="Table2" runat="server" GridLines="Vertical" HorizontalAlign="left">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>GameWeek</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Home Team</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Away Team</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Center"><asp:TextBox runat="server" ID="TextBox1" TextMode="Number" MaxLength="2" Width="40" ></asp:TextBox></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList1" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList2" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Center"><asp:TextBox runat="server" ID="TextBox2" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList3" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList4" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Center"><asp:TextBox runat="server" ID="TextBox3" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList5" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList6" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Center"><asp:TextBox runat="server" ID="TextBox4" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList7" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList8" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Center"><asp:TextBox runat="server" ID="TextBox5" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList9" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList10" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Center"><asp:TextBox runat="server" ID="TextBox6" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList11" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DropDownList12" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
        
                <br />
                <div style="text-align: center;">
                    <asp:Button ID="Button2" runat="server" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Height="48px" OnClick="Button2_Click" Text="Update" Width="226px" Visible="True" />
                    <asp:Label ID="CheckLabel2" runat="server" Text=""></asp:Label>
                    <br />
                    <br />
                </div>
            </div>
        </section>
        <section class="Amatches">
            <br />
            <br />
        
            <h4>Appeared Matches</h4>
            <div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [Gw], [HteamN], [AteamN] FROM [DisplayedMatches]"></asp:SqlDataSource>
                <asp:GridView ID="DisplayGrid" runat="server" AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                    <Columns>
                        <asp:BoundField DataField="Gw" HeaderText="Gw" SortExpression="Gw" />
                        <asp:BoundField DataField="HteamN" HeaderText="HteamN" SortExpression="HteamN" />
                        <asp:BoundField DataField="AteamN" HeaderText="AteamN" SortExpression="AteamN" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>
        
                <div id="btns">
                    <asp:Button ID="Button3" runat="server" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Large" Height="50px" OnClick="Button3_Click" Text="Delete DisplayTable" Width="230px" Visible="True" />
                    <br />
                    <br />
                    <asp:Button ID="Button5" runat="server" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="50px" OnClick="Button5_Click" Text="Delete Match" Width="230px" Visible="True" />
                    <br />
                    <br />
                    <asp:Table ID="Table3" runat="server" GridLines="Vertical">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>GameWeek</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Home Team</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Away Team</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell HorizontalAlign="Center"><asp:TextBox runat="server" ID="DMt" TextMode="Number" MaxLength="2" Width="40" ></asp:TextBox></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DMdlh" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell HorizontalAlign="Center"><asp:DropDownList ID="DMdla" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                    </asp:TableRow>
                    </asp:Table>
                </div>
            </div>
        </section>
        
        <div id="ReturnMain">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FrontPage.aspx" Font-Underline="false" ForeColor="Black">Return to HomePage</asp:HyperLink>
        </div>
        <footer id="end">
            <p>Posted by: Marios Palazis</p>
            <p>Subject: Senior Thesis </p>
            <p>Contact information: <a id="ft" href="mailto:dai17121@uom.edu.gr">dai17121@uom.edu.gr</a></p>
            <p>Supervisor: Georgia Koloniari</p>
        </footer>
    </form>
        
</body>
</html>
