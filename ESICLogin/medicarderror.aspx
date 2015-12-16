<%@ Page Language="C#" AutoEventWireup="true" CodeFile="medicarderror.aspx.cs" Inherits="medicarderror" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>KIOSK - Queue Management System</title>
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
  
     
  
     <style type="text/css">
         .style1
         {
             width: 1132px;
         }
     </style>
  
     
  
     </head>
<body style="overflow:hidden;"> 
    <form id="form1" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  <table style="margin-top:250px; margin-left:100px; text-align: center" 
        align="center">
                <tr>
                <td class="style1">
                <asp:Label ID="Label5" runat="server" Text="Please swipe with a valid Medicare card" Font-Bold="True" ForeColor="Red"
                    Font-Size="50pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
       
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="5000">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

