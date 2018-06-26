using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InventoryManagement.Models;
using InventoryManagement.ViewModels;

namespace InventoryManagement.Controllers
{
    public class StockPostingController : Controller
    {
        // Define DBContext Object
        private ApplicationDbContext _context;


        public StockPostingController()
        {
            // Initialize DBContext Object
            _context = new ApplicationDbContext();
        }

        // GET: StockPosting
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnterReferenceOrder(string postingType)
        {

            // Initialize viewModel object
            var viewModel = new EnterOrderViewModel()
            {
                PostingTypeID = postingType,
                OrderID = 0
            };

            return View("EnterOrderForm", viewModel);

        }


        public ActionResult New(EnterOrderViewModel eoViewModel)
        {
            // Define view model object
            var viewModel = new StockPostingViewModel();
            List<StockPosting_Item> spItems = new List<StockPosting_Item>();
            StockPosting_Header spHeader = new StockPosting_Header();
            StockPosting_Item spItem = null;

            switch (eoViewModel.PostingTypeID)
            {
                // Work Order GI
                case ConstantsDefintion.GOOD_ISSUE_WORK_ORDER:

                    // Based on Work order items 
                    var woItems = _context.WO_Items.Where(w => w.WO_HeaderID == eoViewModel.OrderID).ToList();



                    // Based on WO item list, initialize stock posting items

                    foreach (var item in woItems)
                    {
                        spItem = new StockPosting_Item();
                        spItem.MaterialID = item.MaterialID;
                        spItem.Quantity = item.Quantity;

                        spItems.Add(spItem);
                    }

                    // Inistialize stock posting header
                    spHeader.ReferenceOrderID = eoViewModel.OrderID;
                    spHeader.DateCreated = DateTime.Now;
                    spHeader.PostingTypeID = byte.Parse(eoViewModel.PostingTypeID);



                    // Initialize viewModel object

                    viewModel.StockPosting_Header = spHeader;
                    viewModel.StockPosting_Items = spItems;


                    viewModel.Products = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.FinishedProduct).ToList();
                    viewModel.RawMaterials = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.RawMaterial).ToList();

                    viewModel.PostingTypes = _context.PostingTypes.ToList();

                    break;

                // Work Order GR
                case ConstantsDefintion.GOOD_RECEIPT_WORK_ORDER:

                    // Based on Work order Header, initialize stock posting item 
                    var woHeader = _context.WO_Headers.Where(w => w.ID == eoViewModel.OrderID).Single();


                    spItem = new StockPosting_Item();
                    spItem.MaterialID = woHeader.ProductID;
                    spItem.Quantity = woHeader.Quantity;

                    spItems.Add(spItem);


                    // Inistialize stock posting header

                    spHeader.ReferenceOrderID = eoViewModel.OrderID;
                    spHeader.DateCreated = DateTime.Now;
                    spHeader.PostingTypeID = byte.Parse(eoViewModel.PostingTypeID);



                    // Initialize viewModel object

                    viewModel.StockPosting_Header = spHeader;
                    viewModel.StockPosting_Items = spItems;


                    viewModel.Products = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.FinishedProduct).ToList();
                    viewModel.RawMaterials = _context.Materials.Where(m => m.MaterialTypeID == MaterialType.RawMaterial).ToList();

                    viewModel.PostingTypes = _context.PostingTypes.ToList();

                    break;
                default:
                    break;
            }

            return View("StockPostingForm", viewModel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(StockPostingViewModel viewModel)
        {

            // Server side validation
            if (!ModelState.IsValid)
            {
                // The form is not valid -> Return the same form to the user

                return View("viewModel", viewModel);
            }


            // IF FORM IS VALID


            // Add new stock posting record
            if (viewModel.StockPosting_Header.ID == 0)
            {



                // ADD or Deduct the current stock
                foreach (var item in viewModel.StockPosting_Items)
                {
                    // Following material & quantity will be deducted from the current stock
                    int materialID = item.MaterialID;
                    double quantity = item.Quantity;

                    Material material = _context.Materials.Find(materialID);


                    // Work Order Good Issue
                    if (viewModel.StockPosting_Header.PostingTypeID == PostingType.GoodIssue_WorkOrder)
                    {
                        // Deduct the current stock
                        if (material.Quantity < quantity)
                        {
                            // LOW STOCK => TO be implemented (GIVE ERROR MESSAGE)
                        }
                        else
                        {
                            material.Quantity = material.Quantity - quantity;
                        }

                    }
                    // Work Order Good Receipt
                    else if (viewModel.StockPosting_Header.PostingTypeID == PostingType.GoodReceipt_WorkOrder)
                    {
                        // Add to current stock
                        material.Quantity = material.Quantity + quantity;
                    }





                }


                // NEED TO UPDATE ORDER STATUS => To be implemented


                // IMPROVEMENT: Could change view model to save next line code
                viewModel.StockPosting_Header.StockPosting_Items = viewModel.StockPosting_Items;
                _context.StockPosting_Headers.Add(viewModel.StockPosting_Header);
            }
            // Update existing device
            else
            {
                //Will implement
            }

            _context.SaveChanges();

            return RedirectToAction("EnterReferenceOrder", "StockPosting", new { PostingType = viewModel.StockPosting_Header.PostingTypeID });

        }

    }


}