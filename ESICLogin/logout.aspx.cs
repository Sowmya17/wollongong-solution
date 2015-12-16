using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ClearContent();
        //Request.QueryString.Remove("fname");
        //Request.QueryString.Remove("lname");
        //Request.QueryString.Remove("uname");
        //Request.QueryString.Remove("terdesc");
        //Request.QueryString.Remove("uid");
        //Request.QueryString.Remove("tid");
        //Request.QueryString.Remove("did");
        Response.Redirect("Default.aspx");
    }
}