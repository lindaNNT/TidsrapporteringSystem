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

        [OperationContract]
        string GetLastInsertedDay(string username);

        [OperationContract]
        Tidsrad GetLastTimeLineInsertedForSpecificDate(string username, string date);

        [OperationContract]
        List<Tidsrad> GetAllInsertedTimeLineOnOneDay(string username, string date);

        [OperationContract]
        List<DayStatus> GetAllInsertedDaysOfAMonth(string username, string month);

        [OperationContract]
        string GetMonthFlexForLogOnUser(string username, string flexYearMonth);

        [OperationContract]
        string GetTotalFlexForLogOnUser(string username);

        [OperationContract]
        List<DateTime> GetHolidayForLogOnUser(string username, string yearMonth);

        [OperationContract]
        string InsertNewTimeLine(Tidsrad tidsrad, string username);

        [OperationContract]
        void UpdateTimeLine(Tidsrad tidsrad);

        [OperationContract]
        void DeleteTimeLine(Tidsrad tidsrad);

        [OperationContract]
        List<string> GetAllProducts(string username);

        [OperationContract]
        List<string> GetAllProductsByActivity(string username, string activity);

        [OperationContract]
        List<string> GetAllCust(string username);

        [OperationContract]
        int GetCustNr(string username, string custName);

        [OperationContract]
        List<Order> GetAllOrdNr(string username, string custNo);

        [OperationContract]
        int GetContract(string username, int OrderNr);

        [OperationContract]
        List<string> GetAllServiceByOrderNr(string username, int orderNr);

        [OperationContract]
        List<string> GetActivitiesByDebit(string username, bool debit);

        [OperationContract]
        List<string> GetAllProjects(string username);
    }
}
