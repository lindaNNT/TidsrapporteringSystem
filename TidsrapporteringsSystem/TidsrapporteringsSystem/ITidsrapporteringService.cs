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
        User GetUser();

        [OperationContract]
        List<string> GetAllProducts();
    }
}
