<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DepartmentMaster.aspx.cs" Inherits="DepartmentMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>QMS - Department Master</title>
    <link rel="stylesheet" href="../CSS/menus.css" type="text/css" media="screen"/>
	
			
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

        function DepartmentDescription(departmentdescription, event) 
        {
            var defaultText = "Department Description";
            // Condition to check textbox length and event type
            if (departmentdescription.value.length == 0 & event.type == "blur")
            {
                //if condition true then setting text color and default text in textbox
                departmentdescription.style.color = "Gray";
                departmentdescription.value = defaultText;
                departmentdescription.style.border = "2px Solid red";
            }
            // Condition to check textbox value and event type
            if (departmentdescription.value == defaultText & event.type == "focus")
            {
                departmentdescription.style.color = "black";
                departmentdescription.value = "";
                departmentdescription.style.border = "2px Solid #0379B5";
            }
                        
        }
        function DepartmentCode(departmentcode, event) {
            var defaultText = "Department Code";
            // Condition to check textbox length and event type
            if (departmentcode.value.length == 0 & event.type == "blur") {
                //if condition true then setting text color and default text in textbox
                departmentcode.style.color = "Gray";
                departmentcode.value = defaultText;
                departmentcode.style.border = "2px Solid red";
            }
            // Condition departmentcode check textbox value and event type
            if (departmentcode.value == defaultText & event.type == "focus") {
                departmentcode.style.color = "black";
                departmentcode.value = "";
                departmentcode.style.border = "2px Solid #0379B5";
            }
                        
        }

//        var i = 0;
//        $(document).ready(function () {
//            ShowCurrentTime();
//        })
//        function ShowCurrentTime() {
//            var dt = new Date();
//            document.getElementById("lblTime").innerHTML = 5 - i + " Seconds";
//            i++;
//            if (i == 5) {
//             
//            }
//            window.setTimeout("ShowCurrentTime()", 1000);
//        }

//       function HideValidationErrors() {  
//       //Hide all validation errors  
//       if (window.Page_Validators)  
//           for (var vI = 0; vI < Page_Validators.length; vI++) {  
//           var vValidator = Page_Validators[vI];  
//           vValidator.isvalid = true;  
//           ValidatorUpdateDisplay(vValidator);  
//       }  
//       //Hide all validaiton summaries  
//       if (typeof (Page_ValidationSummaries) != "undefined") { //hide the validation summaries  
//           for (sums = 0; sums < Page_ValidationSummaries.length; sums++) {  
//               summary = Page_ValidationSummaries[sums];  
//               summary.style.display = "none";  
//           }  
//       }  


    </script>--%>

    <style type="text/css">
        .style2
        {
            width: 0px;
        }
        .style3
        {
            width: 150px;
        }
        .style4
        {
            height: 126px;
        }
        .style5
        {
            height: 23px;
        }
        .style6
        {
            width: 150px;
            height: 23px;
        }
        .style7
        {
            height: 36px;
        }
        .style8
        {
            width: 150px;
            height: 36px;
        }
    </style>

</head>
<body onload="startTime()">
    <form id="form1" runat="server">
    <div>
    <center>
   </center>
   <table align="center" 
            style="width: 70%; background-attachment: fixed;">
   <tr>
    
                        <td>
                            <table align="left" style="margin-left:3px; padding: 1px 4px; width: 869px;">
                                <tr>
                                <td align="right" class="style8" style="height: 140px">
                                <%--<asp:Image runat="server" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 80px; text-align: center; float: left;"  ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1"/>
--%>                                <%--<img src="../images/esic.png" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;" />--%>
<%--                                 <img src="images/esic.png" alt="ESIC"  
                  style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;"/>--%>
                  </td>
                                    <td align="right" class="style9" valign="bottom">
                                        <%-- <h3>User :</h3>--%>
                                        <%--<asp:Image ID="Image4" runat="server"  ImageUrl="~/images/User.png" />--%>

                                        <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/User.png" />
                                    </td>
                                    <td align="left" class="style7" valign="bottom">
                                        <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <%--<td class="style12">&nbsp;</td>
                                    <td>&nbsp;</td>--%>
                                    <td align="right" class="style10" valign="bottom">
                                        <%--<h3>Terminal :</h3>--%>
                                        <asp:Image ID="Image2" runat="server" 
                                            ImageUrl="~/images/Terminal.png"  />
                                    </td>
                                    <td align="left" class="style14" valign="bottom">
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="right" class="style3" valign="bottom">
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="left" class="style13" valign="bottom">
                                        <div id="txt"></div>
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
                        <td style="background-color:#0379B5;" align="left">
                            <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" 
                                ForeColor="White">Welcome to Administrator Terminal</asp:Label>
                        </td>
                         <td style="background-color:#0379B5;" align="right">
                             <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>
                        </td>
                    </tr>

                    <tr>

                    <td colspan="2">
                    
                   
    <table align="center" 
                            
                            
                            
                            style="width: 70%; background-attachment: fixed;">


      <%-- <tr>
                        <td style="background-color:#0379B5;" align="left" colspan="4">
                            <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" 
                                ForeColor="White">Welcome to Administrator Terminal</asp:Label>
                        </td>
                         <td style="background-color:#0379B5;" align="right">
                             <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>
                        </td>
                    </tr>--%>
                
                    <tr>
                        <td colspan="5" class="style4" align="center">
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
                                <%--<li><a href="TotalQueue.aspx" style="text-decoration: none">TotalQueue</a></li>
                                <li><a href="Status.aspx" style="text-decoration: none">Status</a></li>
            <li><a href="#" style="text-decoration: none">Reports <span class="arrow">&#9660;</span></a>
        		<ul class="sub-menu">
                     <li><a href="DailyReport.aspx" style="text-decoration: none">Daily Report</a></li>
                     <li><a href="ReportTotalQueue.aspx" style="text-decoration: none">Average Time</a></li>
        			 <%--  <li><a href="ReportTotalQueue.aspx">Total Queue Report</a></li>--%>
        			 <%--<li><a href="ReportTotalMissedQueue.aspx" style="text-decoration: none">Waiting Time</a></li>--%>
        			<%-- <li><a href="#">Report 3</a></li>--%>
        		<%--</ul>
        	</li>--%>
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
        <h2 style="text-align: center">Department Master</h2></td>

    <td>
    </td>

    <td class="style3">
    
    </td>
    
    <%--<td>
    
    </td>--%>

    
    </tr>
    <tr>

     <%--<td></td>--%>

    <td></td>

    <%--<td></td>--%>

    <td colspan="3">
    <asp:ValidationSummary ID="vs_departmentmaster" runat="server" ForeColor="Red" 
            style="text-align: left" />
    </td>

    <td class="style3">
    <asp:Label ID="lbl_departmentmaster" runat="server" Text="N" ForeColor="Red" 
            Visible="False"></asp:Label>
        </td>

     <%--<td></td>--%>
    </tr>
        
    <tr>
    
    <td>
      <p style="width:250px;"></p>
    </td>

    <td>
      <p style="width:175px;"></p>
    </td>

    <td>

    <asp:Label ID="lbl_departmentmessage" runat="server" ForeColor="Green"></asp:Label>
      <%--<p style="width:100px;"></p>--%>
    </td>

    <td>
    <asp:Label ID="lbl_departmentid" runat="server" ForeColor="Red" Visible="False"></asp:Label>
     <%-- <p style="width:100px;"></p>--%>
   <%-- <asp:ValidationSummary ID="vs_departmentmaster" runat="server" ForeColor="Red"/>--%>
    </td>
    
    
    <%--<td class="style2">
    
    </td>--%>
    
    <td class="style3">
      <p style="width:150px;"></p>
    </td>

    
    </tr>

    <tr>
    
     <td>
      
     </td>

    <td>
       Department Code
    </td>

    <td>
        <asp:TextBox ID="txt_departmentcode" runat="server" ForeColor="Black" Width="210px"></asp:TextBox>
    </td>

    <td>
   <asp:RequiredFieldValidator ID="rfv_departmentcode" runat="server" ControlToValidate="txt_departmentcode" ErrorMessage="Department Code Field Should Not Be Empty" ForeColor="Red" InitialValue="" Display="None" Text="*"></asp:RequiredFieldValidator>
    </td>

    <td class="style3">
    
    </td>
    
    <%--<td>
    
    </td>--%>

    
    </tr>
    
    <tr>
    
     <td></td>

    <td>
    Department Description
    </td>

    <%--<td></td>--%>

    
    <td>
    <asp:TextBox ID="txt_departmentdescription" runat="server" ForeColor="Black" Width="210px"/>
    </td>

    <td>
    <asp:RequiredFieldValidator ID="rfv_departmentdescription" runat="server" ControlToValidate="txt_departmentdescription" ErrorMessage="Department Description Field Should Not Be Empty" ForeColor="Red" InitialValue="" Display="None" Text="*"></asp:RequiredFieldValidator>
    </td>
    
    <td class="style3">
    
    </td>

    
    </tr>
    
    <tr>
    
    <td>
    
    </td>

    <td><p style="height:15px"></p></td>

    <td>
    
    </td>

    <td>
    
    </td>
   
    <td class="style3">
    
    </td>

    
    </tr>

    <tr>
    
     <td class="style7"></td>

   <%-- <td>
    
    </td>--%>

    
    <td colspan="2" class="style7">
     <table align="center">

    <tr>

    <%-- <td></td>--%>

    <td>
    <asp:Button ID="btn_departmentnew" runat="server" Text="New" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_departmentnew_Click" CausesValidation="false"/>
    </td>

    <td>
        <asp:Button ID="btn_departmentedit" runat="server" Text="Edit"
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_departmentedit_Click" CausesValidation="false"/>
    </td>
    <td>
        <asp:Button ID="btn_departmentsave" runat="server" Text="Save" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_departmentsave_Click" OnClientClick="return"/>
    </td>
        
    </tr>  

    </table>
    </td>

    <td class="style7">
    
    </td>
    
    <td class="style8">
    
    </td>

    
    </tr>
    
    <%--<tr style="width:10%">
   
    <td>
    
    </td>

    <td></td>
    
    <td>
    
    </td>

    <td class="style2">
    
    </td>
   
    <td>
    
    </td>

    
    </tr>--%>
<%--
    <tr>
    
     <td></td>

    <td>
    
    </td>

    
    <td>
           

     <asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />
        <input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>
    </td>
      
      <td class="style2">
      
      </td>
    
    <td>
    
    </td>

    
    </tr>--%>
        
    <%--<tr>
    
     <td></td>

    <td>
    
    </td>

    
    <td>
    
    </td>
    
    <td class="style2">
    
    </td>
    
    <td>
    
    </td>

    
    </tr>
    --%>
   <%-- <tr>
    
     <td></td>

    <td>
    
    </td>

    
    <td style="text-align: right">
   
    </td>

    <td class="style2">
    
    </td>
    
    <td>
    
    </td>

    
    </tr>--%>

    <tr>
    
     <td class="style5"></td>

    <td class="style5">
    <p style="height:15px"></p>
    </td>

    <td class="style5"></td>

    <td class="style5">
    </td>

    <td class="style6">
    </td>
   
    <%--<td>
    
    </td>--%>

    
    </tr>

    <%--<tr>
    
    <td>
    </td>

    </tr>

    <tr>
    
    <td class="style1"><span style="color:Blue">SEARCH</span></td>

    </tr>

    <tr>
    
    <td>Department Description</td>

    </tr>

    <tr>
    
    <td>
     <asp:TextBox ID="txt_searchdepartmentdescription" runat="server" Text="Department Description" 
            ForeColor="Gray" onblur = "DepartmentDescription(this, event);" 
            onfocus = "DepartmentDescription(this, event);" Width="292px" BorderColor="#0379B5" 
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

    <%--<table  align="center" class="style3">--%>
    
    <tr align="center">
    
    <td></td>

  <%-- <td></td>--%>

    <td colspan="3" align="left">
    <asp:GridView ID="gv_departmentmaster" runat="server" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" 
            onselectedindexchanged="gv_departmentmaster_SelectedIndexChanged" 
            AllowPaging="True" 
            onpageindexchanging="gv_departmentmaster_PageIndexChanging" 
            style="text-align: center">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="department_id" HeaderText="Department Id" />
            <asp:BoundField DataField="department_code" HeaderText="Department Code" />
            <asp:BoundField DataField="department_desc" HeaderText="Department Description" />
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
    
     <td class="style3"></td>

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


     </td>

    </tr>

     </table>
    
    </div>
    </form>
</body>
</html>
