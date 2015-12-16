using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Threading;
using System.Globalization;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.Configuration;

public partial class TerminalMaster : System.Web.UI.Page
{
    // Intiallizing Variables

    #region Intiallizing Variables

    TextInfo TextInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

    MasterBAL masterbal = new MasterBAL();
    MasterBEL masterbel = new MasterBEL();

    public ArrayList departmentdescription = new ArrayList();
    public ArrayList roomcode = new ArrayList();
    public ArrayList terminaltypedescription = new ArrayList();
    public ArrayList TerminalDepartmentSelection = new ArrayList();

    int TerminalCRTLicence = Convert.ToInt16(ConfigurationManager.AppSettings["TerminalCRTLicense"].ToString());
    int TerminalRTLicence = Convert.ToInt16(ConfigurationManager.AppSettings["TerminalRTLicense"].ToString());
    int TerminalKIOSKLicence = Convert.ToInt16(ConfigurationManager.AppSettings["TerminalKIOSKLicense"].ToString());
    int TerminalQUEUEDISPLAYLicence = Convert.ToInt16(ConfigurationManager.AppSettings["TerminalQUEUEDISPLAYLicense"].ToString());


    string TerminalUpdate, TerminalInsert,Licence;

    #endregion Intiallizing Variables

    // Terminal Master - Page Loading

    #region Terminal Master - Page Loading

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {

                // Department Description Combo Box

                DataTable MyTerminalDepartment = new DataTable();

                MyTerminalDepartment = masterbal.GetDepartmentDescription();


                //departmentdescription.Add(new AddValue("Select", 0));

                TerminalDepartmentSelection.Add(new AddValue("ALL", 0));


                foreach (DataRow dr in MyTerminalDepartment.Rows)
                {
                    string Department_Description_Bind = dr["department_desc"].ToString();
                    long Department_id = Int32.Parse(dr["department_id"].ToString());

                    departmentdescription.Add(new AddValue(Department_Description_Bind, Department_id));

                    TerminalDepartmentSelection.Add(new AddValue(Department_Description_Bind, Department_id));

                }

                //// Loading Data To Data Source
                ddl_departmentdescription.DataSource = departmentdescription;
                ddl_departmentdescription.DataTextField = "Display";
                ddl_departmentdescription.DataValueField = "Value";
                ddl_departmentdescription.DataBind();

                ddl_terminaldepartmentselection.DataSource = TerminalDepartmentSelection;
                ddl_terminaldepartmentselection.DataTextField = "Display";
                ddl_terminaldepartmentselection.DataValueField = "Value";
                ddl_terminaldepartmentselection.DataBind();

                lbl_terminaldepartmentid.Text = Convert.ToString(ddl_terminaldepartmentselection.SelectedValue);

                // Terminal Room Code Combo Box

                DataTable MyTerminalRoom = new DataTable();

                MyTerminalRoom = masterbal.GetRoomCode();


                //roomcode.Add(new AddValue("Select", 0));


                foreach (DataRow dr in MyTerminalRoom.Rows)
                {
                    string Room_Code_Bind = dr["room_code"].ToString();
                    long Room_id = Int32.Parse(dr["room_id"].ToString());

                    roomcode.Add(new AddValue(Room_Code_Bind, Room_id));

                }

                //// Loading Data To Data Source
                ddl_roomcode.DataSource = roomcode;
                ddl_roomcode.DataTextField = "Display";
                ddl_roomcode.DataValueField = "Value";
                ddl_roomcode.DataBind();

                // Terminal Type Combo Box

                DataTable MyTerminalType = new DataTable();

                MyTerminalType = masterbal.GetTerminalTypeDescription();


                //terminaltypedescription.Add(new AddValue("Select", 0));


                foreach (DataRow dr in MyTerminalType.Rows)
                {
                    string Terminal_Type_Bind = dr["terminal_type_desc"].ToString();
                    long Terminal_id = Int32.Parse(dr["terminal_type_id"].ToString());

                    terminaltypedescription.Add(new AddValue(Terminal_Type_Bind, Terminal_id));

                }

                //// Loading Data To Data Source
                ddl_terminaltypedescription.DataSource = terminaltypedescription;
                ddl_terminaltypedescription.DataTextField = "Display";
                ddl_terminaltypedescription.DataValueField = "Value";
                ddl_terminaltypedescription.DataBind();

                btn_terminaledit.Enabled = false;


                DataTable table = new DataTable();
                table.Columns.Add("Display", typeof(string));
                table.Columns.Add("Value", typeof(int));
               
               
                // Here we add five DataRows.
                table.Rows.Add("Y",1);
                table.Rows.Add("N",2);

                foreach (DataRow dr in table.Rows)
                {
                    string Terminal_Type_Bind = dr["Display"].ToString();
                    long Terminal_id = Int32.Parse(dr["Value"].ToString());

                    terminaltypedescription.Add(new AddValue(Terminal_Type_Bind, Terminal_id));

                }
                ddlautologinstatus.DataSource = table;
                ddlautologinstatus.DataTextField = "Display";
                ddlautologinstatus.DataValueField = "Value";
                ddlautologinstatus.DataBind();

             



            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                masterbel = null;
                masterbal = null;
            }

            lbl_terminaldepartmentid.Text = Session["did"].ToString();

            ddl_terminaldepartmentselection.SelectedValue = lbl_terminaldepartmentid.Text;

            TerminalBindGrid();
            Label4.Text = DateTime.Now.ToLongDateString();
            lbl_clientip.Text = GetIP();
            lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
            lbl_userna.Text = Session["uname"].ToString();

            Label2.Text = Session["terdesc"].ToString();
            Label5.Text = Session["dd"].ToString();
            
        }
    }


    #endregion Terminal Master - Page Loading

    // Terminal Master - Get IP Address

    #region Terminal - Get IP Address

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

    #endregion Terminal Master - Get IP Address
    
    // Terminal Master - Save Button Click

    #region Terminal Master - Save Button Click

    protected void btn_terminalsave_Click(object sender, EventArgs e)
    {

        try
        {
            if (lbl_terminalmaster.Text == "N")
            {
                if (txt_terminaldescription.Text != "" && txt_terminalip.Text != "" && ddl_departmentdescription.SelectedItem.Text != "Select" && ddl_roomcode.SelectedItem.Text != "Select" && ddl_terminaltypedescription.SelectedItem.Text != "Select" && lbl_terminalipavailability.Text != "Terminal Ip Already Taken")
                {
                    masterbel.TerminalDescription = txt_terminaldescription.Text;
                    masterbel.TerminalIp = txt_terminalip.Text;
                    masterbel.TerminalDepartmentId = Convert.ToInt16(ddl_departmentdescription.SelectedValue);
                    masterbel.TerminalRoomId = Convert.ToInt16(ddl_roomcode.SelectedValue);
                    masterbel.TerminalTypeId = Convert.ToInt16(ddl_terminaltypedescription.SelectedValue);
                    masterbel.TerminalUpdatedDateTime = DateTime.Now;
                    masterbel.TerminalUpdatedBy = "Admin";
                    if (ddlautologinstatus.SelectedValue == "1")
                    {
                        masterbel.AutoLoginStatus = "Y";
                    }
                    else if (ddlautologinstatus.SelectedValue == "2")
                    {
                        masterbel.AutoLoginStatus = "N";
                    }
                    else
                    {
                        masterbel.AutoLoginStatus = "N";
                    }
                    masterbel.AutoLoginUserName = txt_username.Text;
                    masterbel.AutoLoginPassword = txt_password.Text;

                    TerminalInsert = string.Empty;

                     // Counting Terminal Type Description 

                     DataTable CountingTerminal = masterbal.GettingCountTerminal(masterbel);

                     int count = CountingTerminal.Rows.Count;

                     if (ddl_terminaltypedescription.SelectedValue == "1")
                     {
                         Licence = TerminalCRTLicence + " CRT Users";
                     }
                     else if (ddl_terminaltypedescription.SelectedValue == "2")
                     {
                         Licence = TerminalRTLicence + " RT Users";
                     }
                     else if (ddl_terminaltypedescription.SelectedValue == "3")
                     {
                         Licence = TerminalKIOSKLicence + " KIOSK Users";
                     }

                     if (count <= TerminalCRTLicence && ddl_terminaltypedescription.SelectedValue == "1")
                     {
                         TerminalInsert = masterbal.TerminalInsert(masterbel);
                     }
                     else if (count <= TerminalRTLicence && ddl_terminaltypedescription.SelectedValue == "2")
                     {
                         TerminalInsert = masterbal.TerminalInsert(masterbel);
                     }
                     else if (count <= TerminalKIOSKLicence && ddl_terminaltypedescription.SelectedValue == "3")
                     {
                         TerminalInsert = masterbal.TerminalInsert(masterbel);
                     }
                     else if (ddl_terminaltypedescription.SelectedValue == "4")
                     {
                         TerminalInsert = masterbal.TerminalInsert(masterbel);
                     }
                     else if (ddl_terminaltypedescription.SelectedValue == "5")
                     {
                         TerminalInsert = masterbal.TerminalInsert(masterbel);
                     }
                     else if (ddl_terminaltypedescription.SelectedValue == "6")
                     {
                         TerminalInsert = masterbal.TerminalInsert(masterbel);
                     }
                     else
                     {
                         MessageBox.Show("Licence Is Not Valid For Creating More Than "+ Licence);
                     }

                    if (TerminalInsert != string.Empty)
                    {
                        lbl_terminalmessage.Text = "Records Inserted Successfully";

                        txt_terminaldescription.Text = "";
                        txt_terminalip.Text = "";
                        ddl_departmentdescription.SelectedIndex = 0;
                        ddl_roomcode.SelectedIndex = 0;
                        ddl_terminaltypedescription.SelectedIndex = 0;


                        ddlautologinstatus.SelectedIndex = 0;
                        txt_username.Text = "";
                        txt_password.Text = "";
                        //txt_terminaldescription.ForeColor = System.Drawing.Color.Gray;
                        //txt_terminalip.ForeColor = System.Drawing.Color.Gray;
                        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Gray;
                        //ddl_roomcode.ForeColor = System.Drawing.Color.Gray;
                        //ddl_terminaltypedescription.ForeColor = System.Drawing.Color.Gray;

                        img_terminalipavailability.Visible = false;
                        lbl_terminalipavailability.Visible = false;

                        lbl_terminalmessage.Visible = true;

                        gv_terminalmaster.SelectedIndex = -1;

                        //ddl_departmentdescription.Text = "Select";

                        TerminalBindGrid();

                        //vs_terminalmaster.ShowSummary = false;

                        lbl_terminalmaster.Text = "N";
                    }
                    //else
                    //{
                    //    lbl_terminalmessage.Text = "User Name [<b>" + txt_terminalip.Text + "</b>] already exists, try another name";
                    //}

                }

                else
                {
                    //if (txt_terminaldescription.Text == "Terminal Description")
                    //{
                    //    txt_terminaldescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (txt_terminalip.Text == "Terminal Ip")
                    //{
                    //    txt_terminalip.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_departmentdescription.SelectedItem.Text == "Select")
                    //{
                    //    ddl_departmentdescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_roomcode.SelectedItem.Text == "Select")
                    //{
                    //    ddl_roomcode.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_terminaltypedescription.SelectedItem.Text == "Select")
                    //{
                    //    ddl_terminaltypedescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    if (txt_terminaldescription.Text == "" || txt_terminalip.Text == "" || ddl_departmentdescription.SelectedItem.Text == "Select" || ddl_roomcode.SelectedItem.Text == "Select" || ddl_terminaltypedescription.SelectedItem.Text == "Select")
                    {
                        lbl_terminalmessage.Visible = false;
                        img_terminalipavailability.Visible = false;
                        lbl_terminalipavailability.Visible = false;
                    }
                }

                //vs_terminalmaster.ShowSummary = true;
            }
            if (lbl_terminalmaster.Text == "E")
            {

                if (txt_terminaldescription.Text != "" && txt_terminalip.Text != "" && ddl_departmentdescription.SelectedItem.Text != "Select" && ddl_roomcode.SelectedItem.Text != "Select" && ddl_terminaltypedescription.SelectedItem.Text != "Select")
                {
                    masterbel.TerminalId = Convert.ToInt16(lbl_terminalid.Text);
                    masterbel.TerminalDescription = txt_terminaldescription.Text;
                    masterbel.TerminalIp = txt_terminalip.Text;
                    masterbel.TerminalDepartmentId = Convert.ToInt16(ddl_departmentdescription.SelectedValue);
                    masterbel.TerminalRoomId = Convert.ToInt16(ddl_roomcode.SelectedValue);
                    masterbel.TerminalTypeId = Convert.ToInt16(ddl_terminaltypedescription.SelectedValue);
                    masterbel.TerminalUpdatedDateTime = DateTime.Now;
                    masterbel.TerminalUpdatedBy = "Admin";
                    if (ddlautologinstatus.SelectedValue == "1")
                    {
                        masterbel.AutoLoginStatus = "Y";
                    }
                    else if (ddlautologinstatus.SelectedValue == "2")
                    {
                        masterbel.AutoLoginStatus = "N";
                    }
                    else
                    {
                        masterbel.AutoLoginStatus = "N";
                    }
                    masterbel.AutoLoginUserName = txt_username.Text;
                    masterbel.AutoLoginPassword = txt_password.Text;

                    TerminalUpdate = string.Empty;

                    // Counting Terminal Type Description 

                    DataTable EditCountingTerminal = masterbal.GettingCountTerminal(masterbel);

                    int Editcount = EditCountingTerminal.Rows.Count;

                    if (ddl_terminaltypedescription.SelectedValue == "1")
                    {
                        Licence = TerminalCRTLicence + " CRT";
                    }
                    else if (ddl_terminaltypedescription.SelectedValue == "2")
                    {
                        Licence = TerminalRTLicence + " RT";
                    }
                    else if (ddl_terminaltypedescription.SelectedValue == "3")
                    {
                        Licence = TerminalKIOSKLicence + " KIOSK";
                    }

                    if (Editcount <= TerminalCRTLicence && ddl_terminaltypedescription.SelectedValue == "1")
                    {
                        TerminalUpdate = masterbal.TerminalUpdate(masterbel);
                    }
                    else if (Editcount <= TerminalRTLicence && ddl_terminaltypedescription.SelectedValue == "2")
                    {
                        TerminalUpdate = masterbal.TerminalUpdate(masterbel);
                    }
                    else if (Editcount <= TerminalKIOSKLicence && ddl_terminaltypedescription.SelectedValue == "3")
                    {
                        TerminalUpdate = masterbal.TerminalUpdate(masterbel);
                    }
                    else if (ddl_terminaltypedescription.SelectedValue == "4")
                    {
                        TerminalUpdate = masterbal.TerminalUpdate(masterbel);
                    }
                    else if (ddl_terminaltypedescription.SelectedValue == "5")
                    {
                        TerminalUpdate = masterbal.TerminalUpdate(masterbel);
                    }
                    else if (ddl_terminaltypedescription.SelectedValue == "6")
                    {
                        TerminalUpdate = masterbal.TerminalUpdate(masterbel);
                    }
                    else
                    {
                        MessageBox.Show("Licence Is Not Valid For Creating More Than " + Licence);
                    }

                

                    if (TerminalUpdate != string.Empty)
                    {
                        lbl_terminalmessage.Text = "Records Updated Successfully";

                        txt_terminaldescription.Text = "";
                        txt_terminalip.Text = "";
                        ddl_departmentdescription.SelectedIndex = 0;
                        ddl_roomcode.SelectedIndex = 0;
                        ddl_terminaltypedescription.SelectedIndex = 0;

                        ddlautologinstatus.SelectedIndex = 0;
                        txt_username.Text = "";
                        txt_password.Text = "";

                        //txt_terminaldescription.ForeColor = System.Drawing.Color.Gray;
                        //txt_terminalip.ForeColor = System.Drawing.Color.Gray;
                        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Gray;
                        //ddl_roomcode.ForeColor = System.Drawing.Color.Gray;
                        //ddl_terminaltypedescription.ForeColor = System.Drawing.Color.Gray;

                        txt_terminalip.Enabled = true;

                        img_terminalipavailability.Visible = false;
                        lbl_terminalipavailability.Visible = false;

                        lbl_terminalmessage.Visible = true;

                        gv_terminalmaster.SelectedIndex = -1;

                        TerminalBindGrid();

                        //vs_terminalmaster.ShowSummary = false;

                        lbl_terminalmaster.Text = "N";
                    }
                    else
                    {
                        lbl_terminalmessage.Text = "Terminal Ip [<b>" + txt_terminalip.Text + "</b>] already exists, try another Ip";
                    }

                }
                else
                {
                    //if (txt_terminaldescription.Text == "Terminal Description")
                    //{
                    //    txt_terminaldescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (txt_terminalip.Text == "Terminal Ip")
                    //{
                    //    txt_terminalip.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_departmentdescription.SelectedItem.Text == "Select")
                    //{
                    //    ddl_departmentdescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_roomcode.SelectedItem.Text == "Select")
                    //{
                    //    ddl_roomcode.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_terminaltypedescription.SelectedItem.Text == "Select")
                    //{
                    //    ddl_terminaltypedescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    if (txt_terminaldescription.Text == "" || txt_terminalip.Text == "" || ddl_departmentdescription.SelectedItem.Text == "Select" || ddl_roomcode.SelectedItem.Text == "Select" || ddl_terminaltypedescription.SelectedItem.Text == "Select")
                    {
                        lbl_terminalmessage.Visible = false;
                        img_terminalipavailability.Visible = false;
                        lbl_terminalipavailability.Visible = false;
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            throw ex;
        }
        finally
        {
            masterbal = null;
            masterbel = null;
        }
    }

    #endregion Terminal Master - Save Button Click

    // Terminal Master - Adding Combo Box Items

    #region Terminal Master - AddValue Combo Box

    public class AddValue
    {
        private string m_Display;
        private long m_Value;
        public AddValue(string Display, long Value)
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
    #endregion Terminal Master - AddValue Combo Box

    // Terminal Master - Grid View Loading

    #region Terminal Master - Grid View Loading

    public void TerminalBindGrid()
    {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();
        try
        {
            //Intializing Data Table
            DataTable MyTerminalGridViewBind = new DataTable();

            //MyDeviceGridViewBind = null;

            //if(MyDeviceGridViewBind !=null)
            //{

            masterbel.GettingDepartmentId = Convert.ToInt16(lbl_terminaldepartmentid.Text);

            MyTerminalGridViewBind = masterbal.TerminalGridViewLoading(masterbel);

            //}

            gv_terminalmaster.AutoGenerateColumns = false;

            //gv_terminalmaster.Columns[6].Visible = false;
            //gv_terminalmaster.Columns[7].Visible = false;
            //gv_terminalmaster.Columns[8].Visible = false;


            //Cache["Data"] = MyTerminalGridViewBind;

            gv_terminalmaster.DataSource = MyTerminalGridViewBind;
            gv_terminalmaster.DataBind();

            //MyDeviceGridViewBind = null;

        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {

        }

    }

    #endregion Terminal Master - Grid View Loading

    // Terminal Master - Grid View Selected Index Changed

    #region Terminal Master - Grid View Selected Index Changed

    protected void gv_terminalmaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow Row = gv_terminalmaster.SelectedRow;
        lbl_terminalid.Text = Row.Cells[0].Text;
        txt_terminaldescription.Text = Row.Cells[1].Text;
        txt_terminalip.Text = Row.Cells[2].Text;
        //ddl_departmentdescription.SelectedItem.Text = Row.Cells[3].Text;

        ddl_departmentdescription.SelectedValue = Row.Cells[6].Text;
        ddl_roomcode.SelectedValue = Row.Cells[7].Text;
        ddl_terminaltypedescription.SelectedValue = Row.Cells[8].Text;
        if (Row.Cells[9].Text == "N" || Row.Cells[9].Text == "&nbsp;" || Row.Cells[9].Text == "")
        {
            ddlautologinstatus.SelectedValue = "2";
        }
        else
        {
            ddlautologinstatus.SelectedValue = "1";
        }
        txt_username.Text = Row.Cells[10].Text;
        txt_password.Text = Row.Cells[11].Text;

        txt_terminaldescription.Enabled = false;
        txt_terminalip.Enabled = false;
        ddl_departmentdescription.Enabled = false;
        ddl_roomcode.Enabled = false;
        ddl_terminaltypedescription.Enabled = false;

        ddlautologinstatus.Enabled = false;
        txt_username.Enabled = false;
        txt_password.Enabled = false;

        btn_terminaledit.Enabled = true;
        btn_terminalnew.Enabled = true;
        btn_terminalsave.Enabled = false;

        //txt_terminaldescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_terminalip.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_roomcode.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_terminaltypedescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
    }

    #endregion Terminal Master - Grid View Selected Index Changed

    // Terminal Master - Edit Button Click

    #region Terminal Master - Edit Button Click

    protected void btn_terminaledit_Click(object sender, EventArgs e)
    {
        txt_terminaldescription.Enabled = true;
        txt_terminalip.Enabled = true;
        ddl_departmentdescription.Enabled = true;
        ddl_roomcode.Enabled = true;
        ddl_terminaltypedescription.Enabled = true;

        ddlautologinstatus.Enabled = true;
        txt_username.Enabled = true;
        txt_password.Enabled = true;

        //txt_terminaldescription.ForeColor = System.Drawing.Color.Black;
        //txt_terminalip.ForeColor = System.Drawing.Color.Black;
        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Black;
        //ddl_roomcode.ForeColor = System.Drawing.Color.Black;
        //ddl_terminaltypedescription.ForeColor = System.Drawing.Color.Black;

        btn_terminaledit.Enabled = false;
        btn_terminalnew.Enabled = true;
        btn_terminalsave.Enabled = true;


        lbl_terminalmaster.Text = "E";
    }

    #endregion Terminal Master - Edit Button Click

    // Terminal Master - New Button Click

    #region Terminal Master - New Button Click

    protected void btn_terminalnew_Click(object sender, EventArgs e)
    {
        txt_terminaldescription.Text = "";
        txt_terminalip.Text = "";
        ddl_departmentdescription.SelectedIndex = 0;
        ddl_roomcode.SelectedIndex = 0;
        ddl_terminaltypedescription.SelectedIndex = 0;

        ddlautologinstatus.SelectedIndex = 0;
        txt_username.Text = "";
        txt_password.Text = "";

        //txt_terminaldescription.ForeColor = System.Drawing.Color.Gray;
        //txt_terminalip.ForeColor = System.Drawing.Color.Gray;
        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Gray;
        //ddl_roomcode.ForeColor = System.Drawing.Color.Gray;
        //ddl_terminaltypedescription.ForeColor = System.Drawing.Color.Gray;

        txt_terminaldescription.Enabled = true;
        txt_terminalip.Enabled = true;
        ddl_departmentdescription.Enabled = true;
        ddl_roomcode.Enabled = true;
        ddl_terminaltypedescription.Enabled = true;

        ddlautologinstatus.Enabled = true;
        txt_username.Enabled = true;
        txt_password.Enabled = true;

        btn_terminalsave.Enabled = true;
        btn_terminalnew.Enabled = true;
        btn_terminaledit.Enabled = false;

        lbl_terminalmaster.Text = "N";
      
        lbl_terminalmessage.Visible = false;

        //txt_terminaldescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_terminalip.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_roomcode.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_terminaltypedescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

        gv_terminalmaster.SelectedIndex = -1;

        img_terminalipavailability.Visible = false;
        lbl_terminalipavailability.Visible = false;
    }

    #endregion Terminal Master - New Button Click

    // Terminal Master - Terminal Ip Text Changed

    #region Terminal Master - Terminal Ip Text Changed

    protected void txt_terminalip_TextChanged(object sender, EventArgs e)
        {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();
        DataTable AvailableTerminalIp = new DataTable();

        if (!string.IsNullOrEmpty(txt_terminalip.Text) && lbl_terminalmaster.Text != "E")
        {
            masterbel.TerminalIp = txt_terminalip.Text;

            AvailableTerminalIp = masterbal.AvailableTerminalIp(masterbel);


            if (AvailableTerminalIp.Rows.Count != 0)
            {
                img_terminalipavailability.Visible = true;
                img_terminalipavailability.ImageUrl = "~/images/NotAvailable.jpg";
                lbl_terminalipavailability.Text = "Terminal Ip Already Taken";
                img_terminalipavailability.Width = 17;
                img_terminalipavailability.Height = 17;
                lbl_terminalipavailability.ForeColor = System.Drawing.Color.Red;
                //System.Threading.Thread.Sleep(2000);
            }
            else
            {
                img_terminalipavailability.Visible = true;
                img_terminalipavailability.ImageUrl = "~/images/IconAvailable.jpg";
                lbl_terminalipavailability.Text = "Terminal Ip Available";
                img_terminalipavailability.Width = 17;
                img_terminalipavailability.Height = 17;
                lbl_terminalipavailability.ForeColor = System.Drawing.Color.Green;
                //System.Threading.Thread.Sleep(2000);
            }
        }
        else
        {
            img_terminalipavailability.Visible = false;
            //checkusername.Visible = false;
        }
    }

    #endregion Terminal Master - Terminal Ip Text Changed

    // Terminal Master - Row Data Bound

    //#region Terminal Master - Row Data Bound

    //protected void gv_terminalmaster_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        e.Row.Cells[6].Visible = false;
    //        e.Row.Cells[7].Visible = false;
    //        e.Row.Cells[8].Visible = false;
    //    }
    //}

    //#endregion Terminal Master - Row Data Bound

    // Terminal Master - Page Index Changing

    #region Terminal Master - page Index Changing

    protected void gv_terminalmaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_terminalmaster.PageIndex = e.NewPageIndex;
        //gv_terminalmaster.DataSource = (DataTable)Cache["Data"];
        gv_terminalmaster.DataBind();
        TerminalBindGrid();
    }

    #endregion Terminal Master - Page Index Changing

    // Terminal Master - Terminal Department Selection Selected Index Changed

    #region Terminal Master - Terminal Department Selection Selected Index Changed

    protected void ddl_terminaldepartmentselection_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_terminaldepartmentid.Text = Convert.ToString(ddl_terminaldepartmentselection.SelectedValue);

        TerminalBindGrid();

        gv_terminalmaster.SelectedIndex = -1;

    }

    #endregion Terminal Master - Terminal Department Selection Selected Index Changed

    // Terminal Master - Grid View Row Data Bound

    #region Terminal Master - Grid View Row Data Bound

    protected void gv_terminalmaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
        }
    }

    #endregion Terminal Master - Grid View Row Data Bound
}