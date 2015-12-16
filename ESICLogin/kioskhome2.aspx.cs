using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class kioskhome2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        string url = string.Format("kiosklang1.aspx");
        Response.Redirect(url, false);
    }
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        string url = string.Format("kioskcard.aspx");
        Response.Redirect(url, false);
    }
}