using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Core.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal TotalPrice { get; set; }

        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public Customer? Customer { get; set; } = null!;

        public List<OrderItem>? OrderItems { get; set; }
    }
}
