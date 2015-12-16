using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DisplayMap2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["UserAuthentication0"] = Convert.ToString(DateTime.Now);
        //Session["UserAuthentication1"] = "Please proceed to the MAC Unit reception";


        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width)-(2/2);var Mtop = (screen.height)-(1200/2);window.open('MACPrint.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        
        String url = string.Format("Newkioskhome.aspx");
        Response.Redirect(url, false);
    }
}