
using Microsoft.AspNetCore.Mvc;
using UniversityCafeteria.Data;
using UniversityCafeteria.Models.DatabaseFirst;

namespace UniversityCafeteria.Controllers
{
    public class SupplierController : Controller
    {
        private readonly CafeteriaDbContext _context;

        public SupplierController(CafeteriaDbContext context)
        {
            _context = context;
        }

        // Display all suppliers
        [HttpGet]
        public IActionResult Index()
        {
            var suppliers = _context.Suppliers.ToList();

            return View(suppliers);
        }

        // Display Create form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Save supplier to database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Suppliers.Add(supplier);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(supplier);
        }
    }
}
