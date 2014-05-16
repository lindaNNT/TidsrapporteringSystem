using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Web;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            trs.TidsrapporteringServiceClient host = new trs.TidsrapporteringServiceClient();
            bool svar = host.LogIn("linda");

            var custList = host.GetAllCust("linda").ToArray();


            //String path = System.IO.Path.GetFullPath("../../XMLdata/Customer.xml");
            //XmlDocument doc = new XmlDocument();
            //using(FileStream rfs = new FileStream("Customer.xml",FileMode.Open,FileAccess.Read))
            //{
            //    var setting = new XElement("Settings",
            //    new XElement("UseStreemCodec", new XAttribute("value", "false")),
            //    new XElement("SipPort", new XAttribute("value", "5060")),
            //    new XElement("H323Port", new XAttribute("value", "1720"))
            //  );
            //    doc.Save(path);
            //};

            

            //test.Save(path);

            //XDocument doc = new XDocument(
            //    new XDeclaration("1.0", "utf-8", "yes"),

            //    new XComment("Customer XML file"),

            //    new XElement("Costumers",
            //        new XElement("Element",
            //            from el in custList
            //            select new XElement("Customer", new XElement("Name", el),
            //            new XElement("Orders", from ele in host.GetAllOrdNr("linda", Convert.ToInt32(el.Substring(0, el.IndexOf("-") - 1))).ToArray()
            //                                   select new XElement("Order",
            //                                       new XElement("OrderName", (ele.CustNo + ", " + ele.OrderNo + " - " + ele.AvtalNamn)),
            //                                       new XElement("Services", from serv in host.GetAllServiceByOrderNr("linda", ele.OrderNo).ToArray()
            //                                                                select new XElement("Service", serv))
            //                                       ) // Services
            //                ) // Order
            //            ) //Orders
            //        ) // Customer
            //    ) // Element
            //); //Beigner tag
            //doc.Save("Customer.xml");
           
            //Console.WriteLine(doc);
            //Console.Read();

            XDocument doc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),

                new XComment("Customer XML file"),

                new XElement("complete",
                        from el in custList
                        select new XElement("option", el, 
                            new XAttribute("value", el.Substring(0, el.IndexOf("-") - 1))
                            )// option
                ) // complete
            ); //Beigner tag
            doc.Save("Customer.xml");

            Console.WriteLine(doc);
            Console.Read();

        }
    }
}
