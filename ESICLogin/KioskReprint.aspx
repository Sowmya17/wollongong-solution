<%@ Page Language="C#" AutoEventWireup="true" Inherits="KioskDetails" CodeFile="KioskReprint.aspx.cs" %>

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
        .style3
        {
            width: 655px;
        }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <table style="margin-top: 100px; margin-left: 20px;">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
        <br />
        <br />
        <br />
        <br />
        <asp:TextBox ID="txt_esicno" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="txt_cusfname" runat="server" Visible="False"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:TextBox ID="txt_cuslname" runat="server" Visible="False"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <tr>
            <td align="center">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label6" runat="server" Text="" Font-Size="28pt" Font-Strikeout="False"
                    ForeColor="DarkSlateGray" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Timer ID="Timer1" runat="server" ontick="Timer1_Tick">
        </asp:Timer>
        <table class="style1" style="margin-top: 260px;">
            <table style="margin-top: -10px;">
                <tr>
                    <td align="center">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/home.png" OnClick="ImageButton1_Click"
                            Width="250px" Height="65px" ImageAlign="Top" Visible="True" />
                    </td>
                    <td class="style3">
                    </td>
                    <td class="style2">
                        <%--<asp:ImageButton 
                        ID="ImageButton2" runat="server" ImageUrl="~/images/reprint.png" Width="350px" 
                        Height="65px" onclick="ImageButton2_Click" style="margin-left: 5px" />--%>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>
