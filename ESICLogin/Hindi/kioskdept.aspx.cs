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

public partial class kioskdept : System.Web.UI.Page
{
    KioskBEL kisokview;
    kioskBAL kioskcntrl;
    public StringBuilder strb = new StringBuilder();
    public ArrayList arrloaddepot = new ArrayList();
    public ArrayList arrloadpatient = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public ArrayList arraylist1 = new ArrayList();
    public ArrayList arraylist2 = new ArrayList();

    string AverageWaitingQueue, AverageWaitingTime;
    string DepartmentDescription;

    int ApproximateWaitingTime = Convert.ToInt16(ConfigurationManager.AppSettings["ApproximateWaitingTime"].ToString());


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Timer1_Tick(sender, e);
           // Label4.Text = DateTime.Now.ToLongDateString();
           // lbl_clientip.Text = GetIP();
           // lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
            string fname = Server.UrlDecode(Request.QueryString["1"]);
            string lname = Server.UrlDecode(Request.QueryString["2"]);
            string uname = Request.QueryString["3"];
            string terdesc = Request.QueryString["4"];
            string uid = Server.UrlDecode(Request.QueryString["5"]);
            string tid = Server.UrlDecode(Request.QueryString["6"]);
            string did = Server.UrlDecode(Request.QueryString["7"]);
            string dd = Server.UrlDecode(Request.QueryString["8"]);
            txt_esicno.Text = Server.UrlDecode(Request.QueryString["9"]);
            txt_customername.Text = Server.UrlDecode(Request.QueryString["10"]); 
           // lbl_userna.Text = uname;
            Session["User"] = uname;
            Session["esicno"] = "0";
           // Label2.Text = terdesc;
           // Label5.Text = dd;
            RetriveMemberInfo();
            //PageStart();
            LoadDepart();
            //btn_print.Enabled = false;
            //btn_reprint.Enabled = false;
        }
    }
    private string GetIP()
    {
        string strHostName = "";
        strHostName = System.Net.Dns.GetHostName();

        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

        IPAddress[] addr = ipEntry.AddressList;

        return addr[addr.Length - 3].ToString();

    }
    private void RetriveMemberInfo()
    {
        DataTable dtbl = new DataTable();
        try
        {
            
            kioskcntrl = new kioskBAL();
            dtbl = kioskcntrl.GetMemberDetail(txt_esicno.Text);
            if (dtbl.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbl.Rows)
                {
                    string fname = myTI.ToTitleCase(dr["members_firstname"].ToString());
                    string lname = myTI.ToTitleCase(dr["members_lastname"].ToString());
                    string fullname = fname + " " + lname;
                    long memberid = Int64.Parse(dr["members_id"].ToString());
                    arrloadpatient.Add(new KioskAddValue(fullname, memberid));

                }
                rbl_memberlist.DataSource = arrloadpatient;
                rbl_memberlist.DataTextField = "Display";
                rbl_memberlist.DataValueField = "Value";
                rbl_memberlist.DataBind();
            }
            else
            {
                arrloadpatient.Add(new KioskAddValue("No Record", 0));
                rbl_memberlist.DataSource = arrloaddepot;
                rbl_memberlist.DataTextField = "Display";
                rbl_memberlist.DataValueField = "Value";
                rbl_memberlist.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in Retrive Patient Information", ex);
        }
        finally
        {
            dtbl = null;
            kioskcntrl = null;
        }
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
                    arrloaddepot.Add(new KioskAddValue(depotname, depotid));

                }
                lb_deptlist.DataSource = arrloaddepot;
                lb_deptlist.DataTextField = "Display";
                lb_deptlist.DataValueField = "Value";
                lb_deptlist.DataBind();
            }
            else
            {
                arrloaddepot.Add(new KioskAddValue("No Record", 0));
                lb_deptlist.DataSource = arrloaddepot;
                lb_deptlist.DataTextField = "Display";
                lb_deptlist.DataValueField = "Value";
                lb_deptlist.DataBind();
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
    protected void btn_l1tol2_Click(object sender, EventArgs e)
    {
        try
        {
            int val12 = lb_deptlist.SelectedIndex;
            lbltxt.Visible = false;
            if (lb_deptlist.SelectedIndex >= 0)
            {
                for (int i = 0; i < lb_deptlist.Items.Count; i++)
                {
                    if (lb_deptlist.Items[i].Selected == true)
                    {
                        if (!arraylist1.Contains(lb_deptlist.Items[i]))
                        {
                            arraylist1.Add(lb_deptlist.Items[i]);

                        }
                    }
                }
                for (int i = 0; i < arraylist1.Count; i++)
                {
                    if (!lb_seldeptlist.Items.Contains(((ListItem)arraylist1[i])))
                    {
                        lb_seldeptlist.Items.Add(((ListItem)arraylist1[i]));
                    }
                    lb_deptlist.Items.Remove(((ListItem)arraylist1[i]));
                }
                lb_seldeptlist.SelectedIndex = -1;
            }
            else
            {
                lbltxt.Visible = true;
                lbltxt.Text = "Please select atleast one in Listbox1 to move";
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in movel1", ex);
        }
    }
    protected void btn_l2tol1_Click(object sender, EventArgs e)
    {
        try
        {
            lbltxt.Visible = false;
            if (lb_seldeptlist.SelectedIndex >= 0)
            {
                for (int i = 0; i < lb_seldeptlist.Items.Count; i++)
                {
                    if (lb_seldeptlist.Items[i].Selected)
                    {
                        if (!arraylist2.Contains(lb_seldeptlist.Items[i]))
                        {
                            arraylist2.Add(lb_seldeptlist.Items[i]);
                        }
                    }
                }
                for (int i = 0; i < arraylist2.Count; i++)
                {
                    if (!lb_deptlist.Items.Contains(((ListItem)arraylist2[i])))
                    {
                        lb_deptlist.Items.Add(((ListItem)arraylist2[i]));
                    }
                    lb_seldeptlist.Items.Remove(((ListItem)arraylist2[i]));
                }
                lb_deptlist.SelectedIndex = -1;
            }
            else
            {
                lbltxt.Visible = true;
                lbltxt.Text = "Please select atleast one in Listbox2 to move";
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in movel2", ex);
        }
    }
    protected void btn_up_Click(object sender, EventArgs e)
    {
        try
        {
            int selectedIndex = lb_seldeptlist.SelectedIndex;
            lbltxt.Visible = false;
            if (selectedIndex >= 0)
            {
                ListItem li = lb_seldeptlist.Items[selectedIndex - 1];
                lb_seldeptlist.Items.RemoveAt(selectedIndex - 1);
                lb_seldeptlist.Items.Insert(selectedIndex, li);
            }
            else
            {
                lbltxt.Visible = true;
                lbltxt.Text = "Please select atleast one in Listbox2 to Up";
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in up", ex);
        }
    }
    protected void btn_down_Click(object sender, EventArgs e)
    {
        try
        {
            int selectedIndex = lb_seldeptlist.SelectedIndex;
            lbltxt.Visible = false;
            if (selectedIndex >= 0)
            {
                ListItem li = lb_seldeptlist.Items[selectedIndex + 1];
                lb_seldeptlist.Items.RemoveAt(selectedIndex + 1);
                lb_seldeptlist.Items.Insert(selectedIndex, li);

            }
            else
            {
                lbltxt.Visible = true;
                lbltxt.Text = "Please select atleast one in Listbox2 to Down";
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in down", ex);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bool firstval;
        DataTable dtbl = new DataTable();
        DataTable CheckingQueueToken = new DataTable();

        string updatesuccess = string.Empty;
        string insertsuccess = string.Empty;
        string PatientName = string.Empty;

        //newprint.PrintQueuno("DE1-0321");
        //newprint.ReceiptPrint(senderrec, rec);

        try
        {

            kisokview = new KioskBEL();
            kioskcntrl = new kioskBAL();

            if (lb_seldeptlist.Items.Count == 0 && rbl_memberlist.SelectedValue != string.Empty)
            {
                lbltxt.Visible = true;
                lbltxt.Text = "Please Select The Department";
            }

            else if (rbl_memberlist.SelectedValue == string.Empty && lb_seldeptlist.Items.Count > 0)
            {
                lbltxt.Visible = true;
                lbltxt.Text = "Please Select The Patient Name";
            }

            else if (lb_seldeptlist.Items.Count > 0 && rbl_memberlist.SelectedValue != string.Empty)
            {
                firstval = true;

                kisokview.ESCInNumber = txt_esicno.Text;
                kisokview.CustomerFullName = txt_customername.Text;
                kisokview.PatientId = Convert.ToInt32(rbl_memberlist.SelectedValue);

                PatientName = rbl_memberlist.SelectedItem.Text;

                CheckingQueueToken = kioskcntrl.CheckKioskQueueTokenAlreadyGenerated(kisokview);

                if (CheckingQueueToken.Rows.Count == 0)
                {

                    foreach (ListItem list in lb_seldeptlist.Items)
                    {
                        if (firstval == true)
                        {
                            int selectedItem1 = Convert.ToInt32(list.Value.ToString());
                            dtbl = kioskcntrl.GetParticularDepartmentDetail(selectedItem1);
                            if (dtbl.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dtbl.Rows)
                                {
                                    int queueno1 = Convert.ToInt32(dr["department_queueno"].ToString());
                                    string queuecode1 = dr["department_code"].ToString();
                                    DepartmentDescription = dr["department_desc"].ToString();
                                    queueno1++;
                                    updatesuccess = kioskcntrl.UpdateDeptQueuNo(selectedItem1, queueno1);
                                    if (updatesuccess == "1")
                                    {
                                        lbl_msg.Visible = true;
                                        lbl_msg.Text = "Queue Number Not Updated";
                                    }

                                    // Counting Average Waiting Time 

                                    DataTable TotalWaitingQueue = kioskcntrl.GettingTotalWaitingQueue(selectedItem1);

                                    int count = TotalWaitingQueue.Rows.Count;

                                    if (TotalWaitingQueue.Rows.Count > 0)
                                    {
                                        AverageWaitingQueue = Convert.ToString(count) + " Patients Before You";

                                        //AverageWaitingQueue = Convert.ToString(count) + " Persons Have To Go Before You";

                                        //AverageWaitingTime = "Your Average Waiting Time May Be Around " + Convert.ToString(count * 2) + " Minutes";

                                        AverageWaitingTime = Convert.ToString(count * ApproximateWaitingTime) + " Minutes Approximately";
                                    }
                                    else
                                    {
                                        AverageWaitingQueue = "0 Patients Before You";

                                        //AverageWaitingQueue = "You Are The First Patient";

                                        //AverageWaitingTime = "Kindly Consult The Doctor Immediately";

                                        AverageWaitingTime = "0 Minutes Approximately";
                                    }

                                    kisokview.QueueNummber = queuecode1 + "-" + Convert.ToString(queueno1);
                                    kisokview.ESCInNumber = txt_esicno.Text;

                                    Session["Kisok_Qnum"] = kisokview.QueueNummber;
                                    Session["Kisok_esic_num"] = txt_esicno.Text;

                                    Session["Kisok_Avgwaiting"] = AverageWaitingQueue;
                                    Session["Kisok_Avgw_Que"] = AverageWaitingTime;
                                    Session["Kiosk_date"] = Convert.ToString(DateTime.Now);
                                    Session["Kiosk_Department_name"] = DepartmentDescription;

                                    kisokview.CustomerFullName = txt_customername.Text;
                                    kisokview.PatientId = Convert.ToInt32(rbl_memberlist.SelectedValue);
                                    ////  Printer.Show(txt_esicno.Text, kisokview.QueueNummber);
                                    insertsuccess = kioskcntrl.AddCustomerVisitDetails(kisokview);
                                    if (insertsuccess == "1")
                                    {
                                        lbl_msg.Visible = true;
                                        lbl_msg.Text = "Visit Details Not Inserted";
                                    }
                                    insertsuccess = string.Empty;
                                    DataTable dtblvisit = kioskcntrl.GetLastCustomerVisitID();
                                    if (dtblvisit.Rows.Count > 0)
                                    {
                                        foreach (DataRow dr1 in dtblvisit.Rows)
                                        {
                                            kisokview.CusVisitId = Convert.ToInt64(dr1["visit_tnx_id"].ToString());
                                            kisokview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                                            kisokview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                                            kisokview.DepartmentId = selectedItem1;
                                            kisokview.OrderId = 1;
                                            kisokview.SmsStatusFlag = "N";
                                            insertsuccess = kioskcntrl.AddCustomerQueueTransactions(kisokview);
                                            if (insertsuccess == "1")
                                            {
                                                lbl_msg.Visible = true;
                                                lbl_msg.Text = " Transactions Not Inserted";
                                            }
                                            insertsuccess = string.Empty;
                                            DataTable dtblqueuetrans = kioskcntrl.GetLastQueueTransactionID();
                                            if (dtblqueuetrans.Rows.Count > 0)
                                            {
                                                foreach (DataRow dr2 in dtblqueuetrans.Rows)
                                                {
                                                    kisokview.QueueTransID = Convert.ToInt64(dr2["queue_tnx_id"].ToString());

                                                    insertsuccess = kioskcntrl.AddCustomerQueuePlanOrderone(kisokview);
                                                    if (insertsuccess == "1")
                                                    {
                                                        lbl_msg.Visible = true;
                                                        lbl_msg.Text = " Plan Not Inserted";
                                                    }
                                                    insertsuccess = string.Empty;
                                                }
                                            }
                                        }
                                    }
                                }
                                dtbl = null;
                            }
                            firstval = false;
                        }
                        else
                        {
                            kisokview.DepartmentId = Convert.ToInt32(list.Value.ToString());
                            kisokview.OrderId++;
                            insertsuccess = kioskcntrl.AddCustomerQueuePlanOrders(kisokview);
                            if (insertsuccess == "1")
                            {
                                lbl_msg.Visible = true;
                                lbl_msg.Text = "Other Plans Not Inserted";
                            }
                            insertsuccess = string.Empty;
                        }
                    }
                    // MessageBox.Show("Queue Ticket Generate");
                    //  Thread.Sleep(5000);
                    string fname = Server.UrlDecode(Request.QueryString["1"]);
                    string lname = Server.UrlDecode(Request.QueryString["2"]);
                    string uname = Request.QueryString["3"];
                    string terdesc = Request.QueryString["4"];
                    string uid = Server.UrlDecode(Request.QueryString["5"]);
                    string tid = Server.UrlDecode(Request.QueryString["6"]);
                    string did = Server.UrlDecode(Request.QueryString["7"]);
                    string dd = Server.UrlDecode(Request.QueryString["8"]);
                    string url = string.Format("~/kisokprint.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}&10={9}&11={10}&12={11}&13={12}",
                                    Server.UrlEncode(fname),
                                    Server.UrlEncode(lname),
                                    Server.UrlEncode(uname),
                                    Server.UrlEncode(terdesc),
                                    Server.UrlEncode(uid),
                                    Server.UrlEncode(tid),
                                    Server.UrlEncode(did),
                                    Server.UrlEncode(dd), Server.UrlEncode(txt_esicno.Text), Server.UrlEncode(kisokview.QueueNummber), Server.UrlEncode(AverageWaitingQueue), Server.UrlEncode(AverageWaitingTime), Server.UrlEncode(DepartmentDescription));
                    Response.Redirect(url, false);

                    this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "sen", "window.open('~/kisokprint.aspx',null,'height=500,width=500,var Mtop = (screen.height/2)-(1200/2);var Mleft = (screen.width/2)-(2000/2);status= no,resizable= no,scrollbars=no,toolbar=no,toolbar=no,location=yes,menubar=no');", true);


                }

                else
                {

                    //  MessageBox.Show("You Have Already Generated Queue Token For " + PatientName + " Patient");


                    string fname = Server.UrlDecode(Request.QueryString["1"]);
                    string lname = Server.UrlDecode(Request.QueryString["2"]);
                    string uname = Request.QueryString["3"];
                    string terdesc = Request.QueryString["4"];
                    string uid = Server.UrlDecode(Request.QueryString["5"]);
                    string tid = Server.UrlDecode(Request.QueryString["6"]);
                    string did = Server.UrlDecode(Request.QueryString["7"]);
                    string dd = Server.UrlDecode(Request.QueryString["8"]);
                    string url = string.Format("kioskhindiprintchecking.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}&10={9}&11={10}&12={11}",
                                    Server.UrlEncode(fname),
                                    Server.UrlEncode(lname),
                                    Server.UrlEncode(uname),
                                    Server.UrlEncode(terdesc),
                                    Server.UrlEncode(uid),
                                    Server.UrlEncode(tid),
                                    Server.UrlEncode(did),
                                    Server.UrlEncode(dd), Server.UrlEncode(txt_esicno.Text), Server.UrlEncode(kisokview.QueueNummber), Server.UrlEncode(PatientName), Server.UrlEncode(AverageWaitingTime));
                    Response.Redirect(url, false);

                }

            }


            else
            {
                lbltxt.Visible = true;
                lbltxt.Text = "Please Select Patient Name And Department";
            }
        }

        catch (Exception ex)
        {
            throw new Exception("Problem in Queuno Ticket", ex);
        }
        finally
        {

        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (Server.UrlDecode(Request.QueryString["1"]) != null)
        {
            string url = string.Format("../kiosklang.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                             Server.UrlEncode(Server.UrlDecode(Request.QueryString["1"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["2"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["3"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["4"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["5"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["6"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["7"]).ToString()),
                            Server.UrlEncode(Server.UrlDecode(Request.QueryString["8"]).ToString()));
            Response.Redirect(url, false);
        }
        else
        {
            string url = string.Format("../kiosklang.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                           Server.UrlEncode(Session["fname"].ToString()),
                          Server.UrlEncode(Session["lname"].ToString()),
                          Server.UrlEncode(Session["uname"].ToString()),
                          Server.UrlEncode(Session["terdesc"].ToString()),
                          Server.UrlEncode(Session["uid"].ToString()),
                          Server.UrlEncode(Session["tid"].ToString()),
                          Server.UrlEncode(Session["did"].ToString()),
                          Server.UrlEncode(Session["dd"].ToString()));
            Response.Redirect(url, false);
        }
    }
}
public class KioskAddValue
{
    private string m_Display;
    private long m_Value;
    public KioskAddValue(string Display, long Value)
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