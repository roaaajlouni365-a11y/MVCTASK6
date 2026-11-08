
using Microsoft.AspNetCore.Mvc;
using UniversityCafeteria.Data;
using UniversityCafeteria.Models.DatabaseFirst;

namespace UniversityCafeteria.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CafeteriaDbContext _context;

        public CategoryController(CafeteriaDbContext context)
        {
            _context = context;
        }

        // READ: Display all categories
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }

        // CREATE GET: Display form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE POST: Save category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(category);

                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(category);
        }
    }
}
