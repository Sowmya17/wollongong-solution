<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMember.aspx.cs" Inherits="AddMember" %>

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
        <asp:GridView ID="grdaddmember" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#61A6F8"
            ShowFooter="true" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
            DataKeyNames="members_id,relation_desc" OnRowDataBound="grdaddmember_RowDataBound"
            BackColor="White" OnRowCancelingEdit="grdaddmember_RowCancelingEdit" OnRowCommand="grdaddmember_RowCommand"
            OnRowEditing="grdaddmember_RowEditing" 
            OnRowUpdating="grdaddmember_RowUpdating" 
            onselectedindexchanged="grdaddmember_SelectedIndexChanged">
            <Columns>
                <asp:TemplateField HeaderText="First name" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_firstname" runat="server" Text='<%#Eval("members_firstname") %>' />
                        <asp:RequiredFieldValidator ID="rfvfname1" runat="server" ControlToValidate="txt_firstname"
                            Text="*" ValidationGroup="validaiton1" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_firstname" runat="server" Text='<%#Eval("members_firstname") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt_fname" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvfname" runat="server" ControlToValidate="txt_fname"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_lastname" runat="server" Text='<%#Eval("members_lastname") %>' />
                        <asp:RequiredFieldValidator ID="rfvlname1" runat="server" ControlToValidate="txt_lastname"
                            Text="*" ValidationGroup="validaiton1" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_lastname" runat="server" Text='<%#Eval("members_lastname") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt_lname" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvlname" runat="server" ControlToValidate="txt_lname"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_gender" runat="server">
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_gender" runat="server" Text='<%#Eval("members_gender") %>' />
                        <asp:HiddenField ID="hi_gender" runat="server" Value='<%# Eval("members_gender1")%>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddl_ngender" runat="server">
                            <asp:ListItem Text="Female" Value="F"></asp:ListItem>
                            <asp:ListItem Text="Male" Value="M"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvgender" runat="server" ControlToValidate="ddl_ngender"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Date of Birth" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <%--<asp:TextBox ID="txt_age" runat="server" Text='<%#Eval("members_dob") %>' />--%>
                        <%--<asp:RequiredFieldValidator ID="rfvage1" runat="server" ControlToValidate="txt_age"
                            Text="*" ValidationGroup="validaiton1" />--%>
                        <%--<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>--%>
                        <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                            <ContentTemplate>
                                <telerik:RadDatePicker ID="RadDatePicker1" runat="server">
                                </telerik:RadDatePicker>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_age" runat="server" Text='<%#Eval("members_dob") %>' />

                    </ItemTemplate>
                    <FooterTemplate>
                        <%--<asp:TextBox ID="txt_nage" runat="server" />--%>
                        <%--<asp:RequiredFieldValidator ID="rfvage" runat="server" ControlToValidate="txt_nage"
                            Text="*" ValidationGroup="validaiton" />--%>
                            <asp:UpdatePanel ID="UpdatePanel26" runat="server">
                            <ContentTemplate>
                                <telerik:RadDatePicker ID="RadDatePicker2" runat="server">
                                </telerik:RadDatePicker>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Relationship" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_relation" runat="server" DataTextField="relation_desc"
                            DataValueField="relation_id">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_relationship" runat="server" Text='<%# Eval("relation_desc")%>' />
                        <asp:HiddenField ID="hi_relation" runat="server" Value='<%# Eval("relation_id")%>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddl_nrelation" runat="server" DataTextField="relation_desc"
                            DataValueField="relation_id">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvrelation" runat="server" ControlToValidate="ddl_nrelation"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Mobile Number" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_mobile" runat="server" Text='<%#Eval("members_mobile") %>' />
                        <asp:RequiredFieldValidator ID="rfvmobile1" runat="server" ControlToValidate="txt_firstname"
                            Text="*" ValidationGroup="validaiton1" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_mobile" runat="server" Text='<%#Eval("members_mobile") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt_mobile" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvmobile" runat="server" ControlToValidate="txt_mobile"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_email" runat="server" Text='<%#Eval("members_email") %>' />
                        <asp:RequiredFieldValidator ID="rfvfemail1" runat="server" ControlToValidate="txt_email"
                            Text="*" ValidationGroup="validaiton1" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lbl_email" runat="server" Text='<%#Eval("members_email") %>' />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txt_email" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvfemail" runat="server" ControlToValidate="txt_email"
                            Text="*" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                    <EditItemTemplate>
                        <asp:ImageButton ID="imgbtnUpdate" CommandName="Update" runat="server" ImageUrl="~/images/update.jpg"
                            ToolTip="Update" Height="30px" Width="30px" ValidationGroup="validaiton1" />
                        <asp:ImageButton ID="imgbtnCancel" runat="server" CommandName="Cancel" ImageUrl="~/images/Cancel.jpg"
                            ToolTip="Cancel" Height="30px" Width="30px" />
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgbtnEdit" CommandName="Edit" runat="server" ImageUrl="~/images/Edit.jpg"
                            ToolTip="Edit" Height="30px" Width="30px" />
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:ImageButton ID="imgbtnAdd" runat="server" ImageUrl="~/images/AddNewitem.jpg"
                            CommandName="AddNew" Width="40px" Height="40px" ToolTip="Add new User" ValidationGroup="validaiton" />
                    </FooterTemplate>
                </asp:TemplateField>
                            </Columns>
            <HeaderStyle BackColor="#61A6F8" Font-Bold="True" ForeColor="White"></HeaderStyle>
        </asp:GridView>
    </div>
    <div>
        <asp:Label ID="lbl_msg" runat="server" ForeColor="Green" Visible="False"></asp:Label>
    </div>
    </form>
</body>
</html>
