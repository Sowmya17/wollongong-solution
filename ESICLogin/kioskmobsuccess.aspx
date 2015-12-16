<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskmobsuccess.aspx.cs" Inherits="kiosklang" %>

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
  <table style="margin-top:300px; margin-left:130px;height:40pt; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label5" runat="server" Text="Please take your ticket, and remain in the waiting area," Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
                <table style="margin-top:0px; margin-left:400px; height:40pt;" 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label2" runat="server" Text="we will serve you shortly." Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
                 <table style="margin-top:0px; margin-left:60px; height:40pt; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label3" runat="server" Text="Your personal information has been successfully registered." Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
            
       <table style="margin-top:50px; margin-left:500px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label1" runat="server" Text="Thank You" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="40pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
       <table style="margin-top:340px; ">
        <tr>
            <td align="center">
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/home.png" 
                    OnClick="ImageButton3_Click" Width="200px" Height="55px" 
                    ImageAlign="Middle" />
            </td>
            <td>
            </td>
               <td>
                   &nbsp;</td>
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

