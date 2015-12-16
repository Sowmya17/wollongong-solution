using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Data;
using System.Media;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Speech.Synthesis;

public partial class CounterDisplay : System.Web.UI.Page
{
    QueueView queueview = new QueueView();

    string FirstBell, SecondBell, ThirdBell, FourthBell, FifthBell, SixthBell;
    // int FirstColour , SecondColour , TkhirdColour , FourthColour , FifthColour, SixthColour;
    long FirstQueue, SecondQueue, ThirdQueue, FourthQueue, FifthQueue, SixthQueue;
    int FirstColoor;
    string ConnectionString;
    string Decryption;
    string serving = "Serving";
    string waiting = "waiting";

    [DllImport("Iphlpapi.dll")]
    private static extern int SendARP(Int32 dest, Int32 host, ref Int64 mac, ref Int32 length);
    [DllImport("Ws2_32.dll")]
    private static extern Int32 inet_addr(string ip);


    int BOTC
    {
        get { return (int)ViewState["BOTC"]; }
        set { ViewState["BOTC"] = value; }
    }

    int FirstColour
    {
        get { return (int)ViewState["FirstColour"]; }
        set { ViewState["FirstColour"] = value; }
    }

    int SecondColour
    {
        get { return (int)ViewState["SecondColor"]; }
        set { ViewState["SecondColor"] = value; }
    }

    int ThirdColour
    {
        get { return (int)ViewState["ThirdColor"]; }
        set { ViewState["ThirdColor"] = value; }
    }

    int FourthColour
    {
        get { return (int)ViewState["FourthColor"]; }
        set { ViewState["FourthColor"] = value; }
    }

    int FifthColour
    {
        get { return (int)ViewState["FifthColor"]; }
        set { ViewState["FifthColor"] = value; }
    }

    int SixthColour
    {
        get { return (int)ViewState["SixthColor"]; }
        set { ViewState["SixthColor"] = value; }
    }

    string FirstBel
    {

        get { return ViewState["FirstBell"] as string; }
        set { ViewState["FirstBell"] = value; }

    }

    string mac
    {

        get { return ViewState["mac"] as string; }
        set { ViewState["mac"] = value; }

    }

    string path
    {

        get { return ViewState["path"] as string; }
        set { ViewState["path"] = value; }

    }

    string did
    {

        get { return ViewState["did"] as string; }
        set { ViewState["did"] = value; }

    }


    //int FirstDepartmentID=1, SecondDepartmentID=2, ThirdDepartmentID=18, FourthDepartmentID=4, FifthDepartmentID=5;
    //int SixthDepartmentID=6, SevenDepartmentID=7, EighthDepartmentID=8, NinthDepartmentID=9, TenthDepartmentID=10;
    //int ElevenDepartmentID=11, TwelthDepartmentID=12, ThirteenDepartmentID=13, FourteenDepartmentID=14, FifteenDepartmentID=15;
    //int SixteenDepartmentID=16, SeventeenDepartmentID=17, EighteenDepartmentID=18, NineteenDepartmentID=19, TwentyDepartmentID=20;

    // SQL CONNECTION

    #region SQL CONNECTION - ACCESSING CONNECTION STRING FROM TEXT FILE

    SqlConnection MySqlConnection = new SqlConnection();

    #endregion SQL CONNECTION - ACCESSING CONNECTION STRING FROM TEXT FILE


    // SQL CONNECTION - DECRYPTION

    #region SQL CONNECTION - DECRYPTION

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

    #endregion SQL CONNECTION - DECRYPTION





    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            did = Server.UrlDecode(Request.QueryString["1"]);
            if (did == null)
            {
                did = Session["did"].ToString();
            }
            FirstColour = 1;
            SecondColour = 1;
            ThirdColour = 1;
            FourthColour = 1;
            FifthColour = 1;
            SixthColour = 1;
            BOTC = 1;
            mac = MACAddress();
            path = "~/sound/DingDongBell.wav";
            serving = "Serving";
            Decryption = ConfigurationManager.AppSettings["LocalConnection"].ToString();


            ConnectionString = Decryptdata(Decryption);
            //MySqlConnection = ConnectionString;
            //ConnectionString = "Data Source=HMIS-SERVER ; User Id=sa; Password=cmc@123; Initial Catalog=att-india-qms; Pooling=false";
            // ConnectionString = "Data Source=EQMS1-PC ; User Id=sa; Password=P@550rd; Initial Catalog=att-india-qms; Pooling=false";

            MySqlConnection = new SqlConnection(ConnectionString);

            QueueView q = new QueueView();
            DisplayLoad();
            GettingQueueNo();

            //call();

        }
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


    // Queue Display - Initializing Variables

    #region Queue Display - Initializing Variables

    //   Thread NewThread, MyThread, VideoThread;


    SqlDependency sqldep;

    DataTable dt = new DataTable();

    DataTable dtmissedqueue = new DataTable();

    #endregion Queue Display - Initializing Variables



    //Getting QueueNumber
    #region Getting QueueNumber
    public void GettingQueueNo()
    {
        // HtmlGenericControl sound = new HtmlGenericControl("<embed src=\"" + path + "\" autostart=\"true\" hidden=\"true\"></embed>");

        //PlaceHolder1.Controls.Add(sound);

        // int FirstQueue;
        QueueController queuecontroller = new QueueController();

        Hashtable hTable = new Hashtable();
        ArrayList duplicateList = new ArrayList();

        //DataTable dtnurse = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();

        DataTable dname1 = new DataTable();
        DataTable dname2 = new DataTable();


        DataTable dnext1 = new DataTable();
        DataTable dnext2 = new DataTable();
        //if (mac == "E0699501D59C")
        //getting department id from text file
        //string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //StringBuilder sb = new StringBuilder();
        //foreach (string txtName in Directory.GetFiles(@"D:\New folder", "*.txt"))
        //{
        //    using (StreamReader sr = new StreamReader(txtName))
        //    {
        //        //sb.AppendLine(txtName.ToString());
        //       // sb.AppendLine("= = = = = =");
        //        sb.Append(sr.ReadToEnd());
        //       // sb.AppendLine();
        //       // sb.AppendLine();
        //    }
        //}
        //string s1 = sb.ToString();
        //string s = Resources.Resource.counter;
        //queueview.DepartmentIDCounterDisplay =Convert.ToInt32(s1) ;
        queueview.DepartmentIDCounterDisplay = Convert.ToInt32(did);

        dt1 = queuecontroller.GetDirectionIDCounterDisplay(queueview);



        int tt = dt1.Rows.Count;
        if (dt1.Rows.Count != 0)
        {

            lbl_queue11.Text = dt1.Rows[0][0].ToString();

            // queueview.DepartmentID = Convert.ToInt32(dt1.Rows[0][2].ToString());

            dname1 = queuecontroller.GetDepartmentImage(queueview);

            if (dname1.Rows.Count > 0)
            {
                Image1.ImageUrl = dname1.Rows[0][2].ToString();

                lbl_deptname11.Text = dname1.Rows[0][1].ToString();
                lbl_dname11.Text = dname1.Rows[0][0].ToString();

            }

            lbl_queue11.ForeColor = Color.Black;

            lbl_dname11.ForeColor = Color.Black;


            FirstBell = dt1.Rows[0][4].ToString();
            FirstQueue = Convert.ToInt32(dt1.Rows[0][5].ToString());
            if (FirstBell == "N" && FirstColour == 1)
            {
                lbl_queue11.ForeColor = Color.Red;

                lbl_dname11.ForeColor = Color.Red;

                lbl_queue11.Attributes.Add("style", "text-decoration:blink");

                call();

                FirstColour++;
            }

            if (FirstColour == 2 || FirstColour == 3 || FirstColour == 4)
            {
                lbl_queue11.ForeColor = Color.Red;

                lbl_dname11.ForeColor = Color.Red;


                FirstColour++;
            }
            if (FirstColour == 5)
            {
                queueview.SmsStatusFlag = "D";
                queueview.QueueTnxId = FirstQueue;
                queuecontroller.ChangingColourStatus(queueview);

                FirstColour = 1;
            }





        }
        else
        {
            FirstBell = string.Empty;
            SecondBell = string.Empty;
            ThirdBell = string.Empty;
            FourthBell = string.Empty;
            FifthBell = string.Empty;
            SixthBell = string.Empty;

            FirstColour = 1;
            SecondColour = 1;
            ThirdColour = 1;
            FourthColour = 1;
            FifthColour = 1;
            SixthColour = 1;

            lbl_queue11.Text = "";

            lbl_dname11.Text = "";

            Image1.ImageUrl = "~/images/doctor.png";

        }



    }
    #endregion Getting QueueNumber


    protected void Timer1_Tick(object sender, EventArgs e)
    {
        GettingQueueNo();


    }
    public void DisplayLoad()
    {
        QueueController queuecntrl = new QueueController();
        QueueView quvw = new QueueView();
        DataTable datadisplay = new DataTable();
        datadisplay = queuecntrl.GetDisplayScrollText(quvw);
        Label7.Text = datadisplay.Rows[0][0].ToString();
        Image4.ImageUrl = datadisplay.Rows[0][1].ToString();
        Image3.ImageUrl = datadisplay.Rows[0][2].ToString();


    }
    public void call()
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "play", "play();", true);
    }

}