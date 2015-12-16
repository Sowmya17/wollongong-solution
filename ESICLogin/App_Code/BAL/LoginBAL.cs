using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for LoginBAL
/// </summary>
public class LoginBAL
{
    LoginDAL logindata = new LoginDAL();
    LoginBEL loginbel;
   // int usersod;
   // int usersessionId;
    int usersessionId1;
    int usersessionsod;
    #region GetUserLoginDetails
    public LoginBEL GetUserLoginDetails(string username, string password)
    {
        DataTable datatbl = new DataTable();
        loginbel = new LoginBEL();
        datatbl = logindata.SearchUserDetails(username, password);
        try
        {
            if (datatbl.Rows.Count > 0)
            {
                foreach (DataRow dr in datatbl.Rows)
                {
                    loginbel.UserName = dr["user_login"].ToString();
                    loginbel.FirstName = dr["user_firstname"].ToString();
                    loginbel.LastName = dr["user_lastname"].ToString();
                    loginbel.UserId = Int32.Parse(dr["user_id"].ToString());
                    loginbel.DepartmentId = Int32.Parse(dr["user_department_id"].ToString());
                    loginbel.ActiveUser = Char.Parse(dr["user_active"].ToString()); 
                }
            }
            else
            {
                loginbel.UserName = null;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in Login", ex);
        }
        return loginbel;
    }
    
    #endregion
    
    #region Retrieve User Session Details

    public int GetSessionId(int userId)
    {
        
        DataTable datatbl = new DataTable();
        datatbl = logindata.GetSessionId(userId);
        try
        {
            if (datatbl.Rows.Count > 0)
            {
                foreach (DataRow dr in datatbl.Rows)
                {
                    usersessionId1 = Convert.ToInt32(dr["session_id"].ToString());
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to retrieve User Session Data", ex);
        }
        return usersessionId1;
    }

    public int GetUserSessionSod(int userId)
    {
        
        DataTable datatbl = new DataTable();
        datatbl = logindata.GetUserSessionSod(userId);
        try
        {
            if (datatbl.Rows.Count > 0)
            {
                foreach (DataRow dr in datatbl.Rows)
                {
                    string session_sod = dr["session_user_sod"].ToString();
                    if (session_sod == string.Empty)
                    {
                        usersessionsod = 0;
                    }
                    else
                    {
                        usersessionsod = Convert.ToInt32(dr["session_user_sod"].ToString());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to retrieve User Session Data", ex);
        }
        return usersessionsod;
    }

    //public int GetUserSessionId(int userId)
    //{
    //    DataTable datatbl = new DataTable();
    //    datatbl = logindata.GetAllUserSessionDetails(userId);
    //    try
    //    {
    //        if (datatbl.Rows.Count > 0)
    //        {
    //            foreach (DataRow dr in datatbl.Rows)
    //            {
    //                usersessionId = Convert.ToInt32(dr["session_id"].ToString());
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception("Unable to retrieve User Session Data", ex);
    //    }
    //    return usersessionId;
    //}
    #endregion

    #region Update User Session

    public void UpdateUserSession(int userId, int departmentId, int TerminalTypeId, int usersessionsod)
    {
        logindata.UpdateUserSession(userId, departmentId, TerminalTypeId, usersessionsod);
    }

    public void updateUserLogoutSession(int sessionId, int userId)
    {
        logindata.UpdateuserLogoutSession(sessionId, userId);
    }
    #endregion

    #region Mac Address

    public void UpdateMacAddress(string ipaddress, int departmentid, string username)
    {
        logindata.UpdateMacAdd(ipaddress, departmentid, username);
    }

#endregion

    #region GetUserTerminalDetail
    public LoginBEL GetUserTerminalDetail(string ipaddress, int departmentid, string username)
    {
        DataTable datatbl = new DataTable();
        loginbel = new LoginBEL();
        datatbl = logindata.SearchUserTerminalDetails(ipaddress, departmentid, username);
        try
        {
            if (datatbl.Rows.Count > 0)
            {
                //original
                //foreach (DataRow dr in datatbl.Rows)
                //{
                //    loginbel.TerminalId = Int32.Parse(dr["terminal_id"].ToString());
                //    loginbel.TerminalDesc = dr["terminal_desc"].ToString();
                //    loginbel.TerminalTypeId = Int32.Parse(dr["terminal_type_id"].ToString());
                //    loginbel.TerminalRoomId = Int32.Parse(dr["terminal_room_id"].ToString());
                //    loginbel.DeaprtmentDesc = dr["department_desc"].ToString();
                //}
                foreach(DataRow dr in datatbl.Rows)
                {

                loginbel.TerminalId = Int32.Parse(dr["terminal_id"].ToString());
                loginbel.TerminalDesc = dr["terminal_desc"].ToString();
                loginbel.TerminalTypeId = Int32.Parse(dr["terminal_type_id"].ToString());
                loginbel.TerminalRoomId = Int32.Parse(dr["terminal_room_id"].ToString());
                loginbel.DeaprtmentDesc = dr["department_desc"].ToString();
                }
            }
            else
            {
                loginbel.TerminalId = 0;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Problem in terminal", ex);
        }

        return loginbel;
    }
    #endregion

    #region GetAutoLoginDetails
    public DataTable GetAutoLoginDetail(string esicno)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = logindata.SearchAutoLoginDetails(esicno);
            return datatbl;
        }
        catch (Exception)
        {
            return datatbl;
        }
        finally
        {
            datatbl = null;
        }


    }
    #endregion

}