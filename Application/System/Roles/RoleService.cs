using Application.System.Roles;
using Application.ViewModels.Roles;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.System.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<List<RoleVm>> GetAll()
        {
            var x = await _roleManager.RoleExistsAsync("Admin");
            if (!x)
            {
                var role = new Role();
                role.Name = "Admin";
                await _roleManager.CreateAsync(role);
            }
            x = await _roleManager.RoleExistsAsync("Teacher");
            if (!x)
            {
                var role = new Role();
                role.Name = "Teacher";
                await _roleManager.CreateAsync(role);
            }

            // creating Creating Employee role     
            x = await _roleManager.RoleExistsAsync("Student");
            if (!x)
            {
                var role = new Role();
                role.Name = "Student";
                await _roleManager.CreateAsync(role);
            }
            var roles = await _roleManager.Roles
                .Select(x => new RoleVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).ToListAsync();

            return roles;
        }
    }
}