<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskfail.aspx.cs" Inherits="kiosklang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>KIOSK - Queue Management System</title>
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
  
     
  
     </head>
<body> 
    <form id="form1" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  <table style="margin-top:250px; margin-left:250px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label5" runat="server" Text="Sorry, your details are not registered" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
          
       <table style="margin-top:50px; margin-left:250px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label1" runat="server" Text="Please go to the reception counter for assistance." Font-Bold="True" ForeColor="Brown"
                    Font-Size="27pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
                   <table style="margin-top:50px; margin-left:500px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label2" runat="server" Text="Thank You" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
               
       <table style="margin-top:180px; ">
        <tr>
            <td align="center">
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/home.png" 
                    OnClick="ImageButton3_Click" Width="200px" Height="45px" 
                    ImageAlign="Middle" />
            </td>
               
            </tr>
       </table>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="9000">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>

