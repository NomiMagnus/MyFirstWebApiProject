using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order order);
    }
}