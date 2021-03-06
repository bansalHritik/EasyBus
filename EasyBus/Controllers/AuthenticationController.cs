using EasyBus.Configuration;
using EasyBus.Data.Contexts;
using EasyBus.Models;
using EasyBus.Shared.Infrastructure.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
        private readonly RoleManager<IdentityRole> RoleManager;

        public AuthenticationController(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            RoleManager = roleManager;
        }

        [HttpPost("Signup")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationModel user)
        {
            return await NewUser(user, new List<string>());
        }

        [HttpPost("new/admin")]
        [Authorize(Roles = UserRoles.ADMIN)]
        public async Task<IActionResult> NewAdmin([FromBody] UserRegistrationModel user)
        {
            return await NewUser(user, new List<string> { UserRoles.ADMIN });
        }

        [HttpPost("new/operator")]
        [Authorize(Roles = UserRoles.OPERATOR)]
        public async Task<IActionResult> NewOperator([FromBody] UserRegistrationModel user)
        {
            return await NewUser(user, new List<string> { UserRoles.OPERATOR });
        }

        private async Task<IActionResult> NewUser(UserRegistrationModel user, IEnumerable<string> roles)
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

            string token = GenerateToken(newUser, new List<string>());

            return Ok(new AuthenticationResponse
            {
                Successful = true,
                Token = token,
            });
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
            IEnumerable<string> roles = await userManager.GetRolesAsync(userInDb);

            string token = GenerateToken(userInDb, roles);

            return Ok(new AuthenticationResponse
            {
                Successful = true,
                Token = token,
                Roles = roles.ToArray(),
            });
        }

        private string GenerateToken(ApplicationUser user, IEnumerable<string> roles)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);

            var claimsIdentity = new ClaimsIdentity(new[] {
                    new Claim("Id", user.Id),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                });

            foreach (var role in roles)
            {
                claimsIdentity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);
            return jwtToken;
        }
    }
}