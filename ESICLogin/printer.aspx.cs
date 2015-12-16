using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class printer : System.Web.UI.Page
{
    private Thread StatusThread = null;
    private bool sysdevicestatus = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["fname"] = Server.UrlDecode(Request.QueryString["1"]);
            Session["lname"] = Server.UrlDecode(Request.QueryString["2"]);
            Session["uname"] = Request.QueryString["3"];
            Session["terdesc"] = Request.QueryString["4"];
            Session["uid"] = Server.UrlDecode(Request.QueryString["5"]);
            Session["tid"] = Server.UrlDecode(Request.QueryString["6"]);
            Session["did"] = Server.UrlDecode(Request.QueryString["7"]);
            Session["dd"] = Server.UrlDecode(Request.QueryString["8"]);

            lbl_queueno1.Text = Request.QueryString["val"];
            lbl_esicno1.Text = Server.UrlDecode(Request.QueryString["10"]);
            lbl_datetime1.Text = Convert.ToString(DateTime.Now);
            //StatusThread = new Thread(new ThreadStart(StatusMonitoring));
            //StatusThread.Start();
        }
    }

    public void StatusMonitoring()
    {

        while (!sysdevicestatus)
        {
            Thread.Sleep(3000);
            sysdevicestatus = true;

            //string fname = Server.UrlDecode(Request.QueryString["1"]);
            //string lname = Server.UrlDecode(Request.QueryString["2"]);
            //string uname = Request.QueryString["3"];
            //string terdesc = Request.QueryString["4"];
            //string uid = Server.UrlDecode(Request.QueryString["5"]);
            //string tid = Server.UrlDecode(Request.QueryString["6"]);
            //string did = Server.UrlDecode(Request.QueryString["7"]);
            //string dd = Server.UrlDecode(Request.QueryString["8"]);
            string url = string.Format("crtesic.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                                Server.UrlEncode(Session["fname"].ToString()),
                                Server.UrlEncode(Session["lname"].ToString()),
                                Server.UrlEncode(Session["uname"].ToString()),
                                Server.UrlEncode(Session["terdesc"].ToString()),
                                Server.UrlEncode(Session["uid"].ToString()),
                                Server.UrlEncode(Session["tid"].ToString()),
                                Server.UrlEncode(Session["did"].ToString()),
                                Server.UrlEncode(Session["dd"].ToString()));
            //  HttpContext.Current.Response.Redirect(url,false);
            Response.Redirect(url, false);
        }
    }
}