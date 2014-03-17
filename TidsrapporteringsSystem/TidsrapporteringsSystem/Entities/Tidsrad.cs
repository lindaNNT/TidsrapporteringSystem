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
        public int custNo { get; set; } //Kundnr

        [DataMember]
        public string custName { get; set; } //Kundnamn

        [DataMember]
        public int ordNr { get; set; } // vilka tjänster kunderna har.
        [DataMember]
        public int contract { get; set; } // hämtas med ordNr i getContract metod i DBHandler
        [DataMember]
        public string service { get; set; } // kan vara tom

        [DataMember]
        public bool debit { get; set; }
        [DataMember]
        public string  activity { get; set; }
        [DataMember]
        public string prodNo { get; set; } //artikel nr, är beroende av activity

        [DataMember]
        public string project { get; set; } // kan vara tom

        [DataMember]
        public int frTm { get; set; } // TTMM
        [DataMember]
        public int toTm { get; set; }
        [DataMember]
        public float workedTime { get; set; } // Ska räknas automatiskt från angiven tid.
        [DataMember]
        public float faktureradTime { get; set; } //Ska också räknas automatiskt från angiven tid. "0" som default

        [DataMember]
        public string benamning { get; set; } // är descr i DBHandler
        [DataMember]
        public string internText { get; set; } // är descr2 i DBHandler

        [DataMember]
        public bool utlagg { get; set; } //ska default vara false.

        [DataMember]
        public bool adWage { get; set; } // Skippa, ska alltid vara false.

        [DataMember]
        public bool defaultActivity { get; set; } // finns i appsetting.config filen. Heter invoReg.

        [DataMember]
        public bool active { get; set; } // Kolla att det finns värden.
    }
}
