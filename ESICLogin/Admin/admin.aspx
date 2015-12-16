<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="Admin_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QMS - Admin Terminal</title>
    <link rel="stylesheet" href="../CSS/menus.css" type="text/css" media="screen" />
    <script type="text/javascript" src="../js/jquery-1.3.1.min.js"></script>
    <script type="text/javascript" language="javascript" src="../js/jquery.dropdownPlain.js"></script>
    <link rel="stylesheet" type="text/css" href="../CSS/StyleSheet.css" />
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
<body onload="startTime()">
    <form id="form1" runat="server">
    <table style="width: 75%; height: 100%;
        background-attachment: fixed;" align="center">
        <tr>
            <td>
                <table align="left" style="margin-left: 3px; padding: 1px 4px; width: 869px;">
                    <tr>
                        <td align="right" class="style8" style="height: 140px">
                            <%--<asp:Image runat="server" alt="ESIC" Style="margin-left: 1px; margin-top: 4px; height: 80px;
                                text-align: center; float: left;" ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1" />--%>
                            <%--<img src="../images/esic.png" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;" />--%>
                            <%--                                 <img src="images/esic.png" alt="ESIC"  
                  style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;"/>--%>
                        </td>
                        <td align="right" class="style9" valign="bottom">
                            <%-- <h3>User :</h3>--%>
                            <%--<asp:Image ID="Image4" runat="server"  ImageUrl="~/images/User.png" />--%>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/User.png" />
                        </td>
                        <td align="left" class="style7" valign="bottom">
                            <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td class="style12">
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right" class="style10" valign="bottom">
                            <%--<h3>Terminal :</h3>--%>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Terminal.png" />
                        </td>
                        <td align="left" class="style14" valign="bottom">
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="right" class="style3" valign="bottom">
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="left" class="style13" valign="bottom">
                            <div id="txt">
                            </div>
                            <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
                        </td>
                        <td class="style15" valign="bottom">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Desktop.png" />
                            <%--<p>&nbsp;</p>--%>
                        </td>
                        <td class="style5" valign="bottom">
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                            <%--<p>&nbsp;</p>--%>
                        </td>
                        <td align="right">
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right" class="style2">
                <table>
                <tr>
                        <%--<td>
                            <img src="../images/Intouch2.jpg" alt="Qsft" style="margin-right: 2px; margin-top: 3px;
                                float: right;" />
                        </td>--%>
                    </tr>
                    <tr>
                        <td>
                           <%-- <img src="../images/qsoftTmBig.png" alt="Qosft" style="margin-right: 2px; margin-top: 3px;
                                float: right;" />--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="background-color: #0379B5;" align="left">
                <table>
                    <tr>
                        <td colspan="4" style="width: 500px;">
                            <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White">Welcome to Administrator Terminal</asp:Label>
                        </td>
                        <td colspan="4">
                            <p style="width: 200px;">
                                <asp:Label ID="lbl_departmentdescriptionloadingid" runat="server" Style="float: right;"
                                    Text="DepartmentID" Visible="False"></asp:Label>
                            </p>
                        </td>
                        <td style="width: 175px;">
                            <asp:DropDownList ID="ddl_departmentselection" runat="server" Style="text-align: left;
                                float: right;" AutoPostBack="True" OnSelectedIndexChanged="ddl_departmentselection_SelectedIndexChanged"
                                Height="20px" Width="156px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="background-color: #0379B5;" align="right">
                <asp:LinkButton ID="buttonlink" runat="server" Text="Logout" OnClick="buttonlink_Click"
                    ForeColor="White"></asp:LinkButton>
                <%--<asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>--%>
            </td>
        </tr>
        <%--<tr>
                        <td colspan ="2">
                            <table align="left" style="margin-left:120px;padding: 1px 4px;">
                                <tr>
                                    <td align="right">
                                        <%-- <h3>User :</h3>--%>
        <%--  <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/User.png" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td align="right">
                                        <%--<h3>Terminal :</h3>--%>
        <%-- <asp:Image ID="Image2" runat="server" 
                                            ImageUrl="~/images/Terminal.png"  />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="right" style="width:40%;">
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="left">--%>
        <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
        <%--  <div id="txt"></div>
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
                                </tr>
                              
                           </table>
                        </td>
                    </tr>--%>
        <tr>
            <td colspan="3" align="center">
                <div class="menu-wrap">
                    <nav class="menu">
                                 <ul class="clearfix">
        	                    <li><a href="DepartmentMaster.aspx" style="text-decoration: none">Department</a></li>
        	                    <li><a href="TerminalMaster.aspx" style="text-decoration: none">Terminal</a></li>
                                <li><a href="ScheduleMaster.aspx" style="text-decoration: none">Schedule</a></li>
        	                    <li><a href="UserMaster.aspx" style="text-decoration: none">User</a></li>
        	                    <li><a href="LocationMaster.aspx" style="text-decoration: none">Location</a></li>
        	                    <li><a href="DeviceMaster.aspx" style="text-decoration: none">Device</a></li>
                                <li><a href="ImageMaster.aspx" style="text-decoration: none">Image</a></li>
                                <li><a href="ContentManagement.aspx" style="text-decoration: none">Content</a></li>
           
                             </ul>
                             </nav>
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <h5>
                    Clinet IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance
                    IP : [<asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
