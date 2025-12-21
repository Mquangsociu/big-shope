-- Update product image URLs to use existing images in wwwroot/images folder
-- Run this script to fix product images display

USE BigShopeDb;
GO

-- Update New Products
UPDATE Products SET ImageUrl = '/images/si1.jpg' WHERE ProductId = 1; -- Smartphone X
UPDATE Products SET ImageUrl = '/images/ba.jpg' WHERE ProductId = 2;  -- Designer Bag
UPDATE Products SET ImageUrl = '/images/pic.jpg' WHERE ProductId = 3; -- Modern Lamp
UPDATE Products SET ImageUrl = '/images/s1.jpg' WHERE ProductId = 4;  -- Yoga Mat

-- Update Promotional Products
UPDATE Products SET ImageUrl = '/images/si2.jpg' WHERE ProductId = 5; -- Laptop Pro
UPDATE Products SET ImageUrl = '/images/pic2.jpg' WHERE ProductId = 6; -- Winter Jacket
UPDATE Products SET ImageUrl = '/images/bott.jpg' WHERE ProductId = 7; -- Coffee Maker
UPDATE Products SET ImageUrl = '/images/pic3.jpg' WHERE ProductId = 8; -- Programming Guide

GO

-- Verify the updates
SELECT ProductId, Name, ImageUrl FROM Products ORDER BY ProductId;
GO
