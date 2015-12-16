using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;

public partial class DepartmentMaster : System.Web.UI.Page
{
    // Initiallizing Variables

    #region Initiallizing Variables

    MasterBAL masterbal = new MasterBAL();
    MasterBEL masterbel = new MasterBEL();

    string DepartmentInsert, DepartmentUpdate;

    #endregion Intialling Variables

    // Department Master - Page Loading

    #region Department Master - Page Loading

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DepartmentBindGrid();

            btn_departmentnew.Enabled = true;
            btn_departmentedit.Enabled = false;
            btn_departmentsave.Enabled = true;

            Label4.Text = DateTime.Now.ToLongDateString();
            lbl_clientip.Text = GetIP();
            lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
            lbl_userna.Text = Session["uname"].ToString();
          
            Label2.Text = Session["terdesc"].ToString();
            Label5.Text = Session["dd"].ToString();
        }
    }

    #endregion Department Master - Page Loading

    // Department Master - Getting IP Address

    #region Department Master - Getting IP Address

    private string GetIP()
    {
        string strHostName = "";
        strHostName = System.Net.Dns.GetHostName();

        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

        IPAddress[] addr = ipEntry.AddressList;

        if (addr.Length == 6)
        {
            return addr[addr.Length - 3].ToString();
        }
        else
        {
            return addr[addr.Length - 2].ToString();
        }

    }

    #endregion Department Master - Getting Ip Address

    // Department Master - Save Button Click

    #region Department Master - Save Button Click

    protected void btn_departmentsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbl_departmentmaster.Text == "N")
            {
                if (txt_departmentdescription.Text != "" && txt_departmentcode.Text != "")
                {
                    masterbel.DepartmentDescriptions = txt_departmentdescription.Text;
                    masterbel.DepartmentCode = txt_departmentcode.Text;
                    masterbel.DepartmentUpdatedDateTime = DateTime.Now;
                    masterbel.DepartmentUpdatedBy = "Admin";
                    masterbel.DepartmentQueueNo = 0;

                    DepartmentInsert = masterbal.DepartmentInsert(masterbel);

                    if (DepartmentInsert != string.Empty)
                    {
                        lbl_departmentmessage.Text = "Records Inserted Successfully";

                        txt_departmentdescription.Text = "";
                        txt_departmentcode.Text = "";

                        //txt_departmentcode.ForeColor = System.Drawing.Color.Gray;
                        //txt_departmentdescription.ForeColor = System.Drawing.Color.Gray;
                        
                        //txt_departmentcode.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
                        //txt_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

                        lbl_departmentmessage.Visible = true;

                        gv_departmentmaster.SelectedIndex = -1;

                        DepartmentBindGrid();

                        //vs_departmentmaster.ShowSummary = false;
                    }
                    else
                    {
                        lbl_departmentmessage.Text = "User Name [<b>" + txt_departmentdescription.Text + "</b>] already exists, try another name";
                    }

                }



                else
                {
                    //if (txt_departmentcode.Text == "Department Code")
                    //{
                    //    txt_departmentcode.BorderColor = System.Drawing.Color.Red;
                    //}
                    //else
                    //{
                    //    txt_departmentcode.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

                    //    txt_departmentcode.ForeColor = System.Drawing.Color.Black;
                    //}

                    //if (txt_departmentdescription.Text == "Department Description")
                    //{
                    //    txt_departmentdescription.BorderColor = System.Drawing.Color.Red;
                    //}
                    //else
                    //{
                    //    txt_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

                    //    txt_departmentdescription.ForeColor = System.Drawing.Color.Black;
                    //}

                    if (txt_departmentcode.Text == "" || txt_departmentdescription.Text == "")
                    {
                        lbl_departmentmessage.Visible = false;
                    }
                }
                //vs_departmentmaster.ShowSummary = true;

            }
            if (lbl_departmentmaster.Text == "E")
            {

                if (txt_departmentdescription.Text != "" && txt_departmentcode.Text != "")
                {
                    masterbel.DepartmentId = Convert.ToInt16(lbl_departmentid.Text);
                    masterbel.DepartmentDescriptions = txt_departmentdescription.Text;
                    masterbel.DepartmentCode = txt_departmentcode.Text;
                    masterbel.DepartmentUpdatedDateTime = DateTime.Now;
                    masterbel.DepartmentUpdatedBy = "Admin";
                    masterbel.DepartmentQueueNo = 0;

                    DepartmentUpdate = masterbal.DepartmentUpdate(masterbel);

                    if (DepartmentUpdate != string.Empty)
                    {
                        lbl_departmentmessage.Text = "Records Updated Successfully";

                        txt_departmentdescription.Text = "";
                        txt_departmentcode.Text = "";

                        //txt_departmentcode.ForeColor = System.Drawing.Color.Gray;
                        //txt_departmentdescription.ForeColor = System.Drawing.Color.Gray;

                        //txt_departmentcode.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
                        //txt_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

                        lbl_departmentmessage.Visible = true;

                        gv_departmentmaster.SelectedIndex = -1;

                        DepartmentBindGrid();

                        lbl_departmentmaster.Text = "N";

                        //vs_departmentmaster.ShowSummary = false;
                    }
                    else
                    {
                        lbl_departmentmessage.Text = "User Name [<b>" + txt_departmentdescription.Text + "</b>] already exists, try another name";
                    }

                }
                else
                {
                    //if (txt_departmentcode.Text == "Department Code")
                    //{
                    //    txt_departmentcode.BorderColor = System.Drawing.Color.Red;
                    //}
                    //else
                    //{
                    //    txt_departmentcode.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
                    //}

                    //if (txt_departmentdescription.Text == "Department Description")
                    //{
                    //    txt_departmentdescription.BorderColor = System.Drawing.Color.Red;
                    //}
                    //else
                    //{
                    //    txt_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
                    //}

                    if (txt_departmentcode.Text == "" || txt_departmentdescription.Text == "")
                    {
                        lbl_departmentmessage.Visible = false;
                    }
                }
            }
                        
            //vs_departmentmaster.ShowSummary = true;
        }
        catch
        {
            throw;
        }
        finally
        {
            masterbal = null;
            masterbel = null;
        }
    }

    #endregion Department Master - Save Button Click

    // Department Master - Grid View Loading

    #region Department Master - Grid View Loading

    public void DepartmentBindGrid()
    {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();
        try
        {
            //Intializing Data Table
            DataTable MyDepartmentGridViewBind = new DataTable();

            //MyDeviceGridViewBind = null;

            //if(MyDeviceGridViewBind !=null)
            //{

            MyDepartmentGridViewBind = masterbal.DepartmentGridViewLoading(masterbel);

            //}

            gv_departmentmaster.AutoGenerateColumns = false;


            gv_departmentmaster.DataSource = MyDepartmentGridViewBind;
            gv_departmentmaster.DataBind();

            //MyDeviceGridViewBind = null;

        }
        catch
        {
            throw;
        }
        finally
        {

        }

    }

    #endregion Department Master - Grid View Loading

    // Department Master - Grid View Selected Index Changed

    #region Department Master - Grid View Selected Index Changed

    protected void gv_departmentmaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow Row = gv_departmentmaster.SelectedRow;

        lbl_departmentid.Text = Row.Cells[0].Text;
        
        txt_departmentcode.Text = Row.Cells[1].Text;
        txt_departmentdescription.Text = Row.Cells[2].Text;
        
        txt_departmentdescription.Enabled = false;
        txt_departmentcode.Enabled = false;

        btn_departmentedit.Enabled = true;
        btn_departmentnew.Enabled = true;
        btn_departmentsave.Enabled = false;

        //txt_departmentcode.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        
    }

    #endregion Department Master - Grid View Selected Index Changed

    // Department Master - Edit Button Click

    #region Department Master - Edit Button Click

    protected void btn_departmentedit_Click(object sender, EventArgs e)
    {
        txt_departmentdescription.Enabled = true;
        txt_departmentcode.Enabled = true;

        //txt_departmentcode.ForeColor = System.Drawing.Color.Black;
        //txt_departmentdescription.ForeColor = System.Drawing.Color.Black;

        btn_departmentedit.Enabled = false;
        btn_departmentnew.Enabled = true;
        btn_departmentsave.Enabled = true;
        
        lbl_departmentmaster.Text = "E";
    }

    #endregion Department Master - Edit Button Click

    // Department Master - New Button Click

    #region Department Master - New Button Click


    protected void btn_departmentnew_Click(object sender, EventArgs e)
    {
        txt_departmentdescription.Text = "";
        txt_departmentcode.Text = "";

        //txt_departmentcode.ForeColor = System.Drawing.Color.Gray;
        //txt_departmentdescription.ForeColor = System.Drawing.Color.Gray;

        //txt_departmentdescription.BorderColor = System.Drawing.Color.Aqua;

        txt_departmentdescription.Enabled = true;
        txt_departmentcode.Enabled = true;

        btn_departmentsave.Enabled = true;
        btn_departmentnew.Enabled = true;
        btn_departmentedit.Enabled = false;

        lbl_departmentmaster.Text = "N";

        lbl_departmentmessage.Visible = false;

        //txt_departmentcode.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

        gv_departmentmaster.SelectedIndex = -1;

        //vs_departmentmaster.Visible = false;
        
    }

    #endregion Department Master - New Button Click

    // Department Master - New Button Click

    #region Department Master - Page Index Changing

    protected void gv_departmentmaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_departmentmaster.PageIndex = e.NewPageIndex;
        //gv_usermaster.DataSource = (DataTable)Cache["Data"];
        gv_departmentmaster.DataBind();

        DepartmentBindGrid();
    }

    #endregion Department Master - Page Index Changing


}