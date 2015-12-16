using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for LoginBEL
/// </summary>
public class LoginBEL
{
    #region Variables
    private string _UserName;
    private string _Password;
    private string _terminaldesc;
    private string _ipaddress;
    private string _firstname;
    private string _lastname;
    private string _departmentdesc;
    private string _autologinstatus;
    private string _autologinusername;
    private string _autologinpassword;
    private char _UserActive;
    private int _Userid;
    private int _departmentid;
    private int _terminaltypeid;
    private int _terminalroomid;
    private int _terminalid;
    
    #endregion

    #region String

    public string UserName
    {
        get
        {
            return _UserName;
        }
        set
        {
            _UserName = value;
        }
    }

    public string FirstName
    {
        get
        {
            return _firstname;
        }
        set
        {
            _firstname = value;
        }
    }

    public string LastName
    {
        get
        {
            return _lastname;
        }
        set
        {
            _lastname = value;
        }
    }

    public string Password
    {
        get
        {
            return _Password;
        }
        set
        {
            _Password = value;
        }
    }

    public string IPAddress
    {
        get
        {
            return _ipaddress;
        }
        set
        {
            _ipaddress = value;
        }
    }

    public string TerminalDesc
    {
        get
        {
            return _terminaldesc;
        }
        set
        {
            _terminaldesc = value;
        }
    }

    public string DeaprtmentDesc
    {
        get
        {
            return _departmentdesc;
        }
        set
        {
            _departmentdesc = value;
        }
    }


    public string AutoLoginStatus
    {
        get
        {
            return _autologinstatus;
        }
        set
        {
            _autologinstatus = value;
        }
    }

    public string AutoLoginUserName
    {
        get
        {
            return _autologinusername;
        }
        set
        {
            _autologinusername = value;
        }
    }
    public string AutoLoginPassword
    {
        get
        {
            return _autologinpassword;
        }
        set
        {
            _autologinpassword = value;
        }
    }

    #endregion

    #region Char
    public char ActiveUser
    {
        get
        {
            return _UserActive;
        }
        set
        {
            _UserActive = value;
        }
    }
    #endregion

    #region Int
    public int UserId
    {
        get
        {
            return _Userid;
        }
        set
        {
            _Userid = value;
        }
    }
    
    public int DepartmentId
    {
        get
        {
            return _departmentid;
        }
        set
        {
            _departmentid = value;
        }
    }

    public int TerminalId
    {
        get
        {
            return _terminalid;
        }
        set
        {
            _terminalid = value;
        }
    }

    public int TerminalTypeId
    {
        get
        {
            return _terminaltypeid;
        }
        set
        {
            _terminaltypeid = value;
        }
    }

    public int TerminalRoomId
    {
        get
        {
            return _terminalroomid;
        }
        set
        {
            _terminalroomid = value;
        }
    }
    #endregion

  

}