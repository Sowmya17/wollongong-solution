<%@ Page Language="C#" AutoEventWireup="true" CodeFile="appointment.aspx.cs" Inherits="appointment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="CSS/jquery-ui.css" />
    <script src="js/braviPopup.js" type="text/javascript"></script>
    <link href="CSS/braviStyle.css" rel="stylesheet" type="text/css" />
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
                 alert("Please enter ESIC  Number");
                 return false;
             }
             if (validatePhone(ESICText)) {
                 // alert('Valid ESIC Number');
                 return true;
             }
             else {
                 alert('Invalid ESIC  Number');
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
                oDoc.write("</head><body style='width:10%; height:10%' onload='this.focus(); this.print();'>");
                oDoc.write(oContent + "</body></html>");
                oDoc.close();

            }
            catch (e) {
                self.print();
            }
        }
        function printPageContent() {
            var DocumentContainer = document.getElementById('Label3');
            var WindowObject = window.open('', "PrintWindow", "width=5,height=5,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
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

    <style type="text/css">
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
        .style8
        {
            width: 134px;
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
        .style17
        {
            width: 602px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
   <table style="width:75%; background-image: url(images/crt-rt-background.jpg); background-repeat:no-repeat;" align="center">

   <tr>

        <%-- <td class="style1">
        
         </td>--%>
                        <td class="style17">
                            <table align="left" style="margin-left:3px; padding: 1px 4px; width: 869px;">
                                <tr>
                                <td align="right" class="style8">
                                 &nbsp;
                                 <asp:Image runat="server" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;"  ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1"/>
                                 <%--<img src="images/esic.png" alt="ESIC"  
                  
                                        style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left; width: 158px;"/>--%></td>
                                    <td align="right" class="style9" valign="bottom">
                                        <%-- <h3>User :</h3>--%>
                                        <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/User.png" />
                                    </td>
                                    <td align="left" class="style7" valign="bottom">
                                        <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td class="style12">&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td align="right" class="style10" valign="bottom">
                                        <%--<h3>Terminal :</h3>--%>
                                        <asp:Image ID="Image2" runat="server" 
                                            ImageUrl="~/images/Terminal.png"  />
                                    </td>
                                    <td align="left" class="style14" valign="bottom">
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="right" class="style3" valign="bottom">
                                        <asp:Label ID="Label4" runat="server" Text="Label" style="text-align: left"></asp:Label>
                                    </td>
                                    <td align="left" class="style13" valign="bottom">
                                        <div id="txt"> </div>
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
                        <asp:Image ID="Image4"  runat="server" alt="Qosft" style="margin-right:2px; margin-top:3px; float:right;" ImageUrl="~/Admin/ImageHandler.ashx?imgID=2"/>
                                        <%--<img src="images/qsoftTmBig.png" alt="Qosft" 
                                            style="margin-right:2px; margin-top:3px;"/>--%>
                                    </td>
                    </tr>
                    <tr>
                    <td class="style17">
                    
                            <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" 
                                ForeColor="White">Welcome to Customer Request Terminal</asp:Label>
                    </td>
                    <td>
                    
                    </td>
                    </tr>
                    <tr>
                    <td colspan="2">
                               <asp:Label ID="lbl_esicno" runat="server" Font-Bold="True" Font-Size="Large">
                            ESIC No</asp:Label>&nbsp; 
                   
                            
                            <asp:TextBox ID="txt_esicno" runat="server" MaxLength="20" 
                                    Width="200px"></asp:TextBox>
                              &nbsp;  <asp:Button ID="btn_search" runat="server" Text="Search" 
                                    onclick="btn_search_Click" />
                                   
                            
                        </td>
                    
                    </tr>
                    <tr>
                    
                    <td class="style17">
                                    Card Holder Name
                                </td>
                                <td></td>
                                <td>
                                 <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                            <ContentTemplate>
                                    <asp:TextBox ID="txt_cusfname" runat="server" Width="150px"></asp:TextBox>
                                
                                    </ContentTemplate></asp:UpdatePanel>
                                </td>

                    </tr>
                    <tr>
                     <td class="style17">
                                    Patient Name
                                </td>
                                <td></td>
                                <td>
                        
                                    
                                    
                                    <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="156px">
                                    </asp:DropDownList>
                        
                                    
                                    
                                </td>
                            
                    </tr>

                     <tr>
                     <td >
                                    Department Name
                                </td>
                                <td></td>
                                <td>
                                    
                                    <asp:DropDownList ID="DropDownList2" runat="server" Height="16px" Width="152px">
                                    </asp:DropDownList>
                                    
                                </td>
                            
                    </tr>
                     <tr>
                     <td >
                                    Appointment Time
                                </td>
                                <td></td>
                                <td>
                                    
                                    
                                </td>
                            
                    </tr>
                    <tr>
                   <td>
                       <asp:Button ID="Button1" runat="server" Text="Button" />
                   </td>
                    </tr>


   </table>
    </form>
</body>
</html>
