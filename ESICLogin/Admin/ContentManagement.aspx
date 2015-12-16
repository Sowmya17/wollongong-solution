<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContentManagement.aspx.cs" Inherits="Admin_ContentManagement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>QMS - Content Master</title>
    <link rel="stylesheet" href="../CSS/menus.css" type="text/css" media="screen"/>
	  <link rel="stylesheet" href="../CSS/datepicker.css"/>
    <link rel="stylesheet" href="../CSS/bootstrap.css" />
	<script src="../js/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../js/bootstrap-datepicker.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../CSS/StyleSheet.css" />
        	
	<%--<script type="text/javascript" src="../js/jquery-1.3.1.min.js"></script>	--%>
	<script type="text/javascript" language="javascript" src="../js/jquery.dropdownPlain.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {

             $('#example1').datepicker({
                 format: "yyyy-mm-dd",
                 startDate: '0d'
             });

         });
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
            width: 16px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table align="center" 
            style="width: 70%; background-attachment: fixed;">

      <tr>
                                                         
                        <td colspan ="4" align="left" valign="bottom">
                            <table align="left" style="margin-left:0px;padding: 1px 4px;">
                                <tr>
                                <td valign="bottom" style="height: 160px">
                                <%--<asp:Image runat="server" alt="ESIC" Height="80px" Width="130px" style="margin-left:1px; margin-top:4px; text-align: center; float: left;"  ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1"/>--%>
                                <%--<img src="../images/esic.png" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center;"/>--%>
                                </td>
                                      <td>
                                      </td>                

                                    <td align="right" valign="bottom">
                                        <%-- <h3>User :</h3>--%>
                                        <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/User.png" />
                                    </td>
                                    <td align="left" valign="bottom">
                                        <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td align="right" valign="bottom">
                                        <%--<h3>Terminal :</h3>--%>
                                        <asp:Image ID="Image2" runat="server" 
                                            ImageUrl="~/images/Terminal.png"  />
                                    </td>
                                    <td align="left" valign="bottom">
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td></td>
                                    <td align="right" valign="bottom" style="width:40%;">
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="left" valign="bottom">
                                        <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
                                        <div id="txt"></div>
                                    </td>
                                    <td>
                                        <p>&nbsp;</p>
                                    </td>
                                    <td style="width:10%;">
                                        <p>&nbsp;</p>
                                    </td>
                                    <td align="right" valign="bottom">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Desktop.png" />
                                    </td>
                                    <td align="right" valign="bottom">
                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    </td>

                                  
                                </tr>
                              
                            </table>
                        </td>

                          <td>
                                                   <table>
                                    <tr>
                                        <%--<td class="style3">
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
                        <%--<img src="../images/qsoftTmBig.png" alt="Qosft" 
                                            style="margin-right:2px; margin-top:3px;"/>--%>
                                            </td>
                        
                    </tr>

       <tr>
                        <td style="background-color:#0379B5;" align="left" colspan="4">

                        <table>
                        
                        <tr>
                        
                        <td>
                        
                        <p style="width:500px">

                            <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" 
                                ForeColor="White">Welcome to Administrator Terminal</asp:Label>

                        </p>
                        
                        </td>

                        <td>

                        <p style="width:200px">
                        </p>
                        
                        </td>
                       
                        <td>

                        </td>

                        </tr>

                        </table>
                        
                        </td>
                         <td style="background-color:#0379B5;" align="right">
                             <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>
                        </td>
                    </tr>
                
                    <tr>
                        <td colspan="5" align="center">
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
            <td>
        </td>

        <td colspan="2">
            <h2 style="text-align: center">Content Master &nbsp; &nbsp; &nbsp; &nbsp;</h2></td>
        <td class="style1">&nbsp;</td>
       <td></td>
    </tr>

    <tr>
        <td><p style="width:275px"></p></td>
        <td colspan="2">
            <asp:ValidationSummary ID="vs_contentmaster" runat="server" ForeColor="Red" 
                style="text-align: left; width:220px;"/></td>
        <td class="style1"></td>
        <td>
            <asp:Label ID="lbl_contentmaster" runat="server" Text="N" ForeColor="Red" 
                Visible="False"></asp:Label></td>
    </tr>
    
    <tr>
        <td></td>
        <td><p>Text Name:</p></td>
        <td>
            <asp:TextBox runat="server" ID="txt_Textname" Width="180px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_Textname" ControlToValidate="txt_Textname" runat="server" ErrorMessage="Please Enter Text Name" InitialValue="" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
       </td>
       <td class="style1"></td>
       <td><asp:Label id="lbl_ContentId" runat="server" visible="false"></asp:Label></td>
    </tr>
    
    <tr>
        <td></td>
        <td><p>Text Description:</p></td>
        <td><asp:TextBox runat="server" ID="txt_TextDescription" Width="180px"></asp:TextBox></td>    
        <td class="style1"></td>
        <td></td>
    </tr>

    <tr>
        <td></td>
        <td><p>Scrolling Text:</p>
            <p>&nbsp;</p></td>
        <td><asp:TextBox runat="server" ID="txt_ScrollingText" Width="180px" 
                TextMode="MultiLine" Height="53px"></asp:TextBox></td>
        <td class="style1"></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td><p>Terminal Description</p></td>
        <td><asp:DropDownList ID="drpdwn_TerminalDesc" runat="server" Width="193px" 
                DataTextField="terminal_desc" DataValueField="terminal_id"></asp:DropDownList></td>
        <td class="style1"></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td><p>Scrolling Date</p></td>
        <td><input type="text" runat="server" id="example1" name="rollingDateTimePicker" title="Pick your date"/></td>
        <td class="style1"></td>    
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td><p>Scrolling Order:</p></td>
        <td><asp:DropDownList ID="drpdwn_Order" runat="server" Width="193px">
            </asp:DropDownList></td>
        <td class="style1"></td>
        <td><asp:Label runat="server" ID="lbl_Status"></asp:Label></td>
    </tr>
    <tr>
        <td></td>
        <td><p style="height:15px"></p></td>
        <td></td>
        <td class="style1"></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td colspan="2" style="text-align: right">
            <table align="center">
                <tr>
                    <td><asp:Button ID="btn_Contentnew" runat="server" Text="New" 
                            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
                            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
                            onclick="btn_Contentnew_Click" CausesValidation="false"/>
                    </td>
                    <td><asp:Button ID="btn_Contentedit" runat="server" Text="Edit" style="text-align: center" 
                            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
                            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
                            onclick="btn_Contentedit_Click" CausesValidation="false"/>
                    </td>
                    <td><asp:Button ID="btn_Contentsave" runat="server" Text="Save" style="text-align: right" 
                            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
                            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
                            onclick="btn_Contentsave_Click" OnClientClick="return" />
                    </td>
                </tr>
            </table>
        </td>
        <td class="style1"></td>
        <td></td>
    </tr>

    <tr>
    
    <td></td>

    <td>
    <p style="height:15px"></p>
    </td>

    <td></td>

    <td class="style1">
    
    </td>
    
    <td></td>
    </tr>

    <tr>
    <td></td>

        <td colspan="3">
            <asp:GridView ID="gv_ContentMaster" runat="server" AutoGenerateColumns="False" 
                CellPadding="4" ForeColor="#333333" GridLines="None" 
                onselectedindexchanged="gv_ContentMaster_SelectedIndexChanged" 
                style="text-align: center" AllowPaging="True" 
                onpageindexchanging="gv_ContentMaster_PageIndexChanging" 
                onrowdatabound="gv_ContentMaster_RowDataBound">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="content_id" HeaderText="Content Id" ItemStyle-Width="100px"/>
                    <asp:BoundField DataField="content_starttime" HeaderText="Scrolling Date" DataFormatString="{0:d}"  ItemStyle-Width="100px"/>
                    <asp:BoundField DataField="content_order_id" HeaderText="Content Order" ItemStyle-Width="100px" />
                    <asp:BoundField DataField="terminal_desc" HeaderText="Terminal Description" ItemStyle-Width="100px" />
                    <asp:BoundField DataField="content_text" HeaderText="Scrolling Text" ItemStyle-Width="120px" />
                    <asp:CommandField ShowSelectButton="True" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" Wrap="True" />
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
      <tr>
        <td colspan="5"></td>
    </tr>
     <tr>
            <td colspan="5" align="center">
                <h5>Client IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="Label" 
                        ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance IP :
                [<asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>
               
            </td>
           
        </tr>
    </table>
    </div>
    </form>
</body>
</html>