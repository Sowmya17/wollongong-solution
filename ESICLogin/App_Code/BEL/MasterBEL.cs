using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for MasterBEL
/// </summary>
public class MasterBEL
{
    // Master BEL - Constructor

    #region Master BEL - Constructor

    public MasterBEL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion Master BEL - Constructor


    // ----------------------- User Master --------------------------------

    // User Variables

    #region UserVariables

    private int _userid;
    private DataTable _ddlloading;
    private string _firstname;
    private string _lastname;
    private string _username;
    private string _autologinstatus;
    private string _autologinusername;
    private string _autologinpassword;
    private string _confirmpassword;
    private int _rolldescription;
    private int _departmentdescription;
    private string _userstatus;
    private DateTime _updateddatetime;

    private string _updatedby;
    private string _gridviewpassword;

    private int _gettingdepartmentid;

    #endregion UserVariables


    // ---------------------- Device Master --------------------------------

    // Device Variables

    #region Device Variables

    private int _deviceid;
    private int _avgdeptid;
    private string _devicename;
    private string _devicedescription;
    private DateTime _deviceupdateddatetime;
    private DateTime _deviceupdateddatetimeto;
    private DateTime _avgdatetime;
    private string _deviceupdatedby;

    #endregion Device Variables

    // ---------------------- Location Master ------------------------------

    // Location Variables

    #region Location Variables

    private int _locationid;
    private string _locationdescription;
    private string _locationcode;
    private int _locationdepartmentid;
    private DateTime _locationupdateddatetime;
    private string _locationupdatedby;

    #endregion Location Variables

    // ---------------------- Terminal Master -------------------------------

    // Terminal Variables

    #region Terminal Variables

    private int _terminalid;
    private string _terminaldescription;
    private string _terminalip;
    private int _terminaldepartmentid;
    private int _terminalroomid;
    private int _terminaltypeid;
    private DateTime _terminalupdateddatetime;
    private string _terminalupdatedby;

    #endregion Terminal Variables

    // ---------------------- Department Master -----------------------------

    // Department Variables

    #region Department Variables

    private int _departmentid;
    private string _departmentdescriptions;
    private string _departmentcode;
    private DateTime _departmentupdateddatetime;
    private string _departmentupdatedby;
    private int _departmentqueueno;

    #endregion Department Variables

    // ---------------------- Schedule Master -----------------------------

    // Schedule Variables

    #region Schedule Variables

    private int _scheduleId;
    private int _scheduleId1;
    private int _schedule_Week;
    private int _schedule_Day;
    private int _schedule_Dept_Id;
    private int _schedule_room_Id;
    private char[] _schedule_Room_Code;
    private int _schedule_Session;
    private DateTime _schedule_Start_Time;
    private DateTime _schedule_End_Time;
    private string _schedule_UpdatedBy;
    private DateTime _schedule_UpdatedDateTime;

    #endregion

    // ---------------------- Content Master -----------------------------

    // Content Variables

    #region Content Variables

    private int _contentId;
    private string _content_Name;
    private string _content_Description;
    private string _content_Text;
    private DateTime _content_StartTime;
    private DateTime _content_EndTime;
    private string _content_Day;
    private int _content_Terminal_Id;
    private string _content_UpdatedBy;
    private DateTime _content_UpdatedDateTime;
    private int _content_OrderId;
    private char _content_Active;

    #endregion



    // ---------------------- User Master -----------------------------------


    // User Properties

    #region UserProperties

    public int UserId
    {
        get { return _userid; }
        set { _userid = value; }
    }

    public DataTable DDLLoading
    {
        get { return _ddlloading; }
        set { _ddlloading = value; }
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

    public string UserName
    {
        get
        {
            return _username;
        }
        set
        {
            _username = value;
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


    public string ConfirmPassword
    {
        get
        {
            return _confirmpassword;
        }
        set
        {
            _confirmpassword = value;
        }
    }
    public int RollDescription
    {
        get
        {
            return _rolldescription;
        }
        set
        {
            _rolldescription = value;
        }
    }

    public int DepartmentDescription
    {
        get
        {
            return _departmentdescription;
        }
        set
        {
            _departmentdescription = value;
        }
    }

    public string UserStatus
    {
        get
        {
            return _userstatus;
        }
        set
        {
            _userstatus = value;
        }
    }

    public DateTime UpdatedDateTime
    {
        get
        {
            return _updateddatetime;
        }
        set
        {
            _updateddatetime = value;
        }
    }

    public string UpdatedBy
    {
        get
        {
            return _updatedby;
        }
        set
        {
            _updatedby = value;
        }
    }

    public string GridViewPassword
    {
        get
        {
            return _gridviewpassword;
        }
        set
        {
            _gridviewpassword = value;
        }
    }

    #endregion UserProperties

    // ---------------------- Device Master ---------------------------------

    // Device Properties

    #region Device Properties

    public virtual bool CausesValidation { get; set; }

    public int DeviceId
    {
        get
        {
            return _deviceid;
        }
        set
        {
            _deviceid = value;
        }
    }

    public int AvgDeptId
    {
        get
        {
            return _avgdeptid;
        }
        set
        {
            _avgdeptid = value;
        }
    }

    public string DeviceName
    {
        get
        {
            return _devicename;
        }
        set
        {
            _devicename = value;
        }
    }

    public string DeviceDescription
    {
        get
        {
            return _devicedescription;
        }
        set
        {
            _devicedescription = value;
        }
    }

    public DateTime DeviceUpdatedDateTime
    {
        get
        {
            return _deviceupdateddatetime;
        }
        set
        {
            _deviceupdateddatetime = value;
        }
    }

    public DateTime DeviceUpdatedDateTimeTo
    {
        get
        {
            return _deviceupdateddatetimeto;
        }
        set
        {
            _deviceupdateddatetimeto = value;
        }
    }

    public DateTime AvgDateTime
    {
        get
        {
            return _avgdatetime;
        }
        set
        {
            _avgdatetime = value;
        }
    }

    public string DeviceUpdatedBy
    {
        get
        {
            return _deviceupdatedby;
        }
        set
        {
            _deviceupdatedby = value;
        }
    }

    #endregion Device Properties

    // ---------------------- Location Master -------------------------------

    // Location Properties

    #region Location Properties

    public int LocationId
    {
        get
        {
            return _locationid;
        }
        set
        {
            _locationid = value;
        }
    }

    public string LocationDescription
    {
        get
        {
            return _locationdescription;
        }
        set
        {
            _locationdescription = value;
        }
    }

    public string LocationCode
    {
        get
        {
            return _locationcode;
        }
        set
        {
            _locationcode = value;
        }
    }

    public int LocationDepartmentId
    {
        get
        {
            return _locationdepartmentid;
        }
        set
        {
            _locationdepartmentid = value;
        }
    }

    public DateTime LocationUpdatedDateTime
    {
        get
        {
            return _locationupdateddatetime;
        }
        set
        {
            _locationupdateddatetime = value;
        }
    }

    public string LocationUpdatedBy
    {
        get
        {
            return _locationupdatedby;
        }
        set
        {
            _locationupdatedby = value;
        }
    }

    public int GettingDepartmentId
    {
        get
        {
            return _gettingdepartmentid;
        }
        set
        {
            _gettingdepartmentid = value;
        }
    }

    #endregion Location Properties

    // ---------------------- Terminal Master --------------------------------

    #region Terminal Properties

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

    public string TerminalDescription
    {
        get
        {
            return _terminaldescription;
        }
        set
        {
            _terminaldescription = value;
        }
    }

    public string TerminalIp
    {
        get
        {
            return _terminalip;
        }
        set
        {
            _terminalip = value;
        }
    }

    public int TerminalDepartmentId
    {
        get
        {
            return _terminaldepartmentid;
        }
        set
        {
            _terminaldepartmentid = value;
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


    public DateTime TerminalUpdatedDateTime
    {
        get
        {
            return _terminalupdateddatetime;
        }
        set
        {
            _terminalupdateddatetime = value;
        }
    }

    public string TerminalUpdatedBy
    {
        get
        {
            return _terminalupdatedby;
        }
        set
        {
            _terminalupdatedby = value;
        }
    }

    #endregion Terminal Properties

    // ----------------------- Department Master -----------------------------

    #region Department Properties

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

    public string DepartmentDescriptions
    {
        get
        {
            return _departmentdescriptions;
        }
        set
        {
            _departmentdescriptions = value;
        }
    }

    public string DepartmentCode
    {
        get
        {
            return _departmentcode;
        }
        set
        {
            _departmentcode = value;
        }
    }

    public DateTime DepartmentUpdatedDateTime
    {
        get
        {
            return _departmentupdateddatetime;
        }
        set
        {
            _departmentupdateddatetime = value;
        }
    }

    public string DepartmentUpdatedBy
    {
        get
        {
            return _departmentupdatedby;
        }
        set
        {
            _departmentupdatedby = value;
        }
    }

    public int DepartmentQueueNo
    {
        get
        {
            return _departmentqueueno;
        }
        set
        {
            _departmentqueueno = value;
        }
    }

    #endregion Department Properties


    // ---------------------- Image Master -----------------------------

    #region Image Variables
    private int _img_id;
    private string _img_name;
    private string _img_desc;
    private byte[] _img_image;
    private DateTime _updated_datetime;
    private string _updated_by;
    #endregion



    // ---------------------- Image Master -----------------------------

    #region Image Properties
    public int ImageId
    {
        get { return _img_id; }
        set { _img_id = value; }
    }
    public string ImageName
    {
        get { return _img_name; }
        set { _img_name = value; }
    }
    public string ImageDesc
    {
        get { return _img_desc; }
        set { _img_desc = value; }
    }
    public byte[] Image
    {
        get { return _img_image; }
        set { _img_image = value; }
    }
    public DateTime ImageUpdateDate
    {
        get { return _updateddatetime; }
        set { _updateddatetime = value; }
    }
    public string ImageUpdatedby
    {
        get { return _updatedby; }
        set { _updatedby = value; }
    }
    #endregion

    // ---------------------- Schedule Master -----------------------------

    #region Schedule Properties

    public int ScheduleId
    {
        get { return _scheduleId; }
        set { _scheduleId = value; }
    }

    public int ScheduleId1
    {
        get { return _scheduleId1; }
        set { _scheduleId1 = value; }
    }

    public int ScheduleWeek
    {
        get { return _schedule_Week; }
        set { _schedule_Week = value; }
    }

    public int ScheduleDay
    {
        get { return _schedule_Day; }
        set { _schedule_Day = value; }
    }

    public int ScheduleDeptid
    {
        get { return _schedule_Dept_Id; }
        set { _schedule_Dept_Id = value; }
    }

    public char[] ScheduleRoomCode
    {
        get { return _schedule_Room_Code; }
        set { _schedule_Room_Code = value; }
    }

    public int ScheduleSession
    {
        get { return _schedule_Session; }
        set { _schedule_Session = value; }
    }

    public int ScheduleRoomId
    {
        get { return _schedule_room_Id; }
        set { _schedule_room_Id = value; }
    }

    public DateTime ScheduleStartTime
    {
        get { return _schedule_Start_Time; }
        set { _schedule_Start_Time = value; }
    }

    public DateTime ScheduleEndTime
    {
        get { return _schedule_End_Time; }
        set { _schedule_End_Time = value; }
    }

    public string ScheduleUpdatedBy
    {
        get { return _schedule_UpdatedBy; }
        set { _schedule_UpdatedBy = value; }
    }

    public DateTime ScheduleUpdateDateTime
    {
        get { return _schedule_UpdatedDateTime; }
        set { _schedule_UpdatedDateTime = value; }
    }

    #endregion

    // ---------------------- Content Master -----------------------------

    #region Content Properties

    public int ContentId
    {
        get { return _contentId; }
        set { _contentId = value; }
    }

    public string ContentName
    {
        get { return _content_Name; }
        set { _content_Name = value; }
    }

    public string ContentDesc
    {
        get { return _content_Description; }
        set { _content_Description = value; }
    }

    public string ContentText
    {
        get { return _content_Text; }
        set { _content_Text = value; }
    }

    public DateTime ContentStartTime
    {
        get { return _content_StartTime; }
        set { _content_StartTime = value; }
    }

    public DateTime ContentEndTime
    {
        get { return _content_EndTime; }
        set { _content_EndTime = value; }
    }

    public int ContentTerminalId
    {
        get { return _content_Terminal_Id; }
        set { _content_Terminal_Id = value; }
    }

    public string ContentDay
    {
        get { return _content_Day; }
        set { _content_Day = value; }
    }

    public string ContentUpdateBy
    {
        get { return _content_UpdatedBy; }
        set { _content_UpdatedBy = value; }
    }

    public DateTime ContentUpdateDateTime
    {
        get { return _content_UpdatedDateTime; }
        set { _content_UpdatedDateTime = value; }
    }


    public int ContentOrderId
    {
        get { return _content_OrderId; }
        set { _content_OrderId = value; }
    }

    public char ContentActive
    {
        get { return _content_Active; }
        set { _content_Active = value; }
    }

    #endregion

    // status
    private string _queuenoshow;

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

    private int _transferid;
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

    private int _transferid1;

    public int TransferID1
    {
        get
        {
            return _transferid1;
        }
        set
        {
            _transferid1 = value;
        }
    }
}