<%@ Page Language="C#" AutoEventWireup="true" Async="true" CodeFile="Display.aspx.cs" Inherits="Display" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
       
        
    .col
    {
        border-right: 2px solid white;
    }
        .style4
        {
            width: 14%;
            height: 7px;
        }
        .style5
        {
            width: 13%;
            height: 7px;
        }
        .style6
        {
            width: 31%;
        }
        .style7
        {
            width: 32%;
        }
        .style8
        {
            width: 15%;
            height: 7px;
        }
        .style9
        {
            width: 7%;
        }
        
        .style10
        {
            height: 60px;
            
        }
        
        .style11
        {
            height: 60px;
            width: 60px;
        }
        
    </style>
   
    <script type="text/javascript" src="js/speech.js"></script>

    <script type="text/javascript">
        function play() {
            $('<audio id="chatAudio"><source src="notify.mp3" type="audio/mpeg"><source src="notify.ogg" type="audio/ogg"><source src="notify.wav" type="audio/wav"></audio>').appendTo('body');



            $('#chatAudio')[0].play();
        }
</script>
<script type="text/javascript">
function speak(text) {
  // Create a new instance of SpeechSynthesisUtterance.
	var msg = new SpeechSynthesisUtterance();
	
	// Set the text.

	msg.text = text;
     // Queue this utterance.
	window.speechSynthesis.speak(msg);
}
</script>
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
         document.getElementById('txt').innerHTML = h + ":" + m + ":" + s+" "+ampm;
         t = setTimeout(function () { startTime() }, 500);
     }

     function checkTime(i) {
         if (i < 10) {
             i = "0" + i;
         }
         return i;
     }
    </script>
   

  
    </head>
<body style=" background-image:url(images/Background.jpg);  background-repeat:no-repeat; overflow:hidden; font-family:Calibri;" onload="startTime()">

    <form id="form1" runat="server">

    
    <div >
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

       

    
    
        <br />
        <br />
        <br />
       

    
    
    <table style="width:1200px;height:460px; margin-top: 252px;" cellpadding="0" 
            cellspacing="0">
    
  <%-- <tr style="width:1300px; height:53.5px;" >
    <td  style="width:16%; text-align:center; font-size:34pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
        <asp:Label ID="Label1" runat="server" Text=" Queue " ForeColor="White"></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        
        </td>
        <td  style="width:28%; text-align:center; font-size:34pt; font-weight:bolder;">
        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
        <asp:Label ID="Label2" runat="server" Text=" Room " ForeColor="white" ></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        
    <td  style="width:0%;text-align:center; font-size:34pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
        <asp:Label ID="Label3" runat="server" Text=" Queue " ForeColor="white"></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        
        </td>
        

        <td  style="width:25%;text-align:center; font-size:34pt; font-weight:bolder;">
        <asp:UpdatePanel ID="UpdatePanel44" runat="server">
        <ContentTemplate>
        <asp:Label ID="Label13" runat="server" Text=" Room " ForeColor="white"  ></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        
        </td>
        
        <td  style="width:30%;text-align:center; font-size:34pt; font-weight:bolder;">
        <asp:UpdatePanel ID="UpdatePanel45" runat="server">
        <ContentTemplate>
        <asp:Label ID="Label14" runat="server" Text=" Queue" ForeColor="white"></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        
        </td>

        <td style="width:30%;text-align:center; font-size:34pt; font-weight:bolder;">
        <asp:UpdatePanel ID="UpdatePanel25" runat="server">
        <ContentTemplate>
        <asp:Label ID="Label15" runat="server" Text=" Room " ForeColor="white"></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>

    
    </tr>--%>
    
    <tr style="width:1200px; height:53.5px;padding-bottom:0px; padding-top:0px; " >
    <td   style="text-align:center; font-size:45pt; font-weight:bolder;" class="style9">
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" style=" width:180px;">
        <ContentTemplate>
      <asp:Label ID="lbl_queue11" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td  style="width:15%; text-align:center; font-size:45pt; font-weight:bolder;">
        <asp:UpdatePanel ID="UpdatePanel7" runat="server" style="width: 180px;">
        <ContentTemplate>
         <asp:Label ID="lbl_room11" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel8" runat="server" style="width: 180px; margin-left:75px;">
        <ContentTemplate>
            <asp:Label ID="lbl_queue17" runat="server" ForeColor="Black" Text=""></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
            <td  style="text-align:center; font-size:45pt; font-weight:bolder;" 
            class="style6">
        <asp:UpdatePanel ID="UpdatePanel46" runat="server" style="width: 180px; margin-left:25px;">
            <ContentTemplate>
                <asp:Label ID="lbl_room17" runat="server" ForeColor="Black" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        </td>


    <td  style="text-align:center; font-size:45pt; font-weight:bolder;" class="style7">
    <asp:UpdatePanel ID="UpdatePanel47" runat="server" style="width: 180px; margin-left:40px;">
    <ContentTemplate>
            <asp:Label ID="lbl_queue29" runat="server" ForeColor="Black" Text=""></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td style="text-align:center; font-size:45pt; font-weight:bolder;" class="style7">
    <asp:UpdatePanel ID="UpdatePanel28" runat="server" style="width: 180px; margin-left:40px;">
        <ContentTemplate>
        <asp:Label ID="lbl_room23" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>

    <tr style="width:1200px; height:53.5px;">
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;" class="style9">
    <asp:UpdatePanel ID="UpdatePanel9" runat="server" style="width: 180px;">
        <ContentTemplate>
        <asp:Label ID="lbl_queue12" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td  style="width:15%; text-align:center; font-size:45pt; font-weight:bolder;">
        <asp:UpdatePanel ID="UpdatePanel10" runat="server" style="width: 180px;">
        <ContentTemplate>
        <asp:Label ID="lbl_room12" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel11" runat="server" style="width: 180px; margin-left: 75px;">
        <ContentTemplate>
            <asp:Label ID="lbl_queue18" runat="server" ForeColor="Black" Text=""></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>

            <td  style="text-align:center; font-size:45pt; font-weight:bolder;" 
            class="style6">
        <asp:UpdatePanel ID="UpdatePanel48" runat="server" style="width: 180px; margin-left: 25px;">
            <ContentTemplate>
                <asp:Label ID="lbl_room18" runat="server" ForeColor="Black" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        </td>


        <%--Froom here--%>


    <td  style="text-align:center; font-size:45pt; font-weight:bolder;" class="style7">
    <asp:UpdatePanel ID="UpdatePanel49" runat="server" style=" width: 180px; margin-left: 40px ;">
    <ContentTemplate>
            <asp:Label ID="lbl_queue30" runat="server" ForeColor="Black" Text=""></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
     <td style="text-align:center; font-size:45pt; font-weight:bolder;" class="style7">
    <asp:UpdatePanel ID="UpdatePanel31" runat="server" style=" width: 180px; margin-left: 40px ;">
        <ContentTemplate>
        <asp:Label ID="lbl_room24" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>

    <tr style="width:1200px; height:53.5px;">
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;" class="style9">
    <asp:UpdatePanel ID="UpdatePanel12" runat="server" style=" width: 180px;">
        <ContentTemplate>
        <asp:Label ID="lbl_queue13" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td  style="width:15%; text-align:center; font-size:45pt; font-weight:bolder;">
        <asp:UpdatePanel ID="UpdatePanel13" runat="server" style=" width: 180px;">
        <ContentTemplate>
        <asp:Label ID="lbl_room13" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>



    <td  style="text-align:center; font-size:45pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel14" runat="server" style=" width: 180px; margin-left: 75px;">
        <ContentTemplate>
        <asp:Label ID="lbl_queue19" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>

        <td  style="text-align:center; font-size:45pt; font-weight:bolder;" 
            class="style6">
        <asp:UpdatePanel ID="UpdatePanel50" runat="server" style=" width: 180px; margin-left: 25px;">
            <ContentTemplate>
                <asp:Label ID="lbl_room19" runat="server" ForeColor="Black" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;" class="style7">
    <asp:UpdatePanel ID="UpdatePanel51" runat="server" style=" width: 180px; margin-left :40px;">
    <ContentTemplate>
            <asp:Label ID="lbl_queue31" runat="server" ForeColor="Black" Text=""></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td style="text-align:center; font-size:45pt; font-weight:bolder;" 
            class="style7">
    <asp:UpdatePanel ID="UpdatePanel34" runat="server" style=" width: 180px; margin-left :40px">
        <ContentTemplate>
        <asp:Label ID="lbl_room25" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    
    </tr>

    <tr style="width:1200px; height:53.5px;">
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;" class="style9">
    <asp:UpdatePanel ID="UpdatePanel15" runat="server" style=" width: 180px;">
        <ContentTemplate>
        <asp:Label ID="lbl_queue14" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td  style="width:15%; text-align:center; font-size:45pt; font-weight:bolder;">
        <asp:UpdatePanel ID="UpdatePanel16" runat="server" style=" width: 180px;">
        <ContentTemplate>
        <asp:Label ID="lbl_room14" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel17" runat="server" style=" width: 180px; margin-left: 75px;">
        <ContentTemplate>
        <asp:Label ID="lbl_queue20" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>

        <td  style="text-align:center; font-size:45pt; font-weight:bolder;" 
            class="style6">
        <asp:UpdatePanel ID="UpdatePanel52" runat="server" style=" width: 180px; margin-left: 25px;">
            <ContentTemplate>
                <asp:Label ID="lbl_room20" runat="server" ForeColor="Black" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;" class="style7">
    <asp:UpdatePanel ID="UpdatePanel53" runat="server" style=" width: 180px; margin-left: 40px;">
    <ContentTemplate>
            <asp:Label ID="lbl_queue33" runat="server" ForeColor="Black" Text=""></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td style="text-align:center; font-size:45pt; font-weight:bolder;" class="style7">
    <asp:UpdatePanel ID="UpdatePanel37" runat="server" style=" width: 180px; margin-left: 40px;">
        <ContentTemplate>
        <asp:Label ID="lbl_room26" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>

    <tr style="width:1200px; height:53.5px;">
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;" class="style9">
    <asp:UpdatePanel ID="UpdatePanel18" runat="server" style=" width: 180px;">
        <ContentTemplate>
        <asp:Label ID="lbl_queue15" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td  style="width:15%; text-align:center; font-size:45pt; font-weight:bolder;">
        <asp:UpdatePanel ID="UpdatePanel19" runat="server" style=" width: 180px;">
        <ContentTemplate>
        <asp:Label ID="lbl_room15" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel20" runat="server" style=" width: 180px; margin-left: 75px;">
        <ContentTemplate>
        <asp:Label ID="lbl_queue21" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>

        <td  style="text-align:center; font-size:45pt; font-weight:bolder;" 
            class="style6">
        <asp:UpdatePanel ID="UpdatePanel54" runat="server" style=" width: 180px; margin-left: 25px" >
            <ContentTemplate>
                <asp:Label ID="lbl_room21" runat="server" ForeColor="Black" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td  style="text-align:center; font-size:45pt; font-weight:bolder;" class="style7">
    <asp:UpdatePanel ID="UpdatePanel55" runat="server" style=" width: 180px; margin-left: 40px;">
    <ContentTemplate>
            <asp:Label ID="lbl_queue34" runat="server" ForeColor="Black" Text=""></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td style="text-align:center; font-size:45pt; font-weight:bolder;" class="style7">
    <asp:UpdatePanel ID="UpdatePanel40" runat="server" style=" width: 180px; margin-left: 40px;">
        <ContentTemplate>
        <asp:Label ID="lbl_room27" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>
    

    <%--<tr style="width:1200px; height:53.5px;">
    <td  style="text-align:center; font-size:30pt; font-weight:bolder;" class="style9">
    <asp:UpdatePanel ID="UpdatePanel21" runat="server" style=" width: 180px;">
        <ContentTemplate>
        <asp:Label ID="lbl_queue16" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td  style="width:15%; text-align:center; font-size:30pt; font-weight:bolder;">
        <asp:UpdatePanel ID="UpdatePanel22" runat="server" style=" width: 180px;">
        <ContentTemplate>
        <asp:Label ID="lbl_room16" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td  style="text-align:center; font-size:28pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel23" runat="server" style=" width: 180px; margin-left: 75px;">
        <ContentTemplate>
            <asp:Label ID="lbl_queue22" runat="server" ForeColor="Black" Text=""></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>

        <td  style="text-align:center; font-size:30pt; font-weight:bolder;" 
            class="style6">
        <asp:UpdatePanel ID="UpdatePanel56" runat="server" style=" width: 180px; margin-left: 25px;">
            <ContentTemplate>
                <asp:Label ID="lbl_room22" runat="server" ForeColor="Black" Text=""></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    <td  style="text-align:center; font-size:30pt; font-weight:bolder;" class="style7">
    <asp:UpdatePanel ID="UpdatePanel57" runat="server" style=" width: 180px; margin-left: 40px;">
    <ContentTemplate>
            <asp:Label ID="lbl_queue35" runat="server" ForeColor="Black" Text=""></asp:Label>
        </ContentTemplate>
        </asp:UpdatePanel>
        </td>

        <td style="text-align:center; font-size:30pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel43" runat="server" style=" width: 180px; margin-left:40px;">
        <ContentTemplate>
        <asp:Label ID="lbl_room28" ForeColor="Black" runat="server" Text=""></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>--%>
     
    </table>
   <%-- <table style="width:1397px; height:71px; border-top-style: none; border-top-color: inherit; border-top-width: 0px;"  
            cellpadding="0" cellspacing="0">
    <tr style="width:100%;">
    
    <td style="text-align:center; font-size:30pt; font-weight:bolder;" class="style3">
    <asp:UpdatePanel ID="UpdatePanel97" runat="server">
        <ContentTemplate>
            <br />
        <asp:Label ID="Label40" ForeColor="White" runat="server" Text="Missed Queue Number"></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>
    </table> --%>
    <table style="width:1397px; height:158px; border-top-style: none; border-top-color: inherit; border-top-width: 0px;"  
            cellpadding="0" cellspacing="0">
    <tr style="width:100%;">
    <div>
    <td style="text-align:center; font-size:45pt; font-weight:bolder;" class="style5">
    <asp:UpdatePanel ID="UpdatePanel98" runat="server" style="margin-top:115px;">
        <ContentTemplate>
        <asp:Label ID="Label47" ForeColor="White" runat="server" ></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td style="text-align:center; font-size:45pt; font-weight:bolder;" class="style4">
    <asp:UpdatePanel ID="UpdatePanel99" runat="server" style="margin-top:115px;">
        <ContentTemplate>
        <asp:Label ID="Label48" ForeColor="White" runat="server" ></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td style="text-align:center; font-size:45pt; font-weight:bolder;" 
            class="style8">
    <asp:UpdatePanel ID="UpdatePanel100" runat="server" style="margin-top:115px;">
        <ContentTemplate>
        <asp:Label ID="Label49" ForeColor="White" runat="server" ></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        <td style="text-align:center; font-size:45pt; font-weight:bolder;" 
            class="style8">
    <asp:UpdatePanel ID="UpdatePanel101" runat="server" style="margin-top:115px;">
        <ContentTemplate>
        <asp:Label ID="Label50" ForeColor="White" runat="server" ></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        </div>
    </tr>
    
    </table>


    
        
    
    </div>
    <table>
    <tr>
    <td class="style11">
    <div  style="width:925px; height: 28px; background: black none repeat scroll 0% 0%; margin: 35px 0px 0px 135px; border-right-style: solid; border-bottom-width: 0px; border-bottom-style: solid; padding-bottom: 0px; border-left-width: 0px; border-left-style: solid; padding-left: 0px; padding-right: 1px; border-right-width: 0px;">

    <marquee style="margin-left: 5px; font-size: 35px; color: White; width: 896px;" loop="true" direction="left">
   <%-- <html:div style="display: -moz-box; overflow: hidden; width: -moz-available; margin-right: -324px;">
    </html:div>  --%>
    "*Welcome to the Wollongong Hospital Ambulatory Care Centre. Q'Soft is powered by ATT Systems Group * * Please note that queue ticket numbers will not be called in order, ticket number will be called based on your appointment time.*"
    
            </marquee>
           
             
    </div>
    </td>
    <td align="center" class="style10">
    <div style="height: 72px; width: 308px; margin-left:-50px;">
    <div style="color:White; font-size:20pt; margin-top:12px;" id="txt">
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
