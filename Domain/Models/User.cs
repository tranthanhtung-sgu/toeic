using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{   
    public class User : IdentityUser<int>
    {   
        public string LastName { get; set; }
        
        public string FirstName { get; set; }
        public string Address { get; set; }
        
        public DateTime birthday {get; set;}
        
    }
}