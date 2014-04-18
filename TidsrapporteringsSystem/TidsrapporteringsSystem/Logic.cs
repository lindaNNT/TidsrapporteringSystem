using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace TidsrapporteringsSystem
{
    public class Logic
    {
        #region extract

        #region extract dates

        /// <summary>
        /// Get the year from a date string and return a int.
        /// </summary>
        /// <param name="date">string</param>
        /// <returns>int</returns>
        internal protected int extractYear(string date)
        {
            try
            {
                string year = date.Substring(0, 4);
                return Convert.ToInt32(year);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the month from the inserted date and return a int.
        /// </summary>
        /// <param name="date">string</param>
        /// <returns>int</returns>
        internal protected int extractMonth(string date)
        {
            try
            {
                string month = date.Substring(4, 2);
                if (month.Contains("0"))
                {
                    month = month.Substring(1, 1);
                }
                int result = Convert.ToInt32(month);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the day from the inserted date.
        /// </summary>
        /// <param name="date">string</param>
        /// <returns>int</returns>
        internal protected int extractDay(string date)
        {
            try
            {
                string day = date.Substring(6, 2);
                if (day.Contains("0"))
                {
                    day = day.Substring(1, 1);
                }
                int result = Convert.ToInt32(day);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Get the orderNr from a string.
        /// </summary>
        /// <param name="text">string</param>
        /// <returns>int</returns>
        internal protected int extractOrderNr(string text)
        {
            try
            {
                int endIndex = text.IndexOf("$");
                int result = Convert.ToInt32(text.Substring(0, endIndex));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the contract Nr from a string.
        /// </summary>
        /// <param name="text">string</param>
        /// <returns>int</returns>
        internal protected int extractContractNr(string text)
        {
            try
            {
                int startIndex = text.IndexOf("#");
                int endIndex = text.IndexOf("~") - startIndex;
                int result = Convert.ToInt32(text.Substring((startIndex + 1), (endIndex - 1)));
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the contract name from a string.
        /// </summary>
        /// <param name="text">string</param>
        /// <returns>string</returns>
        internal protected string extractContractName(string text)
        {
            try
            {
                int startIndex = text.IndexOf("$");
                int endIndex = text.IndexOf("#") - startIndex;
                string result = text.Substring(startIndex + 1, endIndex - 1);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the faktura type from a string.
        /// </summary>
        /// <param name="text">string</param>
        /// <returns>string</returns>
        internal protected string extractFakturaTyp(string text)
        {
            try
            {
                int startIndex = text.IndexOf("~") + 1;
                string result = text.Substring(startIndex);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the service from a string.
        /// </summary>
        /// <param name="service">string</param>
        /// <returns>string</returns>
        internal protected string extractService(string service)
        {
            try
            {
                string nyStr = "";
                if (!service.Equals("tom") || !service.Equals(null) || !service.Equals(string.Empty))
                {
                    nyStr = service.Substring(0, service.IndexOf("-") - 1);
                }
                return nyStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get project from a string.
        /// </summary>
        /// <param name="proj">string</param>
        /// <returns>string</returns>
        internal protected string extractProject(string proj)
        {
            try
            {
                string nyStr = "";
                if (!proj.Equals("tom") || !proj.Equals(null) || !proj.Equals(string.Empty))
                {
                    nyStr = proj.Substring(0, proj.IndexOf(","));
                }
                return nyStr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Convert

        /// <summary>
        /// Get debit int and then convert to bool value.
        /// </summary>
        /// <param name="faktureradTime">int</param>
        /// <returns>bool</returns>
        internal protected bool debitConvertToBool(int faktureradTime)
        {
            try
            {
                if (faktureradTime == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the debit bool value and convert to int.
        /// </summary>
        /// <param name="faktureradTime">bool</param>
        /// <returns>int</returns>
        internal protected int debitConvertToNo(bool faktureradTime)
        {
            try
            {
                if (faktureradTime == true)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get default activity and convert int to bool.
        /// </summary>
        /// <param name="utlagg">int</param>
        /// <returns>bool</returns>
        internal protected bool defaultActivityToBool(int utlagg)
        {
            try
            {
                if (utlagg == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get default activity bool value and then convert to int.
        /// </summary>
        /// <param name="utlagg">bool</param>
        /// <returns>int</returns>
        internal protected int defaultActivityToNo(bool utlagg)
        {
            try
            {
                if (utlagg == true)
                {
                    return 1;
                }
                else
                {
                    return 2065;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Return the color name of the day, depending on activity inserted.
        /// </summary>
        /// <param name="activity">string</param>
        /// <returns>string</returns>
        internal protected string dayColor(string activity)
        {
            try
            {
                string color = "";
                if (activity.Equals("Frånvaro") ||
                    activity.Equals("Tjänstledig") ||
                    activity.Equals("Föräldraledig") ||
                    activity.Equals("Kompledig") ||
                    activity.Equals("Vård av barn") ||
                    activity.Equals("Sjuk") ||
                    activity.Equals("Ledig utan avdrag") ||
                    activity.Equals("Pappaledig(10 dgr)"))
                {
                    color = "red";
                }
                else if (activity.Equals("Semester"))
                {
                    color = "green";
                }
                else
                {
                    color = "blue";
                }
                return color;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Convert hours to minuts.
        /// </summary>
        /// <param name="hour">float</param>
        /// <returns>float</returns>
        internal protected float hourToMin(float hour)
        {
            try
            {
                float minuts = 0;
                if (hour > 0)
                {
                    minuts = hour * 60;
                }
                return minuts;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region inserts

        /// <summary>
        /// Sets values from DataTable at a specific row to Tidsrad-entity.
        /// </summary>
        /// <param name="dataTable">DataTable</param>
        /// <param name="i">int</param>
        /// <returns>Tidsrad</returns>
        internal protected Tidsrad createTidsrad(DataTable dataTable, int i)
        {
            try
            {
                Tidsrad tidsrad = new Tidsrad();
                tidsrad.frDt = Convert.ToInt32(dataTable.Rows[i]["Datum från"]);
                tidsrad.toDt = Convert.ToInt32(dataTable.Rows[i]["Datum till"]);
                tidsrad.frTm = Convert.ToInt32(dataTable.Rows[i]["Från tid"]);
                tidsrad.toTm = Convert.ToInt32(dataTable.Rows[i]["Till tid"]);

                tidsrad.custName = dataTable.Rows[i]["Kundnamn"].ToString();
                tidsrad.custNo = Convert.ToInt32(dataTable.Rows[i]["CustNo"].ToString());
                tidsrad.ordNr = Convert.ToInt32(dataTable.Rows[i]["Order"]);
                tidsrad.contract = Convert.ToInt32(dataTable.Rows[i]["KontraktNr"]);

                tidsrad.service = dataTable.Rows[i]["Service"].ToString();
                tidsrad.debit = debitConvertToBool(Convert.ToInt32(dataTable.Rows[i]["Debitera(H)"]));
                tidsrad.activity = dataTable.Rows[i]["Aktivitet"].ToString();
                tidsrad.project = dataTable.Rows[i]["Projekt"].ToString();

                tidsrad.workedTime = float.Parse(dataTable.Rows[i]["Arbetad(H)"].ToString());
                tidsrad.faktureradTime = float.Parse(dataTable.Rows[i]["Debitera(H)"].ToString());
                tidsrad.activity = dataTable.Rows[i]["Aktivitet"].ToString();
                tidsrad.prodNo = dataTable.Rows[i]["Art"].ToString();
                tidsrad.benamning = dataTable.Rows[i]["Benämning"].ToString();
                tidsrad.internText = dataTable.Rows[i]["Intern text"].ToString();
                tidsrad.utlagg = false;
                tidsrad.adWage = false;
                tidsrad.defaultActivity = defaultActivityToBool(Convert.ToInt32(dataTable.Rows[i]["DefaultActivity"]));
                tidsrad.agrActNo = Convert.ToInt32(dataTable.Rows[i]["AgrActNo"]);
                tidsrad.agrNo = Convert.ToInt32(dataTable.Rows[i]["AgrNo"]);
                return tidsrad;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        #endregion
    }
}
