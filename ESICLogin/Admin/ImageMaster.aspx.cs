using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.Collections;

public partial class Admin_ImageMaster : System.Web.UI.Page
{
    #region Intiallizing Variables
    MasterBAL masterbal = new MasterBAL();
    MasterBEL masterbel = new MasterBEL();
    byte[] imgbyte;
    string updatestatus;
    public ArrayList ImageList = new ArrayList();
    string _currentUsername;

    public int imageid1;

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        Label4.Text = DateTime.Now.ToLongDateString();
        lbl_clientip.Text = GetIP();
        lbl_instanceip.Text = HttpContext.Current.Request.UserHostAddress;
        lbl_userna.Text = Session["uname"].ToString();

        _currentUsername = Session["uname"].ToString();
        Label2.Text = Session["terdesc"].ToString();
        Label5.Text = Session["dd"].ToString();

        ImageBind();
    }


    public void ImageBind()
    {
        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();
            
            
        DataTable MyImageGridViewBind = new DataTable();

        MyImageGridViewBind = masterbal.ImageGridViewLoading();
        gv_imagemaster.AutoGenerateColumns = false;
        gv_imagemaster.DataSource = MyImageGridViewBind;
        gv_imagemaster.DataBind();
        gv_imagemaster.SelectedIndex = 0;
    }
    #region Image - Get IP Address

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

    #endregion Image Master - Get IP Address

    

    // Image Master - Grid View Selected Index Changed

    #region Image Master - Grid View Selected Index Changed

    protected void gv_imagemaster_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_imagename.Enabled = false;
        txt_ImageDescription.Enabled = false;
        GridViewRow Row = gv_imagemaster.SelectedRow;
        txt_imagename.Text = Row.Cells[1].Text;
        txt_ImageDescription.Text = Row.Cells[2].Text;
        btn_imageedit.Enabled = true;
        btn_imagenew.Enabled = true;
        btn_imagesave.Enabled = false;
        fileMyFile.Enabled = false;

        lbl_ImageId.Text = Row.Cells[0].Text;
    }

    #endregion Image Master - Grid View Selected Index Changed


    protected void gv_imagemaster_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gv_imagemaster.PageIndex = e.NewPageIndex;
        //gv_usermaster.DataSource = (DataTable)Cache["Data"];
        gv_imagemaster.DataBind();


    }

    protected void gv_imagemaster_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
        {
        }
    }

    protected void btn_imagenew_Click(object sender, EventArgs e)
    {
        txt_imagename.Text = "";
        txt_ImageDescription.Text = "";
        btn_imagesave.Enabled = true;
        lbl_imagemaster.Text = "N";
        lbl_Status.Text = "";
        fileMyFile.Enabled = true;
    }

    protected void btn_imageedit_Click(object sender, EventArgs e)
    {
        txt_imagename.Enabled = true;
        txt_ImageDescription.Enabled = true;
        lbl_imagemaster.Text = "E";
        lbl_Status.Text = "";
        lbl_imagemaster.Enabled = false;
        btn_imagesave.Enabled = true;
        fileMyFile.Enabled = true;
    }

    protected void btn_imagesave_Click(object sender, EventArgs e)
    {
        if (fileMyFile.HasFile == true)
        {
            HttpPostedFile img = fileMyFile.PostedFile;
            int length = img.ContentLength;
            this.imgbyte = new byte[length];
            img.InputStream.Read(imgbyte, 0, length);
            masterbel.Image = imgbyte;
            masterbel.ImageName = txt_imagename.Text;
            masterbel.ImageDesc = txt_ImageDescription.Text;
            masterbel.ImageUpdateDate = DateTime.Now;
            masterbel.ImageUpdatedby = _currentUsername;
            if (lbl_imagemaster.Text == "N")
            {
                updatestatus = masterbal.ImageInsert(masterbel);
                if (updatestatus != string.Empty)
                {

                    lbl_Status.Text = "Records Added Successfully";
                    ImageBind();
                }
            }
            else
            {
                masterbel.ImageId = Convert.ToInt16(lbl_ImageId.Text);
                updatestatus = masterbal.ImageUpdate(masterbel);
                if (updatestatus != string.Empty)
                {
                    lbl_Status.Text = "Records Updated Successfully";
                    ImageBind();

                    txt_imagename.Text = null;
                    txt_ImageDescription.Text = null;
                    lbl_imagemaster.Text = "N";
                }
            }
        }
    }
}