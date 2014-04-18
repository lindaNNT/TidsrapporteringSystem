using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;

namespace TidsrapporteringASPClient.LogedInPages
{
    public class SharedMethods : Page
    {
        /// <summary>
        /// Check if the user exist.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool controllOfUsername(string username)
        {
            try
            {
                using (trService.TidsrapporteringServiceClient host = new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                {
                    return host.LogIn(username);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Get all timeline inserted on one month.
        /// </summary>
        /// <param name="year">string</param>
        /// <param name="month">string</param>
        /// <param name="user">string</param>
        /// <returns>List of Tidsrad</returns>
        public List<trService.Tidsrad> monthInserts(string user, string year, string month)
        {
            try
            {
                List<trService.Tidsrad> list = new List<TidsrapporteringASPClient.trService.Tidsrad>();
                if (controllOfUsername(user))
                {
                    list = new List<TidsrapporteringASPClient.trService.Tidsrad>();
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        List<trService.DayStatus> dayList = host.GetAllInsertedDaysOfAMonth(user, year + month + DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month))).ToList();
                        foreach (var day in dayList)
                        {
                            var insertedDayList = host.GetAllInsertedTimeLineOnOneDay(user, day.date).ToList();
                            foreach (var insertedDay in insertedDayList)
                            {
                                list.Add(insertedDay);
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get a list of all timelines the is inserted on the selected week.
        /// </summary>
        /// <param name="user">string</param>
        /// <param name="cal">Calendar</param>
        /// <returns>List of Tidsrad</returns>
        public List<trService.Tidsrad> weekInserts(string user, System.Web.UI.WebControls.Calendar cal)
        {
            try
            {
                List<trService.Tidsrad> list = new List<TidsrapporteringASPClient.trService.Tidsrad>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        var dayList = cal.SelectedDates;

                        foreach (DateTime day in dayList)
                        {
                            var date = day.ToString("yyyyMMdd");
                            var insertedDayList = host.GetAllInsertedTimeLineOnOneDay(user, date).ToList();
                            if (insertedDayList.Count > 0)
                            {
                                foreach (var insertedDay in insertedDayList)
                                {
                                    list.Add(insertedDay);
                                }
                            }
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the timelines that was last inserted.
        /// </summary>
        /// <param name="user">string</param>
        /// <param name="cal">Calendar</param>
        /// <returns>List of Tidsrad</returns>
        public List<trService.Tidsrad> getLastInsert(string user, System.Web.UI.WebControls.Calendar cal)
        {
            try
            {
                List<trService.Tidsrad> list = new List<TidsrapporteringASPClient.trService.Tidsrad>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        string date = host.GetLastInsertedDay(user);
                        Session["Date"] = date;
                        cal.SelectedDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
                        list = host.GetAllInsertedTimeLineOnOneDay(user, date).ToList();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all inserted timelines on selected day.
        /// </summary>
        /// <param name="user">string</param>
        /// <param name="cal">Calendar</param>
        /// <returns>List of Tidsrad</returns>
        public List<trService.Tidsrad> getSelectedDayInserts(string user, System.Web.UI.WebControls.Calendar cal)
        {
            try
            {
                List<trService.Tidsrad> list = new List<TidsrapporteringASPClient.trService.Tidsrad>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        string date = cal.SelectedDate.ToString("yyyyMMdd");
                        list = host.GetAllInsertedTimeLineOnOneDay(user, date).ToList();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all days that have timeline in a month.
        /// </summary>
        /// <param name="user">string</param>
        /// <param name="year">string</param>
        /// <param name="month">string</param>
        /// <returns>List of DayStatus</returns>
        public List<trService.DayStatus> getMonthList(string user, string year, string month)
        {
            try
            {
                List<trService.DayStatus> dayList = new List<TidsrapporteringASPClient.trService.DayStatus>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        dayList = host.GetAllInsertedDaysOfAMonth
                            (user, year + month + DateTime.DaysInMonth
                                (Convert.ToInt32(year), Convert.ToInt32(month))).ToList();
                    }
                }
                return dayList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all activitys.
        /// </summary>
        /// <param name="user">string</param>
        /// <param name="debit">string</param>
        /// <returns>List of strings</returns>
        public List<string> getActivity(string user, string debit)
        {
            try
            {
                List<string> list = new List<string>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetActivitiesByDebit(user, Convert.ToBoolean(debit)).ToList();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all articels belonged to activity.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="activity"></param>
        /// <returns></returns>
        public List<string> getArticel(string user, string activity)
        {
            try
            {
                List<string> list = new List<string>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetAllProductsByActivity(user, activity).ToList();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all projects.
        /// </summary>
        /// <param name="user">string</param>
        /// <returns>List of strings</returns>
        public List<string> getProjects(string user)
        {
            try
            {
                List<string> list = new List<string>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetAllProjects(user).ToList();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all customers.
        /// </summary>
        /// <param name="user">string</param>
        /// <returns>List of strings</returns>
        public List<string> getCust(string user)
        {
            try
            {
                List<string> list = new List<string>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetAllCust(user).ToList();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all Order belonging to customer.
        /// </summary>
        /// <param name="user">string</param>
        /// <param name="cust">string</param>
        /// <returns>List of Order</returns>
        public List<trService.Order> getOrder(string user, string cust)
        {
            try
            {
                List<trService.Order> list = new List<trService.Order>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetAllOrdNr(user, cust).ToList();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get all services that belongs to order.
        /// </summary>
        /// <param name="user">string</param>
        /// <param name="order">int</param>
        /// <returns>List of strings</returns>
        public List<string> getService(string user, int order)
        {
            try
            {
                List<string> list = new List<string>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetAllServiceByOrderNr(user, order).ToList();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
