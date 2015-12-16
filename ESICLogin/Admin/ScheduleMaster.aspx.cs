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
    public ArrayList RoomDescription = new ArrayList();
    public ArrayList WeekDescription = new ArrayList();
    public ArrayList SessionDescription = new ArrayList();
    public ArrayList DayDescription = new ArrayList();

    MasterBAL masterbal = new MasterBAL();
    MasterBEL masterbel = new MasterBEL();
    string updatestatus;

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
                DataTable Room = new DataTable();

                 MyLocationDepartment = masterbal.GetDepartmentDescription();


                 //departmentdescription.Add(new AddValue("Select", 0));

               //  LocationDepartmentSelection.Add(new AddValue("ALL", 0));


                 foreach (DataRow dr in MyLocationDepartment.Rows)
                 {
                     string Department_Description_Bind = dr["department_desc"].ToString();
                     long Department_id = Int32.Parse(dr["department_id"].ToString());

                     departmentdescription.Add(new AddValue(Department_Description_Bind, Department_id));
                     LocationDepartmentSelection.Add(new AddValue(Department_Description_Bind, Department_id));

                 }

                 //// Loading Data To Data Source

                 ddl_departmentdescription.DataSource = LocationDepartmentSelection;
                 ddl_departmentdescription.DataTextField = "Display";
                 ddl_departmentdescription.DataValueField = "Value";
                 ddl_departmentdescription.DataBind();
                 
                 Room = masterbal.GetRoomCode();
                 //RoomDescription.Add(new AddValue("ALL", 0));


                 foreach (DataRow dr in Room.Rows)
                 {
                     string Department_Description_Bind = dr["room_code"].ToString();
                     long Department_id = Int32.Parse(dr["room_id"].ToString());

                     RoomDescription.Add(new AddValue(Department_Description_Bind, Department_id));
                    

                 }

                 ddl_locationdepartmentselection.DataSource = RoomDescription;
                 ddl_locationdepartmentselection.DataTextField = "Display";
                 ddl_locationdepartmentselection.DataValueField = "Value";
                 ddl_locationdepartmentselection.DataBind();

                 ddl_roomcode.DataSource = RoomDescription;
                 ddl_roomcode.DataTextField = "Display";
                 ddl_roomcode.DataValueField = "Value";
                 ddl_roomcode.DataBind();

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
            DayDropDown();
            WeekDropdown();
            SessionDropdown();
                       
        }

       

    }

    #endregion Location Master - Page Loading

    private void WeekDropdown()
    {
        //DataTable Weekdesp = new DataTable();
        DataTable dtweek = new DataTable();
        dtweek.Columns.Add("week_id", typeof(int));
        dtweek.Columns.Add("week_desc", typeof(string));
        dtweek.Rows.Add(1, "Week1");
        dtweek.Rows.Add(2, "Week2");
       // WeekDescription.Add(new AddValue("ALL", 0));


        foreach (DataRow dr in dtweek.Rows)
        {
            string Department_Description_Bind = dr["week_desc"].ToString();
            long Department_id = Int32.Parse(dr["week_id"].ToString());

            WeekDescription.Add(new AddValue(Department_Description_Bind, Department_id));


        }

        ddl_week1.DataSource = WeekDescription;
        ddl_week1.DataTextField = "Display";
        ddl_week1.DataValueField = "Value";
        ddl_week1.DataBind();
    }

    private void SessionDropdown()
    {
        //DataTable Weekdesp = new DataTable();
        //ddl_week1.DataBind();
        DataTable dtsession = new DataTable();
        dtsession.Columns.Add("session_id", typeof(int));
        dtsession.Columns.Add("session_desc", typeof(string));
        dtsession.Rows.Add(1, "Morning");
        dtsession.Rows.Add(2, "AfterNoon");
       // SessionDescription.Add(new AddValue("ALL", 0));


        foreach (DataRow dr in dtsession.Rows)
        {
            string Department_Description_Bind = dr["session_desc"].ToString();
            long Department_id = Int32.Parse(dr["session_id"].ToString());

            SessionDescription.Add(new AddValue(Department_Description_Bind, Department_id));


        }

        ddl_session.DataSource = SessionDescription;
        ddl_session.DataTextField = "Display";
        ddl_session.DataValueField = "Value";
        ddl_session.DataBind();
    }

    private void DayDropDown()
    {
        DataTable dtday = new DataTable();
        dtday.Columns.Add("day_id", typeof(int));
        dtday.Columns.Add("day_desc", typeof(string));
        dtday.Rows.Add(1, "Monday");
        dtday.Rows.Add(2, "Tuesday");
        dtday.Rows.Add(3, "Wednesday");
        dtday.Rows.Add(4, "Thursday");
        dtday.Rows.Add(5, "Friday");
       // DayDescription.Add(new AddValue("ALL", 0));


        foreach (DataRow dr in dtday.Rows)
        {
            string Department_Description_Bind = dr["day_desc"].ToString();
            long Department_id = Int32.Parse(dr["day_id"].ToString());

            DayDescription.Add(new AddValue(Department_Description_Bind, Department_id));


        }

        ddl_day.DataSource = DayDescription;
        ddl_day.DataTextField = "Display";
        ddl_day.DataValueField = "Value";
        ddl_day.DataBind();
    }
    

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
        MasterBEL schedulebel = new MasterBEL();
        
 
        schedulebel.ScheduleDay = Convert.ToInt16(ddl_day.SelectedValue);
        schedulebel.ScheduleWeek = Convert.ToInt16(ddl_week1.SelectedValue);
        schedulebel.ScheduleSession = Convert.ToInt16(ddl_session.SelectedValue);
        schedulebel.ScheduleDeptid = Convert.ToInt16(ddl_departmentdescription.SelectedValue);

        schedulebel.ScheduleRoomId = Convert.ToInt16(ddl_roomcode.SelectedValue);
        string stime = "", sdate = "", sdatetime = "", etime = "", edate = "", edatetime = "";
        stime = (dt_starttime.SelectedDate.Value.ToShortTimeString().ToString());
        sdate = (dt_start.SelectedDate.Value.ToShortDateString().ToString());
        sdatetime = sdate +" "+ stime;
        schedulebel.ScheduleStartTime = Convert.ToDateTime(sdatetime);

        etime = (dt_endtime.SelectedDate.Value.ToShortTimeString().ToString());
        edate = (dt_end.SelectedDate.Value.ToShortDateString().ToString());
        edatetime = edate + " " + etime;
        schedulebel.ScheduleEndTime = Convert.ToDateTime(edatetime);
        //schedulebel.ScheduleStartTime = Convert.ToDateTime(dt_starttime.SelectedDate.Value.ToShortTimeString().ToString());
        
       // schedulebel.ScheduleStartTime = Convert.ToDateTime(dt_start.SelectedDate.Value.ToShortDateString().ToString());
        
       // schedulebel.ScheduleEndTime = Convert.ToDateTime(dt_endtime.SelectedDate);
        
        

        if (lbl_schedulemaster.Text == "N")
        {
            updatestatus = masterbal.AddContent1(schedulebel);
            if (updatestatus != string.Empty)
            {
                lbl_locationmessage.Text = "Records Added Successfully.";

            }
        }
        else
        {
            schedulebel.ScheduleId = Convert.ToInt16(lbl_ScheduleId.Text);
            updatestatus = masterbal.ScheduleUpdate(schedulebel);
            if (updatestatus != string.Empty)
            {
                lbl_locationmessage.Text = "Records Updated Successfully.";

                //binding

                ddl_week1.SelectedIndex = 0;
                ddl_day.SelectedIndex = 0;
             
                ddl_departmentdescription.SelectedIndex = 0;
                ddl_roomcode.SelectedIndex = 0;
                ddl_session.SelectedIndex = 0;
                lbl_schedulemaster.Text = "N";
            }

        }
        //ContentBind();
       

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

            //masterbel.GettingDepartmentId = Convert.ToInt16(lbl_locationdepartmentid.Text);

            MyLocationGridViewBind = masterbal.ScheduleGridViewLoading(masterbel);

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

    #region Schedule Master - Grid View Selected Index Changed

    protected void gv_locationmaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();

        //e.Row.Cells[4].Visible = false;

        GridViewRow Row = gv_locationmaster.SelectedRow;
        //gv_locationmaster.Columns[4].Visible = true;
        lbl_ScheduleId.Text = Row.Cells[0].Text;
        ddl_week1.SelectedValue = Row.Cells[1].Text;
        ddl_day.SelectedValue = Row.Cells[2].Text;
       // txt_locationcode.Text = Row.Cells[2].Text;
        //ddl_departmentdescription.SelectedItem.Text = Row.Cells[3].Text;
        ddl_departmentdescription.SelectedValue = Row.Cells[4].Text;
        string r = "";
        r = Row.Cells[5].Text;
        r = r.Trim();
        ddl_roomcode.SelectedValue = Row.Cells[6].Text;
        ddl_session.SelectedValue = Row.Cells[7].Text;
        DateTime sdate = new DateTime();
        DateTime edate = new DateTime();
        sdate = Convert.ToDateTime(Row.Cells[8].Text);
        dt_start.SelectedDate = sdate;
        dt_starttime.SelectedDate = sdate;
        edate = Convert.ToDateTime(Row.Cells[9].Text);
        dt_end.SelectedDate = edate;
        dt_endtime.SelectedDate = edate;
        //gv_locationmaster.Columns[4].Visible = false;

       // txt_locationdescription.Enabled = false;
       // txt_locationcode.Enabled = false;
        ddl_departmentdescription.Enabled = false;
        ddl_week1.Enabled = false;
        ddl_day.Enabled = false;
        ddl_session.Enabled = false;
        ddl_roomcode.Enabled = false;
        dt_end.Enabled = false;
        dt_endtime.Enabled = false;
        dt_start.Enabled = false;
        dt_starttime.Enabled = false;

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
        
        ddl_week1.Enabled = true;
        ddl_day.Enabled = true;
        ddl_departmentdescription.Enabled = true;
        ddl_roomcode.Enabled = true;
        ddl_session.Enabled = true;
        dt_end.Enabled = true;
        dt_endtime.Enabled = true;
        dt_start.Enabled = true;
        dt_starttime.Enabled = true;
        lbl_schedulemaster.Text = "E";
        btn_locationsave.Enabled = true;
    }

    #endregion Location Master - Edit Button Click

    // Location Master - New Button Click

    #region Location Master - New Button Click

    protected void btn_locationnew_Click(object sender, EventArgs e)
    {
        ddl_week1.SelectedIndex = 0;
        ddl_day.SelectedIndex = 0;
        ddl_departmentdescription.SelectedIndex = 0;
        ddl_roomcode.SelectedIndex = 0;
        ddl_session.SelectedIndex = 0;


        ddl_week1.Enabled = true;
        ddl_day.Enabled = true;
        ddl_departmentdescription.Enabled = true;
        ddl_roomcode.Enabled = true;
        ddl_session.Enabled = true;
        dt_end.Enabled = true;
        dt_endtime.Enabled = true;
        dt_start.Enabled = true;
        dt_starttime.Enabled = true;
        lbl_schedulemaster.Text = "N";

        btn_locationsave.Enabled = true;
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