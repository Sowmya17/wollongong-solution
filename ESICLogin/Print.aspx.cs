using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class reynolds : System.Web.UI.Page
{
    string refname;
    protected void Page_Unload(object sender, EventArgs e)
    {
        Session["Userfname"] = refname;
        //Response.Redirect("crtesic.aspx");


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserAuthentication0"] = crtview.QueueNummber;Q_Number
        //Session["UserAuthentication1"] = txt_esicno.Text;ESIC_No
        //Date_Time
        //Session["UserAuthentication2"] = AverageWaitingQueue;Waitng
        //Session["UserAuthentication3"] = AverageWaitingTime;Avg

        //string username5 = (string)(Session["Userfname"]);
        //if (Session["Userfname"] != null)
        //{
        //    refname = username5;

        //} 


        string username0 = (string)(Session["UserAuthentication0"]);
        if (Session["UserAuthentication0"] != null)
        {
            Q_Number.Text = username0;

        }

        string username1 = (string)(Session["UserAuthentication1"]);
        if (Session["UserAuthentication1"] != null)
        {
            Date_Time.Text = username1;
        }

        string username2 = (string)(Session["UserAuthentication2"]);
        if (Session["UserAuthentication2"] != null)
        {
            Dept_Name.Text = username2;
        }

      //  string url = string.Format("kioskesicno.aspx");
       // Response.Redirect(url, true);
        //string username1 = (string)(Session["UserAuthentication1"]);
        //if (Session["UserAuthentication1"] != null)
        //{
        //    ESIC_No.Text = username1;
        //}
        //string username2 = (string)(Session["UserAuthentication2"]);
        //if (Session["UserAuthentication2"] != null)
        //{
        //    Waitng.Text = username2;

        //}
        //string username3 = (string)(Session["UserAuthentication3"]);
        //if (Session["UserAuthentication3"] != null)
        //{
        //    Avg.Text = username3;
        //}

        //string username4 = (string)(Session["UserAuthentication4"]);
        //if (Session["UserAuthentication4"] != null)
        //{
        //    Date_Time.Text = username4;
        //}

        //string username6 = (string)(Session["UserAuthentication5"]);
        //if (Session["UserAuthentication5"] != null)
        //{
        //    Dept_Name.Text = username6;
        //}


        //Label3.Text = Q_Number.Text;

        /*Asterisk place before esic number for bar code_author for this module Meyyappan sen_11 june 2013*/
        //StringBuilder buffer = new StringBuilder();
        //string String1 = "*{0}*";
        //object[] objectArray = new object[1];
        //objectArray[0] = Q_Number.Text;
        //buffer.AppendFormat(String1, objectArray);
        //Label3.Text = buffer.ToString();
        //Label1.Text = Request.QueryString["val1"];
        //lbl_datetime1.Text = Convert.ToString(DateTime.Now);
        //HttpContext.Current.Response.Write("<script type='text/javascript'>" + window.close

        // ClientScript.RegisterStartupScript(GetType(), "Javascript", "<script type='text/javascript'>window.print();</script>", true); 


    }
}