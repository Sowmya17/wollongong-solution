<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskservices.aspx.cs" Inherits="kioskservices" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>KIOSK - Queue Management System</title>
    <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
  
     <style type="text/css">
          .button 
         {
             -moz-border-radius: 20px;
             -webkit-border-radius: 20px;
             -khtml-border-radius: 20px;
              
         }
         .style6
         {
             width: 871px;
             margin-top:50px;
         }
         </style> 
</head>
<body> 
    <form id="form1" runat="server">
   
    <table style="margin-top:110px; margin-left:200px; " 
        align="center">
                <tr>
                <td align="center">
                <asp:Label ID="Label5" runat="server" Text="Sorry, you dont have an appointment scheduled for today," Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="28pt" ></asp:Label>
                
                </td>
                </tr>
                 <tr>
                <td align="center">
                <asp:Label ID="Label1" runat="server" Text=" Please Select the Service to set an appointment." Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="28pt" ></asp:Label>
                
                </td>
                </tr>
                </table>

    <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Label ID="Label1" runat="server" Text="Welcome TO Wollongong Hospital(ISLHD) NSW2500 " Font-Size="XX-Large"></asp:Label>--%>
       <table style="margin-top:50px; margin-left:150px;" 
        align="center">
       <tr>
       <td class="style6" align="center">
           <%--<asp:Label ID="Label1" runat="server" Text="Welcome TO Wollongong Hospital(ISLHD) NSW2500" Font-Size="XX-Large"></asp:Label>--%>
           <asp:Button CssClass="button" ID="btn_service1" runat="server" Height="100px" 
                                onclick="btn_service1_Click" Text="Service1" Width="400px" 
                                BackColor="Silver" Font-Bold="True" Font-Names="Arial Black" 
                                Font-Size="30pt" ForeColor="Gray"/>
       </td>
       <td class="style6" align="left">
           
           <asp:Button CssClass="button" ID="btn_service2" runat="server" Height="100px" 
                                onclick="btn_service2_Click" Text="Service2" Width="400px" 
                                BackColor="Silver" Font-Bold="True" Font-Names="Arial Black" 
                                Font-Size="30pt" ForeColor="Gray" />
           </td>
       </tr>
       <tr>
       <td class="style6" align="center">
           <asp:Button CssClass="button" ID="btn_service3" runat="server" Height="100px" 
                                onclick="btn_service3_Click" Text="Service3" Width="400px" 
                                BackColor="Silver" Font-Bold="True" Font-Names="Arial Black" 
                                Font-Size="30pt" ForeColor="Gray" />
           </td>
           <td class="style6" align="left">
               <asp:Button CssClass="button" ID="btn_service4" runat="server" Height="100px" 
                                onclick="btn_service4_Click" Text="Service4" Width="400px" 
                                BackColor="Silver" Font-Bold="True" Font-Names="Arial Black" 
                                Font-Size="30pt" ForeColor="Gray" />
           </td>
       </tr>
       <tr>
       <td class="style6" style="text-align: center">
           <asp:Button CssClass="button" ID="btn_service5" runat="server" Height="100px" 
                                onclick="btn_service5_Click" Text="Service5" Width="400px" 
                                BackColor="Silver" Font-Bold="True" Font-Names="Arial Black" 
                                Font-Size="30pt" ForeColor="Gray" />
           </td>
           <td class="style6" align="left">
               <asp:Button CssClass="button" ID="btn_service6" runat="server" Height="100px" 
                                onclick="btn_service6_Click" Text="Service6" Width="400px" 
                                BackColor="Silver" Font-Bold="True" Font-Names="Arial Black" 
                                Font-Size="30pt" ForeColor="Gray" />
           </td>
       </tr>
            <tr>
                <td class="style6" style="text-align: right">                      
                <input id="Hidden1" type="hidden" runat="server" />
                <input id="Hidden2" type="hidden" runat="server" />
                <input id="Hidden3" type="hidden" runat="server" />
                <input id="Hidden4" type="hidden" runat="server" />
                <input id="Hidden5" type="hidden" runat="server"/>
                <input id="Hidden6" type="hidden" runat="server" />
                <input id="Hidden7" type="hidden" runat="server"/>
                <input id="Hidden8" type="hidden" runat="server" />
               </td>
               <td class="style6" style="text-align: right">
                        
               </td>
            </tr>
       </table>
       <table style="margin-top:130px; ">
        <tr>
            <td align="center">
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/home.png" 
                    OnClick="ImageButton3_Click" Width="200px" Height="45px" 
                    ImageAlign="Middle" />
            </td>
           
            </tr>
       </table>
    </form>
</body>
</html>


