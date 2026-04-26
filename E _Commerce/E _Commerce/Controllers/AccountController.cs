using E__Commerce.DTO;
using E_Commerce.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace E__Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(UserManager<AppUser> userManager,IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
        }
        [HttpPost("login")]
        public async Task<IActionResult> login(loginUserDto userDto)
        {
            if (ModelState.IsValid)
            {
             AppUser user = await userManager.FindByNameAsync(userDto.UserName);
                if (user != null)
                {
                  bool found =  await userManager.CheckPasswordAsync(user, userDto.Password);
                    if (found)
                    {
                        var claims =new List < Claim > ();
                        claims.Add(new Claim (ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles =  await userManager.GetRolesAsync(user);
                        foreach (var role in roles) 
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role));
                        }
                        SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jWT:secret"]));
                        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        //create token
                        JwtSecurityToken token = new JwtSecurityToken(
                            issuer: configuration["JWT:validissuer"], //url web api
                            audience: configuration["JWT:validaudience"], //url consumer angular
                            claims:claims,
                            expires: DateTime.UtcNow.AddHours(1),
                            signingCredentials : signingCredentials
                            );
                        return Ok (new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            Exception = token.ValidTo,
                        }
                            
                            
                            );




                    }
                    return Unauthorized();
                }
                return Unauthorized();
            }
            return Unauthorized();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Registration(RegisterUserDto registerUserDto)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.UserName = registerUserDto.Username;
                appUser.Email = registerUserDto.Email;
                appUser.PasswordHash = registerUserDto.Password;
                IdentityResult result =  await userManager.CreateAsync(appUser, registerUserDto.Password);
                if (result.Succeeded)
                {
                    return Ok("Account Add Success");
                }
                else
                {
                    //return BadRequest(result.Errors.FirstOrDefault());
                    foreach (var erroritem in result.Errors)
                    {
                        ModelState.AddModelError("Password", erroritem.Description);
                    }
                }
            }
            return BadRequest();
        }
    }
}
