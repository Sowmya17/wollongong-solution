using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data.SqlClient;
using System.Data;

public partial class Admin_Status : System.Web.UI.Page
{

    public int slno = 1;
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

        MasterBEL masterbel = new MasterBEL();
        MasterBAL masterbal = new MasterBAL();
        DataTable MyQueueNumber = new DataTable();
        DataTable MyQueueStatus = new DataTable();
        try
        {
            if (txt_queuenumber.Text != string.Empty)
            {
                masterbel.QueueNummberShow = txt_queuenumber.Text;
                //masterbal.DateTime = System.DateTime.Now.ToShortDateString();

                MyQueueNumber = masterbal.GetMyQueueNumber(masterbel);

                if (MyQueueNumber.Rows.Count != 0)
                {
                    gv_queuedetails.Visible = true;
                    //queuestatusbel.TransferID = Convert.ToInt16(MyQueueNumber.Rows[0][7].ToString());

                    // Creating Data Type Column On Run Time
                    MyQueueNumber.Columns.Add("Queue Status");
                    MyQueueNumber.Columns.Add("Token Reg");
                    MyQueueNumber.Columns.Add("Service Start");
                    MyQueueNumber.Columns.Add("Service End");
                    String dat = MyQueueNumber.Rows[0][8].ToString();
                    // Assigning String To Data Type Column
                    foreach (DataRow queuestatus in MyQueueNumber.Rows)
                    {
                        if ((queuestatus["plan_transfer_id"].ToString() != string.Empty) || (queuestatus["unplan_transfer_id"].ToString()) != string.Empty)
                        {
                            if (queuestatus["plan_transfer_id"].ToString() != string.Empty)
                            {
                                masterbel.TransferID = Convert.ToInt16(queuestatus["plan_transfer_id"].ToString());
                            }
                            else
                            {
                                masterbel.TransferID = Convert.ToInt16(queuestatus["unplan_transfer_id"].ToString());
                            }
                            MyQueueStatus = masterbal.GetMyQueueStatus(masterbel);

                            queuestatus["Queue Status"] = MyQueueStatus.Rows[0][0].ToString();

                        }

                        else
                        {
                            queuestatus["Queue Status"] = "Pending";
                        }
                        queuestatus["Token Reg"] = dat;
                        queuestatus["Service Start"] = MyQueueStatus.Rows[0][2].ToString();
                        queuestatus["Service End"] = MyQueueStatus.Rows[0][3].ToString();
                        //queuestatus["SL.NO"] = slno;

                        //slno = slno + 1;

                    }

                   // lbl_getstatus.Visible = false;

                    //lbl_messagebox.Visible = false;
                }
                else
                {
                    gv_queuedetails.Visible = false;
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
               // lbl_getstatus.Text = "Please Enter Your Queue Number";
                //lbl_getstatus.Visible = true;
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
            masterbel = null;
            masterbal= null;
        }

    }
}