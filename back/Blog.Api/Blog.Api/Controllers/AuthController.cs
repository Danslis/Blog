using Blog.Api.Models.Request;
using Blog.Domain.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userLoginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var identity = await _userService.GetIdentity(userLoginRequest.Email, userLoginRequest.Password);
            if (identity == null)
            {
                return Unauthorized();
            }
            var token = _userService.GenerateJwt(userLoginRequest.Email, identity.UserId);
            return Ok(new
            {
                Token = token                
            });
        }

    }
}
