<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CounterDisplay.aspx.cs" Inherits="CounterDisplay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
    .col
    {
        border-right: 2px solid white;
    }
    </style>
   
    <script type="text/javascript" src="js/speech.js"></script>
    <script type="text/javascript">
        function play() {
            $('<audio id="chatAudio"><source src="notify.mp3" type="audio/mpeg"><source src="notify.ogg" type="audio/ogg"><source src="notify.wav" type="audio/wav"></audio>').appendTo('body');



            $('#chatAudio')[0].play();
        }
</script>
  
    </head>
<body style=" background-color:Gray; height:100%;">

    <form id="form1" runat="server">

    
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
       

        
    
    <table style="width:1080px;height:600px; " cellpadding="0" cellspacing="0">
    
   <tr style="width:1080px; height:50%; background-color:#a028f7;" >
   <td style="width:440px; text-align:center; font-size:30pt; font-weight:bolder;">
     <asp:UpdatePanel ID="UpdatePanel65" runat="server">
        <ContentTemplate>
            <asp:Image ID="Image1" runat="server" Width="440" Height="600" 
                ImageUrl="~/images/doctor.png" AlternateText="Doctor Image" />
           </ContentTemplate>
        </asp:UpdatePanel>
    </td>
    <td>
    <table>
    <tr style="width:640px; height:150px; background-color:#a028f7;">
    
    
        <td  style="width:640px;text-align:center; font-size:75pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
        <asp:Label ID="lbl_deptname11" runat="server" Text="" ForeColor="white"></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        
    
    </tr>
    <tr style="width:640px; height:150px; background-color:#cccccc;">
    
    
        <td  style="width:640px;text-align:center; font-size:75pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
        <asp:Label ID="lbl_dname11" runat="server"  ForeColor="Black"></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
        
    
    </tr>

    <tr style="width:640px; height:150px; background-color:#a028f7;" >
    
       
        

        <td  style="width:640; text-align:center; font-size:75pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
        <ContentTemplate>
        <asp:Label ID="Label2" runat="server" Text="Token N0"  ForeColor="white" ></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
           
    
    </tr>
      <tr style="width:640px; height:150px; background-color:#cccccc;" >
    
       
        

        <td  style="width:640; text-align:center; font-size:75pt; font-weight:bolder;">
    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
        <asp:Label ID="lbl_queue11" runat="server"  ForeColor="Black" ></asp:Label>
           </ContentTemplate>
        </asp:UpdatePanel>
        </td>
           
    
    </tr>

    
    
      
    </table>
    
    </td>

        

        
    
    </tr>
    
  

     
    </table>
    


    <table style="width: 1080px; height:28px;"  cellpadding="0" cellspacing="0">
    <tr style="width:1080px;background-color:Black;">
    <td style="width:175px;">
        <asp:Image ID="Image3" runat="server" Height="42px" Width="172px" 
            ImageUrl="~/images/dm_health_care1.jpg" />
    </td>

    <td style="width:780px; text-align:center; font-size:30pt; font-weight:bolder;" >
    
      <marquee direction="left" loop="true">
              <asp:Label ID="Label7" ForeColor="White" runat="server" Text="Welcome To DM HealthCare Hospital Powered By ATT SYSTEMSGROUP PVT LTD. Welcome To DM HealthCare Hospital Powered By ATT SYSTEMSGROUP PVT LTD. Welcome To DM HealthCare Hospital Powered By ATT SYSTEMSGROUP PVT LTD. Welcome To DM HealthCare Hospital Powered By ATT SYSTEMSGROUP PVT LTD."></asp:Label></marquee>

      
      </td>
        
    <td style="width:125px; " align="right">
        
        <asp:Image ID="Image4" runat="server" Height="42px" Width="143px"  
            ImageUrl="~/images/qsoftAnimatedBig.gif" style="margin-left: 0px" />
            
    </td>
    </tr>
    </table>
        
    



    </div>

    
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
