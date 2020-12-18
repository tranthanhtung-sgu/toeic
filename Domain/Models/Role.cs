using Microsoft.AspNetCore.Identity;
using System;
namespace Domain.Models
{
    public class Role : IdentityRole<int>
    {
        public string Description { get; set; }
    }
}