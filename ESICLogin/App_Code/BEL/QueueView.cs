using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class QueueView
{
    // Queue Display - Initiallizing Variables

    #region Queue Display - Initiallizing Variables

    private int _departmentid;
    private int _departmentidcounterdisplay;
    private int _departmentidnext;
    private static int _botc;


    private long _queuetnxid;

    private string _smsstatusflag;

    #endregion Queue Display - Initiallizing Variables

    // Queue Display - Properties

    #region Queue Display - Properties

    public int DepartmentID
    {
        get { return _departmentid; }
        set { _departmentid = value; }
    }

    public int DepartmentIDCounterDisplay
    {
        get { return _departmentidcounterdisplay; }
        set { _departmentidcounterdisplay = value; }
    }
    public int DepartmentIDNext
    {
        get { return _departmentidnext; }
        set { _departmentidnext = value; }
    }

    public static int BOTC
    {
        get { return _botc; }
        set { _botc = value; }
    }

    public string SmsStatusFlag
    {
        get { return _smsstatusflag; }
        set { _smsstatusflag = value; }
    }

    public long QueueTnxId
    {
        get { return _queuetnxid; }
        set { _queuetnxid = value; }
    }

    #endregion Queue Display - Properties
}

