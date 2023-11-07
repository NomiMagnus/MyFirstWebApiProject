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

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _myStoreContext.Products.ToListAsync();
        }
    }
}
