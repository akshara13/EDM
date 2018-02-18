<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewInstructions.aspx.cs" Inherits="ViewInstructions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head id="Head1" runat="server">
  <meta charset="UTF-8">
  <title>Mining Learning Experience</title>
    <link rel="shortcut icon" href="images/Logo2.jpg" />
  <meta name="description" content="Description of your site goes here">
  <meta name="keywords" content="keyword1, keyword2, keyword3">
  <link href="css/style.css" rel="stylesheet" type="text/css">
    <style type="text/css">
        .style1
        {
            width: 211px;
        }
    </style>
</head>
<body>
<form id="Form1" runat="server">
<div id="main-wraper">
<div id="top-wraper">
<div id="banner">Energetic Analysis of Student Learning Experience<br />via Social Media 
    Mining</div>
<div id="nav">
<ul>
  <li><a href="StaffHome.aspx">Home</a></li>
  <li><a href="StudentDetails.aspx">Student Details</a></li>
  <li><a href="ViewInstructions.aspx">View Instructions</a></li>
  <li><a href="SendInformation.aspx">Send Information</a></li>
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
<div class="right-part" style="padding: 10px 0px;">
<h1>View Admin's <span class="blue-text">Alert Message
    <asp:Label ID="LblDisp" runat="server" Visible="false"></asp:Label>
    </span></h1>
<img src="images/welcome-brd.jpg" alt="">

<center><br /><br />
    <asp:Panel ID="Panel1" runat="server" Height="349px" ScrollBars="Vertical" 
                                        Width="582px">
                                        <asp:GridView ID="DG" runat="server" AutoGenerateColumns="False" 
                                            BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                                            CellPadding="3" Font-Size="Small" Height="16px" Width="557px" 
                                            CellSpacing="2" onrowcommand="DG_RowCommand">
                                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                            <Columns>
                                                <asp:BoundField HeaderText="AID" >
                                                    <ItemStyle Width="75px" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="SUBJECT">
                                                    <ItemStyle Width="300px" VerticalAlign="Top" />
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="ALERT">
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="180px" VerticalAlign="Top"/>
                                                </asp:BoundField>
                                                <asp:BoundField HeaderText="SENT ON">
                                                    <ItemStyle Width="180px" VerticalAlign="Top" />
                                                </asp:BoundField>
                                                <asp:ButtonField CommandName="a" Text="View">
                                                    <ItemStyle BackColor="#CCFF66" ForeColor="#990000" Width="30px" />
                                                </asp:ButtonField>
                                            </Columns>
                                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                            <HeaderStyle BackColor="#A55129" Font-Bold="True" Font-Size="Small" 
                                                ForeColor="White" HorizontalAlign="Left" />
                                        </asp:GridView>
                                    </asp:Panel>
                                    <asp:Panel ID="Panel2" runat="server" Height="349px" ScrollBars="Vertical" 
                                        Width="582px">
                                        <table style="text-align: left; width: 351px; color: #CC6600; font-size: medium; font-weight: bold;">
				                                <tr style="border: thin solid #FFFFFF">
				                                    <td class="style1">
				                                        Subject
				                                    </td>
				                                    <td>
                                                        <asp:TextBox ID="TxtSubject" ReadOnly="true" Width="194px" runat="server" MaxLength="500" BorderColor="darkblue" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
				                                    </td>
				                                </tr>
				                                <tr style="border: thin solid #FFFFFF">
				                                    <td class="style1" style="vertical-align: top">
				                                        Alert Message</td>
				                                    <td>
                                                        <asp:TextBox ID="TxtInfm" ReadOnly="true" TextMode="MultiLine" Width="194px" runat="server" 
                                                            MaxLength="1500" BorderColor="darkblue" BorderStyle="Solid" BorderWidth="1px" 
                                                            Height="198px"></asp:TextBox>
				                                    </td>
				                                </tr>
				                                
				                            </table>
                                    </asp:Panel>
</center>

</div>
<div class="right-part" style="padding: 10px 0px;">
<div style="width: 290px; float: left;">

<h2>Past <span class="blue-text">Approach</span></h2>
<img src="images/small-brd.jpg" alt="" height="3" width="285">
<div
 style="border-right: 1px solid rgb(153, 153, 153); text-align:justify; width: 289px; float: left; padding-right: 10px; margin-top: 10px;">
Data from uninstrumented environment like twitter, facebook. Can provide valuable knowledge to inform student learning. Student informal conversation like opinions, feeling and concerns. About the learning process on social media unstructured. Analyzing such data can be challenging.
<br>
<br>
</div>
</div>
<div style="width: 270px; float: right; padding-right: 10px;">
<h2>Proposed <span class="blue-text">Approach</span></h2>
<img src="images/small-brd.jpg" alt="" height="3" width="265">
<div
 style="width: 269px; float: left; padding-right: 10px; margin-top: 10px; text-align:justify;">To researchers in learning analytics, educational data mining. It provides a 
    workflow for analyzing social media data for educational purposes. That 
    overcomes the major limitations of both manual qualitative analysis. To protect 
    students privacy and trying to provide good education.<br>
<br>
</div>
</div>
</div>
</div>
</div>
</div>
<div id="foter">
<div id="foter-inner">
<p style="margin: 0px; padding: 0px; width: 550px; float: left; display: block;">
  <a href="StaffHome.aspx">Home</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <a href="StudentDetails.aspx">Student Details</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <a href="ViewInstructions.aspx">View Instructions</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  <a href="SendInformation.aspx">Send Information</a> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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