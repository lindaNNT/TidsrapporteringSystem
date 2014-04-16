using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TidsrapporteringsSystem
{
    [ServiceContract]
    public interface ITidsrapporteringService
    {
        [OperationContract]
        User GetUser(string username, bool exist);

        [OperationContract]
        bool LogIn(string username);

        #region Create

        /// <summary>
        /// Insert a new timeline.
        /// </summary>
        /// <param name="tidsrad">Tidsrad</param>
        /// <param name="username">string</param>
        /// <returns>string</returns>
        [OperationContract]
        string InsertNewTimeLine(Tidsrad tidsrad, string username);
        #endregion

        #region Read

        #region get timlines

        /// <summary>
        /// Get the last day that the logon user inserted a timeline.
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>string</returns>
        [OperationContract]
        string GetLastInsertedDay(string username);

        /// <summary>
        /// Get the last timeline that was inserted on the selected date.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="date">string</param>
        /// <returns>Tidsrad</returns>
        [OperationContract]
        Tidsrad GetLastTimeLineInsertedForSpecificDate(string username, string date);

        /// <summary>
        /// Get all the timelines on the selected day.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="date">string</param>
        /// <returns>List of Tidsrad</returns>
        [OperationContract]
        List<Tidsrad> GetAllInsertedTimeLineOnOneDay(string username, string date);

        /// <summary>
        /// retrieve the timeline of stated AgrNo
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="date">string</param>
        /// <param name="agrNo">int</param>
        /// <returns>Tidsrad</returns>
        [OperationContract]
        Tidsrad GetTimeLineByAgrNo(string username, string date, int agrNo);

        /// <summary>
        /// Retrieve all dags from stated month that a user has inserted a timeline.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="month">string</param>
        /// <returns>List of DayStatus</returns>
        [OperationContract]
        List<DayStatus> GetAllInsertedDaysOfAMonth(string username, string month);

        #endregion

        #region get timeline info

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>List of strings</returns>
        [OperationContract]
        List<string> GetAllProducts(string username);

        /// <summary>
        /// Retrieve all products belonging to the selected activity.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="activity">string</param>
        /// <returns>List of strings</returns>
        [OperationContract]
        List<string> GetAllProductsByActivity(string username, string activity);

        /// <summary>
        /// Get all customer from database.
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>List of strings</returns>
        [OperationContract]
        List<string> GetAllCust(string username);

        /// <summary>
        /// Get the customer id of the specified customer name.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="custName">string</param>
        /// <returns>int</returns>
        [OperationContract]
        int GetCustNr(string username, string custName);

        /// <summary>
        /// Get all OrderNr from the specified customer ID.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="custNo">string</param>
        /// <returns>List of Orders</returns>
        [OperationContract]
        List<Order> GetAllOrdNr(string username, string custNo);

        /// <summary>
        /// Get the orders contract ID.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="OrderNr">int</param>
        /// <returns>int</returns>
        [OperationContract]
        int GetContract(string username, int OrderNr);

        /// <summary>
        /// Get all services that belong the the specific order.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="orderNr">int</param>
        /// <returns>List of strings</returns>
        [OperationContract]
        List<string> GetAllServiceByOrderNr(string username, int orderNr);

        /// <summary>
        /// Retrieve different activity depending on the selected debit.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="debit">bool</param>
        /// <returns>List of strings</returns>
        [OperationContract]
        List<string> GetActivitiesByDebit(string username, bool debit);

        /// <summary>
        /// Get all projects.
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>List of strings</returns>
        [OperationContract]
        List<string> GetAllProjects(string username);

        #endregion

        #region Get flex and holiday info

        /// <summary>
        /// Get all flex-hour of the selected month.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="flexYearMonth">string</param>
        /// <returns>string</returns>
        [OperationContract]
        string GetMonthFlexForLogOnUser(string username, string flexYearMonth);

        /// <summary>
        /// Get the total flex-hour that the user have.
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>string</returns>
        [OperationContract]
        string GetTotalFlexForLogOnUser(string username);

        /// <summary>
        /// Get the days that the user have holiday in a month.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="yearMonth">string</param>
        /// <returns>List of DateTime</returns>
        [OperationContract]
        List<DateTime> GetHolidayForLogOnUser(string username, string yearMonth);

        #endregion

        #endregion

        #region Update
        /// <summary>
        /// Update a existing timeline. And then send back an answer of the status.
        /// </summary>
        /// <param name="tidsrad">Tidsrad</param>
        /// <param name="username">string</param>
        /// <returns>string</returns>
        [OperationContract]
        string UpdateTimeLine(Tidsrad tidsrad, string username);
        
        #endregion

        #region Delete

        /// <summary>
        /// Deleting a timeline.
        /// </summary>
        /// <param name="tidsrad">Tidsrad</param>
        /// <param name="username">string</param>
        /// <returns>string</returns>
        [OperationContract]
        string DeleteTimeLine(Tidsrad tidsrad, string username);

        #endregion
    }
}
