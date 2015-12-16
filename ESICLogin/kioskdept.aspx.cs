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
using System.Windows.Forms;

public partial class kioskdept : System.Web.UI.Page
{
    KioskBEL kisokview=new KioskBEL();
    kioskBAL kioskcntrl=new kioskBAL();
    public StringBuilder strb = new StringBuilder();
    public ArrayList arrloaddepot = new ArrayList();
    public ArrayList arrloadpatient = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public ArrayList arraylist1 = new ArrayList();
    public ArrayList arraylist2 = new ArrayList();
    public string QueueTicket, DeptName;
    string AverageWaitingQueue, AverageWaitingTime;
    string DepartmentDescription;
    public int showqueueno = 1;

    int ApproximateWaitingTime = Convert.ToInt16(ConfigurationManager.AppSettings["ApproximateWaitingTime"].ToString());
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
            chk = "no";
            load();
            // Timer1_Tick(sender, e);
           // Label4.Text = DateTime.Now.ToLongDateString();
           // lbl_clientip.Text = GetIP();
           // lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
           // string fname = Server.UrlDecode(Request.QueryString["1"]);
            //string lname = Server.UrlDecode(Request.QueryString["2"]);
            //string uname = Request.QueryString["3"];
            snam = Server.UrlDecode(Request.QueryString["1"]);
             dob = Server.UrlDecode(Request.QueryString["2"]);
             esi = kisokview.ESCInNumber = Server.UrlDecode(Request.QueryString["5"]);
             pid = Server.UrlDecode(Request.QueryString["6"]);
            Button1.Visible = true;
            //ImageButton3.Visible = false;
           // Label1.Text = Server.UrlDecode(Request.QueryString["3"]);
           // Label2.Text = Server.UrlDecode(Request.QueryString["4"]);
            apptime = Server.UrlDecode(Request.QueryString["4"]);

            //string did = Server.UrlDecode(Request.QueryString["7"]);
            //string dd = Server.UrlDecode(Request.QueryString["8"]);
            //txt_esicno.Text = Server.UrlDecode(Request.QueryString["9"]);
            //txt_customername.Text = Server.UrlDecode(Request.QueryString["10"]); 
           // lbl_userna.Text = uname;
            //Session["User"] = uname;
           // Session["esicno"] = "0";
           // Label2.Text = terdesc;
           // Label5.Text = dd;
            //RetriveMemberInfo();
            //PageStart();
            //LoadDepart();
            //btn_print.Enabled = false;
            //btn_reprint.Enabled = false;
        }
    }
    public void load()
    {
        DataTable dt = new DataTable();
        kisokview.ESCInNumber = Server.UrlDecode(Request.QueryString["5"]);
        kisokview.MemberId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"])) ;

        //kioskview.Dob = Convert.ToDateTime(TextBox2.Text);
        // kioskview.Dob = Convert.ToDateTime(RadDatePicker1.SelectedDate);

        dt = kioskcntrl.GetAppointmentDetailsCard(kisokview);
        if (dt.Rows.Count != 0)
        {
            gv_queuedetails.DataSource = dt;
            gv_queuedetails.DataBind();
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

    #region Simple Kiosk - Print Sending

    public void SimpleKioskPrint()
    {
        Session["UserAuthentication0"] = QueueTicket;
        Session["UserAuthentication1"] = DeptName;
        Session["UserAuthentication2"] = Convert.ToString(DateTime.Now);

        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width)-(2/2);var Mtop = (screen.height)-(1200/2);window.open('Print.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }

    #endregion Simple Kiosk - Print Sending
  
   
    
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string url = string.Format("kioskhome.aspx");
        Response.Redirect(url,false);

        //if (Server.UrlDecode(Request.QueryString["1"]) != null)
        //{
        //    string url = string.Format("kiosklang.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
        //                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["1"]).ToString()),
        //                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["2"]).ToString()),
        //                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["3"]).ToString()),
        //                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["4"]).ToString()),
        //                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["5"]).ToString()),
        //                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["6"]).ToString()),
        //                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["7"]).ToString()),
        //                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["8"]).ToString()));
        //    Response.Redirect(url, false);
        //}
        //else
        //{
        //    string url = string.Format("kiosklang.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
        //                  Server.UrlEncode(Session["fname"].ToString()),
        //                  Server.UrlEncode(Session["lname"].ToString()),
        //                  Server.UrlEncode(Session["uname"].ToString()),
        //                  Server.UrlEncode(Session["terdesc"].ToString()),
        //                  Server.UrlEncode(Session["uid"].ToString()),
        //                  Server.UrlEncode(Session["tid"].ToString()),
        //                  Server.UrlEncode(Session["did"].ToString()),
        //                  Server.UrlEncode(Session["dd"].ToString()));
        //    Response.Redirect(url, false);
        //}
    }
    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {

        string url = string.Format("kioskemail.aspx?1={0}&2={1}&3={2}&4={3}&5={4}", Server.UrlEncode(esi), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid), Server.UrlEncode("a"));
        Response.Redirect(url, false);
    }
    public void next()
    {
        if (status == 2)
        {
            string url = string.Format("kioskesicno.aspx");
            Response.Redirect(url, true);
        }
    }
    //protected void Timer1_Tick(object sender, EventArgs e)
    //{
    //    if (chk == "yes")
    //    {
    //        chk = "no";

    //        kisokview.CusLastName = snam;

    //        kisokview.Dob = Convert.ToDateTime(dob);

    //        //firstval = true;
    //        // dt = kioskcntrl.GetAppointmentDetails(kisokview);
    //        kisokview.ESCInNumber = esi;


    //        string url = string.Format("kiosksuccess.aspx?1={0}&2={1}&3={2}&4={3}", Server.UrlEncode(kisokview.ESCInNumber), Server.UrlEncode(queno), Server.UrlEncode(dpt), Server.UrlEncode(pid));
    //        Response.Redirect(url, true);

    //    }
    //}
    //protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    //{
    //    DataTable dt = new DataTable();
        
    //    kisokview.CusLastName = snam;

    //    kisokview.Dob = Convert.ToDateTime(dob);

    //    //firstval = true;
    //   // dt = kioskcntrl.GetAppointmentDetails(kisokview);
    //    kisokview.ESCInNumber = esi;


    //    string url = string.Format("kioskemail.aspx?1={0}&2={1}&3={2}", Server.UrlEncode(kisokview.ESCInNumber), Server.UrlEncode(queno), Server.UrlEncode(dpt));
    //    Response.Redirect(url, true);
    //}
}
public class Kiosk1AddValue
{
    private string m_Display;
    private long m_Value;
    public Kiosk1AddValue(string Display, long Value)
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