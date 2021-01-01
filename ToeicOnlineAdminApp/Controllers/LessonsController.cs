using System.Threading.Tasks;
using Application.ViewModels.Lessons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ToeicOnlineAdminApp.Services.Category;
using ToeicOnlineAdminApp.Services.Lessons;
using ToeicOnlineAdminApp.Models;
using Application.ViewModels.Category;
using System.Collections.Generic;
using ToeicOnlineAdminApp.Services.Level;
using Application.ViewModels.Common;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToeicOnlineAdminApp.Controllers
{
    public class LessonsController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ILessonApiClient _apiLessonClient;
        private readonly ICategoryApiClient _categoryApiClient;
        private readonly ILevelApiClient _levelApiClient;
        public LessonsController(IConfiguration configuration,
            ILessonApiClient apiLessonClient,
            ICategoryApiClient categoryApiClient,
            ILevelApiClient levelApiClient)
        {
            _apiLessonClient = apiLessonClient;
            _configuration = configuration;
            _categoryApiClient = categoryApiClient;
            _levelApiClient = levelApiClient;
        }

        public async Task<IActionResult> Index(string keyword, int? teacherId,
            int? levelId, int? categoryId, int pageIndex = 1, int pageSize = 5)
        {
            var request = new GetLessonsRequest()
            {
                Keyword = keyword,
                PageIndex = pageIndex,
                PageSize = pageSize,
                teacherId = teacherId,
                levelId = levelId,
                categoryId = categoryId   
            };
            var data = await _apiLessonClient.GetLessonPaging(request);
            if (data.IsSuccessed)
            {
                List<string> levels = new List<string>();
                foreach (var item in data.ResultObj.Items)
                {
                    levels.Add(item.Level);
                }
                ViewBag.Level = levels;

                List<string> categories = new List<string>();
                foreach (var item in data.ResultObj.Items)
                {
                    categories.Add(item.CategoryName);
                }
                ViewBag.Category = categories;
            }
            
            ViewBag.Keyword = keyword;
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(data.ResultObj);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        { 
            
            var resultCategory = await _categoryApiClient.GetAll();
            if (resultCategory != null)
            {
                ViewBag.Category = resultCategory.Select(x => new SelectListItem()
                {
                    Text = x.name,
                    Value = x.Id.ToString()
                });
            }
            var resultLevel = await _levelApiClient.GetAllLevel();
            if (resultLevel != null)
            {
                ViewBag.Level = resultLevel.Select(x => new SelectListItem()
                {
                    Text = x.name,
                    Value = x.Id.ToString()
                });
            }
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] CreateLessonRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _apiLessonClient.CreateLesson(request);
            if (result.ResultObj)
            {
                TempData["result"] = "Thêm mới bài giảng thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm bài giảng thất bại");
            return View(request);
        }
    }
}
