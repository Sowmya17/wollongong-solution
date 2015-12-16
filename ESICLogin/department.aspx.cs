using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading;
using System.Xml;
using System.IO;
using System.Data;
using System.Net;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;



public partial class department : System.Web.UI.Page
{

    CRTBEL crtview;
    CRTBAL crtcntrl;
    public ArrayList arrloaddepot = new ArrayList();
    public TextInfo myTI = Thread.CurrentThread.CurrentCulture.TextInfo;
    int session1;
    public int room_code = 11;
    public int room_code1 = 11;
    public int room_code2 = 11;
    public int room_code3 = 11;
    public int room_code4 = 9;
    DateTime scheduledate = new DateTime();
    // DateTime today = new DateTime();
    DateTime Monday = new DateTime();
    DateTime Tuesday = new DateTime();
    DateTime Wednesday = new DateTime();
    DateTime Thursday = new DateTime();
    DateTime Friday = new DateTime();
    DateTime today = new DateTime();
    DateTime Monday1 = new DateTime();
    DateTime Tuesday1 = new DateTime();
    DateTime Wednesday1 = new DateTime();
    DateTime Thursday1 = new DateTime();
    DateTime Friday1 = new DateTime();
    DateTime today1 = new DateTime();

    public string one = "";
    public string two = "";
    public string three = "";
    public string four = "";
    public string five = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        crtview = new CRTBEL();
        crtcntrl = new CRTBAL();
        Label1.Text = "14th";
        Label33.Text = "15th";
        Label34.Text = "16th";
        Label38.Text = "17th";
        Label39.Text = "18th";
        Label2.Text = "21st";
        Label40.Text = "22nd";
        Label41.Text = "23rd";
        Label42.Text = "24th";
        Label43.Text = "25th";


        //.Text = "2015-09-09";
        crtview.room_code = room_code;
        //scheduledate = Convert.ToDateTime("09/09/2015");
        crtview.scheduledate = scheduledate;
        session1 = 1;
        crtview.session1 = session1;
        DataTable dtbl = new DataTable();
        ListItem list1 = new ListItem();
        try
        {
            crtcntrl = new CRTBAL();
            dtbl = crtcntrl.CompareDepartSchedule(scheduledate, session1, room_code);
            if (dtbl.Rows.Count > 0)
            {

                foreach (DataRow dr in dtbl.Rows)
                {

                    Button1.Text = myTI.ToTitleCase(dr["department_desc"].ToString());
                    one = dr["schedule_id"].ToString();
                    //int depotid = Int32.Parse(dr["department_id"].ToString());
                    //arrloaddepot.Add(new CRTAddValue(depotname, depotid));

                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
        }

        //A1M2_schedule();
        //A1T1_schedule();
        //A1T2_schedule();
        date();
        displaya1();
        displaya2();
        displaya3();
        displaya4();
        displaya5();
        displaya6();
        displaya7();
        displaya8();
        displaya9();
        displaya10();
        displaya11();
        displaya12();
        displayab1();
        displayab2();
        displayab3();
        displayab4();
        displayab5();
        displayab6();
        displayab7();
        displayab8();


    }

    public void date()
    {
        DateTime dt = new DateTime();
        today = DateTime.Now;
        string day = Convert.ToString(today.DayOfWeek);
        switch (day)
        {
            case "Monday":

                Monday = today;
                Tuesday = today.AddDays(1);
                Wednesday = today.AddDays(2);
                Thursday = today.AddDays(3);
                Friday = today.AddDays(4);
                Monday1 = today.AddDays(7);
                Tuesday1 = today.AddDays(8);
                Wednesday1 = today.AddDays(9);
                Thursday1 = today.AddDays(10);
                Friday1 = today.AddDays(11);
                break;
            case "Tuesday":
                Monday = today.AddDays(-1);
                Tuesday = today;
                Wednesday = today.AddDays(1);
                Thursday = today.AddDays(2);
                Friday = today.AddDays(3);
                Monday1 = today.AddDays(6);
                Tuesday1 = today.AddDays(7);
                Wednesday1 = today.AddDays(8);
                Thursday1 = today.AddDays(9);
                Friday1 = today.AddDays(10);
                break;
            case "Wednesday":

                Monday = today.AddDays(-2);
                Tuesday = today.AddDays(-1);
                Wednesday = today;
                Thursday = today.AddDays(1);
                Friday = today.AddDays(2);
                Monday1 = today.AddDays(5);
                Tuesday1 = today.AddDays(6);
                Wednesday1 = today.AddDays(7);
                Thursday1 = today.AddDays(8);
                Friday1 = today.AddDays(9);
                break;
            case "Thursday":
                Monday = today.AddDays(-3);
                Tuesday = today.AddDays(-2);
                Wednesday = today.AddDays(-1);
                Thursday = today;
                Friday = today.AddDays(1);
                Monday1 = today.AddDays(4);
                Tuesday1 = today.AddDays(5);
                Wednesday1 = today.AddDays(6);
                Thursday1 = today.AddDays(7);
                Friday1 = today.AddDays(8);
                break;
            case "Friday":
                Monday = today.AddDays(-4);
                Tuesday = today.AddDays(-3);
                Wednesday = today.AddDays(-2);
                Thursday = today.AddDays(-1);
                Friday = today;
                Monday1 = today.AddDays(3);
                Tuesday1 = today.AddDays(4);
                Wednesday1 = today.AddDays(5);
                Thursday1 = today.AddDays(6);
                Friday1 = today.AddDays(7);
                break;
            case "Saturday":
                Monday = today.AddDays(2);
                Tuesday = today.AddDays(3);
                Wednesday = today.AddDays(4);
                Thursday = today.AddDays(5);
                Friday = today.AddDays(6);
                Monday1 = today.AddDays(10);
                Tuesday1 = today.AddDays(11);
                Wednesday1 = today.AddDays(12);
                Thursday1 = today.AddDays(13);
                Friday1 = today.AddDays(14);
                break;

            case "Sunday":
                Monday = today.AddDays(1);
                Tuesday = today.AddDays(2);
                Wednesday = today.AddDays(3);
                Thursday = today.AddDays(4);
                Friday = today.AddDays(5);
                Monday1 = today.AddDays(11);
                Tuesday1 = today.AddDays(12);
                Wednesday1 = today.AddDays(13);
                Thursday1 = today.AddDays(14);
                Friday1 = today.AddDays(15);
                break;
        }
    }

    public string button1 = "", button2 = "", button3 = "", button4 = "", button5 = "", button6 = "", button7 = "", button8 = "", button9 = "", button10 = "",
        button11 = "", button12 = "", button13 = "", button17 = "", button18 = "", button19 = "", button20 = "", button14 = "", button21 = "", button22 = "",
        button23 = " ", button24 = " ", button15 = " ", button25 = " ", button26 = " ", button27 = " ", button28 = " ", button16 = " ", button29 = " ", button30 = " ",
        button31 = "", button32 = "", button33 = "", button34 = "", button35 = "", button36 = "", button39 = "", button40 = "", button41 = "", button37 = "",
        button42 = "", button43 = "", button44 = "", button45 = "", button38 = "", button52 = "", button53 = "", button54 = "", button46 = "", button55 = "",
        button49 = "", button56 = "", button57 = "", button47 = "", button48 = "", button58 = "", button59 = "", button51 = "", button50 = "", button60 = "",
        button61 = "", button62 = "", button63 = "", button64 = "", button65 = "", button66 = "", button67 = "", button68 = "", button69 = "", button70 = "",
        button71 = "", button72 = "", button73 = "", button74 = "", button75 = "", button76 = "", button77 = "", button78 = "", button79 = "", button80 = "",
        button81 = "", button82 = "", button83 = "", button84 = "", button85 = "", button86 = "", button87 = "", button385 = "", button88 = "", button89 = "",
        button90 = "", button354 = "", button346 = "", button315 = "", button93 = "", button91 = "", button92 = "", button387 = "", button94 = "", button95 = "",
        button314 = "", button96 = "", button397 = "", button337 = "", button381 = "", button380 = "", button97 = "", button376 = "", button379 = "", button313 = "",
        button336 = "", button335 = "", button334 = "", button333 = "", button332 = "", button331 = "", button330 = "", button329 = "", button328 = "", button327 = "",
        button310 = "", button311 = "", button347 = "", button312 = "", button361 = "", button360 = "", button395 = "", button309 = "", button98 = "", button308 = "",
        button307 = "", button305 = "", button349 = "", button306 = "", button373 = "", button304 = "", button303 = "", button302 = "", button301 = "", button300 = "",
        button293 = "", button294 = "", button391 = "", button295 = "", button372 = "", button292 = "", button390 = "", button291 = "", button99 = "", button290 = "",
        button288 = "", button289 = "", button393 = "", button285 = "", button371 = "", button287 = "", button389 = "", button286 = "", button100 = "", button284 = "",
        button277 = "", button276 = "", button367 = "", button275 = "", button370 = "", button274 = "", button358 = "", button273 = "", button357 = "", button272 = "",
        button269 = "", button270 = "", button352 = "", button271 = "", button369 = "", button268 = "", button267 = "", button266 = "", button265 = "", button264 = "",
        button251 = "", button250 = "", button249 = "", button248 = "", button247 = "", button242 = "", button243 = "", button244 = "", button245 = "", button246 = "",
        button241 = "", button240 = "", button239 = "", button238 = "", button237 = "", button236 = "", button235 = "", button234 = "", button233 = "", button232 = "",
        button216 = "", button215 = "", button214 = "", button213 = "", button212 = "", button217 = "", button218 = "", button219 = "", button220 = "", button221 = "",
        button226 = "", button225 = "", button224 = "", button222 = "", button223 = "", button227 = "", button228 = "", button229 = "", button230 = "", button231 = "",
        button256 = "", button255 = "", button254 = "", button253 = "", button252 = "", button257 = "", button258 = "", button351 = "", button259 = "", button260 = "",
        button262 = "", button356 = "", button261 = "", button355 = "", button211 = "", button263 = "", button208 = "", button368 = "", button209 = "", button210 = "",
        button279 = "", button207 = "", button278 = "", button206 = "", button205 = "", button280 = "", button202 = "", button394 = "", button203 = "", button204 = "",
        button282 = "", button201 = "", button281 = "", button200 = "", button199 = "", button283 = "", button198 = "", button392 = "", button197 = "", button196 = "",
        button296 = "", button193 = "", button297 = "", button194 = "", button195 = "", button299 = "", button192 = "", button350 = "", button191 = "", button190 = "",
        button359 = "", button187 = "", button298 = "", button188 = "", button189 = "", button186 = "", button185 = "", button348 = "", button184 = "", button183 = "",
        button320 = "", button319 = "", button318 = "", button316 = "", button317 = "", button321 = "", button322 = "", button323 = "", button324 = "", button325 = "",
        button378 = "", button180 = "", button377 = "", button181 = "", button182 = "", button179 = "", button178 = "", button396 = "", button326 = "", button177 = "",
        button176 = "", button175 = "", button388 = "", button174 = "", button173 = "", button172 = "", button171 = "", button345 = "", button170 = "", button169 = "",
        button165 = "", button166 = "", button386 = "", button167 = "", button168 = "", button164 = "", button163 = "", button344 = "", button162 = "", button161 = "",
        button158 = "", button159 = "", button384 = "", button160 = "", button157 = "", button153 = "", button154 = "", button366 = "", button155 = "", button156 = "",
        button152 = "", button151 = "", button383 = "", button150 = "", button149 = "", button148 = "", button147 = "", button365 = "", button146 = "", button145 = "",
        button142 = "", button143 = "", button382 = "", button144 = "", button400 = "", button141 = "", button140 = "", button364 = "", button139 = "", button138 = "",
        button399 = "", button135 = "", button375 = "", button136 = "", button137 = "", button398 = "", button134 = "", button363 = "", button133 = "", button132 = "",
        button128 = "", button129 = "", button374 = "", button130 = "", button131 = "", button127 = "", button353 = "", button362 = "", button126 = "", button125 = "",
        button121 = "", button122 = "", button343 = "", button123 = "", button124 = "", button120 = "", button119 = "", button342 = "", button118 = "", button117 = "",
        button113 = "", button114 = "", button341 = "", button115 = "", button116 = "", button112 = "", button111 = "", button340 = "", button110 = "", button109 = "",
        button104 = "", button105 = "", button339 = "", button106 = "", button108 = "", button101 = "", button102 = "", button338 = "", button103 = "", button107 = "";


    public DataTable fill(DateTime scheduledate, int session1, int room_code1)
    {
        //crtview.room_code = room_code1;
        //scheduledate = Convert.ToDateTime("09/09/2015");
        //crtview.scheduledate = scheduledate;
        //session1 = 2;
        //crtview.session1 = session1;
        DataTable dtbl = new DataTable();
        ListItem list1 = new ListItem();
        try
        {
            crtcntrl = new CRTBAL();

            dtbl = crtcntrl.A1M2CompareDepartSchedule(scheduledate, session1, room_code1);
            //if (dtbl.Rows.Count > 0)
            //{

            //    foreach (DataRow dr in dtbl.Rows)
            //    {

            //        Button6.Text = myTI.ToTitleCase(dr["department_desc"].ToString());
            //        two = dr["schedule_id"].ToString();

            //    }
            //}
            return dtbl;
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
        }

    }

    public void displaya1()
    {
        room_code1 = 11;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 11;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button1.Text = dt.Rows[0][0].ToString();
                    button1 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button101.Text = dt.Rows[0][0].ToString();
                    button101 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 11;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button2.Text = dt.Rows[0][0].ToString();
                    button2 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 11;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button102.Text = dt.Rows[0][0].ToString();
                    button102 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 11;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button3.Text = dt.Rows[0][0].ToString();
                    button3 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button338.Text = dt.Rows[0][0].ToString();
                    button338 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 11;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button4.Text = dt.Rows[0][0].ToString();
                    button4 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button103.Text = dt.Rows[0][0].ToString();
                    button103 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 11;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button5.Text = dt.Rows[0][0].ToString();
                    button5 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 11;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button107.Text = dt.Rows[0][0].ToString();
                    button107 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 11;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button6.Text = dt.Rows[0][0].ToString();
                    button6 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button104.Text = dt.Rows[0][0].ToString();
                    button104 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 11;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button7.Text = dt.Rows[0][0].ToString();
                    button7 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button105.Text = dt.Rows[0][0].ToString();
                    button105 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 11;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button8.Text = dt.Rows[0][0].ToString();
                    button8 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button339.Text = dt.Rows[0][0].ToString();
                    button339 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 11;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button9.Text = dt.Rows[0][0].ToString();
                    button9 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button106.Text = dt.Rows[0][0].ToString();
                    button106 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 11;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button10.Text = dt.Rows[0][0].ToString();
                    button10 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button108.Text = dt.Rows[0][0].ToString();
                    button108 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya2()
    {
        room_code1 = 12;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 12;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button11.Text = dt.Rows[0][0].ToString();
                    button11 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 12;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button112.Text = dt.Rows[0][0].ToString();
                    button112 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 12;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button12.Text = dt.Rows[0][0].ToString();
                    button12 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 12;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button111.Text = dt.Rows[0][0].ToString();
                    button111 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 12;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button13.Text = dt.Rows[0][0].ToString();
                    button13 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 12;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button340.Text = dt.Rows[0][0].ToString();
                    button340 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 12;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button17.Text = dt.Rows[0][0].ToString();
                    button17 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button110.Text = dt.Rows[0][0].ToString();
                    button110 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 12;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button18.Text = dt.Rows[0][0].ToString();
                    button18 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button109.Text = dt.Rows[0][0].ToString();
                    button109 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 12;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button19.Text = dt.Rows[0][0].ToString();
                    button19 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button113.Text = dt.Rows[0][0].ToString();
                    button113 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 12;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button20.Text = dt.Rows[0][0].ToString();
                    button20 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button114.Text = dt.Rows[0][0].ToString();
                    button114 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 12;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button14.Text = dt.Rows[0][0].ToString();
                    button14 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button341.Text = dt.Rows[0][0].ToString();
                    button341 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 12;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button21.Text = dt.Rows[0][0].ToString();
                    button21 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button115.Text = dt.Rows[0][0].ToString();
                    button115 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 12;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button22.Text = dt.Rows[0][0].ToString();
                    button22 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 12;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button116.Text = dt.Rows[0][0].ToString();
                    button116 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya3()
    {
        room_code1 = 13;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 13;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button23.Text = dt.Rows[0][0].ToString();
                    button23 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button120.Text = dt.Rows[0][0].ToString();
                    button120 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 13;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button24.Text = dt.Rows[0][0].ToString();
                    button24 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button119.Text = dt.Rows[0][0].ToString();
                    button119 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 13;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button15.Text = dt.Rows[0][0].ToString();
                    button15 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button342.Text = dt.Rows[0][0].ToString();
                    button342 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 13;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button25.Text = dt.Rows[0][0].ToString();
                    button25 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button118.Text = dt.Rows[0][0].ToString();
                    button118 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 13;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button26.Text = dt.Rows[0][0].ToString();
                    button26 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 13;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button117.Text = dt.Rows[0][0].ToString();
                    button117 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 13;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button27.Text = dt.Rows[0][0].ToString();
                    button27 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button121.Text = dt.Rows[0][0].ToString();
                    button121 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 13;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button28.Text = dt.Rows[0][0].ToString();
                    button28 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 13;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button122.Text = dt.Rows[0][0].ToString();
                    button122 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 13;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button16.Text = dt.Rows[0][0].ToString();
                    button16 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 13;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button343.Text = dt.Rows[0][0].ToString();
                    button343 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 13;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button29.Text = dt.Rows[0][0].ToString();
                    button29 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 13;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button123.Text = dt.Rows[0][0].ToString();
                    button123 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 13;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button30.Text = dt.Rows[0][0].ToString();
                    button30 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button124.Text = dt.Rows[0][0].ToString();
                    button124 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya4()
    {
        room_code1 = 14;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 14;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button31.Text = dt.Rows[0][0].ToString();
                    button31 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 14;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button127.Text = dt.Rows[0][0].ToString();
                    button127 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 14;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button32.Text = dt.Rows[0][0].ToString();
                    button32 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button353.Text = dt.Rows[0][0].ToString();
                    button353 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 14;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button33.Text = dt.Rows[0][0].ToString();
                    button33 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button362.Text = dt.Rows[0][0].ToString();
                    button362 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 14;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button34.Text = dt.Rows[0][0].ToString();
                    button34 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button126.Text = dt.Rows[0][0].ToString();
                    button126 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 14;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button35.Text = dt.Rows[0][0].ToString();
                    button35 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button125.Text = dt.Rows[0][0].ToString();
                    button125 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 14;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button36.Text = dt.Rows[0][0].ToString();
                    button36 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button128.Text = dt.Rows[0][0].ToString();
                    button128 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 14;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button39.Text = dt.Rows[0][0].ToString();
                    button39 = dt.Rows[0][1].ToString();
                }
                dt = null;

                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button129.Text = dt.Rows[0][0].ToString();
                    button129 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 14;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button40.Text = dt.Rows[0][0].ToString();
                    button40 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button374.Text = dt.Rows[0][0].ToString();
                    button374 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 14;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button41.Text = dt.Rows[0][0].ToString();
                    button41 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button130.Text = dt.Rows[0][0].ToString();
                    button130 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 14;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button37.Text = dt.Rows[0][0].ToString();
                    button37 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button131.Text = dt.Rows[0][0].ToString();
                    button131 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya5()
    {
        room_code1 = 15;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 15;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button42.Text = dt.Rows[0][0].ToString();
                    button42 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button398.Text = dt.Rows[0][0].ToString();
                    button398 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 15;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button43.Text = dt.Rows[0][0].ToString();
                    button43 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button134.Text = dt.Rows[0][0].ToString();
                    button134 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 15;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button44.Text = dt.Rows[0][0].ToString();
                    button44 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button363.Text = dt.Rows[0][0].ToString();
                    button363 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 15;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button45.Text = dt.Rows[0][0].ToString();
                    button45 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button133.Text = dt.Rows[0][0].ToString();
                    button133 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 15;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button38.Text = dt.Rows[0][0].ToString();
                    button38 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button132.Text = dt.Rows[0][0].ToString();
                    button132 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 15;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button52.Text = dt.Rows[0][0].ToString();
                    button52 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button399.Text = dt.Rows[0][0].ToString();
                    button399 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 15;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button53.Text = dt.Rows[0][0].ToString();
                    button53 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button135.Text = dt.Rows[0][0].ToString();
                    button135 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 15;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button54.Text = dt.Rows[0][0].ToString();
                    button54 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button375.Text = dt.Rows[0][0].ToString();
                    button375 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 15;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button46.Text = dt.Rows[0][0].ToString();
                    button46 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button136.Text = dt.Rows[0][0].ToString();
                    button136 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 15;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button55.Text = dt.Rows[0][0].ToString();
                    button55 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button137.Text = dt.Rows[0][0].ToString();
                    button137 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya6()
    {
        room_code1 = 16;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 16;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button49.Text = dt.Rows[0][0].ToString();
                    button49 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button141.Text = dt.Rows[0][0].ToString();
                    button141 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 16;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button56.Text = dt.Rows[0][0].ToString();
                    button56 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button140.Text = dt.Rows[0][0].ToString();
                    button140 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 16;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button57.Text = dt.Rows[0][0].ToString();
                    button57 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button364.Text = dt.Rows[0][0].ToString();
                    button364 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 16;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button47.Text = dt.Rows[0][0].ToString();
                    button47 = dt.Rows[0][1].ToString();
                }
                dt = null;
                room_code1 = 16;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button139.Text = dt.Rows[0][0].ToString();
                    button139 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 16;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button48.Text = dt.Rows[0][0].ToString();
                    button48 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 16;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button138.Text = dt.Rows[0][0].ToString();
                    button138 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 16;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button58.Text = dt.Rows[0][0].ToString();
                    button58 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button142.Text = dt.Rows[0][0].ToString();
                    button142 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 16;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button59.Text = dt.Rows[0][0].ToString();
                    button59 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button143.Text = dt.Rows[0][0].ToString();
                    button143 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 16;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button51.Text = dt.Rows[0][0].ToString();
                    button51 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button382.Text = dt.Rows[0][0].ToString();
                    button382 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 16;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button50.Text = dt.Rows[0][0].ToString();
                    button50 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button144.Text = dt.Rows[0][0].ToString();
                    button144 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 16;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button60.Text = dt.Rows[0][0].ToString();
                    button60 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button400.Text = dt.Rows[0][0].ToString();
                    button400 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya7()
    {
        room_code1 = 17;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 17;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button61.Text = dt.Rows[0][0].ToString();
                    button61 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button148.Text = dt.Rows[0][0].ToString();
                    button148 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 17;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button62.Text = dt.Rows[0][0].ToString();
                    button62 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button147.Text = dt.Rows[0][0].ToString();
                    button147 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 17;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button63.Text = dt.Rows[0][0].ToString();
                    button63 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button365.Text = dt.Rows[0][0].ToString();
                    button365 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 17;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button64.Text = dt.Rows[0][0].ToString();
                    button64 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 17;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button146.Text = dt.Rows[0][0].ToString();
                    button146 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 17;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button65.Text = dt.Rows[0][0].ToString();
                    button65 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button145.Text = dt.Rows[0][0].ToString();
                    button145 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 17;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button66.Text = dt.Rows[0][0].ToString();
                    button66 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button152.Text = dt.Rows[0][0].ToString();
                    button152 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 17;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button67.Text = dt.Rows[0][0].ToString();
                    button67 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button151.Text = dt.Rows[0][0].ToString();
                    button151 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 17;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button68.Text = dt.Rows[0][0].ToString();
                    button68 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button383.Text = dt.Rows[0][0].ToString();
                    button383 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 17;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button69.Text = dt.Rows[0][0].ToString();
                    button69 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button150.Text = dt.Rows[0][0].ToString();
                    button150 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 17;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button70.Text = dt.Rows[0][0].ToString();
                    button70 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button149.Text = dt.Rows[0][0].ToString();
                    button149 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya8()
    {
        room_code1 = 18;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 18;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button71.Text = dt.Rows[0][0].ToString();
                    button71 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button153.Text = dt.Rows[0][0].ToString();
                    button153 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 18;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button72.Text = dt.Rows[0][0].ToString();
                    button72 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button154.Text = dt.Rows[0][0].ToString();
                    button154 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 18;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button73.Text = dt.Rows[0][0].ToString();
                    button73 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button366.Text = dt.Rows[0][0].ToString();
                    button366 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 18;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button74.Text = dt.Rows[0][0].ToString();
                    button74 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button155.Text = dt.Rows[0][0].ToString();
                    button155 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 18;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button75.Text = dt.Rows[0][0].ToString();
                    button75 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button156.Text = dt.Rows[0][0].ToString();
                    button156 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 18;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button76.Text = dt.Rows[0][0].ToString();
                    button76 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button158.Text = dt.Rows[0][0].ToString();
                    button158 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 18;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button77.Text = dt.Rows[0][0].ToString();
                    button77 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button159.Text = dt.Rows[0][0].ToString();
                    button159 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 18;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button78.Text = dt.Rows[0][0].ToString();
                    button78 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button384.Text = dt.Rows[0][0].ToString();
                    button384 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 18;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button79.Text = dt.Rows[0][0].ToString();
                    button79 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button160.Text = dt.Rows[0][0].ToString();
                    button160 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 18;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button80.Text = dt.Rows[0][0].ToString();
                    button80 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button157.Text = dt.Rows[0][0].ToString();
                    button157 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya9()
    {
        room_code1 = 19;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 19;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button81.Text = dt.Rows[0][0].ToString();
                    button81 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button164.Text = dt.Rows[0][0].ToString();
                    button164 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 19;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button82.Text = dt.Rows[0][0].ToString();
                    button82 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button163.Text = dt.Rows[0][0].ToString();
                    button163 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 19;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button83.Text = dt.Rows[0][0].ToString();
                    button83 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button344.Text = dt.Rows[0][0].ToString();
                    button344 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 19;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button84.Text = dt.Rows[0][0].ToString();
                    button84 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button162.Text = dt.Rows[0][0].ToString();
                    button162 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 19;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button85.Text = dt.Rows[0][0].ToString();
                    button85 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button161.Text = dt.Rows[0][0].ToString();
                    button161 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 19;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button86.Text = dt.Rows[0][0].ToString();
                    button86 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button165.Text = dt.Rows[0][0].ToString();
                    button165 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 19;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button87.Text = dt.Rows[0][0].ToString();
                    button87 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button166.Text = dt.Rows[0][0].ToString();
                    button166 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 19;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button385.Text = dt.Rows[0][0].ToString();
                    button385 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button386.Text = dt.Rows[0][0].ToString();
                    button386 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 19;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button88.Text = dt.Rows[0][0].ToString();
                    button88 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button167.Text = dt.Rows[0][0].ToString();
                    button167 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 19;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button89.Text = dt.Rows[0][0].ToString();
                    button89 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button168.Text = dt.Rows[0][0].ToString();
                    button168 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya10()
    {
        room_code1 = 20;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 20;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button90.Text = dt.Rows[0][0].ToString();
                    button90 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button172.Text = dt.Rows[0][0].ToString();
                    button172 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 20;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button354.Text = dt.Rows[0][0].ToString();
                    button354 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button171.Text = dt.Rows[0][0].ToString();
                    button171 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 20;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button346.Text = dt.Rows[0][0].ToString();
                    button346 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button345.Text = dt.Rows[0][0].ToString();
                    button345 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 20;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button315.Text = dt.Rows[0][0].ToString();
                    button315 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button170.Text = dt.Rows[0][0].ToString();
                    button170 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 20;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button93.Text = dt.Rows[0][0].ToString();
                    button93 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button169.Text = dt.Rows[0][0].ToString();
                    button169 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 20;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button91.Text = dt.Rows[0][0].ToString();
                    button91 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 20;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button176.Text = dt.Rows[0][0].ToString();
                    button176 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 20;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button92.Text = dt.Rows[0][0].ToString();
                    button92 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button175.Text = dt.Rows[0][0].ToString();
                    button175 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 20;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button387.Text = dt.Rows[0][0].ToString();
                    button387 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button388.Text = dt.Rows[0][0].ToString();
                    button388 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 20;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button94.Text = dt.Rows[0][0].ToString();
                    button94 = dt.Rows[0][1].ToString();
                }
                dt = null;

                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button174.Text = dt.Rows[0][0].ToString();
                    button174 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 20;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button95.Text = dt.Rows[0][0].ToString();
                    button95 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button173.Text = dt.Rows[0][0].ToString();
                    button173 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya11()
    {
        room_code1 = 21;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 21;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button314.Text = dt.Rows[0][0].ToString();
                    button314 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button179.Text = dt.Rows[0][0].ToString();
                    button179 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 21;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button96.Text = dt.Rows[0][0].ToString();
                    button96 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button178.Text = dt.Rows[0][0].ToString();
                    button178 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 21;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button397.Text = dt.Rows[0][0].ToString();
                    button397 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button396.Text = dt.Rows[0][0].ToString();
                    button396 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 21;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button337.Text = dt.Rows[0][0].ToString();
                    button337 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button326.Text = dt.Rows[0][0].ToString();
                    button326 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 21;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button381.Text = dt.Rows[0][0].ToString();
                    button381 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button177.Text = dt.Rows[0][0].ToString();
                    button177 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 21;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button380.Text = dt.Rows[0][0].ToString();
                    button380 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button378.Text = dt.Rows[0][0].ToString();
                    button378 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 21;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button97.Text = dt.Rows[0][0].ToString();
                    button97 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button180.Text = dt.Rows[0][0].ToString();
                    button180 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 21;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button376.Text = dt.Rows[0][0].ToString();
                    button376 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button377.Text = dt.Rows[0][0].ToString();
                    button377 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 21;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button379.Text = dt.Rows[0][0].ToString();
                    button379 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button181.Text = dt.Rows[0][0].ToString();
                    button181 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 21;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button313.Text = dt.Rows[0][0].ToString();
                    button313 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button182.Text = dt.Rows[0][0].ToString();
                    button182 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displaya12()
    {
        room_code1 = 22;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 22;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button336.Text = dt.Rows[0][0].ToString();
                    button336 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button321.Text = dt.Rows[0][0].ToString();
                    button321 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 22;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button335.Text = dt.Rows[0][0].ToString();
                    button335 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button322.Text = dt.Rows[0][0].ToString();
                    button322 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 22;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button334.Text = dt.Rows[0][0].ToString();
                    button334 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button323.Text = dt.Rows[0][0].ToString();
                    button323 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 22;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button333.Text = dt.Rows[0][0].ToString();
                    button333 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button324.Text = dt.Rows[0][0].ToString();
                    button324 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 22;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button332.Text = dt.Rows[0][0].ToString();
                    button332 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 22;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button325.Text = dt.Rows[0][0].ToString();
                    button325 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 22;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button331.Text = dt.Rows[0][0].ToString();
                    button331 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 22;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button320.Text = dt.Rows[0][0].ToString();
                    button320 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 22;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button330.Text = dt.Rows[0][0].ToString();
                    button330 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button319.Text = dt.Rows[0][0].ToString();
                    button319 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 22;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button329.Text = dt.Rows[0][0].ToString();
                    button329 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button318.Text = dt.Rows[0][0].ToString();
                    button318 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 22;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button328.Text = dt.Rows[0][0].ToString();
                    button328 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button316.Text = dt.Rows[0][0].ToString();
                    button316 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 22;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button327.Text = dt.Rows[0][0].ToString();
                    button327 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button317.Text = dt.Rows[0][0].ToString();
                    button317 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displayab1()
    {
        room_code1 = 23;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 23;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button310.Text = dt.Rows[0][0].ToString();
                    button310 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button186.Text = dt.Rows[0][0].ToString();
                    button186 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 23;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button311.Text = dt.Rows[0][0].ToString();
                    button311 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button185.Text = dt.Rows[0][0].ToString();
                    button185 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 23;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button347.Text = dt.Rows[0][0].ToString();
                    button347 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 23;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button348.Text = dt.Rows[0][0].ToString();
                    button348 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 23;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button312.Text = dt.Rows[0][0].ToString();
                    button312 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button184.Text = dt.Rows[0][0].ToString();
                    button184 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 23;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button361.Text = dt.Rows[0][0].ToString();
                    button361 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button183.Text = dt.Rows[0][0].ToString();
                    button183 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 23;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button360.Text = dt.Rows[0][0].ToString();
                    button360 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button359.Text = dt.Rows[0][0].ToString();
                    button359 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 23;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button395.Text = dt.Rows[0][0].ToString();
                    button395 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button187.Text = dt.Rows[0][0].ToString();
                    button187 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 23;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button309.Text = dt.Rows[0][0].ToString();
                    button309 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button298.Text = dt.Rows[0][0].ToString();
                    button298 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 23;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button98.Text = dt.Rows[0][0].ToString();
                    button98 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button188.Text = dt.Rows[0][0].ToString();
                    button188 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 23;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button308.Text = dt.Rows[0][0].ToString();
                    button308 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button189.Text = dt.Rows[0][0].ToString();
                    button189 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displayab2()
    {
        room_code1 = 24;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 24;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button307.Text = dt.Rows[0][0].ToString();
                    button307 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button299.Text = dt.Rows[0][0].ToString();
                    button299 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 24;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button305.Text = dt.Rows[0][0].ToString();
                    button305 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button192.Text = dt.Rows[0][0].ToString();
                    button192 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 24;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button349.Text = dt.Rows[0][0].ToString();
                    button349 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button350.Text = dt.Rows[0][0].ToString();
                    button350 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 24;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button306.Text = dt.Rows[0][0].ToString();
                    button306 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button191.Text = dt.Rows[0][0].ToString();
                    button191 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 24;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button373.Text = dt.Rows[0][0].ToString();
                    button373 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button190.Text = dt.Rows[0][0].ToString();
                    button190 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 24;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button304.Text = dt.Rows[0][0].ToString();
                    button304 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button296.Text = dt.Rows[0][0].ToString();
                    button296 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 24;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button303.Text = dt.Rows[0][0].ToString();
                    button303 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button193.Text = dt.Rows[0][0].ToString();
                    button193 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 24;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button302.Text = dt.Rows[0][0].ToString();
                    button302 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button297.Text = dt.Rows[0][0].ToString();
                    button297 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 24;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button301.Text = dt.Rows[0][0].ToString();
                    button301 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button194.Text = dt.Rows[0][0].ToString();
                    button194 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 24;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button300.Text = dt.Rows[0][0].ToString();
                    button300 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button195.Text = dt.Rows[0][0].ToString();
                    button195 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displayab3()
    {
        room_code1 = 25;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 25;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button293.Text = dt.Rows[0][0].ToString();
                    button293 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button283.Text = dt.Rows[0][0].ToString();
                    button283 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 25;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button294.Text = dt.Rows[0][0].ToString();
                    button294 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button198.Text = dt.Rows[0][0].ToString();
                    button198 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 25;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button391.Text = dt.Rows[0][0].ToString();
                    button391 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button392.Text = dt.Rows[0][0].ToString();
                    button392 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 25;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button295.Text = dt.Rows[0][0].ToString();
                    button295 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button197.Text = dt.Rows[0][0].ToString();
                    button197 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 25;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button372.Text = dt.Rows[0][0].ToString();
                    button372 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button196.Text = dt.Rows[0][0].ToString();
                    button196 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 25;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button292.Text = dt.Rows[0][0].ToString();
                    button292 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button282.Text = dt.Rows[0][0].ToString();
                    button282 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 25;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button390.Text = dt.Rows[0][0].ToString();
                    button390 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button201.Text = dt.Rows[0][0].ToString();
                    button201 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 25;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button291.Text = dt.Rows[0][0].ToString();
                    button291 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 25;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button281.Text = dt.Rows[0][0].ToString();
                    button281 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 25;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button99.Text = dt.Rows[0][0].ToString();
                    button99 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button200.Text = dt.Rows[0][0].ToString();
                    button200 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 25;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button290.Text = dt.Rows[0][0].ToString();
                    button290 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button199.Text = dt.Rows[0][0].ToString();
                    button199 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displayab4()
    {
        room_code1 = 27;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 27;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button288.Text = dt.Rows[0][0].ToString();
                    button288 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button280.Text = dt.Rows[0][0].ToString();
                    button280 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 27;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button289.Text = dt.Rows[0][0].ToString();
                    button289 = dt.Rows[0][1].ToString();
                }
                dt = null;

                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button202.Text = dt.Rows[0][0].ToString();
                    button202 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 27;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button393.Text = dt.Rows[0][0].ToString();
                    button393 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button394.Text = dt.Rows[0][0].ToString();
                    button394 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 27;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button285.Text = dt.Rows[0][0].ToString();
                    button285 = dt.Rows[0][1].ToString();
                }
                dt = null;

                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button203.Text = dt.Rows[0][0].ToString();
                    button203 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 27;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button371.Text = dt.Rows[0][0].ToString();
                    button371 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button204.Text = dt.Rows[0][0].ToString();
                    button204 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 27;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button287.Text = dt.Rows[0][0].ToString();
                    button287 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button279.Text = dt.Rows[0][0].ToString();
                    button279 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 27;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button389.Text = dt.Rows[0][0].ToString();
                    button389 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button207.Text = dt.Rows[0][0].ToString();
                    button207 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 27;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button286.Text = dt.Rows[0][0].ToString();
                    button286 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button278.Text = dt.Rows[0][0].ToString();
                    button278 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 27;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button100.Text = dt.Rows[0][0].ToString();
                    button100 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button206.Text = dt.Rows[0][0].ToString();
                    button206 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 27;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button284.Text = dt.Rows[0][0].ToString();
                    button284 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button205.Text = dt.Rows[0][0].ToString();
                    button205 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displayab5()
    {
        room_code1 = 28;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 28;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button277.Text = dt.Rows[0][0].ToString();
                    button277 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button263.Text = dt.Rows[0][0].ToString();
                    button263 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 28;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button276.Text = dt.Rows[0][0].ToString();
                    button276 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button208.Text = dt.Rows[0][0].ToString();
                    button208 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 28;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button367.Text = dt.Rows[0][0].ToString();
                    button367 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button368.Text = dt.Rows[0][0].ToString();
                    button368 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 28;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button275.Text = dt.Rows[0][0].ToString();
                    button275 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button209.Text = dt.Rows[0][0].ToString();
                    button209 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 28;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button370.Text = dt.Rows[0][0].ToString();
                    button370 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button210.Text = dt.Rows[0][0].ToString();
                    button210 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 28;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button274.Text = dt.Rows[0][0].ToString();
                    button274 = dt.Rows[0][1].ToString();
                }
                dt = null;

                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button262.Text = dt.Rows[0][0].ToString();
                    button262 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 28;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button358.Text = dt.Rows[0][0].ToString();
                    button358 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button356.Text = dt.Rows[0][0].ToString();
                    button356 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 28;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button273.Text = dt.Rows[0][0].ToString();
                    button273 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button261.Text = dt.Rows[0][0].ToString();
                    button261 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 28;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button357.Text = dt.Rows[0][0].ToString();
                    button357 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button355.Text = dt.Rows[0][0].ToString();
                    button355 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 28;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button272.Text = dt.Rows[0][0].ToString();
                    button272 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button211.Text = dt.Rows[0][0].ToString();
                    button211 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displayab6()
    {
        room_code1 = 30;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 30;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button269.Text = dt.Rows[0][0].ToString();
                    button269 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button257.Text = dt.Rows[0][0].ToString();
                    button257 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 30;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button270.Text = dt.Rows[0][0].ToString();
                    button270 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button258.Text = dt.Rows[0][0].ToString();
                    button258 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 30;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button352.Text = dt.Rows[0][0].ToString();
                    button352 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button351.Text = dt.Rows[0][0].ToString();
                    button351 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 30;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button271.Text = dt.Rows[0][0].ToString();
                    button271 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button259.Text = dt.Rows[0][0].ToString();
                    button259 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 30;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button369.Text = dt.Rows[0][0].ToString();
                    button369 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button260.Text = dt.Rows[0][0].ToString();
                    button260 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 30;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button268.Text = dt.Rows[0][0].ToString();
                    button268 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button256.Text = dt.Rows[0][0].ToString();
                    button256 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 30;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button267.Text = dt.Rows[0][0].ToString();
                    button267 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button255.Text = dt.Rows[0][0].ToString();
                    button255 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 30;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button266.Text = dt.Rows[0][0].ToString();
                    button266 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button254.Text = dt.Rows[0][0].ToString();
                    button254 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 30;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button265.Text = dt.Rows[0][0].ToString();
                    button265 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button253.Text = dt.Rows[0][0].ToString();
                    button253 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 30;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button264.Text = dt.Rows[0][0].ToString();
                    button264 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button252.Text = dt.Rows[0][0].ToString();
                    button252 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displayab7()
    {
        room_code1 = 31;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 31;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button251.Text = dt.Rows[0][0].ToString();
                    button251 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button227.Text = dt.Rows[0][0].ToString();
                    button227 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 31;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button250.Text = dt.Rows[0][0].ToString();
                    button250 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button228.Text = dt.Rows[0][0].ToString();
                    button228 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 31;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button249.Text = dt.Rows[0][0].ToString();
                    button249 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button229.Text = dt.Rows[0][0].ToString();
                    button229 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 31;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button248.Text = dt.Rows[0][0].ToString();
                    button248 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button230.Text = dt.Rows[0][0].ToString();
                    button230 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 31;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button247.Text = dt.Rows[0][0].ToString();
                    button247 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 31;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button231.Text = dt.Rows[0][0].ToString();
                    button231 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 31;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button242.Text = dt.Rows[0][0].ToString();
                    button242 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button226.Text = dt.Rows[0][0].ToString();
                    button226 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 31;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button243.Text = dt.Rows[0][0].ToString();
                    button243 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button225.Text = dt.Rows[0][0].ToString();
                    button225 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 31;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button244.Text = dt.Rows[0][0].ToString();
                    button244 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button224.Text = dt.Rows[0][0].ToString();
                    button224 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 31;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button245.Text = dt.Rows[0][0].ToString();
                    button245 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button222.Text = dt.Rows[0][0].ToString();
                    button222 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 31;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button246.Text = dt.Rows[0][0].ToString();
                    button246 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button223.Text = dt.Rows[0][0].ToString();
                    button223 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    public void displayab8()
    {
        room_code1 = 32;
        crtview.room_code = room_code1;
        DataTable dt = new DataTable();
        scheduledate = DateTime.Now;
        crtview.scheduledate = scheduledate;
        session1 = 2;
        string bu = "Button1";
        crtview.session1 = session1;
        for (int i = 1; i <= 10; i++)
        {
            if (i == 1)
            {
                room_code1 = 32;
                scheduledate = Monday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button241.Text = dt.Rows[0][0].ToString();
                    button241 = dt.Rows[0][1].ToString();
                }
                dt = null;
                room_code1 = 32;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button217.Text = dt.Rows[0][0].ToString();
                    button217 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 2)
            {
                room_code1 = 32;
                scheduledate = Tuesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button240.Text = dt.Rows[0][0].ToString();
                    button240 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button218.Text = dt.Rows[0][0].ToString();
                    button218 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 3)
            {
                room_code1 = 32;
                scheduledate = Wednesday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button239.Text = dt.Rows[0][0].ToString();
                    button239 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button219.Text = dt.Rows[0][0].ToString();
                    button219 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 4)
            {
                room_code1 = 32;
                scheduledate = Thursday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button238.Text = dt.Rows[0][0].ToString();
                    button238 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button220.Text = dt.Rows[0][0].ToString();
                    button220 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 5)
            {

                room_code1 = 32;
                scheduledate = Friday;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button237.Text = dt.Rows[0][0].ToString();
                    button237 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 32;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button221.Text = dt.Rows[0][0].ToString();
                    button221 = dt.Rows[0][1].ToString();
                }
                dt = null;

            }
            if (i == 6)
            {
                room_code1 = 32;
                scheduledate = Monday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button236.Text = dt.Rows[0][0].ToString();
                    button236 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button216.Text = dt.Rows[0][0].ToString();
                    button216 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 7)
            {
                room_code1 = 32;
                scheduledate = Tuesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button235.Text = dt.Rows[0][0].ToString();
                    button235 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button215.Text = dt.Rows[0][0].ToString();
                    button215 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }
            if (i == 8)
            {
                room_code1 = 32;
                scheduledate = Wednesday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button234.Text = dt.Rows[0][0].ToString();
                    button234 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button214.Text = dt.Rows[0][0].ToString();
                    button214 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 9)
            {
                room_code1 = 32;
                scheduledate = Thursday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button233.Text = dt.Rows[0][0].ToString();
                    button233 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button213.Text = dt.Rows[0][0].ToString();
                    button213 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

            if (i == 10)
            {
                room_code1 = 32;
                scheduledate = Friday;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button232.Text = dt.Rows[0][0].ToString();
                    button232 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button212.Text = dt.Rows[0][0].ToString();
                    button212 = dt.Rows[0][1].ToString();
                }
                dt = null;
            }

        }
    }

    private void LoadDepart()
    {
        DataTable dtbl = new DataTable();
        ListItem list1 = new ListItem();
        try
        {
            crtcntrl = new CRTBAL();
            dtbl = crtcntrl.GetDepartmentDetail();
            if (dtbl.Rows.Count > 0)
            {

                foreach (DataRow dr in dtbl.Rows)
                {
                    string depotname = myTI.ToTitleCase(dr["department_desc"].ToString());
                    int depotid = Int32.Parse(dr["department_id"].ToString());
                    arrloaddepot.Add(new CRTAddValue(depotname, depotid));

                }

                //DropDownList1.DataSource = arrloaddepot;
                //DropDownList1.DataTextField = "Display";
                //DropDownList1.DataValueField = "Value";
                //DropDownList1.DataBind();
            }
            else
            {
                //arrloaddepot.Add(new CRTAddValue("No Record", 0));
                ////arrloaddepot.Sort();
                //DropDownList1.DataSource = arrloaddepot;
                //DropDownList1.DataTextField = "Display";
                //DropDownList1.DataValueField = "Value";
                //DropDownList1.DataBind();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in department load", ex);
        }
        finally
        {
            dtbl = null;
        }
    }

    // CRT - CRT Add Value

    #region CRT - CRT Add Value

    public class CRTAddValue
    {
        private string m_Display;
        private long m_Value;
        public CRTAddValue(string Display, long Value)
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

    #endregion CRT - CRT Add Value

    public void call()
    {
        ScriptManager.RegisterStartupScript(this, GetType(), "schedulefunction", "schedulefunction();", true);
    }



    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button1;
        call();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button6;
        call();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button2;
        call();
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button7;
        call();
    }

    protected void Button370_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button370;
        call();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        Session["ScheduleId"] = button3;
        call();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        Session["ScheduleId"] = button4;
        call();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        Session["ScheduleId"] = button5;
        call();
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button8;
        call();
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button9;
        call();
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button10;
        call();
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button11;
        call();
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button12;
        call();
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button13;
        call();
    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button17;
        call();
    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button18;
        call();
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button19;
        call();
    }
    protected void Button20_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button20;
        call();
    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button14;
        call();
    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button21;
        call();
    }
    protected void Button22_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button22;
        call();
    }
    protected void Button23_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button23;
        call();
    }
    protected void Button24_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button24;
        call();
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button15;
        call();
    }
    protected void Button25_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button25;
        call();
    }
    protected void Button26_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button26;
        call();
    }
    protected void Button27_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button27;
        call();
    }
    protected void Button28_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button28;
        call();
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button16;
        call();
    }
    protected void Button29_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button29;
        call();
    }
    protected void Button30_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button30;
        call();
    }
    protected void Button31_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button31;
        call();
    }
    protected void Button32_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button32;
        call();
    }
    protected void Button33_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button33;
        call();
    }
    protected void Button34_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button34;
        call();
    }
    protected void Button35_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button35;
        call();
    }
    protected void Button36_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button36;
        call();
    }
    protected void Button39_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button39;
        call();
    }
    protected void Button40_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button40;
        call();
    }
    protected void Button41_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button41;
        call();
    }
    protected void Button37_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button37;
        call();
    }
    protected void Button42_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button42;
        call();
    }
    protected void Button43_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button43;
        call();
    }
    protected void Button44_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button44;
        call();
    }
    protected void Button45_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button45;
        call();
    }
    protected void Button38_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button38;
        call();
    }
    protected void Button52_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button52;
        call();
    }
    protected void Button53_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button53;
        call();
    }
    protected void Button54_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button54;
        call();
    }
    protected void Button46_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button46;
        call();
    }
    protected void Button55_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button55;
        call();
    }
    protected void Button49_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button49;
        call();
    }
    protected void Button56_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button56;
        call();
    }
    protected void Button57_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button57;
        call();
    }
    protected void Button47_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button47;
        call();
    }
    protected void Button48_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button48;
        call();
    }
    protected void Button58_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button58;
        call();
    }
    protected void Button59_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button59;
        call();
    }
    protected void Button51_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button51;
        call();
    }
    protected void Button50_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button50;
        call();
    }
    protected void Button60_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button60;
        call();
    }
    protected void Button61_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button61;
        call();
    }
    protected void Button62_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button62;
        call();
    }
    protected void Button63_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button63;
        call();
    }
    protected void Button64_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button64;
        call();
    }
    protected void Button65_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button65;
        call();
    }
    protected void Button66_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button66;
        call();
    }
    protected void Button67_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button67;
        call();
    }
    protected void Button68_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button68;
        call();
    }
    protected void Button69_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button69;
        call();
    }
    protected void Button70_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button70;
        call();
    }
    protected void Button71_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button71;
        call();
    }
    protected void Button72_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button72;
        call();
    }
    protected void Button73_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button73;
        call();
    }
    protected void Button74_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button74;
        call();
    }
    protected void Button75_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button75;
        call();
    }
    protected void Button76_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button76;
        call();
    }
    protected void Button77_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button77;
        call();
    }
    protected void Button78_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button78;
        call();
    }
    protected void Button79_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button79;
        call();
    }
    protected void Button80_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button80;
        call();
    }
    protected void Button81_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button81;
        call();
    }
    protected void Button82_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button82;
        call();
    }
    protected void Button83_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button83;
        call();
    }
    protected void Button84_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button84;
        call();
    }
    protected void Button85_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button85;
        call();
    }
    protected void Button86_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button86;
        call();
    }
    protected void Button87_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button87;
        call();
    }
    protected void Button385_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button385;
        call();
    }
    protected void Button88_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button88;
        call();
    }
    protected void Button89_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button89;
        call();
    }
    protected void Button90_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button90;
        call();
    }
    protected void Button354_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button354;
        call();
    }
    protected void Button346_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button346;
        call();
    }
    protected void Button315_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button315;
        call();
    }
    protected void Button93_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button93;
        call();
    }
    protected void Button91_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button91;
        call();
    }
    protected void Button92_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button92;
        call();
    }
    protected void Button387_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button387;
        call();
    }
    protected void Button94_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button94;
        call();
    }
    protected void Button95_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button95;
        call();
    }
    protected void Button314_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button314;
        call();
    }
    protected void Button96_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button96;
        call();
    }
    protected void Button397_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button397;
        call();
    }
    protected void Button337_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button337;
        call();
    }
    protected void Button381_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button381;
        call();
    }
    protected void Button380_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button380;
        call();
    }
    protected void Button97_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button97;
        call();
    }
    protected void Button376_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button376;
        call();
    }
    protected void Button379_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button379;
        call();
    }
    protected void Button313_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button313;
        call();
    }
    protected void Button336_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button336;
        call();
    }
    protected void Button335_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button335;
        call();
    }
    protected void Button334_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button334;
        call();
    }
    protected void Button333_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button333;
        call();
    }
    protected void Button332_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button332;
        call();
    }
    protected void Button331_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button331;
        call();
    }
    protected void Button330_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button330;
        call();
    }
    protected void Button329_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button329;
        call();
    }
    protected void Button328_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button328;
        call();
    }
    protected void Button327_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button327;
        call();
    }
    protected void Button310_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button310;
        call();
    }
    protected void Button311_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button311;
        call();
    }
    protected void Button347_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button347;
        call();
    }
    protected void Button312_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button312;
        call();
    }
    protected void Button361_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button361;
        call();
    }
    protected void Button360_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button360;
        call();
    }
    protected void Button395_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button395;
        call();
    }
    protected void Button309_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button309;
        call();
    }
    protected void Button98_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button98;
        call();
    }
    protected void Button308_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button308;
        call();
    }
    protected void Button307_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button307;
        call();
    }
    protected void Button305_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button305;
        call();
    }
    protected void Button349_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button349;
        call();
    }
    protected void Button306_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button306;
        call();
    }
    protected void Button373_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button373;
        call();
    }
    protected void Button304_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button304;
        call();
    }
    protected void Button303_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button303;
        call();
    }
    protected void Button302_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button302;
        call();
    }
    protected void Button301_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button301;
        call();
    }
    protected void Button300_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button300;
        call();
    }
    protected void Button293_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button293;
        call();
    }
    protected void Button294_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button294;
        call();
    }
    protected void Button391_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button391;
        call();
    }
    protected void Button295_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button295;
        call();
    }
    protected void Button372_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button372;
        call();
    }
    protected void Button292_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button292;
        call();
    }
    protected void Button390_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button390;
        call();
    }
    protected void Button291_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button291;
        call();
    }
    protected void Button99_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button99;
        call();
    }
    protected void Button290_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button290;
        call();
    }
    protected void Button288_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button288;
        call();
    }
    protected void Button289_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button289;
        call();
    }
    protected void Button393_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button393;
        call();
    }
    protected void Button285_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button285;
        call();
    }
    protected void Button371_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button371;
        call();
    }
    protected void Button287_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button287;
        call();
    }
    protected void Button389_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button389;
        call();
    }
    protected void Button286_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button286;
        call();
    }
    protected void Button100_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button100;
        call();
    }
    protected void Button284_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button284;
        call();
    }
    protected void Button277_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button277;
        call();
    }
    protected void Button276_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button276;
        call();
    }
    protected void Button367_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button367;
        call();
    }
    protected void Button275_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button275;
        call();
    }
    protected void Button274_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button274;
        call();
    }
    protected void Button358_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button358;
        call();
    }
    protected void Button273_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button273;
        call();
    }
    protected void Button357_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button357;
        call();
    }
    protected void Button272_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button272;
        call();
    }
    protected void Button269_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button269;
        call();
    }
    protected void Button270_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button270;
        call();
    }
    protected void Button352_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button352;
        call();
    }
    protected void Button271_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button271;
        call();
    }
    protected void Button369_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button369;
        call();
    }
    protected void Button268_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button268;
        call();
    }
    protected void Button267_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button267;
        call();
    }
    protected void Button266_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button266;
        call();
    }
    protected void Button265_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button265;
        call();
    }
    protected void Button264_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button264;
        call();
    }
    protected void Button251_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button251;
        call();
    }
    protected void Button250_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button250;
        call();
    }
    protected void Button249_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button249;
        call();
    }
    protected void Button248_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button248;
        call();
    }
    protected void Button247_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button247;
        call();
    }
    protected void Button242_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button242;
        call();
    }
    protected void Button243_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button243;
        call();
    }
    protected void Button244_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button244;
        call();
    }
    protected void Button245_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button245;
        call();
    }
    protected void Button246_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button246;
        call();
    }
    protected void Button241_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button241;
        call();
    }
    protected void Button240_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button240;
        call();
    }
    protected void Button239_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button239;
        call();
    }
    protected void Button238_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button238;
        call();
    }
    protected void Button237_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button237;
        call();
    }
    protected void Button236_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button236;
        call();
    }
    protected void Button235_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button235;
        call();
    }
    protected void Button234_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button234;
        call();
    }
    protected void Button233_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button233;
        call();
    }
    protected void Button232_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = button232;
        call();
    }
}
