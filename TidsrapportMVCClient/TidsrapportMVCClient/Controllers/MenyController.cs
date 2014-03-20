using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace TidsrapportMVCClient.Controllers
{
    public class MenyController : Controller
    {
        //
        // GET: /Meny/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Nav()
        {
            return View();
        }

        public ActionResult Historik()
        {
            return View();
        }

        public ActionResult Oversikt()
        {
            return View();
        }
    }
}
