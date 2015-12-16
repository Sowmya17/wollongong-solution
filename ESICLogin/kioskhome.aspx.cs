using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class kioskhome : System.Web.UI.Page
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
            //Hidden1.Value = fname;
            //Hidden2.Value = lname;
            //Hidden3.Value = uname;
            //Hidden4.Value = uid;
            //Hidden5.Value = tid;
            //Hidden6.Value = did;
            //Hidden7.Value = terdesc;
            //Hidden8.Value = dd;
        }
    }

   
       protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        string depart = "30";
        string url = string.Format("kiosksuccessnew.aspx?1={0}",
            Server.UrlEncode(depart));
        Response.Redirect(url, false);
        //string url = string.Format("kioskreg.aspx");
        //Response.Redirect(url, false);


       //DataTable dt = new DataTable();
       // DataTable dtbl = new DataTable();
       // string esi = "";
       // int esi1 = 0;
       // dtbl = kioskcntrl.GetDummyNo(kioskview);
       // if (dtbl.Rows.Count != 0)
       // {
       //     esi1 = Convert.ToInt32(dtbl.Rows[0][0].ToString());
       //     esi1++;

       // }
       // kioskview.ESCInNumber = esi1.ToString();

       // kioskview.CusFirstname = "abc";
       // kioskview.CusLastName = "efg";
       // kioskview.CusAddress = "australia";
       // kioskview.CusAge = 25;
       // kioskview.CusPhoneNo = 61499721372;
       // kioskview.CusGender = 'M';
       // kioskview.Email = "abc@gmail.com";
       // kioskview.TerminalUser = "admin";
       // kioskview.RelationId = 1;
       // kioskview.Dob = Convert.ToDateTime("1989/10/31");
       // string insertsucess;
       // insertsucess = kioskcntrl.RegCustomerDetail(kioskview);
       // if (insertsucess == "0")
       //{
       //     dtbl = kioskcntrl.UpdateDummyNo(kioskview);
       // }
       // dtbl = kioskcntrl.GetMemberDetail(esi1.ToString());
       // if (dtbl.Rows.Count != 0)
       // {
       //     kioskview.MemberId = Convert.ToInt32(dtbl.Rows[0][0].ToString());
       // }
       // try
       // {
       //     // string url = string.Format("kioskemail.aspx?1={0}&2={1}&3={2}&4={3}&5={4}", Server.UrlEncode(kioskview.ESCInNumber), Server.UrlEncode(kioskview.Dob.ToString()), Server.UrlEncode(kioskview.CusLastName), Server.UrlEncode(kioskview.MemberId.ToString()), Server.UrlEncode("w1"));
       //     //Response.Redirect(url, false);


       //     string url = string.Format("kiosksuccess1.aspx?1={0}&2={1}&3={2}&4={3}&5={4}", Server.UrlEncode(kioskview.ESCInNumber), Server.UrlEncode(kioskview.Dob.ToString()), Server.UrlEncode(kioskview.CusLastName), Server.UrlEncode(kioskview.MemberId.ToString()), Server.UrlEncode("w1"));
       //     Response.Redirect(url, false);
       //     // string url = string.Format("kiosksuccess.aspx?1={0}&2={1}&3={2}&4={3}&5={4}", Server.UrlEncode(kioskview.ESCInNumber), Server.UrlEncode(kioskview.Dob.ToString()), Server.UrlEncode(kioskview.CusLastName), Server.UrlEncode(""), Server.UrlEncode("w1"));
       //     // Response.Redirect(url, false);
       // }
       // catch (Exception)
       // {

       // }

    }
       protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
       {
           string url = string.Format("kioskhome2.aspx");
           Response.Redirect(url, false);
       }
}