
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityCafeteria.Data;
using UniversityCafeteria.Models.DatabaseFirst;

namespace UniversityCafeteria.Controllers
{
    public class ProductController : Controller
    {
        private readonly CafeteriaDbContext _context;

        public ProductController(CafeteriaDbContext context)
        {
            _context = context;
        }

        // READ: Display all products
        [HttpGet]
        public IActionResult Index()
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToList();

            return View(products);
        }

        // CREATE GET: Display form
        [HttpGet]
        public IActionResult Create()
        {
            LoadDropdowns();

            return View();
        }

        // CREATE POST: Save product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            // Navigation properties are not posted
            ModelState.Remove("Category");
            ModelState.Remove("Supplier");

            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            LoadDropdowns();

            return View(product);
        }

        // Fill Category and Supplier dropdown lists
        private void LoadDropdowns()
        {
            ViewBag.Categories = new SelectList(
                _context.Categories.ToList(),
                "Id",
                "Name"
            );

            ViewBag.Suppliers = new SelectList(
                _context.Suppliers.ToList(),
                "Id",
                "Name"
            );
        }
    }
}
