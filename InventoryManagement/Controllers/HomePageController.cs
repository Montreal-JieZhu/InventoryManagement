using InventoryManagement.Models;
using InventoryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace InventoryManagement.Controllers
{
    public class HomePageController : Controller
    {
        // Define DBContext Object
        private ApplicationDbContext _context;


        public HomePageController()
        {
            // Initialize DBContext Object
            _context = new ApplicationDbContext();
        }
        // GET: HomePage
        public ActionResult Index()
        {
            double materialQuantity = _context.Materials.Sum(m => m.Quantity);
            double workOrderQuantity = _context.WO_Headers.Sum(w => w.Quantity);
            List<WO_Header> wlist = _context.WO_Headers.Include(w=>w.Product).ToList();
            HomePageViewModel hpview = new HomePageViewModel() { MaterialQuantity = materialQuantity, WorkOrderQuantity = workOrderQuantity, WOList = wlist };
            return View(hpview);
        }
    }
}