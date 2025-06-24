using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Netronix.API.Models.DTOs;
using Netronix.API.Repositories;

namespace Netronix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);            
            
            if (identityResult.Succeeded)
            {
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                   if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login");
                    }
                }

            }

            return BadRequest("Something went wrong while registering the user. Please try again later.");
        
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] loginDtocs loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Username);
            if (user == null)
            {
                return Unauthorized("Incorrect email");
            }

            var isPasswordValid = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
            {
                return Unauthorized("incorrect password");
            }

            var roles = await userManager.GetRolesAsync(user);
            if (roles == null || !roles.Any())
            {
                return BadRequest("User has no roles assigned.");
            }

            var token = tokenRepository.CreateToken(user, roles.ToList());
            var res = new loginResponseDto
            {
                jwtToken = token
            };
            return Ok("Login successful! "+ token);

        }
    }
}
