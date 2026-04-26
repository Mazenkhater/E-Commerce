using AutoMapper;
using E__Commerce.DTO;
using E__Commerce.ServiceLayer.IServiceLayer;
using E_Commerce.Core.Interfaces.Base;
using E_Commerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace E__Commerce.ServiceLayer
{
    public class OrderService:IOrderService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Order> orderRepository;

        public OrderService(IMapper mapper,IRepository<Order> orderRepository)
        {
           this.mapper = mapper;
           this.orderRepository = orderRepository;
        }

        public async Task<List<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await orderRepository.GetAll();
            return mapper.Map<List<OrderDto>>(orders);
        }

        public async Task<OrderWithOrderItemDto> GetOrderWithOrderItemsAsync(int customerId)
        {
            var order = (await orderRepository.Queryable(p=>p.Customer_Id == customerId,e=>e.Include(o=>o.OrderItems))).FirstOrDefault();
            return mapper.Map<OrderWithOrderItemDto>(order);
        }

        public async Task<OrderWithOrderItemDto> GetOrderDetailsAsync(int id)
        {
            var order = await orderRepository.GetById(id);
            return mapper.Map<OrderWithOrderItemDto>(order);
        }

        public async Task AddOrderAsync(OrderWithOrderItemDto orderDto)
        {
            var order = mapper.Map<Order>(orderDto);
            await orderRepository.ADD(order);
        }

        public async Task UpdateOrderAsync(int id, OrderWithOrderItemDto orderDto)
        {
            var order = mapper.Map<Order>(orderDto);
            order.Id = id;
            await orderRepository.Update(id , order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await orderRepository.Delete(id);
        }
    }
}
