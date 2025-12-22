using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BigShope.Models;
using Microsoft.EntityFrameworkCore;

namespace BigShope.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _context;

        public BaseController(ApplicationDbContext context)
        {
            _context = context;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            // Load footer categories
            var categories = await _context.Categories
                .Where(c => c.IsActive)
                .Take(12)
                .ToListAsync();
            
            ViewBag.FooterCategories = categories;

            await next();
        }
    }
}
