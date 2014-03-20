using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TidsrapportMVCClient.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(FormCollection formCollection)
        {
            TidsrapporteringService.TidsrapporteringServiceClient host = new TidsrapporteringService.TidsrapporteringServiceClient();
            bool login = host.LogIn("linda");
            if (login)
            {
                TidsrapporteringService.Tidsrad tid = host.GetLastTimeLineInsertedForSpecificDate("linda", "20140317");
                
            }
            return RedirectToAction("Index");
        }

        public ActionResult Test()
        {
            TidsrapporteringService.TidsrapporteringServiceClient host = new TidsrapporteringService.TidsrapporteringServiceClient();
            bool login = host.LogIn("linda");
            IEnumerable<TidsrapporteringService.Tidsrad> tid = host.GetAllInsertedTimeLineOnOneDay("linda", "20140317").ToList();

            return View(tid);
        }

        public ActionResult Edit(int id)
        {
            return View(id);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
