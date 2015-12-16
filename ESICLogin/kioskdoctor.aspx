<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskdoctor.aspx.cs" Inherits="kiosklang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>KIOSK - Queue Management System</title>
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
  
     <style type="text/css">
         .style1
         {
             height: 100px;
             width: 373px;
         }
         .style2
         {
             width: 208px;
         }
         .style3
         {
             width: 201px;
         }
     </style> 
</head>
<body> 
    <form id="form1" runat="server">
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Label ID="Label1" runat="server" Text="Welcome to the UNIVERSITY OF SYDNEY " Font-Size="XX-Large"></asp:Label>
       
       <table style="margin-top:100px; margin-left:50px;">
            <tr>
            <td class="style3">
                <asp:Label ID="Label3" runat="server" Text="Selected Service is"></asp:Label>
            </td>
                <td class="style1">                      
                <asp:Label ID="Label2" runat="server" Text="Enter Sur Name"></asp:Label>
                </td>
               <td class="style2">
               </td>
            </tr>
            <tr>
            <td class="style3">
            
                <input id="Hidden1" type="hidden" runat="server" />
                <input id="Hidden2" type="hidden" runat="server" />
                <input id="Hidden3" type="hidden" runat="server" />
                <input id="Hidden4" type="hidden" runat="server" />
                <input id="Hidden5" type="hidden" runat="server"/>
                <input id="Hidden6" type="hidden" runat="server" />
                <input id="Hidden7" type="hidden" runat="server"/>
                <input id="Hidden8" type="hidden" runat="server" />
                &nbsp;</td>
                <td class="style1">                      
                       
                
                    &nbsp;</td>
               <td class="style2">
               </td>
            </tr>
            <tr>
            <td class="style3">
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/home.png" OnClick="ImageButton3_Click" />
            </td>
                <td class="style1">                      
                        
                
               </td>
               <td class="style2">
               <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/next.png" 
                       OnClick="ImageButton2_Click" Width="175px" />
               </td>
            </tr>
       </table>
    </form>
</body>
</html>

