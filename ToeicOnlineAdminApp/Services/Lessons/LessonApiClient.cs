using System;
using System.Threading.Tasks;
using Application.ViewModels.Common;
using Application.ViewModels.Lessons;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ToeicOnlineAdminApp.Services.Lessons
{
    public class LessonApiClient : BaseApiClient, ILessonApiClient
    {
        public LessonApiClient(IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration) : base (httpContextAccessor, configuration)
        {  
        }
        public async Task<ApiResult<PagedResult<LessonVm>>> GetLessonPaging(GetLessonsRequest request)
        {
            var data = await GetAsync<ApiResult<PagedResult<LessonVm>>> (
                $"/api/lesson?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}" +
                $"&keyword={request.Keyword}" +
                $"&levelId={request.levelId}" +
                $"&teacherId={request.teacherId}" +
                $"&categoryId={request.categoryId}");

            return data;

        }
    }
}
