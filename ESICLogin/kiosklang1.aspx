<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kiosklang1.aspx.cs" Inherits="kiosklang" %>

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


         
        <link rel="stylesheet" href="css/jsKeyboard1.css" type="text/css" media="screen"/>

        <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
        
        <script type="text/javascript" src="js/jsKeyboard1.js"></script>
        <script type="text/javascript" src="js/main1.js"></script>
   
        <script type="text/javascript">
            function trig() {
               
            }
        </script>
        <script type="text/javascript">

        $('#myText').live("keypress", function(e) {
        if (e.keyCode == 13) {
            alert("Enter pressed");
            return false; // prevent the button click from happening
        }
});
</script>

    <script type="text/javascript">
        function SetFocus() {
//            document.getElementById('<%=TextBox2.ClientID %>').focus();
            var b = document.getElementById('<%=TextBox2.ClientID %>').focus();
            return false;
        }
    </script>


      <script type="text/javascript">
          (function () {
              var bsa = document.createElement('script');
              bsa.type = 'text/javascript';
              bsa.async = true;

              (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(bsa);
          })();
      </script>
     <style type="text/css">
         .style7
         {
             width: 156px;
         }
         .style9
         {
             width: 11px;
         }
         .style10
         {
             height: 86px;
             margin-top: 126px;
         }
     </style> 
     <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />

</head>
<body onload="trig();" style="overflow:hidden;"> 
    <form id="form1" runat="server">
    
                 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                       
                <table style="margin-top:100px; margin-left:130px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label3" runat="server" Text="Please enter your surname and date of birth" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" Font-Names="Calibri" ></asp:Label>
                
                </td>
                </tr>
                </table>
       <table style="margin-top:70px; margin-left:280px; " 
        align="center">
            <tr>
            <td>
            
                <input class="input" name="input" type="hidden" />
                <asp:Label ID="Label2" runat="server" Text="Surname   " Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="30pt" ></asp:Label>
            </td>
            <td class="style9" >
            <asp:Label ID="Label4" runat="server" Text=":" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="30pt" ></asp:Label>
            </td>
                <td class="style7" >                      
                        
                        <asp:TextBox ID="TextBox1" runat="server" Width="400" Height="40" 
                            Font-Size="25pt"  ontextchanged="TextBox1_TextChanged" onkeydown = "return (event.keyCode!=13);" onclick="jsKeyboard.changeToSmallLetter();"  >
                            
                    </asp:TextBox>
                </td>
                <td class="style7" ><asp:ImageButton runat="server" 
                        ImageUrl="~/images/RUN-icon.png" ID="nextFocus" Width="45px" Height="45px" Visible="false"  
                       OnClientClick="jsKeyboard.changeToNumber(); return SetFocus(); "   />
                        </td>
            </tr>
            </table>
            <table style="margin-top:30px; margin-left:220px; " 
        align="center">
            <tr >
            <td >
            <asp:Label ID="Label1" runat="server" Text="Date of Birth" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="30pt"></asp:Label>
                </td>
                <td class="style9" >
            <asp:Label ID="Label5" runat="server" Text=":" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="30pt" ></asp:Label>
            </td>
                <td >                      
                       
              
                       <asp:TextBox ID="TextBox2" runat="server" Width="400" Height="40" 
                           Font-Size="25pt" onkeydown = "return (event.keyCode!=13);" onclick="jsKeyboard.changeToNumber();" ></asp:TextBox>
                
                 
                 
                       
               </td>
                <td >
            <asp:Label ID="Label6" runat="server" Text="Format : DD/MM/YYYY" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="20pt" ></asp:Label>
                </td>
            </tr>
               
            
            
            
       </table>
       <table style="margin-left:150px; margin-top:37px;">
       <tr>
       <td style="height:330px;">
        <div id="virtualKeyboard"></div>
       </td>
       </tr>
       </table>
       <table style="margin-left:0px; " class="style10">
       <tr>
       <td>
       
                <asp:ImageButton ID="ImageButton3" runat="server" Height="65px" 
                    ImageUrl="~/images/home.png" onclick="ImageButton3_Click1" Width="250px" />
       </td>
       <td>
       </td>
       <td style="width:800px;">
       
       </td>
       <td>
       
               <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/next.png" 
                       OnClick="ImageButton2_Click" Width="250px" Height="65px" 
                       ImageAlign="Bottom" style="margin-left: 100px;" />
       </td>
       </tr>
       </table>
    </form>
</body>
</html>

