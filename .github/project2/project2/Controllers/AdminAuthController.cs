using HomeDecor.Data;
using HomeDecor.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeDecor.Controllers
{
    public class AdminAuthController : Controller
    {
        private readonly HomeDecorDbContext _context;
        public AdminAuthController(HomeDecorDbContext context)
        {
            _context = context;
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var admin = _context.AdminUsers.FirstOrDefault(a => a.Username == username && a.Password == password);
            if (admin != null)
            {
                HttpContext.Session.SetString("AdminUser", admin.Username);
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminUser");
            return RedirectToAction("Login");
        }
    }
}
