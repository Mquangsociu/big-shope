# Big Shope E-commerce Application

ASP.NET Core MVC e-commerce website with Entity Framework Core and SQL Server.

## Features

- **Home Page**: Displays newest products and promotional products with category list
- **Product Management**: CRUD operations for products
- **Category Management**: CRUD operations for categories  
- **Shopping Cart**: Add products to cart, update quantities, remove items
- **Order Management**: Checkout process and order confirmation
- **Authentication**: ASP.NET Identity for login and registration
- **Responsive UI**: Original W3layouts design preserved

## Requirements

- .NET 8.0 SDK or later
- SQL Server (LocalDB or full SQL Server)
- Visual Studio 2022 or VS Code

## Setup Instructions

### 1. Clone the Repository

```bash
git clone https://github.com/Mquangsociu/big-shope.git
cd big-shope
```

### 2. Update Database Connection String (if needed)

The application is pre-configured to work with **SQL Server Express** or **SQL Server Developer Edition** using Windows Authentication.

**Default Configuration (SQL Server Express - Recommended):**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.\\SQLEXPRESS;Database=BigShopeDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

**For SQL Server Developer Edition:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=BigShopeDb;Integrated Security=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

**For SQL Server with SQL Authentication:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=BigShopeDb;User Id=YOUR_USER;Password=YOUR_PASSWORD;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
}
```

**Note:** The application no longer uses LocalDB to ensure better compatibility with SQL Server Developer/Express editions commonly used in development.

### 3. Create Database

Navigate to the BigShope project directory and run:

```bash
cd BigShope
dotnet ef database update
```

This will create the database and seed it with sample categories and products.

**Optional - Update Product Images (if using existing database):**

If you already have a database from a previous version, you may need to update product image URLs to display correctly. Run the provided SQL script:

```sql
-- In SQL Server Management Studio or your SQL client
-- Navigate to BigShope folder and run: UpdateProductImages.sql
```

Or manually execute:
```bash
sqlcmd -S .\SQLEXPRESS -d BigShopeDb -i UpdateProductImages.sql
```

### 4. Run the Application

```bash
dotnet run
```

Or open `BigShope.sln` in Visual Studio and press F5.

The application will be available at:
- HTTPS: https://localhost:5001
- HTTP: http://localhost:5000

## Default Data

The application seeds the following data:

### Categories
- Electronics
- Fashion
- Home & Garden
- Sports
- Books

### Products
- 4 new products
- 4 promotional products

## Usage

### Customer Features

1. **Browse Products**: Visit home page to see latest and promotional products
2. **View by Category**: Click on categories to filter products
3. **Product Details**: Click on any product to see details
4. **Add to Cart**: Click "Add to Cart" on product pages (requires login)
5. **Checkout**: Review cart and place order

### Admin Features

Access these pages after logging in:

- **Category Management**: `/CategoryManagement`
  - View all categories
  - Create, edit, delete categories

- **Product Management**: `/ProductManagement`
  - View all products
  - Create, edit, delete products

## Technology Stack

- **Framework**: ASP.NET Core 8.0 MVC
- **ORM**: Entity Framework Core 8.0
- **Database**: SQL Server
- **Authentication**: ASP.NET Core Identity
- **Frontend**: HTML, CSS, JavaScript (jQuery)
- **UI Design**: W3layouts template

## Project Structure

```
BigShope/
├── Controllers/          # MVC Controllers
│   ├── HomeController.cs
│   ├── ProductsController.cs
│   ├── AccountController.cs
│   ├── CartController.cs
│   ├── CategoryManagementController.cs
│   └── ProductManagementController.cs
├── Models/              # Entity models and ViewModels
│   ├── Category.cs
│   ├── Product.cs
│   ├── Order.cs
│   ├── OrderDetail.cs
│   ├── CartItem.cs
│   └── ApplicationDbContext.cs
├── Views/               # Razor views
│   ├── Home/
│   ├── Products/
│   ├── Account/
│   ├── Cart/
│   ├── CategoryManagement/
│   ├── ProductManagement/
│   └── Shared/
├── wwwroot/             # Static files
│   ├── css/
│   ├── js/
│   └── images/
└── Migrations/          # EF Core migrations
```

## Key Features Implementation

### Entity Framework & LINQ

All data access uses Entity Framework Core with LINQ queries:

```csharp
// Example: Get new products
var newProducts = await _context.Products
    .Include(p => p.Category)
    .Where(p => p.IsActive && p.IsNew)
    .OrderByDescending(p => p.CreatedDate)
    .Take(8)
    .ToListAsync();
```

### Clean URLs (No .html)

All routes use ASP.NET Core MVC routing without .html extensions:
- `/` - Home page
- `/Products` - Product listing
- `/Products/Details/1` - Product details
- `/Account/Login` - Login page
- `/Cart` - Shopping cart

### Functional Buttons

All buttons and links are functional:
- Category navigation
- Add to cart
- Login/Register
- CRUD operations for admin

## License

Design by W3layouts - Creative Commons Attribution 3.0 Unported
