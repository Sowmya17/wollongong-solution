<%@ Page Language="C#"  AutoEventWireup="true" CodeFile="kioskcard.aspx.cs" Inherits="kiosklang" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
     <title>KIOSK - Queue Management System</title>
     <script type="text/javascript">
         function functionx(evt) {
             if (evt.charCode > 31 && (evt.charCode < 48 || evt.charCode > 57)) {
                 alert("Allow Only Numbers");
                 return false;
             }
         }
    </script>
    
  
     <style type="text/css">
         .style2
         {
             width: 208px;
             height: 120px;
         }
         .style3
         {
             margin-top: 49px;
         }
         .style5
         {
             width: 516px;
             height: 120px;
         }
         .style6
         {
             height: 120px;
         }
         .style7
         {
             height: 120px;
             width: 11px;
         }
         .style8
         {
             height: 100px;
         }
         </style> 
     <link href="CSS/StyleSheet.css" rel="stylesheet" type="text/css" />

      <link rel="stylesheet" href="css/jsKeyboard2.css" type="text/css" media="screen"/>
     <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
        
        <script type="text/javascript" src="js/jsKeyboard2.js"></script>
        <script type="text/javascript" src="js/main2.js"></script>


        
</head>
<body style="overflow:hidden;"> 
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <table style="margin-top:70px; margin-left:315px; " 
        align="center">
                <tr>
                <td>
                <asp:Label ID="Label5" runat="server" Text="Swipe your Medicare Card" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="35pt" ></asp:Label>
                
                </td>
                </tr>
                </table>
                <table style=" margin-left:150px; margin-top:50px; ">
                <tr>
                <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/Swipe-Medicard.gif" 
                        Height="298px" Width="416px" />
                </td>
                <td>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/md5.png" 
                        Height="298px" Width="416px" />
                </td>
                </tr>

                
                </table>
                <table>
                <tr><td class="style8">
                <asp:Label ID="Label7" runat="server" Text="If Card swipe doesn’t work please enter only the first 9 digits of your Medicare numbers manually." 
           Font-Bold="True" ForeColor="DarkSlateGray"
           Font-Size="26pt" Width="" Visible="True"> </asp:Label>
                
                </td></tr></table>
       <table style="margin-top:25px; margin-left:150px;">
       
            <tr>
            <td class="style5">
            
                <input id="Hidden1" type="hidden" runat="server" />
                <input id="Hidden2" type="hidden" runat="server" />
                <input id="Hidden3" type="hidden" runat="server" />
                <input id="Hidden4" type="hidden" runat="server" />
                <input id="Hidden5" type="hidden" runat="server"/>
                <input id="Hidden6" type="hidden" runat="server" />
                <input id="Hidden7" type="hidden" runat="server"/>
                <input id="Hidden8" type="hidden" runat="server" />
                <asp:Label ID="Label2" runat="server" Text="Medicare Card Number  " Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="30pt"></asp:Label>
            </td>
            <td class="style7">
            <asp:Label ID="Label4" runat="server" Text=":" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="30pt" ></asp:Label>
            </td>
                <td align="center" class="style6"> 
                
                 <asp:UpdatePanel ID="UpdatePanel6" runat="server">
        <ContentTemplate>
       <asp:TextBox ID="TextBox1" runat="server" Height="40" Width="400" Font-Size="20pt" 
                onkeydown="if (event.keyCode == 13) document.getElementById('ImageButton2').click()" 
                onclick="jsKeyboard.changeToNumber();" onkeypress="return functionx(event)"  
                ontextchanged="TextBox1_TextChanged"></asp:TextBox>
           </ContentTemplate>
        </asp:UpdatePanel>                                       
                </td>
               <td class="style2" align="left">
                   </td>
            </tr>
        
            
       </table>
       <table  style="margin-top:10px; margin-left:35px;">
       <tr>
       <td>
          <asp:Label ID="Label1" runat="server" Text="Select the patient  " 
               Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="26pt" Visible="False"></asp:Label>
            </td>
            <td>
            <asp:Label ID="Label3" runat="server" Text=":" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="26pt" Visible="False" ></asp:Label>
            </td>
       <td style="height:50px;">
       <asp:RadioButtonList ID="RadioButtonList1" runat="server" Font-Size="30pt" 
               ForeColor="DarkSlateGray" Visible="False">
                    </asp:RadioButtonList>
       </td>
       </tr>
       </table>

       <table style="margin-left:50px; margin-top:-10px;">
       <tr>
       <td  style="height:100px;">
        <div id="virtualKeyboard"></div>
       </td>
       </tr>
       </table>
       <table  style="margin-left:0px; " class="style3">

       <tr>
            <td>
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/home.png" 
                    OnClick="ImageButton3_Click" Width="250px" Height="65px" 
                    ImageAlign="Top" />
            </td>
            <td style="width:760px;">
            </td>
                <td>                      
                        
                
               </td>
               <td >
               <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/next.png" 
                       OnClick="ImageButton2_Click" Width="250px" Height="65px" 
                       ImageAlign="Top" />
               </td>
            </tr>
       </table>
    </form>
</body>
</html>

