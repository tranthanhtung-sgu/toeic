using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.User
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string password { get; set; }
        public bool isRememberMe { get; set; }
    }
}