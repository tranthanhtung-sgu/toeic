using System;
using System.Threading.Tasks;
using Application.ViewModels.User;

namespace ToeicOnlineAdminApp.Services
{
    public interface IUserApiClient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}
