<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TotalQueue.aspx.cs" Inherits="Admin_TotalQueue" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="refresh" content="60"/>
    <title>QMS - Admin Terminal</title>
    <link rel="stylesheet" href="../CSS/menus.css" type="text/css" media="screen"/>
    <link rel="stylesheet" href="../CSS/menustyle.css" type="text/css" media="screen"/>
    <link rel="stylesheet" type="text/css" href="../CSS/StyleSheet.css" />
	<link href="../Content/bootstrap.min.css"/>
	<style type="text/css">
      #header
      {
          width:100%;
          height:60px;
          display:inline;
          float:left;
          margin-bottom:5.62%;
          position:relative;
      }
      #header2
      {
          width:100%;
          height:35px;
          display:inline;
          float:left;
          margin-bottom:0.2%;
          position:relative;
            top: 28px;
            left: 0px;
        }
      #headerMenu
      {
          width:100%;
          height:107px;
          display:inline;
          float:left;
          margin-bottom:0.5%;
          position:relative;
            top: 40px;
            left: 0px;
        }
      #main
      {
          display:inline;
          float:left;
          position:relative;
          width:100%;
          height:65%;
      }
      #footer1 
      {
          width:100%;
          height:15px;
          text-align:center;
          position:relative;
          margin-top:3%;
          bottom:0%;
          
      }
        .style1
        {
            height: 54px;
        }
    </style>		
	<script type="text/javascript" src="../js/jquery-1.3.1.min.js"></script>	
	<script type="text/javascript" language="javascript" src="../js/jquery.dropdownPlain.js"></script>
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
        <div>
            <div id="header">
                <table style="width:100%; height:100%; background-attachment: fixed;" 
                    align="center">
                    <tr>
                        <td>
                            <table align="left" style="margin-left:3px; padding: 1px 4px; width: 869px;">
                                <tr>
                                    <td align="right" class="style8" style="height: 140px">
                                        <%--<asp:Image runat="server" alt="ESIC" Height="80px" Width="130px" style="margin-left:1px; margin-top:4px; text-align: center; float: left;"  ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1"/>--%>
                                        <%--<img src="../images/esic.png" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;" />--%>
                                        </td>
                                    <td align="right" class="style9" valign="bottom">
                                        <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/User.png" />
                                    </td>
                                    <td align="left" class="style7" valign="bottom">
                                        <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="style12">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td align="right" class="style10" valign="bottom">
                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Terminal.png"  />
                                    </td>
                                    <td align="left" class="style14" valign="bottom">
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="right" class="style3" valign="bottom">
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="left" class="style13" valign="bottom">
                                        <div id="txt"></div>
                                    </td>
                                    <td class="style15" valign="bottom">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Desktop.png" />
                                    </td>
                                    <td class="style5" valign="bottom">
                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
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
                    </table>
            </div>
            <div id="header2">
                <table style="width:100%; height:100%; background-color:#0379B5;" align="center">
                    <tr>
                    
                        <td colspan="4" style="width:60%;">
                            <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White">Welcome to Administrator Terminal</asp:Label>
                        </td>
                        <td colspan="4">
                            <p style="width:30%">
                                <asp:Label ID="lbl_departmentdescriptionloadingid" runat="server" 
                                    style="float: right;" Text="DepartmentID" Visible="False"></asp:Label>
                            </p>
                        </td>                       
                        <td style="width:175px;">
                            <asp:DropDownList ID="ddl_departmentselection" runat="server"
                                style="text-align:left; float: right;" AutoPostBack="True" 
                                onselectedindexchanged="ddl_departmentselection_SelectedIndexChanged" 
                                Height="20px" Width="156px" AppendDataBoundItems="true">
                                <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width:10%; margin-right:10px" align="right">
                            <asp:LinkButton ID="LinkButton1" runat="server" Text="Logout" 
                                 onclick="buttonlink_Click" ForeColor="White"></asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="headerMenu">
                <table style="width:100%; height:100%; background-attachment: fixed;" 
                    align="center">
                    <tr>
                        <td align="center" class="style1">
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
                                        <%--  <li><a href="ReportTotalQueue.aspx">Total Queue Report</a></li>
                                        	
                                    </ul>
                                </li>--%>
                            </ul>
                            </nav>
                            </div>
                        </td>
                    </tr>
                </table>    
            </div>
            <div id="main">
                <table style="width:100%; height:100%;" align="center">
                    <tr>
                        <td style="height:10px;"></td>
                    </tr>
                    <tr style="height:30px;">
                        
                        <td style="width:32%;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" Font-Size="X-Large" Font-Bold="true" Text="Total Waiting Queue :" runat="server"></asp:Label>
                        </td>
                        <td style="width:32%;">
                            <asp:Label ID="lbl_WaitingQueueTotal"  Font-Bold="true" runat="server" Text="0"></asp:Label>
                        </td>
                        <td style="width:32%;">

                        </td>
                        <td style="width:2%;">
                            <p style="width:5px"></p>
                        </td>
                    </tr>
                    <tr>
                        
                        <td style="width:32%;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label12" Font-Size="X-Large"  Font-Bold="true" Text="Total Serving Queue :" runat="server"></asp:Label>
                        </td>
                        <td style="width:32%;">
                            <asp:Label ID="lbl_ServingQueueTotal"  Font-Bold="true" runat="server" Text="0"></asp:Label>
                        </td>
                        <td style="width:32%;">

                        </td>
                        <td style="width:2%;">
                            <p style="width:5px"></p>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:32%;">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" Font-Size="X-Large"  Font-Bold="true" Text="Total Pending Queue :" runat="server"></asp:Label>
                        </td>
                        <td style="width:32%;">
                            <asp:Label ID="lbl_PendingQueueTotal"  Font-Bold="true" runat="server" Text="0"></asp:Label>
                        </td>
                        <td style="width:32%;">

                        </td>
                        <td style="width:2%;">
                            <p style="width:5px"></p>
                        </td>
                    </tr>
                    



                    <tr>
                        <td style="width:2%;">
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td style="width:32%;">&nbsp;</td>
                        <td style="width:32%;"></td>
                        <td style="width:32%;"></td>
                        <td style="width:2%;"></td>
                    </tr>
                    <tr>
                    
                    

                        
                        <td style="width:25%;"><h5 style=" font-size:x-large; text-align:center"> Waiting Queue</h5></td>
                        <td style="width:25%;"><h5 style=" font-size:x-large; text-align:center"> Serving Queue</h5></td>
                        <td style="width:25%;"><h5 style=" font-size:x-large; text-align:center"> Pending Queue</h5></td>
                        <td style="width:25%;"><h5 style=" font-size:x-large; text-align:center"> Missed Queue</h5></td>
                        

                     </tr>
                    <tr>
                        
                        <td style="width:25%; Height:100px;">
                            <asp:GridView valign="Center" ID="grid_TotalWaitingQueue" runat="server" AutoGenerateColumns="False" 
                              onpageindexchanging="gv_Waiting_PageIndexChanging"  CellPadding="4" 
                                ForeColor="#333333" GridLines="None" AllowPaging="True" 
                                style="vertical-align:top; text-align: center;">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="visit_customer_name" HeaderText="Patient Name" />
                                    <asp:BoundField DataField="visit_queue_no_show" HeaderText="Queue No" />
                                    <asp:BoundField DataField="department_desc" HeaderText="Dr.Name" />
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                        <td style="width:25%; Height:100px">
                            <asp:GridView columnspan="2" valign="Center" ID="grid_TotalServingQueue" runat="server" AutoGenerateColumns="False" 
                              onpageindexchanging="gv_Serving_PageIndexChanging"  CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" style="text-align: center">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="visit_customer_name" HeaderText="Patient Name" />
                                    <asp:BoundField DataField="visit_queue_no_show" HeaderText="Queue No" />
                                    <asp:BoundField DataField="department_desc" HeaderText="Dr.Name" />
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                        <td style="width:25%; Height:100px">
                            <asp:GridView columnspan="3" valign="Right" ID="grid_TotalPendingQueue" runat="server" AutoGenerateColumns="False" 
                              onpageindexchanging="gv_Pending_PageIndexChanging"  CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" style="text-align: center">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:BoundField DataField="visit_customer_name" HeaderText="Patient Name" />
                                    <asp:BoundField DataField="visit_queue_no_show" HeaderText="Queue No" />
                                    <asp:BoundField DataField="department_desc" HeaderText="Dr.Name" />
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                        <td style="width:25%; Height:100px">
                            <asp:GridView columnspan="3" valign="Right" ID="grid_TotalMissedQueue" runat="server" AutoGenerateColumns="False" 
                               onpageindexchanging="gv_Missed_PageIndexChanging" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" style="text-align: center">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                <asp:BoundField DataField="visit_customer_name" HeaderText="PatientName" />
                                    <asp:BoundField DataField="visit_queue_no_show" HeaderText="QueueNo" />
                                    <asp:BoundField DataField="department_desc" HeaderText="Dr.Name" />
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#EFF3FB" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                <SortedDescendingHeaderStyle BackColor="#4870BE" />
                            </asp:GridView>
                        </td>
                        
                    </tr>
                   
                   
                </table>
                <table style="width:100%; height:100%;" align="center">
                    <tr>
                        <td colspan="2" align="center">
                            <h5>Clinet IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="Label" 
                                ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance IP :
                                [<asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="footer1">
                
            </div>
        </div>
    </form>
</body>
</html>
