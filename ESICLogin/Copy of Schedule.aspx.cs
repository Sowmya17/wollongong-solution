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
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;



public partial class Schedule : System.Web.UI.Page
{

    //CRTBEL crtview;
    CRTBAL crtcntrl;
    public ArrayList arrloaddepot = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dtbl = new DataTable();
        ListItem list1 = new ListItem();
        try
        {
            crtcntrl = new CRTBAL();
            dtbl = crtcntrl.GetDepartmentDetailsSchedule();
            if (dtbl.Rows.Count > 0)
            {

                foreach (DataRow dr in dtbl.Rows)
                {
                    Label138.Text = myTI.ToTitleCase(dr["department_desc"].ToString());
                    Label139.Text = myTI.ToTitleCase(dr["department_desc"].ToString());
                    Label140.Text = myTI.ToTitleCase(dr["department_desc"].ToString());
                    Label143.Text = myTI.ToTitleCase(dr["department_desc"].ToString());
                    Label158.Text = myTI.ToTitleCase(dr["department_desc"].ToString());
                    //int depotid = Int32.Parse(dr["department_id"].ToString());
                    //arrloaddepot.Add(new CRTAddValue(depotname, depotid));

                }
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
    private void LoadDepart()
    {
        DataTable dtbl = new DataTable();
        ListItem list1 = new ListItem();
        try
        {
            crtcntrl = new CRTBAL();
            dtbl = crtcntrl.GetDepartmentDetail();
            if (dtbl.Rows.Count > 0)
            {

                foreach (DataRow dr in dtbl.Rows)
                {
                    string depotname = myTI.ToTitleCase(dr["department_desc"].ToString());
                    int depotid = Int32.Parse(dr["department_id"].ToString());
                    arrloaddepot.Add(new CRTAddValue(depotname, depotid));

                }

                //DropDownList1.DataSource = arrloaddepot;
                //DropDownList1.DataTextField = "Display";
                ////DropDownList1.DataValueField = "Value";
                //DropDownList1.DataBind();
            }
            else
            {
                //arrloaddepot.Add(new CRTAddValue("No Record", 0));
                ////arrloaddepot.Sort();
                //DropDownList1.DataSource = arrloaddepot;
                //DropDownList1.DataTextField = "Display";
                ////DropDownList1.DataValueField = "Value";
                //DropDownList1.DataBind();
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

    // CRT - CRT Add Value

    #region CRT - CRT Add Value

    public class CRTAddValue
    {
        private string m_Display;
        private long m_Value;
        public CRTAddValue(string Display, long Value)
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
}

