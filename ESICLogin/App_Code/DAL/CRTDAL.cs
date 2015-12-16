using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
/// <summary>
/// Summary description for CRTDAL
/// </summary>
public class CRTDAL
{
    string ConnectionString;
    string Decryption;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter sqlad;
    SqlDataReader sqlrd;

    string QueueStatus;

    DataTable MyAvailableUserName = new DataTable();
    DataTable MyAvailableQueueStatus = new DataTable();

    //#region ENCRYPTED DATA - CONNECTION STRING

    //private string Encryptdata(string password)
    //{
    //    string strmsg = string.Empty;
    //    byte[] encode = new byte[password.Length];
    //    encode = Encoding.UTF8.GetBytes(password);
    //    strmsg = Convert.ToBase64String(encode);
    //    return strmsg;
    //}

    //#endregion ENCRYPTED DATA - CONNECTION STRING

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


    public CRTDAL()
	{
        Decryption = ConfigurationManager.AppSettings["LocalConnection"].ToString();

        //Encryptdata(ConnectionString);
        // cmd = new SqlCommand();

        sqlad = new SqlDataAdapter();

        ConnectionString = Decryptdata(Decryption);

	}

    #region SearchDepartmentDetails
    public DataTable SearchDepartmentDetails()
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "SELECT department_id,department_desc FROM [tbl_department_mst] ORDER BY department_desc ASC";
            string sql = "SELECT distinct department_id,department_desc FROM [tbl_department_mst],tbl_terminal_mst where department_id=terminal_dept_id and terminal_type_id in (2,6) ORDER BY department_desc ASC";
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

    #region SearchDepartmentDetailsforSchedule
    public DataTable SearchDepartmentDetailsSchedule()
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT UPPER(LEFT(tbl_department_mst.department_desc, 5)) FROM tbl_department_mst INNER JOIN tbl_schedule_tnx ON tbl_schedule_tnx.schedule_dept_id = tbl_department_mst.department_id";
            //string sql = "SELECT department_desc FROM [tbl_department_mst] ORDER BY department_desc ASC";
            //string sql = "SELECT distinct department_id,department_desc FROM [tbl_department_mst],tbl_terminal_mst where department_id=terminal_dept_id and terminal_type_id in (2,6) ORDER BY department_desc ASC";
            //string sql = "Select department_desc from tbl_department_mst,tbl_schedule_tnx where schedule_day=1 and schedule_week=1 and schedule_id=1 and schedule_dept_id=department_id and schedule_session=1 and schedule_start_time='2015-09-09 00:00:00.000' and schedule_end_time='2015-09-07 12:00:00.000'";
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

    #region CompareDepartmentDetailsforSchedule
    //int session1 = 1;
    //string room_code = "A1";
    //string scheduledate = "";
    public DataTable CompareDepartdetailsSchedule(DateTime scheduledate, int session1,int room_code)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            CRTBEL crtbel=new CRTBEL();
            
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "Select department_desc from tbl_schedule_tnx,tbl_department_mst where schedule_room_id=@room_code and schedule_session=@session1 and schedule_start_time=@scheduledate";
            string sql = "Select d.department_desc,s.schedule_id from tbl_schedule_tnx s,tbl_department_mst d where s.schedule_room_code=@room_code and s.schedule_session=@session1 and s.schedule_dept_id=d.department_id and schedule_start_time=@scheduledate ";
            //string sql = "SELECT distinct department_id,department_desc FROM [tbl_department_mst],tbl_terminal_mst where department_id=terminal_dept_id and terminal_type_id in (2,6) ORDER BY department_desc ASC";
            //string sql = "Select department_desc from tbl_department_mst,tbl_schedule_tnx where schedule_day=1 and schedule_week=1 and schedule_id=1 and schedule_dept_id=department_id and schedule_session=1 and schedule_start_time='2015-09-09 00:00:00.000' and schedule_end_time='2015-09-07 12:00:00.000'";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@room_code", room_code);
            cmd.Parameters.AddWithValue("@scheduledate",scheduledate);
            cmd.Parameters.AddWithValue("@session1",session1);
          
          
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

    #region A1M2CompareDepartmentDetailsforSchedule
    //int session1 = 1;
    //string room_code = "A1";
    //string scheduledate = "";
    public DataTable A1M2CompareDepartdetailsSchedule(DateTime scheduledate, int session1, int room_code1)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            CRTBEL crtbel = new CRTBEL();
            scheduledate = scheduledate.Date;
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "Select department_desc from tbl_schedule_tnx,tbl_department_mst where schedule_room_id=@room_code and schedule_session=@session1 and schedule_start_time=@scheduledate";
            string sql = "Select d.department_desc,s.schedule_id from tbl_schedule_tnx s,tbl_department_mst d where s.schedule_room_id=@room_code and s.schedule_session=@session1 and s.schedule_dept_id=d.department_id and cast(schedule_start_time as date)=@scheduledate";
            //string sql = "SELECT distinct department_id,department_desc FROM [tbl_department_mst],tbl_terminal_mst where department_id=terminal_dept_id and terminal_type_id in (2,6) ORDER BY department_desc ASC";
            //string sql = "Select department_desc from tbl_department_mst,tbl_schedule_tnx where schedule_day=1 and schedule_week=1 and schedule_id=1 and schedule_dept_id=department_id and schedule_session=1 and schedule_start_time='2015-09-09 00:00:00.000' and schedule_end_time='2015-09-07 12:00:00.000'";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@room_code", room_code1);
            cmd.Parameters.AddWithValue("@session1", session1);
            cmd.Parameters.AddWithValue("@scheduledate", scheduledate);
            

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

    #region A1T1CompareDepartmentDetailsforSchedule
    //int session1 = 1;
    //string room_code = "A1";
    //string scheduledate = "";
    public DataTable A1T1CompareDepartdetailsSchedule(DateTime scheduledate, int session1, int room_code2)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            CRTBEL crtbel = new CRTBEL();

            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "Select department_desc from tbl_schedule_tnx,tbl_department_mst where schedule_room_id=@room_code and schedule_session=@session1 and schedule_start_time=@scheduledate";
            string sql = "Select d.department_desc,s.schedule_id from tbl_schedule_tnx s,tbl_department_mst d where s.schedule_room_code=@room_code and s.schedule_session=@session1 and s.schedule_dept_id=d.department_id and schedule_start_time=@scheduledate ";
            //string sql = "SELECT distinct department_id,department_desc FROM [tbl_department_mst],tbl_terminal_mst where department_id=terminal_dept_id and terminal_type_id in (2,6) ORDER BY department_desc ASC";
            //string sql = "Select department_desc from tbl_department_mst,tbl_schedule_tnx where schedule_day=1 and schedule_week=1 and schedule_id=1 and schedule_dept_id=department_id and schedule_session=1 and schedule_start_time='2015-09-09 00:00:00.000' and schedule_end_time='2015-09-07 12:00:00.000'";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@room_code", room_code2);
            cmd.Parameters.AddWithValue("@scheduledate", scheduledate);
            cmd.Parameters.AddWithValue("@session1", session1);


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

    #region A1T2CompareDepartmentDetailsforSchedule
    //int session1 = 1;
    //string room_code = "A1";
    //string scheduledate = "";
    public DataTable A1T2CompareDepartdetailsSchedule(DateTime scheduledate, int session1, int room_code3)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            CRTBEL crtbel = new CRTBEL();

            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "Select department_desc from tbl_schedule_tnx,tbl_department_mst where schedule_room_id=@room_code and schedule_session=@session1 and schedule_start_time=@scheduledate";
            string sql = "Select d.department_desc,s.schedule_id from tbl_schedule_tnx s,tbl_department_mst d where s.schedule_room_code=@room_code and s.schedule_session=@session1 and s.schedule_dept_id=d.department_id and schedule_start_time=@scheduledate ";
            //string sql = "SELECT distinct department_id,department_desc FROM [tbl_department_mst],tbl_terminal_mst where department_id=terminal_dept_id and terminal_type_id in (2,6) ORDER BY department_desc ASC";
            //string sql = "Select department_desc from tbl_department_mst,tbl_schedule_tnx where schedule_day=1 and schedule_week=1 and schedule_id=1 and schedule_dept_id=department_id and schedule_session=1 and schedule_start_time='2015-09-09 00:00:00.000' and schedule_end_time='2015-09-07 12:00:00.000'";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@room_code", room_code3);
            cmd.Parameters.AddWithValue("@scheduledate", scheduledate);
            cmd.Parameters.AddWithValue("@session1", session1);


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

    #region A1W1CompareDepartmentDetailsforSchedule
    //int session1 = 1;
    //string room_code = "A1";
    //string scheduledate = "";
    public DataTable A1W1CompareDepartdetailsSchedule(DateTime scheduledate, int session1, int room_code4)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            CRTBEL crtbel = new CRTBEL();

            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "Select department_desc from tbl_schedule_tnx,tbl_department_mst where schedule_room_id=@room_code and schedule_session=@session1 and schedule_start_time=@scheduledate";
            string sql = "Select d.department_desc,s.schedule_id from tbl_schedule_tnx s,tbl_department_mst d where s.schedule_room_code=@room_code and s.schedule_session=@session1 and s.schedule_dept_id=d.department_id and schedule_start_time=@scheduledate ";
            //string sql = "SELECT distinct department_id,department_desc FROM [tbl_department_mst],tbl_terminal_mst where department_id=terminal_dept_id and terminal_type_id in (2,6) ORDER BY department_desc ASC";
            //string sql = "Select department_desc from tbl_department_mst,tbl_schedule_tnx where schedule_day=1 and schedule_week=1 and schedule_id=1 and schedule_dept_id=department_id and schedule_session=1 and schedule_start_time='2015-09-09 00:00:00.000' and schedule_end_time='2015-09-07 12:00:00.000'";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@room_code", room_code4);
            cmd.Parameters.AddWithValue("@scheduledate", scheduledate);
            cmd.Parameters.AddWithValue("@session1", session1);


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

    #region SearchRegCustomerDetailUsingESICNo
    public DataTable SearchRegCustomerDetail(string esicno)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT * FROM [tbl_customerreg_mst] where customer_id = @esicno";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@esicno",Convert.ToInt64(esicno));
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

    #region SearchRegCustomerDetailUsingESICNo
    public DataTable SearchRegCustomerDetail1(string surname)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT * FROM [tbl_customerreg_mst] where customer_lastname = @surname";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@surname", Convert.ToString(surname));
            //cmd.Parameters.AddWithValue("@sdob", Convert.ToDateTime(sdob));
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

    #region InsertRegCustomerDetail
    public string InsertRegCustomerDetail(CRTBEL crtview)
    {
       // DataTable datatbl = new DataTable();
      //  DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customerreg_mst (customer_id,customer_firstname,customer_lastname,customer_dob,customer_address,customer_mobile,customer_email,customer_gender,customer_age,updated_datetime,updated_by)" +
                     "values(@ESCInNumber, @CusFirstname, @CusLastName, @dob, @CusAddress, @CusPhoneNo,@Email, @CusGender, @CusAge, @datetime, @TerminalUser)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ESCInNumber",crtview.ESCInNumber);
            cmd.Parameters.AddWithValue("@CusFirstname",crtview.CusFirstname);
            cmd.Parameters.AddWithValue("@CusLastName",crtview.CusLastName);
            cmd.Parameters.AddWithValue("@dob", crtview.Dob);
            cmd.Parameters.AddWithValue("@CusAddress",crtview.CusAddress);
            cmd.Parameters.AddWithValue("@CusPhoneNo",crtview.CusPhoneNo);
            cmd.Parameters.AddWithValue("@Email",crtview.Email);
            cmd.Parameters.AddWithValue("@CusGender",crtview.CusGender);
            cmd.Parameters.AddWithValue("@CusAge",crtview.CusAge);
            cmd.Parameters.AddWithValue("@datetime",DateTime.Now);
            cmd.Parameters.AddWithValue("@TerminalUser",crtview.TerminalUser);
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

    #region SearchMemberDetail
    public DataTable SearchMemberDetail(string esicno)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT cus.*,rel.relation_desc,rel.relation_id FROM tbl_customer_dtl cus,tbl_relation_mst rel where cus.members_customer_id = @esicno and cus.members_relation_id = rel.relation_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@esicno", Convert.ToInt64(esicno));
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

    #region SearchRelationDetail
    public DataTable SearchRelationDetail()
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT relation_id,relation_desc FROM tbl_relation_mst";
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

    #region InsertMemberDetail
    public string InsertMemberDetail(CRTBEL crtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customer_dtl (members_firstname,members_lastname,members_reg_datetime,members_gender,members_age,members_relation_id,members_customer_id,members_mobile,members_email,updated_datetime,updated_by,members_dob)" +
                     "values(@CusFirstname, @CusLastName, @Cusregupdateddate,@CusGender, @CusAge,@Cusrelationid,@ESCInNumber,@mobile,@Email, @datetime, @Updatedby,@dob)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@CusFirstname", crtview.CusFirstname);
            cmd.Parameters.AddWithValue("@CusLastName", crtview.CusLastName);
            cmd.Parameters.AddWithValue("@Cusregupdateddate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CusGender", crtview.CusGender);
            cmd.Parameters.AddWithValue("@CusAge", crtview.CusAge);
            cmd.Parameters.AddWithValue("@Cusrelationid", crtview.RelationId);
            cmd.Parameters.AddWithValue("@ESCInNumber", crtview.ESCInNumber);
            cmd.Parameters.AddWithValue("@mobile",crtview.CusPhoneNo);
            cmd.Parameters.AddWithValue("@Email",crtview.Email);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Updatedby", crtview.TerminalUser);
            cmd.Parameters.AddWithValue("@dob", crtview.Dob);
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

    #region UpdateRegCustomerDetail
    public string UpdateRegCustomerDetail(CRTBEL crtview)
    {
        // DataTable datatbl = new DataTable();
        //  DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
          
            string sql = "update tbl_customerreg_mst set customer_firstname=@CusFirstname,customer_lastname=@CusLastName,customer_address=@CusAddress,customer_mobile=@CusPhoneNo,"+
            "customer_gender=@CusGender,customer_age=@CusAge,updated_datetime=@datetime,updated_by=@TerminalUser,customer_dob=@dob,customer_email=@Email where customer_id=@ESCInNumber";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ESCInNumber", crtview.ESCInNumber);
            cmd.Parameters.AddWithValue("@CusFirstname", crtview.CusFirstname);
            cmd.Parameters.AddWithValue("@CusLastName", crtview.CusLastName);
            cmd.Parameters.AddWithValue("@CusAddress", crtview.CusAddress);
            cmd.Parameters.AddWithValue("@CusPhoneNo", crtview.CusPhoneNo);
            cmd.Parameters.AddWithValue("@CusGender", crtview.CusGender);
            cmd.Parameters.AddWithValue("@CusAge", crtview.CusAge);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@TerminalUser", crtview.TerminalUser);
            cmd.Parameters.AddWithValue("@dob", crtview.Dob);
            cmd.Parameters.AddWithValue("@Email", crtview.Email);
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

    #region UpdateSelfCustomer
    public string UpdateSelfCustomer(CRTBEL crtview)
    {
        // DataTable datatbl = new DataTable();
        //  DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();

            string sql = "update tbl_customer_dtl set members_firstname=@CusFirstname,members_lastname=@CusLastName," +
            "members_gender=@CusGender,members_age=@CusAge,members_dob=@dob where members_customer_id=@ESCInNumber and members_relation_id = 6";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ESCInNumber", crtview.ESCInNumber);
            cmd.Parameters.AddWithValue("@CusFirstname", crtview.CusFirstname);
            cmd.Parameters.AddWithValue("@CusLastName", crtview.CusLastName);
            cmd.Parameters.AddWithValue("@CusGender", crtview.CusGender);
            cmd.Parameters.AddWithValue("@CusAge", crtview.CusAge);
            cmd.Parameters.AddWithValue("@dob", crtview.Dob);
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


    #region UpdateMemberDetail
    public string UpdateMemberDetail(CRTBEL crtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_customer_dtl set members_firstname=@CusFirstname,members_lastname=@CusLastName," +
            "members_reg_datetime=@Cusregupdateddate,members_gender=@CusGender,members_dob=@CusAge,members_relation_id=@Cusrelationid," +
            "members_customer_id=@ESCInNumber,members_mobile=@mobile,members_email=@email,updated_datetime=@datetime,updated_by=@Updatedby where members_id=@MemberID";
                     
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MemberID", crtview.MemberId);
            cmd.Parameters.AddWithValue("@CusFirstname", crtview.MemberFirstName);
            cmd.Parameters.AddWithValue("@CusLastName", crtview.MemberLastName);
            cmd.Parameters.AddWithValue("@Cusregupdateddate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CusGender", crtview.MemberGender);
            cmd.Parameters.AddWithValue("@CusAge", crtview.Dob);
            cmd.Parameters.AddWithValue("@Cusrelationid", crtview.MemberRelationId);
            cmd.Parameters.AddWithValue("@ESCInNumber", crtview.ESCInNumber);
            cmd.Parameters.AddWithValue("@mobile", crtview.CusPhoneNo);
            cmd.Parameters.AddWithValue("@email",crtview.Email);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Updatedby", crtview.TerminalUser);
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
    #region UpdateMemberDetail
    public string UpdateMemberDetail1(CRTBEL crtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_customer_dtl set members_firstname=@CusFirstname,members_lastname=@CusLastName," +
            "members_gender=@CusGender,members_dob=@dob,members_mobile=@CusPhoneNo," +
            "members_email=@email,updated_datetime=@datetime where members_customer_id=@ESCInNumber";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ESCInNumber", crtview.ESCInNumber);
            cmd.Parameters.AddWithValue("@CusFirstname", crtview.CusFirstname);
            cmd.Parameters.AddWithValue("@CusLastName", crtview.CusLastName);
           // cmd.Parameters.AddWithValue("@CusAddress", crtview.CusAddress);
            cmd.Parameters.AddWithValue("@CusPhoneNo", crtview.CusPhoneNo);
            cmd.Parameters.AddWithValue("@CusGender", crtview.CusGender);
           // cmd.Parameters.AddWithValue("@CusAge", crtview.CusAge);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
           // cmd.Parameters.AddWithValue("@TerminalUser", crtview.TerminalUser);
            cmd.Parameters.AddWithValue("@dob", crtview.Dob);
            cmd.Parameters.AddWithValue("@Email", crtview.Email);
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


    #region InsertMemberDetailpat
    public string InsertMemberDetailpat(CRTBEL crtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customer_dtl (members_firstname,members_lastname,members_reg_datetime,members_gender,members_age,members_dob,members_relation_id,members_customer_id,members_mobile,members_email,updated_datetime,updated_by)" +
                     "values(@CusFirstname, @CusLastName, @Cusregupdateddate,@CusGender,@CusAge,@CusDob, @Cusrelationid,@ESCInNumber,@mobile,@email, @datetime, @Updatedby)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@CusFirstname", crtview.MemberFirstName);
            cmd.Parameters.AddWithValue("@CusLastName", crtview.MemberLastName);
            cmd.Parameters.AddWithValue("@Cusregupdateddate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CusGender", crtview.MemberGender);
            cmd.Parameters.AddWithValue("@CusAge", crtview.CusAge);
            cmd.Parameters.AddWithValue("@CusDob",crtview.Dob);
            cmd.Parameters.AddWithValue("@Cusrelationid", crtview.MemberRelationId);
            cmd.Parameters.AddWithValue("@ESCInNumber", crtview.ESCInNumber);
            cmd.Parameters.AddWithValue("@mobile",crtview.CusPhoneNo);
            cmd.Parameters.AddWithValue("@email",crtview.Email);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Updatedby", crtview.TerminalUser);
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


    #region SearchRegMemberInfo
    public DataTable SearchRegMemberInfo(long memberid)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT * FROM [tbl_customer_dtl] where members_id = @memberid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@memberid", memberid);
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

    #region Search Appointment Details
    public DataTable SearchAppointmentDetails(long memberid)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT a.appointment_time,d.department_desc,a.appointment_id FROM tbl_appointment_tnx a,tbl_department_mst d where a.appointment_members_id = @memberid and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@memberid", memberid);
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
    #endregion Search Appointment Details



    #region check count Number
    public DataTable checkcountNumber(CRTBEL crtbel)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT * FROM tbl_customervisit_tnx where CONVERT(DATE,visit_datetime)=@date";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@date",crtbel.DateTime );
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

    #region check count Number
    public DataTable checkcountNumber()
    {
        DataTable datatbl = new DataTable();

        DataSet ds = new DataSet();

        
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select count(*) as cc from tbl_customervisit_tnx where cast(visit_datetime as date) = cast(getdate() as date)";
            cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }

        
        catch
        {
            return null;
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
    public DataTable SearchParticularDepartmentDetails(int deptid)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT * FROM [tbl_department_mst] where department_id=@deptid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@deptid", deptid);
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


    #region UpdateQueueNumber
    public string UpdateQueueNumber(int deptid,int queueno)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_department_mst set department_queueno=@queueno where department_id=@deptid";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@queueno", queueno);
            cmd.Parameters.AddWithValue("@deptid", deptid);
           
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


    #region TotalWaitingQueue
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
    #endregion

    #region InsertCustomerVisitDetails
    public string InsertCustomerVisitDetails(CRTBEL crtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customervisit_tnx (visit_customer_id,visit_customer_name,visit_datetime,visit_queue_no,visit_member_id,visit_queue_no_show,consulting_status)" +
                     "values(@customerid, @customerfullname, @datetime,@queueno, @memberid,@queuenoshow,@consultingstatus)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@customerid", Convert.ToInt64(crtview.ESCInNumber));
            cmd.Parameters.AddWithValue("@customerfullname", crtview.CustomerFullName);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@queueno", crtview.QueueNummber);
            cmd.Parameters.AddWithValue("@memberid", crtview.PatientId);
            cmd.Parameters.AddWithValue("@queuenoshow", crtview.QueueNummberShow);
            cmd.Parameters.AddWithValue("@consultingstatus",crtview.ConsultingStatus);
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

    #region InsertCustomerAppointmentVisitDetails
    public string InsertCustomerAppointmentVisitDetails(CRTBEL crtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customervisit_tnx (visit_customer_id,visit_customer_name,visit_datetime,visit_queue_no,visit_member_id,visit_queue_no_show,consulting_status,customer_appointment_id,customer_appointment_time)" +
                     "values(@customerid, @customerfullname, @datetime,@queueno, @memberid,@queuenoshow,@consultingstatus,@customerappointmentid,@customerappointmenttime)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@customerid", Convert.ToInt64(crtview.ESCInNumber));
            cmd.Parameters.AddWithValue("@customerfullname", crtview.CustomerFullName);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@queueno", crtview.QueueNummber);
            cmd.Parameters.AddWithValue("@memberid", crtview.PatientId);
            cmd.Parameters.AddWithValue("@queuenoshow", crtview.QueueNummberShow);
            cmd.Parameters.AddWithValue("@consultingstatus", crtview.ConsultingStatus);
            cmd.Parameters.AddWithValue("@customerappointmentid", crtview.AppointmentID);
            cmd.Parameters.AddWithValue("@customerappointmenttime", crtview.AppointmentDateTime);
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

    #region SearchLastCustomerVisitID
    public DataTable SearchLastCustomerVisitID()
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT TOP 1 visit_tnx_id FROM tbl_customervisit_tnx ORDER BY visit_tnx_id DESC";
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

    #region InsertCustomerQueueTransactions
    public string InsertCustomerQueueTransactions(CRTBEL crtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_queue_tnx (queu_visit_tnxid,queue_datetime,queue_wait_starttime,queue_user_id,queue_terminal_id,queue_department_id,queue_status_id,queue_order_id,sms_status_flag,message_status_flag)" +
                     "values(@visitid, @datetime, @waitstarttime,@userid, @terminalid,@departmentid,@statusid,@orderid,@smsstatusflag,@message_status_flag)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@visitid", crtview.CusVisitId);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@waitstarttime", DateTime.Now);
            cmd.Parameters.AddWithValue("@userid", crtview.UserId);
            cmd.Parameters.AddWithValue("@terminalid",crtview.TerminalId);
            cmd.Parameters.AddWithValue("@departmentid", crtview.DepartmentId);
            cmd.Parameters.AddWithValue("@statusid", 1);
            cmd.Parameters.AddWithValue("@orderid", crtview.OrderId);
            cmd.Parameters.AddWithValue("@smsstatusflag", crtview.SmsStatusFlag);
            cmd.Parameters.AddWithValue("@message_status_flag",crtview.SmsStatusFlag);
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
    public DataTable SearchLastQueueTransactionID()
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = " SELECT TOP 1 queue_tnx_id FROM tbl_queue_tnx ORDER BY queue_tnx_id DESC";
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

    #region InsertCustomerQueuePlanOrderone
    public string InsertCustomerQueuePlanOrderone(CRTBEL crtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_queueplan_dtl (plan_datetime,plan_visit_id,plan_transfer_id,plan_order_id,plan_department_id,plan_user_id,plan_terminal_id)" +
                     "values(@datetime, @visitid, @transferid,@orderid, @departmentid,@userid,@terminalid)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@datetime",DateTime.Now);
            cmd.Parameters.AddWithValue("@visitid", crtview.CusVisitId);
            cmd.Parameters.AddWithValue("@transferid", crtview.QueueTransID);
            cmd.Parameters.AddWithValue("@orderid", crtview.OrderId);
            cmd.Parameters.AddWithValue("@departmentid", crtview.DepartmentId);
            cmd.Parameters.AddWithValue("@userid", crtview.UserId);
            cmd.Parameters.AddWithValue("@terminalid", crtview.TerminalId);
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

    #region InsertCustomerQueuePlanOrders
    public string InsertCustomerQueuePlanOrders(CRTBEL crtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_queueplan_dtl (plan_datetime,plan_visit_id,plan_order_id,plan_department_id,plan_user_id,plan_terminal_id)" +
                     "values(@datetime, @visitid,@orderid, @departmentid,@userid,@terminalid)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@visitid", crtview.CusVisitId);
            cmd.Parameters.AddWithValue("@orderid", crtview.OrderId);
            cmd.Parameters.AddWithValue("@departmentid", crtview.DepartmentId);
            cmd.Parameters.AddWithValue("@userid", crtview.UserId);
            cmd.Parameters.AddWithValue("@terminalid", crtview.TerminalId);
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

    // CRT - Check Queue Token Already Generated Details

    #region CRT - Check Queue Token Already Generated Details

    public DataTable CheckQueueTokenAlreadyGeneratedDetails(CRTBEL crtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_customervisit_tnx c,tbl_queue_tnx q where c.visit_customer_id=@customerid and q.queu_visit_tnxid = c.visit_tnx_id and c.visit_customer_name=@customername and cast(c.visit_datetime as date) = cast(getdate() as date)and c.visit_member_id=@memberid and q.queue_status_id != 3;";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@customerid", crtview.ESCInNumber);
            cmd.Parameters.AddWithValue("@customername", crtview.CustomerFullName);
            cmd.Parameters.AddWithValue("@memberid", crtview.PatientId);
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
    #endregion CRT - Check Queue Token Already Generated Details
    
    #region CRT - CheckPreviousToken

    public DataTable CheckPreviousToken(CRTBEL crtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_customervisit_tnx where ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@customerid", crtview.ESCInNumber);
            cmd.Parameters.AddWithValue("@customername", crtview.CustomerFullName);
            cmd.Parameters.AddWithValue("@memberid", crtview.PatientId);
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
    #endregion CRT - Check Queue Token Already Generated Details
    
    #region CRT - Reprint Queue Token Already Generated Details

    public DataTable ReprintCheckQueueTokenAlreadyGeneratedDetails(CRTBEL crtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select  c.visit_customer_id as customer_id,c.visit_customer_name as customer_name,COALESCE(cd.members_firstname,cd.members_lastname) as patient,q.queue_department_id as dept,d.department_desc as department_id,c.visit_queue_no as queue_no,c.visit_queue_no_show as queue_show from tbl_customervisit_tnx c,tbl_queue_tnx q,tbl_department_mst d,tbl_customer_dtl cd where c.visit_customer_id=@customerid and q.queu_visit_tnxid = c.visit_tnx_id and q.queue_department_id=d.department_id and c.visit_member_id=cd.members_id and  cast(c.visit_datetime as date) = cast(getdate() as date)and q.queue_status_id != 3;";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@customerid", crtview.ESCInNumber);
           // cmd.Parameters.AddWithValue("@customername", crtview.CustomerFullName);
            //cmd.Parameters.AddWithValue("@memberid", crtview.PatientId);
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
    #endregion CRT - Check Queue Token Already Generated Details

    #region KIOSK- Reprint Queue Token Already Generated Details

    public DataTable KioskReprintCheckQueueTokenAlreadyGeneratedDetails(KioskBEL kioskview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select  c.visit_customer_id as customer_id,c.visit_customer_name as customer_name,COALESCE(cd.members_firstname,cd.members_lastname) as patient,q.queue_department_id as dept,d.department_desc as department_id,c.visit_queue_no as queue_no,c.visit_queue_no_show as queue_show from tbl_customervisit_tnx c,tbl_queue_tnx q,tbl_department_mst d,tbl_customer_dtl cd where c.visit_customer_id=@customerid and q.queu_visit_tnxid = c.visit_tnx_id and q.queue_department_id=d.department_id and c.visit_member_id=cd.members_id and  cast(c.visit_datetime as date) = cast(getdate() as date)and q.queue_status_id != 3;";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@customerid", kioskview.ESCInNumber);
            // cmd.Parameters.AddWithValue("@customername", crtview.CustomerFullName);
            //cmd.Parameters.AddWithValue("@memberid", crtview.PatientId);
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
    #endregion CRT - Check Queue Token Already Generated Details

    // Getting Queue Status - Getting My Queue Number

    #region Getting Queue Status - Getting My Queue Number

    public DataTable GetDALMyQueueNumber(CRTBEL crtqueuestatusbel)
    {
        DataSet MyQueueNumber = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);

            con.Open();

            string sql = "select p.plan_datetime,v.visit_customer_id,v.visit_customer_name,m.members_firstname,r.relation_desc,d.department_desc,p.plan_transfer_id,p.unplan_transfer_id from tbl_customervisit_tnx v,tbl_customer_dtl m,tbl_relation_mst r,tbl_queueplan_dtl p,tbl_department_mst d,tbl_customerreg_mst c where v.visit_queue_no_show=@queue_number and CONVERT(DATE,p.plan_datetime)= @date_time and v.visit_customer_id=c.customer_id and c.customer_id=m.members_customer_id and m.members_relation_id=r.relation_id and v.visit_member_id=m.members_id and v.visit_tnx_id=p.plan_visit_id and p.plan_department_id=d.department_id order by p.plan_order_id";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@queue_number", crtqueuestatusbel.QueueNummberShow);

            cmd.Parameters.AddWithValue("@date_time", crtqueuestatusbel.DateTime);

            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(MyQueueNumber);
            MyAvailableUserName = MyQueueNumber.Tables[0];
            return MyAvailableUserName;

            //SqlCommand MyQueueNumber = new SqlCommand("select p.plan_order_id,p.plan_datetime,v.visit_customer_id,v.visit_customer_name,m.members_firstname,r.relation_desc,d.department_desc,p.plan_transfer_id from tbl_customervisit_tnx v,tbl_customer_dtl m,tbl_relation_mst r,tbl_queueplan_dtl p,tbl_department_mst d,tbl_customerreg_mst c where v.visit_queue_no=@queue_number and CONVERT(DATE,p.plan_datetime)= @date_time and v.visit_customer_id=c.customer_id and c.customer_id=m.members_customer_id and m.members_relation_id=r.relation_id and v.visit_member_id=m.members_id and v.visit_tnx_id=p.plan_visit_id and p.plan_department_id=d.department_id order by p.plan_order_id", con);



            //SqlCommand MyQueueNumber = new SqlCommand("select p.plan_order_id,p.plan_datetime,v.visit_customer_id,v.visit_customer_name,m.members_firstname,r.relation_desc,d.department_desc,qs.queue_status_desc from tbl_customervisit_tnx v,tbl_customer_dtl m,tbl_relation_mst r,tbl_queueplan_dtl p,tbl_department_mst d,tbl_queue_tnx q,tbl_queuestatus_mst qs,tbl_customerreg_mst c where v.visit_queue_no=@queue_number and CONVERT(DATE,p.plan_datetime)= @date_time and v.visit_customer_id=c.customer_id and c.customer_id=m.members_customer_id and m.members_relation_id=r.relation_id and v.visit_member_id=m.members_id and v.visit_tnx_id=p.plan_visit_id and p.plan_department_id=d.department_id and v.visit_tnx_id=q.queu_visit_tnxid and q.queue_status_id=qs.queue_status_id order by p.plan_order_id", MySqlConnection);


            //SqlCommand MyQueueNumber = new SqlCommand("select p.plan_order_id,v.visit_customer_id,v.visit_customer_name,m.members_firstname,r.relation_desc,d.department_desc,qs.queue_status_desc from tbl_customervisit_tnx v,tbl_customer_dtl m,tbl_relation_mst r,tbl_queueplan_dtl p,tbl_department_mst d,tbl_queue_tnx q,tbl_queuestatus_mst qs where v.visit_queue_no=@queue_number and v.visit_member_id=m.members_id and m.members_relation_id=r.relation_id and v.visit_tnx_id=p.plan_visit_id and p.plan_department_id=d.department_id and p.plan_department_id=q.queue_department_id and v.visit_tnx_id=q.queu_visit_tnxid and q.queue_status_id=qs.queue_status_id order by p.plan_order_id", MySqlConnection);
            //MyQueueNumber.Parameters.Add(new SqlParameter("@queue_number", SqlDbType.VarChar, 255));
            //MyQueueNumber.Parameters["@queue_number"].Value = crtqueuestatusbel.QueueNumber;

            //MyQueueNumber.Parameters.Add(new SqlParameter("@date_time", SqlDbType.VarChar, 255));
            //MyQueueNumber.Parameters["@date_time"].Value = crtqueuestatusbel.DateTime;

            //con.Open();

            //SqlDataReader dr = MyQueueNumber.ExecuteReader();


            //MyAvailableUserName.Load(dr);

            //MySqlConnection.Close();

            //return MyAvailableUserName;


        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Availability User Name Data From DataBase", exmsg);
        }

        finally
        {
            con.Close();
        }

    }

    #endregion Getting Queue Status - Getting My Queue Number


    // Getting Queue Status - Getting My Queue Status

    #region Getting Queue Status - Getting My Queue Status

    public string GetDALMyQueueStatus(CRTBEL crtqueuestatusbel)
    {
        try
        {
            con = new SqlConnection(ConnectionString);

            con.Open();

            string sql = "select qs.queue_status_desc from tbl_queuestatus_mst qs,tbl_queue_tnx q where q.queue_tnx_id=@Transfer_ID and q.queue_status_id=qs.queue_status_id";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Transfer_ID", crtqueuestatusbel.TransferID);

            cmd.Parameters.AddWithValue("@date_time", crtqueuestatusbel.DateTime);

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

            //con = new SqlConnection(ConnectionString);

            //SqlCommand MyQueueNumber = new SqlCommand("select qs.queue_status_desc from tbl_queuestatus_mst qs,tbl_queue_tnx q where q.queue_tnx_id=@Transfer_ID and q.queue_status_id=qs.queue_status_id", con);



            //SqlCommand MyQueueNumber = new SqlCommand("select p.plan_order_id,p.plan_datetime,v.visit_customer_id,v.visit_customer_name,m.members_firstname,r.relation_desc,d.department_desc,qs.queue_status_desc from tbl_customervisit_tnx v,tbl_customer_dtl m,tbl_relation_mst r,tbl_queueplan_dtl p,tbl_department_mst d,tbl_queue_tnx q,tbl_queuestatus_mst qs,tbl_customerreg_mst c where v.visit_queue_no=@queue_number and CONVERT(DATE,p.plan_datetime)= @date_time and v.visit_customer_id=c.customer_id and c.customer_id=m.members_customer_id and m.members_relation_id=r.relation_id and v.visit_member_id=m.members_id and v.visit_tnx_id=p.plan_visit_id and p.plan_department_id=d.department_id and v.visit_tnx_id=q.queu_visit_tnxid and q.queue_status_id=qs.queue_status_id order by p.plan_order_id", MySqlConnection);


            //SqlCommand MyQueueNumber = new SqlCommand("select p.plan_order_id,v.visit_customer_id,v.visit_customer_name,m.members_firstname,r.relation_desc,d.department_desc,qs.queue_status_desc from tbl_customervisit_tnx v,tbl_customer_dtl m,tbl_relation_mst r,tbl_queueplan_dtl p,tbl_department_mst d,tbl_queue_tnx q,tbl_queuestatus_mst qs where v.visit_queue_no=@queue_number and v.visit_member_id=m.members_id and m.members_relation_id=r.relation_id and v.visit_tnx_id=p.plan_visit_id and p.plan_department_id=d.department_id and p.plan_department_id=q.queue_department_id and v.visit_tnx_id=q.queu_visit_tnxid and q.queue_status_id=qs.queue_status_id order by p.plan_order_id", MySqlConnection);
            //MyQueueNumber.Parameters.Add(new SqlParameter("@Transfer_ID", SqlDbType.VarChar, 255));
            //MyQueueNumber.Parameters["@Transfer_ID"].Value = crtqueuestatusbel.TransferID;

            //MyQueueNumber.Parameters.Add(new SqlParameter("@date_time", SqlDbType.VarChar, 255));
            //MyQueueNumber.Parameters["@date_time"].Value = queuestatusbel.DateTime;


            //con.Open();

            ////MySqlConnection.Open();

            ////SqlDataReader dr = MyQueueNumber.ExecuteReader();
            ////while (dr.Read())
            ////{
            //dr.Read();
            ////QueueStatus = dr.GetGuid(0).ToString();
            ////dr.Close();
            //QueueStatus = dr["queue_status_desc"].ToString();
            //dr.Close();
            //string[] tempStr = dr["queue_status_desc"].ToString();

            //QueueStatus = Convert.ToInt16(dr.GetString("queue_status_desc"));

            //QueueStatus = dr.GetValue().ToString().Trim();
            //MyAvailableQueueStatus.Load(dr);

            //MySqlConnection.Close();

            //}

            //return QueueStatus;

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


    //Appointment

    #region SearchAppointmentFresh
    public DataTable SearchAppointmentFresh(CRTBEL crtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "SELECT department_id,department_desc FROM [tbl_department_mst] ORDER BY department_desc ASC";
            //string sql = "select DISTINCT c.members_firstname+c.members_lastname as patientname, a.appointment_id from tbl_appointment_tnx a, tbl_customer_dtl c, tbl_terminal_mst t where CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE()) and a.appointment_members_id=c.members_id and a.appointment_department_id=@departid and a.appointment_status is null";
            string sql = "select DISTINCT c.members_firstname+c.members_lastname as patientname, a.appointment_id from tbl_department_mst d,tbl_appointment_tnx a, tbl_customer_dtl c, tbl_terminal_mst t where CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE()) and a.appointment_members_id=c.members_id and a.appointment_department_id=@departid and a.appointment_department_id=d.department_id and a.appointment_status is null";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@departid", crtview.DepartmentId);
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


    #region SearchAppointmentToken
    public DataTable SearchAppointmentToken(CRTBEL crtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "SELECT department_id,department_desc FROM [tbl_department_mst] ORDER BY department_desc ASC";
            string sql = "select DISTINCT c.members_firstname+c.members_lastname+v.visit_queue_no_show as patientname from tbl_appointment_tnx a,tbl_queue_tnx q, tbl_customer_dtl c,tbl_customervisit_tnx v where CONVERT(DATE, v.visit_datetime) = CONVERT(DATE, GETDATE()) and CONVERT(DATE, q.queue_datetime)=CONVERT(DATE,GETDATE()) and c.members_id=v.visit_member_id and q.queue_department_id=@departid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@departid", crtview.DepartmentId);
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
    //Appointment Emr
    #region SearchAppointmentEmr
    public DataTable SearchAppointmentEmr(CRTBEL crtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "SELECT department_id,department_desc FROM [tbl_department_mst] ORDER BY department_desc ASC";
            string sql = "select c.members_firstname+c.members_lastname+v.visit_queue_no_show as patientname, a.appointment_id from tbl_appointment_tnx a, tbl_customer_dtl c,tbl_customervisit_tnx v where CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE()) and CONVERT(DATE, v.visit_datetime) = CONVERT(DATE, GETDATE()) and a.appointment_members_id=c.members_id and a.appointment_status='E' and a.appointment_customer_id=v.visit_customer_id and a.appointment_department_id=@departid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@departid",crtview.DepartmentId);
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

    #region SearchAppointmentEmrindexchanged
    public DataTable SearchAppointmentEmrIndex(CRTBEL crtview) //SearchAppointmentEmr(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "SELECT department_id,department_desc FROM [tbl_department_mst] ORDER BY department_desc ASC";
            string sql = "select c.members_firstname+c.members_lastname+v.visit_queue_no_show as patientname, a.appointment_id from tbl_appointment_tnx a, tbl_customer_dtl c,tbl_customervisit_tnx v where CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE()) and CONVERT(DATE, v.visit_datetime) = CONVERT(DATE, GETDATE()) and a.appointment_members_id=c.members_id and a.appointment_status='E' and a.appointment_customer_id=v.visit_customer_id and a.appointment_department_id=@departid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@departid", crtview.DepartmentId);
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

    //Appointment Emr
    #region UpdateAppointmentEmr
    public string UpdateAppointmentEmr(CRTBEL crtview)
    {
        string datatbl ="";
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_appointment_tnx set appointment_status='E' where appointment_id = @aptid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@aptid", crtview.AppointmentIDStatus);
            cmd.ExecuteNonQuery();
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

    //Appointment Token
    #region UpdateAppointmentToken
    public string UpdateAppointmentToken(CRTBEL crtview)
    {
        string datatbl ="";
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_appointment_tnx set appointment_status='T' where appointment_id = @aptid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@aptid", crtview.AppointmentIDStatus);
            cmd.ExecuteNonQuery();
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

    #region Searchmembersurname
    public DataTable Searchmembersurname(string _surname)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "SELECT department_id,department_desc FROM [tbl_department_mst] ORDER BY department_desc ASC";
            //string sql = "select DISTINCT c.members_firstname+c.members_lastname+v.visit_queue_no_show as patientname from tbl_appointment_tnx a,tbl_queue_tnx q, tbl_customer_dtl c,tbl_customervisit_tnx v where CONVERT(DATE, a.appointment_time)=CONVERT(DATE, GETDATE())and CONVERT(DATE, v.visit_datetime) = CONVERT(DATE, GETDATE()) and CONVERT(DATE, q.queue_datetime)=CONVERT(DATE,GETDATE()) and c.members_id=v.visit_member_id and q.queue_department_id=@departid";
            string sql = "select DISTINCT c.members_customer_id,c.members_firstname+' '+c.members_lastname as PatientName from tbl_customer_dtl c,tbl_customerreg_mst cr where c.members_lastname LIKE '%'+@surname+'%' and cr.customer_id=c.members_customer_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@surname", _surname);
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

    #region UpdateCancelToken
    public string UpdateCancelToken(CRTBEL crtview)
    {
        string datatbl = "";
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_queue_tnx set queue_status_id=6,sms_status_flag=@CancelStatus where queu_visit_tnxid=@CancelVisitId and CONVERT(DATE,queue_datetime)=CONVERT(Date,GETDATE())";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@CancelVisitId", crtview.CusVisitId);
            cmd.Parameters.AddWithValue("@CancelStatus", crtview.ConsultingStatus);
            cmd.ExecuteNonQuery();
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

    #region get token
    public DataTable selectTicketdata(CRTBEL crtview)
    {
        // SqlDataAdapter sqlad = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_customervisit_tnx c,tbl_queue_tnx q,tbl_department_mst d where CONVERT(DATE,c.visit_datetime)=CONVERT(DATE,GETDATE()) and CONVERT(DATE,q.queue_datetime)=CONVERT(DATE,GETDATE()) and q.queu_visit_tnxid=c.visit_tnx_id and q.queue_department_id=d.department_id and c.visit_queue_no_show=@Qnumber";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Qnumber", crtview.QueueNummberShow);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            dt = ds.Tables[0];
            return dt;

        }
        catch (Exception)
        {

            return dt;
        }
        finally
        {
            // con.Close();
            // cmd.Cancel();
        }
    }
    #endregion

}