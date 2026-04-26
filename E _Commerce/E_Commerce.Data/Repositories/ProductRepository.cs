using E__Commerce.DataBase;
using E__Commerce.Models;
using E_Commerce.Core.Interfaces.Base;
using E_Commerce.Core.Interfaces.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace E__Commerce.Repositories
{
    //public class ProductRepository : MainRepository<Product>, IProductRepository
    //{
    //     DataContext =_context;
    //    public ProductRepository(DataContext _context) : base(_context)
    //    {
    //        this._context = _context;
    //    }

    //    public async Task<List<Product>> GetAll()
    //    {
    //        return await GetAll();
    //    }

    //    public async Task<Product> GetById(int id)
    //    {
    //        return await GetById(id);
    //    }

    //    public async Task<List<Product>> GetProductsByCategoryId(int CategoryId)
    //    {
    //        var products = await _context.Products.Where(e => e.Category_Id == CategoryId)
    //                                              .Include(e => e.Category)
    //                                                   .ToListAsync();
    //        return products;
    //    }

    //    public async Task<Product> GetProductWithCategory(int id)
    //    {
    //        var product = await _context.Products.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
    //        return product;
    //    }

    //    public async Task ADD(Product product, IFormFile file)
    //    {
    //        string filename = null;
    //        if (product.Image != null)
    //        {
    //            filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
    //            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", filename);
    //            using (var stream = new FileStream(path, FileMode.Create))
    //            {
    //                await file.CopyToAsync(stream);
    //            }
    //            product.Image = "/images/" + filename;
    //        }

    //        await ADD(product);
    //    }

    //    public async Task Update(int id, Product newproduct)
    //    {
    //        var oldproduct = await _context.Products.FindAsync(id);
    //        oldproduct.Name = newproduct.Name;
    //        oldproduct.Price = newproduct.Price;
    //        oldproduct.Description = newproduct.Description;
    //        oldproduct.Quantity = newproduct.Quantity;

    //        _context.SaveChangesAsync();

    //    }
    //    public async Task Delete(int id)
    //    {
    //        await Delete(id);
    //    }
    //}
}
