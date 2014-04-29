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

namespace TidsrapporteringASPClient.LogedInPages
{
    public partial class Historik : System.Web.UI.Page
    {
        private FavoritCRUD _Fav = new FavoritCRUD();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //Favorit fav = _Fav.getFavoritByFavoritID(Convert.ToInt32(tbTest.Text));
            string svar = _Fav.deleteFavorit(Convert.ToInt32(tbTest.Text));
            lblTest.Text = "Svar: " + svar; 
        }
    }
}
