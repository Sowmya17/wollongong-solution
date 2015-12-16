<%@ Page Language="C#" AutoEventWireup="true" CodeFile="crtesic.aspx.cs" Inherits="crtesic" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register src="MessageBoxUserControl.ascx" tagname="MessageBoxUserControl" tagprefix="uc1" %>
--%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="CSS/jquery-ui.css" />
    <script src="js/braviPopup.js" type="text/javascript"></script>
    <link href="CSS/braviStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="CSS/RTStyleSheet.css" />
    <title>CRT - Queue Management System</title>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btn_cusreg").click(function () {
                var phoneText = $("#txt_cusphone").val();

                if ($.trim(phoneText).length == 0) {
                    alert("Please enter Phone Number");
                    return false;
                }
                if (validatePhone(phoneText)) {
                    //alert('Valid Phone Number');
                    return true;
                }
                else {
                    alert('Invalid Phone Number');
                    return false;
                }


            });
        });
        function validatePhone(phoneText) {
            var filter = /^[0-9-+]+$/;
            if (filter.test(phoneText)) {
                return true;
            }
            else {
                return false;
            }
        }
        
    </script>
    <script type="text/javascript">
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        function IsNumeric(e) {
            var keyCode = e.which ? e.which : e.keyCode
            var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
            document.getElementById("error").style.display = ret ? "none" : "inline";
            return ret;
        }
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btn_cusreg").click(function () {
                var cusage = $("#txt_cusage").val();


                if ($.trim(cusage).length == 0) {
                    alert("Please enter Age");
                    return false;
                }
                if (validateage(cusage)) {
                    // alert('Valid Age');
                    return true;
                }
                else {
                    alert('Invalid Age');
                    return false;
                }
            });
        });
        function validateage(agetext) {
            var filter = /^[0-9-+]+$/;
            if (filter.test(agetext)) {
                return true;
            }
            else {
                return false;
            }
        }
        
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btn_search").click(function () {
                var ESICText = $("#txt_esicno").val();

                if ($.trim(ESICText).length == 0) {
                    alert("Please enter Medicare Number");
                    return false;
                }
                if (validatePhone(ESICText)) {
                    // alert('Valid ESIC Number');
                    return true;
                }
                else {
                    alert('Invalid Medicare Number');
                    return false;
                }


            });
        });
        function validatePhone(ESICText) {
            var filter = /^[0-9-+]+$/;
            if (filter.test(ESICText)) {
                return true;
            }
            else {
                return false;
            }
        }
    
        
    </script>
    <script type="text/javascript">
        //        $(document).ready(function () {
        //            $('#').click(function () {
        //                $.braviPopUp('Add Family Members', 'AddMember.aspx', 600, 400);
        //            });
        //        });
        //if you want to refresh parent page on closing of a popup window then remove comment to the below function
        //and also call this function from the js file 
        function Refresh() {
            window.location.reload();
        }
        function myfunction() {

            $.braviPopUp('Add Family Members', 'AddMember.aspx', 800, 400);
            $('#dv_move').draggable('destroy');

        };


        function myfunction1() {

            $.braviPopUp('Appointments Details', 'AppDetails.aspx', 800, 400);
            $('#dv_move').draggable('destroy');

        };

        function reprintdisplay() {

            $.braviPopUp('Reprinting', 'ReprintDisplay.aspx', 800, 400);
            $('#dv_move').draggable('destroy');

        };

        //        });       
    </script>
    <script type="text/javascript">
        function ClickHereToPrint() {
            try {
                var oIframe = document.getElementById('ifrmPrint');
                var oContent = document.getElementById('divToPrint').innerHTML;
                var oDoc = (oIframe.contentWindow || oIframe.contentDocument);
                if (oDoc.document) oDoc = oDoc.document;
                oDoc.write("<html><head>");
                oDoc.write("</head><body style='width:50%; height:50%' onload='this.focus(); this.print();'>");
                oDoc.write(oContent + "</body></html>");
                oDoc.close();

            }
            catch (e) {
                self.print();
            }
        }
        function printPageContent() {
            var DocumentContainer = document.getElementById('Label3');
            var WindowObject = window.open('', "PrintWindow", "width=70,height=70,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
            WindowObject.document.writeln(DocumentContainer.innerHTML);
            WindowObject.document.close();
            WindowObject.focus();
            WindowObject.print();
            WindowObject.close();
        }
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
    <script type="text/javascript">
        function keyPressed(evt) {
            var F5 = 116;
            if (evt.which == F5) {
                //               alert("F5 pressed");
                return false;
            }
        }
        document.onkeydown = keyPressed;
    </script>
    <script type="text/javascript">
        function functionx(evt) {
            if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
                alert("Allow Only Numbers");
                return false;
            }
        }
    </script>
    <style type="text/css">
        .style1
        {
            width: 515px;
        }
        .style2
        {
            width: 211px;
        }
        .style3
        {
            width: 50%;
        }
        .style5
        {
            width: 9%;
        }
        .style7
        {
            width: 69px;
        }
        .style9
        {
            width: 45px;
        }
        .style10
        {
            width: 35px;
        }
        .style12
        {
            width: 9px;
        }
        .style13
        {
            width: 63px;
        }
        .style14
        {
            width: 100px;
        }
        .style15
        {
            width: 34px;
        }
        .style16
        {
            height: 23px;
        }
        .style17
        {
            height: 26px;
        }
        
        
        #btn
        {
            background-position: 0% 0%;
            background-image: linear-gradient(to bottom, #60707a, #7791a3);
            -webkit-border-radius: 13;
            -moz-border-radius: 13;
            -moz-border-radius: 13px;
            font-family: Arial;
            color: #fffcff;
            font-size: 16px;
            padding: 10px 15px 11px 17px;
            text-decoration: none;
            margin-left: 99px;
            background-color: #60707a;
            background-repeat: repeat;
            background-attachment: scroll;
        }
        
        
        
        
        #btn1
        {
            background-position: 0% 0%;
            background-image: linear-gradient(to bottom, #60707a, #7791a3);
            -webkit-border-radius: 32;
            -moz-border-radius: 32;
            -moz-border-radius: 32px;
            font-family: Arial;
            color: #fffcff;
            font-size: 16px;
            padding: 10px 15px 11px 17px;
            text-decoration: none;
            margin-left: 0px;
            background-color: #60707a;
            background-repeat: repeat;
            background-attachment: scroll;
        }
    </style>
</head>
<body onload="startTime()">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 75%;" align="center">
        <%--<tr>
          <td  align="left" class="style2">
          
          </td>
         <td align="right" class="style3">
         
          </td>
     
     </tr>--%>
        <tr>
            <%-- <td class="style1">
        
         </td>--%>
            <td>
                <table align="left" style="margin-left: 3px; padding: 1px 4px; width: 869px;">
                    <tr>
                        <td align="right" style="height: 70px">
                            &nbsp;
                            <%--<asp:Image runat="server" alt="ESIC" Style="margin-left: 1px; margin-top: 4px; height: 116px;
                                text-align: center; float: left;" ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1" />--%>
                            <%--<img src="images/esic.png" alt="ESIC"  
                  
                                        style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left; width: 158px;"/>--%>
                        </td>
                        <td align="right" class="style9" valign="bottom">
                            <%-- <h3>User :</h3>--%>
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
                            <asp:Label ID="Label4" runat="server" Text="Label" Style="text-align: left"></asp:Label>
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
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%-- <asp:Image ID="Image4" runat="server" alt="Qosft" Style="margin-right: 2px; margin-top: 3px;
                                float: right;" ImageUrl="~/Admin/ImageHandler.ashx?imgID=2" />--%>
                            <%--<img src="images/qsoftTmBig.png" alt="Qosft" 
                        
                                            style="margin-right:2px; margin-top:3px;"/>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="background-color: #C0C0C0;" align="left" class="style1">
                <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White">Welcome to Clinic Registration Terminal</asp:Label>
            </td>
            <td style="background-color: #C0C0C0;" align="right">
                <asp:LinkButton ID="buttonlink" runat="server" Text="Logout" ForeColor="White" OnClick="buttonlink_Click"></asp:LinkButton>
                <%--<asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn1" runat="server" Text="Appointments" OnClientClick="form.open('AppDetails.aspx', 'OtherPage');"
                        OnClick="btn1_Click" />
                </p>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table align="center" style="margin-left: 120px; padding: 1px 4px; width: 75%; border: 1px solid #C0C0C0;">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lbl_esicno" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">Medicare Number</asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;
                            <asp:Label ID="lbl_surname" runat="server" Font-Bold="true" Font-Size="Large" ForeColor="Darkslategray">Surname</asp:Label>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txt_esicno" runat="server" MaxLength="20" Width="200px" ForeColor="DarkSlateGray"></asp:TextBox>
                                    &nbsp;
                                    <asp:Button ID="btn_search" runat="server" Text="Search" OnClick="btn_search_Click1"
                                        ClientIDMode="Predictable" ViewStateMode="Disabled" />
                                    &nbsp;&nbsp;
                                    <asp:Label ID="Label12" runat="server" Width="50px" Font-Size="Large" Text="or"></asp:Label>
                                    <asp:TextBox ID="txt_surname" runat="server" MaxLength="20" Width="200px" ForeColor="DarkSlateGray"></asp:TextBox>
                                    &nbsp;
                                    <asp:Button ID="btn_Search1" runat="server" Text="Search" 
                                        OnClick="btn_Search1_Click" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="surnameupdatepanel" runat="server">
                                <ContentTemplate>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:DropDownList ID="DropDownList1" Width="200px" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
                                        <asp:ListItem Text="Select your Name" Value="0"> </asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">
                             Card Holder Information</asp:Label>
                        </td>
                        <td align="left">
                            <asp:Label ID="Label6" Style="margin-left: 50px; padding: 1px 4px; text-align: left;"
                                runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">Patient Information</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table align="left">
                                <tr>
                                    <td>
                                        <%--First Name--%>
                                        <asp:Label ID="Lbl8" runat="server" Text="First Name" ForeColor="DarkSlateGray" Font-Size="13pt"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_cusfname" runat="server" Width="150px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <%--<tr><td>&nbsp;</td></tr>--%>
                                <tr>
                                    <td>
                                        <%--Sur Name--%>
                                        <asp:Label ID="lbl9" runat="server" Text="Surname" ForeColor="DarkSlateGray" Font-Size="13pt"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_cuslname" runat="server" Width="150px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <%-- <tr><td>&nbsp;</td></tr>--%>
                                <tr>
                                    <td>
                                        <%--Address--%>
                                        <asp:Label ID="Label7" runat="server" Text="Address" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_cusadd" runat="server" TextMode="MultiLine" Width="150px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <%-- <tr><td>&nbsp;</td></tr>--%>
                                <tr>
                                    <td>
                                        <%--Phone--%>
                                        <asp:Label ID="Label8" runat="server" Text="Phone" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_cusphone" runat="server" Width="150px" onkeypress="return functionx(event)"
                                                    OnTextChanged="txt_cusphone_TextChanged"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style17">
                                        <%--E-mail--%>
                                        <asp:Label ID="Label9" runat="server" Text="E-mail" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                    <td class="style17">
                                    </td>
                                    <td class="style17">
                                        <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_cusemail" runat="server" Width="150px">
                                                </asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--Gender--%>
                                        <asp:Label ID="Label10" runat="server" Text="Gender" Font-Size="13pt" ForeColor="DarkSlateGray"
                                            Visible="false"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddl_cusgender" runat="server" Width="155px" Visible="false">
                                                    <asp:ListItem Value="S">Select</asp:ListItem>
                                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <%--<tr><td>&nbsp;</td></tr>--%>
                                <tr>
                                    <td>
                                        <%--Age--%>
                                        <asp:Label ID="Label11" runat="server" Text="Age" Font-Size="13pt" ForeColor="DarkSlateGray"
                                            Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_cusage" runat="server" Width="150px" MaxLength="3" onkeypress="return functionx(event)"
                                                    Visible="False"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <%--Date Of Birth--%>
                                        <asp:Label ID="lbl12" runat="server" Text="Date Of Birth" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                            <ContentTemplate>
                                                <telerik:RadDatePicker ID="RadDatePicker1" runat="server">
                                                </telerik:RadDatePicker>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center">
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btn_cusreg" runat="server" Text="Save" Width="75px" OnClick="btn_cusreg_Click" />
                                                <input id="Hidden1" type="hidden" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                            <ContentTemplate>
                                                <asp:Label ID="lbl_appointmentid" runat="server" Text="Appointment Id" Visible="False"
                                                    Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right">
                            <table align="right">
                                <tr>
                                    <td>
                                        <%--Student Name--%>
                                        <asp:Label ID="lbl7" runat="server" Text="Patient Name" ForeColor="DarkSlateGray"
                                            Font-Size="13pt"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddl_patlist" runat="server" Width="155px" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddl_patlist_SelectedIndexChanged" ForeColor="DarkSlateGray">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;</ContentTemplate>
                                        </asp:UpdatePanel>
                                        <%--                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClientClick="return myfunction()">Add Member</asp:LinkButton>
                                        --%><%-- <a href="#" onclick="myfunction()">Add Members</a>--%>
                                        <asp:HyperLink ID="AddMembers" NavigateUrl="#" runat="server" onclick="myfunction()">Add Members</asp:HyperLink>
                                    </td>
                                </tr>
                                <%-- <tr><td>&nbsp;</td></tr>--%>
                                <tr>
                                    <td>
                                        <%--Gender--%>
                                        <asp:Label ID="lbl112" runat="server" Text="Gender" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddl_patgender" runat="server" Width="155px" Enabled="false"
                                                    ForeColor="DarkSlateGray">
                                                    <asp:ListItem Value="S">Select</asp:ListItem>
                                                    <asp:ListItem Value="F">Female</asp:ListItem>
                                                    <asp:ListItem Value="M">Male</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <%--<tr><td>&nbsp;</td></tr>--%>
                                <tr>
                                    <td>
                                        <%--Age--%>
                                        <asp:Label ID="lbl012" runat="server" Text="Age" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_patage" runat="server" Width="150px" Enabled="false" ForeColor="DarkSlateGray"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <%-- <tr><td>&nbsp;</td></tr>--%>
                                <tr>
                                    <td>
                                        <%--Select the Department--%>
                                        <asp:Label ID="lbl222" runat="server" Text="Select the Department" Font-Size="13pt"
                                            ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <table>
                                            <tr>
                                                <td rowspan="6" valign="top">
                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ListBox ID="lb_deptlist" AutoPostBack="true" runat="server" Height="120px" Font-Bold="False"
                                                                Font-Size="Medium" Width="150px" ForeColor="DarkSlateGray" OnSelectedIndexChanged="lb_deptlist_SelectedIndexChanged1">
                                                            </asp:ListBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                </td>
                                                <td rowspan="6" valign="top">
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ListBox ID="lb_seldeptlist" AutoPostBack="true" runat="server" Height="120px"
                                                                Font-Bold="False" Font-Size="Medium" Width="150px" ForeColor="DarkSlateGray">
                                                            </asp:ListBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_l1tol2" runat="server" Text=">" Width="45px" OnClick="l1tol2_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_up" runat="server" Text="Up" Width="45px" OnClick="Up_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_l2tol1" runat="server" Text="<" Width="45px" OnClick="l2tol1_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_down" runat="server" Text="Down" Width="45px" OnClick="Down_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style16">
                                                    <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_consultingtype" runat="server" Text="Consultation Type" Font-Size="13pt"
                                                        ForeColor="DarkSlateGray"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                                        <ContentTemplate>
                                                            <asp:DropDownList ID="ddl_consultationstatus" runat="server" Height="23px" Width="155px"
                                                                AutoPostBack="True" OnSelectedIndexChanged="ddl_consultationstatus_SelectedIndexChanged">
                                                                <asp:ListItem Value="W">Walk-in</asp:ListItem>
                                                                <asp:ListItem Value="A">Appointment</asp:ListItem>
                                                                <asp:ListItem Value="V">VIP</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lbl_scheduledtime" runat="server" Text="Consulting Time" Font-Size="13pt"
                                                        ForeColor="DarkSlateGray"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                        <ContentTemplate>
                                                            <asp:TextBox ID="txt_consultingtime" runat="server" Width="152px" Enabled="False"
                                                                ForeColor="DarkSlateGray"></asp:TextBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lbltxt" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="3">
                                        <table>
                                            <tr>
                                                <td>
                                                    <%-- <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                            <ContentTemplate>--%>
                                                    <asp:Button ID="btn_reset" runat="server" Text="Reset" Width="75px" OnClick="btn_reset_Click" />
                                                    <%--</ContentTemplate>
                                        </asp:UpdatePanel>--%>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_reprint" runat="server" Text="Re-Print" Width="75px" OnClick="btn_reprint_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="upd_printq" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_print" runat="server" Text="Print - Q" Width="75px" OnClick="btn_print_Click" />
                                                            <%--OnClientClick="printPageContent()"--%>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="style16">
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table id="tbl_queuestatus" runat="server" align="left" style="margin-left: 120px;">
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <%--<asp:Label ID="lbl_queuenumber" runat="server" Font-Bold="True" 
                                                                        ForeColor="#0066FF">Queue Status</asp:Label>--%>
                            <asp:TextBox ID="txt_queuenumber" runat="server" ForeColor="Black"></asp:TextBox>
                        </td>
                        <td colspan="2" style="text-align: center">
                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                <ContentTemplate>
                                    <%--<asp:Button ID="Button1" runat="server" Text="Save" Width="75px" 
                                                              onclick="btn_cusreg_Click" />--%>
                                    <asp:Button ID="btn_queuestatus" runat="server" Text="Get Status" OnClick="btn_queuestatus_Click"
                                        CausesValidation="true" align="center" />
                                    <input id="Hidden2" type="hidden" runat="server" />
                                    </td>
                                    <td colspan="2" style="text-align: center">
                                    </td>
                                    <td colspan="2" style="text-align: center">
                                        <asp:Label ID="lbl_getstatus" runat="server" ForeColor="Red" Text="No Records Found"></asp:Label>
                                    </td>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" align="center" style="text-align: center">
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <%--<asp:UpdatePanel ID="Cancel_update" runat="server" ClientIDMode="AutoID" 
                                ViewStateMode="Enabled">
                                <ContentTemplate>
                                </ContentTemplate>
                            </asp:UpdatePanel>--%>
                            <asp:UpdatePanel ID="UpdatePanelCancelticket" runat="server">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txt_Qnumbercancel" runat="server" OnTextChanged="txt_Qnumbercancel_TextChanged"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="DropDownList2" runat="server" Width="150px" 
                                                    onselectedindexchanged="DropDownList2_SelectedIndexChanged">
                                                    <asp:ListItem Text="Select Description" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="Doctor Don't See" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Patient No show" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button ID="btn_cancel" runat="server" Text="Cancel Ticket" 
                                                    OnClick="btn_cancel_Click1" />
                                            </td>
                                        </tr>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table id="tbl_customerdetails" runat="server" align="center">
                    <tr>
                        <%-- <td colspan="4" style="text-align: center">
                                     
                                         <asp:Label ID="lbl_messagebox" runat="server" Text="Label"></asp:Label>
                                     
                                     </td>--%>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            <%--<asp:Label ID="lbl_queuedetails" runat="server" Text="Queue Details" 
                                ForeColor="#0066FF" Font-Bold="True"></asp:Label>--%>
                            <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_queuedetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                                        ForeColor="#333333" GridLines="None" Style="text-align: center" Width="779px">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="SL.NO" HeaderText="SL.NO" />
                                            <asp:BoundField DataField="visit_customer_id" HeaderText="Unique CMI No" />
                                            <asp:BoundField DataField="visit_customer_name" HeaderText="Card Holder Name" />
                                            <asp:BoundField DataField="members_firstname" HeaderText="Patient Name" />
                                            <asp:BoundField DataField="relation_desc" HeaderText="Relation" />
                                            <asp:BoundField DataField="department_desc" HeaderText="Department" />
                                            <asp:BoundField DataField="plan_transfer_id" HeaderText="Plan Transfer ID" Visible="false" />
                                            <asp:BoundField DataField="Queue Status" HeaderText="Queue Status" />
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
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <%--<td>
                        
                        </td>--%><%--<td>
                        
                        </td>

                        <td>
                        
                        </td>--%>
                    </tr>
                    <%--<tr>
                    
                         <td colspan="4">
                             &nbsp;</td>--%><%--  <td>
                    
                         </td>

                         <td>
                    
                         </td>

                         <td>
                    
                         </td>--%><%-- </tr>--%>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <h5>
                    Client IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance
                    IP : [<asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
