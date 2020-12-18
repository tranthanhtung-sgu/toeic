using System;
using System.Threading.Tasks;
using Application.ViewModels.Common;
using Application.ViewModels.User;


namespace ToeicOnlineAdminApp.Services.User
{
    public interface IUserApiClient
    {
        Task<ApiResult<string>> Authenticate(LoginRequest request);
        Task<ApiResult<PagedResult<UserVm>>> GetUserPaging(GetUserPagingRequest request);
        Task<ApiResult<bool>> RegisterUser(RegisterRequest register);
        Task<ApiResult<UserVm>> GetById(int id);
        Task<ApiResult<bool>> UpdateUser(int id, UserUpdateRequest request);
        Task<ApiResult<bool>> Delete(int id);
        Task<ApiResult<bool>> RoleAssign(int id, RoleAssignRequest request);
    }
}
