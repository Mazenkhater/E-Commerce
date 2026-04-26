
using E__Commerce.DTO;

namespace E__Commerce.ServiceLayer.IServiceLayer
{
    public interface ICustomerService
    {
        Task<List<CustmoerDto>> GetAllCustomersAsync();
        Task<CustmoerDto> GetCustomerByIdAsync(int id);
        Task<CustmoerDto> GetCustomerByEmailAsync(string email);
        Task AddCustomerAsync(CustmoerDto dto);
        Task UpdateCustomerAsync(int id, CustmoerDto dto);
        Task DeleteCustomerAsync(int id);
    }
}

