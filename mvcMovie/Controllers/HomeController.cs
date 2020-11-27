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
        private readonly ILevelRepositoryAsync levelRepositoryAsync;

        public HomeController(ILevelRepositoryAsync levelRepositoryAsync)
        {
            this.levelRepositoryAsync = levelRepositoryAsync;
        }

        // public IActionResult Index()
        // {
        //     var classes = classRepositoryAsync.GetAllAsync();
        //     return View(classes);
        // }
        
        public async Task<IActionResult> Index()
        {
            var classes =  await levelRepositoryAsync.GetAllAsync();
            return View(classes);
        }
        
    }
}