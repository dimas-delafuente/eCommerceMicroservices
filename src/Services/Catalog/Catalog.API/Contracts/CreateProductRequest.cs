namespace Catalog.API.Contracts;

public sealed record CreateProductRequest(
    string Name,
    string Category,
    string Summary,
    string Description,
    string ImageFile,
    decimal Price,
    string Currency);