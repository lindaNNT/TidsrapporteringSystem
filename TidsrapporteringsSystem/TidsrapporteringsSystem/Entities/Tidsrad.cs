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
    public class Tidsrad
    {
        public Tidsrad()
        {
            utlagg = false;
            adWage = false;
            defaultActivity = false;
        }
        
        [DataMember]
        public int frDt { get; set; }
        [DataMember]
        public int toDt { get; set; }

        [DataMember]
        public int custNo { get; set; } //Customer no.

        [DataMember]
        public string custName { get; set; } //Customer name.

        [DataMember]
        public int ordNr { get; set; } // Order that belong to customer.
        [DataMember]
        public int contract { get; set; } // Contract that belong to the order.
        [DataMember]
        public string service { get; set; } // Service that belong to the order.

        [DataMember]
        public bool debit { get; set; }
        [DataMember]
        public string  activity { get; set; }
        [DataMember]
        public string prodNo { get; set; } 

        [DataMember]
        public string project { get; set; } 

        [DataMember]
        public int frTm { get; set; } // TTMM
        [DataMember]
        public int toTm { get; set; }
        [DataMember]
        public float workedTime { get; set; } 
        [DataMember]
        public float faktureradTime { get; set; } 

        [DataMember]
        public string benamning { get; set; } 
        [DataMember]
        public string internText { get; set; } 

        [DataMember]
        public bool utlagg { get; set; } 

        [DataMember]
        public bool adWage { get; set; } 

        [DataMember]
        public bool defaultActivity { get; set; } 

        [DataMember]
        public bool active { get; set; } 

        [DataMember]
        public int agrNo { get; set; } 

        [DataMember]
        public int agrActNo { get; set; }
    }
}
