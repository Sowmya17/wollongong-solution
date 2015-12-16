using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.IO;
using System.Data;

//this is edit file
public partial class _Default : System.Web.UI.Page
{
    LoginBEL loginview;
    LoginBAL logincntrl;
    string CorrectIPAddress;
    int usersessionid;
    int userdepartmentId;
    MessageBox ModeMsg = new MessageBox();

    [DllImport("Iphlpapi.dll")]
    private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
    [DllImport("Ws2_32.dll")]
    private static extern Int32 inet_addr(string ip);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txt_username.Focus();
            lbl_error.Visible = false;
            btn_login.Enabled = true;
            //client mac address
            lbl_clientip.Text = MACAddress();
            //server mac address
            lbl_instanceip.Text = GetMACAddress();
            //if (File.Exists(@"C:\QMS\login.ini"))
            //{
            //    login();
            //}
           //autologincheck();
       }
         
    }

    public void autologincheck()
    {
        loginview = new LoginBEL();
        logincntrl = new LoginBAL();
        DataTable dt = new DataTable();
        string mac = MACAddress();
        if (mac != "000000000000")
        {
            dt = logincntrl.GetAutoLoginDetail(mac);
            if (dt.Rows.Count > 0)
            {
                string uname = "", pass = "";
                loginview.AutoLoginStatus = dt.Rows[0][0].ToString();
                uname=loginview.AutoLoginUserName = dt.Rows[0][1].ToString();
                pass=loginview.AutoLoginPassword = dt.Rows[0][2].ToString();

                if (loginview.AutoLoginStatus == "Y" && loginview.AutoLoginUserName != "" && loginview.AutoLoginPassword !="")
                {
                    login(uname,pass);
                }
            }
        }

    }


    public void login(string autouname,string autopass)
    {
        //Label1.Text = Encryptdata(txt_password.Text);
        try
        {
            loginview = new LoginBEL();
            logincntrl = new LoginBAL();
            string auto = "y";
            //string[] lines = System.IO.File.ReadAllLines(@"C:\QMS\login.ini");
            if (auto=="y")
            {
                // btn_login.Enabled = false;
                //loginview.Password = Encryptdata(txt_password.Text);
                //loginview.UserName = txt_username.Text;//.ToLower();

                //loginview.Password = Encryptdata(lines[1]);
                //loginview.UserName = lines[0];//.ToLower();
                loginview.Password = Encryptdata(autopass);
                loginview.UserName = autouname;//.ToLower();


                loginview = logincntrl.GetUserLoginDetails(loginview.UserName, loginview.Password);
                if (loginview.UserName == null)
                {
                    lbl_error.Text = "Please Enter Correct Username and Password";
                    ClearInputs(Page.Controls);
                    lbl_error.Visible = true;
                    txt_username.Focus();
                    return;
                }
                if (loginview.ActiveUser == 'N')
                {
                    lbl_error.Text = "User not Activated.";
                    ClearInputs(Page.Controls);
                    lbl_error.Visible = true;
                    txt_username.Focus();
                    return;
                    // btn_cancel_Click(sender, e);
                }
                else
                {
                    // Pass arguments to the Login controller

                    // Running In Normal Systems
                    //loginview.IPAddress = GetIP();
                    //it will get the current system mac address
                    //loginview.IPAddress =GetMACAddress() ;

                    // Running In Server
                    //loginview.IPAddress = HttpContext.Current.Request.UserHostAddress;
                    //it will get the mac address of the client using client ip
                    loginview.IPAddress = MACAddress();

                    usersessionid = loginview.UserId;
                    userdepartmentId = loginview.DepartmentId;
                    // loginview.IPAddress = "127.0.0.1";
                    Hidden1.Value = loginview.FirstName;
                    Hidden2.Value = loginview.LastName;
                    Hidden3.Value = loginview.UserName;
                    Hidden4.Value = Convert.ToString(loginview.UserId);

                    Hidden6.Value = Convert.ToString(loginview.DepartmentId);
                    loginview = logincntrl.GetUserTerminalDetail(loginview.IPAddress, loginview.DepartmentId, loginview.UserName);

                    Hidden5.Value = Convert.ToString(loginview.TerminalTypeId);

                    //  _loginview = _logincontrol.GetUserRoll(LoginView._idUser);
                    if (loginview.TerminalId == 0)
                    {

                        lbl_error.Text = "Terminal is not registered.";
                        ClearInputs(Page.Controls);
                        lbl_error.Visible = true;
                        txt_username.Focus();
                    }
                    else
                    {

                        int terminalId = loginview.TerminalId;

                        #region User Session Stuff
                        int sod1 = 1;
                        int usersessionsod;
                        //int usersession_id1 = logincntrl.GetSessionId(usersessionid);
                        //if(usersession_id1!= 0)
                        //{

                        //}
                        usersessionsod = logincntrl.GetUserSessionSod(usersessionid);
                        sod1 = usersessionsod + 1;
                        //int user_Session_Id = usersessionsod + 1;
                        logincntrl.UpdateUserSession(usersessionid, userdepartmentId, terminalId, sod1);
                        #endregion

                        if (loginview.TerminalTypeId == 1)
                        {
                            Hidden5.Value = Convert.ToString(loginview.TerminalId);
                            string fname = Hidden1.Value;
                            string lname = Hidden2.Value;
                            string uname = Hidden3.Value;
                            string terdesc = loginview.TerminalDesc;
                            string uid = Hidden4.Value;
                            string tid = Hidden5.Value;
                            string did = Hidden6.Value;
                            string dd = loginview.DeaprtmentDesc;
                            string url = string.Format("crtesic.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                                Server.UrlEncode(fname),
                                Server.UrlEncode(lname),
                                Server.UrlEncode(uname),
                                Server.UrlEncode(terdesc),
                                Server.UrlEncode(uid),
                                Server.UrlEncode(tid),
                                Server.UrlEncode(did),
                                Server.UrlEncode(dd));
                            Response.Redirect(url, false);

                            // Response.Redirect("crtesic.aspx?User="+ uname +"&ter="+ terdesc,false);
                        }
                        else if (loginview.TerminalTypeId == 2 || loginview.TerminalTypeId == 6)
                        {



                            Hidden5.Value = Convert.ToString(loginview.TerminalId);
                            //  Hidden5.Value = Convert.ToString(loginview.TerminalTypeId);
                            string fname = Hidden1.Value;
                            string lname = Hidden2.Value;
                            string uname = Hidden3.Value;
                            string terdesc = loginview.TerminalDesc;
                            string uid = Hidden4.Value;
                            string tid = Hidden5.Value;
                            string did = Hidden6.Value;
                            string dd = loginview.DeaprtmentDesc;
                            string terminaltypeid = loginview.TerminalTypeId.ToString();
                            string url = string.Format("rtesic.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}",
                                Server.UrlEncode(fname),
                                Server.UrlEncode(lname),
                                Server.UrlEncode(uname),
                                Server.UrlEncode(terdesc),
                                Server.UrlEncode(uid),
                                Server.UrlEncode(tid),
                                Server.UrlEncode(did),
                                Server.UrlEncode(dd),
                                Server.UrlEncode(terminaltypeid));
                            Response.Redirect(url, false);

                        }
                        else if (loginview.TerminalTypeId == 3)
                        {
                            Hidden5.Value = Convert.ToString(loginview.TerminalId);
                            string fname = Hidden1.Value;
                            string lname = Hidden2.Value;
                            string uname = Hidden3.Value;
                            string terdesc = loginview.TerminalDesc;
                            string uid = Hidden4.Value;
                            string tid = Hidden5.Value;
                            string did = Hidden6.Value;
                            string dd = loginview.DeaprtmentDesc;
                            string url = string.Format("kioskhome.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
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
                        else if (loginview.TerminalTypeId == 4)
                        {
                            Hidden5.Value = Convert.ToString(loginview.TerminalId);
                            Session["fname"] = Hidden1.Value;
                            Session["lname"] = Hidden2.Value;
                            Session["uname"] = Hidden3.Value;
                            Session["terdesc"] = loginview.TerminalDesc;
                            Session["uid"] = Hidden4.Value;
                            Session["tid"] = Hidden5.Value;
                            Session["did"] = Hidden6.Value;
                            Session["dd"] = loginview.DeaprtmentDesc;
                            string url = string.Format("~/Admin/admin.aspx");
                            Response.Redirect(url, false);
                        }
                        else if (loginview.TerminalTypeId == 5)
                        {
                            Hidden5.Value = Convert.ToString(loginview.TerminalId);
                            Session["fname"] = Hidden1.Value;
                            Session["lname"] = Hidden2.Value;
                            Session["uname"] = Hidden3.Value;
                            Session["terdesc"] = loginview.TerminalDesc;
                            Session["uid"] = Hidden4.Value;
                            Session["tid"] = Hidden5.Value;
                            Session["did"] = Hidden6.Value;
                            Session["dd"] = loginview.DeaprtmentDesc;
                            string url = string.Format("~/Admin/TotalQueue.aspx");
                            Response.Redirect(url, false);
                        }

                    }
                }
            }
            else if (txt_username.Text != "" & txt_password.Text == "")
            {
                lbl_error.Text = "Please Enter the Password";
                ClearInputs(Page.Controls);
                lbl_error.Visible = true;
                txt_password.Focus();
            }
            else
            {
                lbl_error.Text = "Please Enter Username and Password";
                ClearInputs(Page.Controls);
                lbl_error.Visible = true;
                txt_username.Focus();
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show("Please Enter a Proper Login Details in a Configuration File");
            // throw new Exception("Problem in Login", ex);
            Application.Clear();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //Label1.Text = Encryptdata(txt_password.Text);
        try
        {
            loginview = new LoginBEL();
            logincntrl = new LoginBAL();
             
            if (txt_username.Text != "" & txt_password.Text != "")
            {
               // btn_login.Enabled = false;
                loginview.Password = Encryptdata(txt_password.Text);
                loginview.UserName = txt_username.Text;//.ToLower();

                loginview = logincntrl.GetUserLoginDetails(loginview.UserName, loginview.Password);
                if (loginview.UserName == null)
                {
                    lbl_error.Text= "Please Enter Correct Username and Password";
                    ClearInputs(Page.Controls);
                    lbl_error.Visible = true;
                    txt_username.Focus();
                    return;
                }
                if (loginview.ActiveUser == 'N')
                {
                    lbl_error.Text= "User not Activated.";
                    ClearInputs(Page.Controls);
                    lbl_error.Visible = true;
                    txt_username.Focus();
                    return;
                   // btn_cancel_Click(sender, e);
                }
                else
                {
                    // Pass arguments to the Login controller
                    
                    // Running In Normal Systems
                    //loginview.IPAddress = GetIP();
                    //it will get the current system mac address
                    //loginview.IPAddress =GetMACAddress() ;
                    
                    // Running In Server
                   //loginview.IPAddress = HttpContext.Current.Request.UserHostAddress;
                    //it will get the mac address of the client using client ip
                    loginview.IPAddress = MACAddress();

                    usersessionid = loginview.UserId;
                    userdepartmentId = loginview.DepartmentId;
                   // loginview.IPAddress = "127.0.0.1";
                    Hidden1.Value = loginview.FirstName;
                    Hidden2.Value = loginview.LastName;
                    Hidden3.Value = loginview.UserName;
                    Hidden4.Value = Convert.ToString(loginview.UserId);
                    
                    Hidden6.Value = Convert.ToString(loginview.DepartmentId);
                    logincntrl.UpdateMacAddress(loginview.IPAddress, loginview.DepartmentId, loginview.UserName);
                    loginview = logincntrl.GetUserTerminalDetail(loginview.IPAddress, loginview.DepartmentId,loginview.UserName);

                    Hidden5.Value = Convert.ToString(loginview.TerminalTypeId);

                  //  _loginview = _logincontrol.GetUserRoll(LoginView._idUser);
                    if (loginview.TerminalId == 0)
                    {
                       
                        lbl_error.Text = "Terminal is not registered.";
                        ClearInputs(Page.Controls);
                        lbl_error.Visible = true;
                        txt_username.Focus();
                    }
                    else
                    {

                        int terminalId = loginview.TerminalId;

                        #region User Session Stuff
                        int sod1=1;
                        int usersessionsod;
                        //int usersession_id1 = logincntrl.GetSessionId(usersessionid);
                        //if(usersession_id1!= 0)
                        //{

                        //}
                        usersessionsod = logincntrl.GetUserSessionSod(usersessionid);
                        sod1 = usersessionsod + 1;
                        //int user_Session_Id = usersessionsod + 1;
                        logincntrl.UpdateUserSession(usersessionid, userdepartmentId, terminalId, sod1);
                        #endregion

                        if (loginview.TerminalTypeId == 1)
                        {
                            Hidden5.Value = Convert.ToString(loginview.TerminalId);
                            string fname = Hidden1.Value;
                            string lname = Hidden2.Value;
                            string uname = Hidden3.Value;
                            string terdesc = loginview.TerminalDesc;
                            string uid = Hidden4.Value;
                            string tid = Hidden5.Value;
                            string did = Hidden6.Value;
                            string dd = loginview.DeaprtmentDesc;
                            string url = string.Format("crtesic.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
                                Server.UrlEncode(fname),
                                Server.UrlEncode(lname),
                                Server.UrlEncode(uname),
                                Server.UrlEncode(terdesc),
                                Server.UrlEncode(uid),
                                Server.UrlEncode(tid),
                                Server.UrlEncode(did),
                                Server.UrlEncode(dd));
                            Response.Redirect(url, false);
                        
                           // Response.Redirect("crtesic.aspx?User="+ uname +"&ter="+ terdesc,false);
                        }
                        else if (loginview.TerminalTypeId == 2 || loginview.TerminalTypeId==6)
                        {
                           


                               Hidden5.Value = Convert.ToString(loginview.TerminalId);
                               //  Hidden5.Value = Convert.ToString(loginview.TerminalTypeId);
                                string fname = Hidden1.Value;
                                string lname = Hidden2.Value;
                                string uname = Hidden3.Value;
                                string terdesc = loginview.TerminalDesc;
                                string uid = Hidden4.Value;
                                string tid = Hidden5.Value;
                                string did = Hidden6.Value;
                                string dd = loginview.DeaprtmentDesc;
                                string terminaltypeid = loginview.TerminalTypeId.ToString();
                                string url = string.Format("rtesic.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}&9={8}",
                                    Server.UrlEncode(fname),
                                    Server.UrlEncode(lname),
                                    Server.UrlEncode(uname),
                                    Server.UrlEncode(terdesc),
                                    Server.UrlEncode(uid),
                                    Server.UrlEncode(tid),
                                    Server.UrlEncode(did),
                                    Server.UrlEncode(dd),
                                    Server.UrlEncode(terminaltypeid));
                                Response.Redirect(url, false);
                            
                        }
                        else if (loginview.TerminalTypeId == 3)
                        {
                            Hidden5.Value = Convert.ToString(loginview.TerminalId);
                            string fname = Hidden1.Value;
                            string lname = Hidden2.Value;
                            string uname = Hidden3.Value;
                            string terdesc = loginview.TerminalDesc;
                            string uid = Hidden4.Value;
                            string tid = Hidden5.Value;
                            string did = Hidden6.Value;
                            string dd = loginview.DeaprtmentDesc;
                            string url = string.Format("kioskhome.aspx?1={0}&2={1}&3={2}&4={3}&5={4}&6={5}&7={6}&8={7}",
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
                        else if (loginview.TerminalTypeId == 4)
                        {
                            Hidden5.Value = Convert.ToString(loginview.TerminalId);
                            Session["fname"] = Hidden1.Value;
                            Session["lname"] = Hidden2.Value;
                            Session["uname"] = Hidden3.Value;
                            Session["terdesc"] = loginview.TerminalDesc;
                            Session["uid"] = Hidden4.Value;
                            Session["tid"] = Hidden5.Value;
                            Session["did"] = Hidden6.Value;
                            Session["dd"] = loginview.DeaprtmentDesc;
                            string url = string.Format("~/Admin/admin.aspx");
                            Response.Redirect(url, false);
                        }
                        else if (loginview.TerminalTypeId == 5)
                        {
                            Hidden5.Value = Convert.ToString(loginview.TerminalId);
                            Session["fname"] = Hidden1.Value;
                            Session["lname"] = Hidden2.Value;
                            Session["uname"] = Hidden3.Value;
                            Session["terdesc"] = loginview.TerminalDesc;
                            Session["uid"] = Hidden4.Value;
                            Session["tid"] = Hidden5.Value;
                            Session["did"] = Hidden6.Value;
                            Session["dd"] = loginview.DeaprtmentDesc;
                            string url = string.Format("~/Admin/TotalQueue.aspx");
                            Response.Redirect(url, false);
                        }
                        
                    }
                }
            }
            else if (txt_username.Text != "" & txt_password.Text == "")
            {
                lbl_error.Text= "Please Enter the Password";
                ClearInputs(Page.Controls);
                lbl_error.Visible = true;
                txt_password.Focus();
            }
            else
            {
               lbl_error.Text= "Please Enter Username and Password";
               ClearInputs(Page.Controls);
               lbl_error.Visible = true;
                txt_username.Focus();
            }
            
        }
        catch (Exception ex)
        {   
            throw new Exception("Problem in Login", ex);
        }
    }
    private string Encryptdata(string password)
    {
        string strmsg = string.Empty;
        byte[] encode = new byte[password.Length];
        encode = Encoding.UTF8.GetBytes(password);
        strmsg = Convert.ToBase64String(encode);
        return strmsg;
    }
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

    void ClearInputs(ControlCollection ctrls)
    {
        foreach (Control ctrl in ctrls)
        {
            if (ctrl is TextBox)
                ((TextBox)ctrl).Text = string.Empty;
            ClearInputs(ctrl.Controls);
        }
    }
       
}