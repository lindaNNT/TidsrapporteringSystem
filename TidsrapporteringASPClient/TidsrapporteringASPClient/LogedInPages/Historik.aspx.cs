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
using TidsrapporteringASPClient.Repository;
using System.Collections.Generic;
using System.Web.Services;
using System.IO;

namespace TidsrapporteringASPClient.LogedInPages
{
    public partial class Historik : System.Web.UI.Page
    {
        private FavoritCRUD _Fav = new FavoritCRUD();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}
