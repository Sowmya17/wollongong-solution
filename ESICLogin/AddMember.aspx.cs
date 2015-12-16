using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;
using System.Data;

public partial class AddMember : System.Web.UI.Page
{
    private CRTBEL crtview;
    private CRTBAL crtcntrl;
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public string esicno, terminaluser;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            esicno = Session["esicno"].ToString();


            terminaluser = Session["User"].ToString();
            //this.RadDatePicker1.MinDate = Convert.ToDateTime("1940-01-01 00:00:00.000");
            //this.RadDatePicker1.MaxDate = DateTime.Today;

            BindMemberData();
        }

        if (esicno == Convert.ToString(0))
        {
            grdaddmember.Visible = false;
            lbl_msg.Text = "No Records Found";
            lbl_msg.Visible = true;
        }
        if (esicno != Convert.ToString(0))
        {
            grdaddmember.Visible = true;
            lbl_msg.Visible = false;
        }

        //lbl_msg.Visible = false;

    }
    private void BindMemberData()
    {
        DataTable dtbl = new DataTable();
        //this.RadDatePicker2.MinDate = Convert.ToDateTime("1940-01-01 00:00:00.000");
        //this.RadDatePicker2.SelectedDate = RadDatePicker1.SelectedDate;
        try
        {
            crtcntrl = new CRTBAL();


            dtbl = crtcntrl.GetMemberDetail(Session["esicno"].ToString());
            DataColumn did = new DataColumn("members_gender1", typeof(string));
            dtbl.Columns.Add(did);
            if (dtbl.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbl.Rows)
                {
                    if (dr["members_gender"].ToString() == "F")
                    {
                        dr["members_gender"] = "Female";
                        dr["members_gender1"] = "F";
                    }
                    else if (dr["members_gender"].ToString() == "M")
                    {
                        dr["members_gender"] = "Male";
                        dr["members_gender1"] = "M";
                    }
                }
                grdaddmember.DataSource = dtbl;
                grdaddmember.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                grdaddmember.DataSource = dtbl;
                grdaddmember.DataBind();
                int columncount = grdaddmember.Rows[0].Cells.Count;
                grdaddmember.Rows[0].Cells.Clear();
                grdaddmember.Rows[0].Cells.Add(new TableCell());
                grdaddmember.Rows[0].Cells[0].ColumnSpan = columncount;
                grdaddmember.Rows[0].Cells[0].Text = "No Records Found";
            }

        }
        catch (Exception ex)
        {
            throw new Exception("Problem in Loading data", ex);
        }
        finally
        {
            dtbl = null;
            crtcntrl = null;
        }
    }
    protected void grdaddmember_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable dtbl = new DataTable();
        try
        {

            DataColumn did = new DataColumn("relation_id", typeof(System.Int32));
            dtbl.Columns.Add(did);
            DataColumn name = new DataColumn("relation_desc", typeof(string));
            dtbl.Columns.Add(name);
            DataRow row = null;



            if (e.Row.RowType == DataControlRowType.Footer)
            {

                DropDownList bind_dropdownlist = (DropDownList)e.Row.FindControl("ddl_nrelation");
                DataTable dtblrelation = new DataTable();
                if (bind_dropdownlist != null)
                {
                    crtcntrl = new CRTBAL();
                    dtblrelation = crtcntrl.GetRelationDetail();
                    if (dtblrelation.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtblrelation.Rows)
                        {
                            string relationname = myTI.ToTitleCase(dr["relation_desc"].ToString());
                            int relationid = Int32.Parse(dr["relation_id"].ToString());

                            row = dtbl.NewRow();

                            row["relation_id"] = relationid;

                            row["relation_desc"] = relationname;

                            dtbl.Rows.Add(row);
                        }
                        bind_dropdownlist.DataSource = dtbl;
                        bind_dropdownlist.DataTextField = "relation_desc";
                        bind_dropdownlist.DataValueField = "relation_id";
                        bind_dropdownlist.DataBind();
                    }

                }
            }

            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList bind_dropdownlist = (DropDownList)e.Row.FindControl("ddl_relation");
                DropDownList bind_gender = (DropDownList)e.Row.FindControl("ddl_gender");

                DataTable dtblrelation = new DataTable();
                if (bind_dropdownlist != null)
                {
                    crtcntrl = new CRTBAL();
                    dtblrelation = crtcntrl.GetRelationDetail();
                    if (dtblrelation.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtblrelation.Rows)
                        {
                            string relationname = myTI.ToTitleCase(dr["relation_desc"].ToString());
                            int relationid = Int32.Parse(dr["relation_id"].ToString());

                            row = dtbl.NewRow();

                            row["relation_id"] = relationid;

                            row["relation_desc"] = relationname;

                            dtbl.Rows.Add(row);
                        }
                        bind_dropdownlist.DataSource = dtbl;
                        bind_dropdownlist.DataTextField = "relation_desc";
                        bind_dropdownlist.DataValueField = "relation_id";
                        bind_dropdownlist.DataBind();
                        bind_dropdownlist.SelectedValue = Session["Hirelation"].ToString();
                        bind_gender.SelectedValue = Session["Higender"].ToString();
                    }

                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in Show data", ex);
        }
        finally
        {
            dtbl = null;
            crtcntrl = null;
        }
    }
    protected void grdaddmember_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grdaddmember.EditIndex = -1;
        BindMemberData();
    }
    protected void grdaddmember_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grdaddmember.EditIndex = e.NewEditIndex;
        int i = e.NewEditIndex;
        HiddenField Hirelation = (HiddenField)grdaddmember.Rows[i].FindControl("hi_relation");
        Session["Hirelation"] = Hirelation.Value;
        HiddenField Higender = (HiddenField)grdaddmember.Rows[i].FindControl("hi_gender");
        Session["Higender"] = Higender.Value;
        BindMemberData();
    }
    protected void grdaddmember_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        crtview = new CRTBEL();
        crtcntrl = new CRTBAL();
        string insertsucess = string.Empty;
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                this.RadDatePicker2.MinDate = Convert.ToDateTime("1940-01-01 00:00:00.000");
                //  this.RadDatePicker2.SelectedDate = RadDatePicker2.SelectedDate;
                TextBox txtfirstname = (TextBox)grdaddmember.FooterRow.FindControl("txt_fname");
                TextBox txtlastname = (TextBox)grdaddmember.FooterRow.FindControl("txt_lname");
                TextBox txtage = (TextBox)grdaddmember.FooterRow.FindControl("txt_age");
                DropDownList ddlgender = (DropDownList)grdaddmember.FooterRow.FindControl("ddl_ngender");
                DropDownList ddlrelation = (DropDownList)grdaddmember.FooterRow.FindControl("ddl_nrelation");
                TextBox txtmobile = (TextBox)grdaddmember.FooterRow.FindControl("txt_mobile");
                TextBox txtemail = (TextBox)grdaddmember.FooterRow.FindControl("txt_email");

                crtview.MemberFirstName = txtfirstname.Text;
                crtview.MemberLastName = txtlastname.Text;
                crtview.Dob = Convert.ToDateTime(RadDatePicker2.SelectedDate);
                crtview.MemberGender = Convert.ToChar(ddlgender.SelectedValue);
                crtview.MemberRelationId = Convert.ToInt16(ddlrelation.SelectedValue);
                //crtview.CusPhoneNo = Convert.ToInt64(txtmobile.Text);
                crtview.CusPhoneNo = txtmobile.Text;
                crtview.Email = txtemail.Text;
                crtview.ESCInNumber = Session["esicno"].ToString();
                crtview.TerminalUser = Session["User"].ToString();
                DateTime today = new DateTime();
                crtview.CusAge = (today.Year - crtview.Dob.Year);

                insertsucess = crtcntrl.AddMemberDetails(crtview);
                if (insertsucess == "0")
                {
                    // RetriveCustomerInfo();
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "Patient Information Added Successfully !!!";
                    BindMemberData();
                }
                else
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "Patient Information Not Added";
                }



            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in storing data", ex);
        }
        finally
        {
            insertsucess = string.Empty;
        }

    }
    protected void grdaddmember_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        crtview = new CRTBEL();
        crtcntrl = new CRTBAL();
        string updatesucess = string.Empty;
        try
        {
            this.RadDatePicker1.MinDate = Convert.ToDateTime("1940-01-01 00:00:00.000");
            this.RadDatePicker1.SelectedDate = RadDatePicker1.SelectedDate;
            int memberid = Convert.ToInt32(grdaddmember.DataKeys[e.RowIndex].Value.ToString());
            TextBox txtfirstname = (TextBox)grdaddmember.Rows[e.RowIndex].FindControl("txt_firstname");
            TextBox txtlastname = (TextBox)grdaddmember.Rows[e.RowIndex].FindControl("txt_lastname");
            TextBox txtage = (TextBox)grdaddmember.Rows[e.RowIndex].FindControl("txt_age");
            DropDownList ddlgender = (DropDownList)grdaddmember.Rows[e.RowIndex].FindControl("ddl_gender");
            DropDownList ddlrelation = (DropDownList)grdaddmember.Rows[e.RowIndex].FindControl("ddl_relation");
            TextBox txtmobile = (TextBox)grdaddmember.Rows[e.RowIndex].FindControl("txt_mobile");
            TextBox txtemail = (TextBox)grdaddmember.Rows[e.RowIndex].FindControl("txt_email");

            crtview.MemberFirstName = txtfirstname.Text;
            crtview.MemberLastName = txtlastname.Text;
            crtview.Dob = Convert.ToDateTime(RadDatePicker1.SelectedDate);
            crtview.MemberGender = Convert.ToChar(ddlgender.SelectedValue);
            crtview.MemberRelationId = Convert.ToInt16(ddlrelation.SelectedValue);
           // crtview.CusPhoneNo = Convert.ToInt64( txtmobile.Text);
            crtview.CusPhoneNo = txtmobile.Text;
            crtview.Email = txtemail.Text;
            crtview.MemberId = memberid;
            crtview.ESCInNumber = Session["esicno"].ToString();
            crtview.TerminalUser = Session["User"].ToString();

            updatesucess = crtcntrl.UpdateMemberDetails(crtview);
            if (updatesucess == "0")
            {
                // RetriveCustomerInfo();
                lbl_msg.Visible = true;
                lbl_msg.Text = "Patient Information Updated Successfully !!!";
                grdaddmember.EditIndex = -1;
                BindMemberData();
            }
            else
            {
                lbl_msg.Visible = true;
                lbl_msg.Text = "Patient Information Not Updated";
            }




        }
        catch (Exception ex)
        {
            throw new Exception("Problem in storing data", ex);
        }
        finally
        {
            updatesucess = string.Empty;
        }
    }
    protected void grdaddmember_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}