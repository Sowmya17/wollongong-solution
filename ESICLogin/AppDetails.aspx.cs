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
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

public partial class AppDetails : System.Web.UI.Page
{


     public string Qnum;
    
    CRTBEL crtview;
    CRTBAL crtcntrl;
    LoginBAL logincntrl;
    public StringBuilder strb = new StringBuilder();
    public ArrayList arrloadfreshQ = new ArrayList();
    public ArrayList arrloaddepot = new ArrayList();
    public ArrayList arrloadtoken = new ArrayList();
    public ArrayList arrloademr = new ArrayList();
    public ArrayList arrloadpatient = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public ArrayList arraylist1 = new ArrayList();
    public ArrayList arraylist2 = new ArrayList();
    public ArrayList TerminalDepartment = new ArrayList();
    public string fname;
    public string lname;
    public string uname;
    public string terdesc;
    public string uid;
    public string tid;
    public int deptid;
    public string did;
    public string dd,QueueTicket,DeptName;
    public int slno = 1;
    public int showqueueno = 1;
    string CorrectIPAddress;
    string consultingstatus;
    string DeptFirstLetter, DeptSurNameFirstLetter;
    public string _currentuserId;

    string AverageWaitingTime, AverageWaitingQueue;

    DataTable MyQueueNumber = new DataTable();

    int ApproximateWaitingTime = Convert.ToInt16(ConfigurationManager.AppSettings["ApproximateWaitingTime"].ToString());


    [DllImport("Iphlpapi.dll")]
    private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
    [DllImport("Ws2_32.dll")]
    private static extern Int32 inet_addr(string ip);
    
    


    #region mac address using userhost address
    public string MACAddress()
    {

        try
        {
            string userip = Request.UserHostAddress;
            string strClientIP = Request.UserHostAddress.ToString().Trim();
            Int32 ldest = inet_addr(strClientIP);
            Int32 lhost = inet_addr("");
            Int64 macinfo = new Int64();
            Int32 len = 6;
            int res = SendARP(ldest, 0, ref macinfo, ref len);
            string mac_src = macinfo.ToString("X");
            //if (mac_src == "0")
            //{
            //    if (userip == "127.0.0.1")
            //        Response.Write("visited Localhost!");
            //    else
            //        Response.Write("the IP from" + userip + "" + "<br>");

            //}

            while (mac_src.Length < 12)
            {
                mac_src = mac_src.Insert(0, "0");
            }

            string mac_dest = "";

            for (int i = 0; i < 11; i++)
            {
                if (0 == (i % 2))
                {
                    if (i == 10)
                    {
                        mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                    }
                    else
                    {
                        mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                    }
                }
            }

            return mac_dest;
        }
        catch (Exception err)
        {
            return null;

        }
    }
    #endregion mac address using userhostaddress



    #region mac address using getip method

    public string GetMACAddress()
    {
        try
        {
            //string userip = GetIP();
            //string strClientIP = GetIP().Trim();
            //Int32 ldest = inet_addr(strClientIP);
            Int32 lhost = inet_addr("");
            Int64 macinfo = new Int64();
            Int32 len = 6;
           // int res = SendARP(ldest, 0, ref macinfo, ref len);
            string mac_src = macinfo.ToString("X");
            //if (mac_src == "0")
            //{
            //    if (userip == "127.0.0.1")
            //        Response.Write("visited Localhost!");
            //    else
            //        Response.Write("the IP from" + userip + "" + "<br>");

            //}

            while (mac_src.Length < 12)
            {
                mac_src = mac_src.Insert(0, "0");
            }

            string mac_dest = "";

            for (int i = 0; i < 11; i++)
            {
                if (0 == (i % 2))
                {
                    if (i == 10)
                    {
                        mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                    }
                    else
                    {
                        mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                    }
                }
            }

            return mac_dest;
        }
        catch (Exception err)
        {
            return null;

        }
    }
    #endregion mac address using getip method




    protected void Page_Load(object sender, EventArgs e)
    {


        _currentuserId = Server.UrlDecode(Request.QueryString["5"]);
        if (!IsPostBack)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);
            // Timer1_Tick(sender, e);
            Label4.Text = DateTime.Now.ToLongDateString();
            //client mac address
            lbl_clientip.Text = MACAddress();
            //server mac address
            lbl_instanceip.Text = GetMACAddress();
            fname = Server.UrlDecode(Request.QueryString["1"]);

            Session["Userfname"] = fname;

            if (fname == null)
            {

                fname = Session["fname"].ToString();

            }

            lname = Server.UrlDecode(Request.QueryString["2"]);
            if (lname == null)
            {
                lname = Session["lname"].ToString();
            }

            uname = Request.QueryString["3"];
            if (uname == null)
            {
                uname = Session["uname"].ToString();
            }

            terdesc = Request.QueryString["4"];
            if (terdesc == null)
            {
                terdesc = Session["terdesc"].ToString();
            }

            uid = Server.UrlDecode(Request.QueryString["5"]);
            if (uid == null || uid == string.Empty)
            {
                uid = Session["uid"].ToString();
            }

            tid = Server.UrlDecode(Request.QueryString["6"]);
            if (tid == null)
            {
                tid = Session["tid"].ToString();
            }

            did = Server.UrlDecode(Request.QueryString["7"]);
            if (did == null)
            {
                did = Session["did"].ToString();
            }
            dd = Server.UrlDecode(Request.QueryString["8"]);
            if (dd == null)
            {
                dd = Session["dd"].ToString();
            }
            lbl_userna.Text = uname;
            Session["User"] = uname;
            Session["esicno"] = "0";
            Label2.Text = terdesc;
            Label5.Text = dd;
            CRTBEL crtview = new CRTBEL();

            #region commented
            //_currentuserId = Server.UrlDecode(Request.QueryString["5"]);
            //if (!IsPostBack)
            //{
            //    ClientScript.GetPostBackEventReference(this, string.Empty);
            //    // Timer1_Tick(sender, e);
            //    Label4.Text = DateTime.Now.ToLongDateString();
            //    //client mac address
            //    lbl_clientip.Text = MACAddress();
            //    //server mac address
            //    lbl_instanceip.Text = GetMACAddress();
            //fname = Server.UrlDecode(Request.QueryString["1"]);

            //Session["Userfname"] = fname;

            ////if (fname == null)
            ////{

            ////    fname = Session["fname"].ToString();

            ////}

            //lname = Server.UrlDecode(Request.QueryString["2"]);
            //if (lname == null)
            //{
            //    lname = Session["lname"].ToString();
            //}

            //uname = Request.QueryString["3"];
            //if (uname == null)
            //{
            //    uname = Session["uname"].ToString();
            //}

            //terdesc = Request.QueryString["4"];
            //if (terdesc == null)
            //{
            //    terdesc = Session["terdesc"].ToString();
            //}

            //uid = Server.UrlDecode(Request.QueryString["5"]);
            //if (uid == null || uid == string.Empty)
            //{
            //    uid = Session["uid"].ToString();
            //}

            //tid = Server.UrlDecode(Request.QueryString["6"]);
            //if (tid == null)
            //{
            //    tid = Session["tid"].ToString();
            //}

            //did = Server.UrlDecode(Request.QueryString["7"]);
            //if (did == null)
            //{
            //    did = Session["did"].ToString();
            //}
            //dd = Server.UrlDecode(Request.QueryString["8"]);
            //if (dd == null)
            //{
            //    dd = Session["dd"].ToString();
            //}
            //    lbl_userna.Text = uname;
            //    Session["User"] = uname;
            //    Session["esicno"] = "0";
            //    Label2.Text = terdesc;
            //    Label5.Text = dd;
            //      PageStart();
            //      LoadDepart();
            //     btn_print.Enabled = false;
            //     btn_reprint.Enabled = false;
            //}
            #endregion
            ArrayList departmentdescription = new ArrayList();
            MasterBAL masterbal = new MasterBAL();
            DataTable MyTerminalDepartment = new DataTable();
            MyTerminalDepartment = masterbal.GetDepartmentDescription();
            TerminalDepartment = new ArrayList();

            //departmentdescription.Add(new AddValue("Select", 0));

            //TerminalDepartmentSelection.Add(new CRTAddValue("ALL", 0));


            foreach (DataRow dr in MyTerminalDepartment.Rows)
            {
                string Department_Description_Bind = dr["department_desc"].ToString();
                long Department_id = Int32.Parse(dr["department_id"].ToString());
                crtview.DepartmentId = Convert.ToInt32(Department_id);
                departmentdescription.Add(new CRTAddValue(Department_Description_Bind, Department_id));

                TerminalDepartment.Add(new CRTAddValue(Department_Description_Bind, Department_id));

            }

            //// Loading Data To Data Source
            //////ddl_departmentdescription.DataSource = departmentdescription;
            //////ddl_departmentdescription.DataTextField = "Display";
            //////ddl_departmentdescription.DataValueField = "Value";
            //////ddl_departmentdescription.DataBind();

            terminaldepartmentselection.DataSource = TerminalDepartment;
            terminaldepartmentselection.DataTextField = "Display";
            terminaldepartmentselection.DataValueField = "Value";
            terminaldepartmentselection.DataBind();
            //string did =Server.UrlDecode(Request.QueryString["7"]);

            // crtview.DepartmentId = Convert.ToInt32(did);
            lbl_terminaldepartmentid.Text = Convert.ToString(terminaldepartmentselection.SelectedValue);
            crtview.DepartmentId = Convert.ToInt32(lbl_terminaldepartmentid.Text);
            LoadFresh();
            LoadAppointmentEmr();
            LoadAppointmentToken();
        }



    }
    

    private void LoadFresh()
    {
        DataTable dtbl = new DataTable();
        ListItem list1 = new ListItem();
        
        try
        {
            if (terminaldepartmentselection.SelectedValue != "0")
            {
                crtcntrl = new CRTBAL();
                CRTBEL crtview = new CRTBEL();
                //rtview = new RTBEL();
               // rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
                //string dept = terminaldepartmentselection.SelectedValue;
              //  crtview.DepartmentId = Convert.ToInt32(dept);
                crtview.DepartmentId =Convert.ToInt32(terminaldepartmentselection.SelectedValue.ToString());
                //rtview.DepartmentId = Convert.ToInt32(lbl_terminaldepartmentid.Text);
                dtbl = crtcntrl.GetAppointmentFresh(crtview);
                if (dtbl.Rows.Count > 0)
                {

                    foreach (DataRow dr in dtbl.Rows)
                    {
                        string depotname = myTI.ToTitleCase(dr["patientname"].ToString());
                        long depotid = Int64.Parse(dr["appointment_id"].ToString());
                        //TerminalDepartmentSelection.Add(new CRTAddValue(depotname, depotid));

                        //arrloaddepot.Add(new CRTAddValue(depotname, depotid));
                        arrloadfreshQ.Add(new CRTAddValue(depotname,depotid));

                    }

                    lb_deptlist.DataSource = arrloadfreshQ; 
                    //lb_deptlist.DataSource = arrloaddepot;
                    //dropdowndept.DataSource = TerminalDepartmentSelection;
                    lb_deptlist.DataTextField = "Display";
                    lb_deptlist.DataValueField = "Value";
                    lb_deptlist.DataBind();
                }
                else
                {
                    arrloaddepot.Add(new CRTAddValue("No Record", 0));
                    //arrloaddepot.Sort();
                    lb_deptlist.DataSource = arrloaddepot;
                    lb_deptlist.DataTextField = "Display";
                    lb_deptlist.DataValueField = "Value";
                    lb_deptlist.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
        }
    }
    

    //private void LoadAppointmentToken()
    //{
    //    DataTable dtbl = new DataTable();
    //    ListItem list1 = new ListItem();
    //    CRTBEL crtview = new CRTBEL();
    //    try
    //    {
    //        crtcntrl = new CRTBAL();
    //       crtview.DepartmentId = Convert.ToInt32(terminaldepartmentselection.SelectedValue.ToString());
    //        dtbl = crtcntrl.GetAppointmentToken(crtview);
    //        if (dtbl.Rows.Count > 0)
    //        {

    //            foreach (DataRow dr in dtbl.Rows)
    //            {
    //                string depotname = myTI.ToTitleCase(dr["patientname"].ToString());
    //                int depotid = Int32.Parse(dr["appointment_id"].ToString());
    //                arrloadtoken.Add(new CRTAddValue(depotname, depotid));

    //            }

    //            lb_apttoken.DataSource = arrloadtoken;
    //            lb_apttoken.DataTextField = "Display";
    //            lb_apttoken.DataValueField = "Value";
    //            lb_apttoken.DataBind();
    //        }
    //        else
    //        {
    //            arrloadtoken.Add(new CRTAddValue("No Record", 0));
    //            //arrloaddepot.Sort();
    //            lb_apttoken.DataSource = arrloadtoken;
    //            lb_apttoken.DataTextField = "Display";
    //            lb_apttoken.DataValueField = "Value";
    //            lb_apttoken.DataBind();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Problem in department load", ex);
    //    }
    //    finally
    //    {
    //        dtbl = null;
    //    }
    //}

    private void LoadAppointmentToken()
    {
        DataTable dtbl = new DataTable();
        ListItem list1 = new ListItem();
        CRTBEL crtview = new CRTBEL();
        try
        {
            crtcntrl = new CRTBAL();
            crtview.DepartmentId = Convert.ToInt32(terminaldepartmentselection.SelectedValue.ToString());
            dtbl = crtcntrl.GetAppointmentToken(crtview);
            if (dtbl.Rows.Count > 0)
            {

                foreach (DataRow dr in dtbl.Rows)
                {
                    string depotname = myTI.ToTitleCase(dr["patientname"].ToString());
                    // int depotid = Int32.Parse(dr["appointment_id"].ToString());
                    arrloadtoken.Add(new AppAddValue(depotname));

                }

                lb_apttoken.DataSource = arrloadtoken;
                lb_apttoken.DataTextField = "Display";
                // lb_apttoken.DataValueField = "Value";
                lb_apttoken.DataBind();
            }
            else
            {
                arrloadtoken.Add(new AppAddValue("No Record"));
                //arrloaddepot.Sort();
                lb_apttoken.DataSource = arrloadtoken;
                lb_apttoken.DataTextField = "Display";
                // lb_apttoken.DataValueField = "Value";
                lb_apttoken.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
        }
    }

    private void LoadAppointmentEmr()
    {
        DataTable dtbl = new DataTable();
        ListItem list1 = new ListItem();
        CRTBEL crtview = new CRTBEL();
        try
        {
            crtcntrl = new CRTBAL();
            crtview.DepartmentId = Convert.ToInt32(terminaldepartmentselection.SelectedValue.ToString());
            dtbl = crtcntrl.GetAppointmentEmr(crtview);
            if (dtbl.Rows.Count > 0)
            {

                foreach (DataRow dr in dtbl.Rows)
                {
                    string depotname = myTI.ToTitleCase(dr["patientname"].ToString());
                    int depotid = Int32.Parse(dr["appointment_id"].ToString());
                    arrloademr.Add(new CRTAddValue(depotname, depotid));

                }

                lb_aptemr.DataSource = arrloademr;
                lb_aptemr.DataTextField = "Display";
                lb_aptemr.DataValueField = "Value";
                lb_aptemr.DataBind();
            }
            else
            {
                arrloademr.Add(new CRTAddValue("No Record", 0));
                //arrloaddepot.Sort();
                lb_aptemr.DataSource = arrloademr;
                lb_aptemr.DataTextField = "Display";
                lb_aptemr.DataValueField = "Value";
                lb_aptemr.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
        }
    }

    private void LoadAppointmentEmrIndex()   
    {
        DataTable dtbl = new DataTable();
        ListItem list1 = new ListItem();
        CRTBEL crtview = new CRTBEL();
        try
        {
            crtcntrl = new CRTBAL();
            crtview.DepartmentId = Convert.ToInt32(terminaldepartmentselection.SelectedValue.ToString());
            dtbl = crtcntrl.GetAppointmentEmrIndex(crtview);  
            if (dtbl.Rows.Count > 0)
            {

                foreach (DataRow dr in dtbl.Rows)
                {
                    string depotname = myTI.ToTitleCase(dr["patientname"].ToString());
                    int depotid = Int32.Parse(dr["appointment_id"].ToString());

                    arrloademr.Add(new CRTAddValue(depotname, depotid));

                }

                lb_aptemr.DataSource = arrloademr;
                lb_aptemr.DataTextField = "Display";
                lb_aptemr.DataValueField = "Value";
                lb_aptemr.DataBind();
            }
            else
            {
                arrloademr.Add(new CRTAddValue("No Record", 0));
                //arrloaddepot.Sort();
                lb_aptemr.DataSource = arrloademr;
                lb_aptemr.DataTextField = "Display";
                lb_aptemr.DataValueField = "Value";
                lb_aptemr.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
        }
    }


    
    protected void btn1_Click(object sender, EventArgs e)
    {
        string url = string.Format("AppDetails.aspx");
        Response.Redirect(url, false);
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        string url = string.Format("crtesic.aspx");
        Response.Redirect(url, false);
    }
    protected void btn_emr_Click(object sender, EventArgs e)
    {
        
        if (lb_apttoken.SelectedIndex >= 0)
        {
            crtview = new CRTBEL();
            crtcntrl=new CRTBAL();
            string chk = "";
            crtview.AppointmentIDStatus = Convert.ToString(lb_apttoken.SelectedValue);
            if (crtview.AppointmentIDStatus != null)
            {
                chk = crtcntrl.UpdateAppointmentEmr(crtview);
            }
            LoadAppointmentEmr();
            //LoadAppointmentToken();
            LoadFresh();
        }
        
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        LoadFresh();
        LoadAppointmentEmr();
        LoadAppointmentToken();
    }
    protected void lb_apttoken_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_token_Click(object sender, EventArgs e)
    {
        if (lb_aptemr.SelectedIndex >= 0)
        {
            crtview = new CRTBEL();
            crtcntrl = new CRTBAL();
            string chk1 = "";
            crtview.AppointmentIDStatus = Convert.ToString(lb_aptemr.SelectedValue);
            if (crtview.AppointmentIDStatus != null)
            {
                chk1 = crtcntrl.UpdateAppointmentToken(crtview);
            }
            LoadAppointmentEmr();
            LoadAppointmentToken();
            LoadFresh();
        }
    }

    protected void btn_crt_Click(object sender, EventArgs e)
    {
        fname = Server.UrlDecode(Request.QueryString["1"]);
        lname = Server.UrlDecode(Request.QueryString["2"]);
        uname = Request.QueryString["3"];
        terdesc = Request.QueryString["4"];
        uid = Server.UrlDecode(Request.QueryString["5"]);
        tid = Server.UrlDecode(Request.QueryString["6"]);
        did = Server.UrlDecode(Request.QueryString["7"]);
        dd = Server.UrlDecode(Request.QueryString["8"]);
        string url = string.Format("crtesic.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                                Server.UrlEncode(fname),
                                Server.UrlEncode(lname),
                                Server.UrlEncode(uname),
                                Server.UrlEncode(terdesc),
                                Server.UrlEncode(uid),
                                Server.UrlEncode(tid),
                                Server.UrlEncode(did),
                                Server.UrlEncode(dd));
        Response.Redirect(url, false);
    }

    protected void terminaldepartmentselection_SelectedIndexChanged(object sender, EventArgs e)
    {
        lb_apttoken.Items.Clear();
        //lbl_terminaldepartmentid.Text = Convert.ToString();
        CRTBEL crtview = new CRTBEL();
        lbl_terminaldepartmentid.Text = terminaldepartmentselection.SelectedValue;
        //rtview.DepartmentId = rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
        crtview.DepartmentId = Convert.ToInt32(lbl_terminaldepartmentid.Text);
        deptid = crtview.DepartmentId;

        LoadFresh();
        LoadAppointmentEmrIndex();
        LoadAppointmentEmr();
        LoadAppointmentToken();
       
    }

   
    //protected void ddl_terminaldepartmentselection_SelectedIndexChanged1(object sender, EventArgs e)
    //{
    //    lbl_terminaldepartmentid.Text = Convert.ToString(terminaldepartmentselection.SelectedValue);
    //    RTBEL rtview = new RTBEL();

    //    rtview.DepartmentId = Convert.ToInt32(terminaldepartmentselection.SelectedValue);

    //    deptid = rtview.DepartmentId;

    //    LoadFresh();

    //    //LoadAppointmentEmr();
    //    //LoadAppointmentToken();
    //    // TerminalBindGrid();

    //   // gv_terminalmaster.SelectedIndex = -1;
    //}


    protected void lb_deptlist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

#region CRT - APP Add Value

public class AppAddValue
{
    private string m_Display;
    private long m_Value;
    public AppAddValue(string Display)
    {
        m_Display = Display;
        // m_Value = Value;
    }
    public string Display
    {
        get { return m_Display; }
    }
    //public long Value
    //{
    //    get { return m_Value; }
    //}

}

#endregion

 //CRT - CRT Add Value

#region CRT - CRT Add Value

public class CRTAddValue
{
    private string m_Display;
    private long m_Value;
    public CRTAddValue(string Display, long Value)
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

#endregion CRT - CRT Add Value