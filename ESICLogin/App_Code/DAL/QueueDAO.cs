using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public class QueueDAO
{

    string QueueStatus;
    string ConnectionString;
    string Decryption;

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

    // Queue Display - Connection String

    #region Queue Display - Connection String

    public QueueDAO()
    {
        Decryption = ConfigurationManager.AppSettings["LocalConnection"].ToString();

        ConnectionString = Decryptdata(Decryption);
        //MySqlConnection = ConnectionString;
        //ConnectionString = "Data Source=HMIS-SERVER ; User Id=sa; Password=cmc@123; Initial Catalog=att-india-qms; Pooling=false";
       // ConnectionString ="Data Source=EQMS1-PC\\SQLSERVER;User Id=sa;Password=P@55w0rd;Initial Catalog=att-india-qms;Pooling=false";
        MySqlConnection = new SqlConnection(ConnectionString);
    }

    #endregion Queue Display - Connection String

    // Queue Display - DirectionID

    #region Queue Display - DirectionID

    public DataTable DaoGetDirectionID(QueueView queueview)
    {

        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable MyQueueNO = new DataTable();
        try
        {
           // SqlCommand MySqlCommand = new SqlCommand("select v.visit_queue_no_show,r.room_code,q.queue_department_id,q.queue_serv_starttime,q.sms_status_flag,q.queue_tnx_id from tbl_queue_tnx q,tbl_customervisit_tnx v,tbl_room_mst r,tbl_terminal_mst t where q.queu_visit_tnxid=v.visit_tnx_id and q.queue_status_id=2 and q.queue_department_id in (2,8,9) and cast(q.queue_serv_starttime as date) = cast(getdate() as date) and q.queue_servterminal_id=t.terminal_id and t.terminal_room_id=r.room_id  order by q.queue_serv_starttime desc", MySqlConnection);

            SqlCommand MySqlCommand = new SqlCommand("select DISTINCT v.visit_queue_no_show,r.room_code,q.queue_department_id,q.queue_serv_starttime,q.sms_status_flag,q.queue_tnx_id from tbl_queue_tnx q,tbl_customervisit_tnx v,tbl_room_mst r,tbl_terminal_mst t where q.queu_visit_tnxid=v.visit_tnx_id and r.[room_mac] collate SQL_Latin1_General_CP1_CI_AS=t.[terminal_ip] collate SQL_Latin1_General_CP1_CI_AS and q.queue_status_id=2 and q.queue_department_id in (36) and cast(q.queue_serv_starttime as date) = cast(getdate() as date) and q.queue_servterminal_id=t.terminal_id order by q.queue_serv_starttime desc", MySqlConnection);

            // MySqlCommand.Parameters.AddWithValue("@deptartment_id", queueview.DepartmentID);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            MyQueueNO.Load(dr);

            //MySqlConnection.Close();

            return MyQueueNO;
        }
        catch
        {
            return MyQueueNO;
        }
        finally
        {
            MySqlConnection.Close();
        }

    }
    #endregion Queue Display - DirectionID


    // Queue Display - DirectionID

    #region Queue Display - DirectionID1

    public DataTable DaoGetDirectionID1(QueueView queueview)
    {

        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable MyQueueNO = new DataTable();

        try
        {

          // SqlCommand MySqlCommand = new SqlCommand("select DISTINCT v.visit_queue_no_show,r.room_code,q.queue_department_id,q.queue_serv_starttime,q.sms_status_flag,q.queue_tnx_id from tbl_queue_tnx q,tbl_customervisit_tnx v,tbl_room_mst r,tbl_terminal_mst t where q.queu_visit_tnxid=v.visit_tnx_id and t.terminal_desc = r.room_desc and r.room_dept_id = q.queue_department_id  and q.queue_status_id=2 and q.queue_department_id in (2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20) and cast(q.queue_serv_starttime as date) = cast(getdate() as date) and q.queue_servterminal_id=t.terminal_id order by q.queue_serv_starttime desc", MySqlConnection);
            SqlCommand MySqlCommand = new SqlCommand("select DISTINCT v.visit_queue_no_show,r.room_code,q.queue_department_id,q.queue_serv_starttime,q.sms_status_flag,q.queue_tnx_id from tbl_queue_tnx q,tbl_customervisit_tnx v,tbl_room_mst r,tbl_terminal_mst t where r.[room_mac] collate SQL_Latin1_General_CP1_CI_AS=t.[terminal_ip] collate SQL_Latin1_General_CP1_CI_AS and q.queu_visit_tnxid=v.visit_tnx_id  and q.queue_status_id=2 and q.queue_department_id in (2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20) and cast(q.queue_serv_starttime as date) = cast(getdate() as date) and q.queue_servterminal_id=t.terminal_id order by q.queue_serv_starttime desc",MySqlConnection);
            // MySqlCommand.Parameters.AddWithValue("@deptartment_id", queueview.DepartmentID);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            MyQueueNO.Load(dr);

            //MySqlConnection.Close();

            return MyQueueNO;
        }
        catch
        {
            return MyQueueNO;
        }
        finally
        {
            MySqlConnection.Close();
        }

    }
    #endregion Queue Display - DirectionID1

    // Queue Display - DirectionID

    #region Queue Display - DirectionID2

    public DataTable DaoGetDirectionID2(QueueView queueview)
    {

        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable MyQueueNO = new DataTable();

        try
        {
            SqlCommand MySqlCommand = new SqlCommand("select DISTINCT v.visit_queue_no_show,r.room_code,q.queue_department_id,q.queue_serv_starttime,q.sms_status_flag,q.queue_tnx_id from tbl_queue_tnx q,tbl_customervisit_tnx v,tbl_room_mst r,tbl_terminal_mst t where q.queu_visit_tnxid=v.visit_tnx_id and r.[room_mac] collate SQL_Latin1_General_CP1_CI_AS=t.[terminal_ip] collate SQL_Latin1_General_CP1_CI_AS  and q.queue_status_id=2 and q.queue_department_id in (37,38) and cast(q.queue_serv_starttime as date) = cast(getdate() as date) and q.queue_servterminal_id=t.terminal_id order by q.queue_serv_starttime desc", MySqlConnection);

            // MySqlCommand.Parameters.AddWithValue("@deptartment_id", queueview.DepartmentID);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            MyQueueNO.Load(dr);

            //MySqlConnection.Close();

            return MyQueueNO;
        }
        catch
        {
            return MyQueueNO;
        }
        finally
        {
            MySqlConnection.Close();
        }

    }
    #endregion Queue Display - DirectionID2


    // Queue Display - DirectionID Billing

    #region Queue Display - DirectionID

    public DataTable DaoGetDirectionIDBilling(QueueView queueview)
    {

        

        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable MyQueueNO = new DataTable();

        try
        {

            SqlCommand MySqlCommand = new SqlCommand("select v.visit_queue_no_show,r.room_code,q.queue_department_id,q.queue_serv_starttime,q.sms_status_flag,q.queue_tnx_id from tbl_queue_tnx q,tbl_customervisit_tnx v,tbl_room_mst r,tbl_terminal_mst t where q.queu_visit_tnxid=v.visit_tnx_id and q.queue_status_id=2 and q.queue_department_id=5 and cast(q.queue_serv_starttime as date) = cast(getdate() as date) and q.queue_servterminal_id=t.terminal_id and t.terminal_room_id=r.room_id  order by q.queue_serv_starttime desc", MySqlConnection);

            // MySqlCommand.Parameters.AddWithValue("@deptartment_id", queueview.DepartmentID);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            MyQueueNO.Load(dr);

            //MySqlConnection.Close();

            return MyQueueNO;
        }
        catch
        {
            return MyQueueNO;
        }
        finally
        {
            MySqlConnection.Close();
        }

    }
    #endregion Queue Display - DirectionID

    // Queue Display - DirectionID CounterDisplay

    #region Queue Display - DirectionID CounterDisplay

    public DataTable DaoGetDirectionIDCounterDisplay(QueueView queueview)
    {

        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable MyQueueNO = new DataTable();

        try
        {

            SqlCommand MySqlCommand = new SqlCommand("select v.visit_queue_no_show,r.room_code,q.queue_department_id,q.queue_serv_starttime,q.sms_status_flag,q.queue_tnx_id from tbl_queue_tnx q,tbl_customervisit_tnx v,tbl_room_mst r,tbl_terminal_mst t where q.queu_visit_tnxid=v.visit_tnx_id and q.queue_status_id=2 and q.queue_department_id=@deptartment_id and cast(q.queue_serv_starttime as date) = cast(getdate() as date) and q.queue_servterminal_id=t.terminal_id and t.terminal_room_id=r.room_id  order by q.queue_serv_starttime desc", MySqlConnection);

            MySqlCommand.Parameters.AddWithValue("@deptartment_id", queueview.DepartmentIDCounterDisplay);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            MyQueueNO.Load(dr);

            //MySqlConnection.Close();

            return MyQueueNO;
        }
        catch
        {
            return MyQueueNO;
        }
        finally
        {
            MySqlConnection.Close();
        }

    }
    #endregion Queue Display - DirectionID
    // Queue Display - GetNextThreeTokens

    #region Queue Display - GetNextThreeTokens

    public DataTable DaoGetNextThreeTokens(QueueView queueview)
    {

        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable MyQueueNO = new DataTable();

        try
        {

            SqlCommand MySqlCommand = new SqlCommand("select c.visit_queue_no_show as queue_show,c.visit_tnx_id as visit_tnx,q.queue_department_id,c.visit_queue_no as queue_no from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @deptartment_id and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 order by c.consulting_status ASC,c.customer_appointment_time ASC", MySqlConnection);

            MySqlCommand.Parameters.AddWithValue("@deptartment_id", queueview.DepartmentIDNext);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            MyQueueNO.Load(dr);

            //MySqlConnection.Close();

            return MyQueueNO;
        }
        catch
        {
            return MyQueueNO;
        }
        finally
        {
            MySqlConnection.Close();
        }

    }
    #endregion Queue Display - GetNextThreeTokens

    // Queue Display - GetNextTokens

    #region Queue Display - GetNextTokens

    public DataTable DaoGetNextTokens(QueueView queueview)
    {

        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable MyQueueNO = new DataTable();

        try
        {

            SqlCommand MySqlCommand = new SqlCommand("select c.visit_queue_no_show as queue_show,c.visit_tnx_id as visit_tnx,q.queue_department_id,c.visit_queue_no as queue_no from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 order by c.consulting_status ASC,c.customer_appointment_time ASC", MySqlConnection);

            //  MySqlCommand.Parameters.AddWithValue("@deptartment_id", queueview.DepartmentIDNext);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            MyQueueNO.Load(dr);

            //MySqlConnection.Close();

            return MyQueueNO;
        }
        catch
        {
            return MyQueueNO;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }
    #endregion Queue Display - GetNextThreeTokens

    // Queue Display - Changing Colour Status

    #region Queue Display - Changing Colour Status

    public DataTable DaoChangingColourStatus(QueueView queueview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable flagname = new DataTable();

        try
        {
            SqlCommand MySqlCommand = new SqlCommand("update tbl_queue_tnx set sms_status_flag='D' where queue_tnx_id=@queuetnxid", MySqlConnection);

            MySqlCommand.Parameters.AddWithValue("@queuetnxid", queueview.QueueTnxId);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            flagname.Load(dr);

            //MySqlConnection.Close();

            return flagname;
        }
        catch
        {
            return flagname;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }

    #endregion Changing Colour Status


    // Queue Display - Missed Queue

    #region Queue Display - Missed Queue

    public DataTable DaoGetMissedQueue(QueueView queueview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable MyQueueNO = new DataTable();

        try
        {

            SqlCommand MySqlCommand = new SqlCommand("select v.visit_queue_no_show from tbl_queue_tnx q,tbl_customervisit_tnx v,tbl_room_mst r,tbl_terminal_mst t where q.queu_visit_tnxid=v.visit_tnx_id and q.queue_status_id=4 and cast(q.queue_serv_starttime as date) = cast(getdate() as date) and q.queue_terminal_id=t.terminal_id and t.terminal_room_id=r.room_id order by q.queue_serv_starttime desc", MySqlConnection);

            // MySqlCommand.Parameters.AddWithValue("@department_id", queueview.DepartmentID);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            MyQueueNO.Load(dr);

            //MySqlConnection.Close();

            return MyQueueNO;
        }
        catch
        {
            return MyQueueNO;
        }
        finally
        {
            MySqlConnection.Close();
        }

    }
    #endregion Queue Display - MissedQueue

    // Queue Display - DAO Getting Department Name

    #region Queue Display - DAO Getting Department Name by DepartmentId
    public DataTable DaoGetDepartmentName(QueueView queueview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable dptName = new DataTable();

        try
        {

            SqlCommand MySqlCommand = new SqlCommand("select department_desc,department_name,doctor_image from tbl_department_mst  where department_id=@department_id1", MySqlConnection);

            MySqlCommand.Parameters.AddWithValue("@department_id1", queueview.DepartmentID);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            dptName.Load(dr);

            //MySqlConnection.Close();

            return dptName;
        }
        catch
        {
            return dptName;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }
   #endregion


    // Queue Display - DAO Getting Department Image CD

    #region Queue Display - DAO Getting Department Name by DepartmentId
    public DataTable DaoGetDepartmentImage(QueueView queueview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable dptName = new DataTable();

        try
        {

            SqlCommand MySqlCommand = new SqlCommand("select department_desc,department_name,doctor_image from tbl_department_mst  where department_id=@department_id1", MySqlConnection);

            MySqlCommand.Parameters.AddWithValue("@department_id1", queueview.DepartmentIDCounterDisplay);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            dptName.Load(dr);

            //MySqlConnection.Close();

            return dptName;
        }
        catch
        {
            return dptName;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }
    #endregion

    // Queue Display - Display Scroll Text

    #region Queue Display - Display Scroll Text

    public DataTable DaoGetDisplayScrollText(QueueView queueview)
    {

        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable MyQueueNO = new DataTable();

        try
        {

            SqlCommand MySqlCommand = new SqlCommand("select * from tbl_display_dtl", MySqlConnection);

            // MySqlCommand.Parameters.AddWithValue("@deptartment_id", queueview.DepartmentIDCounterDisplay);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            MyQueueNO.Load(dr);

            //MySqlConnection.Close();

            return MyQueueNO;
        }
        catch
        {
            return MyQueueNO;
        }
        finally
        {
            MySqlConnection.Close();
        }

    }
    #endregion Queue Display - Display Scroll Text

    // Waiting Time

    #region Queue Display - Waiting Time
    public DataTable WaitingTime(int deptid)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable dptName = new DataTable();

        try
        {

            SqlCommand MySqlCommand = new SqlCommand("select c.visit_tnx_id as visit_tnx,c.visit_queue_no as queue_no,q.queue_wait_starttime,q.queue_wait_endtime from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @deptid and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1", MySqlConnection);

            MySqlCommand.Parameters.AddWithValue("@deptid", deptid);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            dptName.Load(dr);

            //MySqlConnection.Close();

            return dptName;
        }
        catch
        {
            return dptName;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }
    #endregion


    // Waiting Time

    #region Queue Display - Waiting Time
    public DataTable ServingTime(int deptid)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable dptName = new DataTable();

        try
        {

            SqlCommand MySqlCommand = new SqlCommand("select c.visit_tnx_id as visit_tnx,c.visit_queue_no as queue_no,q.queue_serv_starttime,q.queue_serv_endtime from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @deptid and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 2", MySqlConnection);

            MySqlCommand.Parameters.AddWithValue("@deptid", deptid);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            dptName.Load(dr);

            //MySqlConnection.Close();

            return dptName;
        }
        catch
        {
            return dptName;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }
    #endregion


    // Waiting Time

    #region Queue Display - Waiting Time Deptid
    public DataTable WaitingTimeDeptid()
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        DataTable dptName = new DataTable();

        try
        {

            // SqlCommand MySqlCommand = new SqlCommand("select t.terminal_dept_id,r.room_code from tbl_room_mst r,tbl_terminal_mst t where t.terminal_ip COLLATE DATABASE_DEFAULT=r.room_mac COLLATE DATABASE_DEFAULT", MySqlConnection);
            SqlCommand MySqlCommand = new SqlCommand("select r.room_dept_id,r.room_code from tbl_room_mst r where r.room_mac is not null", MySqlConnection);

            // MySqlCommand.Parameters.AddWithValue("@deptid", deptid);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();



            dptName.Load(dr);

            //MySqlConnection.Close();

            return dptName;
        }
        catch
        {
            return dptName;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }
    #endregion




}

