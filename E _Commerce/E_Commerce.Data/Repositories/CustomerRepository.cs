using E__Commerce.DataBase;
using E__Commerce.Models;
using E_Commerce.Core.Interfaces.Base;
using E_Commerce.Core.Interfaces.IRepositories;
using E_Commerce.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace E__Commerce.Repositories
{
    //public class CustomerRepository : MainRepository<Customer>, ICustomerRepository
    //{
    //     DataContext =_context;

    //    public CustomerRepository(DataContext _context) : base(_context)
    //    {
    //          this._context = _context;
    //    }

    //    public async Task<List<Customer>> GetAll()
    //    {
    //        return await GetAll();
    //    }
    //    public async Task<Customer> GetById(int id)
    //    {
    //        return await GetById(id);
    //    }

    //    public async Task<Customer> GetCustomerByEmail(string Email)
    //    {
    //        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Email == Email);
    //        return customer;
    //    }

    //    public async Task ADD(Customer customer)
    //    {
    //        await ADD(customer);
    //    }

    //    public async Task Update(int id, Customer newcustomer)
    //    {
    //        Customer oldcustomer = await GetById(id);
    //        oldcustomer.FirstName = newcustomer.FirstName;
    //        oldcustomer.LastName = newcustomer.LastName;
    //        oldcustomer.PhoneNumber = newcustomer.PhoneNumber;
    //        oldcustomer.Email = newcustomer.Email;
    //        oldcustomer.City = newcustomer.City;
    //    }
    //    public async Task Delete(int id)
    //    {
    //        await Delete(id);
    //    }
    //}
}
