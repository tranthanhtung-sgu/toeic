using System;
using System.Threading.Tasks;
using Application.ViewModels.Common;
using Application.ViewModels.Lessons;

namespace ToeicOnlineAdminApp.Services.Lessons
{
    public interface ILessonApiClient
    {
        Task<ApiResult<PagedResult<LessonVm>>> GetLessonPaging(GetLessonsRequest request);
        Task<ApiResult<bool>> CreateLesson(CreateLessonRequest request);
    }
}
