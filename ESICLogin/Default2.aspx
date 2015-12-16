<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
   <%--  <telerik:RadScriptManager Runat="server" ID ="RadScriptManager1" />--%>
     <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
          <table>
        <tr>
            <td rowspan="6" valign="top">
                  <telerik:RadListBox ID="RadListBox1" runat="server" CssClass="RadListBox1" 
            Width="200px" Height="200px"
            SelectionMode="Single" TransferToID="RadListBox2" AutoPostBackOnTransfer="true"
            AllowReorder="true" AutoPostBackOnReorder="true" EnableDragAndDrop="True" 
            AllowTransfer="True" Font-Bold="True" Font-Size="XX-Large">
            <Items>
                <telerik:RadListBoxItem Text="Argentina" Value="0"></telerik:RadListBoxItem>
                <telerik:RadListBoxItem Text="Australia" Value="1"></telerik:RadListBoxItem>
                <telerik:RadListBoxItem Text="Brazil" Value="2"></telerik:RadListBoxItem>
                <telerik:RadListBoxItem Text="Canada" Value="3"></telerik:RadListBoxItem>
                <telerik:RadListBoxItem Text="Chile" Value="4"></telerik:RadListBoxItem>
                <telerik:RadListBoxItem Text="China" Value="5"></telerik:RadListBoxItem>

        
            </Items>
        </telerik:RadListBox>   

            </td>
            <td>
            </td>
            <td rowspan="6" valign="top">
          <telerik:RadListBox ID="RadListBox2" CssClass="RadListBox2" runat="server" 
            Width="200px" Height="200px"
            SelectionMode="Multiple" AllowReorder="True" AutoPostBackOnReorder="true" 
            EnableDragAndDrop="true"  Font-Bold="True" Font-Size="XX-Large">
           <Items>
                <telerik:RadListBoxItem Text="China" Value="5"></telerik:RadListBoxItem>
           </Items>
        </telerik:RadListBox>
            </td>
        </tr>


  
    </table>
    </telerik:RadAjaxPanel>
    </form>
</body>
</html>
