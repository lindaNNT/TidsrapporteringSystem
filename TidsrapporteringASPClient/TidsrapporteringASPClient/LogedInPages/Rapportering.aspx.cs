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
using AjaxControlToolkit;
using TidsrapporteringASPClient.Repository;
using TidsrapporteringASPClient.LogedInPages;

namespace TidsrapporteringASPClient
{
    public partial class Rapportering : System.Web.UI.Page
    {
        private static List<trService.DayStatus> monthList { get; set; }
        private static List<trService.DayStatus> monthHolidayList { get; set; }
        private static DayRenderEventArgs dayEvent { get; set; }
        private LogedInPages.SharedMethods SM = new TidsrapporteringASPClient.LogedInPages.SharedMethods();
        private FavoritCRUD FD = new FavoritCRUD();
        private static string staticUsername;

        protected void Page_Init(object sender, EventArgs e)
        {
            Session["Date"] = string.Empty;
            Session["custID"] = String.Empty;
            Session["custName"] = String.Empty;
            Session["orderNo"] = String.Empty;
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
                    staticUsername = Session["user"].ToString();
                    startUpMethods();
                }
                else
                {
                    insertCombo();
                }
            }
        }

        private void startUpMethods()
        {
            try
            {
                Calender.SelectedDate = DateTime.Today;
                createCustomerXML();
                createProjectXML();
                createActivityXML("false");
                tbAr.Text = DateTime.Now.Year.ToString();
                ddlManad.SelectedValue = DateTime.Now.ToString("MM");
                fillFlex(tbAr+ddlManad.SelectedItem.Value);
                fillGridViewOneDay();
                hfActor.Value = gwRapport.Rows[0].Cells[1].Text;
                lblAct.Text = hfActor.Value;
                fillFavorit();
                btnTaBortFavorit.Enabled = false;
                btnTaBortFavorit.Visible = false;
                monthList = SM.getMonthList(Session["user"].ToString(), DateTime.Now.Year.ToString(), DateTime.Now.ToString("MM"));
                monthHolidayList = getHolidays(Calender.SelectedDate.ToString("yyyyMM"));
                hfView.Value = "dayView";
                pageRapporteringTitel.Text = "Ny rapportering";
                insertCombo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void fillFavorit()
        {
            try
            {
                ddlFavo.Items.Clear();
                List<Favorit> list = FD.getFavoritByActID(Convert.ToInt32(hfActor.Value));
                if (list.Count > 0)
                {
                    ListItem empty = new ListItem();
                    empty.Text = "Välj ibland favoriter";
                    empty.Value = "tom";
                    ddlFavo.Items.Add(empty);

                    foreach (var str in list)
                    {
                        ListItem li = new ListItem();
                        li.Text = "ID: " + str.FavoritID + " - " + str.FavoritName;
                        li.Value = str.FavoritID.ToString();
                        ddlFavo.Items.Add(li);
                    }
                }
                else
                {
                    ListItem li = new ListItem();
                    li.Text = "Finns ingen";
                    li.Value = "tom";
                    ddlFavo.Items.Add(li);
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Activity");
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
        /// Create customer XML-file
        /// </summary>
        private void createCustomerXML()
        {
            try
            {
                string user = Session["user"].ToString();
                SM.createCustomerXML(user);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Create project XML-file
        /// </summary>
        private void createProjectXML()
        {
            try
            {
                string user = Session["user"].ToString();
                SM.createProjectXML(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Create activity XML-file
        /// </summary>
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void createActivityXML(string debit)
        {
            try
            {
                SharedMethods SM = new SharedMethods();
                SM.createActivityXML(staticUsername, debit);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Create articel XML-file
        /// </summary>
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void createArticelXML(string activity)
        {
            try
            {
                SharedMethods SM = new SharedMethods();
                SM.createArticelXML(staticUsername, activity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// A client-side call to create order XML-file.
        /// </summary>
        /// <param name="custID">string</param>
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void createOrder(string custID)
        {
            try
            {
                SharedMethods SM = new SharedMethods();
                SM.createOrderXML(staticUsername, custID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// A client-side call to create service XML-file.
        /// </summary>
        /// <param name="orderID">string</param>
        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void createService(string orderID)
        {
            try
            {
                SharedMethods SM = new SharedMethods();
                SM.createServiceXML(staticUsername, orderID);
            }
            catch (Exception ex)
            {
                throw ex;
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

        private List<trService.DayStatus> getHolidays(string yearMonth)
        {
            try
            {
                string user = Session["user"].ToString();
                List<trService.DayStatus> list = new List<TidsrapporteringASPClient.trService.DayStatus>();
                if (SM.controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        List<DateTime> days = host.GetHolidayForLogOnUser(user, yearMonth).ToList();
                        foreach(var day in days)
                        {
                            trService.DayStatus dayStatus = 
                                new TidsrapporteringASPClient.trService.DayStatus 
                                        { date = day.ToString("yyyyMMdd"), color = "yellow", status = "RödaDagar" };
                            list.Add(dayStatus);
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception holiday");
                throw ex;
            }
        }

        /// <summary>
        /// Get flex.
        /// </summary>
        public void fillFlex(string date)
        {
            try
            {
                string user = Session["user"].ToString();

                if (SM.controllOfUsername(user))
                {
                    using (trService.TidsrapporteringServiceClient host =
                        new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient())
                    {
                        string flex = host.GetMonthFlexForLogOnUser(user, date);
                        string totFlex = host.GetTotalFlexForLogOnUser(user);
                        if (flex.Length > 0)
                        {
                            lblFlex.Text = flex + " h";
                        }
                        else
                        {
                            lblFlex.Text = "0 h";
                        }

                        if (totFlex.Length > 0)
                        {
                            lblTotFlex.Text = totFlex + " h";
                        }
                        else
                        {
                            lblTotFlex.Text = "0 h";
                        }
                        lblManad.Text = tbAr.Text + " - " + ddlManad.SelectedItem.Text;
                    }
                }
            }
            catch (Exception ex)
            {
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

        private void insertCombo()
        {
            try
            {
                ScriptManager.RegisterStartupScript
                    (this.Page, this.GetType(), "insertToCombo", "insertToCombo();", true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void clearHiddenField()
        {
            hfCustID.Value = String.Empty;
            hfCustName.Value = String.Empty;
            hfOrderID.Value = String.Empty; 
            hfServiceID.Value = String.Empty; 
            hfServiceName.Value = String.Empty;
            hfToTime.Value = String.Empty;  
            hfFrTime.Value = String.Empty;   
            hfToDate.Value = String.Empty; 
            hfFrDate.Value = String.Empty; 
            hfOrderName.Value = String.Empty; 
            hfProjectID.Value = String.Empty; 
            hfProjectName.Value = String.Empty;
            hfBen.Value = String.Empty; 
            hfIntern.Value = String.Empty; 
            hfAct.Value = String.Empty; 
            hfArt.Value = String.Empty; 
            hfTaxa.Value = String.Empty; 
            hfMemo.Value = String.Empty;
            hfDebit.Value = String.Empty;
        }

        protected void ddlFavo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!ddlFavo.SelectedValue.Equals("tom"))
                {
                    Favorit fav = FD.getFavoritByFavoritID(Convert.ToInt32(ddlFavo.SelectedValue));
                    if (fav != null)
                    {
                        hfDebit.Value = fav.Debit;

                        hfAct.Value = fav.Activity;

                        hfArt.Value = fav.Artical;

                        hfCustID.Value = fav.CustomName.Substring(0, fav.CustomName.IndexOf("-")-1);
                        hfCustName.Value = fav.CustomName.Substring(fav.CustomName.IndexOf("-")+2);

                        hfOrderID.Value = fav.Order.Substring(0, fav.Order.IndexOf("-")-1);
                        hfOrderName.Value = fav.Order.Substring(fav.Order.IndexOf("-")+2);

                        if (!fav.Service.Equals(string.Empty))
                        {
                            hfServiceID.Value = fav.Service.Substring(0, fav.Service.IndexOf("-") - 1);
                            hfServiceName.Value = fav.Service.Substring(fav.Service.IndexOf("-") + 2);
                        }
                        else
                        {
                            hfServiceID.Value = "";
                            hfServiceName.Value = "";
                        }

                        if (!fav.Project.Equals(string.Empty))
                        {
                            hfProjectID.Value = fav.Project.Substring(0, fav.Project.IndexOf("-") - 1);
                            hfProjectName.Value = fav.Project.Substring(fav.Project.IndexOf("-") + 2);
                        }
                        else
                        {
                            hfProjectID.Value = "";
                            hfProjectName.Value = "";
                        }

                        if (fav.Benamning.Length > 0)
                        {
                            taBenamning.Value = fav.Benamning;
                        }

                        if (fav.InternText.Length > 0)
                        {
                            taIntern.Value = fav.InternText;
                        }

                        inputFrDt.Text = DateTime.Now.ToString("yyyyMMdd");
                        inputToDt.Text = DateTime.Now.ToString("yyyyMMdd");

                        btnTaBortFavorit.Visible = true;
                        btnTaBortFavorit.Enabled = true;
                        insertCombo();
                    }
                }
                else
                {
                    clearHiddenField();
                    insertCombo();
                    clearAllInput();
                    btnTaBortFavorit.Visible = false;
                    btnTaBortFavorit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
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
                hfAct.Value = "Frånvaro";
                insertCombo();
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
                        trService.Order order = SM.getOrderByOrderID(user, tidsrad.custName, tidsrad.ordNr.ToString());
                        List<string> serviceList = SM.getService(user, tidsrad.ordNr);
                        List<string> projList = SM.getProjects(user);
                        hfDebit.Value = tidsrad.debit.ToString();
                        hfAct.Value = tidsrad.activity;
                        hfArt.Value = tidsrad.prodNo;
                        hfCustName.Value = tidsrad.custName;
                        hfCustID.Value = tidsrad.custNo.ToString();
                        hfOrderID.Value = tidsrad.ordNr.ToString();
                        hfOrderName.Value = order.AvtalNamn;
                        if (tidsrad.service.Length > 0)
                        {
                            foreach (var el in serviceList)
                            {
                                if (el.Substring(0, el.IndexOf("-") - 1).Equals(tidsrad.service))
                                {
                                    hfServiceID.Value = tidsrad.service;
                                    hfServiceName.Value = el;
                                    break;
                                }
                                else
                                {
                                    hfServiceID.Value = "";
                                }
                            }
                        }
                        else
                        {
                            hfServiceID.Value = "";
                        }

                        if (tidsrad.project.Length > 0)
                        {
                            foreach (var el in projList)
                            {
                                if (el.Substring(el.IndexOf("?") + 2).Equals(tidsrad.project))
                                {
                                    hfProjectID.Value = tidsrad.project;
                                    hfProjectName.Value = el.Substring(el.IndexOf("?") + 2) + " - " + el.Substring(0, el.IndexOf("?"));
                                    break;
                                }
                                else
                                {
                                    hfProjectID.Value = "";
                                }
                            }
                        }
                        else
                        {
                            hfProjectID.Value = "";
                        }
                        insertCombo();
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
                    btnSjuk.Enabled = true;
                    btnSenaste.Enabled = true;
                    ddlFavo.Enabled = true;
                    btnRapportera.Text = "Rapportera";
                    pageRapporteringTitel.Text = "Ny rapportering";
                    ddlFavo.SelectedIndex = 0;
                    btnTaBortFavorit.Enabled = false;
                    btnTaBortFavorit.Visible = false;
                    reloadGridView();
                    clearHiddenField();
                    insertCombo();
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
                }
                else
                {
                    ddlFavo.SelectedIndex = 0;
                    btnTaBortFavorit.Enabled = false;
                    btnTaBortFavorit.Visible = false;
                    clearHiddenField();
                    insertCombo();
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
                if (this.Page.IsValid)
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
                            nyTidsrad.debit = Convert.ToBoolean(hfDebit.Value);
                            nyTidsrad.activity = hfAct.Value;
                            string art = hfArt.Value;
                            nyTidsrad.prodNo = art.Substring(0, art.IndexOf("-") - 1);
                            nyTidsrad.frTm = Convert.ToInt32(inputFrTid.Value);
                            nyTidsrad.toTm = Convert.ToInt32(inputToTid.Value);

                            nyTidsrad.faktureradTime = float.Parse(inputFT.Value);
                            string custname = hfCustName.Value;
                            nyTidsrad.custNo = Convert.ToInt32(hfCustID.Value);
                            nyTidsrad.ordNr = Convert.ToInt32(hfOrderID.Value);
                            nyTidsrad.contract = host.GetContract(user, Convert.ToInt32(hfOrderID.Value));
                            nyTidsrad.service = hfServiceID.Value;
                            nyTidsrad.project = hfProjectID.Value;
                            #region if-satser
                            if (inputWT.Value.Contains("."))
                            {
                                nyTidsrad.workedTime = float.Parse(inputWT.Value.Replace(".", ","));
                            }
                            else
                            {
                                nyTidsrad.workedTime = float.Parse(inputWT.Value);
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
                                clearHiddenField();
                                insertCombo();
                            }
                            else if (btnRapportera.Text == "Spara")
                            {
                                nyTidsrad.agrNo = Convert.ToInt32(hfRowNr.Value);
                                nyTidsrad.agrActNo = Convert.ToInt32(hfActor.Value);
                                string respond = host.UpdateTimeLine(nyTidsrad, user);
                                btnRapportera.Text = "Rapportera";
                                btnSjuk.Enabled = true;
                                btnSenaste.Enabled = true;
                                ddlFavo.Enabled = true;
                                btnRensa.Text = "Rensa";
                                pageRapporteringTitel.Text = "Ny rapportering";
                                reloadGridView();
                                clearAllInput();
                                clearHiddenField();
                                insertCombo();
                            }
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

        protected void btnSparaFavorit_Click(object sender, EventArgs e)
        {
            try
            {
                lblFavoDebit.Text = hfDebit.Value;
                lblFavoActivity.Text = hfAct.Value;
                lblFavoArt.Text = hfArt.Value;
                hfArticel.Value = hfArt.Value;
                lblFavoCust.Text = hfCustID.Value + " - " + hfCustName.Value;
                lblFavoOrder.Text = hfOrderName.Value;
                hfOrder.Value = hfOrderID.Value + " - " + hfOrderName.Value;
                lblFavoService.Text = hfServiceName.Value;
                hfService.Value = hfServiceID.Value + " - " + hfServiceName.Value;
                lblFavoProj.Text = hfProjectName.Value;
                hfProj.Value = hfProjectID.Value + " - " + hfProjectName.Value;
                lblFavoBen.Text = taBenamning.Value;
                lblFavoIntern.Text = taIntern.Value;
                lblFavoMemo.Text = taMemo.Value;

                mpeFavo.Show();
            }
            catch (Exception ex)
            {
                alert(ex.Message, "favorit");
                throw ex;
            }
        }

        protected void btnFavoSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string response = "";
                var favName = tbFavoName.Text;
                if (favName.Length > 0)
                {
                    Favorit newFav = new Favorit { FavoritName = favName,
                                                   ActAgrID = Convert.ToInt32(hfActor.Value),     
                                                   Debit = lblFavoDebit.Text,
                                                   Activity = lblFavoActivity.Text,
                                                   Artical = hfArticel.Value,
                                                   CustomName = lblFavoCust.Text,
                                                   Order = hfOrder.Value,
                                                   Service = hfService.Value,
                                                   Project = hfProj.Value,
                                                   Benamning = lblFavoBen.Text,
                                                   InternText = lblFavoIntern.Text,
                                                   Memo = lblFavoMemo.Text,
                                                   Miltal = tbMiltal.Text};
                    response = FD.insertNewFavorit(newFav);
                }
                if (response.Equals("Insättning lyckades."))
                {
                    fillFavorit();
                    tbFavoName.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "favorit");
                throw ex;
            }
        }

        protected void btnTaBort_Click(object sender, EventArgs e)
        {
            try
            {
                string response = "";
                var favID = ddlFavo.SelectedValue;
                if (favID.Length > 0)
                {
                    response = FD.deleteFavorit(Convert.ToInt32(favID));
                }
                if (response.Equals("Borttagning lyckades."))
                {
                    fillFavorit();
                    ddlFavo.ClearSelection();
                    ddlFavo.SelectedIndex = 0;
                    btnTaBortFavorit.Enabled = false;
                    btnTaBortFavorit.Visible = false;
                }
            }
            catch (Exception ex)
            {
                alert(ex.Message, "favorit");
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
            string year = tbAr.Text;
            string month = ddlManad.SelectedValue.ToString();
            fillFlex(year + month);
        }

        protected void gwRapport_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ddlFavo.SelectedIndex = 0;
            btnTaBortFavorit.Enabled = false;
            btnTaBortFavorit.Visible = false;

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
                string date = gw.Rows[row.RowIndex].Cells[4].Text;
                string orderNo = gw.Rows[row.RowIndex].Cells[8].Text;
                trService.Tidsrad tidsrad = SM.getTidsradByAgrNo(Session["user"].ToString(), date, agrNo);
                List<trService.Order> orderList = SM.getOrder(Session["user"].ToString(), tidsrad.custNo);
                var projectList = SM.getProjects(Session["user"].ToString());
                var serviceList = SM.getService(Session["user"].ToString(), tidsrad.ordNr);
                var articelList = SM.getArticel(Session["user"].ToString(), tidsrad.activity);

                #region Insert to hidden fields
                hfRowNr.Value = agrNo;
                hfActor.Value = actNo;
                hfContract.Value = contract;
                hfCustID.Value = tidsrad.custNo.ToString();
                hfCustName.Value = tidsrad.custName;
                hfOrderID.Value = tidsrad.ordNr.ToString();

                foreach(var order in orderList)
                {
                    if (order.OrderNo.Equals(Convert.ToInt32(orderNo)))
                    {
                        hfOrderName.Value = order.AvtalNamn;
                        break;
                    }
                }

                foreach (var el in projectList)
                {
                    string projectID = el.Substring(el.IndexOf("??") + 2);
                    string projectName = el.Substring(0, el.IndexOf("??"));
                    if (projectID.Equals(tidsrad.project))
                    {
                        hfProjectID.Value = projectID;
                        hfProjectName.Value = projectID + " - " + projectName;
                        break;
                    }
                }

                foreach(var el in serviceList)
                {
                    string serviceNo = el.Substring(0, el.IndexOf("-")-1);
                    if(serviceNo.Equals(tidsrad.service))
                    {
                        hfServiceName.Value = el;
                        hfServiceID.Value = tidsrad.service;
                        break;
                    }
                }

                foreach (var el in articelList)
                {
                    string art = el.Substring(0,el.IndexOf("-")+1);
                    string artName = el.Substring(el.IndexOf("-") + 2);
                    if (artName.Equals(tidsrad.prodNo.ToString()))
                    {
                        hfArt.Value = el;
                        break;
                    }
                }
                hfAct.Value = tidsrad.activity;
                hfDebit.Value = tidsrad.debit.ToString();
                hfFrDate.Value = tidsrad.frDt.ToString();
                hfToDate.Value = tidsrad.toDt.ToString();
                hfToTime.Value = tidsrad.toTm.ToString();
                hfFrTime.Value = tidsrad.frTm.ToString();

                if (tidsrad.frTm.ToString().Length == 3)
                {
                    inputFrTid.Value = "0" + tidsrad.frTm.ToString();
                }
                else
                {
                    inputFrTid.Value = tidsrad.frTm.ToString();
                }
                if (tidsrad.toTm.ToString().Length == 3)
                {
                    inputToTid.Value = "0" + tidsrad.toTm.ToString();
                }
                else
                {
                    inputToTid.Value = tidsrad.toTm.ToString();
                }

                inputFrDt.Text = tidsrad.frDt.ToString();
                inputToDt.Text = tidsrad.toDt.ToString();
                inputWT.Value = tidsrad.workedTime.ToString();

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
                #endregion

                insertCombo();

                row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                #endregion
                #region edit row
                btnSjuk.Enabled = false;
                btnSenaste.Enabled = false;
                ddlFavo.Enabled = false;
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
                string date = gw.Rows[row.RowIndex].Cells[4].Text;
                string orderNo = gw.Rows[row.RowIndex].Cells[8].Text;
                trService.Tidsrad tidsrad = SM.getTidsradByAgrNo(Session["user"].ToString(), date, agrNo);
                List<trService.Order> orderList = SM.getOrder(Session["user"].ToString(), tidsrad.custNo);
                var projectList = SM.getProjects(Session["user"].ToString());
                var serviceList = SM.getService(Session["user"].ToString(), tidsrad.ordNr);
                var articelList = SM.getArticel(Session["user"].ToString(), tidsrad.activity);

                #region Insert to hidden fields
                hfRowNr.Value = agrNo;
                hfActor.Value = actNo;
                hfContract.Value = contract;
                hfCustID.Value = tidsrad.custNo.ToString();
                hfCustName.Value = tidsrad.custName;
                hfOrderID.Value = tidsrad.ordNr.ToString();

                foreach (var order in orderList)
                {
                    if (order.OrderNo.Equals(Convert.ToInt32(orderNo)))
                    {
                        hfOrderName.Value = order.AvtalNamn;
                        break;
                    }
                }

                foreach (var el in projectList)
                {
                    string projectID = el.Substring(el.IndexOf("??") + 2);
                    string projectName = el.Substring(0, el.IndexOf("??"));
                    if (projectID.Equals(tidsrad.project))
                    {
                        hfProjectID.Value = projectID;
                        hfProjectName.Value = projectID + " - " + projectName;
                        break;
                    }
                }

                foreach (var el in serviceList)
                {
                    string serviceNo = el.Substring(0, el.IndexOf("-") - 1);
                    if (serviceNo.Equals(tidsrad.service))
                    {
                        hfServiceName.Value = el;
                        hfServiceID.Value = tidsrad.service;
                        break;
                    }
                }

                foreach (var el in articelList)
                {
                    string art = el.Substring(0, el.IndexOf("-") + 1);
                    string artName = el.Substring(el.IndexOf("-") + 2);
                    if (artName.Equals(tidsrad.prodNo.ToString()))
                    {
                        hfArt.Value = el;
                        break;
                    }
                }
                hfAct.Value = tidsrad.activity;
                hfDebit.Value = tidsrad.debit.ToString();
                hfFrDate.Value = tidsrad.frDt.ToString();
                hfToDate.Value = tidsrad.toDt.ToString();
                hfToTime.Value = tidsrad.toTm.ToString();
                hfFrTime.Value = tidsrad.frTm.ToString();
                #endregion

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

                insertCombo();

                hfRowNr.Value = agrNo;
                hfActor.Value = actNo;
                hfContract.Value = contract;

                lblAgrNo.Text = "AgrNo: " + agrNo;
                lblAct.Text = " ActNo: " + actNo;
                lblCon.Text = " Kontrakt: " + contract;

                row.BackColor = ColorTranslator.FromHtml("#FF9933");
                #endregion
                #region Copy Row
                inputFrDt.Text = DateTime.Now.Date.ToString("yyyyMMdd");
                inputToDt.Text = DateTime.Now.Date.ToString("yyyyMMdd");
                inputFrTid.Value = string.Empty;
                inputToTid.Value = string.Empty;
                inputWT.Value = string.Empty;
                inputFT.Value = "0";
                btnRapportera.Text = "Rapportera";
                btnRensa.Text = "Rensa";
                pageRapporteringTitel.Text = "Ny rapportering";
                #endregion
            }
            #endregion

            #region Info
            else if (e.CommandName == "InfoRow")
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
                string custID = gw.Rows[row.RowIndex].Cells[3].Text;

                hfRowNr.Value = agrNo;
                hfActor.Value = actNo;
                hfContract.Value = contract;
                hfCustID.Value = custID;
                row.BackColor = ColorTranslator.FromHtml("#b6ff00");
                insertCombo();
                #endregion

                #region show info
                string user = Session["user"].ToString();
                string date = gw.Rows[row.RowIndex].Cells[4].Text;
                trService.Tidsrad tr = SM.getTidsradByAgrNo(user, date, agrNo);
                #region get labels
                Label lblAgrNo = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("AgrNoPopUp");
                Label lblDate = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("DatePopUp");

                Label lblAct = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("ActivityPopUp");
                Label lblArt = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("ArtPopUp");

                Label lblDebit = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("DebitPopUp");
                Label lblTime = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("TimePopUp");
                Label lblWT = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("WTPopUp");
                Label lblFT = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("FTPopUp");

                Label lblCust = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("CustPopUp");
                Label lblOrder = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("OrderPopUp");
                Label lblContract = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("ContractPopUp");
                Label lblService = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("ServicePopUp");

                Label lblProj = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("ProjPopUp");

                Label lblBen = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("BenamningPopUp");
                Label lblIntern = (Label)gw.Rows[row.RowIndex].Cells[0].FindControl("InternTextPopUp");

                #endregion

                #region set labels

                //lblAgrNo.Text = agrNo;
                lblDate.Text = tr.frDt.ToString() + " - " + tr.toDt.ToString();

                lblAct.Text = tr.activity;
                lblArt.Text = tr.prodNo;

                lblDebit.Text = SM.convertDebitToString(tr.debit);
                lblTime.Text = SM.trimTime(tr.frTm.ToString()) + " - "  + SM.trimTime(tr.toTm.ToString());
                lblWT.Text = tr.workedTime.ToString() + "h";
                lblFT.Text = tr.faktureradTime.ToString() + "h";
                trService.Order order = SM.getOrderByOrderID(user, tr.custName, tr.ordNr.ToString());
                lblCust.Text = tr.custName;
                lblOrder.Text = order.OrderNo + ", " + order.AvtalNamn;
                lblContract.Text = tr.contract.ToString();
                lblService.Text = tr.service;

                lblProj.Text = tr.project;

                lblBen.Text = tr.benamning;
                lblIntern.Text = tr.internText;

                #endregion

                ModalPopupExtender mpePopUp = (ModalPopupExtender)gw.Rows[row.RowIndex].Cells[0].FindControl("ModalPopupExtenderInfo");
                mpePopUp.Show();
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

        protected void lbtnAgrNoPopUpEdit_Command(object sender, CommandEventArgs e)
        {
            LinkButton editBtn =(LinkButton)sender;
            TextBox agrNoTB = (TextBox)editBtn.Parent.FindControl("btnAgrNoPopUp");
            agrNoTB.Visible = true;
            LinkButton agrNolbtn = (LinkButton)editBtn.Parent.FindControl("lbtnAgrNoPopUpCancel");
            agrNolbtn.Visible = true;
            ModalPopupExtender mpePopUp = (ModalPopupExtender)editBtn.Parent.FindControl("ModalPopupExtenderInfo");
            mpePopUp.Show();
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
                foreach (var day in monthHolidayList)
                {
                    DateTime date = DateTime.ParseExact(day.date, "yyyyMMdd", CultureInfo.InvariantCulture);
                    if (e.Day.Date == date)
                    {
                        e.Cell.BackColor = System.Drawing.Color.Yellow;
                        break;
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
