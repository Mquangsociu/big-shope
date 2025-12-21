using Microsoft.AspNetCore.Mvc;
using BigShope.Models;
using Microsoft.EntityFrameworkCore;

namespace BigShope.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(ApplicationDbContext context) : base(context)
        {
        }

        // GET: Products (Product listing page)
        public async Task<IActionResult> Index(int? categoryId)
        {
            var categories = await _context.Categories
                .Where(c => c.IsActive)
                .ToListAsync();

            var productsQuery = _context.Products
                .Include(p => p.Category)
                .Where(p => p.IsActive);

            if (categoryId.HasValue && categoryId.Value > 0)
            {
                productsQuery = productsQuery.Where(p => p.CategoryId == categoryId.Value);
                ViewBag.CurrentCategory = await _context.Categories
                    .FirstOrDefaultAsync(c => c.CategoryId == categoryId.Value);
            }

            var products = await productsQuery.ToListAsync();

            ViewBag.Categories = categories;
            return View(products);
        }

        // GET: Products/Details/5 (Product detail page)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.ProductId == id && m.IsActive);

            if (product == null)
            {
                return NotFound();
            }

            // Get related products from the same category
            var relatedProducts = await _context.Products
                .Where(p => p.CategoryId == product.CategoryId && p.ProductId != id && p.IsActive)
                .Take(4)
                .ToListAsync();

            ViewBag.RelatedProducts = relatedProducts;

            return View(product);
        }
    }
}
