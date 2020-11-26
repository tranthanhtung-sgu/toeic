using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class Teacher : IdentityUser<int>
    {
        public string description { get; set; }
        public string photo { get; set; }
        public List<Class> Classes { get; set; }
    }
}