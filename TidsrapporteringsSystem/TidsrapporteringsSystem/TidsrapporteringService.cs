using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataLayer;
using System.Data;
using System.Globalization;

namespace TidsrapporteringsSystem
{
    public class TidsrapporteringService : ITidsrapporteringService
    {
        #region ITidsrapporteringService Members

        #region Global variable
        private DBHandler _dbHandler;
        private bool _userExist;
        private string _userName;
        private Logic logic;
        #endregion

        #region Constructor
        public TidsrapporteringService()
        {
            logic = new Logic();
        }
        #endregion

        /// <summary>
        /// Hämta användaruppgifter.
        /// </summary>
        /// <returns>User</returns>
        public User GetUser(string username, bool exist)
        {
            #region try block
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
            #endregion

            #region Catch och Finally block
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
            #endregion
        }

        /// <summary>
        /// Kontrollera att användare finns.
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>bool</returns>
        public bool LogIn(string username)
        {
            #region try block
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
            #endregion

            #region Catch och Finally block
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
            #endregion
        }

        /// <summary>
        /// Get all Products
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>List of string</returns>
        public List<string> GetAllProducts(string username)
        {
            #region try block
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
            #endregion

            #region Catch och Finally block
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
            #endregion
        }

        /// <summary>
        /// Get the last day the user inserted an row.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="date">string</param>
        /// <returns>string</returns>
        public string GetLastInsertedDay(string username)
        {
            #region try block
            try
            {
                string todaysDate = DateTime.Now.ToString("yyyyMMdd");
                string dateResult = "";
                bool controll = false;
                int index = 1;
                while (controll == false)
                {
                    Tidsrad tidsradResult = GetLastTimeLineInsertedForSpecificDate(username, todaysDate);
                    if (tidsradResult.active == true)
                    {
                        dateResult = tidsradResult.frDt.ToString();
                        controll = true;
                        break;
                    }
                    else
                    {
                        todaysDate = DateTime.Now.AddDays(-index).ToString("yyyyMMdd");
                        index++;
                    }
                }
                return dateResult;

            }
            #endregion

            #region Catch och Finally block
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
            #endregion
        }

        /// <summary>
        /// Get inserted data from specific date.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="date">string</param>
        /// <returns>idsrad</returns>
        public Tidsrad GetLastTimeLineInsertedForSpecificDate(string username, string date)
        {
            #region try block
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
                            int lastRow = (dataTable.Rows.Count) - 1;
                            tidsrad = logic.createTidsrad(dataTable, lastRow);
                            tidsrad.active = true;
                        }
                        else
                        {
                            tidsrad.active = false;
                        }
                    }
                }
                return tidsrad;
            }
            #endregion

            #region Catch och Finally block
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
            #endregion
        }

        /// <summary>
        /// Get all the timeline inserted on the selected day.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="date">string</param>
        /// <returns>List of Tidsrad</returns>
        public List<Tidsrad> GetAllInsertedTimeLineOnOneDay(string username, string date)
        {
            #region try block
            try
            {
                List<Tidsrad> tidsradLista = new List<Tidsrad>();
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
                            for (int i = 0; i < dataTable.Rows.Count; i++)
                            {
                                Tidsrad tidsrad = logic.createTidsrad(dataTable, i);
                                tidsradLista.Add(tidsrad);
                            }
                        }
                    }
                }
                return tidsradLista;
            }
            #endregion

            #region Catch och Finally block
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
            #endregion
        }

        /// <summary>
        /// Get all day that has a timeline inserted in a month.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="month">string</param>
        /// <returns>List od DayStatus</returns>
        public List<DayStatus> GetAllInsertedDaysOfAMonth(string username, string month)
        {
            #region try block
            try
            {
                DateTime dateTime = DateTime.ParseExact(month, "yyyyMMdd", CultureInfo.InstalledUICulture);

                List<DayStatus> dateList = new List<DayStatus>();
                int currentMonth = logic.extractMonth(month);
                int compMonth = logic.extractMonth(dateTime.ToString("yyyyMMdd"));
                while (currentMonth == compMonth)
                {
                    Tidsrad tidsradResult = GetLastTimeLineInsertedForSpecificDate(username, dateTime.ToString("yyyyMMdd"));
                    if (tidsradResult.active == true)
                    {
                        DayStatus day = new DayStatus();
                        day.date = dateTime.ToString("yyyyMMdd");
                        day.status = tidsradResult.activity;
                        day.color = logic.dayColor(tidsradResult.activity);
                        dateList.Add(day);
                        dateTime = dateTime.AddDays(-1);
                        compMonth = logic.extractMonth(dateTime.ToString("yyyyMMdd"));
                    }
                    else
                    {
                        dateTime = dateTime.AddDays(-1);
                        compMonth = logic.extractMonth(dateTime.ToString("yyyyMMdd"));
                    }
                }
                return dateList;
            }
            #endregion

            #region Catch och Finally block
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
            #endregion
        }

        /// <summary>
        /// Get flex time.
        /// </summary>
        /// <param name="username">string</param>
        /// <param name="flexYearMonth">string</param>
        /// <returns>string</returns>
        public string GetMonthFlexForLogOnUser(string username, string flexYearMonth)
        {
            #region try block
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
            #endregion

            #region Catch och Finally block
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
            #endregion
        }

        /// <summary>
        /// Get the total flex for one user.
        /// </summary>
        /// <param name="username">string</param>
        /// <returns>string</returns>
        public string GetTotalFlexForLogOnUser(string username)
        {
            #region try block
            try
            {
                string flex = "";
                if (!username.Equals("") || !username.Equals(null))
                {
                    _dbHandler = new DBHandler(username);
                    _dbHandler.openDBCon();
                    flex = _dbHandler.getTotFlexForEmp();
                    _dbHandler.closeDBCon();
                }
                return flex;

            }
            #endregion

            #region Catch och Finally block
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
            #endregion
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

                        DateTime datetime = new DateTime((logic.extractYear(holiday)),
                                                            (logic.extractMonth(holiday)),
                                                            (logic.extractDay(holiday)),
                                                             0, 0, 0, 0);
                        dateList.Add(datetime);
                    }
                }

                return dateList;
            }

            #region Catch och Finally block
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
            #endregion
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
