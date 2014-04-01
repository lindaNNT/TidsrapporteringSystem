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
                    Calendar1.SelectedDate = DateTime.Today; 
                    fillProjects();
                    fillCust();
                    fillOrderByCust();
                    fillService();
                    fillActivity();
                    fillArt();
                    fillFlexAndHoliday();
                    controllOfDebit();
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
                        string date = Calendar1.SelectedDate.ToString("yyMMdd");
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
                        list = host.GetAllInsertedTimeLineOnOneDay(user, DateTime.Now.Date.ToString("yyyyMMdd")).ToList();
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

        protected void btnIdag_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewInserts.DataSource = "ObjectDataSourceIdag";
                GridViewInserts.DataSourceID = ObjectDataSourceIdag.ID;
                GridViewInserts.DataBind();
                GridViewInserts.AutoGenerateColumns = false;
                BoundField bf = new BoundField {DataField="Custname", HeaderText = "Kund namn", SortExpression="Kundnamn"};
                GridViewInserts.Columns.Add(bf);
            }
            catch (Exception ex)
            {
                alert(ex.Message, "Exception Timeline Today");
                throw ex;
            }
        }
    }
}
