<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppDetails.aspx.cs" Inherits="AppDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="CSS/RTStyleSheet.css" />

    <title></title>

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
                
        
       #btn {
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
            margin-left: 55px;
            background-color: #60707a;
            background-repeat: repeat;
            background-attachment: scroll;
        }




  #btn1 {
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
            margin-left: 1px;
            background-color: #60707a;
            background-repeat: repeat;
            background-attachment: scroll;
        }

        
       #btn2 {
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
            margin-left: 55px;
            background-color: #60707a;
            background-repeat: repeat;
            background-attachment: scroll;
        }




  #btn2 {
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
            margin-left: 1px;
            background-color: #60707a;
            background-repeat: repeat;
            background-attachment: scroll;
        }

        
       

  #btn2 {
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
            margin-left: 1px;
            background-color: #60707a;
            background-repeat: repeat;
            background-attachment: scroll;
        }

        
       

        .style16
        {
            width: 132px;
        }

        
       

  </style>



</head>
<body onload="startTime()">
    <form id="form1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table style="width: 75%;"
        align="center">
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
                        <td align="right" >
                            &nbsp;
                            <%--<asp:Image runat="server" alt="ESIC" Style="margin-left: 1px; margin-top: 4px; height: 116px;
                                text-align: center; float: left;" ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1" />--%><%--<img src="images/esic.png" alt="ESIC"  
                  
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
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <%-- <asp:Image ID="Image4" runat="server" alt="Qosft" Style="margin-right: 2px; margin-top: 3px;
                                float: right;" ImageUrl="~/Admin/ImageHandler.ashx?imgID=2" />--%><%--<img src="images/qsoftTmBig.png" alt="Qosft" 
                        
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
                <%--<asp:LinkButton ID="buttonlink" runat="server" Text="Logout" ForeColor="White" OnClick="buttonlink_Click"></asp:LinkButton>--%><%--<asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>--%>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                
                

                


                
                 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_crt" runat="server" Text="CRT" Width="142px" Font-Size="20pt"
                         Height="54px" onclick="btn_crt_Click" />


                    
                

                
                         </td>
            
            
        </tr>
   </table>

    <%--<a>Patient Details</a>--%>

    <div style="border-bottom-color: #626262; border: thin solid #626262; width: 729px; margin-left: 300px; margin-top: 0px; ">
    
    <table cellspacing="50">
    <tr>
    <td class="style16">
    
    </td>
    </tr>
        <asp:Label ID="lbl_terminaldepartmentid" runat="server" style="float: right;" 
                                Text="Terminal Department ID" Visible="False"></asp:Label>
    <tr>

    <td class="style16">
    <asp:UpdatePanel ID="UpdatePanel6" runat="server" style=" width:180px;">
        <ContentTemplate>
   <asp:Label ID="Label1" runat="server" Text="All Appointments" Font-Size="15pt" Font-Bold="true"></asp:Label>
    <asp:DropDownList ID="terminaldepartmentselection" runat="server" Height="20px" 
            Width="150px" 
            onselectedindexchanged="terminaldepartmentselection_SelectedIndexChanged"></asp:DropDownList>
            </ContentTemplate>
            </asp:UpdatePanel>
        
    </td>
    <td>
    <asp:Label ID="Label3" runat="server" Text="Appointments With Ticket" Font-Size="15pt" Font-Bold="true"></asp:Label>
    
    </td>
    <td>
    
    </td>
    <td>
    <asp:Label ID="Label6" runat="server" Text="Emr Updated Appointments" Font-Size="15pt" Font-Bold="true"></asp:Label>
    </td>
    </tr>
    <tr>

   <td class="style16">
   <asp:UpdatePanel ID="UpdatePanel4" runat="server">
   <ContentTemplate>
                    <asp:ListBox ID="lb_deptlist" runat="server" Height="400px" Width="150px" ForeColor="DarkSlateGray" Font-Size="Medium"></asp:ListBox>

   </ContentTemplate>
   
   </asp:UpdatePanel>
   </td>
             
            <td>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
               <asp:ListBox ID="lb_apttoken"  runat="server" Height="400px" Font-Bold="False"
                                                                Font-Size="Medium"
                   Width="150px" ForeColor="DarkSlateGray" onselectedindexchanged="lb_apttoken_SelectedIndexChanged"  
                                                                ></asp:ListBox>
                                                                 </ContentTemplate>
    </asp:UpdatePanel>
            </td>

           <td>
                &nbsp;<asp:Button ID="btn_emr" runat="server" Text=">>" 
                    onclick="btn_emr_Click"/><br />
                <asp:Button ID="btn_token" runat="server" Text="<<" onclick="btn_token_Click"/>

            </td>
         

            
             <td>
                 <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
      
            <asp:ListBox ID="lb_aptemr" AutoPostBack="true" runat="server" Height="399px" Font-Bold="False"
                                                                Font-Size="Medium" 
                     Width="150px" ForeColor="DarkSlateGray" 
                                                                ></asp:ListBox>
                                                                 </ContentTemplate>
    </asp:UpdatePanel>
            </td>

</tr>
</table>

    </div>
    <br />

    <table style="margin-left: 441px; height: 168px; width: 303px;">

    <tr>
            <td colspan="2" align="center">
                <h5 style="height: 37px; margin-top: 15px">
                    Client IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="000000000" ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance
                    IP : [<asp:Label ID="lbl_instanceip" runat="server" Text="000000000" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>
            </td>
        </tr>
    </table>

     <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="10000">
            </asp:Timer>
        </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
