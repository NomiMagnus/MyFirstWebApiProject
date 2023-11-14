using Entities;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> getProducts(string? Desc, int? minPrice, int? maxPrice, int?[] categoryIds);
    }
}