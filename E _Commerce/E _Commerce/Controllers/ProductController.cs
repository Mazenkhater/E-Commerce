using E__Commerce.DTO;
using E_Commerce.ServiceLayer.IServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace E__Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet("GetProduct/{id}", Name = "ProductDetailsRoute")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await productService.GetProductById(id);

            return Ok(product);
        }
        [HttpGet("Getproducts")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await productService.GetAllProducts();

            return Ok(products);
        }
        [HttpGet("GetProductWithCategory/{id}")]
        public async Task<IActionResult> GetProductWithCategory(int id)
        {
            var Product = await productService.GetProductWithCategory(id);

            return Ok(Product);
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> postProduct([FromBody] ProductDto dto)
        {
            if (ModelState.IsValid)
            {
                await productService.Add(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            string url = Url.Link("ProductDetailsRoute", new { id = dto.IdProductdto });
            return Created(url, dto);
        }

        [HttpPut("UpdateOrder/{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, ProductDto dto)
        {
            if (ModelState.IsValid)
            {
                await productService.Update(id, dto);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                await productService.Delete(id);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
