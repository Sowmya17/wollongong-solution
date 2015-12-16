using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using Microsoft.Reporting.WebForms;
using System.IO;

using iTextSharp.text;
using iTextSharp.text.pdf;

using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Threading;

public partial class Admin_DailyReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label4.Text = DateTime.Now.ToLongDateString();
            lbl_clientip.Text = GetIP();
            lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
            lbl_userna.Text = Session["uname"].ToString();

            Label2.Text = Session["terdesc"].ToString();
            Label5.Text = Session["dd"].ToString();
        }
    }
    private string GetIP()
    {
        string strHostName = "";
        strHostName = System.Net.Dns.GetHostName();

        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

        IPAddress[] addr = ipEntry.AddressList;

        if (addr.Length == 6)
        {
            return addr[addr.Length - 3].ToString();
        }
        else
        {
            return addr[addr.Length - 2].ToString();
        }

    }
    protected void btn_report_Click(object sender, EventArgs e)
    {
        try
        {

            DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);
            //DateTime enddate = Convert.ToDateTime(RadDatePicker2.SelectedDate);
            string SDate = startdate.ToString("dd/MM/yyyy");
            //string ToDate = enddate.ToString("dd/MM/yyyy");
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            // CS.ReportServerCredential rptservercre = ServerAdaptor.GetReportServerCredential();
            ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://10.39.121.27:80/ReportServer");
            ReportViewer1.ServerReport.ReportPath = "/Daily Report/DailyReport";
            ReportParameter[] @parameters = new ReportParameter[1];
            @parameters[0] = new ReportParameter("SDate", SDate, true);
            //@parameters[1] = new ReportParameter("ToDate", ToDate, true);
            //ReportViewer1.ServerReport.ReportServerCredenti=als.NetworkCredentials = new NetworkCredential("administrator", ")ba@2786@", "tms.plaza.com");
            IReportServerCredentials irsc = new CustomReportCredentials("EQMS_QSOFTPC", "EQMS2015", "EQMS_QSOFTPC/QSOFT");
            ReportViewer1.ServerReport.ReportServerCredentials = irsc;
            ReportViewer1.ServerReport.SetParameters(@parameters);
            ReportViewer1.ServerReport.Refresh();
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }

    public class CustomReportCredentials : IReportServerCredentials
    {
        private string _UserName;
        private string _PassWord;
        private string _DomainName;

        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }

        public System.Security.Principal.WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        public ICredentials NetworkCredentials
        {
            get { return new NetworkCredential(_UserName, _PassWord, _DomainName); }
        }

        public bool GetFormsCredentials(out Cookie authCookie, out string user,
         out string password, out string authority)
        {
            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }
}



    //protected void btn_report_Click(object sender, EventArgs e)
    //{

    //    MasterBEL masterbel = new MasterBEL();
    //    MasterBAL masterbal = new MasterBAL();
    //    try
    //    {
    //        if (RadDatePicker1.SelectedDate != null && RadDatePicker1.SelectedDate.GetValueOrDefault() != DateTime.MinValue)
    //        {
    //            //Intializing Data Table
    //            DataTable MyDepartmentGridViewBind = new DataTable();

    //            //MyDeviceGridViewBind = null;

    //            //if(MyDeviceGridViewBind !=null)
    //            //{

    //            DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);
    //            string date = startdate.ToString("yyyy-MM-dd");
    //            masterbel.DeviceUpdatedDateTime = Convert.ToDateTime(date);

    //            MyDepartmentGridViewBind = masterbal.ReportDailyLoading(masterbel);

    //            //}

    //            //   gv_departmentmaster.AutoGenerateColumns = false;


    //            gv_servwaitreport.DataSource = MyDepartmentGridViewBind;
    //            gv_servwaitreport.DataBind();

    //            //MyDeviceGridViewBind = null;
    //        }

    //    }
    //    catch (ThreadAbortException)
    //    {
    //        throw;
    //    }
    //    finally
    //    {

    //    }
        //try
        //{

        // //string[] str = selecteddevice.ToArray();
        // //string str = cmb.SelectedItem
        // // CS.Device str = (cmb.SelectedValue as CS.Device);
        // DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);
        // //DateTime endate = Convert.ToDateTime(RadDatePicker2.SelectedDate);

        // string date = startdate.ToString("yyyy-MM-dd");
        // string mb = "8";
        // //string Edate = endate.ToString("MM/dd/yyyy");
        // ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
        // // CS.ReportServerCredential rptservercre = ServerAdaptor.GetReportServerCredential();
        // ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://192.168.43.144:80/reportserver");
        // ReportViewer1.ServerReport.ReportPath = "/Eqms/Report1";
        // ReportParameter[] @parameters = new ReportParameter[1];
        // @parameters[0] = new ReportParameter("date", date, true);
        //// @parameters[1] = new ReportParameter("Edate", Edate, true);
        // //ReportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = new NetworkCredential("administrator", ")ba@2786@", "tms.plaza.com");
        // IReportServerCredentials irsc = new CustomReportCredentials("EQMS1-PC", "ptr6040", "tms.plaza.com");
        // ReportViewer1.ServerReport.ReportServerCredentials = irsc;
        // ReportViewer1.ServerReport.SetParameters(@parameters);
        // ReportViewer1.ServerReport.Refresh();

        //}
        //catch (Exception ex)
        //{
        // App.ShowError(this, ex);
        //}
    //}

    //#region Page Index Changing

    //protected void gv_servwaitreport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    try
    //    {
    //        MasterBEL masterbel = new MasterBEL();
    //        MasterBAL masterbal = new MasterBAL();

    //        //Intializing Data Table
    //        DataTable MyDepartmentGridViewBind = new DataTable();


    //        gv_servwaitreport.PageIndex = e.NewPageIndex;
    //        gv_servwaitreport.DataBind();

    //        DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);
    //        string date = startdate.ToString("yyyy-MM-dd");
    //        masterbel.DeviceUpdatedDateTime = Convert.ToDateTime(date);

    //        MyDepartmentGridViewBind = masterbal.ReportDailyLoading(masterbel);


    //        gv_servwaitreport.DataSource = MyDepartmentGridViewBind;
    //        gv_servwaitreport.DataBind();
    //    }
    //    catch (ThreadAbortException)
    //    {
    //        throw;
    //    }
    //}

    //#endregion Page Index Changing

    //#region Report Generated In Word

    ////protected void ExportToWord()
    ////{
    ////    MasterBAL masterbal = new MasterBAL();
    ////    MasterBEL masterbel = new MasterBEL();

    ////    try
    ////    {
    ////        DataTable MyDepartmentGridViewBind = new DataTable();

    ////        DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);
    ////        string date = startdate.ToString("yyyy-MM-dd");
    ////        masterbel.DeviceUpdatedDateTime = Convert.ToDateTime(date);

    ////        MyDepartmentGridViewBind = masterbal.ReportTotalGridViewLoading(masterbel);

    ////        Response.Clear();
    ////        Response.Buffer = true;
    ////        Response.AddHeader("content-disposition",
    ////            "attachment;filename=DataTable.doc");
    ////        Response.Charset = "";
    ////        Response.ContentType = "application/vnd.ms-word ";
    ////        StringWriter sw = new StringWriter();
    ////        HtmlTextWriter hw = new HtmlTextWriter(sw);
    ////       // GridView1.RenderControl(hw);
    ////        Response.Output.Write(sw.ToString());
    ////        Response.Flush();
    ////        Response.End();
    ////    }
    ////    catch (Exception ex)
    ////    {
    ////        throw (ex);
    ////    }
    ////}

    //#endregion Report Generated In Word
    //protected void btn_wordfile_Click(object sender, EventArgs e)
    //{
    //    if (RadDatePicker1.SelectedDate != null && RadDatePicker1.SelectedDate.GetValueOrDefault() != DateTime.MinValue)
    //    {
    //        ExportToWord();
    //    }
    //}

    //private void ExportToWord()
    //{
    //        MasterBAL masterbal = new MasterBAL();
    //        MasterBEL masterbel = new MasterBEL();

    //        try
    //        {
    //            DataTable MyDepartmentGridViewBind = new DataTable();

    //            DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);
    //            string date = startdate.ToString("yyyy-MM-dd");
    //            masterbel.DeviceUpdatedDateTime = Convert.ToDateTime(date);

    //            MyDepartmentGridViewBind = masterbal.ReportTotalGridViewLoading(masterbel);

    //            if (MyDepartmentGridViewBind.Rows.Count > 0)
    //            {
    //                DataGrid dgGrid = new DataGrid();
    //                dgGrid.DataSource = MyDepartmentGridViewBind;
    //                dgGrid.DataBind();


    //                Response.Clear();
    //                Response.Buffer = true;
    //                Response.ClearContent();
    //                //Response.ClearHeaders();
    //                Response.Charset = "";
    //                string FileName = "Queue" + DateTime.Now + ".doc";
    //                StringWriter strwritter = new StringWriter();
    //                HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
    //                Response.Cache.SetCacheability(HttpCacheability.NoCache);

    //                Response.ContentType = "application/msword";
    //                Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);


    //                dgGrid.GridLines = GridLines.Both;
    //                dgGrid.HeaderStyle.Font.Bold = true;
    //                dgGrid.RenderControl(htmltextwrtter);
    //                Response.Write(strwritter.ToString());
    //                Response.End();

    //             //   string filename = "WaitingServingQueue";
    //             //   //string filename = Convert.ToString(DateTime.Now);
    //             //   //StringWriter tw = new System.IO.StringWriter();
    //             //   //HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
    //             //   DataGrid dgGrid = new DataGrid();
    //             //   dgGrid.DataSource = MyDepartmentGridViewBind;
    //             //   dgGrid.DataBind();

    //             //   //Get the HTML for the control.
    //             ////   dgGrid.RenderControl(hw);
    //             //   //Write the HTML back to the browser.
    //             ////   Response.ContentType = "application/msword";
    //             ////   Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename + "");
    //             // //  this.EnableViewState = false;
    //             // //  Response.Write(tw.ToString());
    //             // //  Response.End();
    //             //  // Response.Redirect("~/Admin/ReportTotalMissedQueue.aspx", false);

    //             //   Response.ClearContent();
    //             //   Response.Buffer = true;
    //             //   dgGrid.AllowPaging = false;
    //             //   Response.AddHeader("Content-Disposition",
    //             //       "attachment;filename=" + filename + ".doc" +"");
    //             //   Response.Charset = "";
    //             //   Response.ContentType = "application/vnd.ms-word ";
    //             //   this.EnableViewState = false;
    //             //   StringWriter sw = new StringWriter();
    //             //   HtmlTextWriter hw = new HtmlTextWriter(sw);
    //             //   dgGrid.RenderControl(hw);
    //             //   Response.Output.Write(sw.ToString());
    //             //   Response.Flush();
    //             //   Response.End();
    //            }
    //        }
    //        catch (System.Threading.ThreadAbortException IException)
    //        {
    //            throw IException;

    //            //Debug.WriteLine(ex.Message);
    //            //Debug.WriteLine(ex.StackTrace);
    //            //Debug.WriteLine(ex.InnerException.ToString());
    //        }
    //}
    //protected void btn_pdf_Click(object sender, EventArgs e)
    //{
    //    MasterBAL masterbal = new MasterBAL();
    //    MasterBEL masterbel = new MasterBEL();

    //    try
    //    {
    //        DataTable MyDepartmentGridViewBind = new DataTable();

    //        DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);
    //        string date = startdate.ToString("yyyy-MM-dd");
    ////        masterbel.DeviceUpdatedDateTime = Convert.ToDateTime(date);

    //        MyDepartmentGridViewBind = masterbal.ReportDailyLoading(masterbel);

    //        if (MyDepartmentGridViewBind.Rows.Count > 0)
    //        {
                //GridView GridView1 = new GridView();
                //GridView1.AllowPaging = false;
                //GridView1.DataSource = MyDepartmentGridViewBind;
                //GridView1.DataBind();
                //string FileName = "Queue" + DateTime.Now + ".pdf";
                //Response.ContentType = "application/pdf";
                //Response.AddHeader("content-disposition",
                //    "attachment;filename="+FileName);
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //StringWriter sw = new StringWriter();
                //HtmlTextWriter hw = new HtmlTextWriter(sw);
                //GridView1.RenderControl(hw);
                //StringReader sr = new StringReader(sw.ToString());
                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                //pdfDoc.AddHeader("Waiting And Service Time Analysis", "Header");

                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                //pdfDoc.Open();
                //htmlparser.Parse(sr);
                //pdfDoc.Close();
                //Response.Write(pdfDoc);
                //Response.End();

                //Create a dummy GridView



        //        GridView GridView1 = new GridView();
        //        GridView1.AllowPaging = false;
        //        GridView1.DataSource = MyDepartmentGridViewBind;
        //        GridView1.DataBind();
        //        string FileName = "Queue" + DateTime.Now + ".xls";
        //        Response.Clear();
        //        Response.Buffer = true;
        //        Response.AddHeader("content-disposition",
        //         "attachment;filename=" + FileName);
        //        Response.Charset = "";
        //        Response.ContentType = "application/vnd.ms-excel";
        //        StringWriter sw = new StringWriter();
        //        HtmlTextWriter hw = new HtmlTextWriter(sw);

        //        for (int i = 0; i < GridView1.Rows.Count; i++)
        //        {
        //            //Apply text style to each Row
        //            GridView1.Rows[i].Attributes.Add("class", "textmode");
        //        }
        //        GridView1.RenderControl(hw);

        //        //style to format numbers to string
        //        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        //        Response.Write(style);
        //        Response.Output.Write(sw.ToString());
        //        Response.Flush();
        //        Response.End();



        //    }
        //}
        //catch (System.Threading.ThreadAbortException IException)
        //{
        //    throw IException;

            //Debug.WriteLine(ex.Message);
            //Debug.WriteLine(ex.StackTrace);
            //Debug.WriteLine(ex.InnerException.ToString());
//        }

//    }
//}

