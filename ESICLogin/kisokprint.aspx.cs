using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Windows;
using System.Collections;

public partial class Maya : System.Web.UI.Page
{
    static Dictionary<Page, Queue> pageTable = new Dictionary<Page, Queue>();

    protected void Page_Load(object sender, EventArgs e)
    {
        //kiosk queue number printed on ticket by session
        string kiosk = (string)(Session["Kisok_Qnum"]);
        if (Session["Kisok_Qnum"] != null)
        {
            Q_Number.Text = kiosk;

        }
        //kiosk ESIC number printed on ticket by session
        string ESIC = (string)(Session["Kisok_esic_num"]);
        if (Session["Kisok_esic_num"] != null)
        {
            ESIC_No.Text = ESIC;

        }

        //kiosk Date_Time.Text printed on ticket by session 
        string dateKiosktime = (string)(Session["Kiosk_date"]);
        if (Session["Kiosk_date"] != null)
        {
            Date_Time.Text=dateKiosktime;

        }

        //kiosk Avg_waiting _time printed on ticket by session
        string Avg_wt_time = (string)(Session["Kisok_Avgwaiting"]);
        if (Session["Kisok_Avgwaiting"] != null)
        {
           Waitng.Text = Avg_wt_time;

        }
        //kiosk Avg_waiting _time printed on ticket by session
        string Kisok_wq = (string)(Session["Kisok_Avgw_Que"]);
        if (Session["Kisok_Avgw_Que"] != null)
        {
            Avg.Text = Kisok_wq;

        } 

        //Kiosk Dept_Name
        string Kiosk_dept = (String)(Session["Kiosk_Department_name"]);
        if (Session["Kiosk_Department_name"] != null)
        {
            Dept_Name.Text = Kiosk_dept;
        }

        //code for placing * in between bar code
        /*Asterisk place before esic number for bar code_author for this module Ashok sen_14 aug 2013 for
         * kiosk not for crt which had been done earlier*/
        StringBuilder buffer = new StringBuilder();
        string String1 = "*{0}*";
        object[] objectArray = new object[1];
        objectArray[0] = Q_Number.Text;
        buffer.AppendFormat(String1, objectArray);
        Label3.Text = buffer.ToString();

        //HttpContext.Current.Response.Write("<script>window.print();</script>");

        //ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('kisokprint.aspx');</script>");

        //foreach (Window win in Application.Current.Windows)
        //{
        //if (!Window.IsFocused && Window.Tag.ToString() == "mdi_child")
        //    {
        //        Window.Close();
        //    }
        //}

        //ClientScript.RegisterStartupScript(GetType(), "SetFocusScript", "<Script>self.close();</Script>");

        //var windowToClose = window.open("test.htm");
        //windowToClose.close();

        //Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "keyname", "window.close('kisokprint.aspx')", true);

        //Respose.Write("<script>window.close()</script>");

        //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "<script type='text/JavaScript'>window.close();</script>");

        //string close = @"<script type='text/javascript'>window.close();</script>";
        //base.Response.Write(close);

      //  String cw = "<script language=javascript>window.close('`/kisokprint.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}&10={9}&11={10}&12={11}');</script>";


       // ClientScript.RegisterStartupScript(Page.GetType(), "clientScript", cw, true);

        //string str = "<script>closeWindow('kisokprint.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}');</script>";
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "Script", str, false);

      //  Page.ClientScript.RegisterStartupScript(this.GetType(), "kisokprint", "SenWindow();", true);

      // ScriptManager.RegisterStartupScript(Page, GetType(), "CallingJavaScript", "SenWindow();", true);


        string fname = Server.UrlDecode(Request.QueryString["1"]);
        string lname = Server.UrlDecode(Request.QueryString["2"]);
        string uname = Request.QueryString["3"];
        string terdesc = Request.QueryString["4"];
        string uid = Server.UrlDecode(Request.QueryString["5"]);
        string tid = Server.UrlDecode(Request.QueryString["6"]);
        string did = Server.UrlDecode(Request.QueryString["7"]);
        string dd = Server.UrlDecode(Request.QueryString["8"]);
        string url = string.Format("kisokprin1t.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                        Server.UrlEncode(fname),
                        Server.UrlEncode(lname),
                        Server.UrlEncode(uname),
                        Server.UrlEncode(terdesc),
                        Server.UrlEncode(uid),
                        Server.UrlEncode(tid),
                        Server.UrlEncode(did),
                        Server.UrlEncode(dd));


        Page page = HttpContext.Current.Handler as Page;

       // //HttpContext.Current.Response.Write("<script type='text/javascript'>"

       // // Extract the messages for this page and push them to client side
       //// HttpContext.Current.Response.Write("<script>alert('" + pageTable[page].Dequeue() + "');</script>");

       // HttpContext.Current.Response.Write("<script type='text/javascript'>"
       //     + "var DocumentContainer = '" + kiosk + "';"
       //     + "var DocumentContainer1 = '" + ESIC + "';"
       //     + "var DocumentContainer2 = '" + DateTime.Now.ToString("dd-MM-yyyy") + "';"
       //     + "var DocumentContainer3 = '" + Avg_wt_time + "';"
       //     + "var DocumentContainer4 = '" + Kisok_wq + "';"
       //     //+ "var DocumentContainer5 = '" + pageTable[page].Dequeue() + "';"
       //     + "var WindowObject = window.open('', 'kisokprint.aspx', 'width=1,height=1,top=1000,left=1000,toolbars=no,scrollbars=no,status=no,resizable=no');"
       //     // +"WindowObject.document.writeln(DocumentContainer);"
       //     // +"WindowObject.document.writeln(DocumentContainer1);"

       //     //+ "WindowObject.document.write('<html><head>');"
       //     //+ "WindowObject.document.write('</head><body><table><tr><td><h1>ESIC No</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer + '</h1></td></tr>');"
       //     //+ "WindowObject.document.write('<tr><td><h1>Queue No</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer1 + '</h1></td></tr>');"
       //     //+ "WindowObject.document.write('<tr><td><h1>Date</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer2 + '</h1></td></tr>');"
       //     //+ "WindowObject.document.write('<tr><td><h1>Time</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer3 + '</h1></td></tr>');"
       //     //+ "WindowObject.document.write('<tr><td><h1>Waiting Queue Status</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer4 + '</h1></td></tr><table>');"
       //     ////+ "WindowObject.document.write('<tr><td><h1>Average Waiting Time</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer5 + '</h1></td></tr></table>');"
       //     //+ "WindowObject.document.write('</body></html>');"
       //     //+ "WindowObject.document.close();"
       //     + "WindowObject.focus();"
       //     + "WindowObject.print();"
       //     + "WindowObject.close();"
       //     + "</script>");


      //  Response.Redirect(url, false);
        //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "Meyyappan", "SenWindow();", true);
        //ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);

       // this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);

        //Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.close = CloseWindow();");

        // Lets find out what page is sending the request


      //  Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "ClosePopup", "SenWindow();", true);


        // If a valid page is found
        if (page != null)
        {
            // Check if this page is requesing message show for the first time
            if (pageTable.ContainsKey(page) == false)
            {
                // Lets create a message queue dedicated for this page.
                pageTable.Add(page, new Queue());
            }

            // Let us add messages of this to the queue now
            pageTable[page].Enqueue(url);
        //    //pageTable[page].Enqueue(str1);
        //    //pageTable[page].Enqueue(str2);
        //    //pageTable[page].Enqueue(str3);

            // Now let put a hook on the page unload where we will show our message
            //page.Unload += new EventHandler(page_Unload);

        }

        //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "window.location='" + url.ToString() + "'", true);
       // ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect","alert('test 9'); window.location='" + Request.ApplicationPath + "anotherpage.aspx';", true);


        //ClientScript.RegisterStartupScript(GetType(), "Javascript", "<script type='text/javascript'>window.print();</script>", true);
        //ClientScript.RegisterStartupScript(GetType(), "Javascript", "<script type='text/javascript'>window.close();</script>", true);

        //this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "redirect", "window.open('" + url.ToString() + "')", true);
        this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "redirect", "setTimeout(function(){window.location='" + url.ToString() + "'},1000);", true);
      
        //ScriptManager.RegisterStartupScript(, "alert('Cliente cadastrado com sucesso.'); setTimeout(function(){window.location.href ='../../Default.aspx'}, 3000);", true);


        
        
        //ClientScript.RegisterStartupScript(this.GetType(), "alert", "window.open('" + url.ToString() + "')", true);
        //Page.ClientScript.RegisterStartupScript(this.GetType(), "RedirectingToNextPage", "window.open('')", True);
        //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "ClosePopup", "CloseWindow();", true);
    }

    //protected void Page_Unload(object sender, EventArgs e)
    //{
    //     Page page = sender as Page;
    //    string url = Convert.ToString(pageTable[page].Dequeue());

    //    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "redirect", "window.location='" + url.ToString() + "'", true);

    //   // Session["Userfname"] = refname;
    //    //Response.Redirect("crtesic.aspx");


    //}

    //static void page_Unload(object sender, EventArgs e)
    //{
    //    //ClientScript.RegisterClientScriptBlock(typeof(Page), "ClosePopup", "CloseWindow();", true);

    //     Page page = sender as Page;

    //     //// Extract the messages for this page and push them to client side
    //     //HttpContext.Current.Response.Write("<script>alert('" + pageTable[page].Dequeue() + "');</script>");

    //     //HttpContext.Current.Response.Write("<script type='text/javascript'>"
    //     //    + "var DocumentContainer = '" + pageTable[page].Dequeue() + "';"
    //     //    + "var DocumentContainer1 = '" + pageTable[page].Dequeue() + "';"
    //     //    + "var DocumentContainer2 = '" + DateTime.Now.ToString("dd-MM-yyyy") + "';"
    //     //    + "var DocumentContainer3 = '" + DateTime.Now.ToString("T") + "';"
    //     //    + "var DocumentContainer4 = '" + pageTable[page].Dequeue() + "';"
    //     //    + "var DocumentContainer5 = '" + pageTable[page].Dequeue() + "';"
    //     //    + "var WindowObject = window.open('', 'PrintWindow', 'width=1,height=1,top=1000,left=1000,toolbars=no,scrollbars=no,status=no,resizable=no');"
    //     //    // +"WindowObject.document.writeln(DocumentContainer);"
    //     //    // +"WindowObject.document.writeln(DocumentContainer1);"

    //     //    + "WindowObject.document.write('<html><head>');"
    //     //    + "WindowObject.document.write('</head><body><table><tr><td><h1>ESIC No</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer + '</h1></td></tr>');"
    //     //    + "WindowObject.document.write('<tr><td><h1>Queue No</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer1 + '</h1></td></tr>');"
    //     //    + "WindowObject.document.write('<tr><td><h1>Date</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer2 + '</h1></td></tr>');"
    //     //    + "WindowObject.document.write('<tr><td><h1>Time</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer3 + '</h1></td></tr>');"
    //     //    + "WindowObject.document.write('<tr><td><h1>Waiting Queue Status</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer4 + '</h1></td></tr>');"
    //     //    + "WindowObject.document.write('<tr><td><h1>Average Waiting Time</h1></td><td><h1>:</h1></td><td><h1>' + DocumentContainer5 + '</h1></td></tr></table>');"
    //     //    + "WindowObject.document.write('</body></html>');"
    //     //    + "WindowObject.document.close();"
    //     //    + "WindowObject.focus();"
    //     //    + "WindowObject.print();"
    //     //    + "WindowObject.close();"
    //     //    + "</script>");

         //string url = Convert.ToString(pageTable[page].Dequeue());
    //    //string fname = Server.UrlDecode(Request.QueryString["1"]);
    //    //string lname = Server.UrlDecode(Request.QueryString["2"]);
    //    //string uname = Request.QueryString["3"];
    //    //string terdesc = Request.QueryString["4"];
    //    //string uid = Server.UrlDecode(Request.QueryString["5"]);
    //    //string tid = Server.UrlDecode(Request.QueryString["6"]);
    //    //string did = Server.UrlDecode(Request.QueryString["7"]);
    //    //string dd = Server.UrlDecode(Request.QueryString["8"]);
    //    //string url = string.Format("kisokprin1t.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
    //    //                Server.UrlEncode(fname),
    //    //                Server.UrlEncode(lname),
    //    //                Server.UrlEncode(uname),
    //    //                Server.UrlEncode(terdesc),
    //    //                Server.UrlEncode(uid),
    //    //                Server.UrlEncode(tid),
    //    //                Server.UrlEncode(did),
    //    //                Server.UrlEncode(dd));
        //HttpContext.Current.Response.Redirect(url, false);
        // Response.Redirect(url, false);
    //}

        
}