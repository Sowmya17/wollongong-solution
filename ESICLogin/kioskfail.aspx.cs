using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kiosklang : System.Web.UI.Page
{
    public string fname;
    public string lname;
    public string uname;
    public string terdesc;
    public string uid;
    public string tid;
    public string did;
    public string dd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

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
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {

        string url = string.Format("kiosklang.aspx");
        Response.Redirect(url, false);
    }
    protected void Button1_Click(object sender, ImageClickEventArgs e)
    {
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {

        string url = string.Format("kiosklang.aspx");
        Response.Redirect(url, false);
    }
}