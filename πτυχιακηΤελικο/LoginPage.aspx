<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginPage.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LoginPage</title>
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro&display=swap" rel="stylesheet"/>
    <style>
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
            font-family:'Source Sans Pro', sans-serif;
        }
        #ReturnMain:hover{
             font-weight:bold;
        }
        .Main{
            position:relative;
            height:500px;
            width:100%;
            align-content:center;
            background-color: whitesmoke;
            text-align:center;
        }
        .btn{
            height:45px;
            Width:130px;
            font-weight:bold;
            Font-Size:X-Large; 
            color:white;
            background-color:#33CCCC;
        }
        .btn:hover{
            cursor:pointer;
        }
    </style>
</head>
<body style="background-color:whitesmoke;">
    <form id="form1" runat="server">
        
        <div class="Main">
        <div>
            <div id="ReturnMain">
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/FrontPage.aspx" Font-Underline="false" ForeColor="Black">Return to HomePage</asp:HyperLink>
            </div>
            <br />
            <br />
            <br />
            <br />
            <div style="font-size: xx-large; font-weight: bolder; text-transform: uppercase; color: black; ">Login Page</div> 
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="Black" Height="25px" Text="Username" Width="100px"></asp:Label>
                <asp:TextBox ID="UsernameT" runat="server" BorderColor="#666666" BorderWidth="2px" ForeColor="Black" Height="16px" Width="100px"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UsernameT" ErrorMessage="RequiredFieldValidator" ForeColor="#FF3300" Height="20px" Width="100px">*Username is required</asp:RequiredFieldValidator>
            
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Font-Size="Medium" ForeColor="Black" Height="25px" Text="Password" Width="100px"></asp:Label>
                <asp:TextBox ID="PasswordT" runat="server" BorderColor="#666666" BorderWidth="2px" ForeColor="Black" Height="16px" Width="100px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredFieldValidator" ForeColor="Red" Height="20px" Width="100px" ControlToValidate="PasswordT">*Password is required</asp:RequiredFieldValidator>
                <br />
                <br />
                <br />
                <div>
                    <asp:Label ID="Label3" runat="server" ForeColor="Red"></asp:Label>

                </div>
                <br />
            
                <asp:Button ID="Button1" runat="server" Text="Login"  CssClass="btn" OnClick="Button1_Click" />
            </div>
    
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT * FROM [Managers]"></asp:SqlDataSource>

            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT * FROM [WeAre]"></asp:SqlDataSource>

        </div>
    </form>
</body>
</html>
