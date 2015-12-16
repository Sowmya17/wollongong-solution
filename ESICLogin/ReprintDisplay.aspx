<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReprintDisplay.aspx.cs" Inherits="ReprintDisplay" %>

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
 <script type="text/javascript">
    function windowclose()
{
 window.close();
 }
 </script>

</head>
<body>
    <form id="form1" runat="server">
        <table  align="center">
                  
                      <tr>
                        <td>
                         <h1 style="color:Navy; font-size:xx-large;">Please Click Print To Take Reprint</h1>
                          </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                   <asp:GridView ID="gv_departmentmaster" runat="server" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
            GridLines="None" 
            onselectedindexchanged="gv_departmentmaster_SelectedIndexChanged" 
            AllowPaging="True" 
            
            style="text-align: center" onrowdatabound="gv_departmentmaster_RowDataBound">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="customer_id" HeaderText="Unique UMI No" />
            <asp:BoundField DataField="customer_name" HeaderText="Card Holder Name" />
            <asp:BoundField DataField="patient" HeaderText="Patient Name" />
            <asp:BoundField DataField="dept" HeaderText="Department ID" />
            <asp:BoundField DataField="department_id" HeaderText="Department Name" />
            <asp:BoundField DataField="queue_no" HeaderText="Queue Number" />
            <asp:BoundField DataField="queue_show" HeaderText="QueueNumber Show" 
                SortExpression="queue_show" />
            <asp:CommandField SelectText="PRINT" ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    
                                            </td>
                                        </tr>
                                       <tr>
                                        <td align="center">
                                      <%--  <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                            <ContentTemplate>--%>
                                        
                            <%--</ContentTemplate></asp:UpdatePanel>--%>
                                        </td>
                                        </tr>
                
                                      
                </table>
        
        
    </form>
</body>
</html>

