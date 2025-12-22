-- =====================================================
-- Big Shope Database - SQL Server Setup Script
-- =====================================================
-- Script này tạo database và các bảng cần thiết

-- 1. Tạo database (nếu chưa tồn tại)
-- IF DB_ID('BigShopeDb') IS NOT NULL
--     DROP DATABASE BigShopeDb;
-- GO
-- CREATE DATABASE BigShopeDb;
-- GO
-- USE BigShopeDb;
-- GO

-- 2. Xem các bảng hiện tại
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo';
GO

-- 3. Xem số lượng categories
SELECT COUNT(*) as 'Total Categories' FROM Categories;
GO

-- 4. Xem số lượng products
SELECT COUNT(*) as 'Total Products' FROM Products;
GO

-- 5. Xem tất cả categories
SELECT * FROM Categories ORDER BY CategoryId;
GO

-- 6. Xem tất cả products
SELECT * FROM Products ORDER BY ProductId;
GO

-- 7. Xem products theo category
SELECT c.Name as 'Category', COUNT(p.ProductId) as 'Product Count'
FROM Categories c
LEFT JOIN Products p ON c.CategoryId = p.CategoryId
GROUP BY c.CategoryId, c.Name
ORDER BY c.CategoryId;
GO

-- 8. Xem products được khuyến mãi
SELECT ProductId, Name, Price, PromotionalPrice, 
       (Price - PromotionalPrice) as 'Discount Amount',
       CAST((Price - PromotionalPrice) / Price * 100 as DECIMAL(5,2)) as 'Discount %'
FROM Products
WHERE PromotionalPrice IS NOT NULL
ORDER BY ProductId;
GO

-- 9. Xem inventory
SELECT ProductId, Name, StockQuantity, 
       CASE 
           WHEN StockQuantity = 0 THEN 'Out of Stock'
           WHEN StockQuantity < 10 THEN 'Low Stock'
           ELSE 'In Stock'
       END as 'Status'
FROM Products
ORDER BY StockQuantity ASC;
GO

-- 10. Xem tất cả các users
SELECT * FROM AspNetUsers;
GO

-- 11. Xem tất cả các orders
SELECT * FROM Orders;
GO

-- 12. Xem database size
EXEC sp_helpdb 'BigShopeDb';
GO

-- =====================================================
-- UTILITY COMMANDS
-- =====================================================

-- Reset identity cho các bảng (nếu cần reset ID)
-- DBCC CHECKIDENT (Categories, RESEED, 0);
-- DBCC CHECKIDENT (Products, RESEED, 0);
-- DBCC CHECKIDENT (Orders, RESEED, 0);
-- GO

-- Xóa tất cả data (thử nghiệm)
-- DELETE FROM CartItems;
-- DELETE FROM OrderDetails;
-- DELETE FROM Orders;
-- DELETE FROM Products;
-- DELETE FROM Categories;
-- GO

-- Kiểm tra foreign key constraints
SELECT 
    CONSTRAINT_NAME,
    TABLE_NAME,
    COLUMN_NAME,
    REFERENCED_TABLE_NAME,
    REFERENCED_COLUMN_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE TABLE_SCHEMA = 'dbo' AND REFERENCED_TABLE_NAME IS NOT NULL;
GO
