using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BigShope.Models;
using Microsoft.EntityFrameworkCore;

namespace BigShope.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.Categories
            .Where(c => c.IsActive)
            .ToListAsync();

        var newProducts = await _context.Products
            .Include(p => p.Category)
            .Where(p => p.IsActive && p.IsNew)
            .OrderByDescending(p => p.CreatedDate)
            .Take(8)
            .ToListAsync();

        var promotionalProducts = await _context.Products
            .Include(p => p.Category)
            .Where(p => p.IsActive && p.IsPromotion)
            .Take(8)
            .ToListAsync();

        ViewBag.Categories = categories;
        ViewBag.NewProducts = newProducts;
        ViewBag.PromotionalProducts = promotionalProducts;

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
