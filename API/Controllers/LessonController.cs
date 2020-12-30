using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.ViewModels.Lessons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] GetLessonsRequest request)
        {
            var lessons = await _lessonService.GetGuidelinesPaging(request);
            return Ok(lessons);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] CreateLessonRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _lessonService.CreateLesson(request);
            if (result.ResultObj == 0)
                return BadRequest();

            var lesson = await _lessonService.GetById(result.ResultObj);

            return CreatedAtAction(nameof(GetById), new { id = result.ResultObj }, lesson);
        }

        [HttpGet("{lessonId}")]
        public async Task<IActionResult> GetById(int lessonId)
        {
            var lesson = await _lessonService.GetById(lessonId);
            if (lesson == null)
                return BadRequest("Cannot find Lesson");
            return Ok(lesson);
        }
    }
}
