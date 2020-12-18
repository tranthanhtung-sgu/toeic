using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels.Roles;

namespace Application.System.Roles
{
    public interface IRoleService
    {
        Task<List<RoleVm>> GetAll();
    }
}