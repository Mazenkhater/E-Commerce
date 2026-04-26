using E__Commerce.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace E__Commerce.DTO
{
    public class ProductsWithCategoryDto
    {
        public int IdProductdto { get; set; }

        public string NameProductdto { get; set; }
        public string DescriptionProductdto { get; set; }
        public decimal PriceProductdto { get; set; }
        public int QuantityProductdto { get; set; }
        public string? ImageProductdto { get; set; }

        public int IdCategorydto { get; set; }
        public int NameCategorydto { get; set; }

    }
}
