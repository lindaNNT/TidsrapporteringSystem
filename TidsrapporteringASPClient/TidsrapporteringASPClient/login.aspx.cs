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

namespace TidsrapporteringASPClient
{
    public partial class login : System.Web.UI.Page
    {
        private LdapAuthentication ldap = new LdapAuthentication();
        private BaseClass baseC = new BaseClass("RegularUser");
        private ConfigFile cF = new ConfigFile();
        private Mail mail = new Mail();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"].Equals(null) || Session["user"].Equals(string.Empty))
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                Response.Redirect("~/LogedInPages/Rapportering.aspx");
            }
        }
    }
}