<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskhome2.aspx.cs" Inherits="kioskhome2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/StyleSheet4.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div >
    <table style="margin-top:451px; margin-left:705px; width: 544px; height: 100px;"  
        align="center">
       
       <tr>
       <td class="style10">

       
               <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/images/yes.png" onclick="ImageButton1_Click1" 
                   Width="494px" Height="120px" AlternateText="CARD" BorderStyle="None" 
                   ForeColor="White" style="margin-left: 0px" />
           &nbsp;
           </td>
           </tr>
           </table>
           <table style="margin-top:53px; margin-left:705px; width: 544px; height: 158px;" 
        align="center">
       
       <tr>
       <td class="style10"  >

       
               <asp:ImageButton ID="ImageButton2" runat="server" 
                            ImageUrl="~/images/no.png" onclick="ImageButton2_Click1" 
                   Width="484px" Height="120px" AlternateText="CARD" BorderStyle="None" 
                   ForeColor="White" style="margin-left: 0px" />
           &nbsp;
           </td>
           </tr>
           </table>
    </div>
    </form>
</body>
</html>

