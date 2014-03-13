using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataLayer;
using System.Data;

namespace TidsrapporteringsSystem
{
    public class TidsrapporteringService : ITidsrapporteringService
    {
        #region ITidsrapporteringService Members

        private DBHandler _dbHandler;
        private bool _userExist;
        private string _userName;
        private Logic logic;

        public TidsrapporteringService()
        {
            logic = new Logic();
        }

        public Tidsrad GetLatestTidrad()
        {
            Tidsrad tidrad = new Tidsrad
            {
                custNo = 1,
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

        /// <summary>
        /// Hämta användaruppgifter.
        /// </summary>
        /// <returns>User</returns>
        public User GetUser(string username, bool exist)
        {
            try
            {
                User user = new User();
                if (exist == true)
                {
                    _dbHandler = new DBHandler(username);
                    _dbHandler.openDBCon();
                    user.UserName = username;
                    user.RealName = _dbHandler.getRealName();
                    user.Password = _dbHandler.dbPass;
                    user.Group = "Examen20";
                    _dbHandler.closeDBCon();
                }
                else
                {
                    user.UserName = "finns ej";
                    user.RealName = "finns ej";
                    user.Password = "finns ej";
                    user.Group = "finns ej";
                }
                return user;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            finally
            {
                if (_dbHandler != null)
                {
                    _dbHandler.closeDBCon();
                }
            }
        }

        /// <summary>
        /// Kontrollera att användare finns.
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>bool</returns>
        public bool LogIn(string username)
        {
            try
            {
                _dbHandler = new DBHandler(username);
                _dbHandler.openDBCon();
                bool result = _dbHandler.existsUser();
                _dbHandler.closeDBCon();
                _userExist = result;
                if (result == true)
                {
                    _userName = username;
                }
                return result;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            finally
            {
                if (_dbHandler != null)
                {
                    _dbHandler.closeDBCon();
                }
            }
        }

        /// <summary>
        /// Get all Products
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>List of string</returns>
        public List<string> GetAllProducts(string username)
        {
            try
            {
                List<string> ProdList = new List<string>();
                if (!username.Equals("") || !username.Equals(null))
                {
                    _dbHandler = new DBHandler(username);
                    _dbHandler.openDBCon();
                    ProdList = _dbHandler.getAllProd();
                    _dbHandler.closeDBCon();
                }
                return ProdList;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            finally
            {
                if (_dbHandler != null)
                {
                    _dbHandler.closeDBCon();
                }
            }
        }

        /// <summary>
        /// Get inserted data from specific date.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="date">string</param>
        /// <returns>idsrad</returns>
        public Tidsrad GetTimeLineHistoryForSpecificDate(string username, string date)
        {
            try
            {
                Tidsrad tidsrad = new Tidsrad();
                DataTable dataTable = new DataTable();
                if (date.Length == 8)
                {
                    if (!username.Equals("") || !username.Equals(null))
                    {
                        _dbHandler = new DBHandler(username);
                        _dbHandler.openDBCon();
                        dataTable = _dbHandler.getInfoRow(date);
                        _dbHandler.closeDBCon();
                        if (dataTable.Rows.Count > 0)
                        {
                            tidsrad.custName = dataTable.Rows[0]["Kundnamn"].ToString();
                            tidsrad.ordNr = Convert.ToInt32(dataTable.Rows[0]["Order"]);
                            tidsrad.workedTime = Convert.ToInt32(dataTable.Rows[0]["Arbetad(H)"]);
                            tidsrad.faktureradTime = Convert.ToInt32(dataTable.Rows[0]["Debitera(H)"]);
                            tidsrad.activity = dataTable.Rows[0]["Aktivitet"].ToString();
                            tidsrad.prodNo = dataTable.Rows[0]["Art"].ToString();
                            tidsrad.benamning = dataTable.Rows[0]["Benämning"].ToString();
                            tidsrad.internText = dataTable.Rows[0]["Intern text"].ToString();
                        }
                        else
                        {
                            tidsrad.benamning = "finns ingen träff";
                        }
                    }
                }
                return tidsrad;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            finally
            {
                if (_dbHandler != null)
                {
                    _dbHandler.closeDBCon();
                }
            }
        }

        /// <summary>
        /// Get flex time.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="flexYearMonth">string</param>
        /// <returns>string</returns>
        public string GetFlexForLogOnUser(string username, string flexYearMonth)
        {
            try
            {
                string flex = "";
                if (!username.Equals("") || !username.Equals(null))
                {
                    _dbHandler = new DBHandler(username);
                    _dbHandler.openDBCon();
                    flex = _dbHandler.getFlexMonth(flexYearMonth);
                    _dbHandler.closeDBCon();
                }
                return flex;

            }
            catch (FaultException fe)
            {
                throw fe;
            }
            finally
            {
                if (_dbHandler != null)
                {
                    _dbHandler.closeDBCon();
                }
            }
        }

        /// <summary>
        /// Get holidays.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="yearMonth">string</param>
        /// <returns>List of DateTime</returns>
        public List<DateTime> GetHolidayForLogOnUser(string username, string yearMonth)
        {
            try
            {
                List<string> holidayList = new List<string>();
                List<DateTime> dateList = new List<DateTime>();
                if (!username.Equals("") || !username.Equals(null))
                {
                    _dbHandler = new DBHandler(username);
                    _dbHandler.openDBCon();
                    holidayList = _dbHandler.getHolidays(yearMonth);
                    _dbHandler.closeDBCon();
                }
                if (holidayList.Count > 0)
                {
                    foreach (string holiday in holidayList)
                    {
                        
                        DateTime datetime = new DateTime(   (logic.extractYear(holiday)), 
                                                            (logic.extractMonth(holiday)), 
                                                            (logic.extractDay(holiday)), 
                                                             0, 0, 0, 0);
                        dateList.Add(datetime);
                    }
                }

                return dateList;
            }
            catch (FaultException fe)
            {
                throw fe;
            }
            finally
            {
                if (_dbHandler != null)
                {
                    _dbHandler.closeDBCon();
                }
            }
        }

        public void InsertNewTimeLine(Tidsrad tidsrad)
        {
            throw new NotImplementedException();
        }

        public Tidsrad GetLatestTimeLineInput(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateTimeLine(Tidsrad tidsrad)
        {
            throw new NotImplementedException();
        }

        public void DeleteTimeLine(Tidsrad tidsrad)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
