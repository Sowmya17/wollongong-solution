<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskfailure.aspx.cs" Inherits="kiosklang" %>

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
  <table style="margin-top:110px; margin-left:350px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label5" runat="server" Text="Please Collect Your Q-Ticket" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
       <table style=" margin-left:430px; margin-top:50px; ">
                <tr>
                <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/print.png" />
                </td>
                </tr>
                
                </table>       
       <table style="margin-top:50px; margin-left:50px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label1" runat="server" Text="Please procced to the department waiting area indicated in your Q-Ticket" Font-Bold="True" ForeColor="Brown"
                    Font-Size="27pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
       <table style="margin-top:135px; ">
        <tr>
            <td align="center">
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/home.png" 
                    OnClick="ImageButton3_Click" Width="200px" Height="55px" 
                    ImageAlign="Top" />
            </td>
            <td style="width:850px;">
            </td>
            <td>
            </td>
               <td>
               <asp:ImageButton 
                                    ID="ImageButton1" runat="server" Name="Register Number" Height="55px" 
                                     style="margin-left: 0px" Width="200px" 
                                    ImageAlign="Top" ImageUrl="~/images/rmobile.png" />
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

