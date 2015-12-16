<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MACPrint.aspx.cs" Inherits="reynolds" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            margin-top: 0px;
        }
        .style2
        {
            text-align: left;
        }
        #form1
        {
            height: 410px;
            width: 765px;
        }
        .style4
        {}
        </style>
</head>
<%--Code function for print in XMLns-ashok sen-29-jun-2013--%>
<%--<body onload="closeWindow();SenWindow();" style="">--%>
<body onload="SenWindow();closeWindow();" style="">
                 
  <script language="javascript" type="text/javascript">
      //      var redirectTimerId = 0;
      function closeWindow() {
          window.opener = top;
          redirectTimerId = window.setTimeout('redirect()', );
          window.close();
      }
      function SenWindow() {
          window.print();
      }

      //      function stopRedirect() {
      //          window.clearTimeout(redirectTimerId);
      //      }

      //      function redirect() {
      //          window.location = 'crtesic.aspx';
      //      }
 </script>

    <form id="form1" runat="server">
    <br />

    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image1" runat="server" CssClass="style1" 
        ImageUrl="~/Admin/ImageHandler.ashx?imgID=3" Width="243px" 
        Height="130px" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    &nbsp;<asp:Label ID="Label10" runat="server" CssClass="style4" Height="33px" 
        Text="Welcome to the Ambulatory Care Centre" Width="627px" Font-Size="20pt"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%--<asp:Label 
        ID="Label11" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <asp:Label ID="ESIC_No" runat="server" CssClass="style2" Height="26px" 
        Text="ESIC No." Width="167px" Font-Bold="True" Font-Size="X-Large"></asp:Label>--%>&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
    <asp:Label ID="Label5" runat="server" CssClass="style2" Height="23px" 
        Text="Date &amp; Time" Width="166px" Font-Bold="False" Font-Size="X-Large"></asp:Label>
    <asp:Label ID="Label4" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <asp:Label ID="lbl_datetime1" runat="server" 
        CssClass="style2" Height="28px" Width="458px" Font-Bold="False" 
        Font-Size="X-Large"></asp:Label>
    <br />
    <%--<asp:Label ID="Label6" runat="server" CssClass="style2" Height="26px" Width="225px" Font-Bold="true" Font-Size="X-Large" Text="Floor Number"></asp:Label>--%>&nbsp; &nbsp; &nbsp;&nbsp;
    <%--<asp:Label ID="Label8" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>--%>        <%--<asp:Label ID="Floor_Details" runat="server" 
        CssClass="style2" Height="28px" 
        Text="Ground Floor" Width="458px" Font-Bold="True" Font-Size="X-Large"></asp:Label>--%>
    <br />
    <asp:Label ID="Label7" runat="server" CssClass="style2" Height="26px" 
        Text="Please proceed to the MAC Unit reception" Width="542px" Font-Bold="True" 
        Font-Size="14pt"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;<%--<asp:Label ID="Label13" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>--%>    <%--<asp:Label ID="Waitng" runat="server" 
        CssClass="style2" Height="28px" 
        Text="Waiting" Width="458px" Font-Bold="True" Font-Size="X-Large"></asp:Label>--%>
    <br />
    <%--<asp:Label ID="Label9" runat="server" CssClass="style2" Height="26px" 
        Text="Average Waiting Status" Width="244px" Font-Bold="True" 
        Font-Size="X-Large"></asp:Label>--%>&nbsp;&nbsp;<%--<asp:Label ID="Label14" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>--%>    <%--<asp:Label ID="Avg" runat="server" CssClass="style2" Height="28px" 
        Text="Avg waiting " Width="459px" Font-Bold="True" Font-Size="X-Large"></asp:Label>--%>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <%-- <asp:Label ID="Label3" runat="server" CssClass="style3" Height="50px" 

        Text="DE12-234" Width="280px" Font-Size="XX-Large"></asp:Label>--%>

    <br />    <br /><br />  <br />
    
    <br /><br /><br /><br />
         
&nbsp;</form>
</body>

</html>
