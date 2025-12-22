# Database Setup Guide

## Tùy chọn 1: Sử dụng SQL Server (LocalDB - Khuyến nghị)

LocalDB là phiên bản SQL Server nhẹ dành cho phát triển. Nó đã được cấu hình trong `appsettings.json`.

### Cấu hình Connection String (appsettings.json):
```json
{
  "ConnectionStrings": {
    "SqlServerConnection": "Server=(localdb)\\mssqllocaldb;Database=BigShopeDb;Trusted_Connection=true;MultipleActiveResultSets=true;"
  }
}
```

### Các lệnh Entity Framework:

#### Tạo lại database:
```bash
cd d:\big-shope\BigShope
dotnet ef database drop --force
dotnet ef database update
```

#### Chỉ update migrations:
```bash
dotnet ef database update
```

#### Xem migrations:
```bash
dotnet ef migrations list
```

---

## Tùy chọn 2: Sử dụng SQL Server Express/Full Edition

Nếu bạn muốn sử dụng SQL Server chạy trên máy chủ khác, cập nhật connection string:

```json
{
  "ConnectionStrings": {
    "SqlServerConnection": "Server=YOUR_SERVER_NAME;Database=BigShopeDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;"
  }
}
```

Ví dụ:
- `Server=localhost` (SQL Server trên máy cục bộ)
- `Server=DESKTOP-XXXXX\SQLEXPRESS` (SQL Server Express)
- `Server=192.168.1.100` (SQL Server trên máy chủ từ xa)

---

## Database Schema

### Tables:

#### 1. **Categories**
- CategoryId (int, PK)
- Name (nvarchar(100))
- Description (nvarchar(500))
- IsActive (bit)

#### 2. **Products**
- ProductId (int, PK)
- CategoryId (int, FK)
- Name (nvarchar(200))
- Description (nvarchar(1000))
- Price (decimal)
- PromotionalPrice (decimal, nullable)
- ImageUrl (nvarchar(500))
- StockQuantity (int)
- IsNew (bit)
- IsPromotion (bit)
- IsActive (bit)
- CreatedDate (datetime2)

#### 3. **Orders**
- OrderId (int, PK)
- UserId (nvarchar(450))
- OrderDate (datetime2)
- TotalAmount (decimal)
- CustomerName (nvarchar(100))
- ShippingAddress (nvarchar(500))
- PhoneNumber (nvarchar(20))
- Email (nvarchar(100))
- Status (nvarchar(50))

#### 4. **OrderDetails**
- OrderDetailId (int, PK)
- OrderId (int, FK)
- ProductId (int, FK)
- Quantity (int)
- UnitPrice (decimal)
- TotalPrice (decimal)

#### 5. **CartItems**
- CartItemId (int, PK)
- UserId (nvarchar(450))
- ProductId (int, FK)
- Quantity (int)
- AddedDate (datetime2)

#### 6. **AspNetUsers** (ASP.NET Identity)
- Id (nvarchar(450), PK)
- Email
- PasswordHash
- Và các field khác của Identity User

#### 7. **AspNetRoles** (ASP.NET Identity)
- Id (nvarchar(450), PK)
- Name
- Và các field khác của Identity Role

---

## Seeded Data

### Categories (5 mục):
1. Electronics - Các thiết bị điện tử và gadget
2. Fashion - Quần áo và phụ kiện
3. Home & Garden - Đồ trang trí nhà cửa và vườn
4. Sports - Thiết bị thể thao và phụ kiện
5. Books - Sách và tài liệu giáo dục

### Products (8 sản phẩm):
- **New Products (4):**
  1. Smartphone X - $999.99
  2. Designer Bag - $299.99
  3. Modern Lamp - $89.99
  4. Yoga Mat - $49.99

- **Promotional Products (4):**
  5. Laptop Pro - $1499.99 → $1199.99
  6. Winter Jacket - $199.99 → $149.99
  7. Coffee Maker - $249.99 → $199.99
  8. Programming Guide - $59.99 → $39.99

---

## Troubleshooting

### Lỗi: "Server not found"
- Kiểm tra xem SQL Server/LocalDB đã khởi động
- Đối với LocalDB: `sqllocaldb start mssqllocaldb`

### Lỗi: "Connection refused"
- Kiểm tra connection string trong appsettings.json
- Đảm bảo SQL Server service đang chạy

### Lỗi: "Database in use"
- Đóng tất cả các connection khác
- Sử dụng `dotnet ef database drop --force`

### Tạo lại toàn bộ database:
```bash
dotnet ef database drop --force
dotnet ef database update
```

---

## Backup & Restore

### Backup database (LocalDB):
```bash
sqlcmd -S (localdb)\mssqllocaldb -Q "BACKUP DATABASE BigShopeDb TO DISK = 'C:\backup\BigShopeDb.bak'"
```

### Restore database:
```bash
sqlcmd -S (localdb)\mssqllocaldb -Q "RESTORE DATABASE BigShopeDb FROM DISK = 'C:\backup\BigShopeDb.bak'"
```
