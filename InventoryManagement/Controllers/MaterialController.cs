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
    public class MaterialController : Controller
    {

        // Define DBContext Object
        private ApplicationDbContext _context;


        public MaterialController()
        {
            // Initialize DBContext Object
            _context = new ApplicationDbContext();
        }


        // GET: Material
        public ActionResult Index(string searchString)
        {
            // Get all available materials
            var materials = _context.Materials.Include(m => m.MaterialType).ToList(); ;

            // Search material by keyword
            if (!String.IsNullOrWhiteSpace(searchString))
            {
                materials = _context.Materials.Where(m => m.Name.Contains(searchString)).ToList();
            }


            return View(materials);
        }

        public ActionResult New()
        {

            // Initialize viewModel object
            var viewModel = new MaterialFormViewModel()
            {
                Material = new Material(),
                MaterialTypes = _context.MaterialTypes.ToList()
            };

            return View("MaterialForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Material material)
        {
            // Server side validation
            if (!ModelState.IsValid)
            {
                // The form is not valid -> Return the same form to the user
                var viewModel = new MaterialFormViewModel()
                {
                    Material = material,
                    MaterialTypes = _context.MaterialTypes.ToList()
                };

                return View("MaterialForm", viewModel);
            }


            // IF FORM IS VALID

            // Add new device
            if (material.ID == 0)
            {
                _context.Materials.Add(material);
            }
            // Update existing device
            else
            {
                var materialInDB = _context.Materials.Single(m => m.ID == material.ID);

                // Manually update the fields I want
                materialInDB.MaterialCode = material.MaterialCode;
                materialInDB.Name = material.Name;
                materialInDB.Quantity = material.Quantity;
                materialInDB.Price = material.Price;
                materialInDB.MaterialTypeID = material.MaterialTypeID;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Material");

        }

        public ActionResult Edit(int id)
        {
            // Get material by ID
            var materialInDB = _context.Materials.Find(id);

            if (materialInDB == null)
            {
                return HttpNotFound();
            }


            // Initialize viewModel object
            var viewModel = new MaterialFormViewModel()
            {
                Material = materialInDB,
                MaterialTypes = _context.MaterialTypes.ToList()
            };

            return View("MaterialForm", viewModel);
        }

        public ActionResult Delete(int? id)
        {

            var materialInDB = _context.Materials.Find(id);

            if (materialInDB == null)
            {
                return HttpNotFound();
            }

            return View(materialInDB);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var materialInDB = _context.Materials.Find(id);

            _context.Materials.Remove(materialInDB);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}