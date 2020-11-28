<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrontPage.aspx.cs" Inherits="FrondPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>FrontPage</title>
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro&display=swap" rel="stylesheet"/>
    <style>
        .menu{
            height:6300px;
            width:13.5%;
            top:0px;
            position:fixed;
            background-color:cornsilk;
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
        }
        #MasterDiv{
            position:relative;
            background-color:darkolivegreen;
            background-image: url('http://localhost:52004/images/MD.jpg');
            background-size:cover;
            background-position:center;
            background-repeat:no-repeat;
            top:0px;
            right:0px;
            left:185px;
            height:1205px;
            width:65.5%; 
        }
        .miniDiv{
            position:relative;
            float:left;
            background-color:antiquewhite;
            height:240px;
            width:250px;
            margin:70px; 
            padding:10px;
            border: 1px solid;
            text-align:center;
            font-size:large;
        }
        
        .labels{
            font-size:x-large;
            font-weight:bold;
        }
        #rightBar{
            position:absolute;
            top:188px;
            right:8px;
            height:1205px;
            width:21%;
            background-color:cornsilk;
        }
        .forManager{
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
        }
        .forManager:hover{
             font-weight:bold;
        }
        h3{
            text-align:center;
            font-size:xx-large;
            color:#041104;
            font-weight:300;
        }
        .rightBarPics{
            padding-left:17px;
        }
        
        .menuImage{
            border-radius:80%;
        }
        .menuLinks{
            color:#041104;
            text-align:center;
            padding:30px 30px 20px 20px;
            font-size:xx-large;
        }
        .menuLinks:hover{
            font-weight:bold;
        }
        footer{
            background-color:#132A13;
            position:absolute;
            top:1393px;
            left:192px;
            height:160px;
            width:1089px;
            padding:30px;
            color:cornsilk;
        }
        #Success{
            position:absolute;
            left:200px;
            bottom:5px;
            color:cornsilk;
            font-weight:bold;
        }
        #ft{
            text-decoration:none;
            color:cornflowerblue;
        }
    </style>
    
</head>
<body style="background-color:cornsilk; font-family:'Source Sans Pro', sans-serif;">
    <form id="form1" runat="server">
        <header>    
            <br />
            <br />
            <h1>Thesis MP 2020</h1>
            <div id="lbl">
                <asp:Label ID="Success" runat="server" Text=""></asp:Label>
            </div>
        </header>
      
        <nav class="menu">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Logo.jpg" Height="185px" Width="180px" CssClass="menuImage" />
            <br />
            <br />
            <br />
            <asp:HyperLink ID="Stats" runat="server" CssClass="menuLinks" NavigateUrl="~/Stats.aspx" Font-Underline="False">Statistics</asp:HyperLink>
            <br />
            <br />
            <br />
            <asp:HyperLink ID="Info" runat="server" CssClass="menuLinks" NavigateUrl="~/GeneralInfo.aspx" Font-Underline="False">Info</asp:HyperLink>
            <br />
            <br />
            <br />
        </nav>
        <div id="MasterDiv">
            <div id="g1" class="miniDiv" runat="server">
                <asp:Label ID="Label1" runat="server" Text="" CssClass="labels"></asp:Label> - <asp:Label ID="Label2" runat="server" Text="" CssClass="labels"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Pre1" runat="server" Text=""></asp:Label>
                <br />
                <p id="p1" runat="server"></p>
            </div>
            <div id="g2" class="miniDiv" runat="server">
                <asp:Label ID="Label3" runat="server" Text="" CssClass="labels"></asp:Label> - <asp:Label ID="Label4" runat="server" Text="" CssClass="labels"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Pre2" runat="server" Text=""></asp:Label>
                <br />
                <p id="p2" runat="server"></p>
            </div>
            <div id="g3" class="miniDiv" runat="server">
                <asp:Label ID="Label5" runat="server" Text="" CssClass="labels"></asp:Label> - <asp:Label ID="Label6" runat="server" Text="" CssClass="labels"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Pre3" runat="server" Text=""></asp:Label>
                <br />
                <p id="p3" runat="server"></p>
            </div>
            <div id="g4" class="miniDiv" runat="server">
                <asp:Label ID="Label7" runat="server" Text="" CssClass="labels"></asp:Label> - <asp:Label ID="Label8" runat="server" Text="" CssClass="labels"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Pre4" runat="server" Text=""></asp:Label>
                <br />
                <p id="p4" runat="server"></p>
            </div>
            <div id="g5" class="miniDiv" runat="server">
                <asp:Label ID="Label9" runat="server" Text="" CssClass="labels"></asp:Label> - <asp:Label ID="Label10" runat="server" Text="" CssClass="labels"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Pre5" runat="server" Text="Label"></asp:Label>
                <br />
                <p id="p5" runat="server"></p>
            </div>
            <div id="g6" class="miniDiv" runat="server">
                <asp:Label ID="Label11" runat="server" Text="" CssClass="labels"></asp:Label> - <asp:Label ID="Label12" runat="server" Text="" CssClass="labels"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Pre6" runat="server" Text="Label"></asp:Label>
                <br />
                <p id="p6" runat="server"></p>
            </div>
            
            
        </div>
        
        <aside id="rightBar">
            <h3>Our friends</h3>
            <br />
            <asp:ImageButton ID="ImageButton1" runat="server" Height="250px" Width="250px" ImageUrl="~/images/betarades.jpg" CssClass="rightBarPics" OnClick="ImageButton1_Click" />
            <br />
            <br />
            <br />
            <asp:ImageButton ID="ImageButton2" runat="server" Height="250px" Width="250px" CssClass="rightBarPics" ImageUrl="~/images/stoiximan.jpg" OnClick="ImageButton2_Click" />
        </aside>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/LoginPage.aspx" CssClass="forManager">Manager's Page ></asp:HyperLink>
        <footer>
            <p>Posted by: Marios Palazis</p>
            <p>Subject: Senior Thesis </p>
            <p>Contact information: <a id="ft" href="mailto:dai17121@uom.edu.gr">dai17121@uom.edu.gr</a></p>
            <p>Supervisor: Georgia Koloniari</p>
        </footer>
    </form>
</body>
</html>
