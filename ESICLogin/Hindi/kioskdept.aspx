<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskdept.aspx.cs" Inherits="kioskdept" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="../CSS/jquery-ui.css" />
    <script src="../js/braviPopup.js" type="text/javascript"></script>
    <link href="../CSS/braviStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <title>KIOSK - Queue Management System</title>
    <script type="text/javascript">
        //        $(document).ready(function () {
        //            $('#').click(function () {
        //                $.braviPopUp('Add Family Members', 'AddMember.aspx', 600, 400);
        //            });
        //        });
        //if you want to refresh parent page on closing of a popup window then remove comment to the below function
        //and also call this function from the js file 
        //                function Refresh() {
        //                    window.location.reload();
        //                }
        function myfunction() {

            $.braviPopUp('Add Family Members', 'AddMember.aspx', 800, 400);
        };

        //        });       
    </script>

    <script type="text/javascript">
        function startTime() {
            var today = new Date();
            var h = today.getHours();
            var m = today.getMinutes();
            var s = today.getSeconds();
            // add a zero in front of numbers<10
            m = checkTime(m);
            s = checkTime(s);
            document.getElementById('txt').innerHTML = h + ":" + m + ":" + s;
            t = setTimeout(function () { startTime() }, 500);
        }

        function checkTime(i) {
            if (i < 10) {
                i = "0" + i;
            }
            return i;
        }
</script>
    <style type="text/css">
        .style1
        {
            width: 80%;
        }
        .style2
        {
            width: 80%;
        }
    </style>
</head>
<body onload="startTime()" style="background-color:#B2D9EA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
     <table style="width:100%; background-color:#B2D9EA;" align="center">
                   <tr>
                        <td style="background-color:#7DD0D3;" align="left" class="style1" colspan="2">
                               &nbsp;   <img alt="" src="../images/hindi/1.png" height="45" width="450" />
                        </td>
                       <%--  <td style="background-color:#0379B5;" align="right">--%>
                            <%-- <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>--%>
                      <%--  </td>--%>
                    </tr>
                  
                    <tr>
                        <td colspan ="2">
                            <table align="right">
                                <tr>
                                    <td>
                                    <asp:Image runat="server" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;"  ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1"/>
                                        <%--<img alt="" src="../images/esic.png" height="150" width="150" />--%>
                                    </td>
                                </tr>
                              <%--  <tr>
                                    <td align="right">
                                      
                                        <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/User.png" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td align="right">
                            
                                        <asp:Image ID="Image2" runat="server" 
                                            ImageUrl="~/images/Terminal.png"  />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="right" style="width:40%;">
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="left">
                                      
                                        <div id="txt"></div>
                                    </td>
                                    <td>
                                        <p>&nbsp;</p>
                                    </td>
                                    <td style="width:10%;">
                                        <p>&nbsp;</p>
                                    </td>
                                    <td align="right">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Desktop.png" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>--%>
                              
                            </table>
                        </td>
                    </tr>
                   <tr>
                    <td colspan="2">
                          <asp:Label ID="lbltxt" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                            <ContentTemplate>
                                    <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                    </ContentTemplate></asp:UpdatePanel>
                    </td>
                   </tr>
                   <tr>
                        <td>
                            <table  style="width:80%;" align="center">
                                <tr>
                       
                       
                       <td align="right">
      <%--                        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium"> ESIC Card No</asp:Label>--%>
                                <%--<h1 style="color:Black; font-size:xx-large;">ESIC Card No :</h1>--%>
                                 <img alt="" src="../images/hindi/11.png" height="60" width="250" />
                        </td>
                        <td>&nbsp;</td>
                         <td>
                          <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                             <asp:TextBox ID="txt_esicno" runat="server" Width="200px"  Enabled="false" 
                                 BorderStyle="Solid" Height="30px" Font-Bold="True" Font-Size="X-Large" 
                                    ForeColor="Black"></asp:TextBox>
                            </ContentTemplate></asp:UpdatePanel>
                        </td>
                      
                      
                    </tr>
                            </table>
                        </td>
                        <td>
                            <table  style="width:80%;" align="left">
                                <tr>
                       
                   
                         <td align="right">
                            <%--  <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Medium"> Card Holder Name</asp:Label>--%>
                            <%-- <h1 style="color:Black; font-size:xx-large;">Card Holder Name :</h1>--%>
                            <img alt="" src="../images/hindi/h41.png" height="60" width="250" />
                        </td>
                       
                        <td align="left">
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                            <asp:TextBox ID="txt_customername" runat="server" Width="250px"  Enabled="false" 
                                BorderStyle="Solid" Height="30px" Font-Bold="True" Font-Size="X-Large" 
                                    ForeColor="Black"></asp:TextBox>
                                </ContentTemplate></asp:UpdatePanel>
                        </td>
                    </tr>
                            </table>
                        </td>
                    </tr>
                   <tr>
                    <td colspan="2">
                           <table   width="100%" style="padding: 1px 4px; width:100%;border:1px solid #C0C0C0;">
                           <tr>
                                <td rowspan="2" valign="top" align="left" >
                                    <%--<asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large"> Ple
                                    ase Select Patient</asp:Label>--%>
                                     <table align="right">
                                        <tr>
                                            <td>
                                               <%-- <h1 style="color:Navy; font-size:xx-large;">Please Select Patient</h1>--%>
                                                <img alt="" src="../images/hindi/h51.png" height="80" width="350" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                   <asp:RadioButtonList ID="rbl_memberlist" runat="server" Font-Bold="True" 
                                Font-Size="XX-Large">
                            </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            
                            <td rowspan="2" valign="top" >
                                    <table align="right" style="padding-left:50px;">
                                        <tr>
                                            <td>
                                                 <%--<h1 style="color:Navy; font-size:xx-large;">Please select Department</h1>--%>
                                                 <img alt="" src="../images/hindi/vibag.png" height="80" width="350" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                  <table>
        <tr>
            <td rowspan="6" valign="top">
            <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                <ContentTemplate>
              
                <asp:ListBox ID="lb_deptlist" AutoPostBack="true" runat="server" Height="400px" Font-Bold="True" 
            Font-Size="XX-Large" Width="250px" SelectionMode="Single"></asp:ListBox>
            </ContentTemplate></asp:UpdatePanel>

            </td>
            <td>
            </td>
            <td rowspan="6" valign="top">
            <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                <ContentTemplate>
                <asp:ListBox ID="lb_seldeptlist" AutoPostBack="true" runat="server" Height="400px" Font-Bold="True" 
            Font-Size="XX-Large" Width="250px" SelectionMode="Single"></asp:ListBox>
              </ContentTemplate></asp:UpdatePanel>
            </td>
        </tr>


        <tr>
            <td>
            <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                <ContentTemplate>
                <%-- <asp:Button  ID="btn_l1tol2" runat="server" Text=">" Width="45px" onclick="btn_l1tol2_Click"
                      />--%>
                      <asp:ImageButton ID="btn_l1tol2" runat="server" ImageUrl="~/images/arrow-right.png" onclick="btn_l1tol2_Click"  />
                     </ContentTemplate></asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                <ContentTemplate>
               <%-- <asp:Button ID="btn_up" runat="server" Text="Up" Width="45px" onclick="btn_up_Click" />--%>
                 <asp:ImageButton ID="btn_up" runat="server" ImageUrl="~/images/arrow-up.png" onclick="btn_up_Click"  />
                </ContentTemplate></asp:UpdatePanel>
            </td>
            
        </tr>
        <tr>
            <td>
                
            </td>
            <td>
            </td>
            
        </tr>
       
        <tr>
            <td>
                 <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                <ContentTemplate>
             <%--<asp:Button ID="btn_l2tol1" runat="server" Text="<" Width="45px" onclick="btn_l2tol1_Click"/>--%>
               <asp:ImageButton ID="btn_l2tol1" runat="server" ImageUrl="~/images/arrow-left.png" onclick="btn_l2tol1_Click"  />
                    </ContentTemplate></asp:UpdatePanel>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                <ContentTemplate>
                <%--<asp:Button ID="btn_down" runat="server" Text="Down" Width="45px" onclick="btn_down_Click"/>--%>
                 <asp:ImageButton ID="btn_down" runat="server" ImageUrl="~/images/arrow-down.png" onclick="btn_down_Click"  />
                    </ContentTemplate></asp:UpdatePanel>
            </td>
            
        </tr>
        <tr>
            <td>
           
            </td>
            <td>
            
            </td>
           
        </tr>
        <tr>
            <td>
                 
            </td>
            
        </tr>
      
    </table>
                                            </td>
                                        </tr>
                                    </table>
                                
                            </td>
                     
                              
                           </tr>
                      
                 
                    <tr>
                        <td colspan="5">&nbsp;</td>
                    </tr>
                   <tr>
                     <td colspan="5" align="right">
                       <%-- <asp:Button ID="Button1" runat="server" Text="Print Ticket" Height="35px" 
                            Width="100px" onclick="Button1_Click"/>--%><p>&nbsp;</p>
                    </td>
                   </tr>
                    <tr>
                     <td colspan="5" align="right">
                        <table>
                                  <tr>
                            <td>  
                                <asp:ImageButton ID="ImageButton2" runat="server" 
                                    ImageUrl="~/images/hindi/Hhome.png" onclick="ImageButton2_Click"/></td>
                            <td class="style2"></td>
                    <td   align="left">
                        <asp:ImageButton ID="Button1" runat="server" ImageUrl="~/images/hindi/hprint.png" onclick="Button1_Click"/>
                    </td>
                  
                   </tr>
                        </table>
                    </td>
                   </tr>
                        </table>
                    </td>
                   </tr>
                    
                 
                </table>
    </form>
</body>
</html>
