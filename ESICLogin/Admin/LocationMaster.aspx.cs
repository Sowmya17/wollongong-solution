using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;
using System.Text;
using System.Net;

public partial class LocationMaster : System.Web.UI.Page
{

    // Intiallizing Variables

    #region Intiallizing Variables

    TextInfo TextInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

    public ArrayList departmentdescription = new ArrayList();
    public ArrayList LocationDepartmentSelection = new ArrayList();

    MasterBAL masterbal = new MasterBAL();
    MasterBEL masterbel = new MasterBEL();

    string LocationInsert, LocationUpdate;

    #endregion Intiallizing Variables

    // Location Master - Page Loading

    #region Location Master - Page Loading

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

             // Department Description Combo Box

                DataTable MyLocationDepartment = new DataTable();

                 MyLocationDepartment = masterbal.GetDepartmentDescription();


                 //departmentdescription.Add(new AddValue("Select", 0));

                 LocationDepartmentSelection.Add(new AddValue("ALL", 0));


                 foreach (DataRow dr in MyLocationDepartment.Rows)
                 {
                     string Department_Description_Bind = dr["department_desc"].ToString();
                     long Department_id = Int32.Parse(dr["department_id"].ToString());

                     departmentdescription.Add(new AddValue(Department_Description_Bind, Department_id));
                     LocationDepartmentSelection.Add(new AddValue(Department_Description_Bind, Department_id));

                 }

                 //// Loading Data To Data Source
                 ddl_departmentdescription.DataSource = departmentdescription;
                 ddl_departmentdescription.DataTextField = "Display";
                 ddl_departmentdescription.DataValueField = "Value";
                 ddl_departmentdescription.DataBind();

                 ddl_locationdepartmentselection.DataSource = LocationDepartmentSelection;
                 ddl_locationdepartmentselection.DataTextField = "Display";
                 ddl_locationdepartmentselection.DataValueField = "Value";
                 ddl_locationdepartmentselection.DataBind();

                 //lbl_locationdepartmentid.Text = Convert.ToString(ddl_departmentdescription.SelectedValue);
                 //ddl_departmentdescription.SelectedIndex = 4;

                 lbl_locationdepartmentid.Text = Convert.ToString(ddl_locationdepartmentselection.SelectedValue);

                 //LocationBindGrid();

                 btn_locationedit.Enabled = false;

                 //gv_locationmaster.Columns[4].Visible = false;
           
             }
             catch (Exception ex)
             {
                 throw ex;
             }
             finally
             {
                 masterbel = null;
                 masterbal = null;
             }

            lbl_locationdepartmentid.Text = Session["did"].ToString();

            ddl_locationdepartmentselection.SelectedValue = lbl_locationdepartmentid.Text;

            LocationBindGrid(); 
            Label4.Text = DateTime.Now.ToLongDateString();
            lbl_clientip.Text = GetIP();
            lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
            lbl_userna.Text = Session["uname"].ToString();

            Label2.Text = Session["terdesc"].ToString();
            Label5.Text = Session["dd"].ToString();
                       
        }
    }

    #endregion Location Master - Page Loading

    // Location Master - Get IP Address

    #region Location Master - Get IP Address

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

    #endregion Location Master - Get IP Address
    
    // Location Master - Save Button Click

    #region Location Master - Save Button Click

    protected void btn_locationsave_Click(object sender, EventArgs e)
    {
        try
        {
            if (lbl_locationmaster.Text == "N")
            {
                if (txt_locationdescription.Text != "" && txt_locationcode.Text != "" && ddl_departmentdescription.SelectedItem.Text != "Select")
                {
                    masterbel.LocationDescription = txt_locationdescription.Text;
                    masterbel.LocationCode = txt_locationcode.Text;
                    masterbel.LocationDepartmentId = Convert.ToInt16(ddl_departmentdescription.SelectedValue);
                    masterbel.LocationUpdatedDateTime = DateTime.Now;
                    masterbel.LocationUpdatedBy = "Admin";

                    LocationInsert = masterbal.LocationInsert(masterbel);

                    if (LocationInsert != string.Empty)
                    {
                        lbl_locationmessage.Text = "Records Inserted Successfully";

                        txt_locationdescription.Text = "";
                        txt_locationcode.Text = "";
                        ddl_departmentdescription.SelectedIndex = 0;

                        //txt_locationdescription.ForeColor = System.Drawing.Color.Gray;
                        //txt_locationcode.ForeColor = System.Drawing.Color.Gray;
                        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Gray;

                        lbl_locationmessage.Visible = true;

                        gv_locationmaster.SelectedIndex = -1;

                        //ddl_departmentdescription.Text = "Select";

                        LocationBindGrid();

                        //vs_locationmaster.ShowSummary = false;
                    }
                    else
                    {
                        lbl_locationmessage.Text = "User Name [<b>" + txt_locationdescription.Text + "</b>] already exists, try another name";
                    }

                }

                else
                {
                    //if (txt_locationcode.Text == "Location Code")
                    //{
                    //    txt_locationcode.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (txt_locationdescription.Text == "Location Description")
                    //{
                    //    txt_locationdescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_departmentdescription.SelectedItem.Text == "Select")
                    //{
                    //    ddl_departmentdescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    if (txt_locationcode.Text == "" || txt_locationdescription.Text == "" || ddl_departmentdescription.SelectedItem.Text == "Select")
                    {
                        lbl_locationmessage.Visible = false;
                    }
                }
                //vs_locationmaster.ShowSummary = true;
            }
            if(lbl_locationmaster.Text == "E")
            {

                if (txt_locationdescription.Text != "" && txt_locationcode.Text != "" && ddl_departmentdescription.SelectedItem.Text != "Select")
                {
                    masterbel.LocationId = Convert.ToInt16(lbl_locationid.Text);
                    masterbel.LocationDescription = txt_locationdescription.Text;
                    masterbel.LocationCode = txt_locationcode.Text;
                    masterbel.LocationDepartmentId = Convert.ToInt16(ddl_departmentdescription.SelectedValue);
                    masterbel.LocationUpdatedDateTime = DateTime.Now;
                    masterbel.LocationUpdatedBy = "Admin";

                    LocationUpdate = masterbal.LocationUpdate(masterbel);

                    if (LocationUpdate != string.Empty)
                    {
                        lbl_locationmessage.Text = "Records Updated Successfully";

                        txt_locationdescription.Text = "";
                        txt_locationcode.Text = "";
                        ddl_departmentdescription.SelectedIndex =0;

                        //txt_locationdescription.ForeColor = System.Drawing.Color.Gray;
                        //txt_locationcode.ForeColor = System.Drawing.Color.Gray;
                        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Gray;

                        lbl_locationmessage.Visible = true;

                        gv_locationmaster.SelectedIndex = -1;

                        LocationBindGrid();

                        //vs_locationmaster.ShowSummary = false;
                    }
                    else
                    {
                        lbl_locationmessage.Text = "User Name [<b>" + txt_locationdescription.Text + "</b>] already exists, try another name";
                    }

                }

                else
                {
                    //if (txt_locationcode.Text == "Location Code")
                    //{
                    //    txt_locationcode.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (txt_locationdescription.Text == "Location Description")
                    //{
                    //    txt_locationdescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_departmentdescription.SelectedItem.Text == "Select")
                    //{
                    //    ddl_departmentdescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    if (txt_locationcode.Text == "" || txt_locationdescription.Text == "" || ddl_departmentdescription.SelectedItem.Text == "Select")
                    {
                        lbl_locationmessage.Visible = false;
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            masterbal = null;
            masterbel = null;
        }

    }

    #endregion Location Master - Save Button Click

    // Location Master - Grid View Loading

    #region Location Master - Grid View Loading

    public void LocationBindGrid()
    {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();
        try
        {
            //Intializing Data Table
            DataTable MyLocationGridViewBind = new DataTable();

            //MyDeviceGridViewBind = null;

            //if(MyDeviceGridViewBind !=null)
            //{

            masterbel.GettingDepartmentId = Convert.ToInt16(lbl_locationdepartmentid.Text);

            MyLocationGridViewBind = masterbal.LocationGridViewLoading(masterbel);

            //}

            gv_locationmaster.AutoGenerateColumns = false;

            //gv_locationmaster.Columns[4].Visible = false;

            gv_locationmaster.DataSource = MyLocationGridViewBind;
            gv_locationmaster.DataBind();

            //MyDeviceGridViewBind = null;

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

    #endregion Location Master - Grid View Loading

    // Location Master - Adding Combo Box Items

    #region Location Master - AddValue Combo Box

    public class AddValue
    {
        private string m_Display;
        private long m_Value;
        public AddValue(string Display, long Value)
        {
            m_Display = Display;
            m_Value = Value;
        }
        public string Display
        {
            get { return m_Display; }
        }
        public long Value
        {
            get { return m_Value; }
        }
    }
    #endregion Location Master - AddValue Combo Box
    
    // Location Master - Grid View Selected Index Changed

    #region Location Master - Grid View Selected Index Changed

    protected void gv_locationmaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();

        //e.Row.Cells[4].Visible = false;

        GridViewRow Row = gv_locationmaster.SelectedRow;
        //gv_locationmaster.Columns[4].Visible = true;

        lbl_locationid.Text = Row.Cells[0].Text;
        txt_locationdescription.Text = Row.Cells[1].Text;
        txt_locationcode.Text = Row.Cells[2].Text;
        //ddl_departmentdescription.SelectedItem.Text = Row.Cells[3].Text;
        ddl_departmentdescription.SelectedValue = Row.Cells[4].Text;

        //gv_locationmaster.Columns[4].Visible = false;

        txt_locationdescription.Enabled = false;
        txt_locationcode.Enabled = false;
        ddl_departmentdescription.Enabled = false;

        btn_locationedit.Enabled = true;
        btn_locationnew.Enabled = true;
        btn_locationsave.Enabled = false;

        //txt_locationcode.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_locationdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
    }

    #endregion Location Master - Grid View Selected Index Changed

    // Location Master - Edit Button Click

    #region Location Master - Edit Button Click

    protected void btn_locationedit_Click(object sender, EventArgs e)
    {
        txt_locationdescription.Enabled = true;
        txt_locationcode.Enabled = true;
        ddl_departmentdescription.Enabled = true;

        //txt_locationdescription.ForeColor = System.Drawing.Color.Black;
        //txt_locationcode.ForeColor = System.Drawing.Color.Black;
        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Black;

        btn_locationedit.Enabled = false;
        btn_locationnew.Enabled = true;
        btn_locationsave.Enabled = true;

        lbl_locationmaster.Text = "E";
    }

    #endregion Location Master - Edit Button Click

    // Location Master - New Button Click

    #region Location Master - New Button Click

    protected void btn_locationnew_Click(object sender, EventArgs e)
    {
        txt_locationdescription.Text = "";
        txt_locationcode.Text = "";
        ddl_departmentdescription.SelectedIndex = 0;

        //txt_locationdescription.ForeColor = System.Drawing.Color.Gray;
        //txt_locationcode.ForeColor = System.Drawing.Color.Gray;
        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Gray;

        txt_locationdescription.Enabled = true;
        txt_locationcode.Enabled = true;
        ddl_departmentdescription.Enabled = true;

        btn_locationsave.Enabled = true;
        btn_locationnew.Enabled = true;
        btn_locationedit.Enabled = false;

        lbl_locationmaster.Text = "N";

        lbl_locationmessage.Visible = false;

        //txt_locationcode.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_locationdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

        gv_locationmaster.SelectedIndex = -1;
                
    }

    #endregion Location Master - New Button Click

    // Location Master - Row Data Bound

    #region Location Master - Row Data Bound

    protected void gv_locationmaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
           // e.Row.Cells[4].Visible = false;
            //gv_locationmaster.Columns[4].Visible = false;
        }
    }

    #endregion Location Master - Row Data Bound

    // Location Master - Page Index Changing

    #region Location Master - Page Index Changing

    protected void gv_locationmaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_locationmaster.PageIndex = e.NewPageIndex;
        //gv_terminalmaster.DataSource = (DataTable)Cache["Data"];
        gv_locationmaster.DataBind();
        LocationBindGrid();
    }

    #endregion Location Master - Page Index Changing

    // Location Master - Location Department Selection Selected Index Changed

    #region Location Master - Location Department Selection Selected Index Changed

    protected void ddl_locationdepartmentselection_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_locationdepartmentid.Text = Convert.ToString(ddl_locationdepartmentselection.SelectedValue);

        LocationBindGrid();

        gv_locationmaster.SelectedIndex = -1;
    }

    #endregion Location Master - Location Department Selection Selected Index Changed


}