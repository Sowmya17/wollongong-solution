<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rtesic.aspx.cs" Inherits="rtesic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="CSS/jquery-ui.css" />
    <script src="js/braviPopup.js" type="text/javascript"></script>
    <link href="CSS/braviStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="CSS/RTStyleSheet.css" />
    <title>RT - Queue Management System</title>
    <script type="text/javascript">
        //        $(document).ready(function () {
        //            $('#').click(function () {
        //                $.braviPopUp('Add Family Members', 'AddMember.aspx', 600, 400);
        //            });
        //        });
        //if you want to refresh parent page on closing of a popup window then remove comment to the below function
        //and also call this function from the js file 
        //                function Refresh() {
        //                    window.location.reload();
        //                }
        function myfunction() {

            $.braviPopUp('Add Family Members', 'AddMember.aspx', 800, 400);
        };

        //        });       
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
        function Validate() {

            var e = document.getElementById("lb_freshQ");
            e.options[e.selectedIndex].style.backgroundColor = "red";

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
    <%-- <script type="text/javascript">

     function ConfirmAction() {

         if (confirm('Are you sure, you want to execute this action???')) {
             // you clicked the OK button.  
             // you can allow the form to post the data.  
             return true;
         }
         else {
//             document.getElementById('<%=lblMessage.ClientID %>').innerHTML = "You clicked the Cancel button.";

             // you clicked the Cancel button.  
             // you can disallow the form submission.  
             return false;
         }  

     } 
 </script>--%>
    <style type="text/css">
        .style1
        {
            height: 39px;
        }
        .style3
        {
            height: 29px;
        }
        .style4
        {
            height: 57px;
        }
        .style5
        {
            width: 192px;
        }
        .style6
        {
            height: 148px;
        }
    </style>
    <script type="text/javascript">

        function myfunction() {

            $.braviPopUp('Help', 'Help.aspx', 800, 400);
            $('#dv_move').draggable('destroy');

        };



             
    </script>
</head>
<body onload="startTime()">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%-- <div>  <uc1:MessageBoxUserControl ID="MessageBoxUserControl1" runat="server" />
                                 <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                            <ContentTemplate>
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                 </ContentTemplate></asp:UpdatePanel>
                            </div>--%>
    <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%><%-- <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick">
    </asp:Timer>--%>
    <table style="width: 75%;" align="center">
        <tr>
            <td class="style6">
                <table align="left" style="margin-left: 2px; padding: 1px 4px; width: 806px;">
                    <tr>
                        <td align="right" style="height: 140px">
                            <%--<asp:Image runat="server" alt="ESIC" Style="margin-left: 1px; margin-top: 4px; height: 116px;
                                text-align: center; float: left;" ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1" />--%>
                            <%--<img src="images/esic.png" alt="ESIC"  
                  style="margin-left:0px; margin-top:4px; height: 116px; text-align: center;"/>--%><%-- <h3>User :</h3>--%><%-- <asp:Image ID="Image4" runat="server"  ImageUrl="~/images/User.png" />--%>
                        </td>
                        <td align="right" valign="bottom" style="width: 20%">
                            <%-- <h3>User :</h3>--%>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/User.png" />
                        </td>
                        <td align="left" valign="bottom" style="width: 20%">
                            <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lbl_userid" runat="server" Text="Label" Visible="False"></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right" valign="bottom">
                            <%--<h3>Terminal :</h3>--%>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Terminal.png" />
                        </td>
                        <td align="left" valign="bottom" style="width: 20%">
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="right" style="width: 45%;" valign="bottom">
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="left" valign="bottom" style="width: 20%">
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
                        <td style="width: 40%">
                            <%--<p>&nbsp;</p>--%>
                        </td>
                        <td align="right" valign="bottom" style="width: 40%">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Desktop.png" />
                        </td>
                        <td align="right" valign="bottom" style="width: 40%">
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 10%;">
                            <p>
                            </p>
                        </td>
                    </tr>
                </table>
            </td>
            <td align="right" class="style6">
                <table>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%--<asp:Image ID="Image4" runat="server" alt="Qosft" Style="margin-right: 2px; margin-top: 3px;
                                float: right;" ImageUrl="~/Admin/ImageHandler.ashx?imgID=2" />--%>
                            <%--<img src="images/qsoftTmBig.png" alt="Qosft" 
                        
                                            style="margin-right:2px; margin-top:3px;"/>--%>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="background-color: #C0C0C0;" align="left">
                <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White">Welcome to the Recall Terminal</asp:Label>
            </td>
            <td style="background-color: #C0C0C0;" align="right">
                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <%--<p>&nbsp;</p>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table align="center" style="padding: 1px 4px; width: 90%; border: 1px solid #C0C0C0;">
                    <tr>
                        <td align="right">
                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">Medicare Number</asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txt_esicno" runat="server" Width="200px" Enabled="false" BorderStyle="None"
                                        Height="25px"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right">
                            <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">
                              Card Holder Name</asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txt_customername" runat="server" Width="200px" Enabled="false" BorderStyle="None"
                                        Height="25px"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <table align="center" style="padding: 1px 4px; width: 75%; border: 1px solid #C0C0C0;">
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">
                              New 'Q'</asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">
                              Missed Call</asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">
                              Patient Details</asp:Label>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">
                              Planned Journey List</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" rowspan="4">
                            <table>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:ListBox ID="lb_freshQ" runat="server" Font-Bold="True" Font-Size="Small" Height="126px"
                                                    Width="130px" AutoPostBack="True" OnSelectedIndexChanged="lb_freshQ_SelectedIndexChanged"
                                                    ForeColor="DarkSlateGray"></asp:ListBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label122" runat="server" Text="Multiple Apt" Width="100px" Font-Bold="True"
                                            Font-Size="Large" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel144" runat="server">
                                            <ContentTemplate>
                                                <asp:ListBox ID="lb_pendingQ" runat="server" Font-Bold="True" Font-Size="Small" Height="126px"
                                                    Width="130px" AutoPostBack="True" Enabled="False" ForeColor="DarkSlateGray">
                                                </asp:ListBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td rowspan="4">
                            &nbsp;
                        </td>
                        <td rowspan="4">
                            &nbsp;
                        </td>
                        <td valign="top" class="style4">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:ListBox ID="lb_missedQ" runat="server" Font-Bold="True" Font-Size="Small" Height="125px"
                                        Width="130" AutoPostBack="True" OnSelectedIndexChanged="lb_missedQ_SelectedIndexChanged"
                                        ForeColor="DarkSlateGray"></asp:ListBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td rowspan="4">
                            &nbsp;
                        </td>
                        <td rowspan="4">
                            &nbsp;
                        </td>
                        <td valign="top" rowspan="4">
                            <table align="left">
                                <tr style="height: 40px;">
                                    <td colspan="1">
                                        <asp:Label ID="lbl_patientname" runat="server" Text="Patient Name" Width="100px"
                                            ForeColor="DarkSlateGray" Font-Size="13pt"></asp:Label>
                                        <%-- Patient Name--%>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_patname" runat="server" Width="150px" Enabled="false" BorderStyle="None"
                                                    Height="25px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbl_queuetransactionid" runat="server" Text="Queue Transaction Id"
                                            Visible="False" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbl_visittransactionid" runat="server" Text="Visit Transaction Id"
                                            Visible="False" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                </tr>
                                 <tr style="height: 40px;">
                                    <td class="style5">
                                        <%-- Age--%>
                                        Date of Birth
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_age" runat="server" Width="150px" Enabled="false" BorderStyle="None"
                                                    Height="25px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                                                <tr style="height: 40px;">
                                    <td class="style5">
                                        <%--Gender--%>
                                        <asp:Label ID="Label125" runat="server" visible="false" Text="Gender" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_gender" Visible="false" runat="server" Width="150px" Enabled="False" BorderStyle="None"
                                                    Height="25px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lbl_queueno_show" runat="server" Text="Queue Number Show" Visible="False"
                                            Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="height: 40px;">
                                    <td class="style5">
                                        <%--Appointment Time--%>
                                        <asp:Label ID="Label123" runat="server" Text="Appointment Time" Font-Size="13pt"
                                            ForeColor="DarkSlateGray"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_relation" runat="server" Width="150px" Enabled="false" BorderStyle="None"
                                                    Height="25px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <table>
                                            <tr style="height: 40px;">
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_missedq" runat="server" Height="25px" OnClick="btn_missedq_Click"
                                                                Text="Missed 'Q'" Visible="False" Width="85px" />
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
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_endq" runat="server" Text="End 'Q'" Width="85px" Height="25px"
                                                                OnClick="btn_endq_Click" Visible="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr style="height: 40px;">
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_l1tol2" runat="server" Text="&gt;" Width="75px" OnClick="btn_l1tol2_Click"
                                                                Style="text-align: right" />
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
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_l2tol1" runat="server" Text="&lt;" Width="75px" OnClick="btn_l2tol1_Click" />
                                                            <asp:Button ID="btn_holdq" runat="server" Text="Hold 'Q'" Width="85px" Height="25px"
                                                                OnClick="btn_holdq_Click" Visible="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td colspan="2">
                                                    <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_up" runat="server" Text="Up" Width="50px" OnClick="btn_up_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <%--<td>&nbsp;</td>--%>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ListBox ID="lb_deptlist" runat="server" AutoPostBack="True" Width="150px" Height="120px">
                                                            </asp:ListBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                </td>
                                                <td rowspan="2">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ListBox ID="lb_seldeptlist" runat="server" AutoPostBack="True" Width="150px"
                                                                Height="120px"></asp:ListBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td colspan="2">
                                                    <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_down" runat="server" Text="Down" Width="50px" OnClick="btn_down_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <%--<td></td>--%>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td style="text-align: right">
                                                    <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_addservices" runat="server" OnClick="btn_addservices_Click" Style="text-align: right"
                                                                Text="Add Sevices" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td rowspan="4">
                            &nbsp;
                        </td>
                        <td rowspan="4">
                            &nbsp;
                        </td>
                        <td valign="top" rowspan="4">
                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:ListBox ID="lb_plannedlist" runat="server" Height="150px" Width="250px" Enabled="False"
                                        Font-Bold="True" Font-Size="Large" AutoPostBack="True" ForeColor="DarkSlateGray">
                                    </asp:ListBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <br />
                            <table align="left">
                                <%--<tr><td>&nbsp;</td></tr>--%>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">
                              Select Department To Transfer</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:DropDownList ID="ddl_department" runat="server" Width="250px" Height="25px"
                                            Font-Size="Medium" ForeColor="DarkSlateGray" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btn_transferq" runat="server" Text="Transfer &quot;Q&quot;" OnClick="btn_transferq_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">
                              Called Queue</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_nextq" runat="server" Width="150px" ForeColor="#00FF00" BorderStyle="None"
                                                    Height="25px" Enabled="False"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btn_callq" runat="server" Text="Call &quot;Q&quot;" Width="100px"
                                                    OnClick="btn_callq_Click" />
                                                <asp:Button ID="btn_recall" runat="server" Width="100px" Text="Re-Call &quot;Q&quot;"
                                                    OnClick="btn_recall_Click"></asp:Button>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="text-align: left">
                                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btn_mandataendq" runat="server" Text="End &quot;Q&quot;" Width="100px"
                                                    OnClick="btn_mandataendq_Click" />
                                                <asp:Button ID="btn_mandatamissedq" runat="server" Text="Missed &quot;Q&quot;" Width="100px"
                                                    OnClick="btn_mandatamissedq_Click" style="height: 26px" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btn_mandatamissedqcall" runat="server" Text="Call Missed &quot;Q&quot;"
                                                    Width="100px" OnClick="btn_mandatamissedqcall_Click" />
                                                <asp:Button ID="btn_nextq" runat="server" Text="Next &quot;Q&quot;" OnClick="btn_nextq_Click"
                                                    Width="100px" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:UpdatePanel ID="UpdatePanel28" runat="server">
                                            <ContentTemplate>
                                                <asp:HyperLink ID="AddMembers" NavigateUrl="#" runat="server" onclick="myfunction()">Help</asp:HyperLink>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="style3">
                            <asp:Label ID="Label10" runat="server" Font-Bold="True" Font-Size="Large" Visible="False"
                                ForeColor="DarkSlateGray">
                              Hold 'Q'</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="style1">
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                <ContentTemplate>
                                    <asp:ListBox ID="lb_holdQ" runat="server" Font-Bold="True" Font-Size="Small" Height="125px"
                                        Width="130px" AutoPostBack="True" OnSelectedIndexChanged="lb_holdQ_SelectedIndexChanged"
                                        Enabled="False" Visible="False" ForeColor="DarkSlateGray"></asp:ListBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" Visible="False" Style="text-align: center"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="4" style="text-align: center">
                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gv_queuedetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" Style="text-align: center; margin-left: 100px"
                            Width="779px" 
                            onselectedindexchanged="gv_queuedetails_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="SL.NO" HeaderText="SL.NO" />
                                <asp:BoundField DataField="visit_customer_id" HeaderText="Medicare Card Number" />
                                <asp:BoundField DataField="members_name" HeaderText="Patient Name" />
                                <asp:BoundField DataField="Date of Birth" HeaderText="Date of Birth" />
                                <asp:BoundField DataField="relation_desc" HeaderText="Relation" />
                                <asp:BoundField DataField="department_desc" HeaderText="Services" />
                                <asp:BoundField DataField="plan_transfer_id" HeaderText="Plan Transfer ID" Visible="False" />
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
        </tr>
        <tr>
            <td colspan="2" align="center">
                <h5>
                    Client IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance
                    IP : [<asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="5000">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
