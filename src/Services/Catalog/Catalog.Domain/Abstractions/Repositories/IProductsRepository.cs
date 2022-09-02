using Catalog.Domain.Entities;

namespace Catalog.Domain.Abstractions.Repositories
{
    public interface IProductsRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllByProductNameAsync(string productName);
        Task<IEnumerable<Product>> GetAllByCategoryAsync(string categoryName);

        Task CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(Product product);
        Task<bool> DeleteAsync(Guid id);
    }
}
