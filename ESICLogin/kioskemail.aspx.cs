using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;

public partial class kiosklang : System.Web.UI.Page
{
    KioskBEL kioskview = new KioskBEL();
    kioskBAL kioskcntrl = new kioskBAL();
    public string fname;
    public string lname;
    public string uname;
    public string terdesc;
    public string uid;
    public string tid;
    public string did;
    public string dd;
    public string s = "y";
    public bool valid = false;

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
            TextBox2.Focus();
          //  ScriptManager.RegisterStartupScript(this, GetType(), "changeToNumber", "changeToNumber();", true);
            esi = Server.UrlDecode(Request.QueryString["1"]);
            dob = Server.UrlDecode(Request.QueryString["2"]);
            snam = Server.UrlDecode(Request.QueryString["3"]);
            pid = Server.UrlDecode(Request.QueryString["4"]);
            chk= Server.UrlDecode(Request.QueryString["5"]);
            
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

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

        if (TextBox2.Text != "")
        {
            
                if (TextBox2.Text.Length > 11)
                {
                    MessageBox.Show("Please Enter Valid Phone Number");
                }
                else
                {
                    s = "y";
                    DataTable dt = new DataTable();
                    // snam = TextBox2.Text;
                    kioskview.ESCInNumber = (Server.UrlDecode(Request.QueryString["1"]));
                    kioskview.PatientId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["4"]));
                    // kisokview.CusMobile = (snam);
                    // kioskview.Email = TextBox1.Text;
                    try
                    {

                        kioskcntrl.UpdateMob(kioskview, TextBox2.Text);
                    }
                    catch (Exception)
                    {
                        s = "n";
                        MessageBox.Show("Please Enter Proper Mobile Number");
                    }

                    if (s == "y")
                    {
                        string url = string.Format("KioskDetails.aspx?1={0}&2={1}&3={2}&4={3}&5={4}", Server.UrlEncode(esi), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid), Server.UrlEncode(chk));
                        Response.Redirect(url, false);
                        //string url1 = string.Format("kioskmobsuccess.aspx?1={0}&2={1}", Server.UrlEncode("1"), Server.UrlEncode(""));
                        //Response.Redirect(url1, false);
                    }
                }
                // MessageBox.Show("Please Enter Mobile Number");


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
        Response.Redirect(url, true);
    }

    public bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {

        string url = string.Format("KioskDetails.aspx?1={0}&2={1}&3={2}&4={3}&5={4}", Server.UrlEncode(esi), Server.UrlEncode(dob), Server.UrlEncode(snam), Server.UrlEncode(pid), Server.UrlEncode(chk));
        Response.Redirect(url, false);

        //string chk = "Please take your ticket, and remain in the waiting area,";
        //string chk1 = "we will serve you shortly.";
        //string url = string.Format("kioskmobsuccess.aspx?1={0}&2={1}", Server.UrlEncode("0"), Server.UrlEncode(chk1));
        //Response.Redirect(url, true);
    }
}