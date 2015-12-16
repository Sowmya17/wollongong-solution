using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;

/// <summary>
/// Summary description for KioskDAL
/// </summary>
public class KioskDAL
{
    string ConnectionString;
    string Decryption;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter sqlad;
    SqlDataReader sqlrd;

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


	public KioskDAL()
    {
        Decryption = ConfigurationManager.AppSettings["LocalConnection"].ToString();

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
           // string sql = "SELECT department_id,department_desc FROM [tbl_department_mst] order by department_desc";
            string sql = "SELECT department_id,department_desc FROM [tbl_department_mst],tbl_terminal_mst where department_id=terminal_dept_id and terminal_type_id =2 ORDER BY department_desc ASC";
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


    #region UpdateMobileNO
    public void DaoUpdateMobileNo(KioskBEL kioskview,string es)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_customer_dtl set members_mobile=@mobileno,members_email=@email where members_id = @esicno";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@esicno", kioskview.PatientId);
            cmd.Parameters.AddWithValue("@mobileno",Convert.ToInt64(es));
            cmd.Parameters.AddWithValue("@email", kioskview.Email);
            cmd.ExecuteNonQuery();
            //sqlad.SelectCommand = cmd;
            //sqlad.Fill(ds);
            //datatbl = ds.Tables[0];
            //return datatbl;
        }
        catch
        {
            //return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion


    #region UpdateEmail
    public void DaoUpdateEmail(KioskBEL kioskview, string es)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_customer_dtl set members_email=@email where members_id = @esicno";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@esicno", kioskview.PatientId);
            //cmd.Parameters.AddWithValue("@mobileno", Convert.ToInt64(es));
            cmd.Parameters.AddWithValue("@email", kioskview.Email);
            cmd.ExecuteNonQuery();
            //sqlad.SelectCommand = cmd;
            //sqlad.Fill(ds);
            //datatbl = ds.Tables[0];
            //return datatbl;
        }
        catch
        {
            //return datatbl;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion


    #region UpdateMobileNO
    public void DaoUpdateMob(KioskBEL kioskview, string es)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_customer_dtl set members_mobile=@mobileno where members_id = @esicno";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@esicno", kioskview.PatientId);
            cmd.Parameters.AddWithValue("@mobileno", Convert.ToInt64(es));
           // cmd.Parameters.AddWithValue("@email", kioskview.Email);
            cmd.ExecuteNonQuery();
            //sqlad.SelectCommand = cmd;
            //sqlad.Fill(ds);
            //datatbl = ds.Tables[0];
            //return datatbl;
        }
        catch
        {
            //return datatbl;
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
    public string InsertRegCustomerDetail(KioskBEL kioskview)
    {
        // DataTable datatbl = new DataTable();
        //  DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customerreg_mst (customer_id,customer_firstname,customer_lastname,customer_address,customer_mobile,customer_gender,customer_age,updated_datetime,updated_by)" +
                     "values(@ESCInNumber, @CusFirstname, @CusLastName, @CusAddress, @CusPhoneNo, @CusGender, @CusAge, @datetime, @TerminalUser)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ESCInNumber", kioskview.ESCInNumber);
            cmd.Parameters.AddWithValue("@CusFirstname", kioskview.CusFirstname);
            cmd.Parameters.AddWithValue("@CusLastName", kioskview.CusLastName);
            cmd.Parameters.AddWithValue("@CusAddress", kioskview.CusAddress);
            cmd.Parameters.AddWithValue("@CusPhoneNo", kioskview.CusPhoneNo);
            cmd.Parameters.AddWithValue("@CusGender", kioskview.CusGender);
            cmd.Parameters.AddWithValue("@CusAge", kioskview.CusAge);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@TerminalUser", kioskview.TerminalUser);
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
            //string sql = "SELECT DISTINCT (cus.members_lastname),rel.relation_desc FROM tbl_customer_dtl cus,tbl_relation_mst rel,tbl_appointment_tnx a where left(cus.members_customer_id,9) = @esicno and cus.members_relation_id = rel.relation_id and CONVERT(date,a.appointment_time)=CONVERT(date,GETDATE()) and LEFT(a.appointment_customer_id,9)=@esicno and cus.members_customer_id=a.appointment_customer_id";
           //string sql = "SELECT cus.*,rel.relation_desc FROM tbl_customer_dtl cus,tbl_relation_mst rel where left(cus.members_customer_id,9) = @esicno and cus.members_relation_id = rel.relation_id";
            //string sql = "SELECT cus.*,rel.relation_desc FROM tbl_customer_dtl cus,tbl_relation_mst rel,tbl_appointment_tnx a where left(cus.members_customer_id,9) = @esicno and cus.members_relation_id = rel.relation_id and CONVERT(date,a.appointment_time)=CONVERT(date,GETDATE()) and LEFT(a.appointment_customer_id,9)=@esicno and cus.members_customer_id=a.appointment_customer_id";
            string sql = "SELECT  distinct(cus.members_id),cus.members_firstname,cus.members_lastname,cus.members_reg_datetime,cus.members_gender,cus.members_age,cus.members_relation_id,cus.members_customer_id,cus.updated_datetime,cus.updated_by,cus.members_dob,cus.members_mobile,cus.members_email,rel.relation_desc FROM tbl_customer_dtl cus,tbl_relation_mst rel,tbl_appointment_tnx a where left(cus.members_customer_id,9) = left(@esicno,9) and cus.members_relation_id = rel.relation_id and CONVERT(date,a.appointment_time)=CONVERT(date,GETDATE()) and LEFT(a.appointment_customer_id,9)= LEFT(@esicno,9) and cus.members_customer_id=a.appointment_customer_id";
            //string sql = "SELECT  distinct(cus.members_id),cus.members_firstname,cus.members_lastname,cus.members_reg_datetime,cus.members_gender,cus.members_age,cus.members_relation_id,cus.members_customer_id,cus.updated_datetime,cus.updated_by,cus.members_dob,cus.members_mobile,cus.members_email,rel.relation_desc FROM tbl_customer_dtl cus,tbl_relation_mst rel,tbl_appointment_tnx a where cus.members_relation_id = rel.relation_id and CONVERT(date,a.appointment_time)=CONVERT(date,GETDATE()) and a.appointment_customer_id=@esicno and cus.members_customer_id=a.appointment_customer_id";
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

    #region SearchMemberDetail
    public DataTable SearchMemberDetailOne(string esicno)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "SELECT DISTINCT (cus.members_lastname),rel.relation_desc FROM tbl_customer_dtl cus,tbl_relation_mst rel,tbl_appointment_tnx a where left(cus.members_customer_id,9) = @esicno and cus.members_relation_id = rel.relation_id and CONVERT(date,a.appointment_time)=CONVERT(date,GETDATE()) and LEFT(a.appointment_customer_id,9)=@esicno and cus.members_customer_id=a.appointment_customer_id";
            //string sql = "SELECT Top 1 cus.*,rel.relation_desc FROM tbl_customer_dtl cus,tbl_relation_mst rel,tbl_appointment_tnx a where left(cus.members_customer_id,9) = @esicno and cus.members_relation_id = rel.relation_id and CONVERT(date,a.appointment_time)=CONVERT(date,GETDATE()) and LEFT(a.appointment_customer_id,9)=@esicno and cus.members_customer_id=a.appointment_customer_id";
            string sql = "SELECT cus.*,rel.relation_desc FROM tbl_customer_dtl cus,tbl_relation_mst rel where cus.members_customer_id= @esicno and cus.members_relation_id = rel.relation_id";
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

    #region Check Queue Token Already Generated Details

    public DataTable CheckQueueTokenAlreadyGeneratedDetails(KioskBEL kioskview)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_customervisit_tnx where visit_customer_id=@customerid and visit_customer_name=@customername and cast(visit_datetime as date) = cast(getdate() as date)and visit_member_id=@memberid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@customerid", kioskview.ESCInNumber);
            cmd.Parameters.AddWithValue("@customername", kioskview.CustomerFullName);
            cmd.Parameters.AddWithValue("@memberid", kioskview.PatientId);
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
    public string InsertMemberDetail(KioskBEL kioskview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customer_dtl (members_firstname,members_lastname,members_reg_datetime,members_gender,members_age,members_relation_id,members_customer_id,updated_datetime,updated_by)" +
                     "values(@CusFirstname, @CusLastName, @Cusregupdateddate,@CusGender, @CusAge,@Cusrelationid,@ESCInNumber, @datetime, @Updatedby,@dob)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@CusFirstname", kioskview.CusFirstname);
            cmd.Parameters.AddWithValue("@CusLastName", kioskview.CusLastName);
            cmd.Parameters.AddWithValue("@Cusregupdateddate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CusGender", kioskview.CusGender);
            cmd.Parameters.AddWithValue("@CusAge", kioskview.CusAge);
            cmd.Parameters.AddWithValue("@Cusrelationid", kioskview.RelationId);
            cmd.Parameters.AddWithValue("@ESCInNumber", kioskview.ESCInNumber);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Updatedby", kioskview.TerminalUser);
            
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
    public string UpdateRegCustomerDetail(KioskBEL kioskview)
    {
        // DataTable datatbl = new DataTable();
        //  DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();

            string sql = "update tbl_customerreg_mst set customer_firstname=@CusFirstname,customer_lastname=@CusLastName,customer_address=@CusAddress,customer_mobile=@CusPhoneNo," +
            "customer_gender=@CusGender,customer_age=@CusAge,updated_datetime=@datetime,updated_by=@TerminalUser where customer_id=@ESCInNumber";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ESCInNumber", kioskview.ESCInNumber);
            cmd.Parameters.AddWithValue("@CusFirstname", kioskview.CusFirstname);
            cmd.Parameters.AddWithValue("@CusLastName", kioskview.CusLastName);
            cmd.Parameters.AddWithValue("@CusAddress", kioskview.CusAddress);
            cmd.Parameters.AddWithValue("@CusPhoneNo", kioskview.CusPhoneNo);
            cmd.Parameters.AddWithValue("@CusGender", kioskview.CusGender);
            cmd.Parameters.AddWithValue("@CusAge", kioskview.CusAge);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@TerminalUser", kioskview.TerminalUser);
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
    public string UpdateMemberDetail(KioskBEL kioskview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_customer_dtl set members_firstname=@CusFirstname,members_lastname=@CusLastName," +
            "members_reg_datetime=@Cusregupdateddate,members_gender=@CusGender,members_age=@CusAge,members_relation_id=@Cusrelationid," +
            "members_customer_id=@ESCInNumber,updated_datetime=@datetime,updated_by=@Updatedby where members_id=@MemberID";

            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@MemberID", kioskview.MemberId);
            cmd.Parameters.AddWithValue("@CusFirstname", kioskview.MemberFirstName);
            cmd.Parameters.AddWithValue("@CusLastName", kioskview.MemberLastName);
            cmd.Parameters.AddWithValue("@Cusregupdateddate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CusGender", kioskview.MemberGender);
            cmd.Parameters.AddWithValue("@CusAge", kioskview.MemberAge);
            cmd.Parameters.AddWithValue("@Cusrelationid", kioskview.MemberRelationId);
            cmd.Parameters.AddWithValue("@ESCInNumber", kioskview.ESCInNumber);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Updatedby", kioskview.TerminalUser);
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
    public string InsertMemberDetailpat(KioskBEL kioskview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customer_dtl (members_firstname,members_lastname,members_reg_datetime,members_gender,members_age,members_relation_id,members_customer_id,updated_datetime,updated_by)" +
                     "values(@CusFirstname, @CusLastName, @Cusregupdateddate,@CusGender, @CusAge,@Cusrelationid,@ESCInNumber, @datetime, @Updatedby)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@CusFirstname", kioskview.MemberFirstName);
            cmd.Parameters.AddWithValue("@CusLastName", kioskview.MemberLastName);
            cmd.Parameters.AddWithValue("@Cusregupdateddate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CusGender", kioskview.MemberGender);
            cmd.Parameters.AddWithValue("@CusAge", kioskview.MemberAge);
            cmd.Parameters.AddWithValue("@Cusrelationid", kioskview.MemberRelationId);
            cmd.Parameters.AddWithValue("@ESCInNumber", kioskview.ESCInNumber);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Updatedby", kioskview.TerminalUser);
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
    public string UpdateQueueNumber(int deptid, int queueno)
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


    #region KioskTotalWaitingQueue
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
    public string InsertCustomerVisitDetails(KioskBEL kioskview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customervisit_tnx (visit_customer_id,visit_customer_name,visit_datetime,visit_queue_no,visit_member_id,visit_queue_no_show,consulting_status,customer_appointment_id,customer_appointment_time)" +
                     "values(@customerid, @customerfullname, @datetime,@queueno, @memberid,@queuenoshow,@consultingstatus,@customerappointmentid,@customerappointmenttime)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@customerid", Convert.ToInt64(kioskview.ESCInNumber));
            cmd.Parameters.AddWithValue("@customerfullname", kioskview.CustomerFullName);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@queueno", kioskview.QueueNummber);
            cmd.Parameters.AddWithValue("@memberid", kioskview.PatientId);
            cmd.Parameters.AddWithValue("@queuenoshow", kioskview.QueueNummberShow);
            cmd.Parameters.AddWithValue("@consultingstatus", kioskview.ConsultingStatus);
            cmd.Parameters.AddWithValue("@customerappointmentid", kioskview.AppointmentID);
            cmd.Parameters.AddWithValue("@customerappointmenttime", kioskview.AppointmentDateTime);
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
            string sql = " SELECT TOP 1 visit_tnx_id FROM tbl_customervisit_tnx ORDER BY visit_tnx_id DESC";
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
    public string InsertCustomerQueueTransactions(KioskBEL kioskview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_queue_tnx (queu_visit_tnxid,queue_datetime,queue_wait_starttime,queue_user_id,queue_terminal_id,queue_department_id,queue_status_id,queue_order_id,sms_status_flag,message_status_flag)" +
                     "values(@visitid, @datetime, @waitstarttime,@userid, @terminalid,@departmentid,@statusid,@orderid,@smsstatusflag,@message_status_flag)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@visitid", kioskview.CusVisitId);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@waitstarttime", DateTime.Now);
            cmd.Parameters.AddWithValue("@userid", kioskview.UserId);
            cmd.Parameters.AddWithValue("@terminalid", kioskview.TerminalId);
            cmd.Parameters.AddWithValue("@departmentid", kioskview.DepartmentId);
            cmd.Parameters.AddWithValue("@statusid", 1);
            cmd.Parameters.AddWithValue("@orderid", kioskview.OrderId);
            cmd.Parameters.AddWithValue("@smsstatusflag", kioskview.SmsStatusFlag);
            cmd.Parameters.AddWithValue("@message_status_flag", kioskview.SmsStatusFlag);
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
    public string InsertCustomerQueuePlanOrderone(KioskBEL kioskview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_queueplan_dtl (plan_datetime,plan_visit_id,plan_transfer_id,plan_order_id,plan_department_id,plan_user_id,plan_terminal_id)" +
                     "values(@datetime, @visitid, @transferid,@orderid, @departmentid,@userid,@terminalid)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@visitid", kioskview.CusVisitId);
            cmd.Parameters.AddWithValue("@transferid", kioskview.QueueTransID);
            cmd.Parameters.AddWithValue("@orderid", kioskview.OrderId);
            cmd.Parameters.AddWithValue("@departmentid", 30);
            cmd.Parameters.AddWithValue("@userid", kioskview.UserId);
            cmd.Parameters.AddWithValue("@terminalid", kioskview.TerminalId);
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
    public string InsertCustomerQueuePlanOrders(KioskBEL kioskview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_queueplan_dtl (plan_datetime,plan_visit_id,plan_order_id,plan_department_id,plan_user_id,plan_terminal_id)" +
                     "values(@datetime, @visitid,@orderid, @departmentid,@userid,@terminalid)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@visitid", kioskview.CusVisitId);
            cmd.Parameters.AddWithValue("@orderid", kioskview.OrderId);
            cmd.Parameters.AddWithValue("@departmentid", kioskview.DepartmentId);
            cmd.Parameters.AddWithValue("@userid", kioskview.UserId);
            cmd.Parameters.AddWithValue("@terminalid", kioskview.TerminalId);
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

    #region Search Appointment Details
    public DataTable SearchAppointmentDetails(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select a.appointment_time,d.department_desc,a.appointment_id,a.appointment_customer_id,c.members_firstname+c.members_lastname as customername,c.members_id,d.department_id from tbl_department_mst d, tbl_appointment_tnx a , tbl_customer_dtl c where CONVERT(date,a.appointment_time)=CONVERT(DATE,GETDATE()) and c.members_customer_id=a.appointment_customer_id and a.appointment_department_id=d.department_id and a.appointment_members_id=c.members_id and c.members_lastname=@surname and CONVERT(DATE,c.members_dob)=@dob order by a.appointment_time ASC";
            //string sql = "select a.appointment_time,d.department_desc,a.appointment_id,a.appointment_customer_id,c.members_firstname+c.members_lastname as customername,c.members_id,d.department_id from tbl_department_mst d, tbl_appointment_tnx a , tbl_customer_dtl c where CONVERT(date,a.appointment_time)=CONVERT(DATE,GETDATE()) and c.members_customer_id=a.appointment_customer_id and a.appointment_department_id=d.department_id and a.appointment_members_id=c.members_id and c.members_lastname=@surname and CONVERT(DATE,c.members_dob)=@dob order by a.appointment_time ASC";
            //string sql = "SELECT a.appointment_time,d.department_desc,a.appointment_id,a.appointment_customer_id,c.members_firstname+c.members_lastname as customername,c.members_id,d.department_id FROM tbl_appointment_tnx a,tbl_department_mst d,tbl_customer_dtl c where a.appointment_members_id = (select Top 1 members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,members_dob)=@dob) and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id and a.appointment_members_id=c.members_id order by a.appointment_time";
            //string sql = "SELECT a.appointment_time,d.department_desc,a.appointment_id FROM tbl_appointment_tnx a,tbl_department_mst d where a.appointment_members_id = (select members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,updated_datetime)=@dob) and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@surname", kbel.CusLastName);
            cmd.Parameters.AddWithValue("@dob", kbel.Dob);
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

    #region Update Appointment status
    public string UpdateAppointmentStatus(KioskBEL kbel)
    {
        string datatbl="";
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_appointment_tnx set appointment_status='T' where appointment_id = @aptid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@aptid", kbel.AppointmentID);
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
    #endregion Search Appointment Details


    #region Search Appointment Details Card
    public DataTable SearchAppointmentDetailsCard(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT c.members_lastname,c.members_dob,a.appointment_time,d.department_desc,a.appointment_id,a.appointment_customer_id,c.members_firstname+c.members_lastname as customername,c.members_id,d.department_id FROM tbl_appointment_tnx a,tbl_department_mst d,tbl_customer_dtl c where a.appointment_members_id =@mid and left(a.appointment_customer_id,9)=LEFT(@esic,9) and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id and a.appointment_members_id=c.members_id order by a.appointment_time asc";
            //string sql = "SELECT a.appointment_time,d.department_desc,a.appointment_id FROM tbl_appointment_tnx a,tbl_department_mst d where a.appointment_members_id = (select members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,updated_datetime)=@dob) and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mid", kbel.MemberId);
            cmd.Parameters.AddWithValue("@esic", kbel.ESCInNumber);
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

    #region Search Patient Details Card
    public DataTable SearchMemberCard(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT c.members_lastname,c.members_dob,c.members_id,c.members_customer_id FROM tbl_department_mst d,tbl_customer_dtl c where c.members_id =@mid and c.members_customer_id=@esic";
            //string sql = "SELECT a.appointment_time,d.department_desc,a.appointment_id FROM tbl_appointment_tnx a,tbl_department_mst d where a.appointment_members_id = (select members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,updated_datetime)=@dob) and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mid", kbel.MemberId);
            cmd.Parameters.AddWithValue("@esic", kbel.ESCInNumber);
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


    #region Search Walkin Details 
    public DataTable SearchWalkinDetails(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT members_customer_id,members_firstname+members_lastname as customername,members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,members_dob)=@dob";
            //string sql = "SELECT a.appointment_time,d.department_desc,a.appointment_id FROM tbl_appointment_tnx a,tbl_department_mst d where a.appointment_members_id = (select members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,updated_datetime)=@dob) and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@surname", kbel.CusLastName);
            cmd.Parameters.AddWithValue("@dob", kbel.Dob);
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


    #region Search Walkin Details Esi
    public DataTable SearchWalkinDetailsEsi(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT members_customer_id,members_firstname+members_lastname as customername,members_id from tbl_customer_dtl where members_customer_id=@esi";
            //string sql = "SELECT a.appointment_time,d.department_desc,a.appointment_id FROM tbl_appointment_tnx a,tbl_department_mst d where a.appointment_members_id = (select members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,updated_datetime)=@dob) and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@esi", kbel.ESCInNumber);
           // cmd.Parameters.AddWithValue("@dob", kbel.Dob);
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

    #region Search CRTRT ID
    public DataTable SearchCrtRtId(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select terminal_dept_id from tbl_terminal_mst where terminal_type_id=6";
            //string sql = "SELECT a.appointment_time,d.department_desc,a.appointment_id FROM tbl_appointment_tnx a,tbl_department_mst d where a.appointment_members_id = (select members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,updated_datetime)=@dob) and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id";
            cmd = new SqlCommand(sql, con);
           // cmd.Parameters.AddWithValue("@surname", kbel.CusLastName);
          //  cmd.Parameters.AddWithValue("@dob", kbel.Dob);
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

    #region InsertCustomerVisitDetails Wakin
    public string InsertCustomerVisitDetailsW(KioskBEL crtview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customervisit_tnx (visit_customer_id,visit_datetime,visit_queue_no,visit_member_id,visit_queue_no_show,consulting_status)" +
                     "values(@customerid, @datetime,@queueno, @memberid,@queuenoshow,@consultingstatus)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@customerid", Convert.ToInt64(crtview.ESCInNumber));
            //cmd.Parameters.AddWithValue("@customerfullname", crtview.CustomerFullName);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@queueno", crtview.QueueNummber);
            cmd.Parameters.AddWithValue("@memberid", crtview.PatientId);
            cmd.Parameters.AddWithValue("@queuenoshow", crtview.QueueNummberShow);
            cmd.Parameters.AddWithValue("@consultingstatus", crtview.ConsultingStatus);
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

    #region InsertRegCustomerDetail
    public string InsertRegCustomerDetail1(KioskBEL kioskview)
    {
        // DataTable datatbl = new DataTable();
        //  DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customerreg_mst (customer_id,customer_firstname,customer_lastname,customer_dob,customer_address,customer_mobile,customer_gender,customer_age,updated_datetime,updated_by)" +
                     "values(@ESCInNumber, @CusFirstname, @CusLastName, @dob, @CusAddress, @CusPhoneNo, @CusGender, @CusAge, @datetime, @TerminalUser)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ESCInNumber", kioskview.ESCInNumber);
            cmd.Parameters.AddWithValue("@CusFirstname", kioskview.CusFirstname);
            cmd.Parameters.AddWithValue("@CusLastName", kioskview.CusLastName);
            cmd.Parameters.AddWithValue("@dob", kioskview.Dob);
            cmd.Parameters.AddWithValue("@CusAddress", kioskview.CusAddress);
            cmd.Parameters.AddWithValue("@CusPhoneNo", kioskview.CusPhoneNo);
            // cmd.Parameters.AddWithValue("@Email",crtview.Email);
            cmd.Parameters.AddWithValue("@CusGender", kioskview.CusGender);
            cmd.Parameters.AddWithValue("@CusAge", kioskview.CusAge);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@TerminalUser", kioskview.TerminalUser);
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

    #region InsertMemberDetail
    public string InsertMemberDetail1(KioskBEL kioskview)
    {
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "insert into tbl_customer_dtl (members_firstname,members_lastname,members_reg_datetime,members_gender,members_age,members_relation_id,members_customer_id,members_mobile,members_email,updated_datetime,updated_by,members_dob)" +
                     "values(@CusFirstname, @CusLastName, @Cusregupdateddate,@CusGender, @CusAge,@Cusrelationid,@ESCInNumber,@mobile,@Email, @datetime, @Updatedby,@dob)";
            cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@CusFirstname", kioskview.CusFirstname);
            cmd.Parameters.AddWithValue("@CusLastName", kioskview.CusLastName);
            cmd.Parameters.AddWithValue("@Cusregupdateddate", DateTime.Now);
            cmd.Parameters.AddWithValue("@CusGender", kioskview.CusGender);
            cmd.Parameters.AddWithValue("@CusAge", kioskview.CusAge);
            cmd.Parameters.AddWithValue("@Cusrelationid", kioskview.RelationId);
            cmd.Parameters.AddWithValue("@ESCInNumber", kioskview.ESCInNumber);
            cmd.Parameters.AddWithValue("@mobile", kioskview.CusPhoneNo);
            cmd.Parameters.AddWithValue("@Email", kioskview.Email);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@Updatedby", kioskview.TerminalUser);
            cmd.Parameters.AddWithValue("@dob", kioskview.Dob);
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

    #region Search Dummy Details
    public DataTable SearchDummyNo(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "select * from tbl_dummy_no";
           // string sql = "SELECT members_customer_id,members_firstname+members_lastname as customername,members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,members_dob)=@dob";
            //string sql = "SELECT a.appointment_time,d.department_desc,a.appointment_id FROM tbl_appointment_tnx a,tbl_department_mst d where a.appointment_members_id = (select members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,updated_datetime)=@dob) and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id";
            cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@surname", kbel.CusLastName);
            //cmd.Parameters.AddWithValue("@dob", kbel.Dob);
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

    #region Update Dummy Details
    public DataTable UpdateDummyNo(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "update tbl_dummy_no set dummy_no=@dummyno where dummy_id=1";
            // string sql = "SELECT members_customer_id,members_firstname+members_lastname as customername,members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,members_dob)=@dob";
            //string sql = "SELECT a.appointment_time,d.department_desc,a.appointment_id FROM tbl_appointment_tnx a,tbl_department_mst d where a.appointment_members_id = (select members_id from tbl_customer_dtl where members_lastname=@surname and convert(date,updated_datetime)=@dob) and CONVERT(DATE, a.appointment_time) = CONVERT(DATE, GETDATE())and a.appointment_department_id=d.department_id";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@dummyno", kbel.ESCInNumber);
            //cmd.Parameters.AddWithValue("@dob", kbel.Dob);
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
    public DataTable checkcountNumber(int deptid)
    {
        DataTable datatbl = new DataTable();

        DataSet ds = new DataSet();


        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "select count(*) as cc from tbl_customervisit_tnx where cast(visit_datetime as date) = cast(getdate() as date)";
            string sql = "select count(*) as cc from tbl_queue_tnx where queue_department_id=@deptid and cast(queue_datetime as date)=cast(getdate() as date)";
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





    internal DataTable kioskReprintCheckQueueTokenAlreadyGeneratedDetails(KioskBEL kioskview)
    {
        throw new NotImplementedException();
    }

    internal DataTable KioskReprintCheckQueueTokenAlreadyGeneratedDetails(KioskBEL kioskview)
    {
        throw new NotImplementedException();
    }
}