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
using System.Data;
using System.Data.SqlClient;
using TidsrapporteringASPClient.Repository;

namespace TidsrapporteringASPClient.LogedInPages
{
    public class SharedMethods : Page
    {
        private FavoritCRUD FD = new FavoritCRUD(); 
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
        /// Create customer XML file.
        /// </summary>
        /// <param name="user">string</param>
        public void createCustomerXML(string user)
        {
            try
            {
                var path = String.Format("{0}Repository\\Customer.xml", AppDomain.CurrentDomain.BaseDirectory);
                var custList = getCust(user);

                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "ISO-8859-1", "yes"),
                    new XComment("Customer XML file"),
                    new XElement("complete",
                        from el in custList
                        select new XElement("option", el,
                            new XAttribute("value", el.Substring(0, el.IndexOf("-") - 1))
                        )// option
                    ) // complete
                ); //Beigner tag
                try
                {
                    doc.Save(path);
                }
                catch (Exception saveEx)
                {
                    throw saveEx;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void createOrderXML(string user, string custID)
        {
            try
            {
                var path = String.Format("{0}Repository\\Order.xml", AppDomain.CurrentDomain.BaseDirectory);
                var orderList = getOrder(user, Convert.ToInt32(custID));

                XDocument doc = new XDocument(
                new XDeclaration("1.0", "ISO-8859-1", "yes"),
                new XComment("Order XML file"),
                    new XElement("complete",
                        from el in orderList
                        select new XElement("option", el.OrderNo + " - " + el.AvtalNamn,
                            new XAttribute("value", el.CustNo)
                        )// option
                    ) // complete
                ); //Beigner tag
                try
                {
                    doc.Save(path);
                }
                catch (Exception saveEx)
                {
                    throw saveEx;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void createServiceXML(string user, string orderID)
        {
            try
            {
                var path = String.Format("{0}Repository\\TidsrapporteringService.xml", AppDomain.CurrentDomain.BaseDirectory);
                var serviceList = getService(user, Convert.ToInt32(orderID));

                XDocument doc = new XDocument(
                    new XDeclaration("1.0", "ISO-8859-1", "yes"),
                    new XComment("Servie XML file"),
                    new XElement("complete",
                        from el in serviceList
                        select new XElement("option", el,
                            new XAttribute("value", el.Substring(0, el.IndexOf("-") - 1))
                        )// option
                    ) // complete
                ); //Beigner tag
                try
                {
                    doc.Save(path);
                }
                catch (Exception saveEx)
                {
                    throw saveEx;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        public trService.Tidsrad getTidsradByAgrNo(string user, string date, string agrNo)
        {
            try
            {
                var tidsrad = new trService.Tidsrad();

                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        tidsrad = host.GetTimeLineByAgrNo(user, date, Convert.ToInt32(agrNo));
                    }
                }
                return tidsrad;
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
        public List<trService.Order> getOrder(string user, int cust)
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
        /// Get one specific order
        /// </summary>
        /// <param name="user">string</param>
        /// <param name="cust">string</param>
        /// <param name="order">string</param>
        /// <returns>Order</returns>
        public trService.Order getOrderByOrderID(string user, string cust, string order)
        {
            try
            {
                using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                        {
                            int custID = host.GetCustNr(user, cust);
                            List<trService.Order> list = getOrder(user, custID);
                            trService.Order _order = new TidsrapporteringASPClient.trService.Order();
                            for (int i = 0; i < list.Count; i++)
                            {
                                int _orderNr = Convert.ToInt32(order);
                                if (list.ElementAt(i).OrderNo == _orderNr)
                                {
                                    _order = list.ElementAt(i);
                                    break;
                                }
                            }
                            return _order;
                }
            }
            catch(Exception ex)
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

        /// <summary>
        /// Convert debit bool-value to string-value.
        /// </summary>
        /// <param name="debit">bool</param>
        /// <returns>string</returns>
        public string convertDebitToString(bool debit)
        {
            try
            {
                string response = "";
                if (debit == false)
                {
                    response = "Nej";
                }
                else
                {
                    response =  "Ja";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Trim time string from TTMM to TT:MM.
        /// </summary>
        /// <param name="time">string</param>
        /// <returns>string</returns>
        public string trimTime(string time)
        {
            try
            {
                string _time = "";
                if (time.Length == 3)
                {
                    _time = "0" + time.Substring(0, 1) + ":" + time.Substring(1, 2);
                }
                else
                {
                    _time = time.Substring(0, 2) + ":" + time.Substring(2, 2);
                }
                return _time;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Favorit> fillFavorit()
        {
            try
            {
                return FD.getFavoritByActID(6);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
