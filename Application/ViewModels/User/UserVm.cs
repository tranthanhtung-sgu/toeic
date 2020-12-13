using System;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels.User
{
    public class UserVm
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Address { get; set; }

        [DataType(DataType.Password)]
        public DateTime Dob { get; set; }
    }
}
