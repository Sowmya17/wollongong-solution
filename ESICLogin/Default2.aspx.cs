using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Xml;
using System.IO;
using System.Data;
using System.Net;

public partial class Default2 : System.Web.UI.Page
{
    KioskBEL kisokview;
    kioskBAL kioskcntrl;
    public StringBuilder strb = new StringBuilder();
    public ArrayList arrloaddepot = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDepart();
    }

    private void LoadDepart()
    {
        DataTable dtbl = new DataTable();
        try
        {
            kioskcntrl = new kioskBAL();
            dtbl = kioskcntrl.GetDepartmentDetail();
            if (dtbl.Rows.Count > 0)
            {

                foreach (DataRow dr in dtbl.Rows)
                {
                    string depotname = myTI.ToTitleCase(dr["department_desc"].ToString());
                    int depotid = Int32.Parse(dr["department_id"].ToString());
                    arrloaddepot.Add(new KioskAddValue1(depotname, depotid));

                }
                RadListBox1.DataSource = arrloaddepot;
                RadListBox1.DataTextField = "Display";
                RadListBox1.DataValueField = "Value";
                RadListBox1.DataBind();
            }
            else
            {
                arrloaddepot.Add(new KioskAddValue1("No Record", 0));
                RadListBox1.DataSource = arrloaddepot;
                RadListBox1.DataTextField = "Display";
                RadListBox1.DataValueField = "Value";
                RadListBox1.DataBind();
            }
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
}
public class KioskAddValue1
{
    private string m_Display;
    private long m_Value;
    public KioskAddValue1(string Display, long Value)
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