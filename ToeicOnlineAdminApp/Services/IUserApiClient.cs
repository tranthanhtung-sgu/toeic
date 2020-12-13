using System;
using System.Threading.Tasks;
using Application.ViewModels.Common;
using Application.ViewModels.User;


namespace ToeicOnlineAdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
        Task<PagedResult<UserVm>> GetUserPaging(GetUserPagingRequest request);
        Task<bool> RegisterUser(RegisterRequest register);
    }
}
