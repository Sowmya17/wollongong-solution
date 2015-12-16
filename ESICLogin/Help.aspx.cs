using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;
using System.Data;

public partial class AddMember : System.Web.UI.Page
{
    private CRTBEL crtview;
    private CRTBAL crtcntrl;
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public string esicno, terminaluser;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            //esicno = Session["esicno"].ToString();


            //terminaluser = Session["User"].ToString();
            //this.RadDatePicker1.MinDate = Convert.ToDateTime("1940-01-01 00:00:00.000");
            //this.RadDatePicker1.MaxDate = DateTime.Today;

            
        }

       

        //lbl_msg.Visible = false;

    }
}