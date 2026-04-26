using E__Commerce.Models;
using E_Commerce.Core.Interfaces.Base;

namespace E_Commerce.Core.Interfaces.IRepositories
{
    public interface IOrderRepository:IRepository<Order>
    {
        //Task<List<Order>> GetAllOrders();

        //Task<Order> GetOrderDetailsById(int id);

        //Task<List<Order>> GetOrderByCustomerId(int customerId);

        //Task AddOrderWithOrderItem(Order order);

        //Task Delete(int id);
        Task<List<Order>> GetOrderWithOrderItems(int customerId);
        //Task<Order> GetOrderDetailsById(int id);
        Task Update(int id, Order neworder);
    }
}
