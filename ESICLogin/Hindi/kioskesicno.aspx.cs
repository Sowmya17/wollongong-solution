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


public partial class kioskesicno : System.Web.UI.Page
{
    KioskBEL kisokview;
    kioskBAL kioskcntrl;
    public StringBuilder strb = new StringBuilder();
    public ArrayList arrloaddepot = new ArrayList();
    public ArrayList arrloadpatient = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public ArrayList arraylist1 = new ArrayList();
    public ArrayList arraylist2 = new ArrayList();
    public string fname ;
    public string lname;
    public string uname ;
    public string terdesc;
    public string uid ;
    public string tid;
    public string did ;
    public string dd;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Timer1_Tick(sender, e);
          //  Label4.Text = DateTime.Now.ToLongDateString();
            //lbl_clientip.Text = GetIP();
           // lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
                
             fname = Server.UrlDecode(Request.QueryString["1"]);
            if (fname == null)
            {
                fname = Session["fname"].ToString();
            }

             lname = Server.UrlDecode(Request.QueryString["2"]);
            if (lname == null)
            {
                lname = Session["lname"].ToString();
            }

             uname = Request.QueryString["3"];
            if (uname == null)
            {
                uname = Session["uname"].ToString();
            }

             terdesc = Request.QueryString["4"];
            if (terdesc == null)
            {
                terdesc = Session["terdesc"].ToString();
            }

             uid = Server.UrlDecode(Request.QueryString["5"]);
            if (uid == null || uid == string.Empty)
            {
                uid = Session["uid"].ToString();
            }

             tid = Server.UrlDecode(Request.QueryString["6"]);
            if (tid == null)
            {
                tid = Session["tid"].ToString();
            }

             did = Server.UrlDecode(Request.QueryString["7"]);
            if (did == null)
            {
                did = Session["did"].ToString();
            }
             dd = Server.UrlDecode(Request.QueryString["8"]);
            if (dd == null)
            {
                dd = Session["dd"].ToString();
            }

           // lbl_userna.Text = uname;
            Session["User"] = uname;
            Session["esicno"] = "0";
           // Label2.Text = terdesc;
           // Label5.Text = dd;
            //PageStart();
            //LoadDepart();
            //btn_print.Enabled = false;
            //btn_reprint.Enabled = false;
            CardReader.Focus();
        }
        //write.Value = string.Empty;
        CardReader.Focus();
    }
    private string GetIP()
    {
        string strHostName = "";
        strHostName = System.Net.Dns.GetHostName();

        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

        IPAddress[] addr = ipEntry.AddressList;

        return addr[addr.Length - 3].ToString();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        kisokview = new KioskBEL();
        kioskcntrl = new kioskBAL();
        try
        {
            //strb.Append(txt_esicno.Text);
            kisokview.Esicnodetails = kioskcntrl.GetRegCustomerDetail(write.Value);
            if (kisokview.Esicnodetails.Rows.Count > 0)
            {

              //  AvailableESCIno();
                foreach (DataRow dr in kisokview.Esicnodetails.Rows)
                {

                    kisokview.CusFirstname = dr["customer_firstname"].ToString();
                    kisokview.CusLastName = dr["customer_lastname"].ToString();
                }

                if (Server.UrlDecode(Request.QueryString["1"]) != null)
                {
                    string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}&10={9}",
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["1"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["2"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["3"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["4"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["5"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["6"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["7"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["8"]).ToString()),
                    Server.UrlEncode(write.Value), Server.UrlEncode(kisokview.CusFirstname + " " + kisokview.CusLastName));
                    Response.Redirect(url, false);
                }
                else
                {
                    string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}&10={9}",
                                  Server.UrlEncode(Session["fname"].ToString()),
                                  Server.UrlEncode(Session["lname"].ToString()),
                                  Server.UrlEncode(Session["uname"] .ToString()),
                                  Server.UrlEncode( Session["terdesc"] .ToString()),
                                  Server.UrlEncode( Session["uid"].ToString()),
                                  Server.UrlEncode(Session["tid"].ToString()),
                                  Server.UrlEncode(Session["did"].ToString()),
                                  Server.UrlEncode( Session["dd"].ToString()),
                  Server.UrlEncode(write.Value), Server.UrlEncode(kisokview.CusFirstname + " " + kisokview.CusLastName));
                    Response.Redirect(url, false);
                }
                
            }
            else
            {
                if (Server.UrlDecode(Request.QueryString["1"]) != null)
                {
                    string url = string.Format("kioskerror.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                                     Server.UrlEncode(Server.UrlDecode(Request.QueryString["1"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["2"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["3"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["4"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["5"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["6"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["7"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["8"]).ToString()));
                    Response.Redirect(url, false);
                }
                else
                {
                    string url = string.Format("kioskerror.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                                   Server.UrlEncode(Session["fname"].ToString()),
                                  Server.UrlEncode(Session["lname"].ToString()),
                                  Server.UrlEncode(Session["uname"].ToString()),
                                  Server.UrlEncode(Session["terdesc"].ToString()),
                                  Server.UrlEncode(Session["uid"].ToString()),
                                  Server.UrlEncode(Session["tid"].ToString()),
                                  Server.UrlEncode(Session["did"].ToString()),
                                  Server.UrlEncode(Session["dd"].ToString()));
                    Response.Redirect(url, false);
                }
            }

        }
        catch (Exception ex)
        {
            throw new Exception("Problem in text change", ex);
        }
        finally
        {
            kioskcntrl = null;
        }
    }
   
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        write.Value = string.Empty;
        CardReader.Focus();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (Server.UrlDecode(Request.QueryString["1"]) != null)
        {
            string url = string.Format("../kiosklang.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                             Server.UrlEncode(Server.UrlDecode(Request.QueryString["1"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["2"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["3"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["4"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["5"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["6"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["7"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["8"]).ToString()));
            Response.Redirect(url, false);
        }
        else
        {
            string url = string.Format("../kiosklang.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                           Server.UrlEncode(Session["fname"].ToString()),
                          Server.UrlEncode(Session["lname"].ToString()),
                          Server.UrlEncode(Session["uname"].ToString()),
                          Server.UrlEncode(Session["terdesc"].ToString()),
                          Server.UrlEncode(Session["uid"].ToString()),
                          Server.UrlEncode(Session["tid"].ToString()),
                          Server.UrlEncode(Session["did"].ToString()),
                          Server.UrlEncode(Session["dd"].ToString()));
            Response.Redirect(url, false);
        }
    }

    private void CheckESICNumber()
    {
        kisokview = new KioskBEL();
        kioskcntrl = new kioskBAL();
        try
        {
            //strb.Append(txt_esicno.Text);
            kisokview.Esicnodetails = kioskcntrl.GetRegCustomerDetail(write.Value);
            if (kisokview.Esicnodetails.Rows.Count > 0)
            {

                //  AvailableESCIno();
                foreach (DataRow dr in kisokview.Esicnodetails.Rows)
                {

                    kisokview.CusFirstname = dr["customer_firstname"].ToString();
                    kisokview.CusLastName = dr["customer_lastname"].ToString();
                }

                if (Server.UrlDecode(Request.QueryString["1"]) != null)
                {
                    string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}&10={9}",
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["1"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["2"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["3"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["4"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["5"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["6"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["7"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["8"]).ToString()),
                    Server.UrlEncode(write.Value), Server.UrlEncode(kisokview.CusFirstname + " " + kisokview.CusLastName));
                    Response.Redirect(url, false);
                }
                else
                {
                    string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}&10={9}",
                                  Server.UrlEncode(Session["fname"].ToString()),
                                  Server.UrlEncode(Session["lname"].ToString()),
                                  Server.UrlEncode(Session["uname"].ToString()),
                                  Server.UrlEncode(Session["terdesc"].ToString()),
                                  Server.UrlEncode(Session["uid"].ToString()),
                                  Server.UrlEncode(Session["tid"].ToString()),
                                  Server.UrlEncode(Session["did"].ToString()),
                                  Server.UrlEncode(Session["dd"].ToString()),
                  Server.UrlEncode(write.Value), Server.UrlEncode(kisokview.CusFirstname + " " + kisokview.CusLastName));
                    Response.Redirect(url, false);
                }

            }
            else
            {
                if (Server.UrlDecode(Request.QueryString["1"]) != null)
                {
                    string url = string.Format("kioskerror.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                                     Server.UrlEncode(Server.UrlDecode(Request.QueryString["1"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["2"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["3"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["4"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["5"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["6"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["7"]).ToString()),
                                    Server.UrlEncode(Server.UrlDecode(Request.QueryString["8"]).ToString()));
                    Response.Redirect(url, false);
                }
                else
                {
                    string url = string.Format("kioskerror.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                                   Server.UrlEncode(Session["fname"].ToString()),
                                  Server.UrlEncode(Session["lname"].ToString()),
                                  Server.UrlEncode(Session["uname"].ToString()),
                                  Server.UrlEncode(Session["terdesc"].ToString()),
                                  Server.UrlEncode(Session["uid"].ToString()),
                                  Server.UrlEncode(Session["tid"].ToString()),
                                  Server.UrlEncode(Session["did"].ToString()),
                                  Server.UrlEncode(Session["dd"].ToString()));
                    Response.Redirect(url, false);
                }
            }

        }
        catch (Exception ex)
        {
            throw new Exception("Problem in text change", ex);
        }
        finally
        {
            kioskcntrl = null;
        }
    }


    protected void CardReader_OTC(object sender, EventArgs e)
    {
        //Textbox1.Text = CardReader.Text;
        if (CardReader.Text != string.Empty && (CardReader.Text.Length >= 15 || CardReader.Text.Length >= 12))
        {
            char[] c = CardReader.Text.ToString().ToCharArray();

            StringBuilder _extractnumbers = new StringBuilder();

            foreach (char _c in c)
            {

                if (Char.IsNumber(_c) == true)
                {

                    _extractnumbers.Append(_c);

                }

            }
            write.Value = _extractnumbers.ToString();
            // write.Focus();
            CardReader.Text = string.Empty;
            CheckESICNumber();

        }
        else
        {
            //if (Server.UrlDecode(Request.QueryString["1"]) != null)
            //{
            //    string url = string.Format("kioskcarderror.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
            //                     Server.UrlEncode(Server.UrlDecode(Request.QueryString["1"]).ToString()),
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
            //    string url = string.Format("kioskcarderror.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
            //                   Server.UrlEncode(Session["fname"].ToString()),
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
    }
}