<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copy of Schedule.aspx.cs" Inherits="Schedule" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">


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
    <style type="text/css">
        #form1
        {
            height: 1639px;
            width: 1253px;
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
   


    <div style="border: thin solid #000000; width: 506px; margin-left: 82px; height: 25px; background-color: #336699;">

    &nbsp;&nbsp;&nbsp;
      
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="WEEK1"></asp:Label>
        </div>

        <div style="border: thin solid #000000; width: 483px; margin-left: 594px; height: 25px; background-color: rgb(51, 102, 153); margin-top: -28px;">
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label2" runat="server" Text="WEEK2"></asp:Label>
        </div>
<%--&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Label ID="Label2" runat="server" Text="Week2"></asp:Label>--%>
        
        <div style="border: thin solid #000000; width: 505px; margin-left: 83px; height: 25px;">
           &nbsp;&nbsp;&nbsp;<span style="border-color: #000000;"> 
            <asp:Label ID="Label3" runat="server" Text="Mon" 
                style="border-bottom-color: #000000; border-color: #000000; font-size:25px; margin-left: 30px;"></asp:Label></span>
            &nbsp;&nbsp;&nbsp;<span> <asp:Label ID="Label4" runat="server" Text="Tue" style="font-size:25px; margin-left: 25px;"></asp:Label> </span>
            &nbsp;&nbsp;&nbsp;<span>&nbsp;&nbsp; <asp:Label ID="Label5" runat="server" Text="Wen" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
           &nbsp;&nbsp;&nbsp;<span>&nbsp;&nbsp; <asp:Label ID="Label6" runat="server" Text="Thu" style="font-size:25px;margin-left: 20px;"></asp:Label> </span>
            &nbsp;&nbsp; &nbsp;&nbsp;<span>&nbsp;&nbsp;&nbsp; <asp:Label ID="Label7" runat="server" Text="Fri" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
        </div>
        
    <div style="border: thin solid rgb(0, 0, 0); width: 484px; margin-left: 594px; height: 25px; margin-top: -27px;">
           &nbsp;&nbsp;&nbsp;<span> <asp:Label ID="Label8" runat="server" Text="Mon" style="font-size:25px; margin-left: 30px;"></asp:Label></span>
            &nbsp;&nbsp;&nbsp;<span> <asp:Label ID="Label9" runat="server" Text="Tue" style="font-size:25px; margin-left: 25px;"></asp:Label> </span>
            &nbsp;&nbsp;&nbsp;<span> <asp:Label ID="Label10" runat="server" Text="Wen" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
           &nbsp;&nbsp; &nbsp;&nbsp;<span> <asp:Label ID="Label11" runat="server" Text="Thu" style="font-size:25px;margin-left: 20px;"></asp:Label> </span>
            &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span><asp:Label ID="Label12" runat="server" Text="Fri" style="font-size:25px; margin-left: 20px;"></asp:Label> </span>
        </div>
        
    

 <%--<table style="height: 76px; width: 1218px">
    <tr>
    <td style="background-color:red;">
      <asp:Label ID="lbl_queue11" ForeColor="Black" runat="server" Text="A1" style="margin-left: 12px;"></asp:Label >
                 </td>
                 
                 </tr>
                  </table>--%>

   
      <br />
     <div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label13" runat="server" Text="A1"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label38" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label39" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label40" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label41" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label42" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           <br/>

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label43" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label44" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label45" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label46" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
             <asp:Label ID="Label47" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="Label48" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
             <asp:Label ID="Label49" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label50" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label51" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label52" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           <br/>

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label53" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label54" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label55" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label56" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label57" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
        </div>

        <div style="width: 46px; height: 43px; margin-left: 1091px; margin-top:-46px;">
        
        <asp:Label ID="Label33" runat="server" Text="AM"></asp:Label>
        <br />
        
        <asp:Label ID="Label34" runat="server" Text="PM"></asp:Label>
        </div>
        <br />
        



        <div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label14" runat="server" Text="A2"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label58" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label59" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label60" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label61" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label62" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Label ID="Label63" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label64" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label65" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
             <asp:Label ID="Label66" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>  
&nbsp;&nbsp;
             <asp:Label ID="Label67" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Label ID="Label68" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
             <asp:Label ID="Label69" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
             <asp:Label ID="Label70" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
             <asp:Label ID="Label71" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label72" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label73" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
            &nbsp;&nbsp;
            <asp:Label ID="Label74" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>

&nbsp;&nbsp;
            <asp:Label ID="Label75" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label76" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label77" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            

        </div>

        <br />
        <div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label15" runat="server" Text="A3"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label78" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label79" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label80" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label81" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label82" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Label ID="Label83" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>

            &nbsp;&nbsp;
            <asp:Label ID="Label84" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label85" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label86" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label87" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label88" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label89" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label90" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label91" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label92" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
           <br/>

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label93" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label94" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label95" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label96" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label97" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
          
        </div>

        <br />


        <div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label16" runat="server" Text="A4"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label98" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label99" runat="server" Text="WEEK2" style="background-color:#BDD391; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label100" runat="server" Text="WEEK2" style="background-color:#E62EB8; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label101" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label102" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label103" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
            <asp:Label ID="Label104" runat="server" Text="WEEK2" style="background-color:#B5DAFF; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label105" runat="server" Text="WEEK2" style="background-color:#C0C0C0; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
             <asp:Label ID="Label106" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label107" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label108" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label109" runat="server" Text="WEEK2" style="background-color:#BDD391; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label110" runat="server" Text="WEEK2" style="background-color:white; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label111" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label112" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label113" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
            <asp:Label ID="Label114" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label115" runat="server" Text="WEEK2" style="background-color:#C0C0C0; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label116" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label117" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
        </div>

   <br />


   <div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label17" runat="server" Text="A5"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label888" runat="server" Text="WEEK2"
                style="background-color:#B56CFF; width:80px;" >
                <%--onselectedindexchanged="Label81_SelectedIndexChanged"--%>
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label118" runat="server" Text="WEEK2" style="background-color:#BDD391; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label119" runat="server" Text="WEEK2" style="background-color:#E62EB8; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label120" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label121" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label122" runat="server" Text="WEEK2" style="background-color:#FFA500; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
             <asp:Label ID="Label123" runat="server" Text="WEEK2" style="background-color:#B5DAFF; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
             <asp:Label ID="Label124" runat="server" Text="WEEK2" style="background-color:#C0C0C0; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
             <asp:Label ID="Label125" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
             <asp:Label ID="Label126" runat="server" Text="WEEK2" style="background-color:White; width:80px;">
            </asp:Label>
            

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label127" runat="server" Text="WEEK2" style="background-color:#B56CFF; width:80px;">
            </asp:Label>
            <asp:Label ID="Label128" runat="server" Text="WEEK2" style="background-color:#B56CFF; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label1290" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label1300" runat="server" Text="WEEK2" style="background-color:white; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label1310" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label1320" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1330" runat="server" Text="WEEK2" style="background-color:#FFA500; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
            <asp:Label ID="Label1340" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label1350" runat="server" Text="WEEK2" style="background-color:#C0C0C0; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label1360" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label1370" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
        </div>

      <br />

      <div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label18" runat="server" Text="A6"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1380" runat="server" Text="WEEK2" style="background-color:MistyRose; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label1390" runat="server" Text="WEEK2" style="background-color:#BDD391; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label1400" runat="server" Text="WEEK2" style="background-color:#E62EB8; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label1410" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label142" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
           
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label143" runat="server" Text="WEEK2" style="background-color:White; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
            <asp:Label ID="Label144" runat="server" Text="WEEK2" style="background-color:#B5DAFF; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label145" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label146" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label147" runat="server" Text="WEEK2" style="background-color:#5F9EA0; width:80px;">
            </asp:Label>
            
        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label148" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label149" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
               <asp:Label ID="Label150" runat="server" Text="WEEK2" style="background-color:White; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label151" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label152" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label153" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
            <asp:Label ID="Label154" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label155" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label156" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label157" runat="server" Text="WEEK2" style="background-color:#5F9EA0; width:80px;">
            </asp:Label>
           

        </div>
        <br />

        <div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label19" runat="server" Text="A7"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label158" runat="server" Text="WEEK2" style="background-color:MistyRose; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label159" runat="server" Text="WEEK2" style="background-color:#BDD391; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
             <asp:Label ID="Label160" runat="server" Text="WEEK2" style="background-color:#E62EB8; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
             <asp:Label ID="Label161" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label162" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label163" runat="server" Text="WEEK2" style="background-color:white; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
            <asp:Label ID="Label164" runat="server" Text="WEEK2" style="background-color:#B5DAFF; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label165" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label166" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            
            <asp:Label ID="Label167" runat="server" Text="WEEK2" style="background-color:DodgerBlue; width:80px;">
            </asp:Label>
            

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label168" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label169" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
<asp:Label ID="Label170" runat="server" Text="WEEK2" style="background-color:white; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label171" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label172" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
           <asp:Label ID="Label173" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
            &nbsp;&nbsp;
            <asp:Label ID="Label174" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label175" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label176" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label177" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
        </div>

        <br />

        <div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label20" runat="server" Text="A8"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label178" runat="server" Text="WEEK2" style="background-color:MistyRose; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label179" runat="server" Text="WEEK2" style="background-color:#BDD391; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
             <asp:Label ID="Label180" runat="server" Text="WEEK2" style="background-color:#E62EB8; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label181" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label182" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label183" runat="server" Text="WEEK2" style="background-color:LightCoral; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
             <asp:Label ID="Label184" runat="server" Text="WEEK2" style="background-color:#B5DAFF; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
             <asp:Label ID="Label185" runat="server" Text="WEEK2" style="background-color:LightGoldenRodYellow; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            
             <asp:Label ID="Label186" runat="server" Text="WEEK2" style="background-color:#FFE4E1; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label187" runat="server" Text="WEEK2" style="background-color:DodgerBlue; width:80px;">
            </asp:Label>
           
        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label188" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
             <asp:Label ID="Label189" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
             <asp:Label ID="Label190" runat="server" Text="WEEK2" style="background-color:white; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            
              <asp:Label ID="Label191" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
 
            <asp:Label ID="Label192" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label193" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
             <asp:Label ID="Label194" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
             <asp:Label ID="Label195" runat="server" Text="WEEK2" style="background-color:LightGoldenRodYellow; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label196" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
             <asp:Label ID="Label197" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
        </div>

        <br />

<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label21" runat="server" Text="A9"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Label ID="Label198" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label199" runat="server" Text="WEEK2" style="background-color:#BDD391; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
<asp:Label ID="Label200" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
<asp:Label ID="Label201" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
<asp:Label ID="Label202" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label203" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
            <asp:Label ID="Label204" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
<asp:Label ID="Label205" runat="server" Text="WEEK2" style="background-color:#FFA500; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
<asp:Label ID="Label206" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label207" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label208" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label209" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label210" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label211" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;

            <asp:Label ID="Label212" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2130" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
            &nbsp;&nbsp;
            <asp:Label ID="Label2140" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label2150" runat="server" Text="WEEK2" style="background-color:#FFA500; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label2160" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label2170" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            

        </div>

        <br />

        <div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label22" runat="server" Text="A10"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2180" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label2190" runat="server" Text="WEEK2" style="background-color:#BDD391; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label2200" runat="server" Text="WEEK2" style="background-color:#B88A00; width:80px;">
            </asp:Label>
            
&nbsp;&nbsp;
            <asp:Label ID="Label2210" runat="server" Text="WEEK2" style="background-color:Yellow; width:80px;">
            </asp:Label>
           
&nbsp;&nbsp;
            <asp:Label ID="Label2220" runat="server" Text="WEEK2" style="background-color:Red; width:80px;">
            </asp:Label>
            
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2230" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label2240" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label2250" runat="server" style="background-color:#FFA500; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label2260" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label2270" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2280" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label2290" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label2300" runat="server" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label2310" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label2320" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2330" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label2340" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label2350" runat="server" style="background-color:#FFA500; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label2360" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label2370" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>


        </div>

        <br />

<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label2800" runat="server" Text="A11"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label129" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label130" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label131" runat="server" style="background-color:CornflowerBlue; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label132" runat="server" style="background-color:Aqua; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label133" runat="server" style="background-color:#DE8CA7; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label134" runat="server" style="background-color:#DE8CA7; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label135" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label136" runat="server" style="background-color:DarkGray; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label137" runat="server" style="background-color:#DE8CA7; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label138" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label139" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label140" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label213" runat="server" style="background-color:CornflowerBlue; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label214" runat="server" style="background-color:Aqua; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label215" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label216" runat="server" style="background-color:Fuchsia; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label217" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label218" runat="server" style="background-color:DarkGray; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label219" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label220" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>

        </div>

        <br />
<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label24" runat="server" Text="A12"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label221" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label222" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label223" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label224" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label225" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label226" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label227" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label228" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label229" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label230" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label231" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label232" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label233" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label234" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label235" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label236" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label237" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label238" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label239" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label240" runat="server" style="background-color:Cyan; width:80px;">
            </asp:Label>

        </div>

        <br />

<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label25" runat="server" Text="B1"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label241" runat="server" style="background-color:Yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label242" runat="server" style="background-color:Yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label243" runat="server" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label244" runat="server" style="background-color:Yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label245" runat="server" style="background-color:#B56CFF; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label246" runat="server" style="background-color:#B56CFF; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label247" runat="server" style="background-color:#DE8CA7 ; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label248" runat="server" style="background-color:Yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label249" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label250" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label251" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label252" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label253" runat="server" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label254" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label255" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label256" runat="server" style="background-color:#B56CFF; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label257" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label258" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label259" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label260" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>

        </div>

        <br />

<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label26" runat="server" Text="B2"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label261" runat="server" 
                style="background-color:yellow; width:80px;"> 
               <%-- onselectedindexchanged="Label261_SelectedIndexChanged"--%>
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label262" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label263" runat="server" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label264" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label265" runat="server" style="background-color:white; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label266" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label267" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label268" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label269" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label270" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label271" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label272" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label273" runat="server" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label274" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label275" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label276" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label277" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label278" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label279" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label280" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>

        </div>

        <br />

<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label27" runat="server" Text="B3"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label281" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label282" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label283" runat="server" style="background-color:ForestGreen; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label284" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label285" runat="server" style="background-color:white; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label286" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label287" runat="server" style="background-color:DodgerBlue ; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label288" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label289" runat="server" style="background-color:Coral; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label290" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label291" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label292" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label293" runat="server" style="background-color:ForestGreen; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label294" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label295" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label296" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label297" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label298" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label299" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label300" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>

        </div>
        <br />
<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label28" runat="server" Text="B4"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label301" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label302" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label303" runat="server" style="background-color:ForestGreen; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label304" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label305" runat="server" style="background-color:white; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label306" runat="server" style="background-color:Yellow; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label307" runat="server" style="background-color:DodgerBlue ; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label308" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label309" runat="server" style="background-color:Coral; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label310" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label311" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label312" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label313" runat="server" style="background-color:ForestGreen; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label314" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label315" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label316" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label317" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label318" runat="server" style="background-color:Yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label319" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label320" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>

        </div>
        <br />

<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label29" runat="server" Text="B5"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label321" runat="server" 
                style="background-color:Yellow; width:80px;" >
                <%--onselectedindexchanged="Label321_SelectedIndexChanged"--%>
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label322" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label323" runat="server" style="background-color:Lavender; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label324" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label325" runat="server" style="background-color:white; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label326" runat="server" style="background-color:Yellow; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label327" runat="server" style="background-color:#B56CFF; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label328" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label329" runat="server" style="background-color:#B56CFF; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label330" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label331" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label332" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label333" runat="server" style="background-color:Lavender; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label334" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label335" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label336" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label337" runat="server" style="background-color:#B56CFF; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label338" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label339" runat="server" style="background-color:#B56CFF; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label340" runat="server" style="background-color:Red; width:80px;">
            </asp:Label>

        </div>
        <br />

<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label30" runat="server" Text="B6"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label341" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label342" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label343" runat="server" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label344" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label345" runat="server" style="background-color:white; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label346" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label347" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label348" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label349" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label350" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label351" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label352" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label353" runat="server" style="background-color:#B88A00; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label354" runat="server" style="background-color:Yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label355" runat="server" style="background-color:Yellow; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label356" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label357" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label358" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label359" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label360" runat="server" style="background-color:yellow; width:80px;">
            </asp:Label>

        </div>
        <br />

<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label31" runat="server" Text="B7"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label361" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label362" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label363" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label364" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label365" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label366" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label367" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label368" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label369" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label370" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label371" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label372" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label373" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label374" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label375" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label376" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label377" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label378" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label379" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label380" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>

        </div>

        <br />
<div style="width: 50px; height: 45px; background-color:Red; margin-left:27px;">
     <br />
    &nbsp;&nbsp; <asp:Label ID="Label32" runat="server" Text="B8"></asp:Label>
     </div>
        <div style="width: 495px; margin-left: 80px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label381" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label382" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label383" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label384" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label385" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label386" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label387" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label388" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label389" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label390" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>

        </div>

        <div style="width: 495px; margin-left: 585px; margin-top: -50px;">

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label391" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label392" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label393" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label394" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label395" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
           <br />

           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label396" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="Label397" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label398" runat="server" style="background-color:#86ECCA;  width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label399" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>
&nbsp;&nbsp;
            <asp:Label ID="Label400" runat="server" style="background-color:#86ECCA; width:80px;">
            </asp:Label>

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
