using System.Threading.Tasks;
using Application.ViewModels.User;

namespace Application.System.Users
{
    public interface IUserService
    {
         Task<string> Autheticate(LoginRequest request);
         Task<bool> Register(RegisterRequest register);
    }
}