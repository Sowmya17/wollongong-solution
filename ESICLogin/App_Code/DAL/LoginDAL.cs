using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

/// <summary>
/// Summary description for LoginDAL
/// </summary>

public class LoginDAL
{
    string ConnectionString;
    string Decryption;
    SqlConnection con;
    SqlCommand cmd;
    SqlDataAdapter sqlad;
    SqlDataReader sqlrd;

   // List<SqlParameter> tempParameterlist;

    //// SQL CONNECTION STRING - Encryption

    //#region SQL CONNECTION STRING - Encryption

    //private string Encryptdata(string password)
    //{
    //    string strmsg = string.Empty;
    //    byte[] encode = new
    //    byte[password.Length];
    //    encode = Encoding.UTF8.GetBytes(password);
    //    strmsg = Convert.ToBase64String(encode);
    //    return strmsg;
    //}

    //#endregion SQL CONNECTION STRING - Encryption

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


	public LoginDAL()
	{
        Decryption = ConfigurationManager.AppSettings["LocalConnection"].ToString();
        
        // cmd = new SqlCommand();
         sqlad = new SqlDataAdapter();

         //Encryptdata(Decryption); 
        // sqlrd = new SqlDataReader(); 

         ConnectionString = Decryptdata(Decryption);
	}

    // Search the user login details
    #region SearchUserDetails
    public DataTable SearchUserDetails(string _username, string _password)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT * FROM [tbl_user_mst] where user_login=@username and user_pwd=@password";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@username", _username);
            cmd.Parameters.AddWithValue("@password", _password);
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
    #endregion SearchUserDetails

    #region Get Current SessionId based on User
    public DataTable GetSessionId(int userId)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "Select max(session_id) as Session_Id from tbl_usersession_dtl where session_user_id=@UserId and Cast(session_user_logintime as date) = Cast(GETDATE() as date)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region Get Current User Session Records
    public DataTable GetUserSessionSod(int UserId)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "Select Max(session_user_sod) as Session_user_sod from [tbl_usersession_dtl] where session_user_id=@UserId and Cast(session_user_logintime as date) = Cast(GETDATE() as date)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.ExecuteNonQuery();
            sqlad.SelectCommand = cmd;
            sqlad.Fill(ds);
            datatbl = ds.Tables[0];
            return datatbl;
            //userSessionSod = Convert.ToInt32(datatbl.Rows[0].ToString());
            //return userSessionSod;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }

    #endregion

    #region Update User Session 
    public void UpdateuserLogoutSession(int sessionId, int userId)
    {
        DateTime logoutdatetime = DateTime.Now;
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "Update tbl_usersession_dtl SET session_user_logouttime=@logOutTime where session_user_id=@userId and session_id=@sessionid";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@logOutTime", logoutdatetime);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.Parameters.AddWithValue("@sessionid", sessionId);
            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }

    public void UpdateUserSession(int userId, int departmentId, int TerminalTypeId, int usersessionsod)
    {
        DateTime logindatetime = DateTime.Now;
        DateTime operatorDate = DateTime.Now;
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "Insert into tbl_usersession_dtl(session_user_id,session_user_sod,session_user_logintime,session_user_oprdate,session_user_deaprtment_id,session_user_terminal_id)" +
                "values(@UserId,@userSod,@userLoginTime,@userOprTime,@userDeptId,@userTermId)";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.Parameters.AddWithValue("@userSod", usersessionsod);
            cmd.Parameters.AddWithValue("@userLoginTime", logindatetime);
            //cmd.Parameters.AddWithValue("@userLogout", null);
            cmd.Parameters.AddWithValue("@userOprTime", operatorDate);
            cmd.Parameters.AddWithValue("@userDeptId", departmentId);
            cmd.Parameters.AddWithValue("@userTermId", TerminalTypeId);
            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }

    }
    #endregion 

    #region Update Mac Address
    public void UpdateMacAdd(string _ipaddress, int _departmentid, string _username)
    {
        DateTime logoutdatetime = DateTime.Now;
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "Update tbl_terminal_mst SET terminal_ip=@ipadress where terminal_dept_id=@departmentid and terminal_username=@username";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ipadress", _ipaddress);
            cmd.Parameters.AddWithValue("@departmentid", _departmentid);
            cmd.Parameters.AddWithValue("@username", _username);
            sqlad.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            con.Close();
            //sqlrd.Close();
            cmd.Cancel();
        }
    }
    #endregion

    #region SearchUserTerminalDetails
    public DataTable SearchUserTerminalDetails(string _ipaddress, int _departmentid, string _username)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            //string sql = "SELECT t1.*,t2.department_desc FROM [tbl_terminal_mst] t1,[tbl_department_mst] t2 where t1.terminal_ip=@ipadress and t1.terminal_dept_id=@departmentid and t2.department_id=@departmentid ";

            string sql = "SELECT t1.*,t2.department_desc FROM [tbl_terminal_mst] t1,[tbl_department_mst] t2 where t1.terminal_dept_id=@departmentid and terminal_username=@username and t2.department_id=@departmentid ";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ipadress", _ipaddress);
            cmd.Parameters.AddWithValue("@departmentid", _departmentid);
            cmd.Parameters.AddWithValue("@username", _username);
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


    #region SearchAutoLoginDetails
    public DataTable SearchAutoLoginDetails(string _ipaddress)
    {
        DataTable datatbl = new DataTable();
        DataSet ds = new DataSet();
        try
        {
            con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT terminal_autologin_status,terminal_username,terminal_password FROM [tbl_terminal_mst] t1 where t1.terminal_ip=@ipadress and terminal_autologin_status='y'";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@ipadress", _ipaddress);
            //cmd.Parameters.AddWithValue("@departmentid", _departmentid);
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
}