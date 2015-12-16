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

public partial class Admin_admin : System.Web.UI.Page
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
            
        }

       
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
        lbl_departmentdescriptionloadingid.Text = Convert.ToString(ddl_departmentselection.SelectedValue);
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