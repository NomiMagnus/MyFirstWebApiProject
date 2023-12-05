using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStoreContext _myStoreContext;

        public ProductRepository(MyStoreContext myStoreContext)
        {
            _myStoreContext = myStoreContext;
        }
//use PascalCase
        public async Task<List<Product>> getProducts(string? desc, int? minPrice, int? maxPrice, int?[] categoryIds)
        {
                var query = _myStoreContext.Products.Where(product =>
                (desc == null ? (true) : (product.Description.Contains(desc)))
                && ((minPrice == null) ? (true) : (product.Price >= minPrice))
                && ((maxPrice == null) ? (true) : (product.Price <= maxPrice))
                && ((categoryIds.Length == 0) ? (true) : (categoryIds.Contains(product.CategoryId)))
                ).OrderBy(product => product.Price);
                //.Skip((position-1)*skip)
                //.Take(skip);
                Console.WriteLine(query.ToQueryString());
                List<Product> products = await query.ToListAsync();
                return products;
        }
    }
}
