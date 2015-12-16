<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Rtnew.aspx.cs" Inherits="Rtnew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="CSS/RTStyleSheet.css" />
        <style type="text/css">
              .cldQ
        {
            border: thin solid #000000;
            padding: 10px;
            margin: 05px;
            width: 290px;
            -moz-border-radius: 15px;
            -webkit-border-radius: 15px;
            border-radius: 15px;
            margin-top: 20px;
            height: 230px;
        }
        </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <table style="width: 75%;" align="center">
        <tr>
    <td class="style6">
                <table align="left" style="margin-left: 2px; padding: 1px 4px; width: 806px;">
                    <tr>
                        <td align="right" style="height: 140px">
                            <%--<asp:Image runat="server" alt="ESIC" Style="margin-left: 1px; margin-top: 4px; height: 116px;
                                text-align: center; float: left;" ID="imgLogo" ImageUrl="~/Admin/ImageHandler.ashx?imgID=1" />--%>
                            <%--<img src="images/esic.png" alt="ESIC"  
                  style="margin-left:0px; margin-top:4px; height: 116px; text-align: center;"/>--%><%-- <h3>User :</h3>--%><%-- <asp:Image ID="Image4" runat="server"  ImageUrl="~/images/User.png" />--%>
                        </td>
                        <td align="right" valign="bottom" style="width: 20%">
                            <%-- <h3>User :</h3>--%>
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/User.png" />
                        </td>
                        <td align="left" valign="bottom" style="width: 20%">
                            <asp:Label ID="lbl_userna" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lbl_userid" runat="server" Text="Label" Visible="False"></asp:Label>
                            </p>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="right" valign="bottom">
                            <%--<h3>Terminal :</h3>--%>
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/Terminal.png" />
                        </td>
                        <td align="left" valign="bottom" style="width: 20%">
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="right" style="width: 45%;" valign="bottom">
                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td align="left" valign="bottom" style="width: 20%">
                            <%--<asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                            </Triggers>
                                        </asp:UpdatePanel>--%>
                            <div id="txt">
                            </div>
                        </td>
                        <td style="width: 40%">
                            <%--<p>&nbsp;</p>--%>
                        </td>
                        <td align="right" valign="bottom" style="width: 40%">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/images/Desktop.png" />
                        </td>
                        <td align="right" valign="bottom" style="width: 40%">
                            <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td style="width: 10%;">
                            <p>
                            </p>
                        </td>
                    </tr>
                </table>
            </td>
            </tr>
            <tr>
            <td style="background-color: #C0C0C0;" align="left">
                <asp:Label ID="lbl_login" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="White">Welcome to the Recall Terminal</asp:Label>
            </td>
            <td style="background-color: #C0C0C0;" align="right">
                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" OnClick="LinkButton1_Click">Logout</asp:LinkButton>
            </td>
        </tr>
        <tr> <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        </td></tr>

       <%-- <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Ambulatory Care Center Wollongong Hospital" ForeColor="DarkSlateGray"  Font-Size="30pt" align="center" ></asp:Label>
        </td></tr>--%>
        <tr>
        <td valign="top" rowspan="4">
                            <table align="center" >
                            <tr><td>
                            <table>
                                <tr>
                                <td>
                            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">
                              New 'Q'</asp:Label>
                        </td> 
                       </tr> <tr>
                                    <td>
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <asp:ListBox ID="lb_freshQ" runat="server" Font-Bold="True" Font-Size="Small" Height="230px"
                                                    Width="170px" AutoPostBack="True" OnSelectedIndexChanged="lb_freshQ_SelectedIndexChanged"
                                                    ForeColor="DarkSlateGray"></asp:ListBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td></tr></table>
                                    </td>
                                    <td>
                                   
                                    <table>
                                    <tr>
                                    <td>
                                     <fieldset class="cldQ">
                    <legend style="color: #000080;">Serving Q Number </legend>
                    <div>
                        <asp:UpdatePanel ID="update4" runat="server">
                            <ContentTemplate>
                           &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                <asp:Label ID="lbl_nextq" runat="server"  Font-Bold="true" Text="275" margin-top="800px" margin-right="300px" Font-Size="100px">
                                </asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                
                        
                        
                        <asp:UpdatePanel ID="update5" runat="server">
                            <ContentTemplate>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;  &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;
                                <asp:Label ID="lbl_name" runat="server" style="text-align:center;" margin-top="500px"  margin-right="50px" Font-Size="20px" Text=" Anusha janardhan gowda "
                                    Font-Bold="True" ForeColor="Navy" Width="220px"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </fieldset>
                                    </td></tr>
                                    </table>
                                     </td><td>
                                     <table>
                                     <tr>
                                     <td>
                            <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="DarkSlateGray">
                              Missed 'Q'</asp:Label>
                        </td></tr>
                        <tr>
                        <td>
                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:ListBox ID="lb_missedQ" runat="server" Font-Bold="True" Font-Size="Small" Height="230px"
                                        Width="170" AutoPostBack="True" OnSelectedIndexChanged="lb_missedQ_SelectedIndexChanged"
                                        ForeColor="DarkSlateGray"></asp:ListBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        </tr>
                                     </table>
                                     </td>
                                     </tr>
                                     <table align="center" >
                                     <tr>
                                     <td>
                                         <asp:ImageButton ID="btn_callq" runat="server" ImageUrl="~/images/cal1.png" 
                                             Height="40px" width="140px" onclick="btn_callq_Click"/>
                                         </td>
                                         <td>
                                         <asp:ImageButton ID="btn_mandataendq" runat="server" ImageUrl="~/images/end1.png" 
                                                 Height="40px" width="140px" onclick="btn_mandataendq_Click"/>
                                         </td>
                                         <td>
                                         <asp:ImageButton ID="btn_mandatamissedq" runat="server" 
                                                 ImageUrl="~/images/missed1.png" Height="40px" width="140px" 
                                                 onclick="btn_mandatamissedq_Click" />
                                         </td>
                                         <td>
                                         <asp:ImageButton ID="btn_mandatamissedqcall" runat="server" 
                                                 ImageUrl="~/images/missed cal.png" Height="40px" width="140px" 
                                                 onclick="btn_mandatamissedqcall_Click"/>
                                         </td>
                                         <td>
                                         <asp:ImageButton ID="btn_nextq" runat="server"  ImageUrl="~/images/next1.png"  
                                                 Height="40px" width="140px" onclick="btn_nextq_Click"/>
                                     </td>
                                     </tr></table>
                                     <table>
                                     <tr>
                                     <td>
                                     <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                <ContentTemplate>
                                    <asp:ListBox ID="lb_plannedlist" runat="server" Height="150px" Width="250px" Enabled="False"
                                        Font-Bold="True" Font-Size="Large" AutoPostBack="True" Visible="false" 
                                        ForeColor="DarkSlateGray" 
                                        onselectedindexchanged="lb_plannedlist_SelectedIndexChanged">
                                    </asp:ListBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                             <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txt_esicno" runat="server" Width="200px" Enabled="false"  Visible="false" BorderStyle="None"
                                        Height="25px"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txt_customername" runat="server" Width="200px" Enabled="false"  Visible="false"  BorderStyle="None"
                                        Height="25px"></asp:TextBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                <ContentTemplate>
                                    <asp:ListBox ID="lb_holdQ" runat="server" Font-Bold="True" Font-Size="Small" Height="125px"
                                        Width="130px" AutoPostBack="True" OnSelectedIndexChanged="lb_holdQ_SelectedIndexChanged"
                                        Enabled="False" Visible="False" ForeColor="DarkSlateGray"></asp:ListBox>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_patname" runat="server" Width="150px" Enabled="false" Visible="false" BorderStyle="None"
                                                    Height="25px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_age" runat="server" Width="150px" Enabled="false"  Visible="false" BorderStyle="None"
                                                    Height="25px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_gender" Visible="false" runat="server" Width="150px" Enabled="False" BorderStyle="None"
                                                    Height="25px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_relation" runat="server" Width="150px" Enabled="false"  Visible="false" BorderStyle="None"
                                                    Height="25px"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                            <ContentTemplate>
                                                <asp:TextBox ID="txt_nextq" runat="server" Width="150px"  Visible="false" ForeColor="#00FF00" BorderStyle="None"
                                                    Height="25px" Enabled="False"></asp:TextBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel> 
                                         <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gv_queuedetails" runat="server" AutoGenerateColumns="False" CellPadding="4"
                            ForeColor="#333333" GridLines="None" Style="text-align: center; margin-left: 100px"
                            Width="779px" 
                            onselectedindexchanged="gv_queuedetails_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="SL.NO" HeaderText="SL.NO" />
                                <asp:BoundField DataField="visit_customer_id" HeaderText="Medicare Card Number" />
                                <asp:BoundField DataField="members_name" HeaderText="Patient Name" />
                                <asp:BoundField DataField="Date of Birth" HeaderText="Date of Birth" />
                                <asp:BoundField DataField="relation_desc" HeaderText="Relation" />
                                <asp:BoundField DataField="department_desc" HeaderText="Services" />
                                <asp:BoundField DataField="plan_transfer_id" HeaderText="Plan Transfer ID" Visible="False" />
                                <asp:BoundField DataField="Queue Status" HeaderText="Queue Status" />
                            </Columns>
                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#0379B5" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#0379B5" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#0379B5" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ListBox ID="lb_deptlist" runat="server" AutoPostBack="True" Visible="false" Width="150px" Height="120px">
                                                            </asp:ListBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                                                        <ContentTemplate>
                                                            <asp:ListBox ID="lb_seldeptlist" runat="server" Visible="false" AutoPostBack="True" Width="150px"
                                                                Height="120px"></asp:ListBox>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_l1tol2" runat="server" Text="&gt;"  Visible="false" Width="75px" OnClick="btn_l1tol2_Click"
                                                                Style="text-align: right" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_l2tol1" runat="server" Text="&lt;"  Visible="false" Width="75px" OnClick="btn_l2tol1_Click" />
                                                            <asp:Button ID="btn_holdq" runat="server" Text="Hold 'Q'"  Visible="false" Width="85px" Height="25px"
                                                                OnClick="btn_holdq_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                     <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_up" runat="server" Text="Up" Width="50px" Visible="false" OnClick="btn_up_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_down" runat="server" Text="Down" Width="50px" Visible="false" OnClick="btn_down_Click" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:UpdatePanel ID="UpdatePanel27" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_addservices" runat="server" Visible="false" OnClick="btn_addservices_Click" Style="text-align: right"
                                                                Text="Add Sevices" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:Label ID="lbl_queuetransactionid" runat="server" Text="Queue Transaction Id"
                                            Visible="False" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                            <asp:Label ID="lbl_visittransactionid" runat="server" Text="Visit Transaction Id"
                                            Visible="False" Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                            <asp:Label ID="lbl_queueno_show" runat="server" Text="Queue Number Show" Visible="False"
                                            Font-Size="13pt" ForeColor="DarkSlateGray"></asp:Label>
                                            <asp:Button ID="btn_recall" runat="server" Width="100px"  Visible="false"  Text="Re-Call &quot;Q&quot;"
                                                    OnClick="btn_recall_Click"></asp:Button>
                                                    <asp:DropDownList ID="ddl_department" runat="server" Visible="false" Width="250px" Height="25px"
                                            Font-Size="Medium" ForeColor="DarkSlateGray" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_endq" runat="server" Text="End 'Q'" Width="85px" Height="25px"
                                                                OnClick="btn_endq_Click" Visible="False" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Button ID="btn_missedq" runat="server" Height="25px" OnClick="btn_missedq_Click"
                                                                Text="Missed 'Q'" Visible="False" Width="85px" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                     <asp:UpdatePanel ID="UpdatePanel144" runat="server">
                                            <ContentTemplate>
                                                <asp:ListBox ID="lb_pendingQ" runat="server" Font-Bold="True" Font-Size="Small" Height="126px"
                                                    Width="130px" AutoPostBack="True" Visible="False" Enabled="False" 
                                                    ForeColor="DarkSlateGray" 
                                                    onselectedindexchanged="lb_pendingQ_SelectedIndexChanged">
                                                </asp:ListBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <asp:ListBox ID="ListBox1" runat="server" Visible="False"  Font-Bold="True" 
                                                    Font-Size="Small" Height="126px"
                                                    Width="130px" AutoPostBack="True" Enabled="False" 
                                                    ForeColor="DarkSlateGray" 
                                                    onselectedindexchanged="ListBox1_SelectedIndexChanged">
                                                </asp:ListBox>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbl_msg" runat="server" ForeColor="Red" Visible="False" Style="text-align: center"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                 <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                            <ContentTemplate>
                                                <asp:Button ID="btn_transferq" runat="server" Visible="False" Text="Transfer &quot;Q&quot;" OnClick="btn_transferq_Click" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                     </td></tr></table>

    </table>
        
    
    <div align="center">
    <tr>
            <td colspan="2" align="center">
                <h5>
                    Client IP :&nbsp;[<asp:Label ID="lbl_clientip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Instance
                    IP : [<asp:Label ID="lbl_instanceip" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>]&nbsp;</h5>
            </td>
        </tr>
    </div>
    </form>
</body>
</html>
