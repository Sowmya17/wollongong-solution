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

public partial class DisplayMap : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
 
        if (!IsPostBack)
        {
            Labeltime.Text = DateTime.Now.ToShortDateString();
            // lbl_r2.ForeColor = Color.Yellow;
            waittime();
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width)-(2/2);var Mtop = (screen.height)-(1200/2);window.open('print_map.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

        }
       
    }

    public void waittime()
    {
        DataTable deptid = new DataTable();
        DataTable dt = new DataTable();
        DataTable dtserv = new DataTable();
        DateTime now = new DateTime();
        DateTime WaitStart = new DateTime();
        DateTime ServStart = new DateTime();
        int count = 0,min=0,serving=0,servcount=0,big=0;
        string lbl = "";
        QueueController queuecontroller = new QueueController();
        allgreen();
        deptid = queuecontroller.GetWaitingTimeDeptid();
        if (deptid.Rows.Count != 0)
        {
            for (int i = 0; i < deptid.Rows.Count; i++)
            {
                count = 0;
                min = 0;
                serving = 0;
                servcount = 0;
                big = 0;
                dt = queuecontroller.GetWaitingTime(Convert.ToInt32(deptid.Rows[i][0].ToString()));
                
                count = dt.Rows.Count;
                count = count * 5;
                
                dtserv = queuecontroller.GetServingTime(Convert.ToInt32(deptid.Rows[i][0].ToString()));
                servcount = dtserv.Rows.Count;

                if (count > 0)
                {
                    if (dt.Rows[0][3].ToString() == "")
                    {
                        WaitStart = Convert.ToDateTime(dt.Rows[0][2].ToString());
                        now = DateTime.Now;
                        min = (int)(now - WaitStart).TotalMinutes;
                    }
                }

                if (servcount > 0)
                {
                    if (dtserv.Rows[0][3].ToString() == "")
                    {
                        ServStart = Convert.ToDateTime(dtserv.Rows[0][2].ToString());
                        now = DateTime.Now;
                        serving = (int)(now - ServStart).TotalMinutes;
                    }

                }
                lbl = deptid.Rows[i][1].ToString();
                lbl = lbl.Trim();
                big = count;
                if (min > big)
                    big = min;
                if (serving > big)
                    big = serving;
                if (count ==min && count==serving)
                {
                    if (count <= 30)
                    {

                        Green(lbl);
                        //lbl.ForeColor = ConsoleColor.LawnGreen;
                    }
                    else if (count > 30 && count <= 60)
                    {
                        Yellow(lbl);
                    }
                    else if (count > 60)
                    {

                        Red(lbl);
                    }
                }
                else 
                {

                   
                        if (big <= 30)
                        {

                            Green(lbl);
                            //lbl.ForeColor = ConsoleColor.LawnGreen;
                        }
                        else if (big > 30 && big <= 60)
                        {
                            Yellow(lbl);
                        }
                        else if (big > 60)
                        {

                            Red(lbl);
                        }
                    
                }

            }
        }
        // dt = queuecontroller.GetWaitingTime(1);

    }

    public void allgreen()
    {

        lbl_a1.ForeColor = Color.LawnGreen;
        lbl_a2.ForeColor = Color.LawnGreen;
        lbl_a3.ForeColor = Color.LawnGreen;
        lbl_a4.ForeColor = Color.LawnGreen;
        lbl_a5.ForeColor = Color.LawnGreen;
        lbl_a6.ForeColor = Color.LawnGreen;
        lbl_a7.ForeColor = Color.LawnGreen;
        lbl_a8.ForeColor = Color.LawnGreen;
        lbl_a9.ForeColor = Color.LawnGreen;
        lbl_a10.ForeColor = Color.LawnGreen;
        lbl_a11.ForeColor = Color.LawnGreen;
        lbl_a12.ForeColor = Color.LawnGreen;
        lbl_b1.ForeColor = Color.LawnGreen;

        lbl_b2.ForeColor = Color.LawnGreen;

        lbl_b3.ForeColor = Color.LawnGreen;

        lbl_b4.ForeColor = Color.LawnGreen;

        lbl_b5.ForeColor = Color.LawnGreen;

        lbl_b6.ForeColor = Color.LawnGreen;

        lbl_b7.ForeColor = Color.LawnGreen;

        lbl_b8.ForeColor = Color.LawnGreen;



        lbl_r1.ForeColor = Color.LawnGreen;

        lbl_r2.ForeColor = Color.LawnGreen;

        lbl_r3.ForeColor = Color.LawnGreen;

        lbl_r4.ForeColor = Color.LawnGreen;


        lbl_plaster.ForeColor = Color.LawnGreen;

        lbl_plaster.ForeColor = Color.LawnGreen;



        lbl_ar.ForeColor = Color.LawnGreen;

        lbl_br.ForeColor = Color.LawnGreen;

        lbl_podb.ForeColor = Color.LawnGreen;
        lbl_poda.ForeColor = Color.LawnGreen;







    }
    public void Green(string str)
    {
        switch (str)
        {
            case "A1": lbl_a1.ForeColor = Color.LawnGreen;
                break;
            case "A2": lbl_a2.ForeColor = Color.LawnGreen;
                break;
            case "A3": lbl_a3.ForeColor = Color.LawnGreen;
                break;
            case "A4": lbl_a4.ForeColor = Color.LawnGreen;
                break;
            case "A5": lbl_a5.ForeColor = Color.LawnGreen;
                break;
            case "A6": lbl_a6.ForeColor = Color.LawnGreen;
                break;
            case "A7": lbl_a7.ForeColor = Color.LawnGreen;
                break;
            case "A8": lbl_a8.ForeColor = Color.LawnGreen;
                break;
            case "A9": lbl_a9.ForeColor = Color.LawnGreen;
                break;
            case "A10": lbl_a10.ForeColor = Color.LawnGreen;
                break;
            case "A11": lbl_a11.ForeColor = Color.LawnGreen;
                break;
            case "A12": lbl_a12.ForeColor = Color.LawnGreen;
                break;


            case "B1": lbl_b1.ForeColor = Color.LawnGreen;
                break;
            case "B2": lbl_b2.ForeColor = Color.LawnGreen;
                break;
            case "B3": lbl_b3.ForeColor = Color.LawnGreen;
                break;
            case "B4": lbl_b4.ForeColor = Color.LawnGreen;
                break;
            case "B5": lbl_b5.ForeColor = Color.LawnGreen;
                break;
            case "B6": lbl_b6.ForeColor = Color.LawnGreen;
                break;
            case "B7": lbl_b7.ForeColor = Color.LawnGreen;
                break;
            case "B8": lbl_b8.ForeColor = Color.LawnGreen;
                break;


            case "R1": lbl_r1.ForeColor = Color.LawnGreen;
                break;
            case "R2": lbl_r2.ForeColor = Color.LawnGreen;
                break;
            case "R3": lbl_r3.ForeColor = Color.LawnGreen;
                break;
            case "R4": lbl_r4.ForeColor = Color.LawnGreen;
                break;

            case "PLA1": lbl_plaster.ForeColor = Color.LawnGreen;
                break;
            case "PLA2": lbl_plaster.ForeColor = Color.LawnGreen;
                break;


            case "AR": lbl_ar.ForeColor = Color.LawnGreen;
                break;
            case "BR": lbl_br.ForeColor = Color.LawnGreen;
                break;

            case "POD1": lbl_podb.ForeColor = Color.LawnGreen;
                break;
            case "POD2": lbl_poda.ForeColor = Color.LawnGreen;
                break;







            default: break;
        }
    }
    public void Yellow(string str)
    {
        switch (str)
        {
            case "A1": lbl_a1.ForeColor = Color.Yellow;
                break;
            case "A2": lbl_a2.ForeColor = Color.Yellow;
                break;
            case "A3": lbl_a3.ForeColor = Color.Yellow;
                break;
            case "A4": lbl_a4.ForeColor = Color.Yellow;
                break;
            case "A5": lbl_a5.ForeColor = Color.Yellow;
                break;
            case "A6": lbl_a6.ForeColor = Color.Yellow;
                break;
            case "A7": lbl_a7.ForeColor = Color.Yellow;
                break;
            case "A8": lbl_a8.ForeColor = Color.Yellow;
                break;
            case "A9": lbl_a9.ForeColor = Color.Yellow;
                break;
            case "A10": lbl_a10.ForeColor = Color.Yellow;
                break;
            case "A11": lbl_a11.ForeColor = Color.Yellow;
                break;
            case "A12": lbl_a12.ForeColor = Color.Yellow;
                break;


            case "B1": lbl_b1.ForeColor = Color.Yellow;
                break;
            case "B2": lbl_b2.ForeColor = Color.Yellow;
                break;
            case "B3": lbl_b3.ForeColor = Color.Yellow;
                break;
            case "B4": lbl_b4.ForeColor = Color.Yellow;
                break;
            case "B5": lbl_b5.ForeColor = Color.Yellow;
                break;
            case "B6": lbl_b6.ForeColor = Color.Yellow;
                break;
            case "B7": lbl_b7.ForeColor = Color.Yellow;
                break;
            case "B8": lbl_b8.ForeColor = Color.Yellow;
                break;


            case "R1": lbl_r1.ForeColor = Color.Yellow;
                break;
            case "R2": lbl_r2.ForeColor = Color.Yellow;
                break;
            case "R3": lbl_r3.ForeColor = Color.Yellow;
                break;
            case "R4": lbl_r4.ForeColor = Color.Yellow;
                break;

            case "PLA1": lbl_plaster.ForeColor = Color.Yellow;
                break;
            case "PLA2": lbl_plaster.ForeColor = Color.Yellow;
                break;


            case "AR": lbl_ar.ForeColor = Color.Yellow;
                break;
            case "BR": lbl_br.ForeColor = Color.Yellow;
                break;

            case "POD1": lbl_podb.ForeColor = Color.Yellow;
                break;
            case "POD2": lbl_poda.ForeColor = Color.Yellow;
                break;







            default: break;
        }
    }

    public void Red(string str)
    {
        switch (str)
        {
            case "A1": lbl_a1.ForeColor = Color.Red;
                break;
            case "A2": lbl_a2.ForeColor = Color.Red;
                break;
            case "A3": lbl_a3.ForeColor = Color.Red;
                break;
            case "A4": lbl_a4.ForeColor = Color.Red;
                break;
            case "A5": lbl_a5.ForeColor = Color.Red;
                break;
            case "A6": lbl_a6.ForeColor = Color.Red;
                break;
            case "A7": lbl_a7.ForeColor = Color.Red;
                break;
            case "A8": lbl_a8.ForeColor = Color.Red;
                break;
            case "A9": lbl_a9.ForeColor = Color.Red;
                break;
            case "A10": lbl_a10.ForeColor = Color.Red;
                break;
            case "A11": lbl_a11.ForeColor = Color.Red;
                break;
            case "A12": lbl_a12.ForeColor = Color.Red;
                break;


            case "B1": lbl_b1.ForeColor = Color.Red;
                break;
            case "B2": lbl_b2.ForeColor = Color.Red;
                break;
            case "B3": lbl_b3.ForeColor = Color.Red;
                break;
            case "B4": lbl_b4.ForeColor = Color.Red;
                break;
            case "B5": lbl_b5.ForeColor = Color.Red;
                break;
            case "B6": lbl_b6.ForeColor = Color.Red;
                break;
            case "B7": lbl_b7.ForeColor = Color.Red;
                break;
            case "B8": lbl_b8.ForeColor = Color.Red;
                break;


            case "R1": lbl_r1.ForeColor = Color.Red;
                break;
            case "R2": lbl_r2.ForeColor = Color.Red;
                break;
            case "R3": lbl_r3.ForeColor = Color.Red;
                break;
            case "R4": lbl_r4.ForeColor = Color.Red;
                break;

            case "PLA1": lbl_plaster.ForeColor = Color.Red;
                break;
            case "PLA2": lbl_plaster.ForeColor = Color.Red;
                break;


            case "AR": lbl_ar.ForeColor = Color.Red;
                break;
            case "BR": lbl_br.ForeColor = Color.Red;
                break;

            case "POD1": lbl_podb.ForeColor = Color.Red;
                break;
            case "POD2": lbl_poda.ForeColor = Color.Red;
                break;







            default: break;
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //Session["UserAuthentication0"] = Convert.ToString(DateTime.Now);
        //Session["UserAuthentication1"] = "Please proceed to the MAC Unit reception";


        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width)-(2/2);var Mtop = (screen.height)-(1200/2);window.open('PrinterHITH.aspx', null, 'height=02,width=02,status=no,toolbar=no,scrollbars=no,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);

        String url = string.Format("Newkioskhome.aspx");
        Response.Redirect(url, false);

    }
}