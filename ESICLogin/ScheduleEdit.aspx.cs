using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class AddMember : System.Web.UI.Page
{
    private CRTBEL crtview;
    private CRTBAL crtcntrl;
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public string esicno, terminaluser;

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


    protected void Page_Load(object sender, EventArgs e)
    {

        
        
        if (!IsPostBack)
        {
            DataTable Room = new DataTable();
            DataTable MyLocationDepartment = new DataTable();
            MyLocationDepartment = masterbal.GetDepartmentDescription();
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
            ddl_roomcode.DataSource = RoomDescription;
            ddl_roomcode.DataTextField = "Display";
            ddl_roomcode.DataValueField = "Value";
            ddl_roomcode.DataBind();
            esicno = Session["ScheduleId"].ToString();
            DayDropDown();
            WeekDropdown();
            SessionDropdown();

            //terminaluser = Session["User"].ToString();
            //this.RadDatePicker1.MinDate = Convert.ToDateTime("1940-01-01 00:00:00.000");
            //this.RadDatePicker1.MaxDate = DateTime.Today;

            BindMemberData();
        }

       

        //lbl_msg.Visible = false;

    }


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
    private void BindMemberData()
    {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();
        try
        {
            //Intializing Data Table
            DataTable MyLocationGridViewBind = new DataTable();
            masterbel.ScheduleId1 = Convert.ToInt32(esicno);
            //MyDeviceGridViewBind = null;

            //if(MyDeviceGridViewBind !=null)
            //{

            //masterbel.GettingDepartmentId = Convert.ToInt16(lbl_locationdepartmentid.Text);

            MyLocationGridViewBind = masterbal.ScheduleSearchLoading(masterbel);

            if (MyLocationGridViewBind.Rows.Count > 0)
            {
               // lbl_ScheduleId.Text = Row.Cells[0].Text;
                ddl_week1.SelectedValue = MyLocationGridViewBind.Rows[0][1].ToString();
                ddl_day.SelectedValue = MyLocationGridViewBind.Rows[0][2].ToString();
                // txt_locationcode.Text = Row.Cells[2].Text;
                //ddl_departmentdescription.SelectedItem.Text = Row.Cells[3].Text;
                ddl_departmentdescription.SelectedValue = MyLocationGridViewBind.Rows[0][3].ToString();
                string r = "";
                r = MyLocationGridViewBind.Rows[0][5].ToString();
                r = r.Trim();
                ddl_roomcode.SelectedValue = MyLocationGridViewBind.Rows[0][4].ToString();
                ddl_session.SelectedValue = MyLocationGridViewBind.Rows[0][6].ToString();
                DateTime sdate = new DateTime();
                DateTime edate = new DateTime();
                string dtime = MyLocationGridViewBind.Rows[0][7].ToString();
                sdate = Convert.ToDateTime(dtime);
                dt_start.SelectedDate = sdate;
                dt_starttime.SelectedDate = sdate;
                string dtime1 = MyLocationGridViewBind.Rows[0][8].ToString();
                edate = Convert.ToDateTime(dtime1);
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
                //btn_locationnew.Enabled = true;
                btn_locationsave.Enabled = false;
            }

            //}

           // gv_locationmaster.AutoGenerateColumns = false;

            //gv_locationmaster.Columns[4].Visible = false;

            //gv_locationmaster.DataSource = MyLocationGridViewBind;
            //gv_locationmaster.DataBind();

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

    // Location Master - Adding Combo Box Items

    #region Schedule Master - AddValue Combo Box

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


    
    protected void btn_locationedit_Click(object sender, EventArgs e)
    {
        ddl_departmentdescription.Enabled = true;
        dt_endtime.Enabled = true;
        dt_starttime.Enabled = true;
        btn_locationsave.Enabled = true;

        
        ddl_week1.Enabled = false;
        ddl_day.Enabled = false;
        ddl_session.Enabled = false;
        ddl_roomcode.Enabled = true;
        dt_end.Enabled = false;
        
        dt_start.Enabled = false;
        

        btn_locationedit.Enabled = true;
        //btn_locationnew.Enabled = true;
        
    }
    protected void btn_locationsave_Click(object sender, EventArgs e)
    {
        MasterBEL schedulebel = new MasterBEL();

        schedulebel.ScheduleId1 = Convert.ToInt32(Session["ScheduleId"].ToString());
        schedulebel.ScheduleDay = Convert.ToInt16(ddl_day.SelectedValue);
        schedulebel.ScheduleWeek = Convert.ToInt16(ddl_week1.SelectedValue);
        schedulebel.ScheduleSession = Convert.ToInt16(ddl_session.SelectedValue);
        schedulebel.ScheduleDeptid = Convert.ToInt16(ddl_departmentdescription.SelectedValue);

        schedulebel.ScheduleRoomId = Convert.ToInt16(ddl_roomcode.SelectedValue);
        string stime = "", sdate = "", sdatetime = "", etime = "", edate = "", edatetime = "";
        stime = (dt_starttime.SelectedDate.Value.ToShortTimeString().ToString());
        sdate = (dt_start.SelectedDate.Value.ToShortDateString().ToString());
        sdatetime = sdate + " " + stime;
        schedulebel.ScheduleStartTime = Convert.ToDateTime(sdatetime);

        etime = (dt_endtime.SelectedDate.Value.ToShortTimeString().ToString());
        edate = (dt_end.SelectedDate.Value.ToShortDateString().ToString());
        edatetime = edate + " " + etime;
        schedulebel.ScheduleEndTime = Convert.ToDateTime(edatetime);

        updatestatus = masterbal.ScheduleUpdateDisplay(schedulebel);

        btn_locationsave.Enabled = false;
        btn_locationedit.Enabled = true;

        ddl_departmentdescription.Enabled = false;
        dt_endtime.Enabled = false;
        dt_starttime.Enabled = false;

    }
}