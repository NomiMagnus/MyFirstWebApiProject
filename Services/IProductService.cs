using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> getProducts(string? Desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}