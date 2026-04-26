using E_Commerce.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E__Commerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; } 
        public int Quantity { get; set; }
        public string? Image { get; set; } 

        [ForeignKey("Category")]
        public int Category_Id { get; set; }

        public Category? Category { get; set; }

    }
}
