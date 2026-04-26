using E_Commerce.Core.DTO;

namespace E__Commerce.DTO
{
    public class OrderWithOrderItemDto
    {
        public int IdOrderdto { get; set; }

        public decimal TotalPriceOrderdto { get; set; }

        public int IdOrderItemDto { get; set; }

        public List<OrderItemDto>? OrderItemsdto { get; set; }
    }
}
