using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

namespace TidsrapporteringASPClient
{
    public class Global : System.Web.HttpApplication
    {
        private BaseClass bc = new BaseClass(string.Empty);

        protected void Application_Start(object sender, EventArgs e)
        {
            
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            string id = null;
            var ticket = bc.getTicket();
            if (ticket == null)
            {
                Session["user"] = string.Empty;
            }
            else
            {
                id = ticket.Name;
                Session["user"] = id;
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //Get the url
            string urlAdmin = HttpContext.Current.Request.Url.AbsoluteUri;
            if (urlAdmin != null)
            {
                string[] strs = urlAdmin.Split('/');    //Split to get all the words
                if (strs[strs.Length - 1].Equals("Admin", StringComparison.OrdinalIgnoreCase))  //Check the last word if it's 'Admin'
                {
                    // Finally redirect to the page                
                    System.Web.HttpContext.Current.Response.Redirect("~/Adminlogin.aspx");
                }
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}