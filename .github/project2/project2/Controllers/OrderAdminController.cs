using Microsoft.AspNetCore.Mvc;

namespace project2.Controllers
{
    public class OrderAdminController : Controller
    {
        private readonly HomeDecorDbContext _context;
        public OrderAdminController(HomeDecorDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Orders.Include(o => o.User).ToList();
            return View(orders);
        }

        public IActionResult Details(int id)
        {
            var order = _context.Orders
                        .Include(o => o.User)
                        .Include(o => o.OrderItems)
                        .ThenInclude(oi => oi.Product)
                        .FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                order.Status = status;
                _context.SaveChanges();
            }
            return RedirectToAction("Details", new { id = id });
        }
    }
}
