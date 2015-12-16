<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kisokprin1t.aspx.cs" Inherits="kisokprint" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="refresh" content="5;url=kiosklang.aspx"/>
<script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="CSS/jquery-ui.css" />
    <script src="js/braviPopup.js" type="text/javascript"></script>
    <link href="CSS/braviStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
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
</head>
<body onload="startTime()" style="background-color:#B2D9EA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
      <table style="width:100%; background-color:#B2D9EA;" align="center">
                <tr>
                        <td style="background-color:#0379B5;" align="left" class="style1" colspan="2">
                                <h1 style="color:White; font-size:xx-large;">Welcome to Kiosk</h1>
                        </td>
                     <%--    <td style="background-color:#0379B5;" align="right">--%>
                            <%-- <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>--%>
                   <%--     </td>--%>
                    </tr>
                  
                    <tr>
                        <td colspan ="2">
                            <table align="right">
                                <tr>
                                    <td>
                                    <asp:Image runat="server" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;"  ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1"/>
                                        <%--<img alt="" src="images/esic.png" height="150" width="150" />--%>
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
                        <td colspan="2" style="height:250px;"></td>

                    </tr>
                    
                    
                   
                   <tr>
                    <td colspan="2" align="center" valign="middle">
                        <asp:Label ID="Label1" runat="server" Text="Please Take Your 'Q' Ticket" 
                            Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                    </td>
                   </tr>
                   <tr>
                    <td colspan="2">
                    </td>
                   </tr>
                  
                   <tr>
            <td colspan="2" align="center">
            <%--    <h5>Clinet IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="Label" 
                        ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance IP :
                [<asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>--%>
               
            </td>
           
        </tr>
                </table>
    </form>
</body>
</html>
