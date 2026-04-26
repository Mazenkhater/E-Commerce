using E__Commerce.Models;
using E_Commerce.Core.Interfaces.Base;
using E_Commerce.Core.Models;

namespace E_Commerce.Core.Interfaces.IRepositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        //Task<List<Customer>> GetAllCustomers();

        //Task <Customer> GetCustomerById(int id);

        //Task<Customer> GetCustomerByEmail(string Email);

        //Task Add(Customer customer);

        //Task Delete(int id);
        Task<Customer> GetCustomerByEmail(string Email);
        Task Update(int id, Customer newcustomer);
    }
}
