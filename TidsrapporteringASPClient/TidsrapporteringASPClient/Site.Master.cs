using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace TidsrapporteringASPClient
{
    public partial class Site : System.Web.UI.MasterPage
    {
        private LdapAuthentication ldap = new LdapAuthentication();
        private BaseClass baseC = new BaseClass(string.Empty);
        private FormsAuthenticationTicket ticket;
        private ConfigFile cF = new ConfigFile();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ibtnLogo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Session["user"] = string.Empty;
            Response.Redirect(cF.loginPage);
        }
    }
}
