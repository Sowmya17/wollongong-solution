<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScheduleEdit.aspx.cs" Inherits="AddMember" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
    <table>
      <tr>
    
    <td></td>

    <td>
     Schedule Week
    </td>

    <td>
        <asp:DropDownList ID="ddl_week1" runat="server" AppendDataBoundItems="True">
         <asp:ListItem>Select</asp:ListItem>
        </asp:DropDownList>
           

     <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
        <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
    </td>
    
    
    
    <td></td>

    </tr>
    <tr>
   
   <td></td>

   <td>
    Schdule Day
   </td>

    <td>

    <asp:DropDownList ID="ddl_day" runat="server" AppendDataBoundItems="True">
     <asp:ListItem>Select</asp:ListItem>
        </asp:DropDownList>
    </td>
    
   
    <td></td>

    </tr>

    <tr>
    
    <td></td>

    <td>
      Department Description
    </td>

    <td>
   <asp:DropDownList ID="ddl_departmentdescription" runat="server" ForeColor="Black" 
            Width="216px" Height="20px" AppendDataBoundItems="True">
       <asp:ListItem>Select</asp:ListItem>
     </asp:DropDownList>
    </td>
    
  
    
    <td></td>

    </tr>

    <tr>
   
   <td></td>

   <td>
    Schdule Room Code
   </td>

    <td>

   <asp:DropDownList ID="ddl_roomcode" runat="server" ForeColor="Black" 
            Width="216px" Height="20px" AppendDataBoundItems="True">
       <asp:ListItem>Select</asp:ListItem>
     </asp:DropDownList>
    </td>
    
    
    
    <td></td>

    </tr>

    <tr>
    
    <td></td>

    <td>
     Schedule Session
    </td>

    <td>
        <asp:DropDownList ID="ddl_session" runat="server" AppendDataBoundItems="True">
         <asp:ListItem>Select</asp:ListItem>
        </asp:DropDownList>
           

     <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
        <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
    </td>
    
   
    
    <td></td>

    </tr>

     <tr>
    
    <td></td>

    <td>
     Schedule StartDate Time
    </td>

    <td>
        <telerik:RadTimePicker ID="dt_starttime" runat="server">
    <TimeView TimeFormat="h:mm t"></TimeView>
</telerik:RadTimePicker>

           
           <telerik:RadDatePicker ID="dt_start" runat="server"></telerik:RadDatePicker>
     <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
        <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
    </td>
    
   
    
    <td></td>

    </tr>

    <tr>
    
    <td></td>

    <td>
     Schedule End Date Time
    </td>

    <td>
        
          

           <telerik:RadDatePicker ID="dt_end" runat="server">
           </telerik:RadDatePicker>
         <telerik:RadTimePicker ID="dt_endtime" runat="server">
    <TimeView TimeFormat="h:mm t"></TimeView>
</telerik:RadTimePicker>
     <%--<asp:TextBox ID="txt_firstname" runat="server" Text="First Name" 
            ForeColor="Gray" onblur = "FirstName()" />--%>
        <%--<input id="txt_firstname" value="Enter Your First Name" Forecolor="Gray"/>--%>
    </td>
    
  
    
    <td></td>

    </tr>
    </table>
    <table align="center">

    <tr>

    <td>
        &nbsp;</td>    

    <td>
    <asp:Button ID="btn_locationedit" runat="server" Text="Edit" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_locationedit_Click" CausesValidation="false"/>
    </td>

    <td>
    <asp:Button ID="btn_locationsave" runat="server" Text="Save" 
            Width="65px" BackColor="#0379B5" BorderColor="#0379B5" 
            BorderStyle="Solid" ForeColor="White" Font-Bold="True" 
            onclick="btn_locationsave_Click" OnClientClick="return"/>
    </td>  
    
    </tr>
            
    </table>
    </div>
    <div>
        <asp:Label ID="lbl_msg" runat="server" ForeColor="Green" Visible="False"></asp:Label>
    </div>
    </form>
</body>
</html>
