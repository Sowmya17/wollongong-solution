<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Kioskrtv.aspx.cs" Inherits="Kioskrtv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/StyleSheet3.css"/>

    <style type="text/css">
        .style1
        {
            width: 984px;
            height: 307px;
            margin-left: 8px;
            margin-top: 22px;
        }
        .style2
        {
            width: 1196px;
            height: 317px;
            margin-left: 69px;
            margin-top: 247px;
        }
        .style3
        {
            width: 786px;
            height: 199px;
            margin-left: 95px;
            margin-top: 26px;
        }
        
        input:checked {
    height: 50px;
    width: 50px;
}
        
     
        .style4
        {
            margin-top: 0px;
        }
        
     
        .rd
        {}
        
     
    </style>
</head>
<body>
    <form id="form1" runat="server" class="style2">
    <div class="style1">
    
        <div class="style3">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            &nbsp;<asp:Label ID="lbl" Text="Please select the patient name."  
                runat="server" Font-Size="45pt" Font-Bold="True" ForeColor="DarkSlateGray"></asp:Label>
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButtonList  UnChecked="checked" ID="RadioButtonList1" CssClass="rd" 
                runat="server" Font-Size="50pt" 
               ForeColor="Red" Visible="False" Height="150px" Width="400px" 
                oncheckedchanged="RadioButtonList1_CheckedChanged" 
                onselectedindexchanged="RadioButtonList1_SelectedIndexChanged">
                    </asp:RadioButtonList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" Text="Press next after selection of name"  
                runat="server" Font-Size="35pt" Font-Bold="True" ForeColor="DarkSlateGray"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
    
    </div>

    <br />
     <br />

        <br />
            <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    
            <br />    

    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/home.png" 
                    OnClick="ImageButton2_Click" Width="250px" Height="65px" 
        style="margin-left:-60px; margin-top:0px;" />


     <asp:ImageButton ID="ImageButton1"  runat="server" Height="65px" ImageUrl="~/images/next.png" 
        onclick="ImageButton1_Click" Width="250px" 
        style=" margin-left:750px; font-size:25px; margin-top: 0px;" 
        CssClass="style4" />
    </form>
</body>
</html>
