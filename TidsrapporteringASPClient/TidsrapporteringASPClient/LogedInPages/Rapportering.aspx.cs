using System;
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
        private static List<trService.DayStatus> monthList { get; set; }
        private static DayRenderEventArgs dayEvent { get; set; }
        private LogedInPages.SharedMethods SM = new TidsrapporteringASPClient.LogedInPages.SharedMethods();

        protected void Page_Init(object sender, EventArgs e)
        {
            Session["Date"] = string.Empty;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"].Equals(null) || Session["user"].Equals(string.Empty)) //Check if the session if empty or null.
            {
                Response.Redirect("~/Default.aspx"); // Send user to login page.
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
                    tbAr.Text = DateTime.Now.Year.ToString();
                    ddlManad.SelectedValue = DateTime.Now.ToString("MM");
                    fillGridViewOneDay();
                    monthList = SM.getMonthList(Session["user"].ToString(), DateTime.Now.Year.ToString(), DateTime.Now.ToString("MM"));
                    pageRapporteringTitel.Text = "Ny rapportering";
                }
                else
                {
                }
            }
        }

        /// <summary>
        /// Fill the actitvity combobox with all activity.
        /// </summary>
        private void fillActivity()
        {
            try
            {
                string user = Session["user"].ToString();
                ddlAktivitet.Items.Clear();
                List<string> list = SM.getActivity(user, ddlDebit.SelectedValue);
                foreach (string str in list)
                {
                    ListItem li = new ListItem();
                    li.Text = str;
                    li.Value = str;
                    ddlAktivitet.Items.Add(li);
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Activity");
                throw ex;
            }
        }

        /// <summary>
        /// fill Artikel combobox with producs depending on selected activity.
        /// </summary>
        private void fillArt()
        {
            try
            {
                string user = Session["user"].ToString();
                ddlArt.Items.Clear();
                List<string> list = SM.getArticel(user, ddlAktivitet.SelectedItem.Text);
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
            catch (Exception ex)
            {
                alert(ex.Message, "Exception artikel");
                throw ex;
            }
        }

        /// <summary>
        /// fill projects combobox with projects.
        /// </summary>
        private void fillProjects()
        {
            try
            {
                string user = Session["user"].ToString();
                ddlProj.Items.Clear();
                List<string> list = SM.getProjects(user);
                ListItem empty = new ListItem { Text = "Valfritt", Value = string.Empty };
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
            catch (Exception ex)
            {
                alert(ex.Message, "Exception project");
                throw ex;
            }
        }

        /// <summary>
        /// fill customer combobox with customer.
        /// </summary>
        private void fillCust()
        {
            try
            {
                string user = Session["user"].ToString();
                ddlKundNamn.Items.Clear();
                List<string> list = SM.getCust(user);
                foreach (string str in list)
                {
                    ListItem li = new ListItem();
                    li.Text = str;
                    li.Value = str;
                    ddlKundNamn.Items.Add(li);
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception customer");
                throw ex;
            }
        }

        /// <summary>
        /// fill Order combobox with orders depending on selected customer.
        /// </summary>
        private void fillOrderByCust()
        {
            try
            {
                string user = Session["user"].ToString();
                ddlOrder.Items.Clear();
                List<trService.Order> list = SM.getOrder(user, ddlKundNamn.SelectedItem.Text);
                foreach (var str in list)
                {
                    ListItem li = new ListItem();
                    li.Text = str.OrderNo + " - " + str.AvtalNamn;
                    li.Value = str.OrderNo.ToString();
                    ddlOrder.Items.Add(li);
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception order");
                throw ex;
            }
        }

        /// <summary>
        /// Fill service combobox with service depending on selected order.
        /// </summary>
        private void fillService()
        {
            try
            {
                string user = Session["user"].ToString();
                ddlService.Items.Clear();
                if (ddlOrder.Items.Count > 0)
                {
                    List<string> list = SM.getService(user, Convert.ToInt32(ddlOrder.SelectedItem.Value));
                    ListItem empty = new ListItem { Text = "Valfritt", Value = string.Empty };
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
            catch (Exception ex)
            {
                alert(ex.Message, "Exception service");
                throw ex;
            }
        }

        /// <summary>
        /// Fill gridview with all the inserted timeline for the last inserted day.
        /// </summary>
        private void fillGridViewOneDay()
        {
            try
            {
                string user = Session["user"].ToString();
                gwRapport.DataSource = SM.getLastInsert(user, Calender);
                gwRapport.DataBind();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Today");
                throw ex;
            }
        }

        /// <summary>
        /// Fill gridview with all timelines for the selected day.
        /// </summary>
        private void fillGridViewSelectedDay()
        {
            try
            {
                string user = Session["user"].ToString();
                gwRapport.DataSource = SM.getSelectedDayInserts(user, Calender);
                gwRapport.DataBind();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Selected Day");
                throw ex;
            }
        }

        /// <summary>
        /// Fill gridview with all the timelines for selected week.
        /// </summary>
        private void fillGridViewWeek()
        {
            try
            {
                string user = Session["user"].ToString();
                gwRapport.DataSource = SM.weekInserts(user, Calender);
                gwRapport.DataBind();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Week");
                throw ex;
            }
        }

        /// <summary>
        /// Fill gridview with all the timelines for selected month.
        /// </summary>
        /// <param name="year">string</param>
        /// <param name="month">string</param>
        private void fillGridViewMonth(string year, string month)
        {
            try
            {
                string user = Session["user"].ToString();
                gwRapport.DataSource = SM.monthInserts(user, year, month);
                gwRapport.DataBind();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Month");
                throw ex;
            }
        }

        /// <summary>
        /// Reload gridview depending on the last view.
        /// </summary>
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

        /// <summary>
        /// Clear all input boxes for insert.
        /// </summary>
        private void clearAllInput()
        {
            inputFrDt.Text = string.Empty;
            inputToDt.Text = string.Empty;
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

        /// <summary>
        /// Get all info about the selected timeline on the gridview and the set the values in the correct box.
        /// </summary>
        /// <param name="date">string</param>
        /// <param name="agrNo">int</param>
        private void getSelectedTimeLine(string date, int agrNo)
        {
            try
            {
                string user = Session["user"].ToString();
                var tidsrad = new trService.Tidsrad();

                if (SM.controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        tidsrad = host.GetTimeLineByAgrNo(user, date, agrNo);
                        inputFrTid.Value = tidsrad.frTm.ToString();
                        inputToTid.Value = tidsrad.toTm.ToString();
                        inputFrDt.Text = tidsrad.frDt.ToString();
                        inputToDt.Text = tidsrad.toDt.ToString();
                        inputWT.Value = tidsrad.workedTime.ToString();
                        inputFT.Value = tidsrad.faktureradTime.ToString();
                        ddlDebit.SelectedValue = tidsrad.debit.ToString();
                        controllOfDebit();
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
                        if (tidsrad.benamning.Length > 0)
                        {
                            taBenamning.Value = tidsrad.benamning;
                        }
                        else
                        {
                            taBenamning.Value = string.Empty;
                        }

                        if (tidsrad.internText.Length > 0)
                        {
                            taIntern.Value = tidsrad.internText;
                        }
                        else
                        {
                            taIntern.Value = string.Empty;
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

        /// <summary>
        /// Disable and enable depending on the debit value.
        /// </summary>
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

        /// <summary>
        /// Get flex and holidays.
        /// </summary>
        private void fillFlexAndHoliday()
        {
            try
            {
                string user = Session["user"].ToString();
                string flex = "0";
                string totFlex = "0";
                List<DateTime> holidays = new List<DateTime>();
                if (SM.controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        string date = Calender.SelectedDate.ToString("yyMMdd");

                        flex = host.GetMonthFlexForLogOnUser(user, date);
                        totFlex = host.GetTotalFlexForLogOnUser(user);
                        holidays = host.GetHolidayForLogOnUser(user, date.Substring(0, 4)).ToList();

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

        /// <summary>
        /// Show an alert message.
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

        protected void btnSjuk_Click(object sender, EventArgs e)
        {
            try
            {
                inputFrDt.Text = DateTime.Now.Date.ToString("yyyyMMdd");
                inputToDt.Text = DateTime.Now.Date.ToString("yyyyMMdd");
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
                inputFrDt.Text = DateTime.Now.Date.ToString("yyyyMMdd");
                inputToDt.Text = DateTime.Now.Date.ToString("yyyyMMdd");
                if (SM.controllOfUsername(user))
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
                clearAllInput();
                if (btnRensa.Text == "Avbryt")
                {
                    btnRensa.Text = "Rensa";
                    btnRapportera.Text = "Rapportera";
                    pageRapporteringTitel.Text = "Ny rapportering";
                    reloadGridView();
                }
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

                if (SM.controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        #region inserts values
                        nyTidsrad.frDt = Convert.ToInt32(inputFrDt.Text);
                        nyTidsrad.toDt = Convert.ToInt32(inputToDt.Text);
                        nyTidsrad.debit = Convert.ToBoolean(ddlDebit.SelectedValue);
                        nyTidsrad.activity = ddlAktivitet.SelectedItem.Text;
                        nyTidsrad.prodNo = ddlArt.SelectedValue;
                        nyTidsrad.frTm = Convert.ToInt32(inputFrTid.Value);
                        nyTidsrad.toTm = Convert.ToInt32(inputToTid.Value);
                        nyTidsrad.workedTime = float.Parse(inputWT.Value);
                        nyTidsrad.faktureradTime = float.Parse(inputFT.Value);
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
                        #endregion

                        if (btnRapportera.Text == "Rapportera")
                        {
                            string respond = host.InsertNewTimeLine(nyTidsrad, user);
                            fillGridViewOneDay();
                            hfView.Value = "dayView";
                            clearAllInput();
                            alert(respond, "INSERT respons");
                        }
                        else if (btnRapportera.Text == "Spara")
                        {
                            nyTidsrad.agrNo = Convert.ToInt32(hfRowNr.Value);
                            nyTidsrad.agrActNo = Convert.ToInt32(hfActor.Value);
                            string respond = host.UpdateTimeLine(nyTidsrad, user);
                            btnRapportera.Text = "Rapportera";
                            btnRensa.Text = "Rensa";
                            pageRapporteringTitel.Text = "Ny rapportering";
                            reloadGridView();
                            clearAllInput();
                            alert(respond, "UPDATE respons");
                        }
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
            string user = Session["user"].ToString();
            fillGridViewOneDay();
            hfView.Value = "dayView";
            DateTime date = DateTime.ParseExact(Session["Date"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
            Calender.VisibleDate = date;
            monthList = SM.getMonthList(user, date.Year.ToString(), date.ToString("MM"));
            Calender_DayRender(sender, dayEvent);
        }

        protected void btnSeMan_Click(object sender, EventArgs e)
        {
            string user = Session["user"].ToString();
            string year = tbAr.Text;
            string month = ddlManad.SelectedValue.ToString();
            fillGridViewMonth(year, month);
            hfView.Value = "monthView";
            Calender.VisibleDate = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
            monthList = SM.getMonthList(user, year, month);
            Calender_DayRender(sender, dayEvent);

        }

        protected void gwRapport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            #region edit
            if (e.CommandName == "EditRow")
            {
                #region SelectRow
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
                #endregion
                #region edit row
                string date = gw.Rows[row.RowIndex].Cells[3].Text;
                getSelectedTimeLine(date, Convert.ToInt32(agrNo));
                btnRapportera.Text = "Spara";
                btnRensa.Text = "Avbryt";
                string text = "Redigera AgrNo: " + agrNo;
                pageRapporteringTitel.Text = text;
                #endregion
            }
            #endregion

            #region copy
            else if (e.CommandName == "CopyRow")
            {
                #region SelectRow
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

                row.BackColor = ColorTranslator.FromHtml("#FF9933");
                #endregion
                #region Copy Row
                string date = gw.Rows[row.RowIndex].Cells[3].Text;
                getSelectedTimeLine(date, Convert.ToInt32(agrNo));
                inputFrDt.Text = DateTime.Now.Date.ToString("yyyyMMdd");
                inputToDt.Text = DateTime.Now.Date.ToString("yyyyMMdd");
                inputFrTid.Value = string.Empty;
                inputToTid.Value = string.Empty;
                inputWT.Value = string.Empty;
                inputFT.Value = "0";
                #endregion
            }
            #endregion

            #region Contract
            else if (e.CommandName == "ContractRow")
            {
                #region SelectRow
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

                row.BackColor = ColorTranslator.FromHtml("#b6ff00");
                #endregion

                #region show contract

                #endregion
            }
            #endregion

            #region delete
            else if (e.CommandName == "DeleteRow")
            {
                #region SelectRow
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
                #endregion
                #region Try Delete
                try
                {
                    string user = Session["user"].ToString();
                    trService.Tidsrad tidsrad = new TidsrapporteringASPClient.trService.Tidsrad();
                    tidsrad.agrActNo = Convert.ToInt32(actNo);
                    tidsrad.agrNo = Convert.ToInt32(agrNo);

                    if (SM.controllOfUsername(user))
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
                #endregion
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
                dayEvent = e;
                string user = Session["user"].ToString();
                if (SM.controllOfUsername(user))
                {
                    foreach (var day in monthList)
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
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline CalendarColor List");
                throw ex;
            }
        }

        protected void Calender_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            string user = Session["user"].ToString();
            monthList = SM.getMonthList(user, e.NewDate.Year.ToString(), e.NewDate.Date.ToString("MM"));
            fillGridViewMonth(e.NewDate.Year.ToString(), e.NewDate.Date.ToString("MM"));
            hfView.Value = "monthView";
        }


    }
}
