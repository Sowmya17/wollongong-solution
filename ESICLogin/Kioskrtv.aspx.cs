using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Configuration;
using System.Threading;
using Org.BouncyCastle.Math;

public partial class Kioskrtv : System.Web.UI.Page
{

    public StringBuilder strb = new StringBuilder();

    public string QueueTicket, DeptName;
    string AverageWaitingQueue, AverageWaitingTime;
    string DepartmentDescription;
    public int showqueueno = 1;

    KioskBEL kioskview = new KioskBEL();
    kioskBAL kioskcntrl = new kioskBAL();
    public ArrayList arrloadpatient = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public string fname;
    public string lname;
    public string uname;
    public string terdesc;
    public string uid;
    public string tid;
    public string did;
    public string dd;



    string dob
    {

        get { return ViewState["dob"] as string; }
        set { ViewState["dob"] = value; }

    }
    string snam
    {

        get { return ViewState["snam"] as string; }
        set { ViewState["snam"] = value; }

    }

    string queno
    {

        get { return ViewState["queno"] as string; }
        set { ViewState["queno"] = value; }

    }

    string dpt
    {

        get { return ViewState["dpt"] as string; }
        set { ViewState["dpt"] = value; }

    }

    string apptime
    {

        get { return ViewState["apptime"] as string; }
        set { ViewState["apptime"] = value; }

    }

    string esi
    {

        get { return ViewState["esi"] as string; }
        set { ViewState["esi"] = value; }

    }

    string chk
    {

        get { return ViewState["chk"] as string; }
        set { ViewState["chk"] = value; }

    }
    string pid
    {

        get { return ViewState["pid"] as string; }
        set { ViewState["pid"] = value; }

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load1();
        }
    }

    public void load1()
    {
        DataTable dt = new DataTable();
        kioskview.ESCInNumber = Server.UrlDecode(Request.QueryString["5"]);
        DataTable dtbl = new DataTable();
        try
        {

            dtbl = kioskcntrl.GetMemberDetail(kioskview.ESCInNumber);
            if (dtbl.Rows.Count > 0)
            {
                //arrloadpatient.Add(new KioskAddValue("Select", 0));
                foreach (DataRow dr in dtbl.Rows)
                {
                    string fname = myTI.ToTitleCase(dr["members_firstname"].ToString());
                    string lname = myTI.ToTitleCase(dr["members_lastname"].ToString());
                    string fullname = fname + " " + lname;
                    long memberid = Int64.Parse(dr["members_customer_id"].ToString());
                    arrloadpatient.Add(new KioskAddValue2(fullname, memberid));

                }
                RadioButtonList1.DataSource = arrloadpatient;
                RadioButtonList1.DataTextField = "Display";
                RadioButtonList1.DataValueField = "Value";
                RadioButtonList1.DataBind();
                ImageButton1.Visible = true;
                // Label3.Visible = true;
                // Label1.Visible = true;
                RadioButtonList1.Visible = true;
            }
            else
            {
                arrloadpatient.Add(new KioskAddValue2("No Record", 0));
                RadioButtonList1.DataSource = arrloadpatient;
                RadioButtonList1.DataTextField = "Display";
                RadioButtonList1.DataValueField = "Value";
                RadioButtonList1.DataBind();

                kioskview.CusLastName = "";
                //string url = string.Format("kioskfailure.aspx?1={0}&2={1}",
                //       Server.UrlEncode(kioskview.CusLastName),
                //       Server.UrlEncode(Convert.ToString(kioskview.Dob)));
                //Response.Redirect(url, false);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in Retrive Patient Information", ex);
        }
        finally
        {

        }
    }

    private void turnOffButtons()
    {
            ImageButton1.Enabled = false;
            ImageButton2.Enabled = false;   
    }
    private void RadioButtonList1_CheckedChanged(object sender, EventArgs e)
    {

            ImageButton1.Enabled = false;
            ImageButton2.Enabled = false;
    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            ImageButton1.Enabled = true;
            ImageButton2.Enabled = true;
            RadioSelect();
        
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            RadioSelect();
        }
    }
        private void  RadioSelect()
        {
        if (RadioButtonList1.SelectedIndex != null)
        {
            DataTable dt = new DataTable();
            DataTable dtbl = new DataTable();
            // string dt123 = RadioButtonList1.SelectedValue;
            //kioskview.MemberId = Int32.Parse(RadioButtonList1.SelectedValue);
            esi = RadioButtonList1.SelectedValue;
            kioskview.ESCInNumber = esi;
            dtbl = kioskcntrl.GetMemberDetailOne(esi);
            if (dtbl.Rows.Count != 0)
            {
                kioskview.MemberId = Int32.Parse(dtbl.Rows[0][0].ToString());
            }

            dt = kioskcntrl.GetAppointmentDetailsCard(kioskview);
            if (dt.Rows.Count != 0)
            {
                kioskview.CusLastName = dt.Rows[0][0].ToString();
                kioskview.Dob = Convert.ToDateTime(dt.Rows[0][1].ToString());
                string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}",
                    //string url = string.Format("kioskrtv.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}",
                    Server.UrlEncode(kioskview.CusLastName),
                    Server.UrlEncode(Convert.ToString(kioskview.Dob)),
                    Server.UrlEncode(dt.Rows[0][3].ToString()),
                    Server.UrlEncode(dt.Rows[0][2].ToString()),
                    Server.UrlEncode(kioskview.ESCInNumber),
                    Server.UrlEncode(kioskview.MemberId.ToString()));
                Response.Redirect(url, false);
            }
            else
            {
                Response.Redirect("kioskreg.aspx");
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('We could not find any appointment, please make your way to the Ambulatory Care Centre reception.'); window.location = '" + Page.ResolveUrl("kioskhome.aspx") + "';", true);
            }
        }
        else
        {
            MessageBox.Show("Please Select the patient");
        }
    }
   
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (RadioButtonList1.SelectedIndex != -1)
        {
            string url = string.Format("kioskhome.aspx");
            Response.Redirect(url, true);
        }
    }
}


#region Kiosk - Kiosk Add Value

public class KioskAddValue2
{
    private string m_Display;
    private long m_Value;
    public KioskAddValue2(string Display, long Value)
    {
        m_Display = Display;
        m_Value = Value;
    }
    public string Display
    {
        get { return m_Display; }
    }
    public long Value
    {
        get { return m_Value; }
    }

}

#endregion CRT - CRT Add Value