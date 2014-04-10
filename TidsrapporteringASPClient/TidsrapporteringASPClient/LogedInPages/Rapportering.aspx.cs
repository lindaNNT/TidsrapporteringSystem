﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace TidsrapporteringASPClient
{
    public partial class Rapportering : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"].Equals(null) || Session["user"].Equals(string.Empty))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    Calender.SelectedDate = DateTime.Today; 
                    fillProjects();
                    fillCust();
                    fillOrderByCust();
                    fillService();
                    fillActivity();
                    fillArt();
                    fillFlexAndHoliday();
                    controllOfDebit();
                    //tbAr.Text = DateTime.Now.Year.ToString();
                    //ddlManad.SelectedValue = DateTime.Now.ToString("MM");
                    fillGridViewOneDay();
                }
                else
                {
                }
            }
        }

        private void fillActivity()
        {
            try
            {
                ddlAktivitet.Items.Clear();
                string user = Session["user"].ToString();
                List<string> list = new List<string>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetActivitiesByDebit(user, Convert.ToBoolean(ddlDebit.SelectedValue)).ToList();
                        foreach (string str in list)
                        {
                            ListItem li = new ListItem();
                            li.Text = str;
                            li.Value = str;
                            ddlAktivitet.Items.Add(li);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Activity");
                throw ex;
            }
        }

        private void fillArt()
        {
            try
            {
                ddlArt.Items.Clear();
                string user = Session["user"].ToString();
                List<string> list = new List<string>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetAllProductsByActivity(user, ddlAktivitet.SelectedItem.Text).ToList();
                        foreach (string str in list)
                        {
                            string artNr = str.Substring(0, str.IndexOf("?"));
                            string artName = str.Substring(str.IndexOf("?") + 2);
                            if (artName.Contains("??"))
                            {
                                artName = artName.Substring(0, artName.Length - 2);
                            }
                            ListItem li = new ListItem();
                            li.Text = artNr + " - " + artName;
                            li.Value = artNr;
                            ddlArt.Items.Add(li);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception artikel");
                throw ex;
            }
        }

        private void fillProjects()
        {
            try
            {
                ddlProj.Items.Clear();
                string user = Session["user"].ToString();
                List<string> list = new List<string>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetAllProjects(user).ToList();
                        ListItem empty = new ListItem {Text = "Valfritt", Value = string.Empty};
                        ddlProj.Items.Add(empty);
                        foreach (string str in list)
                        {
                            ListItem li = new ListItem();
                            string projName = str.Substring(0, str.IndexOf("?"));
                            string projId = str.Substring(str.IndexOf("?") + 2);
                            li.Text = projId + " - " + projName;
                            li.Value = projId;
                            ddlProj.Items.Add(li);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception project");
                throw ex;
            }
        }

        private void fillCust()
        {
            try
            {
                ddlKundNamn.Items.Clear();
                string user = Session["user"].ToString();
                List<string> list = new List<string>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetAllCust(user).ToList();
                        foreach (string str in list)
                        {
                            ListItem li = new ListItem();
                            li.Text = str;
                            li.Value = str;
                            ddlKundNamn.Items.Add(li);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception customer");
                throw ex;
            }
        }

        private void fillOrderByCust()
        {
            try
            {
                ddlOrder.Items.Clear();
                string user = Session["user"].ToString();
                List<trService.Order> list = new List<trService.Order>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        list = host.GetAllOrdNr(user, ddlKundNamn.SelectedItem.Text).ToList();
                        foreach (var str in list)
                        {
                            ListItem li = new ListItem();
                            li.Text = str.OrderNo + " - " + str.AvtalNamn;
                            li.Value = str.OrderNo.ToString();
                            ddlOrder.Items.Add(li);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception order");
                throw ex;
            }
        }

        private void fillService()
        {
            try
            {
                ddlService.Items.Clear();
                string user = Session["user"].ToString();
                List<string> list = new List<string>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        if (ddlOrder.Items.Count > 0)
                        {
                            list = host.GetAllServiceByOrderNr(user, Convert.ToInt32(ddlOrder.SelectedItem.Value)).ToList();
                            ListItem empty = new ListItem {Text = "Valfritt", Value = string.Empty};
                            ddlService.Items.Add(empty);
                            foreach (string str in list)
                            {
                                ListItem li = new ListItem();
                                var serviceId = str.Substring(0, str.IndexOf("-") - 1);
                                var serviceName = str.Substring(serviceId.Length + 3);
                                li.Text = serviceId + " - " + serviceName;
                                li.Value = serviceId;
                                ddlService.Items.Add(li);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception service");
                throw ex;
            }
        }

        private void fillFlexAndHoliday()
        {
            try
            {
                string user = Session["user"].ToString();
                string flex = "0";
                string totFlex = "0";
                List<DateTime> holidays = new List<DateTime>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        string date = Calender.SelectedDate.ToString("yyMMdd");
                        flex = host.GetMonthFlexForLogOnUser(user, date);
                        totFlex = host.GetTotalFlexForLogOnUser(user);
                        holidays = host.GetHolidayForLogOnUser(user, date.Substring(0,4)).ToList();
                        lblFlex.Text = flex;
                        lblTotFlex.Text = totFlex;
                        lblSemester.Text = holidays.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception flex and holiday");
                throw ex;
            }
        }

        private void fillGridViewOneDay()
        {
            try
            {
                gwRapport.DataSource = getTodaysInserts();
                gwRapport.DataBind();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Today");
                throw ex;
            }
        }

        private void fillGridViewSelectedDay()
        {
            try
            {
                gwRapport.DataSource = getSelectedDayInserts();
                gwRapport.DataBind();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Selected Day");
                throw ex;
            }
        }

        private void fillGridViewWeek()
        {
            try
            {
                gwRapport.DataSource = weekInserts();
                gwRapport.DataBind();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Week");
                throw ex;
            }
        }

        private void fillGridViewMonth(string year, string month)
        {
            try
            {
                gwRapport.DataSource = monthInserts(year, month);
                gwRapport.DataBind();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Month");
                throw ex;
            }
        }

        private void reloadGridView()
        {
            if (hfView.Value == "dayView")
            {
                fillGridViewOneDay();
            }
            else if (hfView.Value == "monthView")
            {
                string year = Calender.SelectedDate.ToString("yyyy");
                string month = Calender.SelectedDate.ToString("MM");
                fillGridViewMonth(year, month);
            }
            else if (hfView.Value == "weekView")
            {
                fillGridViewWeek();
            }
        }

        public List<trService.Tidsrad> monthInserts(string year, string month)
        {
            try
            {
                string user = Session["user"].ToString();
                List<trService.Tidsrad> list = new List<TidsrapporteringASPClient.trService.Tidsrad>();
                if (controllOfUsername(user))
                {
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
                alert(ex.Message, "Exception Timeline Month List");
                throw ex;
            }
        }

        public List<trService.Tidsrad> weekInserts()
        {
            try
            {
                string user = Session["user"].ToString();
                List<trService.Tidsrad> list = new List<TidsrapporteringASPClient.trService.Tidsrad>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        var dayList = Calender.SelectedDates;
                        
                        foreach (DateTime day in dayList)
                        {
                            var date = day.ToString("yyyyMMdd");
                            var insertedDayList = host.GetAllInsertedTimeLineOnOneDay(user, date).ToList();
                            if(insertedDayList.Count > 0)
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
                alert(ex.Message, "Exception Timeline WeekList");
                throw ex;
            }
        } 

        public List<trService.Tidsrad> getTodaysInserts()
        {
            try
            {
                string user = Session["user"].ToString();
                List<trService.Tidsrad> list = new List<TidsrapporteringASPClient.trService.Tidsrad>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        var date = host.GetLastInsertedDay(user);
                        Calender.SelectedDate = DateTime.ParseExact(date, "yyyyMMdd", CultureInfo.InvariantCulture);
                        list = host.GetAllInsertedTimeLineOnOneDay(user, date).ToList();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Today List");
                throw ex;
            }
        }

        public List<trService.Tidsrad> getSelectedDayInserts()
        {
            try
            {
                string user = Session["user"].ToString();
                List<trService.Tidsrad> list = new List<TidsrapporteringASPClient.trService.Tidsrad>();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        string date = Calender.SelectedDate.ToString("yyyyMMdd");
                        list = host.GetAllInsertedTimeLineOnOneDay(user, date).ToList();
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Today List");
                throw ex;
            }
        }

        private bool controllOfUsername(string username)
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
                alert(e.Message, "Exception login");
                throw e;
            }
        }

        private void controllOfDebit()
        {
            if (ddlDebit.SelectedItem.Text == "Nej")
            {
                inputFT.Value = "0";
                inputFT.Disabled = true;
            }
            else
            {
                inputFT.Value = string.Empty;
                inputFT.Disabled = false;
            }
        }

        protected void ddlDebit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillActivity();
                fillArt();
                controllOfDebit();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception DebitEvent");
                throw ex;
            }
        }

        protected void ddlAktivitet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillArt();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception ActivityEvent");
                throw ex;
            }
        }

        protected void ddlKundNamn_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillOrderByCust();
                if (ddlOrder.Items.Count > 0)
                {
                    fillService();
                }
                else
                {
                    ddlService.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception CustEvent");
                throw ex;
            }
        }

        protected void ddlOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillService();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception orderEvent");
                throw ex;
            }
        }

        /// <summary>
        /// Visa ett alert meddelande.
        /// </summary>
        /// <param name="meddelande">string</param>
        /// <param name="titel">string</param>
        private void alert(string meddelande, string titel)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
            titel,
            "alert('" + meddelande + "');",
            true);
        }

        protected void btnSjuk_Click(object sender, EventArgs e)
        {
            try
            {
                inputFrDt.Value = DateTime.Now.Date.ToString("yyyyMMdd");
                inputToDt.Value = DateTime.Now.Date.ToString("yyyyMMdd");
                inputWT.Value = "0";
                inputFT.Value = "0";
                ddlDebit.SelectedIndex = 0;
                fillActivity();
                ddlAktivitet.SelectedValue = "Frånvaro";
                fillArt();
                inputFT.Disabled = true;
                ddlKundNamn.SelectedValue = "IT-Mästaren Mitt AB";
                fillOrderByCust();
                fillService();
                ddlService.SelectedValue = "1öö";
                ddlProj.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSenaste_Click(object sender, EventArgs e)
        {
            try
            {
                string user = Session["user"].ToString();
                var tidsrad = new trService.Tidsrad();
                inputFrDt.Value = DateTime.Now.Date.ToString("yyyyMMdd");
                inputToDt.Value = DateTime.Now.Date.ToString("yyyyMMdd");
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        string date = host.GetLastInsertedDay(user);
                        tidsrad = host.GetLastTimeLineInsertedForSpecificDate(user, date);
                        ddlDebit.SelectedValue = tidsrad.debit.ToString();
                        fillActivity();
                        ddlAktivitet.SelectedValue = tidsrad.activity;
                        fillArt();
                        ddlArt.SelectedItem.Text = tidsrad.prodNo;
                        ddlKundNamn.SelectedValue = tidsrad.custName;
                        fillOrderByCust();
                        ddlOrder.SelectedValue = tidsrad.ordNr.ToString();
                        fillService();
                        if (tidsrad.service.Length > 0)
                        {
                            ddlService.SelectedValue = tidsrad.service;
                        }
                        else
                        {
                            ddlService.SelectedIndex = 0;
                        }
                        if (tidsrad.project.Length > 0)
                        {
                            ddlProj.SelectedValue = tidsrad.project;
                        }
                        else
                        {
                            ddlProj.SelectedIndex = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Last Inserted");
                throw ex;
            }
        }

        protected void btnRensa_Click(object sender, EventArgs e)
        {
            try
            {
                inputFrDt.Value = string.Empty;
                inputToDt.Value = string.Empty;
                inputFrTid.Value = string.Empty;
                inputToTid.Value = string.Empty;
                inputWT.Value = string.Empty;
                inputFT.Value = "0";
                ddlDebit.SelectedIndex = 0;
                fillActivity();
                ddlAktivitet.SelectedIndex = 0;
                fillArt();
                ddlArt.SelectedIndex = 0;
                fillCust();
                ddlKundNamn.SelectedIndex = 0;
                fillOrderByCust();
                ddlOrder.SelectedIndex = 0;
                fillService();
                ddlService.SelectedIndex = 0;
                fillProjects();
                ddlProj.SelectedIndex = 0;
                taBenamning.Value = string.Empty;
                taIntern.Value = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnRapportera_Click(object sender, EventArgs e)
        {
            try
            {
                string user = Session["user"].ToString();
                trService.Tidsrad nyTidsrad = new TidsrapporteringASPClient.trService.Tidsrad();
                
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        nyTidsrad.frDt = Convert.ToInt32(inputFrDt.Value);
                        nyTidsrad.toDt = Convert.ToInt32(inputToDt.Value);
                        nyTidsrad.debit = Convert.ToBoolean(ddlDebit.SelectedValue);
                        nyTidsrad.activity = ddlAktivitet.SelectedItem.Text;
                        nyTidsrad.prodNo = ddlArt.SelectedValue;
                        nyTidsrad.frTm = Convert.ToInt32(inputFrTid.Value);
                        nyTidsrad.toTm = Convert.ToInt32(inputToTid.Value);
                        nyTidsrad.workedTime = Convert.ToInt32(inputWT.Value);
                        nyTidsrad.faktureradTime = Convert.ToInt32(inputFT.Value);
                        string custname = ddlKundNamn.SelectedValue;
                        nyTidsrad.custNo = host.GetCustNr(user, custname);
                        nyTidsrad.ordNr = Convert.ToInt32(ddlOrder.SelectedValue);
                        nyTidsrad.contract = host.GetContract(user, Convert.ToInt32(ddlOrder.SelectedValue));
                        #region if-satser
                        if (!ddlService.SelectedItem.Text.Equals("Valfritt"))
                        {
                            nyTidsrad.service = ddlService.SelectedValue;
                        }
                        else
                        {
                            nyTidsrad.service = string.Empty;
                        }

                        if (!ddlProj.SelectedItem.Text.Equals("Valfritt"))
                        {
                            nyTidsrad.project = ddlProj.SelectedValue;
                        }
                        else
                        {
                            nyTidsrad.project = string.Empty;
                        }
                        if (taBenamning.Value.Length > 0)
                        {
                            nyTidsrad.benamning = taBenamning.Value;
                        }
                        else
                        {
                            nyTidsrad.benamning = string.Empty;
                        }
                        if (taIntern.Value.Length > 0)
                        {
                            nyTidsrad.internText = taIntern.Value;
                        }
                        else
                        {
                            nyTidsrad.internText = string.Empty;
                        }
                        #endregion
                        string respond = host.InsertNewTimeLine(nyTidsrad, user);
                        fillGridViewOneDay();
                        alert(respond, "INSERT respons");
                    }
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception New Insert");
                throw ex;
            }
        }

        protected void btnSenasteInsattning_Click(object sender, EventArgs e)
        {
            fillGridViewOneDay();
            hfView.Value = "dayView";
        }

        protected void btnSeMan_Click(object sender, EventArgs e)
        {
            //fillGridViewMonth();
            hfView.Value = "monthView";
        }

        protected void gwRapport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region edit
            if (e.CommandName == "EditRow")
            {
                foreach (GridViewRow rows in gwRapport.Rows)
                {
                    if (rows.RowIndex == 0 || rows.RowIndex == 2 ||
                        rows.RowIndex == 4 || rows.RowIndex == 6 ||
                        rows.RowIndex == 8)
                    {
                        rows.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else
                    {
                        rows.BackColor = ColorTranslator.FromHtml("#C0C0C0");
                    }
                }
                LinkButton btn = (LinkButton)e.CommandSource;
                GridViewRow row = (GridViewRow)btn.Parent.Parent;
                GridView gw = (GridView)sender;
                string agrNo = gw.Rows[row.RowIndex].Cells[0].Text;
                string actNo = gw.Rows[row.RowIndex].Cells[1].Text;
                string contract = gw.Rows[row.RowIndex].Cells[2].Text;

                hfRowNr.Value = agrNo;
                hfActor.Value = actNo;
                hfContract.Value = contract;

                lblAgrNo.Text = "AgrNo: " + agrNo;
                lblAct.Text = " ActNo: " + actNo;
                lblCon.Text = " Kontrakt: " + contract;

                row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
            }
            #endregion

            #region delete
            else if (e.CommandName == "DeleteRow")
            {
                foreach (GridViewRow rows in gwRapport.Rows)
                {
                    if (rows.RowIndex == 0 || rows.RowIndex == 2 ||
                        rows.RowIndex == 4 || rows.RowIndex == 6 ||
                        rows.RowIndex == 8)
                    {
                        rows.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    }
                    else
                    {
                        rows.BackColor = ColorTranslator.FromHtml("#C0C0C0");
                    }
                }
                LinkButton btn = (LinkButton)e.CommandSource;
                GridViewRow row = (GridViewRow)btn.Parent.Parent;
                GridView gw = (GridView)sender;
                string agrNo = gw.Rows[row.RowIndex].Cells[0].Text;
                string actNo = gw.Rows[row.RowIndex].Cells[1].Text;
                string contract = gw.Rows[row.RowIndex].Cells[2].Text;

                hfRowNr.Value = string.Empty;
                hfActor.Value = string.Empty;
                hfContract.Value = string.Empty;

                lblAgrNo.Text = "AgrNo: " + agrNo + "borttagen";
                lblAct.Text = " ActNo: " + actNo + "borttagen";
                lblCon.Text = " Kontrakt: " + contract + "borttagen";

                try
                {
                    string user = Session["user"].ToString();
                    trService.Tidsrad tidsrad = new TidsrapporteringASPClient.trService.Tidsrad();
                    tidsrad.agrActNo = Convert.ToInt32(actNo);
                    tidsrad.agrNo = Convert.ToInt32(agrNo);

                    if (controllOfUsername(user))
                    {
                        using (trService.TidsrapporteringServiceClient host =
                            new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                        {

                            string respond = host.DeleteTimeLine(tidsrad, user);
                            alert(respond, "Delete respons");
                        }
                    }
                }
                catch (Exception ex)
                {
                    alert(ex.Message, "Exception Delete");
                    throw ex;
                }
                reloadGridView();
            }
            #endregion
        }

        protected void gwRapport_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gwRapport.PageIndex = e.NewPageIndex;
            reloadGridView();
        }

        protected void Calender_SelectionChanged(object sender, EventArgs e)
        {
            if (Calender.SelectedDates.Count > 7)
            {
                string year = Calender.SelectedDate.ToString("yyyy");
                string month = Calender.SelectedDate.ToString("MM");
                fillGridViewMonth(year, month);
                hfView.Value = "monthView";
            }
            else if (Calender.SelectedDates.Count == 7)
            {
                fillGridViewWeek();
                hfView.Value = "weekView";
            }
            else if (Calender.SelectedDates.Count == 1)
            {
                fillGridViewSelectedDay();
                hfView.Value = "dayView";
            }
            else
            {
                Calender.SelectedDate = DateTime.Now.Date;
                fillGridViewSelectedDay();
                hfView.Value = "dayView";
            }
        }

        protected void Calender_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                string user = Session["user"].ToString();
                if (controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        string year = Calender.SelectedDate.ToString("yyyy");
                        string month = Calender.SelectedDate.ToString("MM");
                        List<trService.DayStatus> dayList = 
                            host.GetAllInsertedDaysOfAMonth(user, year + month + DateTime.DaysInMonth(Convert.ToInt32(year), Convert.ToInt32(month))).ToList();
                        foreach (var day in dayList)
                        {
                            DateTime date = DateTime.ParseExact(day.date, "yyyyMMdd", CultureInfo.InvariantCulture);
                            if (e.Day.Date == date)
                            {
                                if (day.color == "red")
                                {
                                    e.Cell.BackColor = System.Drawing.Color.Red;
                                }
                                else if (day.color == "green")
                                {
                                    e.Cell.BackColor = System.Drawing.Color.Green;
                                }
                                else if (day.color == "blue")
                                {
                                    e.Cell.BackColor = System.Drawing.Color.Blue;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline CalendarColor List");
                throw ex;
            }
        }

        protected void Calender_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            
        }

        
    }
}
