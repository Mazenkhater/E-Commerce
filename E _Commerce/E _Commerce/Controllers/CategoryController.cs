using E__Commerce.DTO;
using E__Commerce.Models;
using E__Commerce.ServiceLayer.IServiceLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E__Commerce.ServiceLayer;
using Microsoft.Extensions.Caching.Memory;
namespace E__Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IMemoryCache memoryCache;

        public CategoryController(ICategoryService categoryService,IMemoryCache memoryCache)
        {
            this.categoryService = categoryService;
            this.memoryCache = memoryCache;
        }
        [HttpGet("GetCategory/{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var Categorydto = await categoryService.GetCategoryByIdAsync(id);

            return Ok(Categorydto);
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            string cacheKey = "CategoriesList";
                if (!memoryCache.TryGetValue(cacheKey, out List<CategoryDto> Categoriessto))      // يعني لو cache فاضية 
                {
                    Categoriessto = await categoryService.GetAllCategoriesAsync();
    
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromMinutes(5)) //البيانات تتشال لو:محدش استخدمها لمدة 5 دقائق
                        .SetAbsoluteExpiration(TimeSpan.FromHours(1)); //البيانات تتشال لو:مر ساعة من وقت تخزينها في الذاكرة

                memoryCache.Set(cacheKey, Categoriessto, cacheEntryOptions);
                }
                // var Categoriessto = await categoryService.GetAllCategoriesAsync();

            return Ok(Categoriessto);
        }
        [HttpGet("CategorysWithProducts/{id}", Name = "CategoryDetailsRoute")]
        public async Task<IActionResult> GetCategorysWithProducts( [FromRoute] int id)
        {
            var Categorydto = await categoryService.GetCategoryWithProductsAsync(id);

            return Ok(Categorydto);
        }
        [HttpPost("AddCategorysWithProducts")]
        public async Task<IActionResult> postCategorysWithProducts([FromBody] CategoryDto dto)
        {
            if (ModelState.IsValid)
            {
               await categoryService.AddCategoryAsync(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            string url = Url.Link("CategoryDetailsRoute", new { id = dto.Iddto });
            return Created(url, dto);
        }

        [HttpPut("UpdateCategory/{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute ]int id, CategoryDto dto)
        {
            if (ModelState.IsValid)
            {
                await categoryService.UpdateCategoryAsync(id, dto);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
                if (ModelState.IsValid)
                {
                    await categoryService.DeleteCategoryAsync(id);

                    return StatusCode(StatusCodes.Status204NoContent);
                }
                else
                {
                    return BadRequest(ModelState);
                }
        }
        
    }
}

