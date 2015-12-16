<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskemail.aspx.cs" Inherits="kiosklang" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
       <title>KIOSK - Queue Management System</title>
        <meta name="description" content="">
        <meta name="keywords" content="jQuery OnScreen Keyboard">
        <meta name="viewport" content="width=device-width">


         
        <link rel="stylesheet" href="css/jsKeyboard.css" type="text/css" media="screen"/>
        
        

      <script type="text/javascript">
          (function () {
              var bsa = document.createElement('script');
              bsa.type = 'text/javascript';
              bsa.async = true;

              (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(bsa);
          })();
      </script>
    
  
    
     <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />

     <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
        
        <script type="text/javascript" src="js/jsKeyboard.js"></script>
        <script type="text/javascript" src="js/main.js"></script>





 

     <style type="text/css">
         .style1
         {
             height: 59px;
         }
         .style2
         {
             width: 520px;
             height: 59px;
         }
         .style3
         {
             height: 111px;
         }
     </style>





 

</head>
<body onload="" style="overflow:hidden;" > 
    <form id="form1" runat="server">
                       
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <table style="margin-top:60px; margin-left:100px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label3" runat="server" 
                        Text="To be notified by an SMS when we are ready to see you," 
                        Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
     
                
                </td>
                </tr>
                </table>
                <table style="margin-top:0px; margin-left:220px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label4" runat="server" 
                        Text="please enter your phone number or skip." 
                        Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
       <table style="margin-top:80px; margin-left:150px;" 
        align="center">
            
            <tr>
            <td >
            <asp:Label ID="Label1" runat="server" Text="Mobile Number" Font-Bold="True" ForeColor="DarkSlateGray" 
                    Font-Size="30pt"></asp:Label>
                </td>
                <td>
            <asp:Label ID="Label5" runat="server" Text=":" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="30pt" ></asp:Label>
            </td>
                <td >                      
                       
              
                       <asp:TextBox ID="TextBox2" runat="server" Width="400" Height="40" Font-Size="20pt" onkeydown = "return (event.keyCode!=13);" onclick="jsKeyboard.changeToNumber();"></asp:TextBox>
                
                 
                 
                       
               </td>
               <td>
               </td>
               <td  valign="middle">
                       
                
            <asp:Label ID="Label7" runat="server" Text="Format : 04 xxxx xxxx" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="20pt" ></asp:Label>
                </td>
            </tr>
           
       </table>
        <table style="margin-left:440px; margin-top:40px;">
       <tr>
       <td class="style3">
        <div id="virtualKeyboard"></div>
       </td>
       </tr>
       </table>

       <table style="margin-top:180px;">
       <tr>
            <td class="style1">
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/home.png" 
                    OnClick="ImageButton3_Click" Width="250px" Height="65px" 
                    ImageAlign="Top" />
            </td>
            <td class="style2">
            </td>
                <td class="style1">                      
                        
                
                    <asp:ImageButton ID="ImageButton4" runat="server" Height="65px" Width="250px" 
                        ImageUrl="~/images/skip.png" onclick="ImageButton4_Click" 
                        style="margin-left: 10px; margin-top: 0px" />
                        
                
               </td>
               <td  align="right" class="style1">
               <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/next.png" 
                       OnClick="ImageButton2_Click" Width="250px" Height="65px" 
                       ImageAlign="Top" />
               </td>
            </tr>
       </table>
    </form>
</body>
</html>

