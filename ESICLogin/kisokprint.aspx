<%@ Page Language="C#" AutoEventWireup="true" CodeFile="kisokprint.aspx.cs" Inherits="Maya" %>

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
        .style3
        {
            font-family: IDAutomationHC39M;
            font-size: x-large;
        }
        #form1
        {
            height: 410px;
            width: 765px;
        }
        .style5
        {
            font-weight: 700;
            text-align: center;
            font-family: serif;
            font-size: larger;
        }
        .style6
        {
            font-family: serif;
            font-weight: 700;
        }
    </style>
</head>
<%--Code function for print in XMLns-ashok sen-12-jul-2013--%>

<body onload="SenWindow();" onunload="CloseWindow();" style="">
                 
  <script language="javascript" type="text/javascript">
      var redirectTimerId = 0;

//      function CloseWindow() {
//            window.close();
//        }

      function closeWindow() {
          window.opener = top;
          redirectTimerId = window.setTimeout('redirect()', 1000);
          window.close();
      }
      function SenWindow() {
          window.print();
//          window.close();
      }

      function stopRedirect() {
          window.clearTimeout(redirectTimerId);
      }

      function redirect() {
          window.location = 'kiosklang.aspx';
      }
 </script>

    <form id="form1" runat="server">
    <asp:Label ID="Label10" runat="server" CssClass="style5" Height="33px" 
        Text="ESIC HOSPITAL GULBARGA" Width="564px" Font-Size="XX-Large"></asp:Label>
    <br />

&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    <asp:Image ID="Image1" runat="server" CssClass="style1" 
        ImageUrl="~/Admin/ImageHandler.ashx?imgID=3" Width="111px" Height="104px" />
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
    <asp:Label ID="Q_Number" runat="server" CssClass="style6" Font-Size="29pt" 
        Height="30px" Text="DE12-234" Width="235px"></asp:Label>
    &nbsp;&nbsp;<br />
    <br />
    <asp:Label ID="Label1" runat="server" CssClass="style2" Height="26px" 
        Text="ESIC No" Width="123px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label 
        ID="Label11" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <asp:Label ID="ESIC_No" runat="server" CssClass="style2" Height="26px" 
        Text="ESIC No." Width="167px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;<br />
    <asp:Label ID="Label5" runat="server" CssClass="style2" Height="23px" 
        Text="Date &amp; Time" Width="166px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label12" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <asp:Label ID="Date_Time" runat="server" 
        CssClass="style2" Height="26px" 
        Text="Date and Time" Width="457px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <br />

     <asp:Label ID="Label2" runat="server" CssClass="style2" Height="26px" Width="225px" Font-Bold="true" Font-Size="X-Large" Text="Department Name"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label4" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <asp:Label ID="Dept_Name" runat="server" 
        CssClass="style2" Height="28px" 
        Text="Dept Name" Width="458px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
         <asp:Label ID="Label6" runat="server" CssClass="style2" Height="26px" Width="225px" Font-Bold="true" Font-Size="X-Large" Text="Floor Number"></asp:Label>
    &nbsp; &nbsp; &nbsp;&nbsp;
    <asp:Label ID="Label8" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <asp:Label ID="Floor_Details" runat="server" 
        CssClass="style2" Height="28px" 
        Text="Ground Floor" Width="458px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    
    <br />
    <asp:Label ID="Label7" runat="server" CssClass="style2" Height="26px" 
        Text="Waiting Queue Status" Width="225px" Font-Bold="True" 
        Font-Size="X-Large"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;<asp:Label ID="Label13" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <asp:Label ID="Waitng" runat="server" 
        CssClass="style2" Height="28px" 
        Text="Waiting" Width="458px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <br />
    <asp:Label ID="Label9" runat="server" CssClass="style2" Height="26px" 
        Text="Average Waiting Status" Width="244px" Font-Bold="True" 
        Font-Size="X-Large"></asp:Label>
    &nbsp;&nbsp;<asp:Label ID="Label14" runat="server" CssClass="style2" Height="26px" 
        Text=":" Width="16px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <asp:Label ID="Avg" runat="server" CssClass="style2" Height="28px" 
        Text="Avg waiting " Width="459px" Font-Bold="True" Font-Size="X-Large"></asp:Label>
    <br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
    <asp:Label ID="Label3" runat="server" CssClass="style3" Height="50px" 

        Text="DE12-234" Width="280px" Font-Size="XX-Large"></asp:Label>

    <br />    <br /><br />  <br />
    
    <br /><br /><br /><br />
         
&nbsp;</form>
</body>

</html>