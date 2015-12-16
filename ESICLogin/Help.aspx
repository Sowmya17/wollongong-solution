<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Help.aspx.cs" Inherits="AddMember" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .grdaddmember_SkinName.form1
        {
            left: 150px !important;
            top: 200px !important;
        }
        </style>
    <link rel="stylesheet" type="text/css" href="CSS/StyleSheet.css" />
   
</head>
<body style="background-color:Gray;">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   
    <div style="font-family: 'Calibri Light'">
        <asp:Label ID="lbl_msg" runat="server" ForeColor="Green" Visible="False"></asp:Label>
        <br />
        
        <br />
        &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Font-Underline="True" ForeColor="#FF3300" 
            Text="Call &quot;Q&quot;"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ---------&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This Button is used for Calling a 
        Particular Queue<br />
        <br />
        &nbsp;&nbsp; <asp:Label ID="Label2" runat="server" Font-Underline="True" ForeColor="#FF3300" 
            Text="Re-Call &quot;Q&quot;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ---------&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; This Button is used for Re-Calling a Called 
        Queue<br />
        <br />
&nbsp; &nbsp; <asp:Label ID="Label3" runat="server" Font-Underline="True" ForeColor="#FF3300" 
            Text="End  &quot;Q&quot;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ----------&gt;&nbsp;&nbsp;&nbsp; This Button is used 
        for Ending&nbsp; a Called Queue<br />
        <br />
&nbsp;&nbsp;<asp:Label ID="Label4" runat="server" Font-Underline="True" ForeColor="#FF3300" 
            Text="Missed &quot;Q&quot;"></asp:Label> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ----------&gt;&nbsp;&nbsp;&nbsp;&nbsp; This button is used for Putting a Queue into Missed 
        &quot;Q&quot;<br />
        <br />
&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" Font-Underline="True" ForeColor="#FF3300" 
            Text="Calling Missed &quot;Q&quot;"></asp:Label> &nbsp;&nbsp;&nbsp; ----------&gt;&nbsp;&nbsp;&nbsp; This button is used for Calling a Missed &quot;Q&quot;<br />
        <br />
&nbsp; <asp:Label ID="Label6" runat="server" Font-Underline="True" ForeColor="#FF3300" 
            Text="Next &quot;Q&quot;"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; -----------&gt;&nbsp;&nbsp;&nbsp; This button is 
        used for Calling &quot;Q&quot;
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    </form>
</body>
</html>
