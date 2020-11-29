using System.Threading.Tasks;
using Application.System.Users;
using Application.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("autheticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Autheticate([FromForm]LoginRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var resultTokent = await _userService.Autheticate(request);
            if(string.IsNullOrEmpty(resultTokent))
            {
                return BadRequest("Login username or password incorrect");
            }
            return Ok(new {token = resultTokent});

        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromForm]RegisterRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _userService.Register(request);
            if(!result)
            {
                return BadRequest("Register Unsuccessfull");
            }
            return Ok();
        }
    }
}