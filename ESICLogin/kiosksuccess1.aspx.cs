using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using System.Threading;
using System.Globalization;

public partial class kioskhome : System.Web.UI.Page
{
    CRTBEL crtview;
    CRTBAL crtcntrl; 
    public string fname;
    public string lname;
    public string uname;
    public string terdesc;
    public string uid;
    public string tid;
    public string did;
    public string dd;
    public int showqueueno = 1;
    KioskBEL kioskview = new KioskBEL();
    kioskBAL kioskcntrl = new kioskBAL();



    public StringBuilder strb = new StringBuilder();
    public ArrayList arrloaddepot = new ArrayList();
    public ArrayList arrloadpatient = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public ArrayList arraylist1 = new ArrayList();
    public ArrayList arraylist2 = new ArrayList();
    public string QueueTicket, DeptName;
    string AverageWaitingQueue, AverageWaitingTime;
    string DepartmentDescription;

    int status;
    string dob
    {

        get { return ViewState["dob"] as string; }
        set { ViewState["dob"] = value; }

    }
    string snam
    {

        get { return ViewState["snam"] as string; }
        set { ViewState["snam"] = value; }

    }

    string chk
    {

        get { return ViewState["chk"] as string; }
        set { ViewState["chk"] = value; }

    }
    string pid
    {

        get { return ViewState["pid"] as string; }
        set { ViewState["pid"] = value; }

    }



    string queno
    {

        get { return ViewState["queno"] as string; }
        set { ViewState["queno"] = value; }

    }

    string dpt
    {

        get { return ViewState["dpt"] as string; }
        set { ViewState["dpt"] = value; }

    }

    string apptime
    {

        get { return ViewState["apptime"] as string; }
        set { ViewState["apptime"] = value; }

    }

    string esi
    {

        get { return ViewState["esi"] as string; }
        set { ViewState["esi"] = value; }

    }





    protected void Page_Load(object sender, EventArgs e)
    {


        if (!IsPostBack)
        {



            chk = Server.UrlDecode(Request.QueryString["1"]);
            dob = Server.UrlDecode(Request.QueryString["2"]);
            snam = Server.UrlDecode(Request.QueryString["3"]);
            pid = Server.UrlDecode(Request.QueryString["4"]);
            esi = Server.UrlDecode(Request.QueryString["5"]);
            if (esi == "w" || esi == "w1")
            {
                print();
            }
            if (esi == "a")
            {
                printappointment();
            }
            //fname = Server.UrlDecode(Request.QueryString["1"]);
            //if (fname == null)
            //{
            //    fname = Session["fname"].ToString();
            //}

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

        }
    }

    public void printappointment()
    {
        status = 1;
        bool firstval;
        DataTable dtbl = new DataTable();
        DataTable CheckingQueueToken = new DataTable();
        DataTable CheckingPreviousToken = new DataTable();
        DataTable showqueueno1 = new DataTable();

        string updatesuccess = string.Empty;
        string insertsuccess = string.Empty;
        string PatientName = string.Empty;
        string queue = string.Empty;

        //newprint.PrintQueuno("DE1-0321");
        //newprint.ReceiptPrint(senderrec, rec);

        try
        {

            DataTable dt = new DataTable();

            //kioskview.CusLastName = Server.UrlDecode(Request.QueryString["1"]);

            //kioskview.Dob = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["2"]));

            kioskview.CusLastName = snam;
            kioskview.Dob = Convert.ToDateTime(dob);
            firstval = true;



            dt = kioskcntrl.GetAppointmentDetails(kioskview);
            kioskview.ESCInNumber = dt.Rows[0][3].ToString();
            esi = dt.Rows[0][3].ToString();
            kioskview.CustomerFullName = dt.Rows[0][4].ToString();
            kioskview.PatientId = Convert.ToInt32(dt.Rows[0][5].ToString());
            kioskview.AppointmentID = Convert.ToInt32(dt.Rows[0][2].ToString());
            kioskview.AppointmentDateTime = Convert.ToDateTime(dt.Rows[0][0].ToString());
            kioskview.ConsultingStatus = "A";

            PatientName = dt.Rows[0][4].ToString();

            pid = Convert.ToString(kioskview.PatientId);
            CheckingQueueToken = kioskcntrl.CheckKioskQueueTokenAlreadyGenerated(kioskview);
            int co = 0;
            if (CheckingQueueToken.Rows.Count == 0)
           // if (co == 0)
            {

                #region queue checking
                // Checking Patients Have Already Taken Queue Token Or Not

                //CheckingQueueToken = crtcntrl.CheckQueueTokenAlreadyGenerated(crtview);
                //CheckingPreviousToken = crtcntrl.CheckPreviousToken(crtview);

                //CheckingQueueToken = crtcntrl.ReprintCheckQueueTokenAlreadyGenerated(crtview);

                //if (CheckingQueueToken.Rows.Count == 0)
                //{
                //    MessageBox.Show("You are not Generated any Token to Reprint Please generate a Print first");
                //}
                //else if (CheckingQueueToken.Rows.Count == 1)
                //{
                //    int selectedItem1 = Convert.ToInt32(CheckingQueueToken.Rows[0][3]);
                //    crtview.QueueNummberShow = Convert.ToString(CheckingQueueToken.Rows[0][6]);
                //    DataTable TotalWaitingQueue = crtcntrl.GettingTotalWaitingQueue(selectedItem1);
                //    int count = TotalWaitingQueue.Rows.Count;

                //    if (TotalWaitingQueue.Rows.Count > 0)
                //    {
                //        AverageWaitingQueue = Convert.ToString(count) + " Patients Before You";
                //        //AverageWaitingTime = Convert.ToString(count * ApproximateWaitingTime) + " Minutes Approximately";
                //    }
                //    else
                //    {
                //        AverageWaitingQueue = "0 Patients Before You";
                //        AverageWaitingTime = "0 Minutes Approximately";
                //    }
                //    Session["UserAuthentication0"] = QueueTicket;
                //    Session["UserAuthentication1"] = DeptName;
                //    Session["UserAuthentication2"] = Convert.ToString(DateTime.Now);


                //    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(2/2);var Mtop = (screen.height/2)-(1200/2);window.open( 'ReprintDisplay.aspx', null, 'height=20000,width=20000,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);


                //}
                //else
                //{
                //    string url = string.Format("KioskTicketAlredyExist.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}", Server.UrlEncode(esi), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid), Server.UrlEncode(chk), Server.UrlEncode("r"));
                //    Response.Redirect(url, false);
                //    //Session["UserAuthentication1"] = txt_esicno.Text;
                //    //crtview.ESCInNumber = txt_esicno.Text;
                //    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "ReprintDisplay", "reprintdisplay();", true);
                //}
                #endregion queue checking



                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (firstval == true)
                    {
                        int selectedItem1;


                        selectedItem1 = Convert.ToInt32(dt.Rows[0][6].ToString());

                        dtbl = kioskcntrl.GetParticularDepartmentDetail(selectedItem1);
                        if (dtbl.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtbl.Rows)
                            {
                                int queueno1 = Convert.ToInt32(dr["department_queueno"].ToString());
                                string queuecode1 = dr["department_code"].ToString();
                                DepartmentDescription = "Pre-Registration";
                                queueno1++;
                                // updatesuccess = kioskcntrl.UpdateDeptQueuNo(selectedItem1, queueno1);
                                if (updatesuccess == "1")
                                {
                                    //lbl_msg.Visible = true;
                                    //lbl_msg.Text = "Queue Number Not Updated";
                                }

                                // Counting Average Waiting Time 

                                DataTable TotalWaitingQueue = kioskcntrl.GettingTotalWaitingQueue(selectedItem1);

                                int count = TotalWaitingQueue.Rows.Count;

                                if (TotalWaitingQueue.Rows.Count > 0)
                                {
                                    AverageWaitingQueue = Convert.ToString(count) + " Patients Before You";

                                    //AverageWaitingQueue = Convert.ToString(count) + " Persons Have To Go Before You";

                                    //AverageWaitingTime = "Your Average Waiting Time May Be Around " + Convert.ToString(count * 2) + " Minutes";

                                    // AverageWaitingTime = Convert.ToString(count * ApproximateWaitingTime) + " Minutes Approximately";
                                }
                                else
                                {
                                    AverageWaitingQueue = "0 Patients Before You";

                                    //AverageWaitingQueue = "You Are The First Patient";

                                    //AverageWaitingTime = "Kindly Consult The Doctor Immediately";

                                    AverageWaitingTime = "0 Minutes Approximately";
                                }
                                ////Session["UserAuthentication1"] = txt_esicno.Text;
                                kioskview.QueueNummber = queuecode1 + "-" + Convert.ToString(queueno1);
                                //  kisokview.QueueNummberShow = queueno1.ToString();
                                // kisokview.ESCInNumber = txt_esicno.Text;

                                showqueueno1 = kioskcntrl.checkcount(selectedItem1);
                                showqueueno = Convert.ToInt32(showqueueno1.Rows[0][0]);
                                showqueueno += 1;
                                //original
                                // kioskview.QueueNummberShow = showqueueno.ToString();
                                // updatesuccess = kioskcntrl.UpdateDeptQueuNo(selectedItem1, showqueueno);


                                //wollongong digit
                                queue = showqueueno.ToString().PadLeft(3, '0');
                                kioskview.QueueNummberShow = queue;
                                updatesuccess = kioskcntrl.UpdateDeptQueuNo(selectedItem1, showqueueno);
                                //  Session["Kisok_Qnum"] = kisokview.QueueNummberShow;
                                QueueTicket = kioskview.QueueNummberShow;
                                //Session["Kisok_esic_num"] = kisokview.ESCInNumber;
                                DeptName = DepartmentDescription;
                                queno = QueueTicket;
                                dpt = DeptName;
                                //Session["Kisok_Avgwaiting"] = AverageWaitingQueue;
                                //Session["Kisok_Avgw_Que"] = AverageWaitingTime;
                                //Session["Kiosk_date"] = Convert.ToString(DateTime.Now);
                                //Session["Kiosk_Department_name"] = DepartmentDescription;
                                Session["UserAuthentication0"] = QueueTicket;
                                Session["UserAuthentication1"] = DeptName;
                                Session["UserAuthentication2"] = Convert.ToString(DateTime.Now);

                                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width)-(2/2);var Mtop = (screen.height)-(1200/2);window.open('Print.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

                                //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(2/2);var Mtop = (screen.height/2)-(1200/2);window.open( 'Print.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

                                ////ensure the below three lines are needed
                                // kisokview.CustomerFullName = txt_customername.Text;
                                //kisokview.PatientId = Convert.ToInt32(rbl_memberlist.SelectedValue);
                                ////  Printer.Show(txt_esicno.Text, kisokview.QueueNummber);
                                if (apptime == "Walk In")
                                {
                                    insertsuccess = kioskcntrl.AddCustomerVisitDetailsW(kioskview);
                                }
                                else
                                {

                                    insertsuccess = kioskcntrl.AddCustomerVisitDetails(kioskview);
                                }
                                // SimpleKioskPrint();
                                if (insertsuccess == "1")
                                {
                                    //lbl_msg.Visible = true;
                                    //lbl_msg.Text = "Visit Details Not Inserted";
                                }
                                insertsuccess = string.Empty;
                                DataTable dtblvisit = kioskcntrl.GetLastCustomerVisitID();
                                if (dtblvisit.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in dtblvisit.Rows)
                                    {
                                        kioskview.CusVisitId = Convert.ToInt64(dr1["visit_tnx_id"].ToString());
                                        kioskview.UserId = 2;
                                        kioskview.TerminalId = 3;
                                        kioskview.DepartmentId = selectedItem1;
                                        kioskview.OrderId = 1;
                                        kioskview.SmsStatusFlag = "N";
                                        insertsuccess = kioskcntrl.AddCustomerQueueTransactions(kioskview);
                                        if (insertsuccess == "1")
                                        {
                                            //lbl_msg.Visible = true;
                                            //lbl_msg.Text = " Transactions Not Inserted";
                                        }
                                        insertsuccess = string.Empty;
                                        DataTable dtblqueuetrans = kioskcntrl.GetLastQueueTransactionID();
                                        if (dtblqueuetrans.Rows.Count > 0)
                                        {
                                            foreach (DataRow dr2 in dtblqueuetrans.Rows)
                                            {
                                                kioskview.QueueTransID = Convert.ToInt64(dr2["queue_tnx_id"].ToString());

                                                insertsuccess = kioskcntrl.AddCustomerQueuePlanOrderone(kioskview);
                                                if (insertsuccess == "1")
                                                {
                                                    //lbl_msg.Visible = true;
                                                    //lbl_msg.Text = " Plan Not Inserted";
                                                }
                                                insertsuccess = string.Empty;
                                            }
                                        }
                                    }
                                }
                            }
                            dtbl = null;
                        }
                        firstval = false;
                    }

                    else
                    {
                        kioskview.DepartmentId = Convert.ToInt32(dt.Rows[i][6].ToString());
                        kioskview.OrderId++;
                        insertsuccess = kioskcntrl.AddCustomerQueuePlanOrders(kioskview);
                        if (insertsuccess == "1")
                        {
                            //lbl_msg.Visible = true;
                            //lbl_msg.Text = "Other Plans Not Inserted";
                        }
                        insertsuccess = string.Empty;
                    }
                }


                // MessageBox.Show("Queue Ticket Generate");
                //  Thread.Sleep(5000);
                //open just a pop up window.
                //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "sen", "window.open('KioskSenPrint.aspx',null,'height=500,width=500,var Mtop = (screen.height/2)-(1200/2);var Mleft = (screen.width/2)-(2000/2);status= no,resizable= no,scrollbars=no,toolbar=no,toolbar=no,location=yes,menubar=no');", true);

                //string fname = Server.UrlDecode(Request.QueryString["1"]);
                //string lname = Server.UrlDecode(Request.QueryString["2"]);
                //string uname = Request.QueryString["3"];
                //string terdesc = Request.QueryString["4"];
                //string uid = Server.UrlDecode(Request.QueryString["5"]);
                //string tid = Server.UrlDecode(Request.QueryString["6"]);
                //string did = Server.UrlDecode(Request.QueryString["7"]);
                //string dd = Server.UrlDecode(Request.QueryString["8"]);
                //string url = string.Format("kisokprint.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}&10={9}&11={10}&12={11}&13={12}",
                //                 Server.UrlEncode(fname),
                //                 Server.UrlEncode(lname),
                //                 Server.UrlEncode(uname),
                //                 Server.UrlEncode(terdesc),
                //                 Server.UrlEncode(uid),
                //                 Server.UrlEncode(tid),
                //                 Server.UrlEncode(did),
                //                 Server.UrlEncode(dd), Server.UrlEncode(kisokview.ESCInNumber), Server.UrlEncode(kisokview.QueueNummber), Server.UrlEncode(AverageWaitingQueue), Server.UrlEncode(AverageWaitingTime), Server.UrlEncode(DepartmentDescription));
                //// Response.Redirect(url, false);
                // this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "sen", "window.open('kisokprint.aspx',null,'height=500,width=500,var Mtop = (screen.height/2)-(1200/2);var Mleft = (screen.width/2)-(2000/2);status= no,resizable= no,scrollbars=no,toolbar=no,toolbar=no,location=yes,menubar=no');", true);
                //Response.Redirect("kiosklang.aspx");
                // string url = string.Format("kioskmobile.aspx");
                // Response.Redirect(url, true);
                //status = 2;
                // Button1.Visible = false;
                // ImageButton3.Visible = true;
                //this.Page.RegisterStartupScript(“openchildwindows”,   “<script>OpenWindows();</script>”);
            }
            else
            {

                //  MessageBox.Show("You Have Already Generated Queue Token For " + PatientName + " Patient");

                string url = string.Format("kioskReprint.aspx");
                Response.Redirect(url, false);
                //string fname = Server.UrlDecode(Request.QueryString["1"]);
                //string lname = Server.UrlDecode(Request.QueryString["2"]);
                //string uname = Request.QueryString["3"];
                //string terdesc = Request.QueryString["4"];
                //string uid = Server.UrlDecode(Request.QueryString["5"]);
                //string tid = Server.UrlDecode(Request.QueryString["6"]);
                //string did = Server.UrlDecode(Request.QueryString["7"]);
                //string dd = Server.UrlDecode(Request.QueryString["8"]);
                //string url = string.Format("kioskprintchecking.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}&10={9}&11={10}&12={11}&13={12}",
                //                Server.UrlEncode(fname),
                //                Server.UrlEncode(lname),
                //                Server.UrlEncode(uname),
                //                Server.UrlEncode(terdesc),
                //                Server.UrlEncode(uid),
                //                Server.UrlEncode(tid),
                //                Server.UrlEncode(did),
                //                Server.UrlEncode(dd), Server.UrlEncode(kisokview.ESCInNumber), Server.UrlEncode(kisokview.QueueNummber), Server.UrlEncode(PatientName), Server.UrlEncode(AverageWaitingTime), Server.UrlEncode(DepartmentDescription));
                //// Response.Redirect(url, false);

            }

        }




        catch (Exception ex)
        {
            throw new Exception("Problem in Queuno Ticket", ex);
        }
        finally
        {
            chk = "yes";
            //next();
            //Response.Redirect("Maya.aspx");
            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(2/2);var Mtop = (screen.height/2)-(1200/2);window.open( 'KioskSenPrint.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);


        }
    }

    public void print()
    {


        bool firstval;
        DataTable dtbl = new DataTable();
        DataTable CheckingQueueToken = new DataTable();
        DataTable CheckingPreviousToken = new DataTable();
        DataTable showqueueno1 = new DataTable();
        string updatesuccess = string.Empty;
        string insertsuccess = string.Empty;
        string PatientName = string.Empty;
        string queue = string.Empty;
        //newprint.PrintQueuno("DE1-0321");
        //newprint.ReceiptPrint(senderrec, rec);

        try
        {

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            //kioskview.CusLastName = Server.UrlDecode(Request.QueryString["1"]);



            //kioskview.Dob = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["2"]));
            kioskview.ESCInNumber = chk;
            kioskview.CusLastName = snam;
            kioskview.Dob = Convert.ToDateTime(dob);
            firstval = true;
            if (esi == "w1")
            {
                dt = kioskcntrl.GetWalkinDetailsEsi(kioskview);
            }
            else
            {
                dt = kioskcntrl.GetWalkinDetails(kioskview);
            }
            if (dt.Rows.Count > 0)
            {
                kioskview.ESCInNumber = dt.Rows[0][0].ToString();
                kioskview.CustomerFullName = dt.Rows[0][1].ToString();
                kioskview.PatientId = Convert.ToInt32(dt.Rows[0][2].ToString());
                pid = dt.Rows[0][2].ToString();
                // kioskview.AppointmentID = Convert.ToInt32(dt.Rows[0][2].ToString());
                //kioskview.AppointmentDateTime = Convert.ToDateTime(dt.Rows[0][0].ToString());
                kioskview.ConsultingStatus = "W";

                //PatientName = dt.Rows[0][4].ToString();

                CheckingQueueToken = kioskcntrl.CheckKioskQueueTokenAlreadyGenerated(kioskview);
                //int co = 0;
                if (CheckingQueueToken.Rows.Count == 0)
               // if (co == 0)
                {
                    #region queue checking
                    // Checking Patients Have Already Taken Queue Token Or Not

                    //CheckingQueueToken = crtcntrl.CheckQueueTokenAlreadyGenerated(crtview);
                    //CheckingPreviousToken = crtcntrl.CheckPreviousToken(crtview);

                    //CheckingQueueToken = crtcntrl.ReprintCheckQueueTokenAlreadyGenerated(crtview);

                    //if (CheckingQueueToken.Rows.Count == 0)
                    //{
                    //    MessageBox.Show("You are not Generated any Token to Reprint Please generate a Print first");
                    //}
                    //else if (CheckingQueueToken.Rows.Count == 1)
                    //{
                    //    int selectedItem1 = Convert.ToInt32(CheckingQueueToken.Rows[0][3]);
                    //    crtview.QueueNummberShow = Convert.ToString(CheckingQueueToken.Rows[0][6]);
                    //    DataTable TotalWaitingQueue = crtcntrl.GettingTotalWaitingQueue(selectedItem1);
                    //    int count = TotalWaitingQueue.Rows.Count;

                    //    if (TotalWaitingQueue.Rows.Count > 0)
                    //    {
                    //        AverageWaitingQueue = Convert.ToString(count) + " Patients Before You";
                    //        //AverageWaitingTime = Convert.ToString(count * ApproximateWaitingTime) + " Minutes Approximately";
                    //    }
                    //    else
                    //    {
                    //        AverageWaitingQueue = "0 Patients Before You";
                    //        AverageWaitingTime = "0 Minutes Approximately";
                    //    }
                    //    Session["UserAuthentication0"] = QueueTicket;
                    //    Session["UserAuthentication1"] = DeptName;
                    //    Session["UserAuthentication2"] = Convert.ToString(DateTime.Now);


                    //    ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(2/2);var Mtop = (screen.height/2)-(1200/2);window.open( 'ReprintDisplay.aspx', null, 'height=20000,width=20000,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);


                    //}
                    //else
                    //{
                    //    string url = string.Format("KioskTicketAlredyExist.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}", Server.UrlEncode(esi), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid), Server.UrlEncode(chk), Server.UrlEncode("r"));
                    //    Response.Redirect(url, false);
                    //    //Session["UserAuthentication1"] = txt_esicno.Text;
                    //    //crtview.ESCInNumber = txt_esicno.Text;
                    //    //ScriptManager.RegisterStartupScript(Page, typeof(Page), "ReprintDisplay", "reprintdisplay();", true);
                    //}
                    #endregion queue checking


                    if (firstval == true)
                    {
                        dt1 = kioskcntrl.GetCrtRtId(kioskview);

                        int selectedItem1 = Convert.ToInt16(dt1.Rows[0][0].ToString());
                        dtbl = kioskcntrl.GetParticularDepartmentDetail(selectedItem1);
                        if (dtbl.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dtbl.Rows)
                            {
                                int queueno1 = Convert.ToInt32(dr["department_queueno"].ToString());
                                string queuecode1 = dr["department_code"].ToString();
                                string DepartmentDescription = "Pre-Registration";
                                queueno1++;

                                if (updatesuccess == "1")
                                {
                                    //lbl_msg.Visible = true;
                                    //lbl_msg.Text = "Queue Number Not Updated";
                                }

                                // Counting Average Waiting Time 

                                DataTable TotalWaitingQueue = kioskcntrl.GettingTotalWaitingQueue(selectedItem1);

                                int count = TotalWaitingQueue.Rows.Count;

                                if (TotalWaitingQueue.Rows.Count > 0)
                                {
                                    //AverageWaitingQueue = Convert.ToString(count) + " Patients Before You";

                                    //AverageWaitingQueue = Convert.ToString(count) + " Persons Have To Go Before You";

                                    //AverageWaitingTime = "Your Average Waiting Time May Be Around " + Convert.ToString(count * 2) + " Minutes";

                                    //AverageWaitingTime = Convert.ToString(count * ApproximateWaitingTime) + " Minutes Approximately";
                                }
                                else
                                {
                                    //AverageWaitingQueue = "0 Patients Before You";

                                    //AverageWaitingQueue = "You Are The First Patient";

                                    //AverageWaitingTime = "Kindly Consult The Doctor Immediately";

                                    //AverageWaitingTime = "0 Minutes Approximately";
                                }
                                ////Session["UserAuthentication1"] = txt_esicno.Text;
                                kioskview.QueueNummber = queuecode1 + "-" + Convert.ToString(queueno1);
                                // kioskview.QueueNummberShow = queueno1.ToString();
                                // kisokview.ESCInNumber = txt_esicno.Text;
                                showqueueno1 = kioskcntrl.checkcount(selectedItem1);
                                showqueueno = Convert.ToInt32(showqueueno1.Rows[0][0]);
                                showqueueno += 1;
                                //original
                                // kioskview.QueueNummberShow = showqueueno.ToString();
                                // updatesuccess = kioskcntrl.UpdateDeptQueuNo(selectedItem1, showqueueno);

                                //wollongong digit
                                queue = showqueueno.ToString().PadLeft(3, '0');
                                kioskview.QueueNummberShow = queue;
                                updatesuccess = kioskcntrl.UpdateDeptQueuNo(selectedItem1, showqueueno);

                                //  Session["Kisok_Qnum"] = kisokview.QueueNummberShow;
                                string QueueTicket = kioskview.QueueNummberShow;
                                //Session["Kisok_esic_num"] = kisokview.ESCInNumber;
                                string DeptName = DepartmentDescription;
                                queno = QueueTicket;
                                dpt = DeptName;
                                //Session["Kisok_Avgwaiting"] = AverageWaitingQueue;
                                //Session["Kisok_Avgw_Que"] = AverageWaitingTime;
                                //Session["Kiosk_date"] = Convert.ToString(DateTime.Now);
                                //Session["Kiosk_Department_name"] = DepartmentDescription;
                                Session["UserAuthentication0"] = QueueTicket;
                                Session["UserAuthentication1"] = DeptName;
                                Session["UserAuthentication2"] = Convert.ToString(DateTime.Now);

                                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width)-(2/2);var Mtop = (screen.height)-(1200/2);window.open('Print.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

                                //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(2/2);var Mtop = (screen.height/2)-(1200/2);window.open( 'Print.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

                                ////ensure the below three lines are needed
                                // kisokview.CustomerFullName = txt_customername.Text;
                                //kisokview.PatientId = Convert.ToInt32(rbl_memberlist.SelectedValue);
                                ////  Printer.Show(txt_esicno.Text, kisokview.QueueNummber);

                                insertsuccess = kioskcntrl.AddCustomerVisitDetailsW(kioskview);
                                // SimpleKioskPrint();
                                if (insertsuccess == "1")
                                {
                                    // lbl_msg.Visible = true;
                                    //lbl_msg.Text = "Visit Details Not Inserted";
                                }
                                insertsuccess = string.Empty;
                                DataTable dtblvisit = kioskcntrl.GetLastCustomerVisitID();
                                if (dtblvisit.Rows.Count > 0)
                                {
                                    foreach (DataRow dr1 in dtblvisit.Rows)
                                    {
                                        kioskview.CusVisitId = Convert.ToInt64(dr1["visit_tnx_id"].ToString());
                                        kioskview.UserId = 2;
                                        kioskview.TerminalId = 3;
                                        kioskview.DepartmentId = selectedItem1;
                                        kioskview.OrderId = 1;
                                        kioskview.SmsStatusFlag = "N";
                                        insertsuccess = kioskcntrl.AddCustomerQueueTransactions(kioskview);
                                        if (insertsuccess == "1")
                                        {
                                            //lbl_msg.Visible = true;
                                            //lbl_msg.Text = " Transactions Not Inserted";
                                        }
                                        insertsuccess = string.Empty;
                                        DataTable dtblqueuetrans = kioskcntrl.GetLastQueueTransactionID();
                                        if (dtblqueuetrans.Rows.Count > 0)
                                        {
                                            foreach (DataRow dr2 in dtblqueuetrans.Rows)
                                            {
                                                kioskview.QueueTransID = Convert.ToInt64(dr2["queue_tnx_id"].ToString());

                                                insertsuccess = kioskcntrl.AddCustomerQueuePlanOrderone(kioskview);
                                                if (insertsuccess == "1")
                                                {
                                                    //lbl_msg.Visible = true;
                                                    //lbl_msg.Text = " Plan Not Inserted";
                                                }
                                                insertsuccess = string.Empty;
                                            }
                                        }
                                    }
                                }
                            }
                            dtbl = null;
                        }
                        firstval = false;
                    }

                    else
                    {
                        kioskview.DepartmentId = Convert.ToInt32(dt.Rows[0][5].ToString());
                        kioskview.OrderId++;
                        insertsuccess = kioskcntrl.AddCustomerQueuePlanOrders(kioskview);
                        if (insertsuccess == "1")
                        {
                            //lbl_msg.Visible = true;
                            //lbl_msg.Text = "Other Plans Not Inserted";
                        }
                        insertsuccess = string.Empty;
                    }

                    chk = "yes";
                    // MessageBox.Show("Queue Ticket Generate");
                    //  Thread.Sleep(5000);
                    //open just a pop up window.
                    //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "sen", "window.open('KioskSenPrint.aspx',null,'height=500,width=500,var Mtop = (screen.height/2)-(1200/2);var Mleft = (screen.width/2)-(2000/2);status= no,resizable= no,scrollbars=no,toolbar=no,toolbar=no,location=yes,menubar=no');", true);

                }
                else
                {

                    //  MessageBox.Show("You Have Already Generated Queue Token For " + PatientName + " Patient");

                    string url = string.Format("kioskReprint.aspx");
                    Response.Redirect(url, false);

                }
            }
            else
            {
                MessageBox.Show("Yor Details Are Not Registered Please Go to Reception or CRT Counter");

            }

        }

        catch (Exception ex)
        {
            throw new Exception("Problem in Queuno Ticket", ex);
        }
        finally
        {
            // chk = "yes";
            //next();
            //Response.Redirect("Maya.aspx");
            //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(2/2);var Mtop = (screen.height/2)-(1200/2);window.open( 'KioskSenPrint.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);




        }
    }
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    string fname = Hidden1.Value;
    //    string lname = Hidden2.Value;
    //    string uname = Hidden3.Value;
    //    string terdesc = Hidden7.Value;
    //    string uid = Hidden4.Value;
    //    string tid = Hidden5.Value;
    //    string did = Hidden6.Value;
    //    string dd = Hidden8.Value;
    //    string url = string.Format("kioskesicno.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
    //        Server.UrlEncode(fname),
    //        Server.UrlEncode(lname),
    //        Server.UrlEncode(uname),
    //        Server.UrlEncode(terdesc),
    //        Server.UrlEncode(uid),
    //        Server.UrlEncode(tid),
    //        Server.UrlEncode(did),
    //        Server.UrlEncode(dd));
    //    Response.Redirect(url, false);
    //}

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

        string url = string.Format("kioskhome.aspx");
        Response.Redirect(url, true);
    }
    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {

        if (chk == "yes")
        {
            chk = "no";

            //        kisokview.CusLastName = snam;

            //        kisokview.Dob = Convert.ToDateTime(dob);

            //        //firstval = true;
            //        // dt = kioskcntrl.GetAppointmentDetails(kisokview);
            //        kisokview.ESCInNumber = esi;


            //        string url = string.Format("kiosksuccess.aspx?1={0}&2={1}&3={2}&4={3}", Server.UrlEncode(kisokview.ESCInNumber), Server.UrlEncode(queno), Server.UrlEncode(dpt), Server.UrlEncode(pid));
            //        Response.Redirect(url, true);

            string url = string.Format("kioskhome.aspx");
            Response.Redirect(url, false);
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string url = string.Format("kioskemail.aspx?1={0}&2={1}&3={2}&4={3}", Server.UrlEncode(chk), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid));
        Response.Redirect(url, true);
    }
}