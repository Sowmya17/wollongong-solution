<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kiosknoApp.aspx.cs" Inherits="kiosknoApp" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>KIOSK - Queue Management System</title>
    
  
     <style type="text/css">
         .style1
         {
             height: 100px;
             width: 3940px;
         }
         .style2
         {
             width: 208px;
         }
         .style4
         {
            width:500px;
             height: 100px;
         }
         .style5
         {
             width: 3940px;
         }
     </style> 
     <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />

     
     
    <link href="CSS/jquery-ui-key.css" rel="stylesheet" />
<script type="text/javascript" src="js/jquerykey.min.js"></script>
<script type="text/javascript" src="js/jquerykey-ui.min.js"></script>
<link href="CSS/keyboard.css" rel="stylesheet" />
<script type="text/javascript" src="js/jquery.keyboard.js"></script>
    <script src="js/jquery.keyboard.extension-typing.js" type="text/javascript"></script>


<script type="text/javascript">
    $(document).ready(function () {
        $('#TextBox1').keyboard({
            autoAccept: true
        })
     .addTyping();
    });
</script>


</head>
<body> 
    <form id="form1" runat="server">
    <table style=" width: 100%">
    <tr style="width: 100%">
    <td colspan="2" class="ui-accordion" >
    <asp:Image ID="Image2" runat="server" alt="Qosft" Style="margin-right: 2px; margin-top: 3px;
                                float: left;" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1" />
    <asp:Image ID="Image1"  runat="server" alt="Qosft" style="margin-right:2px; margin-top:3px; float:right;" ImageUrl="~/Admin/ImageHandler.ashx?imgID=2"/>

     </td>
    </tr>
    <tr style="background-color:#0379B5; width: 100%">
    <td style= "background-color:#0379B5;  width:125%" colspan="2" class="ui-accordion" >
    <h1 style="color:White; font-size:35pt; width: 100%; font-family: 'Times New Roman', Times, serif; text-align: center;">Welcome to the 
        Student Administrative Services</h1>
                                         </td>
                                        <%--<td style="background-color:#0379B5;">--%>
                                            <%--<asp:Image ID="Image4" runat="server" alt="Qosft" Style="margin-right: 2px; margin-top: 3px;
                                float: right;" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1" />--%>                                        <%--<asp:Image runat="server" alt="ESIC" 
                                                style="margin-left:1px; margin-top:4px; width:100%; height: 135px; text-align: center; float: left;"  
                                                ID="Image1" ImageUrl="~/images/woll.jpg"/>--%>
                                       
       <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:Label ID="Label1" runat="server" Text="Welcome TO Wollongong Hospital(ISLHD) NSW2500 " Font-Size="XX-Large"></asp:Label>--%>
       <%--</td>--%>
       </tr>
       </table>
       <table style="margin-top:100px; margin-left:150px; height: 407px;">
            <tr>
            <td>
            
                <input id="Hidden1" type="hidden" runat="server" />
                <input id="Hidden2" type="hidden" runat="server" />
                <input id="Hidden3" type="hidden" runat="server" />
                <input id="Hidden4" type="hidden" runat="server" />
                <input id="Hidden5" type="hidden" runat="server"/>
                <input id="Hidden6" type="hidden" runat="server" />
                <input id="Hidden7" type="hidden" runat="server"/>
                <input id="Hidden8" type="hidden" runat="server" />
            </td>
            <td>
                &nbsp;</td>
                <td align="center" class="style5" >                      
                <asp:Label ID="Label3" runat="server" Text="Sorry No Appointment Scheduled  " Font-Bold="True" 
                    Font-Size="22pt"></asp:Label>
                </td>
               <td class="style2" align="left">
                   &nbsp;</td>
            </tr>
            <tr>
            <td >
                &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style5" >                      
                       
                                    <asp:Label ID="Label5" runat="server" 
                                        Text="Please press next and register your Mobile Number to serve you better" 
                                        Font-Bold="True" Font-Size="22pt"></asp:Label>
                </td>
               <td class="style4" valign="middle">
                       
                 
                       
                
               </td>
            </tr>
            <tr>
            <td>
                &nbsp;</td>
            <td>
            </td>
                <td class="style1">                      
                        
                
               </td>
               <td class="style2">
               <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/next.png" 
                       OnClick="ImageButton2_Click" Width="150px" Height="60px" 
                       ImageAlign="Bottom" />
               </td>
            </tr>
       </table>
    </form>
</body>
</html>

