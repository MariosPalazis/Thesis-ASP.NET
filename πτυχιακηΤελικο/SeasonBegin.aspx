<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeasonBegin.aspx.cs" Inherits="SeasonBegin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Season</title>
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro&display=swap" rel="stylesheet"/>
    <style>
        #teamsexcel{
            position:absolute;
            left:150px;
            top:30px;
            width:30%;
        }
        #playersexcel{
            position:absolute;
            right:100px;
            top:30px;
            width:30%;
        }
        .Button{
            position:absolute;
            left: 35%; 
            text-align: center;
            top:240px;
        }
        section{
            height:250px;
            background-color:whitesmoke;
            width:100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="background-color: whitesmoke; height:610px;">
        <section>
            <div id="teamsexcel">      
                <h4>Upload a file for teams! (excel)</h4> <br />
                <asp:fileupload runat="server" Height="42px" ID="FileUploadTeams" ></asp:fileupload> <br />
                <br />
                <asp:Button ID="Button1" runat="server" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Height="48px" OnClick="Button1_Click" Text="Upload" Width="226px" /> <br />
                <asp:Label ID="StatusLabel1" runat="server" Text=""></asp:Label>
            </div>
            <div id="playersexcel">      
                <h4>Upload a file for players! (excel)</h4> <br />
                <asp:fileupload runat="server" Height="42px" style="margin-top: 0px" ID="FileUploadPlayers"></asp:fileupload> <br />
                <br />
                <asp:Button ID="Button2" runat="server" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="X-Large" Height="48px" OnClick="Button2_Click" Text="Upload" Width="226px" /> <br />
                <asp:Label ID="StatusLabel2" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <hr />
        </section>
        

        
        <section>
            <div class="Button">
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Button ID="Button3" runat="server" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="48px" OnClick="Button3_Click" Text="Continue" Width="226px" Visible="True" />
            </div>
        </section>
        
    </form>
</body>
</html>
