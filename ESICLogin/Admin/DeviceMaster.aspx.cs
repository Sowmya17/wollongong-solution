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

public partial class DeviceMaster : System.Web.UI.Page
{

    // Initializing Variables

    #region Initializing Variables
    
    TextInfo TextInfo = Thread.CurrentThread.CurrentCulture.TextInfo;

    MasterBAL masterbal = new MasterBAL();
    MasterBEL masterbel = new MasterBEL();

    //int DeviceID;
    string DeviceUpdate,DeviceInsert;

    #endregion Initializing

    // Device Master - Page Loading
  
    #region Device Master - Page Loading

    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable MyLoad = new DataTable();

        if (!IsPostBack)
        {

            DeviceBindGrid();

            // Roll Description Combo Box

            //MyLoad = masterbal.GetRollDescription();

            btn_deviceedit.Enabled = false;
            Label4.Text = DateTime.Now.ToLongDateString();
            lbl_clientip.Text = GetIP();
            lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
            lbl_userna.Text = Session["uname"].ToString();

            Label2.Text = Session["terdesc"].ToString();
            Label5.Text = Session["dd"].ToString();

        }
    }

    #endregion Device Master - Page Loading

    // Device Master - Getting IP Address

    #region Device Master - Getting IP Address

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

    #endregion Device Master - Getting IP Address
    
    // Device Master - Save Button Click

    #region Device Master - Save Button Click

    protected void btn_devicesave_Click(object sender, EventArgs e)
    {
        //DataTable DeviceInsertData = new DataTable();
        //DataTable DeviceUpdateData = new DataTable();

        try
        {
            if (lbl_devicemaster.Text == "N")
            {
                if (txt_devicename.Text != "")
                {
                    masterbel.DeviceName = txt_devicename.Text;
                    //masterbel.DeviceDescription = txt_devicedescription.Text;

                    if (txt_devicedescription.Text == "")
                    {
                        masterbel.DeviceDescription = string.Empty.Trim();
                    }
                    else
                    {
                        masterbel.DeviceDescription = txt_devicedescription.Text;
                    }
                    masterbel.DeviceUpdatedDateTime = DateTime.Now;
                    masterbel.DeviceUpdatedBy = "Admin";

                    DeviceInsert = masterbal.DeviceInsert(masterbel);

                    if (DeviceInsert != string.Empty)
                    {
                        lbl_devicemessage.Text = "Records Inserted Successfully";

                        txt_devicename.Text = "";
                        txt_devicedescription.Text = "";

                        //txt_devicename.ForeColor = System.Drawing.Color.Gray;
                        //txt_devicedescription.ForeColor = System.Drawing.Color.Gray;

                        //txt_devicename.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
                        
                        lbl_devicemessage.Visible = true;

                        gv_devicemaster.SelectedIndex = -1;


                        DeviceBindGrid();

                        //vs_devicemaster.ShowSummary = false;
                    }
                    else
                    {
                        lbl_devicemessage.Text = "User Name [<b>" + txt_devicename.Text + "</b>] already exists, try another name";
                    }

                }

                else
                {
                    //if (txt_devicename.Text == "Device Name")
                    //{
                    //    txt_devicename.BorderColor = System.Drawing.Color.Red;
                    //}
                    //else
                    //{
                    //    txt_devicename.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
                    //    txt_devicename.ForeColor = System.Drawing.Color.Black;
                    //}

                    //if (txt_devicedescription.Text == "Device Description")
                    //{
                    //    txt_devicedescription.BorderColor = System.Drawing.Color.Red;
                    //}
                    //else
                    //{
                    //    txt_devicedescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
                    //    txt_devicedescription.ForeColor = System.Drawing.Color.Black;
                    //}

                    //if (txt_devicename.Text == "Device Name" || txt_devicedescription.Text == "Device Description")
                    if (txt_devicename.Text == "")
                    {
                        lbl_devicemessage.Visible = false;
                    }
                }

                //vs_devicemaster.ShowSummary = true;
                //btn_devicesave.Attributes.Add("onclick", "this.disabled=false;return false");
            }
            if(lbl_devicemaster.Text == "E")
            {

                if (txt_devicename.Text != "")
                {
                    masterbel.DeviceId = Convert.ToInt16(lbl_deviceid.Text);
                    masterbel.DeviceName = txt_devicename.Text;
                    //masterbel.DeviceDescription = txt_devicedescription.Text;

                    if (txt_devicedescription.Text == "")
                    {
                        masterbel.DeviceDescription = string.Empty.Trim();
                    }
                    else
                    {
                        masterbel.DeviceDescription = txt_devicedescription.Text;
                    }
                    masterbel.DeviceUpdatedDateTime = DateTime.Now;
                    masterbel.DeviceUpdatedBy = "Admin";

                    DeviceUpdate = masterbal.DeviceUpdate(masterbel);

                    if (DeviceUpdate != string.Empty)
                    {
                        lbl_devicemessage.Text = "Records Updated Successfully";

                        txt_devicename.Text = "";
                        txt_devicedescription.Text = "";

                        //txt_devicename.ForeColor = System.Drawing.Color.Gray;
                        //txt_devicedescription.ForeColor = System.Drawing.Color.Gray;

                        //txt_devicename.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

                        lbl_devicemessage.Visible = true;

                        gv_devicemaster.SelectedIndex = -1;

                        DeviceBindGrid();

                        lbl_devicemaster.Text = "N";

                        //vs_devicemaster.ShowSummary = false;
                    }
                    else
                    {
                        lbl_devicemessage.Text = "User Name [<b>" + txt_devicename.Text + "</b>] already exists, try another name";
                    }

                }

                else
                {
                    //if (txt_devicename.Text == "Device Name")
                    //{
                    //    txt_devicename.BorderColor = System.Drawing.Color.Red;
                    //}
                    //else
                    //{
                    //    txt_devicename.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
                    //    txt_devicename.ForeColor = System.Drawing.Color.Black;
                    //}

                    //if (txt_devicedescription.Text == "Device Description")
                    //{
                    //    txt_devicedescription.BorderColor = System.Drawing.Color.Red;
                    //}
                    //else
                    //{
                    //    txt_devicedescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
                    //    txt_devicedescription.ForeColor = System.Drawing.Color.Black;
                    //}

                    //if (txt_devicename.Text == "Device Name" || txt_devicedescription.Text == "Device Description")
                    if (txt_devicename.Text == "")
                    {
                        lbl_devicemessage.Visible = false;
                    }
                }

                //vs_devicemaster.ShowSummary=true;
            }

            //txt_devicename.BorderColor = System.Drawing.Color.Red;
            //txt_devicedescription.BorderColor = System.Drawing.Color.Red;

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

    #endregion Device Master - Save Button Click

    // Device Master - New Button Click

    #region Device Master - New Button Click

    protected void btn_devicenew_Click(object sender, EventArgs e)
    {
        txt_devicename.Text = "";
        txt_devicedescription.Text = "";

        //txt_devicename.ForeColor = System.Drawing.Color.Gray;
        //txt_devicedescription.ForeColor = System.Drawing.Color.Gray;
              

        txt_devicename.Enabled = true;
        txt_devicedescription.Enabled = true;

        
        btn_devicesave.Enabled = true;
        btn_devicenew.Enabled = true;
        btn_deviceedit.Enabled = false;

        lbl_devicemaster.Text = "N";

        lbl_devicemessage.Visible = false;

        //txt_devicename.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_devicedescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);

        gv_devicemaster.SelectedIndex = -1;


        //txt_devicename.Style.border = "2px Solid #0379B5";
        //txt_devicename.BorderColor=System.Drawing.Color. #0379B5;

        //vs_devicemaster.ShowSummary = false;
        // vs_devicemaster.EnableViewState = false;
        //vs_devicemaster.ShowSummary = false;


        
    }

    #endregion Device Master - New Button Click

    // Device Master - Grid View Binding

    #region Device Master - Grid View Binding

   public void DeviceBindGrid()
    {
        try
        {
            //Intializing Data Table
            DataTable MyDeviceGridViewBind = new DataTable();

            //MyDeviceGridViewBind = null;

            //if(MyDeviceGridViewBind !=null)
            //{

            MyDeviceGridViewBind = masterbal.DeviceGridViewLoading(masterbel);

            //}

            gv_devicemaster.AutoGenerateColumns = false;


            gv_devicemaster.DataSource = MyDeviceGridViewBind;
            gv_devicemaster.DataBind();

            //MyDeviceGridViewBind = null;
            
        }
        catch
        {
            throw;
        }
        finally
        {
          
        }

    }

    #endregion Device Master - Grid View Binding

    // Device Master - Grid View Selected Index Changed

    #region Device Master - Grid View Selected Index Changed

    protected void gv_devicemaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow DeviceRow = gv_devicemaster.SelectedRow;

        lbl_deviceid.Text = DeviceRow.Cells[0].Text;
        
        txt_devicename.Text = DeviceRow.Cells[1].Text;

        if(DeviceRow.Cells[2].Text == "&nbsp;")
        {
        txt_devicedescription.Text = string.Empty;
        }
        else
        {
            txt_devicedescription.Text = DeviceRow.Cells[2].Text;
        }

        txt_devicename.Enabled = false;
        txt_devicedescription.Enabled = false;

        btn_deviceedit.Enabled = true;
        btn_devicenew.Enabled = true;
        btn_devicesave.Enabled = false;

        //txt_devicename.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        //txt_devicedescription.BorderColor = System.Drawing.Color.FromArgb(0x0379B5);
        
    }

    #endregion Device Master - Grid View Selected Index Changed

    // Device Master - Edit Button Click

    #region Device Master - Edit Button Click

    protected void btn_deviceedit_Click(object sender, EventArgs e)
    {
        txt_devicename.Enabled = true;
        txt_devicedescription.Enabled = true;

        //txt_devicename.ForeColor = System.Drawing.Color.Black;
        //txt_devicedescription.ForeColor = System.Drawing.Color.Black;
                
        btn_deviceedit.Enabled = false;
        btn_devicenew.Enabled = true;
        btn_devicesave.Enabled = true;

        lbl_devicemaster.Text = "E";

        //vs_devicemaster.ShowSummary = false;
    }

    #endregion Device Master - Edit Button Click

    // Device Master - Page Index Changing

    #region Device Master - Page Index Changing

    protected void gv_devicemaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_devicemaster.PageIndex = e.NewPageIndex;
        //gv_usermaster.DataSource = (DataTable)Cache["Data"];
        gv_devicemaster.DataBind();

        DeviceBindGrid();
    }

    #endregion Device Master - Page Index Changing

}