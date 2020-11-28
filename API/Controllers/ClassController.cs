using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.ViewModels.Class;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassRepositoryAsync _classRepositoryAsync;
        private readonly IMapper _mapper;
        public ClassController(IClassRepositoryAsync classRepositoryAsync, IMapper mapper)
        {
            this._classRepositoryAsync = classRepositoryAsync;
            this._mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ClassCreateModel request)
        {
             var result = _mapper.Map<Class>(request);
             var classes = await _classRepositoryAsync.AddAsync(result);
            return Ok(classes);
        }
    }
}