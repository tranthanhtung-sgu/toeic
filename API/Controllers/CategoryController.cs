using System;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepositoryAsync _categoryRepositoryAsync;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepositoryAsync categoryRepositoryAsync, IMapper mapper)
        {
            _categoryRepositoryAsync = categoryRepositoryAsync;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryRepositoryAsync.GetAllCategory();
            return Ok(categories);
        }
    }
}
