using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RTBEL
/// </summary>
public class RTBEL
{
    #region Variables
   // private DataTable _esicnodetails;

    //private string _esicnumber;
    //private string _customerfname;
    //private string _customerlname;
    //private string _memberfname;
    //private string _memberlname;
    //private string _queueno;
    //private string _customeradd;
    //private string _userterminal;
    //private string _customerfullname;
    private string _smsstatusflag;
    private string _searchqueueno;
    private string _buttoneventflag;

    private char _customergender;
    private char _membergender;
   

    private long _cusotmerphone;
    private long _customervisitid;
    private long _customerqueuetnx;
    private long _queueplantnx;
    
    private int _gettinguserid;
    private int _transferid;
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
    private int _queuestatusid;

    private DateTime _currentDateTime;
    private int _statusid;
    private char _smsflag;
    private int _lbholdcount;
    #endregion

    #region Int

    public string ButtonEventFlag
    {
        get
        {
            return _buttoneventflag;
        }
        set
        {
            _buttoneventflag = value;
        }
    }
    public int GettingUserId
    {
        get
        {
            return _gettinguserid;
        }
        set
        {
            _gettinguserid = value;
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
    public int QueueStatusID
    {
        get
        {
            return _queuestatusid;
        }
        set
        {
            _queuestatusid = value;
        }
    }

     public string SMSStatusFlag
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

     public string SearchQueueNo
     {
         get
         {
             return _searchqueueno;
         }
         set
         {
             _searchqueueno = value;
         }
     }

    #endregion
    
    #region Long
    public long CustomerVisitId
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
    public long CustomerQueueTnx
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
     public long QueuePlanTnxId
    {
        get
        {
            return _queueplantnx;
        }
        set
        {
            _queueplantnx = value;
        }
    }
    #endregion
    
    //datetime
    
    #region
     public DateTime currentDateTime
     {
         get
         {
             return _currentDateTime;
         }
         set
         {
             _currentDateTime = value;
         }
     }
     public int statusid
     {
         get
         {
             return _statusid;
         }
         set
         {
             _statusid = value;
         }
     }
     public char smsflag
     {
         get
         {
             return _smsflag;
         }
         set
         {
             _smsflag = value;
         }
     }
     public int lbholdcount
     {
         get
         {
             return _lbholdcount;
         }
         set
         {
             _lbholdcount = value;
         }
     }
    #endregion

     #region SMS View - Initiallizing Variables

     private string _deliveryReport;
    // private string _smsstatusflag;
     private int _queuetnxid;
     private string _queueno;
    // private int _departmentid;
    // private int _queuestatusid;
     private string _mysms;
     private string _insmsstatus;
     private string _incomingsmsflag;
     private long _custid;
     private string _msg;
     private DateTime _smsdttime;
     private string _phoneno;
     private int _member_id;

     #endregion SMS View - Initiallizing Variables

     #region SMS View - Properties

     public int MenberId
     {
         get
         {
             return _member_id;
         }
         set
         {
             _member_id = value;
         }
     }
     public string DeliveryReport
     {
         get
         {
             return _deliveryReport;
         }
         set
         {
             _deliveryReport = value;
         }
     }

     public string PnoneNo
     {
         get
         {
             return _phoneno;
         }
         set
         {
             _phoneno = value;
         }
     }

     public DateTime SMSDateTime
     {
         get
         {
             return _smsdttime;
         }
         set
         {
             _smsdttime = value;
         }
     }
     public string Message
     {
         get
         {
             return _msg;
         }
         set
         {
             _msg = value;
         }
     }
     public long CustId
     {
         get
         {
             return _custid;
         }
         set
         {
             _custid = value;
         }
     }
     public string IncomingsmsFlag
     {
         get
         {
             return _incomingsmsflag;
         }
         set
         {
             _incomingsmsflag = value;
         }
     }
     public string InsmsStatus
     {
         get
         {
             return _insmsstatus;
         }
         set
         {
             _insmsstatus = value;
         }
     }

     public string MySms
     {
         get { return _mysms; }
         set { _mysms = value; }
     }

     public int QueueTransaction
     {
         get { return _queuetnxid; }
         set { _queuetnxid = value; }
     }

     public string QueueNo
     {
         get { return _queueno; }
         set { _queueno = value; }
     }


     #endregion SMS View - Properties
}