using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement.Controllers
{
    public class ShowDataController : Controller
    {

        // Define DBContext Object
        private ApplicationDbContext _context;


        public ShowDataController()
        {
            // Initialize DBContext Object
            _context = new ApplicationDbContext();
        }
        // GET: ShowData
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStatisticalData()
        {
            var tempList = (from material in _context.Materials
                            join item in
                        (from it in _context.WO_Items
                         group it by it.MaterialID into materialGroup
                         select new
                         {
                             ID = materialGroup.Key,
                             UsedQuantity = materialGroup.Sum(i => i.Quantity)
                         }) on material.ID equals item.ID into gj
                            from submaterial in gj.DefaultIfEmpty()
                            select new
                            {
                                Name = material.Name,
                                Quantity = material.Quantity,
                                UsedQuantity = submaterial == null ? 0 : submaterial.UsedQuantity
                            }).ToList();
            int size = tempList.Count();
            string[] names = new string[size];
            double[] quantity = new double[size];
            double[] usedquantity = new double[size];

            for (int i = 0; i < size; i++)
            {
                names[i] = tempList.ElementAt(i).Name;
                quantity[i] = tempList.ElementAt(i).Quantity;
                usedquantity[i] = tempList.ElementAt(i).UsedQuantity;
            }
            var tempseries = new[] { new { name = "series-real", data = quantity }, new { name = "series-projection", data = usedquantity } };
            return Json(new { labels = names, series = tempseries }, JsonRequestBehavior.AllowGet);

        }
    }
}