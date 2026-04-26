using E__Commerce.DTO;
using E__Commerce.Models;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.ServiceLayer.IServiceLayer
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllProducts();

        Task<ProductDto> GetProductById(int id);

        Task<ProductsWithCategoryDto> GetProductWithCategory(int Id);

      //  Task<List<Product>> GetProductsByCategoryId(int CategoryId);

        Task Add(ProductDto productdto);

        Task Update(int id, ProductDto newproductdto);

        Task Delete(int id);
    }
}
