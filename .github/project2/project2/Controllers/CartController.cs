using HomeDecor.Data;
using HomeDecor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HomeDecor.Controllers
{
    public class CartController : Controller
    {
        private readonly HomeDecorDbContext _context;
        public CartController(HomeDecorDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int userId)
        {
            var cart = _context.Carts.Include(c => c.Product)
                                     .Where(c => c.UserId == userId)
                                     .ToList();
            return View(cart);
        }

        [HttpPost]
        public IActionResult Add(int userId, int productId, int quantity)
        {
            var cartItem = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.ProductId == productId);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                _context.Carts.Add(new Cart { UserId = userId, ProductId = productId, Quantity = quantity });
            }
            _context.SaveChanges();
            return RedirectToAction("Index", new { userId = userId });
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var item = _context.Carts.Find(id);
            if (item != null)
            {
                _context.Carts.Remove(item);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { userId = item.UserId });
        }
    }
}
