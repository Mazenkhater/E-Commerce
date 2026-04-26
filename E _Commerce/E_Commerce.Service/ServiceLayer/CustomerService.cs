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
    public class CustomerService:ICustomerService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Customer> customerrepository;

        public CustomerService(IMapper mapper, IRepository<Customer> customerrepository)
        {
           this.mapper = mapper;
           this.customerrepository = customerrepository;
        }

        public async Task<List<CustmoerDto>> GetAllCustomersAsync()
        {
            var customers = await customerrepository.GetAll();
            return mapper.Map<List<CustmoerDto>>(customers);
        }

        public async Task<CustmoerDto> GetCustomerByIdAsync(int id)
        {
            var customer = await customerrepository.GetById(id);
            return mapper.Map<CustmoerDto>(customer);
        }

        public async Task<CustmoerDto> GetCustomerByEmailAsync(string email)
        {
           var customer = ( await customerrepository.Queryable(c => c.Email == email)).FirstOrDefault();
            return mapper.Map<CustmoerDto>(customer);
        }

        public async Task AddCustomerAsync(CustmoerDto dto)
        {
            var customer = mapper.Map<Customer>(dto);
            await customerrepository.ADD(customer);
        }

        public async Task UpdateCustomerAsync(int id, CustmoerDto dto)
        {
            var customer = mapper.Map<Customer>(dto);
            customer.Id = id;
            await customerrepository.Update(id,customer);
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await customerrepository.Delete(id);
        }
    }
}
