<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kiosksuccess1.aspx.cs" Inherits="kioskhome" %>

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
  <table style="margin-top:200px; margin-left:300px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label5" runat="server" Text="Please Collect Your Q-Ticket" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
       <table style=" margin-left:351px; margin-top:60px; ">
                <tr>
                <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/print.png" 
                        Height="300px" />
                </td>
                </tr>
                
                </table>       
       <table style="margin-top:70px; margin-left:70px;" 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label1" runat="server" Text="Please make your way to reception to check your details." Font-Bold="True" ForeColor="Brown"
                    Font-Size="25pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
       <table style="margin-top:186px;">
        <tr>
            <td align="center">
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/home.png" 
                    OnClick="ImageButton3_Click" Width="250px" Height="65px" 
                    ImageAlign="Top" />
            </td>
            <td style="width:850px;">
            </td>
            <td>
            </td>
               <td>
               <asp:ImageButton 
                                    ID="ImageButton1" runat="server" Name="Register Number" Height="55px" 
                                    onclick="ImageButton1_Click" style="margin-left: 0px" Width="200px" 
                                    ImageAlign="Top" ImageUrl="~/images/rmobile.png" 
                       Visible="False" />
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
