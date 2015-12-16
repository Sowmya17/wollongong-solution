<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleMaster.aspx.cs" Inherits="LocationMaster" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QMS - Schedule Master</title>
     <link rel="stylesheet" href="../CSS/menus2.css" type="text/css" media="screen"/>
	
			
	<script type="text/javascript" src="../js/jquery-1.3.1.min.js"></script>	
	<script type="text/javascript" language="javascript" src="../js/jquery.dropdownPlain.js"></script>
     <link rel="stylesheet" type="text/css" href="../CSS/RTStyleSheet.css" />
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

<%--   <script language="javascript" type="text/javascript">

        function LocationDescription(locationdescription, event) {
            var defaultText = "Location Description";
            // Condition to check textbox length and event type
            if (locationdescription.value.length == 0 & event.type == "blur") {
                //if condition true then setting text color and default text in textbox
                locationdescription.style.color = "Gray";
                locationdescription.value = defaultText;
                locationdescription.style.border = "2px Solid red";
            }
            // Condition to check textbox value and event type
            if (locationdescription.value == defaultText & event.type == "focus") {
                locationdescription.style.color = "black";
                locationdescription.value = "";
                locationdescription.style.border = "2px Solid #0379B5";
            }
        }


        function LocationCode(locationcode, event) {
            var defaultText = "Location Code";
            // Condition to check textbox length and event type
            if (locationcode.value.length == 0 & event.type == "blur") {
                //if condition true then setting text color and default text in textbox
                locationcode.style.color = "Gray";
                locationcode.value = defaultText;
                locationcode.style.border = "2px Solid red";
            }
            // Condition to check textbox value and event type
            if (locationcode.value == defaultText & event.type == "focus") {
                locationcode.style.color = "black";
                locationcode.value = "";
                locationcode.style.border = "2px Solid #0379B5";
            }
        }


        function DepartmentDescription(departmentdescription, event) {
            var defaultText = "Select";
            // Condition to check textbox length and event type
            if (departmentdescription.value == defaultText & event.type == "blur") {
                //if condition true then setting text color and default text in textbox
                departmentdescription.style.color = "Gray";
                departmentdescription.value = defaultText;
                departmentdescription.style.border = "2px Solid Red";

            }
            // Condition to check textbox value and event type
            if (departmentdescription.value == defaultText & event.type == "focus") {
                departmentdescription.style.color = "black";
                departmentdescription.value = "";
                departmentdescription.style.border = "2px Solid #0379B5";

            }
        }
               
    </script>--%>

    <style type="text/css">
        .style2
        {
            height: 20px;
        }
    </style>

</head>
<body onload="startTime()">
    <form id="form1" runat="server">
    <div>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <table align="center" 
             style="width: 70%; background-attachment: fixed;">

           <tr>
                                                         
                        <td colspan ="4" align="left" valign="bottom">
                            <table align="left" style="margin-left:0px;padding: 1px 4px;">
                                <tr>
                                <td valign="bottom" style="height: 140px">
                                <%--<asp:Image runat="server" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 80px; text-align: center; float: left;"  ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1"/>
--%>                               <%-- <img src="../images/esic.png" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center;"/>--%>
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
                                    <td align="right" valign="bottom" style="width:50%;">
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
                       
                       <td class="style2">
                      <p style="width:500px">
                       
                            <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" 
                                ForeColor="White">Welcome to Administrator Terminal</asp:Label>
                      </p>

                       </td>

                       <td class="style2">

                       <p style="width:200px">
                          <asp:Label ID="lbl_locationdepartmentid" runat="server" style="float: right;" 
                               Text="Location Department ID" Visible="False"></asp:Label>                    
                       </p>

                       </td>

                        <td class="style2">
                                <asp:DropDownList ID="ddl_locationdepartmentselection" runat="server"
                                style="text-align: left; float: right;" AutoPostBack="True" 
                                onselectedindexchanged="ddl_locationdepartmentselection_SelectedIndexChanged" 
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
        <h2 style="text-align: center">Schedule Master &nbsp; &nbsp; &nbsp; &nbsp;</h2></td>

    <td>
        &nbsp;</td>

    <td>
    
    </td>
    
    <%--<td>
    
    </td>--%>

    
    </tr>
    
    <tr>

    <td>
    <p style="width:250px"></p>
    </td>

    <%--<td>
     <p style="width:100px"></p>
    </td>--%>

    <td colspan="3">
    <asp:ValidationSummary ID="vs_locationmaster" runat="server" ForeColor="Red" 
            style="text-align: left" />
    </td>

    <td>
     <p style="width:100px"></p>
    </td>
    
    </tr>
    
    <tr>

    <td>
    <%-- <p style="width:100px"></p>--%>
     </td>

    <td>
     <%--<p style="width:100px"></p>--%>
    </td>
    
    <td></td>

    <td>
        <asp:Label ID="lbl_schedulemaster" runat="server" Text="N" ForeColor="Red" 
                Visible="False"></asp:Label>
        </td>

    <td></td>

    </tr>
    
    <tr>
    
    <td></td>

    <td>
    
    </td>

    <td>
    <asp:Label ID="lbl_locationmessage" runat="server" ForeColor="Green"></asp:Label>
    </td>
    
    <td>
    <asp:Label ID="lbl_locationid" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </td>
    
    <td></td>

    </tr>
    
    <tr>

    <td></td>

    <td></td>

    <td>
    <asp:Label ID="lbl_locationmaster" runat="server" Text="N" ForeColor="Red" 
            Visible="False"></asp:Label>
    </td>

    <td>
        <asp:Label ID="lbl_ScheduleId" runat="server" visible="false"></asp:Label>
    </td>
    
    <td></td>

    </tr>

    

    <tr>
    
    <td></td>

    <td>
     Schedule Week
    </td>

    <td>
        <asp:DropDownList ID="ddl_week1" runat="server" AppendDataBoundItems="True">
         <asp:ListItem>Select</asp:ListItem>
        </asp:DropDownList>
           

     <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
        <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
    </td>
    
    <td>
     <asp:RequiredFieldValidator ID="rfv_locationcode" ControlToValidate="ddl_week1" runat="server" ErrorMessage="Location Code Field Should Not Left Empty" InitialValue="" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
    
    <td></td>

    </tr>
    <tr>
   
   <td></td>

   <td>
    Schdule Day
   </td>

    <td>

    <asp:DropDownList ID="ddl_day" runat="server" AppendDataBoundItems="True">
     <asp:ListItem>Select</asp:ListItem>
        </asp:DropDownList>
    </td>
    
    <td>
    <asp:RequiredFieldValidator ID="rfv_locationdescription" ControlToValidate="ddl_day" runat="server" ErrorMessage="Location Description Field Should Not Left Empty" InitialValue="" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
    
    <td></td>

    </tr>

    <tr>
    
    <td></td>

    <td>
      Department Description
    </td>

    <td>
   <asp:DropDownList ID="ddl_departmentdescription" runat="server" ForeColor="Black" 
            Width="216px" Height="20px" AppendDataBoundItems="True">
       <asp:ListItem>Select</asp:ListItem>
     </asp:DropDownList>
    </td>
    
    <td>
    <asp:RequiredFieldValidator ID="rfv_locationdepartmentdescription" ControlToValidate="ddl_departmentdescription" runat="server" ErrorMessage="Department Description Field Should Not Left Empty" InitialValue="Select" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
    
    <td></td>

    </tr>

    <tr>
   
   <td></td>

   <td>
    Schdule Room Code
   </td>

    <td>

   <asp:DropDownList ID="ddl_roomcode" runat="server" ForeColor="Black" 
            Width="216px" Height="20px" AppendDataBoundItems="True">
       <asp:ListItem>Select</asp:ListItem>
     </asp:DropDownList>
    </td>
    
    <td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddl_roomcode" runat="server" ErrorMessage="Location Description Field Should Not Left Empty" InitialValue="" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
    
    <td></td>

    </tr>

    <tr>
    
    <td></td>

    <td>
     Schedule Session
    </td>

    <td>
        <asp:DropDownList ID="ddl_session" runat="server" AppendDataBoundItems="True">
         <asp:ListItem>Select</asp:ListItem>
        </asp:DropDownList>
           

     <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
        <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
    </td>
    
    <td>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddl_session" runat="server" ErrorMessage="Location Code Field Should Not Left Empty" InitialValue="" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
    
    <td></td>

    </tr>

     <tr>
    
    <td></td>

    <td>
     Schedule StartDate Time
    </td>

    <td>
        <telerik:RadTimePicker ID="dt_starttime" runat="server">
    <TimeView TimeFormat="h:mm t"></TimeView>
</telerik:RadTimePicker>

           
           <telerik:RadDatePicker ID="dt_start" runat="server"></telerik:RadDatePicker>
     <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
        <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
    </td>
    
    <td>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="dt_start" runat="server" ErrorMessage="Location Code Field Should Not Left Empty" InitialValue="" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
    
    <td></td>

    </tr>

    <tr>
    
    <td></td>

    <td>
     Schedule End Date Time
    </td>

    <td>
        
          

           <telerik:RadDatePicker ID="dt_end" runat="server">
           </telerik:RadDatePicker>
         <telerik:RadTimePicker ID="dt_endtime" runat="server">
    <TimeView TimeFormat="h:mm t"></TimeView>
</telerik:RadTimePicker>
     <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
        <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
    </td>
    
    <td>
     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="dt_end" runat="server" ErrorMessage="Location Code Field Should Not Left Empty" InitialValue="" Display="None" ForeColor="Red">*</asp:RequiredFieldValidator>
    </td>
    
    <td></td>

    </tr>

    <%--<tr>
    
    <td></td>

    <td></td>

    <td>
    
    </td>
    
    <td>
     
    </td>
    
    <td></td>

    </tr>
    
    <tr>
    
    <td></td>

    <td></td>

    <td>
  
    </td>

    <td>
    </td>
    
    <td></td>

    </tr>--%>
        
    <tr>
    
    <td>
     <p style="height:15px">
    </td>

    <td></td>

    <td>
    
     </p>
  
    </td>

    <td>
    <p style="width:175px"></p>
    <%--<asp:Label ID="lbl_locationdepartmentid" runat="server"></asp:Label>--%>
    </td>
    
    <td></td>

    </tr>
            
   <%-- <tr>
    
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

   <%-- <td></td>--%>

    <td colspan="2">

    <table align="center">

    <tr>

    <td>
    <asp:Button ID="btn_locationnew" runat="server" Text="New" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_locationnew_Click" CausesValidation="false"/>
    </td>    

    <td>
    <asp:Button ID="btn_locationedit" runat="server" Text="Edit" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_locationedit_Click" CausesValidation="false"/>
    </td>

    <td>
    <asp:Button ID="btn_locationsave" runat="server" Text="Save" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_locationsave_Click" OnClientClick="return"/>
    </td>  
    
    </tr>
            
    </table>
    
    </td>

    <td>
    
    </td>
    
    <td></td>

    </tr>

    <tr>

    <td>
     <p style="height:15px">
     </p>
    </td>

    <td></td>
    
    <td>
    
    </td>

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
    
    <td colspan="2">Location Description</td>

    </tr>

    <tr>
    
    <td colspan="2">
     <asp:TextBox ID="txt_searchlocationdescription" runat="server" Text="Location Description" 
            ForeColor="Gray" onblur = "LocationDescription(this, event);" 
            onfocus = "LocationDescription(this, event);" Width="292px" BorderColor="#0379B5" 
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

   <%-- <table align="center" class="style3">--%>
    
    <tr align="left">

    <td></td>
    
    

    <td colspan="3" align="left" >

    <%--<table align="left">

    <tr>

  

    <td>--%>

    <asp:GridView ID="gv_locationmaster" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="gv_locationmaster_SelectedIndexChanged" 
            DataKeyNames="schedule_id" 
            style="text-align: center; margin-left:0px;" AllowPaging="True" 
            onrowdatabound="gv_locationmaster_RowDataBound" 
            onpageindexchanging="gv_locationmaster_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="schedule_id" HeaderText="Schedule Id" />
            <asp:BoundField DataField="schedule_week" HeaderText="Schedule Week" />
            <asp:BoundField DataField="schedule_day" HeaderText="Schedule Day" />
            <asp:BoundField DataField="department_desc"  HeaderText="Department Description" />
            <asp:BoundField DataField="department_id" HeaderText="Department Id" />
                <asp:BoundField DataField="room_code" HeaderText="Schedule Room Code" />
                <asp:BoundField DataField="schedule_room_id" HeaderText="Schedule Room Id" />
                <asp:BoundField DataField="schedule_session" HeaderText="Schedule Session" />
                <asp:BoundField DataField="schedule_start_time" HeaderText="Schedule Start Time" />
                <asp:BoundField DataField="schedule_end_time" HeaderText="Schedule End Time" />

            
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
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

      <%--  <td></td>--%>

          <%--<td colspan="2">
          <p style="width:100px"></p>
          </td>

        </tr>

        </table>--%>

   <%-- </td>--%>
    
   <td></td>

    </tr>
      <tr>
        <td colspan="5"></td>
    </tr>
     <tr>
            <td colspan="5" align="center">
                <h5>Clinet IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="Label" 
                        ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance IP :
                [<asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>
               
            </td>
           
        </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
