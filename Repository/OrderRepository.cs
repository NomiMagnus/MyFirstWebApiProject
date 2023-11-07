using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MyStoreContext _myStoreContext;

        public OrderRepository(MyStoreContext myStoreContext)
        {
            _myStoreContext = myStoreContext;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _myStoreContext.Orders.AddAsync(order);
            await _myStoreContext.SaveChangesAsync();
            return order;
        }
    }
}
