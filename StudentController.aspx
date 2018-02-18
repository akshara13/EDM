<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StudentController.aspx.cs" Inherits="StudentController" %>

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
<form runat="server">
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
<h1>Welcome to <span class="blue-text">Analyze Students’ Learning Experiences</span></h1>
<img src="images/welcome-brd.jpg" alt="">
<div style="padding: 10px 0px; width: 596px; text-align:justify; float: left;">

<center>
    <table style="width: 521px">
        <tr>
            <td>
                <asp:Button ID="CmdViewStudDtls" runat="server" Text="Student Details" 
                    BackColor="#FFAB2D" BorderColor="#003300" BorderStyle="Double" Font-Bold="True" 
                    Font-Size="Medium" ForeColor="#003300" Width="240px" 
                    onclick="CmdViewStudDtls_Click" />
            </td>
            <td>
                <asp:Button ID="CmdViewStuLE" runat="server" Text="Learning Experience" 
                    BackColor="#FFAB2D" BorderColor="#003300" BorderStyle="Double" Font-Bold="True" 
                    Font-Size="Medium" ForeColor="#003300" onclick="CmdViewStuLE_Click" />
            </td>
        </tr>
    </table>
</center>

    <br />

Students’ informal conversations on social media (e.g. Twitter, Facebook) shed light into their educational experiences—opinions, feelings, and concerns about the learning process. Data from such uninstrumented environments can provide valuable knowledge to inform student learning. Analyzing such data, however, can be challenging. The complexity of students’ experiences reflected from social media content requires human interpretation. However, the growing scale of data demands automatic data analysis techniques. In this paper, we developed a workflow to integrate both qualitative analysis and large-scale data mining techniques. We focused on engineering students’ Twitter posts to understand issues and problems in their educational experiences. We first conducted a qualitative analysis on samples taken from about 25,000 tweets related to engineering students’ college life. We found engineering students encounter problems such as heavy study load, lack of social engagement, and sleep deprivation. Based on these results, we implemented a multi-label classification algorithm to classify tweets reflecting students’ problems. We then used the algorithm to train a detector of student problems from about 35,000 tweets streamed at the geo-location of Purdue University. This work, for the first time, presents a methodology and results that show how informal social media data can provide insights into students’ experiences.
<br>
<br>



</div>
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