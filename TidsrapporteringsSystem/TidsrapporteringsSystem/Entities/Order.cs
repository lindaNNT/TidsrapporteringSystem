using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TidsrapporteringsSystem.Entities
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int OrderNo { get; set; }

        [DataMember]
        public string AvtalNamn { get; set; }

        [DataMember]
        public int AvtalNr { get; set; }

        [DataMember]
        public string Fakturatyp { get; set; }
    }
}
