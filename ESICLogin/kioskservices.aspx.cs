using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;
using System.Globalization;

public partial class kioskservices : System.Web.UI.Page
{

    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;

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
    protected void Page_Load(object sender, EventArgs e)
    {
        DepartmentDescription();
        snam = Server.UrlDecode(Request.QueryString["1"]);
        dob = Server.UrlDecode(Request.QueryString["2"]);

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {

    }
    protected void btn_service1_Click(object sender, EventArgs e)
    {
        string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}",
                        Server.UrlEncode(snam),
                        Server.UrlEncode(dob),
                        Server.UrlEncode(btn_service1.Text.ToString()),
                        Server.UrlEncode("Walk In"),
                        Server.UrlEncode("3"));
        Response.Redirect(url, true);

    }


    

    protected void btn_service2_Click(object sender, EventArgs e)
    {
        string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}",
                        Server.UrlEncode(snam),
                        Server.UrlEncode(dob),
                        Server.UrlEncode(btn_service2.Text.ToString()),
                        Server.UrlEncode("Walk In"),
                        Server.UrlEncode("4"));
        Response.Redirect(url, true);
    }
    protected void btn_service3_Click(object sender, EventArgs e)
    {
        string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}",
                        Server.UrlEncode(snam),
                        Server.UrlEncode(dob),
                        Server.UrlEncode(btn_service3.Text.ToString()),
                        Server.UrlEncode("Walk In"),
                        Server.UrlEncode("5"));
        Response.Redirect(url, true);
    }
    protected void btn_service4_Click(object sender, EventArgs e)
    {
        string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}",
                        Server.UrlEncode(snam),
                        Server.UrlEncode(dob),
                        Server.UrlEncode(btn_service4.Text.ToString()),
                        Server.UrlEncode("Walk In"),
                        Server.UrlEncode("6"));
        Response.Redirect(url, true);
    }
    protected void btn_service6_Click(object sender, EventArgs e)
    {
        string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}",
                       Server.UrlEncode(snam),
                       Server.UrlEncode(dob),
                       Server.UrlEncode(btn_service6.Text.ToString()),
                       Server.UrlEncode("Walk In"),
                       Server.UrlEncode("8"));
        Response.Redirect(url, true);
    }
    protected void btn_service5_Click(object sender, EventArgs e)
    {
        string url = string.Format("kioskdept.aspx?1={0}&2={1}&3={2}&4={3}&5={4}",
                        Server.UrlEncode(snam),
                        Server.UrlEncode(dob),
                        Server.UrlEncode(btn_service5.Text.ToString()),
                        Server.UrlEncode("Walk In"),
                        Server.UrlEncode("7"));
        Response.Redirect(url, true);
    }

    #region Simple Kiosk - Getting Department Description

    public void DepartmentDescription()
    {
        DataTable dtbl = new DataTable();
        //ListItem list1 = new ListItem();

        try
        {
            kioskBAL kioskcntrl = new kioskBAL();
            dtbl = kioskcntrl.GetDepartmentDetail();

            if (dtbl.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbl.Rows)
                {
                    string deportname = myTI.ToTitleCase(dr["department_desc"].ToString());
                    int deportid = Int32.Parse(dr["department_id"].ToString());

                    if (deportid == 3)
                    {
                        btn_service1.Text = deportname;
                    }
                    if (deportid == 4)
                    {
                        btn_service2.Text = deportname;
                    }
                    if (deportid == 5)
                    {
                        btn_service3.Text = deportname;
                    }
                    if (deportid == 6)
                    {
                        btn_service4.Text = deportname;
                    }
                    if (deportid == 7)
                    {
                        btn_service5.Text = deportname;
                    }
                    if (deportid == 8)
                    {
                        btn_service6.Text = deportname;
                    }
                }
            }

            //if (dtbl.Rows.Count > 0)
            //{

            //    foreach (DataRow dr in dtbl.Rows)
            //    {
            //        string depotname = myTI.ToTitleCase(dr["department_desc"].ToString());
            //        int depotid = Int32.Parse(dr["department_id"].ToString());
            //        arrloaddepot.Add(new CRTAddValue(depotname, depotid));

            //    }

            //    lb_deptlist.DataSource = arrloaddepot;
            //    lb_deptlist.DataTextField = "Display";
            //    lb_deptlist.DataValueField = "Value";
            //    lb_deptlist.DataBind();
            //}
            //else
            //{
            //arrloaddepot.Add(new CRTAddValue("No Record", 0));
            ////arrloaddepot.Sort();
            //lb_deptlist.DataSource = arrloaddepot;
            //lb_deptlist.DataTextField = "Display";
            //lb_deptlist.DataValueField = "Value";
            //lb_deptlist.DataBind();
            //}
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
        }

    }

    #endregion Simple Kiosk - Getting Department Description
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string url = string.Format("kiosklang.aspx");
        Response.Redirect(url, false);
    }
    
}