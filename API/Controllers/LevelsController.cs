﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels.Level;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ILevelRepositoryAsync _levelRepositoryAsync;
        private readonly IMapper _mapper;
        public LevelsController(ILevelRepositoryAsync levelRepositoryAsync, IMapper mapper)
        {
            _levelRepositoryAsync = levelRepositoryAsync;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var levels = await _levelRepositoryAsync.GetAllLevel();
            return Ok(levels);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromQuery]int levelId)
        {
            var levels = await _levelRepositoryAsync.GetByIdAsync(levelId);
            return Ok(levels);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] LevelViewModel request)
        {
             var result = _mapper.Map<Level>(request);
             var levels = await _levelRepositoryAsync.AddAsync(result);
            return Ok(levels);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete (int Id)
        {
            await _levelRepositoryAsync.DeleteById(Id);
            return Ok();
        }
        [HttpPut("level-update/{id}")]
        public async Task<IActionResult> UpdateLevel([FromQuery]int id, LevelViewModel request)
        {
            await _levelRepositoryAsync.UpdateLevel(id,request);
            return Ok();
        }
        
    }
}