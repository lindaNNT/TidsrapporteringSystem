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

namespace TidsrapporteringClient
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            TidsrapportService.TidsrapporteringServiceClient host =
                new TidsrapportService.TidsrapporteringServiceClient();
            TidsrapportService.User _user = host.GetUser();
            lblText.Text = _user.UserName;
            tb.Text = _user.Password + " " + _user.Group;
        }
    }
}
