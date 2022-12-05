namespace Discount.Infrastructure.DatabaseQueries;

public static class Query
{
    public static class ProductDiscount
    {
        public static string Create => "INSERT INTO ProductDiscounts (ProductId, Description, Amount) VALUES (@ProductId, @Description, @Amount)";
        public static string Get => "SELECT * from ProductDiscounts WHERE ProductId = @ProductId";
        public static string GetAll => "SELECT * from ProductDiscounts";
        public static string Update => "UPDATE ProductDiscounts SET ProductId=@ProductId, Description=@Description, Amount=@Amount WHERE Id = @Id";
        public static string Delete => "DELETE FROM ProductDiscounts WHERE Id = @Id";
    }
}
