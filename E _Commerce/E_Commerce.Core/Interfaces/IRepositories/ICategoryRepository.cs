using E__Commerce.Models;
using E_Commerce.Core.Interfaces.Base;
using E_Commerce.Core.Models;

namespace E_Commerce.Core.Interfaces.IRepositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        //Task<List<Category>> GetAllCategorys();

        //Task<Category> GetCategoryById (int id);

        //Task<Category> GetCategorysWithProducts (int id);

        //Task Add (Category category);

        //Task Delete (int id);
        Task<Category> GetCategoryWithProducts(int id);
        Task Update(int id, Category newcategory);
    }
}
