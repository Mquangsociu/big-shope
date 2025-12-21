using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wed_project.Data;
using wed_project.Models;

namespace wed_project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Load latest products for homepage
            var products = await _context.Products
                .Include(p => p.Category)
                .Take(6) // Show 6 latest products on homepage
                .ToListAsync();

            // Load categories for sidebar
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;

            return View(products);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
