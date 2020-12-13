using System.Threading.Tasks;
using Application.ViewModels.Common;
using Application.ViewModels.User;

namespace Application.System.Users
{
    public interface IUserService
    {
        Task<string> Authenticate(LoginRequest request);
        Task<bool> Register(RegisterRequest register);
        Task<PagedResult<UserVm>> GetUserPaging(GetUserPagingRequest request);
    }
}