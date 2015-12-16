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
using System.Windows.Forms;

public partial class ReprintDisplay : System.Web.UI.Page
{   
    string AverageWaitingTime, AverageWaitingQueue;
    string esicno;
    

    int ApproximateWaitingTime = Convert.ToInt16(ConfigurationManager.AppSettings["ApproximateWaitingTime"].ToString());

    CRTBEL crtview;
    CRTBAL crtcntrl;
    public ArrayList arrloadpatient;
    protected void Page_Load(object sender, EventArgs e)
    {
        esicno = (string)(Session["UserAuthentication1"]);
        
        RetriveMemberInfo();
    }
    private void RetriveMemberInfo()
    {
        DataTable dtbl = new DataTable();
        try
        {
            
        
        crtview = new CRTBEL();
        crtcntrl = new CRTBAL();

            arrloadpatient= new ArrayList();
            crtview.ESCInNumber = esicno;
            dtbl = crtcntrl.ReprintCheckQueueTokenAlreadyGenerated(crtview);
            
            gv_departmentmaster.AutoGenerateColumns = false;


            gv_departmentmaster.DataSource = dtbl;
            gv_departmentmaster.DataBind();
            
           
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in Retrive Patient Information", ex);
        }
        finally
        {
            dtbl = null;
            
        }
    }
   
    protected void gv_departmentmaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow Row = gv_departmentmaster.SelectedRow;


        int selectedItem1 = Convert.ToInt32(Row.Cells[3].Text);
        DataTable TotalWaitingQueue = crtcntrl.GettingTotalWaitingQueue(selectedItem1);
        int count = TotalWaitingQueue.Rows.Count;

        if (TotalWaitingQueue.Rows.Count > 0)
        {
            AverageWaitingQueue = Convert.ToString(count) + " Patients Before You";
            AverageWaitingTime = Convert.ToString(count * ApproximateWaitingTime) + " Minutes Approximately";
        }
        else
        {
            AverageWaitingQueue = "0 Patients Before You";
            AverageWaitingTime = "0 Minutes Approximately";
        }
        Session["UserAuthentication0"] = Row.Cells[6].Text;
        Session["UserAuthentication1"] = Row.Cells[0].Text;

        Session["UserAuthentication2"] = AverageWaitingQueue;
        Session["UserAuthentication3"] = AverageWaitingTime;
        Session["UserAuthentication4"] = Convert.ToString(DateTime.Now);

        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(2/2);var Mtop = (screen.height/2)-(1200/2);window.open( 'Print.aspx', null, 'height=20000,width=20000,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        RegisteredDisposeScript.Equals(this, this);
        this.Dispose();


    }

    //protected void btn_close_Click(object sender, EventArgs e)
    //{
    //    //this.Dispose();
    //    //this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "window.close()", true);
    //    //  Response.Close();
    //    //Response.End();
    //    // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "close", "<Script>self.close();</Script>", true);

    //    //ClientScript.RegisterStartupScript(GetType(), "SetFocusScript", "<Script>self.close();</Script>");

    //    this.ClientScript.RegisterClientScriptBlock(this.GetType(), "Close", "windowclose()", true);
    //   // Response.Write("<script>self.close();</script>");

    //   // Response.End();

    //}
    protected void gv_departmentmaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[3].Visible = false;
        }
    }
}
public class ReprintAddValue
{
    private string m_Display;
    private long m_Value;
    public ReprintAddValue(string Display, long Value)
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