using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.Collections;
using System.Globalization;

public partial class Admin_ContentManagement : System.Web.UI.Page
{
    MasterBAL masterbal = new MasterBAL();
    MasterBEL masterbel = new MasterBEL();
    string updatestatus;
    string _currentUsername;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = DateTime.Now.ToLongDateString();
        lbl_clientip.Text = GetIP();
        lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
        lbl_userna.Text = Session["uname"].ToString();

        _currentUsername = Session["uname"].ToString();
        Label2.Text = Session["terdesc"].ToString();
        Label5.Text = Session["dd"].ToString();

        BindTerminalDropdown();
        ContentBind();
    }

    private void BindTerminalDropdown()
    {
        DataTable terminalDescription = new DataTable();
        terminalDescription = masterbal.GetTerminalDesc();
        drpdwn_TerminalDesc.DataSource = terminalDescription;
        drpdwn_TerminalDesc.DataBind();
        for (int i = 0; i < 10; i++)
        {
            drpdwn_Order.Items.Add(i.ToString());
        }
    }

    protected void btn_Contentnew_Click(object sender, EventArgs e)
    {
        btn_Contentnew.Enabled = true;
        btn_Contentsave.Enabled = true;
        btn_Contentedit.Enabled = false;
        txt_Textname.Text = "";
        txt_TextDescription.Text = "";
        txt_ScrollingText.Text = "";
        drpdwn_TerminalDesc.SelectedIndex = 0;
        drpdwn_Order.SelectedIndex = 0;
        lbl_contentmaster.Text = "N";
        
               
    }
    
    protected void btn_Contentedit_Click(object sender, EventArgs e)
    {
        btn_Contentnew.Enabled = false;
        btn_Contentsave.Enabled = true;
        btn_Contentedit.Enabled = true;
        txt_Textname.Enabled = true;
        txt_TextDescription.Enabled = true;
        txt_ScrollingText.Enabled = true;
        drpdwn_Order.Enabled = true;
        drpdwn_TerminalDesc.Enabled = true;
        lbl_contentmaster.Text = "E";
    }
    protected void btn_Contentsave_Click(object sender, EventArgs e)
    {
        MasterBEL contentbel = new MasterBEL();
        string startTime = " 12:00 AM";
        string endTime = " 11:59 PM";
        string rollingDate = Page.Request.Form["example1"];
        string rollingStartDate = String.Format(rollingDate + startTime);
        string rollingEndDate = String.Format(rollingDate + endTime);
        DateTime datStart = DateTime.Parse(rollingStartDate);
        DateTime datEnd = DateTime.Parse(rollingEndDate);
        contentbel.ContentName = txt_Textname.Text;
        contentbel.ContentDesc = txt_TextDescription.Text;
        contentbel.ContentText = txt_ScrollingText.Text;
        contentbel.ContentTerminalId = Convert.ToInt16(drpdwn_TerminalDesc.SelectedValue);
        contentbel.ContentOrderId = Convert.ToInt16(drpdwn_Order.SelectedValue);
        DateTime dat = Convert.ToDateTime(rollingDate);
        contentbel.ContentDay = dat.DayOfWeek.ToString();

        contentbel.ContentStartTime = datStart;
        contentbel.ContentEndTime = datEnd;
        contentbel.ContentActive = 'Y';

        if (lbl_contentmaster.Text == "N")
        {
            updatestatus = masterbal.AddContent(contentbel);
            if (updatestatus != string.Empty)
            {
                lbl_Status.Text = "Records Added Successfully.";

            }
        }
        else
        {
            masterbel.ContentId = Convert.ToInt16(lbl_ContentId.Text);
            updatestatus = masterbal.ContentUpdate(masterbel);
            if (updatestatus != string.Empty)
            {
                lbl_Status.Text = "Records Updated Successfully.";

                //binding

                txt_Textname.Text = "";
                txt_TextDescription.Text = "";
                txt_ScrollingText.Text = "";
                drpdwn_TerminalDesc.SelectedIndex = 0;
                drpdwn_Order.SelectedIndex = 0;
                lbl_contentmaster.Text = "N";
            }

        }
        ContentBind();

    }
    
    protected void gv_ContentMaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_ContentMaster.PageIndex = e.NewPageIndex;
        gv_ContentMaster.DataBind();
    }
    protected void gv_ContentMaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }
    protected void gv_ContentMaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        MasterBAL bal = new MasterBAL();
        txt_Textname.Enabled = false;
        txt_TextDescription.Enabled = false;
        txt_ScrollingText.Enabled = false;
        drpdwn_Order.Enabled = false;
        drpdwn_TerminalDesc.Enabled = false;
        GridViewRow row = gv_ContentMaster.SelectedRow;
        int contentId = Convert.ToInt32(row.Cells[0].Text);
        DataTable dt = new DataTable();
        dt = bal.GetContentbyId(contentId);
        foreach (DataRow dr in dt.Rows)
        {
            txt_Textname.Text = dr["content_name"].ToString();
            txt_TextDescription.Text = dr["content_desc"].ToString();
            txt_ScrollingText.Text = dr["content_text"].ToString();
            drpdwn_Order.SelectedValue = dr["content_order_id"].ToString();
        }
        lbl_ContentId.Text = Convert.ToString(contentId);
    }

    #region Content - Get IP Address

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

    #endregion Content Master - Get IP Address

    // Content Master - Grid View Loading

    #region Content Master - Grid View Loading

    public void ContentBind()
    {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();
       
        DataTable MyContentGridViewBind = new DataTable();

        MyContentGridViewBind = masterbal.ContentGridViewLoading();

        gv_ContentMaster.AutoGenerateColumns = false;
        gv_ContentMaster.DataSource = MyContentGridViewBind;
        gv_ContentMaster.DataBind();
        gv_ContentMaster.SelectedIndex = 0;
    }

    #endregion Content Master - Grid View Loading
}