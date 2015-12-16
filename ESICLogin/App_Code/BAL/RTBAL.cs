using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for RTBAL
/// </summary>
public class RTBAL
{
    RTDAL rtdata = new RTDAL();
   // RTBEL crtbel;

    #region GetQueueNoDetail
    public DataTable GetQueueNoDetail(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchQueueNoDetails(rtview);
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

    #region GetMissedQueueNoDetail
    public DataTable GetMissedQueueNoDetail(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchMissedQueueNoDetail(rtview);
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

    #region GetHoldQueueNoDetail
    public DataTable GetHoldQueueNoDetail(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchHoldQueueNoDetail(rtview);
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


    #region GetPendingQueueNoDetail
    public DataTable GetPendingQueueNoDetail(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchPendingQueueNoDetail(rtview);
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

    #region GetQueueMemberDetails
    public DataTable GetQueueMemberDetails(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchQueueMemberDetails(rtview);
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

    #region GetQueueServiceStatus

    public DataTable GetQeueuServiceStatus(RTBEL rtview)
    {
        DataTable dtgqssd = new DataTable();
        //loginbel = new LoginBEL();

        dtgqssd = null;

        try
        {
            dtgqssd = rtdata.SearchQueueServiceStatusDetails(rtview);
            return dtgqssd;
        }
        catch (Exception)
        {
            return dtgqssd;
        }
        finally
        {
            dtgqssd = null;
        }


    }

    #endregion GetQueueServiceStatus

    #region GetQueuePlanList
    public DataTable GetQueuePlanList(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchQueuePlanList(rtview);
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

    #region GetDepartmentDetail
    public DataTable GetDepartmentDetail()
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchDepartmentDetails();
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

    #region GetCallVisitFunction
    public DataTable GetCallVisitFunction(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchCallVisitFunction(rtview);
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

    #region GetCallVisitFunction
    public DataTable GetQueueNo(RTBEL rtview)
    {
        DataTable getqueuenodt = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            getqueuenodt = rtdata.DaoGetQueueNo(rtview);
            return getqueuenodt;
        }
        catch (Exception)
        {
            return getqueuenodt;
        }
        finally
        {
            getqueuenodt = null;
        }
    }
    #endregion

    #region SearchQueueNo
    public DataTable SearchQueueNo(RTBEL rtview)
    {
        DataTable searchqueuenodt = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            searchqueuenodt = rtdata.DaoSearchQueueNo(rtview);
            return searchqueuenodt;
        }
        catch (Exception)
        {
            return searchqueuenodt;
        }
        finally
        {
            searchqueuenodt = null;
        }
    }
    #endregion

    #region InsertAutoSMS
    public DataTable InsertAutoSMS(RTBEL rtview)
    {
        DataTable InsertSMS = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            InsertSMS = rtdata.DaoInsertAutoSMS(rtview);
            return InsertSMS;
        }
        catch (Exception)
        {
            return InsertSMS;
        }
        finally
        {
            InsertSMS = null;
        }
    }
    #endregion

    #region UpdateHoldQueue
    public void UpdateHoldQueue(RTBEL rtview)
    {
       
       

        try
        {
            rtdata.UpdateHoldQueue(rtview);
            
        }
        catch (Exception)
        {
                    }
        finally
        {
            
        }
    }
    #endregion

    #region UpdateStatusid
    public void UpdateStatusid(RTBEL rtview)
    {



        try
        {
            rtdata.UpdateStatusid(rtview);

        }
        catch (Exception)
        {
        }
        finally
        {

        }
    }
    #endregion

    #region GetHoldVisitFunction
    public DataTable GetHoldVisitFunction(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchHoldVisitFunction(rtview);
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

    #region Get Missed Visit Function
    public DataTable GetMissedVisitFunction(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchMissedVisitFunction(rtview);
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
    #endregion Get Missed Visit Function

    #region GetENDVisitFunction
    public DataTable GetENDVisitFunction(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchENDVisitFunction(rtview);
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

    #region GetFirstPlanInList
    public DataTable GetFirstPlanInList(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchFirstPlanInList(rtview);
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

    #region UpdateQueuestatusforCallMissed
    public string UpdateQueuestatusforCallMissed(RTBEL rtview)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = rtdata.SetQueuestatusforCallMissed(rtview);
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

    #region UpdateQueuestatusforCallMissedSMS
    public string UpdateQueuestatusforCallMissedSMS(RTBEL rtview)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = rtdata.SetQueuestatusforCallMissedSMS(rtview);
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

    #region UpdateQueuestatusforEND
    public string UpdateQueuestatusforEND(RTBEL rtview)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = rtdata.SetQueuestatusforEND(rtview);
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

    #region AddCustomerQueueTransactions
    public string AddCustomerQueueTransactions(RTBEL rtview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = rtdata.InsertCustomerQueueTransactions(rtview);
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
    public DataTable GetLastQueueTransactionID(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchLastQueueTransactionID(rtview);
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

    #region UpdateTransaferIdtoPlan
    public string UpdateTransaferIdtoPlan(RTBEL rtview)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = rtdata.SetTransaferIdtoPlan(rtview);
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

    #region AddCustomerQueuePlanOrderone
    public string AddCustomerQueuePlanOrderone(RTBEL rtview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = rtdata.InsertCustomerQueuePlanOrderone(rtview);
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

    #region show gridview loading for queue status

    public DataTable RTGridViewLoading(string selectedqueueno)
    {
        RTDAL rtdal = new RTDAL();
        try
        {
            return rtdal.GetRTGridViewLoading(selectedqueueno);
        }
        catch
        {
            throw;
        }
        finally
        {
            rtdal = null;
        }
    }


    #endregion

    #region Getting Queue Status - Getting My Queue Status

    public string GetMyQueueStatus(RTBEL crtqueuestatusbel)
    {
        RTDAL rtqueuestatusdal = new RTDAL();
        try
        {
            return rtqueuestatusdal.GetDALMyQueueStatus(crtqueuestatusbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            rtqueuestatusdal = null;
        }
    }

    #endregion Getting Queue Status - Getting My Queue Status
    
    #region GetDepartmentCountbyQueueno

    public int GetDepartmentCountbyQueueno(string selectedQueueCount)
    {
        try
        {
            RTDAL dal = new RTDAL();
            return dal.GetDepartmentCountByQueueNo(selectedQueueCount);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #endregion

    #region Get Next VIP Queue
    public DataTable GetNextVIPQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.DAOGetNextVIPQueue(rtview);
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
    #endregion Get Next VIP Queue

    #region Get Next Appointment Queue
    public DataTable GetNextAppointmentQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.DAOGetNextAppointmentQueue(rtview);
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
    #endregion Get Next Appointment Queue

    #region Update Appointment To Walkin Status
    public string UpdateAppointmentToWalkinStatus(RTBEL rtview)
    {
        string updatesucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            updatesucess = rtdata.DAOUpdateAppointmentToWalkinStatus(rtview);
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
    #endregion Update Appointment To Walkin Status

    #region Re-calling Queue

    public string RecallingQueue(RTBEL rtview)
    {
        string updatesucess = string.Empty;

        try
        {
            updatesucess = rtdata.DAORecallingQueue(rtview);
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
    #endregion Re-calling Queue

    #region Get load
    public DataTable Getload(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.DAOGetLoad(rtview);
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
    #endregion Get load


    #region Get Next Walkin Queue
    public DataTable GetNextWalkinQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.DAOGetNextWalkinQueue(rtview);
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
    #endregion Get Next Walkin Queue

    #region Get Next ImmediateAppointment Queue
    public DataTable GetNextImmediateAppointmentQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.DAOGetNextImmediateAppointmentQueue(rtview);
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
    #endregion Get Next Immediate Appointment Queue

    #region Getting Next Order
    public DataTable GettingNextOrder(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.DAOGettingNextOrder(rtview);
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

    #region Get Next Nurse Appointment Queue
    public DataTable GetNextNurseAppointmentQueue(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.DAOGetNextNurseAppointmentQueue(rtview);
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
    #endregion Getting Transaction Id

    #region Getting Transaction Id
    public DataTable GettingTransactionId(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.DAOGettingTransactionId(rtview);
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
    #endregion Getting Transaction Id

    #region Getting Fresh Queue Transaction Id
    public DataTable GettingFreshQueueTransactionId(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.DAOGettingFreshQueueTransactionId(rtview);
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
    #endregion Getting Transaction Id

    #region GettingOrderDetails

    public DataTable GettingOrderDetails(RTBEL rtview)
    {
        DataTable datatbl = new DataTable();
        //loginbel = new LoginBEL();

        try
        {
            datatbl = rtdata.SearchGettingOrderDetails(rtview);
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

    #region RT Add Customer Queue Plan Orders
    public string RTAddCustomerQueuePlanOrders(RTBEL rtview)
    {
        string insertsucess = string.Empty;
        //loginbel = new LoginBEL();

        try
        {
            insertsucess = rtdata.RTADDCustomerQueuePlanOrders(rtview);
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
    #endregion RT Add Customer Queue Plan Orders

    public DataTable GetQueuePosition(RTBEL smsview)
    {
        RTDAL smsdao = new RTDAL();
        DataTable dt = new DataTable();
        try
        {
            dt = smsdao.selectQueuePosition(smsview);
            return dt;
        }
        catch (Exception)
        {

            return dt;
        }
        finally
        {
            smsdao = null;
        }
    }

    #region retrievevisittnxidbyusingrepliedsms
    public DataTable Getvisittnxidbyusingrepliedsms(RTBEL smsview)
    {
        DataTable dt = new DataTable();
        RTDAL smsdao = new RTDAL();
        try
        {
            dt = smsdao.retrievevisittnxidbyusingrepliedsms(smsview);
            return dt;
        }
        catch (Exception)
        {

            throw;
        }
        finally
        {
            smsdao = null;
        }
    }
    #endregion retrievevisittnxidbyusingrepliedsms 

        public DataTable GetQueueTokenGenerationSentSMS(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                DataTable dt1 = new DataTable();
                // Getting Data From Dao
                dt1 = smsdao.GetDaoQueueTokenGenerationSentSMS(smsview);
                return dt1;
            }
            catch
            {
                throw;
            }
            finally
            {
                smsdao = null;
            }
        }

        public DataTable GetRetrieveSMSstatusFlag(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                DataTable dt = new DataTable();
                dt = smsdao.RetrieveSMSstatusFlag(smsview);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }

        public DataTable GetMissedQueueSendingSMS()
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                // Getting Data From Dao
                return smsdao.GetDaoMissedQueueSendingSMS();
            }
            catch
            {
                throw;
            }
            finally
            {
                smsdao = null;
            }
        }

        public DataTable GetMissedQueueSentSMS(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                // Getting Data From Dao
                return smsdao.GetDaoMissedQueueSentSMS(smsview);
            }
            catch
            {
                throw;
            }
            finally
            {
                smsdao = null;
            }
        }

        public DataTable GetMissedQueue()
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                // Getting Data From Dao
                return smsdao.DaoGetMissedQueue();
            }
            catch
            {
                throw;
            }
            finally
            {
                smsdao = null;
            }

        }

        public DataTable GetAutoQueueSendingSMS()
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                // Getting Data From Dao
                return smsdao.GetDaoAutoQueueSendingSMS();
            }
            catch
            {
                throw;
            }
            finally
            {
                smsdao = null;
            }
        }

        public DataTable GetAutoQueueSentSMS(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                // Getting Data From Dao
                return smsdao.GetDaoAutoQueueSentSMS(smsview);
            }
            catch
            {
                throw;
            }
            finally
            {
                smsdao = null;
            }
        }

        public DataTable GetIncomingSMS(RTBEL smsview)
        {
            RTDAL smsdao=new RTDAL();
            try
            {
                return smsdao.searchIncomingSMS(smsview);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }

        public DataTable GetQueueStatus(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                return smsdao.serachQueueStatus(smsview);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }

        public DataTable GetsmsStatusFlag(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                return smsdao.updateincomingsms(smsview);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }


        public DataTable GetQueuePosition123(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            DataTable dt = new DataTable();
            try
            {
                dt = smsdao.selectQueuePosition123(smsview);
                return dt;
            }
            catch (Exception)
            {

                return dt;
            }
            finally
            {
                smsdao = null;
            }
        }

        public DataTable GetpositionbyusingQueueno(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            DataTable dt = new DataTable();
            try
            {
                dt = smsdao.positionretrievebyusingQueueno(smsview);
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }

        #region retrieve CustomerName
        public DataTable GetCustomerName(RTBEL smsview)
        {
            DataTable dta = new DataTable();
            RTDAL smsdao = new RTDAL();
            try
            {
                return dta = smsdao.retrieveNameByCustID(smsview);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }
        #endregion retrieve CustomerName

        #region GetInsertNewSMS
        public string GetInsertNewSMS(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                string dt2;
                dt2= smsdao.InsertNewSMS(smsview);
                return dt2;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }
        #endregion GetInsertNewSMS

        #region GetInsertAlertSMS
        public string GetInsertAlertSMS(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                string dt2;
                dt2 = smsdao.InsertAlertSMS(smsview);
                return dt2;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }
        #endregion GetInsertAlertSMS


        #region GetInsertMissedQSMS
        public string GetInsertMissedQSMS(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                string dt2;
                dt2 = smsdao.InsertMissedQSMS(smsview);
                return dt2;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }
        #endregion GetInsertMissedQSMS

        

        #region GetDeptid
        public DataTable GetDeptid(RTBEL smsview)
        {
            DataTable dt4 = new DataTable();
            RTDAL smsdao = new RTDAL();
            try
            {
                dt4 = smsdao.selectDeptId(smsview);
                return dt4;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }
        #endregion GetDeptid

        #region GetStatusCount
        public DataTable GetStatusCount(RTBEL smsview)
        {
            DataTable dt7 = new DataTable();
            RTDAL smsdao = new RTDAL();
            try
            {
                dt7 = smsdao.SelectQueueStatus(smsview);
                return dt7;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }
        #endregion GetStatusCount

        #region GetStatusCount123
        public DataTable GetStatusCount123(RTBEL smsview)
        {
            DataTable dt7 = new DataTable();
            RTDAL smsdao = new RTDAL();
            try
            {
                dt7 = smsdao.SelectQueueStatus123(smsview);
                return dt7;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }
        #endregion GetStatusCount

        #region GetCustIDByUsingQueueno
        public DataTable GetCustIDByUsingQueueno(RTBEL smsview)
        {
            DataTable dt1 = new DataTable();
            RTDAL smsdao = new RTDAL();
            try
            {
                dt1 = smsdao.SelectCustIDByUsingQueueno(smsview);
                return dt1;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }

        }
        #endregion GetCustIDByUsingQueueno

        #region GetInsertReplySMS
        public string GetInsertReplySMS(RTBEL smsview)
        {
            RTDAL smsdao = new RTDAL();
            try
            {
                return smsdao.InsertReplySMS(smsview);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion GetInsertReplySMS

        #region retrieve CustomerNameAndMobileNo
        public DataTable GetCustomerNameMobile(RTBEL smsview)
        {
            DataTable dta = new DataTable();
            RTDAL smsdao = new RTDAL();
            try
            {
                return dta = smsdao.retrieveNamemobilenoByCustID(smsview);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }
        #endregion retrieve CustomerNameAndMobileNo

        #region GetretCustID

       public DataTable GetCustId(RTBEL smsview)
        {
            DataTable dta = new DataTable();
            RTDAL smsdao = new RTDAL();
            try
            {
                return dta = smsdao.retCustID(smsview);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                smsdao = null;
            }
        }
        #endregion GetretCustID

      

       #region Alert Message existance
       public DataTable GetAlertQMessageExistance(RTBEL smsview)
       {
           DataTable dta = new DataTable();
           RTDAL smsdao = new RTDAL();
           try
           {
               return dta = smsdao.getAlertMessageExistance(smsview);
           }
           catch (Exception)
           {

               throw;
           }
           finally
           {
               smsdao = null;
           }
       }
       #endregion Alert Message Existance
    }
