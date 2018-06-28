using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class SalesOrderController : Controller
    {
        // GET: SalesOrder
        public ActionResult Index()
        {
            return View();
        }

        // Go to Page is under construction View
        public ActionResult UnderConstruction()
        {
            return View();
        }
    }
}