<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskhome.aspx.cs" Inherits="kioskhome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/StyleSheet3.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <table style="margin-top:55px; margin-left:750px;" 
        align="center">
        <tr style="margin-left:25px;">
        <td  >
        <asp:Label ID="Label3" runat="server" Text="Welcome to the" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" Font-Names="Arial Unicode MS" ></asp:Label>
                
        </td>
        
        </tr>
       
        </table>

        <table style="margin-top:0px; margin-left:655px;" 
        align="center">
       
        <tr>
        <td>
        <asp:Label ID="Label6" runat="server" Text="Ambulatory Care Centre" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" Font-Names="Arial Unicode MS" ></asp:Label>
                
        </td>
        
        </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>

                    <asp:Label ID="Label1" runat="server" font-style="Calibri" Font-Bold="true" Font-Size="275%" Text="Do you have an appointment?"></asp:Label>
                  </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>

       
               <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/images/yes.png" onclick="ImageButton1_Click1" 
                   Width="494px" Height="120px" AlternateText="CARD" BorderStyle="None" 
                   ForeColor="White" style="margin-left: 0px" />

       
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>

       
               <asp:ImageButton ID="ImageButton2" runat="server" 
                            ImageUrl="~/images/no.png" onclick="ImageButton2_Click1" 
                   Width="484px" Height="120px" AlternateText="CARD" BorderStyle="None" 
                   ForeColor="White" style="margin-left: 0px" />
                </td>
            </tr>
        </table>
       
    <div >
    <table style="margin-top:449px; margin-left:705px; width: 544px; height: 100px;" 
        align="center">
       
       <tr>
       <td class="style10"  >

       
           &nbsp;
           </td>
           </tr>
           </table>
           <table style="margin-top:52px; margin-left:705px; width: 544px; height: 158px;" 
        align="center">
       
       <tr>
       <td class="style10"  >

       
           &nbsp;
           </td>
           </tr>
           </table>
    </div>
    </form>
</body>
</html>
