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

public partial class Rtnew : System.Web.UI.Page
{
    #region RT Screen - Initiallizing Values

    RTBEL rtview;
    RTBAL rtcntrl;
    LoginBAL logincntrl;
    public ArrayList arrloadfreshq;
    public ArrayList arrloadmissedq;
    public ArrayList arrloadholdq;
    public ArrayList arrloadpendingq;
    public ArrayList arrloaddepot = new ArrayList();
    public ArrayList listboxarrloaddepot;
    public ArrayList arraylist1 = new ArrayList();
    public ArrayList arraylist2 = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    string CorrectIPAddress;
    MessageBox ModeMsg = new MessageBox();
    public string _currentuserId;


    public int slno = 1;
    string ConsultationStartTime;
    string ConsultationEndTime;
    string updatesuccess = string.Empty;
    string insertsuccess = string.Empty;
    string MissedQueueNoShow = string.Empty;
    string MissedVisitTransactionId = string.Empty;
    string MissedQueueTransactionId = string.Empty;

    DateTime start;
    DateTime end;
    DateTime now;

    public int AvailableServicingQueue;
    int AppointmentToWalkin = 0;
    int CheckingAppointmentToWalkin;
    int gettinglastorderid;


    int FirstColour
    {
        get { return (int)ViewState["FirstColour"]; }
        set { ViewState["FirstColour"] = value; }
    }

    int AutoSMS = Convert.ToInt16(ConfigurationManager.AppSettings["AutoSMS"].ToString());


    [DllImport("Iphlpapi.dll")]
    private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
    [DllImport("Ws2_32.dll")]
    private static extern Int32 inet_addr(string ip);

    #endregion RT Screen - Intiallizing Values

    // RT Screen - Page Loading

    #region RT Screen - Page Loading
    protected void Page_Load(object sender, EventArgs e)
    {
        _currentuserId = Server.UrlDecode(Request.QueryString["5"]);
        if (!IsPostBack)
        {
            FirstColour = 1;
            Label4.Text = DateTime.Now.ToLongDateString();
            //client mac address
            lbl_clientip.Text = MACAddress();
            //server mac address
            lbl_instanceip.Text = GetMACAddress();
            string fname = Server.UrlDecode(Request.QueryString["1"]);
            string lname = Server.UrlDecode(Request.QueryString["2"]);
            string uname = Request.QueryString["3"];
            string terdesc = Request.QueryString["4"];
            string uid = Server.UrlDecode(Request.QueryString["5"]);
            string tid = Server.UrlDecode(Request.QueryString["6"]);
            string did = Server.UrlDecode(Request.QueryString["7"]);
            string dd = Server.UrlDecode(Request.QueryString["8"]);
            lbl_userna.Text = uname;
            lbl_userid.Text = uid;
            Session["User"] = uname;
            Session["esicno"] = "0";
            Label2.Text = terdesc;
            Label5.Text = dd;
            lbl_name.Text = dd;
            ButtonDisable();
            LoadDepart();
            LoadFreshQ();
            LoadMissedQ();
            LoadHoldQ();
            LoadPendingQ();
            ListBoxLoadDepart();


            btn_nextq.Enabled = true;
            btn_mandatamissedq.Enabled = false;
            btn_endq.Enabled = false;
            btn_mandatamissedqcall.Enabled = false;

            // btn_callq.Enabled = true;
            btn_holdq.Enabled = false;
            btn_endq.Enabled = false;
            btn_missedq.Enabled = false;
            btn_recall.Enabled = false;
            lb_deptlist.Enabled = false;
            lb_seldeptlist.Enabled = false;
            btn_l1tol2.Enabled = false;
            btn_l2tol1.Enabled = false;
            btn_up.Enabled = false;
            btn_down.Enabled = false;
            btn_addservices.Enabled = false;

            RLoad();

            if (FirstColour == 1)
            {
                LoadingAddServices();
                //AscendingOrder();
            }
        }
    }
    #region mac address using getip method
    #region RT Screen - Get IP Address

    private string GetIP()
    {
        string strHostName = "";
        strHostName = System.Net.Dns.GetHostName();

        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

        IPAddress[] addr = ipEntry.AddressList;

        //if (addr.Length == 6)
        //{
        //     return addr[addr.Length - 3].ToString();
        //}
        //else 
        //{
        //    return addr[addr.Length - 2].ToString();
        //}

        int AddressCount = addr.Count();

        for (int i = 0; i < AddressCount; i++)
        {
            string CheckingCorrectIPAddress = addr[i].ToString();
            string pattern = @"^[0-9.]*$";
            bool outputs = Regex.IsMatch(CheckingCorrectIPAddress, pattern);

            if (outputs == true)
            {
                CorrectIPAddress = CheckingCorrectIPAddress;
            }
        }

        return CorrectIPAddress;


    }

    #endregion RT Screen - Get IP Address

    public string GetMACAddress()
    {
        try
        {
            string userip = GetIP();
            string strClientIP = GetIP().Trim();
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
    #endregion mac address using getip method
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
      private void LoadingAddServices()
    {

        string removingdept = Server.UrlDecode(Request.QueryString["9"]);
        int removedept = Convert.ToInt16(removingdept);

        try
        {
            if (removedept == 6)
            {
                lb_deptlist.Visible = true;
                lb_seldeptlist.Visible = true;
                btn_up.Visible = true;
                btn_down.Visible = true;
                btn_l1tol2.Visible = true;
                btn_l2tol1.Visible = true;
                btn_addservices.Visible = true;
            }
            else if (removedept < 6)
            {
                lb_deptlist.Visible = false;
                lb_seldeptlist.Visible = false;
                btn_up.Visible = false;
                btn_down.Visible = false;
                btn_l1tol2.Visible = false;
                btn_l2tol1.Visible = false;
                btn_addservices.Visible = false;
            }
            FirstColour++;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion RT Screen - Loading Add Services
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        DataTable dtgqss = new DataTable();

        rtcntrl = new RTBAL();

        rtview = new RTBEL();

        rtview.GettingUserId = Convert.ToInt32(lbl_userid.Text);

        dtgqss = rtcntrl.GetQeueuServiceStatus(rtview);
        AvailableServicingQueue = dtgqss.Rows.Count;

        if (AvailableServicingQueue != 0)
        {
            //ModeMsg.ModeMessages("Kindly Process The Servicing Queue And Then LogOut", "ssd");
            MessageBox.Show("Kindly Process The Servicing Queue And Then LogOut");
            //string CheckingServing = "Kindly Process The Servicing Queue And Then LogOut";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", CheckingServing, true);

        }
        else
        {
            int userid = Convert.ToInt32(_currentuserId);
            logincntrl = new LoginBAL();
            int session_Id = logincntrl.GetSessionId(userid);
            //int session_sod2 = logincntrl.GetUserSessionSod(userid);
            logincntrl.updateUserLogoutSession(session_Id, userid);
            Response.Redirect("Default.aspx");
            //Response.Redirect("~/logout.aspx");
        }
    }
       protected void UpdatePatientInfoGridViewbyQueue(string selectedValue)
    {
        RTBAL bal = new RTBAL();
        RTBEL rtview = new RTBEL();
        //RTBAL crtcntrl = new CRTBAL();
        DataTable MyQueueNumber = new DataTable();
        try
        {
               // crtview.DateTime = System.DateTime.Now.ToShortDateString();

                MyQueueNumber = bal.RTGridViewLoading(selectedValue);

                if (MyQueueNumber.Rows.Count != 0)
                {
                    gv_queuedetails.Visible = true;
                    //queuestatusbel.TransferID = Convert.ToInt16(MyQueueNumber.Rows[0][7].ToString());

                    // Creating Data Type Column On Run Time
                    MyQueueNumber.Columns.Add("Queue Status");
                    MyQueueNumber.Columns.Add("SL.NO");
                    MyQueueNumber.Columns.Add("Date of Birth");
                    DateTime dob = new DateTime();
                    // Assigning String To Data Type Column
                    foreach (DataRow queuestatus in MyQueueNumber.Rows)
                    {

                        if ((queuestatus["plan_transfer_id"].ToString() != string.Empty) || (queuestatus["unplan_transfer_id"].ToString()) != string.Empty)
                        {
                            if (queuestatus["plan_transfer_id"].ToString() != string.Empty)
                            {
                                rtview.TransferID = Convert.ToInt16(queuestatus["plan_transfer_id"].ToString());
                            }
                            else
                            {
                                rtview.TransferID = Convert.ToInt16(queuestatus["unplan_transfer_id"].ToString());
                            }
                            string MyQueueStatus = bal.GetMyQueueStatus(rtview);

                            queuestatus["Queue Status"] = MyQueueStatus;

                        }

                        else
                        {
                            queuestatus["Queue Status"] = "Pending";
                        }


                        queuestatus["SL.NO"] = slno;

                        slno = slno + 1;

                        dob = Convert.ToDateTime(queuestatus["members_dob"].ToString());
                        queuestatus["Date of Birth"] = dob.ToString("dd/M/yyyy");

                       

                    }

                   // lbl_getstatus.Visible = false;

                    //lbl_messagebox.Visible = false;
                }
                else
                {
                    gv_queuedetails.Visible = false;
                   // lbl_getstatus.Text = "No Records Found";
                   // lbl_getstatus.Visible = true;
                }
                //else
                //{
                //    lbl_messagebox.Text = "No Matching The Record";
                //    lbl_messagebox.Visible = true;
                //}

                gv_queuedetails.DataSource = MyQueueNumber;
                gv_queuedetails.DataBind();
            
        }
        catch (SqlException ex)
        {
            ex.ToString();
        }
        finally
        {
            MyQueueNumber = null;
            rtview = null;
         //dal = null;
        }
    }

    
    protected void lb_missedQ_SelectedIndexChanged(object sender, EventArgs e)
    {
         DataTable dtbl = new DataTable();
        DataTable dtbl1 = new DataTable();
        ArrayList arrplanjr = new ArrayList();
        //btn_callq.Enabled = true;
        lb_plannedlist.Items.Clear();
        // btn_transferq.Enabled = true;
       
            try
            {
                if (txt_nextq.Text == null || txt_nextq.Text == "")
                {
                    rtcntrl = new RTBAL();
                    rtview = new RTBEL();
                    rtview.CustomerVisitId = Convert.ToInt64(lb_missedQ.SelectedValue);

                    string selecteQueueCount = lb_missedQ.SelectedItem.ToString();
                    UpdatePatientInfoGridViewbyQueue(selecteQueueCount);

                    rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
                    dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                    if (dtbl.Rows.Count > 0)
                    {
                        // btn_callq.Enabled = true;

                        btn_mandataendq.Enabled = true;
                        btn_mandatamissedq.Enabled = false;
                        btn_mandatamissedqcall.Enabled = true;
                        btn_nextq.Enabled = false;

                        lb_freshQ.SelectedIndex = -1;
                        lb_holdQ.SelectedIndex = -1;
                        DateTime dob = new DateTime();
                        foreach (DataRow dr in dtbl.Rows)
                        {
                            //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                            txt_esicno.Text = dr["visit_customer_id"].ToString();
                            txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                            dob= Convert.ToDateTime(dr["members_dob"].ToString());
                            txt_age.Text  =dob.ToString("dd/M/yyyy");
                            if (dr["members_gender"].ToString() == "M")
                            {
                                txt_gender.Text = "Male";
                            }
                            else
                            {
                                txt_gender.Text = "Female";
                            }
                            txt_relation.Text = dr["customer_appointment_time"].ToString();
                            txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                        }

                        dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                        if (dtbl1.Rows.Count > 0)
                        {
                            // btn_callq.Enabled = true;

                            lb_freshQ.SelectedIndex = -1;

                            foreach (DataRow dr1 in dtbl1.Rows)
                            {
                                string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                                long planid = Int64.Parse(dr1["plan_id"].ToString());
                                arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                            }
                            lb_plannedlist.DataSource = arrplanjr;
                            lb_plannedlist.DataTextField = "Display";
                            lb_plannedlist.DataValueField = "Value";
                            lb_plannedlist.DataBind();
                        }

                        btn_callq.Enabled = false;
                        btn_nextq.Enabled = true;
                    }
                    else
                    {
                        btn_callq.Enabled = false;

                        btn_mandataendq.Enabled = true;
                        btn_mandatamissedq.Enabled = false;
                        btn_mandatamissedqcall.Enabled = false;
                        btn_nextq.Enabled = true;


                        lb_freshQ.SelectedIndex = -1;
                        lb_holdQ.SelectedIndex = -1;

                        ClearAll();
                    }
                }
                else
                {
                    lb_missedQ.SelectedIndex = -1;
                    string script = "alert('Please end the current queue');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                dtbl = null;
                dtbl1 = null;
                arrplanjr = null;
            }

       
    }

   

        #region RT Screen - Button Disable

    private void ButtonDisable()
    {
        btn_callq.Enabled = false;
        btn_endq.Enabled = false;
        btn_missedq.Enabled = false;
        //btn_transferq.Enabled = false;
        btn_holdq.Enabled = false;
    }

    #endregion RT Screen - Button Disable
        #region RT Screen - Load Department

    private void LoadDepart()
    {
        DataTable dtbl = new DataTable();
        try
        {
            rtcntrl = new RTBAL();
            dtbl = rtcntrl.GetDepartmentDetail();
            if (dtbl.Rows.Count > 0)
            {
                //DataSet ds = new DataSet();
                //DataView view = new DataView(ds.Tables["MyTable"]);
                //view.RowFilter = "MyValue = 42"; // MyValue here is a column name

                //// Delete these rows.
                //foreach (DataRowView row in view)
                //{
                //    row.Delete();
                //}
                //dtbl.Rows[0].Delete();
                //dtbl.AcceptChanges();
                string removingdept = Server.UrlDecode(Request.QueryString["7"]);
                int removedept = Convert.ToInt16(removingdept);
                arrloaddepot.Add(new RTAddValue("Select", 0));
                foreach (DataRow dr in dtbl.Rows)
                {
                    string depotname = myTI.ToTitleCase(dr["department_desc"].ToString());
                    int depotid = Int32.Parse(dr["department_id"].ToString());
                    //if (removedept != depotid)
                    //{
                    arrloaddepot.Add(new RTAddValue(depotname, depotid));
                    //if (removedept == 6)
                    //{
                    //    if (depotid < 6)
                    //    {
                    //        arrloaddepot.Add(new RTAddValue(depotname, depotid));
                    //    }
                    //}
                    //else if (removedept != 6)
                    //{
                    //    if (depotid == 2 || depotid == 3 || depotid == 4 || depotid == 5 || depotid == 6)
                    //    {
                    //        arrloaddepot.Add(new RTAddValue(depotname, depotid));
                    //    }
                    //}
                    //}

                }

                //string removingdept = Server.UrlDecode(Request.QueryString["7"]);
                //int removedept = Convert.ToInt16(removingdept);
                //ddl_department.Items.RemoveAt(removedept);
                
                ddl_department.DataSource = arrloaddepot;
                ddl_department.DataTextField = "Display";
                ddl_department.DataValueField = "Value";
                ddl_department.DataBind();
            }
            else
            {
                arrloaddepot.Add(new RTAddValue("No Record", 0));
                ddl_department.DataSource = arrloaddepot;
                ddl_department.DataTextField = "Display";
                ddl_department.DataValueField = "Value";
                ddl_department.DataBind();
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

    #endregion RT Screen - Load Department
    private void LoadFreshQ()
    {
        DataTable dtbl = new DataTable();
        try
        {
            arrloadfreshq = new ArrayList();
            rtcntrl = new RTBAL();
            rtview = new RTBEL();
            rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
            dtbl = rtcntrl.GetQueueNoDetail(rtview);
            if (dtbl.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbl.Rows)
                {
                    string queueno = myTI.ToTitleCase(dr["queue_show"].ToString());
                    long visittnxid = Int64.Parse(dr["visit_tnx"].ToString());
                    arrloadfreshq.Add(new RTAddValue(queueno, visittnxid));

                }
                lb_freshQ.DataSource = arrloadfreshq;
                lb_freshQ.DataTextField = "Display";
                lb_freshQ.DataValueField = "Value";
                lb_freshQ.DataBind();
            }
            else
            {
                arrloadfreshq.Add(new RTAddValue("No Record", 0));
                lb_freshQ.DataSource = arrloadfreshq;
                lb_freshQ.DataTextField = "Display";
                lb_freshQ.DataValueField = "Value";
                lb_freshQ.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
            arrloadfreshq = null;
        }
    }

    
     #region RT Screen - Load Missed Queue

    private void LoadMissedQ()
    {
        DataTable dtbl = new DataTable();
        try
        {
            rtcntrl = new RTBAL();
            rtview = new RTBEL();
            arrloadmissedq = new ArrayList();
            rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
            dtbl = rtcntrl.GetMissedQueueNoDetail(rtview);
            if (dtbl.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbl.Rows)
                {
                    string queueno = myTI.ToTitleCase(dr["queue_show"].ToString());
                    long visittnxid = Int64.Parse(dr["visit_tnx"].ToString());
                    arrloadmissedq.Add(new RTAddValue(queueno, visittnxid));

                }
                lb_missedQ.DataSource = arrloadmissedq;
                lb_missedQ.DataTextField = "Display";
                lb_missedQ.DataValueField = "Value";
                lb_missedQ.DataBind();
            }
            else
            {
                arrloadmissedq.Add(new RTAddValue("No Record", 0));
                lb_missedQ.DataSource = arrloadmissedq;
                lb_missedQ.DataTextField = "Display";
                lb_missedQ.DataValueField = "Value";
                lb_missedQ.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
            arrloadmissedq = null;
        }
    }

    #endregion RT Screen - Load Missed Queue
      #region RT Screen - Loading Department List In List Box 1

    private void ListBoxLoadDepart()
    {
        DataTable dtbl = new DataTable();
        ListItem list1 = new ListItem();
        listboxarrloaddepot = new ArrayList();
        try
        {
            rtcntrl = new RTBAL();
            dtbl = rtcntrl.GetDepartmentDetail();
            if (dtbl.Rows.Count > 0)
            {

                foreach (DataRow dr in dtbl.Rows)
                {
                    string depotname = myTI.ToTitleCase(dr["department_desc"].ToString());
                    int depotid = Int32.Parse(dr["department_id"].ToString());
                    listboxarrloaddepot.Add(new RTAddValue(depotname, depotid));

                }

                lb_deptlist.DataSource = listboxarrloaddepot;
                lb_deptlist.DataTextField = "Display";
                lb_deptlist.DataValueField = "Value";
                lb_deptlist.DataBind();
            }
            else
            {
                listboxarrloaddepot.Add(new RTAddValue("No Record", 0));
                //arrloaddepot.Sort();
                lb_deptlist.DataSource = listboxarrloaddepot;
                lb_deptlist.DataTextField = "Display";
                lb_deptlist.DataValueField = "Value";
                lb_deptlist.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
            listboxarrloaddepot = null;
        }
    }

    #endregion RT Screen - Loading Department List In List Box 1
        #region RT Screen - Load 

    private void RLoad()
    {
        DataTable dtbl = new DataTable();
        try
        {
            ArrayList arrplanjr = new ArrayList();
            rtcntrl = new RTBAL();
            rtview = new RTBEL();
            rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
            rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
            
            #region Checking Serving Queue

              dtbl = rtcntrl.Getload(rtview);

              if (dtbl.Rows.Count > 0)
              {
                  foreach (DataRow ds in dtbl.Rows)
                  {
                      lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                      lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                      lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();

                  }

                  rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);
                  dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                  DateTime dob2 = new DateTime();
                  if (dtbl.Rows.Count > 0)
                  {

                      foreach (DataRow dr in dtbl.Rows)
                      {
                          //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                          txt_esicno.Text = dr["visit_customer_id"].ToString();

                          txt_patname.Text =dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                          dob2 = Convert.ToDateTime(dr["members_dob"].ToString());
                          txt_age.Text = dob2.ToString("dd/M/yyyy");
                          if (dr["members_gender"].ToString() == "M")
                          {
                              txt_gender.Text = "Male";
                          }
                          else
                          {
                              txt_gender.Text = "Female";
                          }
                          txt_relation.Text = dr["customer_appointment_time"].ToString();
                          txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                      }

                      dtbl = rtcntrl.GetQueuePlanList(rtview);
                      if (dtbl.Rows.Count > 0)
                      {
                          //btn_callq.Enabled = true;

                          lb_missedQ.SelectedIndex = -1;

                          foreach (DataRow dr1 in dtbl.Rows)
                          {
                              string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                              long planid = Int64.Parse(dr1["plan_id"].ToString());
                              arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                          }
                          lb_plannedlist.DataSource = arrplanjr;
                          lb_plannedlist.DataTextField = "Display";
                          lb_plannedlist.DataValueField = "Value";
                          lb_plannedlist.DataBind();
                      }
                  }


                  //rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                  //rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                  //rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                  //rtview.QueueStatusID = 2;
                  //vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);
                  txt_nextq.Text = lbl_queueno_show.Text;

                  UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                  btn_mandatamissedq.Enabled = true;
                  btn_recall.Enabled = true;
                  // btn_nextq.Enabled = true;

                  //if (vipupdatesucess == "1")
                  //{
                  //    lbl_msg.Visible = true;
                  //    lbl_msg.Text = "VIP Queue not Called";
                  //}

                  lb_deptlist.Enabled = true;
                  lb_seldeptlist.Enabled = true;
                  btn_l1tol2.Enabled = true;
                  btn_l2tol1.Enabled = true;
                  btn_up.Enabled = true;
                  btn_down.Enabled = true;
              }
              else
              {
                  txt_nextq.Text = string.Empty;
                  lbl_queuetransactionid.Text = "Queue Transaction Id";
                  lbl_visittransactionid.Text = "Visit Transaction Id";
                  lbl_queueno_show.Text = "Queue Number Show";
                  btn_recall.Enabled = false;

                  lb_deptlist.Enabled = false;
                  lb_seldeptlist.Enabled = false;
                  btn_l1tol2.Enabled = false;
                  btn_l2tol1.Enabled = false;
                  btn_up.Enabled = false;
                  btn_down.Enabled = false;
                  btn_addservices.Enabled = false;
                  lb_seldeptlist.Items.Clear();
                  ListBoxLoadDepart();
                  ClearAll();
              }
            #endregion Walkin Checking 1
                btn_nextq.Enabled = true;
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in load", ex);
        }
        finally
        {
            dtbl = null;
            arrloadfreshq = null;
        }
    }

    #endregion RT Screen - Load 
      #region RT Screen - Clear All

    private void ClearAll()
    {
        txt_esicno.Text = string.Empty;
        txt_customername.Text = string.Empty;
        txt_patname.Text = string.Empty;
        txt_gender.Text = string.Empty;
        txt_age.Text = string.Empty;
        txt_relation.Text = string.Empty;
        lb_plannedlist.Items.Clear();

        gv_queuedetails.DataSource = null;
        gv_queuedetails.DataBind();
    }

    #endregion RT Screen - Clear All
protected void  lb_freshQ_SelectedIndexChanged(object sender, EventArgs e)
{
     DataTable dtbl = new DataTable();
        DataTable dtbl1 = new DataTable();
        ArrayList arrplanjr = new ArrayList();
        btn_callq.Enabled = true;
        lb_plannedlist.Items.Clear();
        // btn_transferq.Enabled = true;
        try
        {
            if (txt_nextq.Text == null || txt_nextq.Text == "")
            {
                rtcntrl = new RTBAL();
                rtview = new RTBEL();
                rtview.CustomerVisitId = Convert.ToInt64(lb_freshQ.SelectedValue);

                string selectedQueueno = lb_freshQ.SelectedItem.ToString();
                UpdatePatientInfoGridViewbyQueue(selectedQueueno);

                rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
                dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                if (dtbl.Rows.Count > 0)
                {
                    btn_callq.Enabled = true;

                    lb_missedQ.SelectedIndex = -1;
                    lb_holdQ.SelectedIndex = -1;
                    DateTime dob1 = new DateTime();
                    foreach (DataRow dr in dtbl.Rows)
                    {
                        //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                        txt_esicno.Text = dr["visit_customer_id"].ToString();
                        txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                        dob1 = Convert.ToDateTime(dr["members_dob"].ToString());
                        txt_age.Text = dob1.ToString("dd/M/yyyy");
                        if (dr["members_gender"].ToString() == "M")
                        {
                            txt_gender.Text = "Male";
                        }
                        else
                        {
                            txt_gender.Text = "Female";
                        }
                        txt_relation.Text = dr["customer_appointment_time"].ToString();
                        txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                    }

                    dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                    if (dtbl1.Rows.Count > 0)
                    {
                        btn_callq.Enabled = true;

                        lb_missedQ.SelectedIndex = -1;

                        foreach (DataRow dr1 in dtbl1.Rows)
                        {
                            string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                            long planid = Int64.Parse(dr1["plan_id"].ToString());
                            arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                        }
                        lb_plannedlist.DataSource = arrplanjr;
                        lb_plannedlist.DataTextField = "Display";
                        lb_plannedlist.DataValueField = "Value";
                        lb_plannedlist.DataBind();
                    }

                    btn_mandatamissedqcall.Enabled = false;
                }
                else
                {
                    btn_callq.Enabled = false;

                    lb_missedQ.SelectedIndex = -1;

                    ClearAll();

                    btn_mandatamissedqcall.Enabled = false;

                }
            }
            else
            {
                btn_callq.Enabled = false;
                lb_freshQ.SelectedIndex = -1;
                string script = "alert('Please end the current queue');";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            dtbl = null;
            dtbl1 = null;
            arrplanjr = null;
        }
}
protected void btn_callq_Click(object sender, ImageClickEventArgs e)
{
    DataTable dtbl = new DataTable();
    DataTable GettingQueueNo = new DataTable();
    DataTable SearchingQueueNo = new DataTable();
    DataTable InsertingAutoSMS = new DataTable();
    DataTable dtGettingTransactionId = new DataTable();

    updatesuccess = string.Empty;
    try
    {
        rtcntrl = new RTBAL();
        rtview = new RTBEL();
        rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
        if (lb_freshQ.SelectedValue == "0" || lb_freshQ.SelectedValue == string.Empty)
        {
            if (lb_holdQ.SelectedValue == "0" || lb_holdQ.SelectedValue == string.Empty)
            {
                rtview.CustomerVisitId = Convert.ToInt64(lb_missedQ.SelectedValue);
            }
            else
            {
                rtview.CustomerVisitId = Convert.ToInt64(lb_holdQ.SelectedValue);
            }
            dtbl = rtcntrl.GetMissedVisitFunction(rtview);

            lb_freshQ.Enabled = false;
            //HyperLink1.Enabled = false;
        }
        else if (lb_missedQ.SelectedValue == "0" || lb_missedQ.SelectedValue == string.Empty)
        {
            rtview.CustomerVisitId = Convert.ToInt64(lb_freshQ.SelectedValue);

            // Showing Values To User

            lbl_visittransactionid.Text = Convert.ToString(lb_freshQ.SelectedValue);

            dtGettingTransactionId = rtcntrl.GettingFreshQueueTransactionId(rtview);

            if (dtGettingTransactionId.Rows.Count > 0)
            {
                foreach (DataRow dr in dtGettingTransactionId.Rows)
                {

                    lbl_queuetransactionid.Text = Convert.ToString(dr["queue_tnx_id"].ToString());
                    lbl_queueno_show.Text = Convert.ToString(dr["visit_queue_no_show"].ToString());

                }
                txt_nextq.Text = lbl_queueno_show.Text;

            }

            dtbl = rtcntrl.GetCallVisitFunction(rtview);

            //GettingQueueNo = rtcntrl.GetQueueNo(rtview);

            //foreach (DataRow ds in GettingQueueNo.Rows)
            //{
            //    string QueueNo = ds["visit_queue_no"].ToString();
            //    string[] splitted = QueueNo.Split('-');
            //    splitted[1] = Convert.ToString(int.Parse(splitted[1]) + AutoSMS);
            //    rtview.SearchQueueNo = splitted[0] + "-" + splitted[1];

            //    SearchingQueueNo = rtcntrl.SearchQueueNo(rtview);

            //    foreach (DataRow dr in SearchingQueueNo.Rows)
            //    {
            //        rtview.CustomerVisitId = Convert.ToInt64(dr["visit_tnx_id"].ToString());
            //    }

            // Previous Coding Dummy For DM Health Care Bangalore

            //if (SearchingQueueNo.Rows.Count > 0)
            //{
            //    rtview.SMSStatusFlag = "A";

            //    InsertingAutoSMS = rtcntrl.InsertAutoSMS(rtview);
            //}
            //}

            lb_holdQ.Enabled = false;
            //HyperLink1.Enabled = false;

        }

        if (dtbl.Rows.Count > 0)
        {
            foreach (DataRow dr in dtbl.Rows)
            {
                //string depotname = myTI.ToTitleCase(dr["department_desc"].ToString());
                rtview.CustomerQueueTnx = Int64.Parse(dr["queue_tnx_id"].ToString());

            }
            rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
            rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
            rtview.QueueStatusID = 2;
            rtview.SMSStatusFlag = "N";
            rtview.ButtonEventFlag = "E";
            updatesuccess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);

            if (updatesuccess == "1")
            {
                lbl_msg.Visible = true;
                lbl_msg.Text = "Queue not Called";
            }


            UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

            lb_deptlist.Enabled = true;
            lb_seldeptlist.Enabled = true;
            btn_l1tol2.Enabled = true;
            btn_l2tol1.Enabled = true;
            btn_up.Enabled = true;
            btn_down.Enabled = true;


        }
        // lb_freshQ.Enabled = false;
        // lb_missedQ.Enabled = false;
        btn_transferq.Enabled = true;
        btn_callq.Enabled = false;
        // btn_endq.Enabled = true;
        // btn_missedq.Enabled = true;
        // btn_holdq.Enabled = true;
        //HyperLink1.Enabled = false;
        btn_mandatamissedq.Enabled = true;
        btn_recall.Enabled = true;
        btn_mandataendq.Enabled = true;
        LoadFreshQ();

    }
    catch (Exception ex)
    {
        throw new Exception("Problem in call", ex);
    }
    finally
    {
        dtbl = null;
        GettingQueueNo = null;
        SearchingQueueNo = null;
        InsertingAutoSMS = null;
        updatesuccess = string.Empty;

    }
}
protected void btn_mandataendq_Click(object sender, ImageClickEventArgs e)
{
    DataTable dtGettingNextOrder = new DataTable();

    try
    {
        rtcntrl = new RTBAL();
        rtview = new RTBEL();

        if (lbl_queuetransactionid.Text != "Queue Transaction Id")
        {
            rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));

            rtview.CustomerQueueTnx = Convert.ToInt32(lbl_queuetransactionid.Text);
            rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
            rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
            rtview.QueueStatusID = 3;
            updatesuccess = rtcntrl.UpdateQueuestatusforEND(rtview);
            if (updatesuccess == "1")
            {
                lbl_msg.Visible = true;
                lbl_msg.Text = "Queue not Updated to End";
            }

            rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);

            dtGettingNextOrder = rtcntrl.GettingNextOrder(rtview);

            if (dtGettingNextOrder.Rows.Count > 0)
            {
                foreach (DataRow dr in dtGettingNextOrder.Rows)
                {
                    rtview.QueuePlanTnxId = Convert.ToInt32(dr["plan_id"].ToString());
                    rtview.OrderId = Convert.ToInt32(dr["plan_order_id"].ToString());
                    rtview.DepartmentId = Convert.ToInt32(dr["plan_department_id"].ToString());

                }
                rtview.QueueStatusID = 1;
                rtview.SMSStatusFlag = "N";
                rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                insertsuccess = rtcntrl.AddCustomerQueueTransactions(rtview);

                if (insertsuccess == "1")
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "Transactions Not Inserted";
                }
                DataTable dtblqueuetrans = rtcntrl.GetLastQueueTransactionID(rtview);
                if (dtblqueuetrans.Rows.Count > 0)
                {
                    foreach (DataRow dr2 in dtblqueuetrans.Rows)
                    {
                        rtview.CustomerQueueTnx = Convert.ToInt64(dr2["queue_tnx_id"].ToString());
                    }
                    updatesuccess = rtcntrl.UpdateTransaferIdtoPlan(rtview);

                    if (updatesuccess == "1")
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "Order not updated";
                    }
                }


            }

            txt_nextq.Text = string.Empty;
            lbl_queuetransactionid.Text = "Queue Transaction Id";
            lbl_visittransactionid.Text = "Visit Transaction Id";
            lbl_queueno_show.Text = "Queue Number Show";
            btn_recall.Enabled = false;

            lb_deptlist.Enabled = false;
            lb_seldeptlist.Enabled = false;
            btn_l1tol2.Enabled = false;
            btn_l2tol1.Enabled = false;
            btn_up.Enabled = false;
            btn_down.Enabled = false;
            btn_addservices.Enabled = false;
            lb_seldeptlist.Items.Clear();
            ListBoxLoadDepart();


            ClearAll();
        }
    }
    catch (Exception ex)
    {
        throw new Exception("Problem in End Queue", ex);
    }
    finally
    {
        dtGettingNextOrder = null;
    }
}
protected void btn_mandatamissedq_Click(object sender, ImageClickEventArgs e)
{
    try
    {
        rtcntrl = new RTBAL();
        rtview = new RTBEL();

        rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));

        if (lbl_queuetransactionid.Text != "Queue Transaction Id")
        {
            rtview.CustomerQueueTnx = Convert.ToInt32(lbl_queuetransactionid.Text);

            rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
            rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
            rtview.QueueStatusID = 4;
            rtview.SMSStatusFlag = "M";
            updatesuccess = rtcntrl.UpdateQueuestatusforCallMissedSMS(rtview);

            if (updatesuccess == "1")
            {
                lbl_msg.Visible = true;
                lbl_msg.Text = "Queue not Missed";
            }

            txt_nextq.Text = string.Empty;
            lbl_queuetransactionid.Text = "Queue Transaction Id";
            lbl_visittransactionid.Text = "Visit Transaction Id";
            lbl_queueno_show.Text = "Queue Number Show";


            ClearAll();

            btn_mandatamissedq.Enabled = false;
            btn_mandataendq.Enabled = false;
            btn_recall.Enabled = false;

            lb_deptlist.Enabled = false;
            lb_seldeptlist.Enabled = false;
            btn_l1tol2.Enabled = false;
            btn_l2tol1.Enabled = false;
            btn_up.Enabled = false;
            btn_down.Enabled = false;
            btn_addservices.Enabled = false;
            lb_seldeptlist.Items.Clear();
            ListBoxLoadDepart();

            LoadFreshQ();
            LoadMissedQ();
            LoadPendingQ();
            LoadHoldQ();
        }
    }
    catch (Exception ex)
    {
        throw new Exception("Problem in Missed Queue", ex);
    }
    finally
    {

    }
}
protected void btn_mandatamissedqcall_Click(object sender, ImageClickEventArgs e)
{
    DataTable dtGettingNextOrder = new DataTable();
    DataTable dtbl = new DataTable();
    DataTable dtGettingTransactionId = new DataTable();

    try
    {
        rtcntrl = new RTBAL();
        rtview = new RTBEL();

        // End Serving Queue For Calling Missed Queue

        if (txt_nextq.Text != string.Empty)
        {

            rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));

            rtview.CustomerQueueTnx = Convert.ToInt32(lbl_queuetransactionid.Text);
            rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
            rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
            rtview.QueueStatusID = 3;
            updatesuccess = rtcntrl.UpdateQueuestatusforEND(rtview);
            if (updatesuccess == "1")
            {
                lbl_msg.Visible = true;
                lbl_msg.Text = "Queue not Updated to End";
            }

            rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);

            dtGettingNextOrder = rtcntrl.GettingNextOrder(rtview);

            if (dtGettingNextOrder.Rows.Count > 0)
            {
                foreach (DataRow dr in dtGettingNextOrder.Rows)
                {
                    rtview.QueuePlanTnxId = Convert.ToInt32(dr["plan_id"].ToString());
                    rtview.OrderId = Convert.ToInt32(dr["plan_order_id"].ToString());
                    rtview.DepartmentId = Convert.ToInt32(dr["plan_department_id"].ToString());

                }

                rtview.QueueStatusID = 1;
                rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                rtview.SMSStatusFlag = "N";
                insertsuccess = rtcntrl.AddCustomerQueueTransactions(rtview);

                if (insertsuccess == "1")
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "Transactions Not Inserted";
                }
                DataTable dtblqueuetrans = rtcntrl.GetLastQueueTransactionID(rtview);
                if (dtblqueuetrans.Rows.Count > 0)
                {
                    foreach (DataRow dr2 in dtblqueuetrans.Rows)
                    {
                        rtview.CustomerQueueTnx = Convert.ToInt64(dr2["queue_tnx_id"].ToString());
                    }
                    updatesuccess = rtcntrl.UpdateTransaferIdtoPlan(rtview);

                    if (updatesuccess == "1")
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "Order not updated";
                    }
                }


            }

            // Calling Now Missed Queue From List View

            rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
            rtview.CustomerVisitId = Convert.ToInt64(lb_missedQ.SelectedValue);

            lbl_visittransactionid.Text = Convert.ToString(lb_missedQ.SelectedValue);

            dtGettingTransactionId = rtcntrl.GettingTransactionId(rtview);

            if (dtGettingTransactionId.Rows.Count > 0)
            {
                foreach (DataRow dr in dtGettingTransactionId.Rows)
                {

                    lbl_queuetransactionid.Text = Convert.ToString(dr["queue_tnx_id"].ToString());
                    lbl_queueno_show.Text = Convert.ToString(dr["visit_queue_no_show"].ToString());

                }
                txt_nextq.Text = lbl_queueno_show.Text;

            }

            dtbl = rtcntrl.GetMissedVisitFunction(rtview);

            if (dtbl.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbl.Rows)
                {
                    //string depotname = myTI.ToTitleCase(dr["department_desc"].ToString());
                    rtview.CustomerQueueTnx = Int64.Parse(dr["queue_tnx_id"].ToString());

                }
                rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                rtview.QueueStatusID = 2;
                rtview.SMSStatusFlag = "N";
                updatesuccess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);

                if (updatesuccess == "1")
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "Queue not Called";
                }

            }
            UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

            lb_deptlist.Enabled = true;
            lb_seldeptlist.Enabled = true;
            btn_l1tol2.Enabled = true;
            btn_l2tol1.Enabled = true;
            btn_up.Enabled = true;
            btn_down.Enabled = true;

        }

        else if (txt_nextq.Text == string.Empty)
        {
            // Calling Now Missed Queue From List View

            rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));

            rtview.CustomerVisitId = Convert.ToInt64(lb_missedQ.SelectedValue);

            lbl_visittransactionid.Text = Convert.ToString(lb_missedQ.SelectedValue);

            dtGettingTransactionId = rtcntrl.GettingTransactionId(rtview);

            if (dtGettingTransactionId.Rows.Count > 0)
            {
                foreach (DataRow dr in dtGettingTransactionId.Rows)
                {

                    lbl_queuetransactionid.Text = Convert.ToString(dr["queue_tnx_id"].ToString());
                    lbl_queueno_show.Text = Convert.ToString(dr["visit_queue_no_show"].ToString());

                }
                txt_nextq.Text = lbl_queueno_show.Text;

            }
            dtbl = rtcntrl.GetMissedVisitFunction(rtview);

            if (dtbl.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbl.Rows)
                {
                    //string depotname = myTI.ToTitleCase(dr["department_desc"].ToString());
                    rtview.CustomerQueueTnx = Int64.Parse(dr["queue_tnx_id"].ToString());

                }
                rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                rtview.QueueStatusID = 2;
                rtview.SMSStatusFlag = "N";
                rtview.ButtonEventFlag = "N";
                updatesuccess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);

                if (updatesuccess == "1")
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "Queue not Called";
                }

            }
            UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

            lb_deptlist.Enabled = true;
            lb_seldeptlist.Enabled = true;
            btn_l1tol2.Enabled = true;
            btn_l2tol1.Enabled = true;
            btn_up.Enabled = true;
            btn_down.Enabled = true;

        }

        LoadFreshQ();
        LoadMissedQ();
        LoadHoldQ();
        LoadPendingQ();
        btn_nextq.Enabled = true;
        btn_mandatamissedq.Enabled = true;
        btn_mandataendq.Enabled = true;
        btn_mandatamissedqcall.Enabled = false;
        btn_recall.Enabled = true;
    }
    catch (Exception ex)
    {
        throw new Exception("Problem in Missed Queue Again Calling", ex);
    }
    finally
    {
        dtGettingNextOrder = null;
        dtbl = null;
        dtGettingTransactionId = null;
    }
}
#region RT Screen - Load Hold Queue

private void LoadHoldQ()
{
    DataTable dtbl = new DataTable();
    try
    {
        rtcntrl = new RTBAL();
        rtview = new RTBEL();
        arrloadholdq = new ArrayList();
        rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
        dtbl = rtcntrl.GetHoldQueueNoDetail(rtview);
        rtview.lbholdcount = dtbl.Rows.Count;
        if (dtbl.Rows.Count > 0)
        {
            foreach (DataRow dr in dtbl.Rows)
            {
                string queueno = myTI.ToTitleCase(dr["queue_show"].ToString());
                long visittnxid = Int64.Parse(dr["visit_tnx"].ToString());
                arrloadholdq.Add(new RTAddValue(queueno, visittnxid));

            }
            lb_holdQ.DataSource = arrloadholdq;
            lb_holdQ.DataTextField = "Display";
            lb_holdQ.DataValueField = "Value";
            lb_holdQ.DataBind();
        }
        else
        {
            arrloadholdq.Add(new RTAddValue("No Record", 0));
            lb_holdQ.DataSource = arrloadholdq;
            lb_holdQ.DataTextField = "Display";
            lb_holdQ.DataValueField = "Value";
            lb_holdQ.DataBind();
        }
    }
    catch (Exception ex)
    {
        throw new Exception("Problem in department hold", ex);
    }
    finally
    {
        dtbl = null;
        arrloadholdq = null;
    }
}

#endregion RT Screen - Load Hold Queue
#region RT Screen - Load Pending Queue

private void LoadPendingQ()
{
    DataTable dtbl = new DataTable();
    try
    {
        rtcntrl = new RTBAL();
        rtview = new RTBEL();
        arrloadpendingq = new ArrayList();
        rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));
        dtbl = rtcntrl.GetPendingQueueNoDetail(rtview);
        rtview.lbholdcount = dtbl.Rows.Count;
        if (dtbl.Rows.Count > 0)
        {
            foreach (DataRow dr in dtbl.Rows)
            {
                string queueno = myTI.ToTitleCase(dr["queue_show"].ToString());
                long visittnxid = Int64.Parse(dr["visit_tnx"].ToString());
                arrloadpendingq.Add(new RTAddValue(queueno, visittnxid));

            }
            lb_pendingQ.DataSource = arrloadpendingq;
            lb_pendingQ.DataTextField = "Display";
            lb_pendingQ.DataValueField = "Value";
            lb_pendingQ.DataBind();
        }
        else
        {
            arrloadpendingq.Add(new RTAddValue("No Record", 0));
            lb_pendingQ.DataSource = arrloadpendingq;
            lb_pendingQ.DataTextField = "Display";
            lb_pendingQ.DataValueField = "Value";
            lb_pendingQ.DataBind();
        }
    }
    catch (Exception ex)
    {
        throw new Exception("Problem in Loading Pending Queue", ex);
    }
    finally
    {
        dtbl = null;
        arrloadpendingq = null;
    }
}

#endregion RT Screen - Load Pending Queue
protected void btn_nextq_Click(object sender, ImageClickEventArgs e)
{
    DataTable dtNextVIPQueue = new DataTable();

    string vipupdatesucess = string.Empty;

    DataTable dtNextAppointmentQueue = new DataTable();

    string appointmentupdatesucess = string.Empty;

    DataTable dtNextWalkinQueue = new DataTable();

    string walkinupdatesucess = string.Empty;

    DataTable dtGettingNextOrder = new DataTable();
    DataTable dtbl = new DataTable();
    DataTable dtbl1 = new DataTable();

    ArrayList arrplanjr = new ArrayList();
    try
    {
        rtcntrl = new RTBAL();
        rtview = new RTBEL();
        rtview.DepartmentId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["7"]));

        #region Checking Department 15 Or Not

        // btn_nextq_Click(sender,e);
        AppointmentToWalkin = 0;


        #region Checking Queue No Null

        if (lbl_queueno_show.Text == "Queue Number Show")
        {

            dtNextVIPQueue = rtcntrl.GetNextVIPQueue(rtview);

            #region Next VIP Queue Checking

            if (dtNextVIPQueue.Rows.Count > 0 && AppointmentToWalkin != 1)
            {
                foreach (DataRow ds in dtNextVIPQueue.Rows)
                {
                    lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                    lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                    lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();
                }
                rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);
                dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                if (dtbl.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtbl.Rows)
                    {
                        //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                        txt_esicno.Text = dr["visit_customer_id"].ToString();
                        txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                        txt_age.Text = dr["members_age"].ToString();
                        if (dr["members_gender"].ToString() == "M")
                        {
                            txt_gender.Text = "Male";
                        }
                        else
                        {
                            txt_gender.Text = "Female";
                        }
                        //txt_relation.Text = dr["relation_desc"].ToString();
                        txt_relation.Text = dr["customer_appointment_time"].ToString();
                        txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                    }

                    dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                    if (dtbl1.Rows.Count > 0)
                    {
                        //btn_callq.Enabled = true;

                        lb_missedQ.SelectedIndex = -1;

                        foreach (DataRow dr1 in dtbl1.Rows)
                        {
                            string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                            long planid = Int64.Parse(dr1["plan_id"].ToString());
                            arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                        }
                        lb_plannedlist.DataSource = arrplanjr;
                        lb_plannedlist.DataTextField = "Display";
                        lb_plannedlist.DataValueField = "Value";
                        lb_plannedlist.DataBind();
                    }
                }



                rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                rtview.QueueStatusID = 2;
                rtview.SMSStatusFlag = "N";
                rtview.ButtonEventFlag = "E";
                vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);
                txt_nextq.Text = lbl_queueno_show.Text;

                UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                if (vipupdatesucess == "1")
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "VIP Queue not Called";
                }

            }
            #endregion Next VIP Queue Checking

            #region Appointment Checking

            if (dtNextVIPQueue.Rows.Count == 0 && AppointmentToWalkin != 1)
            {

                dtNextAppointmentQueue = rtcntrl.GetNextAppointmentQueue(rtview);

                if (dtNextAppointmentQueue.Rows.Count > 0 && AppointmentToWalkin != 1)
                {
                    foreach (DataRow ds in dtNextAppointmentQueue.Rows)
                    {
                        lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                        lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                        lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();

                        ConsultationStartTime = ds["ConsultingStartTime"].ToString();
                        ConsultationEndTime = ds["ConsultingEndTime"].ToString();
                        //start = DateTime.Parse(ConsultationStartTime);
                        //end = DateTime.Parse(ConsultationEndTime);


                        //start = DateTime.ParseExact(ConsultationStartTime, "yyyyMMddHHmmssfff", CultureInfo.CurrentCulture);
                        //end = DateTime.ParseExact(ConsultationEndTime, "yyyyMMddHHmmssfff", CultureInfo.CurrentCulture);
                        now = DateTime.Now;
                        TimeSpan st1 = new TimeSpan(2, 0, 0);
                        start = now - st1;
                        TimeSpan st2 = new TimeSpan(2, 0, 0);
                        end = now + st2;
                        if ((now > start) && (now < end) && AppointmentToWalkin != 1)
                        {
                            rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                            rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                            rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                            rtview.QueueStatusID = 2;
                            rtview.SMSStatusFlag = "N";
                            rtview.ButtonEventFlag = "E";
                            vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);
                            txt_nextq.Text = lbl_queueno_show.Text;

                            UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                            if (vipupdatesucess == "1")
                            {
                                lbl_msg.Visible = true;
                                lbl_msg.Text = "Appointment Queue not Called";
                            }

                            rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);

                            dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                            if (dtbl.Rows.Count > 0)
                            {

                                foreach (DataRow dr in dtbl.Rows)
                                {
                                    //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                                    txt_esicno.Text = dr["visit_customer_id"].ToString();
                                    txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                                    txt_age.Text = dr["members_age"].ToString();
                                    if (dr["members_gender"].ToString() == "M")
                                    {
                                        txt_gender.Text = "Male";
                                    }
                                    else
                                    {
                                        txt_gender.Text = "Female";
                                    }
                                    txt_relation.Text = dr["customer_appointment_time"].ToString();
                                    txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                                }

                                dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                                if (dtbl1.Rows.Count > 0)
                                {
                                    //btn_callq.Enabled = true;

                                    lb_missedQ.SelectedIndex = -1;

                                    foreach (DataRow dr1 in dtbl1.Rows)
                                    {
                                        string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                                        long planid = Int64.Parse(dr1["plan_id"].ToString());
                                        arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                                    }
                                    lb_plannedlist.DataSource = arrplanjr;
                                    lb_plannedlist.DataTextField = "Display";
                                    lb_plannedlist.DataValueField = "Value";
                                    lb_plannedlist.DataBind();
                                }
                            }
                        }
                        else if ((now > end) && AppointmentToWalkin != 1)
                        {
                            rtview.SMSStatusFlag = "W";
                            rtview.CustomerVisitId = Convert.ToInt64(lbl_visittransactionid.Text);
                            vipupdatesucess = rtcntrl.UpdateAppointmentToWalkinStatus(rtview);
                            if (vipupdatesucess == "1")
                            {
                                lbl_msg.Visible = true;
                                lbl_msg.Text = "Appointment Changed To Walkin not Called";
                            }
                            else
                            {
                                //txt_nextq.Text = string.Empty;
                                //lbl_queueno_show.Text = "Queue Number Show";
                                //lbl_queuetransactionid.Text = "Queue Transaction Id";
                                //lbl_visittransactionid.Text = "Visit Transaction Id";
                                AppointmentToWalkin = 1;
                                CheckingAppointmentToWalkin = 1;

                            }

                        }
                    }

                }
            }

            #endregion Next Appointment Checking

            #region Walkin Checking 1

            if (dtNextVIPQueue.Rows.Count == 0 && dtNextAppointmentQueue.Rows.Count > 0 && !(now > start) && AppointmentToWalkin != 1)
            {
                dtNextWalkinQueue = rtcntrl.GetNextWalkinQueue(rtview);

                if (dtNextWalkinQueue.Rows.Count > 0)
                {
                    foreach (DataRow ds in dtNextWalkinQueue.Rows)
                    {
                        lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                        lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                        lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();

                    }

                    rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);
                    dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                    if (dtbl.Rows.Count > 0)
                    {

                        foreach (DataRow dr in dtbl.Rows)
                        {
                            //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                            txt_esicno.Text = dr["visit_customer_id"].ToString();
                            txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                            txt_age.Text = dr["members_age"].ToString();
                            if (dr["members_gender"].ToString() == "M")
                            {
                                txt_gender.Text = "Male";
                            }
                            else
                            {
                                txt_gender.Text = "Female";
                            }
                            // txt_relation.Text = dr["relation_desc"].ToString();
                            txt_relation.Text = dr["customer_appointment_time"].ToString();
                            txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                        }

                        dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                        if (dtbl1.Rows.Count > 0)
                        {
                            //btn_callq.Enabled = true;

                            lb_missedQ.SelectedIndex = -1;

                            foreach (DataRow dr1 in dtbl1.Rows)
                            {
                                string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                                long planid = Int64.Parse(dr1["plan_id"].ToString());
                                arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                            }
                            lb_plannedlist.DataSource = arrplanjr;
                            lb_plannedlist.DataTextField = "Display";
                            lb_plannedlist.DataValueField = "Value";
                            lb_plannedlist.DataBind();
                        }
                    }


                    rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                    rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                    rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                    rtview.QueueStatusID = 2;
                    rtview.SMSStatusFlag = "N";
                    rtview.ButtonEventFlag = "E";
                    vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);
                    txt_nextq.Text = lbl_queueno_show.Text;

                    UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                    if (vipupdatesucess == "1")
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "VIP Queue not Called";
                    }
                }
            }

            #endregion Walkin Checking 1

            #region Walkin Checking 2

            if (dtNextVIPQueue.Rows.Count == 0 && dtNextAppointmentQueue.Rows.Count == 0 && AppointmentToWalkin != 1)
            {
                dtNextWalkinQueue = rtcntrl.GetNextWalkinQueue(rtview);

                if (dtNextWalkinQueue.Rows.Count > 0)
                {
                    foreach (DataRow ds in dtNextWalkinQueue.Rows)
                    {
                        lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                        lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                        lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();

                    }

                    rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);
                    dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                    if (dtbl.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtbl.Rows)
                        {
                            //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                            txt_esicno.Text = dr["visit_customer_id"].ToString();
                            txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                            txt_age.Text = dr["members_age"].ToString();
                            if (dr["members_gender"].ToString() == "M")
                            {
                                txt_gender.Text = "Male";
                            }
                            else
                            {
                                txt_gender.Text = "Female";
                            }
                            // txt_relation.Text = dr["relation_desc"].ToString();
                            txt_relation.Text = dr["customer_appointment_time"].ToString();
                            txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                        }

                        dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                        if (dtbl1.Rows.Count > 0)
                        {
                            //btn_callq.Enabled = true;

                            lb_missedQ.SelectedIndex = -1;

                            foreach (DataRow dr1 in dtbl1.Rows)
                            {
                                string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                                long planid = Int64.Parse(dr1["plan_id"].ToString());
                                arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                            }
                            lb_plannedlist.DataSource = arrplanjr;
                            lb_plannedlist.DataTextField = "Display";
                            lb_plannedlist.DataValueField = "Value";
                            lb_plannedlist.DataBind();
                        }
                    }

                    rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                    rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                    rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                    rtview.QueueStatusID = 2;
                    rtview.SMSStatusFlag = "N";
                    rtview.ButtonEventFlag = "E";
                    vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);
                    txt_nextq.Text = lbl_queueno_show.Text;

                    UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                    if (vipupdatesucess == "1")
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "VIP Queue not Called";
                    }
                }
            }

            #endregion Walin Checking 2

            #region Appointment checking 2

            if (dtNextVIPQueue.Rows.Count == 0 && dtNextWalkinQueue.Rows.Count == 0 && (now < start) && AppointmentToWalkin != 1)
            {

                dtNextAppointmentQueue = rtcntrl.GetNextImmediateAppointmentQueue(rtview);

                if (dtNextAppointmentQueue.Rows.Count > 0)
                {
                    foreach (DataRow ds in dtNextAppointmentQueue.Rows)
                    {
                        lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                        lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                        lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();

                    }

                    rtview.CustomerVisitId = Convert.ToInt64(lbl_visittransactionid.Text);
                    dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                    if (dtbl.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtbl.Rows)
                        {
                            //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                            txt_esicno.Text = dr["visit_customer_id"].ToString();
                            txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                            txt_age.Text = dr["members_age"].ToString();
                            if (dr["members_gender"].ToString() == "M")
                            {
                                txt_gender.Text = "Male";
                            }
                            else
                            {
                                txt_gender.Text = "Female";
                            }
                            txt_relation.Text = dr["customer_appointment_time"].ToString();
                            txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                        }


                        dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                        if (dtbl1.Rows.Count > 0)
                        {
                            // btn_callq.Enabled = true;

                            lb_missedQ.SelectedIndex = -1;

                            foreach (DataRow dr1 in dtbl1.Rows)
                            {
                                string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                                long planid = Int64.Parse(dr1["plan_id"].ToString());
                                arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                            }
                            lb_plannedlist.DataSource = arrplanjr;
                            lb_plannedlist.DataTextField = "Display";
                            lb_plannedlist.DataValueField = "Value";
                            lb_plannedlist.DataBind();
                        }
                        rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                        rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                        rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                        rtview.QueueStatusID = 2;
                        rtview.SMSStatusFlag = "N";
                        rtview.ButtonEventFlag = "E";
                        vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);
                        txt_nextq.Text = lbl_queueno_show.Text;

                        UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                        if (vipupdatesucess == "1")
                        {
                            lbl_msg.Visible = true;
                            lbl_msg.Text = "Appointment Queue not Called";
                        }

                    }


                }
            }

            #endregion Appointment Checking 2

            // No Queue Token Or Not Checking

            #region No Queue Token Or Not Checking

            if (dtNextVIPQueue.Rows.Count == 0 && dtNextAppointmentQueue.Rows.Count == 0 && dtNextWalkinQueue.Rows.Count == 0 && AppointmentToWalkin != 1)
            {
                txt_nextq.Text = string.Empty;
                lbl_queueno_show.Text = "Queue Number Show";
                lbl_queuetransactionid.Text = "Queue Transaction Id";
                lbl_visittransactionid.Text = "Visit Transaction Id";

                ClearAll();

            }

            #endregion No Queue Token Or Not Checking

            lb_deptlist.Enabled = true;
            lb_seldeptlist.Enabled = true;
            btn_l1tol2.Enabled = true;
            btn_l2tol1.Enabled = true;
            btn_up.Enabled = true;
            btn_down.Enabled = true;
        }

        #endregion Checking Queue No Null

        #region Checking Queue No 2

        else if (lbl_queueno_show.Text != "Queue Number Show")
        {
            #region Ending & Call Next Order

            if (AppointmentToWalkin != 1 && CheckingAppointmentToWalkin != 1)
            {
                rtview.CustomerQueueTnx = Convert.ToInt32(lbl_queuetransactionid.Text);
                rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                rtview.QueueStatusID = 3;
                updatesuccess = rtcntrl.UpdateQueuestatusforEND(rtview);
                if (updatesuccess == "1")
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "Queue not Updated to End";
                }

                rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);

                dtGettingNextOrder = rtcntrl.GettingNextOrder(rtview);

                if (dtGettingNextOrder.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtGettingNextOrder.Rows)
                    {
                        rtview.QueuePlanTnxId = Convert.ToInt32(dr["plan_id"].ToString());
                        rtview.OrderId = Convert.ToInt32(dr["plan_order_id"].ToString());
                        rtview.DepartmentId = Convert.ToInt32(dr["plan_department_id"].ToString());

                    }

                    rtview.QueueStatusID = 1;
                    rtview.SMSStatusFlag = "N";
                    rtview.ButtonEventFlag = "E";
                    rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                    rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                    insertsuccess = rtcntrl.AddCustomerQueueTransactions(rtview);

                    if (insertsuccess == "1")
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "Transactions Not Inserted";
                    }
                    DataTable dtblqueuetrans = rtcntrl.GetLastQueueTransactionID(rtview);
                    if (dtblqueuetrans.Rows.Count > 0)
                    {
                        foreach (DataRow dr2 in dtblqueuetrans.Rows)
                        {
                            rtview.CustomerQueueTnx = Convert.ToInt64(dr2["queue_tnx_id"].ToString());
                        }
                        updatesuccess = rtcntrl.UpdateTransaferIdtoPlan(rtview);

                        if (updatesuccess == "1")
                        {
                            lbl_msg.Visible = true;
                            lbl_msg.Text = "Order not updated";
                        }
                    }


                }
            }
            #endregion End & Call Next Order

            // Retrieving Next Queue Number From Database Based On Priority

            dtNextVIPQueue = rtcntrl.GetNextVIPQueue(rtview);

            #region Next VIP Queue

            if (dtNextVIPQueue.Rows.Count > 0 && AppointmentToWalkin != 1)
            {
                foreach (DataRow ds in dtNextVIPQueue.Rows)
                {
                    lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                    lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                    lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();
                }

                rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);
                dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                if (dtbl.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtbl.Rows)
                    {
                        //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                        txt_esicno.Text = dr["visit_customer_id"].ToString();
                        txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                        txt_age.Text = dr["members_age"].ToString();
                        if (dr["members_gender"].ToString() == "M")
                        {
                            txt_gender.Text = "Male";
                        }
                        else
                        {
                            txt_gender.Text = "Female";
                        }
                        // txt_relation.Text = dr["relation_desc"].ToString();
                        txt_relation.Text = dr["customer_appointment_time"].ToString();
                        txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                    }

                    dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                    if (dtbl1.Rows.Count > 0)
                    {
                        // btn_callq.Enabled = true;

                        lb_missedQ.SelectedIndex = -1;

                        foreach (DataRow dr1 in dtbl1.Rows)
                        {
                            string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                            long planid = Int64.Parse(dr1["plan_id"].ToString());
                            arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                        }
                        lb_plannedlist.DataSource = arrplanjr;
                        lb_plannedlist.DataTextField = "Display";
                        lb_plannedlist.DataValueField = "Value";
                        lb_plannedlist.DataBind();
                    }
                }

                rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                rtview.QueueStatusID = 2;
                rtview.SMSStatusFlag = "N";
                rtview.ButtonEventFlag = "E";
                vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);
                if (Page.IsPostBack)
                {
                    txt_nextq.Text = lbl_queueno_show.Text;
                }

                UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                if (vipupdatesucess == "1")
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "VIP Queue not Called";
                }

            }

            #endregion Next VIP Queue

            #region Next Appointment Queue

            if (dtNextVIPQueue.Rows.Count == 0 && AppointmentToWalkin != 1)
            {
                dtNextAppointmentQueue = rtcntrl.GetNextAppointmentQueue(rtview);

                if (dtNextAppointmentQueue.Rows.Count > 0 && AppointmentToWalkin != 1)
                {
                    foreach (DataRow ds in dtNextAppointmentQueue.Rows)
                    {
                        lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                        lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                        lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();

                        ConsultationStartTime = ds["ConsultingStartTime"].ToString();
                        ConsultationEndTime = ds["ConsultingEndTime"].ToString();

                        start = DateTime.Parse(ConsultationStartTime);
                        end = DateTime.Parse(ConsultationEndTime);
                        //start = DateTime.ParseExact(ConsultationStartTime, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                        //end = DateTime.ParseExact(ConsultationEndTime, "yyyyMMddHHmmssfff", CultureInfo.CurrentCulture);
                        now = DateTime.Now;

                        if ((now > start) && (now < end) && AppointmentToWalkin != 1)
                        {
                            rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                            rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                            rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                            rtview.QueueStatusID = 2;
                            rtview.SMSStatusFlag = "N";
                            rtview.ButtonEventFlag = "E";
                            vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);
                            if (Page.IsPostBack)
                            {
                                txt_nextq.Text = lbl_queueno_show.Text;
                            }

                            UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                            if (vipupdatesucess == "1")
                            {
                                lbl_msg.Visible = true;
                                lbl_msg.Text = "Appointment Queue not Called";
                            }

                            rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);

                            dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                            if (dtbl.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtbl.Rows)
                                {
                                    //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                                    txt_esicno.Text = dr["visit_customer_id"].ToString();
                                    txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                                    txt_age.Text = dr["members_age"].ToString();
                                    if (dr["members_gender"].ToString() == "M")
                                    {
                                        txt_gender.Text = "Male";
                                    }
                                    else
                                    {
                                        txt_gender.Text = "Female";
                                    }
                                    txt_relation.Text = dr["customer_appointment_time"].ToString();
                                    txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                                }
                                dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                                if (dtbl1.Rows.Count > 0)
                                {
                                    //btn_callq.Enabled = true;

                                    lb_missedQ.SelectedIndex = -1;

                                    foreach (DataRow dr1 in dtbl1.Rows)
                                    {
                                        string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                                        long planid = Int64.Parse(dr1["plan_id"].ToString());
                                        arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                                    }
                                    lb_plannedlist.DataSource = arrplanjr;
                                    lb_plannedlist.DataTextField = "Display";
                                    lb_plannedlist.DataValueField = "Value";
                                    lb_plannedlist.DataBind();
                                }
                            }
                        }
                        else if (now > end)
                        {
                            rtview.SMSStatusFlag = "W";
                            rtview.CustomerVisitId = Convert.ToInt64(lbl_visittransactionid.Text);
                            vipupdatesucess = rtcntrl.UpdateAppointmentToWalkinStatus(rtview);
                            if (vipupdatesucess == "1")
                            {
                                lbl_msg.Visible = true;
                                lbl_msg.Text = "Appointment Changed To Walkin not Called";
                            }
                            else
                            {
                                //txt_nextq.Text = string.Empty;
                                //lbl_queueno_show.Text = "Queue Number Show";
                                //lbl_queuetransactionid.Text = "Queue Transaction Id";
                                //lbl_visittransactionid.Text = "Visit Transaction Id";
                                AppointmentToWalkin = 1;
                                CheckingAppointmentToWalkin = 1;

                            }
                        }
                    }

                }
            }

            #endregion Next Appointment Queue 1

            #region Next Walkin Queue

            if (dtNextVIPQueue.Rows.Count == 0 && dtNextAppointmentQueue.Rows.Count > 0 && !(now > start) && AppointmentToWalkin != 1)
            {
                dtNextWalkinQueue = rtcntrl.GetNextWalkinQueue(rtview);

                if (dtNextWalkinQueue.Rows.Count > 0)
                {
                    foreach (DataRow ds in dtNextWalkinQueue.Rows)
                    {
                        lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                        lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                        lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();

                    }

                    rtview.CustomerVisitId = Convert.ToInt64(lbl_visittransactionid.Text);
                    dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                    if (dtbl.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtbl.Rows)
                        {
                            //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                            txt_esicno.Text = dr["visit_customer_id"].ToString();
                            txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                            txt_age.Text = dr["members_age"].ToString();
                            if (dr["members_gender"].ToString() == "M")
                            {
                                txt_gender.Text = "Male";
                            }
                            else
                            {
                                txt_gender.Text = "Female";
                            }
                            txt_relation.Text = dr["customer_appointment_time"].ToString();
                            txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                        }

                        dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                        if (dtbl1.Rows.Count > 0)
                        {
                            // btn_callq.Enabled = true;

                            lb_missedQ.SelectedIndex = -1;

                            foreach (DataRow dr1 in dtbl1.Rows)
                            {
                                string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                                long planid = Int64.Parse(dr1["plan_id"].ToString());
                                arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                            }
                            lb_plannedlist.DataSource = arrplanjr;
                            lb_plannedlist.DataTextField = "Display";
                            lb_plannedlist.DataValueField = "Value";
                            lb_plannedlist.DataBind();
                        }
                    }

                    rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                    rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                    rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                    rtview.QueueStatusID = 2;
                    rtview.SMSStatusFlag = "N";
                    rtview.ButtonEventFlag = "E";
                    vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);
                    if (Page.IsPostBack)
                    {

                        txt_nextq.Text = lbl_queueno_show.Text;
                    }
                    UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                    if (vipupdatesucess == "1")
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "VIP Queue not Called";
                    }
                }
            }

            #endregion Next Walkin Queue

            #region Next Walkin Queue 2

            if (dtNextVIPQueue.Rows.Count == 0 && dtNextAppointmentQueue.Rows.Count == 0 && AppointmentToWalkin != 1)
            {
                dtNextWalkinQueue = rtcntrl.GetNextWalkinQueue(rtview);

                if (dtNextWalkinQueue.Rows.Count > 0)
                {
                    foreach (DataRow ds in dtNextWalkinQueue.Rows)
                    {
                        lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                        lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                        lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();

                    }

                    rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);

                    dtbl = rtcntrl.GetQueueMemberDetails(rtview);
                    if (dtbl.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtbl.Rows)
                        {
                            //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                            txt_esicno.Text = dr["visit_customer_id"].ToString();
                            txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                            txt_age.Text = dr["members_age"].ToString();
                            if (dr["members_gender"].ToString() == "M")
                            {
                                txt_gender.Text = "Male";
                            }
                            else
                            {
                                txt_gender.Text = "Female";
                            }
                            // txt_relation.Text = dr["relation_desc"].ToString();
                            txt_relation.Text = dr["customer_appointment_time"].ToString();
                            txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                        }

                        dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                        if (dtbl1.Rows.Count > 0)
                        {
                            //btn_callq.Enabled = true;

                            lb_missedQ.SelectedIndex = -1;

                            foreach (DataRow dr1 in dtbl1.Rows)
                            {
                                string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                                long planid = Int64.Parse(dr1["plan_id"].ToString());
                                arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                            }
                            lb_plannedlist.DataSource = arrplanjr;
                            lb_plannedlist.DataTextField = "Display";
                            lb_plannedlist.DataValueField = "Value";
                            lb_plannedlist.DataBind();
                        }
                    }
                    rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                    rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                    rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                    rtview.QueueStatusID = 2;
                    rtview.SMSStatusFlag = "N";
                    rtview.ButtonEventFlag = "E";
                    vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);

                    if (Page.IsPostBack)
                    {
                        txt_nextq.Text = lbl_queueno_show.Text;
                    }

                    UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                    if (vipupdatesucess == "1")
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "Doctor Walkin Queue not Called";
                    }
                }
            }

            #endregion Next Walkin Queue 2

            #region Next Appointment Queue 2

            if (dtNextVIPQueue.Rows.Count == 0 && dtNextWalkinQueue.Rows.Count == 0 && (now < start) && AppointmentToWalkin != 1)
            {

                dtNextAppointmentQueue = rtcntrl.GetNextImmediateAppointmentQueue(rtview);

                if (dtNextAppointmentQueue.Rows.Count > 0)
                {
                    foreach (DataRow ds in dtNextAppointmentQueue.Rows)
                    {
                        lbl_queuetransactionid.Text = ds["queue_tnx_id"].ToString();
                        lbl_visittransactionid.Text = ds["visit_tnx_id"].ToString();
                        lbl_queueno_show.Text = ds["visit_queue_no_show"].ToString();

                    }

                    rtview.CustomerVisitId = Convert.ToInt32(lbl_visittransactionid.Text);

                    dtbl = rtcntrl.GetQueueMemberDetails(rtview);

                    if (dtbl.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtbl.Rows)
                        {
                            //c.visit_customer_id,m.members_firstname,m.members_lastname,m.members_gender,m.members_age,r.relation_desc,cm.customer_firstname,cm.customer_lastname
                            txt_esicno.Text = dr["visit_customer_id"].ToString();
                            txt_patname.Text = dr["members_lastname"].ToString() + " " + dr["members_firstname"].ToString();
                            txt_age.Text = dr["members_age"].ToString();
                            if (dr["members_gender"].ToString() == "M")
                            {
                                txt_gender.Text = "Male";
                            }
                            else
                            {
                                txt_gender.Text = "Female";
                            }
                            txt_relation.Text = dr["customer_appointment_time"].ToString();
                            txt_customername.Text = dr["customer_firstname"].ToString() + " " + dr["customer_lastname"].ToString();

                        }

                        dtbl1 = rtcntrl.GetQueuePlanList(rtview);
                        if (dtbl1.Rows.Count > 0)
                        {
                            // btn_callq.Enabled = true;

                            lb_missedQ.SelectedIndex = -1;

                            foreach (DataRow dr1 in dtbl1.Rows)
                            {
                                string departmentdesc = myTI.ToTitleCase(dr1["department_desc"].ToString());
                                long planid = Int64.Parse(dr1["plan_id"].ToString());
                                arrplanjr.Add(new RTAddValue(departmentdesc, planid));

                            }
                            lb_plannedlist.DataSource = arrplanjr;
                            lb_plannedlist.DataTextField = "Display";
                            lb_plannedlist.DataValueField = "Value";
                            lb_plannedlist.DataBind();
                        }
                    }

                    rtview.CustomerQueueTnx = Convert.ToInt64(lbl_queuetransactionid.Text);
                    rtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                    rtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                    rtview.QueueStatusID = 2;
                    rtview.SMSStatusFlag = "N";
                    rtview.ButtonEventFlag = "E";
                    vipupdatesucess = rtcntrl.UpdateQueuestatusforCallMissed(rtview);
                    if (Page.IsPostBack)
                    {
                        txt_nextq.Text = lbl_queueno_show.Text;
                    }

                    UpdatePatientInfoGridViewbyQueue(lbl_queueno_show.Text);

                    if (vipupdatesucess == "1")
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "Doctor Appointment Queue not Called";
                    }


                }
            }

            #endregion Next Appointment Queue 2

            // No Queue Token Or Not Checking

            #region No Queue Token Or Not Checking

            if (dtNextVIPQueue.Rows.Count == 0 && dtNextWalkinQueue.Rows.Count == 0 && dtNextAppointmentQueue.Rows.Count == 0)
            {
                txt_nextq.Text = string.Empty;
                lbl_queueno_show.Text = "Queue Number Show";
                lbl_queuetransactionid.Text = "Queue Transaction Id";
                lbl_visittransactionid.Text = "Visit Transaction Id";

                ClearAll();
            }

            #endregion No Queue Token Or Not Checking

            lb_deptlist.Enabled = true;
            lb_seldeptlist.Enabled = true;
            btn_l1tol2.Enabled = true;
            btn_l2tol1.Enabled = true;
            btn_up.Enabled = true;
            btn_down.Enabled = true;
        }

        #endregion Checking Queue No 2

  #endregion Checking Department 15 Or Not


        LoadFreshQ();
        LoadMissedQ();
        LoadPendingQ();
        LoadHoldQ();
        btn_nextq.Enabled = true;
        btn_mandataendq.Enabled = true;
        btn_mandatamissedq.Enabled = true;
        btn_mandatamissedqcall.Enabled = false;
        btn_callq.Enabled = false;
        btn_recall.Enabled = true;

        if (AppointmentToWalkin == 1)
        {
            AppointmentToWalkin = 0;
            btn_nextq_Click(sender, e);
        }

        CheckingAppointmentToWalkin = 0;

    }

    catch (Exception ex)
    {
        throw new Exception("Problem in Next Queue", ex);
    }
    finally
    {
        dtNextVIPQueue = null;

        vipupdatesucess = string.Empty;

        dtNextAppointmentQueue = null;

        appointmentupdatesucess = string.Empty;

        dtNextWalkinQueue = null;

        walkinupdatesucess = string.Empty;

        dtGettingNextOrder = null;

    }
}
protected void lb_holdQ_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void lb_plannedlist_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void gv_queuedetails_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void btn_l1tol2_Click(object sender, EventArgs e)
{

}
protected void btn_holdq_Click(object sender, EventArgs e)
{

}
protected void btn_l2tol1_Click(object sender, EventArgs e)
{

}
protected void btn_up_Click(object sender, EventArgs e)
{

}
protected void btn_down_Click(object sender, EventArgs e)
{

}
protected void btn_addservices_Click(object sender, EventArgs e)
{

}
protected void btn_recall_Click(object sender, EventArgs e)
{

}
protected void ddl_department_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void btn_endq_Click(object sender, EventArgs e)
{

}
protected void btn_missedq_Click(object sender, EventArgs e)
{

}
protected void lb_pendingQ_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
{

}
protected void btn_transferq_Click(object sender, EventArgs e)
{

}
}

    #region RT Screen - RT Add New Value

public class RTAddValue
{
    private string m_Display;
    private long m_Value;
    public RTAddValue(string Display, long Value)
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

#endregion RT Screen - RT Add New Value}
