<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddInfo.aspx.cs" Inherits="AddInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Player's Statistics</title>
    <style>
        .btnsDiv{
            position:relative;
            width:100%;
            height:200px;
            align-content:center;
            text-align:center;
        }
        #Button1{
            margin:5px;
        }
        #Button2{
            margin:5px;
        }
        #importPanel{
            visibility:hidden;
            height:450px;
            position:absolute;
            background-color:darkkhaki;
            width:40%;
            padding:50px;
            top:200px;
            left:25%;
            margin:20px;
        }
        section{
            position:relative;
            float:left;
            width:100%;
            height:500px
        }
        .pbtn{
            margin-left:220px;
        }
        .pbtn:hover{
            cursor:pointer;
        }
    </style>
</head>
<body style="background-color:whitesmoke;">
    <form id="form1" runat="server">
        
            <section>
                <h2><asp:Label ID="Label1Panel" runat="server" Text=""></asp:Label></h2> 
                <br />
                <asp:Label ID="Status1" runat="server" Text=""></asp:Label>
                <br />
                <asp:Table ID="Table1" runat="server" Width="885px" HorizontalAlign="Center">
                    <asp:TableHeaderRow HorizontalAlign="Center">
                        <asp:TableHeaderCell>Player's name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Minutes played</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Goals scored</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Cards recived</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Win balls</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Rate</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell ><asp:DropDownList ID="DropDownList1" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox1" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox2" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox3" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox4" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox5" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList2" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox6" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox7" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox8" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox9" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox10" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList3" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox11" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox12" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox13" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox14" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox15" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList4" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox16" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox17" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox18" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox19" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox20" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList5" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox21" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox22" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox23" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox24" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox25" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList6" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox26" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox27" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox28" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox29" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox30" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList7" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox31" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox32" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox33" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox34" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox35" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList8" runat="server"  Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox36" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox37" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox38" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox39" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox40" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList9" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox41" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox42" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox43" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox44" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox45" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList10" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox46" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox47" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox48" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox49" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox50" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList11" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox51" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox52" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox53" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox54" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox55" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList12" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox56" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox57" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox58" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox59" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox60" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList13" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox61" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox62" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox63" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox64" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox65" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList14" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox66" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox67" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox68" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox69" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox70" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
           </section>
           <section>
                <h2><asp:Label ID="Label2Panel" runat="server" Text=""></asp:Label></h2>
               <br />
               <asp:Label ID="Status2" runat="server" Text=""></asp:Label>
                <br />
                <asp:Table ID="Table2" runat="server" Width="885px" HorizontalAlign="Center">
                    <asp:TableHeaderRow HorizontalAlign="Center">
                        <asp:TableHeaderCell>Player's name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Minutes played</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Goals scored</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Cards recived</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Win balls</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Rate</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList15" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox71" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox72" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox73" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox74" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox75" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList16" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox76" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox77" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox78" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox79" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox80" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList17" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox81" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox82" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox83" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox84" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox85" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList18" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox86" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox87" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox88" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox89" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox90" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList19" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox91" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox92" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox93" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox94" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox95" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList20" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox96" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox97" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox98" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox99" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox100" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList21" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox101" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox102" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox103" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox104" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox105" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList22" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox106" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox107" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox108" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox109" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox110" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList23" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox111" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox112" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox113" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox114" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox115" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList24" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox116" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox117" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox118" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox119" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox120" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList25" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox121" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox122" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox123" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox124" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox125" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList26" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox126" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox127" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox128" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox129" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox130" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList27" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox131" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox132" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox133" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox134" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox135" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow HorizontalAlign="Center">
                        <asp:TableCell><asp:DropDownList ID="DropDownList28" runat="server" Width="110"></asp:DropDownList></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox136" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox137" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox138" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox139" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                        <asp:TableCell><asp:TextBox ID="TextBox140" runat="server" TextMode="Number" MaxLength="2" Width="40"></asp:TextBox></asp:TableCell>
                    </asp:TableRow>
   
                </asp:Table>
            </section>
            
            
        
        
        <br />
        <br />
        <hr />
        <div class="btnsDiv">
            <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="#FFFF66"  BorderColor="Black" BorderStyle="Double" BorderWidth="4px" ForeColor="Red" Height="50px"  Width="130px" OnClick="Button1_Click" />
        
            <asp:Button ID="Button2" runat="server" Text="Import" BackColor="#FFFF66" BorderColor="Black" BorderStyle="Double" BorderWidth="4px" ForeColor="Red" Height="50px"  Width="130px" OnClick="Button2_Click"/>
        </div>
        <div id="importPanel" runat="server">
                <br />
                <h4>Import .csv for <asp:Label ID="ImpHome" runat="server" Text=""></asp:Label></h4>
                <br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <br />
                <hr />
                <br />
                <h4>Import .csv for <asp:Label ID="ImpAway" runat="server" Text=""></asp:Label> </h4>
                <br />
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <br />
                <br/>
                <br />
                <hr />
                <asp:Button ID="Upload" runat="server" Text="Update"  OnClick="Upload_Click" BorderColor="Black" Height="40px" CssClass="pbtn" Width="90px"/>
                <br />
                <asp:Label ID="status" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="Close" runat="server" Text="Close" OnClick="Close_Click" BorderColor="Black" Height="40px"  CssClass="pbtn" Width="90px"/>

            </div>
    </form>
</body>
</html>
