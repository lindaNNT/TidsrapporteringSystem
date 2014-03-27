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
                    fillProjects();
                    fillCust();
                    fillOrderByCust();
                    fillService();
                    fillActivity();
                    fillArt();
                }
                else
                {
                }
            }
        }

        //private void fillDebit()
        //{
        //    ListItem nej = new ListItem { Value = "false", Text = "Nej" };
        //    ListItem ja = new ListItem { Value = "true", Text = "Ja" };
        //    ddlDebit.Items.Add(nej);
        //    ddlDebit.Items.Add(ja);
        //}

        private void fillActivity()
        {
            ddlAktivitet.Items.Clear();
            string user = Session["user"].ToString();
            List<string> list = new List<string>();
            if (controllOfUsername(user))
            {
                trService.TidsrapporteringServiceClient host = new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient();
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

        private void fillArt()
        {
            ddlArt.Items.Clear();
            string user = Session["user"].ToString();
            List<string> list = new List<string>();
            if (controllOfUsername(user))
            {
                trService.TidsrapporteringServiceClient host = new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient();
                list = host.GetAllProductsByActivity(user, ddlAktivitet.SelectedItem.Text).ToList();
                foreach (string str in list)
                {
                    ListItem li = new ListItem();
                    li.Text = str;
                    li.Value = str;
                    ddlArt.Items.Add(li);
                }
            }
        }

        private void fillProjects()
        {
            ddlProj.Items.Clear();
            string user = Session["user"].ToString();
            List<string> list = new List<string>();
            if (controllOfUsername(user))
            {
                trService.TidsrapporteringServiceClient host = new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient();
                list = host.GetAllProjects(user).ToList();
                foreach (string str in list)
                {
                    ListItem li = new ListItem();
                    li.Text = str;
                    li.Value = str;
                    ddlProj.Items.Add(li);
                }
            }
        }

        private void fillCust()
        {
            ddlKundNamn.Items.Clear();
            string user = Session["user"].ToString();
            List<string> list = new List<string>();
            if (controllOfUsername(user))
            {
                trService.TidsrapporteringServiceClient host = new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient();
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

        private void fillOrderByCust()
        {
            ddlOrder.Items.Clear();
            string user = Session["user"].ToString();
            List<trService.Order> list = new List<trService.Order>();
            if (controllOfUsername(user))
            {
                trService.TidsrapporteringServiceClient host = new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient();
                list = host.GetAllOrdNr(user, ddlKundNamn.SelectedItem.Text).ToList();
                foreach (var str in list)
                {
                    ListItem li = new ListItem();
                    li.Text = str.OrderNo + " " + str.AvtalNr + ": " + str.AvtalNamn;
                    li.Value = str.OrderNo.ToString();
                    ddlOrder.Items.Add(li);
                }
            }
        }

        private void fillService()
        {
            ddlService.Items.Clear();
            string user = Session["user"].ToString();
            List<string> list = new List<string>();
            if (controllOfUsername(user))
            {
                trService.TidsrapporteringServiceClient host = 
                    new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient();

                list = host.GetAllServiceByOrderNr(user, Convert.ToInt32(ddlOrder.SelectedItem.Value)).ToList();
                foreach (string str in list)
                {
                    ListItem li = new ListItem();
                    li.Text = str;
                    li.Value = str;
                    ddlService.Items.Add(li);
                }
            }
        }

        private bool controllOfUsername(string username)
        {
            trService.TidsrapporteringServiceClient host = new TidsrapporteringASPClient.trService.TidsrapporteringServiceClient();
            return host.LogIn(username);
        }

        protected void ddlDebit_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillActivity();
            fillArt();
        }

        protected void ddlAktivitet_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillArt();
        }

        protected void ddlKundNamn_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillOrderByCust();
            fillService();
        }

        protected void ddlOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillService();
        }
    }
}
