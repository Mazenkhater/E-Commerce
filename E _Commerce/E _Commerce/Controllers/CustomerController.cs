using E__Commerce.DTO;
using E__Commerce.ServiceLayer.IServiceLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace E__Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService customerService;
        private readonly IDistributedCache distributedCache;

        public CustomerController(ICustomerService customerService ,IDistributedCache distributedCache )
        {
            this.customerService = customerService;
            this.distributedCache = distributedCache;
        }

        [HttpGet("Getcustomer/{id}", Name = "CustomerDetailsRoute") ]
        public async Task<IActionResult> Getcustomer([FromRoute] int id)
        {
            var customer = await customerService.GetCustomerByIdAsync(id);

            return Ok(customer);
        }
        [HttpGet("Getcustomers")]
        public async Task<IActionResult> Getcustomers()
        {
            string cacheKey = "CustomersList";
            var customerscache = await distributedCache.GetStringAsync(cacheKey);

            if (customerscache != null)      // يعني لو cache مش فاضية
            {
                var customersdto = JsonSerializer.Deserialize<List<CustmoerDto>>(customerscache);
                return Ok(customersdto);
            }
            else // طب لو cache فاضية
            {
                var customersdto = await customerService.GetAllCustomersAsync();
                var serializedData = JsonSerializer.Serialize(customersdto);
                var cacheEntryOptions = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(5))  //البيانات تتشال لو:محدش استخدمها لمدة 5 دقائق
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1)); //البيانات تتشال لو:مر ساعة من وقت تخزينها في الذاكرة
                await distributedCache.SetStringAsync(cacheKey, serializedData, cacheEntryOptions);
                return Ok(customersdto);
            }
            //var customersdto = await customerService.GetAllCustomersAsync();
            //  return Ok(customersdto);
        }
        [HttpGet("GetcustomerbyEmail/{email}")]
        public async Task<IActionResult> GetcustomerbyEmail(string email)
        {
            var customerdto = await customerService.GetCustomerByEmailAsync(email);

            return Ok(customerdto);
        }
        [HttpPost("postcustomer")]
        public async Task<IActionResult> postcustomer([FromBody] CustmoerDto dto)
        {
            if (ModelState.IsValid)
            {
                await customerService.AddCustomerAsync(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            string url = Url.Link("CustomerDetailsRoute", new { id = dto.IdCustmoerdto });
            return Created(url, dto);
        }

        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, CustmoerDto dto)
        {
            if (ModelState.IsValid)
            {
                await customerService.UpdateCustomerAsync(id, dto);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (ModelState.IsValid)
            {
                await customerService.DeleteCustomerAsync(id);

                return StatusCode(StatusCodes.Status204NoContent);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
