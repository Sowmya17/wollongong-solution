<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!--home page-->
    <!--sen-->
    <title>Queue Management System</title>
    <style type="text/css">
        .style1
        {
            width: 297px;
        }
        h2
        {
            color: #0379B5;
            text-align: left;
            font-size: 18pt;
            margin-left: 20px;
            font-family: Arial;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table style="padding: 1px 4px; border: 1px solid #C0C0C0; background-color: #D4F0F1;"
        align="center">
        <tr>
            <td>
                <%--<h2>Hospital&nbsp;LOGO&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Hospital&nbsp;Name</h2>--%>
                <%--<img src="images/logofinal.png" alt="ESIC"  
                    style="margin-left:20px; margin-top:50px; height: 80px; width: 499px;"/>--%>
                <asp:Image runat="server" alt="ESIC" Style="margin-left: 1px; margin-top: 4px; height: 80px;
                    text-align: center; float: left;" ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1"/>
            </td>
            <td align="right">
                <table>
                    <tr style="height:30px;">
                        <td style="height:15px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height:15px;">
                            <img src="images/qsoftAnimatedBig.gif" alt="Qosft" style="margin-right: 50px; margin-top: 10px;" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 30px;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 60%; height: 200px;">
                <h2>
                    Welcome to the Patient Queue and Wait Management System
                </h2>
                <p style="color: Maroon; text-align: justify; font-family: Arial; font-size: 9pt;
                    margin-left: 20px;">
                </p>
                <input id="Hidden1" type="hidden" runat="server" />
                <input id="Hidden2" type="hidden" runat="server" />
                <input id="Hidden3" type="hidden" runat="server" />
                <input id="Hidden4" type="hidden" runat="server" />
                <input id="Hidden5" type="hidden" runat="server" />
                <input id="Hidden6" type="hidden" runat="server" />
            </td>
            <td class="style1" align="center">
                <table style="width: 75%; background-color: #B2D9EA; border: 1px solid #C0C0C0">
                    <%--75BBD9- #DCEDF5 B2D9EA --%>
                    <tr>
                        <td colspan="2" style="background-color: #0379B5;" align="center">
                            <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White">Login</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lbl_error" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <p>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbl_username" runat="server" Text="Username  "></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txt_username" runat="server" MaxLength="15"></asp:TextBox>
                        </td>
                        <%-- <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="You must enter username!" ControlToValidate="TextBox1" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>--%>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <p>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="lbl_password" runat="server" Text="Password  "></asp:Label>
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txt_password" runat="server" TextMode="Password" MaxLength="15"></asp:TextBox>
                        </td>
                        <%-- <td align="left">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                ErrorMessage="You must enter password!" ControlToValidate="TextBox2" 
                                ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>--%>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <p style="text-align: center;">
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Counter Display" Visible="False" />
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button ID="btn_login" runat="server" Text="Log In" Height="30px" Width="75px"
                                OnClick="Button1_Click" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <p>
                    &nbsp;</p>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="height: 60px;">
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <h5>
                    &nbsp;<asp:Label ID="lbl_clientip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>&nbsp;
                    <br />
                    <br />
                    Copyright &copy; ATT Systems Group 2015
                </h5>
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
