-- Update Products to match static web
DELETE FROM Products;

-- Insert new Products to match static web
INSERT INTO Products (Name, Description, Price, PromotionalPrice, ImageUrl, StockQuantity, IsNew, IsPromotion, IsActive, CategoryId, CreatedDate) VALUES
('Lorem ipsum dolor', 'Product 1', 400, 300, '/images/ch.jpg', 100, 1, 0, 1, 14, GETDATE()),
('Lorem ipsum dolor', 'Product 2', 400, 300, '/images/ba.jpg', 100, 1, 0, 1, 14, GETDATE()),
('Lorem ipsum dolor', 'Product 3', 400, 300, '/images/bo.jpg', 100, 1, 0, 1, 14, GETDATE()),
('Lorem ipsum dolor', 'Product 4', 400, 300, '/images/bott.jpg', 100, 1, 0, 1, 15, GETDATE()),
('Lorem ipsum dolor', 'Product 5', 400, 300, '/images/bottle.jpg', 100, 1, 0, 1, 15, GETDATE()),
('Lorem ipsum dolor', 'Product 6', 400, 300, '/images/baa.jpg', 100, 1, 0, 1, 16, GETDATE()),
('Lorem ipsum dolor', 'Featured Product', 500, 300, '/images/wat.jpg', 100, 1, 1, 1, 17, GETDATE());
