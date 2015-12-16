using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;
using System.Threading;
using System.Globalization;

public partial class KioskDetails : System.Web.UI.Page
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

    protected void Page_Load(object sender, EventArgs e)
    {

        esi = Server.UrlDecode(Request.QueryString["1"]);
        dob = Server.UrlDecode(Request.QueryString["2"]);
        snam = Server.UrlDecode(Request.QueryString["3"]);
        pid = Server.UrlDecode(Request.QueryString["4"]);
        chk = Server.UrlDecode(Request.QueryString["5"]);

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string url = string.Format("kiosksuccess1.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}", Server.UrlEncode(esi), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid), Server.UrlEncode(chk), Server.UrlEncode("r"));
        Response.Redirect(url, false);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
      
        {
            string url = string.Format("kioskReprint.aspx");
            Response.Redirect(url, false);
        }

        {
            string url = string.Format("kiosksuccess.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}", Server.UrlEncode(esi), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid), Server.UrlEncode(chk), Server.UrlEncode("n"));
            Response.Redirect(url, false);
        }
    }
   // try
   //{
   //         DataTable dt = new DataTable();
   //         DataTable dt1 = new DataTable();

   //         //kioskview.CusLastName = Server.UrlDecode(Request.QueryString["1"]);



   //         //kioskview.Dob = Convert.ToDateTime(Server.UrlDecode(Request.QueryString["2"]));
  
            
   //             dt = kioskcntrl.GetWalkinDetailsEsi(kioskview);
            

   //         if (dt.Rows.Count > 0)
   //         {
   //             kioskview.ESCInNumber = dt.Rows[0][0].ToString();
   //             kioskview.CustomerFullName = dt.Rows[0][1].ToString();
   //             kioskview.PatientId = Convert.ToInt32(dt.Rows[0][2].ToString());
   //             pid = dt.Rows[0][2].ToString();
   //             // kioskview.AppointmentID = Convert.ToInt32(dt.Rows[0][2].ToString());
   //             //kioskview.AppointmentDateTime = Convert.ToDateTime(dt.Rows[0][0].ToString());
   //             kioskview.ConsultingStatus = "W";
}