using Catalog.Domain.Abstractions.Repositories;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Contexts;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Repositories;

internal class ProductsRepository : RepositoryBase, IProductsRepository
{
    public ProductsRepository(ICatalogContext catalogContext) : base(catalogContext)
    {
    }

    public async Task CreateProductAsync(Product product)
    {
        await _catalogContext.Products.InsertOneAsync(product).ConfigureAwait(false);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

        var result = await _catalogContext.Products.DeleteOneAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _catalogContext.Products.Find(prop => true).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetAllByCategoryAsync(string categoryName)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Category, categoryName);
        return await _catalogContext.Products.Find(filter).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetAllByProductNameAsync(string productName)
    {
        var filter = Builders<Product>.Filter.Eq(p => p.Name, productName);
        return await _catalogContext.Products.Find(filter).ToListAsync();
    }

    public async Task<Product> GetByIdAsync(Guid id)
    {
        return await _catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var result = await _catalogContext.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }
}
