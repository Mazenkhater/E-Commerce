using E__Commerce.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Core.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Customer")]
        public int Customer_Id { get; set; }
        public Customer? Customer { get; set; }
        public List<Product>? Products { get; set; }
    }
}
