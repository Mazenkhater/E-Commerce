using E__Commerce.Models;

namespace E_Commerce.Core.Models
{
    public class Customer
    {
        public int Id { get; set; } 
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string PhoneNumber { get; set; } 
        public string City { get; set; } 
        public string StreetAddress { get; set; }

        public List<Order>? Orders { get; set; }
    }
}
