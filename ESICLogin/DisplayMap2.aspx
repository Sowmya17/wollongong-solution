<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DisplayMap2.aspx.cs" Inherits="DisplayMap2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
<style type="text/css">
.txtVertical 
{
	filter:  progid:DXImageTransform.Microsoft.BasicImage(rotation=3);  /* IE6,IE7 */
	ms-filter: "progid:DXImageTransform.Microsoft.BasicImage(rotation=3)"; /* IE8 */
	-moz-transform: rotate(-90deg);  /* FF3.5+ */
	-o-transform: rotate(-90deg);  /* Opera 10.5 */
	-webkit-transform: rotate(-90deg);  /* Safari 3.1+, Chrome */
	position: absolute; 
}
</style>


<script type="text/javascript">
    function startTime() {
        var today = new Date();
        var h = today.getHours();
        var m = today.getMinutes();
        var s = today.getSeconds();

        var ampm = h >= 12 ? 'PM' : 'AM';
        h = h % 12;
        h = h ? h : 12; // the hour '0' should be '12'
        // add a zero in front of numbers<10
        m = checkTime(m);
        s = checkTime(s);
        document.getElementById('txt').innerHTML = h + ":" + m + ":" + s;
        t = setTimeout(function () { startTime() }, 500);
    }

    function checkTime(i) {
        if (i < 10) {
            i = "0" + i;
        }
        return i;
    }
    </script>
   


<title> </title>
<style type="text/css">
div.rotate_right {
    float: left;
    -ms-transform: rotate(34deg); /* IE 9 */
    -webkit-transform: rotate(34deg); /* Safari */
    transform: rotate(34deg);

}
table.rotate_right1 {
    float: left;
    -ms-transform: rotate(34deg); /* IE 9 */
    -webkit-transform: rotate(34deg); /* Safari */
    transform: rotate(34deg);

}
table.rotate_right2 {
    float: left;
    -ms-transform: rotate(34deg); /* IE 9 */
    -webkit-transform: rotate(34deg); /* Safari */
    transform: rotate(0deg);

}
body,td,th 
{
    
	font-family: Calibri;
	font-weight: bold;
}
Lable
{
    font-size:26pt;
}
</style>
</head>

<body style="background-image:url(images/waitbg3.jpg); background-repeat:no-repeat;" onload="startTime()">
<form id="form1" runat="server">
<div>
   <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
<table class="rotate_right1" style="margin-top:450px; margin-left:470px;">
<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_b2" runat="server" ForeColor="#00ff00" Text="B2" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>
</table>

<table class="rotate_right1" style="margin-top:390px; margin-left:100px;" Visible="false" cellspacing="50">
<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_b3" runat="server" ForeColor="#00FF00" Text="B3" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel3" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_b4" runat="server" ForeColor="#00FF00" Text="B4" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>
</table>
<table class="rotate_right1" style="margin-top:580px; margin-left:-280px;" >
<tr>
<td>
<asp:Label ID="Label1" class=txtVertical ForeColor="red" Width="280pt" runat="server" Text="Please go in this way for MAC" Font-Size="22pt"></asp:Label>
</td>
</tr>
</table>

<table class="rotate_right1" style="margin-top:400px; margin-left:-200px;" cellspacing="20" >
<tr>
<td >
<asp:UpdatePanel ID="UpdatePanel4" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_b6" runat="server" ForeColor="#00FF00" Text="B6" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_b5" runat="server" ForeColor="#00FF00" Text="B5" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel7" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_br" runat="server" ForeColor="#00FF00" Text="MAC" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>

</table>


<table class="rotate_right1" style="margin-top:530px; margin-left:-300px;" cellspacing="15" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel8" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_b7" runat="server" ForeColor="#00FF00" Text="B7" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel9" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_b8" runat="server" ForeColor="#00FF00" Text="B8" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel10" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_podb" runat="server" ForeColor="Lime" Text="Unit" Visible="false" Font-Size="17pt" 
                ></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>
</table>

<table class="rotate_right1" style="margin-top:520px; margin-left:-420px;">
<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_b1" runat="server" ForeColor="#00FF00" Text="B1" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>
</table>

<table class="rotate_right1" style="margin-top:585px; margin-left:-482px;">
<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel12" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_a10" runat="server" ForeColor="#00FF00" Text="A10" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>
</table>

<table class="rotate_right1" style="margin-top:620px; margin-left:-503px;">
<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel13" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_a9" runat="server" ForeColor="#00FF00" Text="A9" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>
</table>

<table class="rotate_right1" style="margin-top:690px; margin-left:-400px;" cellspacing="2" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel14" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_plaster" runat="server" ForeColor="#00FF00" Text="PLASTER" Visible="false" Font-Size="15pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel15" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_a11" runat="server" ForeColor="#00FF00" Text="A11" Visible="false" Font-Size="22pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel16" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_a12" runat="server" ForeColor="#00FF00" Text="A12" Visible="false" Font-Size="22pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>
</table>

<table class="rotate_right1" style="margin-top:725px; margin-left:-440px;" cellspacing="10" >

<tr>  
<td>
<asp:UpdatePanel ID="UpdatePanel17" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_a4" runat="server" ForeColor="#00FF00" Text="A4" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel18" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_a3" runat="server" ForeColor="#00FF00" Text="A3" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel19" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_a2" runat="server" ForeColor="#00FF00" Text="A2" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
<td>
<asp:UpdatePanel ID="UpdatePanel20" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_a1" runat="server" ForeColor="#00FF00" Text="A1" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>
</table>

<table class="rotate_right2" style="margin-top:830px; margin-left:-575px;" cellspacing="10" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel21" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_a8" runat="server" ForeColor="#00FF00" Text="A8" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>


</tr>
</table>


<table class="rotate_right2" style="margin-top:873px; margin-left:-575px;" cellspacing="10" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel22" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_a7" runat="server" ForeColor="#00FF00" Text="A7" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>


</tr>
</table>

<table class="rotate_right2" style="margin-top:780px; margin-left:-430px;" cellspacing="10" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel23" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_ar" runat="server" ForeColor="#00FF00" Text="HITH" Visible="false" Font-Size="20pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>


</tr>
</table>

<table class="rotate_right2" style="margin-top:815px; margin-left:-430px;" cellspacing="10" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel24" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_poda" runat="server" ForeColor="Lime" Text="HITH" Font-Size="15pt" 
                Visible="False" EnableViewState="False" ></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>


</tr>
</table>

<table class="rotate_right2" style="margin-top:840px; margin-left:-430px;" cellspacing="10" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel25" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_a5" runat="server" ForeColor="#00FF00" Text="A5" Font-Size="25pt" Visible="false"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>


</tr>
</table>

<table class="rotate_right2" style="margin-top:880px; margin-left:-430px;" cellspacing="10" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel26" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_a6" runat="server" ForeColor="#00FF00" Text="A6" Font-Size="25pt" Visible="false"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>
</tr>
</table>
<table class="rotate_right2" style="margin-top:850px; margin-left:-270px;" cellspacing="10" >
<tr><td>
<asp:UpdatePanel ID="UpdatePanel32" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_you" runat="server" ForeColor="#00008B" Text="You" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td></tr>
</table>
<table class="rotate_right2" style="margin-top:890px; margin-left:-260px;" cellspacing="10">
<tr><td>
<asp:UpdatePanel ID="UpdatePanel33" runat="server">
        <ContentTemplate>
<asp:Label ID="lbl_here" runat="server" ForeColor="#00008B" Text="are here" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td></tr>
</table>
<table class="rotate_right1" style="margin-top:820px; margin-left:-360px;" cellspacing="10">

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel27" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_pat" runat="server" ForeColor="#00FF00" Text="PAT" Font-Size="25pt" Visible="false"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>


</tr>
</table>

<table class="rotate_right1" style="margin-top:790px; margin-left:-195px;" cellspacing="10" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel28" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_r4" runat="server" ForeColor="#00FF00" Text="R4" Font-Size="25pt" Visible="false"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>


</tr>
</table>

<table class="rotate_right1" style="margin-top:815px; margin-left:-160px;" cellspacing="10" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel29" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_r3" runat="server" ForeColor="#00FF00" Text="R3" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>


</tr>
</table>

<table class="rotate_right2" style="margin-top:855px; margin-left:-125px;" cellspacing="10" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel30" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_r2" runat="server" ForeColor="#00FF00" Text="R2" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>


</tr>
</table>

<table class="rotate_right2" style="margin-top:890px; margin-left:-125px;" cellspacing="10" >

<tr>
<td>
<asp:UpdatePanel ID="UpdatePanel31" runat="server" >
        <ContentTemplate>
<asp:Label ID="lbl_r1" runat="server" ForeColor="#00FF00" Text="R1" Visible="false" Font-Size="25pt"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
</td>


</tr>
</table>


</div>

<table class="rotate_right2" style="margin-top:920px; margin-left:-900px;">
    <tr>
    <td class="style11">
    <div  style="width:925px; height: 28px; background: black none repeat scroll 0% 0%; margin: 35px 0px 0px 135px; border-right-style: solid; border-bottom-width: 0px; border-bottom-style: solid; padding-bottom: 0px; border-left-width: 0px; border-left-style: solid; padding-left: 0px; padding-right: 1px; border-right-width: 0px;">

    <marquee style="margin-left: 5px; font-size: 25px; color: White; width: 896px;" loop="true" direction="left">
   <%-- <html:div style="display: -moz-box; overflow: hidden; width: -moz-available; margin-right: -324px;">
    </html:div>  --%>
    "*Welcome to the Wollongong Hospital Ambulatory Care Centre. Q'Soft is powered by  ATT Systems Group ** Please note that queue ticket numbers will not be called in order, ticket number will be called based on your appointment time.*"
    
   </marquee>
           
             
    </div>
    </td>
   <td align="center" class="style10">
    <div style="height: 72px; width: 308px; margin-left:-50px;">
    <div style="color:White; font-size:20pt; margin-top:30px;" id="txt">
    </div>
    <div style="font-size: 20pt; height: 40px;">
    <asp:Label ID="Labeltime" ForeColor="White" runat="server" ></asp:Label>
    </div>
     
    </div>
    </td>
    </tr>
    </table>


    <div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick" Interval="5000">
    </asp:Timer>
       
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>  

    
    </form>
</body>
</html>


