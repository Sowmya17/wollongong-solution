<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskdept.aspx.cs" Inherits="kioskdept" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
      <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />
    <title>KIOSK - Queue Management System</title>
   

   
    <style type="text/css">
        .style6
        {
            width: 800px;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="margin-top:150px; margin-left:300px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label3" runat="server" Text="you have an appointment today for" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
     <table style="margin-top:50px; margin-left:150px;  height:500px;"
        align="center">
                 
                
                  
                    <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                                        <ContentTemplate>
                             <asp:GridView ID="gv_queuedetails" runat="server" AutoGenerateColumns="False" 
                                 CellPadding="4" ForeColor="DarkSlateGray" GridLines="None" 
                                style="text-align: center" Width="1000px" BackColor="Orange">
                                 <AlternatingRowStyle BackColor="Gray" />
                                 <Columns>
                                     <asp:BoundField DataField="department_desc" HeaderText="Services"  ControlStyle-Font-Size="30pt"/>
                                     <asp:BoundField DataField="appointment_time" HeaderText="Appointment" />
                                     
                                 </Columns>
                                 <EditRowStyle BackColor="#2461BF" />
                                 <FooterStyle BackColor="#0379B5" Font-Bold="True" Font-Size="30pt" ForeColor="DarkSlateGray" />
                                 <HeaderStyle BackColor="Orange" Font-Bold="True" Font-Size="35pt" ForeColor="DarkSlateGray" />
                                 <PagerStyle BackColor="#0379B5" ForeColor="DarkSlateGray" Font-Size="30pt" HorizontalAlign="Center" />
                                 <RowStyle BackColor="Yellow" Font-Size="30pt" />
                                 <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                 <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                 <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                 <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                 <SortedDescendingHeaderStyle BackColor="#4870BE" />
                             </asp:GridView>
                             </ContentTemplate></asp:UpdatePanel>
               </td>>
               </tr>
                    </table>

                    <table style="margin-top:50px; margin-left:40px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label6" runat="server" Text="If your appointment is incorrect please contact  reception for assistance." Font-Bold="True" ForeColor="Brown"
                    Font-Size="27pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
                    <table style="margin-left:0px; margin-top:40px;">
                    <tr>
                           
                            <td>
                              <asp:ImageButton 
                                    ID="ImageButton2" runat="server" 
                                    ImageUrl="~/images/home.png" onclick="ImageButton2_Click" Height="65px" 
                                    ImageAlign="Middle" Width="250px"/></td>

                                    <td class="style6">
                                    </td>

                                    <td >
                      
                           
                                        &nbsp;</td>
                                    <td>
                                      <asp:ImageButton ID="Button1" runat="server" 
                            ImageUrl="~/images/confirm.png" onclick="Button1_Click" Height="65px" 
                            ImageAlign="Middle" Width="250px"/>
                                    </td>
                    
                  
                   </tr>
                    
                 
                </table>
    </form>
</body>
</html>
