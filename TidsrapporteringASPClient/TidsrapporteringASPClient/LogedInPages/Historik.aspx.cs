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
            tbEx.Text = "asgia";
        }

        protected void btnTest_Click(object sender, EventArgs e)
        {
            //Favorit fav = _Fav.getFavoritByFavoritID(Convert.ToInt32(tbTest.Text));
            //string svar = _Fav.deleteFavorit(Convert.ToInt32(tbTest.Text));
            //lblTest.Text = "Svar: " + svar;
            var path = String.Format("{0}Repository\\Customer.xml", AppDomain.CurrentDomain.BaseDirectory);

            trService.TidsrapporteringServiceClient host = new trService.TidsrapporteringServiceClient();
            bool svar = host.LogIn("linda");

            var custList = host.GetAllCust("linda").ToArray();
            
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "ISO-8859-1", "yes"),

                new XComment("Customer XML file"),

                new XElement("complete",
                        from el in custList
                        select new XElement("option", el,
                            new XAttribute("value", el.Substring(0,el.IndexOf("-")-1))
                            )// option
                ) // complete
            ); //Beigner tag
            doc.Save(path);

            Console.WriteLine(doc);
            Console.Read();
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void createOrder(string custID)
        {
            trService.TidsrapporteringServiceClient host = new trService.TidsrapporteringServiceClient();
            bool svar = host.LogIn("linda");
            List<trService.Order> orderList = host.GetAllOrdNr("linda", Convert.ToInt32(custID)).ToList();
            
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "ISO-8859-1", "yes"),

                new XComment("Order XML file"),

                new XElement("complete",
                        from el in orderList
                        select new XElement("option", el.OrderNo + " - " + el.AvtalNamn,
                            new XAttribute("value", el.CustNo)
                            )// option
                ) // complete
            ); //Beigner tag
            var path = String.Format("{0}Repository\\Order.xml", AppDomain.CurrentDomain.BaseDirectory);
            doc.Save(path);
        }

        [System.Web.Services.WebMethod()]
        [System.Web.Script.Services.ScriptMethod()]
        public static void createService(string orderID)
        {
            trService.TidsrapporteringServiceClient host = new trService.TidsrapporteringServiceClient();
            bool svar = host.LogIn("linda");
            List<string> serviceList = host.GetAllServiceByOrderNr("linda", Convert.ToInt32(orderID)).ToList();

            XDocument doc = new XDocument(
                new XDeclaration("1.0", "ISO-8859-1", "yes"),

                new XComment("Servie XML file"),

                new XElement("complete",
                        from el in serviceList
                        select new XElement("option", el,
                            new XAttribute("value", el.Substring(0, el.IndexOf("-")-1))
                            )// option
                ) // complete
            ); //Beigner tag
            var path = String.Format("{0}Repository\\TidsrapporteringService.xml", AppDomain.CurrentDomain.BaseDirectory);
            doc.Save(path);
        }
    }
}
