using E__Commerce.DTO;
using E__Commerce.ServiceLayer.IServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace E__Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("GetOrder/{id}", Name = "OrderDetailsRoute")]
        public async Task<IActionResult> GetOrder([FromRoute] int id)
        {
            var order = await orderService.GetOrderDetailsAsync(id);
           
            return Ok(order);
        }
        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await orderService.GetAllOrdersAsync();

            return Ok(orders);
        }
        [HttpGet("GetOrderWithOrderItems/{id}")]
        public async Task<IActionResult> GetOrderWithOrderItems(int id)
        {
            var order = await orderService.GetOrderWithOrderItemsAsync(id);

            return Ok(order);
        }
        [HttpPost("Addorder")]
        public async Task<IActionResult> postOrder([FromBody] OrderWithOrderItemDto dto)
        {
            if (ModelState.IsValid)
            {
                await orderService.AddOrderAsync(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            string url = Url.Link("OrderDetailsRoute", new { id = dto.IdOrderdto});
            return Created(url, dto);
        }

        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, OrderWithOrderItemDto dto)
        {
            if (ModelState.IsValid)
            {
                await orderService.UpdateOrderAsync(id, dto);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("DeleteOrder/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (ModelState.IsValid)
            {
                await orderService.DeleteOrderAsync(id);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
