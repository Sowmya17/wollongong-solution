<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Newkioskhome.aspx.cs" Inherits="Newkioskhome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

   
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {

    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/StyleSheet3.css"/>
</head>
<body>
    <form id="form1" runat="server">
   


    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
     <br />
     <br/>
     
   
       <div><asp:Label ID="Label3" runat="server" Text="Please select your purpose of visit" Font-Bold="True" ForeColor="DarkSlateGray"
                    Font-Size="30pt"  style="margin-left:330px;"></asp:Label>
           
    </div>
        
              
                <div style="margin-top:0px;">


                <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/images/fr_1.png" onclick="Button1_Click" 
                   style="margin-left:270px; margin-top:10px;"  />
                        
                          <%--<asp:Button ID="Button1" runat="server" Text="Fracture Clinic" 
                              style="margin-left:270px; margin-top:10px; background-color:" Height="40px" 
                        Width="300px" font-size="20pt" onclick="Button1_Click"/>--%>

                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            ImageUrl="~/images/MAC_1.png" onclick="Button2_Click" 
                   style="margin-left:30px; margin-top:10px; "  />

                        <%--<asp:Button ID="Button2" runat="server" Text="MAC Unit" 
                              style="margin-left:30px; margin-top:10px; background-color:" Height="40px" 
                        Width="200px" font-size="20pt" onclick="Button2_Click"/>--%>


                         <asp:ImageButton ID="ImageButton3" runat="server" 
                            ImageUrl="~/images/HITH_1.png" onclick="Button3_Click" 
                   style="margin-left:30px; margin-top:10px;"  />

                        <%--<asp:Button ID="Button3" runat="server" Text="HITH" 
                              style="margin-left:30px; margin-top:10px; background-color:" Height="40px" 
                        Width="150px" font-size="20pt" onclick="Button3_Click"/>--%>
                        </div>
         
                    
                <div style="margin-top:30px;">


                 <asp:ImageButton ID="ImageButton4" runat="server" 
                            ImageUrl="~/images/endo_11.png" onclick="Button4_Click" 
                   style="margin-left:270px; margin-top:10px;"  />

                    <%--<asp:Button ID="Button4" runat="server" Text="Endocrine Clinic" 
                        style="margin-left:270px; margin-top:10px; background-color:" Height="40px" 
                        Width="300px" font-size="20pt" onclick="Button4_Click"/>--%>

                          <asp:ImageButton ID="ImageButton5" runat="server" 
                            ImageUrl="~/images/Geriatric_1.png" onclick="Button5_Click" 
                   style="margin-left:30px; margin-top:10px;"  />

                        <%--<asp:Button ID="Button5" runat="server" Text="Geriatric Clinic" 
                        style="margin-left:30px; margin-top:10px; background-color:" Height="40px" 
                        Width="200px" font-size="20pt" onclick="Button5_Click"/>--%>

                        <asp:ImageButton ID="ImageButton6" runat="server" 
                            ImageUrl="~/images/IBD_1.png" onclick="Button6_Click" 
                   style="margin-left:30px; margin-top:10px;"  />

                       <%-- <asp:Button ID="Button6" runat="server" Text="IBD Clinic" 
                        style="margin-left:30px; margin-top:10px; background-color:" Height="40px" 
                        Width="150px" font-size="20pt" onclick="Button6_Click"/>--%>
                
                   
                </div>
                    
               
                <div style="margin-top:30px;">

                 <asp:ImageButton ID="ImageButton7" runat="server" 
                            ImageUrl="~/images/pain_1.png" onclick="Button7_Click" 
                   style="margin-left:270px; margin-top:10px;"  />

                    <%--<asp:Button ID="Button7" runat="server" Text="Pain Management Clinic" 
                        style="margin-left:270px; margin-top:10px; background-color:" Height="40px" 
                        Width="300px" font-size="20pt" onclick="Button7_Click"/>--%> 

                         <asp:ImageButton ID="ImageButton8" runat="server" 
                            ImageUrl="~/images/vascular_1.png" onclick="Button8_Click" 
                   style="margin-left:30px; margin-top:10px;"  />

                      <%--  <asp:Button ID="Button8" runat="server" Text="Vascular Clinic" 
                        style="margin-left:30px; margin-top:10px; background-color:" Height="40px" 
                        Width="200px" font-size="20pt" onclick="Button8_Click"/>--%>

                        <asp:ImageButton ID="ImageButton9" runat="server" 
                            ImageUrl="~/images/ENT_1.png" onclick="Button9_Click" 
                   style="margin-left:30px; margin-top:10px;"  />

                        <%--<asp:Button ID="Button9" runat="server" Text="ENT Clinic" 
                        style="margin-left:30px; margin-top:10px; background-color:" Height="40px" 
                        Width="150px" font-size="20pt" onclick="Button9_Click"/>--%>
                    
                </div>
                
                <div style="margin-top:30px;">


                <asp:ImageButton ID="ImageButton10" runat="server" 
                            ImageUrl="~/images/pre_1.png" onclick="Button10_Click" 
                   style="margin-left:270px; margin-top:10px;"  />

                    <%--<asp:Button ID="Button10" runat="server" Text="Pre-Admission Clinic" 
                        style="margin-left:270px; margin-top:10px; background-color:" Height="40px" 
                        Width="300px" font-size="20pt" onclick="Button10_Click"/>--%>

                        <asp:ImageButton ID="ImageButton11" runat="server" 
                            ImageUrl="~/images/plastic_1.png" onclick="Button11_Click" 
                   style="margin-left:30px; margin-top:10px;"  />

                        <%--<asp:Button ID="Button11" runat="server" Text="Plastic's Clinic" 
                        style="margin-left:30px; margin-top:10px; background-color:" Height="40px" 
                        Width="200px" font-size="20pt" onclick="Button11_Click"/>--%> 

                        <asp:ImageButton ID="ImageButton12" runat="server" 
                            ImageUrl="~/images/other_1.png" onclick="Button12_Click" 
                   style="margin-left:30px; margin-top:10px;"  />

                       <%-- <asp:Button ID="Button12" runat="server" Text="Others" 
                        style="margin-left:30px; margin-top:10px; background-color:" Height="40px" 
                        Width="150px" font-size="20pt" onclick="Button12_Click"/>--%>
                    
                
                </div>
                <br/>
                <br/>
                <br/>
                <br/>


    </form>
</body>
</html>
