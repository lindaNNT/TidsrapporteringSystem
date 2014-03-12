﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataLayer;

namespace TidsrapporteringsSystem
{
    public class TidsrapporteringService : ITidsrapporteringService
    {
        #region ITidsrapporteringService Members

        //private DBHandler dbHandler; 

        public TidsrapporteringService()
        {
          //  dbHandler = new DBHandler("linda"); 
        }

        public Tidsrad GetLatestTidrad()
        {
            Tidsrad tidrad = new Tidsrad {  custNo = 1, 
                                            ordNr = 1, 
                                            contract = 1,
                                            service = "test 1 service", 
                                            frDt = 20140311, 
                                            toDt = 20140311, 
                                            debit = false,
                                            activity = "test 1 aktivitet",
                                            prodNo = "test 1 produkt",
                                            project = "test 1 projekt, kan vara tom",
                                            frTm = 1200,
                                            toTm = 1400,
                                            workedTime = 2,
                                            faktureradTime = 1,
                                            benamning = "test 1 benämning",
                                            internText = "test 1 interntext", 
                                            utlagg = false,
                                            adWage = false,
                                            defaultActivity = false
                                            };
            return tidrad;

        }

        public User GetUser()
        {
            User user = new User {  UserName = "linda", 
                                    Password = "Examen20", 
                                    Group = "Exjobb" };
            return user;
        }

        public List<string> GetAllProducts()
        {
            DBHandler dbHandler = new DBHandler("linda");
            dbHandler.openDBCon();
            List<string> ProdList = dbHandler.getAllProd();
            dbHandler.closeDBCon();
            return ProdList;
        }

        #endregion
    }
}
