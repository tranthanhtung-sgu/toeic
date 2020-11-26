using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Infrastructure.Repositories;
using System.Threading.Tasks;

namespace mvcMovie.Controllers
{   
    // [Route("api/v{version:apiVersion}/[Controller]")]
    // [ApiVersion("1.0")]
    // [ApiController]
    public class HomeController : Controller
    {
        private readonly IClassRepositoryAsync classRepositoryAsync;

        public HomeController(IClassRepositoryAsync classRepositoryAsync)
        {
            this.classRepositoryAsync = classRepositoryAsync;
        }

        // public IActionResult Index()
        // {
        //     var classes = classRepositoryAsync.GetAllAsync();
        //     return View(classes);
        // }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var classes = await classRepositoryAsync.GetAllAsync();
            return Ok(classes);
        }
        public async Task<IActionResult> Index()
        {
            var classes =  await classRepositoryAsync.GetAllAsync();
            return View(classes);
        }
        
    }
}