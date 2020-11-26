using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class Student : IdentityUser<int>
    {
        public List<StudentInClass> studentInClasses { get; set; }
        public List<Payment> payments { get; set; }
        
    }
}