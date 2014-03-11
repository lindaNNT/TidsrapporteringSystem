using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TidsrapporteringsSystem
{
    [DataContract]
    public class Tidsrad
    {
        [DataMember]
        public int frDt { get; set; }
        [DataMember]
        public int toDt { get; set; }

        [DataMember]
        public int custNo { get; set; }
        [DataMember]
        public int ordNo { get; set; }
        [DataMember]
        public int contract { get; set; } //Hämtas mha av getContract(int ordNo) metoden.
        [DataMember]
        public string service { get; set; } // Kan vara tom

        [DataMember]
        public bool debit { get; set; }
        [DataMember]
        public string activity { get; set; }
        [DataMember]
        public string prodNo { get; set; } // hänger ihop med activity

        [DataMember]
        public string project { get; set; } // kan vara tom

        [DataMember]
        public int frTm { get; set; }
        [DataMember]
        public int toTm { get; set; }
        [DataMember]
        public float workedTime { get; set; } // räknas automatiskt
        [DataMember]
        public float faktureradTime { get; set; }

        [DataMember]
        public string benamning { get; set; } // är string descr i DBHandler
        [DataMember]
        public string internText { get; set; } // är string desr2 i DBHandlar

        [DataMember]
        public bool utlagg { get; set; } // default false
        [DataMember]
        public bool adWage { get; set; } // default false
        [DataMember]
        public bool defaultActivity { get; set; } // hämtas från appsetting.config "invoReg"

        public int test { get; set; }
    }
}
