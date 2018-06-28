using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InventoryManagement.ViewModels;
using InventoryManagement.Models;

namespace InventoryManagement.Controllers
{
    public class WorkOrderController : Controller
    {
        // Define DBContext Object
        private ApplicationDbContext _context;


        public WorkOrderController()
        {
            // Initialize DBContext Object
            _context = new ApplicationDbContext();
        }


        // GET: WorkOrder
        public ActionResult Index()
        {
            var allWorkOrders = _context.WO_Headers.Include(w => w.Product).Include(w => w.Status).ToList();

            return View(allWorkOrders);
        }

        [Authorize(Roles = "Admin, ProductionDept")]
        public ActionResult ChooseProduct()
        {
            // Initialize viewModel object
            var viewModel = new ChooseProductViewModel()
            {
                SelectedProductID = 0,
                Quantity = 1,
                Products = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.FinishedProduct).ToList()
            };

            return View("ChooseProduct", viewModel);


        }

        [Authorize(Roles = "Admin, ProductionDept")]
        public ActionResult New(ChooseProductViewModel cpViewModel)
        {
            // Inistialize WO items
            List<WO_Item> woItems = new List<WO_Item>();

           
            
            // Get BOM based on selected product id
            var bomHeader = _context.BOM_Headers.Include(b => b.BOM_Items).Where(i => i.ProductID == cpViewModel.SelectedProductID).SingleOrDefault();

            // BOM does not exist
            if (bomHeader == null)
            {
                return View("BOMIsNonExistent");
            }

            // Based on bom item list, initialize wo items

            //foreach (var item in bomHeader.BOM_Items)
            foreach (var item in bomHeader.BOM_Items) 
            {
                WO_Item woItem = new WO_Item();
                woItem.MaterialID = item.MaterialID;
                woItem.Quantity = item.Quantity * cpViewModel.Quantity;
                // FIXME Did NOT SET IN WORK ORDER FORM
                woItem.StatusID = Status.NotStart;   
                woItems.Add(woItem);
            }

            // Inistialize WO Header
            WO_Header woHeader = new WO_Header();
            woHeader.ProductID = cpViewModel.SelectedProductID;
            woHeader.Quantity = cpViewModel.Quantity;
            woHeader.DueDate = DateTime.Now.AddDays(20);
            woHeader.StatusID = Status.NotStart;

            woHeader.Product = _context.Materials.Find(woHeader.ProductID);

            // Initialize viewModel object
            var viewModel = new WorkOrderViewModel()
            {
                WO_Header = woHeader,
                WO_Items = woItems,
                Status = _context.Status.ToList(),
                Products = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.FinishedProduct).ToList(),
                RawMaterials = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.RawMaterial).ToList()

            };
            

            return View("WorkOrderForm", viewModel);

   

        }

        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(WorkOrderViewModel viewModel)
        {
            
            // Server side validation
            if (!ModelState.IsValid)
            {
                // The form is not valid -> Return the same form to the user

                return View("MaterialForm", viewModel);
            }


            // IF FORM IS VALID

            // Add new device
            if (viewModel.WO_Header.ID == 0)
            {

                // IMPROVEMENT: Could change view model to save next line code
                viewModel.WO_Header.WO_Items = viewModel.WO_Items;
                _context.WO_Headers.Add(viewModel.WO_Header);
            }
            // Update existing device
            else
            {
                //Will implement
            }

            _context.SaveChanges();

            return RedirectToAction("index"); 

        }

    }
}