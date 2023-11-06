using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyStoreContext _myStoreContext;

        public CategoryRepository(MyStoreContext myStoreContext)
        {
            _myStoreContext = myStoreContext;
        }

        public async Task<IEnumerable<Category>> getAllCategories()
        {
            return await _myStoreContext.Categories.ToListAsync();
        }
    }
}
