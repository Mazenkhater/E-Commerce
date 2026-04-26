using E__Commerce.DTO;

namespace E__Commerce.ServiceLayer.IServiceLayer
{
    public interface IOrderService
    {
        Task<OrderWithOrderItemDto> GetOrderDetailsAsync(int id);
        Task<List<OrderDto>> GetAllOrdersAsync();
        Task<OrderWithOrderItemDto> GetOrderWithOrderItemsAsync(int customerId);
        Task AddOrderAsync(OrderWithOrderItemDto orderDto);
        Task UpdateOrderAsync(int id, OrderWithOrderItemDto orderDto);
        Task DeleteOrderAsync(int id);
    }
}
