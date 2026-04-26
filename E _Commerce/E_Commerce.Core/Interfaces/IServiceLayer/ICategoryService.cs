using E__Commerce.DTO;

namespace E__Commerce.ServiceLayer.IServiceLayer
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesAsync();
        Task<CategoryDto> GetCategoryByIdAsync(int id);
        Task<CategorywithProductDto> GetCategoryWithProductsAsync(int id);
        Task AddCategoryAsync(CategoryDto categoryDto);
        Task UpdateCategoryAsync(int id, CategoryDto categoryDto);
        Task DeleteCategoryAsync(int id);
    }
}
