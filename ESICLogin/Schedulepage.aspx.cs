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



public partial class Schedule : System.Web.UI.Page
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
    DateTime scheduledate=new DateTime();
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
        Label1.Text = "05th";
        Label33.Text = "06th";
        Label34.Text = "07th";
        Label38.Text = "08th";
        Label39.Text = "09th";
        Label2.Text = "12th";
        Label40.Text = "13th";
        Label41.Text = "14th";
        Label42.Text = "15th";
        Label43.Text = "16th";
        
        
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
            dtbl = crtcntrl.CompareDepartSchedule(scheduledate,session1,room_code);
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
       string day=Convert.ToString(today.DayOfWeek);
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

    public string but1 = "", but2 = "", but3 = "", but4 = "", but5 = "", but6 = "", but7 = "", but8 = "", but9 = "", but10 = "",
        but11 = "", but12 = "", but13 = "", but17 = "", but18 = "", but19 = "", but20 = "", but14 = "", but21 = "", but22 = "",
        but23 = " ", but24 = " ", but15 = " ", but25 = " ", but26 = " ", but27 = " ", but28 = " ", but16 = " ", but29 = " ", but30 = " ",
        but31 = "", but32 = "", but33 = "", but34 = "", but35 = "", but36 = "", but39 = "", but40 = "", but41 = "", but37 = "",
        but42 = "", but43 = "", but44 = "", but45 = "", but38 = "", but52 = "", but53 = "", but54 = "", but46 = "", but55 = "",
        but49 = "", but56 = "", but57 = "", but47 = "", but48 = "", but58 = "", but59 = "", but51 = "", but50 = "", but60 = "",
        but61 = "", but62 = "", but63 = "", but64 = "", but65 = "", but66 = "", but67 = "", but68 = "", but69 = "", but70 = "",
        but71 = "", but72 = "", but73 = "", but74 = "", but75 = "", but76 = "", but77 = "", but78 = "", but79 = "", but80 = "",
        but81 = "", but82 = "", but83 = "", but84 = "", but85 = "", but86 = "", but87 = "", but385 = "", but88 = "", but89 = "",
        but90 = "", but354 = "", but346 = "", but315 = "", but93 = "", but91 = "", but92 = "", but387 = "", but94 = "", but95 = "",
        but314 = "", but96 = "", but397 = "", but337 = "", but381 = "", but380 = "", but97 = "", but376 = "", but379 = "", but313 = "",
        but336 = "", but335 = "", but334 = "", but333 = "", but332 = "", but331 = "", but330 = "", but329 = "", but328 = "", but327 = "",
        but310 = "", but311 = "", but347 = "", but312 = "", but361 = "", but360 = "", but395 = "", but309 = "", but98 = "", but308 = "",
        but307 = "", but305 = "", but349 = "", but306 = "", but373 = "", but304 = "", but303 = "", but302 = "", but301 = "", but300 = "",
        but293 = "", but294 = "", but391 = "", but295 = "", but372 = "", but292 = "", but390 = "", but291 = "", but99 = "", but290 = "",
        but288 = "", but289 = "", but393 = "", but285 = "", but371 = "", but287 = "", but389 = "", but286 = "", but100 = "", but284 = "",
        but277 = "", but276 = "", but367 = "", but275 = "", but370 = "", but274 = "", but358 = "", but273 = "", but357 = "", but272 = "",
        but269 = "", but270 = "", but352 = "", but271 = "", but369 = "", but268 = "", but267 = "", but266 = "", but265 = "", but264 = "",
        but251 = "", but250 = "", but249 = "", but248 = "", but247 = "", but242 = "", but243 = "", but244 = "", but245 = "", but246 = "",
        but241 = "", but240 = "", but239 = "", but238 = "", but237 = "", but236 = "", but235 = "", but234 = "", but233 = "", but232 = "",
        but216 = "", but215 = "", but214 = "", but213 = "", but212 = "", but217 = "", but218 = "", but219 = "", but220 = "", but221 = "",
        but226 = "", but225 = "", but224 = "", but222 = "", but223 = "", but227 = "", but228 = "", but229 = "", but230 = "", but231 = "",
        but256 = "", but255 = "", but254 = "", but253 = "", but252 = "", but257 = "", but258 = "", but351 = "", but259 = "", but260 = "",
        but262 = "", but356 = "", but261 = "", but355 = "", but211 = "", but263 = "", but208 = "", but368 = "", but209 = "", but210 = "",
        but279 = "", but207 = "", but278 = "", but206 = "", but205 = "", but280 = "", but202 = "", but394 = "", but203 = "", but204 = "",
        but282 = "", but201 = "", but281 = "", but200 = "", but199 = "", but283 = "", but198 = "", but392 = "", but197 = "", but196 = "",
        but296 = "", but193 = "", but297 = "", but194 = "", but195 = "", but299 = "", but192 = "", but350 = "", but191 = "", but190 = "",
        but359 = "", but187 = "", but298 = "", but188 = "", but189 = "", but186 = "", but185 = "", but348 = "", but184 = "", but183 = "",
        but320 = "", but319 = "", but318 = "", but316 = "", but317 = "", but321 = "", but322 = "", but323 = "", but324 = "", but325 = "",
        but378 = "", but180 = "", but377 = "", but181 = "", but182 = "", but179 = "", but178 = "", but396 = "", but326 = "", but177 = "",
        but176 = "", but175 = "", but388 = "", but174 = "", but173 = "", but172 = "", but171 = "", but345 = "", but170 = "", but169 = "",
        but165 = "", but166 = "", but386 = "", but167 = "", but168 = "", but164 = "", but163 = "", but344 = "", but162 = "", but161 = "",
        but158 = "", but159 = "", but384 = "", but160 = "", but157 = "", but153 = "", but154 = "", but366 = "", but155 = "", but156 = "",
        but152 = "", but151 = "", but383 = "", but150 = "", but149 = "", but148 = "", but147 = "", but365 = "", but146 = "", but145 = "",
        but142 = "", but143 = "", but382 = "", but144 = "", but400 = "", but141 = "", but140 = "", but364 = "", but139 = "", but138 = "",
        but399 = "", but135 = "", but375 = "", but136 = "", but137 = "", but398 = "", but134 = "", but363 = "", but133 = "", but132 = "",
        but128 = "", but129 = "", but374 = "", but130 = "", but131 = "", but127 = "", but353 = "", but362 = "", but126 = "", but125 = "",
        but121 = "", but122 = "", but343 = "", but123 = "", but124 = "", but120 = "", but119 = "", but342 = "", but118 = "", but117 = "",
        but113 = "", but114 = "", but341 = "", but115 = "", but116 = "", but112 = "", but111 = "", but340 = "", but110 = "", but109 = "",
        but104 = "", but105 = "", but339 = "", but106 = "", but108 = "", but101 = "", but102 = "", but338 = "", but103 = "", but107 = "";


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
                    but1 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button101.Text = dt.Rows[0][0].ToString();
                    but101 = dt.Rows[0][1].ToString();
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
                    but2 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 11;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button102.Text = dt.Rows[0][0].ToString();
                    but102 = dt.Rows[0][1].ToString();
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
                    but3 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button338.Text = dt.Rows[0][0].ToString();
                    but338 = dt.Rows[0][1].ToString();
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
                    but4 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button103.Text = dt.Rows[0][0].ToString();
                    but103 = dt.Rows[0][1].ToString();
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
                    but5 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 11;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button107.Text = dt.Rows[0][0].ToString();
                    but107 = dt.Rows[0][1].ToString();
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
                    but6 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button104.Text = dt.Rows[0][0].ToString();
                    but104 = dt.Rows[0][1].ToString();
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
                    but7= dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button105.Text = dt.Rows[0][0].ToString();
                    but105 = dt.Rows[0][1].ToString();
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
                    but8 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button339.Text = dt.Rows[0][0].ToString();
                    but339 = dt.Rows[0][1].ToString();
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
                    but9= dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button106.Text = dt.Rows[0][0].ToString();
                    but106 = dt.Rows[0][1].ToString();
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
                    but10 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 11;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button108.Text = dt.Rows[0][0].ToString();
                    but108 = dt.Rows[0][1].ToString();
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
                    but11 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 12;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button112.Text = dt.Rows[0][0].ToString();
                    but112 = dt.Rows[0][1].ToString();
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
                    but12 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 12;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button111.Text = dt.Rows[0][0].ToString();
                    but111 = dt.Rows[0][1].ToString();
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
                    but13 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 12;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button340.Text = dt.Rows[0][0].ToString();
                    but340 = dt.Rows[0][1].ToString();
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
                    but17 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button110.Text = dt.Rows[0][0].ToString();
                    but110 = dt.Rows[0][1].ToString();
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
                    but18 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button109.Text = dt.Rows[0][0].ToString();
                    but109 = dt.Rows[0][1].ToString();
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
                    but19 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button113.Text = dt.Rows[0][0].ToString();
                    but113 = dt.Rows[0][1].ToString();
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
                    but20 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button114.Text = dt.Rows[0][0].ToString();
                    but114 = dt.Rows[0][1].ToString();
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
                    but14 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button341.Text = dt.Rows[0][0].ToString();
                    but341 = dt.Rows[0][1].ToString();
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
                    but21 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 12;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button115.Text = dt.Rows[0][0].ToString();
                    but115 = dt.Rows[0][1].ToString();
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
                    but22 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 12;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button116.Text = dt.Rows[0][0].ToString();
                    but116 = dt.Rows[0][1].ToString();
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
                    but23 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button120.Text = dt.Rows[0][0].ToString();
                    but120 = dt.Rows[0][1].ToString();
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
                    but24 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button119.Text = dt.Rows[0][0].ToString();
                    but119 = dt.Rows[0][1].ToString();
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
                    but15 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button342.Text = dt.Rows[0][0].ToString();
                    but342 = dt.Rows[0][1].ToString();
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
                    but25 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button118.Text = dt.Rows[0][0].ToString();
                    but118 = dt.Rows[0][1].ToString();
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
                    but26 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 13;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button117.Text = dt.Rows[0][0].ToString();
                    but117 = dt.Rows[0][1].ToString();
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
                    but27 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button121.Text = dt.Rows[0][0].ToString();
                    but121 = dt.Rows[0][1].ToString();
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
                    but28 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 13;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button122.Text = dt.Rows[0][0].ToString();
                    but122 = dt.Rows[0][1].ToString();
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
                    but16 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 13;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button343.Text = dt.Rows[0][0].ToString();
                    but343 = dt.Rows[0][1].ToString();
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
                    but29 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 13;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button123.Text = dt.Rows[0][0].ToString();
                    but123 = dt.Rows[0][1].ToString();
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
                    but30 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 13;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button124.Text = dt.Rows[0][0].ToString();
                    but124 = dt.Rows[0][1].ToString();
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
                    but31 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 14;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button127.Text = dt.Rows[0][0].ToString();
                    but127 = dt.Rows[0][1].ToString();
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
                    but32 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button353.Text = dt.Rows[0][0].ToString();
                    but353 = dt.Rows[0][1].ToString();
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
                    but33 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button362.Text = dt.Rows[0][0].ToString();
                    but362 = dt.Rows[0][1].ToString();
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
                    but34 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button126.Text = dt.Rows[0][0].ToString();
                    but126 = dt.Rows[0][1].ToString();
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
                    but35 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button125.Text = dt.Rows[0][0].ToString();
                    but125 = dt.Rows[0][1].ToString();
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
                    but36 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button128.Text = dt.Rows[0][0].ToString();
                    but128 = dt.Rows[0][1].ToString();
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
                    but39 = dt.Rows[0][1].ToString();
                }
                dt = null;

                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button129.Text = dt.Rows[0][0].ToString();
                    but129 = dt.Rows[0][1].ToString();
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
                    but40 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button374.Text = dt.Rows[0][0].ToString();
                    but374 = dt.Rows[0][1].ToString();
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
                    but41 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button130.Text = dt.Rows[0][0].ToString();
                    but130 = dt.Rows[0][1].ToString();
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
                    but37 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 14;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button131.Text = dt.Rows[0][0].ToString();
                    but131 = dt.Rows[0][1].ToString();
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
                    but42 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button398.Text = dt.Rows[0][0].ToString();
                    but398 = dt.Rows[0][1].ToString();
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
                    but43 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button134.Text = dt.Rows[0][0].ToString();
                    but134 = dt.Rows[0][1].ToString();
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
                    but44 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button363.Text = dt.Rows[0][0].ToString();
                    but363 = dt.Rows[0][1].ToString();
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
                    but45 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button133.Text = dt.Rows[0][0].ToString();
                    but133 = dt.Rows[0][1].ToString();
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
                    but38 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button132.Text = dt.Rows[0][0].ToString();
                    but132 = dt.Rows[0][1].ToString();
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
                    but52 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button399.Text = dt.Rows[0][0].ToString();
                    but399 = dt.Rows[0][1].ToString();
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
                    but53 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button135.Text = dt.Rows[0][0].ToString();
                    but135 = dt.Rows[0][1].ToString();
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
                    but54 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button375.Text = dt.Rows[0][0].ToString();
                    but375 = dt.Rows[0][1].ToString();
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
                    but46 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button136.Text = dt.Rows[0][0].ToString();
                    but136 = dt.Rows[0][1].ToString();
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
                    but55 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 15;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button137.Text = dt.Rows[0][0].ToString();
                    but137 = dt.Rows[0][1].ToString();
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
                    but49 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button141.Text = dt.Rows[0][0].ToString();
                    but141 = dt.Rows[0][1].ToString();
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
                    but56 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button140.Text = dt.Rows[0][0].ToString();
                    but140 = dt.Rows[0][1].ToString();
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
                    but57 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button364.Text = dt.Rows[0][0].ToString();
                    but364 = dt.Rows[0][1].ToString();
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
                    but47 = dt.Rows[0][1].ToString();
                }
                dt = null;
                room_code1 = 16;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button139.Text = dt.Rows[0][0].ToString();
                    but139 = dt.Rows[0][1].ToString();
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
                    but48 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 16;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button138.Text = dt.Rows[0][0].ToString();
                    but138 = dt.Rows[0][1].ToString();
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
                    but58 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button142.Text = dt.Rows[0][0].ToString();
                    but142 = dt.Rows[0][1].ToString();
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
                    but59 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button143.Text = dt.Rows[0][0].ToString();
                    but143 = dt.Rows[0][1].ToString();
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
                    but51 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button382.Text = dt.Rows[0][0].ToString();
                    but382 = dt.Rows[0][1].ToString();
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
                    but50 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button144.Text = dt.Rows[0][0].ToString();
                    but144 = dt.Rows[0][1].ToString();
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
                    but60 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 16;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button400.Text = dt.Rows[0][0].ToString();
                    but400 = dt.Rows[0][1].ToString();
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
                    but61 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button148.Text = dt.Rows[0][0].ToString();
                    but148 = dt.Rows[0][1].ToString();
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
                    but62 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button147.Text = dt.Rows[0][0].ToString();
                    but147 = dt.Rows[0][1].ToString();
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
                    but63 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button365.Text = dt.Rows[0][0].ToString();
                    but365 = dt.Rows[0][1].ToString();
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
                    but64 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 17;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button146.Text = dt.Rows[0][0].ToString();
                    but146 = dt.Rows[0][1].ToString();
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
                    but65 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button145.Text = dt.Rows[0][0].ToString();
                    but145 = dt.Rows[0][1].ToString();
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
                    but66 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button152.Text = dt.Rows[0][0].ToString();
                    but152 = dt.Rows[0][1].ToString();
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
                    but67 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button151.Text = dt.Rows[0][0].ToString();
                    but151 = dt.Rows[0][1].ToString();
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
                    but68 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button383.Text = dt.Rows[0][0].ToString();
                    but383 = dt.Rows[0][1].ToString();
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
                    but69 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button150.Text = dt.Rows[0][0].ToString();
                    but150 = dt.Rows[0][1].ToString();
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
                    but70 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 17;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button149.Text = dt.Rows[0][0].ToString();
                    but149 = dt.Rows[0][1].ToString();
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
                    but71 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button153.Text = dt.Rows[0][0].ToString();
                    but153 = dt.Rows[0][1].ToString();
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
                    but72 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button154.Text = dt.Rows[0][0].ToString();
                    but154 = dt.Rows[0][1].ToString();
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
                    but73 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button366.Text = dt.Rows[0][0].ToString();
                    but366 = dt.Rows[0][1].ToString();
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
                    but74 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button155.Text = dt.Rows[0][0].ToString();
                    but155 = dt.Rows[0][1].ToString();
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
                    but75 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button156.Text = dt.Rows[0][0].ToString();
                    but156 = dt.Rows[0][1].ToString();
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
                    but76= dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button158.Text = dt.Rows[0][0].ToString();
                    but158 = dt.Rows[0][1].ToString();
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
                    but77 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button159.Text = dt.Rows[0][0].ToString();
                    but159 = dt.Rows[0][1].ToString();
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
                    but78 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button384.Text = dt.Rows[0][0].ToString();
                    but384 = dt.Rows[0][1].ToString();
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
                    but79 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button160.Text = dt.Rows[0][0].ToString();
                    but160 = dt.Rows[0][1].ToString();
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
                    but80 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 18;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button157.Text = dt.Rows[0][0].ToString();
                    but157 = dt.Rows[0][1].ToString();
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
                    but81 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button164.Text = dt.Rows[0][0].ToString();
                    but164 = dt.Rows[0][1].ToString();
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
                    but82 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button163.Text = dt.Rows[0][0].ToString();
                    but163 = dt.Rows[0][1].ToString();
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
                    but83 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button344.Text = dt.Rows[0][0].ToString();
                    but344 = dt.Rows[0][1].ToString();
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
                    but84 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button162.Text = dt.Rows[0][0].ToString();
                    but162 = dt.Rows[0][1].ToString();
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
                    but85 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button161.Text = dt.Rows[0][0].ToString();
                    but161 = dt.Rows[0][1].ToString();
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
                    but86 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button165.Text = dt.Rows[0][0].ToString();
                    but165 = dt.Rows[0][1].ToString();
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
                    but87 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button166.Text = dt.Rows[0][0].ToString();
                    but166 = dt.Rows[0][1].ToString();
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
                    but385 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button386.Text = dt.Rows[0][0].ToString();
                    but386 = dt.Rows[0][1].ToString();
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
                    but88 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button167.Text = dt.Rows[0][0].ToString();
                    but167 = dt.Rows[0][1].ToString();
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
                    but89 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 19;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button168.Text = dt.Rows[0][0].ToString();
                    but168 = dt.Rows[0][1].ToString();
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
                    but90 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button172.Text = dt.Rows[0][0].ToString();
                    but172 = dt.Rows[0][1].ToString();
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
                    but354 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button171.Text = dt.Rows[0][0].ToString();
                    but171 = dt.Rows[0][1].ToString();
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
                    but346 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button345.Text = dt.Rows[0][0].ToString();
                    but345 = dt.Rows[0][1].ToString();
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
                    but315 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button170.Text = dt.Rows[0][0].ToString();
                    but170 = dt.Rows[0][1].ToString();
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
                    but93 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button169.Text = dt.Rows[0][0].ToString();
                    but169= dt.Rows[0][1].ToString();
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
                    but91 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 20;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button176.Text = dt.Rows[0][0].ToString();
                    but176 = dt.Rows[0][1].ToString();
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
                    but92 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button175.Text = dt.Rows[0][0].ToString();
                    but175 = dt.Rows[0][1].ToString();
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
                    but387 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button388.Text = dt.Rows[0][0].ToString();
                    but388 = dt.Rows[0][1].ToString();
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
                    but94 = dt.Rows[0][1].ToString();
                }
                dt = null;

                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button174.Text = dt.Rows[0][0].ToString();
                    but174 = dt.Rows[0][1].ToString();
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
                    but95 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 20;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button173.Text = dt.Rows[0][0].ToString();
                    but173 = dt.Rows[0][1].ToString();
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
                    but314= dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button179.Text = dt.Rows[0][0].ToString();
                    but179 = dt.Rows[0][1].ToString();
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
                   but96 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button178.Text = dt.Rows[0][0].ToString();
                    but178 = dt.Rows[0][1].ToString();
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
                   but397 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button396.Text = dt.Rows[0][0].ToString();
                    but396 = dt.Rows[0][1].ToString();
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
                   but337= dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button326.Text = dt.Rows[0][0].ToString();
                    but326 = dt.Rows[0][1].ToString();
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
                 but381 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button177.Text = dt.Rows[0][0].ToString();
                    but177 = dt.Rows[0][1].ToString();
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
                    but380 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button378.Text = dt.Rows[0][0].ToString();
                    but378 = dt.Rows[0][1].ToString();
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
                    but97 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button180.Text = dt.Rows[0][0].ToString();
                    but180= dt.Rows[0][1].ToString();
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
                    but376 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button377.Text = dt.Rows[0][0].ToString();
                    but377 = dt.Rows[0][1].ToString();
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
                    but379 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button181.Text = dt.Rows[0][0].ToString();
                    but181 = dt.Rows[0][1].ToString();
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
                   but313 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 21;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button182.Text = dt.Rows[0][0].ToString();
                    but182 = dt.Rows[0][1].ToString();
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
                    but336 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button321.Text = dt.Rows[0][0].ToString();
                    but321 = dt.Rows[0][1].ToString();
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
                    but335 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button322.Text = dt.Rows[0][0].ToString();
                    but322 = dt.Rows[0][1].ToString();
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
                    but334 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button323.Text = dt.Rows[0][0].ToString();
                    but323 = dt.Rows[0][1].ToString();
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
                    but333 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button324.Text = dt.Rows[0][0].ToString();
                    but324 = dt.Rows[0][1].ToString();
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
                    but332 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 22;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button325.Text = dt.Rows[0][0].ToString();
                    but325 = dt.Rows[0][1].ToString();
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
                    but331 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 22;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button320.Text = dt.Rows[0][0].ToString();
                    but320 = dt.Rows[0][1].ToString();
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
                    but330 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button319.Text = dt.Rows[0][0].ToString();
                    but319 = dt.Rows[0][1].ToString();
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
                    but329 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button318.Text = dt.Rows[0][0].ToString();
                    but318 = dt.Rows[0][1].ToString();
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
                    but328 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button316.Text = dt.Rows[0][0].ToString();
                    but316 = dt.Rows[0][1].ToString();
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
                    but327 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 22;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button317.Text = dt.Rows[0][0].ToString();
                    but317 = dt.Rows[0][1].ToString();
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
                    but310 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button186.Text = dt.Rows[0][0].ToString();
                    but186 = dt.Rows[0][1].ToString();
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
                    but311 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button185.Text = dt.Rows[0][0].ToString();
                    but185 = dt.Rows[0][1].ToString();
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
                    but347 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 23;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button348.Text = dt.Rows[0][0].ToString();
                    but348 = dt.Rows[0][1].ToString();
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
                    but312 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button184.Text = dt.Rows[0][0].ToString();
                    but184 = dt.Rows[0][1].ToString();
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
                    but361 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button183.Text = dt.Rows[0][0].ToString();
                    but183 = dt.Rows[0][1].ToString();
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
                    but360 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button359.Text = dt.Rows[0][0].ToString();
                    but359 = dt.Rows[0][1].ToString();
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
                    but395 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button187.Text = dt.Rows[0][0].ToString();
                    but187 = dt.Rows[0][1].ToString();
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
                    but309 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button298.Text = dt.Rows[0][0].ToString();
                    but298 = dt.Rows[0][1].ToString();
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
                    but98 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button188.Text = dt.Rows[0][0].ToString();
                    but188 = dt.Rows[0][1].ToString();
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
                    but308 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 23;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button189.Text = dt.Rows[0][0].ToString();
                    but189 = dt.Rows[0][1].ToString();
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
                    but307 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button299.Text = dt.Rows[0][0].ToString();
                    but299 = dt.Rows[0][1].ToString();
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
                    but305 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button192.Text = dt.Rows[0][0].ToString();
                    but192 = dt.Rows[0][1].ToString();
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
                    but349 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button350.Text = dt.Rows[0][0].ToString();
                    but350 = dt.Rows[0][1].ToString();
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
                    but306 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button191.Text = dt.Rows[0][0].ToString();
                    but191 = dt.Rows[0][1].ToString();
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
                    but373 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button190.Text = dt.Rows[0][0].ToString();
                    but190 = dt.Rows[0][1].ToString();
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
                    but304 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button296.Text = dt.Rows[0][0].ToString();
                    but296 = dt.Rows[0][1].ToString();
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
                    but303 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button193.Text = dt.Rows[0][0].ToString();
                    but193 = dt.Rows[0][1].ToString();
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
                    but302 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button297.Text = dt.Rows[0][0].ToString();
                    but297 = dt.Rows[0][1].ToString();
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
                    but301 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button194.Text = dt.Rows[0][0].ToString();
                    but194 = dt.Rows[0][1].ToString();
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
                    but300 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 24;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button195.Text = dt.Rows[0][0].ToString();
                    but195 = dt.Rows[0][1].ToString();
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
                    but293 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button283.Text = dt.Rows[0][0].ToString();
                    but283 = dt.Rows[0][1].ToString();
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
                    but294 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button198.Text = dt.Rows[0][0].ToString();
                    but198 = dt.Rows[0][1].ToString();
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
                    but391 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button392.Text = dt.Rows[0][0].ToString();
                    but392 = dt.Rows[0][1].ToString();
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
                    but295 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button197.Text = dt.Rows[0][0].ToString();
                    but197 = dt.Rows[0][1].ToString();
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
                    but372 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button196.Text = dt.Rows[0][0].ToString();
                    but196 = dt.Rows[0][1].ToString();
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
                    but292 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button282.Text = dt.Rows[0][0].ToString();
                    but282 = dt.Rows[0][1].ToString();
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
                    but390 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button201.Text = dt.Rows[0][0].ToString();
                    but201 = dt.Rows[0][1].ToString();
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
                    but291 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 25;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button281.Text = dt.Rows[0][0].ToString();
                    but281 = dt.Rows[0][1].ToString();
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
                    but99 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button200.Text = dt.Rows[0][0].ToString();
                    but200= dt.Rows[0][1].ToString();
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
                    but290 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 25;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button199.Text = dt.Rows[0][0].ToString();
                    but199 = dt.Rows[0][1].ToString();
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
                    but288 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button280.Text = dt.Rows[0][0].ToString();
                    but280 = dt.Rows[0][1].ToString();
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
                    but289 = dt.Rows[0][1].ToString();
                }
                dt = null;

                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button202.Text = dt.Rows[0][0].ToString();
                    but202 = dt.Rows[0][1].ToString();
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
                    but393 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button394.Text = dt.Rows[0][0].ToString();
                    but394 = dt.Rows[0][1].ToString();
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
                    but285 = dt.Rows[0][1].ToString();
                }
                dt = null;

                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button203.Text = dt.Rows[0][0].ToString();
                    but203 = dt.Rows[0][1].ToString();
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
                    but371 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button204.Text = dt.Rows[0][0].ToString();
                    but204 = dt.Rows[0][1].ToString();
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
                    but287 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button279.Text = dt.Rows[0][0].ToString();
                    but279 = dt.Rows[0][1].ToString();
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
                    but389 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button207.Text = dt.Rows[0][0].ToString();
                    but207 = dt.Rows[0][1].ToString();
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
                    but286 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button278.Text = dt.Rows[0][0].ToString();
                    but278 = dt.Rows[0][1].ToString();
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
                    but100 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button206.Text = dt.Rows[0][0].ToString();
                    but206 = dt.Rows[0][1].ToString();
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
                    but284 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 27;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button205.Text = dt.Rows[0][0].ToString();
                    but205 = dt.Rows[0][1].ToString();
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
                    but277 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button263.Text = dt.Rows[0][0].ToString();
                    but263 = dt.Rows[0][1].ToString();
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
                    but276 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button208.Text = dt.Rows[0][0].ToString();
                    but208 = dt.Rows[0][1].ToString();
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
                    but367 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button368.Text = dt.Rows[0][0].ToString();
                    but368 = dt.Rows[0][1].ToString();
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
                    but275 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button209.Text = dt.Rows[0][0].ToString();
                    but209 = dt.Rows[0][1].ToString();
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
                    but370 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button210.Text = dt.Rows[0][0].ToString();
                    but210 = dt.Rows[0][1].ToString();
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
                    but274 = dt.Rows[0][1].ToString();
                }
                dt = null;

                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button262.Text = dt.Rows[0][0].ToString();
                    but262 = dt.Rows[0][1].ToString();
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
                    but358 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button356.Text = dt.Rows[0][0].ToString();
                    but356 = dt.Rows[0][1].ToString();
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
                    but273 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button261.Text = dt.Rows[0][0].ToString();
                    but261 = dt.Rows[0][1].ToString();
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
                    but357 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button355.Text = dt.Rows[0][0].ToString();
                    but355 = dt.Rows[0][1].ToString();
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
                    but272 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 28;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button211.Text = dt.Rows[0][0].ToString();
                    but211 = dt.Rows[0][1].ToString();
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
                    but269 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button257.Text = dt.Rows[0][0].ToString();
                    but257 = dt.Rows[0][1].ToString();
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
                    but270 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button258.Text = dt.Rows[0][0].ToString();
                    but258 = dt.Rows[0][1].ToString();
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
                    but352 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button351.Text = dt.Rows[0][0].ToString();
                    but351 = dt.Rows[0][1].ToString();
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
                    but271 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button259.Text = dt.Rows[0][0].ToString();
                    but259 = dt.Rows[0][1].ToString();
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
                    but369 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button260.Text = dt.Rows[0][0].ToString();
                    but260 = dt.Rows[0][1].ToString();
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
                    but268 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button256.Text = dt.Rows[0][0].ToString();
                    but256 = dt.Rows[0][1].ToString();
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
                    but267 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button255.Text = dt.Rows[0][0].ToString();
                    but255 = dt.Rows[0][1].ToString();
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
                    but266 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button254.Text = dt.Rows[0][0].ToString();
                    but254 = dt.Rows[0][1].ToString();
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
                    but265 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button253.Text = dt.Rows[0][0].ToString();
                    but253 = dt.Rows[0][1].ToString();
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
                    but264 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 30;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button252.Text = dt.Rows[0][0].ToString();
                    but252 = dt.Rows[0][1].ToString();
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
                    but251 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button227.Text = dt.Rows[0][0].ToString();
                    but227 = dt.Rows[0][1].ToString();
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
                    but250 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button228.Text = dt.Rows[0][0].ToString();
                    but228 = dt.Rows[0][1].ToString();
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
                    but249 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button229.Text = dt.Rows[0][0].ToString();
                    but229 = dt.Rows[0][1].ToString();
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
                    but248 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button230.Text = dt.Rows[0][0].ToString();
                    but230 = dt.Rows[0][1].ToString();
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
                    but247 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 31;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button231.Text = dt.Rows[0][0].ToString();
                    but231 = dt.Rows[0][1].ToString();
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
                    but242 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button226.Text = dt.Rows[0][0].ToString();
                    but226 = dt.Rows[0][1].ToString();
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
                    but243 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button225.Text = dt.Rows[0][0].ToString();
                    but225 = dt.Rows[0][1].ToString();
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
                    but244 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button224.Text = dt.Rows[0][0].ToString();
                    but224 = dt.Rows[0][1].ToString();
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
                    but245 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button222.Text = dt.Rows[0][0].ToString();
                    but222 = dt.Rows[0][1].ToString();
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
                    but246 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 31;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button223.Text = dt.Rows[0][0].ToString();
                    but223 = dt.Rows[0][1].ToString();
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
                    but241 = dt.Rows[0][1].ToString();
                }
                dt = null;
                room_code1 = 32;
                scheduledate = Monday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button217.Text = dt.Rows[0][0].ToString();
                    but217 = dt.Rows[0][1].ToString();
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
                    but240 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Tuesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button218.Text = dt.Rows[0][0].ToString();
                    but218 = dt.Rows[0][1].ToString();
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
                    but239 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Wednesday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button219.Text = dt.Rows[0][0].ToString();
                    but219 = dt.Rows[0][1].ToString();
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
                    but238 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Thursday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button220.Text = dt.Rows[0][0].ToString();
                    but220 = dt.Rows[0][1].ToString();
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
                    but237 = dt.Rows[0][1].ToString();
                }
                dt = null;


                room_code1 = 32;
                scheduledate = Friday1;
                session1 = 1;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button221.Text = dt.Rows[0][0].ToString();
                    but221 = dt.Rows[0][1].ToString();
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
                    but236 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Monday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button216.Text = dt.Rows[0][0].ToString();
                    but216 = dt.Rows[0][1].ToString();
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
                    but235 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Tuesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button215.Text = dt.Rows[0][0].ToString();
                    but215 = dt.Rows[0][1].ToString();
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
                    but234 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Wednesday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button214.Text = dt.Rows[0][0].ToString();
                    but214 = dt.Rows[0][1].ToString();
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
                    but233 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Thursday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button213.Text = dt.Rows[0][0].ToString();
                    but213 = dt.Rows[0][1].ToString();
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
                    but232 = dt.Rows[0][1].ToString();
                }
                dt = null;

                room_code1 = 32;
                scheduledate = Friday1;
                session1 = 2;
                dt = fill(scheduledate, session1, room_code1);
                if (dt.Rows.Count > 0)
                {
                    Button212.Text = dt.Rows[0][0].ToString();
                    but212 = dt.Rows[0][1].ToString();
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
        Session["ScheduleId"] = but1;
        call();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but6;
        call();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but2;
        call();
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but7;
        call();
    }

    protected void Button370_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but370;
        call();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        Session["ScheduleId"] = but3;
        call();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

        Session["ScheduleId"] = but4;
        call();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {

        Session["ScheduleId"] = but5;
        call();
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but8;
        call();
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but9;
        call();
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but10;
        call();
    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but11;
        call();
    }
    protected void Button12_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but12;
        call();
    }
    protected void Button13_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but13;
        call();
    }
    protected void Button17_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but17;
        call();
    }
    protected void Button18_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but18;
        call();
    }
    protected void Button19_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but19;
        call();
    }
    protected void Button20_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but20;
        call();
    }
    protected void Button14_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but14;
        call();
    }
    protected void Button21_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but21;
        call();
    }
    protected void Button22_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but22;
        call();
    }
    protected void Button23_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but23;
        call();
    }
    protected void Button24_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but24;
        call();
    }
    protected void Button15_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but15;
        call();
    }
    protected void Button25_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but25;
        call();
    }
    protected void Button26_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but26;
        call();
    }
    protected void Button27_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but27;
        call();
    }
    protected void Button28_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but28;
        call();
    }
    protected void Button16_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but16;
        call();
    }
    protected void Button29_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but29;
        call();
    }
    protected void Button30_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but30;
        call();
    }
    protected void Button31_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but31;
        call();
    }
    protected void Button32_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but32;
        call();
    }
    protected void Button33_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but33;
        call();
    }
    protected void Button34_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but34;
        call();
    }
    protected void Button35_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but35;
        call();
    }
    protected void Button36_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but36;
        call();
    }
    protected void Button39_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but39;
        call();
    }
    protected void Button40_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but40;
        call();
    }
    protected void Button41_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but41;
        call();
    }
    protected void Button37_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but37;
        call();
    }
    protected void Button42_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but42;
        call();
    }
    protected void Button43_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but43;
        call();
    }
    protected void Button44_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but44;
        call();
    }
    protected void Button45_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but45;
        call();
    }
    protected void Button38_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but38;
        call();
    }
    protected void Button52_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but52;
        call();
    }
    protected void Button53_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but53;
        call();
    }
    protected void Button54_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but54;
        call();
    }
    protected void Button46_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but46;
        call();
    }
    protected void Button55_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but55;
        call();
    }
    protected void Button49_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but49;
        call();
    }
    protected void Button56_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but56;
        call();
    }
    protected void Button57_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but57;
        call();
    }
    protected void Button47_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but47;
        call();
    }
    protected void Button48_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but48;
        call();
    }
    protected void Button58_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but58;
        call();
    }
    protected void Button59_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but59;
        call();
    }
    protected void Button51_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but51;
        call();
    }
    protected void Button50_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but50;
        call();
    }
    protected void Button60_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but60;
        call();
    }
    protected void Button61_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but61;
        call();
    }
    protected void Button62_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but62;
        call();
    }
    protected void Button63_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but63;
        call();
    }
    protected void Button64_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but64;
        call();
    }
    protected void Button65_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but65;
        call();
    }
    protected void Button66_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but66;
        call();
    }
    protected void Button67_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but67;
        call();
    }
    protected void Button68_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but68;
        call();
    }
    protected void Button69_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but69;
        call();
    }
    protected void Button70_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but70;
        call();
    }
    protected void Button71_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but71;
        call();
    }
    protected void Button72_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but72;
        call();
    }
    protected void Button73_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but73;
        call();
    }
    protected void Button74_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but74;
        call();
    }
    protected void Button75_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but75;
        call();
    }
    protected void Button76_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but76;
        call();
    }
    protected void Button77_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but77;
        call();
    }
    protected void Button78_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but78;
        call();
    }
    protected void Button79_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but79;
        call();
    }
    protected void Button80_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but80;
        call();
    }
    protected void Button81_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but81;
        call();
    }
    protected void Button82_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but82;
        call();
    }
    protected void Button83_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but83;
        call();
    }
    protected void Button84_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but84;
        call();
    }
    protected void Button85_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but85;
        call();
    }
    protected void Button86_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but86;
        call();
    }
    protected void Button87_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but87;
        call();
    }
    protected void Button385_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but385;
        call();
    }
    protected void Button88_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but88;
        call();
    }
    protected void Button89_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but89;
        call();
    }
    protected void Button90_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but90;
        call();
    }
    protected void Button354_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but354;
        call();
    }
    protected void Button346_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but346;
        call();
    }
    protected void Button315_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but315;
        call();
    }
    protected void Button93_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but93;
        call();
    }
    protected void Button91_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but91;
        call();
    }
    protected void Button92_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but92;
        call();
    }
    protected void Button387_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but387;
        call();
    }
    protected void Button94_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but94;
        call();
    }
    protected void Button95_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but95;
        call();
    }
    protected void Button314_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but314;
        call();
    }
    protected void Button96_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but96;
        call();
    }
    protected void Button397_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but397;
        call();
    }
    protected void Button337_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but337;
        call();
    }
    protected void Button381_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but381;
        call();
    }
    protected void Button380_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but380;
        call();
    }
    protected void Button97_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but97;
        call();
    }
    protected void Button376_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but376;
        call();
    }
    protected void Button379_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but379;
        call();
    }
    protected void Button313_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but313;
        call();
    }
    protected void Button336_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but336;
        call();
    }
    protected void Button335_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but335;
        call();
    }
    protected void Button334_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but334;
        call();
    }
    protected void Button333_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but333;
        call();
    }
    protected void Button332_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but332;
        call();
    }
    protected void Button331_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but331;
        call();
    }
    protected void Button330_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but330;
        call();
    }
    protected void Button329_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but329;
        call();
    }
    protected void Button328_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but328;
        call();
    }
    protected void Button327_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but327;
        call();
    }
    protected void Button310_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but310;
        call();
    }
    protected void Button311_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but311;
        call();
    }
    protected void Button347_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but347;
        call();
    }
    protected void Button312_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but312;
        call();
    }
    protected void Button361_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but361;
        call();
    }
    protected void Button360_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but360;
        call();
    }
    protected void Button395_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but395;
        call();
    }
    protected void Button309_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but309;
        call();
    }
    protected void Button98_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but98;
        call();
    }
    protected void Button308_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but308;
        call();
    }
    protected void Button307_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but307;
        call();
    }
    protected void Button305_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but305;
        call();
    }
    protected void Button349_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but349;
        call();
    }
    protected void Button306_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but306;
        call();
    }
    protected void Button373_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but373;
        call();
    }
    protected void Button304_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but304;
        call();
    }
    protected void Button303_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but303;
        call();
    }
    protected void Button302_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but302;
        call();
    }
    protected void Button301_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but301;
        call();
    }
    protected void Button300_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but300;
        call();
    }
    protected void Button293_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but293;
        call();
    }
    protected void Button294_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but294;
        call();
    }
    protected void Button391_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but391;
        call();
    }
    protected void Button295_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but295;
        call();
    }
    protected void Button372_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but372;
        call();
    }
    protected void Button292_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but292;
        call();
    }
    protected void Button390_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but390;
        call();
    }
    protected void Button291_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but291;
        call();
    }
    protected void Button99_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but99;
        call();
    }
    protected void Button290_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but290;
        call();
    }
    protected void Button288_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but288;
        call();
    }
    protected void Button289_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but289;
        call();
    }
    protected void Button393_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but393;
        call();
    }
    protected void Button285_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but285;
        call();
    }
    protected void Button371_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but371;
        call();
    }
    protected void Button287_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but287;
        call();
    }
    protected void Button389_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but389;
        call();
    }
    protected void Button286_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but286;
        call();
    }
    protected void Button100_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but100;
        call();
    }
    protected void Button284_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but284;
        call();
    }
    protected void Button277_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but277;
        call();
    }
    protected void Button276_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but276;
        call();
    }
    protected void Button367_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but367;
        call();
    }
    protected void Button275_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but275;
        call();
    }
    protected void Button274_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but274;
        call();
    }
    protected void Button358_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but358;
        call();
    }
    protected void Button273_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but273;
        call();
    }
    protected void Button357_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but357;
        call();
    }
    protected void Button272_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but272;
        call();
    }
    protected void Button269_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but269;
        call();
    }
    protected void Button270_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but270;
        call();
    }
    protected void Button352_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but352;
        call();
    }
    protected void Button271_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but271;
        call();
    }
    protected void Button369_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but369;
        call();
    }
    protected void Button268_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but268;
        call();
    }
    protected void Button267_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but267;
        call();
    }
    protected void Button266_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but266;
        call();
    }
    protected void Button265_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but265;
        call();
    }
    protected void Button264_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but264;
        call();
    }
    protected void Button251_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but251;
        call();
    }
    protected void Button250_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but250;
        call();
    }
    protected void Button249_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but249;
        call();
    }
    protected void Button248_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but248;
        call();
    }
    protected void Button247_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but247;
        call();
    }
    protected void Button242_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but242;
        call();
    }
    protected void Button243_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but243;
        call();
    }
    protected void Button244_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but244;
        call();
    }
    protected void Button245_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but245;
        call();
    }
    protected void Button246_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but246;
        call();
    }
    protected void Button241_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but241;
        call();
    }
    protected void Button240_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but240;
        call();
    }
    protected void Button239_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but239;
        call();
    }
    protected void Button238_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but238;
        call();
    }
    protected void Button237_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but237;
        call();
    }
    protected void Button236_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but236;
        call();
    }
    protected void Button235_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but235;
        call();
    }
    protected void Button234_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but234;
        call();
    }
    protected void Button233_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but233;
        call();
    }
    protected void Button232_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but232;
        call();
    }
    protected void Button101_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but101;
        call();

    }
    protected void Button102_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but102;
        call();
    }
    protected void Button338_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but338;
        call();

    }
    protected void Button103_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but103;
        call();

    }
    protected void Button107_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but107;
        call();
    }
    protected void Button104_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but104;
        call();
    }
    protected void Button105_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but105;
        call();
    }
    protected void Button339_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but339;
        call();
    }
    protected void Button106_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but106;
        call();
    }
    protected void Button108_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but108;
        call();
    }
    protected void Button112_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but112;
        call();
    }
    protected void Button111_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but111;
        call();
    }
    protected void Button340_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but340;
        call();
    }
    protected void Button110_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but110;
        call();
    }
    protected void Button109_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but109;
        call();
    }
    protected void Button113_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but113;
        call();
    }
    protected void Button114_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but114;
        call();
    }
    protected void Button341_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but341;
        call();
    }
    protected void Button115_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but115;
        call();
    }
    protected void Button116_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but116;
        call();
    }
    protected void Button120_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but120;
        call();
    }
    protected void Button119_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but119;
        call();
    }
    protected void Button342_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but342;
        call();
    }
    protected void Button118_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but118;
        call();
    }
    protected void Button117_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but117;
        call();
    }
    protected void Button121_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but121;
        call();
    }
    protected void Button122_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but122;
        call();
    }
    protected void Button343_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but343;
        call();
    }
    protected void Button123_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but123;
        call();
    }
    protected void Button124_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but124;
        call();
    }
    protected void Button127_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but127;
        call();
    }
    protected void Button353_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but353;
        call();
    }
    protected void Button362_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but362;
        call();
    }
    protected void Button126_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but126;
        call();
    }
    protected void Button125_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but125;
        call();
    }
    protected void Button128_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but128;
        call();
    }
    protected void Button129_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but129;
        call();
    }
    protected void Button374_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but374;
        call();
    }
    protected void Button130_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but130;
        call();

    }
    protected void Button131_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but131;
        call();

    }
    protected void Button398_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but398;
        call();

    }
    protected void Button134_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but134;
        call();

    }
    protected void Button363_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but363;
        call();

    }
    protected void Button133_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but133;
        call();

    }
    protected void Button132_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but132;
        call();

    }
    protected void Button399_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but399;
        call();
    }
    protected void Button135_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but135;
        call();
    }
    protected void Button375_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but375;
        call();
    }
    protected void Button136_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but136;
        call();
    }
    protected void Button137_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but137;
        call();
    }
    protected void Button141_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but141;
        call();
    }
    protected void Button140_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but140;
        call();
    }
    protected void Button364_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but364;
        call();
    }
    protected void Button139_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but139;
        call();
    }
    protected void Button138_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but138;
        call();
    }
    protected void Button142_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but142;
        call();
    }
    protected void Button143_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but143;
        call();
    }
    protected void Button382_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but382;
        call();
    }
    protected void Button144_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but144;
        call();
    }
    protected void Button400_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but400;
        call();
    }
    protected void Button148_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but148;
        call();
    }
    protected void Button147_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but147;
        call();
    }
    protected void Button365_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but365;
        call();
    }
    protected void Button146_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but146;
        call();
    }
    protected void Button145_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but145;
        call();
    }
    protected void Button152_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but152;
        call();
    }
    protected void Button151_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but151;
        call();
    }
    protected void Button383_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but383;
        call();
    }
    protected void Button150_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but150;
        call();
    }
    protected void Button149_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but149;
        call();
    }
    protected void Button153_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but153;
        call();
    }
    protected void Button154_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but154;
        call();
    }
    protected void Button366_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but366;
        call();
    }
    protected void Button155_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but155;
        call();
    }
    protected void Button156_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but156;
        call();
    }
    protected void Button158_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but158;
        call();
    }
    protected void Button159_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but159;
        call();
    }
    protected void Button384_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but384;
        call();
    }
    protected void Button160_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but160;
        call();
    }
    protected void Button157_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but157;
        call();
    }
    protected void Button164_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but164;
        call();
    }
    protected void Button163_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but163;
        call();
    }
    protected void Button344_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but344;
        call();
    }
    protected void Button162_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but162;
        call();
    }
    protected void Button161_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but161;
        call();
    }
    protected void Button165_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but165;
        call();
    }
    protected void Button166_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but166;
        call();
    }
    protected void Button386_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but386;
        call();
    }
    protected void Button167_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but167;
        call();
    }
    protected void Button168_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but168;
        call();
    }
    protected void Button172_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but172;
        call();
    }
    protected void Button171_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but171;
        call();
    }
    protected void Button345_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but345;
        call();
    }
    protected void Button170_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but170;
        call();
    }
    protected void Button169_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but169;
        call();
    }
    protected void Button176_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but176;
        call();
    }
    protected void Button175_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but175;
        call();
    }
    protected void Button388_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but388;
        call();
    }
    protected void Button174_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but174;
        call();
    }
    protected void Button173_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but173;
        call();
    }
    protected void Button179_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but179;
        call();
    }
    protected void Button178_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but178;
        call();
    }
    protected void Button396_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but396;
        call();
    }
    protected void Button326_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but326;
        call();
    }
    protected void Button177_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but177;
        call();
    }
    protected void Button378_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but378;
        call();
    }
    protected void Button180_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but180;
        call();
    }
    protected void Button377_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but377;
        call();
    }
    protected void Button181_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but181;
        call();
    }
    protected void Button182_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but182;
        call();
    }
    protected void Button321_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but321;
        call();
    }
    protected void Button322_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but322;
        call();
    }
    protected void Button323_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but323;
        call();
    }
    protected void Button324_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but324;
        call();
    }
    protected void Button325_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but325;
        call();
    }
    protected void Button320_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but320;
        call();
    }
    protected void Button319_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but139;
        call();
    }
    protected void Button318_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but318;
        call();
    }
    protected void Button316_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but316;
        call();
    }
    protected void Button317_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but317;
        call();
    }
    protected void Button186_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but186;
        call();
    }
    protected void Button185_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but185;
        call();
    }
    protected void Button348_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but348;
        call();
    }
    protected void Button184_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but184;
        call();
    }
    protected void Button183_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but183;
        call();
    }
    protected void Button359_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but359;
        call();
    }
    protected void Button187_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but187;
        call();
    }
    protected void Button298_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but298;
        call();
    }
    protected void Button188_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but188;
        call();
    }
    protected void Button189_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but189;
        call();
    }
    protected void Button299_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but299;
        call();
    }
    protected void Button192_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but192;
        call();
    }
    protected void Button350_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but350;
        call();
    }
    protected void Button191_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but191;
        call();
    }
    protected void Button190_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but190;
        call();
    }
    protected void Button296_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but296;
        call();
    }
    protected void Button193_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but193;
        call();
    }
    protected void Button297_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but297;
        call();
    }
    protected void Button194_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but194;
        call();
    }
    protected void Button195_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but195;
        call();
    }
    protected void Button283_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but283;
        call();
    }
    protected void Button198_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but198;
        call();
    }
    protected void Button392_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but392;
        call();
    }
    protected void Button197_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but197;
        call();
    }
    protected void Button196_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but196;
        call();
    }
    protected void Button282_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but282;
        call();
    }
    protected void Button201_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but201;
        call();
    }
    protected void Button281_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but281;
        call();
    }
    protected void Button200_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but200;
        call();
    }
    protected void Button199_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but199;
        call();
    }
    protected void Button280_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but280;
        call();
    }
    protected void Button202_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but202;
        call();
    }
    protected void Button394_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but394;
        call();
    }
    protected void Button203_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but203;
        call();
    }
    protected void Button204_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but204;
        call();
    }
    protected void Button279_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but279;
        call();
    }
    protected void Button207_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but207;
        call();
    }
    protected void Button278_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but278;
        call();
    }
    protected void Button206_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but206;
        call();
    }
    protected void Button205_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but205;
        call();
    }
    protected void Button263_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but263;
        call();
    }
    protected void Button208_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but208;
        call();
    }
    protected void Button368_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but368;
        call();
    }
    protected void Button209_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but209;
        call();
    }
    protected void Button210_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but210;
        call();
    }
    protected void Button262_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but262;
        call();
    }
    protected void Button356_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but356;
        call();
    }
    protected void Button261_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but261;
        call();
    }
    protected void Button355_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but355;
        call();
    }
    protected void Button211_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but211;
        call();
    }
    protected void Button257_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but257;
        call();
    }
    protected void Button258_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but258;
        call();
    }
    protected void Button351_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but351;
        call();
    }
    protected void Button259_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but259;
        call();
    }
    protected void Button260_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but260;
        call();
    }
    protected void Button256_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but256;
        call();
    }
    protected void Button255_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but255;
        call();
    }
    protected void Button254_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but254;
        call();
    }
    protected void Button253_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but253;
        call();
    }
    protected void Button252_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but252;
        call();
    }
    protected void Button227_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but227;
        call();
    }
    protected void Button228_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but228;
        call();
    }
    protected void Button229_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but229;
        call();
    }
    protected void Button230_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but230;
        call();
    }
    protected void Button231_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but231;
        call();
    }
    protected void Button226_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but226;
        call();
    }
    protected void Button225_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but225;
        call();
    }
    protected void Button224_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but224;
        call();
    }
    protected void Button222_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but222;
        call();
    }
    protected void Button223_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but223;
        call();
    }
    protected void Button217_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but217;
        call();
    }
    protected void Button218_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but218;
        call();
    }
    protected void Button219_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but219;
        call();
    }
    protected void Button220_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but220;
        call();
    }
    protected void Button221_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but221;
        call();
    }
    protected void Button216_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but216;
        call();
    }
    protected void Button215_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but215;
        call();
    }
    protected void Button214_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but214;
        call();
    }
    protected void Button213_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but213;
        call();
    }
    protected void Button212_Click(object sender, EventArgs e)
    {
        Session["ScheduleId"] = but212;
        call();
    }
}
