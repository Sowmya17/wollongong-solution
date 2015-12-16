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

public partial class kisokprint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Timer1_Tick(sender, e);
           // Label4.Text = DateTime.Now.ToLongDateString();
           // lbl_clientip.Text = GetIP();
            //lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
            Session["fname"] = Server.UrlDecode(Request.QueryString["1"]);
            Session["lname"] = Server.UrlDecode(Request.QueryString["2"]);
            Session["uname"] = Request.QueryString["3"];
            Session["terdesc"] = Request.QueryString["4"];
            Session["uid"] = Server.UrlDecode(Request.QueryString["5"]);
            Session["tid"] = Server.UrlDecode(Request.QueryString["6"]);
            Session["did"] = Server.UrlDecode(Request.QueryString["7"]);
            Session["dd"] = Server.UrlDecode(Request.QueryString["8"]);

            string PatientName = Server.UrlDecode(Request.QueryString["11"]);

           // lbl_userna.Text = Session["uname"].ToString();
            Session["User"] = Session["uname"].ToString();
            Session["esicno"] = "0";

            Label1.Text = "You Have Already Generated Queue Token For " + PatientName + " Patient. Please Contact CRT";

            string fname = Server.UrlDecode(Request.QueryString["1"]);
            string lname = Server.UrlDecode(Request.QueryString["2"]);
            string uname = Request.QueryString["3"];
            string terdesc = Request.QueryString["4"];
            string uid = Server.UrlDecode(Request.QueryString["5"]);
            string tid = Server.UrlDecode(Request.QueryString["6"]);
            string did = Server.UrlDecode(Request.QueryString["7"]);
            string dd = Server.UrlDecode(Request.QueryString["8"]);

           // Label2.Text = Session["terdesc"].ToString();
           //s Label5.Text = Session["dd"].ToString();
           // Returnhome();
            //PageStart();
            //LoadDepart();
            //btn_print.Enabled = false;
            //btn_reprint.Enabled = false;
         //   Printer.Show(Server.UrlDecode(Request.QueryString["9"]), Server.UrlDecode(Request.QueryString["10"]), Server.UrlDecode(Request.QueryString["11"]), Server.UrlDecode(Request.QueryString["12"]));
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
    //private void Returnhome()
    //{
    //    //Thread.SpinWait(5);
    //    string fname = Server.UrlDecode(Request.QueryString["1"]);
    //    string lname = Server.UrlDecode(Request.QueryString["2"]);
    //    string uname = Request.QueryString["3"];
    //    string terdesc = Request.QueryString["4"];
    //    string uid = Server.UrlDecode(Request.QueryString["5"]);
    //    string tid = Server.UrlDecode(Request.QueryString["6"]);
    //    string did = Server.UrlDecode(Request.QueryString["7"]);
    //    string dd = Server.UrlDecode(Request.QueryString["8"]);
    //    string url = string.Format("kioskesicno.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
    //                    Server.UrlEncode(fname),
    //                    Server.UrlEncode(lname),
    //                    Server.UrlEncode(uname),
    //                    Server.UrlEncode(terdesc),
    //                    Server.UrlEncode(uid),
    //                    Server.UrlEncode(tid),
    //                    Server.UrlEncode(did),
    //                    Server.UrlEncode(dd));
    //  //  Response.Redirect(url, false);
    //}
}