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



public partial class crtesic : System.Web.UI.Page
{
    public string Qnum;
    
    CRTBEL crtview;
    CRTBAL crtcntrl;
    LoginBAL logincntrl;
    public StringBuilder strb = new StringBuilder();
    public ArrayList arrloaddepot = new ArrayList();
    public ArrayList arrloadpatient = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    public ArrayList arraylist1 = new ArrayList();
    public ArrayList arraylist2 = new ArrayList();
    public string fname;
    public string lname;
    public string uname;
    public string terdesc;
    public string custid;
    public string uid;
    public string tid;
    public string did;
    public string dd,QueueTicket,DeptName;
    public int slno = 1;
    public int showqueueno = 1;
    string CorrectIPAddress;
    string consultingstatus;
    string DeptFirstLetter, DeptSurNameFirstLetter;
    public string _currentuserId;

    string AverageWaitingTime, AverageWaitingQueue;

    DataTable MyQueueNumber = new DataTable();

    int ApproximateWaitingTime = Convert.ToInt16(ConfigurationManager.AppSettings["ApproximateWaitingTime"].ToString());


    [DllImport("Iphlpapi.dll")]
    private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
    [DllImport("Ws2_32.dll")]
    private static extern Int32 inet_addr(string ip);
    
    protected void Page_Load(object sender, EventArgs e)
    {
        _currentuserId = Server.UrlDecode(Request.QueryString["5"]);
        if (!IsPostBack)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);
           // Timer1_Tick(sender, e);
            Label4.Text = DateTime.Now.ToLongDateString();
            //client mac address
            lbl_clientip.Text = MACAddress();
            //server mac address
            lbl_instanceip.Text = GetMACAddress();
            fname = Server.UrlDecode(Request.QueryString["1"]);

            Session["Userfname"] = fname;

            if (fname == null)
            {

                fname = Session["fname"].ToString();

            }

            lname = Server.UrlDecode(Request.QueryString["2"]);
            if (lname == null)
            {
                lname = Session["lname"].ToString();
            }

            uname = Request.QueryString["3"];
            if (uname == null)
            {
                uname = Session["uname"].ToString();
            }

            terdesc = Request.QueryString["4"];
            if (terdesc == null)
            {
                terdesc = Session["terdesc"].ToString();
            }

            uid = Server.UrlDecode(Request.QueryString["5"]);
            if (uid == null || uid == string.Empty)
            {
                uid = Session["uid"].ToString();
            }

            tid = Server.UrlDecode(Request.QueryString["6"]);
            if (tid == null)
            {
                tid = Session["tid"].ToString();
            }

            did = Server.UrlDecode(Request.QueryString["7"]);
            if (did == null)
            {
                did = Session["did"].ToString();
            }
            dd = Server.UrlDecode(Request.QueryString["8"]);
            if (dd == null)
            {
                dd = Session["dd"].ToString();
            }
            lbl_userna.Text = uname;
            Session["User"] = uname;
            Session["esicno"] = "0";
            Label2.Text = terdesc;
            Label5.Text = dd;
            PageStart();
            LoadDepart();
            btn_print.Enabled = false;
            btn_reprint.Enabled = false;

            gv_queuedetails.Visible = false;
            lbl_getstatus.Visible = false;
           // DateTime min=new DateTime();
            this.RadDatePicker1.MinDate = Convert.ToDateTime("1840-01-01 00:00:00.000"); ;
            this.RadDatePicker1.MaxDate = DateTime.Today;
            txt_Qnumbercancel.Text = string.Empty;
            DropDownList1.SelectedIndex = 0;
        }
    }
    //protected void Timer1_Tick(object sender, EventArgs e)
    //{
    //    Label3.Text = DateTime.Now.ToLongTimeString();
    //}

    #region mac address using userhost address
    public string MACAddress()
    {

        try
        {
            string userip = Request.UserHostAddress;
            string strClientIP = Request.UserHostAddress.ToString().Trim();
            Int32 ldest = inet_addr(strClientIP);
            Int32 lhost = inet_addr("");
            Int64 macinfo = new Int64();
            Int32 len = 6;
            int res = SendARP(ldest, 0, ref macinfo, ref len);
            string mac_src = macinfo.ToString("X");
            //if (mac_src == "0")
            //{
            //    if (userip == "127.0.0.1")
            //        Response.Write("visited Localhost!");
            //    else
            //        Response.Write("the IP from" + userip + "" + "<br>");

            //}

            while (mac_src.Length < 12)
            {
                mac_src = mac_src.Insert(0, "0");
            }

            string mac_dest = "";

            for (int i = 0; i < 11; i++)
            {
                if (0 == (i % 2))
                {
                    if (i == 10)
                    {
                        mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                    }
                    else
                    {
                        mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                    }
                }
            }

            return mac_dest;
        }
        catch (Exception err)
        {
            return null;

        }
    }
    #endregion mac address using userhostaddress

    #region mac address using getip method

    public string GetMACAddress()
    {
        try
        {
            string userip = GetIP();
            string strClientIP = GetIP().Trim();
            Int32 ldest = inet_addr(strClientIP);
            Int32 lhost = inet_addr("");
            Int64 macinfo = new Int64();
            Int32 len = 6;
            int res = SendARP(ldest, 0, ref macinfo, ref len);
            string mac_src = macinfo.ToString("X");
            //if (mac_src == "0")
            //{
            //    if (userip == "127.0.0.1")
            //        Response.Write("visited Localhost!");
            //    else
            //        Response.Write("the IP from" + userip + "" + "<br>");

            //}

            while (mac_src.Length < 12)
            {
                mac_src = mac_src.Insert(0, "0");
            }

            string mac_dest = "";

            for (int i = 0; i < 11; i++)
            {
                if (0 == (i % 2))
                {
                    if (i == 10)
                    {
                        mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                    }
                    else
                    {
                        mac_dest = mac_dest.Insert(0, mac_src.Substring(i, 2));
                    }
                }
            }

            return mac_dest;
        }
        catch (Exception err)
        {
            return null;

        }
    }
    #endregion mac address using getip method

    private string GetIP()
    {
        string strHostName = "";
        strHostName = System.Net.Dns.GetHostName();

        IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

        IPAddress[] addr = ipEntry.AddressList;


        int AddressCount = addr.Count();

        for (int i = 0; i < AddressCount; i++)
        {
            string CheckingCorrectIPAddress = addr[i].ToString();
            string pattern = @"^[0-9.]*$";
            bool outputs = Regex.IsMatch(CheckingCorrectIPAddress, pattern);

            if (outputs == true)
            {
                CorrectIPAddress = CheckingCorrectIPAddress;
            }
        }

        return CorrectIPAddress;


        //if (addr.Length == 6)
        //{
        //    return addr[addr.Length - 3].ToString();
        //}
        //else
        //{
        //    return addr[addr.Length - 2].ToString();
        //}

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

                lb_deptlist.DataSource = arrloaddepot;
                lb_deptlist.DataTextField = "Display";
                lb_deptlist.DataValueField = "Value";
                lb_deptlist.DataBind();
            }
            else
            {
                arrloaddepot.Add(new CRTAddValue("No Record", 0));
                //arrloaddepot.Sort();
                lb_deptlist.DataSource = arrloaddepot;
                lb_deptlist.DataTextField = "Display";
                lb_deptlist.DataValueField = "Value";
                lb_deptlist.DataBind();
            }
        }
        catch(Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
        }
    }

    protected void l1tol2_Click(object sender, EventArgs e)
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
                AscendingOrder();
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
    private void AscendingOrder()
    {
        var list = lb_deptlist.Items.Cast<ListItem>().OrderBy(item => item.Text).ToList();
        lb_deptlist.Items.Clear();
        foreach (ListItem listItem in list)
        {
            lb_deptlist.Items.Add(listItem);
        }
    }
   

    protected void l2tol1_Click(object sender, EventArgs e)
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
                AscendingOrder();
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
    protected void Up_Click(object sender, EventArgs e)
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
            //throw new Exception("Problem in up", ex);
        }
    }
    protected void Down_Click(object sender, EventArgs e)
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
           // throw new Exception("Problem in down", ex);
        }
    }

    //protected void TextBox1_TextChanged(object sender, EventArgs e)
    //{
    //    crtview = new CRTBEL();
    //    crtcntrl = new CRTBAL();
    //    try
    //    {
    //        strb.Append(txt_esicno.Text);
    //        crtview.Esicnodetails = crtcntrl.GetRegCustomerDetail(strb.ToString());
    //        if (crtview.Esicnodetails.Rows.Count > 0)
    //        {
               
    //            AvailableESCIno();
    //            foreach (DataRow dr in crtview.Esicnodetails.Rows)
    //            {

    //                txt_cusfname.Text = dr["customer_firstname"].ToString();
    //                txt_cuslname.Text = dr["customer_lastname"].ToString();
    //                txt_cusadd.Text = dr["customer_address"].ToString();
    //                txt_cusage.Text = dr["customer_age"].ToString();
    //                txt_cusphone.Text = dr["customer_phone"].ToString();
    //                if (Convert.ToChar(dr["customer_gender"].ToString()) == 'M')
    //                {
    //                    ddl_cusgender.SelectedIndex = 2;
    //                }
    //                else
    //                {
    //                    ddl_cusgender.SelectedIndex = 1;
    //                }

    //            }
    //        }
    //        else
    //        {
    //            NotAvailableEsicno();
    //            txt_cusfname.Focus();
    //        }
           
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Problem in text change", ex);
    //    }
    //    finally
    //    {
    //        crtcntrl = null;
    //    }
    //}

    private void PageStart()
    {
        txt_cusfname.Enabled = false;
        txt_cuslname.Enabled = false;
        txt_cusphone.Enabled = false;
        txt_cusadd.Enabled = false;
        txt_cusage.Enabled = false;
        txt_cusemail.Enabled = false;
        ddl_cusgender.Enabled = false;
        lbltxt.Visible = false;
        lbl_msg.Visible = false;
        btn_cusreg.Enabled = false;
        RadDatePicker1.Enabled = false;
        
    }

    private void AvailableESCIno()
    {
        Hidden1.Value = "E";
        btn_cusreg.Enabled = true;
        btn_cusreg.Text = "Edit";
        txt_cusfname.Enabled = false;
        txt_cuslname.Enabled = false;
        txt_cusphone.Enabled = false;
        txt_cusadd.Enabled = false;
        txt_cusage.Enabled = false;
        txt_cusemail.Enabled = false;
        ddl_cusgender.Enabled = false;
        RadDatePicker1.Enabled = false;
    }

    private void NotAvailableEsicno()
    {
        Hidden1.Value = "S";
        btn_cusreg.Enabled = true;
        btn_cusreg.Text = "Save";
        txt_cusfname.Enabled = true;
        txt_cuslname.Enabled = true;
        txt_cusphone.Enabled = true;
        txt_cusadd.Enabled = true;
        txt_cusage.Enabled = true;
        txt_cusemail.Enabled = true;
        ddl_cusgender.Enabled = true;
        RadDatePicker1.Enabled = true;

        txt_cusfname.Text = string.Empty;
        txt_cuslname.Text = string.Empty;
        txt_cusphone.Text = string.Empty;
        txt_cusadd.Text = string.Empty;
        txt_cusage.Text = string.Empty;
        txt_cusemail.Text = string.Empty;
        ddl_cusgender.SelectedIndex = 0;

    }

    protected void btn_cusreg_Click(object sender, EventArgs e)
    {
        crtview = new CRTBEL();
        crtcntrl = new CRTBAL();
        string insertsucess = string.Empty;
        if (Hidden1.Value == "E")
        {
            btn_cusreg.Enabled = false;
            btn_cusreg.Text = "Save";
            Hidden1.Value = "ES";
            txt_cusfname.Enabled = true;
            txt_cuslname.Enabled = true;
            txt_cusphone.Enabled = true;
            txt_cusadd.Enabled = true;
            txt_cusage.Enabled = true;
            txt_cusemail.Enabled = true;
            ddl_cusgender.Enabled = true;
            btn_cusreg.Enabled = true;
            RadDatePicker1.Enabled = true;
        }
        else if (Hidden1.Value == "ES")
        {
            //if (txt_cusfname.Text != string.Empty && ddl_cusgender.SelectedValue != "S")
            if (txt_cusfname.Text != string.Empty)
            {
                btn_cusreg.Enabled = false;
              // string _custid = crtview.ESCInNumber;
               crtview.ESCInNumber = txt_esicno.Text;
                crtview.CusFirstname = txt_cusfname.Text;
                crtview.CusLastName = txt_cuslname.Text;
                crtview.CusAddress = txt_cusadd.Text;
                // For DM Health Care
                //crtview.CusPhoneNo = Convert.ToInt64(9874563210);
                //crtview.CusGender = Convert.ToChar("F");
                //crtview.CusAge = Convert.ToInt16(10);

                crtview.Dob =Convert.ToDateTime(RadDatePicker1.SelectedDate);
                DateTime today = DateTime.Today;
                // Original
               // crtview.CusPhoneNo = Int64.Parse(txt_cusphone.Text);
                crtview.CusPhoneNo = txt_cusphone.Text;
                crtview.Email = txt_cusemail.Text;
                crtview.CusGender = Char.Parse(ddl_cusgender.SelectedValue);
                //crtview.CusAge = Convert.ToInt16(txt_cusage.Text);
                crtview.CusAge = (today.Year - crtview.Dob.Year);
                crtview.RelationId = 6;
                crtview.TerminalUser = lbl_userna.Text;
                if (txt_esicno.Text == string.Empty)
                {
                    crtview.ESCInNumber = DropDownList1.SelectedValue.ToString();
                    insertsucess = crtcntrl.RegCustomerDetailUpdate(crtview);
                }
                else
                {
                    insertsucess = crtcntrl.RegCustomerDetailUpdate(crtview);  
                }
                if (insertsucess == "0")
                {
                    insertsucess = string.Empty;
                    insertsucess = crtcntrl.SelfCustomerDetailUpdate(crtview);
                    if (insertsucess == "0")
                    {

                        if (txt_esicno.Text == string.Empty)
                        {
                            string _custid = DropDownList1.SelectedValue.ToString();
                            RetriveMemberInfobysurname(_custid);
                        }
                        else
                        {
                            RetriveMemberInfo();
                        }
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "Patient Information Updated Successfully !!!";
                        DisableCusField();
                        //MessageBox.Show("Customer Information Updated Successfully !!!");
                    }
                    else
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "Patient Information Not Updated";
                    }


                }
                else
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "Patient Information Not Updated";
                    //MessageBox.Show("Customer Information Not Updated");
                }
                btn_cusreg.Enabled = true;

            }
            else
            {
                lbl_msg.Visible = true;
                lbl_msg.Text = "Please Enter the details";
                // MessageBox.Show("Please Enter the details");
            }
        }
        else if (Hidden1.Value == "S")
        {
            try
            {

                //if (txt_cusfname.Text != string.Empty && ddl_cusgender.SelectedValue !="S")
                if (txt_cusfname.Text != string.Empty)
                {
                    btn_cusreg.Enabled = false;

                    crtview.ESCInNumber = txt_esicno.Text;
                    crtview.CusFirstname = txt_cusfname.Text;
                    crtview.CusLastName = txt_cuslname.Text;
                    crtview.CusAddress = txt_cusadd.Text;
                     //Original
                    //crtview.CusPhoneNo = Convert.ToInt64(txt_cusphone.Text);
                    crtview.CusPhoneNo = txt_cusphone.Text;
                    crtview.Email = txt_cusemail.Text;
                    crtview.CusGender = Convert.ToChar(ddl_cusgender.SelectedValue);
                    //crtview.CusAge = Convert.ToInt16(txt_cusage.Text);

                    // DM Health Care
                    //crtview.CusPhoneNo = Convert.ToInt64(9874563210);
                    //crtview.CusGender = Convert.ToChar("F");
                    //crtview.CusAge = Convert.ToInt16(10);
                    DateTime today = DateTime.Today;
                    crtview.Dob = Convert.ToDateTime(RadDatePicker1.SelectedDate);
                    crtview.CusAge = Convert.ToInt16(today.Year- crtview.Dob.Year);
                    crtview.RelationId = 6;
                    crtview.TerminalUser = lbl_userna.Text;
                    insertsucess = crtcntrl.RegCustomerDetail(crtview);
                    if (insertsucess == "0")
                    {
                        RetriveMemberInfo();
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "Patient Information Added Successfully !!!";
                        //MessageBox.Show("Customer Information Added Successfully !!!");
                        DisableCusField();
                        btn_print.Enabled = true;
                        btn_reprint.Enabled = true;
                    }
                    else
                    {
                        lbl_msg.Visible = true;
                        lbl_msg.Text = "Patient Information Not Added";
                        //MessageBox.Show("Customer Information Not Added");
                    }
                    btn_cusreg.Enabled = true;

                }
                else
                {
                    lbl_msg.Visible = true;
                    lbl_msg.Text = "Please Enter the details";
                    //  MessageBox.Show("Please Enter the details");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Problem in storing data", ex);
            }
            finally
            {
                crtcntrl = null;
            }
        }
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        //MessageBox messageBox = new MessageBox();
        //messageBox.MessageTitle = "Information";
        //messageBox.MessageText = "Hello everyone, I am an Asp.net MessageBox. Please put your message here and click the following button to close me.";
        //Literal1.Text = messageBox.Show(this);
        ResetAllValues();
    }


   
    
        

    private void RetriveMemberInfobysurname(string _custid)
    {
        DataTable dtbl = new DataTable();
        try
        {
            crtcntrl = new CRTBAL();
            dtbl = crtcntrl.GetMemberDetail(_custid);
            if (dtbl.Rows.Count > 0)
            {
                arrloadpatient.Add(new CRTAddValue("Select", 0));
                foreach (DataRow dr in dtbl.Rows)
                {
                    string fname = myTI.ToTitleCase(dr["members_firstname"].ToString());
                    string lname = myTI.ToTitleCase(dr["members_lastname"].ToString());
                    string fullname = fname + " " + lname;
                    long memberid = Int64.Parse(dr["members_id"].ToString());
                    arrloadpatient.Add(new CRTAddValue(fullname, memberid));

                }
                ddl_patlist.DataSource = arrloadpatient;
                ddl_patlist.DataTextField = "Display";
                ddl_patlist.DataValueField = "Value";
                ddl_patlist.DataBind();
            }
            else
            {
                arrloadpatient.Add(new CRTAddValue("No Record", 0));
                ddl_patlist.DataSource = arrloaddepot;
                ddl_patlist.DataTextField = "Display";
                ddl_patlist.DataValueField = "Value";
                ddl_patlist.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in Retrive Patient Information", ex);
        }
        finally
        {
            dtbl = null;
            crtcntrl = null;
        }
    }

    private void RetriveMemberInfo()
    {
        DataTable dtbl = new DataTable();
        try
        {
            crtcntrl = new CRTBAL();
            dtbl = crtcntrl.GetMemberDetail(txt_esicno.Text);
            if (dtbl.Rows.Count > 0)
            {
                arrloadpatient.Add(new CRTAddValue("Select", 0));
                foreach (DataRow dr in dtbl.Rows)
                {
                    string fname = myTI.ToTitleCase(dr["members_firstname"].ToString());
                    string lname = myTI.ToTitleCase(dr["members_lastname"].ToString());
                    string fullname = fname + " " + lname;
                    long memberid = Int64.Parse(dr["members_id"].ToString());
                    arrloadpatient.Add(new CRTAddValue(fullname, memberid));

                }
                ddl_patlist.DataSource = arrloadpatient;
                ddl_patlist.DataTextField = "Display";
                ddl_patlist.DataValueField = "Value";
                ddl_patlist.DataBind();
            }
            else
            {
                arrloadpatient.Add(new CRTAddValue("No Record", 0));
                ddl_patlist.DataSource = arrloaddepot;
                ddl_patlist.DataTextField = "Display";
                ddl_patlist.DataValueField = "Value";
                ddl_patlist.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in Retrive Patient Information", ex);
        }
        finally
        {
            dtbl = null;
            crtcntrl = null;
        }
    }

    protected void btn_print_Click(object sender, EventArgs e)
    {
               
        bool firstval;

        DataTable dtbl = new DataTable();
        DataTable CheckingQueueToken = new DataTable();
        DataTable CheckingPreviousToken = new DataTable();
        DataTable checkcount = new DataTable();
        DataTable showqueueno1 = new DataTable();

        string updatesuccess = string.Empty;
        string insertsuccess = string.Empty;
        string PatientName = string.Empty;
        string queue = string.Empty;
        //newprint.PrintQueuno("DE1-0321");
        //newprint.ReceiptPrint(senderrec, rec);
        try
        {
            crtview = new CRTBEL();
            crtcntrl = new CRTBAL();
            if (txt_surname.Text == String.Empty && txt_esicno.Text != string.Empty)
            {


                if (lb_seldeptlist.Items.Count > 0 && ddl_patlist.SelectedValue != "0")
                {
                    firstval = true;

                    crtview.ESCInNumber = txt_esicno.Text;
                    crtview.CustomerFullName = txt_cusfname.Text + txt_cuslname.Text;
                    crtview.PatientId = Convert.ToInt32(ddl_patlist.SelectedValue);
                    PatientName = ddl_patlist.SelectedItem.Text;

                    // Checking Patients Have Already Taken Queue Token Or Not

                    CheckingQueueToken = crtcntrl.CheckQueueTokenAlreadyGenerated(crtview);
                    CheckingPreviousToken = crtcntrl.CheckPreviousToken(crtview);

                    // original
                     if (CheckingQueueToken.Rows.Count == 0)
                    //dm checking previous
                   // int chk = 0;
                  //  if (chk == 0)
                    {
                        foreach (ListItem list in lb_seldeptlist.Items)
                        {
                            if (firstval == true)
                            {
                                int selectedItem1 = Convert.ToInt32(list.Value.ToString());
                                dtbl = crtcntrl.GetParticularDepartmentDetail(selectedItem1);
                                if (dtbl.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtbl.Rows)
                                    {
                                        int queueno1 = Convert.ToInt32(dr["department_queueno"].ToString());
                                        string queuecode1 = dr["department_code"].ToString();
                                        string DepartmentDescription = dr["department_desc"].ToString();

                                        int dept_id = Convert.ToInt32(dr["department_id"].ToString());
                                        string DeptName = dr["department_desc"].ToString();

                                        //string[] words = DepartmentDescription.Split(' ');
                                        //string FirstLetter = words[0];
                                        //string SurNameFirstLetter = words[1];

                                        ////  DeptFirstLetter = DepartmentDescription.Substring(0, 1);

                                        // DeptFirstLetter = DeptName.Substring(0, 3);
                                        //DeptFirstLetter.ToUpper();
                                        // DeptSurNameFirstLetter = SurNameFirstLetter.Substring(0, 1);


                                        if (ddl_consultationstatus.SelectedIndex == 0)
                                        {
                                            consultingstatus = "W";
                                        }
                                        else if (ddl_consultationstatus.SelectedIndex == 1)
                                        {
                                            consultingstatus = "A";

                                        }
                                        else if (ddl_consultationstatus.SelectedIndex == 2)
                                        {
                                            consultingstatus = "V";
                                        }

                                        string quecod = null;
                                        queueno1++;
                                        showqueueno++;


                                        //switch (dept_id)
                                        //{
                                        //    case 1: quecod = "WH";
                                        //        break;
                                        //    case 2: quecod = "WG";
                                        //        break;
                                        //    case 7: quecod = "WE";
                                        //        break;
                                        //    case 8: quecod = "WN";
                                        //        break;
                                        //    case 9: quecod = "WN";
                                        //        break;
                                        //    case 10: quecod = "WO";
                                        //        break;
                                        //    case 11: quecod = "WO";
                                        //        break;
                                        //    case 12: quecod = "WU";
                                        //        break;
                                        //    case 13: quecod = "WP";
                                        //        break;
                                        //    case 14: quecod = "WR";
                                        //        break;
                                        //    case 15: quecod = "WD";
                                        //        break;



                                        //    default: break;
                                        //}

                                        crtview.DateTime = System.DateTime.Now.ToShortDateString();
                                        checkcount = crtcntrl.checkcount(crtview);

                                        // Getting Total Queue Count
                                        showqueueno1 = crtcntrl.checkcount();
                                        showqueueno = Convert.ToInt32(showqueueno1.Rows[0][0]);
                                        showqueueno += 1;
                                        // showqueueno = checkcount.Rows.Count;
                                        //showqueueno += 1;
                                        //string medanta = string.Concat(consultingstatus + DeptFirstLetter + DeptSurNameFirstLetter);
                                        //original
                                        //string medanta = "ASTER";
                                        //dm token name
                                        string medanta = txt_esicno.Text;
                                        //original

                                        // crtview.QueueNummberShow = Convert.ToString(showqueueno);
                                        // updatesuccess = crtcntrl.UpdateDeptQueuNo(selectedItem1, showqueueno);

                                        //wollongong digit
                                        queue = showqueueno.ToString().PadLeft(3, '0');
                                        crtview.QueueNummberShow = queue;
                                        updatesuccess = crtcntrl.UpdateDeptQueuNo(selectedItem1, showqueueno);

                                        // crtview.QueueNummberShow = queueno1.ToString();
                                        // updatesuccess = crtcntrl.UpdateDeptQueuNo(selectedItem1, queueno1);
                                        if (updatesuccess == "1")
                                        {
                                            lbl_msg.Visible = true;
                                            lbl_msg.Text = "Queue Number Not Updated";
                                        }


                                        // Counting Average Waiting Time 

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



                                        Qnum = txt_esicno.Text;


                                        //printer previous code not required altered by Ashok sen-29-jun-2013
                                        //HttpContext.Current.Response.Write("<script>alert('" +Qnum + "');</script>");
                                        //Printer.Show(txt_esicno.Text, crtview.QueueNummber, AverageWaitingQueue, AverageWaitingTime);
                                        //  Label3.Text = crtview.QueueNummber;
                                        //  HttpContext.Current.Response.Write("<script>alert('" + Label3.Text + "');</script>");
                                        crtview.QueueNummber = queuecode1 + "-" + Convert.ToString(queueno1);

                                        Session["UserAuthentication0"] = crtview.QueueNummberShow;
                                        Session["UserAuthentication1"] = DepartmentDescription;


                                        Session["UserAuthentication2"] = Convert.ToString(DateTime.Now);
                                        // Session["UserAuthentication3"] = AverageWaitingTime;
                                        //Session["UserAuthentication4"] = Convert.ToString(DateTime.Now);
                                        // Session["UserAuthentication5"] = DepartmentDescription;

                                        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width)-(2/2);var Mtop = (screen.height)-(1200/2);window.open('Print.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                                        //window.open('page.aspx?Code=' + code, 'open_window', ' width=640, height=480, left=0, top=0');

                                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "newWindow", "window.open('Print.aspx','_blank','status=1,toolbar=0,menubar=0,location=1,scrollbars=1,resizable=1,width=20000,height=20000');", true);

                                        //insertsuccess = crtcntrl.AddCustomerVisitDetails(crtview);


                                        //printer previous code not required altered by Ashok sen-29-jun-2013
                                        //HttpContext.Current.Response.Write("<script>alert('" +Qnum + "');</script>");
                                        //Printer.Show(txt_esicno.Text, crtview.QueueNummber, AverageWaitingQueue, AverageWaitingTime);
                                        //  Label3.Text = crtview.QueueNummber;
                                        //  HttpContext.Current.Response.Write("<script>alert('" + Label3.Text + "');</script>");

                                        crtview.ESCInNumber = txt_esicno.Text;
                                        crtview.CustomerFullName = txt_cusfname.Text + txt_cuslname.Text;
                                        crtview.PatientId = Convert.ToInt32(ddl_patlist.SelectedValue);
                                        crtview.ConsultingStatus = consultingstatus;

                                        //if (ddl_consultationstatus.SelectedIndex == 1)
                                        //{
                                        //    crtview.AppointmentID = Convert.ToInt32(lbl_appointmentid.Text);
                                        //    crtview.AppointmentTime = txt_consultingtime.Text;
                                        //    insertsuccess = crtcntrl.AddCustomerAppointmentVisitDetails(crtview);
                                        //}

                                        if (ddl_consultationstatus.SelectedIndex != 1)
                                        {
                                            insertsuccess = crtcntrl.AddCustomerVisitDetails(crtview);
                                        }
                                        else
                                        {
                                            crtview.AppointmentID = Convert.ToInt32(lbl_appointmentid.Text);
                                            crtview.AppointmentDateTime = DateTime.Parse(txt_consultingtime.Text);
                                            insertsuccess = crtcntrl.AddCustomerAppointmentVisitDetails(crtview);
                                        }

                                        if (insertsuccess == "1")
                                        {
                                            lbl_msg.Visible = true;
                                            lbl_msg.Text = "Visit Details Not Inserted";
                                        }
                                        insertsuccess = string.Empty;
                                        DataTable dtblvisit = crtcntrl.GetLastCustomerVisitID();
                                        // Thread.Sleep(1000);
                                        if (dtblvisit.Rows.Count > 0)
                                        {
                                            foreach (DataRow dr1 in dtblvisit.Rows)
                                            {
                                                crtview.CusVisitId = Convert.ToInt64(dr1["visit_tnx_id"].ToString());
                                                crtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                                                crtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                                                // Nurse Assesment Hard Coding
                                                //crtview.DepartmentId = 15;
                                                //crtview.OrderId = 1;
                                                //crtview.SmsStatusFlag = "N";
                                                //insertsuccess = crtcntrl.AddCustomerQueueTransactions(crtview);

                                                //Previous Coding

                                                crtview.DepartmentId = selectedItem1;
                                                crtview.OrderId = 1;
                                                crtview.SmsStatusFlag = "N";
                                                insertsuccess = crtcntrl.AddCustomerQueueTransactions(crtview);

                                                if (insertsuccess == "1")
                                                {
                                                    lbl_msg.Visible = true;
                                                    lbl_msg.Text = "Transactions Not Inserted";
                                                }
                                                insertsuccess = string.Empty;
                                                DataTable dtblqueuetrans = crtcntrl.GetLastQueueTransactionID();
                                                // Thread.Sleep(1000);
                                                if (dtblqueuetrans.Rows.Count > 0)
                                                {
                                                    foreach (DataRow dr2 in dtblqueuetrans.Rows)
                                                    {
                                                        crtview.QueueTransID = Convert.ToInt64(dr2["queue_tnx_id"].ToString());

                                                        insertsuccess = crtcntrl.AddCustomerQueuePlanOrderone(crtview);
                                                        if (insertsuccess == "1")
                                                        {
                                                            lbl_msg.Visible = true;
                                                            lbl_msg.Text = "Plan Not Inserted";
                                                        }
                                                        insertsuccess = string.Empty;
                                                    }

                                                    //// Adding Order ID For Medanta
                                                    //crtview.DepartmentId = selectedItem1;
                                                    //crtview.OrderId = 1;

                                                    //insertsuccess = crtcntrl.AddCustomerQueuePlanOrders(crtview);

                                                    //if (insertsuccess == "1")
                                                    //{
                                                    //    lbl_msg.Visible = true;
                                                    //    lbl_msg.Text = "Other Plans Not Inserted";
                                                    //}

                                                    //insertsuccess = string.Empty;

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
                                crtview.DepartmentId = Convert.ToInt32(list.Value.ToString());
                                crtview.OrderId++;
                                insertsuccess = crtcntrl.AddCustomerQueuePlanOrders(crtview);

                                if (insertsuccess == "1")
                                {
                                    lbl_msg.Visible = true;
                                    lbl_msg.Text = "Other Plans Not Inserted";
                                }

                                insertsuccess = string.Empty;
                            }
                        }
                        Session["UserAuthentication1"] = txt_esicno.Text;
                        ResetAllValues();

                    }
                    else
                    {
                        //  MessageBox.Show("You Have Already Generated Queue Token For " + PatientName + " Patient");

                        string Patient = "You Have Already Generated Queue Token For " + PatientName + " Patient";

                        string script = "alert('" + Patient + "');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);

                        ResetAllValues();
                    }

                }
                else
                {
                    if (ddl_patlist.SelectedValue == "0" && lb_seldeptlist.Items.Count != 0)
                    {
                        //MessageBox.Show("Please Select The Patient Name");
                        string msgValidate = "Please Select The Patient Name";
                        string script = "alert('" + msgValidate + "');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);

                    }
                    else if (ddl_patlist.SelectedValue != "0" && lb_seldeptlist.Items.Count == 0)
                    {
                        string msgValidate = "Please Select The Department";
                        string script = "alert('" + msgValidate + "');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);

                    }
                    else
                    {
                        string msgValidate = "Please Select The Patient Name & Department";
                        string script = "alert('" + msgValidate + "');";
                        //MessageBox.Show("Please Select the Patient & Department");
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);
                    }
                }
            }
            else if(txt_esicno.Text==string.Empty && txt_surname.Text!=string.Empty)
            {
                if (lb_seldeptlist.Items.Count > 0 && ddl_patlist.SelectedValue != "0")
                {
                    firstval = true;

                    //crtview.ESCInNumber = txt_esicno.Text;
                    crtview.ESCInNumber = DropDownList1.SelectedValue.ToString();
                    crtview.CustomerFullName = txt_cusfname.Text + txt_cuslname.Text;
                    crtview.PatientId = Convert.ToInt32(ddl_patlist.SelectedValue);
                    PatientName = ddl_patlist.SelectedItem.Text;

                    // Checking Patients Have Already Taken Queue Token Or Not

                    CheckingQueueToken = crtcntrl.CheckQueueTokenAlreadyGenerated(crtview);
                    CheckingPreviousToken = crtcntrl.CheckPreviousToken(crtview);

                    // original
                     if (CheckingQueueToken.Rows.Count == 0)
                    //dm checking previous
                   // int chk = 0;
                   // if (chk == 0)
                    {
                        foreach (ListItem list in lb_seldeptlist.Items)
                        {
                            if (firstval == true)
                            {
                                int selectedItem1 = Convert.ToInt32(list.Value.ToString());
                                dtbl = crtcntrl.GetParticularDepartmentDetail(selectedItem1);
                                if (dtbl.Rows.Count > 0)
                                {
                                    foreach (DataRow dr in dtbl.Rows)
                                    {
                                        int queueno1 = Convert.ToInt32(dr["department_queueno"].ToString());
                                        string queuecode1 = dr["department_code"].ToString();
                                        string DepartmentDescription = dr["department_desc"].ToString();

                                        int dept_id = Convert.ToInt32(dr["department_id"].ToString());
                                        string DeptName = dr["department_desc"].ToString();

                                        //string[] words = DepartmentDescription.Split(' ');
                                        //string FirstLetter = words[0];
                                        //string SurNameFirstLetter = words[1];

                                        ////  DeptFirstLetter = DepartmentDescription.Substring(0, 1);

                                        // DeptFirstLetter = DeptName.Substring(0, 3);
                                        //DeptFirstLetter.ToUpper();
                                        // DeptSurNameFirstLetter = SurNameFirstLetter.Substring(0, 1);


                                        if (ddl_consultationstatus.SelectedIndex == 0)
                                        {
                                            consultingstatus = "W";
                                        }
                                        else if (ddl_consultationstatus.SelectedIndex == 1)
                                        {
                                            consultingstatus = "A";

                                        }
                                        else if (ddl_consultationstatus.SelectedIndex == 2)
                                        {
                                            consultingstatus = "V";
                                        }

                                        string quecod = null;
                                        queueno1++;
                                        showqueueno++;


                                        //switch (dept_id)
                                        //{
                                        //    case 1: quecod = "WH";
                                        //        break;
                                        //    case 2: quecod = "WG";
                                        //        break;
                                        //    case 7: quecod = "WE";
                                        //        break;
                                        //    case 8: quecod = "WN";
                                        //        break;
                                        //    case 9: quecod = "WN";
                                        //        break;
                                        //    case 10: quecod = "WO";
                                        //        break;
                                        //    case 11: quecod = "WO";
                                        //        break;
                                        //    case 12: quecod = "WU";
                                        //        break;
                                        //    case 13: quecod = "WP";
                                        //        break;
                                        //    case 14: quecod = "WR";
                                        //        break;
                                        //    case 15: quecod = "WD";
                                        //        break;



                                        //    default: break;
                                        //}

                                        crtview.DateTime = System.DateTime.Now.ToShortDateString();
                                        checkcount = crtcntrl.checkcount(crtview);

                                        // Getting Total Queue Count
                                        showqueueno1 = crtcntrl.checkcount();
                                        showqueueno = Convert.ToInt32(showqueueno1.Rows[0][0]);
                                        showqueueno += 1;
                                        // showqueueno = checkcount.Rows.Count;
                                        //showqueueno += 1;
                                        //string medanta = string.Concat(consultingstatus + DeptFirstLetter + DeptSurNameFirstLetter);
                                        //original
                                        //string medanta = "ASTER";
                                        //dm token name
                                       // string medanta = txt_esicno.Text;
                                        string medanta = crtview.ESCInNumber;
                                        //original

                                        // crtview.QueueNummberShow = Convert.ToString(showqueueno);
                                        // updatesuccess = crtcntrl.UpdateDeptQueuNo(selectedItem1, showqueueno);

                                        //wollongong digit
                                        queue = showqueueno.ToString().PadLeft(3, '0');
                                        crtview.QueueNummberShow = queue;
                                        updatesuccess = crtcntrl.UpdateDeptQueuNo(selectedItem1, showqueueno);

                                        // crtview.QueueNummberShow = queueno1.ToString();
                                        // updatesuccess = crtcntrl.UpdateDeptQueuNo(selectedItem1, queueno1);
                                        if (updatesuccess == "1")
                                        {
                                            lbl_msg.Visible = true;
                                            lbl_msg.Text = "Queue Number Not Updated";
                                        }


                                        // Counting Average Waiting Time 

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



                                       // Qnum = txt_esicno.Text;
                                        Qnum = crtview.ESCInNumber;

                                        //printer previous code not required altered by Ashok sen-29-jun-2013
                                        //HttpContext.Current.Response.Write("<script>alert('" +Qnum + "');</script>");
                                        //Printer.Show(txt_esicno.Text, crtview.QueueNummber, AverageWaitingQueue, AverageWaitingTime);
                                        //  Label3.Text = crtview.QueueNummber;
                                        //  HttpContext.Current.Response.Write("<script>alert('" + Label3.Text + "');</script>");
                                        crtview.QueueNummber = queuecode1 + "-" + Convert.ToString(queueno1);

                                        Session["UserAuthentication0"] = crtview.QueueNummberShow;
                                        Session["UserAuthentication1"] = DepartmentDescription;


                                        Session["UserAuthentication2"] = Convert.ToString(DateTime.Now);
                                        // Session["UserAuthentication3"] = AverageWaitingTime;
                                        //Session["UserAuthentication4"] = Convert.ToString(DateTime.Now);
                                        // Session["UserAuthentication5"] = DepartmentDescription;

                                        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width)-(2/2);var Mtop = (screen.height)-(1200/2);window.open('Print.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
                                        //window.open('page.aspx?Code=' + code, 'open_window', ' width=640, height=480, left=0, top=0');

                                        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "newWindow", "window.open('Print.aspx','_blank','status=1,toolbar=0,menubar=0,location=1,scrollbars=1,resizable=1,width=20000,height=20000');", true);

                                        //insertsuccess = crtcntrl.AddCustomerVisitDetails(crtview);


                                        //printer previous code not required altered by Ashok sen-29-jun-2013
                                        //HttpContext.Current.Response.Write("<script>alert('" +Qnum + "');</script>");
                                        //Printer.Show(txt_esicno.Text, crtview.QueueNummber, AverageWaitingQueue, AverageWaitingTime);
                                        //  Label3.Text = crtview.QueueNummber;
                                        //  HttpContext.Current.Response.Write("<script>alert('" + Label3.Text + "');</script>");

                                       // crtview.ESCInNumber = txt_esicno.Text;
                                        crtview.CustomerFullName = txt_cusfname.Text + txt_cuslname.Text;
                                        crtview.PatientId = Convert.ToInt32(ddl_patlist.SelectedValue);
                                        crtview.ConsultingStatus = consultingstatus;

                                        //if (ddl_consultationstatus.SelectedIndex == 1)
                                        //{
                                        //    crtview.AppointmentID = Convert.ToInt32(lbl_appointmentid.Text);
                                        //    crtview.AppointmentTime = txt_consultingtime.Text;
                                        //    insertsuccess = crtcntrl.AddCustomerAppointmentVisitDetails(crtview);
                                        //}

                                        if (ddl_consultationstatus.SelectedIndex != 1)
                                        {
                                            insertsuccess = crtcntrl.AddCustomerVisitDetails(crtview);
                                        }
                                        else
                                        {
                                            crtview.AppointmentID = Convert.ToInt32(lbl_appointmentid.Text);
                                            crtview.AppointmentDateTime = DateTime.Parse(txt_consultingtime.Text);
                                            insertsuccess = crtcntrl.AddCustomerAppointmentVisitDetails(crtview);
                                        }

                                        if (insertsuccess == "1")
                                        {
                                            lbl_msg.Visible = true;
                                            lbl_msg.Text = "Visit Details Not Inserted";
                                        }
                                        insertsuccess = string.Empty;
                                        DataTable dtblvisit = crtcntrl.GetLastCustomerVisitID();
                                        // Thread.Sleep(1000);
                                        if (dtblvisit.Rows.Count > 0)
                                        {
                                            foreach (DataRow dr1 in dtblvisit.Rows)
                                            {
                                                crtview.CusVisitId = Convert.ToInt64(dr1["visit_tnx_id"].ToString());
                                                crtview.UserId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["5"]));
                                                crtview.TerminalId = Convert.ToInt32(Server.UrlDecode(Request.QueryString["6"]));
                                                // Nurse Assesment Hard Coding
                                                //crtview.DepartmentId = 15;
                                                //crtview.OrderId = 1;
                                                //crtview.SmsStatusFlag = "N";
                                                //insertsuccess = crtcntrl.AddCustomerQueueTransactions(crtview);

                                                //Previous Coding

                                                crtview.DepartmentId = selectedItem1;
                                                crtview.OrderId = 1;
                                                crtview.SmsStatusFlag = "N";
                                                insertsuccess = crtcntrl.AddCustomerQueueTransactions(crtview);

                                                if (insertsuccess == "1")
                                                {
                                                    lbl_msg.Visible = true;
                                                    lbl_msg.Text = "Transactions Not Inserted";
                                                }
                                                insertsuccess = string.Empty;
                                                DataTable dtblqueuetrans = crtcntrl.GetLastQueueTransactionID();
                                                // Thread.Sleep(1000);
                                                if (dtblqueuetrans.Rows.Count > 0)
                                                {
                                                    foreach (DataRow dr2 in dtblqueuetrans.Rows)
                                                    {
                                                        crtview.QueueTransID = Convert.ToInt64(dr2["queue_tnx_id"].ToString());

                                                        insertsuccess = crtcntrl.AddCustomerQueuePlanOrderone(crtview);
                                                        if (insertsuccess == "1")
                                                        {
                                                            lbl_msg.Visible = true;
                                                            lbl_msg.Text = "Plan Not Inserted";
                                                        }
                                                        insertsuccess = string.Empty;
                                                    }

                                                    //// Adding Order ID For Medanta
                                                    //crtview.DepartmentId = selectedItem1;
                                                    //crtview.OrderId = 1;

                                                    //insertsuccess = crtcntrl.AddCustomerQueuePlanOrders(crtview);

                                                    //if (insertsuccess == "1")
                                                    //{
                                                    //    lbl_msg.Visible = true;
                                                    //    lbl_msg.Text = "Other Plans Not Inserted";
                                                    //}

                                                    //insertsuccess = string.Empty;

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
                                crtview.DepartmentId = Convert.ToInt32(list.Value.ToString());
                                crtview.OrderId++;
                                insertsuccess = crtcntrl.AddCustomerQueuePlanOrders(crtview);

                                if (insertsuccess == "1")
                                {
                                    lbl_msg.Visible = true;
                                    lbl_msg.Text = "Other Plans Not Inserted";
                                }

                                insertsuccess = string.Empty;
                            }
                        }
                        Session["UserAuthentication1"] = txt_esicno.Text;
                        ResetAllValues();

                    }
                    else
                    {
                        //  MessageBox.Show("You Have Already Generated Queue Token For " + PatientName + " Patient");

                        string Patient = "You Have Already Generated Queue Token For " + PatientName + " Patient";

                        string script = "alert('" + Patient + "');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);

                        ResetAllValues();
                    }

                }
                else
                {
                    if (ddl_patlist.SelectedValue == "0" && lb_seldeptlist.Items.Count != 0)
                    {
                        //MessageBox.Show("Please Select The Patient Name");
                        string msgValidate = "Please Select The Patient Name";
                        string script = "alert('" + msgValidate + "');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);

                    }
                    else if (ddl_patlist.SelectedValue != "0" && lb_seldeptlist.Items.Count == 0)
                    {
                        string msgValidate = "Please Select The Department";
                        string script = "alert('" + msgValidate + "');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);

                    }
                    else
                    {
                        string msgValidate = "Please Select The Patient Name & Department";
                        string script = "alert('" + msgValidate + "');";
                        //MessageBox.Show("Please Select the Patient & Department");
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);
                    }
                }
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
        
    private void ResetAllValues()
    {
        PageStart();
        txt_surname.Text = string.Empty;
        DropDownList1.SelectedIndex = 0;
        txt_cusadd.Text = string.Empty;
        txt_cusfname.Text = string.Empty;
        txt_cuslname.Text = string.Empty;
        txt_cusphone.Text = string.Empty;
        txt_cusage.Text = string.Empty;
        txt_patage.Text = string.Empty;
        txt_esicno.Text = string.Empty;
        txt_cusemail.Text = string.Empty;
        txt_consultingtime.Text = string.Empty;
        ddl_cusgender.SelectedIndex = 0;
        ddl_patgender.SelectedIndex = 0;
        ddl_consultationstatus.SelectedIndex = 0;
        ddl_patlist.Items.Clear();
        RadDatePicker1.SelectedDate = null;
        lb_seldeptlist.Items.Clear();
        ListItem l = new ListItem("Select", "0", true); l.Selected = true;
        ddl_patlist.Items.Add(l);
        LoadDepart();
        btn_print.Enabled = false;
        btn_reprint.Enabled = false;
        ddl_consultationstatus.Enabled = true;
        lb_deptlist.Enabled = true;
        lb_seldeptlist.Enabled = true;
        btn_l1tol2.Enabled = true;
        btn_l2tol1.Enabled = true;
        btn_up.Enabled = true;
        btn_down.Enabled = true;
        lbl_appointmentid.Text = string.Empty;

        gv_queuedetails.DataSource = null;
        gv_queuedetails.DataBind();

        Session["esicno"] = "0";
        //AddMembers.Enabled = false;
    }

    protected void ddl_patlist_SelectedIndexChanged(object sender, EventArgs e)
    {
      
            DataTable dtbl = new DataTable();
            DataTable dtblappointment = new DataTable();
            try
            {
                crtview = new CRTBEL();
                crtcntrl = new CRTBAL();
                long memberid = Convert.ToInt64(ddl_patlist.SelectedValue);
                dtbl = crtcntrl.GetRegMemberInfo(memberid);
                if (dtbl.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtbl.Rows)
                    {
                        if (dr["members_gender"].ToString() == "F")
                        {
                            ddl_patgender.SelectedIndex = 1;
                        }
                        else
                        {
                            ddl_patgender.SelectedIndex = 2;
                        }
                        txt_patage.Text = dr["members_age"].ToString();
                    }

                    dtblappointment = crtcntrl.GetAppointmentDetails(memberid);

                    if (dtblappointment.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtblappointment.Rows)
                        {
                            txt_consultingtime.Text = dr["appointment_time"].ToString();
                            ddl_consultationstatus.SelectedIndex = 1;

                            // Appointment Department Auto Selection
                            string Dept = dr["department_desc"].ToString();
                            lbl_appointmentid.Text = dr["appointment_id"].ToString();
                            int i = 0;
                            foreach (var item in lb_deptlist.Items)
                            {

                                if (item.ToString() == Dept)
                                {
                                    if (!arraylist1.Contains(lb_deptlist.Items[i]))
                                    {
                                        arraylist1.Add(lb_deptlist.Items[i]);

                                    }


                                    for (int j = 0; j < arraylist1.Count; j++)
                                    {
                                        if (!lb_seldeptlist.Items.Contains(((ListItem)arraylist1[j])))
                                        {
                                            lb_seldeptlist.Items.Add(((ListItem)arraylist1[j]));
                                        }
                                        lb_deptlist.Items.Remove(((ListItem)arraylist1[j]));
                                    }
                                    lb_seldeptlist.SelectedIndex = -1;

                                    break; // we don't want to run the loop any more.  let's go out              
                                }

                                i = i + 1;
                            }

                            ddl_consultationstatus.Enabled = false;
                            //lb_deptlist.Enabled = false;
                            //lb_seldeptlist.Enabled = false;
                            //btn_l1tol2.Enabled = false;
                            //btn_l2tol1.Enabled = false;
                            //btn_up.Enabled = false;
                            //btn_down.Enabled = false;

                        }
                    }
                    else
                    {
                        lb_seldeptlist.Items.Clear();
                        LoadDepart();
                        ddl_consultationstatus.SelectedIndex = 0;
                        txt_consultingtime.Text = string.Empty;

                        ddl_consultationstatus.Enabled = true;
                        lb_deptlist.Enabled = true;
                        lb_seldeptlist.Enabled = true;
                        btn_l1tol2.Enabled = true;
                        btn_l2tol1.Enabled = true;
                        btn_up.Enabled = true;
                        btn_down.Enabled = true;
                    }
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Problem in member selection", ex);
            }
            finally
            {

            }
        
    }

    #region Simple Kiosk - Print Sending

    public void SimpleKioskPrint()
    {
        Session["UserAuthentication0"] = QueueTicket;
        Session["UserAuthentication1"] = DeptName;
        Session["UserAuthentication2"] = Convert.ToString(DateTime.Now);

        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width)-(2/2);var Mtop = (screen.height)-(1200/2);window.open('Print.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

    }

    #endregion Simple Kiosk - Print Sending

    // CRT - Queue Status Button Click

    #region CRT - Queue Status Button Click

    protected void btn_queuestatus_Click(object sender, EventArgs e)
    {
        CRTBEL crtview = new CRTBEL();
        CRTBAL crtcntrl = new CRTBAL();
        try
        {           
            if (txt_queuenumber.Text != string.Empty)
            {
                crtview.QueueNummberShow = txt_queuenumber.Text;
                crtview.DateTime = System.DateTime.Now.ToShortDateString();

                MyQueueNumber = crtcntrl.GetMyQueueNumber(crtview);

                if (MyQueueNumber.Rows.Count != 0)
                {
                    gv_queuedetails.Visible = true;
                    //queuestatusbel.TransferID = Convert.ToInt16(MyQueueNumber.Rows[0][7].ToString());

                    // Creating Data Type Column On Run Time
                    MyQueueNumber.Columns.Add("Queue Status");
                    MyQueueNumber.Columns.Add("SL.NO");

                    // Assigning String To Data Type Column
                    foreach (DataRow queuestatus in MyQueueNumber.Rows)
                    {
                        if ((queuestatus["plan_transfer_id"].ToString() != string.Empty) || (queuestatus["unplan_transfer_id"].ToString()) != string.Empty)
                        {
                            if (queuestatus["plan_transfer_id"].ToString() != string.Empty)
                            {
                                crtview.TransferID = Convert.ToInt16(queuestatus["plan_transfer_id"].ToString());
                            }
                            else
                            {
                                crtview.TransferID = Convert.ToInt16(queuestatus["unplan_transfer_id"].ToString());
                            }
                            string MyQueueStatus = crtcntrl.GetMyQueueStatus(crtview);

                            queuestatus["Queue Status"] = MyQueueStatus;

                        }

                        else
                        {
                            queuestatus["Queue Status"] = "Pending";
                        }


                        queuestatus["SL.NO"] = slno;

                        slno = slno + 1;

                    }

                    lbl_getstatus.Visible = false;

                    //lbl_messagebox.Visible = false;
                }
                else
                {
                    gv_queuedetails.Visible = false;
                    lbl_getstatus.Text = "No Records Found";
                    lbl_getstatus.Visible = true;
                }
                //else
                //{
                //    lbl_messagebox.Text = "No Matching The Record";
                //    lbl_messagebox.Visible = true;
                //}

                gv_queuedetails.DataSource = MyQueueNumber;
                gv_queuedetails.DataBind();

            }

            else
            {
                lbl_getstatus.Text = "Please Enter Your Queue Number";
                lbl_getstatus.Visible = true;
                gv_queuedetails.Visible = false;
            }

        }
        catch (SqlException ex)
        {
            ex.ToString();
        }
        finally
        {
            MyQueueNumber = null;
            crtview = null;
            crtcntrl = null;
        }
    }

    #endregion CRT - Queue Status Button Click

    protected void btn_reprint_Click(object sender, EventArgs e)
    {
        DataTable dtbl = new DataTable();
        DataTable CheckingQueueToken = new DataTable();
        crtview = new CRTBEL();
        crtcntrl = new CRTBAL();
        string PatientName = string.Empty;
        crtview.ESCInNumber = txt_esicno.Text;

        crtview.CustomerFullName = txt_cusfname.Text + txt_cuslname.Text;
        //crtview.PatientId = Convert.ToInt32(ddl_patlist.SelectedValue);
        //PatientName = ddl_patlist.SelectedItem.Text;
        if (txt_esicno.Text == string.Empty && txt_surname.Text != null)
        {
            crtview.ESCInNumber = DropDownList1.SelectedValue.ToString();
            CheckingQueueToken = crtcntrl.ReprintCheckQueueTokenAlreadyGenerated(crtview);

            if (CheckingQueueToken.Rows.Count == 0)
            {
                MyMessageBox("You are not Generated any Token to Reprint Please generate a Print first");
            }
            else if (CheckingQueueToken.Rows.Count == 1)
            {
                int selectedItem1 = Convert.ToInt32(CheckingQueueToken.Rows[0][3]);
                crtview.QueueNummberShow = Convert.ToString(CheckingQueueToken.Rows[0][6]);
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
                Session["UserAuthentication0"] = crtview.QueueNummberShow;
                Session["UserAuthentication1"] = DropDownList1.SelectedValue.ToString();

                Session["UserAuthentication2"] = AverageWaitingQueue;
                Session["UserAuthentication3"] = AverageWaitingTime;
                Session["UserAuthentication4"] = Convert.ToString(DateTime.Now);

                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(2/2);var Mtop = (screen.height/2)-(1200/2);window.open( 'ReprintDisplay.aspx', null, 'height=20000,width=20000,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);


            }
            else
            {
                Session["UserAuthentication1"] = DropDownList1.SelectedValue.ToString();
                crtview.ESCInNumber = DropDownList1.SelectedValue.ToString();
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ReprintDisplay", "reprintdisplay();", true);
            }
        }
        //ScriptManager.RegisterStartupScript("OpenPopup", "<script>popitup('PageToOpen.aspx');</script>");
        if (txt_esicno.Text != string.Empty && txt_surname.Text == null)
        {


            CheckingQueueToken = crtcntrl.ReprintCheckQueueTokenAlreadyGenerated(crtview);

            if (CheckingQueueToken.Rows.Count == 0)
            {
                MyMessageBox("You are not Generated any Token to Reprint Please generate a Print first");
            }
            else if (CheckingQueueToken.Rows.Count == 1)
            {
                int selectedItem1 = Convert.ToInt32(CheckingQueueToken.Rows[0][3]);
                crtview.QueueNummberShow = Convert.ToString(CheckingQueueToken.Rows[0][6]);
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
                Session["UserAuthentication0"] = crtview.QueueNummberShow;
                Session["UserAuthentication1"] = txt_esicno.Text;

                Session["UserAuthentication2"] = AverageWaitingQueue;
                Session["UserAuthentication3"] = AverageWaitingTime;
                Session["UserAuthentication4"] = Convert.ToString(DateTime.Now);

                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(2/2);var Mtop = (screen.height/2)-(1200/2);window.open( 'ReprintDisplay.aspx', null, 'height=20000,width=20000,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);


            }
            else
            {
                Session["UserAuthentication1"] = txt_esicno.Text;
                crtview.ESCInNumber = txt_esicno.Text;
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "ReprintDisplay", "reprintdisplay();", true);
            }
        }
    }
    public void MyMessageBox(string text)
    {
        string script = "alert('" + text + "');";
        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);
    }
    protected void buttonlink_Click(object sender, EventArgs e)
    {
        int userid = Convert.ToInt32(_currentuserId);
        logincntrl = new LoginBAL();
        int session_Id = logincntrl.GetSessionId(userid);
        //int session_sod2 = logincntrl.GetUserSessionSod(userid);
        logincntrl.updateUserLogoutSession(session_Id, userid);
        Response.Redirect("Default.aspx");
    }

    // CRT Screen - Consulting Status Selected Index Changed

    #region CRT Screen - Consulting Status Selected Index Changed

    protected void ddl_consultationstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_consultationstatus.SelectedIndex == 1)
        {
            btn_print.Enabled = false;
            btn_reprint.Enabled = false;

            string msgValidate = "No Appointment Taken";
            string script = "alert('" + msgValidate + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);


        }
        else
        {
            btn_print.Enabled = true;
            btn_reprint.Enabled = true;

        }

    }

    #endregion CRT Screen - Consulting Status Selected Index Changed

    protected void txt_cusphone_TextChanged(object sender, EventArgs e)
    {
        //Regex regex = new Regex("^[0-9]*$");
        //if (regex.IsMatch(txt_cusphone.Text))
        //{
        //    errorProvider1.SetError(txt_cusphone, String.Empty);
        //}
        //else
        //{
        //    errorProvider1.SetError(txt_cusphone,
        //          "Only numbers may be entered here");
        //}
    }

    protected void lb_deptlist_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lb_deptlist_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void btn_Click(object sender, EventArgs e)
    {
        string url = string.Format("crtesic.aspx");
        Response.Redirect(url, false);
    }
    protected void btn1_Click(object sender, EventArgs e)
    {
        //string url = string.Format("AppDetails.aspx");
        //Response.Redirect(url, false);


        fname = Server.UrlDecode(Request.QueryString["1"]);
        lname = Server.UrlDecode(Request.QueryString["2"]);
        uname = Request.QueryString["3"];
        terdesc = Request.QueryString["4"];
        uid = Server.UrlDecode(Request.QueryString["5"]);
        tid = Server.UrlDecode(Request.QueryString["6"]);
        did = Server.UrlDecode(Request.QueryString["7"]);
        dd = Server.UrlDecode(Request.QueryString["8"]);
        string url = string.Format("AppDetails.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
            Server.UrlEncode(fname),
            Server.UrlEncode(lname),
            Server.UrlEncode(uname),
            Server.UrlEncode(terdesc),
            Server.UrlEncode(uid),
            Server.UrlEncode(tid),
            Server.UrlEncode(did),
            Server.UrlEncode(dd));
        Response.Redirect(url, false);
    }
    protected void btn_search_click(object sender, EventArgs e)
    {
    }
    protected void DropDownList1123_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    public void searchpatient(string _custid)
    {
        crtview = new CRTBEL();
        crtcntrl = new CRTBAL();
        try
        {
            crtview.ESCInNumber = _custid;
            //strb.Append(txt_esicno.Text);
            if (crtview.ESCInNumber != string.Empty && crtview.ESCInNumber != "0")
            {
                crtview.Esicnodetails = crtcntrl.GetRegCustomerDetail(crtview.ESCInNumber);
                if (crtview.Esicnodetails.Rows.Count > 0)
                {

                    AvailableESCIno();
                    foreach (DataRow dr in crtview.Esicnodetails.Rows)
                    {

                        txt_cusfname.Text = dr["customer_firstname"].ToString();
                        txt_cuslname.Text = dr["customer_lastname"].ToString();
                        txt_cusadd.Text = dr["customer_address"].ToString();
                        txt_cusage.Text = dr["customer_age"].ToString();
                        txt_cusphone.Text = dr["customer_mobile"].ToString();
                        txt_cusemail.Text = dr["customer_email"].ToString();
                        //RadDatePicker1.SelectedDate = Convert.ToDateTime(dr["customer_dob"].ToString());
                        if (Convert.ToChar(dr["customer_gender"].ToString()) == 'M')
                        {
                            ddl_cusgender.SelectedIndex = 2;
                        }
                        else
                        {
                            ddl_cusgender.SelectedIndex = 1;
                        }

                    }
                    Session["esicno"] = crtview.ESCInNumber;

                    RetriveMemberInfobysurname(_custid);
                    btn_print.Enabled = true;
                    btn_reprint.Enabled = true;
                    lbl_msg.Visible = false;
                    ddl_consultationstatus.Enabled = true;
                    lb_deptlist.Enabled = true;
                    lb_seldeptlist.Enabled = true;
                    btn_l1tol2.Enabled = true;
                    btn_l2tol1.Enabled = true;
                    btn_up.Enabled = true;
                    btn_down.Enabled = true;
                    //AddMembers.Enabled = true;

                }
                else
                {
                    NotAvailableEsicno();
                    txt_cusfname.Focus();
                    ddl_consultationstatus.Enabled = true;
                    lb_deptlist.Enabled = true;
                    lb_seldeptlist.Enabled = true;
                    btn_l1tol2.Enabled = true;
                    btn_l2tol1.Enabled = true;
                    btn_up.Enabled = true;
                    btn_down.Enabled = true;
                    Session["esicno"] = txt_esicno.Text;
                    //MessageBox messageBox = new MessageBox();
                    //messageBox.MessageTitle = "CRT";
                    //messageBox.MessageText = "ESIC No Not Register.";
                    //Literal1.Text = messageBox.Show(this);
                    //MessageBox.Show("ESIC No Not Register.Please Register ESIC No");

                    string script = "alert('Medicare No Not Register.Please Register Medicare No');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);

                }
            }
            else
            {

                txt_esicno.Focus();
                txt_esicno.Text = "";
                txt_surname.Text = "";
                MessageBox.Show("Please Enter Correct Medicare No Or Your Surname");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in text change", ex);
        }
        finally
        {
            crtcntrl = null;
        }
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        CRTBEL crtview = new CRTBEL();
        custid = DropDownList1.SelectedValue.ToString();
        crtview.ESCInNumber = custid;
        searchpatient(custid);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
    }

    protected void btn_search1_click(object sender, EventArgs e)
   {
        DataTable dt1 = new DataTable();
        CRTBAL crtcntrl = new CRTBAL();
       // ResetAllValues();
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("Select Patient Name");
        try
        {
            if (txt_surname.Text != string.Empty && txt_surname.Text != "")
            {
                dt1 = crtcntrl.Searchmembersurname(txt_surname.Text);

                foreach (DataRow dr in dt1.Rows)
                {

                    ListItem li = new ListItem();
                    // li.Text = dr[ "members_firstname"].ToString();
                    li.Text = dr["PatientName"].ToString();
                    li.Value = dr["members_customer_id"].ToString();
                    //li.Value = dr["PatientName"].ToString();
                    // DropDownList1.DataSource = dt1;
                    // DropDownList1.DataTextField = "members_firstname";
                    // DropDownList1.DataValueField = "members_customer_id";
                   // DropDownList1.Items.Add("Select Patient Name");
                    DropDownList1.Items.Add(li);
                    DropDownList1.DataBind();
                }
            }
            txt_Qnumbercancel.Text = string.Empty;
            DropDownList2.SelectedIndex = 0;
            DropDownList1.SelectedIndex = 0;
        }
        catch (Exception)
        {

            throw;
        }

    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        CRTBEL crtview = new CRTBEL();
        CRTBAL crtcntrl = new CRTBAL();
        try
        {
            if (txt_Qnumbercancel.Text != string.Empty)
            {
                crtview.QueueNummberShow = txt_Qnumbercancel.Text;
                crtview.DateTime = System.DateTime.Now.ToShortDateString();
                DataTable dt2 = new DataTable();

                MyQueueNumber = crtcntrl.GetCancelTicket(crtview);
                if (MyQueueNumber.Rows.Count > 0)
                {
                    foreach (DataRow dr in MyQueueNumber.Rows)
                    {
                        //crtview.PatientId = Convert.ToInt32(dr["visit_customer_id"].ToString());
                        crtview.CusVisitId = Convert.ToInt32(dr["visit_tnx_id"].ToString());
                        if (DropDownList2.SelectedIndex == 1)
                        {
                            crtview.ConsultingStatus = "C";
                        }
                        if (DropDownList2.SelectedIndex == 2)
                        {
                            crtview.ConsultingStatus = "P";
                        }
                        string s = crtcntrl.getUpdateTicket(crtview);
                    }

                }
                ResetAllValues();
                txt_Qnumbercancel.Text = String.Empty;
                DropDownList1.SelectedIndex = 0;
            }

        }
        catch (SqlException ex)
        {
            ex.ToString();
        }
        finally
        {
            MyQueueNumber = null;
            crtview = null;
            crtcntrl = null;
        }

    }
    protected void txt_Qnumbercancel_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btn_cancel_Click1(object sender, EventArgs e)
    {
        CRTBEL crtview = new CRTBEL();
        CRTBAL crtcntrl = new CRTBAL();
        try
        {
            if (txt_Qnumbercancel.Text != string.Empty)
            {
                crtview.QueueNummberShow = txt_Qnumbercancel.Text;
                crtview.DateTime = System.DateTime.Now.ToShortDateString();
                DataTable dt2 = new DataTable();

                MyQueueNumber = crtcntrl.GetCancelTicket(crtview);
                if (MyQueueNumber.Rows.Count > 0)
                {
                    foreach (DataRow dr in MyQueueNumber.Rows)
                    {
                        //crtview.PatientId = Convert.ToInt32(dr["visit_customer_id"].ToString());
                        crtview.CusVisitId = Convert.ToInt32(dr["visit_tnx_id"].ToString());
                        if (DropDownList2.SelectedIndex == 1)
                        {
                            crtview.ConsultingStatus = "C";
                        }
                        if (DropDownList2.SelectedIndex == 2)
                        {
                            crtview.ConsultingStatus = "P";
                        }
                        string s = crtcntrl.getUpdateTicket(crtview);
                    }

                }
                ResetAllValues();
                txt_Qnumbercancel.Text = String.Empty;
                DropDownList1.SelectedIndex = 0;
            }

        }
        catch (SqlException ex)
        {
            ex.ToString();
        }
        finally
        {
            MyQueueNumber = null;
            crtview = null;
            crtcntrl = null;
        }

    }
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        CRTBEL crtview = new CRTBEL();
        custid = DropDownList1.SelectedValue.ToString();
        crtview.ESCInNumber = custid;
        searchpatient(custid);
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btn_search_Click1(object sender, EventArgs e)
    {
        crtview = new CRTBEL();
        crtcntrl = new CRTBAL();
        try
        {
            //strb.Append(txt_esicno.Text);
            if (txt_esicno.Text != string.Empty && txt_esicno.Text != "0")
            {
                crtview.Esicnodetails = crtcntrl.GetRegCustomerDetail(txt_esicno.Text);
                if (crtview.Esicnodetails.Rows.Count > 0)
                {

                    AvailableESCIno();
                    foreach (DataRow dr in crtview.Esicnodetails.Rows)
                    {

                        txt_cusfname.Text = dr["customer_firstname"].ToString();
                        txt_cuslname.Text = dr["customer_lastname"].ToString();
                        txt_cusadd.Text = dr["customer_address"].ToString();
                        txt_cusage.Text = dr["customer_age"].ToString();
                        txt_cusphone.Text = dr["customer_mobile"].ToString();
                        txt_cusemail.Text = dr["customer_email"].ToString();
                        RadDatePicker1.SelectedDate =Convert.ToDateTime(dr["customer_dob"].ToString());
                        if (Convert.ToChar(dr["customer_gender"].ToString()) == 'M')
                        {
                            ddl_cusgender.SelectedIndex = 2;
                        }
                        else
                        {
                            ddl_cusgender.SelectedIndex = 1;
                        }

                    }
                    Session["esicno"] = txt_esicno.Text;

                    RetriveMemberInfo();
                    btn_print.Enabled = true;
                    btn_reprint.Enabled = true;
                    lbl_msg.Visible = false;
                    ddl_consultationstatus.Enabled = true;
                    lb_deptlist.Enabled = true;
                    lb_seldeptlist.Enabled = true;
                    btn_l1tol2.Enabled = true;
                    btn_l2tol1.Enabled = true;
                    btn_up.Enabled = true;
                    btn_down.Enabled = true;
                    //AddMembers.Enabled = true;

                }
                else
                {
                    NotAvailableEsicno();
                    txt_cusfname.Focus();
                    ddl_consultationstatus.Enabled = true;
                    lb_deptlist.Enabled = true;
                    lb_seldeptlist.Enabled = true;
                    btn_l1tol2.Enabled = true;
                    btn_l2tol1.Enabled = true;
                    btn_up.Enabled = true;
                    btn_down.Enabled = true;
                    Session["esicno"] = txt_esicno.Text;
                    //MessageBox messageBox = new MessageBox();
                    //messageBox.MessageTitle = "CRT";
                    //messageBox.MessageText = "ESIC No Not Register.";
                    //Literal1.Text = messageBox.Show(this);
                    //MessageBox.Show("ESIC No Not Register.Please Register ESIC No");

                    string script = "alert('Medicare No Not Register.Please Register Medicare No');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScripts", script, true);

                }
            }
            else
            {

                txt_esicno.Focus();
                txt_esicno.Text = "";
                MessageBox.Show("Please Enter Correct Medicare No");
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in text change", ex);
        }
        finally
        {
            crtcntrl = null;
        }
    }
    private void DisableCusField()
    {
        btn_cusreg.Text = "Edit";
        Hidden1.Value = "E";
        txt_cusfname.Enabled = false;
        txt_cuslname.Enabled = false;
        txt_cusphone.Enabled = false;
        txt_cusage.Enabled = false;
        txt_cusadd.Enabled = false;
        txt_cusemail.Enabled = false;
        ddl_cusgender.Enabled = false;
        RadDatePicker1.Enabled = false;
    }
    private void RetriveCustomerInfo()
    {
        DataTable dtbl = new DataTable();
        try
        {
            crtcntrl = new CRTBAL();
            dtbl = crtcntrl.GetRegCustomerDetail(txt_esicno.Text);
            if (dtbl.Rows.Count > 0)
            {
                foreach (DataRow dr in dtbl.Rows)
                {
                    txt_cusfname.Text = dr["customer_firstname"].ToString();
                    txt_cuslname.Text = dr["customer_lastname"].ToString();
                    txt_cusadd.Text = dr["customer_address"].ToString();
                    txt_cusage.Text = dr["customer_age"].ToString();
                    txt_cusphone.Text = dr["customer_mobile"].ToString();
                    if (Convert.ToChar(dr["customer_gender"].ToString()) == 'M')
                    {
                        ddl_cusgender.SelectedIndex = 2;
                    }
                    else
                    {
                        ddl_cusgender.SelectedIndex = 1;
                    }

                }
                AvailableESCIno();
                RetriveMemberInfo();
            }
            
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in Retrive Patient Information", ex);
        }
        finally
        {
            dtbl = null;
            crtcntrl = null;
        }
    }

    
    protected void btn_Search1_Click(object sender, EventArgs e)
    {
        DataTable dt1 = new DataTable();
        CRTBAL crtcntrl = new CRTBAL();
       // ResetAllValues();
        DropDownList1.Items.Clear();
        DropDownList1.Items.Add("Select Patient Name");
        try
        {
            if (txt_surname.Text != string.Empty && txt_surname.Text != "")
            {
                dt1 = crtcntrl.Searchmembersurname(txt_surname.Text);

                foreach (DataRow dr in dt1.Rows)
                {

                    ListItem li = new ListItem();
                    // li.Text = dr[ "members_firstname"].ToString();
                    li.Text = dr["PatientName"].ToString();
                    li.Value = dr["members_customer_id"].ToString();
                    //li.Value = dr["PatientName"].ToString();
                    // DropDownList1.DataSource = dt1;
                    // DropDownList1.DataTextField = "members_firstname";
                    // DropDownList1.DataValueField = "members_customer_id";
                   // DropDownList1.Items.Add("Select Patient Name");
                    DropDownList1.Items.Add(li);
                    DropDownList1.DataBind();
                }
            }
            txt_Qnumbercancel.Text = string.Empty;
            DropDownList2.SelectedIndex = 0;
            DropDownList1.SelectedIndex = 0;
        }
        catch (Exception)
        {

            throw;
        }

    }

    }


 //CRT - CRT Add Value

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