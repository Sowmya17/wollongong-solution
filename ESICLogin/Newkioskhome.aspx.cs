using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceProcess;

public partial class Newkioskhome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string url = string.Format("DisplayMap.aspx");
        Response.Redirect(url, false);
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        string depart = "30";
        string queueno1 = "900";
        string url = string.Format("kiosksuccessnew.aspx?1={0}&2={1}",
            Server.UrlEncode(depart),
            Server.UrlEncode(Convert.ToInt32(queueno1).ToString()));
        Response.Redirect(url, false);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //string url = string.Format("kioskhome.aspx");
        //Response.Redirect(url, false);
        string depart = "8";
        string url = string.Format("kiosksuccessnew.aspx?1={0}",
            Server.UrlEncode(depart));
        Response.Redirect(url, false);
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string depart = "17";
        string queueno1 = "500";
        string url = string.Format("kiosksuccessnew.aspx?1={0}&2={1}",
            Server.UrlEncode(depart),
            Server.UrlEncode(Convert.ToInt32(queueno1).ToString()));
        Response.Redirect(url, false);
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        //string url = string.Format("kioskhome.aspx");
        //Response.Redirect(url, false);
        string depart = "11";
        string queueno1 = "100";
        string url = string.Format("kiosksuccessnew.aspx?1={0}&2={1}",
            Server.UrlEncode(depart),
            Server.UrlEncode(Convert.ToInt32(queueno1).ToString()));
        Response.Redirect(url, false);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string url = string.Format("DisplayMap2.aspx");                                 
        Response.Redirect(url, false);

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string depart = "2";
        string queueno1 = "300";
        string url = string.Format("kiosksuccessnew.aspx?1={0}&2={1}",
            Server.UrlEncode(depart),
            Server.UrlEncode(Convert.ToInt32(queueno1).ToString()));
        Response.Redirect(url, false);
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        string depart = "5";
        string queueno1 = "200";
        string url = string.Format("kiosksuccessnew.aspx?1={0}&2={1}",
            Server.UrlEncode(depart),
            Server.UrlEncode(Convert.ToInt32(queueno1).ToString()));
        Response.Redirect(url, false);
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string depart = "20";
        string queueno1 = "700";
        string url = string.Format("kiosksuccessnew.aspx?1={0}&2={1}",
            Server.UrlEncode(depart),
            Server.UrlEncode(Convert.ToInt32(queueno1).ToString()));
        Response.Redirect(url, false);
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        string depart = "16";
        string queueno1 = "400";
        string url = string.Format("kiosksuccessnew.aspx?1={0}&2={1}",
            Server.UrlEncode(depart),
            Server.UrlEncode(Convert.ToInt32(queueno1).ToString()));
        Response.Redirect(url, false);
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        string depart = "7";
        string queueno1 = "700";
        string url = string.Format("kiosksuccessnew.aspx?1={0}&2={1}",
            Server.UrlEncode(depart),
            Server.UrlEncode(Convert.ToInt32(queueno1).ToString()));
        Response.Redirect(url, false);
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        string depart = "10";
        string queueno1 = "800";
        string url = string.Format("kiosksuccessnew.aspx?1={0}&2={1}",
            Server.UrlEncode(depart),
            Server.UrlEncode(Convert.ToInt32(queueno1).ToString()));
        Response.Redirect(url, false);
    }
    protected void Button2_Click(object sender, ImageClickEventArgs e)
    {
        string url = string.Format("DisplayMap2.aspx");
        Response.Redirect(url, false);

    }
    protected void Button3_Click(object sender, ImageClickEventArgs e)
    {
        string url = string.Format("DisplayMap.aspx");
        Response.Redirect(url, false);
    }
}