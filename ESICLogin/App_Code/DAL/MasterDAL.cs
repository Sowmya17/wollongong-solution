
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

/// <summary>
/// Summary description for MasterDAL
/// </summary>
public class MasterDAL
{
    string QueueStatus;
    string ConnectionString;
    string Decryption;

    // SQL CONNECTION

    #region SQL CONNECTION - ACCESSING CONNECTION STRING FROM TEXT FILE

    SqlConnection MySqlConnection = new SqlConnection();

    #endregion SQL CONNECTION - ACCESSING CONNECTION STRING FROM TEXT FILE

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


    // Master DAL - Constructor

    #region Master DAL - Constructor

    public MasterDAL()
    {
        Decryption = ConfigurationManager.AppSettings["LocalConnection"].ToString();

        ConnectionString = Decryptdata(Decryption);
        //MySqlConnection = ConnectionString;

        MySqlConnection = new SqlConnection(ConnectionString);
    }

    #endregion Master DAL - Constructor

    // ---------------------------------------------- User Master -------------------------------------
    // User Master - Roll Description Loading

    #region User Master - Roll Description Loading

    public DataTable DaoGetRollDescription()
    {
        try
        {
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select roll_id,roll_desc from tbl_roll_mst order by roll_id asc", MySqlConnection);

            DataSet ds = new DataSet();
            MyDataAdapter.Fill(ds);

            DataTable MySelectDataTable = new DataTable();

            MySelectDataTable = ds.Tables[0];

            return MySelectDataTable;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Roll Data From DataBase", exmsg);
        }

    }

    #endregion User Master - Roll Description Loading

    // User Master - User Name Checking - Availability

    #region User Master - User Name Checking - Availability

    public DataTable GetAvailableUserName(MasterBEL masterbel)
    {
        try
        {
            SqlCommand CheckUserName = new SqlCommand("select * from tbl_user_mst where user_login=@user_login", MySqlConnection);
            CheckUserName.Parameters.Add(new SqlParameter("@user_login", SqlDbType.VarChar, 255));
            CheckUserName.Parameters["@user_login"].Value = masterbel.UserName;

            MySqlConnection.Open();

            SqlDataReader dr = CheckUserName.ExecuteReader();

            DataTable MyAvailableUserName = new DataTable();

            MyAvailableUserName.Load(dr);

            MySqlConnection.Close();

            return MyAvailableUserName;


        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Availability User Name Data From DataBase", exmsg);
        }

    }

    #endregion User Master - User Name Checking - Availability

    // User Master - Department Description 

    #region User Master - Department Description

    public DataTable DaoGetDepartmentDescription()
    {
        try
        {
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select department_id,department_desc from tbl_department_mst where department_id!=1 order by department_id asc", MySqlConnection);

            DataSet ds = new DataSet();
            MyDataAdapter.Fill(ds);

            DataTable MySelectDataTable = new DataTable();

            MySelectDataTable = ds.Tables[0];

            return MySelectDataTable;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Data From DataBase", exmsg);
        }

    }

    #endregion User Master - Department Description

    // User Master - Insert

    #region User Master - Insert

    public string Insert(MasterBEL masterbel)
    {

        try
        {
            SqlCommand MyCommand = new SqlCommand("Insert into tbl_user_mst (user_login,user_pwd,user_firstname,user_lastname,user_roll_id,user_department_id,user_active,updated_datetime,updated_by)" + "values(@user_login,@user_pwd,@user_firstname,@user_lastname,@user_roll_id,@user_department_id,@user_active,@user_updatedatetime,@user_updatedby)", MySqlConnection);

            MyCommand.Parameters.AddWithValue("@user_login", masterbel.UserName);
            MyCommand.Parameters.AddWithValue("@user_pwd", masterbel.ConfirmPassword);
            MyCommand.Parameters.AddWithValue("@user_firstname", masterbel.FirstName);
            MyCommand.Parameters.AddWithValue("@user_lastname", masterbel.LastName);
            MyCommand.Parameters.AddWithValue("@user_roll_id", masterbel.RollDescription);
            MyCommand.Parameters.AddWithValue("@user_department_id", masterbel.DepartmentDescription);
            MyCommand.Parameters.AddWithValue("@user_active", masterbel.UserStatus);
            MyCommand.Parameters.AddWithValue("@user_updatedatetime", masterbel.UpdatedDateTime);
            MyCommand.Parameters.AddWithValue("@user_updatedby", masterbel.UpdatedBy);


            //MyCommand.Parameters.Add(new SqlParameter("@user_login", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@user_login"].Value = masterbel.UserName;

            //MyCommand.Parameters.Add(new SqlParameter("@user_pwd", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@user_pwd"].Value = masterbel.ConfirmPassword;

            //MyCommand.Parameters.Add(new SqlParameter("@user_firstname", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@user_firstname"].Value = masterbel.FirstName;

            //MyCommand.Parameters.Add(new SqlParameter("@user_lastname", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@user_lastname"].Value = masterbel.LastName;

            //MyCommand.Parameters.Add(new SqlParameter("@user_roll_id", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@user_roll_id"].Value = masterbel.RollDescription;

            //MyCommand.Parameters.Add(new SqlParameter("@user_department_id", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@user_department_id"].Value = masterbel.DepartmentDescription;

            //MyCommand.Parameters.Add(new SqlParameter("@user_active", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@user_active"].Value = masterbel.UserStatus;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_datetime", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_datetime"].Value = masterbel.UpdatedDateTime;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_by", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_by"].Value = masterbel.UpdatedBy;

            //MyCommand.Connection.Open();

            //MyCommand.ExecuteNonQuery();

            //MyCommand.Connection.Close();

            //DataSet dsinsert = new DataSet();

            //DataTable MySelectDataTable = new DataTable();

            //MySelectDataTable = dsinsert.Tables[0];

            //return MySelectDataTable;

            MyCommand.Connection.Open();

            //SqlDataReader dr = MyCommand.ExecuteReader(CommandBehavior.CloseConnection);

            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //return dt;

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string insert = Convert.ToString(1);
            return insert;

        }
        catch
        {

            throw;
        }
        finally
        {
            MySqlConnection.Close();

            //MyInsertDataTable = null;
            //dCmd.Dispose();
            //conn.Close();
            //conn.Dispose();
        }
    }

    #endregion User Master - Insert

    // User Master - Grid View Loading

    #region User Master - Grid View Loading

    public DataTable GetUserGridViewLoading(MasterBEL masterbel)
    {
        try
        {

            if (masterbel.GettingDepartmentId != 0)
            {

                SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select user_id,user_login,user_firstname,user_lastname,r.roll_desc,d.department_desc,user_active,user_pwd,r.roll_id,d.department_id from tbl_user_mst u,tbl_roll_mst r,tbl_department_mst d where u.user_department_id=@getting_department_id and u.user_roll_id=r.roll_id and u.user_department_id=d.department_id order by user_id asc", MySqlConnection);

                MyDataAdapter.SelectCommand.Parameters.AddWithValue("@getting_department_id", masterbel.GettingDepartmentId);

                DataSet dsusergridview = new DataSet();
                MyDataAdapter.Fill(dsusergridview);

                DataTable MySelectDataTable = new DataTable();

                MySelectDataTable = dsusergridview.Tables[0];

                return MySelectDataTable;

            }

            else
            {
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select user_id,user_login,user_firstname,user_lastname,r.roll_desc,d.department_desc,user_active,user_pwd,r.roll_id,d.department_id from tbl_user_mst u,tbl_roll_mst r,tbl_department_mst d where u.user_roll_id=r.roll_id and u.user_department_id=d.department_id order by user_id asc", MySqlConnection);

                DataSet dsusergridview = new DataSet();
                MyDataAdapter.Fill(dsusergridview);

                DataTable MySelectDataTable = new DataTable();

                MySelectDataTable = dsusergridview.Tables[0];

                return MySelectDataTable;
            }


        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Data From DataBase", exmsg);
        }
    }

    #endregion User Master - Grid View Loading

    // User Master - Update

    #region User Master - Update

    public string GetUserUpdate(MasterBEL masterbel)
    {
        try
        {
            SqlCommand MyCommand = new SqlCommand("update tbl_user_mst set user_login=@user_login,user_pwd=@user_pwd,user_firstname=@user_firstname,user_lastname=@user_lastname,user_roll_id=@user_roll_id,user_department_id=@user_department_id,user_active=@user_active,updated_datetime=@user_updatedatetime,updated_by=@user_updatedby where user_id=@user_id", MySqlConnection);

            MyCommand.Parameters.AddWithValue("@user_login", masterbel.UserName);
            MyCommand.Parameters.AddWithValue("@user_pwd", masterbel.ConfirmPassword);
            MyCommand.Parameters.AddWithValue("@user_firstname", masterbel.FirstName);
            MyCommand.Parameters.AddWithValue("@user_lastname", masterbel.LastName);
            MyCommand.Parameters.AddWithValue("@user_roll_id", masterbel.RollDescription);
            MyCommand.Parameters.AddWithValue("@user_department_id", masterbel.DepartmentDescription);
            MyCommand.Parameters.AddWithValue("@user_active", masterbel.UserStatus);
            MyCommand.Parameters.AddWithValue("@user_updatedatetime", masterbel.UpdatedDateTime);
            MyCommand.Parameters.AddWithValue("@user_updatedby", masterbel.UpdatedBy);
            MyCommand.Parameters.AddWithValue("@user_id", masterbel.UserId);

            //MyCommand.Parameters.AddWithValue("@userlogin", masterbel.UserName);
            //MyCommand.Parameters.AddWithValue("@userpwd", masterbel.ConfirmPassword);
            //MyCommand.Parameters.AddWithValue("@userfirstname", masterbel.FirstName);
            //MyCommand.Parameters.AddWithValue("@userlastname", masterbel.LastName);
            //MyCommand.Parameters.AddWithValue("@userrollid", masterbel.RollDescription);
            //MyCommand.Parameters.AddWithValue("@userdepartmentid", masterbel.DepartmentDescription);
            //MyCommand.Parameters.AddWithValue("@useractive", masterbel.UserStatus);
            //MyCommand.Parameters.AddWithValue("@userupdatedatetime", masterbel.UpdatedDateTime);
            //MyCommand.Parameters.AddWithValue("@userupdatedby", masterbel.UpdatedBy);
            //MyCommand.Parameters.AddWithValue("@userid", masterbel.UserId);

            //MyCommand.Parameters.Add(new SqlParameter("@terminaldesc", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminaldesc"].Value = masterbel.TerminalDescription;

            //MyCommand.Parameters.Add(new SqlParameter("@terminalip", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminalip"].Value = masterbel.TerminalIp;

            //MyCommand.Parameters.Add(new SqlParameter("@terminaldeptid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminaldeptid"].Value = masterbel.TerminalDepartmentId;

            //MyCommand.Parameters.Add(new SqlParameter("@terminalroomid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminalroomid"].Value = masterbel.TerminalRoomId;

            //MyCommand.Parameters.Add(new SqlParameter("@terminaltypeid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminaltypeid"].Value = masterbel.TerminalTypeId;

            //MyCommand.Parameters.Add(new SqlParameter("@terminalupdatedatetime", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminalupdatedatetime"].Value = masterbel.TerminalUpdatedDateTime;

            //MyCommand.Parameters.Add(new SqlParameter("@terminalupdatedby", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminalupdatedby"].Value = masterbel.TerminalUpdatedBy;

            //MyCommand.Parameters.Add(new SqlParameter("@terminalid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminalid"].Value = masterbel.TerminalId;

            MyCommand.Connection.Open();

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string update = Convert.ToString(1);
            return update;
        }
        catch
        {
            throw;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }

    #endregion User Master - Update


    // ----------------------------------------- Device Master -------------------------------------------------

    // Device Master - Insert

    #region Device Master - Insert

    public string DeviceInsert(MasterBEL masterbel)
    {

        try
        {
            SqlCommand MyCommand = new SqlCommand("Insert into tbl_device_mst (device_name,device_desc,updated_datetime,updated_by)" + "values(@device_name,@device_desc,@device_updateddatetime,@device_updatedby)", MySqlConnection);

            MyCommand.Parameters.AddWithValue("@device_name", masterbel.DeviceName);
            MyCommand.Parameters.AddWithValue("@device_desc", masterbel.DeviceDescription);
            MyCommand.Parameters.AddWithValue("@device_updateddatetime", masterbel.DeviceUpdatedDateTime);
            MyCommand.Parameters.AddWithValue("@device_updatedby", masterbel.DeviceUpdatedBy);

            //MyCommand.Parameters.Add(new SqlParameter("@device_name", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@device_name"].Value = masterbel.DeviceName;

            //MyCommand.Parameters.Add(new SqlParameter("@device_desc", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@device_desc"].Value = masterbel.DeviceDescription;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_datetime", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_datetime"].Value = masterbel.DeviceUpdatedDateTime;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_by", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_by"].Value = masterbel.DeviceUpdatedBy;



            //MyCommand.Connection.Open();

            //MyCommand.ExecuteNonQuery();

            //MyCommand.Connection.Close();

            //DataSet dsinsert = new DataSet();

            //DataTable MySelectDataTable = new DataTable();

            //MySelectDataTable = dsinsert.Tables[0];

            //return MySelectDataTable;
            MyCommand.Connection.Open();

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string insert = Convert.ToString(1);
            return insert;
            //MyCommand.Connection.Open();
            //SqlDataReader dr = MyCommand.ExecuteReader(CommandBehavior.CloseConnection);
            //MyCommand.Connection.Close();
            //DataTable dt = new DataTable();
            //dt.Load(dr);


            //return dt;

        }
        catch
        {

            throw;
        }
        finally
        {
            MySqlConnection.Close();

            //MyInsertDataTable = null;
            //dCmd.Dispose();
            //conn.Close();
            //conn.Dispose();
        }
    }

    #endregion Device Master - Insert

    // Device Master - Update

    #region Device Master - Update

    public string GetDeviceUpdate(MasterBEL masterbel)
    {
        try
        {
            SqlCommand MyCommand = new SqlCommand("update tbl_device_mst set device_name=@device_name,device_desc=@device_desc,updated_datetime=@device_updatedatetime,updated_by=@device_updatedby where device_id=@device_id", MySqlConnection);

            MyCommand.Parameters.AddWithValue("@device_name", masterbel.DeviceName);
            MyCommand.Parameters.AddWithValue("@device_desc", masterbel.DeviceDescription);
            MyCommand.Parameters.AddWithValue("@device_updatedatetime", masterbel.DeviceUpdatedDateTime);
            MyCommand.Parameters.AddWithValue("@device_updatedby", masterbel.DeviceUpdatedBy);
            MyCommand.Parameters.AddWithValue("@device_id", masterbel.DeviceId);

            //MyCommand.Parameters.Add(new SqlParameter("@devicename", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@devicename"].Value = masterbel.DeviceName;

            //MyCommand.Parameters.Add(new SqlParameter("@devicedesc", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@devicedesc"].Value = masterbel.DeviceDescription;

            //MyCommand.Parameters.Add(new SqlParameter("@updatedatetime", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updatedatetime"].Value = masterbel.DeviceUpdatedDateTime;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_by", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_by"].Value = masterbel.DeviceUpdatedBy;

            //MyCommand.Parameters.Add(new SqlParameter("@deviceid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@deviceid"].Value = masterbel.DeviceId;

            MyCommand.Connection.Open();

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string update = Convert.ToString(1);
            return update;
        }
        catch
        {
            throw;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }
    #endregion Device Master - Update

    // Device Master - Grid View Loading

    #region Device Master - Grid View Loading

    public DataTable GetDeviceGridViewLoading(MasterBEL masterbel)
    {
        try
        {
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select device_id,device_name,device_desc from tbl_device_mst order by device_id asc", MySqlConnection);

            MySqlConnection.Open();

            DataSet dsdevicegridview = new DataSet();

            MyDataAdapter.Fill(dsdevicegridview);

            DataTable MyDeviceGridView = new DataTable();

            MyDeviceGridView = dsdevicegridview.Tables[0];

            MySqlConnection.Close();

            return MyDeviceGridView;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Device Master - Grid View Loading


    // ----------------------------------------- Location Master --------------------------------------------------

    // Location Master - Insert

    #region Location Master - Insert

    public string LocationInsert(MasterBEL masterbel)
    {

        try
        {
            SqlCommand MyCommand = new SqlCommand("Insert into tbl_room_mst (room_desc,room_code,room_dept_id,updated_datetime,updated_by)" + "values(@room_desc,@room_code,@room_dept_id,@room_updatedatetime,@room_updatedby)", MySqlConnection);

            MyCommand.Parameters.AddWithValue("@room_desc", masterbel.LocationDescription);
            MyCommand.Parameters.AddWithValue("@room_code", masterbel.LocationCode);
            MyCommand.Parameters.AddWithValue("@room_dept_id", masterbel.LocationDepartmentId);
            MyCommand.Parameters.AddWithValue("@room_updatedatetime", masterbel.LocationUpdatedDateTime);
            MyCommand.Parameters.AddWithValue("@room_updatedby", masterbel.LocationUpdatedBy);

            //MyCommand.Parameters.Add(new SqlParameter("@room_desc", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@room_desc"].Value = masterbel.LocationDescription;

            //MyCommand.Parameters.Add(new SqlParameter("@room_code", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@room_code"].Value = masterbel.LocationCode;

            //MyCommand.Parameters.Add(new SqlParameter("@room_dept_id", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@room_dept_id"].Value = masterbel.LocationDepartmentId;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_datetime", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_datetime"].Value = masterbel.LocationUpdatedDateTime;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_by", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_by"].Value = masterbel.LocationUpdatedBy;



            //MyCommand.Connection.Open();

            //MyCommand.ExecuteNonQuery();

            //MyCommand.Connection.Close();

            //DataSet dsinsert = new DataSet();

            //DataTable MySelectDataTable = new DataTable();

            //MySelectDataTable = dsinsert.Tables[0];

            //return MySelectDataTable;

            MyCommand.Connection.Open();

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string insert = Convert.ToString(1);
            return insert;

            //MyCommand.Connection.Open();
            //SqlDataReader dr = MyCommand.ExecuteReader(CommandBehavior.CloseConnection);
            //MyCommand.Connection.Close();
            //DataTable dt = new DataTable();
            //dt.Load(dr);


            //return dt;

        }
        catch
        {

            throw;
        }
        finally
        {
            MySqlConnection.Close();

            //MyInsertDataTable = null;
            //dCmd.Dispose();
            //conn.Close();
            //conn.Dispose();
        }
    }

    #endregion Location Master - Insert

    // Location Master - Update

    #region Location Master - Update

    public string GetLocationUpdate(MasterBEL masterbel)
    {
        try
        {
            SqlCommand MyCommand = new SqlCommand("update tbl_room_mst set room_desc=@room_desc,room_code=@room_code,room_dept_id=@room_dept_id,updated_datetime=@room_updatedatetime,updated_by=@room_updatedby where room_id=@room_id", MySqlConnection);

            MyCommand.Parameters.AddWithValue("@room_desc", masterbel.LocationDescription);
            MyCommand.Parameters.AddWithValue("@room_code", masterbel.LocationCode);
            MyCommand.Parameters.AddWithValue("@room_dept_id", masterbel.LocationDepartmentId);
            MyCommand.Parameters.AddWithValue("@room_updatedatetime", masterbel.LocationUpdatedDateTime);
            MyCommand.Parameters.AddWithValue("@room_updatedby", masterbel.LocationUpdatedBy);
            MyCommand.Parameters.AddWithValue("@room_id", masterbel.LocationId);

            //MyCommand.Parameters.Add(new SqlParameter("@roomdesc", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@roomdesc"].Value = masterbel.LocationDescription;

            //MyCommand.Parameters.Add(new SqlParameter("@roomcode", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@roomcode"].Value = masterbel.LocationCode;

            //MyCommand.Parameters.Add(new SqlParameter("@roomdeptid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@roomdeptid"].Value = masterbel.LocationDepartmentId;

            //MyCommand.Parameters.Add(new SqlParameter("@roomupdatedatetime", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@roomupdatedatetime"].Value = masterbel.LocationUpdatedDateTime;

            //MyCommand.Parameters.Add(new SqlParameter("@roomupdatedby", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@roomupdatedby"].Value = masterbel.LocationUpdatedBy;

            //MyCommand.Parameters.Add(new SqlParameter("@roomid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@roomid"].Value = masterbel.LocationId;

            MyCommand.Connection.Open();

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string update = Convert.ToString(1);
            return update;
        }
        catch
        {
            throw;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }

    #endregion Location Master - Update

    // Location Master - Grid View Loading

    #region Location Master - Grid View Loading

    public DataTable GetLocationGridViewLoading(MasterBEL masterbel)
    {
        try
        {

            if (masterbel.GettingDepartmentId != 0)
            {
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select room_id,room_desc,room_code,d.department_desc,department_id from tbl_room_mst r, tbl_department_mst d where r.room_dept_id=@getting_department_id and r.room_dept_id=d.department_id order by room_id asc", MySqlConnection);

                MyDataAdapter.SelectCommand.Parameters.AddWithValue("@getting_department_id", masterbel.GettingDepartmentId);

                MySqlConnection.Open();

                DataSet dsdevicegridview = new DataSet();

                MyDataAdapter.Fill(dsdevicegridview);

                DataTable MyDeviceGridView = new DataTable();

                MyDeviceGridView = dsdevicegridview.Tables[0];

                MySqlConnection.Close();

                return MyDeviceGridView;
            }

            else
            {
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select room_id,room_desc,room_code,d.department_desc,department_id from tbl_room_mst r, tbl_department_mst d where r.room_dept_id=d.department_id order by room_id asc", MySqlConnection);

                MySqlConnection.Open();

                DataSet dsdevicegridview = new DataSet();

                MyDataAdapter.Fill(dsdevicegridview);

                DataTable MyDeviceGridView = new DataTable();

                MyDeviceGridView = dsdevicegridview.Tables[0];

                MySqlConnection.Close();

                return MyDeviceGridView;
            }



        }
        catch (Exception exmsg)
        {
            MySqlConnection.Close();
            throw new Exception("Error Occured While Retrieving Department Data From DataBase", exmsg);
        }

        finally
        {
            MySqlConnection.Close();
        }
    }

    #endregion Location Master - Grid View Loading


    // Schedule Master - Grid View Loading

    #region Schedule Master - Grid View Loading

    public DataTable GetScheduleGridViewLoading(MasterBEL masterbel)
    {
        try
        {

            //if (masterbel.GettingDepartmentId != 0)
            //{
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select t.*, d.department_desc,d.department_id,r.room_code from tbl_schedule_tnx t,tbl_department_mst d, tbl_room_mst r where t.schedule_dept_id=d.department_id and t.schedule_room_id=r.room_id", MySqlConnection);

               // MyDataAdapter.SelectCommand.Parameters.AddWithValue("@getting_department_id", masterbel.GettingDepartmentId);

                MySqlConnection.Open();

                DataSet dsdevicegridview = new DataSet();

                MyDataAdapter.Fill(dsdevicegridview);

                DataTable MyDeviceGridView = new DataTable();

                MyDeviceGridView = dsdevicegridview.Tables[0];

                MySqlConnection.Close();

                return MyDeviceGridView;
           // }

            //else
            //{
            //    SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select room_id,room_desc,room_code,d.department_desc,department_id from tbl_room_mst r, tbl_department_mst d where r.room_dept_id=d.department_id order by room_id asc", MySqlConnection);

            //    MySqlConnection.Open();

            //    DataSet dsdevicegridview = new DataSet();

            //    MyDataAdapter.Fill(dsdevicegridview);

            //    DataTable MyDeviceGridView = new DataTable();

            //    MyDeviceGridView = dsdevicegridview.Tables[0];

            //    MySqlConnection.Close();

            //    return MyDeviceGridView;
            //}



        }
        catch (Exception exmsg)
        {
            MySqlConnection.Close();
            throw new Exception("Error Occured While Retrieving Department Data From DataBase", exmsg);
        }

        finally
        {
            MySqlConnection.Close();
        }
    }

    #endregion Location Master - Grid View Loading

    // Schedule Master - Grid View Loading

    #region Schedule Master - Grid View Loading

    public DataTable GetScheduleLoading(MasterBEL masterbel)
    {
        try
        {

            //if (masterbel.GettingDepartmentId != 0)
            //{
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select t.*, d.department_desc,d.department_id,r.room_code from tbl_schedule_tnx t,tbl_department_mst d, tbl_room_mst r where t.schedule_dept_id=d.department_id and t.schedule_room_id=r.room_id and t.schedule_id=@schedule_id ", MySqlConnection);

            MyDataAdapter.SelectCommand.Parameters.AddWithValue("@schedule_id",masterbel.ScheduleId1);

            MySqlConnection.Open();

            DataSet dsdevicegridview = new DataSet();

            MyDataAdapter.Fill(dsdevicegridview);

            DataTable MyDeviceGridView = new DataTable();

            MyDeviceGridView = dsdevicegridview.Tables[0];

            MySqlConnection.Close();

            return MyDeviceGridView;
            // }

            //else
            //{
            //    SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select room_id,room_desc,room_code,d.department_desc,department_id from tbl_room_mst r, tbl_department_mst d where r.room_dept_id=d.department_id order by room_id asc", MySqlConnection);

            //    MySqlConnection.Open();

            //    DataSet dsdevicegridview = new DataSet();

            //    MyDataAdapter.Fill(dsdevicegridview);

            //    DataTable MyDeviceGridView = new DataTable();

            //    MyDeviceGridView = dsdevicegridview.Tables[0];

            //    MySqlConnection.Close();

            //    return MyDeviceGridView;
            //}



        }
        catch (Exception exmsg)
        {
            MySqlConnection.Close();
            throw new Exception("Error Occured While Retrieving Department Data From DataBase", exmsg);
        }

        finally
        {
            MySqlConnection.Close();
        }
    }

    #endregion Location Master - Grid View Loading


    // ------------------------------------------- Terminal Master ----------------------------------------------------

    // Terminal Master - Insert

    #region Terminal Master - Insert

    public string TerminalInsert(MasterBEL masterbel)
    {

        try
        {
            SqlCommand MyCommand = new SqlCommand("Insert into tbl_terminal_mst (terminal_desc,terminal_ip,terminal_dept_id,terminal_room_id,terminal_type_id,updated_datetime,updated_by,terminal_autologin_status,terminal_username,terminal_password)" + "values(@terminal_desc,@terminal_ip,@terminal_dept_id,@terminal_room_id,@terminal_type_id,@terminal_updatedatetime,@terminal_updatedby,@terminal_autologin_status,@terminal_username,@terminal_password)", MySqlConnection);

            MyCommand.Parameters.AddWithValue("@terminal_desc", masterbel.TerminalDescription);
            MyCommand.Parameters.AddWithValue("@terminal_ip", masterbel.TerminalIp);
            MyCommand.Parameters.AddWithValue("@terminal_dept_id", masterbel.TerminalDepartmentId);
            MyCommand.Parameters.AddWithValue("@terminal_room_id", masterbel.TerminalRoomId);
            MyCommand.Parameters.AddWithValue("@terminal_type_id", masterbel.TerminalTypeId);
            MyCommand.Parameters.AddWithValue("@terminal_updatedatetime", masterbel.TerminalUpdatedDateTime);
            MyCommand.Parameters.AddWithValue("@terminal_updatedby", masterbel.TerminalUpdatedBy);

            MyCommand.Parameters.AddWithValue("@terminal_autologin_status", masterbel.AutoLoginStatus);
            MyCommand.Parameters.AddWithValue("@terminal_username", masterbel.AutoLoginUserName);
            MyCommand.Parameters.AddWithValue("@terminal_password", masterbel.AutoLoginPassword);

            //MyCommand.Parameters.Add(new SqlParameter("@terminal_desc", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminal_desc"].Value = masterbel.TerminalDescription;

            //MyCommand.Parameters.Add(new SqlParameter("@terminal_ip", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminal_ip"].Value = masterbel.TerminalIp;

            //MyCommand.Parameters.Add(new SqlParameter("@terminal_dept_id", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminal_dept_id"].Value = masterbel.TerminalDepartmentId;

            //MyCommand.Parameters.Add(new SqlParameter("@terminal_room_id", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminal_room_id"].Value = masterbel.TerminalRoomId;

            //MyCommand.Parameters.Add(new SqlParameter("@terminal_type_id", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminal_type_id"].Value = masterbel.TerminalTypeId;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_datetime", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_datetime"].Value = masterbel.TerminalUpdatedDateTime;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_by", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_by"].Value = masterbel.TerminalUpdatedBy;


            MyCommand.Connection.Open();

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string insert = Convert.ToString(1);
            return insert;

        }
        catch
        {

            throw;
        }
        finally
        {
            MySqlConnection.Close();

        }
    }

    #endregion Terminal Master - Insert

    // Terminal Master - Update

    #region Terminal Master - Update

    public string GetTerminalUpdate(MasterBEL masterbel)
    {
        try
        {
            SqlCommand MyCommand = new SqlCommand("update tbl_terminal_mst set terminal_desc=@terminal_desc,terminal_ip=@terminal_ip,terminal_dept_id=@terminal_dept_id,terminal_room_id=@terminal_room_id,terminal_type_id=@terminal_type_id,updated_datetime=@terminal_updatedatetime,updated_by=@terminal_updatedby,terminal_autologin_status=@terminal_autologin_status, terminal_username=@terminal_username,terminal_password=@terminal_password where terminal_id=@terminal_id", MySqlConnection);

            MyCommand.Parameters.AddWithValue("@terminal_desc", masterbel.TerminalDescription);
            MyCommand.Parameters.AddWithValue("@terminal_ip", masterbel.TerminalIp);
            MyCommand.Parameters.AddWithValue("@terminal_dept_id", masterbel.TerminalDepartmentId);
            MyCommand.Parameters.AddWithValue("@terminal_room_id", masterbel.TerminalRoomId);
            MyCommand.Parameters.AddWithValue("@terminal_type_id", masterbel.TerminalTypeId);
            MyCommand.Parameters.AddWithValue("@terminal_updatedatetime", masterbel.TerminalUpdatedDateTime);
            MyCommand.Parameters.AddWithValue("@terminal_updatedby", masterbel.TerminalUpdatedBy);
            MyCommand.Parameters.AddWithValue("@terminal_id", masterbel.TerminalId);
            MyCommand.Parameters.AddWithValue("@terminal_autologin_status", masterbel.AutoLoginStatus);
            MyCommand.Parameters.AddWithValue("@terminal_username", masterbel.AutoLoginUserName);
            MyCommand.Parameters.AddWithValue("@terminal_password", masterbel.AutoLoginPassword);

            //MyCommand.Parameters.Add(new SqlParameter("@terminaldesc", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminaldesc"].Value = masterbel.TerminalDescription;

            //MyCommand.Parameters.Add(new SqlParameter("@terminalip", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminalip"].Value = masterbel.TerminalIp;

            //MyCommand.Parameters.Add(new SqlParameter("@terminaldeptid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminaldeptid"].Value = masterbel.TerminalDepartmentId;

            //MyCommand.Parameters.Add(new SqlParameter("@terminalroomid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminalroomid"].Value = masterbel.TerminalRoomId;

            //MyCommand.Parameters.Add(new SqlParameter("@terminaltypeid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminaltypeid"].Value = masterbel.TerminalTypeId;

            //MyCommand.Parameters.Add(new SqlParameter("@terminalupdatedatetime", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminalupdatedatetime"].Value = masterbel.TerminalUpdatedDateTime;

            //MyCommand.Parameters.Add(new SqlParameter("@terminalupdatedby", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminalupdatedby"].Value = masterbel.TerminalUpdatedBy;

            //MyCommand.Parameters.Add(new SqlParameter("@terminalid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@terminalid"].Value = masterbel.TerminalId;

            MyCommand.Connection.Open();

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string update = Convert.ToString(1);
            return update;
        }
        catch
        {
            throw;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }

    #endregion Terminal Master - Update

    // Terminal Master - Getting Count Terminal

    #region Terminal Master - Getting Count Terminal

    public DataTable DaoGettingCountTerminal(MasterBEL masterbel)
    {
        try
        {
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select * from tbl_terminal_mst where terminal_type_id=@terminal_type_id order by terminal_id", MySqlConnection);

            MyDataAdapter.SelectCommand.Parameters.AddWithValue("@terminal_type_id", masterbel.TerminalTypeId);

            DataSet ds = new DataSet();
            MyDataAdapter.Fill(ds);

            DataTable MyTerminalCounting = new DataTable();

            MyTerminalCounting = ds.Tables[0];

            return MyTerminalCounting;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Room Data From DataBase", exmsg);
        }

    }

    #endregion Terminal Master - Getting Count Terminal

    // Terminal Master - Room Code 

    #region Terminal Master - Room Code

    public DataTable DaoGetRoomCode()
    {
        try
        {
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select room_id,room_code from tbl_room_mst order by room_id asc", MySqlConnection);

            DataSet ds = new DataSet();
            MyDataAdapter.Fill(ds);

            DataTable MySelectDataTable = new DataTable();

            MySelectDataTable = ds.Tables[0];

            return MySelectDataTable;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Room Data From DataBase", exmsg);
        }

    }

    #endregion Terminal Master - Room Code

    // Terminal Master - Room Code 

    #region Terminal Master - Room Code

    public DataTable DaoGetTerminalTypeDescription()
    {
        try
        {
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select terminal_type_id,terminal_type_desc from tbl_terminal_type_mst order by terminal_type_id asc", MySqlConnection);

            DataSet ds = new DataSet();
            MyDataAdapter.Fill(ds);

            DataTable MySelectDataTable = new DataTable();

            MySelectDataTable = ds.Tables[0];

            return MySelectDataTable;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Terminal Type Data From DataBase", exmsg);
        }

    }

    #endregion Terminal Master - Terminal Type Description

    // Terminal Master - Grid View Loading

    #region Terminal Master - Grid View Loading

    public DataTable GetTerminalGridViewLoading(MasterBEL masterbel)
    {
        try
        {
            if (masterbel.GettingDepartmentId != 0)
            {
               // SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select t.terminal_id,t.terminal_desc,t.terminal_ip,d.department_desc,r.room_code,tt.terminal_type_desc,d.department_id,r.room_id,tt.terminal_type_id from  tbl_terminal_mst t,tbl_department_mst d,tbl_room_mst r,tbl_terminal_type_mst tt where t.terminal_dept_id=@getting_department_id and t.terminal_dept_id=d.department_id and t.terminal_room_id=r.room_id and t.terminal_type_id=tt.terminal_type_id order by t.terminal_id asc", MySqlConnection);
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select t.terminal_id,t.terminal_desc,t.terminal_ip,d.department_desc,r.room_code,tt.terminal_type_desc,d.department_id,r.room_id,tt.terminal_type_id,t.terminal_autologin_status,t.terminal_username,t.terminal_password from  tbl_terminal_mst t,tbl_department_mst d,tbl_room_mst r,tbl_terminal_type_mst tt where t.terminal_dept_id=@getting_department_id and t.terminal_dept_id=d.department_id and t.terminal_room_id=r.room_id and t.terminal_type_id=tt.terminal_type_id order by t.terminal_id asc", MySqlConnection);

                MyDataAdapter.SelectCommand.Parameters.AddWithValue("@getting_department_id", masterbel.GettingDepartmentId);

                MySqlConnection.Open();

                DataSet dsterminalgridview = new DataSet();

                MyDataAdapter.Fill(dsterminalgridview);

                DataTable MyTerminalGridView = new DataTable();

                MyTerminalGridView = dsterminalgridview.Tables[0];

                MySqlConnection.Close();


                return MyTerminalGridView;
            }
            else
            {
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select t.terminal_id,t.terminal_desc,t.terminal_ip,d.department_desc,r.room_code,tt.terminal_type_desc,d.department_id,r.room_id,tt.terminal_type_id,t.terminal_autologin_status,t.terminal_username,t.terminal_password from  tbl_terminal_mst t,tbl_department_mst d,tbl_room_mst r,tbl_terminal_type_mst tt where t.terminal_dept_id=d.department_id and t.terminal_room_id=r.room_id and t.terminal_type_id=tt.terminal_type_id order by t.terminal_id asc", MySqlConnection);

                MySqlConnection.Open();

                DataSet dsterminalgridview = new DataSet();

                MyDataAdapter.Fill(dsterminalgridview);

                DataTable MyTerminalGridView = new DataTable();

                MyTerminalGridView = dsterminalgridview.Tables[0];

                MySqlConnection.Close();


                return MyTerminalGridView;
            }

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Terminal Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Terminal Master - Grid View Loading

    // Terminal Master - Terminal Ip Checking - Availability

    #region Terminal Master - Terminal Ip Checking - Availability

    public DataTable GetAvailableTerminalIp(MasterBEL masterbel)
    {
        try
        {
            SqlCommand CheckTerminalIp = new SqlCommand("select * from tbl_terminal_mst where terminal_ip=@terminal_ip", MySqlConnection);
            CheckTerminalIp.Parameters.Add(new SqlParameter("@terminal_ip", SqlDbType.VarChar, 255));
            CheckTerminalIp.Parameters["@terminal_ip"].Value = masterbel.TerminalIp;

            MySqlConnection.Open();

            SqlDataReader dr = CheckTerminalIp.ExecuteReader();

            DataTable MyAvailableTerminalIp = new DataTable();

            MyAvailableTerminalIp.Load(dr);

            MySqlConnection.Close();

            return MyAvailableTerminalIp;


        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Availability Terminal Ip Data From DataBase", exmsg);
        }

    }

    #endregion Terminal Master - Terminal Ip Checking - Availability


    // Terminal Master - Retrieve Terminal Description of Type Queue Display

    #region Terminal Master - Retrieve Terminal Desc by Id
    public DataTable GetTerminalDesc()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select terminal_id, terminal_desc from tbl_terminal_mst where terminal_type_id = 4", MySqlConnection);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;
        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Terminal Description based on TypeId 5", exmsg);
        }

    }
    #endregion

    // --------------------------------------------- Department Master --------------------------------------------------

    // Department Master - Insert

    #region Department Master - Insert

    public string DepartmentInsert(MasterBEL masterbel)
    {

        try
        {
            SqlCommand MyCommand = new SqlCommand("Insert into tbl_department_mst (department_desc,updated_datetime,updated_by,department_code,department_queueno)" + "values(@department_desc,@updated_datetime,@updated_by,@department_code,@department_queueno)", MySqlConnection);

            MyCommand.Parameters.AddWithValue("@department_desc", masterbel.DepartmentDescriptions);
            MyCommand.Parameters.AddWithValue("@updated_datetime", masterbel.DepartmentUpdatedDateTime);
            MyCommand.Parameters.AddWithValue("@updated_by", masterbel.DepartmentUpdatedBy);
            MyCommand.Parameters.AddWithValue("@department_code", masterbel.DepartmentCode);
            MyCommand.Parameters.AddWithValue("@department_queueno", masterbel.DepartmentQueueNo);

            //MyCommand.Parameters.Add(new SqlParameter("@department_desc", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@department_desc"].Value = masterbel.DepartmentDescriptions;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_datetime", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_datetime"].Value = masterbel.DepartmentUpdatedDateTime;

            //MyCommand.Parameters.Add(new SqlParameter("@updated_by", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@updated_by"].Value = masterbel.DepartmentUpdatedBy;

            //MyCommand.Parameters.Add(new SqlParameter("@department_code", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@department_code"].Value = masterbel.DepartmentCode;

            //MyCommand.Parameters.Add(new SqlParameter("@department_queueno", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@department_queueno"].Value = masterbel.DepartmentQueueNo;

            MyCommand.Connection.Open();

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string insert = Convert.ToString(1);
            return insert;

        }
        catch
        {

            throw;
        }
        finally
        {
            MySqlConnection.Close();

        }
    }

    #endregion Department Master - Insert

    // Department Master - Update

    #region Department Master - Update

    public string GetDepartmentUpdate(MasterBEL masterbel)
    {
        try
        {
            SqlCommand MyCommand = new SqlCommand("update tbl_department_mst set department_desc=@department_desc,department_code=@department_code,updated_datetime=@department_updatedatetime,updated_by=@department_updatedby,department_queueno=@department_queueno where department_id=@department_id", MySqlConnection);

            MyCommand.Parameters.AddWithValue("@department_desc", masterbel.DepartmentDescriptions);
            MyCommand.Parameters.AddWithValue("@department_updatedatetime", masterbel.DepartmentUpdatedDateTime);
            MyCommand.Parameters.AddWithValue("@department_updatedby", masterbel.DepartmentUpdatedBy);
            MyCommand.Parameters.AddWithValue("@department_code", masterbel.DepartmentCode);
            MyCommand.Parameters.AddWithValue("@department_queueno", masterbel.DepartmentQueueNo);
            MyCommand.Parameters.AddWithValue("@department_id", masterbel.DepartmentId);

            //MyCommand.Parameters.Add(new SqlParameter("@departmentdesc", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@departmentdesc"].Value = masterbel.DepartmentDescriptions;

            //MyCommand.Parameters.Add(new SqlParameter("@departmentcode", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@departmentcode"].Value = masterbel.DepartmentCode;

            //MyCommand.Parameters.Add(new SqlParameter("@departmentupdatedatetime", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@departmentupdatedatetime"].Value = masterbel.DepartmentUpdatedDateTime;

            //MyCommand.Parameters.Add(new SqlParameter("@departmentupdatedby", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@departmentupdatedby"].Value = masterbel.DepartmentUpdatedBy;

            //MyCommand.Parameters.Add(new SqlParameter("@departmentid", SqlDbType.VarChar, 255));
            //MyCommand.Parameters["@departmentid"].Value = masterbel.DepartmentId;

            MyCommand.Connection.Open();

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string update = Convert.ToString(1);
            return update;
        }
        catch
        {
            throw;
        }
        finally
        {
            MySqlConnection.Close();
        }
    }

    #endregion Department Master - Update

    // Department Master - Grid View Loading

    #region Department Master - Grid View Loading

    public DataTable GetDepartmentGridViewLoading(MasterBEL masterbel)
    {
        try
        {
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select department_id,department_desc,department_code from tbl_department_mst", MySqlConnection);

            MySqlConnection.Open();

            DataSet dsdepartmentgridview = new DataSet();

            MyDataAdapter.Fill(dsdepartmentgridview);

            DataTable MyDepartmentGridView = new DataTable();

            MyDepartmentGridView = dsdepartmentgridview.Tables[0];

            MySqlConnection.Close();

            return MyDepartmentGridView;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Department Master - Grid View Loading


    // --------------------------------------------- Department Master --------------------------------------------------

    // --------------------------------------------- Image Master --------------------------------------------------

    // Image Master - Insert
    #region Image Master Insert

    public string insertnewImage(MasterBEL masterbel)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("Insert into tbl_image_mst (img_name,img_desc,img_image,updated_datetime,updated_by)" + "values(@img_name,@img_desc,@img_image,@updated_datetime,@updated_by)", MySqlConnection);
            cmd.Parameters.AddWithValue("@img_name", masterbel.ImageName);
            cmd.Parameters.AddWithValue("@img_desc", masterbel.ImageDesc);
            cmd.Parameters.AddWithValue("@img_image", masterbel.Image);
            cmd.Parameters.AddWithValue("@updated_datetime", masterbel.ImageUpdateDate);
            cmd.Parameters.AddWithValue("@updated_by", masterbel.ImageUpdatedby);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            string insert = Convert.ToString(1);
            return insert;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }
    }
    #endregion

    // Image Master - Update

    #region update Image
    public string UpdateImagebyId(MasterBEL masterbel)
    {
        try
        {
            SqlCommand MyCommand = new SqlCommand("update tbl_image_mst set img_name=@img_name,img_desc=@img_desc,img_image=@img_image,updated_datetime=@updated_datetime,updated_by=@updated_by where img_id=@img_id", MySqlConnection);
            MyCommand.Parameters.AddWithValue("@img_id", masterbel.ImageId);
            MyCommand.Parameters.AddWithValue("@img_name", masterbel.ImageName);
            MyCommand.Parameters.AddWithValue("@img_desc", masterbel.ImageDesc);
            MyCommand.Parameters.AddWithValue("@img_image", masterbel.Image);
            MyCommand.Parameters.AddWithValue("@updated_datetime", masterbel.ImageUpdateDate);
            MyCommand.Parameters.AddWithValue("@updated_by", masterbel.ImageUpdatedby);
            MyCommand.Connection.Open();

            MyCommand.ExecuteNonQuery();

            MyCommand.Connection.Close();

            string update = Convert.ToString(1);
            return update;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    // Image Master - Grid View Loading
    #region Load GridView Data
    public DataTable GetImageData()
    {
        try
        {
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("SELECT img_id,img_name,img_desc FROM tbl_image_mst", MySqlConnection);

            MySqlConnection.Open();

            DataTable MyImageGridView = new DataTable();

            MyDataAdapter.Fill(MyImageGridView);

            MySqlConnection.Close();

            return MyImageGridView;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Image Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }
    #endregion

    // --------------------------------------------- Schedule Master --------------------------------------------------

    // Schedule Master - Insert

    #region Schedule Master - Insert
    public string insertnewContents(MasterBEL masterbel)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("Insert into tbl_schedule_tnx (schedule_week,schedule_day,schedule_dept_id,schedule_room_id,schedule_session,schedule_start_time,schedule_end_time,updated_datetime,updated_by)" +
                "values(@schedule_week,@schedule_day,@schedule_dept_id,@schedule_room_id,@schedule_session,@schedule_start_time,@schedule_end_time,@updated_datetime,@updated_by)", MySqlConnection);
            //cmd.Parameters.AddWithValue("@content_id", masterbel.ImageName);
            cmd.Parameters.AddWithValue("@schedule_week", masterbel.ScheduleWeek);
            cmd.Parameters.AddWithValue("@schedule_day", masterbel.ScheduleDay);
            cmd.Parameters.AddWithValue("@schedule_dept_id", masterbel.ScheduleDeptid);
            cmd.Parameters.AddWithValue("@schedule_room_id", masterbel.ScheduleRoomId);
            //cmd.Parameters.AddWithValue("@schedule_room_code", masterbel.ScheduleRoomCode);
            cmd.Parameters.AddWithValue("@schedule_session", masterbel.ScheduleSession);
            cmd.Parameters.AddWithValue("@schedule_start_time", masterbel.ScheduleStartTime);
            cmd.Parameters.AddWithValue("@schedule_end_time", masterbel.ScheduleEndTime);
            cmd.Parameters.AddWithValue("@updated_datetime", masterbel.ScheduleUpdateDateTime);
            cmd.Parameters.AddWithValue("@updated_by", masterbel.ScheduleUpdatedBy);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            string insert = Convert.ToString(1);
            return insert;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }
    }
    #endregion


    #region update Image
    public string UpdateSchedulebyId(MasterBEL masterbel)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("update tbl_schedule_tnx set schedule_week=@schedule_week, schedule_day=@schedule_day,schedule_dept_id=@schedule_dept_id, schedule_room_id=@schedule_room_id, schedule_session=@schedule_session, schedule_start_time=@schedule_start_time, schedule_end_time=@schedule_end_time,updated_datetime=@updated_datetime, updated_by=@updated_by where schedule_id=@schedule_id", MySqlConnection);

            cmd.Parameters.AddWithValue("@schedule_week", masterbel.ScheduleWeek);
            cmd.Parameters.AddWithValue("@schedule_day", masterbel.ScheduleDay);
            cmd.Parameters.AddWithValue("@schedule_dept_id", masterbel.ScheduleDeptid);
            cmd.Parameters.AddWithValue("@schedule_room_id", masterbel.ScheduleRoomId);
            //cmd.Parameters.AddWithValue("@schedule_room_code", masterbel.ScheduleRoomCode);
            cmd.Parameters.AddWithValue("@schedule_session", masterbel.ScheduleSession);
            cmd.Parameters.AddWithValue("@schedule_start_time", masterbel.ScheduleStartTime);
            cmd.Parameters.AddWithValue("@schedule_end_time", masterbel.ScheduleEndTime);
            cmd.Parameters.AddWithValue("@updated_datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@updated_by", "admin");
            cmd.Parameters.AddWithValue("@schedule_id", masterbel.ScheduleId);
            cmd.Connection.Open();

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();

            string update = Convert.ToString(1);
            return update;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
            {
                
            //cmd.Connection.Close();
            }

    }
    #endregion

    #region update Schedule
    public string UpdateSchedulebyIdDisplay(MasterBEL masterbel)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("update tbl_schedule_tnx set schedule_week=@schedule_week, schedule_day=@schedule_day,schedule_dept_id=@schedule_dept_id, schedule_room_id=@schedule_room_id, schedule_session=@schedule_session, schedule_start_time=@schedule_start_time, schedule_end_time=@schedule_end_time,updated_datetime=@updated_datetime, updated_by=@updated_by where schedule_id=@schedule_id", MySqlConnection);

            cmd.Parameters.AddWithValue("@schedule_week", masterbel.ScheduleWeek);
            cmd.Parameters.AddWithValue("@schedule_day", masterbel.ScheduleDay);
            cmd.Parameters.AddWithValue("@schedule_dept_id", masterbel.ScheduleDeptid);
            cmd.Parameters.AddWithValue("@schedule_room_id", masterbel.ScheduleRoomId);
            //cmd.Parameters.AddWithValue("@schedule_room_code", masterbel.ScheduleRoomCode);
            cmd.Parameters.AddWithValue("@schedule_session", masterbel.ScheduleSession);
            cmd.Parameters.AddWithValue("@schedule_start_time", masterbel.ScheduleStartTime);
            cmd.Parameters.AddWithValue("@schedule_end_time", masterbel.ScheduleEndTime);
            cmd.Parameters.AddWithValue("@updated_datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@updated_by", "admin");
            cmd.Parameters.AddWithValue("@schedule_id", masterbel.ScheduleId1);
            cmd.Connection.Open();

            cmd.ExecuteNonQuery();

            cmd.Connection.Close();

            string update = Convert.ToString(1);
            return update;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {

            //cmd.Connection.Close();
        }

    }
    #endregion


    // --------------------------------------------- Content Master --------------------------------------------------

    // Content Master - Insert

    #region Content Master - Insert
    public string insertnewContent(MasterBEL masterbel)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("Insert into tbl_content_mst (content_name,content_desc,content_text,content_starttime,content_endtime,content_day,content_terminal_id,content_updated_by,content_updated_datetime,content_order_id,content_active)" +
                "values(@content_name,@content_desc,@content_text,@content_starttime,@content_endtime,@content_day,@content_terminal_id,@content_updated_by,@content_updated_datetime,@content_order_id,@content_active)", MySqlConnection);
            //cmd.Parameters.AddWithValue("@content_id", masterbel.ImageName);
            cmd.Parameters.AddWithValue("@content_name", masterbel.ContentName);
            cmd.Parameters.AddWithValue("@content_desc", masterbel.ContentDesc);
            cmd.Parameters.AddWithValue("@content_text", masterbel.ContentText);
            cmd.Parameters.AddWithValue("@content_starttime", masterbel.ContentStartTime);
            cmd.Parameters.AddWithValue("@content_endtime", masterbel.ContentEndTime);
            cmd.Parameters.AddWithValue("@content_day", masterbel.ContentDay);
            cmd.Parameters.AddWithValue("@content_terminal_id", masterbel.ContentTerminalId);
            cmd.Parameters.AddWithValue("@content_updated_by", masterbel.ContentUpdateBy);
            cmd.Parameters.AddWithValue("@content_updated_datetime", masterbel.ContentUpdateDateTime);
            cmd.Parameters.AddWithValue("@content_order_id", masterbel.ContentOrderId);
            cmd.Parameters.AddWithValue("@content_active", masterbel.ContentActive);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            string insert = Convert.ToString(1);
            return insert;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
        }
    }
    #endregion

    // Content Master - Update

    #region Content Master - Update

    public string UpdateContentbyId(MasterBEL masterbel)
    {
        try
        {

            SqlCommand cmd = new SqlCommand("update tbl_content_mst set content_name=@content_name,content_desc=@content_desc,content_text=@content_text,content_starttime=@content_starttime,content_endtime=@content_endtime,content_day=@content_day,content_terminal_id=@content_terminal_id,content_updated_by=@content_updated_by,content_updated_datetime=@content_updated_datetime,content_order_id=@content_order_id,content_active=@content_active where content_id=@content_id", MySqlConnection);
            cmd.Parameters.AddWithValue("@content_id", masterbel.ContentId);
            cmd.Parameters.AddWithValue("@content_name", masterbel.ContentName);
            cmd.Parameters.AddWithValue("@content_desc", masterbel.ContentDesc);
            cmd.Parameters.AddWithValue("@content_text", masterbel.ContentText);
            cmd.Parameters.AddWithValue("@content_starttime", masterbel.ContentStartTime);
            cmd.Parameters.AddWithValue("@content_endtime", masterbel.ContentEndTime);
            cmd.Parameters.AddWithValue("@content_day", masterbel.ContentDay);
            cmd.Parameters.AddWithValue("@content_terminal_id", masterbel.ContentTerminalId);
            cmd.Parameters.AddWithValue("@content_updated_by", masterbel.ContentUpdateBy);
            cmd.Parameters.AddWithValue("@content_updated_datetime", masterbel.ContentUpdateDateTime);
            cmd.Parameters.AddWithValue("@content_order_id", masterbel.ContentOrderId);
            cmd.Parameters.AddWithValue("@content_active", masterbel.ContentActive);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            string update = Convert.ToString(1);
            return update;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    // Content Master - Content Grid View Loading

    #region Content Master - Grid View Loading

    public DataTable GetContentData()
    {
        try
        {
            SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select terminal_desc, content_id, content_text, content_order_id,content_starttime from tbl_content_mst t1 inner join tbl_terminal_mst t2 on t1.content_terminal_id = t2.terminal_id ", MySqlConnection);

            MySqlConnection.Open();

            DataTable MyContentGridView = new DataTable();

            MyDataAdapter.Fill(MyContentGridView);

            MySqlConnection.Close();

            return MyContentGridView;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Content Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion

    // Content Master - GetContentbyId

    #region Get Content by contentid
    public DataTable GetContentbyId(int contentId)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select content_id, content_name,content_desc,content_text,content_starttime,content_endtime,content_day,content_terminal_id,content_updated_by,content_updated_datetime,content_order_id,content_active from tbl_content_mst where content_id=@content_id", MySqlConnection);
            cmd.Parameters["@content_id"].Value = contentId;

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);

            MySqlConnection.Close();

            return dt;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving content From DataBase", exmsg);
        }

        finally
        {

        }
    }
    #endregion

    // --------------------------------------------- Queue Information in Admin Panel --------------------------------------------------

    #region Get TotalServingQueueCount by Departmentid

    public string GetServingQueueCountbyDept(int departmentid)
    {
        string totalServingQueueCount = null;
        try
        {
            SqlCommand cmd = new SqlCommand("select Count(queu_visit_tnxid) as TotalServingQueueCount from tbl_queue_tnx where queue_status_id=2 and queue_department_id=@departmentId and cast(queue_datetime as date) = cast(getdate() as date) group by queue_status_id", MySqlConnection);
            cmd.Parameters.AddWithValue("@departmentId", departmentid);
            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            MySqlConnection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalServingQueueCount = dt.Rows[i]["TotalServingQueueCount"].ToString();
            }
            return totalServingQueueCount;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region Get TotalServingQueueCount for All Departments

    public string GetServingQueueCount()
    {
        string totalServingQueueCount1 = null;
        try
        {
            SqlCommand cmd = new SqlCommand("select Count(queu_visit_tnxid) as TotalCount from tbl_queue_tnx where queue_status_id=2 and cast(queue_datetime as date) = cast(getdate() as date) group by queue_status_id", MySqlConnection);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            MySqlConnection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalServingQueueCount1 = dt.Rows[i]["TotalCount"].ToString();
            }

            return totalServingQueueCount1;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region Get TotalWaitingQueueCount by Departmentid

    public string GetWaitingQueueCountbyDept(int departmentid)
    {
        string totalWaitingQueueCount = null;
        try
        {
            SqlCommand cmd = new SqlCommand("select Count(queu_visit_tnxid) as TotalServingQueueCount from tbl_queue_tnx where queue_status_id=1 and queue_department_id=@departmentId and cast(queue_datetime as date) = cast(getdate() as date) group by queue_status_id", MySqlConnection);
            cmd.Parameters.AddWithValue("@departmentId", departmentid);
            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            MySqlConnection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalWaitingQueueCount = dt.Rows[i]["TotalServingQueueCount"].ToString();
            }
            return totalWaitingQueueCount;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region Get TotalWaitingQueueCount for All Departments

    public string GetWaitingQueueCount()
    {
        string totalWaitingQueueCount1 = null;
        try
        {
            SqlCommand cmd = new SqlCommand("select Count(queu_visit_tnxid) as TotalCount from tbl_queue_tnx where queue_status_id=1 and cast(queue_datetime as date) = cast(getdate() as date) group by queue_status_id", MySqlConnection);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            MySqlConnection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalWaitingQueueCount1 = dt.Rows[i]["TotalCount"].ToString();
            }

            return totalWaitingQueueCount1;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region Get TotalPendingQueueCount by Departmentid

    public string GetPendingQueueCountbyDept(int departmentid)
    {
        string totalPendingQueueCount = null;
        try
        {
            SqlCommand cmd = new SqlCommand("select Count(c.visit_queue_no_show) as TotalPendingQueueCount from tbl_queueplan_dtl p,tbl_customervisit_tnx c,tbl_department_mst d where CONVERT(DATE, plan_datetime) = CONVERT(DATE, GETDATE())and plan_transfer_id IS NULL and p.plan_visit_id=c.visit_tnx_id and p.plan_department_id=d.department_id and p.plan_department_id=@departmentId;", MySqlConnection);
            cmd.Parameters.AddWithValue("@departmentId", departmentid);
            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            MySqlConnection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalPendingQueueCount = dt.Rows[i]["TotalPendingQueueCount"].ToString();
            }
            return totalPendingQueueCount;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region Get TotalPendingQueueCount for All Departments

    public string GetPendingQueueCount()
    {
        string totalPendingQueueCount1 = null;
        try
        {
            SqlCommand cmd = new SqlCommand("select Count(c.visit_queue_no_show) as TotalPendingQueueCount from tbl_queueplan_dtl p,tbl_customervisit_tnx c,tbl_department_mst d where CONVERT(DATE, plan_datetime) = CONVERT(DATE, GETDATE())and plan_transfer_id IS NULL and p.plan_visit_id=c.visit_tnx_id and p.plan_department_id=d.department_id;", MySqlConnection);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            MySqlConnection.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                totalPendingQueueCount1 = dt.Rows[i]["TotalPendingQueueCount"].ToString();
            }

            return totalPendingQueueCount1;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region Load Serving Queue Grid View by DepartmentId

    public DataTable LoadServingGridbyDeptId(int departmentId)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select cv1.visit_customer_name,cv1.visit_queue_no_show,dep1.department_desc from tbl_department_mst dep1 inner join tbl_queue_tnx queue1 on dep1.department_id = queue1.queue_department_id inner join tbl_customervisit_tnx cv1 on queue1.queu_visit_tnxid = cv1.visit_tnx_id  where (dep1.department_id = @departmentId) and cast(queue_datetime as date) = cast(getdate() as date) and (queue1.queue_status_id=2)", MySqlConnection);
            cmd.Parameters.AddWithValue("@departmentId", departmentId);
            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            MySqlConnection.Close();

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Missed Queue Grid View by DepartmentId

    public DataTable LoadMissedGridbyDeptId(int departmentId)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select cv1.visit_customer_name,cv1.visit_queue_no_show,dep1.department_desc from tbl_department_mst dep1 inner join tbl_queue_tnx queue1 on dep1.department_id = queue1.queue_department_id inner join tbl_customervisit_tnx cv1 on queue1.queu_visit_tnxid = cv1.visit_tnx_id  where (dep1.department_id = @departmentId) and cast(queue_datetime as date) = cast(getdate() as date) and (queue1.queue_status_id=4)", MySqlConnection);
            cmd.Parameters.AddWithValue("@departmentId", departmentId);
            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            MySqlConnection.Close();

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Serving Queue Grid View for All Departments

    public DataTable LoadServingGrid()
    {
        try
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select cv1.visit_customer_name,cv1.visit_queue_no_show,dep1.department_desc from tbl_department_mst dep1 inner join tbl_queue_tnx queue1 on dep1.department_id = queue1.queue_department_id inner join tbl_customervisit_tnx cv1 on queue1.queu_visit_tnxid = cv1.visit_tnx_id  where dep1.department_id in (select department_id from tbl_department_mst) and cast(queue_datetime as date) = cast(getdate() as date) and queue1.queue_status_id=2", MySqlConnection);
                MySqlConnection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dr);
                MySqlConnection.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Missed Queue Grid View for All Departments

    public DataTable LoadMissedGrid()
    {
        try
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select cv1.visit_customer_name,cv1.visit_queue_no_show,dep1.department_desc from tbl_department_mst dep1 inner join tbl_queue_tnx queue1 on dep1.department_id = queue1.queue_department_id inner join tbl_customervisit_tnx cv1 on queue1.queu_visit_tnxid = cv1.visit_tnx_id  where dep1.department_id in (select department_id from tbl_department_mst) and cast(queue_datetime as date) = cast(getdate() as date) and queue1.queue_status_id=4", MySqlConnection);
                MySqlConnection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dr);
                MySqlConnection.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion


    #region Load Waiting Queue Grid View by DepartmentId

    public DataTable LoadWaitingGridbyDeptId(int departmentId)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select cv1.visit_customer_name,cv1.visit_queue_no_show,dep1.department_desc from tbl_department_mst dep1 inner join tbl_queue_tnx queue1 on dep1.department_id = queue1.queue_department_id inner join tbl_customervisit_tnx cv1 on queue1.queu_visit_tnxid = cv1.visit_tnx_id  where dep1.department_id = @departmentId and cast(queue_datetime as date) = cast(getdate() as date) and queue1.queue_status_id=1", MySqlConnection);
            cmd.Parameters.AddWithValue("@departmentId", departmentId);
            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            MySqlConnection.Close();

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Waiting Queue Grid View for All Departments

    public DataTable LoadWaitingGrid()
    {
        try
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select cv1.visit_customer_name,cv1.visit_queue_no_show,dep1.department_desc from tbl_department_mst dep1 inner join tbl_queue_tnx queue1 on dep1.department_id = queue1.queue_department_id inner join tbl_customervisit_tnx cv1 on queue1.queu_visit_tnxid = cv1.visit_tnx_id  where dep1.department_id in (select department_id from tbl_department_mst) and cast(queue_datetime as date) = cast(getdate() as date) and queue1.queue_status_id=1", MySqlConnection);
                MySqlConnection.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();

                dt.Load(dr);
                MySqlConnection.Close();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Pending Queue Grid View by DepartmentId

    public DataTable LoadPendingGridbyDeptId(int departmentId)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select c.visit_customer_name,c.visit_queue_no_show,d.department_desc from tbl_queueplan_dtl p,tbl_customervisit_tnx c,tbl_department_mst d where CONVERT(DATE, plan_datetime) = CONVERT(DATE, GETDATE())and plan_transfer_id IS NULL and p.plan_visit_id=c.visit_tnx_id and p.plan_department_id=d.department_id and p.plan_department_id=@departmentId;", MySqlConnection);
            cmd.Parameters.AddWithValue("@departmentId", departmentId);
            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            MySqlConnection.Close();

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Pending Queue Grid View for All Departments

    public DataTable LoadPendingGrid()
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select c.visit_customer_name,c.visit_queue_no_show,d.department_desc from tbl_queueplan_dtl p,tbl_customervisit_tnx c,tbl_department_mst d where CONVERT(DATE, plan_datetime) = CONVERT(DATE, GETDATE())and plan_transfer_id IS NULL and p.plan_visit_id=c.visit_tnx_id and p.plan_department_id=d.department_id order by p.plan_department_id asc;", MySqlConnection);
            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            MySqlConnection.Close();

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    // Department Master - AvgDept

    #region Report Total Missed - Avg

    public DataTable GetAvgDept(MasterBEL masterbel)
    {
        try
        {

            // SqlCommand cmd = new SqlCommand("select c.visit_queue_no_show as Queue_Number,u.user_login as User_Name,d.department_desc as Doctor_Name , CAST((q.queue_wait_endtime-q.queue_wait_starttime)as time(0)) as  'WaitingTime', CAST((q.queue_serv_endtime - q.queue_serv_starttime)as time(0)) as 'ServicingTime' from tbl_queue_tnx q, tbl_user_mst u, tbl_customervisit_tnx c, tbl_department_mst d where cast(q.queue_datetime as date) = @date and q.queu_visit_tnxid=c.visit_tnx_id and q.queue_servuser_id=u.user_id and q.queue_department_id=d.department_id order by d.department_desc", MySqlConnection);
            SqlCommand cmd = new SqlCommand("select department_id,department_desc from tbl_department_mst where department_id BETWEEN 1 and 20", MySqlConnection);


            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Department Master - Get Dept

    // Department Master - Avg

    #region Report Total Missed - Avg

    public DataTable GetAvg(MasterBEL masterbel)
    {
        try
        {

            SqlCommand cmd = new SqlCommand("select TOP 1 session_user_logintime from tbl_usersession_dtl where session_user_deaprtment_id=@dept and cast(session_user_logintime as date)=@date ", MySqlConnection);
           // SqlCommand cmd = new SqlCommand("SELECT CAST(CAST( AVG( CAST( (queue_serv_endtime - queue_serv_starttime) AS DECIMAL( 18, 6 ) ) ) AS DATETIME )AS TIME(0)) FROM tbl_queue_tnx where cast(queue_datetime as date)=@date and queue_department_id=@dept", MySqlConnection);


            cmd.Parameters.AddWithValue("@date", masterbel.AvgDateTime);
            cmd.Parameters.AddWithValue("@dept", masterbel.AvgDeptId);
            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Department Master - Get Dept Avg


    // Department Master - Grid View Loading

    #region Report Total Missed - Grid View Loading

    public DataTable GetReportTotalGridViewLoading(MasterBEL masterbel)
    {
        try
        {
            
            // SqlCommand cmd = new SqlCommand("select c.visit_queue_no_show as Queue_Number,u.user_login as User_Name,d.department_desc as Doctor_Name , CAST((q.queue_wait_endtime-q.queue_wait_starttime)as time(0)) as  'WaitingTime', CAST((q.queue_serv_endtime - q.queue_serv_starttime)as time(0)) as 'ServicingTime' from tbl_queue_tnx q, tbl_user_mst u, tbl_customervisit_tnx c, tbl_department_mst d where cast(q.queue_datetime as date) = @date and q.queu_visit_tnxid=c.visit_tnx_id and q.queue_servuser_id=u.user_id and q.queue_department_id=d.department_id order by d.department_desc", MySqlConnection);
            SqlCommand cmd = new SqlCommand("select visit_customer_id as UHID,visit_customer_name as Patient,visit_queue_no_show as QNumber,visit_tnx_id,visit_datetime as RegTime,customer_appointment_time as AppointmenTime,consulting_status from tbl_customervisit_tnx where cast(visit_datetime as date) between @date and @endate", MySqlConnection);

            cmd.Parameters.AddWithValue("@date", masterbel.DeviceUpdatedDateTime);
            cmd.Parameters.AddWithValue("@endate", masterbel.DeviceUpdatedDateTimeTo);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;

            //SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select c.visit_queue_no_show,u.user_login,d.department_desc,CAST((q.queue_wait_endtime-q.queue_wait_starttime)as time(0)) 'Waiting Time',CAST((q.queue_serv_endtime - q.queue_serv_starttime)as time(0)) 'Servicing Time' from tbl_queue_tnx q, tbl_user_mst u, tbl_customervisit_tnx c, tbl_department_mst d where cast(q.queue_datetime as date) = cast(getdate() as date) and q.queu_visit_tnxid=c.visit_tnx_id and q.queue_servuser_id=u.user_id and q.queue_department_id=d.department_id order by d.department_desc", MySqlConnection);

            //cmd.Parameters.AddWithValue("@content_updated_datetime", masterbel.ContentUpdateDateTime);
            //MySqlConnection.Open();

            //DataSet dsdepartmentgridview = new DataSet();

            //MyDataAdapter.Fill(dsdepartmentgridview);

            //DataTable MyDepartmentGridView = new DataTable();

            //MyDepartmentGridView = dsdepartmentgridview.Tables[0];

            //MySqlConnection.Close();

            //return MyDepartmentGridView;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Department Master - Grid View Loading


    // Department Master - Nurse

    #region Report Total Missed - Nurse

    public DataTable GetReportNurse(MasterBEL masterbel)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select d.department_desc as DoctorName ,queue_serv_starttime,queue_serv_endtime, CAST((q.queue_wait_endtime-q.queue_wait_starttime)as time(0)) as  'WaitingTime', CAST((q.queue_serv_endtime - q.queue_serv_starttime)as time(0)) as 'ServicingTime' from tbl_queue_tnx q, tbl_department_mst d where  q.queu_visit_tnxid=@tnx and  q.queue_department_id=@deptid and d.department_id=q.queue_department_id", MySqlConnection);
            //SqlCommand cmd = new SqlCommand("select visit_customer_id,visit_customer_name,visit_queue_no_show,visit_tnx_id from tbl_customervisit_tnx where cast(visit_datetime as date)=@date", MySqlConnection);

            cmd.Parameters.AddWithValue("@tnx", masterbel.TransferID1);
            cmd.Parameters.AddWithValue("@deptid", 15);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;


        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Department Master - Nurse


    // Department Master - Nurse Appointment

    #region Report Total Missed - Nurse Appointment

    public DataTable GetReportNurseAppointment(MasterBEL masterbel)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select d.department_desc as DoctorName ,queue_serv_starttime,queue_serv_endtime, CAST((q.queue_wait_endtime-c.customer_appointment_time)as time(0)) as  'WaitingTime', CAST((q.queue_serv_endtime - q.queue_serv_starttime)as time(0)) as 'ServicingTime' from tbl_queue_tnx q, tbl_department_mst d,tbl_customervisit_tnx c  where q.queu_visit_tnxid=c.visit_tnx_id and q.queu_visit_tnxid=@tnx and  q.queue_department_id=@deptid and d.department_id=q.queue_department_id", MySqlConnection);
            //SqlCommand cmd = new SqlCommand("select visit_customer_id,visit_customer_name,visit_queue_no_show,visit_tnx_id from tbl_customervisit_tnx where cast(visit_datetime as date)=@date", MySqlConnection);

            cmd.Parameters.AddWithValue("@tnx", masterbel.TransferID1);
            cmd.Parameters.AddWithValue("@deptid", 15);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;

            //SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select c.visit_queue_no_show,u.user_login,d.department_desc,CAST((q.queue_wait_endtime-q.queue_wait_starttime)as time(0)) 'Waiting Time',CAST((q.queue_serv_endtime - q.queue_serv_starttime)as time(0)) 'Servicing Time' from tbl_queue_tnx q, tbl_user_mst u, tbl_customervisit_tnx c, tbl_department_mst d where cast(q.queue_datetime as date) = cast(getdate() as date) and q.queu_visit_tnxid=c.visit_tnx_id and q.queue_servuser_id=u.user_id and q.queue_department_id=d.department_id order by d.department_desc", MySqlConnection);

            //cmd.Parameters.AddWithValue("@content_updated_datetime", masterbel.ContentUpdateDateTime);
            //MySqlConnection.Open();

            //DataSet dsdepartmentgridview = new DataSet();

            //MyDataAdapter.Fill(dsdepartmentgridview);

            //DataTable MyDepartmentGridView = new DataTable();

            //MyDepartmentGridView = dsdepartmentgridview.Tables[0];

            //MySqlConnection.Close();

            //return MyDepartmentGridView;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Department Master - Nurse Appointment



    // Department Master - Doctor

    #region Report Total Missed - Doctor

    public DataTable GetReportDoctor(MasterBEL masterbel)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select d.department_desc as DoctorName ,queue_serv_starttime,queue_serv_endtime, CAST((q.queue_wait_endtime-q.queue_wait_starttime)as time(0)) as  'WaitingTime', CAST((q.queue_serv_endtime - q.queue_serv_starttime)as time(0)) as 'ServicingTime' from tbl_queue_tnx q, tbl_department_mst d where  q.queu_visit_tnxid=@tnx and  q.queue_department_id!=@deptid and d.department_id=q.queue_department_id", MySqlConnection);
            //SqlCommand cmd = new SqlCommand("select visit_customer_id,visit_customer_name,visit_queue_no_show,visit_tnx_id from tbl_customervisit_tnx where cast(visit_datetime as date)=@date", MySqlConnection);

            cmd.Parameters.AddWithValue("@tnx", masterbel.TransferID1);
            cmd.Parameters.AddWithValue("@deptid", 15);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;


        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Department Master - Doctor 


    // Department Master - Doctor Appointment

    #region Report Total Missed - Doctor Appointment

    public DataTable GetReportDoctorApp(MasterBEL masterbel)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select d.department_desc as DoctorName ,queue_serv_starttime,queue_serv_endtime, CAST((q.queue_wait_endtime-c.customer_appointment_time)as time(0)) as  'WaitingTime', CAST((q.queue_serv_endtime - q.queue_serv_starttime)as time(0)) as 'ServicingTime' from tbl_queue_tnx q, tbl_department_mst d,tbl_customervisit_tnx c  where q.queu_visit_tnxid=c.visit_tnx_id and q.queu_visit_tnxid=@tnx and  q.queue_department_id!=@deptid and d.department_id=q.queue_department_id", MySqlConnection);
            //SqlCommand cmd = new SqlCommand("select visit_customer_id,visit_customer_name,visit_queue_no_show,visit_tnx_id from tbl_customervisit_tnx where cast(visit_datetime as date)=@date", MySqlConnection);

            cmd.Parameters.AddWithValue("@tnx", masterbel.TransferID1);
            cmd.Parameters.AddWithValue("@deptid", 15);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;


        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Department Master - Doctor Appointment




    // Department Master - Daily Report

    #region Report Total Missed - Daily Report

    public DataTable GetReportDailyLoading(MasterBEL masterbel)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("select c.visit_customer_id as UHID,c.visit_customer_name as PatientName,d.department_desc as DoctorName, c.visit_queue_no_show as QNumber, c.customer_appointment_time as AppointmentTime,c.visit_datetime as RegistrationTime,q.queue_serv_starttime as ServiceStartTime,q.queue_serv_endtime as ServiceEndTime from tbl_queue_tnx q, tbl_user_mst u, tbl_customervisit_tnx c, tbl_department_mst d where cast(q.queue_datetime as date) = @date and q.queu_visit_tnxid=c.visit_tnx_id and q.queue_servuser_id=u.user_id and q.queue_department_id=d.department_id order by d.department_desc", MySqlConnection);

            cmd.Parameters.AddWithValue("@date", masterbel.DeviceUpdatedDateTime);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;

            //SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select c.visit_queue_no_show,u.user_login,d.department_desc,CAST((q.queue_wait_endtime-q.queue_wait_starttime)as time(0)) 'Waiting Time',CAST((q.queue_serv_endtime - q.queue_serv_starttime)as time(0)) 'Servicing Time' from tbl_queue_tnx q, tbl_user_mst u, tbl_customervisit_tnx c, tbl_department_mst d where cast(q.queue_datetime as date) = cast(getdate() as date) and q.queu_visit_tnxid=c.visit_tnx_id and q.queue_servuser_id=u.user_id and q.queue_department_id=d.department_id order by d.department_desc", MySqlConnection);

            //cmd.Parameters.AddWithValue("@content_updated_datetime", masterbel.ContentUpdateDateTime);
            //MySqlConnection.Open();

            //DataSet dsdepartmentgridview = new DataSet();

            //MyDataAdapter.Fill(dsdepartmentgridview);

            //DataTable MyDepartmentGridView = new DataTable();

            //MyDepartmentGridView = dsdepartmentgridview.Tables[0];

            //MySqlConnection.Close();

            //return MyDepartmentGridView;

        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Department Grid View Data From DataBase", exmsg);
        }

        finally
        {

        }
    }

    #endregion Department Master - Grid View Loading




    // Getting Queue Status - Getting My Queue Number

    #region Getting Queue Status - Getting My Queue Number

    public DataTable GetDALMyQueueNumber(MasterBEL crtqueuestatusbel)
    {
        DataSet MyQueueNumber = new DataSet();
        try
        {

            SqlCommand cmd = new SqlCommand("select p.plan_datetime,v.visit_customer_id,v.visit_customer_name,m.members_firstname,r.relation_desc,d.department_desc,p.plan_transfer_id,p.unplan_transfer_id,v.visit_datetime from tbl_customervisit_tnx v,tbl_customer_dtl m,tbl_relation_mst r,tbl_queueplan_dtl p,tbl_department_mst d,tbl_customerreg_mst c where v.visit_queue_no_show=@queue_number and CONVERT(DATE,p.plan_datetime)=CONVERT(DATE, GETDATE()) and v.visit_customer_id=c.customer_id and c.customer_id=m.members_customer_id and m.members_relation_id=r.relation_id and v.visit_member_id=m.members_id and v.visit_tnx_id=p.plan_visit_id and p.plan_department_id=d.department_id order by p.plan_order_id", MySqlConnection);

            cmd.Parameters.AddWithValue("@queue_number", crtqueuestatusbel.QueueNummberShow);

            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;


        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Availability User Name Data From DataBase", exmsg);
        }

        finally
        {

        }

    }

    #endregion Getting Queue Status - Getting My Queue Number


    // Getting Queue Status - Getting My Queue Status

    #region Getting Queue Status - Getting My Queue Status

    public DataTable GetDALMyQueueStatus(MasterBEL crtqueuestatusbel)
    {
        try
        {


            SqlCommand cmd = new SqlCommand("select qs.queue_status_desc,q.queue_datetime,q.queue_serv_starttime,q.queue_serv_endtime from tbl_queuestatus_mst qs,tbl_queue_tnx q where q.queue_tnx_id=@Transfer_ID and q.queue_status_id=qs.queue_status_id", MySqlConnection);

            // cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@Transfer_ID", crtqueuestatusbel.TransferID);
            MySqlConnection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable tbl_TerminalDesc = new DataTable();

            tbl_TerminalDesc.Load(dr);

            MySqlConnection.Close();

            return tbl_TerminalDesc;
            //cmd.Parameters.AddWithValue("@date_time", crtqueuestatusbel.DateTime);

            //cmd.ExecuteNonQuery();
            //sqlad.SelectCommand = cmd;
            //sqlad.Fill(MyQueueNumber);
            //MyAvailableUserName = MyQueueNumber.Tables[0];
            //return MyAvailableUserName;

            //SqlDataReader dr = cmd.ExecuteReader();

            //dr.Read();
            ////QueueStatus = dr.GetGuid(0).ToString();
            ////dr.Close();
            //QueueStatus = dr["queue_status_desc"].ToString();
            //dr.Close();

            //return QueueStatus;



        }
        catch (Exception exmsg)
        {
            throw new Exception("Error Occured While Retrieving Availability Queue Status Data From DataBase", exmsg);
        }

        finally
        {
            //con.Close();
        }
    }

    #endregion Getting Queue Status - Getting My Queue Status


}