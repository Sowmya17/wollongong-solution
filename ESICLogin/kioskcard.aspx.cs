using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Globalization;
using System.Threading;
using System.Text.RegularExpressions;

public partial class kiosklang : System.Web.UI.Page
{
    KioskBEL kioskview = new KioskBEL();
    kioskBAL kioskcntrl = new kioskBAL();
  public ArrayList arrloadpatient = new ArrayList();
  public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public string fname;
    public string lname;
    public string uname;
    public string terdesc;
    public string uid;
    public string tid;
    public string did;
    public string dd;

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


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ImageButton2.Visible = true;
            TextBox1.Focus();
           // Label1.Visible = false;
           // Label3.Visible = false;
           // ddl_patlist.Visible = false;
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

    private void RetriveMemberInfo()
    {
        DataTable dtbl = new DataTable();
        try
        {

            dtbl = kioskcntrl.GetMemberDetail(TextBox1.Text);
            if (dtbl.Rows.Count > 0)
            {
                //arrloadpatient.Add(new KioskAddValue("Select", 0));
                foreach (DataRow dr in dtbl.Rows)
                {
                    string fname = myTI.ToTitleCase(dr["members_firstname"].ToString());
                    string lname = myTI.ToTitleCase(dr["members_lastname"].ToString());
                    string fullname = fname + " " + lname;
                    long memberid = Int64.Parse(dr["members_id"].ToString());
                    arrloadpatient.Add(new KioskAddValue(fullname, memberid));

                }
                RadioButtonList1.DataSource = arrloadpatient;
                RadioButtonList1.DataTextField = "Display";
                RadioButtonList1.DataValueField = "Value";
                RadioButtonList1.DataBind();
                ImageButton2.Visible = true;
                Label3.Visible = true;
                Label1.Visible = true;
                RadioButtonList1.Visible = true;

            }
            else
            {
                arrloadpatient.Add(new KioskAddValue("No Record", 0));
                RadioButtonList1.DataSource = arrloadpatient;
                RadioButtonList1.DataTextField = "Display";
                RadioButtonList1.DataValueField = "Value";
                RadioButtonList1.DataBind();

                kioskview.CusLastName = "";
                string url = string.Format("kioskfailure.aspx?1={0}&2={1}",
                       Server.UrlEncode(kioskview.CusLastName),
                       Server.UrlEncode(Convert.ToString(kioskview.Dob)));

                Response.Redirect(url, false);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in Retrive Patient Information", ex);
        }
        finally
        {

        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

       // kioskBAL kioskcntrl = new kioskBAL();
        //KioskBEL kioskview = new KioskBEL();

        DataTable dt = new DataTable();
        DataTable dtbl= new DataTable();
        string esi="";
        //TextBox1.Text = ";610072=21319027161=8=310517?";


         try
        {
            if (TextBox1.Text != "")
            {
                TextBox1.Style.Add("visibility", "hidden");
                try
                {

                    string[] lines = Regex.Split(TextBox1.Text, "=");
                    // esi = TextBox1.Text;
                    if (lines.Length > 1)
                    {
                        TextBox1.Visible = true;
                        esi = lines[1];
                        for (int ctr = 0; ctr < TextBox1.Text.Length; ctr++)
                        {
                            
                        }
                    }
                    else
                    {
                        
                        TextBox1.Visible = true;
                        esi = TextBox1.Text;
                    }
                }
                catch (Exception)
                {
                    if (esi == "")
                    {
                        TextBox1.Visible = true;
                        esi = TextBox1.Text;
                    }
                }      
                  
                
                dtbl = kioskcntrl.GetMemberDetail(esi);
                if (dtbl.Rows.Count != 0)
                {
                    kioskview.MemberId = Int32.Parse(dtbl.Rows[0][0].ToString());
                }
                kioskview.ESCInNumber = esi;
              //kioskview.MemberId = Convert.ToInt32(RadioButtonList1.SelectedValue);
                
                //kioskview.Dob = Convert.ToDateTime(TextBox2.Text);
               // kioskview.Dob = Convert.ToDateTime(RadDatePicker1.SelectedDate);

              dt = kioskcntrl.GetAppointmentDetailsCard(kioskview);
                if (dtbl.Rows.Count == 1)
                {
                    kioskview.CusLastName=dt.Rows[0][0].ToString();
                    kioskview.Dob =Convert.ToDateTime( dt.Rows[0][1].ToString());
                    string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}",
                        Server.UrlEncode(kioskview.CusLastName),
                        Server.UrlEncode(Convert.ToString(kioskview.Dob)),
                        Server.UrlEncode(dt.Rows[0][3].ToString()),
                        Server.UrlEncode(dt.Rows[0][2].ToString()),
                        Server.UrlEncode(kioskview.ESCInNumber),
                    Server.UrlEncode(kioskview.MemberId.ToString()));

                    Response.Redirect(url, false);
                }
                else if (dtbl.Rows.Count > 1)
                {
                    kioskview.CusLastName=dtbl.Rows[0][2].ToString();
                    kioskview.Dob =Convert.ToDateTime( dtbl.Rows[0][10].ToString());
                    //string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}",
                    string url = string.Format("kioskrtv.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}",
                        Server.UrlEncode(kioskview.CusLastName),
                        Server.UrlEncode(Convert.ToString(kioskview.Dob)),
                        Server.UrlEncode(dtbl.Rows[0][3].ToString()),
                        Server.UrlEncode(dtbl.Rows[0][2].ToString()),
                        Server.UrlEncode(kioskview.ESCInNumber),
                        Server.UrlEncode(kioskview.MemberId.ToString()));

                        Response.Redirect(url, false);
                }
                else if (kioskview.ESCInNumber.Count() < 9)
                {
                    Response.Redirect("medicarderror.aspx");
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please swipe with a valid DVA or medicare card'); window.location = '" + Page.ResolveUrl("kioskhome.aspx") + "';", true);
                    //dt = kioskcntrl.GetMemberCard(kioskview);
                    //if (dt.Rows.Count != 0)
                    //{

                    //    kioskview.CusLastName = dt.Rows[0][0].ToString();
                    //    kioskview.Dob = Convert.ToDateTime(dt.Rows[0][1].ToString());
                    //    string url = string.Format("kioskemail.aspx?1={0}&2={1}&3={2}&4={3}&5={4}", Server.UrlEncode(kioskview.ESCInNumber), Server.UrlEncode(kioskview.Dob.ToString()), Server.UrlEncode(kioskview.CusLastName), Server.UrlEncode(kioskview.MemberId.ToString()), Server.UrlEncode("w"));
                    //    Response.Redirect(url, false);
                    //    //string url = string.Format("kiosksuccess.aspx?1={0}&2={1}&3={2}&4={3}&5={4}", Server.UrlEncode(kioskview.ESCInNumber), Server.UrlEncode(kioskview.Dob.ToString()), Server.UrlEncode(kioskview.CusLastName), Server.UrlEncode(pid), Server.UrlEncode("w"));
                    //    //Response.Redirect(url, false);
                    //   // print();

                    //}
                    //else
                    //{

                    //    int esi1 = 0;
                    //    dtbl = kioskcntrl.GetDummyNo(kioskview);
                    //    if (dtbl.Rows.Count != 0)
                    //    {
                    //        esi1 = Convert.ToInt32(dtbl.Rows[0][0].ToString());
                    //        esi1++;

                    //    }
                    //    kioskview.ESCInNumber = esi.ToString();

                    //    kioskview.CusFirstname = "abc";
                    //    kioskview.CusLastName = "efg";
                    //    kioskview.CusAddress = "australia";
                    //    kioskview.CusAge = 25;
                    //    kioskview.CusPhoneNo = 61499721372;
                    //    kioskview.CusGender = 'M';
                    //    kioskview.Email = "abc@gmail.com";
                    //    kioskview.TerminalUser = "admin";
                    //    kioskview.RelationId = 1;
                    //    kioskview.Dob = Convert.ToDateTime("31/10/1989");
                    //    string insertsucess;
                    //    insertsucess = kioskcntrl.RegCustomerDetail(kioskview);
                    //    if (insertsucess == "0")
                    //    {
                    //        //dtbl = kioskcntrl.UpdateDummyNo(kioskview);
                    //    }
                    //    dtbl = kioskcntrl.GetMemberDetail(esi1.ToString());
                    //    if (dtbl.Rows.Count != 0)
                    //    {
                    //        kioskview.MemberId = Int32.Parse(dtbl.Rows[0][0].ToString());
                    //    }
                    //    try
                    //    {
                    //        string url = string.Format("kioskemail.aspx?1={0}&2={1}&3={2}&4={3}&5={4}", Server.UrlEncode(kioskview.ESCInNumber), Server.UrlEncode(kioskview.Dob.ToString()), Server.UrlEncode(kioskview.CusLastName), Server.UrlEncode(kioskview.MemberId.ToString()), Server.UrlEncode("w1"));
                    //        Response.Redirect(url, false);

                    //       // string url = string.Format("kiosksuccess.aspx?1={0}&2={1}&3={2}&4={3}&5={4}", Server.UrlEncode(kioskview.ESCInNumber), Server.UrlEncode(kioskview.Dob.ToString()), Server.UrlEncode(kioskview.CusLastName), Server.UrlEncode(""), Server.UrlEncode("w1"));
                    //       // Response.Redirect(url, false);
                    //    }
                    //    catch (Exception)
                    //    {

                    //    }


                    //}
                    //// status = 1;



                    ////string url = string.Format("kioskfailure.aspx");
                    ////Response.Redirect(url, false);

                }
                else
                {
                    Response.Redirect("kioskreg.aspx");
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We could not find any appointment, please make your way to the Ambulatory Care Centre reception'); window.location = '" + Page.ResolveUrl("kioskhome.aspx") + "';", true);
                }
            }

            else
            {
                MessageBox.Show("Please Swipe the card again");
            }
        }
        catch (Exception ex)
        {
        }
       
        
        //string fname = Hidden1.Value;
        //string lname = Hidden2.Value;
        //string uname = Hidden3.Value;
        //string terdesc = Hidden7.Value;
        //string uid = Hidden4.Value;
        //string tid = Hidden5.Value;
        //string dd = Hidden8.Value;
        //string url = string.Format("kioskdoctor.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
        //    Server.UrlEncode(fname),
        //    Server.UrlEncode(lname),
        //    Server.UrlEncode(uname),
        //    Server.UrlEncode(terdesc),
        //    Server.UrlEncode(uid),
        //    Server.UrlEncode(tid),
        //    Server.UrlEncode(did),
        //    Server.UrlEncode(dd));
        //Response.Redirect(url, false);

       //MessageBox.Show("We could not find any appointment, please make your way to the Ambulatory Care Centre reception");
        
    }

    public void print()
    {


        bool firstval;
        DataTable dtbl = new DataTable();
        DataTable CheckingQueueToken = new DataTable();

        string updatesuccess = string.Empty;
        string insertsuccess = string.Empty;
        string PatientName = string.Empty;

        //newprint.PrintQueuno("DE1-0321");
        //newprint.ReceiptPrint(senderrec, rec);

        try
        {

            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            //kioskview.CusLastName = Server.UrlDecode(Request.QueryString["1"]);



            //kioskview.Dob = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["2"]));
           // kioskview.CusLastName = snam;
            //kioskview.Dob = Convert.ToDateTime(dob);
            firstval = true;
            dt = kioskcntrl.GetWalkinDetails(kioskview);
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
                int co = 0;
                //if (CheckingQueueToken.Rows.Count == 0)
                if (co == 0)
                {


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
                                string DepartmentDescription = dr["department_desc"].ToString();
                                queueno1++;
                                updatesuccess = kioskcntrl.UpdateDeptQueuNo(selectedItem1, queueno1);
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
                                kioskview.QueueNummberShow = queueno1.ToString();
                                // kisokview.ESCInNumber = txt_esicno.Text;http://localhost:17809/ESICLogin/kiosklang1.aspx

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
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

        //string fname = Hidden1.Value;
        //string lname = Hidden2.Value;
        //string uname = Hidden3.Value;
        //string terdesc = Hidden7.Value;
        //string uid = Hidden4.Value;
        //string tid = Hidden5.Value;
        //string did = Hidden6.Value;
        //string dd = Hidden8.Value;
        //string url = string.Format("kiosklang.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
        //    Server.UrlEncode(fname),
        //    Server.UrlEncode(lname),
        //    Server.UrlEncode(uname),
        //    Server.UrlEncode(terdesc),
        //    Server.UrlEncode(uid),
        //    Server.UrlEncode(tid),
        //    Server.UrlEncode(did),
        //    Server.UrlEncode(dd));
        //Response.Redirect(url, false);


        string url = string.Format("kioskhome.aspx");
        Response.Redirect(url, false);
    }



   

    protected void HiddenField1_ValueChanged(object sender, EventArgs e)
    {

    }
    //protected void Timer1_Tick(object sender, EventArgs e)
    //{
    //    if (chk == "yes")
    //    {
    //        chk = "no";

    //        //kisokview.CusLastName = snam;

    //        //kisokview.Dob = Convert.ToDateTime(dob);

    //        ////firstval = true;
    //        //// dt = kioskcntrl.GetAppointmentDetails(kisokview);
    //        //kisokview.ESCInNumber = esi;

          
    //    }
    //}
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
}

//Kiosk  - Kiosk Add Value

#region Kiosk - Kiosk Add Value

public class KioskAddValue
{
    private string m_Display;
    private long m_Value;
    public KioskAddValue(string Display, long Value)
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