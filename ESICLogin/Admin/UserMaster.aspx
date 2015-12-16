<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserMaster.aspx.cs" Inherits="UserRegistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>QMS - User Master</title>
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
    <style type="text/css">
        #ddl_rolldescription
        {
        }
        #ddl_departmentdescription
        {
        }
        #ddl_userstatus
        {
        }
        #txt_username
        {
        }
        #txt_password
        {
        }
        #txt_confirmpassword
        {
        }
                
        
        .hideGridColumn
        {
            display: none;
        }
        
        .newStyle1
        {
        }
        .style7
        {
            height: 71px;
        }
    </style>
    <%--<script language="javascript" type="text/javascript">

//    function FirstName() 
//    {
////        var defaultText = "First Name";
//        // Condition to check textbox length and event type
//        if (FirstName.value == "")
//         {
//             // if condition true then setting text color and default text in textbox
//             FirstName.style.color = "Gray";
//            // txtName.value = defaultText;
//             FirstName.value = "First Name";
//         }
//            // Condition to check textbox value and event type
//         if (FirstName.value == "First Name" & event.type == "focus")
//         {
//             FirstName.style.color = "black";
//             FirstName.value = "";
//         }
    //     }


//    function WaterMark(txtName, event) 
//    {
//        var defaultText = "First Name";
//        // Condition to check textbox length and event type
//        if (txtName.value.length == 0 & event.type == "blur")
//        {
//            //if condition true then setting text color and default text in textbox
//            txtName.style.color = "Gray";
//            txtName.value = defaultText;
////            txtName.bordercolor = "Red";
////            txtName.style.background = "red";
////            txtName.style.BorderColor = "Red";
//        }
//        // Condition to check textbox value and event type
//        if (txtName.value == defaultText & event.type == "focus")
//        {
//            txtName.style.color = "Black";
//            txtName.value = "";
//            txtName.css('border-color', 'red');
////            txtName.style.background = "yellow";
////            txtName.style.border="Orange";
//        }

//        if (txtName.val().trim() == "") {
////            errMsg += "\nUserName is a mandatory field.";
////            txtName.css('border-color', 'red');
//            var v = document.getElementById('txtName');
//            v.style.bordercolor = "Red";
//        }

//        if (txtName.value == "" & event.type == "blur") 
//        {
//            txtName.style.background = "red";
//        }
    //    }

    function FirstName(firstname, event) 
    {
        var defaultText = "First Name";
        // Condition to check textbox length and event type
        if (firstname.value.length == 0 & event.type == "blur") 
        {
            //if condition true then setting text color and default text in textbox
            firstname.style.color = "Gray";
            firstname.value = defaultText;
            firstname.style.border = "2px Solid red";
        }
        // Condition to check textbox value and event type
        if (firstname.value == defaultText & event.type == "focus") 
        {
            firstname.style.color = "black";
            firstname.value = "";
            firstname.style.border = "2px Solid #0379B5";
        }
    }


    function LastName(lastname, event) 
    {
        var defaultText = "Last Name";
        // Condition to check textbox length and event type
        if (lastname.value.length == 0 & event.type == "blur")
        {
            //if condition true then setting text color and default text in textbox
            lastname.style.color = "Gray";
            lastname.value = defaultText;
            lastname.style.border = "2px Solid red";
        }
        // Condition to check textbox value and event type
        if (lastname.value == defaultText & event.type == "focus") 
        {
            lastname.style.color = "black";
            lastname.value = "";
            lastname.style.border = "2px Solid #0379B5";
        }
    }

    function UserName(username, event) 
    {
        var defaultText = "User Name";
        // Condition to check textbox length and event type
        if (username.value.length == 0 & event.type == "blur") 
        {
            //if condition true then setting text color and default text in textbox
            username.style.color = "Gray";
            username.value = defaultText;
            username.style.border = "2px Solid red";
        }
        // Condition to check textbox value and event type
        if (username.value == defaultText & event.type == "focus") 
        {
            username.style.color = "black";
            username.value = "";
            username.style.border = "2px Solid #0379B5";
        }
    }

    function Password(password, event) 
    {
        var defaultText = "Password";
        // Condition to check textbox length and event type
        if (password.value.length == 0 & event.type == "blur") 
        {
            //if condition true then setting text color and default text in textbox
            password.style.color = "Gray";
            password.value = defaultText;
            password.style.border = "2px Solid Red";
        }
        // Condition to check textbox value and event type
        if (password.value == defaultText & event.type == "focus") 
        {
            password.style.color = "black";
            password.value = "";
            password.style.border = "2px Solid #0379B5";
        }
    }

    function ConfirmPassword(confirmpassword, event) 
    {
        var defaultText = "Confirm Password";
        // Condition to check textbox length and event type
        if (confirmpassword.value.length == 0 & event.type == "blur") 
        {
            //if condition true then setting text color and default text in textbox
            confirmpassword.style.color = "Gray";
            confirmpassword.value = defaultText;
            confirmpassword.style.border = "2px Solid Red";
        }
        // Condition to check textbox value and event type
        if (confirmpassword.value == defaultText & event.type == "focus") 
        {
            confirmpassword.style.color = "black";
            confirmpassword.value = "";
            confirmpassword.style.border = "2px Solid #0379B5";
        }
    }

    function RollDescription(rolldescription, event) 
    {
        var defaultText = "Select";
        // Condition to check textbox length and event type
        if (rolldescription.value == defaultText & event.type == "blur")
         {
            //if condition true then setting text color and default text in textbox
            rolldescription.style.color = "Gray";
            rolldescription.value = defaultText;
            rolldescription.style.border = "2px Solid Red";
            
          }
        // Condition to check textbox value and event type
        if (rolldescription.value == defaultText & event.type == "focus") 
        {
            rolldescription.style.color = "black";
            rolldescription.value = "";
            rolldescription.style.border = "2px Solid #0379B5";
            
        }
    }

    function DepartmentDescription(departmentdescription, event)
     {
        var defaultText = "Select";
        // Condition to check textbox length and event type
        if (departmentdescription.value == defaultText & event.type == "blur") 
        {
            //if condition true then setting text color and default text in textbox
            departmentdescription.style.color = "Gray";
            departmentdescription.value = defaultText;
            departmentdescription.style.border = "2px Solid Red";

        }
        // Condition to check textbox value and event type
        if (departmentdescription.value == defaultText & event.type == "focus") 
        {
            departmentdescription.style.color = "black";
            departmentdescription.value = "";
            departmentdescription.style.border = "2px Solid #0379B5";

        }
    }

    function UserStatus(userstatus, event) 
    {
        var defaultText = "Select";
        // Condition to check textbox length and event type
        if (userstatus.value == defaultText & event.type == "blur") 
        {
            //if condition true then setting text color and default text in textbox
            userstatus.style.color = "Gray";
            userstatus.value = defaultText;
            userstatus.style.border = "2px Solid Red";

        }
        // Condition to check textbox value and event type
        if (userstatus.value == defaultText & event.type == "focus") 
        {
            userstatus.style.color = "black";
            userstatus.value = "";
            userstatus.style.border = "2px Solid #0379B5";

        }
    }

//    $(document).ready(function () {
//        $('#<%=gv_usermaster.ClientID %>').Scrollable();
//    }
//)
//    function mover()
//    {
//    img1.height=300;
//    img1.width=400;
//    }
//    function mout()
//    {
//    img1.height=500;
//    img1.width=1000;
//    }

</script>--%>
</head>
<body onload="startTime()">
    <form id="form1" runat="server">
    <div>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <table align="center" style="width: 70%;
            background-attachment: fixed;">
            <tr>
                <td colspan="5" align="left" valign="bottom">
                    <table align="left" style="margin-left: 0px; padding: 1px 4px;">
                        <tr>
                            <td valign="bottom" style="height: 140px">
                                <%--<asp:Image runat="server" alt="ESIC" Style="margin-left: 1px; margin-top: 4px; height: 80px;
                                    text-align: center; float: left;" ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1" />--%>
                                <%-- <img src="../images/esic.png" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center;"/>--%>
                            </td>
                            <td>
                            </td>
                            <td align="right" valign="bottom">
                                <%-- <h3>User :</h3>--%>
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/User.png" />
                            </td>
                            <td align="left" valign="bottom">
                                <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td align="right" valign="bottom">
                                <%--<h3>Terminal :</h3>--%>
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Terminal.png" />
                            </td>
                            <td align="left" valign="bottom">
                                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                            </td>
                            <td align="right" valign="bottom" style="width: 60%;">
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
                                <div id="txt">
                                </div>
                            </td>
                            <td>
                                <p>
                                    &nbsp;</p>
                            </td>
                            <td style="width: 10%;">
                                <p>
                                    &nbsp;</p>
                            </td>
                            <td align="right" valign="bottom">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Desktop.png" />
                            </td>
                            <td align="right" valign="bottom">
                                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <%--<td class="style7">
                                         <img src="../images/Intouch2.jpg" alt="Qsft" style="margin-right: 2px; margin-top: 3px;
                                float: right;" />
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td>
                                        <%-- <asp:Image ID="Image4" runat="server" alt="Qosft" Style="margin-right: 2px; margin-top: 3px;
                                    float: right;" ImageUrl="~/Admin/ImageHandler.ashx?imgID=2" />--%>
                                        </td>
                                    </tr>
                                </table>
                               
                                <%--<img src="../images/qsoftTmBig.png" alt="Qosft" 
                                            style="margin-right:2px; margin-top:3px; float:right;"/>--%>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="background-color: #0379B5;" align="left" colspan="4">
                    <table>
                        <tr>
                            <td colspan="4">
                                <p style="width: 500px">
                                    <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White">Welcome to Administrator Terminal</asp:Label>
                                </p>
                            </td>
                            <%-- <td>
                        
                        <p style="width:100px">
                        
                        </p>
                        
                        </td>

                         <td>
                        
                        <p style="width:50px">
                        
                        </p>
                        
                        </td>--%>
                            <%--<td>
                        
                        <p style="width:50px">
                        
                        </p>
                        
                        </td>--%>
                            <td>
                                <p style="width: 200px">
                                    <asp:Label ID="lbl_userdepartmentid" runat="server" Style="float: right;" Text="User Department ID"
                                        Visible="False"></asp:Label>
                                </p>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_userdepartmentselection" runat="server" Style="text-align: left;
                                    float: right;" AutoPostBack="True" OnSelectedIndexChanged="ddl_userdepartmentselection_SelectedIndexChanged"
                                    Height="20px" Width="156px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="background-color: #0379B5;" align="right">
                    <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td>
                </td>
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
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <%-- <td>
      
    </td>--%>
                <td colspan="3">
                    <h2 style="text-align: center">
                        User Master</h2>
                </td>
                <%-- <td colspan="2"></td>--%>
                <td>
                </td>
                <%--
    <td>
    <p style="width:100px"></p>
    </td>--%>
                <%-- <td>
    
    </td>--%>
            </tr>
            <tr>
                <td>
                </td>
                <%--  <td></td>--%>
                <td colspan="3" style="height: auto">
                    <asp:ValidationSummary ID="vs_usermaster" runat="server" Height="50px" DisplayMode="List"
                        ForeColor="Red" Style="text-align: center; height: auto" />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <%--  <p style="width:175px;"></p>--%>
                </td>
                <td>
                    <%--<p style="width:80px;"></p>--%>
                </td>
                <td colspan="3" style="text-align: center">
                    <asp:Label ID="lbl_usermaster" runat="server" Text="N" ForeColor="Red" Style="text-align: center"
                        Visible="False"></asp:Label>
                </td>
                <%--<td></td>--%>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="lbl_message" runat="server" ForeColor="Green" Style="text-align: center"></asp:Label>
                </td>
                <td style="text-align: center">
                    <asp:Label ID="lbl_userid" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                </td>
                <%-- <td colspan="2"></td>--%>
            </tr>
            <tr style="width: 10%">
                <td colspan="3">
                </td>
                <%--<td></td>--%>
                <td>
                    <table>
                        <tr>
                            <td colspan="3">
                                <p style="width: 75px">
                                </p>
                            </td>
                            <td>
                            </td>
                            <td>
                                <p style="width: 125px">
                                    First Name
                                </p>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_firstname" runat="server" ForeColor="Black" Width="150px" />
                                <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
                                <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
                            </td>
                            <td>
                                <%--<p style="width:50px">--%>
                                <asp:RequiredFieldValidator ID="rfv_firstname" runat="server" ControlToValidate="txt_firstname"
                                    ErrorMessage="First Name Field Should Not Be Left Empty" Display="None" ForeColor="Red"
                                    InitialValue="">*</asp:RequiredFieldValidator>
                                <%-- </p>--%>
                            </td>
                            <td>
                                <p style="width: 175px;">
                                    Last Name
                                </p>
                            </td>
                            <td>
                                <asp:TextBox ID="txt_lastname" runat="server" ForeColor="Black" Width="150px" />
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <%--<tr>
    
    <td></td>

     <td></td>

    <td>
     
     <p style="width:200px">
     
     </p>
     
     </td>

    </tr>--%>
                        <tr>
                            <td colspan="3">
                            </td>
                            <td>
                            </td>
                            <td>
                                User Status
                            </td>
                            <td>
                                <asp:DropDownList ID="ddl_userstatus" runat="server" ForeColor="Black" Width="156px"
                                    Height="20px">
                                    <asp:ListItem>Select</asp:ListItem>
                                    <asp:ListItem>Active</asp:ListItem>
                                    <asp:ListItem>In-Active</asp:ListItem>
                                </asp:DropDownList>
                                <%--<select id="ddl_userstatus">
    <option>Active</option>
    <option>In-Active</option>
    </select>--%>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfv_userstatus" runat="server" Display="None" ControlToValidate="ddl_userstatus"
                                    ErrorMessage="User Status Should Not Be Select" ForeColor="Red" InitialValue="Select">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                User Name
                            </td>
                            <td>
                                <asp:TextBox ID="txt_username" runat="server" ForeColor="Black" OnTextChanged="txt_username_TextChanged"
                                    AutoPostBack="True" Width="150px" />
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="rfv_username" runat="server" ErrorMessage="User Name Field Should Not Be Left Empty"
                                    Display="None" ControlToValidate="txt_username" ForeColor="Red" InitialValue="">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <p style="width: 30px">
                                    <asp:Image ID="img_usernameavailability" runat="server" Width="17px" Height="17px" />
                                </p>
                            </td>
                            <td>
                                <asp:Label ID="lbl_usernameavailability" runat="server"></asp:Label>
                            </td>
                            <%--    <td></td>--%>
                        </tr>
                        <%--<tr>
    
    <td></td>

     <td></td>

   
    
   

     <td></td>

    </tr>

    <tr>--%>
                    <td colspan="3">
                    </td>
                <td>
                </td>
                <td>
                    Password
                </td>
                <td>
                    <asp:TextBox ID="txt_password" runat="server" TextMode="Password" ForeColor="Black"
                        Width="150px" />
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_password" runat="server" ErrorMessage="Password Field Should Not Be Left Empty"
                        Display="None" ControlToValidate="txt_password" ForeColor="Red" InitialValue="">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    Confirm Password
                </td>
                <td>
                    <asp:TextBox ID="txt_confirmpassword" runat="server" ForeColor="Black" TextMode="Password"
                        Width="150px" />
                </td>
                <td>
                    <asp:CompareValidator ID="cv_confirmpassword" runat="server" ControlToValidate="txt_confirmpassword"
                        ControlToCompare="txt_password" ErrorMessage="Password Mismatch ....!" Display="None"
                        ForeColor="Red">*</asp:CompareValidator>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <%-- <tr>
    
    <td></td>

     <td></td>

   

 <td></td>
 
    </tr>--%>
            <%-- <tr>
    
    <td></td>

     <td></td>

    
     <td></td>

    </tr>--%>
            <%--<tr>
    
    <td></td>
    
     <td></td>

    
    
     <td></td>

    </tr>--%>
            <tr>
                <td colspan="3">
                </td>
                <td>
                </td>
                <td>
                    Roll Description
                </td>
                <td>
                    <asp:DropDownList ID="ddl_rolldescription" runat="server" ForeColor="Black" Width="156px"
                        Height="20px" AppendDataBoundItems="True">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                    <%--<select id="ddl_rolldescription">
   <option>Roll1</option>
   <option>Roll2</option>
   </select>--%>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_rolldescription" runat="server" Display="None"
                        ControlToValidate="ddl_rolldescription" ErrorMessage="Roll Description Should Not Be Select"
                        ForeColor="Red" InitialValue="Select">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    Department Description
                </td>
                <td>
                    <asp:DropDownList ID="ddl_departmentdescription" runat="server" ForeColor="Black"
                        Width="156px" Height="20px" AppendDataBoundItems="True">
                        <asp:ListItem>Select</asp:ListItem>
                    </asp:DropDownList>
                    <%--<select id="ddl_departmentdescription">
    <option>Department1</option>
    <option>Department2</option>
    </select>--%>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfv_departmentdescription" runat="server" Display="None"
                        ControlToValidate="ddl_departmentdescription" ErrorMessage="Department Desciption Should Not Be Select"
                        ForeColor="Red" InitialValue="Select">*</asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <%-- <tr>
    
    <td></td>

     <td></td>

   

    
    
     <td></td>

    </tr>--%>
            <%-- <tr>

    <td></td>

     <td></td>

    
            
             <td></td>

    </tr>--%>
            <%-- <tr>
    
     <td></td>

     <td></td>

    
    
     <td></td>

    </tr>

    <tr>
    
     <td></td>

      <td></td>

    
       
        <td></td>

    </tr>

    <tr>
    
     <td></td>

     <td></td>

    

    
    
     <td></td>

    </tr>--%>
            <tr>
                <td colspan="3">
                </td>
                <td>
                </td>
                <td colspan="4">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="12">
                    <p style="height: 15px">
                    </p>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
                <td>
                </td>
                <td colspan="5" align="center">
                    <table>
                        <tr>
                            <td style="text-align: center">
                                <asp:Button ID="btn_usernew" runat="server" Text="New" Width="65px" BackColor="#0379B5"
                                    BorderColor="#0379B5" BorderStyle="Solid" ForeColor="White" Font-Bold="True"
                                    OnClick="btn_usernew_Click" CausesValidation="false" Style="text-align: left" />
                            </td>
                            <td style="text-align: center">
                                <asp:Button ID="btn_useredit" runat="server" Text="Edit" Style="text-align: center"
                                    Width="65px" BackColor="#0379B5" BorderColor="#0379B5" BorderStyle="Solid" ForeColor="White"
                                    Font-Bold="True" OnClick="btn_useredit_Click" CausesValidation="false" />
                            </td>
                            <td style="text-align: left">
                                <asp:Button ID="btn_usersave" runat="server" Text="Save" Width="65px" BackColor="#0379B5"
                                    BorderColor="#0379B5" BorderStyle="Solid" ForeColor="White" Font-Bold="True"
                                    OnClick="btn_usersave_Click" OnClientClick="return" />
                            </td>
                        </tr>
                    </table>
                </td>
                <%--</tr>
    
    </table>
    
    </td>--%>
                <td colspan="3">
                </td>
                <%-- <td colspan="2"></td>--%>
            </tr>
        </table>
        </td>
        <td>
        </td>
        <%--<td></td>--%>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td colspan="4">
                <p style="height: 15px">
                </p>
            </td>
            <%--  <td></td>--%>
        </tr>
        <%--<tr>
    
    <td colspan="2">
    </td>

    </tr>

    <tr>
    
    <td class="style1" colspan="2"><span style="color:Blue">SEARCH</span></td>

    </tr>

    <tr>
    
    <td colspan="2">User Name</td>

    </tr>

    <tr>
    
    <td colspan="2">
     <asp:TextBox ID="txt_searchusername" runat="server" Text="User Name" 
            ForeColor="Gray" onblur = "UserName(this, event);" 
            onfocus = "UserName(this, event);" Width="292px" BorderColor="#0379B5" 
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
        <%--</table>

    <table align="center" class="style3">--%>
        <tr>
            <td>
            </td>
            <td colspan="6" align="center">
                <asp:GridView ID="gv_usermaster" runat="server" AutoGenerateColumns="False" CellPadding="4"
                    ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gv_usermaster_SelectedIndexChanged"
                    Width="844px" DataKeyNames="user_pwd,roll_id,department_id" Style="text-align: center"
                    AllowPaging="True" OnPageIndexChanging="gv_usermaster_PageIndexChanging" OnRowDataBound="gv_usermaster_RowDataBound">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="user_id" HeaderText="User Id" />
                        <asp:BoundField DataField="user_login" HeaderText="User Name" />
                        <asp:BoundField DataField="user_firstname" HeaderText="First Name" />
                        <asp:BoundField DataField="user_lastname" HeaderText="Last Name" />
                        <asp:BoundField DataField="roll_desc" HeaderText="Roll Description" />
                        <asp:BoundField DataField="department_desc" HeaderText="Department Description" />
                        <asp:BoundField DataField="user_active" HeaderText="User Active" />
                        <asp:BoundField DataField="user_pwd" HeaderText="Password" />
                        <asp:BoundField DataField="roll_id" HeaderText="Roll ID" />
                        <asp:BoundField DataField="department_id" HeaderText="Department ID" />
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
            <%-- <td></td>--%>
        </tr>
        <tr>
            <td colspan="6">
            </td>
        </tr>
        <tr>
            <td colspan="6" align="center">
                <h5>
                    Clinet IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance
                    IP : [<asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>
            </td>
        </tr>
        </table>
    </div>
    <span id="Message" runat="server"></span>
    </form>
</body>
</html>
