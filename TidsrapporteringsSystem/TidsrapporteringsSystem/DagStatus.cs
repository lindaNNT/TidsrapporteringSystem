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
    public class DagStatus
    {
        [DataMember]
        public string datum { get; set; }

        [DataMember]
        public string status { get; set; }
    }
}
