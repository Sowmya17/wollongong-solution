using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for CRTBAL
/// </summary>
public class CRTBAL
{
    CRTDAL crtdata = new CRTDAL();
    KioskDAL kioskdata = new KioskDAL();
    //CRTBEL crtbel;

    #region GetDepartmentDetail
    public DataTable GetDepartmentDetail()
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchDepartmentDetails();
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

    #region GetDepartmentDetailforSchedule
    public DataTable GetDepartmentDetailsSchedule()
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchDepartmentDetailsSchedule();
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

    #region CompareDepartmentDetailforSchedule

   // int session1 = 1;
   // string room_code = "A1";
   // DateTime scheduledate = 
    public DataTable CompareDepartSchedule(DateTime scheduledate, int session1,int room_code) 
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.CompareDepartdetailsSchedule(scheduledate, session1, room_code);
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

    #region A1M2CompareDepartmentDetailforSchedule

    // int session1 = 1;
    // string room_code = "A1";
    // DateTime scheduledate = 
    public DataTable A1M2CompareDepartSchedule(DateTime scheduledate, int session1, int room_code1)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.A1M2CompareDepartdetailsSchedule(scheduledate, session1, room_code1);
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

    #region A1T1CompareDepartmentDetailforSchedule

    // int session1 = 1;
    // string room_code = "A1";
    // DateTime scheduledate = 
    public DataTable A1T1CompareDepartSchedule(DateTime scheduledate, int session1, int room_code2)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.A1T1CompareDepartdetailsSchedule(scheduledate, session1, room_code2);
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

    #region A1T2CompareDepartmentDetailforSchedule

    // int session1 = 1;
    // string room_code = "A1";
    // DateTime scheduledate = 
    public DataTable A1T2CompareDepartSchedule(DateTime scheduledate, int session1, int room_code3)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.A1T2CompareDepartdetailsSchedule(scheduledate, session1, room_code3);
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

    #region A1W1CompareDepartmentDetailforSchedule

    // int session1 = 1;
    // string room_code = "A1";
    // DateTime scheduledate = 
    public DataTable A1W1CompareDepartSchedule(DateTime scheduledate, int session1, int room_code4)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.A1T2CompareDepartdetailsSchedule(scheduledate, session1, room_code4);
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

    #region GetRegCustomerDetailUsingESICNO
    public DataTable GetRegCustomerDetail(string esicno)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchRegCustomerDetail(esicno);
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

    #region GetRegCustomerDetailUsingESICNO
    public DataTable GetRegCustomerDetail1(string surname)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchRegCustomerDetail1(surname);
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

    #region RegCustomerDetail
    public string RegCustomerDetail(CRTBEL crtview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = crtdata.InsertRegCustomerDetail(crtview);
            insertsucess = crtdata.InsertMemberDetail(crtview);
            return insertsucess;
        }
        catch (Exception)
        {
            return insertsucess;
        }
        finally
        {
            insertsucess = string.Empty;
        }


    }
    #endregion
    
    #region GetMemberDetail
    public DataTable GetMemberDetail(string esicno)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchMemberDetail(esicno);
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

    #region GetRelationDetail
    public DataTable GetRelationDetail()
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchRelationDetail();
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
    
    #region RegCustomerDetailUpdate
    public string RegCustomerDetailUpdate(CRTBEL crtview)
    {
        string updatesucess = string.Empty;
        string updatesucess1 = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess1 = crtdata.UpdateRegCustomerDetail(crtview);
            updatesucess = crtdata.UpdateMemberDetail1(crtview);
            return updatesucess;
        }
        catch (Exception)
        {
            return updatesucess;
        }
        finally
        {
            updatesucess = string.Empty;
        }


    }
    #endregion

    #region SelfCustomerDetailUpdate
    public string SelfCustomerDetailUpdate(CRTBEL crtview)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = crtdata.UpdateSelfCustomer(crtview);
            return updatesucess;
        }
        catch (Exception)
        {
            return updatesucess;
        }
        finally
        {
            updatesucess = string.Empty;
        }


    }
    #endregion

    #region AddMemberDetails
    public string AddMemberDetails(CRTBEL crtview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = crtdata.InsertMemberDetailpat(crtview);
            return insertsucess;
        }
        catch (Exception)
        {
            return insertsucess;
        }
        finally
        {
            insertsucess = string.Empty;
        }


    }
    #endregion

    #region UpdateMemberDetails
    public string UpdateMemberDetails(CRTBEL crtview)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = crtdata.UpdateMemberDetail(crtview);
            return updatesucess;
        }
        catch (Exception)
        {
            return updatesucess;
        }
        finally
        {
            updatesucess = string.Empty;
        }


    }
    #endregion

    #region GetRegMemberInfo
    public DataTable GetRegMemberInfo(long memberid)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchRegMemberInfo(memberid);
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

    #region Get Appointment Details

    public DataTable GetAppointmentDetails(long memberid)
    {
        DataTable datatbl = new DataTable();

        try
        {
            datatbl = crtdata.SearchAppointmentDetails(memberid);
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

    #endregion Get Appointment Details
    
    #region GetParticularDepartmentDetail
    public DataTable GetParticularDepartmentDetail(int deptid)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchParticularDepartmentDetails(deptid);
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

    #region check count
    public DataTable checkcount(CRTBEL crtview)
    {
        CRTDAL crtdal = new CRTDAL();
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdal.checkcountNumber(crtview);
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

    #region check count
    public DataTable checkcount()
    {
        DataTable datatbl = new DataTable();

       try
        {
            datatbl = crtdata.checkcountNumber();
            return datatbl;
          

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            datatbl = null;
        }


    }
    #endregion
    
    #region UpdateDeptQueuNo
    public string UpdateDeptQueuNo(int deptid,int queuno)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = crtdata.UpdateQueueNumber(deptid,queuno);
            return updatesucess;
        }
        catch (Exception)
        {
            return updatesucess;
        }
        finally
        {
            updatesucess = string.Empty;
        }


    }
    #endregion

    #region GettingTotalWaitingQueue

    public DataTable GettingTotalWaitingQueue(int deptid)
    {
        DataTable WaitingQueue = new DataTable();

        //string WaitingQueue = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            WaitingQueue = crtdata.TotalWaitingQueue(deptid);
            return WaitingQueue;
        }
        catch (Exception)
        {
            return WaitingQueue;
        }
        finally
        {
            WaitingQueue = null;
        }


    }
    #endregion

    #region AddCustomerVisitDetails
    public string AddCustomerVisitDetails(CRTBEL crtview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = crtdata.InsertCustomerVisitDetails(crtview);
            return insertsucess;
        }
        catch (Exception)
        {
            return insertsucess;
        }
        finally
        {
            insertsucess = string.Empty;
        }


    }
    #endregion

    #region AddCustomerAppointmentVisitDetails
    public string AddCustomerAppointmentVisitDetails(CRTBEL crtview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = crtdata.InsertCustomerAppointmentVisitDetails(crtview);
            return insertsucess;
        }
        catch (Exception)
        {
            return insertsucess;
        }
        finally
        {
            insertsucess = string.Empty;
        }


    }
    #endregion
    
    #region GetLastCustomerVisitID
    public DataTable GetLastCustomerVisitID()
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchLastCustomerVisitID();
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

    #region AddCustomerQueueTransactions
    public string AddCustomerQueueTransactions(CRTBEL crtview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = crtdata.InsertCustomerQueueTransactions(crtview);
            return insertsucess;
        }
        catch (Exception)
        {
            return insertsucess;
        }
        finally
        {
            insertsucess = string.Empty;
        }


    }
    #endregion

    #region GetLastQueueTransactionID
    public DataTable GetLastQueueTransactionID()
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchLastQueueTransactionID();
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

    #region AddCustomerQueuePlanOrderone
    public string AddCustomerQueuePlanOrderone(CRTBEL crtview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = crtdata.InsertCustomerQueuePlanOrderone(crtview);
            return insertsucess;
        }
        catch (Exception)
        {
            return insertsucess;
        }
        finally
        {
            insertsucess = string.Empty;
        }


    }
    #endregion

    #region AddCustomerQueuePlanOrders
    public string AddCustomerQueuePlanOrders(CRTBEL crtview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = crtdata.InsertCustomerQueuePlanOrders(crtview);
            return insertsucess;
        }
        catch (Exception)
        {
            return insertsucess;
        }
        finally
        {
            insertsucess = string.Empty;
        }


    }
    #endregion

    #region CheckingQueueTokenAvailability

    public DataTable CheckQueueTokenAlreadyGenerated(CRTBEL crtview)
    {
        DataTable CheckingQueueTokenGeneration = new DataTable();

        try
        {
            CheckingQueueTokenGeneration = crtdata.CheckQueueTokenAlreadyGeneratedDetails(crtview);
            return CheckingQueueTokenGeneration;
        }
        catch (Exception)
        {
            return CheckingQueueTokenGeneration;
        }
        finally
        {
            CheckingQueueTokenGeneration = null;
        }


    }
    #endregion
    
    #region CheckingQueueTokenAvailability

    public DataTable CheckPreviousToken(CRTBEL crtview)
    {
        DataTable CheckingToken = new DataTable();

        try
        {
            CheckingToken = crtdata.CheckPreviousToken(crtview);
            return CheckingToken;
        }
        catch (Exception)
        {
            return CheckingToken;
        }
        finally
        {
            CheckingToken = null;
        }


    }
    #endregion

    #region ReprintCheckingQueueTokenAvailability

    public DataTable ReprintCheckQueueTokenAlreadyGenerated(CRTBEL crtview)
    {
        DataTable ReprintCheckingQueueTokenGeneration = new DataTable();

        try
        {
            ReprintCheckingQueueTokenGeneration = crtdata.ReprintCheckQueueTokenAlreadyGeneratedDetails(crtview);
            return ReprintCheckingQueueTokenGeneration;
        }
        catch (Exception)
        {
            return ReprintCheckingQueueTokenGeneration;
        }
        finally
        {
            ReprintCheckingQueueTokenGeneration = null;
        }


    }
    #endregion

    #region KioskReprintCheckingQueueTokenAvailability

    public DataTable ReprintCheckQueueTokenAlreadyGenerated(KioskBEL kioskview)
    {
        DataTable ReprintCheckingQueueTokenGeneration = new DataTable();

        try
        {
            ReprintCheckingQueueTokenGeneration = kioskdata.KioskReprintCheckQueueTokenAlreadyGeneratedDetails(kioskview);
            return ReprintCheckingQueueTokenGeneration;
        }
        catch (Exception)
        {
            return ReprintCheckingQueueTokenGeneration;
        }
        finally
        {
            ReprintCheckingQueueTokenGeneration = null;
        }


    }
    #endregion


    // Getting Queue Status - Getting My Queue Number

    #region Getting Queue Status - Getting My Queue Number

    public DataTable GetMyQueueNumber(CRTBEL crtqueuestatusbel)
    {
        CRTDAL crtqueuestatusdal = new CRTDAL();
        try
        {
            return crtqueuestatusdal.GetDALMyQueueNumber(crtqueuestatusbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            crtqueuestatusdal = null;
        }
    }

    #endregion Getting Queue Status - Getting My Queue Number

    // Getting Queue Status - Getting My Queue Status

    #region Getting Queue Status - Getting My Queue Status

    public string GetMyQueueStatus(CRTBEL crtqueuestatusbel)
    {
        CRTDAL crtqueuestatusdal = new CRTDAL();
        try
        {
            return crtqueuestatusdal.GetDALMyQueueStatus(crtqueuestatusbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            crtqueuestatusdal = null;
        }
    }

    #endregion Getting Queue Status - Getting My Queue Status


    //Appointment show
    #region GetAppointmentFresh
    public DataTable GetAppointmentFresh(CRTBEL crtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchAppointmentFresh(crtview);
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


    //Appointment Token
    #region GetAppointmentToken
    public DataTable GetAppointmentToken(CRTBEL crtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchAppointmentToken(crtview);
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

    //Appointment Emr
    #region GetAppointmentEmr
    public DataTable GetAppointmentEmr(CRTBEL crtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchAppointmentEmr(crtview);
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

    //Appointment Emr
    #region GetAppointmentEmr
    public DataTable GetAppointmentEmrIndex(CRTBEL crtview) //GetAppointmentEmr(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.SearchAppointmentEmrIndex(crtview);  //SearchAppointmentEmr(rtview);
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

    //Appointment Emr
    #region UpdateAppointmentEmr
    public string UpdateAppointmentEmr(CRTBEL crtview)
    {
        string datatbl ="";
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.UpdateAppointmentEmr(crtview);
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

    //Appointment Token
    #region UpdateAppointmentToken
    public string UpdateAppointmentToken(CRTBEL crtview)
    {
        string datatbl = "";
        //loginbel = new LoginBEL();

        try
        {
            datatbl = crtdata.UpdateAppointmentToken(crtview);
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

    #region Getmembersurname
    public DataTable Searchmembersurname(string _surname1)
    {
        CRTDAL crtdata = new CRTDAL();
        DataTable dt = new DataTable();
        try
        {
            dt = crtdata.Searchmembersurname(_surname1);
            return dt;
        }
        catch (Exception)
        {
            
            throw;
        }
    }
#endregion

    #region ticket cancel
    public DataTable GetCancelTicket(CRTBEL crtview)
    {
        DataTable dt1 = new DataTable();
        crtdata = new CRTDAL();
        try
        {
            dt1 = crtdata.selectTicketdata(crtview);
            return dt1;
        }
        catch (Exception)
        {

            return dt1;
        }
        finally
        {

        }
    }
    #endregion

    #region update cancel ticket
    public string getUpdateTicket(CRTBEL crtview)
    {
        string s = "";
        crtdata = new CRTDAL();
        try
        {
            s = crtdata.UpdateCancelToken(crtview);
            return s;
        }
        catch (Exception)
        {
            throw;
        }
    }
    #endregion
}