<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stats.aspx.cs" Inherits="_Default" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Statistics</title>
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro&display=swap" rel="stylesheet"/>
    <style>
        header{
            position:relative;
            height:180px;
            left:0px;
            top:0px;
            color:cornsilk;
            text-align:center;
            background-color:#132A13;
            width:100%;
        }
        .ali{
            width:40%;
            float:left;
            height:450px;
            text-align:center;
            background-color:darkolivegreen;
        }
        .alid{
            width:40%;
            float:left;
            height:auto;
            text-align:center;
            background-color:darkolivegreen;
        }
        
        aside{
            position:relative;
            float:right;
            width:20%;
            background-color:cornsilk;
            height:900px;
        }
        h3{
            text-align:center;
            font-size:xx-large;
            color:#041104;
            font-weight:300;
        }
        .rightBarPics{
            padding-left:15px;
        }
        #ReturnMain{
            position:absolute;
            height:30px;
            width:180px;
            background-color:cornsilk;
            top:20px;
            left:20px;
            color:black;
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
        footer{
            background-color:#132A13;
            float:left;
            height:160px;
            width:95.5%;
            padding:30px;
            color:cornsilk;
            font-family:'Lucida Console';
        }
        #ft{
            text-decoration:none;
            color:cornflowerblue;
        }
        .dropd{
            padding:3px;
            margin:5px;
        }
        
    </style>
</head>
<body style="background-color:darkolivegreen; font-family:'Source Sans Pro', sans-serif;">
    <form id="form1" runat="server" style="background-color:darkolivegreen; font-family:'Source Sans Pro', sans-serif;">
        <header>
            <br />
            <br/>
            <h1>Usefull Statistics</h1>
        </header>
        <div id="Trank" class="ali">
            <h1>Table</h1>
        
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [name], [Whome], [Dhome], [Lhome], [Waway], [Daway], [Laway], [goalinfH], [goalagH], [goalinfA], [goalagA] FROM [Teams]"></asp:SqlDataSource>
            <asp:GridView ID="TeamRank" runat="server" BackColor="#CCCCCC" Height="200px" Width="30%" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" HorizontalAlign="Center">
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
        </div>
        <div id="PGoalRank" class="ali">
            <h1>Scorers</h1>
            <br />
            <asp:GridView ID="Scorers" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" CellSpacing="2" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="40%">
                <AlternatingRowStyle BackColor="#CCCCCC" />
                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
        </div>
        <aside>
            <h3>Our friends</h3>
            <br />
            <asp:ImageButton ID="ImageButton1" runat="server" Height="250px" Width="250px" ImageUrl="~/images/betarades.jpg" CssClass="rightBarPics" OnClick="ImageButton1_Click" />
            <br />
            <br />
            <br />
            <asp:ImageButton ID="ImageButton2" runat="server" Height="250px" Width="250px" CssClass="rightBarPics" ImageUrl="~/images/stoiximan.jpg" OnClick="ImageButton2_Click" />
        </aside>
            <div id="Teamsgames" class="alid">
                <h1>Team's Games</h1>
                <asp:DropDownList ID="TeamsG" runat="server" AutoPostBack="true" OnSelectedIndexChanged="TeamsDropChanged" CssClass="dropd"></asp:DropDownList>
                <br />            
                <asp:GridView ID="teamsgames" runat="server" CellPadding="3" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" />
                    <FooterStyle BackColor="#CCCCCC" />
                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#808080" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#383838" />
                </asp:GridView>

            </div>
            <div id="Playersgames" class="alid">
                 <h1>Player's Games</h1>
                 <asp:DropDownList ID="Pteam" runat="server" CssClass="dropd" AutoPostBack="true" OnSelectedIndexChanged="PlayerDrop1Changed"></asp:DropDownList>
                 <br />             
                 <asp:DropDownList ID="Pname" runat="server" CssClass="dropd" AutoPostBack="true" OnSelectedIndexChanged="PlayerDrop2Changed"></asp:DropDownList>                       
                 <br />
                 <asp:GridView ID="PlayerGames" runat="server" CellPadding="3" HorizontalAlign="Center" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" GridLines="Vertical">
                     <AlternatingRowStyle BackColor="#CCCCCC" />
                     <FooterStyle BackColor="#CCCCCC" />
                     <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                     <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                     <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                     <SortedAscendingCellStyle BackColor="#F1F1F1" />
                     <SortedAscendingHeaderStyle BackColor="#808080" />
                     <SortedDescendingCellStyle BackColor="#CAC9C9" />
                     <SortedDescendingHeaderStyle BackColor="#383838" />
                 </asp:GridView>

                
            </div>
             
        <div id="ReturnMain">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FrontPage.aspx" Font-Underline="false" ForeColor="Black">Return to HomePage</asp:HyperLink>
        </div>
        <footer>
            <p>Posted by: Marios Palazis</p>
            <p>Subject: Senior Thesis </p>
            <p>Contact information: <a id="ft" href="mailto:dai17121@uom.edu.gr">dai17121@uom.edu.gr</a></p>
            <p>Supervisor: Georgia Koloniari</p>
        </footer>

    </form>
</body>
</html>
