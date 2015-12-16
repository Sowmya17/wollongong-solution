using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


public class QueueController
{
    // Queue Display - Getting Direction ID

    #region Queue Display - Direction ID

    public DataTable GetDirectionID(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetDirectionID(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }

    #endregion Queue Display - Direction ID

    // Queue Display - Getting Direction ID1

    #region Queue Display - Direction ID1

    public DataTable GetDirectionID1(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetDirectionID1(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }

    #endregion Queue Display - Direction ID1


    // Queue Display - Getting Direction ID1

    #region Queue Display - Direction ID2

    public DataTable GetDirectionID2(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetDirectionID2(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }

    #endregion Queue Display - Direction ID2

    // Queue Display - Getting Direction ID billing

    #region Queue Display - Direction ID

    public DataTable GetDirectionIDBilling(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetDirectionIDBilling(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }

    #endregion Queue Display - Direction ID

    // Queue Display - Getting Direction ID CounterDisplay

    #region Queue Display - Direction ID CounterDisplay

    public DataTable GetDirectionIDCounterDisplay(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetDirectionIDCounterDisplay(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }

    #endregion Queue Display - Direction ID

    // Queue Display - Getting Next Three Tokens

    #region Queue Display - Getting Next Three Tokens

    public DataTable GetNextThreeTokens(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetNextThreeTokens(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }

    #endregion Queue Display - Direction ID




    // Queue Display - Getting Next Tokens

    #region Queue Display - Getting Next Tokens

    public DataTable GetNextTokens(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetNextTokens(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }

    #endregion Queue Display - Getting Next Tokens

    // Queue Display - Missed Queue

    #region Queue Display - Missed Queue

    public DataTable GetMissedQueue(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetMissedQueue(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }

    #endregion Queue Display - Missed Queue

    #region Queue Display - Changing Colour Status

    public DataTable ChangingColourStatus(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();

        try
        {
            return queuedao.DaoChangingColourStatus(queueview);

        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }

    #endregion Queue Display - Changing Colour Status



    // Queue Display - Getting Department Name
    #region Queue Display - Getting Department Name
    public DataTable GetDepartmentName(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetDepartmentName(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }
    #endregion


    // Queue Display - Getting Department Image CD
    #region Queue Display - Getting Department Image CD
    public DataTable GetDepartmentImage(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetDepartmentImage(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }
    #endregion


    // Queue Display -  Display Details

    #region Queue Display - Display Details

    public DataTable GetDisplayScrollText(QueueView queueview)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.DaoGetDisplayScrollText(queueview);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }

    #endregion Queue Display - Direction ID


    // Queue Display - Waiting Time
    #region Queue Display - Getting Department Waiting
    public DataTable GetWaitingTime(int deptid)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.WaitingTime(deptid);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }
    #endregion

    // Queue Display - Serving  Time
    #region Queue Display - Getting Department Serving
    public DataTable GetServingTime(int deptid)
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.ServingTime(deptid);
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }
    #endregion

    // Queue Display - 
    #region Queue Display - Getting Department Name
    public DataTable GetWaitingTimeDeptid()
    {
        QueueDAO queuedao = new QueueDAO();
        try
        {
            return queuedao.WaitingTimeDeptid();
        }
        catch
        {
            throw;
        }
        finally
        {
            queuedao = null;
        }
    }
    #endregion
}

