using Microsoft.AspNetCore.Mvc;

namespace project2.Controllers
{
    public class CategoryController : Controller
    {
        public class CheckoutController : Controller
        {
            private readonly HomeDecorDbContext _context;
            public CheckoutController(HomeDecorDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IActionResult Index(int userId)
            {
                var cart = _context.Carts.Include(c => c.Product)
                                         .Where(c => c.UserId == userId)
                                         .ToList();
                return View(cart);
            }

            [HttpPost]
            public IActionResult PlaceOrder(int userId)
            {
                var cart = _context.Carts.Include(c => c.Product).Where(c => c.UserId == userId).ToList();
                if (!cart.Any()) return RedirectToAction("Index", "Cart", new { userId = userId });

                var order = new Order { UserId = userId, Status = "Pending", OrderDate = DateTime.Now };
                _context.Orders.Add(order);
                _context.SaveChanges();

                foreach (var item in cart)
                {
                    _context.OrderItems.Add(new OrderItem
                    {
                        OrderId = order.Id,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Product.Price
                    });
                }

                _context.Carts.RemoveRange(cart);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
        }
    }