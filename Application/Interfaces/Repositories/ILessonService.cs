using System.Threading.Tasks;
using Application.ViewModels.Common;
using Application.ViewModels.Lessons;
using Domain.Models;

namespace Application.Interfaces.Repositories
{
  public interface ILessonService : IGenericRepositoryAsync<GuideLine>
  {
        Task<ApiResult<PagedResult<LessonVm>>> GetGuidelinesPaging(GetLessonsRequest request);
        //Task<ApiResult<bool>> CreateLesson(CreateLessonRequest register);
        //Task<ApiResult<bool>> Update(int id, UserUpdateRequest request);
        //Task<ApiResult<UserVm>> GetById(int id);
        //Task<ApiResult<bool>> Delete(int id);
        //Task<ApiResult<bool>> RoleAssign(int id, RoleAssignRequest request);
    }
}