using EasyBus.Configuration;
using EasyBus.Data.Contexts;
using EasyBus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasyBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JwtConfig _jwtConfig;

        public AuthenticationController(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor)
        {
            this.userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Register([FromBody]UserRegistrationModel user)
        {
            var userInDB = await userManager.FindByEmailAsync(user.Username);
            if (userInDB != null)
            {
                return BadRequest("User already exist");
            }
            ApplicationUser newUser = new ApplicationUser
            {
                Email = user.Email,
                UserName = user.Username,
                SecurityStamp = new Guid().ToString(),
                Name = user.Name,
            };
            var isUserAdded = await userManager.CreateAsync(newUser, user.Password);
            if (!isUserAdded.Succeeded)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            var token = GenerateToken(newUser);
            return Ok(token);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserModel user)
        {
            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                return Unauthorized();
            }
            bool isPasswordCorrect = await userManager.CheckPasswordAsync(userInDb, user.Password);

            if (!isPasswordCorrect)
            {
                return Unauthorized();

            }
            string token = GenerateToken(userInDb);
            return Ok(new AuthenticationResponse {
                Successful= true,
                Token = token,
            });

        }
        private string GenerateToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}