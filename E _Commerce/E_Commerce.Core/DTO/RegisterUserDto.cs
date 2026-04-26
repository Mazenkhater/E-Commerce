using System.ComponentModel.DataAnnotations;

namespace E__Commerce.DTO
{
    public class RegisterUserDto
    {
        
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
        [Compare("Password") ]
        public string ConfirmPassword { get; set; }
    }
}
