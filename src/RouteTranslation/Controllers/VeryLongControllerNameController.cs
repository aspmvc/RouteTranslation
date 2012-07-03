using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RouteTranslation.Controllers
{
    public class VeryLongControllerNameController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AndEvenMoreLonger()
        {
            return View();
        }
    }
}
