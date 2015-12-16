<%@ page language="C#" autoeventwireup="true" inherits="KioskDetails" CodeFile="KioskDetails.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="CSS/RTStyleSheet.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">
        .style1
        {
            margin-top: 265px;
            height: 46px;
        }
        .style2
        {
            width: 390px;
        }
    </style>
</head>
<body style="overflow:hidden;">
    <form id="form1" runat="server">
    <div>
        <table style="margin-top: 100px;margin-left:20px;">
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Since your appointment was made, have any of the following details changed?"
                        Font-Size="28pt" Font-Strikeout="False" ForeColor="DarkSlateGray" 
                        Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="margin-top: 110px; margin-left: 460px;" align="center">
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="1. Surname Name"  Font-Size="28pt" 
                        ForeColor="DarkSlateGray" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="2. Address" Font-Size="28pt" 
                        ForeColor="DarkSlateGray" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="3. Telephone contact details" Font-Size="28pt"
                        ForeColor="DarkSlateGray" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="4.  GP-General Practitioner" Font-Size="28pt"
                        ForeColor="DarkSlateGray" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="5. Person to contact" 
                        Font-Size="28pt" ForeColor="DarkSlateGray" Font-Bold="True"></asp:Label>
                </td>
            </tr>

            


        </table>
        <br />
        <br />
        <br />
        <br />

        
            <tr>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label6" runat="server" Text="Please go to the reception, to change any of the above."
                        Font-Size="28pt" Font-Strikeout="False" ForeColor="DarkSlateGray" 
                        Font-Bold="True"></asp:Label>
                </td>
            </tr>

        <table class="style1" style="margin-top:260px;">
            <tr>
                <td>
                    &nbsp;</td>
                <td style="width: 720px;">
                </td>
                <td class="style2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:ImageButton 
                        ID="ImageButton1" runat="server" ImageUrl="~/images/ok.png" Width="350px" 
                        Height="65px" onclick="ImageButton1_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
