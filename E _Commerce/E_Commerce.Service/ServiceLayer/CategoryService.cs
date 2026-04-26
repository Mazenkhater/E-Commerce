using AutoMapper;
using E__Commerce.DTO;
using E__Commerce.Models;
using E__Commerce.ServiceLayer.IServiceLayer;
using E_Commerce.Core.Interfaces.Base;
using E_Commerce.Core.Interfaces.IRepositories;
using E_Commerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace E__Commerce.ServiceLayer
{
    public class CategoryService :ICategoryService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Category> categoryRepository;

        public CategoryService(IMapper mapper,IRepository<Category> categoryRepository)
        {
            this.mapper = mapper;
            this.categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
          var categories= await categoryRepository.GetAll();
            var categoriesdto = mapper.Map<List<CategoryDto>>(categories);
            return categoriesdto;

        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
             var cacategory= await categoryRepository.GetById(id);
            var categorydto = mapper.Map<CategoryDto>(cacategory);
            return categorydto;
        }

        public async Task<CategorywithProductDto> GetCategoryWithProductsAsync(int id)
        {
            var category =  (await categoryRepository.Queryable(p => p.Id == id, q => q.Include(c => c.Products))).FirstOrDefault();
            var CategorywithProductdto = mapper.Map<CategorywithProductDto>(category);
            return CategorywithProductdto;
        }

        public async Task UpdateCategoryAsync(int id, CategoryDto categoryDto)
        {
            var categorydto = mapper.Map<Category>(categoryDto);
            categorydto.Id = id;
            await categoryRepository.Update(id,categorydto);

        }
        public async Task AddCategoryAsync(CategoryDto categorydto)
        {
            var category = mapper.Map<Category>(categorydto);
            await categoryRepository.ADD(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await categoryRepository.Delete(id);
        }
    }
}
