using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> getProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}