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

public partial class Display : System.Web.UI.Page
{
    QueueView queueview = new QueueView();
    string FirstBell, SecondBell, ThirdBell, FourthBell, FifthBell, SixthBell, SeventhBell, EightBell, NinthBell;
    string TenthBell, EleventhBel, Twelethbell, Thirteenbell, Fourteenbell, Fifteenbell, Sixteenbell,Seventeenbell, Eighteenbell ;
    // int FirstColour , SecondColour , TkhirdColour , FourthColour , FifthColour, SixthColour;
    long FirstQueue, SecondQueue, ThirdQueue, FourthQueue, FifthQueue, SixthQueue;
    long SeventhQueue, EightQueue, NinthQueue, TenthQueue, EleventhQueue, TwelethQueue;
    long ThirteenQueue, FourteenQueue, FifteenQueue, SixteenQueue, SeventeenQueue, EighteenQueue;
    
    int TotalQueue1;
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

    int SeventhColour
    {
        get { return (int)ViewState["SeventhColor"]; }
        set { ViewState["SeventhColor"] = value; }
    }

    int EightColour
    {
        get { return (int)ViewState["EightColor"]; }
        set { ViewState["EightColor"] = value; }
    }

    int NinthColour
    {
        get { return (int)ViewState["NinthColor"]; }
        set { ViewState["NinthColor"] = value; }
    }

    int TenthColour
    {
        get { return (int)ViewState["TenthColor"]; }
        set { ViewState["TenthColor"] = value; }
    }

    int EleventhColour
    {
        get { return (int)ViewState["EleventhColor"]; }
        set { ViewState["EleventhColor"] = value; } 
    }

    int TwelethColour
    {
        get { return (int)ViewState["TwelethColor"]; }
        set { ViewState["TwelethColor"] = value; }
    }

    int ThirteenColour
    {
        get { return (int)ViewState["Thirteencolor"]; }
        set { ViewState["Thirteencolor"] = value; }
    }

    int FourteenColour
    {
        get { return (int)ViewState["Fourteencolor"]; }
        set { ViewState["Fourteencolor"] = value; }
    }

    int FifteenColour
    {
        get { return (int)ViewState["Fifteencolor"]; }
        set { ViewState["Fifteencolor"] = value; }
    }

    int SixteenColour
    {
        get { return (int)ViewState["Sixteencolor"]; }
        set { ViewState["Sixteencolor"] = value; }
    }

    int SeventeenColour
    {
        get { return (int)ViewState["Seventeencolor"]; }
        set { ViewState["Seventeencolor"] = value; }
    }

    int EighteenColour
    {
        get { return (int)ViewState["Eighteencolor"]; }
        set { ViewState["Eighteencolor"] = value; }
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
            Labeltime.Text = DateTime.Now.ToShortDateString();
            FirstColour = 1;
            SecondColour = 1;
            ThirdColour = 1;
            FourthColour = 1;
            FifthColour = 1;
            SixthColour = 1;
            SeventhColour = 1;
            EightColour = 1;
            NinthColour = 1;
            TenthColour = 1;
            EleventhColour = 1;
            TwelethColour = 1;
            ThirteenColour = 1;
            FourteenColour = 1;
            FifteenColour = 1;
            SixteenColour = 1;
            SeventhColour = 1;
            EighteenColour = 1;
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
           // DisplayLoad();
            GettingQueueNo();
            GettingMissedQueueNo();
          //  GettingNextQueue();
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

    public DataTable getnxt()
    {

        QueueController queuecontroller = new QueueController();
        //DataTable dname1 = new DataTable();
        DataTable nextqueue = new DataTable();
        queueview.DepartmentIDNext = BOTC;

        if (BOTC == 49)
        {
            BOTC = 1;
        }
        else
        {

            if (BOTC == 4 )
            {
                BOTC++;
            }
            if (BOTC == 28)
            {
                BOTC++;
                BOTC++;
            }
            BOTC++;
        }
        //if (mac == "E0699501D59C")
       // if (mac == "645106A6949F" || mac == "B4B52F877445")
       // queueview.DepartmentIDNext = 5;
        //if (mac == "645106A6949F")
        //{
        //    queueview.DepartmentIDNext = 5;

        //}
        nextqueue = queuecontroller.GetNextThreeTokens(queueview);

        return nextqueue;

    }


    #region Getting Next Queue Number
    public void GettingNextQueue()
    {
        int flag = 0;

        QueueController queuecontroller = new QueueController();
        DataTable dname1 = new DataTable();
        DataTable nextqueue = new DataTable();
        // changing department id 
        nextqueue = getnxt();

        #region timer


        //switch (BOTC)
        //{
        //    case 1:
        //        queueview.DepartmentIDNext = FirstDepartmentID;
        //        BOTC = 2;
        //        nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //        if (nextqueue.Rows.Count == 0)
        //        {
        //            flag = 1;

        //        }
        //        break;


        //    case 2:
        //        queueview.DepartmentIDNext = SecondDepartmentID;
        //        BOTC = 3;
        //        nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //        if (nextqueue.Rows.Count == 0)
        //        {
        //           // GettingNextQueue();
        //            flag = 1;

        //        }
        //        break;


        //    case 3: queueview.DepartmentIDNext = ThirdDepartmentID;
        //        BOTC = 4;
        //        nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //        if (nextqueue.Rows.Count == 0)
        //        {
        //            //GettingNextQueue();
        //            flag = 1;
        //        }
        //        break;

        //case "4":
        //    queueview.DepartmentIDNext = FourteenDepartmentID;
        //    BOTC = "5";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;

        //case "5":
        //    queueview.DepartmentIDNext = FifthDepartmentID;
        //    BOTC = "6";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;

        //case "6":
        //    queueview.DepartmentIDNext = SixthDepartmentID;
        //    BOTC = "7";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "7":
        //    queueview.DepartmentIDNext = SevenDepartmentID;
        //    BOTC = "8";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "8":
        //    queueview.DepartmentIDNext = EighthDepartmentID;
        //    BOTC = "9";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "9":
        //    queueview.DepartmentIDNext = NinthDepartmentID;
        //    BOTC = "10";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "10":
        //    queueview.DepartmentIDNext = TenthDepartmentID;
        //    BOTC = "11";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "11":
        //    queueview.DepartmentIDNext = ElevenDepartmentID;
        //    BOTC = "12";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "12":
        //    queueview.DepartmentIDNext = TwelthDepartmentID;
        //    BOTC = "13";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "13":
        //    queueview.DepartmentIDNext = ThirteenDepartmentID;
        //    BOTC = "14";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "14":
        //    queueview.DepartmentIDNext = FourteenDepartmentID;
        //    BOTC = "15";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "15":
        //    queueview.DepartmentIDNext = FifteenDepartmentID;
        //    BOTC = "16";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "16":
        //    queueview.DepartmentIDNext = SixteenDepartmentID;
        //    BOTC = "17";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "17":
        //    queueview.DepartmentIDNext = SeventeenDepartmentID;
        //    BOTC = "18";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "18":
        //    queueview.DepartmentIDNext = EighteenDepartmentID;
        //    BOTC = "19";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "19":
        //    queueview.DepartmentIDNext = NineteenDepartmentID;
        //    BOTC = "20";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //case "20":
        //    queueview.DepartmentIDNext = TwentyDepartmentID;
        //    BOTC = "1";
        //    nextqueue = queuecontroller.GetNextThreeTokens(queueview);
        //    if (nextqueue.Rows.Count == 0)
        //    {
        //        //GettingNextQueue();
        //        flag = 1;
        //    }
        //    break;
        //  }
        #endregion timer



        int totnext = nextqueue.Rows.Count;
        if (nextqueue.Rows.Count != 0)
        {
            for (int i = 1; i <= totnext; i++)
            {
                if (i == 1)
                {
                    //lbl_queue23.Text = nextqueue.Rows[0][0].ToString();
                    //  lbl_room21.Text = nextqueue.Rows[0][1].ToString();
                    //lbl_status21.Text = waiting;
                    queueview.DepartmentID = Convert.ToInt32(nextqueue.Rows[0][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);

                    if (dname1.Rows.Count > 0)
                    {
                        //Image1.ImageUrl = dname1.Rows[0][2].ToString();
                       // lbl_doct.Text = dname1.Rows[0][0].ToString();
                       // lbl_dept.Text = dname1.Rows[0][1].ToString();

                    }

                }
                if (i == 2)
                {

                    //lbl_queue24.Text = nextqueue.Rows[1][0].ToString();
                    // lbl_room22.Text = nextqueue.Rows[1][1].ToString();
                    //lbl_status22.Text = waiting;
                    queueview.DepartmentID = Convert.ToInt32(nextqueue.Rows[1][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    //if (dname1.Rows.Count > 0)
                    //{
                    //  // lbl_deptname22.Text = dname1.Rows[0][1].ToString();
                    //}
                }

                if (i == 3)
                {
                    //lbl_queue25.Text = nextqueue.Rows[2][0].ToString();
                    // lbl_room23.Text = nextqueue.Rows[2][1].ToString();
                    //lbl_status23.Text = waiting;
                    queueview.DepartmentID = Convert.ToInt32(nextqueue.Rows[2][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    //if (dname1.Rows.Count > 0)
                    //{
                    //   lbl_deptname23.Text = dname1.Rows[0][1].ToString();
                    //}


                }

                if (i == 4)
                {

                    //lbl_queue26.Text = nextqueue.Rows[3][0].ToString();
                    // lbl_room24.Text = nextqueue.Rows[3][1].ToString();
                    //lbl_status24.Text = waiting;
                    queueview.DepartmentID = Convert.ToInt32(nextqueue.Rows[3][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    //if (dname1.Rows.Count > 0)
                    //{
                    //    lbl_deptname24.Text = dname1.Rows[0][1].ToString();
                    //}
                }

                if (i == 5)
                {
                    //lbl_queue27.Text = nextqueue.Rows[4][0].ToString();
                    //lbl_room25.Text = nextqueue.Rows[4][1].ToString();
                    //lbl_status25.Text = waiting;
                    queueview.DepartmentID = Convert.ToInt32(nextqueue.Rows[4][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    //if (dname1.Rows.Count > 0)
                    //{
                    //   lbl_deptname25.Text = dname1.Rows[0][1].ToString();
                    //}
                }
                if (i == 6)
                {
                    //lbl_queue28.Text = nextqueue.Rows[5][0].ToString();
                    //lbl_room26.Text = nextqueue.Rows[5][1].ToString();
                    //lbl_status26.Text = waiting;
                    queueview.DepartmentID = Convert.ToInt32(nextqueue.Rows[5][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    //if (dname1.Rows.Count > 0)
                    //{
                    //   lbl_deptname26.Text = dname1.Rows[0][1].ToString();
                    //}
                }
                
            }



            if (totnext == 1)
            {
                //lbl_queue24.Text = "";
                //lbl_status22.Text = "";
                //  lbl_deptname22.Text = "-";


                //lbl_queue25.Text = "";
                //lbl_status23.Text = "";
                //lbl_deptname23.Text = "-";


                //lbl_queue26.Text = "";
                //lbl_status24.Text = "";
                //lbl_deptname24.Text = "-";

               
                //lbl_queue27.Text = "";
                //lbl_status25.Text = "";
                //lbl_deptname25.Text = "-";


                //lbl_queue28.Text = "";
                //lbl_status26.Text = "";
                //lbl_deptname26.Text = "-";
            }
            if (totnext == 2)
            {
               
                //lbl_queue25.Text = "";
                //lbl_status23.Text = "";
                //lbl_deptname23.Text = "-";


                //lbl_queue26.Text = "";
                //lbl_status24.Text = "";
                //lbl_deptname24.Text = "-";


                //lbl_queue27.Text = "";
                //lbl_status25.Text = "";
                //lbl_deptname25.Text = "-";


                //lbl_queue28.Text = "";
                //lbl_status26.Text = "";
                //lbl_deptname26.Text = "-";
            }

            if (totnext == 3)
            {



                //lbl_queue26.Text = "";
                //lbl_status24.Text = "";
                //lbl_deptname24.Text = "-";


                //lbl_queue27.Text = "";
                //lbl_status25.Text = "";
                //lbl_deptname25.Text = "-";


                //lbl_queue28.Text = "";
                //lbl_status26.Text = "";
                //lbl_deptname26.Text = "-";
            }

            if (totnext == 4)
            {



                //lbl_queue27.Text = "";
                //lbl_status25.Text = "";
                //lbl_deptname25.Text = "-";


                //lbl_queue28.Text = "";
                //lbl_status26.Text = "";
                //lbl_deptname26.Text = "-";
            }
            if (totnext == 5)
            {




                //lbl_queue28.Text = "";
                //lbl_status26.Text = "";
                //lbl_deptname26.Text = "-";
            }
        }
        else
        {
            //lbl_queue23.Text = "";
            //lbl_status21.Text = "";
            //lbl_deptname21.Text = "-";

            //lbl_queue24.Text = "";
            //lbl_status22.Text = "";
            //lbl_deptname22.Text = "-";


            //lbl_queue25.Text = "";
            //lbl_status23.Text = "";
            //lbl_deptname23.Text = "-";


            //lbl_queue26.Text = "";
            //lbl_status24.Text = "";
            //lbl_deptname24.Text = "-";


            //lbl_queue27.Text = "";
            //lbl_status25.Text = "";
            //lbl_deptname25.Text = "-";


            //lbl_queue28.Text = "";
            //lbl_status26.Text = "";
            //lbl_deptname26.Text = "-";
            if (BOTC == 1)
            {
                DataTable datanxt = new DataTable();
               datanxt= queuecontroller.GetNextTokens(queueview);
               if (datanxt.Rows.Count == 0)
               {
                  // lbl_doct.Text = "";
                   //Image1.ImageUrl = "~/images/doctor.png";
                  // lbl_dept.Text = "";
               }
               else
               {
                 //  GettingNextQueue();
               }
            }
            else
            {

               // GettingNextQueue();
            }
            
        }
        
        



    }
    #endregion Getting Next Queue Number

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
        //DataTable dtnurse = new DataTable();
        DataTable dc1 = new DataTable();
        DataTable dc2 = new DataTable();


        DataTable dname1 = new DataTable();
        DataTable dname2 = new DataTable();


        DataTable dnext1 = new DataTable();
        DataTable dnext2 = new DataTable();
       // dt1 = queuecontroller.GetDirectionIDBilling(queueview);
        //if (mac == "E0699501D59C")
       // if (mac == "645106A6949F" || mac == "B4B52F877445" || mac ="0C84DC6E0CCD")
        //if (mac == "645106A6949F")
        //{
        //    dt1 = queuecontroller.GetDirectionIDBilling(queueview);
        //}
        //else
        //{
            dt1 = queuecontroller.GetDirectionID(queueview);
            dc1 = queuecontroller.GetDirectionID1(queueview);
            dc2 = queuecontroller.GetDirectionID2(queueview);
        //}
        if (dt1.Rows.Count != 0)
        {
            //Add list of all the unique item value to hashtable, which stores combination of key, value pair.
            //And add duplicate item value in arraylist.
            //foreach (DataRow drow in dt1.Rows)
            //{
            //    if (hTable.Contains(drow["queue_department_id"]))
            //    {
            //        if (drow["queue_department_id"].ToString() == "58")
            //        {
            //        }
            //        else
            //        {
            //            duplicateList.Add(drow);
            //        }
            //    }
            //    else
            //    {
            //        hTable.Add(drow["queue_department_id"], string.Empty);
            //    }
            //}

            //Removing a list of duplicate items from datatable.
            //foreach (DataRow dRow in duplicateList)
            //{
            //    dt1.Rows.Remove(dRow);
            //}
        }

        #region reception
        int tt = dt1.Rows.Count;
        if (dt1.Rows.Count != 0)
        {
            for (int i = 1; i <= tt; i++)
            {
                if (i == 1)
                {
                    lbl_queue11.Text = dt1.Rows[0][0].ToString();
                    lbl_room11.Text = dt1.Rows[0][1].ToString();
                    queueview.DepartmentID = Convert.ToInt32(dt1.Rows[0][2].ToString());
                    //lbl_status11.Text = "Serving";
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname11.Text = dname1.Rows[0][0].ToString();
                      //  lbl_deptname11.Text = dname1.Rows[0][1].ToString();
                    }

                    lbl_queue11.ForeColor = Color.Black;
                    lbl_room11.ForeColor = Color.Black;
                  //  lbl_dname11.ForeColor = Color.Black;
                    //lbl_deptname11.ForeColor = Color.Black;
                    //lbl_status11.ForeColor = Color.Black;


                    FirstBell = dt1.Rows[0][4].ToString();
                    FirstQueue = Convert.ToInt32(dt1.Rows[0][5].ToString());
                    if (FirstBell == "N" && FirstColour == 1)
                    {
                      //  lbl_status11.Text = "Plz Come";
                        lbl_queue11.ForeColor = Color.Red;
                        lbl_room11.ForeColor = Color.Red;
                    //    lbl_dname11.ForeColor = Color.Red;

                        //lbl_deptname11.ForeColor = Color.Red;
                        //lbl_status11.ForeColor = Color.Red;
                        lbl_queue11.Attributes.Add("style", "text-decoration:blink");
                        // Button1_Click(sender,  e);
                        //ScriptManager.RegisterStartupScript(this, GetType(), "play", "play();", true);
                        //SystemSounds.Asterisk.Play();
                        Thread thread = new Thread(() => call(lbl_queue11.Text.ToString(), lbl_room11.Text.ToString()));
                        thread.Start();
                       // call(lbl_queue11.Text.ToString(),lbl_room11.Text.ToString());
                       // call();
                        // ScriptManager.RegisterClientScriptBlock(Me, GetType(), "OpenWindow", "javascript: DHTMLSound('../../MonitoringAlerts/alert.wav')", True);

                        //var audio = new Audio('audio_file.mp3');
                        //audio.play();

                        //  SoundPlayer s = new SoundPlayer();
                        ////  s.Play();
                        //  s.SoundLocation = Server.MapPath("~/sound/DingDongBell.wav");
                        ////  s.PlaySync();
                        //  s.Play();
                        FirstColour++;
                    }

                    if (FirstColour == 2 || FirstColour == 3 || FirstColour == 4 || FirstColour == 5 || FirstColour == 6 || FirstColour == 7 || FirstColour == 8)
                    {
                        //lbl_status11.Text = "Plz Come";
                        lbl_queue11.ForeColor = Color.Red;
                        lbl_room11.ForeColor = Color.Red;
                      //  lbl_dname11.ForeColor = Color.Red;

                        //lbl_deptname11.ForeColor = Color.Red;
                        //lbl_status11.ForeColor = Color.Red;

                        FirstColour++;
                    }
                    if (FirstColour == 9 || FirstColour == 10 || FirstColour == 11 || FirstColour == 12 || FirstColour == 13 || FirstColour == 14 || FirstColour == 15 || FirstColour == 16 || FirstColour == 17 || FirstColour == 18 )
                    {

                        //lbl_status11.Text = "Plz Come";
                        if (FirstColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = FirstQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        //original
                        //FirstColour=1;

                        //for dm status changing
                        FirstColour++;
                    }
                    // for dm health care status
                    if (FirstColour == 19)
                    {
                        //lbl_status11.Text = "Serving";
                        FirstColour = 1;
                    }

                }
                if (i == 2)
                {

                    lbl_queue12.Text = dt1.Rows[1][0].ToString();
                    lbl_room12.Text = dt1.Rows[1][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dt1.Rows[1][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname12.Text = dname1.Rows[0][0].ToString();
                      //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue12.ForeColor = Color.Black;
                    lbl_room12.ForeColor = Color.Black;
                    //lbl_dname12.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    SecondBell = dt1.Rows[1][4].ToString();
                    SecondQueue = Convert.ToInt32(dt1.Rows[1][5].ToString());

                    if (SecondBell == "N" && SecondColour == 1)
                    {
                      //  lbl_status12.Text = "Plz Come";
                        lbl_queue12.ForeColor = Color.Red;
                        lbl_room12.ForeColor = Color.Red;
                      //  lbl_dname12.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue12.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                       //call();
                        Thread thread = new Thread(() => call(lbl_queue12.Text.ToString(), lbl_room12.Text.ToString()));
                        thread.Start();
                        //call(lbl_queue12.Text.ToString(), lbl_room12.Text.ToString());
                        SecondColour++;
                    }

                    if (SecondColour == 2 || SecondColour == 3 || SecondColour == 4 || SecondColour == 5 || SecondColour == 6 || SecondColour == 7 || SecondColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue12.ForeColor = Color.Red;
                        lbl_room12.ForeColor = Color.Red;
                        //lbl_dname12.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        SecondColour++;
                    }
                    if (SecondColour == 9 || SecondColour == 10 || SecondColour == 11 || SecondColour == 12 || SecondColour == 13 || SecondColour == 14 || SecondColour == 15 || SecondColour == 16 || SecondColour == 17 || SecondColour == 18)
                    {
                        if (SecondColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = SecondQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        SecondColour++;
                    }
                    if (SecondColour == 19)
                    {

                        SecondColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }
                   
                }

                if (i == 3)
                {
                    lbl_queue13.Text = dt1.Rows[2][0].ToString();
                    lbl_room13.Text = dt1.Rows[2][1].ToString();
                    //lbl_status13.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dt1.Rows[2][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname13.Text = dname1.Rows[0][0].ToString();
                      //  lbl_deptname13.Text = dname1.Rows[0][1].ToString();
                    }

                    lbl_queue13.ForeColor = Color.Black;
                    lbl_room13.ForeColor = Color.Black;
                    //lbl_dname13.ForeColor = Color.Black;
                    //lbl_deptname13.ForeColor = Color.Black;
                    //lbl_status13.ForeColor = Color.Black;


                    ThirdBell = dt1.Rows[2][4].ToString();
                    ThirdQueue = Convert.ToInt32(dt1.Rows[2][5].ToString());

                    if (ThirdBell == "N" && ThirdColour == 1)
                    {
                      //  lbl_status13.Text = "Plz Come";
                        lbl_queue13.ForeColor = Color.Red;
                        lbl_room13.ForeColor = Color.Red;
                      //  lbl_dname13.ForeColor = Color.Red;

                        //lbl_deptname13.ForeColor = Color.Red;
                       // lbl_status13.ForeColor = Color.Red;

                        // SystemSounds.Asterisk.Play();
                       // call();
                        Thread thread = new Thread(() => call(lbl_queue13.Text.ToString(), lbl_room13.Text.ToString()));
                        thread.Start();
                        //call(lbl_queue13.Text.ToString(), lbl_room13.Text.ToString());
                        ThirdColour++;
                    }

                    if (ThirdColour == 2 || ThirdColour == 3 || ThirdColour == 4 || ThirdColour == 5 || ThirdColour == 6 || ThirdColour == 7 || ThirdColour == 8)
                    {
                        //lbl_status13.Text = "Plz Come";
                        lbl_queue13.ForeColor = Color.Red;
                        lbl_room13.ForeColor = Color.Red;
                        //lbl_dname13.ForeColor = Color.Red;
                       // lbl_deptname13.ForeColor = Color.Red;
                        //lbl_status13.ForeColor = Color.Red;
                        ThirdColour++;
                    }
                    if (ThirdColour == 9 || ThirdColour == 10 || ThirdColour == 11 || ThirdColour == 12 || ThirdColour == 13 || ThirdColour == 14 || ThirdColour == 15 || ThirdColour == 16 || ThirdColour == 17 || ThirdColour == 18)
                    {
                        if (ThirdColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = ThirdQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        ThirdColour++;
                    }
                    if (ThirdColour == 19)
                    {

                        ThirdColour = 1;

                        //dm status
                        //lbl_status13.Text = serving;
                    }


                }

                if (i == 4)
                {

                    lbl_queue14.Text = dt1.Rows[3][0].ToString();
                    lbl_room14.Text = dt1.Rows[3][1].ToString();
                    //lbl_status14.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dt1.Rows[3][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname14.Text = dname1.Rows[0][0].ToString();
                      //  lbl_deptname14.Text = dname1.Rows[0][1].ToString();
                    }

                    lbl_queue14.ForeColor = Color.Black;
                    lbl_room14.ForeColor = Color.Black;
                    //lbl_dname14.ForeColor = Color.Black;
                    //lbl_deptname14.ForeColor = Color.Black;
                    //lbl_status14.ForeColor = Color.Black;



                    FourthBell = dt1.Rows[3][4].ToString();
                    FourthQueue = Convert.ToInt32(dt1.Rows[3][5].ToString());

                    if (FourthBell == "N" && FourthColour == 1)
                    {
                      //  lbl_status14.Text = "Plz Come";

                        lbl_queue14.ForeColor = Color.Red;
                        lbl_room14.ForeColor = Color.Red;
                      //  lbl_dname14.ForeColor = Color.Red;
                        //lbl_deptname14.ForeColor = Color.Red;
                        //lbl_status14.ForeColor = Color.Red;
                        //SystemSounds.Asterisk.Play();
                       // call();
                        Thread thread = new Thread(() => call(lbl_queue14.Text.ToString(), lbl_room14.Text.ToString()));
                        thread.Start();
                       //call(lbl_queue14.Text.ToString(), lbl_room14.Text.ToString());
                        FourthColour++;
                    }

                    if (FourthColour == 2 || FourthColour == 3 || FourthColour == 4 || FourthColour == 5 || FourthColour == 6 || FourthColour == 7 || FourthColour == 8)
                    {
                        //lbl_status14.Text = "Plz Come";
                        lbl_queue14.ForeColor = Color.Red;
                        lbl_room14.ForeColor = Color.Red;
                        //lbl_dname14.ForeColor = Color.Red;
                        //lbl_deptname14.ForeColor = Color.Red;
                        //lbl_status14.ForeColor = Color.Red;
                        FourthColour++;
                    }
                    if (FourthColour == 9 || FourthColour == 10 || FourthColour == 11 || FourthColour == 12 || FourthColour == 13 || FourthColour == 14 || FourthColour == 15 || FourthColour == 16 || FourthColour == 17 || FourthColour == 18)
                    {
                        if (FourthColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = FourthQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        FourthColour++;
                    }
                    if (FourthColour == 19)
                    {

                        FourthColour = 1;

                        //dm status
                        //lbl_status14.Text = serving;
                    }
                }

                if (i == 5)
                {
                    lbl_queue15.Text = dt1.Rows[4][0].ToString();
                    lbl_room15.Text = dt1.Rows[4][1].ToString();
                    //lbl_status15.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dt1.Rows[4][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname15.Text = dname1.Rows[0][0].ToString();
                      //  lbl_deptname15.Text = dname1.Rows[0][0].ToString();
                    }

                    lbl_queue15.ForeColor = Color.Black;
                    lbl_room15.ForeColor = Color.Black;
                    //lbl_dname15.ForeColor = Color.Black;
                    //lbl_deptname15.ForeColor = Color.Black;
                    //lbl_status15.ForeColor = Color.Black;



                    FifthBell = dt1.Rows[4][4].ToString();
                    FifthQueue = Convert.ToInt32(dt1.Rows[4][5].ToString());

                    if (FifthBell == "N" && FifthColour == 1)
                    {
                      //  lbl_status15.Text = "Plz Come";
                        lbl_queue15.ForeColor = Color.Red;
                        lbl_room15.ForeColor = Color.Red;
                      //  lbl_dname15.ForeColor = Color.Red;
                        //lbl_deptname15.ForeColor = Color.Red;
                        //lbl_status15.ForeColor = Color.Red;
                        //SystemSounds.Asterisk.Play();
                       // call();
                        Thread thread = new Thread(() => call(lbl_queue15.Text.ToString(), lbl_room15.Text.ToString()));
                        thread.Start();
                        //call(lbl_queue15.Text.ToString(), lbl_room15.Text.ToString());
                        FifthColour++;
                    }

                    if (FifthColour == 2 || FifthColour == 3 || FifthColour == 4 || FifthColour == 5 || FifthColour == 6 || FifthColour == 7 || FifthColour == 8)
                    {
                        //lbl_status15.Text = "Plz Come";
                        lbl_queue15.ForeColor = Color.Red;
                        lbl_room15.ForeColor = Color.Red;
                        //lbl_dname15.ForeColor = Color.Red;
                        //lbl_deptname15.ForeColor = Color.Red;
                        //lbl_status15.ForeColor = Color.Red;
                        FifthColour++;
                    }
                    if (FifthColour == 9 || FifthColour == 10 || FifthColour == 11 || FifthColour == 12 || FifthColour == 13 || FifthColour == 14 || FifthColour == 15 || FifthColour == 16 || FifthColour == 17 || FifthColour == 18)
                    {
                        if (FifthColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = FifthQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        FifthColour++;

                    }
                    if(FifthColour == 19)
                    {

                        FifthColour = 1;

                        //dm status
                        //lbl_status15.Text = serving;

                    }
                }
                if (i == 6)
                {
                   // lbl_queue16.Text = dt1.Rows[5][0].ToString();
                    //lbl_room16.Text = dt1.Rows[5][1].ToString();
                    //lbl_status16.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dt1.Rows[5][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname16.Text = dname1.Rows[0][0].ToString();
                      //  lbl_deptname16.Text = dname1.Rows[0][1].ToString();
                    }


                   // lbl_queue16.ForeColor = Color.Black;
                   // lbl_room16.ForeColor = Color.Black;
                    //lbl_dname16.ForeColor = Color.Black;
                    //lbl_deptname16.ForeColor = Color.Black;
                    //lbl_status16.ForeColor = Color.Black;


                    SixthBell = dt1.Rows[5][4].ToString();
                    SixthQueue = Convert.ToInt32(dt1.Rows[5][5].ToString());

                    if (SixthBell == "N" && SixthColour == 1)
                    {
                      //  lbl_status16.Text = "Plz Come";
                       // lbl_queue16.ForeColor = Color.Red;
                       // lbl_room16.ForeColor = Color.Red;
                      //  lbl_dname16.ForeColor = Color.Red;
                        //lbl_deptname16.ForeColor = Color.Red;
                        //lbl_status16.ForeColor = Color.Red;
                        //SystemSounds.Asterisk.Play();
                      //call();
                      //  Thread thread = new Thread(() => call(lbl_queue16.Text.ToString(), lbl_room16.Text.ToString()));
                      //  thread.Start();
                        //call(lbl_queue16.Text.ToString(), lbl_room16.Text.ToString());
                        SixthColour++;
                    }

                    if (SixthColour == 2 || SixthColour == 3 || SixthColour == 4 || SixthColour == 5 || SixthColour == 6 || SixthColour == 7 || SixthColour == 8)
                    {
                        //lbl_status16.Text = "Plz Come";
                       // lbl_queue16.ForeColor = Color.Red;
                       // lbl_room16.ForeColor = Color.Red;
                        //lbl_dname16.ForeColor = Color.Red;
                        //lbl_deptname16.ForeColor = Color.Red;
                        //lbl_status16.ForeColor = Color.Red;
                        SixthColour++;
                    }
                    if (SixthColour == 9 || SixthColour == 10 || SixthColour == 11 || SixthColour == 12 || SixthColour == 13 || SixthColour == 14 || SixthColour == 15 || SixthColour == 16 || SixthColour == 17 || SixthColour == 18)
                    {
                        if (SixthColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = SixthQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        SixthColour++;
                    }
                    if(SixthColour == 19)
                    {

                        SixthColour = 1;

                        //dm status
                        //lbl_status16.Text = serving;
                    }
                }

                //added

               
            }

            if (tt == 1)
            {
                SecondBell = string.Empty;
                ThirdBell = string.Empty;
                FourthBell = string.Empty;
                FifthBell = string.Empty;
                SixthBell = string.Empty;
               

                SecondColour = 1;
                ThirdColour = 1;
                FourthColour = 1;
                FifthColour = 1;
                SixthColour = 1;
              

                lbl_queue12.Text = "";
                lbl_room12.Text = "";
                //lbl_dname12.Text = "";
                //lbl_deptname12.Text = "";
                //lbl_status12.Text = "";



                lbl_queue13.Text = "";
                lbl_room13.Text = "";
                //lbl_dname13.Text = "";
                //lbl_deptname13.Text = "";
                //lbl_status13.Text = "";


                lbl_queue14.Text = "";
                lbl_room14.Text = "";
                //lbl_dname14.Text = "";
                //lbl_deptname14.Text = "";
                //lbl_status14.Text = "";

                lbl_queue15.Text = "";
                lbl_room15.Text = "";
                //lbl_dname15.Text = "";
                //lbl_deptname15.Text = "";
                //lbl_status15.Text = "";

               // lbl_queue16.Text = "";
               // lbl_room16.Text = "";
                //lbl_dname16.Text = "";
                //lbl_deptname16.Text = "";
                //lbl_status16.Text = "";

              
            }

            if (tt == 2)
            {


                ThirdBell = string.Empty;
                FourthBell = string.Empty;
                FifthBell = string.Empty;
                SixthBell = string.Empty;
               

                ThirdColour = 1;
                FourthColour = 1;
                FifthColour = 1;
                SixthColour = 1;
                

                lbl_queue13.Text = "";
                lbl_room13.Text = "";
                //lbl_dname13.Text = "";
                //lbl_deptname13.Text = "";
                //lbl_status13.Text = "";

                lbl_queue14.Text = "";
                lbl_room14.Text = "";
                //lbl_dname14.Text = "";
                //lbl_deptname14.Text = "";
                //lbl_status14.Text = "";

                lbl_queue15.Text = "";
                lbl_room15.Text = "";
                //lbl_dname15.Text = "";
                //lbl_deptname15.Text = "";
                //lbl_status15.Text = "";

               // lbl_queue16.Text = "";
               // lbl_room16.Text = "";
                //lbl_dname16.Text = "";
                //lbl_deptname16.Text = "";
                //lbl_status16.Text = "";

               
            }

            if (tt == 3)
            {


                FourthBell = string.Empty;
                FifthBell = string.Empty;
                SixthBell = string.Empty;
                
                
                
                FourthColour = 1;
                FifthColour = 1;
                SixthColour = 1;
               

                lbl_queue14.Text = "";
                lbl_room14.Text = "";
                //lbl_dname14.Text = "";
                //lbl_deptname14.Text = "";
                //lbl_status14.Text = "";

                lbl_queue15.Text = "";
                lbl_room15.Text = "";
                //lbl_dname15.Text = "";
                //lbl_deptname15.Text = "";
                //lbl_status15.Text = "";

               // lbl_queue16.Text = "";
               // lbl_room16.Text = "";
                //lbl_dname16.Text = "";
                //lbl_deptname16.Text = "";
                //lbl_status16.Text = "";

            }

            if (tt == 4)
            {


                FifthBell = string.Empty;
                SixthBell = string.Empty;
               

                FifthColour = 1;
                SixthColour = 1;
               

                lbl_queue15.Text = "";
                lbl_room15.Text = "";
                //lbl_dname15.Text = "";
                //lbl_deptname15.Text = "";
                //lbl_status15.Text = "";

               // lbl_queue16.Text = "";
               // lbl_room16.Text = "";
                //lbl_dname16.Text = "";
                //lbl_deptname16.Text = "";
                //lbl_status16.Text = "";

             
            }

            if (tt == 5)
            {

                SixthBell = string.Empty;
               
                SixthColour = 1;
               

               // lbl_queue16.Text = "";
               // lbl_room16.Text = "";
                //lbl_dname16.Text = "";
                //lbl_deptname16.Text = "";
                //lbl_status16.Text = "";

               
            }


            if (tt == 6)
            {

                
                
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
            lbl_room11.Text = "";
            //lbl_dname11.Text = "";
            //lbl_deptname11.Text = "";
            //lbl_status11.Text = "";

            lbl_queue12.Text = "";
            lbl_room12.Text = "";
            //lbl_dname12.Text = "";
            //lbl_deptname12.Text = "";
            //lbl_status12.Text = "";

            lbl_queue13.Text = "";
            lbl_room13.Text = "";
            //lbl_dname13.Text = "";
            //lbl_deptname13.Text = "";
            //lbl_status13.Text = "";


            lbl_queue14.Text = "";
            lbl_room14.Text = "";
            //lbl_dname14.Text = "";
            //lbl_deptname14.Text = "";
            //lbl_status14.Text = "";

            lbl_queue15.Text = "";
            lbl_room15.Text = "";
            //lbl_dname15.Text = "";
            //lbl_deptname15.Text = "";
            //lbl_status15.Text = "";

           // lbl_queue16.Text = "";
           // lbl_room16.Text = "";
            //lbl_dname16.Text = "";
            //lbl_deptname16.Text = "";
            //lbl_status16.Text = "";


        }








        #endregion reception




        #region Consult room



        int tt1 = dc1.Rows.Count;
        if (dc1.Rows.Count != 0)
        {
            for (int i = 1; i <= tt1; i++)
            {
                
                //added

                if (i == 1)
                {

                    lbl_queue17.Text = dc1.Rows[0][0].ToString();
                    lbl_room17.Text = dc1.Rows[0][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc1.Rows[0][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue17.ForeColor = Color.Black;
                    lbl_room17.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    SeventhBell = dc1.Rows[0][4].ToString();
                    SeventhQueue = Convert.ToInt32(dc1.Rows[0][5].ToString());

                    if (SeventhBell == "N" && SeventhColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                        lbl_queue17.ForeColor = Color.Red;
                        lbl_room17.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue17.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                        //call();
                        call(lbl_queue17.Text.ToString(), lbl_room17.Text.ToString());
                        SeventhColour++;
                    }

                    if (SeventhColour == 2 || SeventhColour == 3 || SeventhColour == 4 || SeventhColour == 5 || SeventhColour == 6 || SeventhColour == 7 || SeventhColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue17.ForeColor = Color.Red;
                        lbl_room17.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        SeventhColour++;
                    }
                    if (SeventhColour == 9 || SeventhColour == 10 || SeventhColour == 11 || SeventhColour == 12 || SeventhColour == 13 || SeventhColour == 14 || SeventhColour == 15 || SeventhColour == 16 || SeventhColour == 17 || SeventhColour == 18)
                    {
                        if (SeventhColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId =SeventhQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        SeventhColour++;
                    }
                    if (SeventhColour == 19)
                    {

                        SeventhColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }

                }

                if (i == 2)
                {

                    lbl_queue18.Text = dc1.Rows[1][0].ToString();
                    lbl_room18.Text = dc1.Rows[1][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc1.Rows[1][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue18.ForeColor = Color.Black;
                    lbl_room18.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    EightBell = dc1.Rows[1][4].ToString();
                    EightQueue = Convert.ToInt32(dc1.Rows[1][5].ToString());

                    if (EightBell == "N" && EightColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                        lbl_queue18.ForeColor = Color.Red;
                        lbl_room18.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue18.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                        //call();
                        call(lbl_queue18.Text.ToString(), lbl_room18.Text.ToString());
                        EightColour++;
                    }

                    if (EightColour == 2 || EightColour == 3 || EightColour == 4 || EightColour == 5 || EightColour == 6 || EightColour == 7 || EightColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue18.ForeColor = Color.Red;
                        lbl_room18.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        EightColour++;
                    }
                    if (EightColour == 9 || EightColour == 10 || EightColour == 11 || EightColour == 12 || EightColour == 13 || EightColour == 14 || EightColour == 15 || EightColour == 16 || EightColour == 17 || EightColour == 18)
                    {
                        if (EightColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = EightQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        EightColour++;
                    }
                    if (EightColour == 19)
                    {

                        EightColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }

                }

                if (i == 3)
                {

                    lbl_queue19.Text = dc1.Rows[2][0].ToString();
                    lbl_room19.Text = dc1.Rows[2][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc1.Rows[2][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue19.ForeColor = Color.Black;
                    lbl_room19.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    NinthBell = dc1.Rows[2][4].ToString();
                    NinthQueue = Convert.ToInt32(dc1.Rows[2][5].ToString());

                    if (NinthBell == "N" && NinthColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                        lbl_queue19.ForeColor = Color.Red;
                        lbl_room19.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue19.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                        //call();
                        call(lbl_queue19.Text.ToString(), lbl_room19.Text.ToString());
                        NinthColour++;
                    }

                    if (NinthColour == 2 || NinthColour == 3 || NinthColour == 4 || NinthColour == 5 || NinthColour == 6 || NinthColour == 7 || NinthColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue19.ForeColor = Color.Red;
                        lbl_room19.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        NinthColour++;
                    }
                    if (NinthColour == 9 || NinthColour == 10 || NinthColour == 11 || NinthColour == 12 || NinthColour == 13 || NinthColour == 14 || NinthColour == 15 || NinthColour == 16 || NinthColour == 17 || NinthColour == 18)
                    {
                        if (NinthColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = NinthQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        NinthColour++;
                    }
                    if (NinthColour == 19)
                    {

                        NinthColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }

                }

                if (i == 4)
                {

                    lbl_queue20.Text = dc1.Rows[3][0].ToString();
                    lbl_room20.Text = dc1.Rows[3][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc1.Rows[3][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue20.ForeColor = Color.Black;
                    lbl_room20.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    TenthBell = dc1.Rows[3][4].ToString();
                    TenthQueue = Convert.ToInt32(dc1.Rows[3][5].ToString());

                    if (TenthBell == "N" && TenthColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                        lbl_queue20.ForeColor = Color.Red;
                        lbl_room20.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue20.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                       // call();
                       call(lbl_queue20.Text.ToString(), lbl_room20.Text.ToString());
                        TenthColour++;
                    }

                    if (TenthColour == 2 || TenthColour == 3 || TenthColour == 4 || TenthColour == 5 || TenthColour == 6 || TenthColour == 7 || TenthColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue20.ForeColor = Color.Red;
                        lbl_room20.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        TenthColour++;
                    }
                    if (TenthColour == 9 || TenthColour == 10 || TenthColour == 11 || TenthColour == 12 || TenthColour == 13 || TenthColour == 14 || TenthColour == 15 || TenthColour == 16 || TenthColour == 17 || TenthColour == 18)
                    {
                        if (TenthColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = TenthQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        TenthColour++;
                    }
                    if (TenthColour == 19)
                    {

                        TenthColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }

                }


                if (i == 5)
                {

                    lbl_queue21.Text = dc1.Rows[4][0].ToString();
                    lbl_room21.Text = dc1.Rows[4][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc1.Rows[4][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue21.ForeColor = Color.Black;
                    lbl_room21.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    EleventhBel = dc1.Rows[4][4].ToString();
                    EleventhQueue = Convert.ToInt32(dc1.Rows[4][5].ToString());

                    if (EleventhBel == "N" && EleventhColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                        lbl_queue21.ForeColor = Color.Red;
                        lbl_room21.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue21.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                       // call();
                       call(lbl_queue21.Text.ToString(), lbl_room21.Text.ToString());
                        EleventhColour++;
                    }

                    if (EleventhColour == 2 || EleventhColour == 3 || EleventhColour == 4 || EleventhColour == 5 || EleventhColour == 6 || EleventhColour == 7 || EleventhColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue21.ForeColor = Color.Red;
                        lbl_room21.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        EleventhColour++;
                    }
                    if (EleventhColour == 9 || EleventhColour == 10 || EleventhColour == 11 || EleventhColour == 12 || EleventhColour == 13 || EleventhColour == 14 || EleventhColour == 15 || EleventhColour == 16 || EleventhColour == 17 || EleventhColour == 18)
                    {
                        if (EleventhColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = EleventhQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        EleventhColour++;
                    }
                    if (EleventhColour == 19)
                    {

                        EleventhColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }

                }


                if (i == 6)
                {

                   // lbl_queue22.Text = dc1.Rows[5][0].ToString();
                   // lbl_room22.Text = dc1.Rows[5][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc1.Rows[5][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                   // lbl_queue22.ForeColor = Color.Black;
                   // lbl_room22.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    Twelethbell = dc1.Rows[5][4].ToString();
                    TwelethQueue = Convert.ToInt32(dc1.Rows[5][5].ToString());

                    if (Twelethbell == "N" && TwelethColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                       // lbl_queue22.ForeColor = Color.Red;
                       // lbl_room22.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                       // lbl_queue22.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                       // call();
                      // call(lbl_queue22.Text.ToString(), lbl_room22.Text.ToString());
                        TwelethColour++;
                    }

                    if (TwelethColour == 2 || TwelethColour == 3 || TwelethColour == 4 || TwelethColour == 5 || TwelethColour == 6 || TwelethColour == 7 || TwelethColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                       // lbl_queue22.ForeColor = Color.Red;
                       // lbl_room22.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        TwelethColour++;
                    }
                    if (TwelethColour == 9 || TwelethColour == 10 || TwelethColour == 11 || TwelethColour == 12 || TwelethColour == 13 || TwelethColour == 14 || TwelethColour == 15 || TwelethColour == 16 || TwelethColour == 17 || TwelethColour == 18)
                    {
                        if (TwelethColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = TwelethQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        TwelethColour++;
                    }
                    if (TwelethColour == 19)
                    {

                        TwelethColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }

                }

                
            }

            if (tt1 == 1)
            {
               
               
                EightBell = string.Empty;
                NinthBell = string.Empty;
                TenthBell = string.Empty;
                EleventhBel = string.Empty;
                Twelethbell = string.Empty;
               

               
               
                EightColour = 1;
                NinthColour = 1;
                TenthColour = 1;
                EleventhColour = 1;
                TwelethColour = 1;
                

               
                

                lbl_queue18.Text = "";
                lbl_room18.Text = "";

                lbl_queue19.Text = "";
                lbl_room19.Text = "";

                lbl_queue20.Text = "";
                lbl_room20.Text = "";

                lbl_queue21.Text = "";
                lbl_room21.Text = "";

               // lbl_queue22.Text = "";
               // lbl_room22.Text = "";

               
            }

            if (tt1 == 2)
            {


              
                NinthBell = string.Empty;
                TenthBell = string.Empty;
                EleventhBel = string.Empty;
                Twelethbell = string.Empty;
                

              
                NinthColour = 1;
                TenthColour = 1;
                EleventhColour = 1;
                TwelethColour = 1;
               
                lbl_queue19.Text = "";
                lbl_room19.Text = "";

                lbl_queue20.Text = "";
                lbl_room20.Text = "";

                lbl_queue21.Text = "";
                lbl_room21.Text = "";

               // lbl_queue22.Text = "";
               // lbl_room22.Text = "";

               

            }

            if (tt1 == 3)
            {


               
                TenthBell = string.Empty;
                EleventhBel = string.Empty;
                Twelethbell = string.Empty;
               

             
                TenthColour = 1;
                EleventhColour = 1;
                TwelethColour = 1;
               

                lbl_queue20.Text = "";
                lbl_room20.Text = "";

                lbl_queue21.Text = "";
                lbl_room21.Text = "";

               // lbl_queue22.Text = "";
               // lbl_room22.Text = "";

            }

            if (tt1 == 4)
            {


               
                EleventhBel = string.Empty;
                Twelethbell = string.Empty;
               

              
                EleventhColour = 1;
                TwelethColour = 1;
              
                lbl_queue21.Text = "";
                lbl_room21.Text = "";

               // lbl_queue22.Text = "";
               // lbl_room22.Text = "";

               
            }

            if (tt1 == 5)
            {

                
                Twelethbell = string.Empty;
               

           
                TwelethColour = 1;
              
               // lbl_queue22.Text = "";
               // lbl_room22.Text = "";

                
            }


            if (tt1 == 6)
            {


              
            }

           
        }
        else
        {
            SeventhBell = string.Empty;
            EightBell = string.Empty;
            NinthBell = string.Empty;
            TenthBell = string.Empty;
            EleventhBel = string.Empty;
            Twelethbell = string.Empty;
            


          
            SeventhColour = 1;
            EightColour = 1;
            NinthColour = 1;
            TenthColour = 1;
            EleventhColour = 1;
            TwelethColour = 1;
       
            //lbl_dname16.Text = "";
            //lbl_deptname16.Text = "";
            //lbl_status16.Text = "";
            lbl_queue17.Text = "";
            lbl_room17.Text = " ";

            lbl_queue18.Text = "";
            lbl_room18.Text = "";

            lbl_queue19.Text = "";
            lbl_room19.Text = "";

            lbl_queue20.Text = "";
            lbl_room20.Text = "";

            lbl_queue21.Text = "";
            lbl_room21.Text = "";

           // lbl_queue22.Text = "";
           // lbl_room22.Text = "";


        }




        #endregion Consult room






        #region Pathalogy

        int tt2 = dc2.Rows.Count;
        if (dc2.Rows.Count != 0)
        {
            for (int i = 1; i <= tt2; i++)
            {
                

                if (i == 1)
                {

                    lbl_queue29.Text = dc2.Rows[0][0].ToString();
                    lbl_room23.Text = dc2.Rows[0][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc2.Rows[0][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue29.ForeColor = Color.Black;
                    lbl_room23.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    Thirteenbell = dc2.Rows[0][4].ToString();
                    ThirteenQueue = Convert.ToInt32(dc2.Rows[0][5].ToString());

                    if (Thirteenbell == "N" && ThirteenColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                        lbl_queue29.ForeColor = Color.Red;
                        lbl_room23.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue29.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                        //call();
                       call(lbl_queue29.Text.ToString(), lbl_room23.Text.ToString());
                        ThirteenColour++;
                    }

                    if (ThirteenColour == 2 || ThirteenColour == 3 || ThirteenColour == 4 || ThirteenColour == 5 || ThirteenColour == 6 || ThirteenColour == 7 || ThirteenColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue29.ForeColor = Color.Red;
                        lbl_room23.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        ThirteenColour++;
                    }
                    if (ThirteenColour == 9 || ThirteenColour == 10 || ThirteenColour == 11 || ThirteenColour == 12 || ThirteenColour == 13 || ThirteenColour == 14 || ThirteenColour == 15 || ThirteenColour == 16 || ThirteenColour == 17 || ThirteenColour == 18)
                    {
                        if (ThirteenColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = ThirteenQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        ThirteenColour++;
                    }
                    if (ThirteenColour == 19)
                    {

                        ThirteenColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }

                }

                if (i == 2)
                {

                    lbl_queue30.Text = dc2.Rows[1][0].ToString();
                    lbl_room24.Text = dc2.Rows[1][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc2.Rows[1][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue30.ForeColor = Color.Black;
                    lbl_room24.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    Fourteenbell = dc2.Rows[1][4].ToString();
                    FourteenQueue = Convert.ToInt32(dc2.Rows[1][5].ToString());

                    if (Fourteenbell == "N" && FourteenColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                        lbl_queue30.ForeColor = Color.Red;
                        lbl_room24.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue30.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                       //call();
                       call(lbl_queue30.Text.ToString(), lbl_room24.Text.ToString());
                        FourteenColour++;
                    }

                    if (FourteenColour == 2 || FourteenColour == 3 || FourteenColour == 4 || FourteenColour == 5 || FourteenColour == 6 || FourteenColour == 7 || FourteenColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue30.ForeColor = Color.Red;
                        lbl_room24.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        FourteenColour++;
                    }
                    if (FourteenColour == 9 || FourteenColour == 10 || FourteenColour == 11 || FourteenColour == 12 || FourteenColour == 13 || FourteenColour == 14 || FourteenColour == 15 || FourteenColour == 16 || FourteenColour == 17 || FourteenColour == 18)
                    {
                        if (FourteenColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = FourteenQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        FourteenColour++;
                    }
                    if (FourteenColour == 19)
                    {

                        FourteenColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }

                }

                if (i == 3)
                {

                    lbl_queue31.Text = dc2.Rows[2][0].ToString();
                    lbl_room25.Text = dc2.Rows[2][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc2.Rows[2][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue31.ForeColor = Color.Black;
                    lbl_room25.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    Fifteenbell = dc2.Rows[2][4].ToString();
                    FifteenQueue = Convert.ToInt32(dc2.Rows[2][5].ToString());

                    if (Fifteenbell == "N" && FifteenColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                        lbl_queue31.ForeColor = Color.Red;
                        lbl_room25.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue31.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                        //call();
                        call(lbl_queue31.Text.ToString(), lbl_room25.Text.ToString());
                        FifteenColour++;
                    }

                    if (FifteenColour == 2 || FifteenColour == 3 || FifteenColour == 4 || FifteenColour == 5 || FifteenColour == 6 || FifteenColour == 7 || FifteenColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue31.ForeColor = Color.Red;
                        lbl_room25.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        FifteenColour++;
                    }
                    if (FifteenColour == 9 || FifteenColour == 10 || FifteenColour == 11 || FifteenColour == 12 || FifteenColour == 13 || FifteenColour == 14 || FifteenColour == 15 || FifteenColour == 16 || FifteenColour == 17 || FifteenColour == 18)
                    {
                        if (FifteenColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = FifteenQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        FifteenColour++;
                    }
                    if (FifteenColour == 19)
                    {

                        FifteenColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }

                }

                if (i == 4)
                {

                    lbl_queue33.Text = dc2.Rows[3][0].ToString();
                    lbl_room26.Text = dc2.Rows[3][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc2.Rows[3][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue33.ForeColor = Color.Black;
                    lbl_room26.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    Sixteenbell = dc2.Rows[3][4].ToString();
                    SixteenQueue = Convert.ToInt32(dc2.Rows[3][5].ToString());

                    if (Sixteenbell == "N" && SixteenColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                        lbl_queue33.ForeColor = Color.Red;
                        lbl_room26.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue33.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                        //call();
                        call(lbl_queue33.Text.ToString(), lbl_room26.Text.ToString());
                        SixteenColour++;
                    }

                    if (SixteenColour == 2 || SixteenColour == 3 || SixteenColour == 4 || SixteenColour == 5 || SixteenColour == 6 || SixteenColour == 7 || SixteenColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue33.ForeColor = Color.Red;
                        lbl_room26.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        SixteenColour++;
                    }
                    if (SixteenColour == 9 || SixteenColour == 10 || SixteenColour == 11 || SixteenColour == 12 || SixteenColour == 13 || SixteenColour == 14 || SixteenColour == 15 || SixteenColour == 16 || SixteenColour == 17 || SixteenColour == 18)
                    {
                        if (SixteenColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = SixteenQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        SixteenColour++;
                    }
                    if (SixteenColour == 19)
                    {

                        SixteenColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }
                }

                if (i == 5)
                {

                    lbl_queue34.Text = dc2.Rows[4][0].ToString();
                    lbl_room27.Text = dc2.Rows[4][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc2.Rows[4][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                    lbl_queue34.ForeColor = Color.Black;
                    lbl_room27.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    Seventeenbell = dc2.Rows[4][4].ToString();
                    SeventeenQueue = Convert.ToInt32(dc2.Rows[4][5].ToString());

                    if (Seventeenbell == "N" && SeventeenColour == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                        lbl_queue34.ForeColor = Color.Red;
                        lbl_room27.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                        lbl_queue34.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                        //call();
                        call(lbl_queue34.Text.ToString(), lbl_room27.Text.ToString());
                        SeventeenColour++;
                    }

                    if (SeventeenColour == 2 || SeventeenColour == 3 || SeventeenColour == 4 || SeventeenColour == 5 || SeventeenColour == 6 || SeventeenColour == 7 || SeventeenColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                        lbl_queue34.ForeColor = Color.Red;
                        lbl_room27.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        SeventeenColour++;
                    }
                    if (SeventeenColour == 9 || SeventeenColour == 10 || SeventeenColour == 11 || SeventeenColour == 12 || SeventeenColour == 13 || SeventeenColour == 14 || SeventeenColour == 15 || SeventeenColour == 16 || SeventeenColour == 17 || SeventeenColour == 18)
                    {
                        if (SeventeenColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = SeventeenQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        SeventeenColour++;
                    }
                    if (SeventeenColour == 19)
                    {

                        SeventeenColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }
                }


                if (i == 6)
                {

                   // lbl_queue35.Text = dc2.Rows[5][0].ToString();
                   // lbl_room28.Text = dc2.Rows[5][1].ToString();
                    //lbl_status12.Text = serving;
                    queueview.DepartmentID = Convert.ToInt32(dc2.Rows[5][2].ToString());
                    dname1 = queuecontroller.GetDepartmentName(queueview);
                    if (dname1.Rows.Count > 0)
                    {
                        //lbl_dname17.Text = dname1.Rows[0][0].ToString();
                        //  lbl_deptname12.Text = dname1.Rows[0][1].ToString();
                    }
                   // lbl_queue35.ForeColor = Color.Black;
                   // lbl_room28.ForeColor = Color.Black;
                    //lbl_dname17.ForeColor = Color.Black;
                    //lbl_deptname12.ForeColor = Color.Black;
                    //lbl_status12.ForeColor = Color.Black;


                    Eighteenbell = dc2.Rows[5][4].ToString();
                    EighteenQueue = Convert.ToInt32(dc2.Rows[5][5].ToString());

                    if (Eighteenbell == "N" && EighteenQueue == 1)
                    {
                        //  lbl_status12.Text = "Plz Come";
                       // lbl_queue35.ForeColor = Color.Red;
                       // lbl_room28.ForeColor = Color.Red;
                        //  lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;
                       // lbl_queue35.Attributes.Add("style", "text-decoration:blink");
                        //  SystemSounds.Asterisk.Play();
                        //call();
                       // call(lbl_queue35.Text.ToString(), lbl_room28.Text.ToString());
                        EighteenColour++;
                    }

                    if (EighteenColour == 2 || EighteenColour == 3 || EighteenColour == 4 || EighteenColour == 5 || EighteenColour == 6 || EighteenColour == 7 || EighteenColour == 8)
                    {
                        //lbl_status12.Text = "Plz Come";
                       // lbl_queue35.ForeColor = Color.Red;
                       // lbl_room28.ForeColor = Color.Red;
                        //lbl_dname17.ForeColor = Color.Red;

                        //lbl_deptname12.ForeColor = Color.Red;
                        //lbl_status12.ForeColor = Color.Red;

                        EighteenColour++;
                    }
                    if (EighteenColour == 9 || EighteenColour == 10 || EighteenColour == 11 || EighteenColour == 12 || EighteenColour == 13 || EighteenColour == 14 || EighteenColour == 15 || EighteenColour == 16 || EighteenColour == 17 || EighteenColour == 18)
                    {
                        if (EighteenColour == 9)
                        {
                            queueview.SmsStatusFlag = "D";
                            queueview.QueueTnxId = EighteenQueue;
                            queuecontroller.ChangingColourStatus(queueview);
                        }
                        EighteenColour++;
                    }
                    if (EighteenColour == 19)
                    {

                        EighteenColour = 1;
                        //dm status
                        //lbl_status12.Text = serving;

                    }
                }
            }

            if (tt2 == 1)
            {
               
                Fourteenbell = string.Empty;
                Fifteenbell = string.Empty;
                Sixteenbell = string.Empty;
                Seventeenbell = string.Empty;
                Eighteenbell = string.Empty;

               
                FourteenColour = 1;
                FifteenColour = 1;
                SixteenColour = 1;
                SeventeenColour = 1;
                EighteenColour = 1;

              
                lbl_queue30.Text = "";
                lbl_room24.Text = "";

                lbl_queue31.Text = "";
                lbl_room25.Text = "";

                lbl_queue33.Text = "";
                lbl_room26.Text = "";

                lbl_queue34.Text = "";
                lbl_room27.Text = "";

               // lbl_queue35.Text = "";
               // lbl_room28.Text = "";
            }

            if (tt2 == 2)
            {


               
                Fifteenbell = string.Empty;
                Sixteenbell = string.Empty;
                Seventeenbell = string.Empty;
                Eighteenbell = string.Empty;

              
                FifteenColour = 1;
                SixteenColour = 1;
                SeventeenColour = 1;
                EighteenColour = 1;

             
                lbl_queue31.Text = "";
                lbl_room25.Text = "";

                lbl_queue33.Text = "";
                lbl_room26.Text = "";

                lbl_queue34.Text = "";
                lbl_room27.Text = "";

               // lbl_queue35.Text = "";
               // lbl_room28.Text = "";

            }

            if (tt2 == 3)
            {


              
              
                Sixteenbell = string.Empty;
                Seventeenbell = string.Empty;
                Eighteenbell = string.Empty;


               
                SixteenColour = 1;
                SeventeenColour = 1;
                EighteenColour = 1;

            
                lbl_queue33.Text = "";
                lbl_room26.Text = "";

                lbl_queue34.Text = "";
                lbl_room27.Text = "";

              //  lbl_queue35.Text = "";
               // lbl_room28.Text = "";

            }

            if (tt2 == 4)
            {


               
                Seventeenbell = string.Empty;
                Eighteenbell = string.Empty;


                SeventeenColour = 1;
                EighteenColour = 1;

               
                lbl_queue34.Text = "";
                lbl_room27.Text = "";

               // lbl_queue35.Text = "";
               // lbl_room28.Text = "";
            }

            if (tt2 == 5)
            {

               
                Eighteenbell = string.Empty;

               
                EighteenColour = 1;

            
               // lbl_queue35.Text = "";
               // lbl_room28.Text = "";
            }


            if (tt2 == 6)
            {


          
            }

                  }
        else
        {
           
            Thirteenbell = string.Empty;
            Fourteenbell = string.Empty;
            Fifteenbell = string.Empty;
            Sixteenbell = string.Empty;
            Seventeenbell = string.Empty;
            Eighteenbell = string.Empty;



           
            ThirteenColour = 1;
            FourteenColour = 1;
            FifteenColour = 1;
            SixteenColour = 1;
            SeventeenColour = 1;
            EighteenColour = 1;

            
            lbl_queue29.Text = "";
            lbl_room23.Text = "";

            lbl_queue30.Text = "";
            lbl_room24.Text = "";

            lbl_queue31.Text = "";
            lbl_room25.Text = "";

            lbl_queue33.Text = "";
            lbl_room26.Text = "";

            lbl_queue34.Text = "";
            lbl_room27.Text = "";

           // lbl_queue35.Text = "";
           // lbl_room28.Text = "";

        }








        #endregion Pathology













    }
    #endregion Getting QueueNumber


    protected void Timer1_Tick(object sender, EventArgs e)
    {
        GettingQueueNo();
        GettingMissedQueueNo();
       // GettingNextQueue();
       //Label722.Text = DateTime.Now.ToString();
    }

    // Loading Scroll Text and Logo
    public void DisplayLoad()
    {
        QueueController queuecntrl = new QueueController();
        QueueView quvw = new QueueView();
        DataTable datadisplay = new DataTable();
        datadisplay = queuecntrl.GetDisplayScrollText(quvw);
        //Label7.Text = datadisplay.Rows[0][0].ToString();
        //Image4.ImageUrl = datadisplay.Rows[0][1].ToString();
        //Image3.ImageUrl = datadisplay.Rows[0][2].ToString();


    }
    public void call(string xStr, string yStr)
    {
         xStr = Regex.Replace(xStr, @"(?<=.)(?!$)", " ");
         yStr = Regex.Replace(yStr, @"(?<=.)(?!$)", " ");
        string tx = "Token Number Is "+" " + xStr + "Room Number Is " + yStr;
        //ScriptManager.RegisterStartupScript(this, GetType(), "play", "play();", true);
        //string script = String.Format("speak({0})", tx);
        ScriptManager.RegisterStartupScript(this, GetType(), "speak", "speak('"+tx+"');", true);
    }
    public void call()
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "play", "play();", true);
       // string script = String.Format("speak({0},{1})", xStr, yStr);
        //ScriptManager.RegisterStartupScript(this, GetType(), "speak", "speak();", true);
    }

    //Getting Missed Queue Number

    public void GettingMissedQueueNo()
    {
        QueueView queueview = new QueueView();
        QueueController queuecontroller = new QueueController();
        DataTable dt = new DataTable();

        try
        {
            
            dtmissedqueue = null;
            dt = queuecontroller.GetMissedQueue(queueview);
            if (dt.Rows.Count != 0)
            {
                TotalQueue1 = dt.Rows.Count;

                
                if (TotalQueue1 != 0)
                {
                    for (int i = 1; i <= TotalQueue1; i++)
                    {
                        if (i == 1)
                        {
                          Label47.Text = dt.Rows[0][0].ToString();
                          // Label47.Text = System.Drawing.Color.White.ToString();
                            //lbl_dpt1queue1.Content = dt.Rows[0][0].ToString();


                        }
                        if (i == 2)
                        {
                            //lbl_dpt1room2.Content = dt.Rows[1][1].ToString();
                           Label48.Text = dt.Rows[1][0].ToString();


                        }
                        if (i == 3)
                        {
                            Label49.Text = dt.Rows[2][0].ToString();
                            // lbl_dpt1queue7.Content = dt.Rows[1][0].ToString();

                        }
                        if (i == 4)
                        {
                            //lbl_dpt1room2.Content = dt.Rows[1][1].ToString();
                            Label50.Text = dt.Rows[3][0].ToString();

                        }

                    }

                    if (TotalQueue1 == 1)
                    {

                        Label48.Text = "";
                        Label49.Text = "";
                        Label50.Text= "";
                        //lbl_dpt1queue3.Content = "";
                        //lbl_dpt1room4.Content = "";
                        //lbl_dpt1queue4.Content = "";
                        //lbl_dpt1room5.Content = "";
                        //lbl_dpt1queue5.Content = "";
                        //lbl_dpt1room6.Content = "";
                        //lbl_dpt1queue6.Content = "";
                    }
                    else if (TotalQueue1 == 2)
                    {


                        //lbl_dpt1roo7.Content = "";
                        Label49.Text = "";
                        Label50.Text = "";
                        //lbl_dpt1room8.Content = "";
                        //lbl_dpt1room3.Content = "";
                        //lbl_dpt1queue3.Content = "";
                        //lbl_dpt1room4.Content = "";
                        //lbl_dpt1queue4.Content = "";
                        //lbl_dpt1room5.Content = "";
                        //lbl_dpt1queue5.Content = "";
                        //lbl_dpt1room6.Content = "";
                        //lbl_dpt1queue6.Content = "";
                    }
                    else if (TotalQueue1 == 3)
                    {


                        //lbl_dpt1queue7.Content = "";
                        Label50.Text = "";
                        //lbl_dpt1room8.Content = "";
                        //    lbl_dpt1room4.Content = "";
                        //    lbl_dpt1queue4.Content = "";
                        //    lbl_dpt1room5.Content = "";
                        //    lbl_dpt1queue5.Content = "";
                        //    lbl_dpt1room6.Content = "";
                        //    lbl_dpt1queue6.Content = "";
                    }
                }
                else
                {

                    Label47.Text = "";
                    Label48.Text = "";
                    Label49.Text = "";
                    Label50.Text = "";

                    //lbl_dpt1room8.Content = "";
                    //lbl_dpt1room7.Content = "";
                }

            }
            else 
            {

                Label47.Text = "";
                Label48.Text = "";
                Label49.Text = "";
                Label50.Text = "";
                //lbl_miss1.Text = "";
                //lbl_miss2.Text = "";
                //lbl_miss3.Text= "";
                //lbl_miss4.Text = "";
                //lbl_dpt1room8.Content = "";
                //lbl_dpt1room7.Content = "";
            }

        }
        catch (Exception ex)
        {
            
            throw ex;
        }
    }

}