CREATE TABLE ProductDiscounts(
	ID SERIAL PRIMARY KEY			NOT NULL,
	ProductId		UUID	NOT NULL,
	Description		TEXT,
	Amount			NUMERIC
);

INSERT INTO ProductDiscounts(ProductId, Description, Amount) VALUES ('9483cd43-80be-4927-9c45-5e8bf9ad9794', 'IPhone X Discount', 150);
INSERT INTO ProductDiscounts(ProductId, Description, Amount) VALUES ('79a9aeb0-fc1e-4225-9f41-f162a2f88e4d', 'Samsung 10 Discount', 100);