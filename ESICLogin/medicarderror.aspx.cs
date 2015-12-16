using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using System.Threading;
using System.Globalization;

public partial class medicarderror : System.Web.UI.Page
{

    protected void Timer1_Tick(object sender, EventArgs e)
    {
        string url = string.Format("kioskhome.aspx");
        Response.Redirect(url, false);

    }

}