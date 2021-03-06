﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AttributeMaster.aspx.cs" Inherits="AttributeMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
  <meta charset="UTF-8">
  <title>Mining Learning Experience</title>
    <link rel="shortcut icon" href="images/Logo2.jpg" />
  <meta name="description" content="Description of your site goes here">
  <meta name="keywords" content="keyword1, keyword2, keyword3">
  <link href="css/style.css" rel="stylesheet" type="text/css">
</head>
<body>
<form id="Form1" runat="server">
<div id="main-wraper">
<div id="top-wraper">
<div id="banner">Energetic Analysis of Student Learning Experience<br />via Social Media 
    Mining</div>
<div id="nav">
<ul>
  <li><a href="AdminHome.aspx">Home</a></li>
  <li><a href="AttributeMaster.aspx">Attribute</a></li>
  <li><a href="StaffDetails.aspx">Staff Details</a></li>
  <li><a href="StudentController.aspx">Student Port</a></li><li><a href="AlertStaff.aspx">Alert</a></li>
  <li><a href="Default.aspx">Signout</a></li>
</ul>
</div>
</div>
<div id="mid-wraper">
<div id="mid-wraper-inner">
<div id="left-wraper">
<div id="left-wraper-top">
<div
 style="margin: 0px; padding: 20px; width: 256px; float: left; display: block;">
<h1>Mining Objectives</h1>
</div>
<ul>
  <li><a href="#">Education</a></li>
  <li><a href="#">Computers And Education</a></li>
  <li><a href="#">Social Networking</a></li>
  <li><a href="#">Web Text Analysis</a></li>
  <li><a href="#">Mining Student Portal</a></li>
  <li><a href="#">Administrative Control</a></li>
</ul>
</div>
<div id="news">
<h3>Need For Mining Student's Learning Experience</h3>
<img src="images/news.jpg" alt="">
<div style="width: 270px; float: left;text-align:justify; padding-top: 10px;">
  I developed both qualitative analysis and large-scale data mining techniques. I focused on engineering students twitter post to understand issues and problem. I implement multi-label classification algorithm. To classify tweets reflecting students problem.
  </div>
</div>
</div>
<div id="right-wraper">
<div class="right-part">
<h1>Attribute <span class="blue-text">
    Master
    </span></h1>
<img src="images/welcome-brd.jpg" alt="">
</div>
<div class="right-part" style="padding: 10px 0px;">


<center><br /><br />
    <table>
        <tr>
            <td>
                <center>
                        <table style="font-size: medium; color: #993300; font-weight: bold; text-align: left">
                            <tr>
                                <td>
                                    Attribute-ID
                                </td> 
                                <td>
                                    <asp:TextBox ID="TxtAID" Width="194px" runat="server" BorderColor="darkblue" 
                                        BorderStyle="Solid" BorderWidth="1px" ReadOnly="True"></asp:TextBox>
                                </td> 
                            </tr>
                            <tr>
                                <td>
                                    Attribute
                                </td> 
                                <td>
                                    <asp:TextBox ID="TxtAttribute" Width="194px" runat="server" BorderColor="darkblue" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                                </td> 
                            </tr>
                            <tr>
                                <td>
                                    
                                </td> 
                                <td>
                                    <center>
                                        <asp:Button ID="CmdSubmit" runat="server" Text="Submit" 
                                        onclick="CmdSubmit_Click" />
                                    <asp:Button ID="CmdReset" runat="server" Text="Reset" Width="61px" 
                                        onclick="CmdReset_Click" />
                                    </center>
                                </td> 
                            </tr>
                        </table>
                </center>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" Height="349px" ScrollBars="Vertical" 
                                        Width="582px">
                                        <asp:GridView ID="DG" runat="server" AutoGenerateColumns="False" 
                                            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="3" Font-Size="Small" Height="16px" Width="557px" 
                                            CellSpacing="2" onrowcommand="DG_RowCommand">
                                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                            <Columns>
                                                <asp:BoundField HeaderText="ATTRIBUTE-ID" >
                                                    <ItemStyle Width="75px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ATTRIBUTE">
                                                    <ItemStyle Width="250px" />
                                                </asp:BoundField>
                                                <asp:ButtonField Text="Delete">
                                                    <ItemStyle BackColor="#FFC6C6" ForeColor="#990000" Width="10px" />
                                                </asp:ButtonField>
                                            </Columns>
                                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#A55129" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="White" HorizontalAlign="Left" />
                                        </asp:GridView>
                                    </asp:Panel>
            </td>
        </tr>
    </table>
</center>

</div>
</div>
</div>
</div>
<div id="foter">
<div id="foter-inner">
<p style="margin: 0px; padding: 0px; width: 550px; float: left; display: block;">

  <a href="AdminHome.aspx">Home</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <a href="AttributeMaster.aspx">Attribute</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <a href="StaffDetails.aspx">Staff Details</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <a href="StudentController.aspx">Student Port</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="AlertStaff.aspx">Alert</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <a href="Default.aspx">Signout</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
 
 </p>
<p style="margin: 0px; padding: 0px; width: 293px; float: right; text-align: left; display: block;">&copy;
Copyrights Reserved <a class="footer-link" target="_blank" href="#">Mining Social Media</a></p>
<img src="images/footnote.gif" class="copyright" alt="#">
</div>
</div>
</div>
</form>
</body>
</html>