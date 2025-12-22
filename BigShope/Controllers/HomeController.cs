using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BigShope.Models;
using Microsoft.EntityFrameworkCore;

namespace BigShope.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context) : base(context)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var categories = await _context.Categories
            .Where(c => c.IsActive)
            .ToListAsync();

        var newProducts = await _context.Products
            .Include(p => p.Category)
            .Where(p => p.IsActive)
            .OrderByDescending(p => p.CreatedDate)
            .Take(6)
            .ToListAsync();

        ViewBag.Categories = categories;
        ViewBag.NewProducts = newProducts;

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
