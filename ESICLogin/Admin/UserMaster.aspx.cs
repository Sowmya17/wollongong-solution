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

public partial class UserRegistration : System.Web.UI.Page
{

    // User Master - Intiallizing Variables

    #region User Master - Intiallizing Variables

    TextInfo TextInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

    public ArrayList rolldescription = new ArrayList();
    public ArrayList departmentdescription = new ArrayList();
    public ArrayList DepartmentSelection = new ArrayList();

    MasterBEL masterbel = new MasterBEL();
    MasterBAL masterbal = new MasterBAL();
    MasterDAL masterdal = new MasterDAL();

    string UserInsert, UserUpdate;

    #endregion User Master - Intiallizing Variables

    // User Master - Page Loading

    #region User Master - Page Loading

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //MasterBEL masterbel = new MasterBEL();
            //MasterBAL masterbal = new MasterBAL();

            // Initializing Data Table
            DataTable MyRoll = new DataTable();
            DataTable MyDepatment = new DataTable();

            try
            {
                // Roll Description Combo Box

                MyRoll = masterbal.GetRollDescription();

                //rolldescription.Add(new AddValue("Select", 0));

                foreach (DataRow dr in MyRoll.Rows)
                {
                    string Roll_Description_Bind = dr["roll_desc"].ToString();
                    long Roll_id = Int32.Parse(dr["roll_id"].ToString());
                    rolldescription.Add(new AddValue(Roll_Description_Bind, Roll_id));
                }

                //// Loading Data To Data Source
                ddl_rolldescription.DataSource = rolldescription;
                ddl_rolldescription.DataTextField = "Display";
                ddl_rolldescription.DataValueField = "Value";
                ddl_rolldescription.DataBind();

                // lbl_rollid.Text = Convert.ToString(ddl_rolldescription.SelectedValue);

                // Department Description Combo Box

                MyDepatment = masterbal.GetDepartmentDescription();
                //departmentdescription.Add(new AddValue("Select", 0));

                DepartmentSelection.Add(new AddValue("ALL",0));

                foreach (DataRow dr in MyDepatment.Rows)
                {
                    string Department_Description_Bind = dr["department_desc"].ToString();
                    long Department_id = Int32.Parse(dr["department_id"].ToString());

                    departmentdescription.Add(new AddValue(Department_Description_Bind, Department_id));

                    DepartmentSelection.Add(new AddValue(Department_Description_Bind, Department_id));
                }

                // Loading Data To Data Source
                ddl_departmentdescription.DataSource = departmentdescription;
                ddl_departmentdescription.DataTextField = "Display";
                ddl_departmentdescription.DataValueField = "Value";
                ddl_departmentdescription.DataBind();

                ddl_userdepartmentselection.DataSource = DepartmentSelection;
                ddl_userdepartmentselection.DataTextField = "Display";
                ddl_userdepartmentselection.DataValueField = "Value";
                ddl_userdepartmentselection.DataBind();

                lbl_userdepartmentid.Text = Convert.ToString(ddl_userdepartmentselection.SelectedValue);

                //lbl_departmentid.Text = Convert.ToString(ddl_departmentdescription.SelectedValue);
                //ddl_departmentdescription.SelectedIndex = 4;

                lbl_userdepartmentid.Text = Session["did"].ToString();

                ddl_userdepartmentselection.SelectedValue = lbl_userdepartmentid.Text;

                BindGrid();

                btn_useredit.Enabled = false;
                Label4.Text = DateTime.Now.ToLongDateString();
                lbl_clientip.Text = GetIP();
                lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
                lbl_userna.Text = Session["uname"].ToString();

                Label2.Text = Session["terdesc"].ToString();
                Label5.Text = Session["dd"].ToString();

                string currentuser = Session["uname"].ToString();
                byte[] currentuserlogo = null;

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
        }
    }

    #endregion User Master - Page Loading

    // User Master - Get IP Address

    #region User Master - Get IP Address

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

    #endregion User Master - Get IP Address

    // User Master - Save Button Click

    #region User Master - Save Button Click

    protected void btn_usersave_Click(object sender, EventArgs e)
    {
        //MasterBAL masterbal = new MasterBAL();
        //MasterBEL masterbel = new MasterBEL();
        //MasterDAL masterdal = new MasterDAL();

        //DataTable MyInsertDataTable = new DataTable();
        string strpassword = Encryptdata(txt_confirmpassword.Text);
        try
        {
            if (lbl_usermaster.Text == "N")
            {
                if (lbl_usernameavailability.Text == "UserName Available")
                {
                    if (txt_firstname.Text != "" && txt_lastname.Text != "" && txt_username.Text != "" && txt_password.Text != "" && txt_confirmpassword.Text != "" && ddl_rolldescription.SelectedItem.Text != "Select" && ddl_departmentdescription.SelectedItem.Text != "Select" && ddl_userstatus.SelectedItem.Text != "Select")
                    {
                        masterbel.FirstName = txt_firstname.Text;
                        masterbel.LastName = txt_lastname.Text;
                        masterbel.UserName = txt_username.Text.ToLower();
                        masterbel.ConfirmPassword = strpassword;
                        masterbel.RollDescription = Convert.ToInt16(ddl_rolldescription.SelectedValue);
                        masterbel.DepartmentDescription = Convert.ToInt16(ddl_departmentdescription.SelectedValue);

                        if (ddl_userstatus.SelectedIndex == 1)
                        {
                            masterbel.UserStatus = "Y";
                        }
                        if (ddl_userstatus.SelectedIndex == 2)
                        {
                            masterbel.UserStatus = "N";
                        }
                        masterbel.UpdatedDateTime = DateTime.Now;
                        masterbel.UpdatedBy = "Admin";

                        UserInsert = masterbal.Insert(masterbel);

                        if (UserInsert != string.Empty)
                        {
                            lbl_message.Text = "Records Inserted Successfully";

                            txt_firstname.Text = "";
                            txt_lastname.Text = "";
                            txt_username.Text = "";
                            txt_password.Text = "";
                            txt_confirmpassword.Text = "";
                            ddl_rolldescription.SelectedIndex = 0;
                            ddl_departmentdescription.SelectedIndex = 0;
                            ddl_userstatus.SelectedIndex = 0;

                            //txt_firstname.ForeColor = System.Drawing.Color.Gray;
                            //txt_lastname.ForeColor = System.Drawing.Color.Gray;
                            //txt_username.ForeColor = System.Drawing.Color.Gray;
                            //txt_password.ForeColor = System.Drawing.Color.Gray;
                            //txt_confirmpassword.ForeColor = System.Drawing.Color.Gray;
                            //ddl_rolldescription.ForeColor = System.Drawing.Color.Gray;
                            //ddl_departmentdescription.ForeColor = System.Drawing.Color.Gray;
                            //ddl_userstatus.ForeColor = System.Drawing.Color.Gray;

                            lbl_message.Visible = true;

                            gv_usermaster.SelectedIndex = -1;

                            BindGrid();
                        }
                        else
                        {
                            lbl_message.Text = "User Name [<b>" + txt_username.Text + "</b>] already exists, try another name";
                        }
                        //}
                    }

                }

                else
                {
                    //if (txt_firstname.Text == "First Name")
                    //{
                    //    txt_firstname.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (txt_lastname.Text == "Last Name")
                    //{
                    //    txt_lastname.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (txt_username.Text == "User Name")
                    //{
                    //    txt_username.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (txt_password.Text == "" || txt_password.Text == "Password")
                    //{
                    //    txt_password.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (txt_confirmpassword.Text == "" || txt_confirmpassword.Text == "Confirm Password")
                    //{
                    //    txt_confirmpassword.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_rolldescription.SelectedItem.Text == "Select")
                    //{
                    //    ddl_rolldescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_departmentdescription.SelectedItem.Text == "Select")
                    //{
                    //    ddl_departmentdescription.BorderColor = System.Drawing.Color.Red;
                    //}

                    //if (ddl_userstatus.SelectedItem.Text == "Select")
                    //{
                    //    ddl_userstatus.BorderColor = System.Drawing.Color.Red;
                    //}

                    if (txt_firstname.Text == "" || txt_lastname.Text == "" || txt_username.Text == "" || ddl_rolldescription.SelectedItem.Text == "Select" || ddl_departmentdescription.SelectedItem.Text == "Select" || ddl_userstatus.SelectedItem.Text == "Select")
                    {
                        lbl_message.Visible = false;
                        img_usernameavailability.Visible = false;
                        lbl_usernameavailability.Visible = false;
                    }
                }
            }

            if (lbl_usermaster.Text == "E")
            {

                if (txt_firstname.Text != "" && txt_lastname.Text != "" && txt_username.Text != "" && txt_password.Text != "" && txt_confirmpassword.Text != "" && ddl_rolldescription.SelectedItem.Text != "Select" && ddl_departmentdescription.SelectedItem.Text != "Select" && ddl_userstatus.SelectedItem.Text != "Select")
                {
                    masterbel.UserId = Convert.ToInt16(lbl_userid.Text);
                    masterbel.FirstName = txt_firstname.Text;
                    masterbel.LastName = txt_lastname.Text;
                    masterbel.UserName = txt_username.Text;
                    masterbel.ConfirmPassword = strpassword;
                    masterbel.RollDescription = Convert.ToInt16(ddl_rolldescription.SelectedValue);
                    masterbel.DepartmentDescription = Convert.ToInt16(ddl_departmentdescription.SelectedValue);

                    if (ddl_userstatus.SelectedIndex == 1)
                    {
                        masterbel.UserStatus = "Y";
                    }
                    if (ddl_userstatus.SelectedIndex == 2)
                    {
                        masterbel.UserStatus = "N";
                    }
                    masterbel.UpdatedDateTime = DateTime.Now;
                    masterbel.UpdatedBy = "Admin";

                    UserUpdate = masterbal.UserUpdate(masterbel);

                    if (UserUpdate != string.Empty)
                    {
                        lbl_message.Text = "Records Updated Successfully";

                        txt_firstname.Text = "";
                        txt_lastname.Text = "";
                        txt_username.Text = "";
                        //txt_password.Text = "Password";
                        //txt_confirmpassword.Text = "Confirm Password";
                        ddl_rolldescription.SelectedIndex = 0;
                        ddl_departmentdescription.SelectedIndex = 0;
                        ddl_userstatus.SelectedIndex = 0;

                        //txt_firstname.ForeColor = System.Drawing.Color.Gray;
                        //txt_lastname.ForeColor = System.Drawing.Color.Gray;
                        //txt_username.ForeColor = System.Drawing.Color.Gray;
                        //txt_password.ForeColor = System.Drawing.Color.Gray;
                        //txt_confirmpassword.ForeColor = System.Drawing.Color.Gray;
                        //ddl_rolldescription.ForeColor = System.Drawing.Color.Gray;
                        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Gray;
                        //ddl_userstatus.ForeColor = System.Drawing.Color.Gray;

                        txt_password.Attributes.Add("value", "Password");
                        txt_confirmpassword.Attributes.Add("value", "Confirm Password");

                        txt_username.Enabled = true;

                        lbl_message.Visible = true;

                        gv_usermaster.SelectedIndex = -1;


                        BindGrid();

                        lbl_usermaster.Text = "N";

                        //vs_departmentmaster.ShowSummary = false;
                    }
                    else
                    {
                        lbl_message.Text = "User Name [<b>" + txt_username.Text + "</b>] already exists, try another name";
                    }

                }

            }

            else
            {
                //if (txt_firstname.Text == "First Name")
                //{
                //    txt_firstname.BorderColor = System.Drawing.Color.Red;
                //}

                //if (txt_lastname.Text == "Last Name")
                //{
                //    txt_lastname.BorderColor = System.Drawing.Color.Red;
                //}

                //if (txt_username.Text == "User Name")
                //{
                //    txt_username.BorderColor = System.Drawing.Color.Red;
                //}

                //if (txt_password.Text == "" || txt_password.Text == "Password")
                //{
                //    txt_password.BorderColor = System.Drawing.Color.Red;
                //}

                //if (txt_confirmpassword.Text == "" || txt_confirmpassword.Text == "Confirm Password")
                //{
                //    txt_confirmpassword.BorderColor = System.Drawing.Color.Red;
                //}

                //if (ddl_rolldescription.SelectedItem.Text == "Select")
                //{
                //    ddl_rolldescription.BorderColor = System.Drawing.Color.Red;
                //}

                //if (ddl_departmentdescription.SelectedItem.Text == "Select")
                //{
                //    ddl_departmentdescription.BorderColor = System.Drawing.Color.Red;
                //}

                //if (ddl_userstatus.SelectedItem.Text == "Select")
                //{
                //    ddl_userstatus.BorderColor = System.Drawing.Color.Red;
                //}

                if (txt_firstname.Text == "" || txt_lastname.Text == "" || txt_username.Text == "" || ddl_rolldescription.SelectedItem.Text == "Select" || ddl_departmentdescription.SelectedItem.Text == "Select" || ddl_userstatus.SelectedItem.Text == "Select")
                {
                    lbl_message.Visible = false;
                    img_usernameavailability.Visible = false;
                    lbl_usernameavailability.Visible = false;
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
            masterdal = null;
        }
    }

    #endregion Save Button Click

    // User Master - Adding Combo Box Items

    #region User Master - AddValue Combo Box

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
    #endregion User Master - AddValue Combo Box

    // User Master - Encrypting Password

    #region User Master - Encrypting Password

    private string Encryptdata(string password)
    {
        string strmsg = string.Empty;
        byte[] encode = new
        byte[password.Length];
        encode = Encoding.UTF8.GetBytes(password);
        strmsg = Convert.ToBase64String(encode);
        return strmsg;
    }

    #endregion User Master - Encrypting Password

    // User Master - Decrypting Password

    #region User Master - Decrypting Password

    private string Decryptdata(string encryptpwd)
    {
        string decryptpwd = string.Empty;

        UTF8Encoding encodepwd = new UTF8Encoding();
        System.Text.Decoder utf8Decode = encodepwd.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        decryptpwd = new String(decoded_char);
        return decryptpwd;
    }

    #endregion User Master - Decrypting Password

    // User Master - User Name Text Change

    #region User Master - User Name Text Change

    protected void txt_username_TextChanged(object sender, EventArgs e)
    {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();
        DataTable AvailableUserName = new DataTable();

        if (!string.IsNullOrEmpty(txt_username.Text))
        {
            masterbel.UserName = txt_username.Text;

            AvailableUserName = masterbal.AvailableUserName(masterbel);


            if (AvailableUserName.Rows.Count != 0)
            {
                img_usernameavailability.Visible = true;
                img_usernameavailability.ImageUrl = "~/images/NotAvailable.jpg";
                lbl_usernameavailability.Text = "UserName Already Taken";
                img_usernameavailability.Width = 17;
                img_usernameavailability.Height = 17;
                lbl_usernameavailability.ForeColor = System.Drawing.Color.Red;
                //System.Threading.Thread.Sleep(2000);
            }
            else
            {
                img_usernameavailability.Visible = true;
                img_usernameavailability.ImageUrl = "~/images/IconAvailable.jpg";
                lbl_usernameavailability.Text = "UserName Available";
                img_usernameavailability.Width = 17;
                img_usernameavailability.Height = 17;
                lbl_usernameavailability.ForeColor = System.Drawing.Color.Green;
                //System.Threading.Thread.Sleep(2000);
            }
        }
        else
        {
            img_usernameavailability.Visible = false;
            //checkusername.Visible = false;
        }
    }

    #endregion User Master - User Name Text Change

    // User Master - User Name Bind Grid View

    #region User Master - User Name Bind Grid View

    public void BindGrid()
    {
        try
        {
            MasterBEL masterbel = new MasterBEL();
            MasterBAL masterbal = new MasterBAL();

            //Intializing Data Table
            DataTable MyGridViewBind = new DataTable();

            masterbel.GettingDepartmentId = Convert.ToInt16(lbl_userdepartmentid.Text);

            MyGridViewBind = masterbal.UserGridViewLoading(masterbel);

            foreach (DataRow dr in MyGridViewBind.Rows)
            {
                if (dr["user_active"].ToString() == "Y")
                {
                    dr["user_active"] = "Active";
                }
                if (dr["user_active"].ToString() == "N")
                {
                    dr["user_active"] = "In-Active";
                }
            }

            gv_usermaster.AutoGenerateColumns = false;

            //SqlDataAdapter MyDataAdapter = new SqlDataAdapter("Select * from employeedetails", MySqlConnection);
            //DataSet ds = new DataSet();
            //MyDataAdapter.Fill(ds);

            //gv_usermaster.Columns[7].Visible = true;
            //grid0.DataSource = dt;
            //grid0.DataBind();
            //grid0.Columns[0].Visible = false;

            //gv_usermaster.Columns[7].Visible = false;
            //gv_usermaster.Columns[8].Visible = false;
            //gv_usermaster.Columns[9].Visible = false;

            gv_usermaster.DataSource = MyGridViewBind;
            gv_usermaster.DataBind();



            //Cache["Data"] = MyGridViewBind;

            //gv_usermaster.Columns[7].Visible = false;
        }

        catch (Exception ex)
        {
            ex.ToString();
        }

        finally
        {

        }

    }

    #endregion User Master - User Name Bind Grid View

    // User Master - New Button Click Event

    #region User Master - New Button Click Event

    protected void btn_usernew_Click(object sender, EventArgs e)
    {
        txt_firstname.Text = "";
        txt_lastname.Text = "";
        txt_username.Text = "";
        txt_password.Attributes["value"] = "";
        txt_confirmpassword.Attributes["value"] = "";
        ddl_rolldescription.SelectedIndex = 0;
        ddl_departmentdescription.SelectedIndex = 0;
        ddl_userstatus.SelectedIndex = 0;

        //txt_firstname.ForeColor = System.Drawing.Color.Gray;
        //txt_lastname.ForeColor = System.Drawing.Color.Gray;
        //txt_username.ForeColor = System.Drawing.Color.Gray;
        //txt_password.ForeColor = System.Drawing.Color.Gray;
        //txt_confirmpassword.ForeColor = System.Drawing.Color.Gray;
        //ddl_rolldescription.ForeColor = System.Drawing.Color.Gray;
        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Gray;
        //ddl_userstatus.ForeColor = System.Drawing.Color.Gray;

        txt_firstname.Enabled = true;
        txt_lastname.Enabled = true;
        txt_username.Enabled = true;
        txt_password.Enabled = true;
        txt_confirmpassword.Enabled = true;
        ddl_rolldescription.Enabled = true;
        ddl_departmentdescription.Enabled = true;
        ddl_userstatus.Enabled = true;

        btn_usersave.Enabled = true;
        btn_usernew.Enabled = true;
        btn_useredit.Enabled = false;

        lbl_usermaster.Text = "N";

        lbl_message.Visible = false;

        //txt_firstname.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_lastname.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_username.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_password.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_confirmpassword.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_rolldescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_userstatus.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

        gv_usermaster.SelectedIndex = -1;

        img_usernameavailability.Visible = false;
        lbl_usernameavailability.Visible = false;

        //txt_firstname.BorderColor = System.Drawing.Color.Black;

        //txt_firstname.style.border = "2px Solid #0379B5";
    }

    #endregion User Master - New Button Click Event

    // User Master - Grid View Selected Index Changed

    #region User Master - Grid View Selected Index Changed

    protected void gv_usermaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();

        //string outlookid = ((HiddenField)e.Row.FindControl("HiddenOutlookID")).Value;

        GridViewRow Row = gv_usermaster.SelectedRow;

        lbl_userid.Text = Row.Cells[0].Text;
        txt_firstname.Text = Row.Cells[2].Text;
        txt_lastname.Text = Row.Cells[3].Text;
        txt_username.Text = Row.Cells[1].Text;

        //string data = GridView.DataKeys[RowIndex].Values[KeyIndex];

        //string Passwords = gv_usermaster.DataKeys[Row.RowIndex].Values.ToString();

        //int EmployeeID = Convert.ToInt32(gv_usermaster.DataKeys[RowIndex]["user_pwd"]);


        //gv_usermaster.Columns[7].Visible = true;

        string decryptpassword = Decryptdata(Row.Cells[7].Text);

        //gv_usermaster.Columns[7].Visible = false;

        //Row.Cells[7].Text = Decryptdata(decryptpassword);
        //txt_password.Text = "";
        //txt_confirmpassword.Text = "";

        txt_password.Attributes.Add("value", decryptpassword);
        txt_confirmpassword.Attributes.Add("value", decryptpassword);

        //txt_password.Text = decryptpassword;
        //txt_confirmpassword.Text = decryptpassword;

        ddl_rolldescription.SelectedValue = Row.Cells[8].Text;

        //string rolldescription = Row.Cells[4].Text;
        //ddl_rolldescription.DataTextField = Row.Cells[4].Text;

        //ddl_rolldescription.Text = gv_usermaster.SelectedRow[0].Cells[4].ToString();
        //ddl_rolldescription.DataValueField = TextInfo.ToTitleCase(Row.Cells[4].Text);

        ddl_departmentdescription.SelectedValue = Row.Cells[9].Text;

        if (Row.Cells[6].Text == "Active")
        {
            ddl_userstatus.SelectedIndex = 1;
        }
        if (Row.Cells[6].Text == "In-Active")
        {
            ddl_userstatus.SelectedIndex = 2;
        }

        //if (Row.Cells[6].Text == "Y")
        //{
        //    ddl_userstatus.SelectedIndex = 1;
        //}
        //else if (Row.Cells[6].Text == "N")
        //{
        //    ddl_userstatus.SelectedIndex = 2;
        //}

        //if (masterbel.RollDescription == "O")
        //{
        //    ddl_plazatolltype.SelectedIndex = 1;
        //}
        //else if (masterview.GetPlazaTollType == "C")
        //{
        //    ddl_plazatolltype.SelectedIndex = 2;
        //}

        //btn_update.Enabled = true;
        //btn_delete.Enabled = true;

        txt_firstname.Enabled = false;
        txt_lastname.Enabled = false;
        //txt_username.Enabled = false;
        txt_password.Enabled = false;
        txt_confirmpassword.Enabled = false;
        ddl_rolldescription.Enabled = false;
        ddl_departmentdescription.Enabled = false;
        ddl_userstatus.Enabled = false;

        btn_useredit.Enabled = true;
        btn_usernew.Enabled = true;
        btn_usersave.Enabled = false;

        //txt_firstname.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_lastname.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_username.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_password.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_confirmpassword.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_rolldescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_departmentdescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //ddl_userstatus.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

    }

    #endregion User Master - Grid View Selected Index Changed

    // User Master - Grid View Row Data Bound

    #region User Master - Grid View Row Data Bound

    protected void gv_usermaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
            e.Row.Cells[9].Visible = false;

            //gv_usermaster.Columns[7].Visible = false;
            //gv_usermaster.Columns[8].Visible = false;
            //gv_usermaster.Columns[9].Visible = false;
        }
    }

    #endregion User Master - Grid View Row Data Bound

    // User Master - Edit Button Click

    #region User Master - Edit Button Click

    protected void btn_useredit_Click(object sender, EventArgs e)
    {
        txt_firstname.Enabled = true;
        txt_lastname.Enabled = true;
        txt_username.Enabled = true;
        txt_password.Enabled = true;
        txt_confirmpassword.Enabled = true;
        ddl_rolldescription.Enabled = true;
        ddl_departmentdescription.Enabled = true;
        ddl_userstatus.Enabled = true;

        //txt_firstname.ForeColor = System.Drawing.Color.Black;
        //txt_lastname.ForeColor = System.Drawing.Color.Black;
        //txt_username.ForeColor = System.Drawing.Color.Black;
        //txt_password.ForeColor = System.Drawing.Color.Black;
        //txt_confirmpassword.ForeColor = System.Drawing.Color.Black;
        //ddl_rolldescription.ForeColor = System.Drawing.Color.Black;
        //ddl_departmentdescription.ForeColor = System.Drawing.Color.Black;
        //ddl_userstatus.ForeColor = System.Drawing.Color.Black;

        btn_useredit.Enabled = false;
        btn_usernew.Enabled = true;
        btn_usersave.Enabled = true;

        lbl_usermaster.Text = "E";
    }

    #endregion User Master - Edit Button Click

    // User Master - Page Index Changing

    #region User Master - Page Index Changing

    protected void gv_usermaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        BindGrid();

        gv_usermaster.PageIndex = e.NewPageIndex;
        //gv_usermaster.DataSource = (DataTable)Cache["Data"];
        gv_usermaster.DataBind();


    }

    #endregion User Master - Page Index Changing


    //protected void gv_usermaster_DataBound(object sender, EventArgs e)
    //{
    //    const int countriesColumnIndex = 7;

    //    //if (someCondition == true)
    //    //{
    //        // Hide the Countries column
    //    this.gv_usermaster.Columns[countriesColumnIndex].Visible = false;
    //    //}
    //}



    // User Master - Department Selection Selected Index Changed

    #region User Master - Department Selection Selected Index Changed

    protected void ddl_userdepartmentselection_SelectedIndexChanged(object sender, EventArgs e)
    {
        lbl_userdepartmentid.Text = Convert.ToString(ddl_userdepartmentselection.SelectedValue);

        BindGrid();

        gv_usermaster.SelectedIndex = -1;
    }

    #endregion User Master - Department Selection Selected Index Changed

}
