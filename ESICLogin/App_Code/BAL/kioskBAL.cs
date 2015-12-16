using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>

/// <summary>
/// Summary description for kioskBAL
/// </summary>
public class kioskBAL
{
    KioskDAL kioskdata = new KioskDAL();
   // KioskBEL kioskbel;

    #region GetDepartmentDetail
    public DataTable GetDepartmentDetail()
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = kioskdata.SearchDepartmentDetails();
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
            datatbl = kioskdata.SearchRegCustomerDetail(esicno);
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
    public string RegCustomerDetail(KioskBEL kioskview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = kioskdata.InsertRegCustomerDetail1(kioskview);
            insertsucess = kioskdata.InsertMemberDetail1(kioskview);
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
            datatbl = kioskdata.SearchMemberDetail(esicno);
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

    #region GetMemberDetail One
    public DataTable GetMemberDetailOne(string esicno)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = kioskdata.SearchMemberDetailOne(esicno);
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
            datatbl = kioskdata.SearchRelationDetail();
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

    #region CheckingKioskQueueTokenAvailability

    public DataTable CheckKioskQueueTokenAlreadyGenerated(KioskBEL kioskview)
    {
        DataTable CheckingQueueTokenGeneration = new DataTable();

        try
        {
            CheckingQueueTokenGeneration = kioskdata.CheckQueueTokenAlreadyGeneratedDetails(kioskview);
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

    #region RegCustomerDetailUpdate
    public string RegCustomerDetailUpdate(KioskBEL kioskview)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = kioskdata.UpdateRegCustomerDetail(kioskview);
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
    public string AddMemberDetails(KioskBEL kioskview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = kioskdata.InsertMemberDetailpat(kioskview);
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
    public string UpdateMemberDetails(KioskBEL kioskview)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = kioskdata.UpdateMemberDetail(kioskview);
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
            datatbl = kioskdata.SearchRegMemberInfo(memberid);
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


    #region GetParticularDepartmentDetail
    public DataTable GetParticularDepartmentDetail(int deptid)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = kioskdata.SearchParticularDepartmentDetails(deptid);
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


    #region UpdateDeptQueuNo
    public string UpdateDeptQueuNo(int deptid, int queuno)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = kioskdata.UpdateQueueNumber(deptid, queuno);
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


    #region KioskGettingTotalWaitingQueue

    public DataTable GettingTotalWaitingQueue(int deptid)
    {
        DataTable WaitingQueue = new DataTable();

        //string WaitingQueue = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            WaitingQueue = kioskdata.TotalWaitingQueue(deptid);
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
    public string AddCustomerVisitDetails(KioskBEL kioskview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = kioskdata.InsertCustomerVisitDetails(kioskview);
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
            datatbl = kioskdata.SearchLastCustomerVisitID();
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
    public string AddCustomerQueueTransactions(KioskBEL kioskview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = kioskdata.InsertCustomerQueueTransactions(kioskview);
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
            datatbl = kioskdata.SearchLastQueueTransactionID();
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
    public string AddCustomerQueuePlanOrderone(KioskBEL kioskview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = kioskdata.InsertCustomerQueuePlanOrderone(kioskview);
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
    public string AddCustomerQueuePlanOrders(KioskBEL kioskview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = kioskdata.InsertCustomerQueuePlanOrders(kioskview);
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

    #region Get Appointment Details

    public DataTable GetAppointmentDetails(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            datatbl = kioskdal.SearchAppointmentDetails(kbel);
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

    #region Update Appointment Details

    public string UpdateAppointmentStatus(KioskBEL kbel)
    {
        string datatbl = "";
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            datatbl = kioskdal.UpdateAppointmentStatus(kbel);
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

    #endregion Update Appointment Details

    #region Get Appointment Details For Card

    public DataTable GetAppointmentDetailsCard(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            datatbl = kioskdal.SearchAppointmentDetailsCard(kbel);
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


    #region RegCustomerDetail
    public string RegCustomerDetail1(KioskBEL kioskview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            insertsucess = kioskdal.InsertRegCustomerDetail1(kioskview);
            insertsucess = kioskdal.InsertMemberDetail1(kioskview);
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

    #region Get Appointment Details For Card

    public DataTable GetMemberCard(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            datatbl = kioskdal.SearchMemberCard(kbel);
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

    #region Get Walkin Details

    public DataTable GetWalkinDetails(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            datatbl = kioskdal.SearchWalkinDetails(kbel);
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

    #region Get Walkin Details

    public DataTable GetWalkinDetailsEsi(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            datatbl = kioskdal.SearchWalkinDetailsEsi(kbel);
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



    #region Get CRT RT Dept ID

    public DataTable GetCrtRtId(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            datatbl = kioskdal.SearchCrtRtId(kbel);
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

    #region Update Mobile Number
    public void UpdateMobileNo(KioskBEL kioskview,string es)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
           kioskdata.DaoUpdateMobileNo(kioskview,es);
           // return datatbl;
        }
        catch (Exception)
        {
            //return datatbl;
        }
        finally
        {
            datatbl = null;
        }


    }
    #endregion

    #region Update Email Number
    public void UpdateEmail(KioskBEL kioskview, string es)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            kioskdata.DaoUpdateEmail(kioskview, es);
            // return datatbl;
        }
        catch (Exception)
        {
            //return datatbl;
        }
        finally
        {
            datatbl = null;
        }


    }
    #endregion

    #region Update Email Number
    public void UpdateMob(KioskBEL kioskview, string es)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            kioskdata.DaoUpdateMob(kioskview, es);
            // return datatbl;
        }
        catch (Exception)
        {
            //return datatbl;
        }
        finally
        {
            datatbl = null;
        }


    }
    #endregion


    #region AddCustomerVisitDetails Walkin
    public string AddCustomerVisitDetailsW(KioskBEL kioskview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = kioskdata.InsertCustomerVisitDetailsW(kioskview);
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


    #region Get Dummy Id

    public DataTable GetDummyNo(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            datatbl = kioskdal.SearchDummyNo(kbel);
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


    #region Get Dummy Id

    public DataTable UpdateDummyNo(KioskBEL kbel)
    {
        DataTable datatbl = new DataTable();
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            datatbl = kioskdal.UpdateDummyNo(kbel);
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

    #region check count
    public DataTable checkcount(int deptid)
    {
        DataTable datatbl = new DataTable();
        KioskDAL kioskdal = new KioskDAL();
        try
        {
            datatbl = kioskdal.checkcountNumber(deptid);
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
    

}