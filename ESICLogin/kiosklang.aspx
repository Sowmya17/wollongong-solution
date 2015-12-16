<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kiosklang.aspx.cs" Inherits="kiosklang" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>KIOSK - Queue Management System</title>
   
  <link rel="stylesheet" type="text/css" href="CSS/StyleSheet1.css" />
     <style type="text/css">
         .style10
         {
             height: 70px;
         }
         .style11
         {
             width: 544px;
             height: 100px;
         }
     </style> 
</head>
<body > 
    <form id="form1" runat="server">
   
    <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Label ID="Label1" runat="server" Text="Welcome TO Wollongong Hospital(ISLHD) NSW2500 " Font-Size="XX-Large"></asp:Label>--%>
 

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
        </table>

         <table style="margin-top:80px; margin-left:800px;" 
        align="center">
        <tr>
        <td>
        <asp:Label ID="Label2" runat="server" Text="Please Choose" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="25pt" Font-Names="Arial Unicode MS" ></asp:Label>
                
        </td>
        
        </tr>
        </table>
        <table style="margin-top:0px; margin-left:680px;" 
        align="center">
        <tr>
        <td>
        <asp:Label ID="Label4" runat="server" Text=" Medicare Card or enter details" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="25pt" Font-Names="Arial Unicode MS" ></asp:Label>
                
        </td>
        
        </tr>
        </table>
        <table style="margin-top:0px; margin-left:700px;" 
        align="center">
        <tr>
        <td>
        <asp:Label ID="Label1" runat="server" Text="manually to join the queue" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="25pt" Font-Names="Arial Unicode MS" ></asp:Label>
                
        </td>
        
        </tr>
        </table>
       <table style="margin-top:29px; margin-left:600px; " 
        align="center" class="style11">
       
       <tr>
       <td class="style10"  >

       
               <asp:ImageButton ID="ImageButton2" runat="server" 
                            ImageUrl="~/images/cardimg.png" onclick="ImageButton2_Click1" 
                   Width="600px" Height="120px" AlternateText="CARD" BorderStyle="None" 
                   ForeColor="White" style="margin-left: 0px" />
           &nbsp;
           </td>
           </tr>
           </table>
           <table style="margin-top:0px; margin-left:600px; height: 70px;" 
        align="center">
       
      
           
           <tr>
            <td  >
            
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/images/manula.png" OnClick="Button1_Click" Width="600px" Height="120px" 
                            style="margin-top: 0px; margin-left: 0px;"  />
           &nbsp;</td>
       </tr>

        <tr>
            <td  >
            
                        <asp:ImageButton ID="ImageButton3" runat="server" 
                            ImageUrl="~/images/Walkin.png"  Width="600px" Height="120px" 
                            style="margin-top: 0px; margin-left: 0px;" 
                            onclick="ImageButton3_Click1"  />
           &nbsp;</td>
       </tr>
     
          
       </table>
    </form>
</body>
</html>

