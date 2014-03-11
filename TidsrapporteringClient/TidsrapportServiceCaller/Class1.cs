using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace TidsrapportServiceCaller
{
    public class Class1
    {
        TidsrapporteringService.TidsrapporteringServiceClient host = new TidsrapportServiceCaller.TidsrapporteringService.TidsrapporteringServiceClient();
        public void test()
        {
            TidsrapporteringService.TidsrapporteringServiceClient host = 
                new TidsrapportServiceCaller.TidsrapporteringService.TidsrapporteringServiceClient();
            host.GetData();
        }
    }
}
