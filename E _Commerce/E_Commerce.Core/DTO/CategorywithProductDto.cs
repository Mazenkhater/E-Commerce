using E__Commerce.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E__Commerce.DTO
{
    public class CategorywithProductDto
    {
        public int Idcategorydto { get; set; }

        [Required(ErrorMessage ="Category name is required")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Namecategorydto { get; set; }

        public int IdProductdto { get; set; }

        [Required(ErrorMessage = "product name is required")]
        [MaxLength(50)]
        [MinLength(3)]
        public string Nameproductdto { get; set; }

        [MaxLength(100)]
        public string Descriptionproductdto { get; set; }
        [Range(1000,50000)]
        public decimal Priceproductdto { get; set; }
        [Range(1,100)]
        public int Quantityproductdto { get; set; }
        public IFormFile? Imageproductdto { get; set; }
        
    }
}
