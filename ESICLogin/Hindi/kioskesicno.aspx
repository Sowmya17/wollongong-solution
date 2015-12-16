<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kioskesicno.aspx.cs" Inherits="kioskesicno" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="../CSS/jquery-ui.css" />
    <script src="../js/braviPopup.js" type="text/javascript"></script>
    <link href="../CSS/braviStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="../css/style.css" />
    <title>KIOSK - Queue Management System</title>
    <script type="text/javascript" language="javascript">
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
        $(document).ready(function(){
        $('#ImageButton4').click(function(){
        location.reload();
        })
        })
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
   
</head>
<body onload="startTime()" style="background-color:#B2D9EA;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
     <table style="width:100%; background-color:#B2D9EA;" align="center">
                <tr>
                        <td style="background-color:#7DD0D3;" align="left" class="style1" colspan="2">
                               &nbsp;   <img alt="" src="../images/hindi/1.png" height="45" width="450" />
                        </td>
                     <%--    <td style="background-color:#0379B5;" align="right">--%>
                            <%-- <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink>--%>
                   <%--     </td>--%>
                    </tr>
                  
                    <tr>
                        <td colspan ="2">
                            <table align="right">
                                <tr>
                                    <td>
                                    <asp:Image runat="server" alt="ESIC" style="margin-left:1px; margin-top:4px; height: 116px; text-align: center; float: left;"  ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1"/>
                                        <%--<img alt="" src="../images/esic.png" height="150" width="150" />--%>
                                    </td>
                                </tr>
                              <%--  <tr>
                                    <td align="right">
                                      
                                        <asp:Image ID="Image1" runat="server"  ImageUrl="~/images/User.png" />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td align="right">
                            
                                        <asp:Image ID="Image2" runat="server" 
                                            ImageUrl="~/images/Terminal.png"  />
                                    </td>
                                    <td align="left">
                                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="right" style="width:40%;">
                                        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                    </td>
                                    <td align="left">
                                      
                                        <div id="txt"></div>
                                    </td>
                                    <td>
                                        <p>&nbsp;</p>
                                    </td>
                                    <td style="width:10%;">
                                        <p>&nbsp;</p>
                                    </td>
                                    <td align="right">
                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Desktop.png" />
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>--%>
                              
                            </table>
                        </td>
                    </tr>
                    <tr>
                        
                        <td style="padding-left:590px;">
                               <%-- <h1>Please Enter ESIC Number</h1>--%>
                               <img alt="" src="../images/hindi/peh.png" height="80" width="450" />
                         </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                    </tr>
                    
                   <tr>
                        <td colspan="2" align="center">
                            <table width="100%" align="center">
                                   <tr>
                    
                   <td align="center" style="width:40%;">
                            <img style="border-color:Silver; border-style:solid; border-width:thick; width:80%;" alt="" src="../images/swipe_card.jpg" />
                    </td>
                    <td align="left" style="width:100%;">
                           <div id="container">
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
	<textarea id="write" runat="server" rows="1"></textarea>
    </ContentTemplate></asp:UpdatePanel>
	<ul id="keyboard">
<!--		<li class="symbol"><span class="off">`</span><span class="on">~</span></li>
-->		<li class="symbol"><span class="off">1</span><span class="on">!</span></li>
		<li class="symbol"><span class="off">2</span><span class="on">@</span></li>
		<li class="symbol"><span class="off">3</span><span class="on">#</span></li>
		<li class="symbol"><span class="off">4</span><span class="on">$</span></li>
		<li class="symbol"><span class="off">5</span><span class="on">%</span></li>
		<li class="symbol"><span class="off">6</span><span class="on">^</span></li>
		<li class="symbol"><span class="off">7</span><span class="on">&amp;</span></li>
		<li class="symbol"><span class="off">8</span><span class="on">*</span></li>
		<li class="symbol"><span class="off">9</span><span class="on">(</span></li>
		<li class="symbol"><span class="off">0</span><span class="on">)</span></li>
		<!--<li class="symbol"><span class="off">-</span><span class="on">_</span></li>
		<li class="symbol"><span class="off">=</span><span class="on">+</span></li>-->
		
		<!--<li class="tab">tab</li>-->
		<%--<li class="letter">Q</li>
		<li class="letter">W</li>
		<li class="letter">E</li>
		<li class="letter">R</li>
		<li class="letter">T</li>
		<li class="letter">Y</li>
		<li class="letter">U</li>
		<li class="letter">I</li>
		<li class="letter">O</li>
		<li class="letter">P</li>--%>
		<!--<li class="symbol"><span class="off">[</span><span class="on">{</span></li>
		<li class="symbol"><span class="off">]</span><span class="on">}</span></li>
		<li class="symbol lastitem"><span class="off">\</span><span class="on">|</span></li>-->
		
		<%--<li class="letter">A</li>
		<li class="letter">S</li>
		<li class="letter">D</li>
		<li class="letter">F</li>
		<li class="letter">G</li>
		<li class="letter">H</li>
		<li class="letter">J</li>
		<li class="letter">K</li>
		<li class="letter">L</li>--%>
		<!--<li class="symbol"><span class="off">;</span><span class="on">:</span></li>
		<li class="symbol"><span class="off">'</span><span class="on">&quot;</span></li>
		<li class="return lastitem">return</li>
		<li class="left-shift">shift</li>-->
		<%--<li class="letter">Z</li>
		<li class="letter">X</li>
		<li class="letter">C</li>
		<li class="letter">V</li>
		<li class="letter">B</li>
		<li class="letter">N</li>
		<li class="letter">M</li>--%>
  
        <li class="delete lastitem">    <img src="../images/hindi/h10.png" alt="bak" style="height: 84px; width: 212px" /></li>
        
       <%-- <li class="capslock">caps lock</li>--%>
		<!--<li class="symbol"><span class="off">,</span><span class="on">&lt;</span></li>
		<li class="symbol"><span class="off">.</span><span class="on">&gt;</span></li>
		<li class="symbol"><span class="off">/</span><span class="on">?</span></li>
		<li class="right-shift lastitem">shift</li>
		<li class="space lastitem">&nbsp;</li>-->

	</ul>
     <div style=" margin-top:0px; margin-left:240px;">
       <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
       <%--     <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/back2.png" onclick="ImageButton2_Click" /> 
     &nbsp;&nbsp;&nbsp;&nbsp;--%>
           <asp:ImageButton ID="ImageButton4" CssClass="clear" runat="server" ImageUrl="~/images/hindi/h11.png" style="height: 84px; width: 212px"/>
           </ContentTemplate></asp:UpdatePanel>
       </div>
       
</div>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
<script type="text/javascript" src="../js/keyboard.js"></script>
                    </td>
                   </tr>
                            </table>
                        </td>
                   </tr>
                  
          <tr>
            <td colspan="2" align="center">
              <p></p>
            </td>
           
        </tr>
                   <tr>
                    <td align="right">
                        <table>
                                  <tr>
                            <td>  <asp:ImageButton ID="ImageButton2" runat="server" 
                                    ImageUrl="~/images/hindi/Hhome.png" onclick="ImageButton2_Click"/></td>
                            <td style="width:73%;">  <asp:TextBox ID="CardReader" runat="server" AutoPostBack="true"
                                    OnTextChanged="CardReader_OTC" BackColor="#B2D9EA" 
                                    BorderStyle="None" ForeColor="#B2D9EA"></asp:TextBox></td>
                    <td   align="right">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/hindi/hnext.png" OnClick="Button1_Click" />
                    </td>
                  
                   </tr>
                        </table>
                    </td>
                      <td style="width:5%;"></td>
                   </tr>
                  
                   <tr>
                    <td colspan="2">
                    </td>
                   </tr>
                  
                   <tr>
            <td colspan="2" align="center">
              
            </td>
           
        </tr>
                </table>
    </form>
</body>
</html>