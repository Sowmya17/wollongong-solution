using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

/// <summary>
/// Summary description for RTDAL
/// </summary>
public class RTDAL
{
    string ConnectionString;
    string Decryption;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter sqlad;
    SqlDataReader sqlrd;
    string QueueStatus;

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


    #region SQL CONNECTION - ACCESSING CONNECTION STRING FROM TEXT FILE

    SqlConnection MySqlConnection = new SqlConnection();

    #endregion SQL CONNECTION - ACCESSING CONNECTION STRING FROM TEXT FILE

    // RT DAO - Constructor

    #region RT DAO - Constructor

    public RTDAL()
	{
        Decryption = ConfigurationManager.AppSettings["LocalConnection"].ToString();

        sqlad = new SqlDataAdapter();

        ConnectionString = Decryptdata(Decryption);
	}

    #endregion RT DAO - Constructor

    #region SearchQueueNoDetails
    public DataTable SearchQueueNoDetails(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select c.visit_tnx_id as visit_tnx,c.visit_queue_no as queue_no,c.visit_queue_no_show as queue_show  from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @departid and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 order by c.consulting_status ASC,c.customer_appointment_time ASC";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@departid",rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchMissedQueueNoDetail
    public DataTable SearchMissedQueueNoDetail(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select c.visit_tnx_id as visit_tnx,c.visit_queue_no as queue_no,c.visit_queue_no_show as queue_show from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @departid and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE()) and q.queue_status_id = 4 order by c.consulting_status ASC,c.customer_appointment_time ASC";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchHoldQueueNoDetail
    public DataTable SearchHoldQueueNoDetail(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select c.visit_tnx_id as visit_tnx,c.visit_queue_no as queue_no,c.visit_queue_no_show as queue_show from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @departid and q.queu_visit_tnxid = c.visit_tnx_id and q.queue_holdstarting_time IS NOT NULL and q.queue_holdend_time IS NULL and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE()) and q.queue_status_id=5;";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchPendingQueueNoDetail
    public DataTable SearchPendingQueueNoDetail(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select c.visit_queue_no_show as queue_show,d.department_desc,c.visit_tnx_id as visit_tnx from tbl_queueplan_dtl p,tbl_customervisit_tnx c,tbl_department_mst d where CONVERT(DATE, plan_datetime) = CONVERT(DATE, GETDATE())and plan_transfer_id IS NULL and unplan_transfer_id IS NULL and p.plan_visit_id=c.visit_tnx_id and p.plan_department_id=d.department_id and p.plan_department_id=@departid order by p.plan_department_id asc;";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchQueueMemberDetails
    public DataTable SearchQueueMemberDetails(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select c.visit_customer_id,LOWER(m.members_firstname) as members_firstname,UPPER(m.members_lastname) as members_lastname, m.members_age,m.members_gender,m.members_dob,r.relation_desc,cm.customer_firstname,cm.customer_lastname, c.customer_appointment_time " +
"from tbl_customervisit_tnx c,tbl_customer_dtl m,tbl_relation_mst r,tbl_customerreg_mst cm " +
"where c.visit_tnx_id = @visittnxid and m.members_id = c.visit_member_id and r.relation_id = m.members_relation_id and cm.customer_id = c.visit_customer_id";



            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion
    
    #region SearchQueueServiceStatusDetails

    public DataTable SearchQueueServiceStatusDetails(RTBEL rtview)
    {
        DataTable dtsqssd = new DataTable();
        DataSet dsqssd = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_queue_tnx where queue_status_id = 2 and CONVERT(DATE, queue_datetime) = CONVERT(DATE, GETDATE()) and queue_servuser_id=@gettinguserid";
            
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@gettinguserid", rtview.GettingUserId);

            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(dsqssd);
            dtsqssd = dsqssd.Tables[0];
            return dtsqssd;
        }
        catch
        {
            return dtsqssd;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }

    #endregion SearchQueueServiceStatusDetails
    
    #region SearchQueuePlanList
    public DataTable SearchQueuePlanList(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select q.plan_id,d.department_desc from tbl_queueplan_dtl q,tbl_department_mst d where q.plan_visit_id = @visittnxid and q.plan_department_id != @departid and d.department_id = q.plan_department_id and q.plan_transfer_id IS NULL and q.unplan_transfer_id IS NULL";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchDepartmentDetails
    public DataTable SearchDepartmentDetails()
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT distinct department_id,department_desc FROM [tbl_department_mst],tbl_terminal_mst where department_id=terminal_dept_id and terminal_type_id in (2,6) ORDER BY department_desc ASC";
            //string sql = "SELECT distinct department_id,department_desc FROM [tbl_department_mst]";
            //string sql = "SELECT department_id,department_desc FROM tbl_department_mst where department_id <=6";
            //string sql = "SELECT department_id,department_desc FROM [tbl_department_mst],tbl_terminal_mst where department_id=terminal_dept_id and terminal_type_id =2 ORDER BY department_desc ASC";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchCallVisitFunction
    public DataTable SearchCallVisitFunction(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_queue_tnx where queu_visit_tnxid = @visittnxid and queue_wait_endtime IS NULL and queue_serv_starttime IS NULL and queue_department_id = @departid and CONVERT(DATE,queue_datetime) = CONVERT(DATE, GETDATE());";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region Dao Get Queue No
    public DataTable DaoGetQueueNo(RTBEL rtview)
    {
        DataTable getqueuenodt = new DataTable();
        DataSet getqueuenods = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select visit_queue_no from tbl_customervisit_tnx where visit_tnx_id=@visittnxid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            //cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(getqueuenods);
            getqueuenodt = getqueuenods.Tables[0];
            return getqueuenodt;
        }
        catch
        {
            return getqueuenodt;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region Dao Search Queue No
    public DataTable DaoSearchQueueNo(RTBEL rtview)
    {
        DataTable getsearchqueuenodt = new DataTable();
        DataSet getsearchqueuenods = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_customervisit_tnx where visit_queue_no=@queueno";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@queueno", rtview.SearchQueueNo);
            //cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(getsearchqueuenods);
            getsearchqueuenodt = getsearchqueuenods.Tables[0];
            return getsearchqueuenodt;
        }
        catch
        {
            return getsearchqueuenodt;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region DaoInsertAutoSMS
    public DataTable DaoInsertAutoSMS(RTBEL rtview)
    {
        DataTable getinsertautosmsdt = new DataTable();
        DataSet getinsertautosmsnods = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_queue_tnx set sms_status_flag=@smsstatusflag where queu_visit_tnxid=@queuevisittnxid and queue_department_id=@departid";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@smsstatusflag",rtview.SMSStatusFlag);
            cmd.Parameters.AddWithValue("@queuevisittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);

            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
            sqlad.Fill(getinsertautosmsnods);
            getinsertautosmsdt = getinsertautosmsnods.Tables[0];
            return getinsertautosmsdt;
            
            //return "0";
        }
        catch
        {
            return getinsertautosmsdt;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region Search Missed Visit Function
    public DataTable SearchMissedVisitFunction(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_queue_tnx where queu_visit_tnxid = @visittnxid and queue_wait_endtime IS NOT NULL and queue_serv_starttime IS NOT NULL and queue_department_id = @departid and CONVERT(DATE,queue_datetime) = CONVERT(DATE, GETDATE());";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion Search Missed Visit Function

    #region UpdateHoldQueue
    public void UpdateHoldQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_queue_tnx set queue_serv_endtime=@serverendtime,queue_status_id=@queuestatus,sms_status_flag=@smsflag,queue_holdstarting_time=@holdstarttime  where queu_visit_tnxid=@visittnxid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@serverendtime", DateTime.Now);
            cmd.Parameters.AddWithValue("@queuestatus", rtview.statusid);
            cmd.Parameters.AddWithValue("@smsflag", rtview.smsflag);
            cmd.Parameters.AddWithValue("@holdstarttime", DateTime.Now);
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
           // SqlDataReader dr1 = cmd.ExecuteReader();
            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();

            
        }
        catch
        {
           
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region UpdateStatusid
    public void UpdateStatusid(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_queue_tnx set queue_status_id=@queuestatus,queue_holdend_time=@holdendtime  where queu_visit_tnxid=@visittnxid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@queuestatus", rtview.statusid);
            cmd.Parameters.AddWithValue("@holdendtime", DateTime.Now);
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            // SqlDataReader dr1 = cmd.ExecuteReader();
            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();


        }
        catch
        {

        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchMissedVisitFunction
    public DataTable SearchHoldVisitFunction(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_queue_tnx where queu_visit_tnxid = @visittnxid and queue_holdstarting_time IS NOT NULL and queue_holdend_time IS NULL and queue_department_id = @departid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchENDVisitFunction
    public DataTable SearchENDVisitFunction(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_queue_tnx where queu_visit_tnxid = @visittnxid and queue_serv_starttime IS NOT NULL and queue_serv_endtime IS NULL and queue_department_id = @departid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SetQueuestatusforCallMissed
    public string SetQueuestatusforCallMissed(RTBEL rtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_queue_tnx set queue_wait_endtime=@Waitendtime,queue_serv_starttime = @ServStarttime,queue_servuser_id=@Userid,queue_servterminal_id=@Terminalid,queue_status_id=@queuestatusid,sms_status_flag=@smsstatusflag,button_event_flag=@buttoneventflag where queue_tnx_id=@queuetnxid";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Waitendtime",DateTime.Now );
            cmd.Parameters.AddWithValue("@ServStarttime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Userid",rtview.UserId);
            cmd.Parameters.AddWithValue("@Terminalid", rtview.TerminalId);
            cmd.Parameters.AddWithValue("@queuestatusid", rtview.QueueStatusID);
            cmd.Parameters.AddWithValue("@queuetnxid", rtview.CustomerQueueTnx);
            cmd.Parameters.AddWithValue("@smsstatusflag", rtview.SMSStatusFlag);
            cmd.Parameters.AddWithValue("@buttoneventflag",rtview.ButtonEventFlag);         
            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();


            return "0";
        }
        catch
        {
            return "1";
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SetQueuestatusforCallMissedSMS
    public string SetQueuestatusforCallMissedSMS(RTBEL rtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_queue_tnx set queue_wait_endtime=@Waitendtime,queue_serv_starttime = @ServStarttime,queue_servuser_id=@Userid,queue_servterminal_id=@Terminalid,queue_status_id=@queuestatusid,sms_status_flag=@smsstatusflag,message_status_flag=@message_status_flag where queue_tnx_id=@queuetnxid";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Waitendtime", DateTime.Now);
            cmd.Parameters.AddWithValue("@ServStarttime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Userid", rtview.UserId);
            cmd.Parameters.AddWithValue("@Terminalid", rtview.TerminalId);
            cmd.Parameters.AddWithValue("@queuestatusid", rtview.QueueStatusID);
            cmd.Parameters.AddWithValue("@queuetnxid", rtview.CustomerQueueTnx);
            cmd.Parameters.AddWithValue("@smsstatusflag", rtview.SMSStatusFlag);
            cmd.Parameters.AddWithValue("@message_status_flag", rtview.SMSStatusFlag);

            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();


            return "0";
        }
        catch
        {
            return "1";
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SetQueuestatusforEND
    public string SetQueuestatusforEND(RTBEL rtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_queue_tnx set queue_serv_endtime = @ServEndtime,queue_servuser_id=@Userid,queue_servterminal_id=@Terminalid,queue_status_id=@queuestatusid where queue_tnx_id=@queuetnxid";

            cmd = new SqlCommand(sql, con);
          //  cmd.Parameters.AddWithValue("@Waitendtime", DateTime.Now);
            cmd.Parameters.AddWithValue("@ServEndtime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Userid", rtview.UserId);
            cmd.Parameters.AddWithValue("@Terminalid", rtview.TerminalId);
            cmd.Parameters.AddWithValue("@queuestatusid", rtview.QueueStatusID);
            cmd.Parameters.AddWithValue("@queuetnxid", rtview.CustomerQueueTnx);

            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();


            return "0";
        }
        catch
        {
            return "1";
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchFirstPlanInList
    public DataTable SearchFirstPlanInList(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_queueplan_dtl where plan_id=@planid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@planid", rtview.QueuePlanTnxId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region InsertCustomerQueueTransactions
    public string InsertCustomerQueueTransactions(RTBEL rtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_queue_tnx (queu_visit_tnxid,queue_datetime,queue_wait_starttime,queue_user_id,queue_terminal_id,queue_department_id,queue_status_id,queue_order_id,sms_status_flag)" +
                     "values(@visitid, @datetime, @waitstarttime,@userid, @terminalid,@departmentid,@statusid,@orderid,@smsstatusflag)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@visitid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@waitstarttime", DateTime.Now);
            cmd.Parameters.AddWithValue("@userid",rtview.UserId);
            cmd.Parameters.AddWithValue("@terminalid", rtview.TerminalId);
            cmd.Parameters.AddWithValue("@departmentid", rtview.DepartmentId);
            cmd.Parameters.AddWithValue("@statusid", rtview.QueueStatusID);
            cmd.Parameters.AddWithValue("@orderid", rtview.OrderId);
            cmd.Parameters.AddWithValue("@smsstatusflag",rtview.SMSStatusFlag);
            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();


            return "0";
        }
        catch
        {
            return "1";
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchLastQueueTransactionID
    public DataTable SearchLastQueueTransactionID(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select TOP 1 * from tbl_queue_tnx where queu_visit_tnxid =@customervisitid and queue_status_id='1' and queue_wait_endtime is NULL and queue_serv_starttime is NULL and queue_serv_endtime is NULL Order by queue_tnx_id desc";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@customervisitid", rtview.CustomerVisitId);
            
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SetTransaferIdtoPlan
    public string SetTransaferIdtoPlan(RTBEL rtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_queueplan_dtl set plan_transfer_id = @transferid where plan_id=@planid and plan_order_id=@orderid";

            cmd = new SqlCommand(sql, con);
          
            cmd.Parameters.AddWithValue("@transferid", rtview.CustomerQueueTnx);
            cmd.Parameters.AddWithValue("@planid", rtview.QueuePlanTnxId);
            cmd.Parameters.AddWithValue("@orderid", rtview.OrderId);

            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();


            return "0";
        }
        catch
        {
            return "1";
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region InsertCustomerQueuePlanOrderone
    public string InsertCustomerQueuePlanOrderone(RTBEL rtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_queueplan_dtl (plan_datetime,plan_visit_id,unplan_transfer_id,plan_order_id,plan_department_id,plan_user_id,plan_terminal_id)" +
                     "values(@datetime, @visitid, @transferid,@orderid, @departmentid,@userid,@terminalid)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@visitid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@transferid", rtview.CustomerQueueTnx);
            cmd.Parameters.AddWithValue("@orderid", rtview.OrderId);
            cmd.Parameters.AddWithValue("@departmentid", rtview.DepartmentId);
            cmd.Parameters.AddWithValue("@userid", rtview.UserId);
            cmd.Parameters.AddWithValue("@terminalid", rtview.TerminalId);
            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();


            return "0";
        }
        catch
        {
            return "1";
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion
    
    #region RT - Grid View Loading

    public DataTable GetRTGridViewLoading(string selectedqueueno)
    {

        DataTable MyAvailableUserName = new DataTable();
        DataSet MyQueueNumber = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);

            con.Open();

            string sql = "select p.plan_datetime,v.visit_customer_id,v.visit_customer_name,m.members_firstname+m.members_lastname as members_name,r.relation_desc,d.department_desc,p.plan_transfer_id,p.unplan_transfer_id, m.members_dob from tbl_customervisit_tnx v,tbl_customer_dtl m,tbl_relation_mst r,tbl_queueplan_dtl p,tbl_department_mst d,tbl_customerreg_mst c where v.visit_queue_no_show=@queue_number and CONVERT(DATE,p.plan_datetime)= CONVERT(DATE, GETDATE()) and v.visit_customer_id=c.customer_id and c.customer_id=m.members_customer_id and m.members_relation_id=r.relation_id and v.visit_member_id=m.members_id and v.visit_tnx_id=p.plan_visit_id and p.plan_department_id=d.department_id order by p.plan_order_id";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@queue_number", selectedqueueno);

            //cmd.Parameters.AddWithValue("@date_time", crtqueuestatusbel.DateTime);

            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(MyQueueNumber);
            MyAvailableUserName = MyQueueNumber.Tables[0];
            return MyAvailableUserName;
        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Rt Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion RT - Grid View Loading

    #region Getting Queue Status - Getting My Queue Status

    public string GetDALMyQueueStatus(RTBEL rtqueuestatusbel)
    {
        //DataTable QueueStatus = new DataTable();
        try
        {
            con = new SqlConnection(ConnectionString);

            con.Open();

            string sql = "select qs.queue_status_desc from tbl_queuestatus_mst qs,tbl_queue_tnx q where q.queue_tnx_id=@Transfer_ID and q.queue_status_id=qs.queue_status_id";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Transfer_ID", rtqueuestatusbel.TransferID);

           // cmd.Parameters.AddWithValue("@date_time", crtqueuestatusbel.DateTime);

            //cmd.ExecuteNonQuery();
            //sqlad.SelectCommand = cmd;
            //sqlad.Fill(MyQueueNumber);
            //MyAvailableUserName = MyQueueNumber.Tables[0];
            //return MyAvailableUserName;

            SqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            //QueueStatus = dr.GetGuid(0).ToString();
            //dr.Close();
            QueueStatus = dr["queue_status_desc"].ToString();
            dr.Close();

            return QueueStatus;

         

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Availability Queue Status Data From DataBase", exmsg);
        }

        finally
        {
            con.Close();
        }
    }

    #endregion Getting Queue Status - Getting My Queue Status
    
    #region GetDepartmentCountByQueueNo

    public int GetDepartmentCountByQueueNo(string selectedqueueno)
    {
        try
        {
            int departmentcount = 0;
            con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(qp.plan_department_id) as departmentCount from tbl_customervisit_tnx cv inner join tbl_queueplan_dtl qp on cv.visit_tnx_id = qp.plan_visit_id where cv.visit_queue_no_show=@QueueNo", con);
            cmd.Parameters.AddWithValue("@QueueNo", selectedqueueno);

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);

            con.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                departmentcount = Convert.ToInt16(dt.Rows[i]["departmentCount"].ToString());
            }

            return departmentcount;
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to retrieve data", ex);
        }
    }

    #endregion

    #region DAO Get Next VIP Queue
    public DataTable DAOGetNextVIPQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select Top 1 q.queue_tnx_id,c.visit_tnx_id,c.visit_queue_no_show from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @departid and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 and consulting_status='V' order by c.visit_datetime asc;";
            cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion DAO Get Next VIP Queue

    #region DAO Get Appointment VIP Queue

    public DataTable DAOGetNextAppointmentQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select Top 1 q.queue_tnx_id,c.visit_tnx_id,c.visit_queue_no_show,DATEADD(minute, -15, c.customer_appointment_time) As ConsultingStartTime,DATEADD(minute, 15, c.customer_appointment_time) As ConsultingEndTime from tbl_customervisit_tnx c,tbl_queue_tnx q where cast(c.visit_datetime as date) = cast(getdate() as date) and c.consulting_status='A' and c.visit_tnx_id =q.queu_visit_tnxid and q.queue_status_id='1' and q.queue_department_id=@departid order by customer_appointment_time asc";
            cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }

    #endregion DAO Get Next Appointment Queue

    #region DAO Get Load
    public DataTable DAOGetLoad(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select Top 1 q.queue_tnx_id,c.visit_tnx_id,c.visit_queue_no_show from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @departid and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 2 and q.queue_servuser_id=@userid order by c.visit_datetime asc";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@userid", rtview.UserId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion DAO Get Load
    
    #region DAO Get Next Walkin Queue
    public DataTable DAOGetNextWalkinQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select Top 1 q.queue_tnx_id,c.visit_tnx_id,c.visit_queue_no_show from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @departid and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 and consulting_status='W' order by c.visit_datetime asc";
            cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion DAO Get Next Walkin Queue

    #region DAO Get Immediate Appointment VIP Queue

    public DataTable DAOGetNextImmediateAppointmentQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select Top 1 q.queue_tnx_id,c.visit_tnx_id,c.visit_queue_no_show from tbl_customervisit_tnx c,tbl_queue_tnx q where cast(c.visit_datetime as date) = cast(getdate() as date) and c.consulting_status='A' and c.visit_tnx_id =q.queu_visit_tnxid and q.queue_status_id='1' and q.queue_department_id=@departid order by customer_appointment_time asc";
            cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }

    #endregion DAO Get Next Immediate Appointment Queue

    #region DAO Update Appointment To Walkin Status
    public string DAOUpdateAppointmentToWalkinStatus(RTBEL rtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_customervisit_tnx set consulting_status='W' where visit_tnx_id=@visittnxid";

            cmd = new SqlCommand(sql, con);
            
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);

            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();


            return "0";
        }
        catch
        {
            return "1";
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion DAO Update VIP To Walkin Status

    #region DAO Re-Calling Queue
    public string DAORecallingQueue(RTBEL rtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_queue_tnx set sms_status_flag='N' where queue_tnx_id=@queuetnxid";

            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@queuetnxid", rtview.CustomerQueueTnx);

            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();


            return "0";
        }
        catch
        {
            return "1";
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion DAO Re-Calling Queue

    #region DAO Getting Next Order
    public DataTable DAOGettingNextOrder(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select Top 1 p.plan_id,p.plan_order_id,p.plan_department_id from tbl_queueplan_dtl p,tbl_queue_tnx q where p.plan_visit_id =@customervisitid and p.plan_visit_id = q.queu_visit_tnxid and p.plan_transfer_id is NULL and p.unplan_transfer_id is NULL order by p.plan_id";
            cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@customervisitid", rtview.CustomerVisitId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion DAO Getting Next Order

    #region DAO Get Next Nurse Appointment Queue
    public DataTable DAOGetNextNurseAppointmentQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select TOP 1 q.queue_tnx_id,c.visit_tnx_id,c.visit_queue_no_show from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @departid and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 and consulting_status='A' order by c.visit_datetime asc";
            cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion DAO Get Next Nurse Appointment Queue

    #region DAO Getting Transaction Id

    public DataTable DAOGettingTransactionId(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select q.queue_tnx_id,c.visit_queue_no_show from tbl_customervisit_tnx c,tbl_queue_tnx q where visit_tnx_id=@customervisitid and c.visit_tnx_id=q.queu_visit_tnxid and q.queue_status_id = 4";
            cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@customervisitid", rtview.CustomerVisitId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion DAO Getting Transaction Id

    #region DAO Getting Fresh Queue Transaction Id

    public DataTable DAOGettingFreshQueueTransactionId(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select q.queue_tnx_id,c.visit_queue_no_show from tbl_customervisit_tnx c,tbl_queue_tnx q where visit_tnx_id=@customervisitid and c.visit_tnx_id=q.queu_visit_tnxid and q.queue_status_id = 1";
            cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@customervisitid", rtview.CustomerVisitId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion DAO Getting Fresh Queue Transaction Id

    #region Search Getting Order Details

    public DataTable SearchGettingOrderDetails(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select Top 1 * from tbl_queueplan_dtl where plan_visit_id=@visittnxid and CONVERT(DATE,plan_datetime) = CONVERT(DATE, GETDATE()) order by plan_order_id desc;";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@visittnxid", rtview.CustomerVisitId);
          //  cmd.Parameters.AddWithValue("@departid", rtview.DepartmentId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch
        {
            return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion Search Getting Order Details

    #region RT Add Customer Queue Plan Orders

    public string RTADDCustomerQueuePlanOrders(RTBEL rtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_queueplan_dtl (plan_datetime,plan_visit_id,plan_order_id,plan_department_id,plan_user_id,plan_terminal_id)" +
                     "values(@datetime, @visitid,@orderid, @departmentid,@userid,@terminalid)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@visitid", rtview.CustomerVisitId);
            cmd.Parameters.AddWithValue("@orderid", rtview.OrderId);
            cmd.Parameters.AddWithValue("@departmentid", rtview.DepartmentId);
            cmd.Parameters.AddWithValue("@userid", rtview.UserId);
            cmd.Parameters.AddWithValue("@terminalid", rtview.TerminalId);
            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();


            return "0";
        }
        catch
        {
            return "1";
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion RT ADD Customer Queue Plan Orders

    #region queue position retrieve

    public DataTable selectQueuePosition(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            // string sql = "select DISTINCT q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and q.sms_status_flag='A'";
            // string sql = "select DISTINCT v.visit_queue_no_show from tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and sms_status_flag='N'";
            // string sql = "select DISTINCT q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and q.message_status_flag='A'";
            //string sql = "select q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c,tbl_appointment_tnx a where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and a.appointment_id=v.customer_appointment_id and q.queue_status_id=1 and q.message_status_flag='A' order by v.consulting_status ASC, v.customer_appointment_time ASC";
            string sql = "select c.visit_tnx_id,c.visit_queue_no,c.visit_queue_no_show  from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 and message_status_flag='A' order by c.consulting_status ASC,c.customer_appointment_time ASC";
            SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
            // MySqlCommand.Parameters.AddWithValue("@Departmentid",smsview.DepartmentID);
            SqlDataReader dr = MySqlCommand.ExecuteReader();

            DataTable MyQSMSstatus = new DataTable();

            MyQSMSstatus.Load(dr);

            MySqlConnection.Close();

            return MyQSMSstatus;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Occured While Retrieving Data From DataBase", ex);

        }
    }
    #endregion queue position retrieve

    #region retrieve visit tnxid by using replied sms
    public DataTable retrievevisittnxidbyusingrepliedsms(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        MySqlConnection.Open();
        string sql = "select visit_tnx_id from tbl_customervisit_tnx where visit_queue_no_show=@InSMS and CONVERT(DATE, visit_datetime) = CONVERT(DATE, GETDATE())";
        SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
        MySqlCommand.Parameters.AddWithValue("@InSMS", smsview.MySms);
        SqlDataReader dr = MySqlCommand.ExecuteReader();
        DataTable MyCustName = new DataTable();
        MyCustName.Load(dr);
        MySqlConnection.Close();
        return MyCustName;
    }
    #endregion  retrieve visit tnxid by using replied sms

    #region SMS - Queue Token Generation Sent SMS

    public DataTable GetDaoQueueTokenGenerationSentSMS(RTBEL smsview)
    {
        SqlConnection con = new SqlConnection(ConnectionString);
        con.Open();
        string sql = "update tbl_queue_tnx set message_status_flag=@smsstatusflag where queu_visit_tnxid=@queuevisittnxid";

        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@smsstatusflag", smsview.SMSStatusFlag);
        cmd.Parameters.AddWithValue("@queuevisittnxid", smsview.QueueTransaction);

        SqlDataReader dr = cmd.ExecuteReader();

        DataTable MyMissedQueueNO = new DataTable();

        MyMissedQueueNO.Load(dr);
        con.Close();
        return MyMissedQueueNO;
    }

    #endregion SMS - Queue Token Generation Sent SMS

    // SMS - Missed Queue Sending SMS

    #region retrieve status flag

    public DataTable RetrieveSMSstatusFlag(RTBEL smsview)
    {
        SqlConnection con = new SqlConnection(ConnectionString);
        con.Open();
        string sql = "select message_status_flag from tbl_queue_tnx where queu_visit_tnxid=@queuevisittnxid";

        SqlCommand cmd = new SqlCommand(sql, con);

        cmd.Parameters.AddWithValue("@queuevisittnxid", smsview.QueueTransaction);

        SqlDataReader dr = cmd.ExecuteReader();

        DataTable MyMissedQueueNO = new DataTable();

        MyMissedQueueNO.Load(dr);
        con.Close();
        return MyMissedQueueNO;

    }

    #endregion retrieve status flag

    #region SMS - Missed Queue Sending SMS


    public DataTable GetDaoMissedQueueSendingSMS()
    {
        //TemperaryParameterList = new List<OracleParameter>();
        try
        {
            //// Query For Fault Monitoring
            //query = string.Format("select device_alaram_id,device_id,device_fault_code from tmsplaza.device_fault_ln_tnx where device_alaram_id=(select max(device_alaram_id) from tmsplaza.device_fault_ln_tnx)");

            SqlConnection MySqlConnection = new SqlConnection(ConnectionString);

            // SqlCommand MySqlCommand = new SqlCommand("select q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile,c.customer_id from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(queue_datetime as date) = cast(getdate() as date) and queue_status_id=4 and sms_status_flag='M'", MySqlConnection);
            SqlCommand MySqlCommand = new SqlCommand("select q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile,c.customer_id from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(queue_datetime as date) = cast(getdate() as date) and queue_status_id=4 and message_status_flag='M'", MySqlConnection);
            //MySqlCommand.Parameters.AddWithValue("@department_id", queueview.DepartmentID);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();

            DataTable MyQueueNO = new DataTable();

            MyQueueNO.Load(dr);

            MySqlConnection.Close();

            return MyQueueNO;
        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Data From DataBase", exmsg);
        }
        // Executing Select Query 
        //return smsdbconnection.ExecuteSelectQuery(query, TemperaryParameterList);
    }

    #endregion SMS - Missed Queue Sending SMS

    // SMS - Missed Queue Sent SMS

    #region SMS - Missed Queue Sent SMS

    public DataTable GetDaoMissedQueueSentSMS(RTBEL smsview)
    {
        SqlConnection con = new SqlConnection(ConnectionString);
        con.Open();
        string sql = "update tbl_queue_tnx set sms_status_flag=@smsstatusflag where queue_tnx_id=@queuetnxid";

        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@smsstatusflag", smsview.SMSStatusFlag);
        cmd.Parameters.AddWithValue("@queuetnxid", smsview.QueueTransaction);

        SqlDataReader dr = cmd.ExecuteReader();

        DataTable MyMissedQueueNO = new DataTable();

        MyMissedQueueNO.Load(dr);
        con.Close();
        return MyMissedQueueNO;
    }

    #endregion SMS - Missed Queue Sent SMS

    // SMS - Total Waiting Queue

    #region SMS - TotalWaitingQueue
    public DataTable TotalWaitingQueue(int deptid)
    {
        DataTable TotalWaitingQueue = new DataTable();
        DataSet dstwq = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select c.visit_tnx_id as visit_tnx,c.visit_queue_no as queue_no from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @deptid and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1";

            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@deptid", deptid);

            sqlad.SelectCommand = cmd;
            cmd.ExecuteNonQuery();

            sqlad.SelectCommand = cmd;
            sqlad.Fill(dstwq);
            TotalWaitingQueue = dstwq.Tables[0];

            con.Close();
            return TotalWaitingQueue;
        }
        catch
        {
            return TotalWaitingQueue;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion SMS - Total Waiting Queue

    // SMS - Missed Queue

    #region Queue Display - Missed Queue

    public DataTable DaoGetMissedQueue()
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);

        SqlCommand MySqlCommand = new SqlCommand("select v.visit_queue_no_show from tbl_queue_tnx q,tbl_customervisit_tnx v,tbl_terminal_mst t where q.queue_department_id=@department_id and q.queue_status_id=4 and cast(queue_serv_starttime as date) = cast(getdate() as date) and q.queu_visit_tnxid=v.visit_tnx_id and q.queue_terminal_id=t.terminal_id order by q.queue_serv_starttime desc", MySqlConnection);
        //select v.visit_queue_no_show from tbl_queue_tnx q,tbl_customervisit_tnx v,tbl_terminal_mst t where q.queue_department_id=2 and q.queue_status_id=4 and q.queu_visit_tnxid=v.visit_tnx_id and q.queue_terminal_id=t.terminal_id order by q.queue_serv_starttime desc
        //MySqlCommand.Parameters.AddWithValue("@department_id", queueview.DepartmentID);

        MySqlConnection.Open();

        SqlDataReader dr = MySqlCommand.ExecuteReader();

        DataTable MyQueueNO = new DataTable();

        MyQueueNO.Load(dr);

        MySqlConnection.Close();

        return MyQueueNO;

    }
    #endregion Queue Display - MissedQueue

    // SMS - Auto Queue Sending SMS

    #region SMS - Auto Queue Sending SMS


    public DataTable GetDaoAutoQueueSendingSMS()
    {
        //TemperaryParameterList = new List<OracleParameter>();
        try
        {
            //// Query For Fault Monitoring
            //query = string.Format("select device_alaram_id,device_id,device_fault_code from tmsplaza.device_fault_ln_tnx where device_alaram_id=(select max(device_alaram_id) from tmsplaza.device_fault_ln_tnx)");

            SqlConnection MySqlConnection = new SqlConnection(ConnectionString);

            SqlCommand MySqlCommand = new SqlCommand("select q.queue_tnx_id,v.visit_queue_no_show,c.customer_mobile from tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(queue_datetime as date) = cast(getdate() as date) and queue_status_id=1 and sms_status_flag='A'", MySqlConnection);

            //MySqlCommand.Parameters.AddWithValue("@department_id", queueview.DepartmentID);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();

            DataTable MyQueueNO = new DataTable();

            MyQueueNO.Load(dr);

            MySqlConnection.Close();

            return MyQueueNO;
        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Data From DataBase", exmsg);
        }
        // Executing Select Query 
        //return smsdbconnection.ExecuteSelectQuery(query, TemperaryParameterList);
    }

    #endregion SMS - Auto Queue Sending SMS

    // SMS - Missed Queue Sent SMS

    #region SMS - Missed Queue Sent SMS

    public DataTable GetDaoAutoQueueSentSMS(RTBEL smsview)
    {
        SqlConnection con = new SqlConnection(ConnectionString);
        con.Open();
        string sql = "update tbl_queue_tnx set sms_status_flag=@smsstatusflag where queue_tnx_id=@queuetnxid";

        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.AddWithValue("@smsstatusflag", smsview.SMSStatusFlag);
        cmd.Parameters.AddWithValue("@queuetnxid", smsview.QueueTransaction);

        SqlDataReader dr = cmd.ExecuteReader();

        DataTable MyAutoSMS = new DataTable();

        MyAutoSMS.Load(dr);
        con.Close();
        return MyAutoSMS;

    }

    #endregion SMS - Missed Queue Sent SMS

    #region incoming SMS

    public DataTable searchIncomingSMS(RTBEL smsview)
    {
        string dattime = System.DateTime.Now.ToString();
        //insert into tbl_sms_mst(phone_number,incomingsms,incoming_sms_datetime)values(9002476871,'Test Message','2015-04-17 00:00:00')
        // select incomingsms from tbl_sms_mst where CONVERT(DATE, incoming_sms_datetime) = CONVERT(DATE, GETDATE())
        try
        {
            //// Query For Fault Monitoring
            //query = string.Format("select device_alaram_id,device_id,device_fault_code from tmsplaza.device_fault_ln_tnx where device_alaram_id=(select max(device_alaram_id) from tmsplaza.device_fault_ln_tnx)");

            SqlConnection MySqlConnection = new SqlConnection(ConnectionString);

            SqlCommand MySqlCommand = new SqlCommand("select sms_content,sms_phoneno from tbl_sms_tnx where CONVERT(DATE, sms_datetime) = CONVERT(DATE, GETDATE()) and sms_status_flag='I'", MySqlConnection);

            //MySqlCommand.Parameters.AddWithValue("@department_id", queueview.DepartmentID);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();

            DataTable MySms = new DataTable();

            MySms.Load(dr);

            MySqlConnection.Close();

            return MySms;
        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Data From DataBase", exmsg);
        }

    }
    #endregion incoming SMS

    #region retrieve SMS status

    public DataTable serachQueueStatus(RTBEL smsview)
    {
        string dattime = System.DateTime.Now.ToString();
        //insert into tbl_sms_mst(phone_number,incomingsms,incoming_sms_datetime)values(9002476871,'Test Message','2015-04-17 00:00:00')
        // select incomingsms from tbl_sms_mst where CONVERT(DATE, incoming_sms_datetime) = CONVERT(DATE, GETDATE())
        try
        {
            //// Query For Fault Monitoring
            //query = string.Format("select device_alaram_id,device_id,device_fault_code from tmsplaza.device_fault_ln_tnx where device_alaram_id=(select max(device_alaram_id) from tmsplaza.device_fault_ln_tnx)");

            SqlConnection MySqlConnection = new SqlConnection(ConnectionString);

            SqlCommand MySqlCommand = new SqlCommand("select DISTINCT tq.queue_status_id from tbl_queue_tnx tq, tbl_sms_tnx stx,tbl_customervisit_tnx ctv where stx.sms_content=ctv.visit_queue_no_show COLLATE SQL_Latin1_General_CP1_CI_AI and CONVERT(DATE, tq.queue_datetime) = CONVERT(DATE, GETDATE()) and stx.sms_status_flag='I'", MySqlConnection);

            //MySqlCommand.Parameters.AddWithValue("@department_id", queueview.DepartmentID);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();

            DataTable MyQSMSstatus = new DataTable();

            MyQSMSstatus.Load(dr);

            MySqlConnection.Close();

            return MyQSMSstatus;
        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Data From DataBase", exmsg);
        }
    }

    #endregion retrieve SMS status

    #region incoming sms status update

    public DataTable updateincomingsms(RTBEL smsview)
    {
        try
        {
            SqlConnection MySqlConnection = new SqlConnection(ConnectionString);

            SqlCommand MySqlCommand = new SqlCommand("update tbl_incomingsms_mst set status_flag=@IncomingsmsStatus where incomingsms=@MySms and CONVERT(DATE, incoming_sms_datetime) = CONVERT(DATE, GETDATE())", MySqlConnection);

            MySqlCommand.Parameters.AddWithValue("@IncomingsmsStatus", smsview.InsmsStatus);
            MySqlCommand.Parameters.AddWithValue("@MySms", smsview.MySms);

            MySqlConnection.Open();

            SqlDataReader dr = MySqlCommand.ExecuteReader();

            DataTable MyQSMSstatus = new DataTable();

            MyQSMSstatus.Load(dr);

            MySqlConnection.Close();

            return MyQSMSstatus;
        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Data From DataBase", exmsg);
        }
    }

    #endregion incoming sms status update

    //#region queue position retrieve

    //public DataTable selectQueuePosition(RTBEL smsview)
    //{
    //    SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
    //    try
    //    {
    //        MySqlConnection.Open();
    //        // string sql = "select DISTINCT q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and q.sms_status_flag='A'";
    //        // string sql = "select DISTINCT v.visit_queue_no_show from tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and sms_status_flag='N'";
    //        // string sql = "select DISTINCT q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and q.message_status_flag='A'";
    //        //string sql = "select q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c,tbl_appointment_tnx a where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and a.appointment_id=v.customer_appointment_id and q.queue_status_id=1 and q.message_status_flag='A' order by v.consulting_status ASC, v.customer_appointment_time ASC";
    //        string sql = "select c.visit_tnx_id,c.visit_queue_no,c.visit_queue_no_show  from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 and message_status_flag='A' order by c.consulting_status ASC,c.customer_appointment_time ASC";
    //        SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
    //        // MySqlCommand.Parameters.AddWithValue("@Departmentid",smsview.DepartmentID);
    //        SqlDataReader dr = MySqlCommand.ExecuteReader();

    //        DataTable MyQSMSstatus = new DataTable();

    //        MyQSMSstatus.Load(dr);

    //        MySqlConnection.Close();

    //        return MyQSMSstatus;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Error Occured While Retrieving Data From DataBase", ex);

    //    }
    //}
    //#endregion queue position retrieve

    #region SelectQueueStatus123
    public DataTable SelectQueueStatus123(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        MySqlConnection.Open();
        // string sql = "select ctv.visit_queue_no_show from tbl_queue_tnx tq,tbl_customervisit_tnx ctv where tq.queu_visit_tnxid=ctv.visit_tnx_id and queue_department_id=@DeptId and queue_status_id=1 and CONVERT(DATE, queue_datetime) = CONVERT(DATE, GETDATE()) order by ctv.consulting_status ASC, ctv.customer_appointment_time asc";
        string sql = "select c.visit_queue_no_show from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @DeptId and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 order by c.consulting_status ASC,c.customer_appointment_time ASC";

        SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
        MySqlCommand.Parameters.AddWithValue("@DeptId", smsview.DepartmentId);
        SqlDataReader dr = MySqlCommand.ExecuteReader();
        DataTable MyDeptid = new DataTable();
        MyDeptid.Load(dr);
        MySqlConnection.Close();
        return MyDeptid;
    }
    #endregion SelectQueueStatus123

    #region queue position retrieve123

    public DataTable selectQueuePosition123(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            string sql = "select DISTINCT td.department_desc, q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile from tbl_department_mst td, tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and q.queue_department_id=@Departmentid and td.department_id=@Departmentid";
            // string sql = "select DISTINCT v.visit_queue_no_show from tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and sms_status_flag='N'";

            SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
            MySqlCommand.Parameters.AddWithValue("@Departmentid", smsview.DepartmentId);
            SqlDataReader dr = MySqlCommand.ExecuteReader();

            DataTable MyQSMSstatus = new DataTable();

            MyQSMSstatus.Load(dr);

            MySqlConnection.Close();

            return MyQSMSstatus;
        }
        catch (Exception ex)
        {
            MySqlConnection.Close();
            throw new Exception("Error Occured While Retrieving Data From DataBase", ex);

        }
        finally
        {
            MySqlConnection.Close();
        }
    }
    #endregion queue position retrieve

    #region position retrieve by using Queueno
    public DataTable positionretrievebyusingQueueno(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        try
        {
            MySqlConnection.Open();
            // string sql = "select q.queu_visit_tnxid,v.visit_queue_no_show,c.customer_mobile from tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and q.sms_status_flag='N' and queue_department_id=@Departmentid";
            // string sql = "select v.visit_queue_no_show from tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and queue_department_id=@Departmentid";
            string sql = "select tq.queue_department_id from tbl_customervisit_tnx cv,tbl_queue_tnx tq where cv.visit_tnx_id=tq.queu_visit_tnxid and cv.visit_queue_no_show=@MySms and CONVERT(DATE, tq.queue_datetime) = CONVERT(DATE, GETDATE())";
            SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
            MySqlCommand.Parameters.AddWithValue("@MySms", smsview.MySms);
            SqlDataReader dr = MySqlCommand.ExecuteReader();

            DataTable MyQSMSstatus = new DataTable();

            MyQSMSstatus.Load(dr);

            MySqlConnection.Close();

            return MyQSMSstatus;
        }
        catch (Exception ex)
        {
            throw new Exception("Error Occured While Retrieving Data From DataBase", ex);

        }
    }
    #endregion position retrieve by using Queueno

    #region retrieve name
    public DataTable retrieveNameByCustID(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        MySqlConnection.Open();
        string sql = "select DISTINCT members_firstname,members_lastname,cd.members_mobile,cd.members_email from tbl_customer_dtl cd,tbl_customervisit_tnx tcv,tbl_customerreg_mst cr where cd.members_id=@memberid and cd.members_id=tcv.visit_member_id and members_customer_id=@CustID  and cr.customer_id=tcv.visit_customer_id";
        SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
        MySqlCommand.Parameters.AddWithValue("@CustID", smsview.CustId);
        MySqlCommand.Parameters.AddWithValue("@memberid", smsview.MenberId);
        SqlDataReader dr = MySqlCommand.ExecuteReader();
        DataTable MyCustName = new DataTable();
        MyCustName.Load(dr);
        MySqlConnection.Close();
        return MyCustName;
    }
    #endregion retrieve name

    #region insert new sms
    public string InsertNewSMS(RTBEL smsview)
    {
        SqlConnection MysqlConnection = new SqlConnection(ConnectionString);
        try
        {

            string sql = "if not exists(select * from tbl_sms_tnx where sms_cust_id=@sms_cust_id and sms_phoneno=@sms_phoneno and sms_queueno=@QueueNo and sms_content=@sms_content and sms_status_flag=@sms_status_flag  )insert into tbl_sms_tnx(sms_visit_tnxid,sms_cust_id, sms_datetime,sms_phoneno,sms_status_flag,sms_content,sms_queueno)values(@sms_visit_tnxid,@sms_cust_id,@sms_datetime,@sms_phoneno,@sms_status_flag,@sms_content,@QueueNo)";
            cmd = new SqlCommand(sql, MysqlConnection);
            cmd.Parameters.AddWithValue("@sms_visit_tnxid", smsview.QueueTransaction);
            cmd.Parameters.AddWithValue("@sms_cust_id", smsview.CustId);
            cmd.Parameters.AddWithValue("@sms_datetime", smsview.SMSDateTime);
            cmd.Parameters.AddWithValue("@sms_phoneno", smsview.PnoneNo);
            cmd.Parameters.AddWithValue("@sms_status_flag", smsview.IncomingsmsFlag);
            cmd.Parameters.AddWithValue("@sms_content", smsview.MySms);
            cmd.Parameters.AddWithValue("@QueueNo", smsview.QueueNo);
            // cmd.Parameters.AddWithValue("@sms_delivery_status", smsview.DeliveryReport);
            // DataTable dt3 = new DataTable();
            MysqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return Convert.ToString(i);
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion insert new sms

    #region insert Alert sms
    public string InsertAlertSMS(RTBEL smsview)
    {
        SqlConnection MysqlConnection = new SqlConnection(ConnectionString);
        try
        {

            string sql = "if not exists(select * from tbl_sms_tnx where sms_cust_id=@sms_cust_id and sms_phoneno=@sms_phoneno and sms_queueno=@QueueNo and sms_content=@sms_content and sms_status_flag=@sms_status_flag  )insert into tbl_sms_tnx(sms_visit_tnxid,sms_cust_id, sms_datetime,sms_phoneno,sms_status_flag,sms_content,sms_queueno)values(@sms_visit_tnxid,@sms_cust_id,@sms_datetime,@sms_phoneno,@sms_status_flag,@sms_content,@QueueNo)";
            cmd = new SqlCommand(sql, MysqlConnection);
            cmd.Parameters.AddWithValue("@sms_visit_tnxid", smsview.QueueTransaction);
            cmd.Parameters.AddWithValue("@sms_cust_id", smsview.CustId);
            cmd.Parameters.AddWithValue("@sms_datetime", smsview.SMSDateTime);
            cmd.Parameters.AddWithValue("@sms_phoneno", smsview.PnoneNo);
            cmd.Parameters.AddWithValue("@sms_status_flag", smsview.IncomingsmsFlag);
            cmd.Parameters.AddWithValue("@sms_content", smsview.MySms);
            cmd.Parameters.AddWithValue("@QueueNo", smsview.QueueNo);
            // cmd.Parameters.AddWithValue("@sms_delivery_status", smsview.DeliveryReport);
            // DataTable dt3 = new DataTable();
            MysqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return Convert.ToString(i);
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion insert Alert sms

    #region insert MissedQ sms
    public string InsertMissedQSMS(RTBEL smsview)
    {
        SqlConnection MysqlConnection = new SqlConnection(ConnectionString);
        try
        {

            string sql = "if not exists(select * from tbl_sms_tnx where sms_cust_id=@sms_cust_id and sms_phoneno=@sms_phoneno and sms_queueno=@QueueNo and sms_content=@sms_content and sms_status_flag=@sms_status_flag  )insert into tbl_sms_tnx(sms_visit_tnxid,sms_cust_id, sms_datetime,sms_phoneno,sms_status_flag,sms_content,sms_queueno)values(@sms_visit_tnxid,@sms_cust_id,@sms_datetime,@sms_phoneno,@sms_status_flag,@sms_content,@QueueNo)";
            cmd = new SqlCommand(sql, MysqlConnection);
            cmd.Parameters.AddWithValue("@sms_visit_tnxid", smsview.QueueTransaction);
            cmd.Parameters.AddWithValue("@sms_cust_id", smsview.CustId);
            cmd.Parameters.AddWithValue("@sms_datetime", smsview.SMSDateTime);
            cmd.Parameters.AddWithValue("@sms_phoneno", smsview.PnoneNo);
            cmd.Parameters.AddWithValue("@sms_status_flag", smsview.IncomingsmsFlag);
            cmd.Parameters.AddWithValue("@sms_content", smsview.MySms);
            cmd.Parameters.AddWithValue("@QueueNo", smsview.QueueNo);
            // cmd.Parameters.AddWithValue("@sms_delivery_status", smsview.DeliveryReport);
            // DataTable dt3 = new DataTable();
            MysqlConnection.Open();
            int i = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return Convert.ToString(i);
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion insert MissedQ sms

    //#region retrieve visit tnxid by using replied sms
    //public DataTable retrievevisittnxidbyusingrepliedsms(RTBEL smsview)
    //{
    //    SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
    //    MySqlConnection.Open();
    //    string sql = "select visit_tnx_id from tbl_customervisit_tnx where visit_queue_no_show=@InSMS and CONVERT(DATE, visit_datetime) = CONVERT(DATE, GETDATE())";
    //    SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
    //    MySqlCommand.Parameters.AddWithValue("@InSMS", smsview.MySms);
    //    SqlDataReader dr = MySqlCommand.ExecuteReader();
    //    DataTable MyCustName = new DataTable();
    //    MyCustName.Load(dr);
    //    MySqlConnection.Close();
    //    return MyCustName;
    //}
    //#endregion  retrieve visit tnxid by using replied sms

    #region Retrieve Department id
    public DataTable selectDeptId(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        MySqlConnection.Open();
        string sql = "select queue_department_id from tbl_queue_tnx where queu_visit_tnxid=@TnxId";
        SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
        MySqlCommand.Parameters.AddWithValue("@TnxId", smsview.QueueTransaction);
        SqlDataReader dr = MySqlCommand.ExecuteReader();
        DataTable MyDeptid = new DataTable();
        MyDeptid.Load(dr);
        MySqlConnection.Close();
        return MyDeptid;
    }
    #endregion Retrieve Department id

    #region SelectQueueStatus
    public DataTable SelectQueueStatus(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        MySqlConnection.Open();
        // string sql = "select ctv.visit_queue_no_show from tbl_queue_tnx tq,tbl_customervisit_tnx ctv where tq.queu_visit_tnxid=ctv.visit_tnx_id and queue_department_id=@DeptId and queue_status_id=1 and CONVERT(DATE, queue_datetime) = CONVERT(DATE, GETDATE()) and message_status_flag='A'";
        //string sql = "select ctv.visit_queue_no_show from tbl_queue_tnx tq,tbl_customervisit_tnx ctv where tq.queu_visit_tnxid=ctv.visit_tnx_id and queue_department_id=@DeptId and queue_status_id=1 and CONVERT(DATE, queue_datetime) = CONVERT(DATE, GETDATE()) and message_status_flag='A' order by ctv.consulting_status ASC, ctv.customer_appointment_time asc";
        // string sql = "select c.visit_tnx_id,c.visit_queue_no,c.visit_queue_no_show from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @DeptId and message_status_flag='A' and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 order by c.consulting_status ASC,c.customer_appointment_time ASC";
        string sql = "select c.visit_tnx_id,c.visit_queue_no,c.visit_queue_no_show  from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queue_department_id = @DeptId and q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 order by c.consulting_status ASC,c.customer_appointment_time ASC";
        SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
        MySqlCommand.Parameters.AddWithValue("@DeptId", smsview.DepartmentId);
        SqlDataReader dr = MySqlCommand.ExecuteReader();
        DataTable MyDeptid = new DataTable();
        MyDeptid.Load(dr);
        MySqlConnection.Close();
        return MyDeptid;
    }
    #endregion SelectQueueStatus

    #region SelectCustIDByUsingQueueno

    public DataTable SelectCustIDByUsingQueueno(RTBEL smsview)
    {
        SqlConnection MysqlConnection = new SqlConnection(ConnectionString);
        MysqlConnection.Open();
        string sql = "select tcv.visit_customer_id,cd.members_id from tbl_customervisit_tnx tcv, tbl_customer_dtl cd where tcv.visit_queue_no_show=@Mysms and CONVERT(DATE, tcv.visit_datetime) = CONVERT(DATE, GETDATE()) and tcv.visit_member_id=cd.members_id";
        SqlCommand MyCommand = new SqlCommand(sql, MysqlConnection);
        MyCommand.Parameters.AddWithValue("@Mysms", smsview.MySms);
        SqlDataReader dr = MyCommand.ExecuteReader();
        DataTable dt = new DataTable();
        dt.Load(dr);
        MysqlConnection.Close();
        return dt;
    }

    #endregion SelectCustIDByUsingQueueno

    #region insert Reply sms
    public string InsertReplySMS(RTBEL smsview)
    {
        SqlConnection MysqlConnection = new SqlConnection(ConnectionString);
        try
        {
            MysqlConnection.Open();
            string sql = "insert into tbl_sms_tnx(sms_visit_tnxid,sms_cust_id, sms_datetime,sms_phoneno,sms_status_flag,sms_content,sms_queueno)values(@sms_visit_tnxid,@sms_cust_id,@sms_datetime,@sms_phoneno,@sms_status_flag,@sms_content,@QueueNo)";
            cmd = new SqlCommand(sql, MysqlConnection);
            cmd.Parameters.AddWithValue("@sms_visit_tnxid", smsview.QueueTransaction);
            cmd.Parameters.AddWithValue("@sms_cust_id", smsview.CustId);
            cmd.Parameters.AddWithValue("@sms_datetime", smsview.SMSDateTime);
            cmd.Parameters.AddWithValue("@sms_phoneno", smsview.PnoneNo);
            cmd.Parameters.AddWithValue("@sms_status_flag", smsview.SMSStatusFlag);
            cmd.Parameters.AddWithValue("@sms_content", smsview.MySms);
            cmd.Parameters.AddWithValue("@QueueNo", smsview.QueueNo);
            //  cmd.Parameters.AddWithValue("@SmsDeliveryStatus", smsview.DeliveryReport);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            string insert = Convert.ToString(1);
            return insert;
        }
        catch (Exception)
        {

            throw;
        }
    }
    #endregion insert Reply sms

    #region retrieve name and mobileno
    public DataTable retrieveNamemobilenoByCustID(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        MySqlConnection.Open();
        string sql = "select cr.customer_firstname,cr.customer_lastname,cd.members_mobile from tbl_customerreg_mst cr,tbl_customer_dtl cd where cr.customer_id=cd.members_customer_id and cr.customer_id=@CustID and cd.members_id=@members";
        SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
        MySqlCommand.Parameters.AddWithValue("@CustID", smsview.CustId);
        MySqlCommand.Parameters.AddWithValue("@members", smsview.MenberId);
        SqlDataReader dr = MySqlCommand.ExecuteReader();
        DataTable MyCustName = new DataTable();
        MyCustName.Load(dr);
        MySqlConnection.Close();
        return MyCustName;
    }
    #endregion retrieve name and mobileno

    #region get CustID
    public DataTable retCustID(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        MySqlConnection.Open();
        string sql = "select DISTINCT tv.visit_customer_id,td.members_id from tbl_customer_dtl td, tbl_customervisit_tnx tv where cast(tv.visit_datetime as date) = cast(getdate() as date) and tv.visit_member_id=td.members_id and tv.visit_queue_no_show=@QueueNo";
        SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
        MySqlCommand.Parameters.AddWithValue("@QueueNo", smsview.QueueNo);
        SqlDataReader dr = MySqlCommand.ExecuteReader();
        DataTable MyCustName = new DataTable();
        MyCustName.Load(dr);
        MySqlConnection.Close();
        return MyCustName;
    }
    #endregion Get CustID


    #region Alert Message Confirmation
    public DataTable getAlertMessageExistance(RTBEL smsview)
    {
        SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
        MySqlConnection.Open();
        string sql = "select * from tbl_sms_tnx where sms_visit_tnxid=@QueueTransactionID and sms_status_flag='A' and cast(sms_datetime as date) = cast(getdate() as date)";
        SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
      MySqlCommand.Parameters.AddWithValue("@QueueTransactionID", smsview.QueueTransaction);
        SqlDataReader dr = MySqlCommand.ExecuteReader();
        DataTable MyCustName = new DataTable();
        MyCustName.Load(dr);
        MySqlConnection.Close();
        return MyCustName;
    }
    #endregion Alert Message Confirmation


    //#region retrieve visit tnxid by using replied sms
    //public DataTable retrievevisittnxidbyusingrepliedsms(RTBEL smsview)
    //{
    //    SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
    //    MySqlConnection.Open();
    //    string sql = "select visit_tnx_id from tbl_customervisit_tnx where visit_queue_no_show=@InSMS and CONVERT(DATE, visit_datetime) = CONVERT(DATE, GETDATE())";
    //    SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
    //    MySqlCommand.Parameters.AddWithValue("@InSMS", smsview.MySms);
    //    SqlDataReader dr = MySqlCommand.ExecuteReader();
    //    DataTable MyCustName = new DataTable();
    //    MyCustName.Load(dr);
    //    MySqlConnection.Close();
    //    return MyCustName;
    //}
    //#endregion  retrieve visit tnxid by using replied sms

    //#region queue position retrieve

    //public DataTable selectQueuePosition(RTBEL smsview)
    //{
    //    SqlConnection MySqlConnection = new SqlConnection(ConnectionString);
    //    try
    //    {
    //        MySqlConnection.Open();
    //        // string sql = "select DISTINCT q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and q.sms_status_flag='A'";
    //        // string sql = "select DISTINCT v.visit_queue_no_show from tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and sms_status_flag='N'";
    //        // string sql = "select DISTINCT q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and q.queue_status_id=1 and q.message_status_flag='A'";
    //        //string sql = "select q.queu_visit_tnxid,v.visit_queue_no_show,tc.members_mobile from tbl_customer_dtl tc, tbl_customervisit_tnx v,tbl_queue_tnx q,tbl_customerreg_mst c,tbl_appointment_tnx a where v.visit_member_id=tc.members_id and v.visit_tnx_id=q.queu_visit_tnxid and c.customer_id=v.visit_customer_id and cast(q.queue_datetime as date) = cast(getdate() as date) and a.appointment_id=v.customer_appointment_id and q.queue_status_id=1 and q.message_status_flag='A' order by v.consulting_status ASC, v.customer_appointment_time ASC";
    //        string sql = "select c.visit_tnx_id,c.visit_queue_no,c.visit_queue_no_show  from tbl_queue_tnx q,tbl_customervisit_tnx c where q.queu_visit_tnxid = c.visit_tnx_id and CONVERT(DATE, q.queue_datetime) = CONVERT(DATE, GETDATE())and q.queue_status_id = 1 and message_status_flag='A' order by c.consulting_status ASC,c.customer_appointment_time ASC";
    //        SqlCommand MySqlCommand = new SqlCommand(sql, MySqlConnection);
    //        // MySqlCommand.Parameters.AddWithValue("@Departmentid",smsview.DepartmentID);
    //        SqlDataReader dr = MySqlCommand.ExecuteReader();

    //        DataTable MyQSMSstatus = new DataTable();

    //        MyQSMSstatus.Load(dr);

    //        MySqlConnection.Close();

    //        return MyQSMSstatus;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Error Occured While Retrieving Data From DataBase", ex);

    //    }
    //}
    //#endregion queue position retrieve
}