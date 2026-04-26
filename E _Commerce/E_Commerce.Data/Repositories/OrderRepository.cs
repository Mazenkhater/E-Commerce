using E__Commerce.DataBase;
using E__Commerce.Models;
using E_Commerce.Core.Interfaces.Base;
using E_Commerce.Core.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace E__Commerce.Repositories
{
    //public class OrderRepository : MainRepository<Order>, IOrderRepository
    //{
    //     DataContext =_context;
    //    public OrderRepository(DataContext _context) : base(_context)
    //    {
    //       this._context = _context;
    //    }

    //    public async Task<List<Order>> GetAll()
    //    {
    //        return await GetAll();
    //    }

    //    public async Task<List<Order>> GetOrderWithOrderItems(int customerId)
    //    {
    //        List<Order> orders = await _context.Orders.Where(e => e.Customer_Id == customerId)
    //                                                        .Include(o => o.OrderItems)
    //                                                            .ToListAsync();
    //        return orders;
    //    }

    //    public async Task<Order> GetById(int id)
    //    {
    //        return await GetById(id);
    //    }

    //    public async Task ADD(Order order)
    //    {
    //        await ADD(order);
    //    }

    //    public async Task Update(int id, Order neworder)
    //    {
    //        var oldorder = await _context.Orders.Include(e => e.OrderItems).FirstOrDefaultAsync(e => e.Id == id);
    //        oldorder.TotalPrice = neworder.TotalPrice;
    //        oldorder.Name = neworder.Name;
    //        foreach (var orderr in neworder.OrderItems)
    //        {
    //            oldorder.OrderItems.Add(new OrderItem
    //            {
    //                Id = orderr.Id,
    //                Name = orderr.Name,
    //                Price = orderr.Price,
    //                Quantity = orderr.Quantity,

    //            });
    //            _context.SaveChangesAsync();
    //        }
    //    }
    //    public async Task Delete(int id)
    //    {
    //        await Delete(id);
    //    }
    //}
}
