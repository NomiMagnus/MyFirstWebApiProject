using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService

    {
        IProductRepository _productRepository;

        public ProductService(IProductRepository userRepository)
        {
            _productRepository = userRepository;
        }
        public async Task<List<Product>> getProducts(string? Desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
            return await _productRepository.getProducts(Desc, minPrice, maxPrice, categoryIds);
        }
    }
}
