namespace Discount.Infrastructure.DatabaseQueries;

public static class Query
{
    public static class ProductDiscount
    {
        public static string Create => "INSERT INTO ProductDiscount (ProductId, Description, Amount) VALUES (@ProductId, @Description, @Amount)";
        public static string Get => "SELECT * from ProductDiscount WHERE ProductId = @ProductId";
        public static string Update => "UPDATE ProductDiscount SET ProductId=@ProductId, Description=@Description, Amount=@Amount WHERE Id = @Id";
        public static string Delete => "DELETE FROM ProductDiscount WHERE ProductId = @ProductId";
    }
}
