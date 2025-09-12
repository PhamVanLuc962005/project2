using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using project2.Models;

namespace project2.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeDecorDbContext _context;
        public HomeController(HomeDecorDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.Include(p => p.Category).Take(8).ToList();
            return View(products);
        }

        public IActionResult Category(int id)
        {
            var products = _context.Products.Where(p => p.CategoryId == id).ToList();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Category)
                                           .FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}
