using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for MasterBAL
/// </summary>
public class MasterBAL
{
    //MasterDAL masterdal = new MasterDAL();

    DataTable MySelectMasterDataTable = new DataTable();

    // BAL Constructor

    #region BAL Constructor

    public MasterBAL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion BAL Constructor


    // --------------------------------------------  User Master ----------------------------------------------

    // User Master - Roll Description - Drop Down List Loading

    #region User Master - Roll Description - Drop Down List Loading

    public DataTable GetRollDescription()
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.DaoGetRollDescription();
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion User Master - Roll Description - Drop Down List Loading


    // User Master - Department Description - Drop Down List Loading

    #region User Master - Department Description - Drop Down List Loading

    public DataTable GetDepartmentDescription()
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.DaoGetDepartmentDescription();
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion User Master - Department Description - Drop Down List Loading


    // User Master - User Name Checking - Available Or Not

    #region User Master - User Name Checking - Available Or Not

    public DataTable AvailableUserName(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetAvailableUserName(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion User Master - User Name Checking - Available Or Not


    // User Master - Insert

    #region User Master - Insert

    public string Insert(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.Insert(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion User Master - Insert

    // User Master - Grid View Loading

    #region User Master - Grid View Loading

    public DataTable UserGridViewLoading(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetUserGridViewLoading(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion User Master - Grid View Loading

    // User Master - Update

    #region Usert Master - Update

    public string UserUpdate(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetUserUpdate(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion User Master - Update

    //------------------------------   Device Master ------------------------------------------

    // Device Master - Insert

    #region Device Master - Insert

    public string DeviceInsert(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.DeviceInsert(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Device Master - Insert

    // Device Master - Update

    #region Device Master - Update

    public string DeviceUpdate(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetDeviceUpdate(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Device Master - Update

    // Device Master - Grid View Loading

    #region Device Master - Grid View Loading

    public DataTable DeviceGridViewLoading(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetDeviceGridViewLoading(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Device Master - Grid View Loading

    //------------------------------  Location Master ------------------------------------------

    // Location Master - Insert

    #region Location Master - Insert

    public string LocationInsert(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.LocationInsert(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Location Master - Insert


    // Location Master - Update

    #region Location Master - Update

    public string LocationUpdate(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetLocationUpdate(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Location Master - Update

    // Location Master - Grid View Loading

    #region Location Master - Grid View Loading

    public DataTable LocationGridViewLoading(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetLocationGridViewLoading(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Location Master - Grid View Loading


    // Location Master - Grid View Loading

    #region Schedule Master - Grid View Loading

    public DataTable ScheduleGridViewLoading(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetScheduleGridViewLoading(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Location Master - Grid View Loading

    // Location Master - Grid View Loading

    #region Schedule Master - Grid View Loading

    public DataTable ScheduleSearchLoading(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetScheduleLoading(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Location Master - Grid View Loading



    //------------------------------- Terminal Master --------------------------------------------------

    // Terminal Master - Insert

    #region Terminal Master - Insert

    public string TerminalInsert(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.TerminalInsert(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Terminal Master - Insert

    // Terminal Master - Update

    #region Terminal Master - Update

    public string TerminalUpdate(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetTerminalUpdate(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Terminal Master - Update

    // Terminal Master - Counting Terminal Type Id

    #region Terminal Master - Counting Terminal Type Id

    public DataTable GettingCountTerminal(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.DaoGettingCountTerminal(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Terminal Master - Counting Terminal Type Id

    // Terminal Master - Room Code - Drop Down List Loading

    #region Terminal Master - Room Code - Drop Down List Loading

    public DataTable GetRoomCode()
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.DaoGetRoomCode();
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Terminal Master - Room Code - Drop Down List Loading


    // Terminal Master - Terminal Type Description - Drop Down List Loading

    #region Terminal Master - Terminal Type Description - Drop Down List Loading

    public DataTable GetTerminalTypeDescription()
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.DaoGetTerminalTypeDescription();
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Terminal Master - Terminal Type Description - Drop Down List Loading

    // Terminal Master - Terminal Description - Drop Down List Loading

    #region Terminal Master - Terminal Description - Drop Down List Loading
    public DataTable GetTerminalDesc()
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetTerminalDesc();
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }
    #endregion

    // Terminal Master - Grid View Loading

    #region Terminal Master - Grid View Loading

    public DataTable TerminalGridViewLoading(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetTerminalGridViewLoading(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Terminal Master - Grid View Loading

    // Terminal Master - Terminal Ip Checking - Available Or Not

    #region Terminal Master - Terminal Ip Checking - Available Or Not

    public DataTable AvailableTerminalIp(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetAvailableTerminalIp(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion User Master - User Name Checking - Available Or Not


    //------------------------------- Department Master --------------------------------------------------

    // Department Master - Insert

    #region Department Master - Insert

    public string DepartmentInsert(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.DepartmentInsert(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Department Master - Insert

    // Department Master - Update

    #region Department Master - Update

    public string DepartmentUpdate(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetDepartmentUpdate(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Terminal Master - Update

    // Department Master - Grid View Loading

    #region Department Master - Grid View Loading

    public DataTable DepartmentGridViewLoading(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetDepartmentGridViewLoading(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Department Master - Grid View Loading



    //------------------------------   Device Master ------------------------------------------

    //------------------------------- Image Master --------------------------------------------------

    // Image Master - Insert

    #region Image Master - Insert
    public string ImageInsert(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.insertnewImage(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion

    // Image Master - Update
    #region Image Master - Update
    public string ImageUpdate(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.UpdateImagebyId(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }
    #endregion

    // Image Master Grid View Loading
    #region Load Image Grid View
    public DataTable ImageGridViewLoading()
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetImageData();
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }
    #endregion

    // ------------------------------- Schedule Master -----------------------------------------------

    // Schedule Master - Insert
    #region Schedule Master - Insert
    public string AddContent1(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            masterbel.ScheduleUpdatedBy = "admin";
            masterbel.ScheduleUpdateDateTime = DateTime.Now;

            return masterdal.insertnewContents(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }
    #endregion

    // ------------------------------- Content Master -----------------------------------------------

    // Schedule Master - Insert
    #region Schedule Master - Insert
    public string AddContents(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            masterbel.ScheduleUpdatedBy = "admin";
            masterbel.ScheduleUpdateDateTime = DateTime.Now;

            return masterdal.insertnewContents(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }
    #endregion

    // Schedule Master - Update
    public string ScheduleUpdate(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.UpdateSchedulebyId(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    public string ScheduleUpdateDisplay(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.UpdateSchedulebyIdDisplay(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    // Content Master - Insert
    #region Content Master - Insert
    public string AddContent(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            masterbel.ContentUpdateBy = "admin";
            masterbel.ContentUpdateDateTime = DateTime.Now;

            return masterdal.insertnewContents(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }
    #endregion

    // Content Master - Update

    #region Content - Update

    public string ContentUpdate(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.UpdateContentbyId(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion

    // Content Master - Grid View Loading

    #region Load Content View Loading

    public DataTable ContentGridViewLoading()
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetContentData();
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }


    #endregion

    // Content Master - get Content by ContentId

    #region Get Content by ContentId
    public DataTable GetContentbyId(int id)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetContentbyId(id);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }
    #endregion

    // --------------------------------------------- Queue Information in Admin Panel --------------------------------------------------

    #region Get TotalServingQueueCount for All Departments

    public string GetTotalServingQueueCountbyDeptId(int departmentId)
    {
        MasterDAL dal = new MasterDAL();
        try
        {
            return dal.GetServingQueueCountbyDept(departmentId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Get TotalServingQueueCount for All Departments

    public string GetTotalServingQueueCount()
    {
        MasterDAL dal = new MasterDAL();
        try
        {
            return dal.GetServingQueueCount();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Get TotalWaitingQueueCount by Departmentid

    public string GetWaitingQueueCountbyDept(int departmentid)
    {
        MasterDAL dal = new MasterDAL();
        try
        {
            return dal.GetWaitingQueueCountbyDept(departmentid);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region Get TotalWaitingQueueCount for All Departments

    public string GetWaitingQueueCount()
    {
        MasterDAL dal = new MasterDAL();
        try
        {
            return dal.GetWaitingQueueCount();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region Get TotalPendingQueueCount by Departmentid

    public string GetPendingQueueCountbyDept(int departmentid)
    {
        MasterDAL dal = new MasterDAL();
        try
        {
            return dal.GetPendingQueueCountbyDept(departmentid);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region Get TotalPendingQueueCount for All Departments

    public string GetPendingQueueCount()
    {
        MasterDAL dal = new MasterDAL();
        try
        {
            return dal.GetPendingQueueCount();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    #endregion

    #region Load Serving Queue Grid View by DepartmentId

    public DataTable LoadServingGridbyDeptId(int departmentId)
    {
        try
        {
            MasterDAL dal = new MasterDAL();
            return dal.LoadServingGridbyDeptId(departmentId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion


    #region Load Missed Queue Grid View by DepartmentId

    public DataTable LoadMissedGridbyDeptId(int departmentId)
    {
        try
        {
            MasterDAL dal = new MasterDAL();
            return dal.LoadMissedGridbyDeptId(departmentId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Serving Queue Grid View for All Departments

    public DataTable LoadServingGrid()
    {
        try
        {
            try
            {
                MasterDAL dal = new MasterDAL();
                return dal.LoadServingGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion


    #region Load Missed Queue Grid View for All Departments

    public DataTable LoadMissedGrid()
    {
        try
        {
            try
            {
                MasterDAL dal = new MasterDAL();
                return dal.LoadMissedGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Waiting Queue Grid View by DepartmentId

    public DataTable LoadWaitingGridbyDeptId(int departmentId)
    {
        try
        {
            MasterDAL dal = new MasterDAL();
            return dal.LoadWaitingGridbyDeptId(departmentId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Waiting Queue Grid View for All Departments

    public DataTable LoadWaitingGrid()
    {
        try
        {
            try
            {
                MasterDAL dal = new MasterDAL();
                return dal.LoadWaitingGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Pending Queue Grid View by DepartmentId

    public DataTable LoadPendingGridbyDeptId(int departmentId)
    {
        try
        {
            MasterDAL dal = new MasterDAL();
            return dal.LoadPendingGridbyDeptId(departmentId);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion

    #region Load Pending Queue Grid View for All Departments

    public DataTable LoadPendingGrid()
    {
        try
        {
            MasterDAL dal = new MasterDAL();
            return dal.LoadPendingGrid();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #endregion


    // Department Master - Grid View Loading

    #region Report Total Missed Queue - Grid View Loading

    public DataTable ReportAvgDept(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetAvgDept(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Department Master - Grid View Loading


    // Department Master - Avg

    #region Report Total Missed Queue - Grid View Loading

    public DataTable ReportAvg(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetAvg(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Department Master - Grid View Loading


    // Department Master - Grid View Loading

    #region Report Total Missed Queue - Grid View Loading

    public DataTable ReportTotalGridViewLoading(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetReportTotalGridViewLoading(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Department Master - Grid View Loading

    // Department Master - Nurse report

    #region Report Total Missed Queue - Nurse

    public DataTable ReportNurse(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetReportNurse(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Department Master - Nurse

    // Department Master - Nurse Appointment report

    #region Report Total Missed Queue - Nurse

    public DataTable ReportNurseAppointment(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetReportNurseAppointment(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Department Master - Nurse

    // Department Master - Doctor report

    #region Report Total Missed Queue - Doctor

    public DataTable ReportDoctor(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetReportDoctor(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Department Master - Doctor


    // Department Master - Doctor report Appointment

    #region Report Total Missed Queue - Doctor App

    public DataTable ReportDoctorApp(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetReportDoctorApp(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Department Master - Doctor




    // Department Master - Daily Report Loading

    #region Report Total Missed Queue - Daily Report Loading

    public DataTable ReportDailyLoading(MasterBEL masterbel)
    {
        MasterDAL masterdal = new MasterDAL();
        try
        {
            return masterdal.GetReportDailyLoading(masterbel);
        }
        catch
        {
            throw;
        }
        finally
        {
            masterdal = null;
        }
    }

    #endregion Department Master - Daily Report Loading


    // Getting Queue Status - Getting My Queue Number

    #region Getting Queue Status - Getting My Queue Number

    public DataTable GetMyQueueNumber(MasterBEL crtqueuestatusbel)
    {
        MasterDAL crtqueuestatusdal = new MasterDAL();
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

    public DataTable GetMyQueueStatus(MasterBEL crtqueuestatusbel)
    {
        MasterDAL crtqueuestatusdal = new MasterDAL();
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


}