using AutoMapper;
using E__Commerce.DTO;
using E__Commerce.Models;
using E_Commerce.Core.Interfaces.Base;
using E_Commerce.Core.Interfaces.IRepositories;
using E_Commerce.ServiceLayer.IServiceLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E__Commerce.ServiceLayer
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Product> productrepository;

        public ProductService(IMapper mapper , IRepository<Product> productrepository)
        {
            this.mapper = mapper;
            this.productrepository = productrepository;
        }
        public async Task<ProductDto> GetProductById(int id)
        {
            var product = await productrepository.GetById(id);
            return mapper.Map<ProductDto>(product);
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await productrepository.GetAll();
            return mapper.Map<List<ProductDto>>(products);
        }

        public async Task<ProductsWithCategoryDto> GetProductWithCategory(int Id)
        {
            var Product = (await productrepository.Queryable(p => p.Id == Id, q => q.Include(c => c.Category))).FirstOrDefault();
            return mapper.Map<ProductsWithCategoryDto>(Product);
        }

        public async Task Add(ProductDto productdto)
        {
            var product = mapper.Map<Product>(productdto);
            await productrepository.ADD(product);
        }

        public async Task Update(int id, ProductDto newproductdto)
        {
            var product = mapper.Map<Product>(newproductdto);
            product.Id = id;
            await productrepository.Update(id, product);
        }

        public async Task Delete(int id)
        {
            await productrepository.Delete(id);
        }


    }
}
