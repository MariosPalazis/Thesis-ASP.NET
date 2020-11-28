<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeText.aspx.cs" Inherits="ChangeText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Change text</title>
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro&display=swap" rel="stylesheet"/>
    <style>
        .menu{
            height:6300px;
            width:13.5%;
            top:0px;
            position:fixed;
            background-color:cornsilk;
            font-family:'Source Sans Pro', sans-serif;
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
        section{
            position:relative;
            background-color:darkolivegreen;
            background-image: url('http://localhost:52004/images/MD.jpg');
            background-size:cover;
            background-position:center;
            background-repeat:no-repeat;
            text-align:center;
            align-content:center;
            top:0px;
            right:0px;
            left:185px;
            height:1205px;
            width:65.5%; 
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
        .menuImage{
            border-radius:80%;
        }
        #text{
            height:850px;
            width:70%;
            color:cornsilk;
            background-color:darkolivegreen;
            margin-left:120px;
            padding:20px;
        }
        .par{
            height:100px;
            width:500px;
            margin:10px;
        }
    </style>
</head>
<body style="font-family:'Source Sans Pro', sans-serif; background-color:cornsilk;">
    <form id="form1" runat="server">
        <header>    
            <br />
            <h2>InfoPage lookalike</h2>
        </header>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ManagersPage.aspx" CssClass="forManager">Return </asp:HyperLink>
        <nav class="menu">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Logo.jpg" Height="185px" Width="180px" CssClass="menuImage" />
            <br />
        </nav>
        <section>
            <br />
            <br />
            <br />
            <br />
            <div id="text">
                <br />
                <br />
                <asp:TextBox ID="Head" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:TextBox ID="pt1" runat="server" CssClass="par" TextMode="MultiLine" ></asp:TextBox>
                <asp:TextBox ID="pt2" runat="server" CssClass="par" TextMode="MultiLine"></asp:TextBox>
                <asp:TextBox ID="pt3" runat="server" CssClass="par" TextMode="MultiLine"></asp:TextBox>
                <asp:TextBox ID="pt4" runat="server" CssClass="par" TextMode="MultiLine"></asp:TextBox>
                <asp:TextBox ID="pt5" runat="server" CssClass="par" TextMode="MultiLine"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" Text="Update" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="35px" OnClick="Button8_Click"  Width="180px" Visible="True"/>
                <br />
                <asp:Label ID="Error" runat="server" Text="" ForeColor="Cornsilk"></asp:Label>
            </div>
        </section>
        <aside id="rightBar">
            <h3>Our friends</h3>
            
        </aside>
        <footer>
           
        </footer>
    </form>
</body>
</html>
