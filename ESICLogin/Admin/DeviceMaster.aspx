<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeviceMaster.aspx.cs" Inherits="DeviceMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QMS - Device Master</title>
     <link rel="stylesheet" href="../CSS/menus2.css" type="text/css" media="screen"/>
	
			
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
  <%--  <script language="javascript" type="text/javascript"">

        function DeviceName(devicename, event) {
            var defaultText = "Device Name";
            // Condition to check textbox length and event type
            if (devicename.value.length == 0 & event.type == "blur") {
                //if condition true then setting text color and default text in textbox
                devicename.style.color = "Gray";
                devicename.value = defaultText;
                devicename.style.border = "2px Solid red";
            }
            // Condition to check textbox value and event type
            if (devicename.value == defaultText & event.type == "focus") {
                devicename.style.color = "black";
                devicename.value = "";
                devicename.style.border = "2px Solid #0379B5";
            }
        }


        function DeviceDescription(devicedescription, event) 
        {
            var defaultText = "Device Description";
            // Condition to check textbox length and event type
            if (devicedescription.value.length == 0 & event.type == "blur") 
            {
                //if condition true then setting text color and default text in textbox
                devicedescription.style.color = "Gray";
                devicedescription.value = defaultText;
//                devicedescription.style.border = "2px Solid red";
            }
            // Condition to check textbox value and event type
            if (devicedescription.value == defaultText & event.type == "focus") 
            {
                devicedescription.style.color = "black";
                devicedescription.value = "";
//                devicedescription.style.border = "2px Solid #0379B5";
            }
        }

//        function NewButton(ButtonClick, event)
//        {
//            var defaultText = "Device Description";
//            // Condition to check textbox length and event type
////            if (event.type == "blur")
////             {
////                //if condition true then setting text color and default text in textbox
////                devicedescription.style.color = "Gray";
////                devicedescription.value = defaultText;
////                devicedescription.style.border = "2px Solid red";
////            }
//            // Condition to check textbox value and event type
//            if (devicedescription.value == defaultText & event.type == "focus") {
//                devicedescription.style.color = "black";
//                devicedescription.value = "";
//                devicedescription.style.border = "2px Solid #0379B5";
//            }
//        }

//        function changeColor(source, args) 
//        {
//            var txtuser = document.getElementById('txt_devicename');
//            var txtpwd = document.getElementById('txt_devicedescription');
////            var txtfname = document.getElementById('txtfname');
////            var txtlname = document.getElementById('txtlname');
//            var strimg = new Array();
//            strimg = [txtuser, txtpwd, txtfname, txtlname];
//            if (args.Value == "") 
//            {
//                args.IsValid = false;
//                document.getElementById(source.id.replace('cv', 'txt')).style.background = 'orange';
//            }
//            else 
//            {
//                args.IsValid = true;
////                document.getElementById(source.id.replace('cv', 'txt')).style.background = 'white';
//                document.getElementById(source.id.replace('cv', 'txt')).style.border = '2px Solid #0379B5';
//            }
        //        }

//        function ChangeBorder(obj, evt)
//        {

//            if (evt.type == "focus")

//            txt_devicedescription.
//                obj.style.borderColor = "red";

//            else if (evt.type == "blur")

//                obj.style.borderColor = "black";

        //        } 

//        function call()
//         {
//             if (Page_ClientValidate()) 
//            {
//                return true;
//            }
//            else {
//                var v = document.getElementById('txt_devicename');
//                var s = document.getElementById('txt_devicedescription');
//                v.style.borderColor = '#0379B5';
//                s.style.borderColor = '#0379B5';
//            }
//        }
    
    </script>--%>
    <style type="text/css">
        .style2
        {
            text-align: right;
        }
        .style3
        {
            height: 113px;
        }
        </style>
</head>
<body onload="startTime()">
    <form id="frm_devicemaster" runat="server">
    <div>
   
     <table align="center" 
            style="width: 80%; background-attachment: fixed;">

                     <tr>
                                                         
                        <td colspan ="4" align="left" valign="bottom" class="style3">
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

                          <td class="style3">
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
                            <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" 
                                ForeColor="White">Welcome to Administrator Terminal</asp:Label>
                        </td>
                         <td style="background-color:#0379B5;" align="right">
                             <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>
                        </td>
                    </tr>
      
                    <tr>
                        <td colspan="6" align="center">
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
    
   <%--  <td>
      
     </td>--%>

    <td>
      
    </td>

    <td colspan="2" align="left">
        <h2 style="text-align: center">Device Master &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</h2></td>

    <td>
       </td>

    <td class="style2">
    
    </td>
    
    <%--<td>
    
    </td>--%>

    
    </tr>
    <tr>

    <td></td>

   <%-- <td></td>--%>

    

    <td colspan="2" style="text-align: center">
    <asp:ValidationSummary ID="vs_devicemaster" runat="server" DisplayMode="List" ForeColor="Red" />
    </td>
    <td></td>
    <td>
    </td>
    
   

    </tr>
       <tr>
    
    <td>
      <p style="width:225px;"></p>
    </td>

    <td>
     <%-- <p style="width:100px;"></p>--%>
    </td>

    <td>
     <%-- <p style="width:100px;"></p>--%>
    </td>

    <td>
      <%--<p style="width:100px;"></p>--%>
   <%-- <asp:ValidationSummary ID="vs_departmentmaster" runat="server" ForeColor="Red"/>--%>
    </td>
    
    
    <%--<td class="style2">
    
    </td>--%>
    
    <td>
      <p style="width:100px;"></p>
    </td>

    
    </tr>
    <tr style="width:5%">
    
    <td></td>

    <td></td>

    

    <td>
    <asp:Label ID="lbl_devicemessage" runat="server" ForeColor="Green" ></asp:Label>
    </td>
    <td></td>
    <td>
    </td>
    
    

    </tr>

    <tr>
    
    <td></td>

    <td></td>

    

    <td>
    <asp:Label ID="lbl_devicemaster" runat="server" Text="N" Visible="False" 
            ForeColor="Red"></asp:Label>
    </td>

    
    <td>
    <asp:Label ID="lbl_deviceid" runat="server" Visible="False" ForeColor="Red" >*</asp:Label>
    </td>
    
   <td></td>

    </tr>
    <tr>
       
   <td></td>

   <td>
    Device Name
   </td>

   

    <td>
    <asp:TextBox ID="txt_devicename" runat="server" ForeColor="Black" Width="200px"/>
    </td>

    <td>
     <asp:RequiredFieldValidator ID="rfv_devicename" runat="server" ControlToValidate="txt_devicename" ErrorMessage="Device Name Field Should Not Be Left Empty" Display="None" ForeColor="Red" InitialValue="">*</asp:RequiredFieldValidator>
    </td>
    <td></td>
    </tr>

    <tr>
    
    <td></td>

    <td>
     Device Description
    </td>

    

    <td>
          <asp:TextBox ID="txt_devicedescription" runat="server" 
           ForeColor="Black" Width="200px" />

     <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
        <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
    </td>

    <td>
    <%--<asp:CustomValidator ID="cv_devicename" runat="server" SetFocusOnError="true" ControlToValidate="txt_devicename" ValidateEmptyText="true" Display="None" ClientValidationFunction="changecolor" ErrorMessage="Device Name Field Should Not Be Left Empty">*</asp:CustomValidator>--%>
   
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
   
   <td></td>

   <td>
   <p style="height:10px"></p>
   </td>

   <td>
   
   </td>
   
   <td>
   </td>
   
   </tr>

    <tr>
    
    <td></td>

    <%--<td>

    
    
    </td>--%>

  

    <td colspan="3" style="text-align: center">

    <table align="center">
    <tr align="center">

    <td style="text-align: center">
    <asp:Button ID="btn_devicenew" runat="server" Text="New" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True"
            onclick="btn_devicenew_Click" CausesValidation="false" />
    </td>

    <td>
    <asp:Button ID="btn_deviceedit" runat="server" Text="Edit" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_deviceedit_Click" CausesValidation="false"/>    
    </td>
    <td>
    <%--<asp:Button ID="btn_devicesave" CausesValidation="true" runat="server" Text="Save" style="text-align: right" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_devicesave_Click"/>   --%> 
            <asp:Button ID="btn_devicesave" runat="server" Text="Save" 
            BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" Font-Bold="True" ForeColor="White" Width="65px" 
            onclick="btn_devicesave_Click" OnClientClick="return" 
            style="text-align: center"/>
    </td>

     </tr>

     </table>

    </td>

    <td>
    </td>
      <td></td>
    </tr>

    <tr>
    
    <td></td>

    <td></td>
    
    <td>
    <p style="height:15px"></p>
    </td>

    <td>
    </td>

    <td>
    </td>
   
    </tr>

    <%--<tr>
    
    <td colspan="2">
    </td>

    </tr>

    <tr>
    
    <td class="style1"><span style="color:Blue">SEARCH</span></td>

    </tr>

    <tr>
    
    <td>Device Name</td>

    </tr>

    <tr>
    
    <td>
     <asp:TextBox ID="txt_searchdevicename" runat="server" Text="Device Name" 
            ForeColor="Gray" onblur = "DeviceName(this, event);" 
            onfocus = "DeviceName(this, event);" Width="292px" BorderColor="#0379B5" 
            BorderStyle="Solid" />
    </td>

    </tr>

    <tr>
    
    <td>
    
    </td>

    </tr>

    <tr>
    
    <td>
    
    </td>
    </tr>--%>
   <%-- </table>--%>

   <%-- <table align="center">--%>
    
    <tr align="left">
    
    <td></td>

   

    <td colspan="3" align="left">

    <asp:GridView ID="gv_devicemaster" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" ForeColor="#333333" GridLines="None" 
            onselectedindexchanged="gv_devicemaster_SelectedIndexChanged" 
            style="text-align: center" AllowPaging="True" 
            onpageindexchanging="gv_devicemaster_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="device_id" HeaderText="Device Id" />
            <asp:BoundField DataField="device_name" HeaderText="Device Name" />
            <asp:BoundField DataField="device_desc" HeaderText="Device Description" />
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
