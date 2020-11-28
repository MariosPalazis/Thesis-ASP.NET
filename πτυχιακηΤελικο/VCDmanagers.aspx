<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VCDmanagers.aspx.cs" Inherits="VCDmanagers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit managers</title>
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
        
        #tbl{
            position:relative;
            float:left;
            height:500px;
            width:30%;
            text-align:center;
        }
        #btns{
            position:relative;
            float:left;
            height:500px;
            width:70%;
            text-align:center;
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
    </style>
</head>
<body style="background-color:cornsilk; font-family:'Source Sans Pro', sans-serif;">
    <form id="form1" runat="server">
        <header>
            <br />
            <h2>Edit Managers</h2>
            <asp:HyperLink ID="ReturnMan" runat="server" NavigateUrl="~/ManagersPage.aspx" Font-Underline="false">Return to HomePage</asp:HyperLink>
        </header>
        <section id="tbl">
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridM" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center">
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
            <br />
            <br />
            <br />
            <asp:Label ID="Status" runat="server" Text="" Font-Bold="true" ForeColor="Brown" Font-Size="Large"></asp:Label>
        </section>
        <section id="btns">
            <br />
            <br />
            <h3>Insert Manager</h3>
            <asp:Table runat="server" HorizontalAlign="Center">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Username</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Password</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableHeaderCell><asp:TextBox ID="name" runat="server"></asp:TextBox></asp:TableHeaderCell>
                    <asp:TableHeaderCell><asp:TextBox ID="passw" runat="server"></asp:TextBox></asp:TableHeaderCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Button ID="create" runat="server" Text="Add Manager" Width="230px" Visible="True" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="50px" OnClick="Cr_Click"/>
            <br />
            <br />
            <h3>Delete Manager</h3>
            <asp:Table runat="server" HorizontalAlign="Center">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Username</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableHeaderCell><asp:TextBox ID="Dname" runat="server"></asp:TextBox></asp:TableHeaderCell>
                </asp:TableRow>
            </asp:Table>
            <br />
            <asp:Button ID="delete" runat="server" Text="Delete Manager" BackColor="#FFCC00" BorderStyle="Solid" Font-Bold="True" Font-Italic="False" Font-Size="Medium" Height="50px" OnClick="Del_Click" Width="230px" Visible="True"/>
        </section>
    </form>
</body>
</html>
