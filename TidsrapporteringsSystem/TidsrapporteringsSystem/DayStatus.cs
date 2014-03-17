using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace TidsrapporteringsSystem
{
    [DataContract]
    public class DayStatus
    {
        [DataMember]
        public string date { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string color { get; set; }
    }
}
