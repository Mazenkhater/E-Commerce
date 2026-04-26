using E__Commerce.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Core.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Quantity { get; set; }

        public decimal Price { get; set; }

        [ForeignKey("Order")]
        public int Order_Id { get; set; }
        public Order? Order { get; set; }

        [ForeignKey("Product")]
        public int Product_Id { get; set; }
        public Product? Product { get; set; }
    }
}
