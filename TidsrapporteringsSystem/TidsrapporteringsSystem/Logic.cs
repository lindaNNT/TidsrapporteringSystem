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

        #region dates
        internal protected int extractYear(string date)
        {
            string year = date.Substring(0, 4);
            return Convert.ToInt32(year);
        }

        internal protected int extractMonth(string date)
        {
            string month = date.Substring(4, 2);
            if (month.Contains("0"))
            {
                month = month.Substring(1, 1);
            }
            int result = Convert.ToInt32(month);
            return result;
        }

        internal protected int extractDay(string date)
        {
            string day = date.Substring(6, 2);
            if (day.Contains("0"))
            {
                day = day.Substring(1, 1);
            }
            int result = Convert.ToInt32(day);
            return result;
        }
        #endregion

        internal protected int extractOrderNr(string text)
        {
            int endIndex = text.IndexOf("$");
            int result = Convert.ToInt32(text.Substring(0, endIndex));
            return result;
        }

        internal protected int extractAvtalNr(string text)
        {
            int startIndex = text.IndexOf("#");
            int endIndex = text.IndexOf("~")-startIndex;
            int result = Convert.ToInt32(text.Substring((startIndex+1), (endIndex-1)));
            return result;
        }

        internal protected string extractAvtalName(string text)
        {
            int startIndex = text.IndexOf("$");
            int endIndex = text.IndexOf("#") - startIndex;
            string result = text.Substring(startIndex + 1, endIndex - 1);
            return result;
        }

        internal protected string extractFakturaTyp(string text)
        {
            int startIndex = text.IndexOf("~")+1;
            string result = text.Substring(startIndex);
            return result;
        }

        internal protected string extractSerive(string service)
        {
            string nyStr = "";
            if (!service.Equals("tom") || !service.Equals(null) || !service.Equals(string.Empty))
            {
                nyStr = service.Substring(0, service.IndexOf("-") - 1);
            }
            return nyStr;
        }

        internal protected string extractProject(string proj)
        {
            string nyStr = "";
            if (!proj.Equals("tom") || !proj.Equals(null) || !proj.Equals(string.Empty))
            {
                nyStr = proj.Substring(0, proj.IndexOf(","));
            }
            return nyStr;
        }

        #region orders

        #endregion
        #endregion

        #region Convert

        internal protected bool debitConvertToBool(int faktureradTime)
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

        internal protected int debitConvertToNo(bool faktureradTime)
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

        internal protected bool defaultActivityToBool(int utlagg)
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

        internal protected int defaultActivityToNo(bool utlagg)
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

        #endregion

        #region inserts

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

                tidsrad.workedTime = Convert.ToInt32(dataTable.Rows[i]["Arbetad(H)"]);
                tidsrad.faktureradTime = Convert.ToInt32(dataTable.Rows[i]["Debitera(H)"]);
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
