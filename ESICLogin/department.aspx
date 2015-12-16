<%@ Page Language="C#" AutoEventWireup="true" CodeFile="department.aspx.cs" Inherits="department" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">


<script type="text/javascript">
    Telerik.Web.UI.RadDatePicker.prototype._actionBeforeShowPopup_original = Telerik.Web.UI.RadDatePicker.prototype._actionBeforeShowPopup;
    Telerik.Web.UI.RadDatePicker.prototype._actionBeforeShowPopup = function () {
        this._actionBeforeShowPopup_original();
        if (Telerik.Web.UI.RadDateTimePicker) {
            Telerik.Web.UI.RadDateTimePicker.prototype._hideAllTimePopups();
        }
    }
</script>


    <title></title>
    
    <script type="text/javascript" src="js/jquery.min.js"></script>
    <script type="text/javascript" src="js/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="CSS/jquery-ui.css" />
    <script src="js/braviPopup.js" type="text/javascript"></script>
    <link href="CSS/braviStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="CSS/RTStyleSheet.css" />
    <script type="text/javascript">
        //        $(document).ready(function () {
        //            $('#').click(function () {
        //                $.braviPopUp('Add Family Members', 'AddMember.aspx', 600, 400);
        //            });
        //        });
        //if you want to refresh parent page on closing of a popup window then remove comment to the below function
        //and also call this function from the js file 
        function Refresh() {
            window.location.reload();
        }

        function schedulefunction() {

            $.braviPopUp('Edit Schedule Details', 'ScheduleEdit.aspx', 800, 400);
            $('#dv_move').draggable('destroy');

        };


        function myfunction1() {

            $.braviPopUp('Appointments Details', 'AppDetails.aspx', 800, 400);
            $('#dv_move').draggable('destroy');

        };

        function reprintdisplay() {

            $.braviPopUp('Reprinting', 'ReprintDisplay.aspx', 800, 400);
            $('#dv_move').draggable('destroy');

        };

        //        });       
    </script>
    <style type="text/css">
        #form1
        {
            height: 1639px;
            width: 1253px;
        }
        
        
        
        
        
        .style1
        {
            width: 551px;
            height: 25px;
        }
        .style2
        {
            width: 559px;
            height: 25px;
            margin-left: 638px;
        }
        .style3
        {
            width: 550px;
            height: 25px;
        }
        .style4
        {
            width: 557px;
            height: 25px;
            margin-left: 638px;
        }
        
        
        
        
        
        .style5
        {
           
            width: 50px;
            height: 53px;
        }
        
        
        
        
        
        .style6
        {
            width: 556px;
        }
        
        
        
        
        
        .style7
        {
            width: 550px;
        }
        
        
        
        
        
        .style8
        {
            width: 553px;
        }
        .style9
        {
            width: 555px;
        }
        
        
        
        
        
        .style10
        {
            width: 549px;
        }
        
        
        
        
        
        .style11
        {
            width: 554px;
        }
        .style12
        {
            width: 542px;
        }
        
        
        
        
        
        .style13
        {
            width: 551px;
        }
        
        
        
        
        
        .style14
        {
            width: 545px;
        }
        
        
        
        
        
        .style15
        {
            width: 539px;
        }
        
        
        
        
        
        .style16
        {
            width: 540px;
        }
        
        
        
        
        
        .style17
        {
            width: 548px;
        }
        
        
        
        
        
        .style18
        {
            width: 536px;
        }
        
        
        
        
        
        .style19
        {
            width: 543px;
        }
        .style20
        {
            width: 547px;
        }
        
        
        
        
        
        .style21
        {
            width: 533px;
        }
        
        
        
        
        
        .style22
        {
            width: 537px;
        }
        
        
        
        
        
        .style23
        {
            width: 534px;
        }
        
        
        
        
        
        .style24
        {
            width: 538px;
        }
        
        
        
        
        
        .style25
        {
            width: 532px;
        }
        
        
        
        
        
        .style26
        {
            width: 535px;
        }
        
        
        
        
        
        .style27
        {
            width: 531px;
        }
        
        
        
        
        
        .style28
        {
            width: 530px;
        }
        
        
        
        
        
        </style>
</head>
<body style="height: 1645px; width: 1264px">
    <form id="form1" runat="server">
    <div style="border-bottom-color: #000000; border: medium none #000000; width: 1197px; height: 1567px; margin-left: 27px">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <br />
    <br />
   


    <div style="border: thin solid #000000; margin-left: 82px; " 
            class="style1">

    &nbsp;&nbsp;&nbsp;
      
<%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
        <asp:Label ID="Label1" runat="server" Text="" 
                style="border-bottom-color: #000000; border-color: #000000; font-size:25px; margin-left: 30px;"></asp:Label></span>
            &nbsp;&nbsp;&nbsp;<span> <asp:Label ID="Label33" runat="server" Text="" style="font-size:25px; margin-left: 25px;"></asp:Label> </span>
            &nbsp;&nbsp;&nbsp;<span>&nbsp;&nbsp; <asp:Label ID="Label34" runat="server" Text="" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
           &nbsp;&nbsp; <span>&nbsp;&nbsp; <asp:Label ID="Label38" runat="server" Text="" style="font-size:25px;margin-left: 20px;"></asp:Label> </span>&nbsp; &nbsp;&nbsp;<span>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label39" runat="server" Text="" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
        </div>

        <div style="border: thin solid #000000; margin-top: -28px;" 
            class="style2">
       <%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label2" runat="server" Text="WEEK2"></asp:Label>--%>
        &nbsp;&nbsp;&nbsp; &nbsp;<span> <asp:Label ID="Label2" runat="server" Text="" style="font-size:25px; margin-left: 30px;"></asp:Label></span>
            &nbsp;&nbsp;&nbsp;<span>&nbsp; <asp:Label ID="Label40" runat="server" Text="" style="font-size:25px; margin-left: 25px;"></asp:Label> </span>
            &nbsp;&nbsp; &nbsp;<span> <asp:Label ID="Label41" runat="server" Text="" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
           &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<span> <asp:Label ID="Label42" runat="server" Text="" style="font-size:25px;margin-left: 20px;"></asp:Label> </span>
            &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<span><asp:Label ID="Label43" runat="server" Text="" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>


        </div>
<%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label2" runat="server" Text="Week2"></asp:Label>--%>
        
        <div style="border: thin solid #000000; margin-left: 83px; " class="style3">
           &nbsp;&nbsp;&nbsp;<span style="border-color: #000000;"> 
            </span>
            &nbsp;&nbsp;&nbsp;<span> <asp:Label ID="Label4" runat="server" Text="Tue" style="font-size:25px; margin-left: 25px;"></asp:Label> </span>
            &nbsp;&nbsp;&nbsp;<span>&nbsp;&nbsp; <asp:Label ID="Label5" runat="server" Text="Wen" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
           &nbsp;&nbsp;&nbsp;<span>&nbsp; &nbsp; <asp:Label ID="Label6" runat="server" Text="Thu" style="font-size:25px;margin-left: 20px;"></asp:Label> </span>
            &nbsp;&nbsp; &nbsp;&nbsp;<span>&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label7" runat="server" Text="Fri" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
        </div>
        
        
    <div style="border: thin solid rgb(0, 0, 0); margin-top: -27px;" class="style4">
           &nbsp;&nbsp;&nbsp; &nbsp;<span> <asp:Label ID="Label8" runat="server" Text="Mon" style="font-size:25px; margin-left: 30px;"></asp:Label></span>
            &nbsp;&nbsp;&nbsp;<span>&nbsp; <asp:Label ID="Label9" runat="server" Text="Tue" style="font-size:25px; margin-left: 25px;"></asp:Label> </span>
            &nbsp;&nbsp; &nbsp;<span> <asp:Label ID="Label10" runat="server" Text="Wen" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
           &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;<span> <asp:Label ID="Label11" runat="server" Text="Thu" style="font-size:25px;margin-left: 20px;"></asp:Label> </span>
            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<span><asp:Label ID="Label12" runat="server" Text="Fri" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
        </div>
        
       <%-- <div><asp:Label ID="schedule_date" runat="server" style="width:80px; margin-left: 90px;">
            </asp:Label></div>--%>
 <%--<table style="height: 76px; width: 1218px">
    <tr>
    <td style="background-color:red;">
      <asp:Label ID="lbl_queue11" ForeColor="Black" runat="server" Text="A1" style="margin-left: 12px;"></asp:Label >
                 </td>
                 
                 </tr>
                  </table>--%>

   
      <br />
     <div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" 
            class="style5">
     <br />
    &nbsp;&nbsp; 
    
    <asp:Label ID="Label13" runat="server" Text="A1"></asp:Label>
    
     </div>
      <div style="margin-left: 80px; margin-top: -55px;" class="style6">


     
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

       
        
          <asp:Button ID="Button1" runat="server" Text="" 
              style="background-color:Red; text-align:center;" Width="80px" 
              onclick="Button1_Click"/>

            
&nbsp;&nbsp;
          <asp:Button ID="Button2" runat="server" Text="" 
              style="background-color:Red; text-align:center;" Width="80px" 
              onclick="Button2_Click" />
             
&nbsp;&nbsp;
           
            
          <asp:Button ID="Button3" runat="server" Text="" 
              style="background-color:#B88A00; text-align:center;" Width="80px" 
              onclick="Button3_Click"/>
            

&nbsp;&nbsp;

          <asp:Button ID="Button4" runat="server" Text="" 
              style="background-color:Red; text-align:center;" Width="80px" 
              onclick="Button4_Click"/>

            
&nbsp;&nbsp;
          <asp:Button ID="Button5" runat="server" Text="" 
              style="background-color:Red; text-align:center;" Width="80px" 
              onclick="Button5_Click"/>
            
            <br />
            <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button6" runat="server" Text="" 
              style="background-color:Red; text-align:center;" Width="80px" 
              onclick="Button6_Click"/>
            

            &nbsp;&nbsp;
          <asp:Button ID="Button7" runat="server" Text="" 
              style="background-color:Red; text-align:center;" Width="80px" 
              onclick="Button7_Click"/>
            
&nbsp;&nbsp;
          <asp:Button ID="Button8" runat="server" Text="" 
              style="background-color:#B88A00; text-align:center;" Width="80px" 
              onclick="Button8_Click"/>

            
&nbsp;&nbsp;
          <asp:Button ID="Button9" runat="server" Text="" 
              style="background-color:Red; text-align:center;" Width="80px" 
              onclick="Button9_Click" />
            
&nbsp;&nbsp;
            
          <asp:Button ID="Button10" runat="server" Text="" 
              style="background-color:Red; text-align:center;" Width="80px" 
              onclick="Button10_Click"/>

     </div>


        <div style="margin-left: 650px; margin-top: -55px;" class="style7">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button101" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button102" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px" />
&nbsp;&nbsp;
            <asp:Button ID="Button338" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button103" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px" />
&nbsp;&nbsp;
            <asp:Button ID="Button107" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button104" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px" />
            &nbsp;&nbsp;
            <asp:Button ID="Button105" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button339" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button106" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button108" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>

        </div>

        <%--<div style="width: 46px; height: 43px; margin-left: 1091px; margin-top:-46px;">
        
        <asp:Label ID="Label33" runat="server" Text="AM"></asp:Label>
        <br />
        
        <asp:Label ID="Label34" runat="server" Text="PM"></asp:Label>
        </div>--%>
        <br />
        



        <div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label14" runat="server" Text="A2"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style9">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button11" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button11_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button12" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button12_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button13" runat="server" Text="" 
                style="background-color:#B88A00; text-align:center;" Width="80px" 
                onclick="Button13_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button17" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button17_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button18" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button18_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button19" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button19_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button20" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button20_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button14" runat="server" Text="" 
                style="background-color:#B88A00; text-align:center;" Width="80px" 
                onclick="Button14_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button21" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button21_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button22" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button22_Click" />

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style8">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button112" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px" />
&nbsp;&nbsp;
            <asp:Button ID="Button111" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px" />
&nbsp;&nbsp;
            <asp:Button ID="Button340" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button110" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button109" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button113" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button114" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button341" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button115" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button116" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>

        </div>

        <br />
        <div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label15" runat="server" Text="A3"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style6">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button23" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button23_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button24" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button24_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button15" runat="server" Text="" 
                style="background-color:#B88A00; text-align:center;" Width="80px" 
                onclick="Button15_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button25" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button25_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button26" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button26_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button27" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button27_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button28" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button28_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button16" runat="server" Text="" 
                style="background-color:#B88A00; text-align:center;" Width="80px" 
                onclick="Button16_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button29" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button29_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button30" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button30_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style10">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button120" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button119" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button342" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button118" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button117" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button121" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button122" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button343" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button123" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button124" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>

        </div>

        <br />


        <div style=" border: thin solid #000000;  background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label16" runat="server" Text="A4"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style11">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button31" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button31_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button32" runat="server" Text="" 
                style="background-color:#BDD391; text-align:center; height: 26px;" Width="80px" 
                onclick="Button32_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button33" runat="server" Text="" 
                style="background-color:#E62EB8; text-align:center;" Width="80px" 
                onclick="Button33_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button34" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button34_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button35" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button35_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button36" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button36_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button39" runat="server" Text="" 
                style="background-color:#B5DAFF; text-align:center;" Width="80px" 
                onclick="Button39_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button40" runat="server" Text="" 
                style="background-color:#C0C0C0; text-align:center;" Width="80px" 
                onclick="Button40_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button41" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button41_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button37" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button37_Click" />

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style12">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button127" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button353" runat="server" Text="" style="background-color:#BDD391;  text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button362" runat="server" Text="" style="background-color:white;  text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button126" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button125" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button128" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button129" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px" />
&nbsp;&nbsp;
            <asp:Button ID="Button374" runat="server" Text="" style="background-color:#C0C0C0; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button130" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button131" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>

        </div>

   <br />


   <div style=" border: thin solid #000000;  background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label17" runat="server" Text="A5"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style13">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button42" runat="server" Text="" 
                style="background-color:#B56CFF; text-align:center;" Width="80px" 
                onclick="Button42_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button43" runat="server" Text="" 
                style="background-color:#BDD391; text-align:center;" Width="80px" 
                onclick="Button43_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button44" runat="server" Text="" 
                style="background-color:#E62EB8; text-align:center;" Width="80px" 
                onclick="Button44_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button45" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button45_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button38" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button38_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button52" runat="server" Text="" 
                style="background-color:#FFA500; text-align:center;" Width="80px" 
                onclick="Button52_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button53" runat="server" Text="" 
                style="background-color:#B5DAFF; text-align:center;" Width="80px" 
                onclick="Button53_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button54" runat="server" Text="" 
                style="background-color:#C0C0C0; text-align:center;" Width="80px" 
                onclick="Button54_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button46" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button46_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button55" runat="server" Text="" 
                style="background-color:white; text-align:center;" Width="80px" 
                onclick="Button55_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style14">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button398" runat="server" Text="" style="background-color:#B56CFF; text-align:center; height: 19px;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button134" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button363" runat="server" Text="" style="background-color:white;  text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button133" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button132" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button399" runat="server" Text="" style="background-color:#FFA500; text-align:center;" Width="80px"/> 
            &nbsp;&nbsp;
            <asp:Button ID="Button135" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button375" runat="server" Text="" style="background-color:#C0C0C0; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button136" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button137" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>

        </div>

      <br />

      <div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label18" runat="server" Text="A6"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -55px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button49" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button49_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button56" runat="server" Text="" 
                style="background-color:#BDD391; text-align:center;" Width="80px" 
                onclick="Button56_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button57" runat="server" Text="" 
                style="background-color:#E62EB8; text-align:center;" Width="80px" 
                onclick="Button57_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button47" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button47_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button48" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button48_Click"/>
           <br />          <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button58" runat="server" Text="" 
                style="background-color:white; text-align:center;" Width="80px" 
                onclick="Button58_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button59" runat="server" Text="" 
                style="background-color:#B5DAFF; text-align:center;" Width="80px" 
                onclick="Button59_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button51" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button51_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button50" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button50_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button60" runat="server" Text="" 
                style="background-color:#5F9EA0; text-align:center;" Width="80px" 
                onclick="Button60_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style15">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button141" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button140" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px" /> 
&nbsp;&nbsp;
            <asp:Button ID="Button364" runat="server" Text="" style="background-color:white;  text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button139" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button138" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button142" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px" />
            &nbsp;&nbsp;
            <asp:Button ID="Button143" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button382" runat="server" Text="" style="background-color:#FFE4E1; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button144" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button400" runat="server" Text="" style="background-color:#5F9EA0; text-align:center;" Width="80px"/>

        </div>
        <br />

        <div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label19" runat="server" Text="A7"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style9">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button61" runat="server" Text="" 
                style="background-color:MistyRose; text-align:center;" Width="80px" 
                onclick="Button61_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button62" runat="server" Text="" 
                style="background-color:#BDD391; text-align:center;" Width="80px" 
                onclick="Button62_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button63" runat="server" Text="" 
                style="background-color:#E62EB8; text-align:center;" Width="80px" 
                onclick="Button63_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button64" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button64_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button65" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button65_Click" />
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button66" runat="server" Text="" 
                style="background-color:white; text-align:center;" Width="80px" 
                onclick="Button66_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button67" runat="server" Text="" 
                style="background-color:#B5DAFF; text-align:center;" Width="80px" 
                onclick="Button67_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button68" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button68_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button69" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button69_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button70" runat="server" Text="" 
                style="background-color:DodgerBlue; text-align:center;" Width="80px" 
                onclick="Button70_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style16">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button148" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button147" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button365" runat="server" Text="" style="background-color:white;  text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button146" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button145" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button152" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button151" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button383" runat="server" Text="" style="background-color:#FFE4E1; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button150" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button149" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>

        </div>

        <br />

        <div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label20" runat="server" Text="A8"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style17">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button71" runat="server" Text="" 
                style="background-color:MistyRose; text-align:center;" Width="80px" 
                onclick="Button71_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button72" runat="server" Text="" 
                style="background-color:#BDD391; text-align:center;" Width="80px" 
                onclick="Button72_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button73" runat="server" Text="" 
                style="background-color:#E62EB8; text-align:center;" Width="80px" 
                onclick="Button73_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button74" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button74_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button75" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button75_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button76" runat="server" Text="" 
                style="background-color:LightCoral; text-align:center;" Width="80px" 
                onclick="Button76_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button77" runat="server" Text="" 
                style="background-color:#B5DAFF; text-align:center;" Width="80px" 
                onclick="Button77_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button78" runat="server" Text="" 
                style="background-color:LightGoldenRodYellow; text-align:center;" Width="80px" 
                onclick="Button78_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button79" runat="server" Text="" 
                style="background-color:#FFE4E1; text-align:center;" Width="80px" 
                onclick="Button79_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button80" runat="server" Text="" 
                style="background-color:DodgerBlue; text-align:center;" Width="80px" 
                onclick="Button80_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style18">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button153" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button154" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button366" runat="server" Text="" style="background-color:white;  text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button155" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button156" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button158" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button159" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button384" runat="server" Text="" style="background-color:LightGoldenRodYellow; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button160" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button157" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>

        </div>

        <br />

<div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label21" runat="server" Text="A9"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style20">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button81" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button81_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button82" runat="server" Text="" 
                style="background-color:#BDD391; text-align:center;" Width="80px" 
                onclick="Button82_Click"/>  
&nbsp;&nbsp;
            <asp:Button ID="Button83" runat="server" Text="" 
                style="background-color:#B88A00; text-align:center;" Width="80px" 
                onclick="Button83_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button84" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button84_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button85" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button85_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button86" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button86_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button87" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button87_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button385" runat="server" Text="" 
                style="background-color:#FFA500; text-align:center;" Width="80px" 
                onclick="Button385_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button88" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button88_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button89" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button89_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style21">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button164" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button163" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button344" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button162" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button161" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button165" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button166" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button386" runat="server" Text="" style="background-color:#FFA500; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button167" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button168" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>

        </div>

        <br />

        <div style="  border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label22" runat="server" Text="A10"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -55px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button90" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button90_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button354" runat="server" Text="" 
                style="background-color:#BDD391;  text-align:center;" Width="80px" 
                onclick="Button354_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button346" runat="server" Text="" 
                style="background-color:#B88A00; text-align:center;" Width="80px" 
                onclick="Button346_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button315" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button315_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button93" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button93_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button91" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button91_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button92" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button92_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button387" runat="server" Text="" 
                style="background-color:#FFA500; text-align:center;" Width="80px" 
                onclick="Button387_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button94" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button94_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button95" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button95_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style22">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button172" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button171" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button345" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button170" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button169" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button176" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button175" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button388" runat="server" Text="" style="background-color:#FFA500; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button174" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button173" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 


        </div>

        <br />

<div style="  border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label23" runat="server" Text="A11"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -55px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button314" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button314_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button96" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button96_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button397" runat="server" Text="" 
                style="background-color:CornflowerBlue; text-align:center;" Width="80px" 
                onclick="Button397_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button337" runat="server" Text="" 
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button337_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button381" runat="server" Text="" 
                style="background-color:#DE8CA7; text-align:center;" Width="80px" 
                onclick="Button381_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button380" runat="server" Text="" 
                style="background-color:#DE8CA7; text-align:center;" Width="80px" 
                onclick="Button380_Click"/> 
            &nbsp;&nbsp;
            <asp:Button ID="Button97" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button97_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button376" runat="server" Text="" 
                style="background-color:DarkGray; text-align:center;" Width="80px" 
                onclick="Button376_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button379" runat="server" Text="" 
                style="background-color:#DE8CA7; text-align:center;" Width="80px" 
                onclick="Button379_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button313" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button313_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style23">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button179" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button178" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button396" runat="server" Text="" style="background-color:CornflowerBlue; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button326" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button177" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button378" runat="server" Text="" style="background-color:Fuchsia; text-align:center;" Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button180" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button377" runat="server" Text="" style="background-color:DarkGray; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button181" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button182" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>

        </div>

        <br />
<div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label24" runat="server" Text="A12"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -55px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button336" runat="server"  
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button336_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button335" runat="server" Text="" 
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button335_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button334" runat="server" Text="" 
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button334_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button333" runat="server" Text="" 
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button333_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button332" runat="server" Text="" 
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button332_Click"/> 
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button331" runat="server" Text="" 
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button331_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button330" runat="server" Text="" 
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button330_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button329" runat="server" Text="" 
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button329_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button328" runat="server" Text="" 
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button328_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button327" runat="server" Text="" 
                style="background-color:Cyan; text-align:center;" Width="80px" 
                onclick="Button327_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style23">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button321" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/>  
&nbsp;&nbsp;
            <asp:Button ID="Button322" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button323" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button324" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button325" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button320" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button319" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button318" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button316" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button317" runat="server" Text="" style="background-color:Cyan; text-align:center;" Width="80px"/> 

        </div>

        <br />

<div style="  border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label25" runat="server" Text="B1"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style19">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button310" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button310_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button311" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button311_Click"/>  
&nbsp;&nbsp;
            <asp:Button ID="Button347" runat="server" Text="" 
                style="background-color:#B88A00; text-align:center;" Width="80px" 
                onclick="Button347_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button312" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button312_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button361" runat="server" Text="" 
                style="background-color:#B56CFF;text-align:center;"  Width="80px" 
                onclick="Button361_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button360" runat="server" Text="" 
                style="background-color:#B56CFF;text-align:center;"  Width="80px" 
                onclick="Button360_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button395" runat="server" Text="" 
                style="background-color:#DE8CA7 ; text-align:center;" Width="80px" 
                onclick="Button395_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button309" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button309_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button98" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button98_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button308" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button308_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style25">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button186" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button185" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button348" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button184" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button183" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px" /> 
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button359" runat="server" Text="" style="background-color:#B56CFF;text-align:center;"  Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button187" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button298" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button188" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button189" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>

        </div>

        <br />

<div style="  border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label26" runat="server" Text="B2"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style24">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button307" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" onclick="Button307_Click" 
                /> 
&nbsp;&nbsp;
            <asp:Button ID="Button305" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button305_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button349" runat="server" Text="" 
                style="background-color:#B88A00; text-align:center;" Width="80px" 
                onclick="Button349_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button306" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button306_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button373" runat="server" Text="" 
                style="background-color:white; text-align:center;"  Width="80px" 
                onclick="Button373_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button304" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button304_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button303" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button303_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button302" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button302_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button301" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button301_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button300" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button300_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style12">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button299" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button192" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button350" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button191" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button190" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button296" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button193" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button297" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button194" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button195" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 

        </div>

        <br />

<div style="  border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label27" runat="server" Text="B3"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style18">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button293" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button293_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button294" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button294_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button391" runat="server" Text="" 
                style="background-color:ForestGreen;text-align:center;"  Width="80px" 
                onclick="Button391_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button295" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button295_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button372" runat="server" Text="" 
                style="background-color:white; text-align:center;"  Width="80px" 
                onclick="Button372_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button292" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button292_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button390" runat="server" Text="" 
                style="background-color:DodgerBlue ;text-align:center;"  Width="80px" 
                onclick="Button390_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button291" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button291_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button99" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button99_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button290" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button290_Click"/>

        </div>

        <div style="margin-left: 655px; margin-top: -55px;" class="style18">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button283" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button198" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button392" runat="server" Text="" style="background-color:ForestGreen;text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button197" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button196" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>  
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button282" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button201" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button281" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button200" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button199" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px" />

        </div>
        <br />
<div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label28" runat="server" Text="B4"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style18">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button288" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button288_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button289" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button289_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button393" runat="server" Text="" 
                style="background-color:ForestGreen;text-align:center;"  Width="80px" 
                onclick="Button393_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button285" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button285_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button371" runat="server" Text="" 
                style="background-color:white; text-align:center;"  Width="80px" 
                onclick="Button371_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button287" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button287_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button389" runat="server" Text="" 
                style="background-color:DodgerBlue ;text-align:center;"  Width="80px" 
                onclick="Button389_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button286" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button286_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button100" runat="server" Text="" 
                style="background-color:Red; text-align:center;" Width="80px" 
                onclick="Button100_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button284" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button284_Click"/> 

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style22">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button280" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button202" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>  
&nbsp;&nbsp;
            <asp:Button ID="Button394" runat="server" Text="" style="background-color:ForestGreen;text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button203" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button204" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button279" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button207" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button278" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button206" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button205" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 

        </div>
        <br />

<div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label29" runat="server" Text="B5"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style26">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button277" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button277_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button276" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button276_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button367" runat="server" Text="" 
                style="background-color:Lavender; text-align:center;"  Width="80px" 
                onclick="Button367_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button275" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button275_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button370" runat="server" Text="" 
                style="background-color:white; text-align:center;"  Width="80px" 
                onclick="Button370_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button274" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button274_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button358" runat="server" Text="" 
                style="background-color:#B56CFF;text-align:center;"  Width="80px" 
                onclick="Button358_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button273" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button273_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button357" runat="server" Text="" 
                style="background-color:#B56CFF;text-align:center;"  Width="80px" 
                onclick="Button357_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button272" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button272_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style26">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button263" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button208" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button368" runat="server" Text="" style="background-color:Lavender; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button209" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button210" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button262" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/> 
            &nbsp;&nbsp;
            <asp:Button ID="Button356" runat="server" Text="" style="background-color:#B56CFF;text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button261" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button355" runat="server" Text="" style="background-color:#B56CFF;text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button211" runat="server" Text="" style="background-color:Red; text-align:center;" Width="80px"/> 

        </div>
        <br />

<div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label30" runat="server" Text="B6"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style26">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button269" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button269_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button270" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button270_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button352" runat="server" Text="" 
                style="background-color:#B88A00; text-align:center;" Width="80px" 
                onclick="Button352_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button271" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button271_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button369" runat="server" Text="" 
                style="background-color:white; text-align:center;"  Width="80px" 
                onclick="Button369_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button268" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button268_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button267" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button267_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button266" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button266_Click"/>  
&nbsp;&nbsp;
            <asp:Button ID="Button265" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button265_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button264" runat="server" Text="" 
                style="background-color:yellow;text-align:center;"  Width="80px" 
                onclick="Button264_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style27">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button257" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button258" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button351" runat="server" Text="" style="background-color:#B88A00; text-align:center;" Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button259" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button260" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button256" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/> 
            &nbsp;&nbsp;
            <asp:Button ID="Button255" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button254" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button253" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button252" runat="server" Text="" style="background-color:yellow;text-align:center;"  Width="80px"/>  

        </div>
        <br />

<div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label31" runat="server" Text="B7"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style27">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button251" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button251_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button250" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button250_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button249" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button249_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button248" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button248_Click" />
&nbsp;&nbsp;
            <asp:Button ID="Button247" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button247_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button242" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center; height: 26px;"  
                Width="80px" onclick="Button242_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button243" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button243_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button244" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button244_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button245" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button245_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button246" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button246_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style25">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button227" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button228" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button229" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button230" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button231" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/> 
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button226" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button225" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button224" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button222" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button223" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/> 

        </div>

        <br />
<div style=" border: thin solid #000000; background-color:Red; margin-left:27px;" class="style5">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label32" runat="server" Text="B8"></asp:Label>
     </div>
        <div style="margin-left: 80px; margin-top: -55px;" class="style28">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button241" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button241_Click"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button240" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button240_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button239" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button239_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button238" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button238_Click"/>  
&nbsp;&nbsp;
            <asp:Button ID="Button237" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button237_Click"/>
           <br />
           <br />
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button236" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button236_Click"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button235" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button235_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button234" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button234_Click"/>
&nbsp;&nbsp;
            <asp:Button ID="Button233" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button233_Click"/>  
&nbsp;&nbsp;
            <asp:Button ID="Button232" runat="server" Text="" 
                style="background-color:#86ECCA; text-align:center;"  Width="80px" 
                onclick="Button232_Click"/>

        </div>

        <div style="margin-left: 650px; margin-top: -55px;" class="style27">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button217" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button218" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button219" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button220" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/> 
&nbsp;&nbsp;
            <asp:Button ID="Button221" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
           <br />
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button216" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
            &nbsp;&nbsp;
            <asp:Button ID="Button215" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button214" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button213" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>
&nbsp;&nbsp;
            <asp:Button ID="Button212" runat="server" Text="" style="background-color:#86ECCA; text-align:center;"  Width="80px"/>

        </div>

        <br />
        

        <div style="width: 1017px; margin-left: 05px; margin-top:0px; height: 55px;">
        

        <div style="width: 383px; margin-left: 193px; height: 37px;">

        <telerik:RadDatePicker ID="RadDatePicker2" runat="server"></telerik:RadDatePicker>


        
        <!--  time picker-->
            
            <div id="Div2" class="RadPicker RadPicker_Default " style="width: 45px; margin-left: -52px; margin-top: 10px; border-top-width: 0px;">
             <span id="Label35">From</span>
             </div>


        <div id="RadTimePicker1_wrapper" class="RadPicker RadPicker_Default " style="width: 110px; margin-left: 0px; margin-top: -22px;">
       

            <telerik:RadTimePicker ID="RadTimePicker1" runat="server">
            </telerik:RadTimePicker>
        </div>

        <div id="Div3" class="RadPicker RadPicker_Default " style="width: 45px; margin-left: 113px; margin-top: -22px; border-top-width: 0px;">
              <asp:Label ID="Label36" runat="server" Text="To"></asp:Label>
        </div>


    <div id="Div1" class="RadPicker RadPicker_Default " style="width: 110px; margin-left: 140px; margin-top: -21px;">

        <telerik:RadTimePicker ID="RadTimePicker3" runat="server">
</telerik:RadTimePicker>
</div>



<br />
<br />
<%--<telerik:RadButton ID="RadButton1" runat="server" AutoPostBack="false" Text="Get Date and Time" OnClientClicked="OnClientClicked">

</telerik:RadButton>--%>

        </div>

        <div style="width: 381px; margin-left: 705px; height: 46px; margin-top: -37px;">
        <telerik:RadDatePicker ID="RadDatePicker1" runat="server"></telerik:RadDatePicker>

        <div id="Div4" class="RadPicker RadPicker_Default " style="width: 45px; margin-left: -52px; margin-top: 10px; border-top-width: 0px;">
             <span id="Span1">From</span>
             </div>

            <div id="RadTimePicker2_wrapper" class="RadPicker RadPicker_Default " style="width: 110px; margin-left: 0px; margin-top: -24px;">



            <telerik:RadTimePicker ID="RadTimePicker2" runat="server">
            </telerik:RadTimePicker>
        </div>

            <div id="Div5" class="RadPicker RadPicker_Default " style="width: 45px; margin-left: 113px; margin-top: -22px; border-top-width: 0px;">
              <asp:Label ID="Label37" runat="server" Text="To"></asp:Label>
            </div>

             <div id="Div6" class="RadPicker RadPicker_Default " style="width: 110px; margin-left: 140px; margin-top: -21px;">

        <telerik:RadTimePicker ID="RadTimePicker4" runat="server">
        </telerik:RadTimePicker>
        </div>

        </div>
              
        
        </div>
                


    
    </div>
    </form>
</body>
</html>

