using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly ILevelRepositoryAsync _levelRepositoryAsync;
        private readonly IMapper _mapper;
        public LevelController(ILevelRepositoryAsync levelRepositoryAsync, IMapper mapper)
        {
            this._levelRepositoryAsync = levelRepositoryAsync;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var levels = await _levelRepositoryAsync.GetAllAsync();
            return Ok(levels);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery]int levelId)
        {
            var levels = await _levelRepositoryAsync.GetByIdAsync(levelId);
            return Ok(levels);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LevelCreateRequest request)
        {
            // var level = _mapper.Map<LevelCreateRequest>(level);
            // var levels = await _levelRepositoryAsync.AddAsync(request);
            return Ok(levels);
        }
    }
}
