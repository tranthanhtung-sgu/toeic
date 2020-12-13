using System;

namespace Application.ViewModels.User
{
    public class RegisterRequest
    {
        public string LastName { get; set; }
        
        public string FirstName { get; set; }
        public string Address { get; set; }
        public DateTime Dob {get; set;}
        public string Email {get; set;}
        public string PhoneNumber {get; set;}
        public string UserName { get; set; }
        public string password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}