using System.Threading.Tasks;
using Application.System.Users;
using Application.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]LoginRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var resultTokent = await _userService.Authenticate(request);
            if(string.IsNullOrEmpty(resultTokent))
            {
                return BadRequest("Login username or password incorrect");
            }
            return Ok(new {token = resultTokent});

        }
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
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