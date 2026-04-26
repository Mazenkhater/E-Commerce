using E__Commerce.Models;
using E_Commerce.Core.Interfaces.Base;
using Microsoft.AspNetCore.Http;

namespace E_Commerce.Core.Interfaces.IRepositories
{
    public interface IProductRepository:IRepository<Product>
    {
        //Task<List<Product>> GetAllProducts();

        //Task<Product> GetProductById(int id);

        //Task<Product> GetProductWithCategory(int Id);

        //Task<List<Product>> GetProductsByCategoryId(int CategoryId);

        //Task Add(Product product);

        //Task Delete(int id);
        Task<List<Product>> GetProductsByCategoryId(int CategoryId);
        Task<Product> GetProductWithCategory(int id);
        Task ADD(Product product, IFormFile file);
        Task Update(int id, Product newproduct);


    }
}
