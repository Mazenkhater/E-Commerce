using E__Commerce.DataBase;
using E__Commerce.Models;
using E_Commerce.Core.Interfaces.Base;
using E_Commerce.Core.Interfaces.IRepositories;
using E_Commerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace E__Commerce.Repositories
{
//    public class CategoryRepository : MainRepository<Category>, ICategoryRepository
//    {
//        DataContext _context;

//        public CategoryRepository(DataContext _context) : base(_context)
//        {
//            this._context = _context;
//        }
//        public async Task<List<Category>> GetAll()
//        {
//            //List<Category> categories =await mainrepository.GetAll();
//            //return categories;
//            return await GetAll();
//        }
//        public async Task<Category> GetCategoryWithProducts(int id)
//        {
//            Category category = await _context.Categories.Include(e => e.Products).FirstOrDefaultAsync(c => c.Id == id);
//            return category;
//        }

//        public async Task<Category> GetById(int id)
//        {

//            return await GetById(id);
//        }
//        public async Task ADD(Category category)
//        {
//            await ADD(category);
//        }

//        public async Task Update(int id, Category newcategory)
//        {
//            var oldcarteg = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.Id == id);
//            oldcarteg.Name = newcategory.Name;
//            oldcarteg.Products.Clear();
//            foreach (var newpro in newcategory.Products)
//            {
//                oldcarteg.Products.Add(new Product
//                {
//                    Name = newpro.Name,
//                    Price = newpro.Price,
//                    Description = newpro.Description,
//                    Quantity = newpro.Quantity,

//                });
//            }
//            await _context.SaveChangesAsync();
//        }
//        public async Task delete(int id)
//        {
//            delete(id);
//        }
//    }
}
