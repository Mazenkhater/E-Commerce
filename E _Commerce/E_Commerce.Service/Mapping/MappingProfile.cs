using AutoMapper;
using E__Commerce.DTO;
using E__Commerce.Models;
using E_Commerce.Core.Models;

namespace E__Commerce.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategorywithProductDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductsWithCategoryDto>();
            CreateMap<Customer, CustmoerDto>();
            CreateMap<CustmoerDto, Customer>();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderWithOrderItemDto>();


        }
    }
}
