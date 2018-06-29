using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;
using InventoryManagement.ViewModels;
using System.Data.Entity;

namespace InventoryManagement.Controllers
{
    public class BOMController : Controller
    {
        // Define DBContext Object
        private ApplicationDbContext _context;


        public BOMController()
        {
            // Initialize DBContext Object
            _context = new ApplicationDbContext();
        }

        // GET: BOM
        public ActionResult Index()
        {

            // Get all available BOM headers
            List<BOM_Header> BOMHeaderList = _context.BOM_Headers.ToList();

            return View(BOMHeaderList);
        }

        [Authorize(Roles = "Admin, ProductionDept")]
        public ActionResult New()
        {
            // Initialize 10(?) BOM Items
            List<BOM_Item> BOM_Items = new List<BOM_Item>();

            for (int i = 0; i < ConstantsDefintion.DEFAULT_TOTAL_ITEMS; i++)
            {
                BOM_Items.Add(new BOM_Item());
            }

            // Initialize viewModel object
            var viewModel = new BOMFormViewModel()
            {
                BOM_Header = new BOM_Header(),
                BOM_Items = BOM_Items,
                Products = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.FinishedProduct).ToList(),
                RawMaterials = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.RawMaterial).ToList()
            };

            return View("BOMForm", viewModel);

        }

        [Authorize(Roles = "Admin, ProductionDept")]
        public ActionResult Details(int id)
        {
            BOM_Header bomHeader = _context.BOM_Headers.Find(id);
            List<BOM_Item> bomItems = _context.BOM_Items.Where(i => i.BOM_HeaderID == bomHeader.ID).ToList();

            // Initialize viewModel object
            var viewModel = new BOMFormViewModel()
            {
                BOM_Header = bomHeader,
                BOM_Items = bomItems,
                Products = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.FinishedProduct).ToList(),
                RawMaterials = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.RawMaterial).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BOMFormViewModel viewModel)
        {
            // Server side validation
            if (!ModelState.IsValid)
            {
                // The form is not valid -> Return the same form to the user
                return View("BOMForm", viewModel);
            }


            // IF FORM IS VALID

            // Add new BOM
            if (viewModel.BOM_Header.ID == 0)
            {
                BOM_Header bomHeader = viewModel.BOM_Header;

                List<BOM_Item> bomItems = new List<BOM_Item>();

                foreach (var item in viewModel.BOM_Items)
                {
                    if (item.MaterialID == 0)
                    {
                        break;
                    }  
                    else
                    {
                        bomItems.Add(item);
                    }
                }


                bomHeader.BOM_Items = bomItems;


                _context.BOM_Headers.Add(bomHeader);
            }
            // Update existing device
            else
            {
                // Will implement
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "BOM");


        }

        // Go to Page is under construction View
        public ActionResult UnderConstruction()
        {
            return View();
        }
    }
}