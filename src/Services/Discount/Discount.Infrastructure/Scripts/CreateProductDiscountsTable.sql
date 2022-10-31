CREATE TABLE ProductDiscounts(
	ID SERIAL PRIMARY KEY			NOT NULL,
	ProductId		UUID	NOT NULL,
	Description		TEXT,
	Amount			NUMERIC
);

INSERT INTO ProductDiscounts(ProductId, Description, Amount) VALUES ('6f60bfe0-1582-44b0-b876-b93ae009e1e7', 'IPhone X Discount', 150);
INSERT INTO ProductDiscounts(ProductId, Description, Amount) VALUES ('94a46ddf-6ae1-43f7-9faa-96f9966c183d', 'Samsung 10 Discount', 100);