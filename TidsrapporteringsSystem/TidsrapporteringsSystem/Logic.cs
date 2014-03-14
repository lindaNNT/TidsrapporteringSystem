using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TidsrapporteringsSystem
{
    public class Logic
    {
        #region extract date
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

        #endregion
    }
}
