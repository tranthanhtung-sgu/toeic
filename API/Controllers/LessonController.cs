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
    }
}
