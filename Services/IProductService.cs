using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> getProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}