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
        Tidsrad GetLatestTidrad();

        [OperationContract]
        User GetUser(string username, bool exist);

        [OperationContract]
        bool LogIn(string username);

        [OperationContract]
        List<Tidsrad> GetTimeLineHistoryForLogOnUser(User user);

        [OperationContract]
        string GetFlexForLogOnUser(string username, string flexYearMonth);

        [OperationContract]
        string GetHolydayForLogOnUser(User user);

        [OperationContract]
        void InsertNewTimeLine(Tidsrad tidsrad);

        [OperationContract]
        Tidsrad GetLatestTimeLineInput(User user);

        [OperationContract]
        void UpdateTimeLine(Tidsrad tidsrad);

        [OperationContract]
        void DeleteTimeLine(Tidsrad tidsrad);

        [OperationContract]
        List<string> GetAllProducts(string username);
    }
}
