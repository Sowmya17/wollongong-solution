<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printer.aspx.cs" Inherits="printer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="refresh" content="0;url=crtesic.aspx"/>
    <title></title>
    <script type="text/javascript">
        function ClickHereToPrint() {
            try {
                var oIframe = document.getElementById('ifrmPrint');
                var oContent = document.getElementById('divToPrint').innerHTML;
                var oDoc = (oIframe.contentWindow || oIframe.contentDocument);
                if (oDoc.document) oDoc = oDoc.document;
                oDoc.write("<html><head>");
                oDoc.write("</head><body style='width:32%;' onload='this.focus(); this.print();'>");
                oDoc.write(oContent + "</body></html>");
                oDoc.close();

            }
            catch (e) {
                self.print();
            }
        }
        function printPageContent() {
            var DocumentContainer = document.getElementById('divToPrint');
            var WindowObject = window.open('', "PrintWindow", "width=5,height=5,top=200,left=200,toolbars=no,scrollbars=no,status=no,resizable=no");
            WindowObject.document.writeln(DocumentContainer.innerHTML);
            WindowObject.document.close();
            WindowObject.focus();
            WindowObject.print();
            WindowObject.close();
        }
</script>
  
</head>
<body onload="printPageContent();">
    <form id="form1" runat="server">
   
        <iframe id='ifrmPrint' style="width:0px; height:0px;"></iframe>
	    <div id="divToPrint">
		    
            
                    <table align="left">
                            <tr>
                                <td colspan="3" align="center">
                                    <h1>ESIC Hospital</h1>
                                </td>
                                
                            </tr>
                            <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td>
                                   <h2><asp:Label ID="lbl_esicno" runat="server" Text="ESIC No"></asp:Label></h2>
                                </td>
                                <td valign="middle" align="center"><h2>:</h2></td>
                                <td>
                                  <h2><asp:Label ID="lbl_esicno1" runat="server" Text="Label"></asp:Label></h2>
                                </td>
                            </tr>
                               <tr><td>&nbsp;</td></tr>
                       
                            <tr>
                                 <td>
                                   <h2><asp:Label ID="lbl_datetime" runat="server" Text="Date & Time"></asp:Label></h2>
                                </td>
                                <td valign="middle" align="center"><h2>:</h2></td>
                                <td>
                                  <h2><asp:Label ID="lbl_datetime1" runat="server" Text="Label"></asp:Label></h2>
                                </td>
                            </tr>
                             <tr><td>&nbsp;</td></tr>
                            <tr>
                                <td>
                                    <h2><asp:Label ID="lbl_queueno" runat="server" Text="Queue No"></asp:Label> </h2>
                                </td>
                                <td valign="middle" align="center"><h2>:</h2></td>
                                <td>
                                  <h2><asp:Label ID="lbl_queueno1" runat="server" Text="Label"></asp:Label></h2>
                                </td>
                            </tr>
                              <tr><td>&nbsp;</td></tr>
            
                           </table>
	    </div>
   
    </form>
</body>
</html>
