<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TerminalMaster.aspx.cs" Inherits="TerminalMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QMS - Terminal Master</title>
      <link rel="stylesheet" href="../CSS/menus1.css" type="text/css" media="screen"/>
	
			
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
  <%--  <script language="javascript" type="text/javascript">
    
    function TerminalDescription(terminaldescription, event) 
    {
        var defaultText = "Terminal Description";
        // Condition to check textbox length and event type
        if (terminaldescription.value.length == 0 & event.type == "blur") 
        {
            //if condition true then setting text color and default text in textbox
            terminaldescription.style.color = "Gray";
            terminaldescription.value = defaultText;
            terminaldescription.style.border = "2px Solid red";
        }
        // Condition to check textbox value and event type
        if (terminaldescription.value == defaultText & event.type == "focus") 
        {
            terminaldescription.style.color = "Black";
            terminaldescription.value = "";
            terminaldescription.style.border = "2px Solid #0379B5";
        }
    }


    function TerminalIp(terminalip, event) 
    {
        var defaultText = "Terminal Ip";
        // Condition to check textbox length and event type
        if (terminalip.value.length == 0 & event.type == "blur")
        {
            //if condition true then setting text color and default text in textbox
            terminalip.style.color = "Gray";
            terminalip.value = defaultText;
            terminalip.style.border = "2px Solid red";
        }
        // Condition to check textbox value and event type
        if (terminalip.value == defaultText & event.type == "focus") 
        {
            terminalip.style.color = "Black";
            terminalip.value = "";
            terminalip.style.border = "2px Solid #0379B5";
        }
    }


    function DepartmentDescription(departmentdescription, event) {
        var defaultText = "Select";
        // Condition to check textbox length and event type
        if (departmentdescription.value == "Select" & event.type == "blur") {
            //if condition true then setting text color and default text in textbox
            departmentdescription.style.color = "Gray";
            departmentdescription.value = defaultText;
            departmentdescription.style.border = "2px Solid Red";

        }
        // Condition to check textbox value and event type
        if (departmentdescription.value == defaultText & event.type == "focus") {
            departmentdescription.style.color = "Black";
            departmentdescription.value = "";
            departmentdescription.style.border = "2px Solid #0379B5";

        }
    }

    function RoomCode(roomcode, event) {
        var defaultText = "Select";
        // Condition to check textbox length and event type
        if (roomcode.value == "Select" & event.type == "blur") {
            //if condition true then setting text color and default text in textbox
            roomcode.style.color = "Gray";
            roomcode.value = defaultText;
            roomcode.style.border = "2px Solid Red";

        }
        // Condition to check textbox value and event type
        if (roomcode.value == defaultText & event.type == "focus") {
            roomcode.style.color = "Black";
            roomcode.value = "";
            roomcode.style.border = "2px Solid #0379B5";

        }
    }

    function TerminalTypeDescription(terminaltypedescription, event) {
        var defaultText = "Select";
        // Condition to check textbox length and event type
        if (terminaltypedescription.value == "Select" & event.type == "blur") {
            //if condition true then setting text color and default text in textbox
            terminaltypedescription.style.color = "Gray";
            terminaltypedescription.value = defaultText;
            terminaltypedescription.style.Border = "2px Solid Red";

        }
        // Condition to check textbox value and event type
        if (terminaltypedescription.value == defaultText & event.type == "focus") {
            terminaltypedescription.style.color = "Black";
            terminaltypedescription.value = "";
            terminaltypedescription.style.Border = "2px Solid #0379B5";

        }
    }
    </script>--%>
</head>
<body onload="startTime()">
    <form id="form1" runat="server">
    <div>
    
     <table align="center" 
            style="width: 70%; background-attachment: fixed;">

      <tr>
                                                         
                        <td colspan ="4" align="left" valign="bottom">
                            <table align="left" style="margin-left:0px;padding: 1px 4px;">
                                <tr>
                                <td valign="bottom" style="height: 140px">
                                <%--<asp:Image runat="server" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 80px; text-align: center; float: left;"  ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1"/>--%>
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
                        <asp:Label ID="lbl_terminaldepartmentid" runat="server" style="float: right;" 
                                Text="Terminal Department ID" Visible="False"></asp:Label>
                        </p>
                        
                        </td>
                       
                        <td>
                        <asp:DropDownList ID="ddl_terminaldepartmentselection" runat="server"
                                style="text-align: left; float: right;" AutoPostBack="True" 
                                
                                onselectedindexchanged="ddl_terminaldepartmentselection_SelectedIndexChanged" 
                                Height="20px" Width="156px"></asp:DropDownList>
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

    <%--<td>
      
    </td>--%>

    <td colspan="2">
        <h2 style="text-align: center">Terminal Master &nbsp; &nbsp; &nbsp; &nbsp;</h2></td>

    <td>
        &nbsp;</td>

    <td>
    
    </td>
    
    <%--<td>
    
    </td>--%>

    
    </tr>
    <tr>

    <td>
    <p style="width:275px"></p>
    </td>
    
   <%--<td>--%>
     <%--<p style="width:100px"></p>--%>
   <%--  </td>--%>

    <td colspan="2">
     <asp:ValidationSummary ID="vs_terminalmaster" runat="server" ForeColor="Red" 
            style="text-align: center" />
    </td>
    
    <td>
    
    </td>

    <td></td>
    
    </tr>
    
   

    <tr>
   
   <td></td>

   <td></td>

   <td>
   <asp:Label ID="lbl_terminalmessage" runat="server" ForeColor="Green"></asp:Label>
   </td> 
   
   <td>
   </td>
  
  <td><p style="width:200px"></p></td>

    </tr>
   
    <tr>

    <td></td>

    <td><p style="width:100px"></p></td>

    <td>
    <asp:Label ID="lbl_terminalid" runat="server" ForeColor="Red" Visible="False">*</asp:Label>
    </td>
   
   <td>
   <asp:Label ID="lbl_terminalmaster" runat="server" Text="N" ForeColor="Red" 
           Visible="False"></asp:Label>
   </td> 
   
   <td></td>

    </tr>
    
    <tr>
   

   <td></td>

   <td>
   Terminal Description
   </td>

    <td>
    <asp:TextBox ID="txt_terminaldescription" runat="server" ForeColor="Black" Width="285px" />
    </td>
    
    <td>
    <asp:RequiredFieldValidator ID="RFV" ControlToValidate="txt_terminaldescription" runat="server" ErrorMessage="Terminal Description Field Should Not Left Empty" InitialValue="" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
    
    <td></td>

    </tr>

    <tr>
    
    <td></td>

    <td>Terminal Ip</td>

    <td>
           <asp:TextBox ID="txt_terminalip" runat="server" 
           ForeColor="Black" Width="285px" ontextchanged="txt_terminalip_TextChanged" AutoPostBack="True" />

     <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
        <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
    </td>
    
    <td>
     <asp:RequiredFieldValidator ID="rfv_terminalip" ControlToValidate="txt_terminalip" runat="server" ErrorMessage="Terminal Ip Field Should Not Left Empty" InitialValue="" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
     <asp:Image ID="img_terminalipavailability" runat="server" Width="17px" Height="17px" />
            
     <asp:Label ID="lbl_terminalipavailability" runat="server"></asp:Label>
    </td>
    
    <td></td>

    </tr>

    <tr>
    
    <td></td>

    <td>Department Description</td>

    <td>
    <asp:DropDownList ID="ddl_departmentdescription" runat="server" ForeColor="Black" 
            Width="290px" Height="23px" AppendDataBoundItems="True">
        <asp:ListItem>Select</asp:ListItem>
     </asp:DropDownList>
    </td>
    
    <td>
    <asp:RequiredFieldValidator ID="rfv_terminaldepartmentdescription" ControlToValidate="ddl_departmentdescription" runat="server" ErrorMessage="Department Description Field Should Not Left Select" InitialValue="Select" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
    
    <td></td>

    </tr>

    <tr>
    
    <td></td>

    <td>Room Code</td>

    <td>
    <asp:DropDownList ID="ddl_roomcode" runat="server"  ForeColor="Black" Width="290px" 
            Height="23px" AppendDataBoundItems="True">
        <asp:ListItem>Select</asp:ListItem>
    </asp:DropDownList>
    </td>
    
    <td>
    <asp:RequiredFieldValidator ID="rfv_terminalroomcode" ControlToValidate="ddl_roomcode" runat="server" ErrorMessage="Room Code Field Should Not Left Select" InitialValue="Select" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
    
    <td></td>

    </tr>
    
    <tr>
    
    <td></td>

    <td>Terminal Type Description</td>

    <td>
   <asp:DropDownList ID="ddl_terminaltypedescription" runat="server" ForeColor="Black" 
            Width="290px" Height="23px" AppendDataBoundItems="True">
       <asp:ListItem>Select</asp:ListItem>
     </asp:DropDownList>
    </td>

    <td>
    <asp:RequiredFieldValidator ID="rfv_terminaltypedescription" ControlToValidate="ddl_terminaltypedescription" runat="server" ErrorMessage="Terminal Type Description Field Should Not Left Select" InitialValue="Select" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
   
   <td></td>

    </tr>

    <tr>
    
    <td></td>

    <td>Terminal Auto Login Status</td>

    <td>
   <asp:DropDownList ID="ddlautologinstatus" runat="server" ForeColor="Black" 
            Width="290px" Height="23px" AppendDataBoundItems="True">
       <asp:ListItem>Select</asp:ListItem>
     </asp:DropDownList>
    </td>

    <td>
    
    </td>
   
   <td></td>

    </tr>
    <tr>
    
    <td></td>

    <td>Terminal UserName</td>

    <td>
   <asp:TextBox ID="txt_username" runat="server" ForeColor="Black" Width="285px" />
    </td>

    <td>
    
    </td>
   
   <td></td>

    </tr>
    <tr>
    
    <td></td>

    <td>Terminal Password</td>

    <td>

            <asp:TextBox ID="txt_password" runat="server" ForeColor="Black" Width="285px" />
    
    </td>

    <td>
    
    </td>
   
   <td></td>

    </tr>
        
    <%--<tr>
    
    <td></td>

    <td></td>

    <td>
     
   <select id="ddl_rolldescription">
   <option>Roll1</option>
   <option>Roll2</option>
   </select>
    </td>

    <td>
     
    </td>
   
   <td></td>

    </tr>--%>

   <%-- <tr>
    
    <td></td>

    <td></td>

    <td>

    </td>

    <td>

    </td>
    
    <td></td>

    </tr>--%>

    <%--<tr>
    
    <td></td>

    <td></td>

    <td>

    
   <select id="ddl_departmentdescription">
    <option>Department1</option>
    <option>Department2</option>
    </select>
    </td>

    <td>
     
    </td>
    
    <td></td>

    </tr>--%>

   <%-- <tr>
    
    <td></td>

    <td></td>

    <td>
    
    </td>
    
    <td>
    
    </td>
    
    <td></td>

    </tr>--%>
<%--
    <tr>
    
    <td></td>

    <td></td>
    
    <td>
    
   
    </td>

    <td>
     
    </td>
   
   <td></td>

    </tr>--%>

    <%--<tr>
    
    <td></td>

    <td></td>

    <td>
    
    </td>
    
    <td>
    
    </td>
    
    <td></td>

    </tr>--%>
    
    <tr>
    
    <td></td>

    <td><p style="height:15px"></p></td>

    <td>

    </td>
    
    <td>
    
    </td>
    
    <td></td>

    </tr>

    <tr>
    
    <td></td>

    <%--<td></td>--%>

    <td colspan="2" style="text-align: right">

    <table align="center">

    <tr>
        
    <td>

    <asp:Button ID="btn_terminalnew" runat="server" Text="New" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_terminalnew_Click" CausesValidation="false"/>
    </td>


    <td>
    <asp:Button ID="btn_terminaledit" runat="server" Text="Edit" style="text-align: center" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_terminaledit_Click" CausesValidation="false"/>
    </td>
    <td>
    <asp:Button ID="btn_terminalsave" runat="server" Text="Save" style="text-align: right" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_terminalsave_Click" OnClientClick="return" />
    </td>

    </tr>

    </table>

    </td>

    <td></td>

    <td>
    
    </td>
    
    </tr>

    <tr>
    
    <td></td>

    <td>
    <p style="height:15px"></p>
    </td>

    <td></td>

    <td>
    
    </td>
    
    <td></td>

    </tr>

    <%--<tr>
    
    <td colspan="2">
    </td>

    </tr>

    <tr>
    
    <td class="style1" colspan="2"><span style="color:Blue">SEARCH</span></td>

    </tr>

    <tr>
    
    <td colspan="2">Terminal Description</td>

    </tr>

    <tr>
    
    <td colspan="2">
     <asp:TextBox ID="txt_searchterminaldescription" runat="server" Text="Terminal Description" 
            ForeColor="Gray" onblur = "TerminalDescription(this, event);" 
            onfocus = "TerminalDescription(this, event);" Width="292px" BorderColor="#0379B5" 
            BorderStyle="Solid" />
    </td>

    </tr>

    <tr>
    
    <td colspan="2">
    
    </td>

    </tr>

    <tr>
    
    <td colspan="2">
    
    </td>
    </tr>--%>
    <%--</table>--%>

    <%--<table align="center" class="style3">--%>
    
    <tr>

    <td></td>
    
   

    <td colspan="3">
    <asp:GridView ID="gv_terminalmaster" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="gv_terminalmaster_SelectedIndexChanged" 
            style="text-align: center" AllowPaging="True" 
            onpageindexchanging="gv_terminalmaster_PageIndexChanging" 
            onrowdatabound="gv_terminalmaster_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
       <%-- <HeaderStyle Width="1000px" />--%>
        <Columns>
            <asp:BoundField DataField="terminal_id" HeaderText="Terminal Id" ItemStyle-Width="100px"/>
            <asp:BoundField DataField="terminal_desc" HeaderText="Terminal Description"  ItemStyle-Width="100px"/>
            <asp:BoundField DataField="terminal_ip" HeaderText="Terminal Ip" ItemStyle-Width="100px" />
            <asp:BoundField DataField="department_desc" HeaderText="Department Description" ItemStyle-Width="100px" />
            <asp:BoundField DataField="room_code" HeaderText="Room Code" ItemStyle-Width="100px" />
            <asp:BoundField DataField="terminal_type_desc" HeaderText="Type Description" ItemStyle-Width="100px" />
            <asp:BoundField DataField="department_id" HeaderText="Department Id" />
            <asp:BoundField DataField="room_id" HeaderText="Room Id" />
            <asp:BoundField DataField="terminal_type_id" HeaderText="Terminal Type Id" />
            <asp:BoundField DataField="terminal_autologin_status" HeaderText="Auto Login Status" ItemStyle-Width="100px" />
            <asp:BoundField DataField="terminal_username" HeaderText="Auto Login Username" ItemStyle-Width="100px"/>
            <asp:BoundField DataField="terminal_password" HeaderText="Auto Login Pass" ItemStyle-Width="100px"/>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" 
            Wrap="True" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </td>

    <td></td>

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
