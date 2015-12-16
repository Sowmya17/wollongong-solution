using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Xml;
using System.IO;
using System.Data;
using System.Net;

public partial class Admin_TotalQueue : System.Web.UI.Page
{

    // Varaible Intiallizing

    #region Variable Intiallizing
    LoginBAL logincntrl;
    public ArrayList departmentdescriptionloading = new ArrayList();

    public string _currentuserId;

    MasterBAL masterbal = new MasterBAL();

    #endregion Variable Intiallizing

    protected void Page_Load(object sender, EventArgs e)
    {
        _currentuserId = Session["uid"].ToString();
        if (!IsPostBack)
        {
            Label4.Text = DateTime.Now.ToLongDateString();
            lbl_clientip.Text = GetIP();
            lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
            lbl_userna.Text = Session["uname"].ToString();
            // Session["User"] = uname;
            // Session["esicno"] = "0";
            Label2.Text = Session["terdesc"].ToString();
            Label5.Text = Session["dd"].ToString();


            DepartmentDescriptionLoading();

            lbl_departmentdescriptionloadingid.Text = Session["did"].ToString();

            //ddl_departmentselection.SelectedItem.Text = Label5.Text;

            ddl_departmentselection.SelectedValue = lbl_departmentdescriptionloadingid.Text;
            int _selecteddepartmentno = Convert.ToInt32(Session["did"].ToString());
            UpdateAdminPanel(_selecteddepartmentno);
        }
    }

    public void UpdateAdminPanel(int selected_department)
    {

        MasterBAL bal = new MasterBAL();
        if (selected_department == 0)
        {
            int selectedvalue = 0;
            int deptid = Convert.ToInt32(ddl_departmentselection.SelectedValue);
            lbl_ServingQueueTotal.Text = bal.GetTotalServingQueueCount();
            lbl_PendingQueueTotal.Text = bal.GetPendingQueueCount();
            lbl_WaitingQueueTotal.Text = bal.GetWaitingQueueCount();
            LoadServingGridView(selectedvalue);
            LoadWaitingGridView(selectedvalue);
            LoadPendingGridView(selectedvalue);
            LoadMissedGridView(selectedvalue);
        }
        else
        {
            int selectedvalue = Convert.ToInt32(ddl_departmentselection.SelectedValue);
            string servingqueuecount = bal.GetTotalServingQueueCountbyDeptId(selectedvalue);
            lbl_ServingQueueTotal.Text = servingqueuecount;
            lbl_WaitingQueueTotal.Text = bal.GetWaitingQueueCountbyDept(selectedvalue);
            lbl_PendingQueueTotal.Text = bal.GetPendingQueueCountbyDept(selectedvalue);
            LoadServingGridView(selectedvalue);
            LoadWaitingGridView(selectedvalue);
            LoadPendingGridView(selectedvalue);
            LoadMissedGridView(selectedvalue);
            
        }

    }

    private void LoadServingGridView(int departmentid)
    {
        try
        {
            MasterBAL bal = new MasterBAL();
            DataTable dt = new DataTable();
            if (departmentid == 0)
            {
                dt = bal.LoadServingGrid();
                grid_TotalServingQueue.AutoGenerateColumns = false;
                grid_TotalServingQueue.DataSource = dt;
                grid_TotalServingQueue.DataBind();
            }
            else
            {
                dt = bal.LoadServingGridbyDeptId(departmentid);
                grid_TotalServingQueue.AutoGenerateColumns = false;
                grid_TotalServingQueue.DataSource = dt;
                grid_TotalServingQueue.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadMissedGridView(int departmentid)
    {
        try
        {
            MasterBAL bal = new MasterBAL();
            DataTable dt = new DataTable();
            if (departmentid == 0)
            {
                dt = bal.LoadMissedGrid();
                grid_TotalMissedQueue.AutoGenerateColumns = false;
                grid_TotalMissedQueue.DataSource = dt;
                grid_TotalMissedQueue.DataBind();
            }
            else
            {
                dt = bal.LoadMissedGridbyDeptId(departmentid);
                grid_TotalMissedQueue.AutoGenerateColumns = false;
                grid_TotalMissedQueue.DataSource = dt;
                grid_TotalMissedQueue.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadWaitingGridView(int departmentid)
    {
        try
        {
            MasterBAL bal = new MasterBAL();
            DataTable dt = new DataTable();
            if (departmentid == 0)
            {
                dt = bal.LoadWaitingGrid();
                grid_TotalWaitingQueue.AutoGenerateColumns = false;
                grid_TotalWaitingQueue.DataSource = dt;
                grid_TotalWaitingQueue.DataBind();
            }
            else
            {
                dt = bal.LoadWaitingGridbyDeptId(departmentid);
                grid_TotalWaitingQueue.AutoGenerateColumns = false;
                grid_TotalWaitingQueue.DataSource = dt;
                grid_TotalWaitingQueue.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LoadPendingGridView(int departmentid)
    {
        try
        {
            MasterBAL bal = new MasterBAL();
            DataTable dt = new DataTable();
            if (departmentid == 0)
            {
                dt = bal.LoadPendingGrid();
                grid_TotalPendingQueue.AutoGenerateColumns = false;
                grid_TotalPendingQueue.DataSource = dt;
                grid_TotalPendingQueue.DataBind();
            }
            else
            {
                dt = bal.LoadPendingGridbyDeptId(departmentid);
                grid_TotalPendingQueue.AutoGenerateColumns = false;
                grid_TotalPendingQueue.DataSource = dt;
                grid_TotalPendingQueue.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void gv_Waiting_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int departmentid = 0;
        departmentid = Convert.ToInt32(ddl_departmentselection.SelectedValue);
        grid_TotalWaitingQueue.PageIndex = e.NewPageIndex;
        grid_TotalWaitingQueue.DataBind();

        string selected = ddl_departmentselection.SelectedValue.ToString();
        if (selected == Convert.ToString(-1))
        {
            lbl_departmentdescriptionloadingid.Text = "Select All";
            departmentid = 0;
        }
        else
        {
            lbl_departmentdescriptionloadingid.Text = Convert.ToString(ddl_departmentselection.SelectedValue);
            departmentid = Convert.ToInt32(ddl_departmentselection.SelectedValue);

        }

        LoadWaitingGridView(departmentid);

    }
    protected void gv_Serving_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int departmentid = 0;
        departmentid = Convert.ToInt32(ddl_departmentselection.SelectedValue);
        grid_TotalServingQueue.PageIndex = e.NewPageIndex;
        grid_TotalServingQueue.DataBind();

        string selected = ddl_departmentselection.SelectedValue.ToString();
        if (selected == Convert.ToString(-1))
        {
            lbl_departmentdescriptionloadingid.Text = "Select All";
            departmentid = 0;
        }
        else
        {
            lbl_departmentdescriptionloadingid.Text = Convert.ToString(ddl_departmentselection.SelectedValue);
            departmentid = Convert.ToInt32(ddl_departmentselection.SelectedValue);

        }

        LoadServingGridView(departmentid);
    }
    protected void gv_Pending_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int departmentid = 0;
        departmentid = Convert.ToInt32(ddl_departmentselection.SelectedValue);
        grid_TotalPendingQueue.PageIndex = e.NewPageIndex;
        grid_TotalPendingQueue.DataBind();

        string selected = ddl_departmentselection.SelectedValue.ToString();
        if (selected == Convert.ToString(-1))
        {
            lbl_departmentdescriptionloadingid.Text = "Select All";
            departmentid = 0;
        }
        else
        {
            lbl_departmentdescriptionloadingid.Text = Convert.ToString(ddl_departmentselection.SelectedValue);
            departmentid = Convert.ToInt32(ddl_departmentselection.SelectedValue);

        }

        LoadPendingGridView(departmentid);
    }

    protected void gv_Missed_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int departmentid=0;
        departmentid = Convert.ToInt32(ddl_departmentselection.SelectedValue);
        grid_TotalMissedQueue.PageIndex = e.NewPageIndex;
        grid_TotalMissedQueue.DataBind();
        
        string selected = ddl_departmentselection.SelectedValue.ToString();
        if (selected == Convert.ToString(-1))
        {
            lbl_departmentdescriptionloadingid.Text = "Select All";
            departmentid = 0;
        }
        else
        {
            lbl_departmentdescriptionloadingid.Text = Convert.ToString(ddl_departmentselection.SelectedValue);
            departmentid = Convert.ToInt32(ddl_departmentselection.SelectedValue);
            
        }

        LoadMissedGridView(departmentid);

    }
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

    // DepatmentDescriptionLoading

    #region Department Description Loading

    public void DepartmentDescriptionLoading()
    {

        // Admin - Department Description Combo Box Loading

        DataTable MyDepartmentDescription = new DataTable();

        MyDepartmentDescription = masterbal.GetDepartmentDescription();
        //departmentdescriptionloading.Add("ALL");
        foreach (DataRow dr in MyDepartmentDescription.Rows)
        {
            string Department_Description_Bind = dr["department_desc"].ToString();
            long Department_id = Int32.Parse(dr["department_id"].ToString());

            departmentdescriptionloading.Add(new AddValue(Department_Description_Bind, Department_id));

        }

        //// Loading Data To Data Source
        ddl_departmentselection.DataSource = departmentdescriptionloading;
        ddl_departmentselection.DataTextField = "Display";
        ddl_departmentselection.DataValueField = "Value";
        ddl_departmentselection.DataBind();

        lbl_departmentdescriptionloadingid.Text = Convert.ToString(ddl_departmentselection.SelectedValue);
    }

    #endregion Department Description Loading


    // Admin - Department Selection Selected Index Changed

    #region Admin - Department Selection Selected Index Changed

    protected void ddl_departmentselection_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selecteddepartment = 0;
        string selected = ddl_departmentselection.SelectedValue.ToString();
        if (selected == Convert.ToString(-1))
        {
            lbl_departmentdescriptionloadingid.Text = "Select All";
            UpdateAdminPanel(selecteddepartment);
        }
        else
        {
            lbl_departmentdescriptionloadingid.Text = Convert.ToString(ddl_departmentselection.SelectedValue);
            selecteddepartment = Convert.ToInt32(ddl_departmentselection.SelectedValue);
            UpdateAdminPanel(selecteddepartment);
        }
    }

    #endregion Admin - Department Selection Selected Index Changed


    // Admin - Adding Combo Box Items

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


    protected void buttonlink_Click(object sender, EventArgs e)
    {
        int userid = Convert.ToInt32(_currentuserId);
        logincntrl = new LoginBAL();
        int session_Id = logincntrl.GetSessionId(userid);
        //int session_sod2 = logincntrl.GetUserSessionSod(userid);
        logincntrl.updateUserLogoutSession(session_Id, userid);
        string url = string.Format("~/Default.aspx");
        Response.Redirect(url, false);
    }
}