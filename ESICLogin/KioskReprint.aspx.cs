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

public partial class KioskDetails : System.Web.UI.Page
{
    //string AverageWaitingTime, AverageWaitingQueue;

    DataTable MyQueueNumber = new DataTable();

    int ApproximateWaitingTime = Convert.ToInt16(ConfigurationManager.AppSettings["ApproximateWaitingTime"].ToString());

    
    
    
    LoginBAL logincntrl;

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
       // dob = Server.UrlDecode(Request.QueryString["2"]);
       // snam = Server.UrlDecode(Request.QueryString["3"]);
       // pid = Server.UrlDecode(Request.QueryString["4"]);
       // chk = Server.UrlDecode(Request.QueryString["5"]);
        Label6.Text = "You Have Already Generated Queue Ticket";

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

        DataTable dtbl = new DataTable();
        DataTable CheckingQueueToken = new DataTable();
        kioskview = new KioskBEL();
        kioskcntrl = new kioskBAL();
        
        string PatientName = string.Empty;
        kioskview.ESCInNumber = txt_esicno.Text;
        kioskview.CustomerFullName = txt_cusfname.Text + txt_cuslname.Text;
        //crtview.PatientId = Convert.ToInt32(ddl_patlist.SelectedValue);
        //PatientName = ddl_patlist.SelectedItem.Text;
        CheckingQueueToken = kioskview.KioskReprintCheckQueueTokenAlreadyGenerated(kioskview);

        if (CheckingQueueToken.Rows.Count == 0)
        {
            MyMessageBox("You are not Generated any Token to Reprint Please generate a Print first");
        }
        else if (CheckingQueueToken.Rows.Count == 1)
        {
            int selectedItem1 = Convert.ToInt32(CheckingQueueToken.Rows[0][3]);
            kioskview.QueueNummberShow = Convert.ToString(CheckingQueueToken.Rows[0][6]);
            DataTable TotalWaitingQueue = kioskcntrl.GettingTotalWaitingQueue(selectedItem1);
            int count = TotalWaitingQueue.Rows.Count;

            if (TotalWaitingQueue.Rows.Count > 0)
            {
                AverageWaitingQueue = Convert.ToString(count) + " Patients Before You";
                AverageWaitingTime = Convert.ToString(count * ApproximateWaitingTime) + " Minutes Approximately";
            }
            else
            {
                AverageWaitingQueue = "0 Patients Before You";
                AverageWaitingTime = "0 Minutes Approximately";
            }
            Session["UserAuthentication0"] = kioskview.QueueNummberShow;
            Session["UserAuthentication1"] = txt_esicno.Text;

            Session["UserAuthentication2"] = AverageWaitingQueue;
            Session["UserAuthentication3"] = AverageWaitingTime;
            Session["UserAuthentication4"] = Convert.ToString(DateTime.Now);

            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(2/2);var Mtop = (screen.height/2)-(1200/2);window.open( 'ReprintDisplay.aspx', null, 'height=20000,width=20000,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);


        }
        else
        {
            Session["UserAuthentication1"] = txt_esicno.Text;
            kioskview.ESCInNumber = txt_esicno.Text;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "ReprintDisplay", "reprintdisplay();", true);
        }
       
        //string url = string.Format("kiosksuccess1.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}", Server.UrlEncode(esi), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid), Server.UrlEncode(chk), Server.UrlEncode("r"));
        //Response.Redirect(url, false);
    }

    public void MyMessageBox(string text)
    {
        string script = "alert('" + text + "');";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        
        
        //string url = string.Format("kiosksuccess.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}", Server.UrlEncode(esi), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid), Server.UrlEncode(chk), Server.UrlEncode("n"));
        string url = string.Format("kioskhome.aspx");
        Response.Redirect(url, false);
    
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        
        string url = string.Format("Kioskhome.aspx");
        Response.Redirect(url, false);
    }
}
//else
//{
//Response.Redirect("kiosksuccess.aspx")
//}