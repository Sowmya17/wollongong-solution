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
    string det
    {

        get { return ViewState["det"] as string; }
        set { ViewState["det"] = value; }

    }

    string reg
    {

        get { return ViewState["reg"] as string; }
        set { ViewState["reg"] = value; }

    }

   



    protected void Page_Load(object sender, EventArgs e)
    {

        
        if (!IsPostBack)
        {
            


            //chk= Server.UrlDecode(Request.QueryString["1"]);
            //dob = Server.UrlDecode(Request.QueryString["2"]);
            //snam= Server.UrlDecode(Request.QueryString["3"]);
            //pid = Server.UrlDecode(Request.QueryString["4"]);
            //esi = Server.UrlDecode(Request.QueryString["5"]);
            //reg = Server.UrlDecode(Request.QueryString["6"]);
            //if (esi == "y")
            //{
            //    Label1.Text = "Please make your way to reception to check your details";
                
            //}
            //else
            //{
            //    Label1.Text = "Please remain in the waiting room until your number has been called.";
                
            //}
            //if (esi == "w" || esi=="w1")
            //{
            //    print();
            //}
            //if (esi == "a" && reg=="n")
            //{
            //    printappointment();
            //}
            //else if (esi == "a" && reg == "r")
            //{
            //    printappointmentreg();
            //}
            ////fname = Server.UrlDecode(Request.QueryString["1"]);
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

        //if (chk == "yes")
        //{
        //  chk = "no";

    //        kisokview.CusLastName = snam;

    //        kisokview.Dob = Convert.ToDateTime(dob);

    //        //firstval = true;
    //        // dt = kioskcntrl.GetAppointmentDetails(kisokview);
    //        kisokview.ESCInNumber = esi;


    //        string url = string.Format("kiosksuccess.aspx?1={0}&2={1}&3={2}&4={3}", Server.UrlEncode(kisokview.ESCInNumber), Server.UrlEncode(queno), Server.UrlEncode(dpt), Server.UrlEncode(pid));
    //        Response.Redirect(url, true);

        string url = string.Format("kioskhome.aspx");
        Response.Redirect(url, false);
        //}
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string url = string.Format("kioskemail.aspx?1={0}&2={1}&3={2}&4={3}", Server.UrlEncode(chk), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid));
        Response.Redirect(url, true);
    }
}