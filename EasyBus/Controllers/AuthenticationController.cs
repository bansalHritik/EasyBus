using EasyBus.Data.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EasyBus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public AuthenticationController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody]UserRegistrationModel user)
        {
            var userInDB = await userManager.FindByNameAsync(user.Username);
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
            return Ok();
        }
    }
}
