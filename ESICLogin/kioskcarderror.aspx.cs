using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Data;
using System.Net;

public partial class kioskcarderror : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Timer1_Tick(sender, e);
            // Label4.Text = DateTime.Now.ToLongDateString();
            // lbl_clientip.Text = GetIP();
            // lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
            Session["fname"] = Server.UrlDecode(Request.QueryString["1"]);
            Session["lname"] = Server.UrlDecode(Request.QueryString["2"]);
            Session["uname"] = Request.QueryString["3"];
            Session["terdesc"] = Request.QueryString["4"];
            Session["uid"] = Server.UrlDecode(Request.QueryString["5"]);
            Session["tid"] = Server.UrlDecode(Request.QueryString["6"]);
            Session["did"] = Server.UrlDecode(Request.QueryString["7"]);
            Session["dd"] = Server.UrlDecode(Request.QueryString["8"]);
            //   lbl_userna.Text = Session["uname"].ToString();
            Session["User"] = Session["uname"].ToString();
            Session["esicno"] = "0";
            //  Label2.Text = Session["terdesc"].ToString();
            //  Label5.Text = Session["dd"].ToString();
            // Returnhome();
            //PageStart();
            //LoadDepart();
            //btn_print.Enabled = false;
            //btn_reprint.Enabled = false;

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
}