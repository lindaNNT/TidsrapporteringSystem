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

        protected void ddlDebit_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fillActivity();
                fillArt();
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

        }
    }
}
