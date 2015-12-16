using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Net;
using System.Data;
using System.Threading;
using System.IO;

public partial class Admin_Totalqueuereport : System.Web.UI.Page
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
            string ADate = startdate.ToString("dd/MM/yyyy");
            //string ToDate = enddate.ToString("dd/MM/yyyy");
            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
            // CS.ReportServerCredential rptservercre = ServerAdaptor.GetReportServerCredential();
            ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://10.39.121.27:80/ReportServer");
            ReportViewer1.ServerReport.ReportPath = "DocLogin/ReporDocAvgTime";
            ReportParameter[] @parameters = new ReportParameter[1];
            @parameters[0] = new ReportParameter("ADate", ADate, true);
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
//    protected void btn_report_Click(object sender, EventArgs e)
//    {
//        try
//        {
//            ////string[] str = selecteddevice.ToArray();
//            ////string str = cmb.SelectedItem
//            //// CS.Device str = (cmb.SelectedValue as CS.Device);
//            //DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);
//            //DateTime endate = Convert.ToDateTime(RadDatePicker2.SelectedDate);

//            //string Sdate = startdate.ToString("MM/dd/yyyy");
//            //string Edate = endate.ToString("MM/dd/yyyy");
//            //ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Remote;
//            //// CS.ReportServerCredential rptservercre = ServerAdaptor.GetReportServerCredential();
//            //ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://192.168.1.180:80/reportserver");
//            //ReportViewer1.ServerReport.ReportPath = "/QMSReport/TotalQueueReport";
//            //ReportParameter[] @parameters = new ReportParameter[2];
//            //@parameters[0] = new ReportParameter("Sdate", Sdate, true);
//            //@parameters[1] = new ReportParameter("Edate", Edate, true);
//            ////ReportViewer1.ServerReport.ReportServerCredentials.NetworkCredentials = new NetworkCredential("administrator", ")ba@2786@", "tms.plaza.com");
//            //IReportServerCredentials irsc = new CustomReportCredentials1("administrator", ")ba@2786@", "tms.plaza.com");
//            //ReportViewer1.ServerReport.ReportServerCredentials = irsc;
//            //ReportViewer1.ServerReport.SetParameters(@parameters);
//            ////ReportViewer1.BackColor.
//            //ReportViewer1.ServerReport.Refresh();


//            MasterBEL masterbel = new MasterBEL();
//            MasterBAL masterbal = new MasterBAL();
            
         
//                if (RadDatePicker1.SelectedDate != null && RadDatePicker1.SelectedDate.GetValueOrDefault() != DateTime.MinValue )
//                {
//                    //Intializing Data Table
//                    DataTable MyDepartmentGridViewBind = new DataTable();
//                    DataTable DtblNurse = new DataTable();
//                    DataTable DtblDoctor = new DataTable();

                    
//                    DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);
                    
//                    string date = startdate.ToString("yyyy-MM-dd");
                    
//                    string status = "";
//                    masterbel.AvgDateTime = Convert.ToDateTime(date);
                    
//                    DtblNurse = masterbal.ReportAvgDept(masterbel);

//                    DtblNurse.Columns.Add("Doctor");
//                    DtblNurse.Columns.Add("Login");
//                    foreach (DataRow queuestatus in DtblNurse.Rows)
//                    {
//                        masterbel.AvgDeptId = Convert.ToInt16(queuestatus["department_id"].ToString());

//                        status = queuestatus["department_desc"].ToString();
//                        if (masterbel.AvgDeptId <= 20)
//                        {

                            
//                            DtblDoctor = masterbal.ReportAvg(masterbel);
                        
//                        }
                        
//                        if (DtblDoctor.Rows.Count > 0)
//                        {
//                            queuestatus["Doctor"] = status;
//                            queuestatus["Login"] = DtblDoctor.Rows[0][0].ToString();
//                        }
//                    }
//                    DtblNurse.Columns.Remove("department_id");
//                    DtblNurse.Columns.Remove("department_desc");
//                    gv_servwaitreport.DataSource = DtblNurse;
//                    gv_servwaitreport.DataBind();

//                    //MyDeviceGridViewBind = null;
//                }

            
           
        

//        }
//        catch (Exception ex)
//        {
//            // App.ShowError(this, ex);
//        }
//    }

//    #region Page Index Changing

//    protected void gv_servwaitreport_PageIndexChanging(object sender, GridViewPageEventArgs e)
//    {
//        try
//        {
//            MasterBEL masterbel = new MasterBEL();
//            MasterBAL masterbal = new MasterBAL();

//            //Intializing Data Table
//            // DataTable MyDepartmentGridViewBind = new DataTable();


//            gv_servwaitreport.PageIndex = e.NewPageIndex;
//            gv_servwaitreport.DataBind();



//            DataTable MyDepartmentGridViewBind = new DataTable();
//            DataTable DtblNurse = new DataTable();
//            DataTable DtblDoctor = new DataTable();


//            DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);

//            string date = startdate.ToString("yyyy-MM-dd");

//            string status = "";
//            masterbel.AvgDateTime = Convert.ToDateTime(date);

//            DtblNurse = masterbal.ReportAvgDept(masterbel);

//            DtblNurse.Columns.Add("Doctor");
//            DtblNurse.Columns.Add("Avg");
//            foreach (DataRow queuestatus in DtblNurse.Rows)
//            {
//                masterbel.AvgDeptId = Convert.ToInt16(queuestatus["department_id"].ToString());

//                status = queuestatus["department_desc"].ToString();
//                if (masterbel.AvgDeptId <= 20)
//                {


//                    DtblDoctor = masterbal.ReportAvg(masterbel);

//                }

//                if (DtblDoctor.Rows.Count > 0)
//                {
//                    queuestatus["Doctor"] = status;
//                    queuestatus["Avg"] = DtblDoctor.Rows[0][0].ToString();
//                }
//            }
//            DtblNurse.Columns.Remove("department_id");
//            DtblNurse.Columns.Remove("department_desc");
//            gv_servwaitreport.DataSource = DtblNurse;
//            gv_servwaitreport.DataBind();

//        }
//        catch (ThreadAbortException)
//        {
//            throw;
//        }
//    }

//    #endregion Page Index Changing


//    protected void btn_pdf_Click(object sender, EventArgs e)
//    {
//        MasterBAL masterbal = new MasterBAL();
//        MasterBEL masterbel = new MasterBEL();

//        try
//        {
//            DataTable MyDepartmentGridViewBind = new DataTable();
//            DataTable DtblNurse = new DataTable();
//            DataTable DtblDoctor = new DataTable();


//            DateTime startdate = Convert.ToDateTime(RadDatePicker1.SelectedDate);

//            string date = startdate.ToString("yyyy-MM-dd");

//            string status = "";
//            masterbel.AvgDateTime = Convert.ToDateTime(date);

//            DtblNurse = masterbal.ReportAvgDept(masterbel);

//            DtblNurse.Columns.Add("Doctor");
//            DtblNurse.Columns.Add("Login");
//            foreach (DataRow queuestatus in DtblNurse.Rows)
//            {
//                masterbel.AvgDeptId = Convert.ToInt16(queuestatus["department_id"].ToString());

//                status = queuestatus["department_desc"].ToString();
//                if (masterbel.AvgDeptId <= 20)
//                {


//                    DtblDoctor = masterbal.ReportAvg(masterbel);

//                }

//                if (DtblDoctor.Rows.Count > 0)
//                {
//                    queuestatus["Doctor"] = status;
//                    queuestatus["Login"] = DtblDoctor.Rows[0][0].ToString();
//                }
//            }
//            DtblNurse.Columns.Remove("department_id");
//            DtblNurse.Columns.Remove("department_desc");

//            if (DtblNurse.Rows.Count > 0)
//            {
//                //GridView GridView1 = new GridView();
//                //GridView1.AllowPaging = false;
//                //GridView1.DataSource = MyDepartmentGridViewBind;
//                //GridView1.DataBind();
//                //string FileName = "Queue" + DateTime.Now + ".pdf";
//                //Response.ContentType = "application/pdf";
//                //Response.AddHeader("content-disposition",
//                //    "attachment;filename="+FileName);
//                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
//                //StringWriter sw = new StringWriter();
//                //HtmlTextWriter hw = new HtmlTextWriter(sw);
//                //GridView1.RenderControl(hw);
//                //StringReader sr = new StringReader(sw.ToString());
//                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
//                //pdfDoc.AddHeader("Waiting And Service Time Analysis", "Header");

//                //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
//                //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
//                //pdfDoc.Open();
//                //htmlparser.Parse(sr);
//                //pdfDoc.Close();
//                //Response.Write(pdfDoc);
//                //Response.End();

//                //Create a dummy GridView
//                GridView GridView1 = new GridView();
//                GridView1.AllowPaging = false;
//                GridView1.DataSource = DtblNurse;
//                GridView1.DataBind();
//                string FileName = "Login" + date + ".xls";
//                Response.Clear();
//                Response.Buffer = true;
//                Response.AddHeader("content-disposition",
//                 "attachment;filename=" + FileName);
//                Response.Charset = "";
//                Response.ContentType = "application/vnd.ms-excel";
//                StringWriter sw = new StringWriter();
//                HtmlTextWriter hw = new HtmlTextWriter(sw);

//                for (int i = 0; i < GridView1.Rows.Count; i++)
//                {
//                    //Apply text style to each Row
//                    GridView1.Rows[i].Attributes.Add("class", "textmode");
//                }
//                GridView1.RenderControl(hw);

//                //style to format numbers to string
//                string style = @"<style> .textmode { mso-number-format:\@; } </style>";
//                Response.Write(style);
//                Response.Output.Write(sw.ToString());
//                Response.Flush();
//                Response.End();

//            }
//        }
//        catch (System.Threading.ThreadAbortException IException)
//        {
//            throw IException;

//            //Debug.WriteLine(ex.Message);
//            //Debug.WriteLine(ex.StackTrace);
//            //Debug.WriteLine(ex.InnerException.ToString());
//        }

//    }
//}
//public class CustomReportCredentials1 : IReportServerCredentials
//{
//    private string _UserName;
//    private string _PassWord;
//    private string _DomainName;

//    public CustomReportCredentials1(string UserName, string PassWord, string DomainName)
//    {
//        _UserName = UserName;
//        _PassWord = PassWord;
//        _DomainName = DomainName;
//    }

//    public System.Security.Principal.WindowsIdentity ImpersonationUser
//    {
//        get { return null; }
//    }

//    public ICredentials NetworkCredentials
//    {
//        get { return new NetworkCredential(_UserName, _PassWord, _DomainName); }
//    }

//    public bool GetFormsCredentials(out Cookie authCookie, out string user,
//     out string password, out string authority)
//    {
//        authCookie = null;
//        user = password = authority = null;
//        return false;
//    }
//}
