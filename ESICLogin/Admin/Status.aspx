<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Status.aspx.cs" Inherits="Admin_Status" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>QMS - Total Missed Queue Report</title>
    <link rel="stylesheet" href="../CSS/menur.css" type="text/css" media="screen" />
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
    <style type="text/css">
        .style1
        {
            width: 188px;
        }
        .style2
        {
            width: 42px;
        }
        .style3
        {
            width: 43px;
        }
        .style4
        {
            width: 134px;
        }
        .style5
        {
            height: 118px;
        }
    </style>
</head>
<body onload="startTime()">
    <form id="form1" runat="server">
    <div>
        <center>
        </center>
        <table align="center" style="width: 70%;
            background-attachment: fixed;">
            <tr>
                <td>
                    <table align="left" style="margin-left: 3px; padding: 1px 4px; width: 869px;">
                        <tr>
                            <td align="right" class="style8" style="height: 140px">
                                <%--<asp:Image runat="server" alt="ESIC" Style="margin-left: 1px; margin-top: 4px; height: 80px;
                                    text-align: center; float: left;" ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1" />--%>
                                <%--<img src="../images/esic.png" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;" />--%><%--                                 <img src="images/esic.png" alt="ESIC"  
                  style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;"/>--%>
                            </td>
                            <td align="right" class="style9" valign="bottom">
                                <%-- <h3>User :</h3>--%><%--<asp:Image ID="Image4" runat="server"  ImageUrl="~/images/User.png" />--%>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/User.png" />
                            </td>
                            <td align="left" class="style7" valign="bottom">
                                <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                            </td>
                            <%--<td class="style12">&nbsp;</td>
                                    <td>&nbsp;</td>--%>
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
                                <%--<asp:Image ID="Image4" runat="server" alt="Qosft" Style="margin-right: 2px; margin-top: 3px;
                                    float: right;" ImageUrl="~/Admin/ImageHandler.ashx?imgID=2" />--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="background-color: #0379B5;" align="left">
                    <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White">Welcome to Administrator Terminal</asp:Label>
                </td>
                <td style="background-color: #0379B5;" align="right">
                    <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table align="center" style="width: 70%;
                        background-attachment: fixed;">
                        <tr>
                            <td colspan="5" class="style5" align="center">
                                <div class="menu-wrap">
                                    <nav class="menu">
                                <ul class="clearfix">
                                <li><a href="TotalQueue.aspx" style="text-decoration: none">TotalQueue</a></li>
                                <li><a href="Status.aspx" style="text-decoration: none">Status</a></li>
                                <li><a href="DailyReport.aspx" style="text-decoration: none">Daily</a></li>
                                <li><a href="ReportTotalQueue.aspx" style="text-decoration: none">Avg Time</a></li>
                                <li><a href="ReportTotalMissedQueue.aspx" style="text-decoration: none">Wait Time</a></li>
            <%--<li><a href="#">Reports</a>
        		<ul class="sub_menu">
        			   <li><a href="ReportTotalQueue.aspx">Total Queue Report</a></li>
        			 
        			      <li><a href="#">Report 3</a></li>
        		</ul>
        	</li>--%>
        </ul>
        </nav>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <h2 style="text-align: center">
                                    Token Trace</h2>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <p>
                                    &nbsp;</p>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table align="center">
                                    <tr>
                                        <td class="style4">
                                            Enter Token Number
                                        </td>
                                        <td class="style1">
                                            <asp:TextBox ID="txt_queuenumber" runat="server"></asp:TextBox>
                                        </td>
                                        <%--  <td>
                    To Date:&nbsp;
                </td>
                <td>
                    <telerik:RadDatePicker ID="RadDatePicker2" runat="server"></telerik:RadDatePicker>
                </td>--%>
                                        <td>
                                            <asp:Button ID="btn_report" runat="server" Text="Get Status" OnClick="btn_report_Click"
                                                Style="margin-left: 4px" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table align="center">
                                    <tr>
                                        <td colspan="5">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <div style="overflow: visible; margin-top: 10px; background-color: #FFFFFF;">
                                                <asp:GridView ID="gv_queuedetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                                    ForeColor="#333333" GridLines="None" Style="text-align: center" Width="779px">
                                                    <AlternatingRowStyle BackColor="White" />
                                                    <Columns>
                                                        <asp:BoundField DataField="visit_customer_id" HeaderText="Medicare Card No" />
                                                        <asp:BoundField DataField="members_firstname" HeaderText="Patient Name" />
                                                        <asp:BoundField DataField="department_desc" HeaderText="Department" />
                                                        <asp:BoundField DataField="plan_transfer_id" HeaderText="Plan Transfer ID" Visible="false" />
                                                        <asp:BoundField DataField="Queue Status" HeaderText="Queue Status" />
                                                        <asp:BoundField DataField="Token Reg" HeaderText="Token Reg" />
                                                        <asp:BoundField DataField="Service Start" HeaderText="Service Start" />
                                                        <asp:BoundField DataField="Service End" HeaderText="Service End" />
                                                    </Columns>
                                                    <EditRowStyle BackColor="#2461BF" />
                                                    <FooterStyle BackColor="#0379B5" Font-Bold="True" ForeColor="White" />
                                                    <HeaderStyle BackColor="#0379B5" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#0379B5" ForeColor="White" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EFF3FB" />
                                                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                </asp:GridView>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                <h5>
                                    Client IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance
                                    IP : [<asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
