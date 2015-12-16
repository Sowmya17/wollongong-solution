using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CRTBEL
/// </summary>
public class CRTBEL
{

    #region Variables
    private DataTable _esicnodetails;
    private DataTable _esicsurname;
    private DataTable _esicdob;


    private DateTime _appointmentdatetime;
    private DateTime _dob;

    private Char _cancelstatus;
    private string _esicnumber;
    private string _customerfname;
    private string _customerlname;
    private string _memberfname;
    private string _memberlname;
    private string _queueno;
    private string _customeradd;
    private string _userterminal;
    private string _customerfullname;
    private string _smsstatusflag;
    private string _queuenoshow;
    private string _consultingstatus;
    private string _email;

    private char _customergender;
    private char _membergender;
    

    private string _cusotmerphone;
    private long _customervisitid;
    private long _customerqueuetnx;

    private int _cusotmerage;
    private int _patientid;
    private int _memberage;
    private int _memberid;
    private int _memberrelationid;
    private int _relationid;
    private int _userid;
    private int _terminalid;
    private int _departmentid;
    private int _orderid;
    private int _transferid;
    private int _appointmentid;
    private string _appointmentidstatus;

    private string _queuenumber;
    private string _datetime;
    private string _appointmenttime;

    private int _session1;
    private int _room_code;
    private DateTime _scheduledate;

    #endregion

    #region DataTable
    public DataTable Esicnodetails
    {
        get
        {
            return _esicnodetails;
        }
        set
        {
            _esicnodetails = value;
        }
    }
    #endregion

    #region DataTable
    public DataTable Esicsurname
    {
        get
        {
            return _esicsurname;
        }
        set
        {
            _esicsurname = value;
        }
    }
    #endregion

    #region DataTable
    public DataTable Esicdob
    {
        get
        {
            return _esicdob;
        }
        set
        {
            _esicdob = value;
        }
    }
    #endregion
    
    #region Appointment Date Time

    public DateTime AppointmentDateTime
    {
        get
        {
            return _appointmentdatetime;
        }
        set
        {
            _appointmentdatetime = value;
        }
    }


    public DateTime Dob
    {
        get
        {
            return _dob;
        }
        set
        {
            _dob = value;
        }
    }
    #endregion Appointment Date Time

    #region String

    public Char CancelStatus
    {
        get
        {
            return _cancelstatus;
        }
        set
        {
            _cancelstatus = value;
        }
    }
    public string Email
    {
        get
        {
            return _email;
        }
        set
        {
            _email = value;
        }
    }
    public string ESCInNumber
    {
        get
        {
            return _esicnumber;
        }
        set
        {
            _esicnumber = value;
        }
    }
    public string CusFirstname
    {
        get
        {
            return _customerfname;
        }
        set
        {
            _customerfname = value;
        }
    }
    public string CusLastName
    {
        get
        {
            return _customerlname;
        }
        set
        {
            _customerlname = value;
        }
    }
    public string CusAddress
    {
        get
        {
            return _customeradd;
        }
        set
        {
            _customeradd = value;
        }
    }
    public string TerminalUser
    {
        get
        {
            return _userterminal;
        }
        set
        {
            _userterminal = value;
        }
    }
    public string MemberLastName
    {
        get
        {
            return _memberlname;
        }
        set
        {
            _memberlname = value;
        }
    }
    public string MemberFirstName
    {
        get
        {
            return _memberfname;
        }
        set
        {
            _memberfname = value;
        }
    }
    public string QueueNummber
    {
        get
        {
            return _queueno;
        }
        set
        {
            _queueno = value;
        }
    }
    public string QueueNummberShow
    {
        get
        {
            return _queuenoshow;
        }
        set
        {
            _queuenoshow = value;
        }
    }
    public string CustomerFullName
    {
        get
        {
            return _customerfullname;
        }
        set
        {
            _customerfullname = value;
        }
    }

    public string QueueNumber
    {
        get
        {
            return _queuenumber;
        }
        set
        {
            _queuenumber = value;
        }
    }

    public string DateTime
    {
        get
        {
            return _datetime;
        }
        set
        {
            _datetime = value;
        }
    }

    public string SmsStatusFlag
    {
        get
        {
            return _smsstatusflag;
        }
        set
        {
            _smsstatusflag = value;
        }
    }

    public string AppointmentTime
    {
        get
        {
            return _appointmenttime;
        }
        set
        {
            _appointmenttime = value;
        }
    }
    public string ConsultingStatus
    {
        get
        {
            return _consultingstatus;
        }
        set
        {
            _consultingstatus = value;
        }
    }
    #endregion

    #region Long
    public string CusPhoneNo
    {
        get
        {
            return _cusotmerphone;
        }
        set
        {
            _cusotmerphone = value;
        }
    }
    public long CusVisitId
    {
        get
        {
            return _customervisitid;
        }
        set
        {
            _customervisitid = value;
        }
    }
    public long QueueTransID
    {
        get
        {
            return _customerqueuetnx;
        }
        set
        {
            _customerqueuetnx = value;
        }
    }
    #endregion

    #region Char
    public Char CusGender
    {
        get
        {
            return _customergender;
        }
        set
        {
            _customergender = value;
        }
    }
    public Char MemberGender
    {
        get
        {
            return _membergender;
        }
        set
        {
            _membergender = value;
        }
    }
   
    #endregion

    #region Int
    public int CusAge
    {
        get
        {
            return _cusotmerage;
        }
        set
        {
            _cusotmerage = value;
        }
    }

    public int room_code
    {
        get
        {
            return _room_code;
        }
        set
        {
            _room_code = value;
        }
    }

    public DateTime scheduledate
    {
        get
        {
            return _scheduledate;
        }
        set
        {
            _scheduledate = value;
        }
    }
    public int session1
    {
        get
        {
            return _session1;
        }
        set
        {
            _session1 = value;
        }
    }
    public int RelationId
    {
        get
        {
            return _relationid;
        }
        set
        {
            _relationid = value;
        }
    }
    public int MemberAge
    {
        get
        {
            return _memberage;
        }
        set
        {
            _memberage = value;
        }
    }
    public int MemberRelationId
    {
        get
        {
            return _memberrelationid;
        }
        set
        {
            _memberrelationid = value;
        }
    }
    public int MemberId
    {
        get
        {
            return _memberid;
        }
        set
        {
            _memberid = value;
        }
    }
    public int PatientId
    {
        get
        {
            return _patientid;
        }
        set
        {
            _patientid = value;
        }
    }


    public int UserId
    {
        get
        {
            return _userid;
        }
        set
        {
            _userid = value;
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

    public int OrderId
    {
        get
        {
            return _orderid;
        }
        set
        {
            _orderid = value;
        }
    }

    public int TransferID
    {
        get
        {
            return _transferid;
        }
        set
        {
            _transferid = value;
        }
    }
    public int AppointmentID
    {
        get
        {
            return _appointmentid;
        }
        set
        {
            _appointmentid = value;
        }
    }

    public string AppointmentIDStatus
    {
        get
        {
            return _appointmentidstatus;
        }
        set
        {
            _appointmentidstatus = value;
        }
    }
    #endregion


}