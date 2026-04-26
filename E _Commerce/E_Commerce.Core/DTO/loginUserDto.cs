using System.ComponentModel.DataAnnotations;

namespace E__Commerce.DTO
{
    public class loginUserDto
    {
        [Required]
        public string UserName {  get; set; }
        [Required]
        public string Password { get; set; }
    }
}
