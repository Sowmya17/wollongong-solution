using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Org.BouncyCastle.Math;

/// <summary>
/// Summary description for KioskBEL
/// </summary>
public class KioskBEL
{
    #region Variables
    private DataTable _esicnodetails;

    private string _esicnumber;
    private string _email;
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

    private char _customergender;
    private char _membergender;

    private long _cusotmerphone;
    private long _customervisitid;
    private long _customerqueuetnx;

    private int _cusotmerage;
    private int _cusmobile;
    private int _patientid;
    private int _memberage;
    private int _memberid;
    private int _memberrelationid;
    private int _relationid;
    private int _userid;
    private int _terminalid;
    private int _departmentid;
    private int _orderid;
    private int _appointmentid;

    private DateTime _dob;
    private DateTime _appointmentdatetime;
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

    #region String
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
    #endregion

    #region Long
    public long CusPhoneNo
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
    public int CusMobile
    {
        get
        {
            return _cusmobile;
        }
        set
        {
            _cusmobile = value;
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
    #endregion

    #region dob

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
    #endregion dob
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

    public DataTable KioskReprintCheckQueueTokenAlreadyGenerated(KioskBEL kioskview)
    {
        throw new NotImplementedException();
    }
}