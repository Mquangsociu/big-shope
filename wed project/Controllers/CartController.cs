using Microsoft.AspNetCore.Mvc;
using wed_project.Data;
using wed_project.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization; // 👈 THÊM DÒNG NÀY

namespace wed_project.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ADD TO CART → CHUYỂN SANG CHECKOUT
        public IActionResult AddToCart(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var cart = HttpContext.Session.GetString("cart");
            List<Product> cartItems;

            if (cart == null)
            {
                cartItems = new List<Product>();
            }
            else
            {
                cartItems = JsonSerializer.Deserialize<List<Product>>(cart);
            }

            cartItems.Add(product);

            HttpContext.Session.SetString("cart",
                JsonSerializer.Serialize(cartItems));

            return RedirectToAction("Checkout");
        }

        // 🔐 BẮT BUỘC ĐĂNG NHẬP MỚI ĐƯỢC THANH TOÁN
        [Authorize]
        public IActionResult Checkout()
        {
            var cart = HttpContext.Session.GetString("cart");
            List<Product> cartItems = new();

            if (cart != null)
            {
                cartItems = JsonSerializer.Deserialize<List<Product>>(cart);
            }

            return View(cartItems);
        }
    }
}

