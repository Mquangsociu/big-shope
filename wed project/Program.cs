using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using wed_project.Data;

var builder = WebApplication.CreateBuilder(args);

// ===== SERVICES =====
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=bigshope.db";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();


builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// ===== MIDDLEWARE =====
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 👉 SESSION PHẢI SAU UseRouting
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

// ===== ROUTING =====
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
